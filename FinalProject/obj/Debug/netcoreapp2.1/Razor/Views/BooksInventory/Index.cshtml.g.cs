#pragma checksum "/Users/madina/Projects/FinalProject/FinalProject/Views/BooksInventory/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ed22f42a429267b36a003165b21b93b4470596a5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(FinalProject.Views.BooksInventory.Views_BooksInventory_Index), @"mvc.1.0.view", @"/Views/BooksInventory/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/BooksInventory/Index.cshtml", typeof(FinalProject.Views.BooksInventory.Views_BooksInventory_Index))]
namespace FinalProject.Views.BooksInventory
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "/Users/madina/Projects/FinalProject/FinalProject/Views/_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 4 "/Users/madina/Projects/FinalProject/FinalProject/Views/_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed22f42a429267b36a003165b21b93b4470596a5", @"/Views/BooksInventory/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5828b75983512cb417032f0de0b685251c6570d7", @"/Views/_ViewImports.cshtml")]
    public class Views_BooksInventory_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<FinalProject.Models.BooksInventory>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(56, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "/Users/madina/Projects/FinalProject/FinalProject/Views/BooksInventory/Index.cshtml"
  
Layout = "_Layout";
var title = "READ BooksInventory";
ViewData["Title"] = title;

#line default
#line hidden
            BeginContext(150, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(154, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "75b21450c9c94ebba19955b94efbb391", async() => {
                BeginContext(177, 10, true);
                WriteLiteral("Create New");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(191, 319, true);
            WriteLiteral(@"

<table class=""table table-bordered table-sm table-striped"">
    <thead>
        <tr>
            <th>
               Book Name
            </th>
            <th>
                Inventory
            </th>
            <th>Update</th>
            <th>Delete</th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 26 "/Users/madina/Projects/FinalProject/FinalProject/Views/BooksInventory/Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(559, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(620, 50, false);
#line 30 "/Users/madina/Projects/FinalProject/FinalProject/Views/BooksInventory/Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Book.Book_title));

#line default
#line hidden
            EndContext();
            BeginContext(670, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(738, 48, false);
#line 33 "/Users/madina/Projects/FinalProject/FinalProject/Views/BooksInventory/Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.User.FullName));

#line default
#line hidden
            EndContext();
            BeginContext(786, 69, true);
            WriteLiteral("\r\n                </td>\r\n\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(856, 83, false);
#line 37 "/Users/madina/Projects/FinalProject/FinalProject/Views/BooksInventory/Index.cshtml"
               Write(Html.ActionLink("Update", "Update", new { id1 = item.Book_id, id2 = item.User_id }));

#line default
#line hidden
            EndContext();
            BeginContext(939, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1007, 83, false);
#line 40 "/Users/madina/Projects/FinalProject/FinalProject/Views/BooksInventory/Index.cshtml"
               Write(Html.ActionLink("Delete", "Delete", new { id1 = item.Book_id, id2 = item.User_id }));

#line default
#line hidden
            EndContext();
            BeginContext(1090, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 43 "/Users/madina/Projects/FinalProject/FinalProject/Views/BooksInventory/Index.cshtml"
        }

#line default
#line hidden
            BeginContext(1145, 22, true);
            WriteLiteral("    </tbody>\r\n</table>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<FinalProject.Models.BooksInventory>> Html { get; private set; }
    }
}
#pragma warning restore 1591
