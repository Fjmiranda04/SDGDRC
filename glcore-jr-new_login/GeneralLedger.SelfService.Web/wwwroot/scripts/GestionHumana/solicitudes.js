const modalEPS = new bootstrap.Modal(document.getElementById("modal-eps"), {});
const modalTipoDocumento = new bootstrap.Modal(document.getElementById("modal-tipo-documento"), {});
const modalFondoP = new bootstrap.Modal(document.getElementById("modal-fondop"), {});
const modalFondoC = new bootstrap.Modal(document.getElementById("modal-fondoc"), {});
const modalSueldo= new bootstrap.Modal(document.getElementById("modal-sueldo"), {});
const modalCajaCompensacion = new bootstrap.Modal(document.getElementById("modal-caja"), {});
const modalShow = new bootstrap.Modal(document.getElementById("modal-show-novedad"), {});
const modalPermiso = new bootstrap.Modal(document.getElementById("modal-permiso"), {});
const modalVacaciones = new bootstrap.Modal(document.getElementById("modal-vacaciones"), {});
const modalVacacionesShow = new bootstrap.Modal(document.getElementById("modal-show-vacaciones"), {});
const modalPermisoShow = new bootstrap.Modal(document.getElementById("modal-show-permiso"), {});
var vacacionesEmpleados = {};

$(document).ready(function ()
{
    'use strict';

    $("#hfinalpermiso").attr("step", "60");
    $("#hinicialpermiso").attr("step", "60");

    $('#hfinalpermiso').attr('min', '08:00');
    $('#hfinalpermiso').attr('max', '18:00');

    $('#hinicialpermiso').attr('min', '08:00');
    $('#hinicialpermiso').attr('max', '18:00');

    $("#hfinalpermiso").val("08:00");
    $("#hinicialpermiso").val("08:00");

    $(".js-example-basic-single").select2({
        theme: "bootstrap4",
        language: "es"
    });

    $("#btn-save-eps").click(function () {
        SaveNovedad("0002");
    });
    $("#btn-save-tipdoc").click(function () {
        SaveNovedad("0003");
    });
    $("#btn-save-pen").click(function () {
        SaveNovedad("0004");
    });
    $("#btn-save-ces").click(function () {
        SaveNovedad("0005");
    });
    $("#btn-save-sue").click(function () {
        SaveNovedad("0006");
    });
    $("#btn-save-com").click(function () {
        SaveNovedad("0008");
    });

    $("#btn-save-permiso").click(function ()
    {
        if (ValidateForms("#form-permiso"))
        {
            SavePermiso();
        }
    });

    $("#btn-save-vacaciones").click(function ()
    {
        if (ValidateForms("#form-vacaciones"))
        {
            SaveVacaciones();
        }
    });

    $('#sueldoactual').on('input', function () {
        var valor = parseFloat($(this).val().replace(/,/g, ''));
        if (!isNaN(valor)) {
            $(this).val(valor.toLocaleString());
        }
    });

    $('#sueldonuevo').on('input', function () {
        var valor = parseFloat($(this).val().replace(/,/g, ''));
        if (!isNaN(valor)) {
            $(this).val(valor.toLocaleString());
        }
    });

    $('#diashabil').on('change', function ()
    {
        if (ValidateVacaciones(vacacionesEmpleados))
        {
            CalculateVacaciones(vacacionesEmpleados);
        }
    });

    $('#diascompensados').on('change', function ()
    {
        if (ValidateVacaciones(vacacionesEmpleados))
        {
            CalculateVacaciones(vacacionesEmpleados);
        }
    });

    $('#fvacacionesi').on('change', function ()
    {
        if (ValidateVacaciones(vacacionesEmpleados))
        {
            CalculateVacaciones(vacacionesEmpleados);
        }
    });

    $("#btn-n-solicitud").click(function ()
    {
        let option = $("#TipoNovedad").val();

        switch (option)
        {
            case "0002": GetInfoEmpleado("0002"); break;
            case "0003": GetInfoEmpleado("0003"); break;
            case "0004": GetInfoEmpleado("0004"); break;
            case "0005": GetInfoEmpleado("0005"); break;
            case "0006": GetInfoEmpleado("0006"); break;
            case "0008": GetInfoEmpleado("0008"); break;
            case "AUSP": GetInfoEmpleado("AUSP"); break;
            case "AUSV": GetInfoEmpleado("AUSV"); break;
            default: ToastAlert.fire({ icon: 'error', title: "No se ha elegido una novedad valida" }); break;
        }
    });

    $('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
        LoadTableSolicitudes();
    });

    LoadTableSolicitudes();
});


