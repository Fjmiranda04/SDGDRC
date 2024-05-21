//VARIABLES
const modalArticulos = new bootstrap.Modal(document.getElementById("modal-articulos"), {});
const modalServicios = new bootstrap.Modal(document.getElementById("modal-servicios"), {});
const modalNota = new bootstrap.Modal(document.getElementById("modal-nota"), {});

let tablePedidos = $('#table-pedidos');
let tableArticulos = $('#table-articulos');
let tableServicios = $('#table-servicios');
let details = [];
let isIva = ($('#IvaIncluido').val() == "1") ? true : false;
let subTotal = 0.0;
let iva = 0.0;
let total = 0.0;

$(document).ready(function () {
    $("#btnArticulos").click(function (e) {
        modalArticulos.show();
    });

    $("#btnServicios").click(function (e) {
        modalServicios.show();
    });

    $("#btnNotas").click(function (e) {
        $("#nota-modal").val($("#detalle").val());
        modalNota.show();
    });

    $("#btnSave").click(function (e) {
        SavePedido();
    });

    $("#IvaIncluido").change(function (e) {
        isIva = ($("#IvaIncluido").val() == "1") ? true : false;
        SwitchIva();
    });

    $('#FechaRequerido').datepicker({
        autoclose: true,
        language: 'es',
        format: 'dd/mm/yyyy'
    });

    // LoadPedido();
    //LoadTablePedidos();

    tableArticulos = $('#table-articulos').DataTable({
        dom: "t<'d-none align-items-center'<'me-auto pb-2 mx-2'i><'mb-0 pb-2 mx-2'p>>",
        paging: false,
        ordering: false,
        destroy: true,
        responsive: true,
        autoWidth: true,
        scrollY: 400,
        serverSide: true,
        ajax: {
            url: "/Pedido/GetArticulos",
            type: "GET",
            "data": {
                codigoEscala: function () { return $('#CodigoEscala').val() },
            },
            contentType: "application/json",
            dataSrc: '',
        },
        columns: [
            { "data": "codigo" },
            { "data": "descripcion" },
            { "data": "referencia" },
            {
                "data": "iva",
                render: function (data, type, row) {
                    return `${data}%`;
                }
            },
            {
                "data": "precio",
                render: function (data, type, row) {
                    return `${formatterPeso.format(data)}`;
                }
            },
            {
                "data": "codigo",
                render: function (data, type, row) {
                    return `<button type="button" class="btn btn-primary btn-sm" onclick="AddArticulo('${data}')"><i class="fas fa-circle-plus"></i></button>`;
                }
            },
        ],

    });

    tableServicios = $('#table-servicios').DataTable({
        dom: "t<'d-none align-items-center'<'me-auto pb-2 mx-2'i><'mb-0 pb-2 mx-2'p>>",
        paging: false,
        ordering: false,
        destroy: true,
        responsive: true,
        scrollY: 400,
        autoWidth: true,
        ajax: {
            url: "/Pedido/GetServicios",
            type: "GET",
            "data": {
                codigoEscala: function () { return $('#CodigoEscala').val() },
            },
            contentType: "application/json",
            dataSrc: '',
        },
        columns: [
            { "data": "codigo" },
            { "data": "servicio" },
            { "data": "descripcion" },
            {
                "data": "iva",
                render: function (data, type, row) {
                    return `${data}%`;
                }
            },
            {
                "data": "precio",
                render: function (data, type, row) {
                    return `${formatterPeso.format(data)}`;
                }
            },
            {
                "data": "codigo",
                render: function (data, type, row) {
                    return `<button type="button" class="btn btn-primary btn-sm" onclick="AddServicio('${data}')"><i class="fas fa-circle-plus"></i></button>`;
                }
            },
        ]
    });

});

