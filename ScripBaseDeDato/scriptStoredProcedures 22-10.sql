USE [ProyectoArtemisa]
GO
/****** Object:  StoredProcedure [dbo].[sp_venta]    Script Date: 22/10/2016 19:28:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_ventaXapunte]    Script Date: 22/10/2016 19:28:20 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_ventaXdia]    Script Date: 22/10/2016 19:28:20 ******/
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
