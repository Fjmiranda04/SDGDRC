var ApexCharOne;
var ApexCharTwo;
var ApexCharThree;
var ApexCharFour;
var ApexCharFive;
var ApexChartSix;
var ApexChartSeven;
var ApexChartEight;
var ApexChartNine;
var ApexChartTen;
var ApexChartEleven;
var ApexChartRecaudo;
const captionVencimiento =
    [
        ['No Vencidas', '1 - 30', 'Más de 30', '--', '--'],
        ['No Vencidas', '1 - 30', '31 - 60', 'Más de 60', '--'],
        ['No Vencidas', '1 - 30', '31 - 60', '61 - 90', 'Más de 90'],
        ['No Vencidas', '1 - 60', '61 - 90', '91 - 120', 'Más de 120'],
        ['No Vencidas', '1 - 90', '91 - 120', '121 - 180', 'Más de 180'],
        ['No Vencidas', '1 - 120', '121 - 180', '181 - 360', 'Más de 360']
    ]

$(document).ready(() =>
{
    var datosEstadistico = [];
    

    let currentDate = new Date();
    $("#fecha-corte").val(formatDate2(currentDate));
    $("#srangodias").val(0);
    $("#saniorecaudo").val(new Date().getFullYear());
    LoadData();
    LoadRecaudoCartera();


    $("#scliente").on("change", function ()
    {
        LoadDataCliente($("#scliente").val())
    });

    $("#sdependencia").on("change", function ()
    {
        LoadDataDependencia($("#sdependencia").val())
    });

    $("#fecha-corte").on("change", function ()
    {
        LoadData();
    });

    $("#srangodias").on("change", function () {
        LoadData();
    });

    $("#saniorecaudo").on("change", function () {
        LoadRecaudoCartera();
    });

    ApexOne("");
    ApexTwo("");
    ApexThree("");
    ApexFour("");
    ApexFive("");
    ApexNine();
    ApexTen();
    ApexEleven();
    ApexRecaudo();
});

function LoadRecaudoCartera()
{
    $.ajax({
        url: "/Cartera/GetRecaudoCartera",
        type: "GET",
        data: {
            fecha: $("#saniorecaudo").val()
        },
        contentType: "application/json",
        beforeSend: function () {
            LoaderScreenShow();
        },
        success: function (response)
        {
            let a = response.data.cartera;
            let b = response.data.recaudo;
            var anio = $("#saniorecaudo").val();

            let datosCartera =
            [
                (b[0].abonoFactura >  0)?a[0].abonoFactura:0,
                (b[1].abonoFactura >  0)?a[1].abonoFactura:0,
                (b[2].abonoFactura >  0)?a[2].abonoFactura:0,
                (b[3].abonoFactura >  0)?a[3].abonoFactura:0,
                (b[4].abonoFactura >  0)?a[4].abonoFactura:0,
                (b[5].abonoFactura >  0)?a[5].abonoFactura:0,
                (b[6].abonoFactura >  0)?a[6].abonoFactura:0,
                (b[7].abonoFactura >  0)?a[7].abonoFactura:0,
                (b[8].abonoFactura >  0)?a[8].abonoFactura:0,
                (b[9].abonoFactura >  0)?a[9].abonoFactura:0,
                (b[10].abonoFactura >  0)?a[10].abonoFactura:0,
                (b[11].abonoFactura > 0)?a[11].abonoFactura:0
            ];

            let datosRecaudo =
            [
                b[0].abonoFactura,
                b[1].abonoFactura,
                b[2].abonoFactura,
                b[3].abonoFactura,
                b[4].abonoFactura,
                b[5].abonoFactura,
                b[6].abonoFactura,
                b[7].abonoFactura,
                b[8].abonoFactura,
                b[9].abonoFactura,
                b[10].abonoFactura,
                b[11].abonoFactura
            ];

            ApexChartRecaudo.updateOptions({
                series: [{
                    name: 'Cartera',
                    data: datosCartera,
                }, {
                    name: 'Recaudo',
                    data: datosRecaudo,
                    }],
                title: {
                    text: `Recaudo de Cartera desde 01/01/${anio} hasta 31/12/${anio}`,
                    FontFace: 'Arial',
                    align: 'center'
                }
            });


        },
        complete: function () {
            LoaderScreenHide();
        }
    });
}

