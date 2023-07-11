using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class Book
    {
        public int id { get; set; }
        public string name { get; set; }

        public Book(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        public Book()
        {
        }
    }
}
