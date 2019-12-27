using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HeyTom.Application.DTO
{
	public class RegisterInfoDTO
	{
		[Required]
		public string Email { get; set; }
		[Required]
		public string Password { get; set; }
		[Required]
		public string NickName { get; set; }
		[Required]
		public string Code { get; set; }
	}
}
