using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface ILoaispRepository
    {
        List<LoaispModel> GetDataAll();

        //admin
        bool Create(LoaispModel model);
        bool Delete(string id);
        bool Update(LoaispModel model);

        LoaispModel GetDatabyID(string id);

        List<LoaispModel> Search1(int pageIndex, int pageSize, out long total, string tt_name);

    }
}
