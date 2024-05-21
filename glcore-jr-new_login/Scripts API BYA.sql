IF OBJECT_ID('[dbo].[TrackRemisionesPedidos]') IS NULL
BEGIN
	CREATE TABLE [dbo].[TrackRemisionesPedidos]
	(
		Id			INT IDENTITY(1,1)	NOT NULL,
		Pedido		VARCHAR(20)	NOT NULL DEFAULT (''),
		Fecha		DATETIME	NOT NULL DEFAULT ('19000101'),
		Remision	VARCHAR(20) NOT NULL DEFAULT (''),
	) 
END
GO

IF NOT EXISTS ( select * from dbo.syscolumns where id = object_id(N'[dbo].[accpedidos]') and OBJECTPROPERTY(id, N'IsUserTable') = 1 and  name = 'CodigoExtApi')
	ALTER TABLE accpedidos ADD CodigoExtApi VARCHAR(20) DEFAULT '' NOT NULL
GO

IF NOT EXISTS(SELECT * FROM SYS.types WHERE NAME = 'WEBGLSS_TypeApiDetallePedido') 
BEGIN
	CREATE TYPE [dbo].[WEBGLSS_TypeApiDetallePedido] AS TABLE(  								
			 		 CodigoArticulo						VARCHAR(800)			
					,ReferenciaArticulo					VARCHAR(20)			
			 		,CantidadArticulo					NUMERIC(18,2)
					,CostoUnitarioArticulo				NUMERIC(18,2)
					,ValorUnitarioArticulo				NUMERIC(18,2)
					,PorcentajeIva						NUMERIC(18,2)
					,MedidaArticulo						VARCHAR(4)
					,TipoArticulo						VARCHAR(3)
				);
END
GO

IF OBJECT_ID(N'dbo.WEBGLSS_SP_APIAYB') IS NULL
BEGIN
    PRINT 'Create procedure : dbo.WEBGLSS_SP_APIAYB'
    EXECUTE('CREATE PROCEDURE dbo.WEBGLSS_SP_APIAYB AS RETURN 0') 
END
GO

PRINT 'Alter procedure : dbo.WEBGLSS_SP_APIAYB'
GO

ALTER PROCEDURE [dbo].[WEBGLSS_SP_APIAYB] 
     @Operacion			VARCHAR(20) = ''
	,@CodigoPedido	    VARCHAR(20) = ''
	,@NumeroPedido	    VARCHAR(20) = ''
	,@NitCliente		VARCHAR(20) = ''
	,@Observacion		VARCHAR(250) = ''
	,@FechaPedido		DATETIME	= '19000101'
	,@dtDetallePedido WEBGLSS_TypeApiDetallePedido READONLY
