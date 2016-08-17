using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgFeeds.Models
{
    public class Post
    {
        public string Title { get; set; }
        public string Date { get; set; }
        public string Website { get; set; }
        public string Category { get; set; }
        public string PostId { get; set; }
        public string Picture { get; set; }
        public string Url { get; set; }
    }
}
