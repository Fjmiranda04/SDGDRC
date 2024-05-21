

--DECLARE @Operacion VARCHAR(20) = 'GETARTICULOS';
--DECLARE @Escala VARCHAR(20) = 'ARVENTA'; -- Puedes cambiar este valor según tus necesidades
-- Puedes definir los parámetros adicionales como @FechaI, @FechaF, etc., si son necesarios

--EXEC WEBGLSS_SP_PEDIDOS 
  --  @Operacion = @Operacion,
    --@Escala = @Escala;


	DECLARE @Operacion VARCHAR(20) = 'GETSERVICIOS';
DECLARE @Escala VARCHAR(20) = 'ARVENTA'; -- Puedes cambiar este valor según tus necesidades

EXEC WEBGLSS_SP_PEDIDOS  
    @Operacion = @Operacion,
    @Escala = @Escala;

	select * from accmovpedidos
	EXEC WEBGLSS_SP_PEDIDOS 
    @Operacion = 'GETPED',
	 @NroIdCliente  = ' ',
	@FechaI = '2023-08-18 00:00:00.000',
	@FechaF = '2024-04-19 00:00:00.000';



EXEC sp_help  'accpedidos'
EXEC sp_help  'accmovpedidos'
select Cli.clinom, Cli.clinit from clientes CLI WHERE clinom = 'ROJAS HERRERA JAIRO ELIECER'

select * from clientes

select * from accPedidos
select * from accmovpedidos
EXEC sp_spaceused  accpedidos


-- Agregar una columna de clave foránea en la tabla accmovpedidos
ALTER TABLE accmovpedidos
ADD CONSTRAINT FK_accmovpedidos_accpedidos FOREIGN KEY (numfac) 
REFERENCES accpedidos(nrofac);

-- Asegurarse de que nrofac sea una clave primaria en la tabla accpedidos
ALTER TABLE accpedidos
ADD CONSTRAINT PK_accpedidos PRIMARY KEY (nrofac);




--DECLARE @NroIdCliente VARCHAR(20) = ' ';
--DECLARE @FechaI DATE= '2023-08-18 00:00:00.000';
--DECLARE @FechaF DATE= '2024-04-19 00:00:00.000';

SELECT 
        PED.nrofac AS NumeroPedido,
        PED.fecfac AS Fecha,
        CLI.clinom AS Cliente,
        PED.fechaReq AS FechaRequerido,
        PED.vlrfac AS Total,
        PED.subtotal AS SubTotal,
        PED.iva AS ValorIva,
        PED.detalle AS Descripcion,
        CASE 
            WHEN PED.estado = '0' THEN 'GENERADO' 
            WHEN PED.estado = '1' THEN 'AUTORIZADO' 
            WHEN PED.estado = '2' THEN 'NO AUTORIZADO'
            WHEN PED.estado = '3' THEN 'FACTURADO' 
            ELSE 'REMISIONADO' 
        END AS Estado,
        PRO.ciunom AS Ciudad,
        SUC.direccion AS Direccion,
        PED.Calificacion AS Calificacion,
        DET.codart AS CodigoArticulo,
        DET.detalle AS Detalle,
        DET.cantid AS Cantidad
    FROM accpedidos PED
    LEFT JOIN clientes CLI ON PED.codcli = CLI.clicod
    LEFT JOIN prociudades PRO ON PRO.ciucod = CLI.cliCodCiud
    LEFT JOIN proPaises PAI ON CLI.cliPais = PAI.codPais
    LEFT JOIN vendedores VEN ON PED.vendedor = VEN.vencod 
    LEFT JOIN Sucursales SUC ON PED.cxc_Id_Sucursal = SUC.id_Sucursal
    LEFT JOIN ProZona ZON ON SUC.Barrio = ZON.CodZona 
    LEFT JOIN (
        SELECT numfac, codart, detalle, cantid
        FROM accmovpedidos
    ) DET ON PED.nrofac = DET.numfac
    WHERE PED.fecfac BETWEEN @FechaI AND @FechaF 
    AND CLI.clinit = CASE WHEN @NroIdCliente = '' THEN CLI.clinit ELSE @NroIdCliente END


	


    DECLARE @NroIdCliente VARCHAR(20) = '1010120607';
DECLARE @FechaI DATE= '2023-08-18 00:00:00.000';
DECLARE @FechaF DATE= '2024-04-19 00:00:00.000';

SELECT 
    PED.nrofac AS NumeroPedido,
    MAX(PED.fecfac) AS Fecha,
    CLI.clinom AS Cliente,
    MAX(PED.fechaReq) AS FechaRequerido,
    MAX(PED.vlrfac) AS Total,
    MAX(PED.subtotal) AS SubTotal,
    MAX(PED.iva) AS ValorIva,
    MAX(PED.detalle) AS Descripcion,
    CASE 
        WHEN MAX(PED.estado) = '0' THEN 'GENERADO' 
        WHEN MAX(PED.estado) = '1' THEN 'AUTORIZADO' 
        WHEN MAX(PED.estado) = '2' THEN 'NO AUTORIZADO'
        WHEN MAX(PED.estado) = '3' THEN 'FACTURADO' 
        ELSE 'REMISIONADO' 
    END AS Estado,
    MAX(PRO.ciunom) AS Ciudad,
    MAX(SUC.direccion) AS Direccion,
    MAX(PED.Calificacion) AS Calificacion,
    DET.codart AS CodigoArticulo,
    DET.detalle AS Detalle,
    DET.cantid AS Cantidad
FROM 
    accpedidos PED
LEFT JOIN 
    clientes CLI ON PED.codcli = CLI.clicod
