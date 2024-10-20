using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Shop.Domain.Entities;

namespace ShopProject1.Infrastructures
{
    [HtmlTargetElement("nav", Attributes = "page-model")]
    public class PagerTagHelper : TagHelper
    {
        // for generating the link we need IUrlHelperFactory
        private IUrlHelperFactory urlHelperFactory;

        public PagerTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }

        // system will inject from outside on base on this attribute 
        [ViewContext]
        [HtmlAttributeNotBound] // we didn't want to change it from outside we put this attribute 
        public ViewContext ViewContext { get; set; }
        public PagingData PageModel { get; set; }
        public string PageAction { get; set; }
        public string PageController { get; set; }
        public string PageCategory { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // for generating dynamic url
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

            // for generating the ul tag and its the attribute of class should be pagination
            TagBuilder result = new TagBuilder("ul");
            result.Attributes["class"] = "pagination";

            // for generating our link one by one (until the amount of TotalPages) in our li we should put a tag 
            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder litag = new TagBuilder("li");
                TagBuilder tag = new TagBuilder("a");

                if (string.IsNullOrEmpty(PageCategory))
                {
                    tag.Attributes["href"] = urlHelper.Action(PageAction, PageController, new { page = i });
                }
                else
                {
                    tag.Attributes["href"] = urlHelper.Action(PageAction, PageController, new { page = i, category = PageCategory });
                }

                // we add the a to the li, the inner text of a should be i 
                tag.InnerHtml.Append(i.ToString());

                // in li put the a tag that we created
                litag.InnerHtml.AppendHtml(tag);

                // we added the li to the ul 
                result.InnerHtml.AppendHtml(litag);
            }

            // into the content of output we add the tags that we generated 
            output.Content.AppendHtml(result);
        }
    }
}
