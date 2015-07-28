using System.Linq;
using System.Text;
using System.Xml;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace Constellation.Umbraco.HttpHandlers.SitemapXml
{
    /// <summary>
    /// Default Crawler Class for sitemaps
    /// </summary>
    public class DefaultCrawler : ICrawler
    {
        /// <summary>
        /// The crawl.
        /// </summary>
        /// <param name="site">
        /// The site.
        /// </param>
        /// <param name="doc">
        /// The doc.
        /// </param>
        public void Crawl(UmbracoContext site, XmlDocument doc)
        {
            /*
             *  We're going to crawl the site layer-by-layer which will put the upper levels
             *  of the site nearer the top of the sitemap.xml document as opposed to crawling
             *  the tree by parent/child relationships, which will go deep on each branch before
             *  crawling the entire site.
             */

            var helper = new UmbracoHelper(UmbracoContext.Current);
            var siteRoot = helper.TypedContentAtRoot().First();
            var node = SitemapGenerator.CreateNode(siteRoot, site);
            if (node.IsPage && node.IsListedInNavigation && node.ShouldIndex)
            {
                SitemapGenerator.AppendUrlElement(doc, node);
            }

            var items = siteRoot.Descendants();
            if (items != null)
            {
                foreach (var item in items)
                {
                    node = SitemapGenerator.CreateNode(item, site);

                    if (node.IsPage && node.IsListedInNavigation && node.ShouldIndex)
                    {
                        SitemapGenerator.AppendUrlElement(doc, node);
                    }
                }
            }
        }
    }
}
