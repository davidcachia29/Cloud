#pragma checksum "E:\Level 6\3\Year2\Cloud\Project1.1\PFCMSD63A\WebApplication1\Views\Driver\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9dc1e1d44f1c182f8ad5609c4e4ac238aa3411c4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Driver_Index), @"mvc.1.0.view", @"/Views/Driver/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "E:\Level 6\3\Year2\Cloud\Project1.1\PFCMSD63A\WebApplication1\Views\_ViewImports.cshtml"
using WebApplication1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Level 6\3\Year2\Cloud\Project1.1\PFCMSD63A\WebApplication1\Views\_ViewImports.cshtml"
using WebApplication1.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9dc1e1d44f1c182f8ad5609c4e4ac238aa3411c4", @"/Views/Driver/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"729efaa87342638aecfe1a972ce9f9f8dff55b4c", @"/Views/_ViewImports.cshtml")]
    public class Views_Driver_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebApplication1.Models.Domain.Booking>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\Level 6\3\Year2\Cloud\Project1.1\PFCMSD63A\WebApplication1\Views\Driver\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9dc1e1d44f1c182f8ad5609c4e4ac238aa3411c43723", async() => {
                WriteLiteral("Create New");
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
            WriteLiteral("\r\n</p>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 17 "E:\Level 6\3\Year2\Cloud\Project1.1\PFCMSD63A\WebApplication1\Views\Driver\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.BookingID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 20 "E:\Level 6\3\Year2\Cloud\Project1.1\PFCMSD63A\WebApplication1\Views\Driver\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.PassangerName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>            \r\n            <th>\r\n                ");
#nullable restore
#line 23 "E:\Level 6\3\Year2\Cloud\Project1.1\PFCMSD63A\WebApplication1\Views\Driver\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Categories));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 26 "E:\Level 6\3\Year2\Cloud\Project1.1\PFCMSD63A\WebApplication1\Views\Driver\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.accepted));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n\r\n\r\n\r\n\r\n");
#nullable restore
#line 36 "E:\Level 6\3\Year2\Cloud\Project1.1\PFCMSD63A\WebApplication1\Views\Driver\Index.cshtml"
         foreach (var item in Model)
        {


            if (this.User.IsInRole("BUISNESS"))
            {
                if (item.Categories == "Business")
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 46 "E:\Level 6\3\Year2\Cloud\Project1.1\PFCMSD63A\WebApplication1\Views\Driver\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.BookingID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 49 "E:\Level 6\3\Year2\Cloud\Project1.1\PFCMSD63A\WebApplication1\Views\Driver\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.PassangerName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>                        \r\n                        <td>\r\n                            ");
#nullable restore
#line 52 "E:\Level 6\3\Year2\Cloud\Project1.1\PFCMSD63A\WebApplication1\Views\Driver\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Categories));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 55 "E:\Level 6\3\Year2\Cloud\Project1.1\PFCMSD63A\WebApplication1\Views\Driver\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.accepted));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 58 "E:\Level 6\3\Year2\Cloud\Project1.1\PFCMSD63A\WebApplication1\Views\Driver\Index.cshtml"
                       Write(Html.ActionLink("Accept Ride", "UpdateAcceptance", new { BookingID = item.BookingID, Accapted = item.accepted }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 61 "E:\Level 6\3\Year2\Cloud\Project1.1\PFCMSD63A\WebApplication1\Views\Driver\Index.cshtml"
                }
            }

            if (this.User.IsInRole("LUXURY"))
            {
                if (item.Categories == "luxury" & item.accepted == false)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 70 "E:\Level 6\3\Year2\Cloud\Project1.1\PFCMSD63A\WebApplication1\Views\Driver\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.BookingID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 73 "E:\Level 6\3\Year2\Cloud\Project1.1\PFCMSD63A\WebApplication1\Views\Driver\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.PassangerName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>                       \r\n                        <td>\r\n                            ");
#nullable restore
#line 76 "E:\Level 6\3\Year2\Cloud\Project1.1\PFCMSD63A\WebApplication1\Views\Driver\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Categories));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 79 "E:\Level 6\3\Year2\Cloud\Project1.1\PFCMSD63A\WebApplication1\Views\Driver\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.accepted));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 82 "E:\Level 6\3\Year2\Cloud\Project1.1\PFCMSD63A\WebApplication1\Views\Driver\Index.cshtml"
                       Write(Html.ActionLink("Accept Ride", "UpdateAcceptance", new { BookingID = item.BookingID  , Accapted = item.accepted}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 85 "E:\Level 6\3\Year2\Cloud\Project1.1\PFCMSD63A\WebApplication1\Views\Driver\Index.cshtml"
                }
            }

            if (this.User.IsInRole("ECONOMY"))
            {
                if (item.Categories == "Economy")
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 94 "E:\Level 6\3\Year2\Cloud\Project1.1\PFCMSD63A\WebApplication1\Views\Driver\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.BookingID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 97 "E:\Level 6\3\Year2\Cloud\Project1.1\PFCMSD63A\WebApplication1\Views\Driver\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.PassangerName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>                        \r\n                        <td>\r\n                            ");
#nullable restore
#line 100 "E:\Level 6\3\Year2\Cloud\Project1.1\PFCMSD63A\WebApplication1\Views\Driver\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Categories));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 103 "E:\Level 6\3\Year2\Cloud\Project1.1\PFCMSD63A\WebApplication1\Views\Driver\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.accepted));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 106 "E:\Level 6\3\Year2\Cloud\Project1.1\PFCMSD63A\WebApplication1\Views\Driver\Index.cshtml"
                       Write(Html.ActionLink("Accept Ride", "UpdateAcceptance", new { BookingID = item.BookingID, Accapted = item.accepted }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 109 "E:\Level 6\3\Year2\Cloud\Project1.1\PFCMSD63A\WebApplication1\Views\Driver\Index.cshtml"
                }
            }

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebApplication1.Models.Domain.Booking>> Html { get; private set; }
    }
}
#pragma warning restore 1591
