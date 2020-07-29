$(document).ready(function () {

    var table = $('#Nominas').dataTable({
        processing: true,
        aLengthMenu: [[5, 10, 50, 100, -1], [5, 10, 50, 100, "Todos"]],
        ordering: false,
        language: {
            "lengthMenu": "Mostrar _MENU_ Registros",
            "zeroRecords": "No existe La Nomina",
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
       /* fnRowCallback: function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
            var IdNominaHistorial = $("#IdNominaHistorial").val();
            $(nRow).attr('id', IdNominaHistorial);
        },*/
        dom: '<"row toolbar" <"col-md-4 col-sm-12 text-center" l>><t><"row" <"col-md-2 col-sm-12 text-center" i><"col-md-8 col-sm-12 text-center"p>>'
    });
    $('.toolbar #PACS').change(function () {
        table = $('#Nominas').dataTable();
        table.fnFilter($(this).val());
    });
});