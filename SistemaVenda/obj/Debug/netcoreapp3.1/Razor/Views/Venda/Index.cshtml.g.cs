#pragma checksum "C:\Users\jonas\Documents\GitHub\SistemaVenda\SistemaVenda\Views\Venda\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "53f7940e6d3d3fbc673e9527046e9e0ff98407b9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Venda_Index), @"mvc.1.0.view", @"/Views/Venda/Index.cshtml")]
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
#line 1 "C:\Users\jonas\Documents\GitHub\SistemaVenda\SistemaVenda\Views\_ViewImports.cshtml"
using SistemaVenda;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\jonas\Documents\GitHub\SistemaVenda\SistemaVenda\Views\_ViewImports.cshtml"
using SistemaVenda.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"53f7940e6d3d3fbc673e9527046e9e0ff98407b9", @"/Views/Venda/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9542d2a040dc74eba97c4a394c73aefd7909e77c", @"/Views/_ViewImports.cshtml")]
    public class Views_Venda_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<SistemaVenda.Models.VendaViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h2>Vendas</h2>\r\n<hr />\r\n\r\n<table class=\"table table-bordered\">\r\n    <thead>\r\n        <tr>\r\n            <th>Código</th>\r\n            <th>Data</th>\r\n            <th>Cliente</th>\r\n            <th>Total </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 16 "C:\Users\jonas\Documents\GitHub\SistemaVenda\SistemaVenda\Views\Venda\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr");
            BeginWriteAttribute("onclick", " onclick=\"", 361, "\"", 391, 3);
            WriteAttributeValue("", 371, "Editar(", 371, 7, true);
#nullable restore
#line 18 "C:\Users\jonas\Documents\GitHub\SistemaVenda\SistemaVenda\Views\Venda\Index.cshtml"
WriteAttributeValue("", 378, item.Codigo, 378, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 390, ")", 390, 1, true);
            EndWriteAttribute();
            WriteLiteral(" style=\"cursor:pointer\">\r\n            <td>");
#nullable restore
#line 19 "C:\Users\jonas\Documents\GitHub\SistemaVenda\SistemaVenda\Views\Venda\Index.cshtml"
           Write(item.Codigo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 20 "C:\Users\jonas\Documents\GitHub\SistemaVenda\SistemaVenda\Views\Venda\Index.cshtml"
           Write(item.Data);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 21 "C:\Users\jonas\Documents\GitHub\SistemaVenda\SistemaVenda\Views\Venda\Index.cshtml"
           Write(item.CodigoCliente);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 22 "C:\Users\jonas\Documents\GitHub\SistemaVenda\SistemaVenda\Views\Venda\Index.cshtml"
           Write(item.Total);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n");
#nullable restore
#line 24 "C:\Users\jonas\Documents\GitHub\SistemaVenda\SistemaVenda\Views\Venda\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </tbody>
</table>
<br />
<button type=""button"" class=""btn btn-block btn-primary"" onclick=""Cadastrar()"">Cadastrar Venda</button>

<script>
    function Editar(Codigo)
    {
        window.location = window.origin + ""\\Venda\\Cadastro\\"" + Codigo;
    }

    function Cadastrar()
    {
        window.location = window.origin + ""\\Venda\\Cadastro"";
    }
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<SistemaVenda.Models.VendaViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
