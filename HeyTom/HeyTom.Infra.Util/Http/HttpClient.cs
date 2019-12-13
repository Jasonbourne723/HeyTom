using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HeyTom.Infra.Util.Http
{
	public class HttpClient
	{
		public static string Get(string url, string httpPostType = "application/json;charset=utf-8", CookieContainer cookieContainer = null)
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
			httpWebRequest.Method = "GET";
			httpWebRequest.ContentType = httpPostType;
			if (cookieContainer != null)
			{
				httpWebRequest.CookieContainer = cookieContainer;
			}
			string result;
			using (WebResponse response = httpWebRequest.GetResponse())
			{
				using (StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
				{
					result = streamReader.ReadToEnd();
				}
			}
			return result;
		}

		public static async Task<string> GetAsync(string url, string httpPostType = "application/json;charset=utf-8", CookieContainer cookieContainer = null)
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
			httpWebRequest.Method = "GET";
			httpWebRequest.ContentType = httpPostType;
			if (cookieContainer != null)
			{
				httpWebRequest.CookieContainer = cookieContainer;
			}
			WebResponse webResponse = await httpWebRequest.GetResponseAsync();
			string result;
			try
			{
				StreamReader var_5 = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8);
				try
				{
					result = var_5.ReadToEnd();
				}
				finally
				{
					int num = 0;
					if (num < 0 && var_5 != null)
					{
						((IDisposable)var_5).Dispose();
					}
				}
			}
			finally
			{
				int num = 0;
				if (num < 0 && webResponse != null)
				{
					((IDisposable)webResponse).Dispose();
				}
			}
			return result;
		}

		public static string Post(string url, string postData, string httpPostType = "application/json;charset=utf-8", CookieContainer cookieContainer = null, Dictionary<string, string> header = null)
		{
			byte[] postBuffer = (!string.IsNullOrEmpty(postData)) ? Encoding.UTF8.GetBytes(postData) : new byte[0];
			return HttpClient.Post(url, postBuffer, httpPostType, cookieContainer, header);
		}

		public static string Post(string url, byte[] postBuffer, string httpPostType = "application/json;charset=utf-8", CookieContainer cookieContainer = null, Dictionary<string, string> header = null)
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
			if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
			{
				ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(HttpClient.CheckValidationResult);
			}
			httpWebRequest.Method = "POST";
			httpWebRequest.ContentType = httpPostType;
			httpWebRequest.ContentLength = (long)postBuffer.Length;
			if (cookieContainer != null)
			{
				httpWebRequest.CookieContainer = cookieContainer;
			}
			if (header != null)
			{
				foreach (string current in header.Keys)
				{
					string value = "";
					header.TryGetValue(current, out value);
					httpWebRequest.Headers.Add(current, value);
				}
			}
			if (postBuffer.Length != 0)
			{
				using (Stream requestStream = httpWebRequest.GetRequestStream())
				{
					requestStream.Write(postBuffer, 0, postBuffer.Length);
				}
			}
			string result;
			using (WebResponse response = httpWebRequest.GetResponse())
			{
				using (StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
				{
					result = streamReader.ReadToEnd();
				}
			}
			return result;
		}

		private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslpolicyerrors)
		{
			return true;
		}

		public static async Task<string> PostAsync(string url, string postData, string httpPostType = "application/json;charset=utf-8", CookieContainer cookieContainer = null, Dictionary<string, string> header = null)
		{
			byte[] postBuffer = (!string.IsNullOrEmpty(postData)) ? Encoding.UTF8.GetBytes(postData) : new byte[0];
			return await HttpClient.PostAsync(url, postBuffer, httpPostType, cookieContainer, null);
		}

		public static async Task<string> PostAsync(string url, byte[] postBuffer, string httpPostType = "application/json;charset=utf-8", CookieContainer cookieContainer = null, Dictionary<string, string> header = null)
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
			new ManualResetEvent(false);
			httpWebRequest.Method = "POST";
			httpWebRequest.ContentType = httpPostType;
			httpWebRequest.ContentLength = (long)postBuffer.Length;
			if (cookieContainer != null)
			{
				httpWebRequest.CookieContainer = cookieContainer;
			}
			int num  = 0;
			if (postBuffer.Length != 0)
			{
				Stream stream = await httpWebRequest.GetRequestStreamAsync();
				try
				{
					stream.Write(postBuffer, 0, postBuffer.Length);
				}
				finally
				{
					if (num < 0 && stream != null)
					{
						((IDisposable)stream).Dispose();
					}
				}
			}
			WebResponse var_4 = await httpWebRequest.GetResponseAsync();
			string result;
			try
			{
				StreamReader var_6 = new StreamReader(var_4.GetResponseStream(), Encoding.UTF8);
				try
				{
					result = var_6.ReadToEnd();
				}
				finally
				{
					if (num < 0 && var_6 != null)
					{
						((IDisposable)var_6).Dispose();
					}
				}
			}
			finally
			{
				if (num < 0 && var_4 != null)
				{
					((IDisposable)var_4).Dispose();
				}
			}
			return result;
		}
	}
}