function LoadTableSolicitudes()
{
    $.ajax({
        url: "/GestionHumana/GetSolicitudesNovedadEmpleado",
        type: 'GET',
        dataType: 'json',
        success: function (response)
        {


            tableSolicitudesP = $('#table-pendientes').DataTable({
                dom: "t<'d-flex align-items-center'<'me-auto pb-2 mx-2'i><'mb-0 pb-2 mx-2'p>>",
                responsive: true,
                scrollCollapse: true,
                destroy: true,
                paging: true,
                lengthMenu: [15, 25, 50, 100],
                language: {
                    url: "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json",
                },
                data: response.data.pendientes,
                columns: [
                    {
                        "data": "idSolicitudNovedad",
                        render: function (data, type, row)
                        {
                            return `<span class="badge bg-info fw-bold" style="font-size:0.9rem">#${data}</span>`;
                        }
                    },
                    {
                        "data": "fechaNovedad",
                        render: function (data, type, row) {
                            let fecha = new Date(data);
                            fecha = formatDate(fecha);
                            return `
                                    <div class="text-center">
                                        <span class="badge bg-success bg-opacity-20 text-success fw-bold text-center" style="font-size:0.8rem"> 
                                            <i class="far fa-calendar-plus fa-lg"></i>
                                            ${fecha}
                                        </span>
                                    </div>`;
                        }
                    },
                    { "data": "nombreNovedad" },
                    {
                        "data": "descripcionNovedad",
                        render: function (data, type, row)
                        {
                            return `<span class="d-inline-block text-truncate fw-bold py-0 px-0 mx-0 my-0" style="font-size: 1rem;max-width: 320px;max-height:30px;">${data}</span>  `;                                    
                        }
                    },
                    {
                        "data": "idSolicitudNovedad",
                        render: function (data, type, row)
                        {
                            var html = '';

                            html += '<div class="btn-group btn-group-sm" role="group">';
                            html += `<button type="button" class="btn btn-secondary btn-sm" onclick="ModalShow('${data}','${row.codigoTipoNovedad}')" title="Ver detalles" ><i class="fa fa-fw fa-eye"></i></button>
                                     <button type="button" class="btn btn-secondary btn-sm" onclick="" title="Imprimir Solicitud" ><i class="fas fa-print"></i></button>`;
                            html += '</div>';
                            return html;
                           
                        }
                    },
                ],
                columnDefs: [
                    { "width": "10%", "targets": 0 },
                    { "width": "10%", "targets": 1 },
                    { "width": "20%", "targets": 2 },
                    { "width": "50%", "targets": 3 },
                    { "width": "10%", "targets": 4 },
                ],
            });

            tableSolicitudesA = $('#table-aprobadas').DataTable({
                dom: "t<'d-flex align-items-center'<'me-auto pb-2 mx-2'i><'mb-0 pb-2 mx-2'p>>",
                responsive: true,
                scrollCollapse: true,
                destroy: true,
                paging: true,
                lengthMenu: [15, 25, 50, 100],
                language: {
                    url: "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json",
                },
                data: response.data.aprobadas,
                columns: [
                    {
                        "data": "idSolicitudNovedad",
                        render: function (data, type, row) {
                            return `<span class="badge bg-info fw-bold" style="font-size:0.9rem">#${data}</span>`;
                        }
                    },
                    {
                        "data": "fechaNovedad",
                        render: function (data, type, row) {
                            let fecha = new Date(data);
                            fecha = formatDate(fecha);
                            return `
                                    <div class="text-center">
                                        <span class="badge bg-success bg-opacity-20 text-success fw-bold text-center" style="font-size:0.8rem"> 
                                            <i class="far fa-calendar-plus fa-lg"></i>
                                            ${fecha}
                                        </span>
                                    </div>`;
                        }
                    },
                    { "data": "nombreNovedad" },
                    { "data": "descripcionNovedad" },
                    { "data": "fechaAprobacionNovedad" },
                    {
                        "data": "idSolicitudNovedad",
                        render: function (data, type, row)
                        {
                            var html = '';

                            html += '<div class="btn-group btn-group-sm" role="group">';
                            html += `<button type="button" class="btn btn-secondary btn-sm" onclick="ModalShow('${data}','${row.codigoTipoNovedad}')" title="Ver detalles" ><i class="fa fa-fw fa-eye"></i></button>
                                     <button type="button" class="btn btn-secondary btn-sm" onclick="" title="Imprimir Solicitud" ><i class="fas fa-print"></i></button>`;
                            html += '</div>';
                            return html;
                        }
                    },
                ],
                columnDefs: [
                    { "width": "10%", "targets": 0 },
                    { "width": "10%", "targets": 1 },
                    { "width": "20%", "targets": 2 },
                    { "width": "40%", "targets": 3 },
                    { "width": "10%", "targets": 4 },
                    { "width": "10%", "targets": 5 },
                ],
            });

            tableSolicitudesR = $('#table-rechazadas').DataTable({
                dom: "t<'d-flex align-items-center'<'me-auto pb-2 mx-2'i><'mb-0 pb-2 mx-2'p>>",
                responsive: true,
                scrollCollapse: true,
                destroy: true,
                paging: true,
                lengthMenu: [15, 25, 50, 100],
                language: {
                    url: "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json",
                },
                data: response.data.rechazadas,
                columns: [
                    {
                        "data": "idSolicitudNovedad",
                        render: function (data, type, row) {
                            return `<span class="badge bg-info fw-bold" style="font-size:0.9rem">#${data}</span>`;
                        }
                    },
                    {
                        "data": "fechaNovedad",
                        render: function (data, type, row) {
                            let fecha = new Date(data);
                            fecha = formatDate(fecha);
                            return `
                                    <div class="text-center">
                                        <span class="badge bg-success bg-opacity-20 text-success fw-bold text-center" style="font-size:0.8rem"> 
                                            <i class="far fa-calendar-plus fa-lg"></i>
                                            ${fecha}
                                        </span>
                                    </div>`;
                        }
                    },
                    { "data": "nombreNovedad" },
                    { "data": "descripcionNovedad" },
                    { "data": "fechaAprobacionNovedad" },
                    {
                        "data": "idSolicitudNovedad",
                        render: function (data, type, row)
                        {
                            var html = '';

                            html += '<div class="btn-group btn-group-sm" role="group">';
                            html += `<button type="button" class="btn btn-secondary btn-sm" onclick="ModalShow('${data}','${row.codigoTipoNovedad}')" title="Ver detalles" ><i class="fa fa-fw fa-eye"></i></button>
                                     <button type="button" class="btn btn-secondary btn-sm" onclick="" title="Imprimir Solicitud" ><i class="fas fa-print"></i></button>`;
                            html += '</div>';
                            return html;
                        }
                    },
                ],
                columnDefs: [
                    { "width": "10%", "targets": 0 },
                    { "width": "10%", "targets": 1 },
                    { "width": "20%", "targets": 2 },
                    { "width": "40%", "targets": 3 },
                    { "width": "10%", "targets": 4 },
                    { "width": "10%", "targets": 5 },
                ],
            });

        }
    });

    AdjustColumnsTableEC();
}

