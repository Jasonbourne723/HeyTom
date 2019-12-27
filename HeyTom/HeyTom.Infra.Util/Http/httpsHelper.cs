﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
 
namespace HeyTom.Infra.Util.Http
{
	/// <summary>  
	/// 有关HTTP请求的辅助类  
	/// </summary>  
	public class httpsHelper
	{
		private static readonly string DefaultUserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
		/// <summary>  
		/// 创建GET方式的HTTP请求  
		/// </summary>  
		/// <param name="url">请求的URL</param>  
		/// <param name="timeout">请求的超时时间</param>  
		/// <param name="userAgent">请求的客户端浏览器信息，可以为空</param>  
		/// <param name="cookies">随同HTTP请求发送的Cookie信息，如果不需要身份验证可以为空</param>  
		/// <returns></returns>  
		public static string CreateGetHttpResponse(string url,string authorization, int? timeout, string userAgent, CookieCollection cookies)
		{
			try
			{
				if (string.IsNullOrEmpty(url))
				{
					throw new ArgumentNullException("url");
				}
				

				//如果是发送HTTPS请求  
				if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
				{
					ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
				}
				HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
				request.Method = "GET";
				request.Headers.Add("Authorization",authorization);
				request.UserAgent = DefaultUserAgent;
				if (!string.IsNullOrEmpty(userAgent))
				{
					request.UserAgent = userAgent;
				}
				if (timeout.HasValue)
				{
					request.Timeout = timeout.Value;
				}
				if (cookies != null)
				{
					request.CookieContainer = new CookieContainer();
					request.CookieContainer.Add(cookies);
				}
				//获取网页响应结果
				//return request.GetResponse() as HttpWebResponse;
				string result;
				using (WebResponse response = request.GetResponse())
				{
					using (StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
					{
						result = streamReader.ReadToEnd();
					}
				}
				return result;
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		//该方法用于验证服务器证书是否合法，当然可以直接返回true来表示验证永远通过。服务器证书具体内容在参数certificate中。可根据个人需求验证
		//该方法在request.GetResponse()时触发
		private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
		{
			return true; //总是接受  
		}
	}
}
