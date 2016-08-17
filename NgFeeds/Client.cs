using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extensions;
using System.Web;

namespace NgFeeds
{
    public class Client
    {
        private string _resolveUrl(string urlSuffix)
        {
            string rootUrl = System.Configuration.ConfigurationManager.AppSettings["NgFeeds_Root_Url"];
            if (String.IsNullOrEmpty(rootUrl)) rootUrl = "http://api.ngfeeds.com/";
            return rootUrl + urlSuffix;
        }

        public Promise<List<Models.NgCategory>> FetchCategories()
        {
            return Api.GetAsync<List<Models.NgCategory>>(_resolveUrl("fetchcategories"));
        }

        public Promise<List<Models.Channel>> FetchChannels(string category = null)
        {
            string query = "";
            if (String.IsNullOrEmpty(category)) return Api.GetAsync<List<Models.Channel>>(_resolveUrl("fetchallchannels"));
            else query = "?catshortcode=" + HttpUtility.UrlEncode(category);
            return Api.GetAsync<List<Models.Channel>>(_resolveUrl("fetchChannelsInCategory" + query));
        }

        public Promise<List<Models.Post>> FetchPosts(int count = -1, string category = null)
        {
            string query = "";
            if (count > 0 && count < Int32.MaxValue) query = "?count=" + count;
            if (!String.IsNullOrEmpty(category)) query = (String.IsNullOrEmpty(query) ? "?" : "&") + "catshortcode=" + category;
            return Api.GetAsync<List<Models.Post>>(_resolveUrl("fetchposts" + query));
        }

        public Promise<List<Models.Post>> FetchChannelPosts(string channelcode, int count = 50)
        {
            string query = "?channelshortcode=" + channelcode + "&count=" + count;
            return Api.GetAsync<List<Models.Post>>(_resolveUrl("fetchchannelposts" + query));
        }

        public Promise<List<Models.Post>> FetchCategoryPosts(string catshortname, int count)
        {
            string query = "?catshortname=" + catshortname;
            if (count > 0 && count < Int32.MaxValue) query += "&count=" + count;
            else query += "&count=" + 50;
            return Api.GetAsync<List<Models.Post>>(_resolveUrl("categoryposts" + query));
        }

        public Promise<Models.HomeData> FetchWebsiteHomeData()
        {
            return Api.GetAsync<Models.HomeData>(_resolveUrl("fetchWebsiteHomeData"));
        }
    }
}
