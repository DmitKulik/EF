using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Entities{
    public class Book{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public Int64 CreatedDate { get; set; }
        public int UserId { get; set; } = 0;
    }
}