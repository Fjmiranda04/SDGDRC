$(document).ready(() =>
{
    $('#btnuploadpicture').click(function ()
    {
        $('#filelogo').click();
    });

    $('#btnsavecfg').click(function () {
        SaveConfiguracion();
    });

    $('#filelogo').on('change', function ()
    {
        var archivos = $(this)[0].files;

        if (archivos.length > 0) {

            var extension = $(this).val().split('.').pop().toLowerCase();

            // Verificar si la extensión está en la lista de extensiones de imágenes
            if ($.inArray(extension, ['png', 'jpg', 'jpeg', 'gif']) == -1)
            {
                ToastAlert.fire({ icon: 'error', title: 'Por favor, selecciona un archivo de imagen válido.' });
                $(this).val(''); 

                return;
            }

            var imagenSeleccionada = archivos[0];

            var lector = new FileReader();

            lector.onload = function (e)
            {
                var urlImagen = e.target.result;

                $('#imglogo').attr('src', urlImagen).show();
            };

            lector.readAsDataURL(imagenSeleccionada);

            console.log('Nombre del archivo:', imagenSeleccionada);
            console.log('Tipo del archivo:', imagenSeleccionada.type);
            console.log('Tamaño del archivo:', imagenSeleccionada.size);
        }
    });

    $('#btnsavecfg').click(function ()
    {

    });

    GetConfiguracion();
});


function GetConfiguracion()
{
    $.ajax({
        url: "/Configuration/GetConfiguraciones",
        type: "GET",
        contentType: "application/json",
        beforeSend: function ()
        {
            LoaderScreenShow();
        },
        success: function (response)
        {
            if (response.result)
            {
                console.log(response.data);
                $("#nombreempresa").val(response.data.filter(obj => obj.clave == "NAME_EMPRESA")[0].valor);
                $("#nitempresa").val(response.data.filter(obj => obj.clave == "NIT_EMPRESA")[0].valor);
                $("#direccionempresa").val(response.data.filter(obj => obj.clave == "NAME_EMPRESA")[0].valor);
                $("#telefonoempresa").val(response.data.filter(obj => obj.clave == "NAME_EMPRESA")[0].valor);
                $("#webempresa").val(response.data.filter(obj => obj.clave == "WEB_EMPRESA")[0].valor);
                $("#emails").val(response.data.filter(obj => obj.clave == "PRINCIPAL_EMAILS")[0].valor);

                $('#imglogo').attr('src', response.data.filter(obj => obj.clave == "LOGO_EMPRESA")[0].valor);

                $("#idbucket").val(response.data.filter(obj => obj.clave == "AWS_ID_BUCKET")[0].valor);
                $("#urlbucket").val(response.data.filter(obj => obj.clave == "AWS_URL_BUCKET")[0].valor);
                $("#nombrebucket").val(response.data.filter(obj => obj.clave == "AWS_NAME_BUCKET")[0].valor);
            }
            else
            {
                ToastAlert.fire({ icon: 'error', title: response.msg });
            }

        },
        complete: function () {
            LoaderScreenHide();
        }
    });
}

function SaveConfiguracion()
{
    let datos =
        [
            { Id: 0, Clave: "PRINCIPAL_EMAILS", Valor: $("#emails").val(), Descripcion:"" },
            { Id: 0, Clave: "AWS_URL_BUCKET", Valor: $("#urlbucket").val(), Descripcion: "" },
            { Id: 0, Clave: "AWS_ID_BUCKET", Valor: $("#idbucket").val(), Descripcion: "" },
            { Id: 0, Clave: "AWS_NAME_BUCKET", Valor: $("#nombrebucket").val(), Descripcion: "" },
            { Id: 0, Clave: "LOGO_EMPRESA", Valor: $("#").val(), Descripcion: "" },
            { Id: 0, Clave: "WEB_EMPRESA", Valor: $("#webempresa").val(), Descripcion: "" },
            { Id: 0, Clave: "CONNECTION_STRING", Valor: $("#").val(), Descripcion: "" },
            { Id: 0, Clave: "NIT_EMPRESA", Valor: $("#").val(), Descripcion: "" },
            { Id: 0, Clave: "NAME_EMPRESA", Valor: $("#nombreempresa").val(), Descripcion: "" },
        ];

        var logoForm = new FormData();
        logoForm.append('filelogo', $('#filelogo')[0].files[0]);


        $.ajax({
            url: "/Configuration/SaveConfiguraciones",
            type: "POST",
            data: { configuraciones: datos},
            beforeSend: function () {
                LoaderScreenShow();
            },
            success: function (response) {
                if (response.result) {
                    ToastAlert.fire({ icon: 'success', title: response.msg });
                
                }
                else {
                    ToastAlert.fire({ icon: 'error', title: response.msg });
                }

            },
            complete: function () {
                LoaderScreenHide();
            }
        });

        $.ajax({
            url: "/Configuration/SaveLogoEmpresa",
            type: "POST",
            data: { logo: logoForm },
            beforeSend: function () {
                LoaderScreenShow();
            },
            success: function (response) {
                if (response.result) {
                    ToastAlert.fire({ icon: 'success', title: response.msg });

                }
                else {
                    ToastAlert.fire({ icon: 'error', title: response.msg });
                }

            },
            complete: function () {
                LoaderScreenHide();
            }
        });
}

function UploadLogo()
{

}