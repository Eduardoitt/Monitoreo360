$(document).ready(function () {

    var table = $('#PAC').dataTable({
        processing: true,
        aLengthMenu: [[5, 10, 50, 100, -1], [5, 10, 50, 100, "Todos"]],
        ordering: false,
        language: {
            "lengthMenu": "Mostrar _MENU_ Registros",
            "zeroRecords": "No existe el ingreso",
            "info": "Pagina _PAGE_ de _PAGES_",
            "infoEmpty": "No hay registros disponibles",
            "infoFiltered": "(filtrado de _MAX_ registros)",
            "sSearch": "Buscar",
            "oPaginate": {
                "sFirst": "Primero",
                "sPrevious": "Anterior",
                "sNext": "Siguiente",
                "sLast": "Ultimo"
            }
        },
        sPaginationType: "full_numbers",
         /*fnRowCallback: function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
             var IdNominaHistorial = $("#IdNominaHistorial").val();
             $(nRow).attr('id', IdNominaHistorial);
         },*/
        dom: '<"row toolbar" <"col-md-4 col-sm-12" l>><t><"row" <"col-md-2 col-sm-12 text-center" i><"col-md-8 col-sm-12 text-center"p>>'
    });
    $('.toolbar').append("<div class=\"col-md-4 col-sm-12 text-center\"><button class=\"btn btn-info\" data-toggle=\"modal\" data-target=\"#myModal\" onclick=\"OpenModal('/Configuracion/Nuevo')\">Nueva Llave</button></div>");
   /*$('#MetodoPago').change(function () {
       console.log("Cambio:" + $('#MetodoPago').val());       
        table = $('#MonitoreoIngresos').dataTable();
        table.fnFilter($('#MetodoPago').val(), 4);
   });*/
    /*<button class="btn btn-info btn-xs" data-toggle="modal" data-target="#myModal" onclick="OpenModal('/Configuracion/Editar?id=2054ba57-f45e-4599-9b7c-a97744160265')">Editar</button>*/
   /*$('#dateSelector').change(function () {
       var fecha=$('#dateSelector').val().replace("-","/").split("/");
       console.log("Cambio:" +fecha[0]);
       table = $('#MonitoreoIngresos').dataTable();
       if (fecha[0]=="") {
           table.fnFilter("", 0);
       } else {
           table.fnFilter(fecha[1]+"/"+fecha[0], 0);
       }
   });*/
});