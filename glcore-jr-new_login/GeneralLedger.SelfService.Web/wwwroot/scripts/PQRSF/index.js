var tablePQRSF;
var modal = new bootstrap.Modal(document.getElementById("modal-reabrir-pqrsf"), {});

const urlClosePQRSF = "/PQRSF/ClosePQRSFCliente";
const urlOpenPQRSF = "/PQRSF/OpenPQRSFCliente";

var fechaInicioFilter = moment().subtract(29, 'days');
var fechaFinalFilter = moment();

$(document).ready(function () {
    let currentDate = new Date();
    let firstDate = new Date(currentDate.getFullYear(), currentDate.getMonth(), 1);

    $("#dateini").val(formatDate2(firstDate));
    $("#datefin").val(formatDate2(currentDate));

    //JQUERY PARA FILTRAR EN LA TABLA POR CAMPO DE ESTADO 
    $("#EstadoPqrsf").on("change", function () {
        LoadTablePQRSF();
    });

    //JQUERY PARA FILTRAR EN LA TABLA POR CAMPO DE TIPO DE RESEÑA 
    $("#TipoPqrsf").on("change", function () {
        LoadTablePQRSF();
    });

    $("#dateini").on("change", function () {
        LoadTablePQRSF();
    });

    $("#datefin").on("change", function () {
        LoadTablePQRSF();
    });

    //JQUERY PARA FILTRAR EN LA TABLA DE FORMA GENERAL (TODAS LAS COLUMNAS)
    $("#Search").on("keyup", function () {
        LoadTablePQRSF();
    });

    //JQUERY PARA FILTRAR POR FECHA
    $('#daterange').daterangepicker({
        opens: 'right',
        format: 'MM/DD/YYYY',
        separator: ' a ',
        ranges: {
            'Hoy': [moment(), moment()],
            'Ayer': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
            'Últimos 7 días': [moment().subtract(6, 'days'), moment()],
            'Últimos 30 días': [moment().subtract(29, 'days'), moment()],
            'Este mes': [moment().startOf('month'), moment().endOf('month')],
            'Mes pasado': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
        },
        applyLabel: 'Aplicar',
        cancelLabel: 'Cancelar',
        fromLabel: 'Desde',
        toLabel: 'Hasta',
        customRangeLabel: 'Personalizado',
        weekLabel: 'S',
        daysOfWeek: ['Dom', 'Lun', 'Mar', 'Mié', 'Jue', 'Vie', 'Sáb'],
        monthNames: [
            'Enero',
            'Febrero',
            'Marzo',
            'Abril',
            'Mayo',
            'Junio',
            'Julio',
            'Agosto',
            'Septiembre',
            'Octubre',
            'Noviembre',
            'Diciembre'
        ],
        locale: { cancelLabel: 'Clear' },
        startDate: moment().subtract(29, 'days'),
        endDate: moment(),
    }, function (start, end) {
        $('#daterange input').val(start.format('DD/MM/YYYY') + ' - ' + end.format('DD/MM/YYYY'));
        fechaInicioFilter = start.format('MM/DD/YYYY');
        fechaFinalFilter = end.format('MM/DD/YYYY');

        tablePQRSF.draw();
    });


    LoadTablePQRSF();
});




//$.fn.dataTable.ext.search.push(
//    function(settings, data, dataIndex) 
//    {
//        var min = new Date(fechaInicioFilter);
//        var max = new Date(fechaFinalFilter);
//        var fecha = data[3].split("/");
//        var startDate = new Date(`${fecha[1]}/${fecha[0]}/${fecha[2]}`);

//        if (min == null && max == null) { return true; }
//        if (min == null && startDate <= max) { return true; }
//        if (max == null && startDate >= min) { return true; }
//        if (startDate <= max && startDate >= min) { return true; }
//        return false;
//    }
//);

