var Operation = "N";

/*********************************************************************ETIQUETAS************************************************************************************************* */
const modalEtiquetas = new bootstrap.Modal(document.getElementById("modal-etiquetas"), {});
const modalPreguntas = new bootstrap.Modal(document.getElementById("modal-preguntas"), {});
const modalAreas = new bootstrap.Modal(document.getElementById("modal-areas"), {});
const modalAgentes = new bootstrap.Modal(document.getElementById("modal-agentes"), {});
var tableEtiquetas = "";
var tableAreas = "";
var tablePreguntas = "";


$(document).ready(function () {

    $("#btn-n-etiqueta").click(function (e) {
        $("#etiqueta").val("");
        $("#codigoetiqueta").val("");
        Operation = "N";
        modalEtiquetas.show();
    });

    $("#btn-n-pregunta").click(function (e) {
        $("#pregunta").val("");
        $("#codigopregunta").val("");
        Operation = "N";
        modalPreguntas.show();
    });

    $("#btn-n-area").click(function (e) {
        $("#area").val("");
        $("#codigoarea").val("");
        Operation = "N";
        modalAreas.show();
    });

    $("#btn-n-agente").click(function (e) {
        $("#NroId").val("");
        $("#NombreCompleto").val("");
        $("#Email").val("");
        Operation = "N";
        modalAgentes.show();
    });

    $("#NroId").keypress(function (event) {
        if (event.which === 13) {
            Search($("#NroId").val());
        }
    });

    $("#btn-save-new-agente").click(function (event) {
        SaveAgente();
    });

    $("#search-area").on("keyup", function () {
        tableAreas.search(this.value).draw();
    });

    $("#search-pregunta").on("keyup", function () {
        tablePreguntas.search(this.value).draw();
    });

    $("#search-etiqueta").on("keyup", function () {
        tableEtiquetas.search(this.value).draw();
    });

    $("#search-agente").keypress(function (event) {
        if (event.which === 13) {
            LoadDataTable("Agente");
        }
    });

    LoadDataTable("Etiqueta");
    LoadDataTable("Pregunta");
    LoadDataTable("Area");
    LoadDataTable("Agente");

});

function LoadDataTable(table)
{

    switch (table) {
        case "Etiqueta":
            LoadTableEtiquetas();
            break;

        case "Pregunta":
            LoadTablePreguntas();
            break;

        case "Area":
            LoadTableAreas();
            break;

        case "Agente":
            LoadTableAgentes();
            break;
    }
   
}

function LoadTableEtiquetas()
{
    $.ajax({
        url: "/Profiler/GetEtiquetas",
        type: 'GET',
        dataType: 'json',
        success: function (data) {

            tableEtiquetas = $('#table-etiquetas').DataTable({
                dom: "t<'d-none align-items-center'<'me-auto pb-2 mx-2'i><'mb-0 pb-2 mx-2'p>>",
                "language": {
                    "url": "https://cdn.datatables.net/plug-ins/1.10.21/i18n/Spanish.json"
                },
                data: data,
                columns: [
                    { "data": "nombre" },
                    {
                        "data": "codigo",
                        render: function (data, type, row) {
                            return `<button type="button" class="btn btn-warning btn-sm" onclick="ModalEtiqueta('${data}','${row.nombre}')"><i class="fas fa-edit"></i></button>
                            <button type="button" class="btn btn-danger btn-sm" onclick="DeleteEtiqueta('${data}')"><i class="fas fa-trash-alt"></i></button>`;
                        }
                    },
                ],
                columnDefs: [
                    { "width": "80%", "targets": 0 },
                    { "width": "20%", "targets": 1 },
                ],
                destroy: true,
                responsive: true,
                paging: true,
            });

        }
    });
}

function LoadTablePreguntas()
{
    $.ajax({
        url: "/Profiler/GetPreguntas",
        type: 'GET',
        dataType: 'json',
        success: function (data) {

            tablePreguntas = $('#table-preguntas').DataTable({
                dom: "t<'d-none align-items-center'<'me-auto pb-2 mx-2'i><'mb-0 pb-2 mx-2'p>>",
                "language": {
                    "url": "https://cdn.datatables.net/plug-ins/1.10.21/i18n/Spanish.json"
                },
                data: data,
                columns: [
                    { "data": "nomPregunta" },
                    {
                        "data": "id",
                        render: function (data, type, row) {
                            return `<button type="button" class="btn btn-warning btn-sm" onclick="ModalPregunta('${data}','${row.nomPregunta}')"><i class="fas fa-edit"></i></button>
                            <button type="button" class="btn btn-danger btn-sm" onclick="DeletePregunta('${data}')"><i class="fas fa-trash-alt"></i></button>`;
                        }
                    },
                ],
                columnDefs: [
                    { "width": "80%", "targets": 0 },
                    { "width": "20%", "targets": 1 },
                ],
                destroy: true,
                responsive: true,
                paging: true,
            });

        }
    });
}