function LoadPedido() {
    tablePedidos = $('#table-pedidos').DataTable({
        dom: "t<'d-none align-items-center'<'me-auto pb-2 mx-2'i><'mb-0 pb-2 mx-2'p>>",
        paging: false,
        ordering: false,
        destroy: true,
        responsive: true,
        autoWidth: true,
        data: details,
        columns: [
            { "data": "tipoMov" },
            { "data": "codigo" },
            { "data": "detalle" },
            {
                "data": "cantidad",
                render: function (data, type, row) {
                    return `<input type="number" class="form-control form-control-sm amount" value="${data}" data-ref="${row.codigo}">`;
                }
            },
            { "data": "medida" },
            {
                "data": "vlrUni",
                render: function (data, type, row) {
                    return `${formatterPeso.format(data)}`;
                }
            },
            {
                "data": "subtotal",
                render: function (data, type, row) {
                    return `${formatterPeso.format(data)}`;
                }
            },
            {
                "data": "valorIva",
                render: function (data, type, row) {
                    return `${formatterPeso.format(data)}`;
                }
            },
            {
                "data": "codigo",
                render: function (data, type, row) {
                    return `<button type="button" class="btn btn-danger btn-sm" onclick="RemoveItem('${data}')"><i class="fas fa-trash"></i></button>`;
                }
            }
        ]
    });

    $("input[type='number']").on('keyup change paste', function (e) {
        Recalculate($(this).attr("data-ref"), $(this).val());
    });
}

function AddArticulo(arcod) {
    if (details.filter(a => a.codigo == arcod).length > 0) {
        ToastAlert.fire({ icon: 'warning', title: "¡Este producto ya se agregó al pedido!" });
    }
    else {
        let dataArticulos = tableArticulos.rows().data();
        let articulo;

        dataArticulos.each(function (value, index) {
            if (value.codigo === arcod) {
                articulo = value;
                return false;
            }
        });

        var newArticulo = {
            codigo: articulo.codigo,
            cantidad: 1,
            detalle: articulo.descripcion,
            medida: articulo.medida,
            vlrUni: articulo.precio,
            tipoMov: "INV",
            tecnico: "",
            iva: articulo.iva,
            costo: (articulo.costo == "" || articulo.costo == null) ? "0" : articulo.costo,
            dependencia: "",
            escala: articulo.escala,
            porDescuento: 0,
            tercero: 0,
            valorIva: (isIva) ? ((articulo.precio) * (articulo.iva / (articulo.iva + 100))) : (articulo.iva * (articulo.precio / 100)),
            subtotal: (isIva) ? (articulo.precio - (articulo.precio) * (articulo.iva / (articulo.iva + 100))) : (articulo.precio),
            cco: "",
            NumDoc: "",
            tipodoc_ped: "COT"
        };

        details.push(newArticulo);
        LoadPedido();
        CalculateTotals();
        $(".dataTables_scrollHeadInner").width("100%");
    }
}

function AddServicio(sercod) {
    if (details.filter(a => a.codigo == sercod).length > 0) {
        ToastAlert.fire({ icon: 'warning', title: "¡Este servicio ya se agregó al pedido!" });
    }
    else {
        let dataServicios = tableServicios.rows().data();
        let servicio;

        dataServicios.each(function (value, index) {
            if (value.codigo === sercod) {
                servicio = value;
                return false;
            }
        });

        var newServicio = {
            codigo: servicio.codigo,
            cantidad: 1,
            detalle: servicio.servicio,
            medida: servicio.medida,
            vlrUni: servicio.precio,
            tipoMov: "SER",
            tecnico: "",
            iva: servicio.iva,
            costo: (servicio.costo == "" || servicio.costo == null) ? "0" : servicio,
            dependencia: "",
            escala: servicio.escala,
            porDescuento: 0,
            tercero: 0,
            valorIva: (isIva) ? ((servicio.precio) * (servicio.iva / (servicio.iva + 100))) : (servicio.iva * (servicio.precio / 100)),
            subtotal: (isIva) ? (servicio.precio - (servicio.precio) * (servicio.iva / (servicio.iva + 100))) : (servicio.precio),
            cco: "",
            NumDoc: "",
            tipodoc_ped: "COT"
        };

        details.push(newServicio);
        LoadPedido();
        CalculateTotals();
        $(".dataTables_scrollHeadInner").width("100%");
    }
}

