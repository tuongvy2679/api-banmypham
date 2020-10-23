using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface INewsRepository
    {
        List<NewsModel> GetDataAll();

        //admin
        bool Create(NewsModel model);
        bool Delete(string id);
        bool Update(NewsModel model);

        NewsModel GetDatabyID(string id);

        List<NewsModel> Search1(int pageIndex, int pageSize, out long total, string tt_name);

    }
}
