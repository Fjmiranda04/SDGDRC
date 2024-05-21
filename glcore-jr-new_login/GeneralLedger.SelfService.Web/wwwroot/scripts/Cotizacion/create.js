var liElement = `<li style='background-color: #ecf2fc; border: 1px solid #ccc;padding: 5px;width: 100%;float: left;cursor: pointer;'>`
var listCliente = "#clienteList";
var listSolicitante = "#solicitanteList";

$(function () {
    $("#NitCliente").on("input", function () {
        var term = $(this).val();
        $.ajax({
            url: "/Cotizacion/GetClientes",
            dataType: "json",
            data: {
                filter: term
            },
            success: function (data) {
                console.log(data);
                showClienteItem(data);
            }
        });
    });

    $(listCliente).on("click", "li", function () {
        var selectedItem = $(this).data("item");
        $("#NitCliente").val(selectedItem.nit);
        $("#NombreCliente").val(selectedItem.nombre);

        $(listCliente).hide();
    });

    $(document).on("click", function (event) {
        if (!$(event.target).closest(listCliente).length && !$(event.target).closest("#NitCliente").length) {
            $(listCliente).hide();
        }
    });
});

$(function () {
    $("#CodSolicitante").on("input", function () {
        var term = $(this).val();
        var currentNit = $('#NitCliente').val();
        $.ajax({
            url: "/Cotizacion/GetSolicitantes",
            dataType: "json",
            data: {
                filter: term,
                nitCliente: currentNit.trim()
            },
            success: function (data) {
                showSolicitanteItem(data);
            }
        });
    });

    $(solicitanteList).on("click", "li", function () {
        var selectedItem = $(this).data("item");
        $("#CodSolicitante").val(selectedItem.cedula);
        $("#NombreSolicitante").val(selectedItem.nombre);
        $("#Cargo").val(selectedItem.cargo);
        $("#Correo").val(selectedItem.email);
        $("#Telefono").val(selectedItem.telefono);

        $(solicitanteList).hide();
    });

    $(document).on("click", function (event) {
        if (!$(event.target).closest(solicitanteList).length && !$(event.target).closest("#CodSolicitante").length) {
            $(solicitanteList).hide();
        }
    });
});

function showClienteItem(data) {
    var listContainer = $(listCliente);
    listContainer.empty();

    $.each(data, function (index, item) {
        $(liElement)
            .text(item.nit + ' - ' + item.nombre)
            .data('item', item)
            .appendTo(listContainer);
    });

    listContainer.show();
}

function showSolicitanteItem(data) {
    var listContainer = $(listSolicitante);
    listContainer.empty();

    $.each(data, function (index, item) {
        $(liElement)
            .text(item.cedula + ' - ' + item.nombre)
            .data('item', item)
            .appendTo(listContainer);
    });

    listContainer.show();
}

const tabLinks = document.querySelectorAll(".tabs-menu a");
const tabPanels = document.querySelectorAll(".tabs-panel");

for (let el of tabLinks) {
    el.addEventListener("click", e => {
        e.preventDefault();

        document.querySelector(".tabs-menu li.active").classList.remove("active");
        document.querySelector(".tabs-panel.active").classList.remove("active");

        const parentListItem = el.parentElement;
        parentListItem.classList.add("active");
        const index = [...parentListItem.parentElement.children].indexOf(parentListItem);

        const panel = [...tabPanels].filter(el => el.getAttribute("data-index") == index);
        panel[0].classList.add("active");
    });
}

$(document).ready(function () {
    $.ajax({
        url: "/Cotizacion/GetArticulos",
        dataType: "json",
        success: function (data) {
            showArticulos(data);
        }
    });
});

$(document).ready(function () {
    $.ajax({
        url: "/Cotizacion/GetServicios",
        dataType: "json",
        success: function (data) {
            showServicios(data);
        }
    });
});

function showArticulos(list) {
    var listContainer = document.querySelector('#articulosLayout');

    $.each(list, function (index, item) {
        var article = document.createElement('article');
        article.className = 'col-md-6 mb-3 p-0 flex';
        article.innerHTML = `
        <div class="card item-card mx-2 position-relative d-flex flex-column overflow-hidden h-100">
            <div class="d-flex flex-column flex-grow-1 p-3 text-black">
                <span class="font-weight-bold h4">${item.descripcion}</span>
                <div class="d-flex gap-2">
                    <span class="m-0 text-gray-700">Valor unitario:</span>
                    <span class="fw-bold m-0">${item.costo}</span>
                </div>
                <div class="d-flex gap-2">
                    <span class="m-0 text-gray-700">Medida:</span>
                    <span class="fw-bold m-0">${item.medida}</span>
                </div>
                <div class="d-flex justify-content-end mt-auto">
                    <button class="btn btn-sm btn-success">
                        <i class="fa fa-plus"></i>
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
        article.className = 'col-md-6 mb-3 p-0 flex';
        article.innerHTML = `
        <div class="card item-card mx-2 position-relative d-flex flex-column overflow-hidden h-100">
            <div class="d-flex flex-column flex-grow-1 p-3 text-black">
                <span class="font-weight-bold h4">${item.servicio}</span>
                <div class="d-flex">
                    <div class="m-0 text-gray-700 overflow-hidden">${item.descripcion}</div>
                </div>
                <div class="d-flex gap-2">
                    <span class="m-0 text-gray-700">Valor unitario:</span>
                    <span class="fw-bold m-0">${item.precio}</span>
                </div>
                <div class="d-flex gap-2">
                    <span class="m-0 text-gray-700">Medida:</span>
                    <span class="fw-bold m-0">${item.medida}</span>
                </div>
                <div class="d-flex justify-content-end mt-auto">
                    <button class="btn btn-sm btn-success">
                        <i class="fa fa-plus"></i>
                    </button>
                </div>
            </div>
        </div>
    `;
        articulosContainer.appendChild(article);
    });
}