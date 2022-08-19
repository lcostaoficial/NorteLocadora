$(function () {

    "use strict";

    window.Quadro = window.Quadro || {};

    Quadro.Quadro = function () {
        $("#calendar").fullCalendar("refetchEvents");
    };

    Quadro.carregarCalendario = function () {

        if ($('#calendar').length) {

            $('#calendar').fullCalendar({

                locale: 'pt-br',
                eventRender: function (eventObj, $el) {
                    $el.popover({
                        title: eventObj.title,
                        content: eventObj.description,
                        trigger: 'hover',
                        placement: 'bottom',
                        container: 'body'
                    });

                    if (eventObj.author) {
                        $el.find(".fc-title").prepend("<i style='cursor: help' title='Responsável: " + eventObj.author + "' class='fa fa-" + "user" + "'></i> ");
                    }
                },  

                eventClick: function (info) {
                    window.location.replace("/Retirada/Editar/" + info.id);
                },

                header: {
                    left: 'prev,next today',
                    center: 'title',
                    right: 'month,listYear'
                },

                buttonIcons: {
                    prev: 'none fa fa-angle-left',
                    next: 'none fa fa-angle-right',
                    prevYear: 'none fa fa-angle-left',
                    nextYear: 'none fa fa-angle-right'
                },

                editable: false,
                eventLimit: true,
                navLinks: true,
                droppable: false,      

                events: {
                    url: $("#calendar").data("url")
                    //error: function () {
                    //    caso.pararcarregamento();
                    //    alert('erro');
                    //}
                }
            });
        }
    };

    Quadro.carregarEventos();

});