LEFT JOIN 
    prociudades PRO ON PRO.ciucod = CLI.cliCodCiud
LEFT JOIN 
    proPaises PAI ON CLI.cliPais = PAI.codPais
LEFT JOIN 
    vendedores VEN ON PED.vendedor = VEN.vencod 
LEFT JOIN 
    Sucursales SUC ON PED.cxc_Id_Sucursal = SUC.id_Sucursal
LEFT JOIN 
    ProZona ZON ON SUC.Barrio = ZON.CodZona 
LEFT JOIN 
    (
        SELECT 
            numfac, 
            codart, 
            detalle, 
            cantid
        FROM 
            accmovpedidos
    ) DET ON PED.nrofac = DET.numfac
WHERE 
    PED.fecfac BETWEEN @FechaI AND @FechaF 
    AND CLI.clinit = CASE WHEN @NroIdCliente = '' THEN CLI.clinit ELSE @NroIdCliente END
GROUP BY 
    PED.nrofac, 
    DET.codart, 
    DET.detalle, 
    DET.cantid





    SELECT 
        CLI.clicod AS ClienteID,
        CLI.clinom AS Cliente,
        PED.nrofac AS NumeroPedido,
        MAX(PED.fecfac) AS Fecha,
        PED.fechaReq AS FechaRequerido,
        SUM(PED.vlrfac) AS Total,
        SUM(PED.subtotal) AS SubTotal,
        SUM(PED.iva) AS ValorIva,
         STRING_AGG(CAST(PED.detalle AS nvarchar(max)), ', ') AS Descripcion,
        CASE 
            WHEN PED.estado = '0' THEN 'GENERADO' 
            WHEN PED.estado = '1' THEN 'AUTORIZADO' 
            WHEN PED.estado = '2' THEN 'NO AUTORIZADO'
            WHEN PED.estado = '3' THEN 'FACTURADO' 
            ELSE 'REMISIONADO' 
        END AS Estado,
        PRO.ciunom AS Ciudad,
        SUC.direccion AS Direccion,
        PED.Calificacion AS Calificacion
    FROM accpedidos PED
    LEFT JOIN clientes CLI ON PED.codcli = CLI.clicod
    LEFT JOIN prociudades PRO ON PRO.ciucod = CLI.cliCodCiud
    LEFT JOIN proPaises PAI ON CLI.cliPais = PAI.codPais
    LEFT JOIN vendedores VEN ON PED.vendedor = VEN.vencod 
    LEFT JOIN Sucursales SUC ON PED.cxc_Id_Sucursal = SUC.id_Sucursal
    LEFT JOIN ProZona ZON ON SUC.Barrio = ZON.CodZona 
    WHERE PED.fecfac BETWEEN @FechaI AND @FechaF 
    AND CLI.clinit = CASE WHEN @NroIdCliente = '' THEN CLI.clinit ELSE @NroIdCliente END
    GROUP BY CLI.clicod, CLI.clinom, PED.nrofac, PED.fechaReq, PED.estado, PRO.ciunom, SUC.direccion, PED.Calificacion

	
		
    SELECT 
        PED.nrofac AS NumeroPedido,
        PED.fecfac AS Fecha,
        CLI.clinom AS Cliente,
        PED.fechaReq AS FechaRequerido,
        PED.vlrfac AS Total,
        PED.subtotal AS SubTotal,
        PED.iva AS ValorIva,
        STRING_AGG(CAST(PED.detalle AS nvarchar(max)), ', ') AS Descripcion,
        CASE 
            WHEN PED.estado = '0' THEN 'GENERADO' 
            WHEN PED.estado = '1' THEN 'AUTORIZADO' 
            WHEN PED.estado = '2' THEN 'NO AUTORIZADO'
            WHEN PED.estado = '3' THEN 'FACTURADO'
            ELSE 'REMISIONADO' 
        END AS Estado,
        PRO.ciunom AS Ciudad,
        SUC.direccion AS Direccion,
        PED.Calificacion AS Calificacion			
    FROM 
        accpedidos PED
    LEFT JOIN 
        clientes CLI ON PED.codcli = CLI.clicod
    LEFT JOIN 
        prociudades PRO ON PRO.ciucod = CLI.cliCodCiud
    LEFT JOIN 
        proPaises PAI ON CLI.cliPais = PAI.codPais
    LEFT JOIN 
        vendedores VEN ON PED.vendedor = VEN.vencod 
    LEFT JOIN 
        Sucursales SUC ON PED.cxc_Id_Sucursal = SUC.id_Sucursal
    LEFT JOIN 
        ProZona ZON ON SUC.Barrio = ZON.CodZona 
    WHERE 
        PED.fecfac BETWEEN @FechaI AND @FechaF 
        AND CLI.clinit = CASE WHEN @NroIdCliente = '' THEN CLI.clinit ELSE @NroIdCliente END
    GROUP BY 
        PED.nrofac,
        PED.fecfac,
        CLI.clinom,
        PED.fechaReq,
        PED.vlrfac,
        PED.subtotal,
        PED.iva,
        PED.estado,
        PRO.ciunom,
        SUC.direccion,
        PED.Calificacion
   

   


   

   EXEC WEBGLSS_SP_PEDIDOS 
    @Operacion = 'GETPED',
	 @NroIdCliente  = ' ',
	@FechaI = '2023-08-18 00:00:00.000',
	@FechaF = '2024-04-19 00:00:00.000';

	EXEC WEBGLSS_SP_PEDIDOS 
    @Operacion = 'GETDET',
	@NroFac = '00000022';