function GetInfoEmpleado(novedad)
{
    $.ajax({
        url: "/GestionHumana/GetInfoEmpleado",
        type: "GET",
        beforeSend: function () {
            LoaderScreenShow();
        },
        success: function (response)
        {
            if (response.result)
            {
                switch (novedad)
                {
                    case "0002": OpenEditEps(response.data); break;
                    case "0003": OpenEditTipoDoc(response.data); break;
                    case "0004": OpenEditFondoP(response.data); break;
                    case "0005": OpenEditFondoC(response.data); break;
                    case "0006": OpenEditSueldo(response.data); break;
                    case "0008": OpenEditCaja(response.data); break;
                    case "AUSP": OpenEditPermiso(response.data); break;
                    case "AUSV": OpenEditVacaciones(response.data); break;
                    default: ToastAlert.fire({ icon: 'error', title: "No se ha elegido una novedad valida" }); break;
                }
                
            } else
            {
                ToastAlert.fire({ icon: 'error', title: "Error" });
            }
        },
        complete: function ()
        {
            LoaderScreenHide();
        }
    });
}

function GetTiposPermisos()
{
    $.ajax({
        url: "/Profiler/GetTipoPermisos",
        type: "GET",
        success: function (response) {
            if (response.result)
            {
                $('#codigopermiso').empty();

                $('#codigopermiso').append($('<option>',
                {
                    value: "",
                    text: "Seleccione una opción"
                }));


                $.each(response.data, function (index, opcion)
                {
                    $('#codigopermiso').append($('<option>',
                    {
                        value: opcion.codigo,
                        text: opcion.nombre
                    }));
                });
            }
            else {
                ToastAlert.fire({ icon: 'error', title: "Error" });
            }
        },
    });
}

