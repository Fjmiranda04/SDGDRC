const modalPeriodo = new bootstrap.Modal(document.getElementById("modal-periodo"), {});
const modalEmpresa = new bootstrap.Modal(document.getElementById("modal-empresa"), {});
const modalBanco = new bootstrap.Modal(document.getElementById("modal-banco"), {});
const modalComprobante = new bootstrap.Modal(document.getElementById("modal-comprobante"), {});
const modalEmail = new bootstrap.Modal(document.getElementById("modal-email"), {});
var archivo = "";

$(document).ready(function ()
{

    let currentDate = new Date();
    let firstDate = new Date(currentDate.getFullYear(), currentDate.getMonth(), 1);


    $("#fechaicp").val(formatDate2(firstDate));
    $("#fechafcp").val(formatDate2(currentDate));

    //$("#fechaicp").on('change', function ()
    //{
    //    ValidateFechaPeriodo();
    //});

    //$("#fechafcp").on('change', function ()
    //{
    //    ValidateFechaPeriodo();
    //});

    $('#btnSueldoAct').click(function ()
    {
        archivo = "";
        GetCertificadoSueldoAct();
        $("#lblVisor").text("Certificado: Sueldo Actual");
    });

    $('#btnSueldoProm').click(function ()
    {
        archivo = "";
        GetCertificadoSueldoProm();
        $("#lblVisor").text("Certificado: Sueldo Promedio");
    });

    $('#btnCertificadoLab').click(function ()
    {
        archivo = "";
        modalPeriodo.show();
        $("#lblVisor").text("Certificado: Ingresos y Retenciones");
    });

    $('#btnHistorialLaboral').click(function ()
    {
        archivo = "";
        GetHistorialLaboral();
        $("#lblVisor").text("Certificado: Historial Laboral");
    });
    $('#btnContratoLaboral').click(function ()
    {
        archivo = "";
        GetContratoLaboral();
        $("#lblVisor").text("Certificado: Contrato Laboral");
    });

    $('#btnExamenI').click(function () {
        modalEmpresa.show();
    });

    $('#btnEmpresa').click(function () {
        GetExamenIngreso();
    });

    $('#btnCartaBanco').click(function () {
        modalBanco.show();
    });

    $('#btnBanco').click(function () {
        GetCartaBanco();
    });

    $('#btnBanco').click(function () {
        GetCartaBanco();
    });

    $('#btnComprobante').click(function () {
        GetComprobantePago();
    });

    $('#btnComprobantePago').click(function ()
    {
        archivo = "";
        modalComprobante.show();
        $("#lblVisor").text("Certificado: Comprobantes de Pago");
    });

    $('#btnSendMyEmail').click(function () {
        SendMyEmail();
    });

    $('#btnSendOtherEmail').click(function () {
        $("#emailing").val("")
        modalEmail.show();
    });

    $('#btnSendOtherEmailModal').click(function () {
        SendOtherEmail();
    });

    $('#btn-download-pdf').click(function () {
        DownLoadPdf();
    });

    $('#btnPeriodo').click(function ()
    {
        $.ajax({
            url: "/GestionHumana/GetDocumentCertificadoLaboral",
            type: "GET",
            data: { Periodo: $('#periodo option:selected').val() },
            beforeSend: function () {
                LoaderScreenShow();
                modalPeriodo.hide();
                $('#btnContratoLaboral').prop("disabled", true);
            },
            success: function (response) {
                if (response.result)
                {
                    archivo = response.data;
                    $("#viewerpdf").html(function () {
                        return `<embed src="/Net/Temp/${response.data}" width="100%" height="640px" type="application/pdf" />`;
                    });

                    let fecha = new Date();
                    $("#fechacertificado").text("Generado el " + fecha.getDate() + " de " + fecha.toLocaleString('default', { month: 'long' }) + " de " + fecha.getFullYear());

                } else
                {
                    $("#viewerpdf").html(function () {
                        return ``;
                    });
                    $("#fechacertificado").text("");
                    ToastAlert.fire({ icon: 'error', title: response.message }); ToastAlert.fire({ icon: 'error', title: response.message });
                }
            },
            complete: function () {
                LoaderScreenHide();
                $('#btnContratoLaboral').prop('disabled', true);
            }
        });
    });

    GetBancos();
});

