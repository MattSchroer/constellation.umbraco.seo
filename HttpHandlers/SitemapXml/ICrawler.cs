using System.Xml;
using Umbraco.Web;

namespace Constellation.Umbraco.HttpHandlers.SitemapXml
{
    /// <summary>
	/// The base contract for an object that represents a crawler in a sitemap.xml document.
	/// The crawler object is used to build the sitemap
	/// </summary>
	public interface ICrawler
	{
		/// <summary>
		/// The crawl.
		/// </summary>
        /// <param name="umbracoContext">
		/// The context.
		/// </param>
		/// <param name="doc">
		/// The doc.
		/// </param>
		void Crawl(UmbracoContext umbracoContext, XmlDocument doc);
	}
}
