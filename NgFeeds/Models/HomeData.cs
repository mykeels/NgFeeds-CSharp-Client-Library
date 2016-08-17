using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgFeeds.Models
{
    public class HomeData
    {
        public List<Post> LatestPosts { get; set; }
        public List<NgCategory> CategoryPosts { get; set; }
    }
}