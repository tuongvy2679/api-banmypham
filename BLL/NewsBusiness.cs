using BLL.Interfaces;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class NewsBusiness : INewsBusiness
    {
        private INewsRepository _res;
        public NewsBusiness(INewsRepository ItemGroupRes)
        {
            _res = ItemGroupRes;
        }

        public List<NewsModel> GetData()
        {
            return _res.GetDataAll();
        }


        //admin
        public bool Create(NewsModel model)
        {
            return _res.Create(model);
        }
        public bool Update(NewsModel model)
        {
            return _res.Update(model);
        }

        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public NewsModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }

        public List<NewsModel> Search1(int pageIndex, int pageSize, out long total, string tt_name)
        {
            return _res.Search1(pageIndex, pageSize, out total, tt_name);
        }


    }

}