const LoadTablePQRSF = function () {

    var filterModel =
    {
        FechaCreacionIni: $("#dateini").val(),
        FechaCreacionFin: $("#datefin").val(),
        Agente: "NA",
        Area: "NA",
        Tipo: $("#TipoPqrsf").val(),
        Estado: $("#EstadoPqrsf").val(),
        Prioridad: "NA",
        Cliente: "NA",
        Search: $("#Search").val(),
    };

    $.ajax({
        url: "/PQRSF/GetPqrsfByUser",
        type: 'POST',
        dataType: "json",
        data: { filter: filterModel },
        success: function (response) {
            console.log(response);
            tablepqrsf = $('#pqrflist').DataTable({
                dom: "t<'d-flex align-items-center'<'me-auto pb-2 mx-2'i><'mb-0 pb-2 mx-2'p>>",
                responsive: true,
                scrollCollapse: true,
                destroy: true,
                paging: true,
                lengthMenu: [15, 25, 50, 100],
                language: {
                    url: "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json",
                },
                data: response.data,
                columns: [
                    {
                        "data": "codigo",
                        render: function (data, type, row) {
                            return `
                                <div class="list-group list-group-flush bg-transparent" onclick="Redirect('${data}')">
                                    <div class="list-group-item d-flex px-0 bg-transparent">
                                        <div class="flex-fill">
                                            <div class="d-flex justify-content-center align-items-center">
                                                <div class="my-0 py-0">
                                                    <span class="badge bg-info fw-bold" style="font-size:1rem"># ${data}</span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            `;
                        }
                    },
                    {
                        "data": "fecha",
                        render: function (data, type, row) {
                            let html = `
                                <div class="list-group list-group-flush bg-transparent" onclick="Redirect('${row.codigo}')">
                                    <div class="list-group-item d-flex px-0  bg-transparent">
                                        <div class="flex-fill">
                                            <span class="badge bg-success bg-opacity-20 text-success fw-bold" style="font-size:0.9rem"> 
                                                <i class="far fa-calendar-plus fa-lg"></i>
                                               ${formatFecha3(new Date(data))}
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            `;

                            return html;
                        }
                    },
                    {
                        "data": "asunto",
                        render: function (data, type, row) {
                            let html = `
                                <div class="list-group list-group-flush bg-transparent" >                                    
                                    <div class="row">
                                        <div class="col-md-12">
                                            <span class="d-inline-block text-truncate fw-bold py-0 px-0 mx-0 my-0" style="font-size: 1rem;max-width: 350px;max-height:30px;">${data}</span>                                      
                                        </div>                                   
                                    </div>                                                                                                    
                                </div>
                            `;

                            return html;
                        }
                    },
                    {
                        "data": "tipoSituacion",
                        render: function (data, type, row) {
                            let color = ["teal", "indigo", "purple", "yellow", "info"];
                            let index = (data == "PETICIÓN") ? 0 : (data == "QUEJA") ? 1 : (data == "RECLAMO") ? 2 : (data == "SUGERENCIA") ? 3 : 4;

                            let html = `
                                <div class="list-group list-group-flush bg-transparent" onclick="Redirect('${row.codigo}')">                                    
                                    <div class="row">
                                        <div class="col-md-12">
                                            <span class="badge bg-${color[index]} bg-opacity-20 text-${color[index]} fw-bold" style="font-size:0.75rem">${data}</span>     
                                        </div>                                  
                                    </div>                                                                                                    
                                </div>
                            `;

                            return html;
                        }
                    },

                    {
                        "data": "estado",
                        render: function (data, type, row) {

                            let color = ["success", "dark", "warning", "warning", "primary"];
                            let index = (data == "Abierta") ? 0 : (data == "Cerrada") ? 1 : (data == "Pendiente") ? 2 : (data == "En Gestión") ? 3 : 4;

                            let html = `
                                <div class="list-group list-group-flush bg-transparent" onclick="Redirect('${row.codigo}')">
                                    <div class="list-group-item d-flex px-0 bg-transparent">
                                        <div class="flex-fill">
                                              <span class="badge bg-${color[index]} bg-opacity-20 text-${color[index]}" style="font-size:0.9rem"><i class="fas fa-heartbeat fa-lg"></i> ${data}</span>
                                        </div>
                                    </div>
                                </div>
                            `;

                            return html;
                        }
                    },
                    {
                        "data": "contacto",
                        render: function (data, type, row) {

                            let html = `
                                <div class="list-group list-group-flush bg-transparent" onclick="Redirect('${row.codigo}')">
                                    <div class="list-group-item d-flex align-items-center justify-content-center px-0 py-1 my-1 bg-transparent">
                                        <div class="flex-fill">
                                            <p class="fw-bold py-0 px-0 mx-0 my-0" style="font-size: 0.9rem;">${data}</p>
                                        </div>
                                    </div>
                                </div>
                                `;

                            return html;
                        }
                    },
                    {
                        "data": "codigo",
                        render: function (data, type, row) {

                            let html = `
                                 <div class="btn-group btn-group-sm">
                                    <a class="btn btn-light" href="/PQRSF/Details/${row.codigo}"><i class="fa fa-fw fa-eye"></i></a>`;

                            if (row.estado != "Cerrada") {
                                html = html + `<button class="btn btn-light" onclick="ClosePQRSF('${row.codigo}')"><i class="fas fa-lock-open"></i></button>`;
                            }
                            else {
                                html = html + `<button class="btn btn-light" onclick="OpenModal('${row.codigo}')"><i class="fas fa-lock"></i></button>`;
                            }
                            html = html + `<a class="btn btn-light" href="/PQRSF/ReportPQRSFPDF/${row.codigo}"><i class="far fa-file-pdf"></i></a>
                                        <a class="btn btn-light" href="/PQRSF/ReportPQRSFExcel/${row.codigo}"><i class="far fa-file-excel"></i></a>
                                </div>`;

                            return html;
                        }
                    },
                ],
                columnDefs: [
                    { "width": "10%", "targets": 0 },
                    { "width": "10%", "targets": 1 },
                    { "width": "30%", "targets": 2 },
                    { "width": "10%", "targets": 3 },
                    { "width": "10%", "targets": 4 },
                    { "width": "10%", "targets": 5 },
                    { "width": "20%", "targets": 6 },
                ],
            });
        }
    });

    AdjustColumnsTableEC();
}

