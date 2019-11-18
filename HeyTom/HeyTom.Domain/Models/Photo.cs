namespace HeyTom.Domain.Models
{
	/// <summary>
	/// 社区动态图片
	/// </summary>
	public class Photo : Entity
	{
		public Photo(long simpleSayId, long vipId, string photoUrl)
		{
			SimpleSayId = simpleSayId;
			VipId = vipId;
			PhotoUrl = photoUrl;
		}

		public long SimpleSayId { get; set; }

		public long VipId { get; set; }

		public string PhotoUrl { get; set; }
	}
}
