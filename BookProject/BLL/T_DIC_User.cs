using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// 实现调用DAL层增删改查，分页方法的书写
    /// </summary>
    public class T_DIC_User
    {
        public List<MODEL.T_DIC_User> GetAll()
        {
            List<MODEL.T_DIC_User> lst = new List<MODEL.T_DIC_User>();
            DAL.T_DIC_User dal = new DAL.T_DIC_User();
            lst = dal.Get("1=1");
            return lst;
        }

        public bool Delete(int uid)
        {
            DAL.T_DIC_User dalUser = new DAL.T_DIC_User();
            return dalUser.Delete(uid);
        }

        public bool AddUser(MODEL.T_DIC_User user)
        {
            DAL.T_DIC_User dal = new DAL.T_DIC_User();
            return dal.Add(user);
        }

        public MODEL.T_DIC_User GetModel(int uid)
        {
            DAL.T_DIC_User dal = new DAL.T_DIC_User();
            string where;
            where = "ID=" + uid;
            MODEL.T_DIC_User model = dal.Get(where)[0];
            return model;
        }

        public bool Update(MODEL.T_DIC_User model)
        {
            DAL.T_DIC_User dal = new DAL.T_DIC_User();
            return dal.Update(model);
        }

        /// <summary>
        /// 分页方法编写
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <returns></returns>
        public List<MODEL.T_DIC_User> GetUserByPage(int PageSize, int PageIndex)
        {
            DAL.T_DIC_User dal = new DAL.T_DIC_User();
            return dal.GetByPage(PageSize,PageIndex);
        }

        public int GetUserTotalCount(string where)
        {
            DAL.T_DIC_User dal = new DAL.T_DIC_User();
            return dal.GetTotalCount(where);
        }
    }
}
