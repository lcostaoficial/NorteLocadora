$(function () {

    "use strict";

    window.Contrato = window.Contrato || {};

    Contrato.gerarContrato = function (model) {

        console.log(model);

        var dd = {
            content: [
                {
                    text: '\nCONTRATO DE LOCAÇÃO\n\n',
                    style: 'header',
                    decoration: 'underline',
                    alignment: 'center'
                },

                {
                    text: [
                        'Os signatários, que contratam nas qualidades indicadas neste contrato, tem entre si, ',
                        'ajustadas a presente locação, mediante as seguintes cláusulas e condições: \n\n',
                    ], alignment: 'justify'
                },

                {
                    text: [
                        '1. ',
                        { text: 'LOCADOR(A): ' + 'NAIR FERNANDA GOMES RAMALHO', bold: true },
                        ', ' + 'portadora do CPF nº 028.369.872-19, 1556135 – SSP/RO' +
                        ', ' + 'responsável pela empresa Cleiton Motos, situado em Estrada do Belmont, 7867' +
                        ', ' + 'Nacional, na cidade de Porto Velho/RO' + '. \n\n'
                    ], alignment: 'justify'
                },

                {
                    text: [
                        '2. ',
                        { text: 'LOCATÁRIO(A): ' + model.nome, bold: true },
                        ', ' + 'portador(a) do CPF nº ' + model.cpf + ', RG nº ' + model.rg + ' ' + model.orgaoExpedidorRg + '/' + model.estadoRg +
                        ', ' + 'com endereço em ' + model.rua + ', ' + model.numero +
                        ', ' + model.bairro + ', na cidade de ' + model.cidade + '/' + model.estado +  '. \n\n'
                    ], alignment: 'justify'
                },

                {
                    text: [
                        '3. ',
                        { text: 'OBJETO DA LOCAÇÃO', bold: true },
                        ', ' + '01 ' + model.tipoVeiculo + '; ' + 'Marca: ' + model.marca + ', Modelo: ' + model.modelo +
                        ', ' + 'Ano/Modelo: ' + model.anoDeFabricacao + '/' + model.anoDeFabricacao +
                        ', ' + 'Placa: ' + model.placa + ',' + ' Valor/Fipe: ' + model.valorFipe + '. \n\n'
                    ], alignment: 'justify'
                },

                {
                    text: [
                        '4. ',
                        { text: 'FINALIDADE DE LOCAÇÃO: ', bold: true },
                        'O veículo alugado deverá ser utilizado única e exclusivamente para o transporte e entrega ' +
                        'de bens lícitos até o limite da capacidade imposta pelo fabricante do veículo ' +
                        'e informada ao locatário pela locadora, dentro da zona urbana e adjacências de PORTO VELHO/RO.' +
                        '\n\n'
                    ], alignment: 'justify'
                },

                {
                    text: [
                        '5. ',
                        { text: 'VÍNCULO: ', bold: true },
                        'Manterá vinculo conforme determina o Art. 565, do Código Civil Brasileiro, ' +
                        '(locação de coisa certa e determinada, cedendo uso, mediante certa retribuição) não mantendo nenhum vínculo empregatício/trabalhista, ' +
                        'nem propondo atividades ao locatário.' +
                        '\n\n'
                    ], alignment: 'justify'
                },

                {
                    text: [
                        '6. ',
                        { text: 'VALOR DA LOCAÇÃO: ', bold: true },                       
                        '\n\n'
                    ], alignment: 'justify'
                },

                {
                    text: [
                        '6.1 ',
                        { text: 'VALOR: ', bold: true },
                        'R$ ' + model.valorDaLocacao + ' (' + model.valorDaLocacaoPorExtenso + ')' +
                        '\n\n'
                    ], alignment: 'justify'
                },

                {
                    text: [
                        '6.2 ',
                        { text: 'Hora e Data de Entrega: ', bold: true },
                        model.dataRetiradaFormatada +
                        '\n\n'
                    ], alignment: 'justify'
                },

                {
                    text: [
                        '6.3 ',
                        { text: 'Data e Hora de Devolução: ', bold: true },
                        model.dataDevolucaoFormatada +
                        '\n\n'
                    ], alignment: 'justify'
                },

                {
                    text: [
                        '6.4 O valor da locação será pago no ato de entrega do veículo, que corresponderá pelo aluguel, conforme estabelecido na Clausula de n. 5.' +
                        '\n\n'
                    ], alignment: 'justify'
                },

                {
                    text: [
                        '7. ',
                        { text: 'PRAZO DE LOCAÇÃO: ', bold: true },
                        'Este contrato poderá ter aditivos, que será identificado no próprio contrato de locação, seguindo o descrito na Clausula de n. 5.2 e 5.3.' +
                        '\n\n'
                    ], alignment: 'justify'
                },

                {
                    text: [
                        '8. ',
                        { text: 'OBRIGAÇÕES GERAIS: ', bold: true },
                        'Responsabilidades do locador e locatário: ' +
                        '\n\n'
                    ], alignment: 'justify'
                },

                {
                    text: [
                        '§ 1º O locador declara que a moto está em perfeitas condições mecânicas, como ' +
                        'também em relação a toda documentação pertinente a mesma, como licenciamento da ' +
                        'moto e a vistoria semestral conforme lei 12.009/2009, se responsabilizando pela ' +
                        'manutenção preventiva, conforme determina o fabricante.' +
                        '\n\n'
                    ], alignment: 'justify'
                },

                {
                    text: [
                        '§ 2º Esse contrato não poderá em nenhum momento ser reconhecido como ' +
                        'remuneração para todos os fins, exceto nas condições estabelecidas da clausula n. 5. ' +
                        '\n\n'
                    ], alignment: 'justify'
                },

                {
                    text: [
                        '§ 3º O locatário deverá possuir obrigatoriamente Carteira Nacional de Habilitação Cat. ' +
                        '“A”, ativa e regular, como conduzir o veiculo de forma a minimizar os acidentes de ' +
                        'trânsito.' +
                        '\n\n'
                    ], alignment: 'justify'
                },

                {
                    text: [
                        '§ 4º As multas e acidentes de trânsitos são de responsabilidade única do locatário, ' +
                        'inclusive se responsabilizando pelos terceiros envolvidos, em que a culpa ser ' +
                        'reconhecida como do locatário, sendo que a manutenção corretiva que vier do mau uso ' +
                        'ou de acidentes, será arcado exclusivamente pelo locatário.' +
                        '\n\n'
                    ], alignment: 'justify'
                },

                {
                    text: [
                        '§ 5º O locador exerce seu direito, de não permitir a sublocação do veículo, sendo de ' +
                        'total responsabilidade do locatário qualquer eventualidade que possa ocorrer sob ' +
                        'domínio de terceiros.' +
                        '\n\n'
                    ], alignment: 'justify'
                },

                {
                    text: [
                        '§ 6º Em caso de acidente com perca total, roubo ou furto, deverá o locatário restituir o ' +
                        'valor integral do bem ao locador, no prazo de 10 (dez) dias do boletim de ocorrência, ' +
                        'utilizando como parâmetros a tabela FIPE, sob pena de ter executado este título ' +
                        'executivo extrajudicial.' +
                        '\n\n'
                    ], alignment: 'justify'
                },

                {
                    text: [
                        '§ 7º O prazo estipulado para devolução do bem móvel, clausulas nº 5.2 e 5.3, deverão ' +
                        'ser respeitadas em sua totalidade, em caso de atraso de 15 (quinze) minutos, será ' +
                        'cobrado o valor referente ao uso excedente, usando como referência o valor-hora ' +
                        'integral.' +
                        '\n\n'
                    ], alignment: 'justify'
                },

                {
                    text: [
                        '§ 8º Em caso de atraso superior a uma hora, sem justifica plausível, ou ' +
                        'desaparecimento, o locatário tomará as medidas judiciais cabíveis, sendo considerado ' +
                        'apropriação indébita.' +
                        '\n\n'
                    ], alignment: 'justify'
                },

                {
                    text: [
                        '9. ',
                        { text: 'RESCISÃO CONTRATUAL – ', bold: true },
                        'Nos casos descritos na Clausula de n. 7, § 4º e 5º.' +
                        '\n\n'
                    ], alignment: 'justify'
                },

                {
                    text: [
                        '10. ',
                        { text: 'CONCLUSÃO: ', bold: true },
                        'As partes contratantes elegem o foro de PORTO VELHO - RO, quaisquer que sejam os ' +
                        'seus domicílios, para dirimir qualquer dúvida ou litígio oriundo do presente contrato.' +
                        '\n\n'
                    ], alignment: 'justify'
                },

                {
                    text: [
                        'E por estarem juntos e contratados assinam o presente instrumento em 2 vias de igual teor, ' +
                        'e deverá ainda constar cópia do documento da moto e da CNH do Locatário' +
                        '\n\n',
                    ], alignment: 'justify'
                },

                {
                    text: [
                        '\n\n',
                    ], alignment: 'justify'
                }, 

                {
                    text: [
                        'PORTO VELHO/RO, ' + model.dataDoContratoPorExtenso
                    ], alignment: 'center'
                },

                {
                    text: [
                        '\n\n',
                    ], alignment: 'justify'
                },                

                {
                    alignment: 'justify',
                    columns: [
                        {
                            text: [
                                '_________________________________________ \n\n',
                                { text: 'NAIR FERNANDA GOMES RAMALHO', bold: true },
                                '\n',
                                'LOCADOR \n',
                                'CPF Nº 028.369.872-19'
                            ],
                            alignment: 'center'
                        },
                        {
                            text: [
                                '_________________________________________ \n\n',
                                { text: model.nome, bold: true },
                                '\n',
                                'LOCATÁRIO \n',
                                'CPF Nº ' + model.cpf
                            ],
                            alignment: 'center'
                        }
                    ]
                },

                {
                    text: [
                        '\n\n\n\n\n\n',
                    ], alignment: 'justify'
                },    

                {
                    alignment: 'justify',
                    columns: [
                        {
                            text: [
                                '_________________________________________ \n\n',
                                'TESTEMUNHA',
                                '\n',
                                'CPF Nº'
                            ],
                            alignment: 'center'
                        },
                        {
                            text: [
                                '_________________________________________ \n\n',
                                'TESTEMUNHA',
                                '\n',
                                'CPF Nº'
                            ],
                            alignment: 'center'
                        }
                    ]
                },

            ],
            styles: {
                header: {
                    fontSize: 14,
                    bold: true
                }
            },
            defaultStyle: {
                fontSize: 11
            }

        };

        pdfMake.createPdf(dd).open();
    };

    Contrato.imprimirContrato = function (locacaoId) {
        var url = "/Impressao/ImprimirContrato";
        $.ajax({
            type: "GET",
            url: url,
            data: { locacaoId: locacaoId },
            dataType: "json",
            success: function success(result) {
                if (result.success) {
                    Contrato.gerarContrato(result.model);
                }
                if (result.Error) {
                    swal("Mensagem", result.error, "warning");
                }
            },
            error: function error(XMLHttpRequest, textStatus, errorThrown) {

                console.log(XMLHttpRequest);
                console.log(textStatus);
                console.log(errorThrown);
                swal("Mensagem", errorThrown, "error");
            }
        });
    };

});