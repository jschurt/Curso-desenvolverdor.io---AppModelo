using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace JSchurt.UI.Site.Extensions.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {

        public string EmailDomain { get; set; } = "email.com";

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            //minha taghelper vai gerar um link
            output.TagName = "a";

            //Pegando a informacao que esta dentro da tag (<email>content</email>)
            var content = await output.GetChildContentAsync();
            var target = content.GetContent() + $"@{EmailDomain}";

            //Setando atributos que serao adicionados no meu link
            output.Attributes.SetAttribute("href", $"mailto:{target}");

            //Setando valor que sera colocado dentro da tag <a>valor</a>
            output.Content.SetContent(target);

        } //ProcessAsync

    } //class
} //namespace
