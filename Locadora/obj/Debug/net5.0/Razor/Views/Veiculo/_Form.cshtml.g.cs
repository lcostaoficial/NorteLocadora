#pragma checksum "C:\Git\NorteLocadora\Locadora\Views\Veiculo\_Form.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2b6f30fefdc099fb411e69680be0931dcf488968"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Veiculo__Form), @"mvc.1.0.view", @"/Views/Veiculo/_Form.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2b6f30fefdc099fb411e69680be0931dcf488968", @"/Views/Veiculo/_Form.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c0224845b91fd63a4726505e5348f391d40b261", @"/Views/_ViewImports.cshtml")]
    public class Views_Veiculo__Form : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Locadora.Models.Veiculo>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Git\NorteLocadora\Locadora\Views\Veiculo\_Form.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"form-group col-md-12\" style=\"margin-bottom: 0px\">\r\n    <h4>Veículo</h4>\r\n    <hr class=\"my-4\">\r\n</div>\r\n\r\n<div class=\"form-group col-md-6\">\r\n    ");
#nullable restore
#line 11 "C:\Git\NorteLocadora\Locadora\Views\Veiculo\_Form.cshtml"
Write(Html.LabelFor(m => m.Marca));

#line default
#line hidden
#nullable disable
            WriteLiteral(" <label style=\"color: red\" title=\"Este campo é obrigatório\">*</label>\r\n    ");
