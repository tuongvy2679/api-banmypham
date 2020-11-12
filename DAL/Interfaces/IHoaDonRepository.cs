using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface IHoaDonRepository
    {
        bool Create(HoaDonModel model);
        List<HoaDonModel> GetDataAll();

        List<HoaDonModel> Search1(int pageIndex, int pageSize, out long total, string ho_ten);

    }
}