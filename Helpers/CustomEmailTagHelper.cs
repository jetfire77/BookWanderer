using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Tanuj.BookStore.Helpers
{
    public class CustomEmailTagHelper : TagHelper
    {
        public string MyEmail { get; set; }    // to set email form view
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", $"mailto:{MyEmail}");
            output.Attributes.Add("id", "my-email-id");

            output.Content.SetContent("Contact us");
        }


    }
}
