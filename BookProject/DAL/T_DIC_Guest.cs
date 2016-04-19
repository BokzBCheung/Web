using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class T_DIC_Guest
    {
        public List<MODEL.T_DIC_Guest> Get(string where) {
            List<MODEL.T_DIC_Guest> lst = new List<MODEL.T_DIC_Guest>();

            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.215;uid=10jb;pwd=10jb;database=13110033246_Book";
            co.Open();

            SqlCommand cm = new SqlCommand();
            cm.CommandText = "select * from T_DIC_Guest where " + where;
            cm.Connection = co;

            SqlDataReader dr = cm.ExecuteReader();
            while (dr.Read()) {
                MODEL.T_DIC_Guest item = new MODEL.T_DIC_Guest();
                item.ID = Convert.ToInt32(dr["ID"]);
                item.Coding = Convert.ToString(dr["Coding"]);
                item.NameEntity = Convert.ToString(dr["NameEntity"]);
                item.AddressEntity = Convert.ToString(dr["AddressEntity"]);
                item.Contact = Convert.ToString(dr["Contact"]);
                item.Phone = Convert.ToString(dr["Phone"]);
                item.Account = Convert.ToString(dr["Account"]);
                item.Mail = Convert.ToString(dr["Mail"]);

                lst.Add(item);
            }

            dr.Close();
            co.Close();
            return lst;
            
        }
        public bool Add(MODEL.T_DIC_Guest model)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.215;uid=10jb;pwd=10jb;database=13110033246_Book";
            co.Open();

            SqlCommand cm = new SqlCommand();
            cm.CommandText = "insert into t_dic_guest (Coding,NameEntity,AddressEntity,Contact,Phone,Account,Mail) values (@Coding,@NameEntity,@AddressEntity,@Contact,@Phone,@Account,@Mail)";
            cm.Parameters.AddWithValue("@Coding", model.Coding);
            cm.Parameters.AddWithValue("@NameEntity", model.NameEntity);
            cm.Parameters.AddWithValue("@AddressEntity", model.AddressEntity);
            cm.Parameters.AddWithValue("@Contact", model.Contact);
            cm.Parameters.AddWithValue("@Phone", model.Phone);
            cm.Parameters.AddWithValue("@Account", model.Account);
            cm.Parameters.AddWithValue("@Mail", model.Mail);

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

        public bool Delete(int uid)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.215;uid=10jb;pwd=10jb;database=13110033246_Book";
            co.Open();

            SqlCommand cm = new SqlCommand();
            cm.CommandText = "delete from t_dic_guest where id=@id";
            cm.Parameters.AddWithValue("@id", uid);
            cm.Connection = co;


            int result = cm.ExecuteNonQuery();
            if (result >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool Update(MODEL.T_DIC_Guest model)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.215;uid=10jb;pwd=10jb;database=13110033246_Book";
            co.Open();

            SqlCommand cm = new SqlCommand();
            cm.CommandText = "update t_dic_guest set Coding=@Coding,NameEntity=@NameEntity,AddressEntity=@AddressEntity,Contact=@Contact,Phone=@Phone,Account=@Account,Mail=@Mail where id=@ID";
            cm.Parameters.AddWithValue("Coding", model.Coding);
            cm.Parameters.AddWithValue("NameEntity", model.NameEntity);
            cm.Parameters.AddWithValue("AddressEntity", model.AddressEntity);
            cm.Parameters.AddWithValue("Contact", model.Contact);
            cm.Parameters.AddWithValue("Phone", model.Phone);
            cm.Parameters.AddWithValue("Account", model.Account);
            cm.Parameters.AddWithValue("Mail", model.Mail);
            cm.Parameters.AddWithValue("id", model.ID);
            cm.Connection = co;


            int result = cm.ExecuteNonQuery();
            if (result >= 1)
                return true;
            else
                return false;
        }
        //分页操作
        public List<MODEL.T_DIC_Guest> GetGuestByPage(int PageSize, int PageIndex, string keywords)
        {
            List<MODEL.T_DIC_Guest> lst = new List<MODEL.T_DIC_Guest>();

            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.215;uid=10jb;pwd=10jb;database=13110033246_Book";
            co.Open();

            SqlCommand cm = new SqlCommand();
            cm.CommandText = string.Format("select top {0} * from T_DIC_Guest where id not in (select top {1} id from T_DIC_Guest)" + keywords, PageSize, (PageIndex - 1) * PageSize);
            cm.Connection = co;

            SqlDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                MODEL.T_DIC_Guest item = new MODEL.T_DIC_Guest();
                item.ID = Convert.ToInt32(dr["ID"]);
                item.Coding = Convert.ToString(dr["Coding"]);
                item.NameEntity = Convert.ToString(dr["NameEntity"]);
                item.AddressEntity = Convert.ToString(dr["AddressEntity"]);
                item.Contact = Convert.ToString(dr["Contact"]);
                item.Phone = Convert.ToString(dr["Phone"]);
                item.Account = Convert.ToString(dr["Account"]);
                item.Mail = Convert.ToString(dr["Mail"]);

                lst.Add(item);
            }

            dr.Close();
            co.Close();
            return lst;
        }

        public int GetCount(string keywords)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.215;uid=10jb;pwd=10jb;database=13110033246_Book";
            co.Open();

            SqlCommand cm = new SqlCommand();
            cm.CommandText = "select count(1) as num from T_DIC_Guest where 1=1" + keywords;
            cm.Connection = co;

            int count = Convert.ToInt32(cm.ExecuteScalar());
            co.Close();

            return count;
        }
    }
}
