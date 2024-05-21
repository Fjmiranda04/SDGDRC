
$(document).ready(function () {
    // Obtener la fecha del primer día del mes actual
    var primerDiaMes = new Date();
    primerDiaMes.setDate(1);

    // Establecer la fecha de inicio como primer día del mes y la fecha de fin como la fecha actual
    $('#fechaI').val(formatDate(primerDiaMes));
    $('#fechaF').val(formatDate(new Date()));

    // Inicializar el selector de fechas
    $('#fechaI, #fechaF').datepicker({
        format: 'dd/mm/yyyy',
        autoclose: true,
        language: 'es'
    });

    // Cargar los pedidos al abrir la página
    cargarPedidos();

    // Asignar el evento de clic al botón de búsqueda
    $('#btnBuscar').on('click', function () {
        cargarPedidos();
    });
});

function cargarPedidos() {
    var fechaI = $('#fechaI').val();
    var fechaF = $('#fechaF').val();

    // Formatear las fechas antes de enviarlas al servidor
    fechaI = moment(fechaI, 'DD/MM/YYYY').format('YYYYMMDD');
    fechaF = moment(fechaF, 'DD/MM/YYYY').format('YYYYMMDD');

    $.ajax({
        url: '@Url.Action("GetPedidos", "Pedido")',
        type: 'GET',
        data: { FechaI: fechaI, FechaF: fechaF },
        success: function (data) {
            mostrarPedidos(data);
        },
        error: function (error) {
            Swal.fire({
                icon: 'error',
                title: 'Error al cargar los pedidos',
                text: 'Hubo un problema al cargar los pedidos. Por favor, intenta de nuevo más tarde.'
            });
        }
    });
}

function mostrarPedidos(datosPedidos) {
    // Limpiar la tabla antes de cargar nuevos datos
    $('#tablaPedidos').DataTable().clear().destroy();

    $('#tablaPedidos').DataTable({
        responsive: true,
        data: datosPedidos,
        columns: [
            { data: 'numeroPedido' },
            {
                data: 'fecha',
                render: function (data) {
                    return formatDate(new Date(data));
                }
            },
            {
                data: 'fechaRequerido',
                render: function (data) {
                    return formatDate(new Date(data));
                }
            },
            { data: 'cliente' },
            { data: 'direccion' },
            { data: 'estado' },
            {
                data: 'subTotal',
                render: function (data) {
                    return formatterPeso.format(data);
                }
            },
            {
                data: 'valorIva',
                render: function (data) {
                    return formatterPeso.format(data);
                }
            },
            {
                data: 'total',
                render: function (data) {
                    return formatterPeso.format(data);
                }
            },
            {
                // Columna para los detalles de cada pedido
                data: null,
                render: function (data, type, row) {
                    return '<button class="btn btn-primary btn-detalle">Detalles</button>';
                }
            }
        ]
    });

    // Agregar el evento de clic para mostrar los detalles del pedido
    $('#tablaPedidos').on('click', '.btn-detalle', function () {
        var data = $('#tablaPedidos').DataTable().row($(this).parents('tr')).data();
        // Llenar los campos de la ventana modal con los datos del pedido
        $('#detalleNumeroPedido').val(data.numeroPedido);
        $('#detalleCliente').val(data.cliente);
        $('#detalleDireccion').val(data.direccion);
        $('#detalleCiudad').val(data.ciudad);
        $('#estado').val(data.estado);
        $('#subTotal').val(formatterPeso.format(data.subTotal));
        $('#valorIva').val(formatterPeso.format(data.valorIva));
        $('#total').val(formatterPeso.format(data.total));
        $('#detalleDescripcion').val(data.descripcion);

        // Mostrar la ventana modal
        $('#modalDetallesPedido').modal('show');
    });
}


