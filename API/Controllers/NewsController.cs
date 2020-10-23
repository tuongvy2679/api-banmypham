

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
    public class NewsController : ControllerBase
    {
        //private readonly INewsBusiness _newsBusiness;
        private string _path;
        private INewsBusiness _newsBusiness;
        public NewsController(INewsBusiness bus)
        {
            _newsBusiness = bus;
        }
        [Route("get_tintuc_new")]
        [HttpGet]
        public List<NewsModel> get_Tintuc_New()
        {
            return _newsBusiness.GetData();
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


        //admin
        [Route("delete-news")]
        [HttpPost]
        public IActionResult DeleteNews([FromBody] Dictionary<string, object> formData)
        {
            string tt_id = "";

            if (formData.Keys.Contains("tt_id") && !string.IsNullOrEmpty(Convert.ToString(formData["tt_id"]))) { tt_id = Convert.ToString(formData["tt_id"]); }
            _newsBusiness.Delete(tt_id);
            return Ok();
        }



        [Route("create-news")]
        [HttpPost]
        public NewsModel CreateNews([FromBody] NewsModel model)
        {
            if (model.tt_image != null)
            {
                var arrData = model.tt_image.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"assets/images/{arrData[0]}";
                    model.tt_image = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }

            model.tt_id = Guid.NewGuid().ToString();

            _newsBusiness.Create(model);

            return model;
        }


        [Route("update-news")]
        [HttpPost]
        public NewsModel UpdateNews([FromBody] NewsModel model)
        {
            if (model.tt_image != null)
            {
                var arrData = model.tt_image.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"assets/images/{arrData[0]}";
                    model.tt_image = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            _newsBusiness.Update(model);
            return model;
        }


    }
}