function OpenEditEps(data)
{
    console.log(data.epsEmpleado);
    $("#identificacioneps").val(data.cedulaEmpleado);
    $("#nomeempleadoeps").val(data.nombreEmpleado);
    $(`#epsactual option[value="${data.epsEmpleado}"]`).prop('selected', true);
    //$("#epsactual").val(data.epsEmpleado);
    modalEPS.show();
}

function OpenEditTipoDoc(data)
{
    $("#identificaciontipdoc").val(data.cedulaEmpleado);
    $("#nomeempleadotipdoc").val(data.nombreEmpleado);
    $("#tipdocactual").val(data.tipoDocEmpleado);
    modalTipoDocumento.show();
}

function OpenEditFondoP(data)
{
    $("#identificacionfp").val(data.cedulaEmpleado);
    $("#nomeempleadofp").val(data.nombreEmpleado);
    $("#fpactual").val(data.pensionEmpleado);
    modalFondoP.show();
}

function OpenEditFondoC(data) {
    $("#identificacionfc").val(data.cedulaEmpleado);
    $("#nomeempleadofc").val(data.nombreEmpleado);
    $("#fcactual").val(data.cesantiaEmpleado);
    modalFondoC.show();
}

function OpenEditSueldo(data) {
    $("#identificacionsueldo").val(data.cedulaEmpleado);
    $("#nomeempleadosueldo").val(data.nombreEmpleado);
    $("#sueldoactual").val(data.sueldoEmpleado);
    modalSueldo.show();
}

function OpenEditCaja(data) {
    $("#identificacioncaja").val(data.cedulaEmpleado);
    $("#nomeempleadocaja").val(data.nombreEmpleado);
    $("#cajaactual").val(data.cajaCompensacion);
    modalCajaCompensacion.show();
}

function OpenEditPermiso(data)
{
    var fechaActual = new Date().toISOString().split('T')[0];

    $("#finicialpermiso").val(fechaActual);
    $("#ffinalpermiso").val(fechaActual);

    GetTiposPermisos();
    $("#identificacionpermiso").val(data.cedulaEmpleado);
    $("#nomeempleadopermiso").val(data.nombreEmpleado);
    $("#observacionespermiso").val("");
    $("#hfinalpermiso").val("08:00");
    $("#hinicialpermiso").val("08:00");
    $("#regresa").val("");
    modalPermiso.show();
}

function OpenEditVacaciones(data)
{
    $("#identificacionvacaciones").val(data.cedulaEmpleado);
    $("#nomeempleadovacaciones").val(data.nombreEmpleado);

    $.ajax({
        url: "/GestionHumana/GetVacacionesEmpleado",
        type: "GET",
        beforeSend: function () {
            LoaderScreenShow();
        },
        success: function (response) {
            if (response.result)
            {
                vacacionesEmpleados =
                {
                    IdentificacionEmpleado: response.data.identificacionEmpleado,
                    TipoNomina: response.data.tipoNomina,
                    DiasHabiles: response.data.diasHabiles ,
                    Holidays: response.feriados
                };

                $("#diashabil").val(response.data.diasHabiles);
                $("#diastotal").val(0);
                $("#diaspagar").val(0);
                $("#diasdisfrute").val(0);
                $("#diascompensados").val(0);
                $("#fvacacionesf").val("");
                $("#fvacacionesi").val("");
                $("#observacionesvacaciones").val("");
                $("#fperiodoi").val(response.data.fechaInicialPeriodo.split('T')[0]);
                $("#fperiodof").val(response.data.fechaFinalPeriodo.split('T')[0]);
                $("#fvacacionesi").val(response.data.fechaInicialVacaciones.split('T')[0]);

                modalVacaciones.show();

                CalculateVacaciones(vacacionesEmpleados);

            } else {
                ToastAlert.fire({ icon: 'error', title: "Error" });
            }
        },
        complete: function () {
            LoaderScreenHide();
        }


    });
}

