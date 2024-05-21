let comboMes = document.getElementById("mesperiodo");
let comboAnio = document.getElementById("anioperiodo");

var apexChartAssigned;
var apexChartResolved;

$(document).ready(function ()
{
    let fechaActual = new Date();
    comboMes.value = (fechaActual.getMonth() + 1);
    comboAnio.value = (fechaActual.getFullYear());

    LoadTableActivities();
    LoadTableActivityDetails();
    LoadAreaChart();
    BuildAreaChartPeriodo();
    LoadAreaPeriodo();
    GetStatistics();

    $("#btn-consultar").on("click", () => {
        LoadAreaPeriodo();
    });
});

function LoadTableActivities()
{
    tableActivities = $("#table-actividades").DataTable({
        dom: "t<'d-none'<'me-auto pb-2 mx-2'i><'mb-0 pb-2 mx-2'p>>",
        responsive: true,
        paging: false,
        scrollY: 340,
        scrollCollapse: true,
        destroy: true,
        ordering: false,
        language: {
            "url": "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json",
        },
        ajax: {
            "url": '/Home/GetAllActividadesByAgente',
            "type": "GET",
            "datatype": "json"
        },
        columns: [
            {
                "data": "actividad",
                render: function (data, type, row) {
                    return `<h6 ${(row.checked) ? 'style="text-decoration:line-through;"' : ''}>${data}<h6>`;
                }
            },
            {
                "data": "fechaCumplimiento",
                render: function (data, type, row) {
                    let fechaLimite = new Date(data).toLocaleDateString();
                    let today = new Date().toLocaleDateString();
                    let fechaCheck = new Date(row.fechaCheck).toLocaleDateString();
                    return `
                                    <span class="mx-1 badge ${((today > fechaLimite && !(row.checked)) || (fechaCheck > fechaLimite)) ? 'bg-danger text-danger' : 'bg-success text-success'} bg-opacity-20  fw-bold" style="font-size:0.7rem"> 
                                        <i class="far fa-calendar-plus"></i>
                                        ${fechaLimite}                 
                                    </span>
                                    `;
                }
            }
        ],
        columnDefs: [
            { "orderable": false, "targets": 0 },
            { "orderable": false, "targets": 1 },
        ],
    });
}

function LoadTableActivityDetails() {
    tableActivityDetails = $("#table-activity-details").DataTable({
        dom: "t<'d-none'<'me-auto pb-2 mx-2'i><'mb-0 pb-2 mx-2'p>>",
        responsive: true,
        paging: false,
        scrollY: 340,
        scrollCollapse: true,
        destroy: true,
        ordering: false,
        language: {
            "url": "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json",
        },
        ajax: {
            "url": '/Home/GetAllActividadesByAgente',
            "type": "GET",
            "datatype": "json"
        },
        columns: [
            {
                "data": "actividad",
                render: function (data, type, row) {
                    return `<h6 ${(row.checked) ? 'style="text-decoration:line-through;"' : ''}>${data}<h6>`;
                }
            },
            {
                "data": "fechaCumplimiento",
                render: function (data, type, row) {
                    let fechaLimite = new Date(data).toLocaleDateString();
                    let today = new Date().toLocaleDateString();
                    let fechaCheck = new Date(row.fechaCheck).toLocaleDateString();
                    return `
                                    <span class="mx-1 badge ${((today > fechaLimite && !(row.checked)) || (fechaCheck > fechaLimite)) ? 'bg-danger text-danger' : 'bg-success text-success'} bg-opacity-20 fw-bold" style="font-size:0.7rem"> 
                                        <i class="far fa-calendar-plus"></i>
                                        ${fechaLimite}                 
                                    </span>
                                    `;
                }
            },
            { "data": "observaciones" },
            {
                "data": "id",
                render: function (data, type, row) {
                    return `<input class="form-check-input me-1" onchange="CheckActivity(${data})" type="checkbox" ${(row.checked) ? 'checked' : ''}> `;
                }
            }
        ],
        columnDefs: [
            { "orderable": false, "targets": 0 },
            { "orderable": false, "targets": 2 },
            { "orderable": false, "targets": 3 },
        ],
    });

    AdjustColumnsTableEC()
}

