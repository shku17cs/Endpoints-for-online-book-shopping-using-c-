using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public int Title { get; set; }
        public int Description { get; set; }
    }
}
