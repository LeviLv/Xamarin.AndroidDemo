using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Xamarin.AndroidDemo
{
    public class WebApiRequest
    {
        /// <summary>
        /// 模拟httppost请求
        /// </summary>
        /// <param name="json"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public Task<bool> HttpPostRequest(string json,string url)
        {
            string postData = json; // 要发放的数据 
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            HttpWebRequest objWebRequest = (HttpWebRequest)WebRequest.Create(url);
            objWebRequest.Method = "POST";
            objWebRequest.ContentType = "application/x-www-form-urlencoded";
            objWebRequest.ContentLength = byteArray.Length;
            Stream newStream = objWebRequest.GetRequestStream();
            // Send the data. 
            newStream.Write(byteArray, 0, byteArray.Length); //写入参数 
            newStream.Close();

            HttpWebResponse response = (HttpWebResponse)objWebRequest.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.Default);
            string textResponse = sr.ReadToEnd(); // 返回的数据
            if (string.IsNullOrWhiteSpace(textResponse))
                return Task.FromResult(false);
            return Task.FromResult(true);
        }
    }
}