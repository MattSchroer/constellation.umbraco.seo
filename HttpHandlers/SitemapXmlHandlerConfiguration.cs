using System.Configuration;

namespace Constellation.Umbraco.HttpHandlers
{
    /// <summary>
	/// The sitemap xml handler configuration.
	/// </summary>
	public class SitemapXmlHandlerConfiguration : ConfigurationSection
	{
		/* <sitemapXmlHandler
		 *		crawlerType="Constellation.Umbraco.HttpHandlers.SitemapXml.DefaultCrawler, Constellation.Umbraco.Seo"
		 *		sitemapNodeType="Constellation.Umbraco.HttpHandlers.SitemapXml.DefaultSitemapNode, Constellation.Umbraco.Seo"
		 *		cacheTimeoutMinutes="45" />
		 */

		/// <summary>
		/// The settings.
		/// </summary>
		private static SitemapXmlHandlerConfiguration settings;

		/// <summary>
		/// Gets the settings.
		/// </summary>
		public static SitemapXmlHandlerConfiguration Settings
		{
			get
			{
				if (settings == null)
				{
					var config = ConfigurationManager.GetSection("sitemapXmlHandler");
					settings = config as SitemapXmlHandlerConfiguration;
				}

				return settings;
			}
		}


		/// <summary>
		/// Gets the crawler type.
		/// </summary>
		[ConfigurationProperty("crawlerType", IsRequired = true)]
		public string CrawlerType
		{
			get
			{
				return (string)base["crawlerType"];
			}
		}

		/// <summary>
		/// Gets the sitemap node type.
		/// </summary>
		[ConfigurationProperty("sitemapNodeType", IsRequired = true)]
		public string SitemapNodeType
		{
			get
			{
				return (string)base["sitemapNodeType"];
			}
		}

		/// <summary>
		/// Gets the cache timeout minutes.
		/// </summary>
		[ConfigurationProperty("cacheTimeoutMinutes", DefaultValue = "45", IsRequired = true)]
		public int CacheTimeoutMinutes
		{
			get
			{
				return (int)base["cacheTimeoutMinutes"];
			}
		}
	}
}
