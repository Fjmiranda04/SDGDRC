$(document).ready(function () {

    let currentDate = new Date();
    let firstDate = new Date(currentDate.getFullYear(), currentDate.getMonth(), 1);

    $("#dateini").val(formatDate2(firstDate));
    $("#datefin").val(formatDate2(currentDate));
    $('#ex-etiquetas').picker();

    $("#ex-multiselect").on('sp-change', function () {
        var etiquetas = "";
        $('.pc-element').each(function () {
            if ($(this).attr('data-id') != undefined) {
                if (etiquetas == "") {
                    etiquetas = $(this).attr('data-id');
                } else {
                    etiquetas = etiquetas + "," + $(this).attr('data-id');
                }
            }
        });
    });

    $("#EstadoPqrsf").val("cer");

    $("#btn-filter").click(function () {
        LoadTableSolicitudes();
    });

    LoadTableSolicitudes();

});

function LoadTableSolicitudes()
{

    var filterModel =
    {
        FechaCreacionIni: $("#dateini").val(),
        FechaCreacionFin: $("#datefin").val(),
        Agente: $("#AgentePqrsf").val(),
        Area: $("#AreaPqrsf").val(),
        Tipo: $("#TipoPqrsf").val(),
        Estado: $("#EstadoPqrsf").val(),
        Prioridad: $("#PrioridadPqrsf").val(),
        Cliente: $("#ClientePqrsf").val(),
        Search: $("#Search").val(),
    };

    $.ajax({
        url: "/PQRSF/GetPqrsf",
        type: 'POST',
        dataType: "json",
        data: { filter: filterModel },
        success: function (response)
        {

            tablepqrsf = $('#list-pqrsf').DataTable({
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
                        "data": "nombreCliente",
                        render: function (data, type, row) {
                            return `
                                   <div class="list-group list-group-flush bg-transparent" onclick="Redirect('${row.codigo}')">
                                        <div class="list-group-item d-flex px-0 py-1 my-1 bg-transparent">
                                            <div class="m-0 p-0">
                                                <div class="w-30px h-30px d-flex align-items-center justify-content-center bg-secondary text-white rounded-circle ms-n1">
                                                    <i class="fa-solid fa-user"></i>
                                                </div>
                                            </div>

                                            <div class="flex-fill">
                                                <div class="py-0 px-2 mx-0 my-0">
                                                    <p class="text-truncate fw-bold py-0 px-0 mx-0 my-0" style="font-size: 0.75rem;">${data}</p>
                                                </div>
                                                <div class="py-0 px-2 mx-0 my-0">
                                                    <p class="fw-light py-0 px-0 mx-0 my-0" style="font-size: 0.75rem;">${row.emailCliente}</p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                            `;
                        }
                    },
                    {
                        "data": "tipoSituacion",
                        render: function (data, type, row)
                        {
                            let color = ["teal", "indigo", "purple", "yellow", "info"];
                            let index = (data == "PETICIÓN") ? 0 : (data == "QUEJA") ? 1 : (data == "RECLAMO") ? 2 : (data == "SUGERENCIA") ? 3 : 4;

                            let html = `
                                <div class="list-group list-group-flush bg-transparent" onclick="Redirect('${row.codigo}')">                                    
                                    <div class="row">
                                        <div class="col-md-12">
                                            <span class="badge bg-${color[index]} bg-opacity-20 text-${color[index]} fw-bold" style="font-size:0.75rem">${data}</span>     
                                        </div>
                                        <div class="col-md-12">
                                            <span class="d-inline-block text-truncate fw-bold py-0 px-0 mx-0 my-0" style="font-size: 1rem;max-width: 260px;max-height:30px;">${row.asunto}</span>                                      
                                        </div>                                   
                                    </div>                                                                                                    
                                </div>
                            `;

                            return html;
                        }
                    },
                    {
                        "data": "fecha",
                        render: function (data, type, row)
                        {
                            let html = `
                                <div class="list-group list-group-flush bg-transparent" onclick="Redirect('${row.codigo}')">
                                    <div class="list-group-item d-flex px-0  bg-transparent">
                                        <div class="flex-fill">
                                            <span class="badge bg-success bg-opacity-20 text-success fw-bold" style="font-size:0.9rem"> 
                                                <i class="far fa-calendar-plus fa-lg"></i>
                                               ${formatFecha3(new Date(data)) }
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            `;

                            return html;
                        }
                    },
                    {
                        "data": "estado",
                        render: function (data, type, row)
                        {

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
                        "data": "tipoPrioridad",
                        render: function (data, type, row) {

                            let color = ["success", "yellow", "orange", "danger", "dark"];
                            let index = (data == "Baja") ? 0 : (data == "Media") ? 1 : (data == "Alta") ? 2 : (data == "Urgente") ? 3 : 4;

                            let html = `
                                <div class="list-group list-group-flush bg-transparent" onclick="Redirect('${row.codigo}')">
                                    <div class="list-group-item d-flex px-0 bg-transparent">
                                        <div class="flex-fill">
                                               <span class="badge bg-${color[index]} bg-opacity-20 text-${color[index]} rounded" style="font-size:0.9rem"><i class="fa fa-circle fs-9px fa-fw me-5px"></i>${data}</span>
                                        </div>
                                    </div>
                                </div>
                                `;

                            return html;
                        }
                    },
                    {
                        "data": "agenteResponsable",
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
                ],
                columnDefs: [
                    { "width": "7%", "targets": 0 },
                    { "width": "20%", "targets": 1 },
                    { "width": "25%", "targets": 2 },
                    { "width": "10%", "targets": 3 },
                    { "width": "10%", "targets": 4 },
                    { "width": "10%", "targets": 5 },
                    { "width": "18%", "targets": 5 },
                ],          
            });

            let abiertas = 0;
            let pendientes = 0;
            let gestion = 0;
            let resueltas = 0;
            let total = 0;

            abiertas = response.data.filter(x => x.estado == "Abierta").length;
            pendientes = response.data.filter(x => x.estado == "Pendiente").length;
            gestion = response.data.filter(x => x.estado == "En Gestión").length;
            resueltas = response.data.filter(x => x.estado == "Cerrada").length;
            total = response.data.length;
            $("#sabiertas").text(`${abiertas} Abiertas`);
            $("#spendientes").text(`${pendientes} Pendientes`);
            $("#sgestion").text(`${gestion} En Gestión`);
            $("#sresueltas").text(`${resueltas} Resueltas`);
            $("#stotal").text(`${total} Total`);

        }
    });

    AdjustColumnsTableEC();
}

function AdjustColumnsTableEC() {
    setTimeout(() => {
        $(".dataTables_scrollHeadInner").width("100%");

    }, 800)
}

function Redirect(id){
    window.location.href='/PQRSF/Profiler' +  '/'+id;
}