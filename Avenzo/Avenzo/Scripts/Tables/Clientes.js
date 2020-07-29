$(document).ready(function () {

    var table = $('#clientes').dataTable({
        processing: true,
        aLengthMenu: [[5, 10, 50, 100, -1], [5, 10, 50, 100, "Todos"]],
        ordering: false,
        language: {
            "lengthMenu": "Mostrar _MENU_ Registros",
            "zeroRecords": "No existe el cliente",
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
        "dom": '<"row toolbar" <"col-sm-12 col-md-4 text-center" f><"col-sm-12 col-md-4 text-center" l>><"table-responsive" t><"row" <"col-sm-2" i><"col-sm-8" p>>'

    });
    $("div.toolbar").append('<div class="col-md-4 col-sm-12 text-center"><button class="btn btn-info" onclick="OpenModal(\'/Clientes/Nuevo\')"  data-toggle="modal" data-target="#myModal"> <i class="fa fa-user-plus" aria-hidden="true"></i> &nbsp;Nuevo Cliente</button ></div>');
});