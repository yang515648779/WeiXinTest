using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Text;
using Senparc.Weixin.MP;

namespace WeiXinTest.Handlers
{
    /// <summary>
    /// WeatherHandler 的摘要说明
    /// </summary>
    public class WeatherHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string location = context.Request.Form["location"];
            string strUrl = "http://api.map.baidu.com/telematics/v3/weather?location=" + HttpUtility.HtmlDecode(location) + "&output=json&ak=DCf24c93f90b05d0e6b5f80dbf567a5e";
            context.Response.Write(GetUrltoHtml(strUrl, "utf-8"));
        }

        private  string GetUrltoHtml(string Url, string type)
        {
            try
            {
                System.Net.WebRequest wReq = System.Net.WebRequest.Create(Url);
                // Get the response instance.
                System.Net.WebResponse wResp = wReq.GetResponse();
                System.IO.Stream respStream = wResp.GetResponseStream();
                // Dim reader As StreamReader = New StreamReader(respStream)
                using (System.IO.StreamReader reader = new System.IO.StreamReader(respStream, Encoding.GetEncoding(type)))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (System.Exception ex)
            {
                //errorMsg = ex.Message;
            }
            return "";
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}