using Model;
using System;
using System.Collections.Generic;
using System.Text;


namespace DAL.Interfaces
{
    class INewsRepository
    {
        List<NewsModel> GetDataAll();
    }
}
