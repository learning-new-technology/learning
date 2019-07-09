using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Resort
    {
        public int Id { get; set; }
        public string ResortName { get; set; }
        public string ResortAddress { get; set; }
        public int? Rating { get; set; }
        public int? Price { get; set; }
        public string ResortImage { get; set; }
    }
}
