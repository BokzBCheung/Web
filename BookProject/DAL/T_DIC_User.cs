using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class T_DIC_User
    {
        public List<MODEL.T_DIC_User> Get(string where)
        {
            List<MODEL.T_DIC_User> lst = new List<MODEL.T_DIC_User>();

            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.215;uid=10jb;pwd=10jb;database=13110033246_Book";
            co.Open();

            SqlCommand cm = new SqlCommand();
            cm.CommandText = "select * from T_DIC_User where " + where;
            cm.Connection = co;

            SqlDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                MODEL.T_DIC_User item = new MODEL.T_DIC_User();
                item.ID = Convert.ToInt32(dr["ID"]);
                item.LoginName = Convert.ToString(dr["LoginName"]);
                item.Pwd = Convert.ToString(dr["Pwd"]);
                item.Phone = Convert.ToString(dr["Phone"]);
                item.LastLoginTime = Convert.ToDateTime(dr["LastLoginTime"]);
                item.VisitCount = Convert.ToInt32(dr["VisitCount"]);
                item.Status = Convert.ToInt32(dr["Status"]);

                lst.Add(item);
            }

            dr.Close();
            co.Close();
            return lst;

        }
        public bool Delete(int uid)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.215;uid=10jb;pwd=10jb;database=13110033246_Book";
            co.Open();

            SqlCommand cm = new SqlCommand();
            cm.CommandText = "delete from t_dic_user where id=@id";
            cm.Parameters.AddWithValue("@id", uid);
            cm.Connection = co;

            int result = cm.ExecuteNonQuery();
            co.Close();
            if (result >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool Add(MODEL.T_DIC_User user)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.215;uid=10jb;pwd=10jb;database=13110033246_Book";
            co.Open();

            SqlCommand cm = new SqlCommand();
            cm.CommandText = "insert into t_dic_user (LoginName,Pwd,Phone,LastLoginTime,VisitCount,Status) values (@LoginName,@Pwd,@Phone,@LastLoginTime,@VisitCount,@Status)";
            cm.Parameters.AddWithValue("@LoginName", user.LoginName);
            cm.Parameters.AddWithValue("@Pwd", "123");
            cm.Parameters.AddWithValue("@Phone", user.Phone);
            cm.Parameters.AddWithValue("@LastLoginTime", System.DateTime.Now);
            cm.Parameters.AddWithValue("@VisitCount", 3);
            cm.Parameters.AddWithValue("@Status", user.Status);
            cm.Connection = co;

            int result = cm.ExecuteNonQuery();
            co.Close();
            if (result >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(MODEL.T_DIC_User model)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.215;uid=10jb;pwd=10jb;database=13110033246_Book";
            co.Open();

            SqlCommand cm = new SqlCommand();
            cm.CommandText = "update t_dic_user set LoginName=@LoginName,Pwd=@Pwd,Phone=@Phone,LastLoginTime=@LastLoginTime,VisitCount=@VisitCount,Status=@Status where id=@ID";
            cm.Parameters.AddWithValue("@ID", model.ID);
            cm.Parameters.AddWithValue("@Pwd", model.Pwd);
            cm.Parameters.AddWithValue("@LoginName", model.LoginName);
            cm.Parameters.AddWithValue("@Phone", model.Phone);
            cm.Parameters.AddWithValue("@LastLoginTime", model.LastLoginTime);
            cm.Parameters.AddWithValue("@VisitCount", model.VisitCount);
            cm.Parameters.AddWithValue("@Status", model.Status);
            cm.Connection = co;

            int result = cm.ExecuteNonQuery();
            co.Close();
            if (result >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<MODEL.T_DIC_User> GetByPage(int PageSize, int PageIndex)
        {
            List<MODEL.T_DIC_User> lst = new List<MODEL.T_DIC_User>();

            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.215;uid=10jb;pwd=10jb;database=13110033246_Book";
            co.Open();

            SqlCommand cm = new SqlCommand();
            cm.CommandText = string.Format("select top {0} * from T_DIC_User where id not in (select top {1} id from t_dic_user)",PageSize,(PageIndex-1)*PageSize);
            cm.Connection = co;

            SqlDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                MODEL.T_DIC_User item = new MODEL.T_DIC_User();
                item.ID = Convert.ToInt32(dr["ID"]);
                item.LoginName = Convert.ToString(dr["LoginName"]);
                item.Pwd = Convert.ToString(dr["Pwd"]);
                item.Phone = Convert.ToString(dr["Phone"]);
                item.LastLoginTime = Convert.ToDateTime(dr["LastLoginTime"]);
                item.VisitCount = Convert.ToInt32(dr["VisitCount"]);
                item.Status = Convert.ToInt32(dr["Status"]);

                lst.Add(item);
            }

            dr.Close();
            co.Close();
            return lst;

        }

        public int GetTotalCount(string where)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.215;uid=10jb;pwd=10jb;database=13110033246_Book";
            co.Open();

            SqlCommand cm = new SqlCommand();
            cm.CommandText = "select count(1) as num from t_dic_user where "+where;
            cm.Connection = co;

            int count =Convert.ToInt32(cm.ExecuteScalar());
            co.Close();

            return count;
        }
    }
}
