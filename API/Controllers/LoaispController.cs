using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaispController : ControllerBase
    {
        //private readonly IloaispBusiness _loaispBusiness;
        private string _path;
        private ILoaispBusiness _loaispBusiness;
        public LoaispController(ILoaispBusiness bus)
        {
            _loaispBusiness = bus;
        }
        [Route("get_tintuc_new")]
        [HttpGet]
        public List<LoaispModel> get_Tintuc_New()
        {
            return _loaispBusiness.GetData();
        }

        public string SaveFileFromBase64String(string RelativePathFileName, string dataFromBase64String)
        {
            if (dataFromBase64String.Contains("base64,"))
            {
                dataFromBase64String = dataFromBase64String.Substring(dataFromBase64String.IndexOf("base64,", 0) + 7);
            }
            return WriteFileToAuthAccessFolder(RelativePathFileName, dataFromBase64String);
        }
        public string WriteFileToAuthAccessFolder(string RelativePathFileName, string base64StringData)
        {
            try
            {
                string result = "";
                string serverRootPathFolder = _path;
                string fullPathFile = $@"{serverRootPathFolder}\{RelativePathFileName}";
                string fullPathFolder = System.IO.Path.GetDirectoryName(fullPathFile);
                if (!Directory.Exists(fullPathFolder))
                    Directory.CreateDirectory(fullPathFolder);
                System.IO.File.WriteAllBytes(fullPathFile, Convert.FromBase64String(base64StringData));
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [Route("get_loaisp_id/{id}")]
        [HttpGet]
        public LoaispModel GetDatabyID(string id)
        {
            return _loaispBusiness.GetDatabyID(id);
        }


        //admin
        [Route("delete-loaisp")]
        [HttpPost]
        public IActionResult Deleteloaisp([FromBody] Dictionary<string, object> formData)
        {
            string maloai = "";

            if (formData.Keys.Contains("maloai") && !string.IsNullOrEmpty(Convert.ToString(formData["maloai"]))) { maloai = Convert.ToString(formData["maloai"]); }
            _loaispBusiness.Delete(maloai);
            return Ok();
        }



        [Route("create-loaisp")]
        [HttpPost]
        public LoaispModel Createloaisp([FromBody] LoaispModel model)
        {
            if (model.anhloai != null)
            {
                var arrData = model.anhloai.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"assets/images/{arrData[0]}";
                    model.anhloai = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }

            model.maloai = Guid.NewGuid().ToString();

            _loaispBusiness.Create(model);

            return model;
        }


        [Route("update-loaisp")]
        [HttpPost]
        public LoaispModel Updateloaisp([FromBody] LoaispModel model)
        {
            if (model.anhloai != null)
            {
                var arrData = model.anhloai.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"assets/images/{arrData[0]}";
                    model.anhloai = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            _loaispBusiness.Update(model);
            return model;
        }

        [Route("search1")]
        [HttpPost]
        public ResponseModel Search1([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string tenloai = "";
                if (formData.Keys.Contains("tenloai") && !string.IsNullOrEmpty(Convert.ToString(formData["tenloai"]))) { tenloai = Convert.ToString(formData["tenloai"]); }
                long total = 0;
                var data = _loaispBusiness.Search1(page, pageSize, out total, tenloai);
                response.TotalItems = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }
    }
}