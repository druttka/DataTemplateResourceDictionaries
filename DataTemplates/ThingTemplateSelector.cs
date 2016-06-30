using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DataTemplates
{
    public class ThingTemplateSelector : DataTemplateSelector
    {
        private readonly Dictionary<Type, DataTemplate> TemplatesByType;
        private readonly ResourceDictionary Resources;

        public ThingTemplateSelector() : this(Application.Current.Resources)
        {

        }

        public ThingTemplateSelector(ResourceDictionary resources)
        {
            Resources = resources;
            
            TemplatesByType = new Dictionary<Type, DataTemplate>
            {
                { typeof(RedThing), resources["RedThingTemplate"] as DataTemplate },
                { typeof(BlueThing), resources["BlueThingTemplate"] as DataTemplate }
            };
        }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            DataTemplate dataTemplate;

            if (TemplatesByType.TryGetValue(item?.GetType(), out dataTemplate))
            {
                return dataTemplate;
            }
            
            return base.SelectTemplateCore(item, container);
        }
    }
}