function LoadAreaChart()
{

    $.ajax({
        url: "/Home/GetAssignedClosePQRSFByAgent",
        type: "GET",
        contentType: "application/json",
        success: function (response) {
            ShowAreaChart(response.data);
            ShowAreaChartAyerVsHoy(response.data);
        },
    });
}

function LoadAreaPeriodo()
{

    $.ajax({
        url: "/Home/GetDataByPeriodo",
        type: "GET",
        data: {
            mes: comboMes.value, anio: comboAnio.value
        },
        contentType: "application/json",
        success: function (response) {
            LoadDataByPeriodo(response);
        },
    });
}

function ShowPieChart(data)
{
    console.log(data);
    var apexPieChartOptions = {
        chart: { height: 365, type: 'donut' },
        stroke: { show: true, colors: [app.color.componentBg], width: 2, dashArray: 0 },
        dataLabels: { dropShadow: { enabled: false, top: 1, left: 1, blur: 1, opacity: 0.45 } },
        colors: [app.color.success, app.color.yellow, app.color.orange, app.color.red],
        labels: ['Abiertas', 'Pendientes', 'En Gestión', 'Cerradas'],
        series: [parseInt(data.xState[1]), parseInt(data.xState[2]), parseInt(data.xState[3]), parseInt(data.xState[4])],
        title: {
            text: '% de Estados de Mis PQRSF Asignadas',
            FontFace: 'Arial',
            align: 'center'
        }
    };

    var apexPieChart = new ApexCharts(document.querySelector('#apexPieChart'), apexPieChartOptions);
    apexPieChart.render();
}

function ShowAreaChart(data) {
    var apexAreaChartOptions =
    {
        chart: { height: 350, type: 'area', },
        dataLabels: { enabled: false },
        stroke: { curve: 'smooth', width: 3 },
        colors: [app.color.blue, app.color.dark],
        series: [{ name: 'Cerradas', data: data.values }],
        markers: { size: 4 },
        xaxis: { type: 'datetime', categories: data.date, },
        yaxis: {
            min: 0,
            tickAmount: 5
        },
        title: {
            text: 'PQRSF Cerradas por día',
            align: 'center'
        },
        tooltip: {
            x: { format: 'dd/MM/yy' },
        }
    };
    var apexAreaChart = new ApexCharts(document.querySelector('#apexAreaChart'), apexAreaChartOptions);
    apexAreaChart.render();
}

function ShowAreaChartAyerVsHoy(data) {
    let yesterday = (data.dtayer == null) ? [] : Object.entries(data.dtayer).map(i => i[1]);
    let today = (data.dthoy == null) ? [] : Object.entries(data.dthoy).map(i => i[1]);

    var apexAreaChartOptionsVs =
    {
        chart: { height: 350, type: 'area', },
        dataLabels: { enabled: false },
        stroke: { curve: 'smooth', width: 3 },
        colors: [app.color.dark, app.color.blue],
        series: [{ name: 'Ayer', data: yesterday }, { name: 'Hoy', data: today }],
        markers: { size: 4 },
        xaxis: { type: 'category', categories: ['00:00', '01:00', '02:00', '03:00', '04:00', '05:00', '06:00', '07:00', '08:00', '09:00', '10:00', '11:00', '12:00', '13:00', '14:00', '15:00', '16:00', '17:00', '18:00', '19:00', '20:00', '21:00', '22:00', '23:00'] },
        yaxis: {
            min: 0,
            tickAmount: 5
        },
        title: {
            text: 'Tendencia de PQRSF cerradas entre ayer y hoy',
            align: 'center'
        },
        tooltip: {
            x: { format: 'dd/MM/yy' },
        }
    };
    var apexAreaChartVs = new ApexCharts(document.querySelector('#apexAreaChartVs'), apexAreaChartOptionsVs);
    apexAreaChartVs.render();
}

