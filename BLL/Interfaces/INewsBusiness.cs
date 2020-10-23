using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace BLL.Interfaces
{
    public partial interface INewsBusiness
    {
        List<NewsModel> GetData();


        //admin
        bool Create(NewsModel model);
        bool Update(NewsModel model);
        bool Delete(string id);
        NewsModel GetDatabyID(string id);

        List<NewsModel> Search1(int pageIndex, int pageSize, out long total, string tt_name);

    }
}