function SaveNovedad(novedad)
{
    let codEmpleado = "";
    let codNovedad = "";
    let valorAnt = "";
    let valorAntExt = "";
    let valorNue = "";
    let valorNueExt = "";
    let observacion = "";

    if (novedad == "0002")
    {
        codEmpleado = $("#identificacioneps").val();
        codNovedad = novedad;
        valorAnt = $("#epsactual option:selected").val();
        valorNue = $("#codigoeps").val();
        observacion = $("#observaciones").val();
    }
    if (novedad == "0003")
    {
        codEmpleado = $("#identificaciontipdoc").val();
        codNovedad = novedad;
        valorAnt = $("#tipdocactual").val();
        valorNue = $("#codigotipdoc").val();
        observacion = $("#observacionestipdoc").val();
    }
    if (novedad == "0004")
    {
        codEmpleado = $("#identificacionfp").val();
        codNovedad = novedad;
        valorAnt = $("#fpactual option:selected").val();
        valorNue = $("#codigofp").val();
        observacion = $("#observacionesfp").val();
    }
    if (novedad == "0005")
    {
        codEmpleado = $("#identificacionfc").val();
        codNovedad = novedad;
        valorAnt = $("#fcactual option:selected").val();
        valorNue = $("#codigofc").val();
        observacion = $("#observacionesfc").val();
    }

    if (novedad == "0006")
    {
        codEmpleado = $("#identificacionsueldo").val();
        codNovedad = novedad;
        valorAnt = $("#sueldoactual").val();
        valorNue = $("#sueldonuevo").val();
        observacion = $("#observacionessueldo").val();
    }

    if (novedad == "0008") {
        codEmpleado = $("#identificacioncaja").val();
        codNovedad = novedad;
        valorAnt =  $("#cajaactual option:selected").val();
        valorNue = $("#codigocaja").val(); 
        observacion = $("#observacionescaja").val();
    }

    var novedadEmpleadoModel =
    {
        TipoNovedad         : codNovedad,
        CodigoEmpleado      : codEmpleado,
        ValorAnterior       : valorAnt,
        ValorAnteriorExt    : valorAntExt,
        ValorNuevo          : valorNue,
        ValorNuevoExt       : valorNueExt,
        Descripcion         : observacion
    };

    $.ajax({
        url: "/GestionHumana/SaveSolicitudNovedadEmpleado",
        type: "POST",
        data: { novedadEmpleado: novedadEmpleadoModel },
        beforeSend: function ()
        {
            LoaderScreenShow();
            $('#btnSave').prop('disabled', true);
        },
        success: function (response)
        {
            if (response.result)
            {
                ToastAlert.fire({ icon: 'success', title: response.message });
            } else
            {
                ToastAlert.fire({ icon: 'error', title: "Error" });
            }
        },
        complete: function ()
        {
            switch (novedad)
            {
                case "0002": modalEPS.hide(); break;
                case "0003": modalTipoDocumento.hide(); break;
                case "0004": modalFondoP.hide(); break;
                case "0005": modalFondoC.hide(); break;
                case "0006": modalSueldo.hide(); break;
                case "0008": modalCajaCompensacion.hide(); break;
                default: ToastAlert.fire({ icon: 'error', title: "No se ha elegido una novedad valida" }); break;
            }
            LoaderScreenHide();
            LoadTableSolicitudes();
        }
    });
    
}

