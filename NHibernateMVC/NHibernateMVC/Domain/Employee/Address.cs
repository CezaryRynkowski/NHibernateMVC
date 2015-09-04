using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateMVC.Domain.Employee
{
    public class Address : Employee
    {
        /// <summary>
        /// employee address - city
        /// </summary>
        public virtual string City { get; set; }
        /// <summary>
        /// employee address - street
        /// </summary>
        public virtual string Street { get; set; }
        /// <summary>
        /// employee address - country
        /// </summary>
        public virtual string Country { get; set; }
        /// <summary>
        /// employee address - zip code
        /// </summary>
        public virtual string ZipCode { get; set; }
    }
}