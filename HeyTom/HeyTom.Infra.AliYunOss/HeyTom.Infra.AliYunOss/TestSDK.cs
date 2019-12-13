using System.IO;
using Aliyun.OSS;

namespace HeyTom.Infra.AliYunOss
{
	public class TestSDK
	{


		public static void Test()
		{
			//.aliyuncs.com
			/*client: new OSS({
        region: 'oss-cn-shenzhen',
        accessKeyId: 'LTAISgT8Qj4MCgAT',
        accessKeySecret: 'smtQr62zYeRTHDCZGZ0eseA8CDdBpk',
        // bucket: 'swyunfan'
        bucket: 'swyunfantesting'
    })*/

				string endpoint = "oss-cn-shenzhen.aliyuncs.com";
			string accessKeyId = "LTAISgT8Qj4MCgAT";
			string accessKeySecret = "smtQr62zYeRTHDCZGZ0eseA8CDdBpk";
			string bucketName;
			string objectName;
			string localFilename;
			Aliyun.OSS.Common.ClientConfiguration configuration = new Aliyun.OSS.Common.ClientConfiguration();
			var client = new OssClient(endpoint, accessKeyId, accessKeySecret, configuration);
			
			var list = client.ListBuckets();

			var aa = client.GeneratePresignedUri("swyunfantesting", "test100818.jpg");

			// 上传文件。
			var result = client.PutObject("swyunfantesting", "test100818.jpg", @"G:\resource\e53c868ee9e8e7b28c424b56afe2066d.jpg");

			var obj = client.GetObject("swyunfantesting", "test100818.jpg");
			using (var requestStream = obj.Content)
			{
				byte[] buf = new byte[1024];
				var fs = File.Open(@"G:\resource\12313.jpg", FileMode.OpenOrCreate);
				var len = 0;
				// 通过输入流将文件的内容读取到文件或者内存中。
				while ((len = requestStream.Read(buf, 0, 1024)) != 0)
				{
					fs.Write(buf, 0, len);
				}
				fs.Close();
			}
			
		}
	}
}