function SavePermiso()
{

    if (!ValidFormPermiso())
    {
        return;
    }

    let fNitEmpleado    = "";
    let fTipoPermiso    = "";
    let fFechaInicial   = "";
    let fFechaFinal     = "";
    let fHoraInicial    = "";
    let fHoraFinal      = "";
    let fReingresa      = false;
    let fObservaciones = "";

    fNitEmpleado = $("#identificacionpermiso").val();
    fTipoPermiso = $("#codigopermiso").val();
    fFechaInicial = $("#finicialpermiso").val();
    fFechaFinal = $("#ffinalpermiso").val();
    fHoraInicial = $("#hinicialpermiso").val();
    fHoraFinal = $("#hfinalpermiso").val();
    fObservaciones = $("#observacionespermiso").val();
    fReingresa = $("#regresa").is(":checked");


    var permisoEmpleadoModel =
    {
        IdentificacionEmpleado    : fNitEmpleado,
        CodigoEmpleado            : "",
        TipoPermiso               : fTipoPermiso  ,
        FechaInicial              : fFechaInicial ,
        FechaFinal                : fFechaFinal   ,
        HoraInicial               : fHoraInicial  ,
        HoraFinal                 : fHoraFinal    ,
        Reingresa                 : fReingresa    ,
        Observaciones             : fObservaciones,
    };

    $.ajax({
        url: "/GestionHumana/SaveSolicitudPermisoEmpleado",
        type: "POST",
        data: { permisoEmpleado: permisoEmpleadoModel },
        beforeSend: function () {
            LoaderScreenShow();
            $('#btn-save-permiso').prop('disabled', true);
        },
        success: function (response)
        {
            if (response.result) {
                ToastAlert.fire({ icon: 'success', title: response.message });
            } else {
                ToastAlert.fire({ icon: 'error', title: "Error" });
            }
        },
        complete: function ()
        {
            $('#btn-save-permiso').prop('disabled', false);
            modalPermiso.hide();
            LoaderScreenHide();
            LoadTableSolicitudes();
        }
    });
}


function SaveVacaciones()
{

    let fNitEmpleado = "";
    let fperiodoi = "";
    let fperiodof = "";
    let fvacacionesi = "";
    let fvacacionesf = "";
    let diashabil = "";
    let diascompensados = 0;
    let diasdisfrute = 0;
    let diastotal = 0;
    let diaspagar = 0;
    let fObservaciones = "";

    if (!ValidateVacaciones(vacacionesEmpleados))
    {
        return;
    }


    fNitEmpleado = $("#identificacionvacaciones").val();
    fperiodoi = $("#fperiodoi").val();
    fperiodof = $("#fperiodof").val();
    fvacacionesi = $("#fvacacionesi").val();
    fvacacionesf = $("#fvacacionesf").val();
    diashabil = parseInt($("#diashabil").val());
    diascompensados = parseInt($("#diascompensados").val());
    diasdisfrute = parseInt($("#diasdisfrute").val());
    diastotal = parseInt($("#diastotal").val());
    diaspagar = parseInt($("#diaspagar").val());
    fObservaciones = $("#observacionesvacaciones").val();

    var solicitudVacaciones =
    {
        IdentificacionEmpleado: fNitEmpleado,
        CodigoEmpleado : "",
        FechaPeriodoInicial: fperiodoi,
        FechaPeriodoFinal: fperiodof,
        FechaInicialVacaciones: fvacacionesi,
        FechaReintegro: fvacacionesf,
        DiasHabiles: diashabil,
        DiasCompensados: diascompensados,
        DiasDisfrute: diasdisfrute,
        DiasTotal: diastotal,
        DiasPagar: diaspagar,
        Observaciones: fObservaciones,
    };


    $.ajax({
        url: "/GestionHumana/SaveSolicitudVacacionesEmpleado",
        type: "POST",
        data: { solicitudVacaciones: solicitudVacaciones },
        beforeSend: function () {
            LoaderScreenShow();
            $('#btn-save-vacaciones').prop('disabled', true);
        },
        success: function (response) {
            if (response.result)
            {
                ToastAlert.fire({ icon: 'success', title: response.message });
            } else {
                ToastAlert.fire({ icon: 'error', title: "Error" });
            }
        },
        complete: function () {
            $('#btn-save-vacaciones').prop('disabled', false);
            modalVacaciones.hide();
            LoaderScreenHide();
            LoadTableSolicitudes();
        }
    });
}

