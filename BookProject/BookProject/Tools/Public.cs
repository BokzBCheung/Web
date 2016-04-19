using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookProject
{
    public class Public
    {
       //弹窗实现局部刷新
        public static string LoginName;

        public static MODEL.Message T_CloseSMess(string TabID,string Rel,string AlertMes)
        {
            MODEL.Message message = new MODEL.Message();
            message.statusCode = "200";
            message.message = AlertMes;
            message.navTabId = TabID;
            message.rel =Rel;
            message.forwardUrl ="";
            message.callbackType = "closeCurrent";
            return message;
        }
        public static MODEL.Message T_CloseFMess(string TabID, string Rel, string AlertMes)
        {
            MODEL.Message message = new MODEL.Message();
            message.statusCode = "300";
            message.message = AlertMes;
            message.navTabId = TabID;
            message.rel = Rel;
            message.forwardUrl = "";
            message.callbackType = "closeCurrent";
            return message;
        }
        public static MODEL.Message U_CloseSMess(string TabID, string Rel, string AlertMes)
        {
            MODEL.Message message = new MODEL.Message();
            message.statusCode = "200";
            message.message = AlertMes;
            message.navTabId = TabID;
            message.rel =Rel;
            message.forwardUrl = "";
            message.callbackType = "";
            return message;
        }
        public static MODEL.Message U_CloseFMess(string TabID, string Rel, string AlertMes)
        {
            MODEL.Message message = new MODEL.Message();
            message.statusCode = "300";
            message.message = AlertMes;
            message.navTabId = TabID;
            message.rel = Rel;
            message.forwardUrl = "";
            message.callbackType = "";
            return message;
        }
        public static MODEL.Message LoginSuc()
        {
            MODEL.Message message = new MODEL.Message();
            message.statusCode = "200";
            message.message = "修改密码成功";
            message.navTabId = "Exit";
            message.rel = "Exit";
            message.forwardUrl = "Exit";
            message.callbackType = "";
            return message;
        }

        //构造文本截取显示
        public static string cutstring(string input, int count)
        {
            if (input.Length < count)
            {
                return input;
            }
            else
            {
                return input.Substring(0, count - 3) + "．．．";
            }
        }
    }

}