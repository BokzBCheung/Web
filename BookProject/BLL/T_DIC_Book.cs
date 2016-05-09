using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class T_DIC_Book
    {
            public List<MODEL.T_DIC_Book> GETALL() {
                List<MODEL.T_DIC_Book> lst = new List<MODEL.T_DIC_Book>();
                DAL.T_DIC_Book dal = new DAL.T_DIC_Book();
                lst = dal.Get("1=1");
                return lst;
            }
            public bool AddBook(MODEL.T_DIC_Book book) {
                if (check(book))
                {
                    DAL.T_DIC_Book dalBook = new DAL.T_DIC_Book();
                    return dalBook.Add(book);
                }
                else {
                    return false;
                }
            }

            private bool check(MODEL.T_DIC_Book book)
            {
                return true;
            }

            public bool Delete(int uid)
            {
                DAL.T_DIC_Book dalBook = new DAL.T_DIC_Book();
                return dalBook.Delete(uid);
            }

            public MODEL.T_DIC_Book GetModel(int uid)
            {
                DAL.T_DIC_Book dalBook = new DAL.T_DIC_Book();
                string where = "ID=" + uid;
                if (dalBook.Get(where).Count >= 1)
                {
                    return dalBook.Get(where)[0];
                }
                else
                {
                    return null;
                }
            }

            public bool Update(MODEL.T_DIC_Book book)
            {
                DAL.T_DIC_Book dal = new DAL.T_DIC_Book();
                bool result = dal.Update(book);
                return result;
            }

            public int GetUserTotalCount(string where)
            {
                DAL.T_DIC_Book dal = new DAL.T_DIC_Book();
                return dal.GetCount(where);
            }


            public List<MODEL.T_DIC_Book> GetBookByPage(int PageSize, int PageIndex,string keywords)
            {
                DAL.T_DIC_Book dal = new DAL.T_DIC_Book();
                return dal.GetListByPage(PageSize,PageIndex,keywords);
            }
    }
}