function GetCertificadoSueldoAct()
{
    $.ajax({
        url: '/GestionHumana/GetDocumentCertificadoLaboralS',
        type: "GET",
        beforeSend: function ()
        {
            LoaderScreenShow();
            $('#btnSueldoAct').prop("disabled", true);
        },
        success: function (response) {
            if (response.result)
            {
                archivo = response.data;
                $("#viewerpdf").html(function () {
                    return `<embed src="/Temp/Trash/${response.data}" width="100%" height="640px" type="application/pdf" />`;
                });

                let fecha = new Date();
                $("#fechacertificado").text("Generado el " + fecha.getDate() + " de " + fecha.toLocaleString('default', { month: 'long' }) + " de " + fecha.getFullYear());

            } else
            {
                $("#viewerpdf").html(function () {
                    return ``;
                });
                $("#fechacertificado").text("");
                ToastAlert.fire({ icon: 'error', title: response.message }); ToastAlert.fire({ icon: 'error', title: response.message });
            }
        },
        complete: function () {
            LoaderScreenHide();
            $('#btnSueldoAct').prop('disabled', true);
        }
    });
}

function GetCertificadoSueldoProm() {
    $.ajax({
        url: '/GestionHumana/GetDocumentCertificadoLaboralP',
        type: "GET",
        beforeSend: function () {
            LoaderScreenShow();
            $('#btnSueldoAct').prop("disabled", true);
        },
        success: function (response) {
            if (response.result) {

                archivo = response.data;
                $("#viewerpdf").html(function () {
                    return `<embed src="/Temp/Trash/${response.data}" width="100%" height="640px" type="application/pdf" />`;
                });

                let fecha = new Date();
                $("#fechacertificado").text("Generado el " + fecha.getDate() + " de " + fecha.toLocaleString('default', { month: 'long' }) + " de " + fecha.getFullYear());


            } else
            {
                $("#viewerpdf").html(function () {
                    return ``;
                });
                $("#fechacertificado").text("");
                ToastAlert.fire({ icon: 'error', title: response.message }); ToastAlert.fire({ icon: 'error', title: response.message });
            }
        },
        complete: function () {
            LoaderScreenHide();
            $('#btnSueldoAct').prop('disabled', true);
        }
    });
}

function GetContratoLaboral() {
    $.ajax({
        url: '/GestionHumana/GetContratoLaboral',
        type: "GET",
        beforeSend: function () {
            LoaderScreenShow();
            $('#btnSueldoAct').prop("disabled", true);
        },
        success: function (response) {
            if (response.result) {

                archivo = response.data;
                $("#viewerpdf").html(function () {
                    return `<embed src="/Temp/Trash/${response.data}" width="100%" height="640px" type="application/pdf" />`;
                });

                let fecha = new Date();
                $("#fechacertificado").text("Generado el " + fecha.getDate() + " de " + fecha.toLocaleString('default', { month: 'long' }) + " de " + fecha.getFullYear());


            } else
            {
                $("#viewerpdf").html(function () {
                    return ``;
                });
                $("#fechacertificado").text("");
                ToastAlert.fire({ icon: 'error', title: response.message }); ToastAlert.fire({ icon: 'error', title: response.message });
            }
        },
        complete: function () {
            LoaderScreenHide();
            $('#btnSueldoAct').prop('disabled', true);
        }
    });
}

