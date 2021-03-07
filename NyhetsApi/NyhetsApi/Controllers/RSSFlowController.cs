using NyhetsApi.Models;
using NyhetsApi.Services;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace NyhetsApi.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("api/rssflow")]
    public class RSSFlowController : ApiController
    {
        [Route("get/rssfeed")]
        public RSSFeedModel GetRSSFeed()
        {
            RSSFeedService service = new RSSFeedService();
            RSSFeedModel model = new RSSFeedModel();
            List<RSSFeedItemModel> list = new List<RSSFeedItemModel>();

            List<RSSFeedItemModel> ntList = service.GetRSSFeed(ConfigurationManager.AppSettings["NTRSSFeedUrl"]).Items.ToList();
            List<RSSFeedItemModel> expressenList = service.GetRSSFeed(ConfigurationManager.AppSettings["ExpressenRSSFeedUrl"]).Items.ToList();
            List<RSSFeedItemModel> svdList = service.GetRSSFeed(ConfigurationManager.AppSettings["SvdRSSFeedUrl"]).Items.ToList();

            model.Items = list.Concat(ntList).Concat(expressenList).Concat(svdList).OrderByDescending(x => x.PubDate);
            return model;
        }

        [Route("get/ntrssfeed")]
        public RSSFeedModel GetNTRSSFeed()
        {
            RSSFeedService service = new RSSFeedService();
            RSSFeedModel model = service.GetRSSFeed(ConfigurationManager.AppSettings["NTRSSFeedUrl"]);
            model.Items.OrderByDescending(x => x.PubDate);
            return model;
        }

        [Route("get/expressenrssfeed")]
        public RSSFeedModel GetExpressenRSSFeed()
        {
            RSSFeedService service = new RSSFeedService();
            RSSFeedModel model = service.GetRSSFeed(ConfigurationManager.AppSettings["ExpressenRSSFeedUrl"]);
            model.Items.OrderByDescending(x => x.PubDate);
            return model;
        }

        [Route("get/svdrssfeed")]
        public RSSFeedModel GetSvdRSSFeed()
        {
            RSSFeedService service = new RSSFeedService();
            RSSFeedModel model = service.GetRSSFeed(ConfigurationManager.AppSettings["SvdRSSFeedUrl"]);
            model.Items.OrderByDescending(x => x.PubDate);
            return model;
        }
    }
}