function LoadDataByPeriodo(data1)
{
    let assigned = (data1.listbydayA == null) ? [] : Object.entries(data1.listbydayA).map(i => i[1]);
    let resolved = (data1.listbydayR == null) ? [] : Object.entries(data1.listbydayR).map(i => i[1]);

    $("#assigned").text(`${data1.data.asignadas}`);
    if (data1.data.porcentajeUpDownAsignadas > 0) { $("#assignedUpDown").html(`<i class="fa fa-caret-up text-success"></i> <b class="text-success">${data1.data.porcentajeUpDownAsignadas.toFixed(2)}%</b> aumentó respecto al mes pasado`) } else { $("#assignedUpDown").html(`<i class="fa fa-caret-down text-danger"></i> <b class="text-danger">${data1.data.porcentajeUpDownAsignadas.toFixed(2)}%</b> disminuyó respecto al mes pasado`) };
    $("#assignedProm").text(`${data1.data.promedioAsignadas.toFixed(2)}`);
    if (data1.data.porcentajeUpDownAsignadasProm > 0) { $("#assignedPromUpDown").html(`<i class="fa fa-caret-up text-success"></i> <b class="text-success">${data1.data.porcentajeUpDownAsignadasProm.toFixed(2)}%</b> aumentó respecto al mes pasado`) } else { $("#assignedPromUpDown").html(`<i class="fa fa-caret-down text-danger"></i> <b class="text-danger">${data1.data.porcentajeUpDownAsignadasProm.toFixed(2)}%</b> disminuyó respecto al mes pasado`) };
    $("#resolved").text(`${data1.data.resueltas}`);
    if (data1.data.porcentajeUpDownResueltas > 0) { $("#resolvedUpDown").html(`<i class="fa fa-caret-up text-success"></i> <b class="text-success">${data1.data.porcentajeUpDownResueltas.toFixed(2)}%</b> aumentó respecto al mes pasado`) } else { $("#resolvedUpDown").html(`<i class="fa fa-caret-down text-danger"></i> <b class="text-danger">${data1.data.porcentajeUpDownResueltas.toFixed(2)}%</b> disminuyó respecto al mes pasado`) };
    $("#resolvedProm").text(`${data1.data.promedioResueltas.toFixed(2)}`);
    if (data1.data.porcentajeUpDownResueltasProm > 0) { $("#resolvedPromUpDown").html(`<i class="fa fa-caret-up text-success"></i> <b class="text-success">${data1.data.porcentajeUpDownResueltasProm.toFixed(2)}%</b> aumentó respecto al mes pasado`) } else { $("#resolvedPromUpDown").html(`<i class="fa fa-caret-down text-danger"></i> <b class="text-danger">${data1.data.porcentajeUpDownResueltasProm.toFixed(2)}%</b> disminuyó respecto al mes pasado`) };


    apexChartAssigned.updateSeries([{
        data: assigned
    }]);

    apexChartResolved.updateSeries([{
        data: resolved
    }]);

}


function CheckActivity(id)
{
    $.ajax({
        url: '/Home/CheckActividad',
        type: "POST",
        data: { id: id },
        success: function (response) {
            if (response.result) {
                ToastAlert.fire({ icon: 'success', title: response.message });
                LoadTableActivities();
                LoadTableActivityDetails();
            } else {
                ToastAlert.fire({ icon: 'error', title: response.message });
            }
        },
    });
}