function LoadData()
{
    $.ajax({
        url: "/Cartera/GetAnalisisData",
        type: "GET",
        data: {
            fecha: $("#fecha-corte").val(), rango: $("#srangodias").val()
        },
        contentType: "application/json",
        beforeSend: function ()
        {
            LoaderScreenShow();
        },
        success: function (response)
        {
            datosEstadistico = response.data;

            let totalCartera = 0, totalPendiente = 0, totalFacturas = 0;

            response.data.forEach(obj =>
            {
                totalCartera += (obj.subTotal + obj.valorIva);
                totalPendiente = totalPendiente + (obj.noVen + obj.rango1 + obj.rango2 + obj.rango3 + obj.rango4  );
            });

            totalFacturas = response.data.length;

            $("#totalCartera").text(totalCartera.toLocaleString());
            $("#totalPendiente").text(totalPendiente.toLocaleString());
            $("#totalFacturas").text(totalFacturas);
            $("#scliente").val($("#scliente option:first").val());
            $("#sdependencia").val($("#sdependencia option:first").val());

            //APEXONE
            let dataApexOne =
            [
                0,
                0,
                0,
                0,
                0,
            ];
     
            response.data.forEach(obj =>
            {
                dataApexOne[0] += obj.noVen || 0;
                dataApexOne[1] += obj.rango1 || 0;
                dataApexOne[2] += obj.rango2 || 0;
                dataApexOne[3] += obj.rango3 || 0;
                dataApexOne[4] += obj.rango4 || 0;
            });

            //ApexOne(dataApexOne);

            ApexCharOne.updateOptions({
                series: [{
                    name: 'valor',
                    data: dataApexOne,
                }],
                xaxis: {
                    categories: captionVencimiento[$("#srangodias").val()]
                }
            });

            //APEXTWO
            let dataApexTwo =
            [
                response.data.filter(obj => obj.noVen > 0).length,
                response.data.filter(obj => obj.rango1 > 0).length,
                response.data.filter(obj => obj.rango2 > 0).length,
                response.data.filter(obj => obj.rango3 > 0).length,
                response.data.filter(obj => obj.rango4 > 0).length,
            ];

            ApexCharTwo.updateOptions({
                series: [{
                    name: 'Facturas',
                    data: dataApexTwo,
                }],
                xaxis: {
                    categories: captionVencimiento[$("#srangodias").val()]
                }
            });
            
            //ApexTwo(dataApexTwo);
            //APEXTHREE
            //ApexThree(dataApexTwo);

            ApexCharThree.updateOptions({
                series:  dataApexTwo,             
                labels: captionVencimiento[$("#srangodias").val()]                
            });


            //APEXFOUR
            let dataApexFour =
            [
                response.data.filter(obj => obj.calificacion == "SIN GESTION" || obj.calificacion == "SIN GESTIÓN").length,
                response.data.filter(obj => obj.calificacion  == "GESTIÓN SIN RESULTADO").length,
                response.data.filter(obj => obj.calificacion  == "EN PROGRAMACIÓN").length,
                response.data.filter(obj => obj.calificacion == "PAGO AUTORIZADO").length,
                response.data.filter(obj => obj.calificacion == "OBJETADO").length,
            ];

            ApexCharFour.updateOptions({
                series: dataApexFour,
            });

            //APEXFIVE

            ApexCharFive.updateOptions({
                series: [{
                    name: 'Facturas',
                    data: dataApexFour,
                }],
            });
            //ApexFive(dataApexFour);
            ApexSix("");
            ApexSeven("");
            ApexEight("");
            ApexNine("");
            ApexTen("");
            ApexEleven("");

            //LoadDataCliente("");
            ApexChartSix.updateOptions({
                xaxis: {
                    categories: captionVencimiento[$("#srangodias").val()]
                }
            });

            ApexChartSeven.updateOptions({
                xaxis: {
                    categories: captionVencimiento[$("#srangodias").val()]
                }
            });

            ApexChartNine.updateOptions({
                xaxis: {
                    categories: captionVencimiento[$("#srangodias").val()]
                }
            });

            ApexChartTen.updateOptions({
                xaxis: {
                    categories: captionVencimiento[$("#srangodias").val()]
                }
            });
        },
        complete: function ()
        {
            LoaderScreenHide();         
        }
    });
}