const ShowMessage = function (message) {
    if (message != "" && message != null && message != undefined) {
        ToastAlert.fire({
            icon: 'success',
            title: message
        });
    }
}

const OpenModal = function (idPQRSF) {
    $("#IdPQRSF").val(idPQRSF);
    $("#Nota").val();
    modal.show();
}

const ClosePQRSF = function (idPQRSF) {
    Swal.fire({
        title: '¿Esta seguro de cerrar esta PQRSF?',
        showCancelButton: true,
        icon: 'warning',
        confirmButtonText: 'Aceptar',
        confirmButtonColor: '#028824',
        cancelButtonText: 'Cancelar',
        cancelButtonColor: '#e6180d',

    }).then((result) => {
        if (result.isConfirmed) {

            $.ajax({
                url: urlClosePQRSF,
                type: "POST",
                data: { id: idPQRSF },
                beforeSend: function () {
                    $("#btn-new-pqrsf").prop("disabled", true);
                },
                success: function (response) {
                    if (response.result) {
                        window.location.href = response.redirect;
                    } else {
                        ToastAlert.fire({ icon: 'error', title: response.message }); ToastAlert.fire({ icon: 'error', title: response.message });
                    }
                },
            });
        }
    });
}

const OpenPQRSF = function () {
    Swal.fire({
        title: '¿Esta seguro de abrir esta PQRSF?',
        showCancelButton: true,
        icon: 'warning',
        confirmButtonText: 'Aceptar',
        confirmButtonColor: '#028824',
        cancelButtonText: 'Cancelar',
        cancelButtonColor: '#e6180d',

    }).then((result) => {
        if (result.isConfirmed) {
            let form = $('#form-close-pqrsf');

            $.ajax({
                url: urlOpenPQRSF,
                type: "POST",
                data: form.serialize(),
                beforeSend: function () {
                    $("#btn-new-pqrsf").prop("disabled", true);
                },
                success: function (response) {
                    if (response.result) {
                        window.location.href = response.redirect;
                    }
                    else {
                        ToastAlert.fire({ icon: 'error', title: response.message });
                    }
                },
            });
        }
    });
}

function AdjustColumnsTableEC() {
    setTimeout(() => {
        $(".dataTables_scrollHeadInner").width("100%");

    }, 800)
}


