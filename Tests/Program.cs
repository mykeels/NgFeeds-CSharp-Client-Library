using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NgFeeds;
using Extensions;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Program
    {
        [Test]
        public static List<NgFeeds.Models.NgCategory> TestFetchCategories()
        {
            Console.WriteLine("Test Fetch Categories");
            List<NgFeeds.Models.NgCategory> ret = new List<NgFeeds.Models.NgCategory>();
            Assert.DoesNotThrow(new TestDelegate(() =>
            {
                Client client = new Client();
                client.FetchCategories().Success((categories) =>
                {
                    Console.WriteLine("Fetch All Categories: \n" + categories.ToJson(true));
                    ret = categories;
                }).Error((Exception ex) =>
                {
                    throw ex;
                }).Wait();
            }), "This Method (TestFetchCategories) should not throw an error");
            return ret;
        }

        [Test]
        public static List<NgFeeds.Models.Post> TestFetchCategoryPosts(string categoryShortCode, int count = 0)
        {
            Console.WriteLine("Test Fetch Category Posts");
            List<NgFeeds.Models.Post> ret = new List<NgFeeds.Models.Post>();
            Assert.DoesNotThrow(new TestDelegate(() =>
            {
                Client client = new Client();
                client.FetchCategoryPosts(categoryShortCode, count).Success((posts) =>
                {
                    Console.WriteLine("Fetch Category Posts: \n" + posts.ToJson(true));
                    ret = posts;
                }).Error((Exception ex) =>
                {
                    throw ex;
                }).Wait();
            }), "This method should not throw an error");
            return ret;
        }

        [Test]
        public static List<NgFeeds.Models.Channel> TestFetchChannels(string categoryShortCode = null)
        {
            Console.WriteLine("Test Fetch Channels");
            Client client = new Client();
            List<NgFeeds.Models.Channel> ret = new List<NgFeeds.Models.Channel>();
            Assert.DoesNotThrow(new TestDelegate(() =>
            {
                client.FetchChannels(categoryShortCode).Success((channels) =>
                {
                    Console.WriteLine("Fetch Channels: \n" + channels.ToJson(true));
                    ret = channels;
                    if (!String.IsNullOrEmpty(categoryShortCode))
                    {
                        Assert.That(channels.All((channel) => channel.Category.ToLower().Equals(categoryShortCode.ToLower())), "Category Short Code was specified, but does not work!");
                    }
                }).Error((Exception ex) =>
                {
                    throw ex;
                }).Wait();
            }), "This Method (TestFetchChannels) should not throw an error");
            return ret;
        }

        [Test]
        public static List<NgFeeds.Models.Post> TestFetchChannelPosts(string channelShortCode)
        {
            Console.WriteLine("Test Fetch Channel Posts");
            Client client = new Client();
            List<NgFeeds.Models.Post> ret = new List<NgFeeds.Models.Post>();
            Assert.DoesNotThrow(new TestDelegate(() =>
            {
                client.FetchChannelPosts(channelShortCode).Success((posts) =>
                {
                    Console.WriteLine("Fetch Channel Posts: \n" + posts.ToJson(true));
                    ret = posts;
                }).Error((Exception ex) =>
                {
                    throw ex;
                }).Wait();
            }), "This Method (TestFetchChannelPosts) should not throw an error");
            return ret;
        }

        [Test]
        public static NgFeeds.Models.HomeData TestFetchHomeData()
        {
            Console.WriteLine("Test Fetch Website Home Data");
            Client client = new Client();
            NgFeeds.Models.HomeData data = new NgFeeds.Models.HomeData();
            Assert.DoesNotThrow(new TestDelegate(() =>
            {
                client.FetchWebsiteHomeData().Success((response) =>
                {
                    Console.WriteLine("Fetch Website Home Data: \n" + response.ToJson(true));
                    data = response;
                }).Error((Exception ex) =>
                {
                    throw ex;
                }).Wait();
            }), "This Method (TestFetchHomeData) should not throw an error");
            return data;
        }

        public static void Main(string[] args)
        {
            List<NgFeeds.Models.NgCategory> categories = TestFetchCategories();
            var category = categories.Random();
            TestFetchCategoryPosts(category.CategoryShortName);
            TestFetchChannels(category.ShortCode);
            List<NgFeeds.Models.Channel> channels = TestFetchChannels();
            var channel = channels.Random();
            TestFetchChannelPosts(channel.ShortCode);
            TestFetchHomeData();
            Console.WriteLine("Tests completed successfully!");
            Console.Read();
        }
    }
}
