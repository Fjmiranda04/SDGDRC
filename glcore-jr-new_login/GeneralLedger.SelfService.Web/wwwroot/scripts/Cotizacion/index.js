$(document).ready(function () {
    getCotizaciones();
});

function loadListContizaciones(data) {
    tableCotizaciones = $("#table-cotizaciones").DataTable({
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
                "data": "cotizacion",
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
                "data": "nroIdCliente",
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
                "data": "cliente",
                render: function (data, type, row) {

                    return `
                        ${data}
                    `;
                }
            },
            {
                "data": "etiqueta",
                render: function (data, type, row) {

                    return `
                        ${data}
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
                "data": "dias",
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
                "data": "descripcion",
                render: function (data, type, row) {

                    return `
                        ${data}
                    `;
                }
            },
            {
                "data": "total",
                render: function (data, type, row) {
                    return `<b class="text-success">${formatterPeso.format(data)}</b>`;
                }
            },
        ]
    })
}

function getCotizaciones() {
    try {
        $.ajax({
            type: "GET",
            url: "/Cotizacion/GetCotizaciones",
            dataType: "json",
            success: function (response) {
                loadListContizaciones(response);
            }
        });
    } catch (e) {
        console.log(e)
    }

}