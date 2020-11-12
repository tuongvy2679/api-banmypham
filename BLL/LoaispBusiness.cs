using BLL.Interfaces;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class LoaispBusiness : ILoaispBusiness
    {
        private ILoaispRepository _res;
        public LoaispBusiness(ILoaispRepository ItemGroupRes)
        {
            _res = ItemGroupRes;
        }

        public List<LoaispModel> GetData()
        {
            return _res.GetDataAll();
        }


        //admin
        public bool Create(LoaispModel model)
        {
            return _res.Create(model);
        }
        public bool Update(LoaispModel model)
        {
            return _res.Update(model);
        }

        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public LoaispModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }

        public List<LoaispModel> Search1(int pageIndex, int pageSize, out long total, string tt_name)
        {
            return _res.Search1(pageIndex, pageSize, out total, tt_name);
        }


    }

}
