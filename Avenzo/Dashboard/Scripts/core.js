$(document).ready(function () {
    
   jQuery.extend(jQuery.validator.messages, {
                required: "Este campo es obligatorio.",
                remote: "Por favor, rellena este campo.",
                email: "Por favor, escribe una dirección de correo válida",
                url: "Por favor, escribe una URL válida.",
                date: "Por favor, escribe una fecha válida.",
                dateISO: "Por favor, escribe una fecha (ISO) válida.",
                number: "Por favor, escribe un número entero válido.",
                digits: "Por favor, escribe sólo dígitos.",
                creditcard: "Por favor, escribe un número de tarjeta válido.",
                equalTo: "Por favor, escribe el mismo valor de nuevo.",
                accept: "Por favor, escribe un valor con una extensión aceptada.",
                maxlength: jQuery.validator.format("Por favor, no escribas más de {0} caracteres."),
                minlength: jQuery.validator.format("Por favor, no escribas menos de {0} caracteres."),
                rangelength: jQuery.validator.format("Por favor, escribe un valor entre {0} y {1} caracteres."),
                range: jQuery.validator.format("Por favor, escribe un valor entre {0} y {1}."),
                max: jQuery.validator.format("Por favor, escribe un valor menor o igual a {0}."),
                min: jQuery.validator.format("Por favor, escribe un valor mayor o igual a {0}.")
   });
  
});
function redondeo(numero, decimales) {
    var flotante = parseFloat(numero);
    var resultado = Math.round(flotante * Math.pow(10, decimales)) / Math.pow(10, decimales);
    return resultado;
}
function OpenPage(url) {
    //var container = document.getElementById('AppView');
    $("#AppView").scrollTop(0);
    $("#AppView").perfectScrollbar('update');
    $("#NavBar").fadeOut("slow");
    $("#AppView").fadeOut("slow", function () {
        $("#AppView").empty();
        $("#loader").fadeIn(150,function () {
            $("#AppView").load(url, function (result, status) {
                $("#loader").fadeOut();
                $("#NavBar").fadeIn("slow");
                $("#AppView").fadeIn("slow");
            });
           /* $.ajax({
                method: "GET",
                url: url,
                async: false,
                success: function (result) {
                    $('#AppView').perfectScrollbar('update');
                    $("#AppView").html(result);
                    $("#NavBar").fadeIn("slow");
                    $("#loader").delay(1).fadeOut("slow", function () {                        
                        $("#AppView").fadeIn("slow");
                    });                    
                },
                error: function (result, status, xhr) {
                    var err = "Error " + " " + status;
                    if (xhr.responseText && xhr.responseText[0] == "{")
                        err += " "+JSON.parse(xhr.responseText).Message;
                    console.log(err);
                    alert(err)
                }*/
            });
        
    });   
}
function showNotification(from ,align,type,icon,message)
{
   // type = ['', 'info', 'success', 'warning', 'danger', 'rose', 'primary'];    
    $.notify({
        icon: icon,
        message:message

    }, {
        type: type,
        timer: 3000,
        placement: {
            from: from,
            align: align
        }
    });
}