#nullable restore
#line 12 "C:\Git\NorteLocadora\Locadora\Views\Veiculo\_Form.cshtml"
Write(Html.TextBoxFor(m => m.Marca, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 13 "C:\Git\NorteLocadora\Locadora\Views\Veiculo\_Form.cshtml"
Write(Html.ValidationMessageFor(m => m.Marca));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n<div class=\"form-group col-md-6\">\r\n    ");
#nullable restore
#line 17 "C:\Git\NorteLocadora\Locadora\Views\Veiculo\_Form.cshtml"
Write(Html.LabelFor(m => m.Modelo));

#line default
#line hidden
#nullable disable
            WriteLiteral(" <label style=\"color: red\" title=\"Este campo é obrigatório\">*</label>\r\n    ");
#nullable restore
#line 18 "C:\Git\NorteLocadora\Locadora\Views\Veiculo\_Form.cshtml"
Write(Html.TextBoxFor(m => m.Modelo, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 19 "C:\Git\NorteLocadora\Locadora\Views\Veiculo\_Form.cshtml"
Write(Html.ValidationMessageFor(m => m.Modelo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n<div class=\"form-group col-md-6\">\r\n    ");
#nullable restore
#line 23 "C:\Git\NorteLocadora\Locadora\Views\Veiculo\_Form.cshtml"
Write(Html.LabelFor(m => m.AnoDeModelo));

#line default
#line hidden
#nullable disable
            WriteLiteral(" <label style=\"color: red\" title=\"Este campo é obrigatório\">*</label>\r\n    ");
#nullable restore
#line 24 "C:\Git\NorteLocadora\Locadora\Views\Veiculo\_Form.cshtml"
Write(Html.TextBoxFor(m => m.AnoDeModelo, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 25 "C:\Git\NorteLocadora\Locadora\Views\Veiculo\_Form.cshtml"
Write(Html.ValidationMessageFor(m => m.AnoDeModelo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n<div class=\"form-group col-md-6\">\r\n    ");
#nullable restore
#line 29 "C:\Git\NorteLocadora\Locadora\Views\Veiculo\_Form.cshtml"
Write(Html.LabelFor(m => m.AnoDeFabricacao));

#line default
#line hidden
#nullable disable
            WriteLiteral(" <label style=\"color: red\" title=\"Este campo é obrigatório\">*</label>\r\n    ");
#nullable restore
#line 30 "C:\Git\NorteLocadora\Locadora\Views\Veiculo\_Form.cshtml"
Write(Html.TextBoxFor(m => m.AnoDeFabricacao, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 31 "C:\Git\NorteLocadora\Locadora\Views\Veiculo\_Form.cshtml"
Write(Html.ValidationMessageFor(m => m.AnoDeFabricacao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n<div class=\"form-group col-md-6\">\r\n    ");
#nullable restore
#line 35 "C:\Git\NorteLocadora\Locadora\Views\Veiculo\_Form.cshtml"
Write(Html.LabelFor(m => m.Placa));

#line default
#line hidden
#nullable disable
            WriteLiteral(" <label style=\"color: red\" title=\"Este campo é obrigatório\">*</label>\r\n    ");
#nullable restore
#line 36 "C:\Git\NorteLocadora\Locadora\Views\Veiculo\_Form.cshtml"
Write(Html.TextBoxFor(m => m.Placa, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 37 "C:\Git\NorteLocadora\Locadora\Views\Veiculo\_Form.cshtml"
Write(Html.ValidationMessageFor(m => m.Placa));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n<div class=\"form-group col-md-6\">\r\n    ");
#nullable restore
#line 41 "C:\Git\NorteLocadora\Locadora\Views\Veiculo\_Form.cshtml"
Write(Html.LabelFor(m => m.Cor));

#line default
#line hidden
#nullable disable
            WriteLiteral(" <label style=\"color: red\" title=\"Este campo é obrigatório\">*</label>\r\n    ");
#nullable restore
#line 42 "C:\Git\NorteLocadora\Locadora\Views\Veiculo\_Form.cshtml"
Write(Html.TextBoxFor(m => m.Cor, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 43 "C:\Git\NorteLocadora\Locadora\Views\Veiculo\_Form.cshtml"
Write(Html.ValidationMessageFor(m => m.Cor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n<div class=\"form-group col-md-6\">\r\n    ");
#nullable restore
#line 47 "C:\Git\NorteLocadora\Locadora\Views\Veiculo\_Form.cshtml"
Write(Html.LabelFor(m => m.Renavam));

#line default
#line hidden
#nullable disable
            WriteLiteral(" <label style=\"color: red\" title=\"Este campo é obrigatório\">*</label>\r\n    ");
#nullable restore
#line 48 "C:\Git\NorteLocadora\Locadora\Views\Veiculo\_Form.cshtml"
Write(Html.TextBoxFor(m => m.Renavam, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 49 "C:\Git\NorteLocadora\Locadora\Views\Veiculo\_Form.cshtml"
Write(Html.ValidationMessageFor(m => m.Renavam));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n");
#nullable restore
#line 52 "C:\Git\NorteLocadora\Locadora\Views\Veiculo\_Form.cshtml"
 if (Model != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form-group col-md-12\" style=\"margin-bottom: 0px\">\r\n        <h4>Fotos do veículo</h4>\r\n        <hr class=\"my-4\">\r\n    </div>\r\n");
            WriteLiteral(@"    <div class=""form-group col-md-12"">
        <button type=""submit"" class=""btn btn-primary btn-sm waves-effect waves-light"">Salvar alterações</button>
        <button onclick=""$('#modalAnexarFoto').modal('show')"" type=""button"" class=""btn btn-success btn-sm waves-effect waves-light"">Incluir fotos</button>
    </div>
");
#nullable restore
#line 63 "C:\Git\NorteLocadora\Locadora\Views\Veiculo\_Form.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form-group col-md-12\">\r\n        <button type=\"submit\" class=\"btn btn-primary btn-sm waves-effect waves-light\">Salvar alterações</button>\r\n    </div>\r\n");
#nullable restore
#line 69 "C:\Git\NorteLocadora\Locadora\Views\Veiculo\_Form.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"form-group col-md-12\">\r\n    <div class=\"prj-list row\">\r\n");
#nullable restore
#line 73 "C:\Git\NorteLocadora\Locadora\Views\Veiculo\_Form.cshtml"
         if (Model != null && Model.FotosDeGaragem != null && Model.FotosDeGaragem.Any())
        {
            foreach (var item in Model.FotosDeGaragem.Where(x => x.Ativo).OrderByDescending(x => x.DataDeRegistro))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-lg-4 col-md-6 col-xs-12 margin-bottom-30\">\r\n                    <div class=\"prj-item\">\r\n                        <div class=\"top-project-section\">\r\n                            <a target=\"_blank\"");
            BeginWriteAttribute("href", " href=\"", 3271, "\"", 3325, 1);
#nullable restore
#line 80 "C:\Git\NorteLocadora\Locadora\Views\Veiculo\_Form.cshtml"
WriteAttributeValue("", 3278, Url.Content($"~/Uploads/Fotos/{item.Caminho}"), 3278, 47, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"project-icon\">\r\n                                <img");
            BeginWriteAttribute("src", " src=\"", 3386, "\"", 3439, 1);
#nullable restore
#line 81 "C:\Git\NorteLocadora\Locadora\Views\Veiculo\_Form.cshtml"
WriteAttributeValue("", 3392, Url.Content($"~/Uploads/Fotos/{item.Caminho}"), 3392, 47, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"184\" height=\"170\"");
            BeginWriteAttribute("alt", " alt=\"", 3465, "\"", 3471, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                            </a>\r\n                            <h3>");
#nullable restore
#line 83 "C:\Git\NorteLocadora\Locadora\Views\Veiculo\_Form.cshtml"
                           Write(item.Descricao);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                            <div class=\"meta\">\r\n                                <p class=\"author\">\r\n                                    Data: <span>");
#nullable restore
#line 86 "C:\Git\NorteLocadora\Locadora\Views\Veiculo\_Form.cshtml"
                                           Write(item.DataDeRegistro.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                </p>
                            </div>
                        </div>
                        <div class=""bottom-project-section"">
                            <div class=""meta"">
                                <div");
            BeginWriteAttribute("class", " class=\"", 4012, "\"", 4067, 2);
            WriteAttributeValue("", 4020, "points", 4020, 6, true);
#nullable restore
#line 92 "C:\Git\NorteLocadora\Locadora\Views\Veiculo\_Form.cshtml"
WriteAttributeValue(" ", 4026, item.Principal ? "success" : "danger", 4027, 40, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    <i class=\"fa fa-image\"></i> ");
#nullable restore
#line 93 "C:\Git\NorteLocadora\Locadora\Views\Veiculo\_Form.cshtml"
                                                            Write(item.Principal ? "Principal" : "Imagem");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </div>\r\n                                <span class=\"feedable-time timeago\">\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 4327, "\"", 4382, 1);
#nullable restore
#line 96 "C:\Git\NorteLocadora\Locadora\Views\Veiculo\_Form.cshtml"
WriteAttributeValue("", 4334, Url.Action("ExcluirFoto", new { id = item.Id }), 4334, 48, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> Excluir</a>\r\n                                </span>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 102 "C:\Git\NorteLocadora\Locadora\Views\Veiculo\_Form.cshtml"
            }
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Locadora.Models.Veiculo> Html { get; private set; }
    }
}
#pragma warning restore 1591
