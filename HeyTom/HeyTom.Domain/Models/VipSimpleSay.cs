using System;
using System.Collections.Generic;

namespace HeyTom.Domain.Models
{
    public partial class VipSimpleSay
    {
        public long Id { get; set; }
        public long VipId { get; set; }
        public string Body { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
