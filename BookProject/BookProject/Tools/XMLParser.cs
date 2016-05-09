using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;


namespace BookProject.Tools
{

    public class XMLParser
    {

        //添加用户
        public static bool AddUser(MODEL.T_DIC_User model)
        {
            XmlDocument xml = new XmlDocument();
            string path = HttpContext.Current.Server.MapPath("~/Tools/XML_User.xml");
            xml.Load(path);

            XmlElement person = xml.CreateElement("Person");

            XmlAttribute ID = xml.CreateAttribute("ID");
            int id = Convert.ToInt32(xml.GetElementsByTagName("LastID")[0].ChildNodes[0].InnerText);
            xml.GetElementsByTagName("LastID")[0].ChildNodes[0].InnerText = (id + 1).ToString();
            ID.Value = Convert.ToString(id + 1);

            XmlElement LoginName = xml.CreateElement("LoginName");
            LoginName.InnerText = Convert.ToString(model.LoginName);
            XmlElement PWD = xml.CreateElement("Pwd");
            PWD.InnerText = Convert.ToString(model.Pwd);
            XmlElement Phone = xml.CreateElement("Phone");
            Phone.InnerText = Convert.ToString(model.Phone);
            XmlElement LastLoginTime = xml.CreateElement("LastLoginTime");
            LastLoginTime.InnerText = Convert.ToString(string.Format("{0:yyyy-MM-dd}", model.LastLoginTime));
            XmlElement Status = xml.CreateElement("Status");
            Status.InnerText = Convert.ToString(model.Status);
            XmlElement VisitCount = xml.CreateElement("VisitCount");
            VisitCount.InnerText = Convert.ToString(model.VisitCount);

            person.Attributes.Append(ID);
            person.AppendChild(LoginName);
            person.AppendChild(PWD);
            person.AppendChild(Phone);
            person.AppendChild(LastLoginTime);
            person.AppendChild(VisitCount);
            person.AppendChild(Status);

            xml.DocumentElement.AppendChild(person);
            xml.Save(path);

            return true;
        }
        //XML文件列表的展示
        public static List<MODEL.T_DIC_User> GetUser(int PageSize, int PageIndex,string keywords)
        {
            //构建XML文件
            XmlDocument xml = new XmlDocument();
            string path = HttpContext.Current.Server.MapPath("~/Tools/XML_User.xml");
            xml.Load(path);

            List<MODEL.T_DIC_User> lst = new List<MODEL.T_DIC_User>();
            XmlNodeList Nodes = xml.SelectNodes("/User/Person[LoginName"+keywords+"]");
            int n = 1;

            foreach (XmlNode node in Nodes)
            {
                MODEL.T_DIC_User model = new MODEL.T_DIC_User();

                model.ID = Convert.ToInt32(node.Attributes[0].Value);
                model.LoginName = Convert.ToString(node.ChildNodes[0].InnerText);
                model.Pwd = Convert.ToString(node.ChildNodes[1].InnerText);
                model.Phone = Convert.ToString(node.ChildNodes[2].InnerText);
                model.LastLoginTime = Convert.ToDateTime(node.ChildNodes[3].InnerText);
                model.VisitCount = Convert.ToInt32(node.ChildNodes[4].InnerText);
                model.Status = Convert.ToInt32(node.ChildNodes[5].InnerText);//将数据转化成模型中的列表

                n++;
                if (n > PageSize * (PageIndex - 1) + 1)
                {
                    lst.Add(model);

                    if (lst.Count > PageSize - 1)
                        break;
                }
            }
            return lst;
        }
        //获取XML节点条目
        public static int GetCount(string keywords)
        {
            XmlDocument xml = new XmlDocument();
            string path = HttpContext.Current.Server.MapPath("~/Tools/XML_User.xml");
            xml.Load(path);

            XmlNodeList Nodes = xml.SelectNodes("/User/Person[LoginName" + keywords + "]");
            return Nodes.Count;
        }
        public static int GetCount2()
        {
            XmlDocument xml = new XmlDocument();
            string path = HttpContext.Current.Server.MapPath("~/Tools/XML_User.xml");
            xml.Load(path);

            XmlNodeList Nodes = xml.SelectNodes("/User/Person");
            return Nodes.Count;
        }
        //删除用户
        public static bool DeleteUser(int id)
        {
            XmlDocument xml = new XmlDocument();
            string path = HttpContext.Current.Server.MapPath("~/Tools/XML_User.xml");
            xml.Load(path);

            int count = GetCount2();
            XmlNode node = xml.DocumentElement.SelectSingleNode("/User/Person[@ID=\"" + id + "\"]");
            node.ParentNode.RemoveChild(node);

            XmlNodeList Nodes = xml.SelectNodes("/User/Person");
            //int num = Convert.ToInt32(Nodes.Item(count).Attributes[0].InnerText);
            ////int num = Convert.ToInt32(node.ChildNodes[count].Attributes[0].InnerText);
            int num = Convert.ToInt32(xml.GetElementsByTagName("LastID")[0].ChildNodes[0].InnerText);
            xml.GetElementsByTagName("LastID")[0].ChildNodes[0].InnerText = (num).ToString();

            xml.Save(path);
            return true;
        }
        //修改用户
        public static MODEL.T_DIC_User EditUser(int uid)
        {
            XmlDocument xml = new XmlDocument();
            string path = HttpContext.Current.Server.MapPath("~/Tools/XML_User.xml");
            xml.Load(path);

            XmlNode root = xml.DocumentElement;
            XmlNode node = root.SelectSingleNode("/User/Person[@ID=\"" + uid + "\"]");

            MODEL.T_DIC_User model = new MODEL.T_DIC_User();
            model.ID = Convert.ToInt32(node.Attributes[0].Value);
            model.LoginName = node.ChildNodes[0].InnerText;
            model.Pwd = node.ChildNodes[1].InnerText;
            model.Phone = Convert.ToString(node.ChildNodes[2].InnerText);
            model.LastLoginTime = Convert.ToDateTime(node.ChildNodes[3].InnerText);
            model.Status = Convert.ToInt32(node.ChildNodes[5].InnerText);
            model.VisitCount = Convert.ToInt32(node.ChildNodes[4].InnerText);
            return model;
        }
        public static bool EditSave(MODEL.T_DIC_User model)
        {
            XmlDocument xml = new XmlDocument();
            string path = HttpContext.Current.Server.MapPath("~/Tools/XML_User.xml");
            xml.Load(path);

            XmlNode root = xml.DocumentElement;
            XmlNode node = root.SelectSingleNode("/User/Person[@ID=\"" + model.ID + "\"]");

            node.ChildNodes[0].InnerText = model.LoginName;
            node.ChildNodes[1].InnerText = model.Pwd;
            node.ChildNodes[2].InnerText = Convert.ToString(model.Phone);
            node.ChildNodes[3].InnerText = Convert.ToString(model.LastLoginTime);
            node.ChildNodes[4].InnerText = Convert.ToString(model.VisitCount);
            node.ChildNodes[5].InnerText = Convert.ToString(model.Status);

            xml.Save(path);
            return true;

        }
        
        //修改密码
        public static bool ChangePwd(string pwd)
        {
            XmlDocument xml = new XmlDocument();
            string path = HttpContext.Current.Server.MapPath("~/Tools/XML_User.xml");
            xml.Load(path);

            XmlNode root = xml.DocumentElement;
            XmlNode node = root.SelectSingleNode("/User/Person[LoginName=\"" + BookProject.Public.LoginName + "\"]");

            node.ChildNodes[1].InnerText =Convert.ToString(pwd) ;

            xml.Save(path);
            return true;

        }
    }
}