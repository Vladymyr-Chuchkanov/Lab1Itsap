#pragma checksum "D:\Itsap\TWeb1\Views\Main\AddObstacle.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "26bd985f6fc9a047c8dccf5e13826d2ed8cc5c5a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Main_AddObstacle), @"mvc.1.0.view", @"/Views/Main/AddObstacle.cshtml")]
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
#line 1 "D:\Itsap\TWeb1\Views\_ViewImports.cshtml"
using TWeb1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Itsap\TWeb1\Views\_ViewImports.cshtml"
using TWeb1.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"26bd985f6fc9a047c8dccf5e13826d2ed8cc5c5a", @"/Views/Main/AddObstacle.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d93d23cc4f3489b92e3b0c169e117fc9a54b6943", @"/Views/_ViewImports.cshtml")]
    public class Views_Main_AddObstacle : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TWeb1.ObstaclesList>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Main/AddObstacle"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<script src=""https://code.jquery.com/jquery-migrate-3.0.0.js""></script>
<script>

    $(document).ready(function () {

        $(""#navbarGuest"").hide();
        //$(""#navbarAcc"").hide();
    })
    function ShowObstacle(id) {

        var link = '");
#nullable restore
#line 12 "D:\Itsap\TWeb1\Views\Main\AddObstacle.cshtml"
               Write(Url.Action("ShowObstacle","Main",new {id = -101 }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';
        link = link.replace(""-101"", id);

        $(""#dialog"").load(link);
        $(""#dialog"").dialog({
            buttons: [{ text: ""Close"", click: dialogClose, ""class"": ""btn btn-danger"" }],
            autoOpen: false,
            modal: true,
            width: '100%',
            height: '100%',
            position: { my: ""left top"", at: ""left top"", of: window },

            resizable: true

        });
        $("".ui-dialog-titlebar-close"").hide();
        $('#dialog').dialog(""open"");
        $("".ui-dialog-titlebar-close"").hide();
    }
    function dialogClose() {

        $('#dialog').dialog(""close"");
    }
</script>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "26bd985f6fc9a047c8dccf5e13826d2ed8cc5c5a4961", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 38 "D:\Itsap\TWeb1\Views\Main\AddObstacle.cshtml"
Write(Html.HiddenFor(m=>m.str));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 39 "D:\Itsap\TWeb1\Views\Main\AddObstacle.cshtml"
Write(Html.HiddenFor(m=>m.id));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    <div class=\"container-fluid\">\r\n        <div id=\"dialog\"></div>\r\n        <div class=\"row\">\r\n            <div class=\"col-6\">\r\n                <a");
                BeginWriteAttribute("href", " href=\"", 1257, "\"", 1335, 1);
#nullable restore
#line 44 "D:\Itsap\TWeb1\Views\Main\AddObstacle.cshtml"
WriteAttributeValue("", 1264, Url.Action("CreateObstacle","Main",new {idC = Model.id,str=Model.str}), 1264, 71, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Створити Етап</a>\r\n            </div>\r\n            <div class=\"col-6\">\r\n                <a");
                BeginWriteAttribute("href", " href=\"", 1427, "\"", 1506, 1);
#nullable restore
#line 47 "D:\Itsap\TWeb1\Views\Main\AddObstacle.cshtml"
WriteAttributeValue("", 1434, Url.Action("CompetitionAdmin","Main",new {id = Model.id,str=Model.str}), 1434, 72, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Повернутися до змагання</a>\r\n            </div>\r\n        </div>\r\n        <div class=\"row\">\r\n            <div class=\"col-8\">\r\n                ");
#nullable restore
#line 52 "D:\Itsap\TWeb1\Views\Main\AddObstacle.cshtml"
           Write(Html.TextBoxFor(m => m.Search, new { @class = "form-control form-control-sm" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
            </div>
            <div class=""col-4"">
                <button class=""btn btn-success btn-sm"" type=""submit"">Пошук</button>
            </div>
        </div>
        <div class=""row"">
            <table class=""table table-borderless table-sm  table-striped table-hover"">
                <tr class=""row"">
                    <td class=""col-2"">Назва</td>
                    <td class=""col-2"">Опис</td>
                    <td class=""col-2"">Умови подолання</td>
                    <td class=""col-2"">Рух першого</td>
                    <td class=""col-1"">Довжина</td>
                    <td class=""col-1"">ОЧ</td>
                    <td class=""col-1"">КЧ</td>
                    <td class=""col-1"">###</td>
                </tr>
");
#nullable restore
#line 70 "D:\Itsap\TWeb1\Views\Main\AddObstacle.cshtml"
                 foreach (var it in Model.Obstacles)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <tr class=\"row\">\r\n                        <td class=\"col-2\"");
                BeginWriteAttribute("onclick", " onclick=\"", 2638, "\"", 2678, 3);
                WriteAttributeValue("", 2648, "ShowObstacle(\'", 2648, 14, true);
#nullable restore
#line 73 "D:\Itsap\TWeb1\Views\Main\AddObstacle.cshtml"
WriteAttributeValue("", 2662, it.ObstacleId, 2662, 14, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 2676, "\')", 2676, 2, true);
                EndWriteAttribute();
                WriteLiteral("> ");
#nullable restore
#line 73 "D:\Itsap\TWeb1\Views\Main\AddObstacle.cshtml"
                                                                               Write(it.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td class=\"col-2\"");
                BeginWriteAttribute("onclick", " onclick=\"", 2737, "\"", 2777, 3);
                WriteAttributeValue("", 2747, "ShowObstacle(\'", 2747, 14, true);
#nullable restore
#line 74 "D:\Itsap\TWeb1\Views\Main\AddObstacle.cshtml"
WriteAttributeValue("", 2761, it.ObstacleId, 2761, 14, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 2775, "\')", 2775, 2, true);
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 74 "D:\Itsap\TWeb1\Views\Main\AddObstacle.cshtml"
                                                                              Write(it.AdditionalDescription);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td class=\"col-2\"");
                BeginWriteAttribute("onclick", " onclick=\"", 2852, "\"", 2892, 3);
                WriteAttributeValue("", 2862, "ShowObstacle(\'", 2862, 14, true);
#nullable restore
#line 75 "D:\Itsap\TWeb1\Views\Main\AddObstacle.cshtml"
WriteAttributeValue("", 2876, it.ObstacleId, 2876, 14, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 2890, "\')", 2890, 2, true);
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 75 "D:\Itsap\TWeb1\Views\Main\AddObstacle.cshtml"
                                                                              Write(it.ConditionsOvercoming);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td class=\"col-2\"");
                BeginWriteAttribute("onclick", " onclick=\"", 2966, "\"", 3006, 3);
                WriteAttributeValue("", 2976, "ShowObstacle(\'", 2976, 14, true);
#nullable restore
#line 76 "D:\Itsap\TWeb1\Views\Main\AddObstacle.cshtml"
WriteAttributeValue("", 2990, it.ObstacleId, 2990, 14, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 3004, "\')", 3004, 2, true);
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 76 "D:\Itsap\TWeb1\Views\Main\AddObstacle.cshtml"
                                                                              Write(it.MovementFirst);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td class=\"col-1\"");
                BeginWriteAttribute("onclick", " onclick=\"", 3073, "\"", 3113, 3);
                WriteAttributeValue("", 3083, "ShowObstacle(\'", 3083, 14, true);
#nullable restore
#line 77 "D:\Itsap\TWeb1\Views\Main\AddObstacle.cshtml"
WriteAttributeValue("", 3097, it.ObstacleId, 3097, 14, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 3111, "\')", 3111, 2, true);
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 77 "D:\Itsap\TWeb1\Views\Main\AddObstacle.cshtml"
                                                                              Write(it.Length);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td class=\"col-1\"");
                BeginWriteAttribute("onclick", " onclick=\"", 3173, "\"", 3213, 3);
                WriteAttributeValue("", 3183, "ShowObstacle(\'", 3183, 14, true);
