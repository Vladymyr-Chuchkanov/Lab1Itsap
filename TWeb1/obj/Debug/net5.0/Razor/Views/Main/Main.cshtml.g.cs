#pragma checksum "D:\Itsap\TWeb1\Views\Main\Main.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3976d11c5ced421423f5215bd65e04df45005fe9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Main_Main), @"mvc.1.0.view", @"/Views/Main/Main.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3976d11c5ced421423f5215bd65e04df45005fe9", @"/Views/Main/Main.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d93d23cc4f3489b92e3b0c169e117fc9a54b6943", @"/Views/_ViewImports.cshtml")]
    public class Views_Main_Main : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TWeb1.Items>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("MainForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Main/Main"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral(@"<link rel=""stylesheet"" href=""https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css"">


<link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/bootstrap-select/1.13.1/css/bootstrap-select.css"" />
<script src=""https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.bundle.min.js""></script>
<script src=""https://cdnjs.cloudflare.com/ajax/libs/bootstrap-select/1.13.1/js/bootstrap-select.min.js""></script>



<script src=""https://cdn.jsdelivr.net/npm/bootstrap-datepicker@1.9.0/dist/js/bootstrap-datepicker.min.js""></script>
<link id=""bsdp-css"" href=""https://unpkg.com/bootstrap-datepicker@1.9.0/dist/css/bootstrap-datepicker3.min.css"" rel=""stylesheet"">
<script>

    $(document).ready(function () {
        var role = ");
#nullable restore
#line 19 "D:\Itsap\TWeb1\Views\Main\Main.cshtml"
              Write(Html.Raw(Newtonsoft.Json.JsonConvert.SerializeObject(Dict.dApp.Role) as String));

#line default
#line hidden
#nullable disable
            WriteLiteral(@";
        if (role == ""гість"") {
            $(""#navbarAcc"").hide();
        } else {
            $(""#navbarGuest"").hide();
        }
        if (role !=""адмін"") {
            $(""#AdminF"").hide();
        }
    })
</script>
<script type=""text/javascript"">
    
    function Search() {



        var typs = $(""#SelectTypes"").val();

        
        var comps = $(""#SelectCompl"").val();
        //alert(typs);
        //alert(comps);
        $(""#SearchDateFrom"").val(document.getElementById(""SearchDateFrom_0"").value);
        $(""#SearchDateTo"").val(document.getElementById(""SearchDateTo_0"").value);
        $(""#SearchTypes"").val ( typs);
        $(""#SearchComplexities"").val( comps);
        $(""#MainForm"").submit();
    }

</script>
<script>

    $(function () {

        $('.datePick').datepicker({
            format: ""mm/dd/yyyy"",
            todayBtn: ""linked"",
            clearBtn: true,
            orientation: ""bottom auto"",
            todayHighlight: true
        });
");
            WriteLiteral("\n\r\n    });\r\n</script>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3976d11c5ced421423f5215bd65e04df45005fe96543", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3976d11c5ced421423f5215bd65e04df45005fe96805", async() => {
                    WriteLiteral("\r\n        <div class=\"container-fluid\" style=\"min-width: 330px;\">\r\n            \r\n            ");
#nullable restore
#line 69 "D:\Itsap\TWeb1\Views\Main\Main.cshtml"
       Write(Html.HiddenFor(m => m.SearchTypes));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n            ");
#nullable restore
#line 70 "D:\Itsap\TWeb1\Views\Main\Main.cshtml"
       Write(Html.HiddenFor(m => m.SearchComplexities));

#line default
#line hidden
#nullable disable
                    WriteLiteral(@"
            
             <div class=""row"">

                <div id=""AdminF""class=""col-4 col-sm-2"">


                    
                    <a href=""/Main/CompetitionAdmin""><i class=""fas fa-plus fa-fw"" style=""color:green""></i></a>
                    
                </div>

                <div class=""col-6 col-sm-2"">
                    <div class=""row"">
                        <button type=""button"" onclick=""Search()"" class=""btn btn-success btn-sm col-3""><i class=""fas fa-search fa-fw""></i></button>
                        ");
#nullable restore
#line 85 "D:\Itsap\TWeb1\Views\Main\Main.cshtml"
                   Write(Html.TextBoxFor(m => m.SearchNameMain, new { @class = "form-control form-control-sm col-8", @placeholder = "Пошук" }));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                    </div>\r\n                </div>\r\n\r\n                <div class=\"col-12 col-sm-8\">\r\n                    <div class=\"row\">\r\n                        ");
#nullable restore
#line 91 "D:\Itsap\TWeb1\Views\Main\Main.cshtml"
                   Write(Html.HiddenFor(m => m.SearchDateFrom));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                        ");
#nullable restore
#line 92 "D:\Itsap\TWeb1\Views\Main\Main.cshtml"
                   Write(Html.HiddenFor(m => m.SearchDateTo));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                        <label class=\"col-3 col-sm-3 col-lg-2 \" style=\"white-space: nowrap;\">Дата вiд:</label>\r\n                        <input type=\"text\" id=\"SearchDateFrom_0\" class=\"datePick form-control col-8 col-sm-3  form-control-sm text-center \"");
                    BeginWriteAttribute("value", " value=\"", 3363, "\"", 3419, 1);
#nullable restore
#line 94 "D:\Itsap\TWeb1\Views\Main\Main.cshtml"
WriteAttributeValue("", 3371, Model.SearchDateFrom.ToString().Split(" ")[0], 3371, 48, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(@">
                        <label class=""col-3 col-sm-3 col-lg-2 mt-1 "" style=""white-space: nowrap;""> Дата до:</label>
                        <input type=""text"" id=""SearchDateTo_0"" class=""mt-1 datePick form-control col-8 col-sm-3  form-control-sm text-center mt-sm-0""");
                    BeginWriteAttribute("value", " value=\"", 3689, "\"", 3743, 1);
#nullable restore
#line 96 "D:\Itsap\TWeb1\Views\Main\Main.cshtml"
WriteAttributeValue("", 3697, Model.SearchDateTo.ToString().Split(" ")[0], 3697, 46, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(@">

                    </div>
                </div>
                <div class=""col-12"">
                    <div class=""row"">
                        <div class=""col-6"">
                            <label>Тип</label>
                            <select class=""selectpicker"" id=""SelectTypes"" multiple data-live-search=""true"" style=""width:100%"">
");
#nullable restore
#line 105 "D:\Itsap\TWeb1\Views\Main\Main.cshtml"
                                 foreach (var typ in Dict.ListType)
                                {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                                    ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3976d11c5ced421423f5215bd65e04df45005fe911122", async() => {
#nullable restore
#line 107 "D:\Itsap\TWeb1\Views\Main\Main.cshtml"
                                                       Write(typ.Name);

#line default
#line hidden
#nullable disable
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    BeginWriteTagHelperAttribute();
#nullable restore
#line 107 "D:\Itsap\TWeb1\Views\Main\Main.cshtml"
                                       WriteLiteral(typ.ID);

#line default
#line hidden
#nullable disable
                    __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                    __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n");
#nullable restore
#line 108 "D:\Itsap\TWeb1\Views\Main\Main.cshtml"
                                }

#line default
#line hidden
#nullable disable
                    WriteLiteral(@"                            </select>
                        </div>
                        <div class=""col-6"">
                            <label>Клас</label>
                            <select class=""selectpicker"" id=""SelectCompl"" multiple data-live-search=""true"" style=""width:100%"">
");
#nullable restore
#line 114 "D:\Itsap\TWeb1\Views\Main\Main.cshtml"
                                 foreach (var com in Dict.ListComplexity)
                                {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                                    ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3976d11c5ced421423f5215bd65e04df45005fe913796", async() => {
#nullable restore
#line 116 "D:\Itsap\TWeb1\Views\Main\Main.cshtml"
                                                       Write(com.Name);

#line default
#line hidden
#nullable disable
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    BeginWriteTagHelperAttribute();
#nullable restore
#line 116 "D:\Itsap\TWeb1\Views\Main\Main.cshtml"
                                       WriteLiteral(com.ID);

#line default
#line hidden
#nullable disable
                    __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                    __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n");
#nullable restore
#line 117 "D:\Itsap\TWeb1\Views\Main\Main.cshtml"
                                }

#line default
#line hidden
#nullable disable
                    WriteLiteral(@"                            </select>
                        </div>
                    </div>
                </div>

            </div>

            <div class=""row"">
                <table class=""table table-borderless table-sm  table-striped table-hover"" style=""min-width:720px;"">

                    <tr class=""row"" style=""background-color: green;color: WHITE;font-weight: bold;"">
                        <td class=""col-2"">Назва</td>
                        <td class=""col-1"">Місце</td>
                        <td class=""col-1"">Старт. внесок</td>
                        <td class=""col-2"">Час початку</td>
                        <td class=""col-1"">Клас</td>
                        <td class=""col-2"">Тип</td>
                        <td class=""col-2"">Опис</td>
                    </tr>



");
#nullable restore
#line 140 "D:\Itsap\TWeb1\Views\Main\Main.cshtml"
                     foreach (var item in Model.competition)
                    {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                        <tr class=\"row\">\r\n                            <td class=\"col-2\"><a");
                    BeginWriteAttribute("href", " href=", 5831, "", 5901, 1);
#nullable restore
#line 143 "D:\Itsap\TWeb1\Views\Main\Main.cshtml"
WriteAttributeValue("", 5837, Url.Action("Competition", "Main", new {id=item.CompetitionId }), 5837, 64, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(">");
#nullable restore
#line 143 "D:\Itsap\TWeb1\Views\Main\Main.cshtml"
                                                                                                                  Write(item.Name);

#line default
#line hidden
#nullable disable
                    WriteLiteral("</a></td>\r\n                            <td class=\"col-1\">");
#nullable restore
#line 144 "D:\Itsap\TWeb1\Views\Main\Main.cshtml"
                                         Write(item.Place);

#line default
#line hidden
#nullable disable
                    WriteLiteral("</td>\r\n                            <td class=\"col-1\">");
#nullable restore
#line 145 "D:\Itsap\TWeb1\Views\Main\Main.cshtml"
                                         Write(item.StartTax);

#line default
#line hidden
#nullable disable
                    WriteLiteral("</td>\r\n                            <td class=\"col-2\">");
#nullable restore
#line 146 "D:\Itsap\TWeb1\Views\Main\Main.cshtml"
                                         Write(item.StartTime);

#line default
#line hidden
#nullable disable
                    WriteLiteral("</td>\r\n                            <td class=\"col-1\">");
#nullable restore
#line 147 "D:\Itsap\TWeb1\Views\Main\Main.cshtml"
                                         Write(Dict.ListComplexity.Find(a => a.ID == item.IdComplexity).Name);

#line default
#line hidden
#nullable disable
                    WriteLiteral("</td>\r\n                            <td class=\"col-2\">");
#nullable restore
#line 148 "D:\Itsap\TWeb1\Views\Main\Main.cshtml"
                                         Write(Dict.ListType.Find(a => a.ID == item.IdType).Name);

#line default
#line hidden
#nullable disable
                    WriteLiteral("</td>\r\n                            <td class=\"col-2\">");
#nullable restore
#line 149 "D:\Itsap\TWeb1\Views\Main\Main.cshtml"
                                         Write(item.Description);

#line default
#line hidden
#nullable disable
                    WriteLiteral("</td>\r\n                            <td class=\"col-1\">\r\n");
#nullable restore
#line 151 "D:\Itsap\TWeb1\Views\Main\Main.cshtml"
                                 if (Dict.dApp.Role == "адмін") { 

#line default
#line hidden
#nullable disable
                    WriteLiteral("                                    <div class=\"input-group\">\r\n");
#nullable restore
#line 153 "D:\Itsap\TWeb1\Views\Main\Main.cshtml"
                                         if(DateTime.Now < item.StartTime) { 

#line default
#line hidden
#nullable disable
                    WriteLiteral("                                        <a");
                    BeginWriteAttribute("href", " href=\"", 6710, "\"", 6791, 1);
#nullable restore
#line 154 "D:\Itsap\TWeb1\Views\Main\Main.cshtml"
WriteAttributeValue("", 6717, Url.Action("CompetitionAdmin","Main",new {id=item.CompetitionId,str="" }), 6717, 74, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(">\r\n                                            <i class=\"fas fa-pencil-alt fa-fw\"style=\"color:forestgreen\"></i>\r\n                                        </a>\r\n");
#nullable restore
#line 157 "D:\Itsap\TWeb1\Views\Main\Main.cshtml"
                                        }

#line default
#line hidden
#nullable disable
                    WriteLiteral("                                        \r\n                                        <a");
                    BeginWriteAttribute("href", " href=\"", 7078, "\"", 7146, 1);
#nullable restore
#line 159 "D:\Itsap\TWeb1\Views\Main\Main.cshtml"
WriteAttributeValue("", 7085, Url.Action("DeleteComp","Main",new {id=item.CompetitionId }), 7085, 61, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(">\r\n                                            <i class=\"fas fa-trash-alt fa-fw\"style=\"color:red\"></i>\r\n                                        </a>\r\n                                        \r\n");
#nullable restore
#line 163 "D:\Itsap\TWeb1\Views\Main\Main.cshtml"
                                          if (item.IsDeleted == 1) { 

#line default
#line hidden
#nullable disable
                    WriteLiteral("                                        <a");
                    BeginWriteAttribute("href", " href=\"", 7452, "\"", 7521, 1);
#nullable restore
#line 164 "D:\Itsap\TWeb1\Views\Main\Main.cshtml"
WriteAttributeValue("", 7459, Url.Action("RestoreComp","Main",new {id=item.CompetitionId }), 7459, 62, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(">\r\n                                            <i class=\"fas fa-upload\" style=\"color:green\"></i>\r\n                                        </a>\r\n");
#nullable restore
#line 167 "D:\Itsap\TWeb1\Views\Main\Main.cshtml"
                                         }

#line default
#line hidden
#nullable disable
                    WriteLiteral("                                    </div>\r\n");
#nullable restore
#line 169 "D:\Itsap\TWeb1\Views\Main\Main.cshtml"
                                }

#line default
#line hidden
#nullable disable
                    WriteLiteral("                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 172 "D:\Itsap\TWeb1\Views\Main\Main.cshtml"
                    }

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n\r\n\r\n                </table>\r\n\r\n            </div>\r\n\r\n        </div>\r\n\r\n    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TWeb1.Items> Html { get; private set; }
    }
}
#pragma warning restore 1591