function LoadDataCliente(codigoCliente)
{
    ApexChartSix.updateOptions({
        xaxis: {
            categories: captionVencimiento[$("#srangodias").val()]
        }
    });

    ApexChartSeven.updateOptions({
        xaxis: {
            categories: captionVencimiento[$("#srangodias").val()]
        }
    });

    let dataApexCliente =
    [
         0,
         0,
         0,
         0,
         0,
    ];

    datosEstadistico.forEach(obj =>
    {
        if (obj.codigoCliente.trim() == codigoCliente.trim())
        {
            dataApexCliente[0] += obj.noVen || 0;
            dataApexCliente[1] += obj.rango1 || 0;
            dataApexCliente[2] += obj.rango2 || 0;
            dataApexCliente[3] += obj.rango3 || 0;
            dataApexCliente[4] += obj.rango4 || 0;
        }
    });

    ApexChartSix.updateSeries([{
        data: dataApexCliente
    }]);

    let dataApexClienteCount =
    [
        0,
        0,
        0,
        0,
        0,
    ];

    dataApexClienteCount[0] = datosEstadistico.filter(obj => obj.noVen > 0 && obj.codigoCliente.trim() == codigoCliente.trim()).length;
    dataApexClienteCount[1] = datosEstadistico.filter(obj => obj.rango1 > 0 && obj.codigoCliente.trim() == codigoCliente.trim()).length;
    dataApexClienteCount[2] = datosEstadistico.filter(obj => obj.rango2 > 0 && obj.codigoCliente.trim() == codigoCliente.trim()).length;
    dataApexClienteCount[3] = datosEstadistico.filter(obj => obj.rango3 > 0 && obj.codigoCliente.trim() == codigoCliente.trim()).length;
    dataApexClienteCount[4] = datosEstadistico.filter(obj => obj.rango4 > 0 && obj.codigoCliente.trim() == codigoCliente.trim()).length;

    ApexChartSeven.updateSeries([{
        data: dataApexClienteCount
    }]);

    let totalCarteraCliente = 0;
    let totalPendienteCliente = 0;
    let totalFacturaCliente = 0;

    totalFacturaCliente = datosEstadistico.filter(obj => obj.codigoCliente.trim() == codigoCliente.trim()).length,

    datosEstadistico.forEach(obj =>
    {
        if (obj.codigoCliente.trim() == codigoCliente.trim())
        {
            totalCarteraCliente += (obj.subTotal + obj.valorIva);
            totalPendienteCliente = totalPendienteCliente + (obj.noVen + obj.rango1 + obj.rango2 + obj.rango3 + obj.rango4);
        }
    });

    $("#totalCarteraCliente").text("$" + totalCarteraCliente.toLocaleString());
    $("#totalPendienteCliente").text("$" + totalPendienteCliente.toLocaleString());
    $("#totalFacturaCliente").text(totalFacturaCliente);

    let porcentaje = ((totalCarteraCliente - totalPendienteCliente) * 100) / totalCarteraCliente;

    if (totalCarteraCliente == 0)
    {
        porcentaje = 0;
    }

    ApexChartEight.updateSeries([porcentaje]);
  
}

