-- Creación de la base de datos SDGDRC
CREATE DATABASE SDGDRC;
GO

-- Uso de la base de datos SDGDRC
USE SDGDRC;
GO

-- Creación de la tabla Usuario con ID_Usuario autoincremental
CREATE TABLE Usuario (
    ID_Usuario INT PRIMARY KEY IDENTITY,
    Nombre VARCHAR(50),
    Apellido VARCHAR(50),
    Email VARCHAR(100),
    Tipo VARCHAR(20)
);
GO

-- Creación de la tabla Credenciales para almacenar el ID de Usuario y la contraseña encriptada
CREATE TABLE Credenciales (
    ID_Usuario INT PRIMARY KEY,
    Contraseña VARCHAR(255) -- Aquí almacenaremos la contraseña encriptada
);
GO

-- Creación de la tabla Voluntario
CREATE TABLE Voluntario (
    ID_Voluntario INT PRIMARY KEY,
    Ubicación VARCHAR(100),
    ID_Usuario INT,
    FOREIGN KEY (ID_Usuario) REFERENCES Usuario(ID_Usuario)
);
GO

-- Creación de la tabla Coordinador
CREATE TABLE Coordinador (
    ID_Coordinador INT PRIMARY KEY,
    Área_de_Responsabilidad VARCHAR(100),
    ID_Usuario INT,
    FOREIGN KEY (ID_Usuario) REFERENCES Usuario(ID_Usuario)
);
GO

-- Creación de la tabla Administrador
CREATE TABLE Administrador (
    ID_Administrador INT PRIMARY KEY,
    ID_Usuario INT,
    FOREIGN KEY (ID_Usuario) REFERENCES Usuario(ID_Usuario)
);
GO

-- Creación de la tabla Ruta
CREATE TABLE Ruta (
    ID_Ruta INT PRIMARY KEY,
    Fecha DATE,
    Coordinador_Asociado INT,
    Voluntarios_Asociados INT,
    FOREIGN KEY (Coordinador_Asociado) REFERENCES Coordinador(ID_Coordinador),
    FOREIGN KEY (Voluntarios_Asociados) REFERENCES Voluntario(ID_Voluntario)
);
GO

-- Creación de la tabla Registro_de_Residuos
CREATE TABLE Registro_de_Residuos (
    ID_Registro INT PRIMARY KEY,
    Fecha_Hora DATETIME,
    Tipo VARCHAR(50),
    Cantidad INT,
    Ubicación VARCHAR(100),
    Voluntario_Registrador INT,
    FOREIGN KEY (Voluntario_Registrador) REFERENCES Voluntario(ID_Voluntario)
);
GO

-- Creación de la tabla Informe
CREATE TABLE Informe (
    ID_Informe INT PRIMARY KEY,
    FechaCreacion DATETIME,
    Encargado_ID INT,
    RegistroResiduo_ID INT,
    FOREIGN KEY (Encargado_ID) REFERENCES Usuario(ID_Usuario),
    FOREIGN KEY (RegistroResiduo_ID) REFERENCES Registro_de_Residuos(ID_Registro)
);
GO

----------------------------------------------------------------------------------------------

-- Procedimiento almacenado para crear un nuevo usuario
ALTER PROCEDURE CrearUsuario (
    @Nombre VARCHAR(50),
    @Apellido VARCHAR(50),
    @Email VARCHAR(100),
    @Tipo VARCHAR(20),
    @Contraseña VARCHAR(255),
    @AreaResponsabilidad VARCHAR(100) = NULL, -- Nuevo parámetro para el área de responsabilidad (predeterminado NULL)
    @Ubicación VARCHAR(100) = NULL
)
AS
BEGIN
    -- Insertar datos del usuario en la tabla Usuario
    INSERT INTO Usuario (Nombre, Apellido, Email, Tipo)
    VALUES (@Nombre, @Apellido, @Email, @Tipo);

    -- Obtener el ID del usuario recién insertado
    DECLARE @ID_Usuario INT;
    SET @ID_Usuario = SCOPE_IDENTITY();

    -- Insertar el ID del usuario y la contraseña encriptada en la tabla Credenciales
    INSERT INTO Credenciales (ID_Usuario, Contraseña)
    VALUES (@ID_Usuario, @Contraseña);

    -- Insertar en las tablas correspondientes según el tipo de usuario
    IF @Tipo = 'Voluntario'
    BEGIN
        INSERT INTO Voluntario (ID_Voluntario, Ubicación, ID_Usuario)
        VALUES (@ID_Usuario, @Ubicación, @ID_Usuario);
    END
    ELSE IF @Tipo = 'Coordinador'
    BEGIN
        INSERT INTO Coordinador (ID_Coordinador, Área_de_Responsabilidad, ID_Usuario)
        VALUES (@ID_Usuario, @AreaResponsabilidad, @ID_Usuario);
    END
    ELSE IF @Tipo = 'Administrador'
    BEGIN
        INSERT INTO Administrador (ID_Administrador, ID_Usuario)
        VALUES (@ID_Usuario, @ID_Usuario);
    END
END;

select U.Email, C.Contraseña from usuario U LEFT JOIN  credenciales C ON U.ID_Usuario = C.ID_Usuario;