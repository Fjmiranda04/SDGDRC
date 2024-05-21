$("#form-create-pqrsf").validate({
    rules: {
        Fecha: {
            required: true,
        },
        IdSituacion: {
            required: true
        },
        NroIdeCli:{
            required: true
        },
        IdContacto: {
            required: true,
        },
        Asunto: {
            required: true,
            minlength: 4,
            maxlength: 50,
        },
        Descripcion : {
            required: true,
            minlength: 3,
            maxlength: 8000
        },
    },
    messages:{
        Fecha: {
            required: "Este campo es requerido",
        },
        IdSituacion: {
            required: "Este campo es requerido",
        },
        NroIdeCli:{
            required: "Este campo es requerido",
        },
        IdContacto: {
            required: "Este campo es requerido",
        },
        Asunto: {
            required: "Este campo es requerido",
            minlength: "Mínimo son 4 caracteres",
            maxlength: "Máximo son 50 caracteres",
        },
        Descripcion : {
            required: "Este campo es requerido",
            minlength: "Mínimo 4 caracteres",
            maxlength: "Máximo 7000 caracteres"
        },
    },
    errorElement: "div",
    errorPlacement: function (error, element) {
          // Add the `help-block` class to the error element
        error.addClass("col-12 text-danger");
 
        if (element.prop( "type" ) === "checkbox") {
            error.insertAfter(element.parent("label") );
        } else {
            error.insertAfter(element);
        }
    },
    highlight: function ( element, errorClass, validClass ) {
        $( element ).parents( ".col-sm-10" ).addClass( "has-error" ).removeClass( "has-success" );
    },
    unhighlight: function (element, errorClass, validClass) {
        $( element ).parents( ".col-sm-10" ).addClass( "has-success" ).removeClass( "has-error" );  
    }
});


$("#form-contacto").validate({
    rules:{
        NombreContacto: {
            required: true,
        },
        Celular: {
            required: true
        },
        Telefono:{
            required: true
        },
        Email: {
            required: true,
            email: true
        },
    },
    messages: {
        NombreContacto: {
            required: "Este campo es requerido",
        },
        Celular: {
            required: "Este campo es requerido",
        },
        Telefono:{
            required: "Este campo es requerido",
        },
        Email: {
            required: "Este campo es requerido",
            email: "Email no válido"
        },
    },
    errorElement: "div",
    errorPlacement: function (error, element) {
          // Add the `help-block` class to the error element
        error.addClass("col-12 text-danger");
 
        if (element.prop( "type" ) === "checkbox") {
            error.insertAfter(element.parent("label") );
        } else {
            error.insertAfter(element);
        }
    },
    highlight: function ( element, errorClass, validClass ) {
        $( element ).parents( ".col-sm-10" ).addClass( "has-error" ).removeClass( "has-success" );
    },
    unhighlight: function (element, errorClass, validClass) {
        $( element ).parents( ".col-sm-10" ).addClass( "has-success" ).removeClass( "has-error" );  
    }
});