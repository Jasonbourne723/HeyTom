using System;
using System.Collections.Generic;

namespace HeyTom.Domain.Models
{
    public partial class Vip :Entity
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string WxOpenId { get; set; }
        public string NickName { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public DateTime? Birthday { get; set; }
        public string Icon { get; set; }
        public string Mark { get; set; }
        public sbyte? Sex { get; set; }
        public long GitHubId { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
    }
}
