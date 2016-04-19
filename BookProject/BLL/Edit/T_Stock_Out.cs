using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class T_Stock_Out
    {
        public bool Add(Book.Model.T_STOCK_OutHead head, List<Book.Model.T_STOCK_OutBody> lst)
        {
            Book.DAL.T_STOCK_OutHead bllHead = new Book.DAL.T_STOCK_OutHead();
            int headid = bllHead.Add(head);

            Book.DAL.T_STOCK_OutBody bllBody = new Book.DAL.T_STOCK_OutBody();
            foreach (var item in lst)
            {
                item.InHeadID = headid;
                bllBody.Add(item);
            }
            return true;
        }

        public bool EditSave(Book.Model.T_STOCK_OutHead head, List<Book.Model.T_STOCK_OutBody> lst)
        {
            //更新header
            Book.DAL.T_STOCK_OutHead bll = new Book.DAL.T_STOCK_OutHead();
            bll.Update(head);

            //更新body:  删除老的

            Book.DAL.T_STOCK_OutBody bllBody = new Book.DAL.T_STOCK_OutBody();
            bllBody.DeleteByHeadID(head.ID);


            //更新body:  插入新的
            Book.DAL.T_STOCK_OutBody dalBody = new Book.DAL.T_STOCK_OutBody();
            foreach (var item in lst)
            {
                item.InHeadID = head.ID;
                dalBody.Add(item);
            }

            return true;
        }
    }
}
