using Microsoft.AspNetCore.Razor.TagHelpers;

namespace StoreApp.UI.Infrastructe
{
    [HtmlTargetElement("table")]// projedeki bütün table etiketleri 
    public class TableTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("class", "table");// burada projedeki bütün table etiketlerin classlarına table ekleniyor.
        }

    }

}