#pragma checksum "D:\Itsap\TWeb1\Views\Account\Register.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "130b2121a3c8dc0f900494cc9127998d5a1608ec"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Register), @"mvc.1.0.view", @"/Views/Account/Register.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"130b2121a3c8dc0f900494cc9127998d5a1608ec", @"/Views/Account/Register.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d93d23cc4f3489b92e3b0c169e117fc9a54b6943", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Register : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TWeb1.Items>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Account/Register"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n\r\n<script type=\"text/javascript\">\r\n    $(document).ready(function () {\r\n        var err = ");
#nullable restore
#line 6 "D:\Itsap\TWeb1\Views\Account\Register.cshtml"
             Write(Model.ErrorLogIn);

#line default
#line hidden
#nullable disable
            WriteLiteral(@";

        if (err == ""1"") {
            $(""#error"").text(""паролi не спiвпадають!"");
        }
        else if (err == ""2"") {
            $(""#error"").text(""логін зайнятий!"");
        }
        $(""#navbarAcc"").hide();
        $(""#navbarGuest"").hide();
    });
    function Back() {
        $.ajax({
            url: ""/Account/Index"",
            success: window.open(""/Account/Index"", ""_self"")
        });

    }

</script>
    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "130b2121a3c8dc0f900494cc9127998d5a1608ec4534", async() => {
                WriteLiteral(@"
        <div class=""container-fluid"" style=""margin-top:10%;"">
            <div class=""row mt-1"">
                <div class=""col-12 offset-md-3 "">
                    <span id=""error"" style=""color:red""></span>
                </div>
            </div>
            <div class=""row"">
                ");
#nullable restore
#line 34 "D:\Itsap\TWeb1\Views\Account\Register.cshtml"
           Write(Html.LabelFor(m => m.account.Email, "Логiн:", new { @class = "col-3 col-md-2 offset-md-3 col-form-label" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
#nullable restore
#line 35 "D:\Itsap\TWeb1\Views\Account\Register.cshtml"
           Write(Html.TextBoxFor(m => m.account.Email, new { @class = "col-8 col-md-4 form-control form-control-sm", @required = "true" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n                ");
#nullable restore
#line 37 "D:\Itsap\TWeb1\Views\Account\Register.cshtml"
           Write(Html.LabelFor(m => m.account.Password, "Пароль:", new { @class = " col-3 col-md-2 offset-md-3  col-form-label" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
#nullable restore
#line 38 "D:\Itsap\TWeb1\Views\Account\Register.cshtml"
           Write(Html.TextBoxFor(m => m.account.Password, new { @class = "col-8 col-md-4 form-control form-control-sm", @type = "password", @required = "true" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n                ");
#nullable restore
#line 40 "D:\Itsap\TWeb1\Views\Account\Register.cshtml"
           Write(Html.LabelFor(m => m.CheckPassword, "Пiдтвердити пароль:", new { @class = " col-3 col-md-2 offset-md-3  col-form-label" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
#nullable restore
#line 41 "D:\Itsap\TWeb1\Views\Account\Register.cshtml"
           Write(Html.TextBoxFor(m => m.CheckPassword, new { @class = "col-8 col-md-4 form-control form-control-sm", @type = "password", @required = "true" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
            </div>

            <div class=""row"">
                <button type=""submit"" id=""submitBtt"" class=""btn-success col-10 "" style=""max-width:190px;margin-left: calc(50% - 95px);"">Зареєструватися</button>
                <button type=""button""onclick=""Back()"" id=""backBtt"" class=""btn-success col-10 "" style=""max-width:190px;margin-left: calc(50% - 95px);"">Назад</button>
            </div>
        </div>
    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
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