AS
BEGIN

	DECLARE @MENSAJE VARCHAR(500)='',@MENSAJE2 VARCHAR(500)=''
    BEGIN TRANSACTION -- O solo BEGIN TRAN
    BEGIN TRY

		IF @Operacion = 'SAVE_PEDIDO'
		BEGIN
		
			DECLARE @CodigoCliente VARCHAR(20) = '', @TipoCliente VARCHAR(20) = '',@ValorTotal NUMERIC(18,2) = 0,@SubTotal NUMERIC(18,2) = 0,@Iva NUMERIC(18,2) = 0, @Descuento NUMERIC(18,2) = 0,
					@Fuente VARCHAR(4) = '', @Dependencia VARCHAR(4) = '', @Escala VARCHAR(4) = ''

			EXEC Proc_Buscar_Consecutivo '44' ,@NumeroPedido OUTPUT ,@Fuente OUTPUT ,'ADMIN'

			SELECT @CodigoCliente = clicod, @TipoCliente = CliTipoCli, @Escala = cliesc
			FROM clientes WHERE clinit = @NitCliente

			SELECT TOP(1) @Dependencia = depcod FROM prodepende WHERE delmrk = 1

			INSERT INTO accmovpedidos 
			(
				numfac
				,codart
				,tipdoc
				,cantid
				,detalle
				,medida
				,vlruni
				,tipmov
				,ctainv
				,ctacos
				,ctaing
				,ivaart
				,costo
				,movdep
				,MovEsc
				,PorDescuento
				,vlriva
				,dsubtotal
			)
			SELECT 
				@NumeroPedido
				,CodigoArticulo
				,'FR'
				,CantidadArticulo
				, ART.arespe 
				,MedidaArticulo
				,ValorUnitarioArticulo
				, TipoArticulo 
				,''
				,''
				,''
				,PorcentajeIva
				,0
				,@Dependencia
				,@Escala
				,0
				,((CantidadArticulo * ValorUnitarioArticulo)*(PorcentajeIva/100))
				,(CantidadArticulo * ValorUnitarioArticulo)
			FROM @dtDetallePedido
			INNER JOIN accglArti ART ON CodigoArticulo = ART.arcod
			WHERE TipoArticulo = 'INV' 
			UNION ALL
			SELECT 
				@NumeroPedido
				,CodigoArticulo
				,'FR'
				,CantidadArticulo
				, TRA.tranom 
				,MedidaArticulo
				,ValorUnitarioArticulo
				, TipoArticulo 
				,''
				,''
				,''
				,PorcentajeIva
				,0
				,@Dependencia
				,@Escala
				,0
				,((CantidadArticulo * ValorUnitarioArticulo)*(PorcentajeIva/100))
				,(CantidadArticulo * ValorUnitarioArticulo)
			FROM @dtDetallePedido
			INNER JOIN Trabajos TRA ON CodigoArticulo = TRA.tracod
			WHERE TipoArticulo = 'SER'
			

			SELECT @ValorTotal = SUM(dsubtotal+vlrIva), @Iva = SUM(vlrIva), @SubTotal = SUM(dsubtotal)
			FROM accmovpedidos WHERE numfac = @NumeroPedido


			INSERT INTO accpedidos 
			(
				nrofac
				,tipodoc
				,tipocli
				,codcli
				,fecfac
				,venfac
				,vlrfac
				,saldo
				,descuento
				,estado
				,subtotal
				,iva
				,flete
				,clitipo
				,dependencia
				,vlrdescuento
				,_nivainc
				,codUsuario
				,user_save
				,REDONDEO
				,cxc_Id_Sucursal
				,detalle
				,vendedor
				,formaPago
				,fechaReq
				,solicitante
				,CodigoExtApi
			)
			VALUES 
			(
				@NumeroPedido
				,'FR'
				,@tipoCLiente
				,@CodigoCliente
				,@FechaPedido
				,0
				,@ValorTotal
				,@ValorTotal
				,@descuento
				,0
				,@subtotal
				,@Iva
				,0
				,@tipoCLiente
				,@Dependencia
				,@descuento
				,0
				,'ADMIN'
				,'ADMIN'
				,0
				,0
				,@Observacion
				,''
				,''
				,@FechaPedido
				,''
				,@CodigoPedido
			)


			SELECT 
				 nrofac			AS NumeroPedido
				,@CodigoPedido	AS CodigoPedido
				,@NitCliente	AS NitCliente
				,fecfac			AS FechaPedido
				,subtotal		AS SubTotalPedido
				,iva			AS IvaPedido
				,vlrfac			AS TotalPedido
			FROM accPedidos WHERE nrofac = @NumeroPedido

		END


		IF @Operacion = 'GET_T_PEDIDOS'
		BEGIN

			SELECT
				 PED.CodigoExtApi AS CodigoPedido
				,PED.nrofac AS NumeroPedido
				,CLI.clinit AS NitCliente
			FROM accPedidos PED
			LEFT JOIN clientes CLI ON PED.codcli = CLI.clicod
			WHERE (SELECT COUNT(*) FROM inremisiones WHERE remtipo = 'RM' AND rem_numero_origen = PED.nrofac AND rem_origen = 'PED') > 0

		END

		IF @Operacion = 'GET_T_REMISIONES'
		BEGIN

			SELECT
				 RTRIM(LTRIM(REM.rem_numero_origen))	AS NumeroPedido
				,CAST(REM.remfec AS DATE)				AS FechaRemision
				,RTRIM(LTRIM(REM.remcod))				AS NumeroRemision
				,RTRIM(LTRIM(CLI.clinit))				AS NitCliente
				,RTRIM(LTRIM(IREM.remar))				AS CodigoArticulo
				,IREM.remcan							AS CantidadArticulo
				,RTRIM(LTRIM(IREM.RemMed))				AS MedidaArticulo
			FROM inremisiones REM
			LEFT JOIN inmovremisiones IREM ON REM.remcod = IREM.remcod AND REM.remtipo = IREM.tipoMov
			LEFT JOIN clientes CLI ON REM.remcli = CLI.clicod
			WHERE rem_origen = 'PED' AND REM.remtipo = 'RM'

		END

		IF @Operacion = 'GET_CLIENTES'
		BEGIN

			SELECT
				  LTRIM(RTRIM(CLI.clinom)) AS NombreCliente
				 ,LTRIM(RTRIM(CLI.clinit)) AS NitCliente
				 ,LTRIM(RTRIM(ISNULL((SELECT TOP(1) NombreContacto FROM CliOtrosContactos WHERE CodigoCliente = CLI.clicod),''))) AS NombreContacto
				 ,LTRIM(RTRIM(ISNULL((SELECT TOP(1) Telefono FROM CliOtrosContactos WHERE CodigoCliente = CLI.clicod),''))) AS Telefono
				 ,LTRIM(RTRIM(CLI.climail)) AS Correo
				 ,LTRIM(RTRIM(CLI.clidir)) AS Direccion
				 ,LTRIM(RTRIM(CASE WHEN CLI.cliesc = '' THEN '0001' ELSE CLI.cliesc END)) AS CategoriaPrecio
			FROM clientes CLI
			WHERE CLI.delmrk = 1

		END

		IF @Operacion = 'GET_FACTURAS'
		BEGIN

			SELECT 
				 Fecha AS FechaFactura
				,Factura AS NumeroFactura
				,Remision AS NumeroRemision
				,(SELECT TOP(1) rem_numero_origen FROM inremisiones WHERE remcod = Remision AND remtipo = 'RM' AND rem_origen = 'PED') AS NumeroPedido
			FROM track_Remisiones
			WHERE (SELECT rem_numero_origen FROM inremisiones WHERE remcod = Remision AND remtipo = 'RM' AND rem_origen = 'PED') <> ''

		END

		IF @Operacion = 'GET_ARTS'
		BEGIN

			SELECT 
					arcod AS CodigoArticulo 
				,arespe AS NombreArticulo
				,'INV' AS Tipo
			FROM accglArti WHERE delmrk = 1
			UNION ALL
			SELECT 
					tracod AS CodigoArticulo 
				,tranom AS NombreArticulo
				,'SER' AS Tipo
			FROM Trabajos WHERE delmrk = 1



		END


		COMMIT TRANSACTION -- O solo COMMIT	-->
	END TRY
	BEGIN CATCH
                        
			SET @MENSAJE2 = ('Error: '+ERROR_MESSAGE())
			RAISERROR (@MENSAJE2, -- Message text.
						10, -- Severity,
						1, -- State,
						N'number', -- First argument.
						5)
			SELECT @MENSAJE2 AS MessageError
			ROLLBACK TRANSACTION -- O solo ROLLBACK
	END CATCH

END
GO
