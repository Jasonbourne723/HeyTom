#pragma checksum "G:\MyCode\hey,Tom\mvc\HeyTom\HeyTom\Views\Vip\VipPersonalInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f86adcceb7576c6778cffb1bc1b3f3adb7d8636d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Vip_VipPersonalInfo), @"mvc.1.0.view", @"/Views/Vip/VipPersonalInfo.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Vip/VipPersonalInfo.cshtml", typeof(AspNetCore.Views_Vip_VipPersonalInfo))]
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
#line 1 "G:\MyCode\hey,Tom\mvc\HeyTom\HeyTom\Views\_ViewImports.cshtml"
using HeyTom;

#line default
#line hidden
#line 2 "G:\MyCode\hey,Tom\mvc\HeyTom\HeyTom\Views\_ViewImports.cshtml"
using HeyTom.Models;

#line default
#line hidden
#line 3 "G:\MyCode\hey,Tom\mvc\HeyTom\HeyTom\Views\Vip\VipPersonalInfo.cshtml"
using HeyTom.Domain.Models;

#line default
#line hidden
#line 4 "G:\MyCode\hey,Tom\mvc\HeyTom\HeyTom\Views\Vip\VipPersonalInfo.cshtml"
using HeyTom.Application.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f86adcceb7576c6778cffb1bc1b3f3adb7d8636d", @"/Views/Vip/VipPersonalInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d55324de7ddba9109b858614d071748f0313a878", @"/Views/_ViewImports.cshtml")]
    public class Views_Vip_VipPersonalInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "G:\MyCode\hey,Tom\mvc\HeyTom\HeyTom\Views\Vip\VipPersonalInfo.cshtml"
                                         
    ViewData["Title"] = "VipPersonalInfo";
    var vip = (VipVO)ViewData["vip"];
    var photos = (List<Photo>)ViewData["photos"];
    var simpleSays = (List<SimpleSay>)ViewData["simpleSays"];

#line default
#line hidden
            BeginContext(283, 88, true);
            WriteLiteral("\r\n\r\n<div class=\"container\" style=\"float:left;width:200px;\">\r\n    <h3>个人资料</h3>\r\n    <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 371, "\"", 386, 1);
