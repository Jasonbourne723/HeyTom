namespace HeyTom.Domain.Models
{
	/// <summary>
	/// 推广横幅
	/// </summary>
	public class ExtendBanner
	{
		public ExtendBanner(string imageUrl, string title, string url)
		{
			this.imageUrl = imageUrl;
			this.title = title;
			this.url = url;
		}

		public string imageUrl { get; }

		public string title { get; }

		public string url { get; }
	}
}
