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
