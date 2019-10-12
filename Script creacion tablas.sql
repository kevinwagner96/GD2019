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
	[dom_calle] [nvarchar](50) NOT NULL,
	[dom_numero] [nvarchar](50) NULL,
	[dom_depto] [int] NULL,
	[dom_piso] [int] NULL,
	[dom_ciudad] [varchar](50) NOT NULL,
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
	[prov_rubro] [nvarchar](50) NOT NULL,
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
	[usu_username] [nvarchar](50) NOT NULL,
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
VALUES (10,'INHABILITAR_CUPON');
INSERT INTO GDDS2.[funcionalidad](func_codigo, func_nombre)
VALUES (11,'CANJEAR_CUPON');


-- Inserto roles
SET IDENTITY_INSERT GDDS2.[Rol] ON

INSERT INTO GDDS2.[Rol](id_rol,rol_nombre,rol_activo)
VALUES (1,'ADMINISTRADOR',1), (2,'CLIENTE',1), (3,'PORVEEDOR',1);

SET IDENTITY_INSERT GDDS2.[Rol] OFF

GO

-- inserto usuario admin
SET IDENTITY_INSERT GDDS2.[Usuario] ON

INSERT INTO GDDS2.[Usuario](id_usuario,usu_username, usu_contrasenia,usu_cant_intentos_fallidos,usu_activo)
VALUES  (1,'admin', HASHBYTES('SHA2_256', N'w23e'),3,1)

GO

SET IDENTITY_INSERT GDDS2.[Usuario] OFF


-- Inserto rol_x_usuario
INSERT INTO GDDS2.[usuario_x_rol](id_usuario,id_rol)
VALUES (1,1)

-- Cargo relaciones en al tabla intermedia

INSERT INTO GDDS2.[rol_funcionalidad](id_rol,func_codigo)
VALUES (1,1),(1,2),(1,3),(1,4),(1,5),(1,6),(1,7),(1,8),(1,9),(1,10),(1,11),(2,2),(2,6),(2,11), (3,5),(3,9),(3,10)

-- inserto clientes, junto con sus domicilios
go
create procedure cargarClientes
as begin
declare @nombre nvarchar(50)
declare @apellido nvarchar(50)
declare @dni numeric(18,0)
declare @direccion_string nvarchar(50)
declare @telefono nvarchar(50)
declare  @email nvarchar(50)
declare @fechaNac datetime
declare @ciudad nvarchar(50)
declare @contador int 
set @contador = 1

declare cursorClientes cursor for (select distinct Cli_Nombre, Cli_Apellido,Cli_Dni,Cli_Direccion,Cli_Telefono,Cli_Mail,Cli_Fecha_Nac,Cli_Ciudad from gd_esquema.Maestra)
open cursorClientes 
fetch cursorClientes into @nombre,@apellido,@dni,@direccion_string,@telefono,@email,@fechaNac,@ciudad

while(@@FETCH_STATUS = 0)
begin

SET IDENTITY_INSERT GDDS2.[Domicilio] ON
insert into GDDS2.[Domicilio](id_domicilio,dom_calle,dom_ciudad)
values (@contador,@direccion_string,@ciudad)

SET IDENTITY_INSERT GDDS2.[Domicilio] OFF

insert into GDDS2.[Cliente](id_domicilio,clie_dni,clie_nombre,clie_apellido,clie_email,clie_telefono,clie_fecha_nac,clie_activo,clie_credito)
values(@contador,@dni,@nombre,@apellido,@email,@telefono,@fechaNac,1,0)
set @contador = @contador + 1
fetch cursorClientes into @nombre,@apellido,@dni,@direccion_string,@telefono,@email,@fechaNac,@ciudad

end
close cursorClientes
deallocate cursorClientes

end

exec cargarClientes
drop procedure cargarClientes
go

--cargo los proveedore con respectivos domicilio
create procedure cargarProveedores
as begin
declare @razon_social nvarchar(50)
declare @domicilio_string nvarchar(50)
declare @ciudad nvarchar(50)
declare @telefono nvarchar(50)
declare @cuit nvarchar(20)
declare @rubro nvarchar(50)
declare @contador int
set @contador = (select count(id_domicilio)from GDDS2.Domicilio)+1

declare cursorProveedores cursor for (select distinct isnull(Provee_RS,'--'),isnull(Provee_Dom,'--'),isnull(Provee_Ciudad,'--'),isnull(Provee_Telefono,0),isnull(Provee_CUIT,'--'),isnull(Provee_Rubro,'--') from gd_esquema.Maestra)
open cursorProveedores
fetch cursorProveedores into @razon_social,@domicilio_string,@ciudad,@telefono,@cuit,@rubro
while (@@FETCH_STATUS = 0)
begin
SET IDENTITY_INSERT GDDS2.[Domicilio] ON
insert into GDDS2.[Domicilio](id_domicilio,dom_calle,dom_ciudad)
values (@contador,@domicilio_string,@ciudad)

SET IDENTITY_INSERT GDDS2.[Domicilio] OFF

insert into GDDS2.[Proveedor] (id_domicilio,prov_CUIT,prov_razon_social,prov_telefono,prov_rubro,prov_activo)
values (@contador,@cuit,@razon_social,@telefono,@rubro,1)
set @contador = @contador + 1
fetch cursorProveedores into @razon_social,@domicilio_string,@ciudad,@telefono,@cuit,@rubro
end
close cursorProveedores
deallocate cursorProveedores
end

exec cargarProveedores
drop procedure cargarProveedores
go












