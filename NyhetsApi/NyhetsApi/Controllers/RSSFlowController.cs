using NyhetsApi.Models;
using NyhetsApi.Services;
using System;
using System.Configuration;
using System.Web.Http;

namespace NyhetsApi.Controllers
{
    [RoutePrefix("api/rssflow")]
    public class RSSFlowController : ApiController
    {
        [Route("rssfeed")]
        public IHttpActionResult GetRSSFeed()
        {
            try
            {
                RSSFeedService service = new RSSFeedService();
                RSSFeedModel model = service.GetRSSFeed(new string[] { ConfigurationManager.AppSettings["NTRSSFeedUrl"], ConfigurationManager.AppSettings["ExpressenRSSFeedUrl"],
                ConfigurationManager.AppSettings["SvdRSSFeedUrl"] });
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Route("ntrssfeed")]
        public IHttpActionResult GetNTRSSFeed()
        {
            try
            {
                RSSFeedService service = new RSSFeedService();
                RSSFeedModel model = service.GetRSSFeed(new string[] { ConfigurationManager.AppSettings["NTRSSFeedUrl"] }, true);
                return Ok(model);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        [Route("expressenrssfeed")]
        public IHttpActionResult GetExpressenRSSFeed()
        {
            try
            {
                RSSFeedService service = new RSSFeedService();
                RSSFeedModel model = service.GetRSSFeed(new string[] { ConfigurationManager.AppSettings["ExpressenRSSFeedUrl"] }, true);
                return Ok(model);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        [Route("svdrssfeed")]
        public IHttpActionResult GetSvdRSSFeed()
        {
            try
            {
                RSSFeedService service = new RSSFeedService();
                RSSFeedModel model = service.GetRSSFeed(new string[] { ConfigurationManager.AppSettings["SvdRSSFeedUrl"] }, true);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}