using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharePay.Web.Models.Base
{
    public class MetaTagsModel
    {
        public MetaTagsModel()
        {
            this.SiteTitle = System.Configuration.ConfigurationManager.AppSettings["SiteTitle"].ToString();
            this.MetaDescription = System.Configuration.ConfigurationManager.AppSettings["SiteDescription"].ToString();
            this.MetaImageUrl = System.Configuration.ConfigurationManager.AppSettings["MetaImageUrl"].ToString();
            this.MetaUrl = System.Configuration.ConfigurationManager.AppSettings["MetaUrl"].ToString();
            this.SiteKeyWords = System.Configuration.ConfigurationManager.AppSettings["SiteKeywords"].ToString();
        }

        public string SiteTitle { get; set; }

        public string SiteKeyWords { get; set; }

        public string MetaDescription { get; set; }

        public string MetaImageUrl { get; set; }

        public string MetaUrl { get; set; }


        public void SetValues(string SiteTitle, string MetaDescription, string MetaImageUrl, string MetaUrl)
        {
            this.SiteTitle = string.IsNullOrEmpty(SiteTitle) ? System.Configuration.ConfigurationManager.AppSettings["SiteTitle"].ToString() : SiteTitle;
            this.MetaDescription = string.IsNullOrEmpty(MetaDescription) ? System.Configuration.ConfigurationManager.AppSettings["SiteDescription"].ToString() : MetaDescription;
            this.MetaImageUrl = string.IsNullOrEmpty(MetaImageUrl) ? System.Configuration.ConfigurationManager.AppSettings["MetaImageUrl"].ToString() : MetaImageUrl;
            this.MetaUrl = string.IsNullOrEmpty(MetaUrl) ? System.Configuration.ConfigurationManager.AppSettings["MetaUrl"].ToString() : MetaUrl;
            this.SiteKeyWords = System.Configuration.ConfigurationManager.AppSettings["SiteKeywords"].ToString();
        }
    }
}