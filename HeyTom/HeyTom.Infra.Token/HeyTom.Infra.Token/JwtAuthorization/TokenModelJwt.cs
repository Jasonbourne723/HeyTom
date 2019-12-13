namespace HeyTom.Infra.Token.JwtAuthorization
{
	public class TokenModelJwt
	{
		/// <summary>
		/// Id
		/// </summary>
		public long Uid { get; set; }
		/// <summary>
		/// 角色
		/// </summary>
		public string Role { get; set; }
		/// <summary>
		/// 职能
		/// </summary>
		public string Work { get; set; }

		public string Name { get; set; }
	}
}