/*$(document).ready(function () {
    $('#fechaI').val("10/01/2023");
    $('#fechaF').val("10/02/2024");

    LoadTablePedidos();

    $("#btn-open-pedido").on('click', () => { OpenModal("modal-tracking-pedido"); });

    var tablePedidos;
    var fechaInicioFilter = moment().subtract(29, 'days');
    var fechaFinalFilter = moment();

    $('#fechaF').datepicker({
        autoclose: true,
        language: 'es',
        format: 'dd/mm/yyyy'
    });

    $('#fechaI').datepicker({
        autoclose: true,
        language: 'es',
        format: 'dd/mm/yyyy'
    });

    $('#fechaI').datepicker('setDate', new Date());

    $('#fechaF').datepicker('setDate', new Date());

    //EVENTOS

    $("#fechaI").keyup(function (event) {
        if (event.keyCode === 13) {
            $("#btnBuscar").click();
        }
    });
    $("#fechaF").keyup(function (event) {
        if (event.keyCode === 13) {
            $("#btnBuscar").click();
        }
    });

    $("#btnBuscar").click(function () {
        $('#table-pedidos').DataTable().ajax.reload();
    });

    $("#pedido-estado").on("change", function () {
        $("#table-pedidos").column($(this).data('index')).search(this.value).draw();
    });

    //JQUERY PARA FILTRAR EN LA TABLA DE FORMA GENERAL (TODAS LAS COLUMNAS)
    $("#Search").on("keyup", function () {
        $("#table-pedidos").search(this.value).draw();
    });

    const ShowMessage = function (message) {
        if (message != "" && message != null && message != undefined) {
            ToastAlert.fire({
                icon: 'success',
                title: message
            });
        }
    }
});

function LoadTablePedidos() {
    try {
        $.ajax({
            type: "GET",
            url: "/Pedido/GetPedidos",
            data: {
                FechaI: function () { return $('#fechaI').val() },
                FechaF: function () { return $('#fechaF').val() },
            },
            dataType: "json",
            success: function (response) {
                getPedidos(response);
            }
        });
    } catch (e) {
        console.log(e)
    }

}

function getPedidos(data) {
    tablePedidos = $("#table-pedidos").DataTable({
        responsive: true,
        scrollCollapse: true,
        destroy: true,
        paging: true,
        lengthMenu: [15, 25, 50, 100],
        language: {
            url: "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json",
        },
        data,
        "columns": [
            {
                "data": "numeroPedido",
                render: function (data, type, row) {

                    return `
                        
                        <div class="list-group list-group-flush bg-transparent">
                            <div class="list-group-item d-flex px-0 bg-transparent">
                                <div class="flex-fill">
                                    <div class="d-flex justify-content-center align-items-center">
                                        <div class="my-0 py-0">
                                            <span class="badge bg-info fw-bold" style="font-size:0.7rem"># ${data}</span>
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

                    return `
                        <div class="list-group list-group-flush bg-transparent">
                            <div class="list-group-item d-flex px-0 py-1 my-1 bg-transparent">
                                <div class="flex-fill">
                                    <span class="badge bg-success bg-opacity-20 text-success fw-bold" style="font-size:0.7rem"> 
                                        <i class="far fa-calendar-plus fa-lg"></i>
                                        ${formatDate(new Date(data))}
                                    </span>
                                </div>
                            </div>
                        </div>
                    `;
                }
            },
            {
                "data": "fechaRequerido",
                render: function (data, type, row) {

                    return `
                        <div class="list-group list-group-flush bg-transparent">
                            <div class="list-group-item d-flex px-0 py-1 my-1 bg-transparent">
                                <div class="flex-fill">
                                    <span class="badge bg-success bg-opacity-20 text-success fw-bold" style="font-size:0.7rem"> 
                                        <i class="far fa-calendar-plus fa-lg"></i>
                                        ${formatDate(new Date(data))}
                                    </span>
                                </div>
                            </div>
                        </div>
                    `;
                }
            },
            {
                "data": "cliente",
                render: function (data, type, row) {

                    return `
                        ${data}
                    `;
                }
            },
            {
                "data": "direccion",
                render: function (data, type, row) {

                    return `
                        ${data}
                    `;
                }
            },
            {
                "data": "estado",
                render: function (data, type, row) {

                    return `
                        ${data}
                    `;
                }
            },
            {
                "data": "subTotal",
                render: function (data, type, row) {

                    return `<b>${formatterPeso.format(data)}</b>`;
                }
            },
            {
                "data": "valorIva",
                render: function (data, type, row) {

                    return `<b>${formatterPeso.format(data)}</b>`;
                }
            },
            {
                "data": "total",
                render: function (data, type, row) {

                    return `<b>${formatterPeso.format(data)}</b>`;
                }
            },
            {
                data: "numeroPedido",
                render: function (data, type, row) {
                    return `<button type="button" data-bs-toggle="modal" data-bs-target="#modal-tracking-pedido" id="btn-open-pedido" class="input-group-text btn-secondary">
                                <i class="fas fa-eye"></i>
                            </button>`
                }
            }
        ]
    })
} */