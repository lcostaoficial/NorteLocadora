$(function () {

    "use strict";

    window.Locacao = window.Locacao || {};

    Locacao.habilitarCpf = function () {
        $(".cpf").prop("disabled", false);
    };

    Locacao.desabilitarCpf = function () {
        $(".cpf").prop("disabled", true);
    };

    Locacao.fixarLocacaoId = function (id) {
        $("#Id").val(id);
    };

    Locacao.fixarClienteId = function (id) {
        $("#ClienteId").val(id);
    };

    Locacao.habilitarEnvioLocacao = function () {
        $("#menu-locacao").removeClass("disabled");
        $("#locacao").removeClass("disabled");
    };

    Locacao.iniciarCarregamento = function () {
        swal({
            title: "",
            text: "Aguarde por favor",
            imageUrl: "../../images/loading.gif",
            showConfirmButton: false
        });
    };

    Locacao.pararCarregamento = function () {
        swal.close();
    };

    Locacao.dadosPessoais = function (locacaoId = 0) {
        Locacao.iniciarCarregamento();
        var url = $("#dadospessoais").data("url");

        $.ajax({
            method: "GET",
            url: url,
            data: { locacaoId: locacaoId },
            dataType: "html",
            success: function success(result) {
                $("#frm-conteudo-dadospessoais").html(result);
                $(".selectpicker").selectpicker();
                GlobalMask.carregarMascaras();
            },
            error: function error(XMLHttpRequest, textStatus, errorThrown) {
                swal("Mensagem", errorThrown, "error");
            },
            complete: function complete() {
                Locacao.pararCarregamento();
            }
        });
    };

    Locacao.carregarLocacao = function (lotacaoId) {
        Locacao.iniciarCarregamento();
        var url = $("#lotacao").data("url");
        $.ajax({
            method: "GET",
            url: url,
            data: { lotacaoId: lotacaoId },
            dataType: "html",
            success: function success(result) {
                $("#frm-conteudo-lotacao").html(result);
                $(".selectpicker").selectpicker();
            },
            error: function error(XMLHttpRequest, textStatus, errorThrown) {
                swal("Mensagem", errorThrown, "error");
            },
            complete: function complete() {
                Locacao.pararCarregamento();
            }
        });
    };

    Locacao.validarCpf = function (cpf) {
        var numeros, digitos, soma, i, resultado, digitos_iguais;
        digitos_iguais = 1;
        if (cpf.length < 11)
            return false;
        for (i = 0; i < cpf.length - 1; i++)
            if (cpf.charAt(i) != cpf.charAt(i + 1)) {
                digitos_iguais = 0;
                break;
            }
        if (!digitos_iguais) {
            numeros = cpf.substring(0, 9);
            digitos = cpf.substring(9);
            soma = 0;
            for (i = 10; i > 1; i--)
                soma += numeros.charAt(10 - i) * i;
            resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
            if (resultado != digitos.charAt(0))
                return false;
            numeros = cpf.substring(0, 10);
            soma = 0;
            for (i = 11; i > 1; i--)
                soma += numeros.charAt(11 - i) * i;
            resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
            if (resultado != digitos.charAt(1))
                return false;
            return true;
        }
        else
            return false;
    };

    Locacao.buscarCpfExistente = function (cpf) {
        Locacao.iniciarCarregamento();
        var url = $("input[name='Cliente.Cpf']").data("url");
        $.ajax({
            type: "GET",
            url: url,
            data: { cpf: cpf },
            success: function success(result) {
                if (result.success) {
                    if (result.jaExiste) {
                        $("#ClienteId").val(result.model.clienteId);
                        $("input[name='Cliente.Nome']").val(result.model.nome);
                        $("input[name='Cliente.NomeMae']").val(result.model.nomeMae);
                        $("input[name='Cliente.Profissao']").val(result.model.profissao);
                        $("input[name='Cliente.Naturalidade']").val(result.model.naturalidade);
                        $("input[name='Cliente.Nacionalidade']").val(result.model.nacionalidade);
                        $("input[name='Cliente.Naturalidade']").val(result.model.naturalidade);
                        $("input[name='Cliente.DataNascimento']").val(result.model.dataNascimentoFormatado);
                        $("select[name='Cliente.EstadoNascimento']").val(result.model.estadoNascimentoFormatado).change();
                        $("select[name='Cliente.EstadoCivil']").val(result.model.estadoCivilFormatado).change();
                        $("select[name='Cliente.ClienteEstrangeiro']").val(`${result.model.clienteEstrangeiro}`).change();
                        $("input[name='Cliente.DocumentoIdentificacaoEstrangeiro']").val(result.model.documentoIdentificacaoEstrangeiro);
                        $("input[name='Cliente.Rg']").val(result.model.rg);
                        $("select[name='Cliente.OrgaoExpedidorRg']").val(result.model.orgaoExpedidorRgFormatado).change();
                        $("select[name='Cliente.EstadoOrgaoExpedidor']").val(result.model.estadoOrgaoExpedidorFormatado).change();
                        if (result.model.clienteEstrangeiro === true) {
                            $("input[name='Cliente.DocumentoIdentificacaoEstrangeiro']").prop("disabled", false);
                        }
                        else {
                            $("input[name='Cliente.Rg']").prop("disabled", false);
                            $("select[name='Cliente.OrgaoExpedidorRg']").prop("disabled", false);
                            $("select[name='Cliente.EstadoOrgaoExpedidor']").prop("disabled", false);
                        }
                        $("input[name='Cliente.Email']").val(result.model.email);
                        $("input[name='Cliente.TelefoneMovel']").val(result.model.telefoneMovel);
                        $("input[name='Cliente.TelefoneFixo']").val(result.model.telefoneFixo);
                        $("input[name='Cliente.Cep']").val(result.model.cep);
                        $("input[name='Cliente.Rua']").val(result.model.rua);
                        $("input[name='Cliente.Numero']").val(result.model.numero);
                        $("input[name='Cliente.Bairro']").val(result.model.bairro);
                        $("input[name='Cliente.Cidade']").val(result.model.cidade);
                        $("select[name='Cliente.Estado']").val(result.model.estadoFormatado).change();
                        Locacao.desabilitarCpf();
                    }
                    else {
                        $("#ClienteId").val(0);
                    }
                }
                if (result.error) {
                    swal("Mensagem", result.error, "warning");
                }
            },
            error: function error(XMLHttpRequest, textStatus, errorThrown) {
                swal("Mensagem", errorThrown, "error");
            },
            complete: function complete() {
                Locacao.pararCarregamento();
            }
        });
    };

    Locacao.inicializar = function () {
        var lotacaoId = $("#menu-dadospessoais").data("locacaoId");
        if (lotacaoId === 0) {
            Locacao.dadosPessoais();
        }
        else {
            Locacao.dadosPessoais(lotacaoId);
            Locacao.desabilitarCpf();
            Locacao.habilitarEnvioLocacao();
            Locacao.carregarLocacao(lotacaoId);
        }
    };

    Locacao.Eventos = {
        Carregar: function Carregar() {

            $(document).on("blur", "input[name='Cliente.Cpf']", function () {
                var input = $(this);
                var cpf = input.val();
                cpf = cpf.replace('.', '');
                cpf = cpf.replace('.', '');
                cpf = cpf.replace('-', '');
                var result = Locacao.validarCpf(cpf);
                if (result === false) {
                    input.val("");
                    $("#ClienteId").val(0);
                    swal("Mensagem", "O CPF informado não é válido!", "warning");
                }
                else {
                    Locacao.buscarCpfExistente($("input[name='Cliente.Cpf']").val());
                }
            });

            $(".selectpicker").selectpicker();

            $("a[data-toggle='tab']").on("show.bs.tab", function (e) {
                var $target = $(e.target);
                if ($target.parent().hasClass("disabled")) {
                    swal("Mensagem", "Antes desta etapa preencha e salve todos os dados pessoais.", "warning");
                    return false;
                }
            });

            $(document).on("submit", "form#frmSalvarLocacaoComDadosPessoais", function (e) {

                e.preventDefault();

                var form = $(this);

                $.ajax({
                    type: "POST",
                    url: form.attr("action"),
                    data: form.serialize(),
                    success: function success(result) {
                        if (result.success) {
                            Locacao.desabilitarCpf();
                            Locacao.habilitarEnvioLocacao();
                            Locacao.fixarLocacaoId(result.Id);
                            swal({
                                title: "Mensagem",
                                text: result.success,
                                type: "success"
                            }, function () {
                                Locacao.dadosPessoais(result.id);
                                Locacao.carregarLocacao(result.id); //verificar

                                //Próxima aba após salvar os dados pessoais
                                $('.nav-tabs a[href="#locacao"]').tab('show')
                            });

                        }
                        if (result.error) {
                            swal("Mensagem", result.error, "warning");
                        }
                    },
                    error: function error(XMLHttpRequest, textStatus, errorThrown) {
                        swal("Mensagem", errorThrown, "error");
                    }
                });
            });


            $(document).on("submit", "form#frmSalvarLocacao", function (e) {
                e.preventDefault();
                $.ajax({
                    type: "POST",
                    url: $(this).attr("action"),
                    data: $(this).serialize(),
                    success: function success(result) {
                        if (result.Success) {

                            swal({
                                title: "Mensagem",
                                text: result.Success,
                                type: "success"
                            }, function () {
                                Locacao.carregarLocacao(result.locacaoId);
                            });

                        }
                        if (result.Error) {
                            swal("Mensagem", result.Error, "warning");
                        }
                    },
                    error: function error(XMLHttpRequest, textStatus, errorThrown) {
                        swal("Mensagem", errorThrown, "error");
                    }
                });
            });

            $(".modal").on("hidden.bs.modal", function () {
                $(this).find('form')[0].reset();
            });
        }
    };

    Locacao.Eventos.Carregar();

    Locacao.inicializar();

});