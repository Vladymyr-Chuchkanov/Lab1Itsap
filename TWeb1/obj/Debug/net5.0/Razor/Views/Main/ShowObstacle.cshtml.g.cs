#pragma checksum "D:\Itsap\TWeb1\Views\Main\ShowObstacle.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cca34c594493d68672366c3b830d0647024bfe13"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Main_ShowObstacle), @"mvc.1.0.view", @"/Views/Main/ShowObstacle.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cca34c594493d68672366c3b830d0647024bfe13", @"/Views/Main/ShowObstacle.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d93d23cc4f3489b92e3b0c169e117fc9a54b6943", @"/Views/_ViewImports.cshtml")]
    public class Views_Main_ShowObstacle : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TWeb1.Obstacle>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"container\" style=\"background-color:grey\">\r\n    <div class=\"row\">\r\n        <div class=\"col-3\">\r\n            ");
#nullable restore
#line 6 "D:\Itsap\TWeb1\Views\Main\ShowObstacle.cshtml"
       Write(Html.LabelFor(m => m.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-9\">\r\n            ");
#nullable restore
#line 9 "D:\Itsap\TWeb1\Views\Main\ShowObstacle.cshtml"
       Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-3\">\r\n            ");
#nullable restore
#line 12 "D:\Itsap\TWeb1\Views\Main\ShowObstacle.cshtml"
       Write(Html.LabelFor(m => m.AdditionalDescription));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-9\">\r\n            ");
#nullable restore
#line 15 "D:\Itsap\TWeb1\Views\Main\ShowObstacle.cshtml"
       Write(Model.AdditionalDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-3\">\r\n            ");
#nullable restore
#line 18 "D:\Itsap\TWeb1\Views\Main\ShowObstacle.cshtml"
       Write(Html.LabelFor(m => m.Length));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-9\">\r\n            ");
#nullable restore
#line 21 "D:\Itsap\TWeb1\Views\Main\ShowObstacle.cshtml"
       Write(Model.Length);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-3\">\r\n            ");
#nullable restore
#line 24 "D:\Itsap\TWeb1\Views\Main\ShowObstacle.cshtml"
       Write(Html.LabelFor(m => m.Height));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-9\">\r\n            ");
#nullable restore
#line 27 "D:\Itsap\TWeb1\Views\Main\ShowObstacle.cshtml"
       Write(Model.Height);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-3\">\r\n            ");
#nullable restore
#line 30 "D:\Itsap\TWeb1\Views\Main\ShowObstacle.cshtml"
       Write(Html.LabelFor(m => m.ConditionsOvercoming));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-9\">\r\n            ");
#nullable restore
#line 33 "D:\Itsap\TWeb1\Views\Main\ShowObstacle.cshtml"
       Write(Model.ConditionsOvercoming);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-3\">\r\n            ");
#nullable restore
#line 36 "D:\Itsap\TWeb1\Views\Main\ShowObstacle.cshtml"
       Write(Html.LabelFor(m => m.MovementFirst));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-9\">\r\n            ");
#nullable restore
#line 39 "D:\Itsap\TWeb1\Views\Main\ShowObstacle.cshtml"
       Write(Model.MovementFirst);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-3\">\r\n            ");
#nullable restore
#line 42 "D:\Itsap\TWeb1\Views\Main\ShowObstacle.cshtml"
       Write(Html.LabelFor(m => m.EquipmentStart));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-9\">\r\n            ");
#nullable restore
#line 45 "D:\Itsap\TWeb1\Views\Main\ShowObstacle.cshtml"
       Write(Model.EquipmentStart);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-3\">\r\n            ");
#nullable restore
#line 48 "D:\Itsap\TWeb1\Views\Main\ShowObstacle.cshtml"
       Write(Html.LabelFor(m => m.EquipmentObstacle));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-9\">\r\n            ");
#nullable restore
#line 51 "D:\Itsap\TWeb1\Views\Main\ShowObstacle.cshtml"
       Write(Model.EquipmentObstacle);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-3\">\r\n            ");
#nullable restore
#line 54 "D:\Itsap\TWeb1\Views\Main\ShowObstacle.cshtml"
       Write(Html.LabelFor(m => m.EquipmentTarget));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-9\">\r\n            ");
#nullable restore
#line 57 "D:\Itsap\TWeb1\Views\Main\ShowObstacle.cshtml"
       Write(Model.EquipmentTarget);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-3\">\r\n            ");
#nullable restore
#line 60 "D:\Itsap\TWeb1\Views\Main\ShowObstacle.cshtml"
       Write(Html.LabelFor(m => m.OptTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-9\">\r\n            ");
#nullable restore
#line 63 "D:\Itsap\TWeb1\Views\Main\ShowObstacle.cshtml"
       Write(Model.OptTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-3\">\r\n            ");
#nullable restore
#line 66 "D:\Itsap\TWeb1\Views\Main\ShowObstacle.cshtml"
       Write(Html.LabelFor(m => m.CriticalTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-9\">\r\n            ");
#nullable restore
#line 69 "D:\Itsap\TWeb1\Views\Main\ShowObstacle.cshtml"
       Write(Model.CriticalTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n\r\n    </div>\r\n\r\n\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TWeb1.Obstacle> Html { get; private set; }
    }
}
#pragma warning restore 1591
