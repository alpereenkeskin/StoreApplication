using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using StoreApp.Entites;
using StoreApp.Services.Concrete;

namespace StoreApp.UI.Infrastructe.Extensions
{
    [HtmlTargetElement("div", Attributes = "products")]
    public class LastestProductsTagHelper : TagHelper
    {
        private readonly IServiceManager _serviceManager;

        [HtmlAttributeName("Number")]// View alanında attribute olarak number değerini bunun sayesinde alıyoruz.
        public int Number { get; set; }


        public LastestProductsTagHelper(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            TagBuilder div = new TagBuilder("div");
            div.Attributes.Add("class", "my-3");

            TagBuilder h6 = new TagBuilder("h6");
            h6.Attributes.Add("class", "lead");

            TagBuilder i = new TagBuilder("i");
            i.Attributes.Add("class", "text-secondary");



            h6.InnerHtml.AppendHtml(i);
            h6.InnerHtml.AppendHtml("Lastest Products");


            TagBuilder ul = new TagBuilder("ul");
            var products = _serviceManager.ProductService.GetLatesProducts(Number, false);
            foreach (Product product in products)
            {
                TagBuilder li = new TagBuilder("li");
                TagBuilder a = new TagBuilder("a");
                a.Attributes.Add("href", $"/home/getproduct/{product.ProductId}");
                a.InnerHtml.AppendHtml(product.ProductName);
                li.InnerHtml.AppendHtml(a);
                ul.InnerHtml.AppendHtml(li);


            }
            div.InnerHtml.AppendHtml(h6);
            div.InnerHtml.AppendHtml(ul);
            output.Content.AppendHtml(div);
        }
    }
}