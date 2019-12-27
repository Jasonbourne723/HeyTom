using System;
using System.Collections.Generic;
using System.Text;

namespace HeyTom.Application.DTO
{
	public class UpdateVipDTO
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string Mobile { get; set; }
		public string NickName { get; set; }
		public string Province { get; set; }
		public string City { get; set; }
		public string Address { get; set; }
		public DateTime? Birthday { get; set; }
		/// <summary>
		/// 个性签名
		/// </summary>
		public string Mark { get; set; }
		/// <summary>
		/// 0:女  1：男
		/// </summary>
		public sbyte? Sex { get; set; }
	}
}