#nullable restore
#line 78 "D:\Itsap\TWeb1\Views\Main\AddObstacle.cshtml"
WriteAttributeValue("", 3197, it.ObstacleId, 3197, 14, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 3211, "\')", 3211, 2, true);
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 78 "D:\Itsap\TWeb1\Views\Main\AddObstacle.cshtml"
                                                                              Write(it.OptTime);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td class=\"col-1\"");
                BeginWriteAttribute("onclick", " onclick=\"", 3274, "\"", 3314, 3);
                WriteAttributeValue("", 3284, "ShowObstacle(\'", 3284, 14, true);
#nullable restore
#line 79 "D:\Itsap\TWeb1\Views\Main\AddObstacle.cshtml"
WriteAttributeValue("", 3298, it.ObstacleId, 3298, 14, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 3312, "\')", 3312, 2, true);
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 79 "D:\Itsap\TWeb1\Views\Main\AddObstacle.cshtml"
                                                                              Write(it.CriticalTime);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td class=\"col-1\">\r\n                            <div class=\"input-group\">\r\n                                <a");
                BeginWriteAttribute("href", " href=\"", 3472, "\"", 3581, 1);
#nullable restore
#line 82 "D:\Itsap\TWeb1\Views\Main\AddObstacle.cshtml"
WriteAttributeValue("", 3479, Url.Action("AddObs","Main",new {str=Model.str,idC = Model.id,idO=it.ObstacleId,calc = Model.calc++ }), 3479, 102, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                    <i class=\"fas fa-plus fa-fw\" style=\"color:green\"></i>\r\n                                </a>\r\n                                <a");
                BeginWriteAttribute("href", " href=\"", 3748, "\"", 3850, 1);
#nullable restore
#line 85 "D:\Itsap\TWeb1\Views\Main\AddObstacle.cshtml"
WriteAttributeValue("", 3755, Url.Action("EditObstacle","Main",new {str=Model.str,idC = Model.id,idO=it.ObstacleId,back=2 }), 3755, 95, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                    <i class=\"fas fa-pencil-alt fa-fw\"></i>\r\n                                </a>\r\n                                <a");
                BeginWriteAttribute("href", " href=\"", 4003, "\"", 4122, 1);
#nullable restore
#line 88 "D:\Itsap\TWeb1\Views\Main\AddObstacle.cshtml"
WriteAttributeValue("", 4010, Url.Action("DeleteObstacle","Main",new {str=Model.str,idC = Model.id,idO=it.ObstacleId,Search = Model.Search }), 4010, 112, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                    <i class=\"fas fa-trash-alt fa-fw\"></i>\r\n                                </a>\r\n                            </div>\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 94 "D:\Itsap\TWeb1\Views\Main\AddObstacle.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </table>\r\n        </div>\r\n\r\n\r\n    </div>\r\n\r\n\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TWeb1.ObstaclesList> Html { get; private set; }
    }
}
#pragma warning restore 1591
