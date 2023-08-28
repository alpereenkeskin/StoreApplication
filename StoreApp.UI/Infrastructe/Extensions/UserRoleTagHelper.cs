using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.VisualBasic;

namespace StoreApp.UI.Infrastructe.Extensions
{
    [HtmlTargetElement("td", Attributes = "user-role")]
    public class UserRoleTagHelper : TagHelper
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRoleTagHelper(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HtmlAttributeName("user-name")]
        public String? UserName { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var user = await 
                _userManager
                .FindByNameAsync(UserName);
            TagBuilder ul = new TagBuilder("ul");
            var roles = 
                _roleManager
                .Roles
                .Select(x=>x.Name)
                .ToList();

            foreach (var role in roles)
            {
                TagBuilder li = new TagBuilder("li");
                li.InnerHtml.Append($"{role,-8} : {await _userManager.IsInRoleAsync(user, role)}");
                ul.InnerHtml.AppendHtml(li);
            }
            output.Content.AppendHtml(ul);
        }





        //public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        //{
        //    var user = await _userManager.FindByNameAsync(UserName);
        //    TagBuilder ul = new TagBuilder("ul");
        //    var roles = _roleManager.Roles.ToList();
        //    foreach (var role in roles)
        //    {
        //        TagBuilder li = new TagBuilder("li");
        //        li.InnerHtml.Append($"{role,-8} : {await _userManager.IsInRoleAsync(user, role.ToString())}");
        //        ul.InnerHtml.AppendHtml(li);


        //    }
        //    output.Content.AppendHtml(ul);
        //}
    }
}