function LoadTableAreas()
{
    $.ajax({
        url: "/Profiler/GetAreas",
        type: 'GET',
        dataType: 'json',
        success: function (data) {

            tableAreas = $('#table-areas').DataTable({
                dom: "t<'d-none align-items-center'<'me-auto pb-2 mx-2'i><'mb-0 pb-2 mx-2'p>>",
                "language": {
                    "url": "https://cdn.datatables.net/plug-ins/1.10.21/i18n/Spanish.json"
                },
                data: data,
                columns: [
                    { "data": "nomare" },
                    {
                        "data": "codare",
                        render: function (data, type, row) {
                            return `<button type="button" class="btn btn-warning btn-sm" onclick="ModalArea('${data}','${row.nomare}')"><i class="fas fa-edit"></i></button>
                            <button type="button" class="btn btn-danger btn-sm" onclick="DeleteArea('${data}')"><i class="fas fa-trash-alt"></i></button>`;
                        }
                    },
                ],
                columnDefs: [
                    { "width": "80%", "targets": 0 },
                    { "width": "20%", "targets": 1 },
                ],
                destroy: true,
                responsive: true,
                paging: true,

            });

            $("#Area").empty();
            let option = "";

            for (var i in data)
            {
                option += `<option value="${data[i].codare}">${data[i].nomare}</option>`;
            }
            $("#Area").append(option);

        }
    });
}

function LoadTableAgentes()
{
    $.ajax({
        url: "/Profiler/GetAgentes",
        type: 'GET',
        dataType: 'json',
        data: { search: $("#search-agente").val() },
        success: function (data) {

            $('#table-agentes').DataTable({
                dom: "t<'d-none align-items-center'<'me-auto pb-2 mx-2'i><'mb-0 pb-2 mx-2'p>>",
                data: data,
                columns: [
                    { "data": "codigo" },
                    { "data": "nroId" },
                    { "data": "nombreCompleto" },
                    { "data": "area" },
                    { "data": "email" },
                    {
                        "data": "id",
                        render: function (data, type, row) {
                            let acciones = "";

                            acciones = (row.recibeEmail) ? `<button type="button" class="btn btn-success btn-sm check-btn" onclick="OnOffEmail('${data}')" title="Recibe Correos"><i class="fas fa-envelope"></i></button>
                            <button type="button" class="btn btn-danger btn-sm" onclick="DeleteAgente('${data}')" title="Eliminar"><i class="fas fa-trash-alt"></i></button>` :

                                `<button type="button" class="btn btn-danger btn-sm check-btn" onclick="OnOffEmail('${data}')"  title="No Recibe Correos"><i class="fas fa-envelope"></i></button>
                            <button type="button" class="btn btn-danger btn-sm" onclick="DeleteAgente('${data}')"  title="Eliminar"><i class="fas fa-trash-alt"></i></button>`

                            return acciones;
                        }
                    },
                ],
                columnDefs: [
                    { "width": "10%", "targets": 0 },
                    { "width": "10%", "targets": 1 },
                    { "width": "40%", "targets": 2 },
                    { "width": "20%", "targets": 3 },
                    { "width": "10%", "targets": 4 },
                    { "width": "10%", "targets": 5 },
                ],
                responsive: true,
                scrollCollapse: true,
                destroy: true,
                paging: true,
                language: {
                    url: "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json",
                },

            });

        }
    });
}


function ModalEtiqueta(codigo,nombre)
{
    $("#etiqueta").val(nombre);
    $("#codigoetiqueta").val(codigo);
    Operation = "E";
    modalEtiquetas.show();
}

function DeleteEtiqueta(codigo)
{
    $.ajax({
        url: "/Profiler/DeleteEtiqueta",
        type: "POST",
        data: { codigo: codigo },
        beforeSend: function () {

        },
        success: function (response) {
            if (response.result) {
                modalEtiquetas.hide();
                LoadDataTable("Etiqueta");
            } else {
                ToastAlert.fire({ icon: 'error', title: "Error" });
            }
        }
    });
}

function SaveE()
{
    if (Operation == "N")
    {
        SaveEtiqueta(); return;
    }

    EditEtiqueta();
}

function SaveEtiqueta()
{
    $.ajax({
        url: "/Profiler/SaveEtiqueta",
        type: "POST",
        data: { etiqueta: $('#etiqueta').val() },
        beforeSend: function () {

        },
        success: function (response) {
            if (response.result)
            {
                modalEtiquetas.hide();
                LoadDataTable("Etiqueta");
            } else
            {
                ToastAlert.fire({ icon: 'error', title: "Error" });
            }
        }
    });
}

function EditEtiqueta() {
    $.ajax({
        url: "/Profiler/EditEtiqueta",
        type: "POST",
        data: { etiqueta: $('#etiqueta').val(), codigo: $('#codigoetiqueta').val() },
        beforeSend: function () {

        },
        success: function (response) {
            if (response.result) {
                modalEtiquetas.hide();
                LoadDataTable("Etiqueta");
            } else {
                ToastAlert.fire({ icon: 'error', title: "Error" });
            }
        }
    });
}

