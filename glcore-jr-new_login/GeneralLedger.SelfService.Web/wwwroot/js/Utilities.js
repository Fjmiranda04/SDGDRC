const ToastAlert = Swal.mixin({
    toast: true,
    position: 'top-end',
    showConfirmButton: false,
    timer: 3000,
    timerProgressBar: true,
    didOpen: (toast) => {
        toast.addEventListener('mouseenter', Swal.stopTimer)
        toast.addEventListener('mouseleave', Swal.resumeTimer)
    }
});

function LoaderScreenShow(){
    let screen = $('#loading-screen');
    screen.fadeIn();
}

function LoaderScreenHide(){
    let screen = $('#loading-screen');
    screen.fadeOut();
}


const ConvertMonth = function (num)
{
    return num.toString().padStart(2, '0');
}

// Función para formatear fechas en formato dd/mm/yyyy
const formatDate = function (date) {
    return [
        (date.getDate() + '').padStart(2, '0'),
        ((date.getMonth() + 1) + '').padStart(2, '0'),
        date.getFullYear()
    ].join('/');
};

const formatDate2 = function (fecha) {
    var mes = (fecha.getMonth() + 1).toString().padStart(2, '0'); // Obtener el mes con dos dígitos
    var dia = fecha.getDate().toString().padStart(2, '0'); // Obtener el día con dos dígitos
    var anio = fecha.getFullYear();
    return anio + '-' + mes + '-' + dia;
}

const formatterPeso = new Intl.NumberFormat('es-CO', {
    style: 'currency',
    currency: 'COP',
    minimumFractionDigits: 0
});

const formatFecha3 = function (cadenaFecha)
{
    var fecha = new Date(cadenaFecha);

    var dia = fecha.getDate();
    var mes = fecha.getMonth() + 1; // Sumamos 1 porque los meses comienzan desde 0
    var anio = fecha.getFullYear();
    var hora = fecha.getHours();
    var minutos = fecha.getMinutes();
    var ampm = hora >= 12 ? 'PM' : 'AM'; // Determina si es AM o PM
    hora = hora % 12; // Convierte la hora a un formato de 12 horas
    hora = hora ? hora : 12; // Si la hora es 0, se convierte a 12 en formato de 12 horas
    minutos = minutos < 10 ? '0' + minutos : minutos; // Agrega un cero si los minutos son menores a 10

    var fechaFormateada = dia + '/' + mes + '/' + anio + ' ' + hora + ':' + minutos + ' ' + ampm;

    return fechaFormateada;
}

const ValidateForms = function (formId)
{
    let form = $(formId)[0];

    if (form.checkValidity() === false) {
        event.preventDefault();
        event.stopPropagation();
    }

    form.classList.add('was-validated');

    if (form.checkValidity()) {
        return true;
    }

    return false;
}