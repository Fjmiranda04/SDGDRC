var detallePedidoModel = [];


var pedidoModel =
{
    consecutivo: "",
    fecha: Date.now(),
    fechaRequerido: Date.now(),
    nombreCliente: "",
    nitCliente:"",
    codigoCliente: "",
    codigoEscala: "",
    codigoVendedor: "",
    tipoCliente: "",
    telefono: "",
    direccion: "",
    codigoPostal: "",
    codigoCiudad: "",
    codigoSucursal: "",
    detalle: "",
    subTotal: 0,
    valorIva: 0,
    total: 0,
    IvaIncluido: 0,
    detalles: detallePedidoModel,
}
 
$(document).ready(function ()
{
    $.ajax({
        url: "/Pedido/GetArticulos",
        dataType: "json",
        success: function (data) {
            showArticulos(data);
        }
    });

    $.ajax({
        url: "/Pedido/GetServicios",
        dataType: "json",
        success: function (data) {
            showServicios(data);
        }
    });


    $(".btn-action-art").click(function ()
    {
        var articulo = $(this).data('item');

        console.log(articulo);
    });

    $(".btn-action-ser").click(function ()
    {
        var servicio = $(this).data('item');
        console.log(servicio);
    });

});


function showArticulos(list) {
    var listContainer = document.querySelector('#articulosLayout');

    $.each(list, function (index, item) {
        var article = document.createElement('article');
        article.className = 'col-md-4 mb-3 p-0 flex';
        article.innerHTML = `
        <div class="card item-card mx-2 position-relative d-flex flex-column overflow-hidden h-100">
            <div class="d-flex flex-column flex-grow-1 p-3 text-black">
                <span class="font-weight-bold h6 text-truncate">${item.descripcion}</span>
                <div class="d-flex gap-2 mt-1">
                    <span class="m-0 fw-bold">Medida:</span>
                    <span class="text-gray-700 m-0">${item.medida}</span>
                </div>
                <div class="d-flex gap-2">
                    <span class="text-bold-600 m-0" style="font-size: 1.09375rem;">${formatterPeso.format(item.costo) }</span>
                </div>
                <div class="d-flex justify-content-end mt-auto">
                <button  type="button" class="btn btn-sm btn-success btn-action-art" data-item="${item}">
                    <i class="fa fa-plus"></i>
                    <span>Agregar</span>
                </button>
                </div>
            </div>
        </div>
    `;
        listContainer.appendChild(article);
    });
}

function showServicios(list) {
    var articulosContainer = document.querySelector('#serviciosLayout');

    $.each(list, function (index, item) {
        var article = document.createElement('article');
        article.className = 'col-md-4 mb-3 p-0 flex';
        article.innerHTML = `
        <div class="card item-card mx-2 position-relative d-flex flex-column overflow-hidden h-100">
            <div class="d-flex flex-column flex-grow-1 p-3 text-black">
                <span class="font-weight-bold h6 mb-0">${item.servicio}</span>
                <div class="d-flex mt-0 pt-0">
                    <div class="m-0 text-gray-700 text-truncate" style="max-width: 350px;max-height:30px;">${item.descripcion}</div>
                </div>
                <div class="d-flex gap-2 mt-3">
                    <span class="m-0 fw-bold">Medida:</span>
                    <span class="text-gray-700 m-0">${item.medida}</span>
                </div>
                <div class="d-flex gap-2">
                    <span class="fw-bold-600 m-0" style="font-size: 1.09375rem;">${formatterPeso.format(item.precio)}</span>
                </div>
                <div class="d-flex justify-content-end mt-auto">
                    <button type="button" class="btn btn-sm btn-success btn-action-ser" data-item="${item}">
                        <i class="fa fa-plus"></i>
                        <span>Agregar</span>
                    </button>
                </div>
            </div>
        </div>
    `;
        articulosContainer.appendChild(article);
    });
}
