using System;
using Umbraco.Core.Models;

namespace Constellation.Umbraco.HttpHandlers.SitemapXml
{
    /// <summary>
    /// Represents a candidate element for the sitemap.xml file.
    /// </summary>
    public class DefaultSitemapNode : SitemapNode<IPublishedContent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultSitemapNode"/> class.
        /// </summary>
        /// <param name="page">
        /// The page to be considered for a node.
        /// </param>
        /// <param name="site">
        /// The site.
        /// </param>
        public DefaultSitemapNode(IPublishedContent page)
            : base(page)
        {
            // shut up Stylecop
        }

        /// <summary>
        /// Determines whether the page object (which is assumed to be a page) is to be represented
        /// in navigation presented on page (ex: a spageap or breadcrumbs).
        /// </summary>
        /// <param name="page">An object representing a Umbraco page.</param>
        /// <returns><c>true</c> if the object is intended to be represented in various page navigation scenarios.</returns>
        protected override bool CheckIsListedInNavigation(IPublishedContent page)
        {
            return page.TemplateId > 0;
        }

        /// <summary>
        /// Determines whether the page object represents a web page on the site and therefore
        /// has presentation details.
        /// </summary>
        /// <param name="page">An object representing a Sitecore page.</param>
        /// <returns><c>true</c> if the object is a page with presentation details given the current context.</returns>
        protected override bool CheckIsPage(IPublishedContent page)
        {
            if (page.TemplateId > 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Determines whether the page object (which is assumed to be a page) is to be indexed
        /// by search engines.
        /// </summary>
        /// <param name="page">An object representing a Sitecore page.</param>
        /// <returns><c>true</c> if the object's presentation is intended to be crawled by search engines.</returns>
        protected override bool CheckShouldIndex(IPublishedContent page)
        {
            if (page.TemplateId > 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Determines the full URL (hostname &amp; language definition) of the page object (which is assumed to be a page).
        /// </summary>
        /// <param name="page">An object representing a Sitecore page.</param>
        /// <returns>The absolute URL to the object, including protocol.</returns>
        protected override string ResolveAbsoluteUrl(IPublishedContent page)
        {
            //TODO: rework.
            return page.Url;
        }

        /// <summary>
        /// Determines the anticipated content/presentation change frequency of the page object (which is assumed to be a page).
        /// </summary>
        /// <param name="page">An object representing a Sitecore page.</param>
        /// <returns>The change frequency.</returns>
        protected override ChangeFrequency ResolveChangeFrequency(IPublishedContent page)
        {
            return ChangeFrequency.Monthly;
        }

        /// <summary>
        /// Determines the crawling priority of the page object (which is assumed to be a page) using a scale
        /// from 0.0 to 1.0 where 1.0 is the highest priority and 0.0 is the lowest priority. 
        /// 0.5 is the expected neutral value.
        /// </summary>
        /// <param name="page">An object representing a Sitecore page.</param>
        /// <returns>The numeric prioritization value.</returns>
        protected override decimal ResolvePriority(IPublishedContent page)
        {
            return 0.5M;
        }

        /// <summary>
        /// Determines the last date that the page object was modified.
        /// </summary>
        /// <param name="page">An object representing a Sitecore page.</param>
        /// <returns>The last date of modification.</returns>
        protected override DateTime ResolveUpdatedDate(IPublishedContent page)
        {
            return page.UpdateDate;
        }

        /// <summary>
        /// Required by the base SpageapNode class, but not used in this implementation.
        /// </summary>
        /// <param name="page">The page to convert.</param>
        /// <returns>The same page.</returns>
        protected override IPublishedContent Convert(IPublishedContent page)
        {
            return page;
        }
    }
}
