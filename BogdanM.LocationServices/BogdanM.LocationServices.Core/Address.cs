using System.Collections.Generic;

namespace BogdanM.LocationServices.Core
{
    public class Address
    {
        public string StreetName { get; set; }
        public string StreetNo { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public override string ToString()
        {
            var parts = new List<string>();
            
            if (string.IsNullOrEmpty(this.StreetName) == false)
                parts.Add(this.StreetName.ToLowerInvariant());

            if (string.IsNullOrEmpty(this.StreetNo) == false)
                parts.Add(this.StreetNo.ToLowerInvariant());

            if (string.IsNullOrEmpty(this.City) == false)
                parts.Add(this.City.ToLowerInvariant());

            if (string.IsNullOrEmpty(this.Country) == false)
                parts.Add(this.Country.ToLowerInvariant());

            return string.Join(",", parts);
        }
    }
}