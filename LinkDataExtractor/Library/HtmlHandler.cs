using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace LinkDataExtractor.Library
{
    public class HtmlHandler
    {
        public string Source;
        public HtmlDocument Document;

        public void FillDocument()
        {
            Document = new HtmlDocument();
            Document.LoadHtml(Source);
        }

        #region Facebook Extractor

        public string GetFacebookImage()
        {
            var node = Document.DocumentNode.SelectSingleNode("//meta[@property='og:image']");

            if (node == null)
            {
                Document.DocumentNode.SelectSingleNode("//meta[@name='og:image']");
            }

            return node == null ? string.Empty : node.Attributes["content"].Value;
        }

        public string GetFacebookTitle()
        {
            var node = Document.DocumentNode.SelectSingleNode("//meta[@property='og:title']");

            if (node == null)
            {
                Document.DocumentNode.SelectSingleNode("//meta[@name='og:title']");
            }

            return node == null ? string.Empty : node.Attributes["content"].Value;
        }

        public string GetFacebookDescription()
        {
            var node = Document.DocumentNode.SelectSingleNode("//meta[@property='og:description']");

            if (node == null)
            {
                Document.DocumentNode.SelectSingleNode("//meta[@name='og:description']");
            }

            return node == null ? string.Empty : node.Attributes["content"].Value;
        }

        #endregion

        #region Twitter Extractor

        public string GetTwitterImage()
        {
            var node = Document.DocumentNode.SelectSingleNode("//meta[@name='twitter:image']") ??
                       Document.DocumentNode.SelectSingleNode("//meta[@property='twitter:image']");

            return node == null ? string.Empty : node.Attributes["content"].Value;
        }

        public string GetTwitterTitle()
        {
            var node = Document.DocumentNode.SelectSingleNode("//meta[@name='twitter:title']") ??
                       Document.DocumentNode.SelectSingleNode("//meta[@property='twitter:title']");

            return node == null ? string.Empty : node.Attributes["content"].Value;
        }

        public string GetTwitterDescription()
        {
            var node = Document.DocumentNode.SelectSingleNode("//meta[@name='twitter:description']") ??
                       Document.DocumentNode.SelectSingleNode("//meta[@property='twitter:description']");

            return node == null ? string.Empty : node.Attributes["content"].Value;
        }

        #endregion

        #region Manual Extractor

        public IEnumerable<string> GetImages()
        {
            var urls = Document.DocumentNode.Descendants("img")
                                .Select(t => t.GetAttributeValue("src", null))
                                .Where(s => !String.IsNullOrEmpty(s));

            return urls.ToList();
        }

        public IEnumerable<string> GetTitles()
        {

            var titles =
                Document.DocumentNode.Descendants("h1")
                    .Select(t => t.InnerText)
                    .Where(s => !String.IsNullOrEmpty(s));

            return titles.ToList();
        }

        public IEnumerable<string> GetDescriptions()
        {
            var titles =
                Document.DocumentNode.Descendants("p")
                    .Select(t => t.InnerText)
                    .Where(s => !String.IsNullOrEmpty(s));

            return titles.ToList();
        }

        #endregion

    }
}