/***************************************************************PREGUNTAS***************************************************************************************************** */
function SaveP()
{
    if (Operation == "N") {
        SavePregunta(); return;
    }

    EditPregunta();
}

function SavePregunta() {
    $.ajax({
        url: "/Profiler/SavePregunta",
        type: "POST",
        data: { pregunta: $('#pregunta').val() },
        beforeSend: function () {

        },
        success: function (response) {
            if (response.result) {
                modalPreguntas.hide();
                LoadDataTable("Pregunta");
            } else {
                ToastAlert.fire({ icon: 'error', title: "Error" });
            }
        }
    });
}

function EditPregunta() {
    $.ajax({
        url: "/Profiler/EditPregunta",
        type: "POST",
        data: { pregunta: $('#pregunta').val(), codigo: $('#codigopregunta').val() },
        beforeSend: function () {

        },
        success: function (response) {
            if (response.result) {
                modalPreguntas.hide();
                LoadDataTable("Pregunta");
            } else {
                ToastAlert.fire({ icon: 'error', title: "Error" });
            }
        }
    });
}

function DeletePregunta(codigo) {
    $.ajax({
        url: "/Profiler/DeletePregunta",
        type: "POST",
        data: { codigo: codigo },
        beforeSend: function () {

        },
        success: function (response) {
            if (response.result) {
                LoadDataTable("Pregunta");
            } else {
                ToastAlert.fire({ icon: 'error', title: "Error" });
            }
        }
    });
}

function ModalPregunta(codigo, nombre) {
    $("#pregunta").val(nombre);
    $("#codigopregunta").val(codigo);
    Operation = "E";
    modalPreguntas.show();
}

/*************************************************************************************************AREAS****************************************************************************************************** */
function SaveA() {
    if (Operation == "N") {
        SaveArea(); return;
    }

    EditArea();
}

function SaveArea() {
    $.ajax({
        url: "/Profiler/SaveArea",
        type: "POST",
        data: { area: $('#area').val() },
        beforeSend: function () {

        },
        success: function (response) {
            if (response.result) {
                modalAreas.hide();
                LoadDataTable("Area");
            } else {
                ToastAlert.fire({ icon: 'error', title: "Error" });
            }
        }
    });
}

function EditArea() {
    $.ajax({
        url: "/Profiler/EditArea",
        type: "POST",
        data: { area: $('#area').val(), codigo: $('#codigoarea').val() },
        beforeSend: function () {

        },
        success: function (response) {
            if (response.result) {
                modalAreas.hide();
                LoadDataTable("Area");
            } else {
                ToastAlert.fire({ icon: 'error', title: "Error" });
            }
        }
    });
}

function DeleteArea(codigo) {
    $.ajax({
        url: "/Profiler/DeleteArea",
        type: "POST",
        data: { codigo: codigo },
        beforeSend: function () {

        },
        success: function (response) {
            if (response.result) {
                LoadDataTable("Area");
            } else {
                ToastAlert.fire({ icon: 'error', title: "Error" });
            }
        }
    });
}

function ModalArea(codigo, nombre) {
    $("#area").val(nombre);
    $("#codigoarea").val(codigo);
    Operation = "E";
    modalAreas.show();
}

/********************************************************************************************AGENTES***************************************************************************************************** */
function OnOffEmail(codigo) {
    $.ajax({
        url: "/Profiler/EnabledEmail",
        type: "POST",
        data: { codigo: codigo },
        beforeSend: function () {

        },
        success: function (response) {
            if (response.result) {
                LoadDataTable("Agente");
            } else {
                ToastAlert.fire({ icon: 'error', title: "Error" });
            }
        }
    });
}

function DeleteAgente(codigo) {
    $.ajax({
        url: "/Profiler/DeleteAgente",
        type: "POST",
        data: { codigo: codigo },
        beforeSend: function () {

        },
        success: function (response) {
            if (response.result) {
                LoadDataTable("Agente");
            } else {
                ToastAlert.fire({ icon: 'error', title: "Error" });
            }
        }
    });
}

function Search(nroId) {
    $.ajax({
        url: "/Profiler/GetUsuarioAgente",
        type: "GET",
        data: { codigo: nroId },
        success: function (response) {
            if (response.result) {
                $("#NroId").val(response.data.nroId);
                $("#NombreCompleto").val(response.data.nombre);       
                $("#Email").val(response.data.email);
            }
        },
    });
}

function SaveAgente() {

    $.ajax({
        url: "/Profiler/SaveAgente",
        type: "POST",
        data: $("#form-new-agente").serialize(),
        beforeSend: function () {
            $('#btn-save-new-agente').prop('disabled', true);
        },
        success: function (response) {
            if (response.result) {
                modalAgentes.hide();
                ToastAlert.fire({ icon: 'success', title: response.message });
                LoadDataTable("Agente");
                $('#btn-save-new-agente').prop('disabled', false);
            }
        },
    });
}