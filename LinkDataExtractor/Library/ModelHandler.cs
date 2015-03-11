using System.Collections.Generic;
using LinkDataExtractor.Models;

namespace LinkDataExtractor.Library
{
    public class ModelHandler
    {
        public string Url;
        public string UserAgent;
        public bool FacebookTags;
        public bool TwitterTags;
        public bool ManualTags;

        private HtmlHandler _html;
        private readonly List<string> _images = new List<string>();
        private readonly List<string> _titles = new List<string>();
        private readonly List<string> _descriptions = new List<string>();

        private string GetResponse()
        {
            return HttpHandler.DownloadString(Url, UserAgent);
        }

        public ReturnModel ExtractData()
        {
            _html = new HtmlHandler {Source = GetResponse()};
            _html.FillDocument();

            if (FacebookTags) CollectFacebookData();
            if (TwitterTags) CollectTwitterData();
            if (ManualTags) CollectManualData();

            return new ReturnModel
                   {
                       Images = _images,
                       Titles = _titles,
                       Descriptions = _descriptions
                   };
        }

        private void CollectFacebookData()
        {
            _images.Add(_html.GetFacebookImage());
            _titles.Add(_html.GetFacebookTitle());
            _descriptions.Add(_html.GetFacebookDescription());
        }

        private void CollectTwitterData()
        {
            _images.Add(_html.GetTwitterImage());
            _titles.Add(_html.GetTwitterTitle());
            _descriptions.Add(_html.GetTwitterDescription());
        }

        private void CollectManualData()
        {
            _images.AddRange(_html.GetImages());
            _titles.AddRange(_html.GetTitles());
            _descriptions.AddRange(_html.GetDescriptions());
        }
    }
}