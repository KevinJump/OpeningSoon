using System;

using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.PropertyEditors;

namespace Our.Umbraco.OpeningSoon
{
    public class OpeningSoonPropertyValueConverter :
        PropertyValueConverterBase
    {
        private static string EditorAlias = "Our.Umbraco.OpeningSoon";

        public override bool IsConverter(IPublishedPropertyType propertyType)
            => EditorAlias == propertyType.EditorAlias;

        public override Type GetPropertyValueType(IPublishedPropertyType propertyType)
            => typeof(OpeningSoonModel);

        public override PropertyCacheLevel GetPropertyCacheLevel(IPublishedPropertyType propertyType)
            => PropertyCacheLevel.Element;

        public override object ConvertSourceToIntermediate(IPublishedElement owner, IPublishedPropertyType propertyType, object source, bool preview)
            => OpeningSoonModel.Deserialize((string)source);
    }
}
