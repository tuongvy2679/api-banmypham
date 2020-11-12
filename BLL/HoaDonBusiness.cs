using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class HoaDonBusiness : IHoaDonBusiness
    {
        private IHoaDonRepository _res;
        public HoaDonBusiness(IHoaDonRepository res)
        {
            _res = res;
        }
        public bool Create(HoaDonModel model)
        {
            return _res.Create(model);
        }

        public List<HoaDonModel> GetDataAll()
        {
            return _res.GetDataAll();
        }

        public List<HoaDonModel> Search1(int pageIndex, int pageSize, out long total, string ho_ten)
        {
            return _res.Search1(pageIndex, pageSize, out total, ho_ten);
        }

    }

}