function ModalShow(idNovedad, novedad)
{

    $.ajax({
        url: "/GestionHumana/GetSolicitudNovedadEmpleado",
        type: "GET",
        data: { idNovedad: idNovedad },
        beforeSend: function () {
            LoaderScreenShow();
            $('#btnSave').prop('disabled', true);
        },
        success: function (response)
        {
            if (response.result)
            {
                if (response.data.codigoTipoNovedad == "AUSV") {
                    $("#title-vacaciones").text("Solicitud de vacaciones #" + response.data.idSolicitudNovedad);
                    $("#sfperiodoi").val(response.data.fechaPeriodoI.split('T')[0]);
                    $("#sfperiodof").val(response.data.fechaPeriodoF.split('T')[0]);
                    $("#sfvacacionesi").val(response.data.fechaVacacionesI.split('T')[0]);
                    $("#sfvacacionesf").val(response.data.fechaVacacionesF.split('T')[0]);
                    $("#sdiashabil").val(response.data.diasHabiles);
                    $("#sdiascompensados").val(response.data.diasCompensados);
                    $("#sdiasdisfrute").val(response.data.diasDisfrute);
                    $("#sdiastotal").val(response.data.totalDias);
                    $("#sdiaspagar").val(response.data.diasPagar);
                    $("#sobservacionesvacaciones").val(response.data.descripcionNovedad);

                    modalVacacionesShow.show();

                } else if (response.data.codigoTipoNovedad == "AUSP")
                {
                    $("#title-permiso").text("Solicitud de Permiso #" + response.data.idSolicitudNovedad);
                   

                    $.ajax({
                        url: "/GestionHumana/GetSolicitudPermisoEmpleado",
                        type: "GET",
                        data: { idNovedad: idNovedad },
                        beforeSend: function () {
                            LoaderScreenShow();
                            $('#btnSave').prop('disabled', true);
                        },
                        success: function (response) {
                            if (response.result) {

                                $("#stipopermiso").val(response.data.tipoPermiso);
                                $("#sfinicialpermiso").val(response.data.fechaInicial);
                                $("#shinicialpermiso").val(response.data.horaInicial);
                                $("#sffinalpermiso").val(response.data.fechaFinal);
                                $("#shfinalpermiso").val(response.data.horaFinal);
                                $("#sobservacionespermiso").val(response.data.observaciones);

                                let regresaText = ((response.data.reingresa == true) ? "SI" : "NO");
                                $("#sregresa").val(regresaText)
                            }
                            else {
                                ToastAlert.fire({ icon: 'error', title: "Error" });
                            }
                        },
                        complete: function () {
                            LoaderScreenHide();
                        }
                    });


                    modalPermisoShow.show();
                } else
                {
                    $("#idsolicitud").val(response.data.idSolicitudNovedad);
                    $("#fechasolicitud").val(response.data.fechaNovedad);
                    $("#tiposolicitud").val(response.data.nombreNovedad);
                    $("#valorant").val(response.data.valorAnterior);
                    $("#valornuevo").val(response.data.valorNuevo);
                    $("#obs").val(response.data.descripcionNovedad);

                    modalShow.show();
                }

            }
            else
            {
                ToastAlert.fire({ icon: 'error', title: "Error" });
            }
        },
        complete: function () {
            LoaderScreenHide();
        }
    });
    
}

function ValidFormPermiso()
{
    let identificacion = $("#identificacionpermiso").val();
    let tipoPermiso = $("#codigopermiso").val();
    let fechaI = $("#finicialpermiso").val();
    let horaI = $("#hinicialpermiso").val();
    let fechaF = $("#ffinalpermiso").val();
    let horaF = $("#hfinalpermiso").val();
    let Observacion = $("#observacionespermiso").val();

    if (identificacion == "" || identificacion == null) return false;
    if (tipoPermiso == "" || tipoPermiso == null)
    {
        ToastAlert.fire({ icon: 'error', title: "¡La fecha Inicial no puede ser superior a la final!" });
        return false;
    }

    if (fechaI == "" || fechaI == null) return false;
    if (horaI == "" || horaI == null) return false;
    if (fechaF == "" || fechaF == null) return false;
    if (horaF == "" || horaF == null) return false;
    if (Observacion == "" || Observacion == null) return false;

    if (new Date(fechaI + "T00:00:00") > new Date(fechaF + "T00:00:00"))
    {
        ToastAlert.fire({ icon: 'error', title: "¡La fecha Inicial no puede ser superior a la final!" });
        return false;
    } 

    if (new Date("2000-01-01T" + horaI) > new Date("2000-01-01T" + horaF))
    {
        ToastAlert.fire({ icon: 'error', title: "¡La hora inicial no puede ser superior a la final!" });
        return false;
    } 

    if (new Date("2000-01-01T" + horaI) == new Date("2000-01-01T" + horaF))
    {
        ToastAlert.fire({ icon: 'error', title: "¡La hora inicial no puede ser igual a la final!" });
        return false;
    } 
    return true;
}

