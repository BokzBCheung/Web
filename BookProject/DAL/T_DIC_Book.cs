using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class T_DIC_Book
    {
        public List<MODEL.T_DIC_Book> Get(string where)
        {

            List<MODEL.T_DIC_Book> lst = new List<MODEL.T_DIC_Book>();

            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.215;uid=10jb;pwd=10jb;database=13110033246_Book";
            //co.ConnectionString = "server=localhost;uid=sa;pwd=;database=13110033246_Book;";
            co.Open();

            SqlCommand cm = new SqlCommand();
            cm.CommandText = "select * from T_DIC_Book where " + where;
            cm.Connection = co;

            SqlDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                MODEL.T_DIC_Book item = new MODEL.T_DIC_Book();
                item.ID = Convert.ToInt32(dr["ID"]);
                item.ISBN = Convert.ToString(dr["ISBN"]);
                item.Name = Convert.ToString(dr["Name"]);
                item.Publisher = Convert.ToString(dr["Publisher"]);
                item.Author = Convert.ToString(dr["Author"]);
                item.Pricing = Convert.ToDecimal(dr["Pricing"]);
                item.PublishYear = Convert.ToDateTime(dr["PublishYear"]);
                item.Notes = Convert.ToString(dr["Notes"]);

                lst.Add(item);

            }
            dr.Close();
            co.Close();

            return lst;
        }
        public bool Add(MODEL.T_DIC_Book book)
        {

            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.215;uid=10jb;pwd=10jb;database=13110033246_Book";
            co.Open();

            SqlCommand cm = new SqlCommand();
            cm.CommandText = "insert into t_dic_book (ISBN,Name,Publisher,Author,Pricing,PublishYear,Notes) values (@ISBN,@Name,@Publisher,@Author,@Pricing,@PublishYear,@Notes)";
            cm.Parameters.AddWithValue("@ISBN", book.ISBN);
            cm.Parameters.AddWithValue("@Name", book.Name);
            cm.Parameters.AddWithValue("@Publisher", book.Publisher);
            cm.Parameters.AddWithValue("@Author", book.Author);
            cm.Parameters.AddWithValue("@Pricing", book.Pricing);
            if (book.PublishYear.Year ==0001 )
                book.PublishYear = System.DateTime.Now;
            cm.Parameters.AddWithValue("@PublishYear", book.PublishYear);
            cm.Parameters.AddWithValue("@Notes", book.Notes);
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
            cm.CommandText = "delete from t_dic_book where id=@id";
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

        //public MODEL.T_DIC_Book GetModel(int uid)
        //{
        //    MODEL.T_DIC_Book model = new MODEL.T_DIC_Book();
        //    SqlConnection co = new SqlConnection();
        //    co.ConnectionString = "server=10.132.239.215;uid=10jb;pwd=10jb;database=13110033246_Book";
        //    co.Open();

        //    SqlCommand cm = new SqlCommand();
        //    cm.CommandText = "select * from t_dic_book where id=@id";
        //    cm.Parameters.AddWithValue("@id", uid);
        //    cm.Connection = co;

        //    SqlDataReader dr = cm.ExecuteReader();
        //    if (dr.Read())
        //    {
        //        MODEL.T_DIC_Book lst = new MODEL.T_DIC_Book();
        //        lst=model.
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        public bool Update(MODEL.T_DIC_Book book)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.215;uid=10jb;pwd=10jb;database=13110033246_Book";
            //co.ConnectionString = "server=10.132.239.215;uid=10jb;pwd=10jb;database=13110033246_Book";
            co.Open();

            SqlCommand cm = new SqlCommand();
            cm.CommandText = "update t_dic_book set ISBN=@ISBN,Name=@Name,Publisher=@Publisher,Author=@Author,Pricing=@Pricing,PublishYear=@PublishYear,Notes=@Notes where ID=@id";
            cm.Parameters.AddWithValue("@ISBN", book.ISBN);
            cm.Parameters.AddWithValue("@Name", book.Name);
            cm.Parameters.AddWithValue("@Publisher", book.Publisher);
            cm.Parameters.AddWithValue("@Author", book.Author);
            cm.Parameters.AddWithValue("@Pricing", book.Pricing);
            if (book.PublishYear.Year == 0001)
                book.PublishYear = System.DateTime.Now;
            cm.Parameters.AddWithValue("@PublishYear", book.PublishYear);
            cm.Parameters.AddWithValue("@Notes", book.Notes);

            cm.Parameters.AddWithValue("@id", book.ID);
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

        public int GetCount(string keywords)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.215;uid=10jb;pwd=10jb;database=13110033246_Book";
            co.Open();

            SqlCommand cm = new SqlCommand();
            cm.CommandText = "select count(1) as num from t_dic_book where 1=1"+keywords;
            cm.Connection = co;

            int count = Convert.ToInt32(cm.ExecuteScalar());
            co.Close();

            return count;
        }

        public List<MODEL.T_DIC_Book> GetListByPage(int PageSize, int PageIndex,string keywords)
        {
            List<MODEL.T_DIC_Book> lst = new List<MODEL.T_DIC_Book>();

            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.215;uid=10jb;pwd=10jb;database=13110033246_Book";
            co.Open();

            SqlCommand cm = new SqlCommand();
            cm.CommandText = string.Format("select top {0} * from T_DIC_Book where id not in (select top {1} id from T_DIC_Book)"+keywords, PageSize, (PageIndex - 1) * PageSize);
            cm.Connection = co;

            SqlDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                MODEL.T_DIC_Book item = new MODEL.T_DIC_Book();
                item.ID = Convert.ToInt32(dr["ID"]);
                item.ISBN = Convert.ToString(dr["ISBN"]);
                item.Name = Convert.ToString(dr["Name"]);
                item.Publisher = Convert.ToString(dr["Publisher"]);
                item.Author = Convert.ToString(dr["Author"]);
                item.Pricing = Convert.ToDecimal(dr["Pricing"]);
                item.PublishYear = Convert.ToDateTime(dr["PublishYear"]);
                item.Notes = Convert.ToString(dr["Notes"]);

                lst.Add(item);
            }

            dr.Close();
            co.Close();
            return lst;
        }
    }
}
