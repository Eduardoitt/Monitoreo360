$(document).ready(function () {
    var empleados = $('#Empleados').dataTable({
        processing: true,
        aLengthMenu: [[5, 10, 50, 100, -1], [5, 10, 50, 100, "Todos"]],
        ordering: false,
        language: {
            "lengthMenu": "Mostrar _MENU_ Registros",
            "zeroRecords": "No existe el Empleado",
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
        "dom": '<"row toolbar1 text-center" fl><t><"row" ip>'

    });
    $("div.toolbar1").append('<div class="col-sm-2 text-center"><button class="btn btn-info" onclick="OpenModal(\'/Empleados/Nuevo\')"  data-toggle="modal" data-target="#myModal"> <i class="fa fa-user-plus" aria-hidden="true"></i> &nbsp;Nuevo Empleado</button ></div>');              
});
