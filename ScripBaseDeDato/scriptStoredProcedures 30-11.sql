USE [hp11]
GO
/****** Object:  StoredProcedure [dbo].[sp_estadisticaDeVentaApunte]    Script Date: 30/11/2016 6:31:33 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_estadisticaDeVentaApunte]
(@fechaDesde datetime,
@fechaHasta datetime)
as
SELECT sum(de.cantidad) as cantidadVendida,
    (CASE WHEN a.idTipoApunte=1 THEN 'Impreso' 
             WHEN a.idTipoApunte=2 THEN 'Digital' END) AS tipoApunte
FROM Apunte a INNER JOIN DetalleFactura de ON a.idApunte = de.idItem 
              INNER JOIN Factura f ON de.idFactura = f.idFactura
where f.fecha between @fechaDesde and @fechaHasta
Group by a.idTipoApunte
GO
/****** Object:  StoredProcedure [dbo].[sp_estadisticaDeVentaLibro]    Script Date: 30/11/2016 6:31:33 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_estadisticaDeVentaLibro]
(@fechaDesde datetime,
@fechaHasta datetime)
as
SELECT sum(de.cantidad) as cantidadVendida, de.idTipoItem AS tipoLibro
FROM Libro l INNER JOIN DetalleFactura de ON l.idLibro = de.idItem 
              INNER JOIN Factura f ON de.idFactura = f.idFactura
where f.fecha between @fechaDesde and @fechaHasta
Group by de.idTipoItem
having de.idTipoItem = 1
GO
/****** Object:  StoredProcedure [dbo].[sp_facturaXIdFactura]    Script Date: 30/11/2016 6:31:33 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_facturaXIdFactura]
(@idFactura int)
as
SELECT F.idFactura, F.fecha, F.total, DF.idDetalleFactura, DF.cantidad, DF.subtotal ,
       (
            CASE WHEN DF.idTipoItem=2 THEN  (SELECT A.nombreApunte FROM Apunte A WHERE A.idApunte = DF.idItem)
                 ELSE (SELECT L.nombreLibro FROM Libro L WHERE L.idLibro = DF.idItem)
                 END
        ) as nombreItem,
        ISNULL (E.nombreEmpleado + ' ' + e.apellidoEmpleado, ' ') AS nombreEmpleado


FROM Factura F INNER JOIN DetalleFactura DF
    ON F.idFactura = DF.idFactura
    LEFT JOIN  Usuario U
    ON U.idUsuario = F.idUsuarioEmpleado
    LEFT JOIN Empleado e
    ON e.idEmpleados = U.idCliente
    where F.idFactura = @idFactura







GO
/****** Object:  StoredProcedure [dbo].[sp_ingresoLibros]    Script Date: 30/11/2016 6:31:33 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_ingresoLibros]
(@FECHADESDE date,
@FECHAHASTA date,
@NOMBREPROVEEDOR varchar,
@NOMBREUSUARIO varchar,
@APELLIDOUSUARIO varchar)
as
SELECT I.fecha, P.nombreProveedor, ISNULL(e.nombreEmpleado,'') + ' ' + ISNULL(e.apellidoEmpleado, '') AS nombreUsuario, i.total
FROM IngresoLibro I LEFT JOIN Usuario U
                ON I.idUsuario = U.idUsuario
                LEFT JOIN Empleado e
                ON e.idEmpleados = U.idCliente
                INNER JOIN Proveedor P
                ON P.idProveedor = I.idProveedor
WHERE (I.fecha between @fechaDesde and @fechaHasta) AND P.nombreProveedor LIKE (CASE WHEN @NOMBREPROVEEDOR='*' THEN   '%%' ELSE  '%'+@NOMBREPROVEEDOR+'%' END ) AND e.apellidoEmpleado LIKE (CASE WHEN @APELLIDOUSUARIO='*' THEN   '%%' ELSE  '%'+@APELLIDOUSUARIO+'%' END ) AND e.nombreEmpleado LIKE (CASE WHEN @NOMBREUSUARIO='*' THEN   '%%' ELSE '%'+@NOMBREUSUARIO+'%' END )







GO
/****** Object:  StoredProcedure [dbo].[sp_venta]    Script Date: 30/11/2016 6:31:33 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_venta]
@idFactura int
as
SELECT idFactura, fecha, total 
FROM dbo.Factura
where idFactura = @idFactura







GO
/****** Object:  StoredProcedure [dbo].[sp_ventaXapunte]    Script Date: 30/11/2016 6:31:33 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_ventaXapunte]
(@fechaDesde datetime,
@fechaHasta datetime)
as
select df.cantidad, a.nombreApunte, a.cantHoja, f.fecha , (df.cantidad  *   a.cantHoja) as hojasTotales from factura f join DetalleFactura df ON f.idFactura = df.idFactura JOIN Apunte a on df.idItem = a.idApunte
where (f.fecha between @fechaDesde and @fechaHasta) AND (a.idTipoApunte = 1)








GO
/****** Object:  StoredProcedure [dbo].[sp_ventaXdia]    Script Date: 30/11/2016 6:31:33 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_ventaXdia]

(@fechaDesde datetime,
@fechaHasta datetime)
as
SELECT idFactura, fecha, total 
FROM dbo.Factura
where fecha between @fechaDesde and @fechaHasta







GO
