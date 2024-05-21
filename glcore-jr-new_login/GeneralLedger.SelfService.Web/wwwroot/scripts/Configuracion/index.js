const modalPermisos = new bootstrap.Modal(document.getElementById("modal-permisos"), {});
var tablePermisos = "";

$(document).ready(() =>
{
    $('#btn-open-modal-permiso').click(function ()
    {
        $('#idpermiso').val(0);
        $('#permiso').val("");
        $('#descripcion').val("");
        modalPermisos.show();
    });

    LoadTablePermisos();

});

function LoadTablePermisos()
{
    $.ajax({
        url: "/Configuration/GetPermisos",
        type: 'GET',
        dataType: 'json',
        success: function (data) {

            tablePermisos = $('#table-permisos').DataTable({
                dom: "t<'d-none align-items-center'<'me-auto pb-2 mx-2'i><'mb-0 pb-2 mx-2'p>>",
                data: data.data,
                responsive: true,
                scrollCollapse: true,
                destroy: true,
                paging: true,
                lengthMenu: [15, 25, 50, 100],
                language: {
                    url: "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json",
                },
                columns: [
                    { "data": "permiso" },
                    { "data": "tipo" },
                    { "data": "descripcion" },
                    {
                        "data": "id",
                        render: function (data, type, row) {
                            return `<button type="button" class="btn btn-warning btn-sm" onclick="ModalPermiso('${data}')"><i class="fas fa-edit"></i></button>
                           `;
                           // <button type="button" class="btn btn-danger btn-sm" onclick="DeletePermiso('${data}')"><i class="fas fa-trash-alt"></i></button>
                        }
                    },
                ],
                columnDefs: [
                    { "width": "20%", "targets": 0 },
                    { "width": "10%", "targets": 1 },
                    { "width": "50%", "targets": 2 },
                    { "width": "20%", "targets": 3 },
                ],
            });

        }
    });
}

function SavePermiso()
{
    $.ajax({
        url: "/Configuration/SavePermiso",
        type: "POST",
        data: { id: $('#idpermiso').val() ,permiso: $('#permiso').val(), tipo: $('#tipo').val(), descripcion: $('#descripcion').val() },
        beforeSend: function () {

        },
        success: function (response) {
            if (response.result) {
                modalPermisos.hide();
                LoadTablePermisos();
            } else {
                ToastAlert.fire({ icon: 'error', title: "Error" });
            }
        }
    });
}

function ModalPermiso(idPermiso)
{
    $.ajax({
        url: "/Configuration/GetPermiso",
        type: "GET",
        data: { id: idPermiso },
        beforeSend: function () {

        },
        success: function (response) {
            if (response.result)
            {
                console.log();
                $('#idpermiso').val(response.data.id);
                $('#permiso').val(response.data.permiso);
                $('#descripcion').val(response.data.descripcion);
                $('#tipo').val(response.data.tipo);
                modalPermisos.show();              
            } else
            {
                ToastAlert.fire({ icon: 'error', title: "Error" });
            }
        }
    });
}