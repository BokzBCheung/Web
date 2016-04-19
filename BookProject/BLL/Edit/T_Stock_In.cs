using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class T_Stock_In
    {

        public bool Add(Book.Model.T_STOCK_InHead head, List<Book.Model.T_STOCK_InBody> lst)
        {
            Book.DAL.T_STOCK_InHead bllHead = new Book.DAL.T_STOCK_InHead();
            int headid = bllHead.Add(head);

            Book.DAL.T_STOCK_InBody bllBody = new Book.DAL.T_STOCK_InBody();
            foreach (var item in lst)
            {
                item.InHeadID = headid;
                bllBody.Add(item);
            }
            return true;
        }

        public bool EditSave(Book.Model.T_STOCK_InHead head, List<Book.Model.T_STOCK_InBody> lst)
        {
            //更新header
            Book.DAL.T_STOCK_InHead bll = new Book.DAL.T_STOCK_InHead();
            bll.Update(head);

            //更新body:  删除老的

            Book.DAL.T_STOCK_InBody bllBody = new Book.DAL.T_STOCK_InBody();
            bllBody.DeleteByHeadid(head.ID);


            //更新body:  插入新的
            Book.DAL.T_STOCK_InBody dalBody = new Book.DAL.T_STOCK_InBody();
            foreach (var item in lst)
            {
                item.InHeadID = head.ID;
                dalBody.Add(item);
            }

            return true;
        }
    }
}
