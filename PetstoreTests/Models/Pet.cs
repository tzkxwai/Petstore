using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTest.Models
{
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public class Pet
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public Category Category { get; set; }
    }
}