function DeleteRegister(ID,URL, Table) {
    swal({
        title: '¿Estas Seguro?',
        text: "No se puede revertir esto!",
        type: 'warning',
        showCancelButton: true,
        confirmButtonClass: 'btn btn-success',
        cancelButtonClass: 'btn btn-danger',
        confirmButtonText: 'Si, Eliminalo!',
        buttonsStyling: false
    }).then(function () {        
        $.ajax({
            url: URL,
            type: 'POST',
            data: { id: ID },
            success: function (result) {
                if (result.error == false) {
                    var TR = document.getElementById(ID);
                    $(Table).dataTable().fnDeleteRow(TR);
                    swal({
                        title: 'Eliminado!',
                        text: 'El registro ha sido Eliminado.',
                        type: 'success',
                        confirmButtonClass: "btn btn-success",
                        buttonsStyling: false
                    });
                }
                else {
                    swal({
                        title: 'Hubo un Error!',
                        text: 'El registro no pudo ser Eliminado.',
                        type: 'error',
                        confirmButtonClass: "btn btn-success",
                        buttonsStyling: false
                    });
                }
            },
            error: function () {
                swal({
                    title: 'Hubo un Error!',
                    text: 'El registro no pudo ser eliminado.',
                    type: 'error',
                    confirmButtonClass: "btn btn-success",
                    buttonsStyling: false
                });
            }
        });
    });
}
function OpenModal(URL) {
    
    $("#Cargando").fadeIn("slow");    
    $('#myModal').load(URL, function () {
        $("#Cargando").fadeOut("slow");
    });
}
var readURL = function (input, id) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $(id).attr('src', e.target.result).fadeIn('slow');
            Imagen = e.target.result;
        }

        reader.readAsDataURL(input.files[0]);
    }
}
App = {
    Certificado: {        
        Nuevo: function () {
          
        },
        /********************************************************************************************************************************/
        Editar: function () {
            var llave = $("#Llave").get(0).files;
            var $this;
            var certificado = $("#Certificados").get(0).files;
            var Logo;
            var Imagen=null;
            var data = new FormData();
            var id = $('#id').val();
            if ($("#wizardPicturePreview").attr("src") != "~/Images/image_placeholder.jpg")
            {
                $('#remove').show();
                $('#selecionar').hide();
                $('#cambiar').show();
            }
            var LoadCer = function (resolve, reject) {        
                if (certificado.length > 0 || llave.length > 0 || Logo.length > 0) {            
                    $.ajax({
                        type: "POST",
                        url: '/Certificados/UpdateFile?Id=' + id,
                        contentType: false,
                        processData: false,
                        data: data,
                        success: function (result) {
                            console.log(result);
                            resolve(result);
                        },
                        error: function (xhr, status, p3, p4) {
                            var err = "Error " + " " + status + " " + p3 + " " + p4;
                            if (xhr.responseText && xhr.responseText[0] == "{")
                                err = JSON.parse(xhr.responseText).Message;
                            console.log(err);
                            reject(Error(err));
                        }
                    });
                }
                else {
                    resolve("No hay Archivos");
                }
            }
            var loadInfo = function () {
                console.log($this);
                $.ajax({
                    url: '/Certificados/Editar?id='+id,
                    type: 'POST',
                    data: $($this).serialize(),
                    success: function (result) {
                        $("#myModal").modal('hide');
                        if (result.error == "none") {
                            if(Logo==null)
                                Image = "~/Images/image_placeholder.jpg";
                            var Image = '<div class="img-container"><img src="' + Imagen + '"/></div>';
                            var Nombre = $('#Nombre').val();
                            var RFC = $('#RFC').val();
                            var CURP = $('#CURP').val();
                            var Regimen = $('#RegimenFiscal').val();
                            var Action = '<button class="btn btn-simple btn-success btn-icon" rel="tooltip" data-original-title="Descargar" onclick="DeleteRegister(\'' + id + '\',\'@Url.Content("/Certificados/Eliminar")\',\'#datatables\')"><i class="material-icons">file_download</i></button>';
                            Action += '<button class="btn btn-info btn-simple" data-toggle="modal" data-target="#myModal" onclick="OpenModal(\'@Url.Content("/Certificados/Editar?TempId=")' + id + '\')" rel="tooltip" data-original-title="Editar"><i class="material-icons">edit</i></button>';
                            Action += '<button class="btn btn-simple btn-danger btn-icon remove" rel="tooltip" data-original-title="Eliminar" onclick="DeleteRegister(\'' + id + '\',\'@Url.Content("/Certificados/Eliminar")\',\'#datatables\')"><i class="material-icons">close</i></button>';
                            var array = [Image, Nombre, RFC, CURP, Regimen, Action];
                            var TRNode = document.getElementById(id);
                            $('#datatables').dataTable().fnUpdate(array, TRNode, undefined);
                            swal({
                                title: 'Ultimo Paso!',
                                text: 'Se esta comprobando tu contraseña de la llave',
                                type: 'info',
                                confirmButtonClass: "btn btn-success",
                                buttonsStyling: false,
                                allowOutsideClick: false,
                                showLoaderOnConfirm: true,
                                preConfirm: function () {
                                    return new Promise(function (resolve,reject) {
                                        $.get('/Certificados/ComprobarLlave?Id=@Model.Id', function (result) {
                                            if (result.error == "none") {
                                                resolve();
                                            }
                                            else {
                                                reject();
                                            }
                                        });
                                  
                                    })
                                }
                            }).then(function (result) {
                                swal({
                                    title: 'Excelente!',
                                    text: 'Ya puedes empezar a facturar',
                                    type: 'success',
                                    confirmButtonClass: "btn btn-success",
                                    buttonsStyling: false
                                });

                            });
                        }
                    },
                    error: function (xhr, status, p3, p4) {
                        var err = "Error " + " " + status + " " + p3 + " " + p4;
                        if (xhr.responseText && xhr.responseText[0] == "{")
                            err = JSON.parse(xhr.responseText).Message;
                        console.log(err);
                    }
            
                });        
            }
            var readURL = function (input, id) {
                if (input.files && input.files[0]) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $(id).attr('src', e.target.result).fadeIn('slow');
                        Imagen = e.target.result;
                    }
                    reader.readAsDataURL(input.files[0]);
                }
            }
            $('#remove').click(function (e) {
                $('#wizardPicturePreview').attr('src', '/Images/image_placeholder.jpg');
                $('#logo').val('');
                $('#remove').hide();
                $('#selecionar').show();
                $('#cambiar').hide();
                console.log("Eliminar");
            });
            $('#logo').change(function (e) {
                readURL(this, '#wizardPicturePreview');
                $('#remove').show();
                $('#selecionar').hide();
                $('#cambiar').show();
                Logo = e.target.files;
            });
            $('#Llave').on('change', function (e) {            
                llave = e.target.files;
            });
            $('#Certificados').on('change', function (e) {            
                certificado = e.target.files;
            });
            $('form').submit(function (event) {
                $("#Cargando").fadeIn();            
                $this = this;
                var files = $("#logo").get(0).files;
                if (files.length>0) {
                    for (i = 0; i < files.length; i++) {
                        data.append("logo" + i, files[i]);
                    }
                }
                if (llave.length > 0) {                
                    if (window.FormData != undefined) {
                        for (var x = 0; x < llave.length; x++) {
                            data.append("llave" + x, llave[x]);
                        }
                    }
                }
                if (certificado.length > 0) {                
                    if (window.FormData != undefined) {
                        for (var x = 0; x < certificado.length; x++) {
                            data.append("certificado" + x, certificado[x]);
                        }
                    }
                }
                var promise = new Promise(LoadCer);
                promise.then(function (result) {
                    console.log("Cargando Info");
                    loadInfo();
                }, function (err) {
                    showNotification("bottom", "center", "danger", "add", "Hubo un problema");
                });
                return false;
            });            
        }
        /********************************************************************************************************************************/
    },
    Adeudo: {
        Inicio: function () {
            
            $('.Crear').click(function () {
                $('#myModal').modal('show');
                OpenModal('/Adeudos/SelecionDeFactura?IdAdeudo=' + $(this).attr("id"));
            });
            
        },
        Confirmar: function () {
           
        }
    }
};