function GetExamenIngreso()
{
    $.ajax({
        url: '/GestionHumana/GetExamenIngreso',
        type: "GET",
        data: { Empresa: $('#empresa').val(), Direccion: $('#direccion').val(), Ciudad: $('#ciudad').val() },
        beforeSend: function () {
            LoaderScreenShow();
            modalEmpresa.hide();
            $('#btnSueldoAct').prop("disabled", true);
        },
        success: function (response) {
            if (response.result) {

                archivo = response.data;
                $("#viewerpdf").html(function () {
                    return `<embed src="/Temp/Trash/${response.data}" width="100%" height="700px" type="application/pdf" />`;
                });

                let fecha = new Date();
                $("#fechacertificado").text("Generado el " + fecha.getDate() + " de " + fecha.toLocaleString('default', { month: 'long' }) + " de " + fecha.getFullYear());


            } else
            {
                $("#viewerpdf").html(function () {
                    return ``;
                });
                $("#fechacertificado").text("");
                ToastAlert.fire({ icon: 'error', title: response.message }); ToastAlert.fire({ icon: 'error', title: response.message });
            }
        },
        complete: function () {
            LoaderScreenHide();
            $('#btnSueldoAct').prop('disabled', true);
        }
    });
}

function GetCartaBanco() {
    $.ajax({
        url: '/GestionHumana/GetCartaBanco',
        type: "GET",
        data: { Banco: $('#banco').val() },
        beforeSend: function () {
            LoaderScreenShow();
            modalBanco.hide();
            $('#btnCartaBanco').prop("disabled", true);
        },
        success: function (response) {
            if (response.result) {

                archivo = response.data;

                $("#viewerpdf").html(function () {
                    return `<embed src="/Temp/Trash/${response.data}" width="100%" height="700px" type="application/pdf" />`;
                });

                let fecha = new Date();
                $("#fechacertificado").text("Generado el " + fecha.getDate() + " de " + fecha.toLocaleString('default', { month: 'long' }) + " de " + fecha.getFullYear());


            } else
            {
                $("#viewerpdf").html(function () {
                    return ``;
                });

                $("#fechacertificado").text("");

                ToastAlert.fire({ icon: 'error', title: response.message }); ToastAlert.fire({ icon: 'error', title: response.message });
            }
        },
        complete: function () {
            LoaderScreenHide();
            $('#btnCartaBanco').prop('disabled', true);
        }
    });
}

function GetBancos() {
    $.ajax({
        url: '/GestionHumana/GetBancos',
        type: "GET",
        success: function (response) {
            if (response.result) {

                for (let i in response.data) {
                    $("#banco").append(`<option value=${response.data[i].codigo}>${response.data[i].nombre}</option>`);
                }


            } else {
                ToastAlert.fire({ icon: 'error', title: response.message }); ToastAlert.fire({ icon: 'error', title: response.message });
            }
        },
    });
}


function GetComprobantePago()
{
    if (!ValidateFechaPeriodo())
    {
        return;
    }

    $.ajax({
        url: '/GestionHumana/GetDocumentComprobantePago',
        type: "GET",
        data: { FechaI: $("#fechaicp").val(), FechaF: $("#fechafcp").val() },
        beforeSend: function () {
            LoaderScreenShow();
            $('#btnComprobantePago').prop("disabled", true);
        },
        success: function (response) {
            if (response.result) {
                archivo = response.data;
                $("#viewerpdf").html(function () {
                    return `<embed src="/Temp/Trash/${response.data}" width="100%" height="640px" type="application/pdf" />`;
                })


            } else
            {
                $("#viewerpdf").html(function () {
                    return ``;
                });
                ToastAlert.fire({ icon: 'error', title: response.message }); ToastAlert.fire({ icon: 'error', title: response.message });
            }
        },
        complete: function () {
            LoaderScreenHide();
            $('#btnComprobantePago').prop('disabled', true);
            modalComprobante.hide();
        }
    });
}