function LoadDataDependencia(codigoDependecia)
{
    //DEPENDENCIA

    ApexChartNine.updateOptions({
        xaxis: {
            categories: captionVencimiento[$("#srangodias").val()]
        }
    });

    ApexChartTen.updateOptions({
        xaxis: {
            categories: captionVencimiento[$("#srangodias").val()]
        }
    });

    let dataApexDependencia =
        [
            0,
            0,
            0,
            0,
            0,
        ];

    datosEstadistico.forEach(obj =>
    {
        if (obj.dependencia.trim() == codigoDependecia.trim()) {
            dataApexDependencia[0] += obj.noVen || 0;
            dataApexDependencia[1] += obj.rango1 || 0;
            dataApexDependencia[2] += obj.rango2 || 0;
            dataApexDependencia[3] += obj.rango3 || 0;
            dataApexDependencia[4] += obj.rango4 || 0;
        }
    });

    ApexChartNine.updateSeries([{
        data: dataApexDependencia
    }]);

    let dataApexDependenciaCount =
        [
            0,
            0,
            0,
            0,
            0,
        ];

    dataApexDependenciaCount[0] = datosEstadistico.filter(obj => obj.noVen > 0 && obj.dependencia.trim() == codigoDependecia.trim()).length;
    dataApexDependenciaCount[1] = datosEstadistico.filter(obj => obj.rango1 > 0 && obj.dependencia.trim() == codigoDependecia.trim()).length;
    dataApexDependenciaCount[2] = datosEstadistico.filter(obj => obj.rango2 > 0 && obj.dependencia.trim() == codigoDependecia.trim()).length;
    dataApexDependenciaCount[3] = datosEstadistico.filter(obj => obj.rango3 > 0 && obj.dependencia.trim() == codigoDependecia.trim()).length;
    dataApexDependenciaCount[4] = datosEstadistico.filter(obj => obj.rango4 > 0 && obj.dependencia.trim() == codigoDependecia.trim()).length;

    ApexChartTen.updateSeries([{
        data: dataApexDependenciaCount
    }]);

    let totalCarteraDependencia = 0;
    let totalPendienteDependencia = 0;
    let totalFacturaDependencia = 0;

    totalFacturaDependencia = datosEstadistico.filter(obj => obj.dependencia.trim() == codigoDependecia.trim()).length,

    datosEstadistico.forEach(obj => {
        if (obj.dependencia.trim() == codigoDependecia.trim()) {
            totalCarteraDependencia += (obj.subTotal + obj.valorIva);
            totalPendienteDependencia = totalPendienteDependencia + (obj.noVen + obj.rango1 + obj.rango2 + obj.rango3 + obj.rango4);
        }
    });

    $("#totalCarteraDependencia").text("$" + totalCarteraDependencia.toLocaleString());
    $("#totalPendienteDependencia").text("$" +totalPendienteDependencia.toLocaleString());
    $("#totalFacturaDependencia").text(totalFacturaDependencia);

    let porcentaje = ((totalCarteraDependencia - totalPendienteDependencia) * 100) / totalCarteraDependencia;

    if (totalCarteraDependencia == 0) {
        porcentaje = 0;
    }

    ApexChartEleven.updateSeries([porcentaje]);
}

function ApexOne(dataApexOne)
{


    var options = {
        series: 
        [
            {
                name: 'valor',
                data: [0, 0, 0, 0, 0]
            },
        ],
        chart: {
            type: 'bar',
            height: 250
        },
        plotOptions: {
            bar: {
                horizontal: false,
                columnWidth: '55%',
                endingShape: 'rounded'
            },
        },
        dataLabels: {
            enabled: false
        },
        stroke: {
            show: true,
            width: 2,
            colors: ['transparent']
        },
        xaxis: {
            categories: captionVencimiento[0],
            title: {
                text: 'Días'
            }
        },
        yaxis: {
            title: {
                text: 'Valor'
            }
        },
        fill: {
            opacity: 1
        },
        tooltip: {
            y: {
                formatter: function (val) {
                    return "$ " + val.toLocaleString();
                }
            },
        },
        title: {
            text: 'Análisis de vencimiento',
            FontFace: 'Arial',
            align: 'center'
        }
    };

    ApexCharOne = new ApexCharts(document.querySelector("#apexOne"), options);
    ApexCharOne.render();
}

function ApexTwo(dataApexTwo) {
    var options = {
        series:
            [
                {
                    name: 'Facturas',
                    data: [0, 0, 0, 0, 0]
                },
            ],
        chart: {
            type: 'bar',
            height: 250
        },
        plotOptions: {
            bar: {
                horizontal: false,
                columnWidth: '55%',
                endingShape: 'rounded'
            },
        },
        dataLabels: {
            enabled: false
        },
        stroke: {
            show: true,
            width: 2,
            colors: ['transparent']
        },
        xaxis: {
            categories: captionVencimiento[0],
            title: {
                text: 'Días'
            }
        },
        yaxis: {
            title: {
                text: 'Cantidad'
            }
        },
        colors: "#00C815",
        fill: {
            opacity: 1
        },
        tooltip: {
            y: {
                formatter: function (val) {
                    return val + " Facturas";
                }
            }
        },
        title: {
            text: 'Facturas por días de vencimentos',
            FontFace: 'Arial',
            align: 'center'
        }
    };

    ApexCharTwo = new ApexCharts(document.querySelector("#apexTwo"), options);
    ApexCharTwo.render();
}

