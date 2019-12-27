using System;
using System.Collections.Generic;

namespace HeyTom.Domain.Models
{
    public partial class VipPhoto
    {
        public long Id { get; set; }
        public long SimpleSayId { get; set; }
        public long VipId { get; set; }
        public string PhotoUrl { get; set; }
    }
}
