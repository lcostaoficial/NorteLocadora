#pragma checksum "C:\Git\NorteLocadora\Locadora\Views\Preventiva\_Form.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e43779f386e291bb6e336c9aa714fefa69e5fbca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Preventiva__Form), @"mvc.1.0.view", @"/Views/Preventiva/_Form.cshtml")]
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
#line 1 "C:\Git\NorteLocadora\Locadora\Views\_ViewImports.cshtml"
using Locadora;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Git\NorteLocadora\Locadora\Views\_ViewImports.cshtml"
using Locadora.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e43779f386e291bb6e336c9aa714fefa69e5fbca", @"/Views/Preventiva/_Form.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c0224845b91fd63a4726505e5348f391d40b261", @"/Views/_ViewImports.cshtml")]
    public class Views_Preventiva__Form : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Locadora.Models.Manutencao>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Git\NorteLocadora\Locadora\Views\Preventiva\_Form.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"form-group col-md-12\" style=\"margin-bottom: 0px\">\r\n    <h4>Preventivas</h4>\r\n    <hr class=\"my-4\">\r\n</div>\r\n\r\n<div class=\"form-group col-md-4\">\r\n    ");
#nullable restore
#line 11 "C:\Git\NorteLocadora\Locadora\Views\Preventiva\_Form.cshtml"
Write(Html.LabelFor(m => m.Data));

#line default
#line hidden
#nullable disable
            WriteLiteral(" <label style=\"color: red\" title=\"Este campo é obrigatório\">*</label>\r\n    ");
#nullable restore
#line 12 "C:\Git\NorteLocadora\Locadora\Views\Preventiva\_Form.cshtml"
Write(Html.TextBoxFor(m => m.Data, new { @class = "form-control date datepicker-basic" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 13 "C:\Git\NorteLocadora\Locadora\Views\Preventiva\_Form.cshtml"
Write(Html.ValidationMessageFor(m => m.Data));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n<div class=\"form-group col-md-8\">\r\n    ");
#nullable restore
#line 17 "C:\Git\NorteLocadora\Locadora\Views\Preventiva\_Form.cshtml"
Write(Html.LabelFor(m => m.VeiculoId));

#line default
#line hidden
#nullable disable
            WriteLiteral(" <label style=\"color: red\" title=\"Este campo é obrigatório\">*</label>\r\n    ");
#nullable restore
#line 18 "C:\Git\NorteLocadora\Locadora\Views\Preventiva\_Form.cshtml"
Write(Html.DropDownListFor(x => x.VeiculoId, new SelectList(ViewBag.Veiculos, "Id", "Placa"), "Selecione...", new { @class = "form-control selectpicker", data_live_search = "true" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 19 "C:\Git\NorteLocadora\Locadora\Views\Preventiva\_Form.cshtml"
Write(Html.ValidationMessageFor(m => m.VeiculoId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n<div class=\"form-group col-md-12\">\r\n    ");
#nullable restore
#line 23 "C:\Git\NorteLocadora\Locadora\Views\Preventiva\_Form.cshtml"
Write(Html.LabelFor(m => m.Descricao));

#line default
#line hidden
#nullable disable
            WriteLiteral(" <label style=\"color: red\" title=\"Este campo é obrigatório\">*</label>\r\n    ");
#nullable restore
#line 24 "C:\Git\NorteLocadora\Locadora\Views\Preventiva\_Form.cshtml"
Write(Html.TextAreaFor(m => m.Descricao, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 25 "C:\Git\NorteLocadora\Locadora\Views\Preventiva\_Form.cshtml"
Write(Html.ValidationMessageFor(m => m.Descricao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n<div class=\"form-group col-md-6\">\r\n    ");
#nullable restore
#line 29 "C:\Git\NorteLocadora\Locadora\Views\Preventiva\_Form.cshtml"
Write(Html.LabelFor(m => m.Valor));

#line default
#line hidden
#nullable disable
            WriteLiteral(" <label style=\"color: red\" title=\"Este campo é obrigatório\">*</label>\r\n    ");
#nullable restore
#line 30 "C:\Git\NorteLocadora\Locadora\Views\Preventiva\_Form.cshtml"
Write(Html.TextBoxFor(m => m.Valor, new { @class = "form-control money" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 31 "C:\Git\NorteLocadora\Locadora\Views\Preventiva\_Form.cshtml"
Write(Html.ValidationMessageFor(m => m.Valor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n<div class=\"form-group col-md-6\">\r\n    ");
#nullable restore
#line 35 "C:\Git\NorteLocadora\Locadora\Views\Preventiva\_Form.cshtml"
Write(Html.LabelFor(m => m.Quilometragem));

#line default
#line hidden
#nullable disable
            WriteLiteral(" <label style=\"color: red\" title=\"Este campo é obrigatório\">*</label>\r\n    ");
#nullable restore
#line 36 "C:\Git\NorteLocadora\Locadora\Views\Preventiva\_Form.cshtml"
Write(Html.TextBoxFor(m => m.Quilometragem, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 37 "C:\Git\NorteLocadora\Locadora\Views\Preventiva\_Form.cshtml"
Write(Html.ValidationMessageFor(m => m.Quilometragem));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n<div class=\"form-group col-md-12\">\r\n    <button type=\"submit\" class=\"btn btn-primary btn-sm waves-effect waves-light\" onclick=\"javascript:void(0)\">Salvar</button>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Locadora.Models.Manutencao> Html { get; private set; }
    }
}
#pragma warning restore 1591
