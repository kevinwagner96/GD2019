USE [GD2C2019]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Set dateformat ymd;

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'GDDS2')
BEGIN
EXEC ('CREATE SCHEMA [GDDS2] AUTHORIZATION [gdCupon2019]')
END


CREATE TABLE [GDDS2].[Cliente](
	[id_cliente] [int] IDENTITY(1,1) NOT NULL,
	[clie_usuario] [int],
	[id_domicilio] [int] NOT NULL,
	[clie_dni] [numeric](18, 0) unique NOT NULL,
	[clie_nombre] [nvarchar](50) NOT NULL,
	[clie_apellido] [nvarchar](50) NOT NULL,
	[clie_email] [nvarchar](50) NULL,
	[clie_telefono] [nvarchar](50) NULL,
	[clie_fecha_nac] [datetime] NOT NULL,
	[clie_activo] [bit] NOT NULL,
	[clie_credito] [decimal](12, 2) NOT NULL,
 CONSTRAINT [Cliente_pk] PRIMARY KEY CLUSTERED 
(
	[id_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [GDDS2].[Rubro]    Script Date: 10/10/2019 18:55:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TABLE [GDDS2].[Rubro](
[rubr_id] [int] IDENTITY(1,1) NOT NULL,
[rubr_detalle] [nvarchar] (50) NOT NULL,
CONSTRAINT [Rubro_pk] PRIMARY KEY CLUSTERED
(
    [rubr_id] ASC       
	 ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO







/****** Object:  Table [GDDS2].[Compra]    Script Date: 10/10/2019 18:55:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [GDDS2].[Compra](
	[id_compra] [int] IDENTITY(1,1) NOT NULL,
	[id_oferta] [nvarchar](50) NOT NULL,
	[id_cliente] [int] NOT NULL,
	[compra_fecha] [datetime] NOT NULL,
	[compra_precio_lista] [decimal](12, 2) NOT NULL,
	[compra_precio_oferta] [decimal](12, 2) NOT NULL,
	[compra_cantidad] [int] NULL,
	[compra_canjeado] [bit] NULL,
	[compra_fecha_vencimiento] [datetime] NULL,
 CONSTRAINT [Compra_pk] PRIMARY KEY CLUSTERED 
(
	[id_compra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



/****** Object:  Table [GDDS2].[credito]    Script Date: 10/10/2019 18:55:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [GDDS2].[credito](
	[id_carga_credito] [int] IDENTITY(1,1) NOT NULL,
	[id_cliente] [int] NOT NULL,
	[id_tipo_pago] [int] NOT NULL,
	[cred_fecha] [datetime] NOT NULL,
	[cred_monto] [decimal](12, 2) NOT NULL,
	[cred_num_tarjeta] [numeric](16, 0) NULL,
	[cre_empresa_tarjeta] [nvarchar](20) NULL,
	[cred_cod_tarjeta] [numeric](4, 0) NULL,
 CONSTRAINT [credito_pk] PRIMARY KEY CLUSTERED 
(
	[id_carga_credito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [GDDS2].[Domicilio]    Script Date: 10/10/2019 18:55:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [GDDS2].[Domicilio](
	[id_domicilio] [int] IDENTITY(1,1) NOT NULL,
	[dom_calle] [nvarchar](255) NOT NULL,
	[dom_numero] [nvarchar](50) NULL,
	[dom_depto] [int] NULL,
	[dom_piso] [int] NULL,
	[dom_ciudad] [nvarchar](50) NOT NULL,
	[dom_localidad] [nvarchar](50) NULL,
	[dom_codigo_postal] [nvarchar](50) NULL,
 CONSTRAINT [domicilio_pk] PRIMARY KEY CLUSTERED 
(
	[id_domicilio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [GDDS2].[Entrega]    Script Date: 10/10/2019 18:55:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [GDDS2].[Entrega](
	[id_entrega] [int] IDENTITY(1,1) NOT NULL,
	[ent_fecha] [datetime] NOT NULL,
	[id_compra] [int] NOT NULL,
	[id_cliente] [int] NOT NULL,
 CONSTRAINT [Entrega_pk] PRIMARY KEY CLUSTERED 
(
	[id_entrega] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [GDDS2].[Factura]    Script Date: 10/10/2019 18:55:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [GDDS2].[Factura](
	[id_fact] [int] IDENTITY(1,1) NOT NULL,
	[id_proveedor] [int] NOT NULL,
	[fact_fecha] [datetime] NOT NULL,
	[fact_fecha_inicio] [datetime] NULL,
	[fact_fecha_fin] [datetime] NULL,
	[fact_importe] [decimal](12, 2) NULL,
 CONSTRAINT [Factura_pk] PRIMARY KEY CLUSTERED 
(
	[id_fact] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [GDDS2].[funcionalidad]    Script Date: 10/10/2019 18:55:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [GDDS2].[funcionalidad](
	[func_codigo] [int] NOT NULL,
	[func_nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [funcionalidad_pk] PRIMARY KEY CLUSTERED 
(
	[func_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO




/****** Object:  Table [GDDS2].[Item_factura]    Script Date: 10/10/2019 18:55:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [GDDS2].[Item_factura](
	[id_fact] [int] NOT NULL,
	[id_compra] [int] NOT NULL,
	[item_precio] [decimal](12, 2) NULL,
	[item_fecha_compra] [datetime] NULL,
 CONSTRAINT [Item_factura_pk] PRIMARY KEY CLUSTERED 
(
	[id_fact] ASC,
	[id_compra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [GDDS2].[Oferta]    Script Date: 10/10/2019 18:55:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [GDDS2].[Oferta](
	[id_oferta] [nvarchar](50) NOT NULL,
	[id_proveedor] [int] NOT NULL,
	[ofer_descripcion] [nvarchar](255) NOT NULL,
	[ofer_cant_disp] [int] NOT NULL,
	[ofer_activo] [bit] NOT NULL,
	[ofer_f_public] [datetime] NOT NULL,
	[ofer_f_venc] [datetime] NOT NULL,
	[ofer_pr_oferta] [decimal](12, 2) NOT NULL,
	[ofer_pr_lista] [decimal](12, 2) NOT NULL,
	[ofer_cant_x_cli] [int] NULL,
 CONSTRAINT [Oferta_pk] PRIMARY KEY CLUSTERED 
(
	[id_oferta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [GDDS2].[Proveedor]    Script Date: 10/10/2019 18:55:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [GDDS2].[Proveedor](
	[id_proveedor] [int] IDENTITY(1,1) NOT NULL,
	[id_domicilio] [int] NOT NULL,
	[prove_usuario] [int] ,
	[prov_CUIT] [nvarchar] (20) unique NOT NULL,
	[prov_razon_social] [nvarchar] (50) unique NOT NULL,
	[prov_email] [nvarchar](50) NULL,
	[prov_telefono] [nvarchar](50) NULL,
	[rubr_id] [int] NOT NULL,
	[prov_contacto] [nvarchar](50) NULL,
	[prov_activo] [bit] NOT NULL,
 CONSTRAINT [Proveedor_pk] PRIMARY KEY CLUSTERED 
(
	[id_proveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [GDDS2].[Rol]    Script Date: 10/10/2019 18:55:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [GDDS2].[Rol](
	[id_rol] [int] IDENTITY(1,1) NOT NULL,
	[rol_nombre] [nvarchar](50) NOT NULL,
	[rol_activo] [bit] NOT NULL,
 CONSTRAINT [Rol_pk] PRIMARY KEY CLUSTERED 
(
	[id_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [GDDS2].[rol_funcionalidad]    Script Date: 10/10/2019 18:55:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [GDDS2].[rol_funcionalidad](
	[id_rol] [int] NOT NULL,
	[func_codigo] [int] NOT NULL,
 CONSTRAINT [rol_funcionalidad_pk] PRIMARY KEY CLUSTERED 
(
	[id_rol] ASC,
	[func_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [GDDS2].[Tipo_pago]    Script Date: 10/10/2019 18:55:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [GDDS2].[Tipo_pago](
	[id_tipo_pago] [int] IDENTITY(1,1) NOT NULL,
	[tipo_pago_nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [Tipo_pago_pk] PRIMARY KEY CLUSTERED 
(
	[id_tipo_pago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [GDDS2].[Usuario]    Script Date: 10/10/2019 18:55:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [GDDS2].[Usuario](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[usu_username] [nvarchar](50) unique NOT NULL,
	[usu_contrasenia] [nvarchar](50) NOT NULL,
	[usu_cant_intentos_fallidos] [int] NOT NULL,
	[usu_activo] [bit] NOT NULL,
 CONSTRAINT [Usuario_pk] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [GDDS2].[usuario_x_rol]    Script Date: 10/10/2019 18:55:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [GDDS2].[usuario_x_rol](
	[id_usuario] [int] NOT NULL,
	[id_rol] [int] NOT NULL,
 CONSTRAINT [usuario_x_rol_pk] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC,
	[id_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [GDDS2].[Cliente]  WITH CHECK ADD  CONSTRAINT [Domicilio_Cliente_fk] FOREIGN KEY([id_domicilio])
REFERENCES [GDDS2].[Domicilio] ([id_domicilio])
GO

ALTER TABLE [GDDS2].[Cliente] CHECK CONSTRAINT [Domicilio_Cliente_fk]
GO

ALTER TABLE [GDDS2].[Cliente]  WITH CHECK ADD  CONSTRAINT [Usuario_Cliente_fk] FOREIGN KEY([clie_usuario])
REFERENCES [GDDS2].[Usuario] ([id_usuario])
GO

ALTER TABLE [GDDS2].[Cliente] CHECK CONSTRAINT [Usuario_Cliente_fk]
GO

ALTER TABLE [GDDS2].[Compra]  WITH CHECK ADD  CONSTRAINT [Cliente_Compra_fk] FOREIGN KEY([id_cliente])
REFERENCES [GDDS2].[Cliente] ([id_cliente])
GO

ALTER TABLE [GDDS2].[Compra] CHECK CONSTRAINT [Cliente_Compra_fk]
GO

ALTER TABLE [GDDS2].[Compra]  WITH CHECK ADD  CONSTRAINT [Oferta_Compra_fk] FOREIGN KEY([id_oferta])
REFERENCES [GDDS2].[Oferta] ([id_oferta])
GO

ALTER TABLE [GDDS2].[Compra] CHECK CONSTRAINT [Oferta_Compra_fk]
GO

ALTER TABLE [GDDS2].[credito]  WITH CHECK ADD  CONSTRAINT [Cliente_credito_fk] FOREIGN KEY([id_cliente])
REFERENCES [GDDS2].[Cliente] ([id_cliente])
GO

ALTER TABLE [GDDS2].[credito] CHECK CONSTRAINT [Cliente_credito_fk]
GO

ALTER TABLE [GDDS2].[credito]  WITH CHECK ADD  CONSTRAINT [Tipo_pago_credito_fk] FOREIGN KEY([id_tipo_pago])
REFERENCES [GDDS2].[Tipo_pago] ([id_tipo_pago])
GO

ALTER TABLE [GDDS2].[credito] CHECK CONSTRAINT [Tipo_pago_credito_fk]
GO

ALTER TABLE [GDDS2].[Entrega]  WITH CHECK ADD  CONSTRAINT [Cliente_Entrega_fk] FOREIGN KEY([id_cliente])
REFERENCES [GDDS2].[Cliente] ([id_cliente])
GO

ALTER TABLE [GDDS2].[Entrega] CHECK CONSTRAINT [Cliente_Entrega_fk]
GO

ALTER TABLE [GDDS2].[Entrega]  WITH CHECK ADD  CONSTRAINT [Compra_Entrega_fk] FOREIGN KEY([id_compra])
REFERENCES [GDDS2].[Compra] ([id_compra])
GO

ALTER TABLE [GDDS2].[Entrega] CHECK CONSTRAINT [Compra_Entrega_fk]
GO

ALTER TABLE [GDDS2].[Factura]  WITH CHECK ADD  CONSTRAINT [Proveedor_Factura_fk] FOREIGN KEY([id_proveedor])
REFERENCES [GDDS2].[Proveedor] ([id_proveedor])
GO

ALTER TABLE [GDDS2].[Factura] CHECK CONSTRAINT [Proveedor_Factura_fk]
GO

ALTER TABLE [GDDS2].[Item_factura]  WITH CHECK ADD  CONSTRAINT [Compra_Item_factura_fk] FOREIGN KEY([id_compra])
REFERENCES [GDDS2].[Compra] ([id_compra])
GO

ALTER TABLE [GDDS2].[Item_factura] CHECK CONSTRAINT [Compra_Item_factura_fk]
GO

ALTER TABLE [GDDS2].[Item_factura]  WITH CHECK ADD  CONSTRAINT [Factura_Item_factura_fk] FOREIGN KEY([id_fact])
REFERENCES [GDDS2].[Factura] ([id_fact])
GO

ALTER TABLE [GDDS2].[Item_factura] CHECK CONSTRAINT [Factura_Item_factura_fk]
GO

ALTER TABLE [GDDS2].[Oferta]  WITH CHECK ADD  CONSTRAINT [Proveedor_oferta_fk] FOREIGN KEY([id_proveedor])
REFERENCES [GDDS2].[Proveedor] ([id_proveedor])
GO

ALTER TABLE [GDDS2].[Oferta] CHECK CONSTRAINT [Proveedor_oferta_fk]
GO

ALTER TABLE [GDDS2].[Proveedor]  WITH CHECK ADD  CONSTRAINT [Domicilio_Proveedor_fk] FOREIGN KEY([id_domicilio])
REFERENCES [GDDS2].[Domicilio] ([id_domicilio])
GO

ALTER TABLE [GDDS2].[Proveedor] CHECK CONSTRAINT [Domicilio_Proveedor_fk]
GO

ALTER TABLE [GDDS2].[Proveedor]  WITH CHECK ADD  CONSTRAINT [Rubro_Proveedor_fk] FOREIGN KEY([rubr_id])
REFERENCES [GDDS2].[Rubro] ([rubr_id])
GO

ALTER TABLE [GDDS2].[Proveedor] CHECK CONSTRAINT [Rubro_Proveedor_fk]
GO




ALTER TABLE [GDDS2].[Proveedor]  WITH CHECK ADD  CONSTRAINT [Usuario_Proveedor_fk] FOREIGN KEY([prove_usuario])
REFERENCES [GDDS2].[Usuario] ([id_usuario])
GO

ALTER TABLE [GDDS2].[Proveedor] CHECK CONSTRAINT [Usuario_Proveedor_fk]
GO

ALTER TABLE [GDDS2].[rol_funcionalidad]  WITH CHECK ADD  CONSTRAINT [funcionalidad_rol_funcionalidad_fk] FOREIGN KEY([func_codigo])
REFERENCES [GDDS2].[funcionalidad] ([func_codigo])
GO

ALTER TABLE [GDDS2].[rol_funcionalidad] CHECK CONSTRAINT [funcionalidad_rol_funcionalidad_fk]
GO

ALTER TABLE [GDDS2].[rol_funcionalidad]  WITH CHECK ADD  CONSTRAINT [Rol_rol_funcionalidad_fk] FOREIGN KEY([id_rol])
REFERENCES [GDDS2].[Rol] ([id_rol])
GO

ALTER TABLE [GDDS2].[rol_funcionalidad] CHECK CONSTRAINT [Rol_rol_funcionalidad_fk]
GO

ALTER TABLE [GDDS2].[usuario_x_rol]  WITH CHECK ADD  CONSTRAINT [Rol_usuario_x_rol_fk] FOREIGN KEY([id_rol])
REFERENCES [GDDS2].[Rol] ([id_rol])
GO

ALTER TABLE [GDDS2].[usuario_x_rol] CHECK CONSTRAINT [Rol_usuario_x_rol_fk]
GO

ALTER TABLE [GDDS2].[usuario_x_rol]  WITH CHECK ADD  CONSTRAINT [Usuario_usuario_x_rol_fk] FOREIGN KEY([id_usuario])
REFERENCES [GDDS2].[Usuario] ([id_usuario])
GO

ALTER TABLE [GDDS2].[usuario_x_rol] CHECK CONSTRAINT [Usuario_usuario_x_rol_fk]
GO


-- insertando valores a las funcionalidades
INSERT INTO GDDS2.[funcionalidad](func_codigo, func_nombre)
VALUES (1,'ABM_ROL'); 
INSERT INTO GDDS2.[funcionalidad](func_codigo, func_nombre)
VALUES (2,'COMPRAR_OFERTA'); 
INSERT INTO GDDS2.[funcionalidad](func_codigo, func_nombre)
VALUES (3,'ABM_CLIENTE'); 
INSERT INTO GDDS2.[funcionalidad](func_codigo, func_nombre)
VALUES (4,'ABM_PROVEEDOR'); 
INSERT INTO GDDS2.[funcionalidad](func_codigo, func_nombre)
VALUES (5,'GENERAR_OFERTA'); 
INSERT INTO GDDS2.[funcionalidad](func_codigo, func_nombre)
VALUES (6,'CARGA_CREDITO'); 
INSERT INTO GDDS2.[funcionalidad](func_codigo, func_nombre)
VALUES (7,'LISTADO_ESTADISTICO'); 
INSERT INTO GDDS2.[funcionalidad](func_codigo, func_nombre)
VALUES (8,'ABM_USUARIO');
INSERT INTO GDDS2.[funcionalidad](func_codigo, func_nombre)
VALUES (9,'GENERAR_FACTURA');
INSERT INTO GDDS2.[funcionalidad](func_codigo, func_nombre)
VALUES (10,'CANJEAR_CUPON');


-- Inserto roles
SET IDENTITY_INSERT GDDS2.[Rol] ON

INSERT INTO GDDS2.[Rol](id_rol,rol_nombre,rol_activo)
VALUES (1,'ADMINISTRADOR',1), (2,'CLIENTE',1), (3,'PROVEEDOR',1);

SET IDENTITY_INSERT GDDS2.[Rol] OFF

GO

-- inserto usuario admin
SET IDENTITY_INSERT GDDS2.[Usuario] ON

INSERT INTO GDDS2.[Usuario](id_usuario,usu_username, usu_contrasenia,usu_cant_intentos_fallidos,usu_activo)
VALUES  (1,'admin', HASHBYTES('SHA2_256', N'w23e'),0,1)

GO

SET IDENTITY_INSERT GDDS2.[Usuario] OFF


-- Inserto rol_x_usuario
INSERT INTO GDDS2.[usuario_x_rol](id_usuario,id_rol)
VALUES (1,1)

-- Cargo relaciones en al tabla intermedia

INSERT INTO GDDS2.[rol_funcionalidad](id_rol,func_codigo)
VALUES (1,1),(1,2),(1,3),(1,4),(1,5),(1,6),(1,7),(1,8),(1,9),(1,10),(2,2),(2,6),(3,5),(3,10)
go

--insertamos los tipos de pago,cod de c/u 1,2,y 3 respectivamente
insert into GDDS2.[Tipo_pago](tipo_pago_nombre)
values ('Efectivo'),('Crédito'),('Débito')
GO
-- inserto clientes, junto con sus domicilios


insert into GDDS2.Domicilio(dom_calle,dom_ciudad)
select distinct Cli_Direccion,Cli_Ciudad from gd_esquema.Maestra where Cli_Direccion is not null

insert into GDDS2.[Cliente](id_domicilio,clie_dni,clie_nombre,clie_apellido,clie_email,clie_telefono,clie_fecha_nac,clie_activo,clie_credito)
(select distinct  id_domicilio,Cli_Dni,Cli_Nombre, Cli_Apellido,Cli_Mail, Cli_Telefono,Cli_Fecha_Nac,1,0 from gd_esquema.Maestra join GDDS2.Domicilio on dom_calle+dom_ciudad = Cli_Direccion+Cli_Ciudad  where Cli_Nombre is not null)

--cargo los rubros

insert into GDDS2.[Rubro](rubr_detalle)
select distinct Provee_Rubro from gd_esquema.Maestra where Provee_Rubro is not null


--cargo los proveedore con respectivos domicilio

insert into GDDS2.Domicilio (dom_calle,dom_ciudad)
select distinct Provee_Dom,Provee_Ciudad from gd_esquema.Maestra where Provee_Dom is not null

insert into GDDS2.Proveedor (id_domicilio,prov_CUIT,prov_razon_social,prov_telefono,rubr_id,prov_activo)
(select distinct id_domicilio,Provee_CUIT,Provee_RS,Provee_Telefono,rubr_id,1 from gd_esquema.Maestra join GDDS2.Rubro on rubr_detalle = Provee_Rubro join GDDS2.Domicilio on dom_calle+dom_ciudad = Provee_Dom+Provee_Ciudad where Provee_RS is not null )
-- migrando los registros de cargas de credito
--en la tabla maestra solo un cliente realiza cargas, DNI: 83183632

insert into GDDS2.[credito](id_cliente,id_tipo_pago,cred_fecha,cred_monto)
 select  distinct id_cliente,id_tipo_pago,Carga_Fecha,Carga_Credito from gd_esquema.Maestra join GDDS2.Cliente on clie_dni = Cli_Dni join GDDS2.Tipo_pago tp on tp.tipo_pago_nombre = Tipo_Pago_Desc  where Carga_Fecha is not null and Tipo_Pago_Desc is not null 


--migramos las ofertas relacionadas a cada proveedor


insert into GDDS2.[Oferta](id_oferta,id_proveedor,ofer_descripcion,ofer_f_public,ofer_f_venc,ofer_pr_oferta,ofer_pr_lista,ofer_cant_disp,ofer_activo)
select distinct Oferta_Codigo,id_proveedor,Oferta_Descripcion,Oferta_Fecha,Oferta_Fecha_Venc,Oferta_Precio,Oferta_Precio_Ficticio,Oferta_Cantidad,1 from gd_esquema.Maestra join GDDS2.Proveedor on prov_CUIT = Provee_CUIT


GO


-- carga de compras que fueron entregadas, 2' 32"
 
create procedure migrarComprasEntregadas
as begin
declare @ofertaCodigo nvarchar(50)
declare @idCliente int
declare @fechaCompra datetime
declare @precioFicticio decimal (12,2)
declare @ofertaPrecio decimal(12,2)
declare @fecha_entrega datetime
declare @id_cliente_destino int
declare @contador int
set @contador = 1
declare c cursor fast_forward for (select distinct m1.Oferta_Codigo,id_cliente,m1.Oferta_Fecha_Compra,m1.Oferta_Precio_Ficticio,m1.Oferta_Precio,m1.Oferta_Entregado_Fecha,isnull((select c1.id_cliente from GDDS2.Cliente c1  where m1.Cli_Dest_Dni = c1.clie_dni  ),id_cliente) cliente_destino from gd_esquema.Maestra m1 join GDDS2.Cliente on clie_dni = m1.Cli_Dni  where m1.Oferta_Fecha_Compra is not null and m1.Oferta_Entregado_Fecha is not null)
open c
fetch next from c into @ofertaCodigo,@idCliente,@fechaCompra,@precioFicticio,@ofertaPrecio,@fecha_entrega,@id_cliente_destino
while (@@FETCH_STATUS = 0)
begin
SET IDENTITY_INSERT GDDS2.[Compra] on
insert into GDDS2.Compra (id_compra ,id_oferta,id_cliente,compra_fecha,compra_precio_lista,compra_precio_oferta,compra_canjeado, compra_cantidad)
values (@contador,@ofertaCodigo,@idCliente,@fechaCompra,@precioFicticio,@ofertaPrecio,1,1)
SET IDENTITY_INSERT GDDS2.[Compra] off

insert into GDDS2.Entrega(ent_fecha,id_compra,id_cliente)
values (@fecha_entrega,@contador,@id_cliente_destino)
set @contador  = @contador +1
fetch next from c into @ofertaCodigo,@idCliente,@fechaCompra,@precioFicticio,@ofertaPrecio,@fecha_entrega,@id_cliente_destino
end
close c
deallocate c
end
GO
exec migrarComprasEntregadas
drop procedure migrarComprasEntregadas
GO





--carga de compras no entregadas
-- duracion 34"

create procedure migrarComprasSinEntregas
as begin
declare @ofertaCodigo nvarchar(50)
declare @idCliente int
declare @fechaCompra datetime
declare @precioFicticio decimal (12,2)
declare @ofertaPrecio decimal(12,2)
declare @fecha_entrega datetime
declare @id_cliente_destino int
declare @contador int
set @contador = (select count(*) from GDDS2.Compra)+1
declare c cursor fast_forward for (select distinct m1.Oferta_Codigo,id_cliente,m1.Oferta_Fecha_Compra,m1.Oferta_Precio_Ficticio,m1.Oferta_Precio,m1.Oferta_Entregado_Fecha,isnull((select c1.id_cliente from GDDS2.Cliente c1  where m1.Cli_Dest_Dni = c1.clie_dni  ),id_cliente) cliente_destino   from gd_esquema.Maestra m1 join GDDS2.Cliente on clie_dni = m1.Cli_Dni   where m1.Oferta_Fecha_Compra is not null and m1.Oferta_Entregado_Fecha is  null and cast(m1.Oferta_Codigo as nvarchar(50))+cast(id_cliente as nvarchar(50))+cast(m1.Oferta_Fecha_Compra as nvarchar(50)) not  in (select distinct( cast(id_oferta as nvarchar(50))+cast(id_cliente as nvarchar(50))+cast(compra_fecha as nvarchar(50))) from GDDS2.Compra)  )
open c
fetch next from c into @ofertaCodigo,@idCliente,@fechaCompra,@precioFicticio,@ofertaPrecio,@fecha_entrega,@id_cliente_destino
while (@@FETCH_STATUS = 0)
begin
SET IDENTITY_INSERT GDDS2.[Compra] on
insert into GDDS2.Compra (id_compra ,id_oferta,id_cliente,compra_fecha,compra_precio_lista,compra_precio_oferta,compra_canjeado,compra_cantidad)
values (@contador,@ofertaCodigo,@idCliente,@fechaCompra,@precioFicticio,@ofertaPrecio,0,1)
SET IDENTITY_INSERT GDDS2.[Compra] off


set @contador = @contador + 1
fetch next from c into @ofertaCodigo,@idCliente,@fechaCompra,@precioFicticio,@ofertaPrecio,@fecha_entrega,@id_cliente_destino
end
close c
deallocate c

end

GO
exec migrarComprasSinEntregas
drop procedure migrarComprasSinEntregas
GO 



--migrarFacturas

create procedure cargarFactura
as begin
declare @idFactura int, @idProveedor int , @fechaDeFacturacion datetime,@total decimal(12,2)

declare c cursor fast_forward for (select distinct Factura_Nro,(select id_proveedor from GDDS2.Proveedor where prov_CUIT = Provee_CUIT),Factura_Fecha, sum(Oferta_Precio) from gd_esquema.Maestra where Factura_Nro is not null group by Factura_Nro,Factura_Fecha,Provee_CUIT)
open c
fetch next from c into @idFactura,@idProveedor,@fechaDeFacturacion,@total 
while (@@FETCH_STATUS = 0)
begin
SET IDENTITY_INSERT GDDS2.[Factura] on
insert into GDDS2.Factura (id_fact,id_proveedor,fact_fecha,fact_importe)
values (@idFactura,@idProveedor,@fechaDeFacturacion,@total)
SET IDENTITY_INSERT GDDS2.[Factura] off
fetch next from c into @idFactura,@idProveedor,@fechaDeFacturacion ,@total
end
close c
deallocate c
end



GO

exec cargarFactura
drop procedure cargarFactura
GO

--cargarItemFactura

insert into GDDS2.Item_factura (id_fact,id_compra,item_precio,item_fecha_compra)
select f.id_fact,co.id_compra,Oferta_Precio,co.compra_fecha from gd_esquema.Maestra join GDDS2.Factura f on Factura_Nro = f.id_fact join GDDS2.Cliente cli on cli.clie_dni = Cli_Dni join GDDS2.Compra co on (cast(co.id_oferta as nvarchar(50))+cast(co.id_cliente as nvarchar(50))+cast(co.compra_fecha as nvarchar(50)) )= (cast(Oferta_Codigo as nvarchar(50))+cast(cli.id_cliente as nvarchar(50))+ cast(Oferta_Fecha_Compra as nvarchar(50)))



GO
--procedure login- existe usuario
create procedure [GDDS2].existe_usuario @Usuario nvarchar(50), @Contrasenia nvarchar(50), @resultado bit OUTPUT
AS
BEGIN
	declare @hash binary(32) = (select HASHBYTES('SHA2_256', @Contrasenia))
	select @resultado = (select case when (select count(*) from GDDS2.Usuario where usu_contrasenia = @hash and usu_username = @Usuario) >=1 then 1 else 0 end)
	if(@resultado = 1)
	begin
		update GDDS2.Usuario set usu_cant_intentos_fallidos = 0 where usu_username = @Usuario
	end
	else
	begin
		if(exists(select * from GDDS2.Usuario where usu_username = @Usuario))
		begin
			update GDDS2.Usuario set usu_cant_intentos_fallidos = ((select usu_cant_intentos_fallidos from GDDS2.Usuario where usu_username = @Usuario) + 1) where usu_username = @Usuario
		end
	end
END

GO
--metodos de compras
create function [GDDS2].cantidadDeArticulosVendidos(@idCliente int, @idOferta nvarchar(50))
returns int
as begin
declare @cantidad int
set @cantidad = isnull((select sum(compra_cantidad) from GDDS2.Compra where id_cliente = @idCliente and @idOferta = id_oferta),0)
return @cantidad

end

GO

create function [GDDS2].hayStockDisponible(@idOferta nvarchar(50),@cantidad int)
returns bit
as begin
declare @estado bit
if ((select ofer_cant_disp from GDDS2.Oferta where id_oferta = @idOferta) >= @cantidad)
begin
set @estado = 1
end
else 
begin
set @estado = 0
end
return @estado
end
GO



create function [GDDS2].poseeSaldoSuficiente(@idCliente int, @idOferta nvarchar(50),@cantidad int)
returns bit
as begin
declare @totalPrecio decimal(12,2), @estado bit,@saldoCliente decimal(12,2)
set @totalPrecio = isnull((select ofer_pr_oferta from GDDS2.Oferta where id_oferta = @idOferta ),0) * @cantidad
set @saldoCliente = (select clie_credito from GDDS2.Cliente where id_cliente = @idCliente)
if (@totalPrecio <= @saldoCliente )
begin
set @estado = 1
end
else
begin
set @estado = 0
end
return @estado
end
GO


create procedure [GDDS2].realizarCompra(@idCliente int ,@idOferta nvarchar(50),@cantidad int,@fechaActual nvarchar(50),@codigoCuponResultante int output)
as begin
declare @cantidadMaximaPorCliente int, @importe decimal(12,2), @fechaActualParseada datetime
set @fechaActualParseada = (convert(datetime,convert(datetime,@fechaActual,103),120))
set @cantidadMaximaPorCliente = (select ofer_cant_x_cli from GDDS2.Oferta where id_oferta = @idOferta)
if (@cantidadMaximaPorCliente < (GDDS2.cantidadDeArticulosVendidos(@idCliente,@idOferta) + @cantidad)   or @cantidadMaximaPorCliente is not null  )
begin
RAISERROR('El cliente no puede adquirir la cantidad seleccionada del producto',16,1)
return
end


if (GDDS2.poseeSaldoSuficiente(@idCliente,@idOferta,@cantidad) = 0)
begin
set @resultado = 2
RAISERROR('Saldo insuficiente',15,1)
return 
end

if(GDDS2.hayStockDisponible(@idOferta,@cantidad) = 0)
begin
set @resultado = 3
RAISERROR('No hay Stock disponible',14,1)
return
end

declare @precioLista decimal(12,2)
declare @precioOferta decimal (12,2)
declare @nuevoCodigo int
set @precioLista = (select ofer_pr_lista from GDDS2.Oferta where id_oferta = @idOferta)
set @precioOferta = (select ofer_pr_oferta from GDDS2.Oferta where id_oferta = @idOferta)
set @importe =  isnull((select ofer_pr_oferta from GDDS2.Oferta where id_oferta = @idOferta ),0) * @cantidad
set @nuevoCodigo = (select count(distinct id_compra) from GDDS2.Compra)+1
update Cliente
set clie_credito = clie_credito - @importe
where id_cliente = @idCliente


SET IDENTITY_INSERT GDDS2.[Compra] on

insert into Compra(id_compra,id_oferta,id_cliente,compra_fecha,compra_precio_lista,compra_precio_oferta,compra_cantidad,compra_canjeado,compra_fecha_vencimiento)
values(@nuevoCodigo,@idOferta,@idCliente,@fechaActualParseada,@precioLista,@precioOferta,@cantidad,0,dateadd(DAY,14,GETDATE()))

SET IDENTITY_INSERT GDDS2.[Compra] off

update Oferta
set ofer_cant_disp = ofer_cant_disp - @cantidad
where id_oferta = @idOferta


set @codigoCuponResultante = @nuevoCodigo
return

end

GO


--trigger ante la carga de credito

create trigger [GDDS2].cargaCredito on GDDS2.credito after INSERT
as begin
declare @id_carga_credito int, @idCliente int ,@cred_monto decimal(12,2)
declare c cursor for (select id_carga_credito,id_cliente,cred_monto from inserted)
open c 
fetch next from c into @id_carga_credito,@idCliente,@cred_monto 
while (@@FETCH_STATUS = 0)
begin
update Cliente
set clie_credito = clie_credito + @cred_monto 
where id_cliente = @idCliente
fetch next from c into @id_carga_credito,@idCliente,@cred_monto
end
close c
deallocate c
end

GO



create procedure [GDDS2].cargarEntrega(@idProveedor int, @idCompra int, @idCliente int,@fechaActual nvarchar(50))
as begin
declare @idOferta nvarchar(50), @fechaActualParseada datetime
set @idOferta = (select id_oferta from GDDS2.Compra where id_compra = @idCompra)
set  @fechaActualParseada = (convert(datetime,convert(datetime,@fechaActual,103),120))
if( @idProveedor not in (select id_proveedor from GDDS2.Oferta where id_oferta = @idOferta)     )
begin
RAISERROR('El codigo de compra no pertenece al proveedor',16,1)
return
end

if ( (select c.compra_canjeado from GDDS2.Compra c where c.id_compra = @idCompra ) = 1       )
begin
set @resultado = 2
RAISERROR('El cupon ya ha sido canjeado',15,1)
return
end

insert into GDDS2.Entrega (ent_fecha,id_compra,id_cliente)
values (@fechaActualParseada,@idCompra,@idCliente)

update Compra
set compra_canjeado = 1 
where id_compra = @idCompra
end

GO





--funciones de listados estadisticos, ambos reciben 2 fechas q seran ingresadas desde la aplicacion


create function [GDDS2].listadoEstadisticoProveedoresMayorDescuento(@fecha1 nvarchar(50) , @fecha2 nvarchar(50))
returns table
as 
return 
select TOP 5 prov.id_proveedor PROVEEDOR,ru.rubr_detalle RUBRO,prov_razon_social RAZON_SOCIAL, prov.prov_CUIT CUIT, prov.prov_email EMAIL, prov.prov_telefono TELEFONO, prov.prov_contacto CONTACTO,(select  top 1(convert( nvarchar(10),cast(((ofe.ofer_pr_lista - ofe.ofer_pr_oferta )/ofe.ofer_pr_lista)*100 as decimal(12,2) ))+'%') from GDDS2.Proveedor p2 join GDDS2.Oferta ofe on ofe.id_proveedor = p2.id_proveedor where p2.id_proveedor =prov.id_proveedor and ofe.ofer_f_public between (convert(datetime,convert(datetime,@fecha1,103),120)) and (convert(datetime,convert(datetime,@fecha2,103),120))   order by 1 desc) PORCENTAJE_MAS_ALTO
from GDDS2.Proveedor prov join GDDS2.Rubro ru on ru.rubr_id = prov.rubr_id 
where prov.prov_activo = 1 
order by 8 desc

GO

create function [GDDS2].listadoEstadisticoMayorFacturacion(@fecha1 nvarchar(50), @fecha2 nvarchar(50))
returns table
as 
return 
select TOP 5 prov.id_proveedor PROVEEDOR,ru.rubr_detalle RUBRO,prov_razon_social RAZON_SOCIAL, prov.prov_CUIT CUIT, prov.prov_email EMAIL, prov.prov_telefono TELEFONO, prov.prov_contacto CONTACTO, (select isnull(sum(f.fact_importe),0) from GDDS2.Factura f where f.id_proveedor = prov.id_proveedor and f.fact_fecha  between (convert(datetime,convert(datetime,@fecha1,103),120)) and (convert(datetime,convert(datetime,@fecha2,103),120))             ) TOTAL_FACTURADO
from GDDS2.Proveedor prov join GDDS2.Rubro ru on ru.rubr_id = prov.rubr_id 
where prov.prov_activo = 1 
order by 8 desc

GO

--procedure para facturación
create procedure [GDDS2].facturar(@proveedor int, @fechaInicio nvarchar(50) , @fechaFin nvarchar(50),@fechaActual nvarchar(50),@numeroFactura int output, @importe decimal(12,2) output)
as begin

declare @fechaActualParseada datetime
set @fechaActualParseada = (convert(datetime,convert(datetime,@fechaActual,103),120))
set @numeroFactura = (select max(id_fact) from GDDS2.Factura)+1
set @importe = isnull((select sum(c.compra_precio_oferta * c.compra_cantidad) from GDDS2.Compra c join GDDS2.Oferta o on o.id_oferta = c.id_oferta where o.id_proveedor = @proveedor and c.compra_fecha between  ((convert(datetime,convert(datetime,@fechaInicio,103),120)) )  and ((convert(datetime,convert(datetime,@fechaFin,103),120)) )  ) ,0)

SET IDENTITY_INSERT GDDS2.[Factura] on
insert into GDDS2.Factura(id_fact,id_proveedor,fact_fecha,fact_fecha_inicio,fact_fecha_fin,fact_importe)
values(@numeroFactura,@proveedor,@fechaActualParseada,@fechaInicio,@fechaFin,@importe)
SET IDENTITY_INSERT GDDS2.[Factura] off

insert into GDDS2.Item_factura(id_fact,id_compra,item_fecha_compra,item_precio)
(select @numeroFactura,c.id_compra,c.compra_fecha,(c.compra_precio_oferta * c.compra_cantidad) from GDDS2.Compra c join GDDS2.Oferta o on o.id_oferta = c.id_oferta where o.id_proveedor = @proveedor and c.compra_fecha between  ((convert(datetime,convert(datetime,@fechaInicio,103),120)) )  and ((convert(datetime,convert(datetime,@fechaFin,103),120)) ) ) 

RETURN
end
