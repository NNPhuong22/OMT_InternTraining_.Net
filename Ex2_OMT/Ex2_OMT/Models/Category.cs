using System;
using System.Collections.Generic;

namespace Ex2_OMT.Models
{
    public partial class Category
    {
        public Category()
        {
            Posts = new HashSet<Post>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int IsDeleted { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