function ValidateVacaciones(vacaciones)
{
    let fechaInicialVacaciones = new Date($("#fvacacionesi").val() + "T00:00:00");

    if (fechaInicialVacaciones.getDay() === 0)
    {
        ToastAlert.fire({ icon: 'error', title: "¡La fecha de inicio de las vacaciones no es un día habil!" });
        return false;
    }

    for (var i = 0; i < vacaciones.Holidays.length; i++)
    {
        var fechaArray = new Date(vacaciones.Holidays[i]);

        if (fechaInicialVacaciones.getTime() === fechaArray.getTime())
        {
            break;
            ToastAlert.fire({ icon: 'error', title: "¡La fecha de inicio de las vacaciones no es un día habil!" });
            return false; 
        }
    }

    if (parseInt($("#diashabil").val()) == 0)
    {
        ToastAlert.fire({ icon: 'error', title: "¡Debe tener al menos un día habil!" });
        $("#diashabil").val(1);
        return false; 
    }

    let acumulado = parseInt($("#diashabil").val()) + parseInt($("#diascompensados").val());

    if (acumulado > vacaciones.DiasHabiles)
    {
        ToastAlert.fire({ icon: 'error', title: "¡El acumulado de los días es mayor a " + vacaciones.DiasHabiles + " días" });
        return false;
    }

    return true;
}

function CalculateVacaciones(vacaciones)
{

    if ($("#diashabil").val() == "" || $("#diashabil").val() == null)
    {
        return;
    }

    if ($("#diascompensados").val() == "" || $("#diascompensados").val() == null) {
        return;
    }

    let fechaInicialVacaciones = "";
    fechaInicialVacaciones = $("#fvacacionesi").val();

    if (fechaInicialVacaciones == "" || fechaInicialVacaciones == null) {
        return;
    }


    let diasHabiles = parseInt($("#diashabil").val());



    $.ajax({
        url: "/GestionHumana/GetDiasDisfrutados",
        type: "GET",
        data: { fechaInicio: fechaInicialVacaciones, tipoNomina: vacaciones.TipoNomina, dias: diasHabiles },
        beforeSend: function () {
            LoaderScreenShow();
            $('#btn-save-vacaciones').prop('disabled', true);
        },
        success: function (response)
        {
            if (response.result)
            {
                let diasCompensando = parseInt($("#diascompensados").val());

                $("#diasdisfrute").val(response.data.diasDisfrute);
                $("#diastotal").val(diasHabiles + diasCompensando + response.data.diasAdicionales);
                $("#diaspagar").val(diasHabiles + diasCompensando + response.data.diasAdicionales);
                $("#fvacacionesf").val(response.data.fechaReingreso.split('T')[0]);
            }
            else {
                ToastAlert.fire({ icon: 'error', title: "Error" });
            }
        },
        complete: function ()
        {
            LoaderScreenHide();
            $('#btn-save-vacaciones').prop('disabled', false);
        }
    });
}

function AdjustColumnsTableEC() {
    setTimeout(() => {
        $(".dataTables_scrollHeadInner").width("100%");

    }, 800)
}

function destruirDataTables() {
    var tabla = $('#table-pendientes').DataTable();
    var tabla2 = $('#table-aprobadas').DataTable();
    var tabla3 = $('#table-rechazadas').DataTable();
    if (tabla !== undefined) {
        tabla.destroy(); // Destruye la instancia existente de DataTables
    }

    if (tabla2 !== undefined) {
        tabla2.destroy(); // Destruye la instancia existente de DataTables
    }

    if (tabla3 !== undefined) {
        tabla3.destroy(); // Destruye la instancia existente de DataTables
    }
}

