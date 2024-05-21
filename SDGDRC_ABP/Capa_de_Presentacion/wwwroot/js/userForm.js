$(document).ready(function () {
    $('#Tipo').change(function () {
        if ($(this).val() === 'Voluntario') {
            $('#ubicacionDiv').show(); // Mostrar el campo de ubicaci�n
            $('#areaResponsabilidadDiv').hide(); // Ocultar el campo de �rea de responsabilidad
        } else if ($(this).val() === 'Coordinador') {
            $('#ubicacionDiv').hide();
            $('#areaResponsabilidadDiv').show(); // Mostrar el campo de �rea de responsabilidad
        } else {
            $('#ubicacionDiv').hide();
            $('#areaResponsabilidadDiv').hide();
        }
    });
});
