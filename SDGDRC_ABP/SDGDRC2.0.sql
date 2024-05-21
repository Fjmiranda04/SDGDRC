-- Creaci�n de la base de datos SDGDRC
CREATE DATABASE SDGDRC;
GO

-- Uso de la base de datos SDGDRC
USE SDGDRC;
GO

-- Creaci�n de la tabla Usuario con ID_Usuario autoincremental
CREATE TABLE Usuario (
    ID_Usuario INT PRIMARY KEY IDENTITY,
    Nombre VARCHAR(50),
    Apellido VARCHAR(50),
    Email VARCHAR(100),
    Tipo VARCHAR(20)
);
GO

-- Creaci�n de la tabla Credenciales para almacenar el ID de Usuario y la contrase�a encriptada
CREATE TABLE Credenciales (
    ID_Usuario INT PRIMARY KEY,
    Contrase�a VARCHAR(255) -- Aqu� almacenaremos la contrase�a encriptada
);
GO

-- Creaci�n de la tabla Voluntario
CREATE TABLE Voluntario (
    ID_Voluntario INT PRIMARY KEY,
    Ubicaci�n VARCHAR(100),
    ID_Usuario INT,
    FOREIGN KEY (ID_Usuario) REFERENCES Usuario(ID_Usuario)
);
GO

-- Creaci�n de la tabla Coordinador
CREATE TABLE Coordinador (
    ID_Coordinador INT PRIMARY KEY,
    �rea_de_Responsabilidad VARCHAR(100),
    ID_Usuario INT,
    FOREIGN KEY (ID_Usuario) REFERENCES Usuario(ID_Usuario)
);
GO

-- Creaci�n de la tabla Administrador
CREATE TABLE Administrador (
    ID_Administrador INT PRIMARY KEY,
    ID_Usuario INT,
    FOREIGN KEY (ID_Usuario) REFERENCES Usuario(ID_Usuario)
);
GO

-- Creaci�n de la tabla Ruta
CREATE TABLE Ruta (
    ID_Ruta INT PRIMARY KEY,
    Fecha DATE,
    Coordinador_Asociado INT,
    Voluntarios_Asociados INT,
    FOREIGN KEY (Coordinador_Asociado) REFERENCES Coordinador(ID_Coordinador),
    FOREIGN KEY (Voluntarios_Asociados) REFERENCES Voluntario(ID_Voluntario)
);
GO

-- Creaci�n de la tabla Registro_de_Residuos
CREATE TABLE Registro_de_Residuos (
    ID_Registro INT PRIMARY KEY,
    Fecha_Hora DATETIME,
    Tipo VARCHAR(50),
    Cantidad INT,
    Ubicaci�n VARCHAR(100),
    Voluntario_Registrador INT,
    FOREIGN KEY (Voluntario_Registrador) REFERENCES Voluntario(ID_Voluntario)
);
GO

-- Creaci�n de la tabla Informe
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
    @Contrase�a VARCHAR(255),
    @AreaResponsabilidad VARCHAR(100) = NULL, -- Nuevo par�metro para el �rea de responsabilidad (predeterminado NULL)
    @Ubicaci�n VARCHAR(100) = NULL
)
AS
BEGIN
    -- Insertar datos del usuario en la tabla Usuario
    INSERT INTO Usuario (Nombre, Apellido, Email, Tipo)
    VALUES (@Nombre, @Apellido, @Email, @Tipo);

    -- Obtener el ID del usuario reci�n insertado
    DECLARE @ID_Usuario INT;
    SET @ID_Usuario = SCOPE_IDENTITY();

    -- Insertar el ID del usuario y la contrase�a encriptada en la tabla Credenciales
    INSERT INTO Credenciales (ID_Usuario, Contrase�a)
    VALUES (@ID_Usuario, @Contrase�a);

    -- Insertar en las tablas correspondientes seg�n el tipo de usuario
    IF @Tipo = 'Voluntario'
    BEGIN
        INSERT INTO Voluntario (ID_Voluntario, Ubicaci�n, ID_Usuario)
        VALUES (@ID_Usuario, @Ubicaci�n, @ID_Usuario);
    END
    ELSE IF @Tipo = 'Coordinador'
    BEGIN
        INSERT INTO Coordinador (ID_Coordinador, �rea_de_Responsabilidad, ID_Usuario)
        VALUES (@ID_Usuario, @AreaResponsabilidad, @ID_Usuario);
    END
    ELSE IF @Tipo = 'Administrador'
    BEGIN
        INSERT INTO Administrador (ID_Administrador, ID_Usuario)
        VALUES (@ID_Usuario, @ID_Usuario);
    END
END;

select U.Email, C.Contrase�a from usuario U LEFT JOIN  credenciales C ON U.ID_Usuario = C.ID_Usuario;