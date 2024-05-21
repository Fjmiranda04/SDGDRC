const modalRazones = new bootstrap.Modal(document.getElementById("modal-razon"), {});

$(document).ready(function ()
{

    $("#btn-save-razon").click(function ()
    {
        if (ValidateForms("#form-reazon"))
        {
            let solicitud = $("#solicitud").val();
            let valor = $("#valor").val();
            let razones = $("#razones").val();
            let remunerado = $("#remunerado").prop('checked');

            SaveApproveReject(solicitud, valor, razones, remunerado);
          
        }
    });

    LoadTableSolicitudes();
});

function LoadTableSolicitudes() {
    $.ajax({
        url: "/GestionHumana/GetSolicitudesNovedad",
        type: 'GET',
        dataType: 'json',
        success: function (response) {

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
                        render: function (data, type, row) {
                            return `<span class="badge bg-info fw-bold" style="font-size:0.9rem"># ${data}</span>`;
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
                    {
                        "data": "nombreEmpleado",
                    },
                    { "data": "nombreNovedad" },
                    {
                        "data": "descripcionNovedad",
                        render: function (data, type, row) {
                            return `<span class="d-inline-block text-truncate fw-bold py-0 px-0 mx-0 my-0" style="font-size: 1rem;max-width: 320px;max-height:30px;">${data}</span>  `;
                        }
                    },
                    {
                        "data": "idSolicitudNovedad",
                        render: function (data, type, row)
                        {
                            var html = '';

                            html += '<div class="btn-group btn-group-sm" role="group">';
                            html += `<button type="button" class="btn btn-success btn-sm" onclick="Approve(${data},'${row.codigoTipoNovedad}')"><i class="fas fa-check-circle"></i> Aprobar</button>
                                        <button type="button" class="btn btn-danger btn-sm" onclick="Reject(${data},'${row.codigoTipoNovedad}')"><i class="fas fa-times-circle"></i> Rechazar</button>`;
                            html += '</div>';
                            return html;
                        }
                    },
                ],
                columnDefs: [
                    { "width": "10%", "targets": 0 },
                    { "width": "10%", "targets": 1 },
                    { "width": "20%", "targets": 2 },
                    { "width": "20%", "targets": 3 },
                    { "width": "25%", "targets": 4 },
                    { "width": "15%", "targets": 5 },
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
                            return `<span class="badge bg-info fw-bold" style="font-size:0.9rem"># ${data}</span>`;
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
                    {
                        "data": "nombreEmpleado",
                    },
                    { "data": "nombreNovedad" },
                    {
                        "data": "descripcionNovedad",
                        render: function (data, type, row) {
                            return `<span class="d-inline-block text-truncate fw-bold py-0 px-0 mx-0 my-0" style="font-size: 1rem;max-width: 320px;max-height:30px;">${data}</span>  `;
                        }
                    },
                    {
                        "data": "fechaAprobacionNovedad",
                        render: function (data, type, row)
                        {
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
                    {
                        "data": "idSolicitudNovedad",
                        render: function (data, type, row) {
                            return `<button type="button" class="btn btn-secondary btn-sm" onclick="ModalPregunta('${data}') title="Ver detalles" ><i class="fa fa-fw fa-eye"></i></button>`;
                        }
                    },
                ],
                columnDefs: [
                    { "width": "10%", "targets": 0 },
                    { "width": "10%", "targets": 1 },
                    { "width": "10%", "targets": 2 },
                    { "width": "20%", "targets": 3 },
                    { "width": "30%", "targets": 4 },
                    { "width": "10%", "targets": 5 },
                    { "width": "10%", "targets": 6 },
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
                            return `<span class="badge bg-info fw-bold" style="font-size:0.9rem"># ${data}</span>`;
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
                    {
                        "data": "nombreEmpleado",
                    },
                    { "data": "nombreNovedad" },
                    {
                        "data": "descripcionNovedad",
                        render: function (data, type, row) {
                            return `<span class="d-inline-block text-truncate fw-bold py-0 px-0 mx-0 my-0" style="font-size: 1rem;max-width: 320px;max-height:30px;">${data}</span>  `;
                        }
                    },
                    {
                        "data": "fechaAprobacionNovedad",
                        render: function (data, type, row)
                        {
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
                    {
                        "data": "idSolicitudNovedad",
                        render: function (data, type, row) {
                            return `<button type="button" class="btn btn-secondary btn-sm" onclick="ModalPregunta('${data}') title="Ver detalles" ><i class="fa fa-fw fa-eye"></i></button>`;
                        }
                    },
                ],
                columnDefs: [
                    { "width": "10%", "targets": 0 },
                    { "width": "10%", "targets": 1 },
                    { "width": "10%", "targets": 2 },
                    { "width": "20%", "targets": 3 },
                    { "width": "30%", "targets": 4 },
                    { "width": "10%", "targets": 5 },
                    { "width": "10%", "targets": 6 },
                ],
            });

        }
    });
}

function Approve(solicitud,tipo)
{
    $("#lbl-solicitud").text("");
    AcceptReject(1, solicitud,tipo);
}

function Reject(solicitud,tipo)
{
    $("#lbl-solicitud").text("");
    AcceptReject(2, solicitud, tipo);
}


function AcceptReject(estado,solicitud,tipo)
{

    let texto = (estado == 1) ? "aprobar" : "rechazar";

    Swal.fire({
        title: '¿Esta seguro de ' + texto + ' la solicitud #' + solicitud + '?',
        showCancelButton: true,
        icon: 'warning',
        confirmButtonText: 'Aceptar',
        confirmButtonColor: '#028824',
        cancelButtonText: 'Cancelar',
        cancelButtonColor: '#e6180d',

    }).then((result) =>
    {
        if (result.isConfirmed)
        {

            $("#solicitud").val(solicitud);
            $("#valor").val(estado);
            $('#remunerado').prop('checked', false);
            $('#razones').val("");

            if (estado == 1)
            {
                $("#lbl-solicitud").text("Observaciones");
                $("#lbl-title").text("Aprobar solicitud #" + solicitud);
            }
            else {
                $("#lbl-solicitud").text("Describa las razones");
                $("#lbl-title").text("Rechazar solicitud #" + solicitud);
            }

            if (tipo == "AUSP" && estado == 1)
            {
                $("#remunerado").show();
                $("#lblremunerado").show();
            } else
            {
                $("#remunerado").hide();
                $("#lblremunerado").hide();
            }

            modalRazones.show();
        }
    });
}

function SaveApproveReject(solicitud, valor, razones, remunerado)
{
    console.log(remunerado);

    $.ajax({
        url: "/GestionHumana/SaveApproveReject",
        type: "POST",
        data: { solicitud: solicitud, valor: valor, razones: razones, remunerado: remunerado },
        beforeSend: function ()
        {
            LoaderScreenShow();
        },
        success: function (response)
        {
            if (response.result)
            {
                modalRazones.hide();
                ToastAlert.fire({ icon: 'success', title: response.message });
                LoadTableSolicitudes();             
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