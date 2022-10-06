using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace AppForm.Models
{
    public class Form
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Request { get; set; }
        public List<Country> CountryList { get; set; }
    }

    public class Country
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}