using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webforms.DTO
{
    public class CountryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }

        public CountryDTO(string name, DateTime createdDate)
        {
            Name = name;
            CreatedDate = createdDate;
        }

        public CountryDTO(int id, string name, DateTime createdDate)
        {
            Id = id;
            Name = name;
            CreatedDate = createdDate;
        }
    }
}