function GetHistorialLaboral() {
    $.ajax({
        url: '/GestionHumana/GetDocumentHistorialLaboral',
        type: "GET",
        beforeSend: function () {
            LoaderScreenShow();
            $('#btnHistorialLaboral').prop("disabled", true);
        },
        success: function (response) {
            if (response.result) {

                archivo = response.data;
                $("#viewerpdf").html(function () {
                    return `<embed src="Temp/Trash/${response.data}" width="100%" height="640px" type="application/pdf" />`;
                });
            } else
            {
                $("#viewerpdf").html(function () {
                    return ``;
                });
                ToastAlert.fire({ icon: 'error', title: response.message }); ToastAlert.fire({ icon: 'error', title: response.message });
            }
        },
        complete: function () {
            LoaderScreenHide();
            $('#btnHistorialLaboral').prop('disabled', true);
            modalComprobante.hide();
        }
    });
}

function SendMyEmail()
{
    $.ajax({
        url: '/GestionHumana/SendMyEmail',
        type: "GET",
        data: { FileSend: archivo },
        beforeSend: function () {
            LoaderScreenShow();
            $('#btnSendMyEmail').prop("disabled", true);
        },
        success: function (response)
        {
            if (response.result)
            {
                ToastAlert.fire({ icon: 'success', title: response.message }); 
            }
            else
            {
                ToastAlert.fire({ icon: 'error', title: response.message }); 
            }
        },
        complete: function () {
            LoaderScreenHide();
            $('#btnSendMyEmail').prop('disabled', false);
        }
    });
}

function SendOtherEmail()
{

    let email = $("#emailing").val();

    $.ajax({
        url: '/GestionHumana/SendOtherEmail',
        type: "GET",
        data: { FileSend: archivo, Email: email },
        beforeSend: function () {
            LoaderScreenShow();
            $('#btnSendOtherEmail').prop("disabled", true);
        },
        success: function (response) {
            if (response.result) {
                ToastAlert.fire({ icon: 'success', title: response.message });
            }
            else {
                ToastAlert.fire({ icon: 'error', title: response.message });
            }
        },
        complete: function () {
            LoaderScreenHide();
            modalEmail.hide();
            $('#btnSendOtherEmail').prop('disabled', false);
        }
    });
}

function DownLoadPdf()
{
    if (archivo != "" && archivo != null)
    {
        $.ajax({
            url: '/GestionHumana/DownLoadFile',
            type: "GET",
            data: { FileSend: archivo },
            xhrFields: {
                responseType: 'blob' // Indicar que la respuesta será un blob (archivo binario)
            },
            beforeSend: function () {
                LoaderScreenShow();
                $('#btn-download-pdf').prop("disabled", true);
            },
            success: function (data, textStatus, jqXHR) {
                // Crear un objeto URL para el blob
                var urlBlob = window.URL.createObjectURL(data);

                var a = document.createElement('a');
                a.href = urlBlob;
                a.download = archivo; // Nombre del archivo
                document.body.appendChild(a);
                a.click();

                window.URL.revokeObjectURL(urlBlob);
                document.body.removeChild(a);
            },
            complete: function () {
                LoaderScreenHide();
                $('#btn-download-pdf').prop('disabled', false);
            }
        });
    }
}

function ValidateFechaPeriodo()
{
    let fechaInicial = new Date($("#fechaicp").val() + "T00:00:00");
    let fechaFinal = new Date($("#fechafcp").val() + "T00:00:00");

    if (fechaInicial > fechaFinal)
    {
        $("#fechafcp").val(new Date().toISOString().split('T')[0]);
        $("#fechaicp").val(new Date().toISOString().split('T')[0]);
        ToastAlert.fire({ icon: 'error', title: "¡La fecha inicial no puede ser mayor a la final!" });
        return false;
    }

    if (fechaFinal < fechaInicial)
    {
        $("#fechafcp").val(new Date().toISOString().split('T')[0]);
        $("#fechaicp").val(new Date().toISOString().split('T')[0]);
        ToastAlert.fire({ icon: 'error', title: "¡La fecha final no puede ser menor a la inicial!" });
        return false;
    }

    return true;
}