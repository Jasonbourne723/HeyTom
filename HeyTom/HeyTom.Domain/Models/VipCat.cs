using System;
using System.Collections.Generic;

namespace HeyTom.Domain.Models
{
    public partial class VipCat
    {
        public long Id { get; set; }
        public long VipId { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public sbyte? Sex { get; set; }
        public DateTime? Birthday { get; set; }
        public int BreedId { get; set; }
    }
}
