using Microsoft.AspNetCore.Razor.TagHelpers;

namespace EAD.Checkpoint01.TagHelpers
{
    public class SubmitButtonTagHelper : TagHelper
    {
        public string Text { get; set; }
        public string Class { get; set; }
        public string Icon { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "button";
            output.Attributes.SetAttribute("type", "submit");
            output.Attributes.SetAttribute("class", string.IsNullOrEmpty(Class) ? "btn btn-success" : Class);
            output.Content.SetHtmlContent(@$"{Text ?? "Cadastrar"} <i class='{Icon ?? "bi bi-check-lg"}'></i>");
        }
    }
}