#line 14 "G:\MyCode\hey,Tom\mvc\HeyTom\HeyTom\Views\Vip\VipPersonalInfo.cshtml"
WriteAttributeValue("", 377, vip.Icon, 377, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(387, 27, true);
            WriteLiteral(" width=\"100\" />\r\n    <p>昵称：");
            EndContext();
            BeginContext(415, 8, false);
#line 15 "G:\MyCode\hey,Tom\mvc\HeyTom\HeyTom\Views\Vip\VipPersonalInfo.cshtml"
     Write(vip.Name);

#line default
#line hidden
            EndContext();
            BeginContext(423, 13, true);
            WriteLiteral("</p>\r\n    <p>");
            EndContext();
            BeginContext(437, 8, false);
#line 16 "G:\MyCode\hey,Tom\mvc\HeyTom\HeyTom\Views\Vip\VipPersonalInfo.cshtml"
  Write(vip.Mark);

#line default
#line hidden
            EndContext();
            BeginContext(445, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 17 "G:\MyCode\hey,Tom\mvc\HeyTom\HeyTom\Views\Vip\VipPersonalInfo.cshtml"
     if (vip.Cats != null && vip.Cats.Count > 0)
    {
        foreach (var item in vip.Cats)
        {

#line default
#line hidden
            BeginContext(559, 39, true);
            WriteLiteral("            <div>\r\n                <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 598, "\"", 614, 1);
#line 22 "G:\MyCode\hey,Tom\mvc\HeyTom\HeyTom\Views\Vip\VipPersonalInfo.cshtml"
WriteAttributeValue("", 604, item.Icon, 604, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(615, 42, true);
            WriteLiteral(" width=\"100\" />\r\n                <p>name: ");
            EndContext();
            BeginContext(658, 9, false);
#line 23 "G:\MyCode\hey,Tom\mvc\HeyTom\HeyTom\Views\Vip\VipPersonalInfo.cshtml"
                    Write(item.Name);

#line default
#line hidden
            EndContext();
            BeginContext(667, 26, true);
            WriteLiteral("</p>\r\n            </div>\r\n");
            EndContext();
#line 25 "G:\MyCode\hey,Tom\mvc\HeyTom\HeyTom\Views\Vip\VipPersonalInfo.cshtml"
        }
    }
    else
    {

#line default
#line hidden
            BeginContext(728, 57, true);
            WriteLiteral("        <div>\r\n            <p>没有猫咪噢</p>\r\n        </div>\r\n");
            EndContext();
#line 32 "G:\MyCode\hey,Tom\mvc\HeyTom\HeyTom\Views\Vip\VipPersonalInfo.cshtml"
    }

#line default
#line hidden
            BeginContext(792, 107, true);
            WriteLiteral("</div>\r\n<div class=\"container\" style=\"float:right;width:900px;\">\r\n    <nav class=\"navbar navbar-default\">\r\n");
            EndContext();
            BeginContext(936, 261, true);
            WriteLiteral(@"        <ul class=""nav navbar-nav"">
            <li class=""active"" id=""111"" onclick=""display('photodiv','simpleSaydiv')""><a href=""#"">个人动态</a></li>
            <li id=""222"" onclick=""display('simpleSaydiv','photodiv')""><a href=""#"">猫咪相册</a></li>
        </ul>
");
            EndContext();
            BeginContext(1217, 58, true);
            WriteLiteral("    </nav>\r\n    <div id=\"simpleSaydiv\" style=\"display:\">\r\n");
            EndContext();
#line 44 "G:\MyCode\hey,Tom\mvc\HeyTom\HeyTom\Views\Vip\VipPersonalInfo.cshtml"
          
            if (simpleSays != null && simpleSays.Count > 0)
            {

                foreach (var item in simpleSays)
                {


#line default
#line hidden
            BeginContext(1436, 136, true);
            WriteLiteral("                    <div class=\"panel panel-default\">\r\n                        <div class=\"panel-body\">\r\n                            <p>");
            EndContext();
            BeginContext(1573, 9, false);
#line 53 "G:\MyCode\hey,Tom\mvc\HeyTom\HeyTom\Views\Vip\VipPersonalInfo.cshtml"
                          Write(item.Body);

#line default
#line hidden
            EndContext();
            BeginContext(1582, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
            BeginContext(1975, 51, true);
            WriteLiteral("                            <p style=\"float:right\">");
            EndContext();
            BeginContext(2027, 15, false);
#line 61 "G:\MyCode\hey,Tom\mvc\HeyTom\HeyTom\Views\Vip\VipPersonalInfo.cshtml"
                                              Write(item.CreateTime);

#line default
#line hidden
            EndContext();
            BeginContext(2042, 66, true);
            WriteLiteral("</p>\r\n                        </div>\r\n                    </div>\r\n");
            EndContext();
#line 64 "G:\MyCode\hey,Tom\mvc\HeyTom\HeyTom\Views\Vip\VipPersonalInfo.cshtml"
                }
            }
        

#line default
#line hidden
            BeginContext(2153, 92, true);
            WriteLiteral("    </div>\r\n    <div id=\"photodiv\" style=\"display:none\" >\r\n        <div class=\"container\">\r\n");
            EndContext();
#line 70 "G:\MyCode\hey,Tom\mvc\HeyTom\HeyTom\Views\Vip\VipPersonalInfo.cshtml"
             if (photos != null && photos.Count > 0)
            {
                int rows = photos.Count / 3;
                if (photos.Count % 3 > 0)
                {
                    rows++;
                }
                for (int i = 0; i < rows; i++)
                {

#line default
#line hidden
            BeginContext(2537, 39, true);
            WriteLiteral("                    <div class=\"row\">\r\n");
            EndContext();
#line 80 "G:\MyCode\hey,Tom\mvc\HeyTom\HeyTom\Views\Vip\VipPersonalInfo.cshtml"
                         for (int j = i * 3; j < i * 3 + 3&&j < photos.Count; j++)
                        {

#line default
#line hidden
            BeginContext(2687, 149, true);
            WriteLiteral("                            <div class=\"col-md-3\">\r\n                                <div class=\"thumbnail\">\r\n                                    <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 2836, "\"", 2861, 1);
#line 84 "G:\MyCode\hey,Tom\mvc\HeyTom\HeyTom\Views\Vip\VipPersonalInfo.cshtml"
WriteAttributeValue("", 2842, photos[j].PhotoUrl, 2842, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2862, 106, true);
            WriteLiteral(" width=\"200\" height=\"100\" />\r\n                                </div>\r\n                            </div>\r\n");
            EndContext();
#line 87 "G:\MyCode\hey,Tom\mvc\HeyTom\HeyTom\Views\Vip\VipPersonalInfo.cshtml"
                        }

#line default
#line hidden
            BeginContext(2995, 28, true);
            WriteLiteral("                    </div>\r\n");
            EndContext();
#line 89 "G:\MyCode\hey,Tom\mvc\HeyTom\HeyTom\Views\Vip\VipPersonalInfo.cshtml"
                }
            }

#line default
#line hidden
            BeginContext(3057, 509, true);
            WriteLiteral(@"        </div>
    </div>
</div>

<script type=""text/javascript"">
    function display(hiddenId, showId) {
        var hiddentraget = document.getElementById(hiddenId);
        var showtraget = document.getElementById(showId);
        hiddentraget.style.display = ""none"";
        showtraget.style.display = """";
        //  if(traget.style.display==""none""){
        //      traget.style.display="""";
        //  }else{
        //      traget.style.display=""none"";
        //}
    }
</script>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
