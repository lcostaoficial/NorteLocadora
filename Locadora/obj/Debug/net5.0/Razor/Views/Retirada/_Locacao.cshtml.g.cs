#pragma checksum "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6b66fb8a41e31aca0b5b9c9a61fb306da04fa4de"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Retirada__Locacao), @"mvc.1.0.view", @"/Views/Retirada/_Locacao.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b66fb8a41e31aca0b5b9c9a61fb306da04fa4de", @"/Views/Retirada/_Locacao.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c0224845b91fd63a4726505e5348f391d40b261", @"/Views/_ViewImports.cshtml")]
    public class Views_Retirada__Locacao : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Locacao>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"form-group col-md-12\" style=\"margin-bottom: 0px\">\r\n    <h4>Detalhes da locação</h4>\r\n    <hr class=\"my-4\">\r\n</div>\r\n\r\n");
#nullable restore
#line 8 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
 if (!Model.ValidarCamposLocacao())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form-group col-md-6\">\r\n        ");
#nullable restore
#line 11 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
   Write(Html.LabelFor(m => m.DataRetirada));

#line default
#line hidden
#nullable disable
            WriteLiteral(" <label style=\"color: red\" title=\"Este campo é obrigatório\">*</label>\r\n        ");
#nullable restore
#line 12 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
   Write(Html.TextBoxFor(m => m.DataRetirada, new { @class = "form-control date datepicker", autocomplete = "off" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 13 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
   Write(Html.ValidationMessageFor(m => m.DataRetirada));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
            WriteLiteral("    <div class=\"form-group col-md-6\">\r\n        ");
#nullable restore
#line 17 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
   Write(Html.LabelFor(m => m.HorarioDeSaida));

#line default
#line hidden
#nullable disable
            WriteLiteral(" <label style=\"color: red\" title=\"Este campo é obrigatório\">*</label>\r\n        ");
#nullable restore
#line 18 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
   Write(Html.TextBoxFor(m => m.HorarioDeSaida, new { @class = "form-control time timepicker", autocomplete = "off" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 19 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
   Write(Html.ValidationMessageFor(m => m.HorarioDeSaida));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
            WriteLiteral("    <div class=\"form-group col-md-6\">\r\n        ");
#nullable restore
#line 23 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
   Write(Html.LabelFor(m => m.DataPrevistaDeDevolucao));

#line default
#line hidden
#nullable disable
            WriteLiteral(" <label style=\"color: red\" title=\"Este campo é obrigatório\">*</label>\r\n        ");
#nullable restore
#line 24 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
   Write(Html.TextBoxFor(m => m.DataPrevistaDeDevolucao, new { @class = "form-control date datepicker", autocomplete = "off" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 25 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
   Write(Html.ValidationMessageFor(m => m.DataPrevistaDeDevolucao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
            WriteLiteral("    <div class=\"form-group col-md-6\">\r\n        ");
#nullable restore
#line 29 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
   Write(Html.LabelFor(m => m.HorarioDeChegada));

#line default
#line hidden
#nullable disable
            WriteLiteral(" <label style=\"color: red\" title=\"Este campo é obrigatório\">*</label>\r\n        ");
#nullable restore
#line 30 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
   Write(Html.TextBoxFor(m => m.HorarioDeChegada, new { @class = "form-control time timepicker", autocomplete = "off" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 31 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
   Write(Html.ValidationMessageFor(m => m.HorarioDeChegada));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
            WriteLiteral("    <div class=\"form-group col-md-6\">\r\n        ");
#nullable restore
#line 35 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
   Write(Html.LabelFor(m => m.PrecoCombinado));

#line default
#line hidden
#nullable disable
            WriteLiteral(" <label style=\"color: red\" title=\"Este campo é obrigatório\">*</label>\r\n        ");
#nullable restore
#line 36 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
   Write(Html.TextBoxFor(m => m.PrecoCombinado, new { @class = "form-control money" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 37 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
   Write(Html.ValidationMessageFor(m => m.PrecoCombinado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
            WriteLiteral("    <div class=\"form-group col-md-6\">\r\n        ");
#nullable restore
#line 41 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
   Write(Html.LabelFor(m => m.QuilometragemAtual));

#line default
#line hidden
#nullable disable
            WriteLiteral(" <label style=\"color: red\" title=\"Este campo é obrigatório\">*</label>\r\n        ");
#nullable restore
#line 42 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
   Write(Html.TextBoxFor(m => m.QuilometragemAtual, new { @class = "form-control", type = "number" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 43 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
   Write(Html.ValidationMessageFor(m => m.QuilometragemAtual));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
            WriteLiteral("    <div class=\"form-group col-md-12\">\r\n        ");
#nullable restore
#line 47 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
   Write(Html.LabelFor(m => m.ObservacoesDeSaida));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 48 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
   Write(Html.TextAreaFor(m => m.ObservacoesDeSaida, new { @class = "form-control", type = "number" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 49 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
   Write(Html.ValidationMessageFor(m => m.ObservacoesDeSaida));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 51 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form-group col-md-6\">\r\n        ");
#nullable restore
#line 55 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
   Write(Html.LabelFor(m => m.DataRetirada));

#line default
#line hidden
#nullable disable
            WriteLiteral(" <label style=\"color: red\" title=\"Este campo é obrigatório\">*</label>\r\n        ");
#nullable restore
#line 56 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
   Write(Html.TextBoxFor(m => m.DataRetirada, new { @class = "form-control date datepicker", autocomplete = "off", disabled = "" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 57 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
   Write(Html.ValidationMessageFor(m => m.DataRetirada));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
            WriteLiteral("    <div class=\"form-group col-md-6\">\r\n        ");
#nullable restore
#line 61 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
   Write(Html.LabelFor(m => m.HorarioDeSaida));

#line default
#line hidden
#nullable disable
            WriteLiteral(" <label style=\"color: red\" title=\"Este campo é obrigatório\">*</label>\r\n        ");
#nullable restore
#line 62 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
   Write(Html.TextBoxFor(m => m.HorarioDeSaida, new { @class = "form-control time", autocomplete = "off", disabled = "" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 63 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
   Write(Html.ValidationMessageFor(m => m.HorarioDeSaida));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
            WriteLiteral("    <div class=\"form-group col-md-6\">\r\n        ");
#nullable restore
#line 67 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
   Write(Html.LabelFor(m => m.DataPrevistaDeDevolucao));

#line default
#line hidden
#nullable disable
            WriteLiteral(" <label style=\"color: red\" title=\"Este campo é obrigatório\">*</label>\r\n        ");
#nullable restore
#line 68 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
   Write(Html.TextBoxFor(m => m.DataPrevistaDeDevolucao, new { @class = "form-control date datepicker", autocomplete = "off", disabled = "" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 69 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
   Write(Html.ValidationMessageFor(m => m.DataPrevistaDeDevolucao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
            WriteLiteral("    <div class=\"form-group col-md-6\">\r\n        ");
#nullable restore
#line 73 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
   Write(Html.LabelFor(m => m.HorarioDeChegada));

#line default
#line hidden
#nullable disable
            WriteLiteral(" <label style=\"color: red\" title=\"Este campo é obrigatório\">*</label>\r\n        ");
#nullable restore
#line 74 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
   Write(Html.TextBoxFor(m => m.HorarioDeChegada, new { @class = "form-control time", autocomplete = "off", disabled = "" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 75 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
   Write(Html.ValidationMessageFor(m => m.HorarioDeChegada));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
            WriteLiteral("    <div class=\"form-group col-md-6\">\r\n        ");
#nullable restore
#line 79 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
   Write(Html.LabelFor(m => m.PrecoCombinado));

#line default
#line hidden
#nullable disable
            WriteLiteral(" <label style=\"color: red\" title=\"Este campo é obrigatório\">*</label>\r\n        ");
#nullable restore
#line 80 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
   Write(Html.TextBoxFor(m => m.PrecoCombinado, new { @class = "form-control money", disabled = "" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 81 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
   Write(Html.ValidationMessageFor(m => m.PrecoCombinado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
            WriteLiteral("    <div class=\"form-group col-md-6\">\r\n        ");
#nullable restore
#line 85 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
   Write(Html.LabelFor(m => m.QuilometragemAtual));

#line default
#line hidden
#nullable disable
            WriteLiteral(" <label style=\"color: red\" title=\"Este campo é obrigatório\">*</label>\r\n        ");
#nullable restore
#line 86 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
   Write(Html.TextBoxFor(m => m.QuilometragemAtual, new { @class = "form-control", type = "number", disabled = "" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 87 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
   Write(Html.ValidationMessageFor(m => m.QuilometragemAtual));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
            WriteLiteral("    <div class=\"form-group col-md-12\">\r\n        ");
#nullable restore
#line 91 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
   Write(Html.LabelFor(m => m.ObservacoesDeSaida));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 92 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
   Write(Html.TextAreaFor(m => m.ObservacoesDeSaida, new { @class = "form-control", type = "number", disabled = "" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 93 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
   Write(Html.ValidationMessageFor(m => m.ObservacoesDeSaida));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 95 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 97 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
 if (!Model.ValidarCamposLocacao())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form-group col-md-12\" style=\"margin-bottom: 0px\">\r\n        <h4>Veículos disponíveis</h4>\r\n        <hr class=\"my-4\">\r\n    </div>\r\n");
#nullable restore
#line 103 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form-group col-md-12\" style=\"margin-bottom: 0px\">\r\n        <h4>Veículos da locação</h4>\r\n        <hr class=\"my-4\">\r\n    </div>\r\n");
#nullable restore
#line 110 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div data-url=\"");
#nullable restore
#line 112 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
          Write(Url.Action("ObterVeiculosDisponiveis", "Retirada"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\" id=\"veiculos-disponiveis\" class=\"form-group col-md-12\"></div>\r\n\r\n");
#nullable restore
#line 114 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
 if (!Model.ValidarCamposLocacao())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form-group col-md-12\">\r\n        <button type=\"submit\" class=\"btn btn-primary btn-sm waves-effect waves-light\" onclick=\"javascript:void(0)\">Salvar</button>\r\n    </div>\r\n");
#nullable restore
#line 119 "C:\Git\NorteLocadora\Locadora\Views\Retirada\_Locacao.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Locacao> Html { get; private set; }
    }
}
#pragma warning restore 1591