function ApexThree(dataApexThree)
{
    var options = {
        series: [0, 0, 0, 0, 0],
        labels: captionVencimiento[0],
        chart: {
            type: 'donut',
        },
        title: {
            text: 'Composición de Facturas por días de vencimiento',
            FontFace: 'Arial',
            align: 'center'
        },
        responsive: [{
            breakpoint: 480,
            options: {
                chart: {
                    width: 200
                },
                legend: {
                    position: 'bottom'
                }
            }
        }]
    };

    ApexCharThree = new ApexCharts(document.querySelector("#apexThree"), options);
    ApexCharThree.render();
}

function ApexFour(dataApexFour)
{
    var options = {
        series: [0, 0, 0, 0, 0],
        labels: ['Sin Gestión', 'Sin Resultado', 'En Programación', 'Pago Autorizado', 'Objetado'],
        chart: {
            type: 'donut',
        },
        title: {
            text: 'Composición de seguimiento cartera',
            FontFace: 'Arial',
            align: 'center'
        },
        responsive: [{
            breakpoint: 480,
            options: {
                chart: {
                    width: 250
                },
                legend: {
                    position: 'bottom'
                }
            }
        }]
    };

    ApexCharFour = new ApexCharts(document.querySelector("#apexFour"), options);
    ApexCharFour.render();
}

function ApexFive(dataApexFive)
{
    var options = {
        series:
            [
                {
                    name: 'Facturas',
                    data: [0, 0, 0, 0, 0]
                },
            ],
        chart: {
            type: 'bar',
            height: 350
        },
        plotOptions: {
            bar: {
                horizontal: false,
                columnWidth: '55%',
                endingShape: 'rounded'
            },
        },
        dataLabels: {
            enabled: false
        },
        stroke: {
            show: true,
            width: 2,
            colors: ['transparent']
        },
        xaxis: {
            categories: ['Sin Gestión', 'Sin Resultado', 'En Programación', 'Pago Autorizado', 'Objetado']

        },
        yaxis: {
            title: {
                text: 'Cantidad'
            }
        },
        colors: "#FEB019",
        fill: {
            opacity: 1
        },
        tooltip: {
            y: {
                formatter: function (val) {
                    return val + " Facturas";
                }
            }
        },
        title: {
            text: 'Facturas por seguimientos',
            FontFace: 'Arial',
            align: 'center'
        }
    };

    ApexCharFive = new ApexCharts(document.querySelector("#apexFive"), options);
    ApexCharFive.render();
}

function ApexSix(dataApexCliente)
{
    var options = {
        series:
            [
                {
                    name: 'Valor',
                    data: [0, 0, 0, 0, 0]
                },
            ],
        chart: {
            type: 'bar',
            height: 250
        },
        plotOptions: {
            bar: {
                horizontal: false,
                columnWidth: '55%',
                endingShape: 'rounded'
            },
        },
        dataLabels: {
            enabled: false
        },
        stroke: {
            show: true,
            width: 2,
            colors: ['transparent']
        },
        xaxis: {
            categories: captionVencimiento[0],
            title: {
                text: 'Días'
            }
        },
        yaxis: {
            title: {
                text: 'Valor'
            }
        },
        fill: {
            opacity: 1
        },
        tooltip: {
            y: {
                formatter: function (val) {
                    return "$ " + val.toLocaleString();
                }
            }
        },
        title: {
            text: 'Análisis de vencimiento',
            FontFace: 'Arial',
            align: 'center'
        }
    };

    ApexChartSix = new ApexCharts(document.querySelector("#apexSix"), options);
    ApexChartSix.render();
}

