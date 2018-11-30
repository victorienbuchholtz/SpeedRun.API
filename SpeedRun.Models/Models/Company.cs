using System;
using System.Collections.Generic;

namespace SpeedRun.Models.Models
{
    public class Company
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string UrlLogo { get; set; }
        public string Description { get; set; }

        // Many to many
        public List<ProductCompany> Published { get; set; }
        public List<ProductCompany> Developped { get; set; }
    }
}