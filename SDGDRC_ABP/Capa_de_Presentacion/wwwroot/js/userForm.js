$(document).ready(function () {
    $('#Tipo').change(function () {
        if ($(this).val() === 'Voluntario') {
            $('#ubicacionDiv').show(); // Mostrar el campo de ubicación
            $('#areaResponsabilidadDiv').hide(); // Ocultar el campo de área de responsabilidad
        } else if ($(this).val() === 'Coordinador') {
            $('#ubicacionDiv').hide();
            $('#areaResponsabilidadDiv').show(); // Mostrar el campo de área de responsabilidad
        } else {
            $('#ubicacionDiv').hide();
            $('#areaResponsabilidadDiv').hide();
        }
    });
});
