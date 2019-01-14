using System.Collections.Generic;

namespace SampleAPI.Tests.Models
{
    public class Catalogue
    {
        public string Name { get; set; }
        public bool CanRelist { get; set; }
        public string PromotionName { get; set; }

        public List<Promotion> Promotions { get; set; }
    }
}