function ApexSeven(dataApexClienteCount) {
    var options = {
        series:
            [
                {
                    name: 'Valor',
                    data: [0, 0, 0, 0, 0]
                },
            ],
        chart: {
            type: 'bar',
            height: 250
        },
        plotOptions: {
            bar: {
                horizontal: false,
                columnWidth: '55%',
                endingShape: 'rounded'
            },
        },
        dataLabels: {
            enabled: false
        },
        colors: "#00E396",
        stroke: {
            show: true,
            width: 2,
            colors: ['transparent']
        },
        xaxis: {
            categories: captionVencimiento[0],
            title: {
                text: 'Días'
            }
        },
        yaxis: {
            title: {
                text: 'Cantidad'
            }
        },
        fill: {
            opacity: 1
        },
        tooltip: {
            y: {
                formatter: function (val) {
                    return val.toLocaleString();
                }
            }
        },
        title: {
            text: 'Cantidad de Facturas por días de vencimentos',
            FontFace: 'Arial',
            align: 'center'
        }
    };

    ApexChartSeven = new ApexCharts(document.querySelector("#apexSeven"), options);
    ApexChartSeven.render();
}

function ApexEight(dataApexEight)
{
    var options = {
        series: [0],
        chart: {
            height: 250,
            type: 'radialBar',
            toolbar: {
                show: true
            }
        },
        plotOptions: {
            radialBar: {
                startAngle: -135,
                endAngle: 225,
                hollow: {
                    margin: 0,
                    size: '70%',
                    background: '#fff',
                    image: undefined,
                    imageOffsetX: 0,
                    imageOffsetY: 0,
                    position: 'front',
                    dropShadow: {
                        enabled: true,
                        top: 3,
                        left: 0,
                        blur: 4,
                        opacity: 0.24
                    }
                },
                track: {
                    background: '#fff',
                    strokeWidth: '67%',
                    margin: 0, // margin is in pixels
                    dropShadow: {
                        enabled: true,
                        top: -3,
                        left: 0,
                        blur: 4,
                        opacity: 0.35
                    }
                },

                dataLabels: {
                    show: true,
                    name: {
                        offsetY: -10,
                        show: true,
                        color: '#888',
                        fontSize: '17px'
                    },
                    value: {
                        formatter: function (val) {
                            return parseInt(val);
                        },
                        color: '#111',
                        fontSize: '36px',
                        show: true,
                    }
                }
            }
        },
        fill: {
            type: 'gradient',
            gradient: {
                shade: 'dark',
                type: 'horizontal',
                shadeIntensity: 0.5,
                gradientToColors: ['#ABE5A1'],
                inverseColors: true,
                opacityFrom: 1,
                opacityTo: 1,
                stops: [0, 100]
            }
        },
        stroke: {
            lineCap: 'round'
        },
        title: {
            text: 'Porcentaje Cobrado respecto al Total de su Cartera',
            FontFace: 'Arial',
            align: 'center'
        },
        labels: ['Porcentaje'],
    };

    ApexChartEight = new ApexCharts(document.querySelector("#apexEight"), options);
    ApexChartEight.render();
}

function ApexNine() {
    var options = {
        series:
            [
                {
                    name: 'Valor',
                    data: [0, 0, 0, 0, 0]
                },
            ],
        chart: {
            type: 'bar',
            height: 250
        },
        colors: "#FEB019",
        plotOptions: {
            bar: {
                horizontal: false,
                columnWidth: '55%',
                endingShape: 'rounded'
            },
        },
        dataLabels: {
            enabled: false
        },
        stroke: {
            show: true,
            width: 2,
            colors: ['transparent']
        },
        xaxis: {
            categories: captionVencimiento[0],
            title: {
                text: 'Días'
            }
        },
        yaxis: {
            title: {
                text: 'Valor'
            }
        },
        fill: {
            opacity: 1
        },
        tooltip: {
            y: {
                formatter: function (val) {
                    return "$ " + val.toLocaleString();
                }
            }
        },
        title: {
            text: 'Análisis de vencimiento Cliente: ',
            FontFace: 'Arial',
            align: 'center'
        }
    };

    ApexChartNine = new ApexCharts(document.querySelector("#apexNine"), options);
    ApexChartNine.render();
}

