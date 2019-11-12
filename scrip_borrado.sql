USE [GD2C2019]
GO

DROP PROCEDURE GDDS2.facturar
GO

DROP PROCEDURE GDDS2.existe_usuario
GO

DROP PROCEDURE GDDS2.realizarCompra
GO

DROP FUNCTION GDDS2.poseeSaldoSuficiente
GO

DROP FUNCTION GDDS2.cantidadDeArticulosVendidos
GO

DROP FUNCTION GDDS2.hayStockDisponible
GO

DROP TRIGGER GDDS2.cargaCredito
GO

DROP PROCEDURE GDDS2.cargarEntrega
GO

DROP FUNCTION GDDS2.compraPerteceAProveedor
GO


DROP FUNCTION GDDS2.listadoEstadisticoProveedoresMayorDescuento
GO


DROP FUNCTION GDDS2.listadoEstadisticoMayorFacturacion
GO




ALTER TABLE [GDDS2].[usuario_x_rol] DROP CONSTRAINT [Usuario_usuario_x_rol_fk]
GO

ALTER TABLE [GDDS2].[usuario_x_rol] DROP CONSTRAINT [Rol_usuario_x_rol_fk]
GO

ALTER TABLE [GDDS2].[rol_funcionalidad] DROP CONSTRAINT [Rol_rol_funcionalidad_fk]
GO

ALTER TABLE [GDDS2].[rol_funcionalidad] DROP CONSTRAINT [funcionalidad_rol_funcionalidad_fk]
GO

ALTER TABLE [GDDS2].[Proveedor] DROP CONSTRAINT [Usuario_Proveedor_fk]
GO

ALTER TABLE [GDDS2].[Proveedor] DROP CONSTRAINT [Rubro_Proveedor_fk]
GO

ALTER TABLE [GDDS2].[Proveedor] DROP CONSTRAINT [Domicilio_Proveedor_fk]
GO

ALTER TABLE [GDDS2].[Oferta] DROP CONSTRAINT [Proveedor_oferta_fk]
GO

ALTER TABLE [GDDS2].[Item_factura] DROP CONSTRAINT [Factura_Item_factura_fk]
GO

ALTER TABLE [GDDS2].[Item_factura] DROP CONSTRAINT [Compra_Item_factura_fk]
GO

ALTER TABLE [GDDS2].[Factura] DROP CONSTRAINT [Proveedor_Factura_fk]
GO

ALTER TABLE [GDDS2].[Entrega] DROP CONSTRAINT [Compra_Entrega_fk]
GO

ALTER TABLE [GDDS2].[Entrega] DROP CONSTRAINT [Cliente_Entrega_fk]
GO

ALTER TABLE [GDDS2].[credito] DROP CONSTRAINT [Tipo_pago_credito_fk]
GO

ALTER TABLE [GDDS2].[credito] DROP CONSTRAINT [Cliente_credito_fk]
GO

ALTER TABLE [GDDS2].[Compra] DROP CONSTRAINT [Oferta_Compra_fk]
GO

ALTER TABLE [GDDS2].[Compra] DROP CONSTRAINT [Cliente_Compra_fk]
GO

ALTER TABLE [GDDS2].[Cliente] DROP CONSTRAINT [Usuario_Cliente_fk]
GO

ALTER TABLE [GDDS2].[Cliente] DROP CONSTRAINT [Domicilio_Cliente_fk]
GO

DROP TABLE [GDDS2].[usuario_x_rol]
GO

DROP TABLE [GDDS2].[Usuario]
GO

DROP TABLE [GDDS2].[Tipo_pago]
GO

DROP TABLE [GDDS2].[Rubro]
GO

DROP TABLE [GDDS2].[rol_funcionalidad]
GO

DROP TABLE [GDDS2].[Rol]
GO

DROP TABLE [GDDS2].[Proveedor]
GO

DROP TABLE [GDDS2].[Oferta]
GO

DROP TABLE [GDDS2].[Item_factura]
GO

DROP TABLE [GDDS2].[funcionalidad]
GO

DROP TABLE [GDDS2].[Factura]
GO

DROP TABLE [GDDS2].[Entrega]
GO

DROP TABLE [GDDS2].[Domicilio]
GO

DROP TABLE [GDDS2].[credito]
GO

DROP TABLE [GDDS2].[Compra]
GO

DROP TABLE [GDDS2].[Cliente]
GO

