using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgFeeds.Models
{
    public class NgCategory
    {
        private string _shortcode = "";
        private string _category = "";
        public string ShortCode
        {
            get
            {
                return _shortcode;
            }
            set
            {
                _shortcode = value;
                if (String.IsNullOrEmpty(CategoryShortName))
                {
                    CategoryShortName = value;
                }
            }
        }
        public string Category { get
            {
                return _category;
            }
            set
            {
                _category = value;
                if (String.IsNullOrEmpty(CategoryName))
                {
                    CategoryName = value;
                }
            }
        }
        public string CategoryName { get
            {
                return _category;
            }
            set
            {
                _category = value;
                if (String.IsNullOrEmpty(_category))
                {
                    _category = value;
                }
            }
        }
        public string CategoryShortName { get
            {
                return _shortcode;
            }
            set
            {
                _shortcode = value;
                if (String.IsNullOrEmpty(_shortcode))
                {
                    _shortcode = value;
                }
            }
        }
        public string PictureUrl { get; set; }
        public List<Post> Posts { get; set; }
        public List<string> Websites { get; set; }
    }
}