function SwitchIva() {
    for (let i in details) {
        if (isIva) {
            details[i].valorIva = parseFloat((details[i].cantidad * details[i].vlrUni) * (details[i].iva / (details[i].iva + 100))).toFixed(2);
            details[i].subtotal = parseFloat((details[i].cantidad * details[i].vlrUni) - ((details[i].cantidad * details[i].vlrUni) * (details[i].iva / (details[i].iva + 100)))).toFixed(2);
        }

        if (!isIva) {
            console.log("Solo cuando no esta el iva Incluido");
            details[i].valorIva = parseFloat((details[i].cantidad * details[i].vlrUni) * (details[i].iva / 100)).toFixed(2);
            details[i].subtotal = parseFloat((details[i].cantidad * details[i].vlrUni)).toFixed(2);
        }
    }
    LoadPedido();
    CalculateTotals();
}

function Recalculate(codigoItem, newCantidad) {
    newCantidad = parseInt(newCantidad);
    for (let i in details) {
        if (details[i].codigo == codigoItem) {
            details[i].cantidad = newCantidad;

            if (isIva) {
                details[i].valorIva = parseFloat((newCantidad * details[i].vlrUni) * details[i].iva / (details[i].iva + 100)).toFixed(2);
                details[i].subtotal = parseFloat((newCantidad * details[i].vlrUni) - details[i].valorIva).toFixed(2);
            }

            if (!isIva) {
                details[i].valorIva = parseFloat((newCantidad * details[i].vlrUni) * (details[i].iva / 100)).toFixed(2);
                details[i].subtotal = parseFloat(newCantidad * details[i].vlrUni);
            }
            break;
        }
    }
    LoadPedido();
    CalculateTotals();
}

function CalculateTotals() {

    subTotal = 0;
    iva = 0;
    total = 0;

    for (let i in details) {
        subTotal += parseFloat(details[i].subtotal);
        iva += parseFloat(details[i].valorIva);
    }
    total += parseFloat(subTotal + iva);

    $("#sub-total").text(" " + formatterPeso.format(subTotal));
    $("#subtotal").val(subTotal);
    $("#iva").text(" " + formatterPeso.format(iva));
    $("#impuesto").val(iva);
    $("#total").text(" " + formatterPeso.format(total));
    $("#total").val(total);
}

function SavePedido() {
    if (details.length <= 0) {
        ToastAlert.fire({ icon: 'warning', title: "No hay articulos o servicios en el pedido!" });
        return true;
    }

    console.log($("#subtotal").val());
    var DetallePedido = details;
    var PedidoCreateDTO = {
        consecutivo: "",
        fecha: Date.now(),
        fechaRequerido: $("#FechaRequerido").val(),
        nombreCliente: $("#NombreCliente").val(),
        nitCliente: $("#NitCliente").val(),
        codigoCliente: $("#CodigoCliente").val(),
        codigoEscala: $("#CodigoEscala").val(),
        codigoVendedor: $("#CodigoVendedor").val(),
        tipoCliente: $("#TipoCliente").val(),
        telefono: $("#Telefono").val(),
        direccion: $("#Direccion").val(),
        codigoPostal: $("#CodigoPostal").val(),
        codigoCiudad: $("#CodigoCiudad").val(),
        codigoSucursal: $('#CodigoSucursal option:selected').val(),
        detalle: $("#detalle").val(),
        subTotal: subTotal,
        valorIva: iva,
        total: total,
        IvaIncluido: (isIva) ? 1 : 0,
        detalles: DetallePedido,
    }

    $.ajax({
        url: "/Pedido/Create",
        type: "POST",
        data: { pedido: PedidoCreateDTO },
        beforeSend: function () {
            LoaderScreenShow();
            $('#btnSave').prop('disabled', true);
        },
        success: function (response) {
            if (response.result) {
                window.location.href = response.redirect;
            } else {
                ToastAlert.fire({ icon: 'error', title: "Error" });
            }
        }
    });
}


function SaveNota() {
    $("#detalle").val($("#nota-modal").val());
    modalNota.hide();
}

function RemoveItem(itemcod) {
    details = details.filter(item => item.codigo != itemcod);
    LoadPedido();
    CalculateTotals();
}

function LoadTablePedidos() {
    $.ajax({
        url: "/Pedido/Create",
        type: 'GET',
        dataType: "json",
        success: function (response) {
            console.log(response);
        }
    })
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
        columns: [
            {

            }
        ]
    })
}