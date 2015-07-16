using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using umbraco.interfaces;

using Umbraco.Core.Configuration;

namespace Jumoo.OpeningSoon.Installer
{
    public class AddLocalizationStuff : IPackageAction
    {
        public string Alias()
        {
            return "OpeningSoon_AddLocalizationStuff";
        }

        public bool Execute(string packageName, XmlNode xmlData)
        {
            if (UmbracoVersion.Current.Major == 7 && UmbracoVersion.Current.Minor < 3)
            {
                TranslationHelper.AddTranslations();
            }
            return true;
        }

        public bool Undo(string packageName, XmlNode xmlData)
        {
            if (UmbracoVersion.Current.Major == 7 && UmbracoVersion.Current.Minor < 3)
            {
                TranslationHelper.RemoveTranslations();
            }
            return true;
        }


        public XmlNode SampleXml()
        {
            var xml = "<Action runat=\"install\" undo=\"true\" alias=\" />";
            XmlDocument x = new XmlDocument();
            x.LoadXml(xml);
            return x; 
        }


    }
}
