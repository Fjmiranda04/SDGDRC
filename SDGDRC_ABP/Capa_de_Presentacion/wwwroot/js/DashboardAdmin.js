//SIDEBAR TOGGLE

var sidebarOpen = false;
var sidebar = document.getElementById("sidebar");

function openSidebar() {
    if (!sidebarOpen) {
        sidebar.classList.add("sidebar-responsive");
        sidebarOpen = true;
    }
}

function closeSidebar() {
    if (sidebarOpen) {
        sidebar.classList.remove("sidebar-responsive");
        sidebarOpen = false;
    }
}


//------- CHARTS ----------

//BAR CHART
var barChartOptions = {
    series: [{
        data: [10, 8, 6]
    }],
    chart: {
        type: 'bar',
        height: 350,
        toolbar: {
            show: false
        },
    },
    colors: [
        "#246dec",
        "#cc3c43",
        "#367952"
       
    ],
    plotOptions: {
        bar: {
            distributed: true,
            borderRadius: 4,
            horizontal: false,
            columWidth: '40%',
        }
    },
    dataLabels: {
        enabled: false
    },
    legend: {
        show: false
    },
    xaxis: {
        categories: ["Plastico", "Carton", "Vidrio" ],
    },
    yaxis: {
        title: {
            text: "Count"
        }

    }
};

var barChar = new ApexCharts(document.querySelector("#bar-chart"), barChartOptions);
barChar.render();

//AREA CHART
// Realizar una solicitud AJAX para obtener los datos de usuarios
fetch('/Usuario/GetUserCount')
    .then(response => response.json())
    .then(data => {
        // Una vez que se reciben los datos, actualizar el gráfico con los datos de usuarios recibidos
        updateChartWithData(data);
    })
    .catch(error => console.error('Error fetching user data for chart:', error));

function updateChartWithData(userData) {
    // Actualizar los datos del gráfico con los datos de usuarios recibidos
    areaChartOptions.series[0].data = userData.newUsers; // Datos de nuevos usuarios
    areaChartOptions.series[1].data = userData.activeUsers; // Datos de usuarios activos

    // Renderizar nuevamente el gráfico con los datos actualizados
    areaChart.updateSeries(areaChartOptions.series);
}

var areaChartOptions = {
    series: [{
        name: 'New Users',
        data: []
    }, {
        name: 'Active Users',
        data: []
    }],
    chart: {
        height: 350,
        type: 'area',
        toolbar: {
            show: false
        },
    },
    colors: [
        "#cc3c43", "#367952"],
    dataLabels: {
        enabled: false,
    },
    stroke: {
        curve: 'smooth'
    },
    labels: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul"], // Puedes personalizar las etiquetas según tus necesidades
    markers: {
        size: 0
    },
    yaxis: [
        {
            title: {
                text: 'New Users',
            },
        },
        {
            opposite: true,
            title: {
                text: 'Active Users',
            },
        },
    ],
    tooltip: {
        shared: true,
        intersect: false,
    }
};

var areaChart = new ApexCharts(document.querySelector("#area-chart"), areaChartOptions);
areaChart.render();
