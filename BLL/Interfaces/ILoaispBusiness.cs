using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace BLL.Interfaces
{
    public partial interface ILoaispBusiness
    {
        List<LoaispModel> GetData();


        //admin
        bool Create(LoaispModel model);
        bool Update(LoaispModel model);
        bool Delete(string id);
        LoaispModel GetDatabyID(string id);

        List<LoaispModel> Search1(int pageIndex, int pageSize, out long total, string tenloai);

    }
}