function ApexTen() {
    var options = {
        series:
            [
                {
                    name: 'Valor',
                    data: [0, 0, 0, 0, 0]
                },
            ],
        chart: {
            type: 'bar',
            height: 250
        },
        plotOptions: {
            bar: {
                horizontal: false,
                columnWidth: '55%',
                endingShape: 'rounded'
            },
        },
        dataLabels: {
            enabled: false
        },
        colors: "#775DD0",
        stroke: {
            show: true,
            width: 2,
            colors: ['transparent']
        },
        xaxis: {
            categories: captionVencimiento[0],
            title: {
                text: 'Días'
            }
        },
        yaxis: {
            title: {
                text: 'Cantidad'
            }
        },
        fill: {
            opacity: 1
        },
        tooltip: {
            y: {
                formatter: function (val) {
                    return val.toLocaleString();
                }
            }
        },
        title: {
            text: 'Cantidad de Facturas por días de vencimentos',
            FontFace: 'Arial',
            align: 'center'
        }
    };

    ApexChartTen = new ApexCharts(document.querySelector("#apexTen"), options);
    ApexChartTen.render();
}

function ApexEleven() {
    var options = {
        series: [0],
        chart: {
            height: 250,
            type: 'radialBar',
            toolbar: {
                show: true
            }
        },
        plotOptions: {
            radialBar: {
                startAngle: -135,
                endAngle: 225,
                hollow: {
                    margin: 0,
                    size: '70%',
                    background: '#fff',
                    image: undefined,
                    imageOffsetX: 0,
                    imageOffsetY: 0,
                    position: 'front',
                    dropShadow: {
                        enabled: true,
                        top: 3,
                        left: 0,
                        blur: 4,
                        opacity: 0.24
                    }
                },
                track: {
                    background: '#fff',
                    strokeWidth: '67%',
                    margin: 0, // margin is in pixels
                    dropShadow: {
                        enabled: true,
                        top: -3,
                        left: 0,
                        blur: 4,
                        opacity: 0.35
                    }
                },

                dataLabels: {
                    show: true,
                    name: {
                        offsetY: -10,
                        show: true,
                        color: '#888',
                        fontSize: '17px'
                    },
                    value: {
                        formatter: function (val) {
                            return parseInt(val);
                        },
                        color: '#111',
                        fontSize: '36px',
                        show: true,
                    }
                }
            }
        },
        fill: {
            type: 'gradient',
            gradient: {
                shade: 'dark',
                type: 'horizontal',
                shadeIntensity: 0.5,
                gradientToColors: ['#ABE5A1'],
                inverseColors: true,
                opacityFrom: 1,
                opacityTo: 1,
                stops: [0, 100]
            }
        },
        stroke: {
            lineCap: 'round'
        },
        title: {
            text: 'Porcentaje Cobrado respecto al Total de la Cartera',
            FontFace: 'Arial',
            align: 'center'
        },
        labels: ['Porcentaje'],
    };

    ApexChartEleven = new ApexCharts(document.querySelector("#apexEleven"), options);
    ApexChartEleven.render();
}

function ApexRecaudo()
{
    var options = {
        series: [{
            name: 'Cartera',
            data: [0, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0 ,0]
        }, {
            name: 'Recaudo',
            data: [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
        }],
        chart: {
            type: 'bar',
            height: 350
        },
        plotOptions: {
            bar: {
                horizontal: false,
                columnWidth: '55%',
                endingShape: 'rounded'
            },
        },
        dataLabels: {
            enabled: false
        },
        stroke: {
            show: true,
            width: 2,
            colors: ['transparent']
        },
        xaxis: {
            categories: ['Ene','Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct','Nov','Dic'],
        },
        yaxis: {
            title: {
                text: 'Valor'
            }
        },
        fill: {
            opacity: 1
        },
        tooltip: {
            y: {
                formatter: function (val) {
                    return "$ " + val.toLocaleString();
                }
            }
        },
        title: {
            text: 'Recaudo de Cartera desde dd/MM/yyyy hasta dd/MM/yyyy',
            FontFace: 'Arial',
            align: 'center'
        }
    };

    ApexChartRecaudo = new ApexCharts(document.querySelector("#apexRecaudo"), options);
    ApexChartRecaudo.render();

}