function BuildAreaChartPeriodo() {
    let options = {
        series: [{
            name: 'ASIGNADAS',
            data: [],
        }],
        chart: {
            height: 95,
            group: 'sparks',
            type: 'line',
            sparkline: {
                enabled: true
            },
        },
        colors: ['#1F6BFF']
        ,
        dataLabels: {
            enabled: false
        },
        markers: {
            size: 0
        },
        tooltip: {
            x: {
                show: true
            },
            y: {
                title: {
                    formatter: function formatter(val) {
                        return '';
                    }
                }
            }
        },
        stroke: {
            curve: 'smooth'
        },
        xaxis: {
            type: 'category',
            categories: ["", "1", "2", "3", "4", "5", "6", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"]
        },
    };

    apexChartAssigned = new ApexCharts(document.querySelector("#apexChartAssigned"), options);
    apexChartAssigned.render();

    let options2 = {
        series: [{
            name: 'RESUELTAS',
            data: [],
        }],
        chart: {
            height: 95,
            group: 'sparks',
            type: 'line',
            sparkline: {
                enabled: true
            },
        },
        colors: ['#212837'],
        dataLabels: {
            enabled: false
        },
        markers: {
            size: 0
        },
        tooltip: {
            x: {
                show: true
            },
            y: {
                title: {
                    formatter: function formatter(val) {
                        return '';
                    }
                }
            }
        },
        stroke: {
            curve: 'smooth'
        },
        xaxis: {
            type: 'category',
            categories: ["", "1", "2", "3", "4", "5", "6", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"]
        },
    };

    apexChartResolved = new ApexCharts(document.querySelector("#apexChartResolved"), options2);
    apexChartResolved.render();
}


function GetStatistics()
{
    $.ajax({
        url: "/Home/GetStatisticsHome",
        type: "GET",
        beforeSend: function () {

        },
        success: function (response)
        {
            if (response.result)
            {
                ShowPieChart(response.data);
                $("#pqrsfasignado").text(response.data.xState[0]);
                $("#pqrsfabierto").text(response.data.xState[1]);
                $("#pqrsfgestion").text(response.data.xState[3]);
                $("#pqrsfpendiente").text(response.data.xState[2]);
                $("#pqrsfvence").text(response.data.xState[5]);
                $("#pqrsfcerrado").text(response.data.xState[4]);

                $("#porpeticion").css('width', `${response.data.xPqrsf[1].porcentaje}%`);
                $("#porqueja").css('width', `${response.data.xPqrsf[2].porcentaje}%`);
                $("#porreclamo").css('width', `${response.data.xPqrsf[3].porcentaje}%`);
                $("#porsugerencia").css('width', `${response.data.xPqrsf[4].porcentaje}%`);
                $("#porfelicitacion").css('width', `${response.data.xPqrsf[5].porcentaje}%`);

                $("#lblporpeticion").text(`${response.data.xPqrsf[1].porcentaje}%`);
                $("#lblporqueja").text(`${response.data.xPqrsf[2].porcentaje}%`);
                $("#lblporreclamo").text(`${response.data.xPqrsf[3].porcentaje}%`);
                $("#lblporsugerencia").text(`${response.data.xPqrsf[4].porcentaje}%`);
                $("#lblporfelicitacion").text(`${response.data.xPqrsf[5].porcentaje}%`);

                $("#lblcanpeticion").text( `Peticiones (${response.data.xPqrsf[1].cantidad})`);
                $("#lblcanqueja").text(`Quejas (${response.data.xPqrsf[2].cantidad})`);
                $("#lblcanreclamo").text(`Reclamos (${response.data.xPqrsf[3].cantidad})`);
                $("#lblcansugerencia").text( `Sugerencias (${response.data.xPqrsf[4].cantidad})`);
                $("#lblcanfelicitacion").text(`Felicitaciones (${response.data.xPqrsf[5].cantidad})`);

                $("#lbltotal").text(`Total: ${response.data.xPqrsf[0].cantidad}`);
            }
            else
            {
                ToastAlert.fire({ icon: 'error', title: "Error" });
            }
        }
    });
}

function AdjustColumnsTableEC()
{
    setTimeout(() => {
        $(".dataTables_scrollHeadInner").width("100%");

    }, 800)
}
