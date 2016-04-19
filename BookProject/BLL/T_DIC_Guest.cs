using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class T_DIC_Guest
    {
        public List<MODEL.T_DIC_Guest> GetAll() {
            List<MODEL.T_DIC_Guest> lst = new List<MODEL.T_DIC_Guest>();
            DAL.T_DIC_Guest dal = new DAL.T_DIC_Guest();
            lst = dal.Get("1=1");
            return lst;
        }

        public bool AddGuest(MODEL.T_DIC_Guest model)
        {
            DAL.T_DIC_Guest dal = new DAL.T_DIC_Guest();
            return dal.Add(model);
        }

        public bool Delete(int uid)
        {
            DAL.T_DIC_Guest dal = new DAL.T_DIC_Guest();
            return dal.Delete(uid);
        }

        public dynamic GetModel(string where)
        {
            DAL.T_DIC_Guest dal = new DAL.T_DIC_Guest();
            return dal.Get(where);
        }

        public bool Update(MODEL.T_DIC_Guest model)
        {
            DAL.T_DIC_Guest dal = new DAL.T_DIC_Guest();
            return dal.Update(model);
        }

        public int GetUserTotalCount(string keywords)
        {
            DAL.T_DIC_Guest dal = new DAL.T_DIC_Guest();
            return dal.GetCount(keywords);
        }

        public List<MODEL.T_DIC_Guest> GetGuestByPage(int PageSize, int PageIndex, string keywords)
        {
            DAL.T_DIC_Guest dal = new DAL.T_DIC_Guest();
            return dal.GetGuestByPage(PageSize,PageIndex,keywords);
        }
    }
}
