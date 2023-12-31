USE [Gestion_gastronomica]
GO
/****** Object:  Table [dbo].[BANCO]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BANCO](
	[id_banco] [int] IDENTITY(1,1) NOT NULL,
	[nombre_banco] [varchar](50) NULL,
 CONSTRAINT [PK_BANCO] PRIMARY KEY CLUSTERED 
(
	[id_banco] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CAJA]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CAJA](
	[id_caja] [int] IDENTITY(1,1) NOT NULL,
	[fecha_caja] [datetime] NULL,
	[id_usuario] [int] NULL,
	[cerrada] [bit] NULL,
	[detalle] [varchar](5000) NULL,
	[saldo_efectivo] [decimal](18, 2) NULL,
	[saldo_tarjeta] [decimal](18, 2) NULL,
	[saldo_cheque] [decimal](18, 2) NULL,
	[saldo_inicial] [decimal](18, 2) NULL,
 CONSTRAINT [PK_CAJA] PRIMARY KEY CLUSTERED 
(
	[id_caja] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CLIENTE]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CLIENTE](
	[id_cliente] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[apellido] [varchar](50) NULL,
	[correo] [varchar](50) NULL,
	[telefono_movil] [varchar](50) NULL,
	[telefono_fijo] [varchar](50) NULL,
	[direccion] [varchar](50) NULL,
	[id_condicion_iva] [int] NULL,
	[id_tipo_dni] [int] NULL,
	[numero_dni_cuit] [varchar](50) NULL,
 CONSTRAINT [PK_CLIENTE] PRIMARY KEY CLUSTERED 
(
	[id_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Condicion_iva]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Condicion_iva](
	[id_condicion_iva] [int] IDENTITY(1,1) NOT NULL,
	[nombre_condicion_iva] [varchar](50) NULL,
 CONSTRAINT [PK_Condicion_iva] PRIMARY KEY CLUSTERED 
(
	[id_condicion_iva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CUERPO_PEDIDO]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CUERPO_PEDIDO](
	[id_cuerpo_pedido] [int] IDENTITY(1,1) NOT NULL,
	[id_pedido] [int] NULL,
	[id_producto] [int] NULL,
	[cantidad] [decimal](18, 0) NULL,
	[precio] [decimal](18, 2) NULL,
 CONSTRAINT [PK_CUERPO_PEDIDO] PRIMARY KEY CLUSTERED 
(
	[id_cuerpo_pedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Egreso_efectivo]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Egreso_efectivo](
	[id_egreso_efectivo] [int] IDENTITY(1,1) NOT NULL,
	[fecha_egreso_efectivo] [datetime] NULL,
	[importe] [decimal](18, 2) NULL,
	[detalle_egreso_efectivo] [varchar](50) NULL,
	[id_caja] [int] NULL,
	[id_usuario] [int] NULL,
 CONSTRAINT [PK_Egreso_efectivo] PRIMARY KEY CLUSTERED 
(
	[id_egreso_efectivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ESTADO_PEDIDO]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ESTADO_PEDIDO](
	[id_estado_pedido] [int] IDENTITY(1,1) NOT NULL,
	[estado_pedido] [varchar](50) NULL,
 CONSTRAINT [PK_ESTADO_PEDIDO] PRIMARY KEY CLUSTERED 
(
	[id_estado_pedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[id_factura] [int] IDENTITY(1,1) NOT NULL,
	[articulo] [varchar](50) NULL,
	[cantidad] [decimal](18, 0) NULL,
	[precio] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[id_factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FORMA_PAGO]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FORMA_PAGO](
	[id_forma_pago] [int] IDENTITY(1,1) NOT NULL,
	[id_tipo_forma_pago] [int] NULL,
	[nombre_forma_pago] [varchar](50) NULL,
 CONSTRAINT [PK_FORMA_PAGO] PRIMARY KEY CLUSTERED 
(
	[id_forma_pago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GRUPO_PRODUCTO]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GRUPO_PRODUCTO](
	[id_grupo_producto] [int] IDENTITY(1,1) NOT NULL,
	[nombre_grupo_producto] [varchar](50) NULL,
 CONSTRAINT [PK_GRUPO_PRODUCTO] PRIMARY KEY CLUSTERED 
(
	[id_grupo_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GRUPO_USUARIO]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GRUPO_USUARIO](
	[id_grupo_usuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre_grupo_usuario] [varchar](50) NULL,
 CONSTRAINT [PK_GRUPO_USUARIO] PRIMARY KEY CLUSTERED 
(
	[id_grupo_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MESA]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MESA](
	[id_mesa] [int] IDENTITY(1,1) NOT NULL,
	[nombre_mesa] [varchar](50) NULL,
	[estado] [varchar](50) NULL,
	[id_reserva] [int] NULL,
	[grupo_mesa] [int] NULL,
	[cantidad_persona] [decimal](18, 0) NULL,
 CONSTRAINT [PK_MESA] PRIMARY KEY CLUSTERED 
(
	[id_mesa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OPCION_MODIFICACION]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OPCION_MODIFICACION](
	[id_opcion_modificacion] [int] IDENTITY(1,1) NOT NULL,
	[nombre_opcion_modificacion] [varchar](50) NULL,
 CONSTRAINT [PK_OPCION_MODIFICACION] PRIMARY KEY CLUSTERED 
(
	[id_opcion_modificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OPCION_MODIFICACION_PRODUCTO]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OPCION_MODIFICACION_PRODUCTO](
	[id_opcion_modificacion_producto] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
	[precio] [decimal](18, 2) NULL,
	[id_opcion_modificacion] [int] NULL,
 CONSTRAINT [PK_OPCION_MODIFICACION_PRODUCTO] PRIMARY KEY CLUSTERED 
(
	[id_opcion_modificacion_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PAGO_PEDIDO]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PAGO_PEDIDO](
	[id_pago_pedido] [int] IDENTITY(1,1) NOT NULL,
	[id_pedido] [int] NULL,
	[id_forma_pago] [int] NULL,
	[importe] [decimal](18, 2) NULL,
	[id_banco] [int] NULL,
	[id_cliente] [int] NULL,
	[nro_cheque] [varchar](50) NULL,
	[id_caja] [int] NULL,
 CONSTRAINT [PK_PAGO_PEDIDO] PRIMARY KEY CLUSTERED 
(
	[id_pago_pedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PEDIDO]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PEDIDO](
	[id_pedido] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [datetime] NULL,
	[importe] [decimal](18, 2) NULL,
	[id_mesa] [int] NULL,
	[fecha_entrega] [datetime] NULL,
	[porcentaje_descuento] [decimal](18, 2) NULL,
	[descuento] [decimal](18, 2) NULL,
	[totals] [decimal](18, 2) NULL,
	[id_estado_pedido] [int] NULL,
	[pago_cliente] [decimal](18, 2) NULL,
	[id_cliente] [int] NULL,
 CONSTRAINT [PK_PEDIDO] PRIMARY KEY CLUSTERED 
(
	[id_pedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRODUCTO]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUCTO](
	[id_producto] [int] IDENTITY(1,1) NOT NULL,
	[nombre_producto] [varchar](50) NULL,
	[id_tipo_producto] [int] NULL,
	[descripcion] [varchar](5000) NULL,
	[receta] [varchar](5000) NULL,
	[precio] [decimal](18, 2) NULL,
	[sin_disponibilidad] [bit] NULL,
	[icono] [varchar](5000) NULL,
	[id_opcion_modificacion] [int] NULL,
 CONSTRAINT [PK_PRODUCTO] PRIMARY KEY CLUSTERED 
(
	[id_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RESERVA_HORA]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RESERVA_HORA](
	[id_reserva_hora] [int] IDENTITY(1,1) NOT NULL,
	[hora_reserva] [datetime] NULL,
	[cantidad] [decimal](18, 0) NULL,
 CONSTRAINT [PK_RESERVA_HORA] PRIMARY KEY CLUSTERED 
(
	[id_reserva_hora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RESERVA_MESA]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RESERVA_MESA](
	[id_reserva_mesa] [int] IDENTITY(1,1) NOT NULL,
	[fecha_reserva] [datetime] NULL,
	[hora_reserva] [datetime] NULL,
	[nro_huesped] [decimal](18, 0) NULL,
	[id_mesa] [int] NULL,
	[estado_reserva] [varchar](50) NULL,
	[id_cliente] [int] NULL,
	[observacion] [varchar](5000) NULL,
 CONSTRAINT [PK_RESERVA_MESA] PRIMARY KEY CLUSTERED 
(
	[id_reserva_mesa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TEMP_PEDIDO]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TEMP_PEDIDO](
	[id_temp_pedido] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [datetime] NULL,
	[id_producto] [int] NULL,
	[id_cuerpo_pedido] [int] NULL,
	[id_mesa] [int] NULL,
	[id_pedido] [int] NULL,
	[precio] [decimal](18, 2) NULL,
	[cantidad] [decimal](18, 0) NULL,
 CONSTRAINT [PK_TEMP_PEDIDO] PRIMARY KEY CLUSTERED 
(
	[id_temp_pedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TEMP_TICKET]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TEMP_TICKET](
	[id_temp_ticket] [int] IDENTITY(1,1) NOT NULL,
	[id_producto] [int] NULL,
	[id_cuerpo_pedido] [int] NULL,
	[id_pedido] [int] NULL,
	[precio] [decimal](18, 2) NULL,
	[cantidad] [decimal](18, 2) NULL,
	[importe] [decimal](18, 2) NULL,
	[totals] [decimal](18, 2) NULL,
	[porcentaje_descuento] [decimal](18, 2) NULL,
	[descuento] [decimal](18, 2) NULL,
 CONSTRAINT [PK_TEMP_TICKET] PRIMARY KEY CLUSTERED 
(
	[id_temp_ticket] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_dni]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_dni](
	[id_tipo_dni] [int] NOT NULL,
	[nombre_tipo_dni] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TIPO_FORMA_PAGO]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIPO_FORMA_PAGO](
	[id_tipo_forma_pago] [int] IDENTITY(1,1) NOT NULL,
	[nombre_tipo_forma_pago] [varchar](50) NULL,
 CONSTRAINT [PK_TIPO_FORMA_PAGO] PRIMARY KEY CLUSTERED 
(
	[id_tipo_forma_pago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TIPO_PRODUCTO]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIPO_PRODUCTO](
	[id_tipo_producto] [int] IDENTITY(1,1) NOT NULL,
	[nombre_tipo_producto] [varchar](50) NULL,
	[icono] [varchar](5000) NULL,
	[id_grupo_producto] [int] NULL,
 CONSTRAINT [PK_TIPO_PRODUCTO] PRIMARY KEY CLUSTERED 
(
	[id_tipo_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USUARIO]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIO](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre_usuario] [varchar](50) NULL,
	[password_usuario] [varchar](50) NULL,
	[id_grupo_usuario] [int] NULL,
	[mail] [varchar](50) NULL,
 CONSTRAINT [PK_USUARIO] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[cop_Banco_Delete]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Banco_Delete]
    @id_banco    int
AS

DELETE FROM [dbo].[Banco]
WHERE
    [id_banco]  =  @id_banco
GO
/****** Object:  StoredProcedure [dbo].[cop_Banco_Exist]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Banco_Exist]
    @nombre_banco    varchar  (50)
AS

DECLARE @total int
SET @total = 0

SELECT
    @total = id_banco
FROM
    [dbo].[Banco]
WHERE
    [nombre_banco] = @nombre_banco

IF @total IS NULL
BEGIN
    SET @total=0
END
SELECT @total AS Total
GO
/****** Object:  StoredProcedure [dbo].[cop_Banco_Find]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Banco_Find]
    @nombre NVARCHAR (30)=NULL
AS SET NOCOUNT ON

IF @nombre IS NOT NULL
BEGIN
SELECT @nombre=RTRIM(@nombre)+'%'
SELECT
    [id_banco] AS Id_banco ,
    RTRIM(nombre_banco) AS Nombre_banco
FROM
    [dbo].[Banco]
WHERE
    [nombre_banco] LIKE @nombre+'%'
ORDER BY
    [nombre_banco]
END
GO
/****** Object:  StoredProcedure [dbo].[cop_Banco_GetAll]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Banco_GetAll]
AS

SELECT
    [id_banco] AS Id_banco ,
    RTRIM(nombre_banco) AS Nombre_banco
FROM
    [dbo].[Banco]
ORDER BY
    [nombre_banco]
GO
/****** Object:  StoredProcedure [dbo].[cop_Banco_GetCmb]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Banco_GetCmb]
AS

SELECT
    [id_banco],
    [nombre_banco]
FROM
    [dbo].[Banco]
ORDER BY
    [nombre_banco]
GO
/****** Object:  StoredProcedure [dbo].[cop_Banco_GetOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Banco_GetOne]
    @id_banco    int
AS

SELECT
    [id_banco] AS Id_banco ,
    [nombre_banco] AS Nombre_banco
FROM
    [dbo].[Banco]
WHERE
    [id_banco]  =  @id_banco
GO
/****** Object:  StoredProcedure [dbo].[cop_Banco_Insert]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Banco_Insert]
    @id_banco    int  output,
    @nombre_banco    varchar  (50)
AS

INSERT INTO [dbo].[Banco]
(
    [nombre_banco]
)
VALUES
(
    @nombre_banco
)
SET @id_banco = @@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[cop_Banco_InsertOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Banco_InsertOne]
AS

INSERT INTO [dbo].[Banco]
(
    [nombre_banco]
)
VALUES
(
    'Ninguno'
)
GO
/****** Object:  StoredProcedure [dbo].[cop_Banco_Update]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Banco_Update]
    @id_banco    int  output,
    @nombre_banco    varchar  (50)
AS

UPDATE [dbo].[Banco] SET
    [nombre_banco] = @nombre_banco
WHERE
    [id_banco]  =  @id_banco
GO
/****** Object:  StoredProcedure [dbo].[cop_Caja_Delete]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Caja_Delete]
    @id_caja    int
AS

DELETE FROM [dbo].[Caja]
WHERE
    [id_caja]  =  @id_caja
GO
/****** Object:  StoredProcedure [dbo].[cop_Caja_Exist]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Caja_Exist]
    @fecha_caja    datetime  ,
    @id_usuario    int  ,
    @cerrada    bit  ,
    @detalle    varchar  (5000),
    @saldo_efectivo    decimal  (18,2),
    @saldo_tarjeta    decimal  (18,2),
    @saldo_cheque    decimal  (18,2),
    @saldo_inicial    decimal  (18,2)
AS

DECLARE @total int
SET @total = 0

SELECT
    @total = id_caja
FROM
    [dbo].[Caja]
WHERE
    [fecha_caja] = @fecha_caja AND
    [id_usuario] = @id_usuario AND
    [cerrada] = @cerrada AND
    [detalle] = @detalle AND
    [saldo_efectivo] = @saldo_efectivo AND
    [saldo_tarjeta] = @saldo_tarjeta AND
    [saldo_cheque] = @saldo_cheque AND
    [saldo_inicial] = @saldo_inicial

IF @total IS NULL
BEGIN
    SET @total=0
END
SELECT @total AS Total
GO
/****** Object:  StoredProcedure [dbo].[cop_Caja_Find]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Caja_Find]
    @nombre NVARCHAR (30)=NULL
AS SET NOCOUNT ON

IF @nombre IS NOT NULL
BEGIN
SELECT @nombre=RTRIM(@nombre)+'%'
SELECT
    [id_caja] AS Id_caja ,
    [fecha_caja] AS Fecha_caja ,
    [id_usuario] AS Id_usuario ,
    [cerrada] AS Cerrada ,
    RTRIM(detalle) AS Detalle ,
    [saldo_efectivo] AS Saldo_efectivo ,
    [saldo_tarjeta] AS Saldo_tarjeta ,
    [saldo_cheque] AS Saldo_cheque ,
    [saldo_inicial] AS Saldo_inicial
FROM
    [dbo].[Caja]
WHERE
    [fecha_caja] LIKE @nombre+'%'
ORDER BY
    [fecha_caja]
END
GO
/****** Object:  StoredProcedure [dbo].[cop_Caja_GetAbiertas]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 


CREATE PROCEDURE [dbo].[cop_Caja_GetAbiertas]
   
AS

SELECT
    [id_caja] AS [Id caja] ,
    [fecha_caja] AS [fecha_caja] ,
    [id_usuario] AS [Id usuario] ,
    [cerrada] AS [Cerrada] ,
    [detalle] AS [Detalle] ,
    [saldo_efectivo] AS [Saldo efectivo] ,
    [saldo_tarjeta] AS [Saldo tarjeta] ,
    [saldo_cheque] AS [Saldo cheque]

FROM
    [dbo].[Caja]
 
where
	   cerrada = 0
order by 
	id_caja




GO
/****** Object:  StoredProcedure [dbo].[cop_Caja_GetAll]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Caja_GetAll]
AS

SELECT
    [id_caja] AS Id_caja ,
    [fecha_caja] AS Fecha_caja ,
    [id_usuario] AS Id_usuario ,
    [cerrada] AS Cerrada ,
    RTRIM(detalle) AS Detalle ,
    [saldo_efectivo] AS Saldo_efectivo ,
    [saldo_tarjeta] AS Saldo_tarjeta ,
    [saldo_cheque] AS Saldo_cheque ,
    [saldo_inicial] AS Saldo_inicial
FROM
    [dbo].[Caja]
ORDER BY
    [fecha_caja]
GO
/****** Object:  StoredProcedure [dbo].[cop_Caja_GetCerradas]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 

CREATE PROCEDURE [dbo].[cop_Caja_GetCerradas]
   
AS

SELECT
    [id_caja] AS [Id caja] ,
    [fecha_caja] AS [fecha_caja] ,
    [id_usuario] AS [Id usuario] ,
    [cerrada] AS [Cerrada] ,
    [detalle] AS [Detalle] ,
    [saldo_efectivo] AS [Saldo efectivo] ,
    [saldo_tarjeta] AS [Saldo tarjeta] ,
    [saldo_cheque] AS [Saldo cheque]

FROM
    [dbo].[Caja]
 
where
	   cerrada = 1
order by 
	id_caja


GO
/****** Object:  StoredProcedure [dbo].[cop_Caja_GetCmb]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Caja_GetCmb]
AS

SELECT
    [id_caja],
    [fecha_caja],
    [id_usuario],
    [cerrada],
    [detalle],
    [saldo_efectivo],
    [saldo_tarjeta],
    [saldo_cheque],
    [saldo_inicial]
FROM
    [dbo].[Caja]
ORDER BY
    [fecha_caja]
GO
/****** Object:  StoredProcedure [dbo].[cop_Caja_GetCmb_2]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[cop_Caja_GetCmb_2]
AS

SELECT
    [id_caja],
    convert(varchar(50), id_caja) + '  -  '+ convert(varchar(50),[fecha_caja]) AS Caja,
    [id_usuario],
    [cerrada],
    [detalle],
    [saldo_efectivo],
    [saldo_tarjeta],
    [saldo_cheque]
FROM
    [dbo].[Caja]
ORDER BY
    [fecha_caja]


GO
/****** Object:  StoredProcedure [dbo].[cop_Caja_GetEntreFechas]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Caja_GetEntreFechas]
		@fecha_inicio datetime,
		@fecha_fin datetime
AS

set @fecha_fin = dateadd(d,1,@fecha_fin)


SELECT
    [id_caja] AS [id caja] ,
	[id_caja] AS [nombre caja],
    [saldo_efectivo] AS [Saldo efectivo] ,
    [saldo_tarjeta] AS [Saldo tarjeta] ,
    [saldo_cheque] AS [Saldo cheque]
FROM
    [dbo].[Caja]
WHERE
	[fecha_caja] >= @fecha_inicio and
	[fecha_caja] < @fecha_fin AND
	cerrada = 1 --caja cerrada
order by
	id_caja

GO
/****** Object:  StoredProcedure [dbo].[cop_Caja_GetOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Caja_GetOne]
    @id_caja    int
AS

SELECT
    [id_caja] AS Id_caja ,
    [fecha_caja] AS Fecha_caja ,
    [id_usuario] AS Id_usuario ,
    [cerrada] AS Cerrada ,
    [detalle] AS Detalle ,
    [saldo_efectivo] AS Saldo_efectivo ,
    [saldo_tarjeta] AS Saldo_tarjeta ,
    [saldo_cheque] AS Saldo_cheque ,
    [saldo_inicial] AS Saldo_inicial
FROM
    [dbo].[Caja]
WHERE
    [id_caja]  =  @id_caja
GO
/****** Object:  StoredProcedure [dbo].[cop_Caja_GetPrint]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Caja_GetPrint]
	@id_caja int
AS

SELECT
    [Caja].[id_caja] AS Id_caja ,
    [fecha_caja] AS Fecha_caja ,
    RTRIM(detalle) AS Detalle_caja ,
    [saldo_efectivo] AS Saldo_efectivo ,
    [saldo_tarjeta] AS Saldo_tarjeta ,
    [saldo_cheque] AS Saldo_cheque ,
    [saldo_inicial] AS Saldo_inicial,
	egreso_efectivo.importe AS importe_egreso,
	egreso_efectivo.detalle_egreso_efectivo,
	pago_pedido.importe AS importe_ingreso,
	FORMA_PAGO.nombre_forma_pago,
	TIPO_FORMA_PAGO.nombre_tipo_forma_pago
FROM
    [dbo].[Caja] INNER JOIN
	Egreso_efectivo ON Egreso_efectivo.id_caja = CAJA.id_caja INNER JOIN
	PAGO_PEDIDO ON PAGO_PEDIDO.id_caja = CAJA.id_caja INNER JOIN
	FORMA_PAGO ON pago_pedido.id_forma_pago = forma_pago.id_forma_pago INNER JOIN
	tipo_forma_pago ON forma_pago.id_tipo_forma_pago = tipo_forma_pago.id_tipo_forma_pago
WHERE
	caja.id_caja = @id_caja
ORDER BY
    [fecha_caja]
GO
/****** Object:  StoredProcedure [dbo].[cop_Caja_GetUltimo_id]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 
 

CREATE PROCEDURE [dbo].[cop_Caja_GetUltimo_id]
AS

declare @Total decimal (18,0)
 
SELECT     
 	 @Total= [id_caja] 
FROM
    [dbo].[Caja]
if @Total is null
begin
set @Total=0
end
select @Total as Ultimo_id
 


GO
/****** Object:  StoredProcedure [dbo].[cop_Caja_Insert]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Caja_Insert]
    @id_caja    int  output,
    @fecha_caja    datetime  ,
    @id_usuario    int  ,
    @cerrada    bit  ,
    @detalle    varchar  (5000),
    @saldo_efectivo    decimal  (18,2),
    @saldo_tarjeta    decimal  (18,2),
    @saldo_cheque    decimal  (18,2),
    @saldo_inicial    decimal  (18,2)
AS

INSERT INTO [dbo].[Caja]
(
    [fecha_caja],
    [id_usuario],
    [cerrada],
    [detalle],
    [saldo_efectivo],
    [saldo_tarjeta],
    [saldo_cheque],
    [saldo_inicial]
)
VALUES
(
    @fecha_caja,
    @id_usuario,
    @cerrada,
    @detalle,
    @saldo_efectivo,
    @saldo_tarjeta,
    @saldo_cheque,
    @saldo_inicial
)
SET @id_caja = @@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[cop_Caja_InsertOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Caja_InsertOne]
AS

INSERT INTO [dbo].[Caja]
(
    [fecha_caja],
    [id_usuario],
    [cerrada],
    [detalle],
    [saldo_efectivo],
    [saldo_tarjeta],
    [saldo_cheque],
    [saldo_inicial]
)
VALUES
(
    '01-01-2000',
    1,
    0,
    'Ninguno',
    0,
    0,
    0,
     0 
)
GO
/****** Object:  StoredProcedure [dbo].[cop_Caja_Update]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Caja_Update]
    @id_caja    int  output,
    @fecha_caja    datetime  ,
    @id_usuario    int  ,
    @cerrada    bit  ,
    @detalle    varchar  (5000),
    @saldo_efectivo    decimal  (18,2),
    @saldo_tarjeta    decimal  (18,2),
    @saldo_cheque    decimal  (18,2),
    @saldo_inicial    decimal  (18,2)
AS

UPDATE [dbo].[Caja] SET
    [fecha_caja] = @fecha_caja,
    [id_usuario] = @id_usuario,
    [cerrada] = @cerrada,
    [detalle] = @detalle,
    [saldo_efectivo] = @saldo_efectivo,
    [saldo_tarjeta] = @saldo_tarjeta,
    [saldo_cheque] = @saldo_cheque,
    [saldo_inicial] = @saldo_inicial
WHERE
    [id_caja]  =  @id_caja
GO
/****** Object:  StoredProcedure [dbo].[cop_Cliente_Delete]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Cliente_Delete]
    @id_cliente    int
AS

DELETE FROM [dbo].[Cliente]
WHERE
    [id_cliente]  =  @id_cliente
GO
/****** Object:  StoredProcedure [dbo].[cop_Cliente_Exist]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Cliente_Exist]
    @nombre    varchar  (50),
    @apellido    varchar  (50),
    @correo    varchar  (50),
    @telefono_movil    varchar  (50),
    @telefono_fijo    varchar  (50),
    @direccion    varchar  (50),
    @id_condicion_iva    int  ,
    @id_tipo_dni    int  ,
    @numero_dni_cuit    varchar  (50)
AS

DECLARE @total int
SET @total = 0

SELECT
    @total = id_cliente
FROM
    [dbo].[Cliente]
WHERE
    [nombre] = @nombre AND
    [apellido] = @apellido AND
    [correo] = @correo AND
    [telefono_movil] = @telefono_movil AND
    [telefono_fijo] = @telefono_fijo AND
    [direccion] = @direccion AND
    [id_condicion_iva] = @id_condicion_iva AND
    [id_tipo_dni] = @id_tipo_dni AND
    [numero_dni_cuit] = @numero_dni_cuit

IF @total IS NULL
BEGIN
    SET @total=0
END
SELECT @total AS Total
GO
/****** Object:  StoredProcedure [dbo].[cop_Cliente_Find]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Cliente_Find]
    @nombre NVARCHAR (30)=NULL
AS SET NOCOUNT ON

IF @nombre IS NOT NULL
BEGIN
SELECT @nombre=RTRIM(@nombre)+'%'
SELECT TOP 100
    [id_cliente] AS [Id cliente] ,
    RTRIM(nombre) AS [Nombre] ,
    RTRIM(apellido) AS [Apellido] ,
    RTRIM(correo) AS [Correo] ,
    RTRIM(telefono_movil) AS [Telefono movil] ,
    RTRIM(telefono_fijo) AS [Telefono fijo] ,
    RTRIM(direccion) AS [Direccion] ,
    [id_condicion_iva] AS [Id condicion iva] ,
    [id_tipo_dni] AS [Id tipo dni] ,
    RTRIM(numero_dni_cuit) AS [Numero dni cuit]
FROM
    [dbo].[Cliente]
WHERE
    [nombre] LIKE @nombre+'%'
ORDER BY
    [nombre]
END
GO
/****** Object:  StoredProcedure [dbo].[cop_Cliente_Find_2]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[cop_Cliente_Find_2]
    @nombre NVARCHAR (30)=NULL
AS SET NOCOUNT ON

IF @nombre IS NOT NULL
BEGIN
SELECT @nombre=RTRIM(@nombre)+'%'
SELECT TOP 100
    [id_cliente] AS [Id cliente] ,
    RTRIM(apellido) AS [Apellido] ,
    RTRIM(nombre) AS [Nombre] ,
    RTRIM(correo) AS [Correo] ,
    RTRIM(telefono_movil) AS [Telefono movil] ,
    RTRIM(telefono_fijo) AS [Telefono fijo] ,
    RTRIM(direccion) AS [Direccion] ,
    [nombre_condicion_iva] AS [Condicion iva],
	nombre_tipo_dni AS [Tipo Dni],
	numero_dni_cuit AS [Dni-Cuit]
FROM
    [dbo].[Cliente] INNER JOIN
	[dbo].Condicion_iva ON Condicion_iva.id_condicion_iva = CLIENTE.id_condicion_iva INNER JOIN
	[dbo].Tipo_dni ON Tipo_dni.id_tipo_dni= CLIENTE.id_tipo_dni
WHERE
    apellido + ' ' + [nombre] LIKE @nombre+'%'
ORDER BY
    apellido + ' ' + [nombre]
END

GO
/****** Object:  StoredProcedure [dbo].[cop_Cliente_GetAll]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Cliente_GetAll]
AS

SELECT TOP 100
    [id_cliente] AS [Id cliente] ,
    RTRIM(nombre) AS [Nombre] ,
    RTRIM(apellido) AS [Apellido] ,
    RTRIM(correo) AS [Correo] ,
    RTRIM(telefono_movil) AS [Telefono movil] ,
    RTRIM(telefono_fijo) AS [Telefono fijo] ,
    RTRIM(direccion) AS [Direccion] ,
    [id_condicion_iva] AS [Id condicion iva] ,
    [id_tipo_dni] AS [Id tipo dni] ,
    RTRIM(numero_dni_cuit) AS [Numero dni cuit]
FROM
    [dbo].[Cliente]
ORDER BY
    [nombre]
GO
/****** Object:  StoredProcedure [dbo].[cop_Cliente_GetAll_2]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Cliente_GetAll_2]
AS

SELECT
    [id_cliente] AS [Id cliente] ,
    RTRIM(apellido) AS [Apellido] ,
    RTRIM(nombre) AS [Nombre] ,
    RTRIM(correo) AS [Correo] ,
    RTRIM(telefono_movil) AS [Telefono movil] ,
    RTRIM(telefono_fijo) AS [Telefono fijo] ,
    RTRIM(direccion) AS [Direccion] ,
    [nombre_condicion_iva] AS [Condicion iva],
	nombre_tipo_dni AS [Tipo Dni],
	numero_dni_cuit AS [Dni-Cuit]
FROM
    [dbo].[Cliente] INNER JOIN
	[dbo].Condicion_iva ON Condicion_iva.id_condicion_iva = CLIENTE.id_condicion_iva INNER JOIN
	[dbo].Tipo_dni ON Tipo_dni.id_tipo_dni= CLIENTE.id_tipo_dni
ORDER BY
    apellido + ' ' + [nombre]
GO
/****** Object:  StoredProcedure [dbo].[cop_Cliente_GetCmb]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Cliente_GetCmb]
AS

SELECT
    [id_cliente],
    [nombre],
    [apellido],
    [correo],
    [telefono_movil],
    [telefono_fijo],
    [direccion],
    [id_condicion_iva],
    [id_tipo_dni],
    [numero_dni_cuit]
FROM
    [dbo].[Cliente]
ORDER BY
    [nombre]
GO
/****** Object:  StoredProcedure [dbo].[cop_Cliente_GetCmb_2]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[cop_Cliente_GetCmb_2]
AS

SELECT
    [id_cliente],
    [apellido] + ', ' +  [nombre] AS [nombre] ,
    [correo],
    [telefono_movil],
    [telefono_fijo],
    [direccion]
FROM
    [dbo].[Cliente]
ORDER BY
    [nombre]

GO
/****** Object:  StoredProcedure [dbo].[cop_Cliente_GetOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Cliente_GetOne]
    @id_cliente    int
AS

SELECT
    [id_cliente] AS [Id cliente] ,
    [nombre] AS [Nombre] ,
    [apellido] AS [Apellido] ,
    [correo] AS [Correo] ,
    [telefono_movil] AS [Telefono_movil] ,
    [telefono_fijo] AS [Telefono_fijo] ,
    [direccion] AS [Direccion] ,
    [id_condicion_iva] AS [Id_condicion_iva] ,
    [id_tipo_dni] AS [Id_tipo_dni] ,
    [numero_dni_cuit] AS [Numero_dni_cuit]
FROM
    [dbo].[Cliente]
WHERE
    [id_cliente]  =  @id_cliente
GO
/****** Object:  StoredProcedure [dbo].[cop_Cliente_GetOne_2]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[cop_Cliente_GetOne_2]
    @id_cliente    int
AS

SELECT
    [id_cliente] AS [Id cliente] ,
    [nombre] AS [Nombre] ,
    [apellido] AS [Apellido] ,
	apellido + ' ' + nombre AS [Nombre_cliente],
    [correo] AS [Correo] ,
    [telefono_movil] AS [Telefono_movil] ,
    [telefono_fijo] AS [Telefono_fijo] ,
    [direccion] AS [Direccion] ,
    [id_condicion_iva] AS [Id_condicion_iva],
	[id_tipo_dni] AS [Id_tipo_dni],
	[numero_dni_cuit] AS [Numero_dni_cuit]
FROM
    [dbo].[Cliente]
WHERE
    [id_cliente]  =  @id_cliente

GO
/****** Object:  StoredProcedure [dbo].[cop_Cliente_Insert]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Cliente_Insert]
    @id_cliente    int  output,
    @nombre    varchar  (50),
    @apellido    varchar  (50),
    @correo    varchar  (50),
    @telefono_movil    varchar  (50),
    @telefono_fijo    varchar  (50),
    @direccion    varchar  (50),
    @id_condicion_iva    int  ,
    @id_tipo_dni    int  ,
    @numero_dni_cuit    varchar  (50)
AS

INSERT INTO [dbo].[Cliente]
(
    [nombre],
    [apellido],
    [correo],
    [telefono_movil],
    [telefono_fijo],
    [direccion],
    [id_condicion_iva],
    [id_tipo_dni],
    [numero_dni_cuit]
)
VALUES
(
    @nombre,
    @apellido,
    @correo,
    @telefono_movil,
    @telefono_fijo,
    @direccion,
    @id_condicion_iva,
    @id_tipo_dni,
    @numero_dni_cuit
)
SET @id_cliente = @@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[cop_Cliente_InsertOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Cliente_InsertOne]
AS

INSERT INTO [dbo].[Cliente]
(
    [nombre],
    [apellido],
    [correo],
    [telefono_movil],
    [telefono_fijo],
    [direccion],
    [id_condicion_iva],
    [id_tipo_dni],
    [numero_dni_cuit]
)
VALUES
(
    'Ninguno',
    'Ninguno',
    'Ninguno',
    'Ninguno',
    'Ninguno',
    'Ninguno',
    1,
    1,
    'Ninguno'
)
GO
/****** Object:  StoredProcedure [dbo].[cop_Cliente_Update]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Cliente_Update]
    @id_cliente    int  output,
    @nombre    varchar  (50),
    @apellido    varchar  (50),
    @correo    varchar  (50),
    @telefono_movil    varchar  (50),
    @telefono_fijo    varchar  (50),
    @direccion    varchar  (50),
    @id_condicion_iva    int  ,
    @id_tipo_dni    int  ,
    @numero_dni_cuit    varchar  (50)
AS

UPDATE [dbo].[Cliente] SET
    [nombre] = @nombre,
    [apellido] = @apellido,
    [correo] = @correo,
    [telefono_movil] = @telefono_movil,
    [telefono_fijo] = @telefono_fijo,
    [direccion] = @direccion,
    [id_condicion_iva] = @id_condicion_iva,
    [id_tipo_dni] = @id_tipo_dni,
    [numero_dni_cuit] = @numero_dni_cuit
WHERE
    [id_cliente]  =  @id_cliente
GO
/****** Object:  StoredProcedure [dbo].[cop_Condicion_iva_Delete]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Condicion_iva_Delete]
    @id_condicion_iva    int
AS

DELETE FROM [dbo].[Condicion_iva]
WHERE
    [id_condicion_iva]  =  @id_condicion_iva
GO
/****** Object:  StoredProcedure [dbo].[cop_Condicion_iva_Exist]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Condicion_iva_Exist]
    @nombre_condicion_iva    varchar  (50)
AS

DECLARE @total int
SET @total = 0

SELECT
    @total = id_condicion_iva
FROM
    [dbo].[Condicion_iva]
WHERE
    [nombre_condicion_iva] = @nombre_condicion_iva

IF @total IS NULL
BEGIN
    SET @total=0
END
SELECT @total AS Total
GO
/****** Object:  StoredProcedure [dbo].[cop_Condicion_iva_Find]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Condicion_iva_Find]
    @nombre NVARCHAR (30)=NULL
AS SET NOCOUNT ON

IF @nombre IS NOT NULL
BEGIN
SELECT @nombre=RTRIM(@nombre)+'%'
SELECT TOP 100
    [id_condicion_iva] AS [Id condicion iva] ,
    RTRIM(nombre_condicion_iva) AS [Nombre condicion iva]
FROM
    [dbo].[Condicion_iva]
WHERE
    [nombre_condicion_iva] LIKE @nombre+'%'
ORDER BY
    [nombre_condicion_iva]
END
GO
/****** Object:  StoredProcedure [dbo].[cop_Condicion_iva_GetAll]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Condicion_iva_GetAll]
AS

SELECT TOP 100
    [id_condicion_iva] AS [Id condicion iva] ,
    RTRIM(nombre_condicion_iva) AS [Nombre condicion iva]
FROM
    [dbo].[Condicion_iva]
ORDER BY
    [nombre_condicion_iva]
GO
/****** Object:  StoredProcedure [dbo].[cop_Condicion_iva_GetCmb]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Condicion_iva_GetCmb]
AS

SELECT
    [id_condicion_iva],
    [nombre_condicion_iva]
FROM
    [dbo].[Condicion_iva]
ORDER BY
    [nombre_condicion_iva]
GO
/****** Object:  StoredProcedure [dbo].[cop_Condicion_iva_GetOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Condicion_iva_GetOne]
    @id_condicion_iva    int
AS

SELECT
    [id_condicion_iva] AS [Id_condicion_iva] ,
    [nombre_condicion_iva] AS [Nombre_condicion_iva]
FROM
    [dbo].[Condicion_iva]
WHERE
    [id_condicion_iva]  =  @id_condicion_iva
GO
/****** Object:  StoredProcedure [dbo].[cop_Condicion_iva_Insert]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Condicion_iva_Insert]
    @id_condicion_iva    int  output,
    @nombre_condicion_iva    varchar  (50)
AS

INSERT INTO [dbo].[Condicion_iva]
(
    [nombre_condicion_iva]
)
VALUES
(
    @nombre_condicion_iva
)
SET @id_condicion_iva = @@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[cop_Condicion_iva_InsertOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Condicion_iva_InsertOne]
AS

INSERT INTO [dbo].[Condicion_iva]
(
    [nombre_condicion_iva]
)
VALUES
(
    'Ninguno'
)
GO
/****** Object:  StoredProcedure [dbo].[cop_Condicion_iva_Update]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Condicion_iva_Update]
    @id_condicion_iva    int  output,
    @nombre_condicion_iva    varchar  (50)
AS

UPDATE [dbo].[Condicion_iva] SET
    [nombre_condicion_iva] = @nombre_condicion_iva
WHERE
    [id_condicion_iva]  =  @id_condicion_iva
GO
/****** Object:  StoredProcedure [dbo].[cop_Cuerpo_Pedido_Delete]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Cuerpo_Pedido_Delete]
    @id_cuerpo_pedido    int
AS

DELETE FROM [dbo].[CUERPO_PEDIDO]
WHERE
    [id_cuerpo_pedido]  =  @id_cuerpo_pedido



GO
/****** Object:  StoredProcedure [dbo].[cop_Cuerpo_Pedido_DeletexPedidos]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[cop_Cuerpo_Pedido_DeletexPedidos]
    @id_pedido    int
AS

DELETE FROM [dbo].[CUERPO_PEDIDO]
WHERE
    [id_pedido]  =  @id_pedido





GO
/****** Object:  StoredProcedure [dbo].[cop_Cuerpo_Pedido_Exist]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Cuerpo_Pedido_Exist]
	@id_pedido int,
	@id_producto int,
	@cantidad decimal(18,0),
	@precio decimal(18,2)
AS

DECLARE @total int
SET @total = 0

SELECT
    @total = id_cuerpo_pedido
FROM
    [dbo].[CUERPO_PEDIDO]
WHERE
    [id_pedido] = @id_pedido and
	[id_producto] = @id_producto and
	[cantidad] = cantidad and
	[precio] = @precio

IF @total IS NULL
BEGIN
    SET @total=0
END
SELECT @total AS Total



GO
/****** Object:  StoredProcedure [dbo].[cop_Cuerpo_Pedido_Find]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Cuerpo_Pedido_Find]
    @nombre NVARCHAR (30)=NULL
AS SET NOCOUNT ON

IF @nombre IS NOT NULL
BEGIN
SELECT @nombre=RTRIM(@nombre)+'%'
SELECT TOP 100
    [id_cuerpo_pedido] AS [id cuerpo pedido] ,
    [id_pedido] AS [id pedido],
	[id_producto] as [id producto],
	[cantidad] as [cantidad],
	[precio] as [precio]
	
FROM
    [dbo].[CUERPO_PEDIDO]
WHERE
    [id_cuerpo_pedido] LIKE @nombre+'%'
ORDER BY
    [id_cuerpo_pedido]
END



GO
/****** Object:  StoredProcedure [dbo].[cop_Cuerpo_Pedido_Find_2]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[cop_Cuerpo_Pedido_Find_2]
    @nombre NVARCHAR (30)=NULL
AS SET NOCOUNT ON

IF @nombre IS NOT NULL
BEGIN
SELECT @nombre=RTRIM(@nombre)+'%'
SELECT TOP 100
    [id_cuerpo_pedido] AS [id cuerpo pedido] ,
    pe.[fecha] AS [fecha],
	pr.[nombre_producto] as [nombre producto],
	cp.[cantidad] as [cantidad],
	cp.[precio] as [precio]
	
FROM
    [dbo].[CUERPO_PEDIDO] cp, [dbo].[PRODUCTO] pr, [dbo].[PEDIDO] pe
WHERE
	cp.[id_producto] = pr.[id_producto] and
	cp.[id_pedido] = pe.[id_pedido] and
    [nombre_producto] LIKE @nombre+'%'
ORDER BY
    [nombre_producto]
END




GO
/****** Object:  StoredProcedure [dbo].[cop_Cuerpo_Pedido_GetAll]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Cuerpo_Pedido_GetAll]
AS

SELECT TOP 100
	[id_cuerpo_pedido] AS [id cuerpo pedido],
    [id_pedido] AS [id pedido],
	[id_producto] as [id producto],
	[cantidad] as [cantidad],
	[precio] as [precio]
FROM
    [dbo].[CUERPO_PEDIDO]
ORDER BY
    [id_cuerpo_pedido]

GO
/****** Object:  StoredProcedure [dbo].[cop_Cuerpo_Pedido_GetAll_2]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cop_Cuerpo_Pedido_GetAll_2]
AS

SELECT TOP 100
	[id_cuerpo_pedido] AS [id cuerpo pedido] ,
    pe.[fecha] AS [fecha],
	pr.[nombre_producto] as [nombre producto],
	[cantidad] as [cantidad],
	cp.[precio] as [precio]
FROM
    [dbo].[CUERPO_PEDIDO] cp, [dbo].[PEDIDO] pe, [dbo].[PRODUCTO] pr
WHERE cp.[id_pedido] = pe.[id_pedido] and
	  cp.[id_producto] = pr.[id_producto]
ORDER BY
    [nombre_producto]
GO
/****** Object:  StoredProcedure [dbo].[cop_Cuerpo_Pedido_GetAllPrint]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[cop_Cuerpo_Pedido_GetAllPrint]
	@id_pedido int

AS

SELECT
    producto.[nombre_producto] as [nombre producto],
	[cantidad] as [cantidad],
	producto.[precio] as [precio],
	cuerpo_pedido.id_pedido,
	nombre_mesa
	
FROM
    [dbo].[CUERPO_PEDIDO] INNER JOIN
	pedido ON pedido.[id_pedido] = cuerpo_pedido.[id_pedido] INNER JOIN
	mesa ON mesa.id_mesa = pedido.id_mesa INNER JOIN
	PRODUCTO ON producto.id_producto = cuerpo_pedido.id_producto
WHERE
	cuerpo_pedido.id_pedido = @id_pedido
	
ORDER BY
    [nombre_producto]






GO
/****** Object:  StoredProcedure [dbo].[cop_Cuerpo_Pedido_GetAllPrintTicket]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[cop_Cuerpo_Pedido_GetAllPrintTicket]
	@id_pedido int
AS

SELECT
    producto.[nombre_producto] as [producto],
	[cantidad] as [cantidad],
	producto.[precio] as [precio],
	cantidad * cuerpo_pedido.precio as Total,
	cuerpo_pedido.id_pedido,
	nombre_mesa
FROM
    [dbo].[CUERPO_PEDIDO] INNER JOIN
	pedido ON pedido.[id_pedido] = cuerpo_pedido.[id_pedido] INNER JOIN
	mesa ON mesa.id_mesa = pedido.id_mesa INNER JOIN
	PRODUCTO ON producto.id_producto = cuerpo_pedido.id_producto
WHERE
	cuerpo_pedido.id_pedido = @id_pedido
ORDER BY
    id_cuerpo_pedido







GO
/****** Object:  StoredProcedure [dbo].[cop_Cuerpo_Pedido_GetCmb]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Cuerpo_Pedido_GetCmb]
AS

SELECT
	[id_cuerpo_pedido],
    [id_pedido],
	[id_producto],
	[cantidad],
	[precio]
FROM
    [dbo].[CUERPO_PEDIDO]
ORDER BY
    [cantidad]



GO
/****** Object:  StoredProcedure [dbo].[cop_Cuerpo_Pedido_GetCuerpoPedido]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[cop_Cuerpo_Pedido_GetCuerpoPedido]
    @id_pedido    int,
	@id_producto int
AS

SELECT
	[id_cuerpo_pedido] AS [id cuerpo pedido]
FROM
    [dbo].[CUERPO_PEDIDO] INNER JOIN
	producto ON producto.id_producto = cuerpo_pedido.id_producto INNER JOIN
	pedido ON pedido.id_pedido = cuerpo_pedido.id_pedido
WHERE
    cuerpo_pedido.[id_pedido]  =  @id_pedido AND
	cuerpo_pedido.[id_producto] = @id_producto




GO
/****** Object:  StoredProcedure [dbo].[cop_Cuerpo_Pedido_GetMesa]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[cop_Cuerpo_Pedido_GetMesa]
	--@id_pedido int,
	@id_mesa int

AS

SELECT
	[id_cuerpo_pedido] AS [id cuerpo pedido],
	producto.[id_producto],
    producto.[nombre_producto] as [nombre producto],
	[cantidad] as [cantidad],
	cuerpo_pedido.[precio] as [precio],
	CONVERT(nvarchar(5),[fecha],108) AS [Hora]
FROM
    [dbo].[CUERPO_PEDIDO] INNER JOIN
	pedido ON pedido.[id_pedido] = cuerpo_pedido.[id_pedido] INNER JOIN
	mesa ON mesa.id_mesa = pedido.id_mesa INNER JOIN
	PRODUCTO ON producto.id_producto = cuerpo_pedido.id_producto
WHERE
	  --cuerpo_pedido.id_pedido = @id_pedido AND
	  pedido.id_mesa = @id_mesa AND
	  pedido.id_estado_pedido = 4
	
ORDER BY
    [nombre_producto]





GO
/****** Object:  StoredProcedure [dbo].[cop_Cuerpo_Pedido_GetMesa_2]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






Create PROCEDURE [dbo].[cop_Cuerpo_Pedido_GetMesa_2]
	--@id_pedido int,
	@id_mesa int

AS

SELECT
	[id_cuerpo_pedido] AS [id cuerpo pedido],
	cuerpo_pedido.[id_pedido] AS [id pedido],
	producto.[id_producto],
    producto.[nombre_producto] as [nombre producto],
	[cantidad] as [cantidad],
	cuerpo_pedido.[precio] as [precio],
	CONVERT(nvarchar(5),[fecha],108) AS [Hora]
FROM
    [dbo].[CUERPO_PEDIDO] INNER JOIN
	pedido ON pedido.[id_pedido] = cuerpo_pedido.[id_pedido] INNER JOIN
	mesa ON mesa.id_mesa = pedido.id_mesa INNER JOIN
	PRODUCTO ON producto.id_producto = cuerpo_pedido.id_producto
WHERE
	  --cuerpo_pedido.id_pedido = @id_pedido AND
	  pedido.id_mesa = @id_mesa AND
	  pedido.id_estado_pedido = 4
	
ORDER BY
    [nombre_producto]






GO
/****** Object:  StoredProcedure [dbo].[cop_Cuerpo_Pedido_GetOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Cuerpo_Pedido_GetOne]
    @id_cuerpo_pedido    int
AS

SELECT
	[id_cuerpo_pedido] AS [id cuerpo pedido] ,
    [id_pedido] AS [id pedido],
	[id_producto] as [id producto],
	[cantidad] as [cantidad],
	[precio] as [precio]
FROM
    [dbo].[CUERPO_PEDIDO]
WHERE
    [id_cuerpo_pedido]  =  @id_cuerpo_pedido



GO
/****** Object:  StoredProcedure [dbo].[cop_Cuerpo_Pedido_GetPedido]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[cop_Cuerpo_Pedido_GetPedido]
	@id_pedido int
	--@id_mesa int

AS

SELECT TOP 100
	[id_cuerpo_pedido] AS [id cuerpo pedido],
	producto.[id_producto],
    producto.[nombre_producto] as [Producto],
	[cantidad] as [cantidad],
	cuerpo_pedido.[precio] as [Precio],
	pedido.[fecha] AS [Fecha]
FROM
    [dbo].[CUERPO_PEDIDO] INNER JOIN
	pedido ON pedido.[id_pedido] = cuerpo_pedido.[id_pedido] INNER JOIN
	mesa ON mesa.id_mesa = pedido.id_mesa INNER JOIN
	PRODUCTO ON producto.id_producto = cuerpo_pedido.id_producto
WHERE
	  cuerpo_pedido.id_pedido = @id_pedido --AND
	  --pedido.id_mesa = @id_mesa
	
ORDER BY
    [nombre_producto]




GO
/****** Object:  StoredProcedure [dbo].[cop_Cuerpo_pedido_GetReporte]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[cop_Cuerpo_pedido_GetReporte]
	@id_pedido int

AS
SELECT     
	dbo.PEDIDO.fecha,
	dbo.CUERPO_PEDIDO.cantidad,
	dbo.PRODUCTO.precio, 
	dbo.PRODUCTO.nombre_producto, 
	dbo.MESA.nombre_mesa,
	dbo.PEDIDO.id_pedido,
	dbo.PEDIDO.importe,
	dbo.PEDIDO.totals, 
	dbo.PEDIDO.porcentaje_descuento, 
	dbo.PEDIDO.descuento
FROM         
	dbo.CUERPO_PEDIDO INNER JOIN
	dbo.PEDIDO ON dbo.CUERPO_PEDIDO.id_pedido = dbo.PEDIDO.id_pedido INNER JOIN
	dbo.PRODUCTO ON dbo.CUERPO_PEDIDO.id_producto = dbo.PRODUCTO.id_producto INNER JOIN
	dbo.MESA ON dbo.PEDIDO.id_mesa = dbo.MESA.id_mesa
WHERE
	dbo.PEDIDO.id_pedido = @id_pedido

GO
/****** Object:  StoredProcedure [dbo].[cop_Cuerpo_Pedido_Insert]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[cop_Cuerpo_Pedido_Insert]
    @id_cuerpo_pedido int output,
	@id_pedido int,
	@id_producto int,
	@cantidad decimal(18,0),
	@precio decimal(18,2)
AS

INSERT INTO [dbo].[CUERPO_PEDIDO]
(
    [id_pedido],
	[id_producto],
	[cantidad],
	[precio]
)
VALUES
(
	@id_pedido,
	@id_producto,
	@cantidad,
	@precio
)
SET @id_cuerpo_pedido = @@IDENTITY




GO
/****** Object:  StoredProcedure [dbo].[cop_Cuerpo_Pedido_InsertOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Cuerpo_Pedido_InsertOne]
AS

INSERT INTO [dbo].[CUERPO_PEDIDO]
(
    [id_pedido],
	[id_producto],
	[cantidad],
	[precio]
)
VALUES
(
    1,
	1,
	0,
	0.0
)



GO
/****** Object:  StoredProcedure [dbo].[cop_Cuerpo_Pedido_Update]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Cuerpo_Pedido_Update]
    @id_cuerpo_pedido    int  output,
	@id_pedido int,
	@id_producto int,
	@cantidad decimal(18,0),
	@precio decimal(18,2)
AS

UPDATE [dbo].[CUERPO_PEDIDO] SET
    [id_pedido] = @id_pedido,
	[id_producto] = @id_producto,
	[cantidad] = @cantidad,
	[precio] = @precio
WHERE
    [id_cuerpo_pedido]  =  @id_cuerpo_pedido

GO
/****** Object:  StoredProcedure [dbo].[cop_Egreso_efectivo_Delete]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Egreso_efectivo_Delete]
    @id_egreso_efectivo    int
AS

DELETE FROM [dbo].[Egreso_efectivo]
WHERE
    [id_egreso_efectivo]  =  @id_egreso_efectivo
GO
/****** Object:  StoredProcedure [dbo].[cop_Egreso_efectivo_EfectivoxCaja]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Egreso_efectivo_EfectivoxCaja]
    @id_caja    int
AS

DECLARE @total int
SET @total = 0

SELECT
    @total = sum(importe)
FROM
    [dbo].[Egreso_efectivo]
WHERE
    [id_caja] = @id_caja

IF @total IS NULL
BEGIN
    SET @total=0
END
SELECT @total AS Total
GO
/****** Object:  StoredProcedure [dbo].[cop_Egreso_efectivo_Exist]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Egreso_efectivo_Exist]
    @fecha_egreso_efectivo    datetime  ,
    @importe    decimal  (18,2),
    @detalle_egreso_efectivo    varchar  (50),
    @id_caja    int  ,
    @id_usuario    int  
AS

DECLARE @total int
SET @total = 0

SELECT
    @total = id_egreso_efectivo
FROM
    [dbo].[Egreso_efectivo]
WHERE
    [fecha_egreso_efectivo] = @fecha_egreso_efectivo AND
    [importe] = @importe AND
    [detalle_egreso_efectivo] = @detalle_egreso_efectivo AND
    [id_caja] = @id_caja AND
    [id_usuario] = @id_usuario

IF @total IS NULL
BEGIN
    SET @total=0
END
SELECT @total AS Total
GO
/****** Object:  StoredProcedure [dbo].[cop_Egreso_efectivo_Find]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Egreso_efectivo_Find]
    @nombre NVARCHAR (30)=NULL
AS SET NOCOUNT ON

IF @nombre IS NOT NULL
BEGIN
SELECT @nombre=RTRIM(@nombre)+'%'
SELECT TOP 100
    [id_egreso_efectivo] AS [Id egreso efectivo] ,
    [fecha_egreso_efectivo] AS [Fecha egreso efectivo] ,
    [importe] AS [Importe] ,
    RTRIM(detalle_egreso_efectivo) AS [Detalle egreso efectivo] ,
    [id_caja] AS [Id caja] ,
    [id_usuario] AS [Id usuario]
FROM
    [dbo].[Egreso_efectivo]
WHERE
    [fecha_egreso_efectivo] LIKE @nombre+'%'
ORDER BY
    [fecha_egreso_efectivo]
END
GO
/****** Object:  StoredProcedure [dbo].[cop_Egreso_efectivo_GetAll]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Egreso_efectivo_GetAll]
AS

SELECT TOP 100
    [id_egreso_efectivo] AS [Id egreso efectivo] ,
    [fecha_egreso_efectivo] AS [Fecha egreso efectivo] ,
    [importe] AS [Importe] ,
    RTRIM(detalle_egreso_efectivo) AS [Detalle egreso efectivo] ,
    [id_caja] AS [Id caja] ,
    [id_usuario] AS [Id usuario]
FROM
    [dbo].[Egreso_efectivo]
ORDER BY
    [fecha_egreso_efectivo]
GO
/****** Object:  StoredProcedure [dbo].[cop_Egreso_efectivo_GetCaja]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Egreso_efectivo_GetCaja]
	@id_caja int
AS

SELECT
    [id_egreso_efectivo] AS [Id egreso efectivo] ,
    [fecha_egreso_efectivo] AS [Fecha egreso efectivo] ,
    [importe] AS [Importe] ,
    RTRIM(detalle_egreso_efectivo) AS [Detalle egreso efectivo] ,
    [id_caja] AS [Id caja] ,
    [Egreso_efectivo].[id_usuario] AS [Id usuario],
	nombre_usuario
FROM
    [dbo].[Egreso_efectivo] inner join
	usuario ON usuario.id_usuario = egreso_efectivo.id_usuario
WHERE
	id_caja = @id_caja
ORDER BY
    [fecha_egreso_efectivo]
GO
/****** Object:  StoredProcedure [dbo].[cop_Egreso_efectivo_GetCmb]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Egreso_efectivo_GetCmb]
AS

SELECT
    [id_egreso_efectivo],
    [fecha_egreso_efectivo],
    [importe],
    [detalle_egreso_efectivo],
    [id_caja],
    [id_usuario]
FROM
    [dbo].[Egreso_efectivo]
ORDER BY
    [fecha_egreso_efectivo]
GO
/****** Object:  StoredProcedure [dbo].[cop_Egreso_efectivo_GetOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Egreso_efectivo_GetOne]
    @id_egreso_efectivo    int
AS

SELECT
    [id_egreso_efectivo] AS [Id_egreso_efectivo] ,
    [fecha_egreso_efectivo] AS [Fecha_egreso_efectivo] ,
    [importe] AS [Importe] ,
    [detalle_egreso_efectivo] AS [Detalle_egreso_efectivo] ,
    [id_caja] AS [Id_caja] ,
    [id_usuario] AS [Id_usuario]
FROM
    [dbo].[Egreso_efectivo]
WHERE
    [id_egreso_efectivo]  =  @id_egreso_efectivo
GO
/****** Object:  StoredProcedure [dbo].[cop_Egreso_efectivo_Insert]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Egreso_efectivo_Insert]
    @id_egreso_efectivo    int  output,
    @fecha_egreso_efectivo    datetime  ,
    @importe    decimal  (18,2),
    @detalle_egreso_efectivo    varchar  (50),
    @id_caja    int  ,
    @id_usuario    int  
AS

INSERT INTO [dbo].[Egreso_efectivo]
(
    [fecha_egreso_efectivo],
    [importe],
    [detalle_egreso_efectivo],
    [id_caja],
    [id_usuario]
)
VALUES
(
    @fecha_egreso_efectivo,
    @importe,
    @detalle_egreso_efectivo,
    @id_caja,
    @id_usuario
)
SET @id_egreso_efectivo = @@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[cop_Egreso_efectivo_InsertOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Egreso_efectivo_InsertOne]
AS

INSERT INTO [dbo].[Egreso_efectivo]
(
    [fecha_egreso_efectivo],
    [importe],
    [detalle_egreso_efectivo],
    [id_caja],
    [id_usuario]
)
VALUES
(
    '01-01-2000',
    0,
    'Ninguno',
    1,
     1 
)
GO
/****** Object:  StoredProcedure [dbo].[cop_Egreso_efectivo_Update]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Egreso_efectivo_Update]
    @id_egreso_efectivo    int  output,
    @fecha_egreso_efectivo    datetime  ,
    @importe    decimal  (18,2),
    @detalle_egreso_efectivo    varchar  (50),
    @id_caja    int  ,
    @id_usuario    int  
AS

UPDATE [dbo].[Egreso_efectivo] SET
    [fecha_egreso_efectivo] = @fecha_egreso_efectivo,
    [importe] = @importe,
    [detalle_egreso_efectivo] = @detalle_egreso_efectivo,
    [id_caja] = @id_caja,
    [id_usuario] = @id_usuario
WHERE
    [id_egreso_efectivo]  =  @id_egreso_efectivo
GO
/****** Object:  StoredProcedure [dbo].[cop_Estado_pedido_Delete]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Estado_pedido_Delete]
    @id_estado_pedido    int
AS

DELETE FROM [dbo].[Estado_pedido]
WHERE
    [id_estado_pedido]  =  @id_estado_pedido
GO
/****** Object:  StoredProcedure [dbo].[cop_Estado_pedido_Exist]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Estado_pedido_Exist]
    @estado_pedido    varchar  (50)
AS

DECLARE @total int
SET @total = 0

SELECT
    @total = id_estado_pedido
FROM
    [dbo].[Estado_pedido]
WHERE
    [estado_pedido] = @estado_pedido

IF @total IS NULL
BEGIN
    SET @total=0
END
SELECT @total AS Total
GO
/****** Object:  StoredProcedure [dbo].[cop_Estado_pedido_Find]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Estado_pedido_Find]
    @nombre NVARCHAR (30)=NULL
AS SET NOCOUNT ON

IF @nombre IS NOT NULL
BEGIN
SELECT @nombre=RTRIM(@nombre)+'%'
SELECT
    [id_estado_pedido] AS Id_estado_pedido ,
    RTRIM(estado_pedido) AS Estado_pedido
FROM
    [dbo].[Estado_pedido]
WHERE
    [estado_pedido] LIKE @nombre+'%'
ORDER BY
    [estado_pedido]
END
GO
/****** Object:  StoredProcedure [dbo].[cop_Estado_pedido_GetAll]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Estado_pedido_GetAll]
AS

SELECT
    [id_estado_pedido] AS Id_estado_pedido ,
    RTRIM(estado_pedido) AS Estado_pedido
FROM
    [dbo].[Estado_pedido]
ORDER BY
    [estado_pedido]
GO
/****** Object:  StoredProcedure [dbo].[cop_Estado_pedido_GetCmb]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Estado_pedido_GetCmb]
AS

SELECT
    [id_estado_pedido],
    [estado_pedido]
FROM
    [dbo].[Estado_pedido]
ORDER BY
    [estado_pedido]
GO
/****** Object:  StoredProcedure [dbo].[cop_Estado_pedido_GetOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Estado_pedido_GetOne]
    @id_estado_pedido    int
AS

SELECT
    [id_estado_pedido] AS Id_estado_pedido ,
    [estado_pedido] AS Estado_pedido
FROM
    [dbo].[Estado_pedido]
WHERE
    [id_estado_pedido]  =  @id_estado_pedido
GO
/****** Object:  StoredProcedure [dbo].[cop_Estado_pedido_Insert]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Estado_pedido_Insert]
    @id_estado_pedido    int  output,
    @estado_pedido    varchar  (50)
AS

INSERT INTO [dbo].[Estado_pedido]
(
    [estado_pedido]
)
VALUES
(
    @estado_pedido
)
SET @id_estado_pedido = @@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[cop_Estado_pedido_InsertOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Estado_pedido_InsertOne]
AS

INSERT INTO [dbo].[Estado_pedido]
(
    [estado_pedido]
)
VALUES
(
    'Ninguno'
)
GO
/****** Object:  StoredProcedure [dbo].[cop_Estado_pedido_Update]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Estado_pedido_Update]
    @id_estado_pedido    int  output,
    @estado_pedido    varchar  (50)
AS

UPDATE [dbo].[Estado_pedido] SET
    [estado_pedido] = @estado_pedido
WHERE
    [id_estado_pedido]  =  @id_estado_pedido
GO
/****** Object:  StoredProcedure [dbo].[cop_Factura_Delete]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Factura_Delete]
    @id_factura    int
AS

DELETE FROM [dbo].[Factura]
WHERE
    [id_factura]  =  @id_factura
GO
/****** Object:  StoredProcedure [dbo].[cop_Factura_Exist]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Factura_Exist]
    @articulo    varchar  (50),
    @cantidad    decimal  (18,0),
    @precio    decimal  (18,2)
AS

DECLARE @total int
SET @total = 0

SELECT
    @total = id_factura
FROM
    [dbo].[Factura]
WHERE
    [articulo] = @articulo AND
    [cantidad] = @cantidad AND
    [precio] = @precio

IF @total IS NULL
BEGIN
    SET @total=0
END
SELECT @total AS Total
GO
/****** Object:  StoredProcedure [dbo].[cop_Factura_Find]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Factura_Find]
    @nombre NVARCHAR (30)=NULL
AS SET NOCOUNT ON

IF @nombre IS NOT NULL
BEGIN
SELECT @nombre=RTRIM(@nombre)+'%'
SELECT TOP 100
    [id_factura] AS [Id factura] ,
    RTRIM(articulo) AS [Articulo] ,
    [cantidad] AS [Cantidad] ,
    [precio] AS [Precio]
FROM
    [dbo].[Factura]
WHERE
    [articulo] LIKE @nombre+'%'
ORDER BY
    [articulo]
END
GO
/****** Object:  StoredProcedure [dbo].[cop_Factura_GetAll]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Factura_GetAll]
AS

SELECT TOP 100
    [id_factura] AS [Id factura] ,
    RTRIM(articulo) AS [Articulo] ,
    [cantidad] AS [Cantidad] ,
    [precio] AS [Precio]
FROM
    [dbo].[Factura]
ORDER BY
    [articulo]
GO
/****** Object:  StoredProcedure [dbo].[cop_Factura_GetAll_2]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[cop_Factura_GetAll_2]
AS

SELECT
    [id_factura] AS [Id factura] ,
    RTRIM(articulo) AS [Articulo] ,
    [cantidad] AS [Cantidad] ,
    [precio] AS [Precio],
	cantidad * precio AS Subtotal
FROM
    [dbo].[Factura]
ORDER BY
    [id_factura]
GO
/****** Object:  StoredProcedure [dbo].[cop_Factura_GetAll_Ticket]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[cop_Factura_GetAll_Ticket]
AS

SELECT TOP 100
    [id_factura] AS [Id factura] ,
    RTRIM(articulo) AS [Articulo] ,
    [cantidad] AS [Cantidad] ,
    [precio] AS [Precio]
FROM
    [dbo].[Factura]
ORDER BY
    [id_factura]
GO
/****** Object:  StoredProcedure [dbo].[cop_Factura_GetCmb]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Factura_GetCmb]
AS

SELECT
    [id_factura],
    [articulo],
    [cantidad],
    [precio]
FROM
    [dbo].[Factura]
ORDER BY
    [articulo]
GO
/****** Object:  StoredProcedure [dbo].[cop_Factura_GetOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Factura_GetOne]
    @id_factura    int
AS

SELECT
    [id_factura] AS [Id factura] ,
    [articulo] AS [Articulo] ,
    [cantidad] AS [Cantidad] ,
    [precio] AS [Precio]
FROM
    [dbo].[Factura]
WHERE
    [id_factura]  =  @id_factura
GO
/****** Object:  StoredProcedure [dbo].[cop_Factura_Insert]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Factura_Insert]
    @id_factura    int  output,
    @articulo    varchar  (50),
    @cantidad    decimal  (18,0),
    @precio    decimal  (18,2)
AS

INSERT INTO [dbo].[Factura]
(
    [articulo],
    [cantidad],
    [precio]
)
VALUES
(
    @articulo,
    @cantidad,
    @precio
)
SET @id_factura = @@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[cop_Factura_InsertOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Factura_InsertOne]
AS

INSERT INTO [dbo].[Factura]
(
    [articulo],
    [cantidad],
    [precio]
)
VALUES
(
    'Ninguno',
    0,
     0 
)
GO
/****** Object:  StoredProcedure [dbo].[cop_Factura_Update]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Factura_Update]
    @id_factura    int  output,
    @articulo    varchar  (50),
    @cantidad    decimal  (18,0),
    @precio    decimal  (18,2)
AS

UPDATE [dbo].[Factura] SET
    [articulo] = @articulo,
    [cantidad] = @cantidad,
    [precio] = @precio
WHERE
    [id_factura]  =  @id_factura
GO
/****** Object:  StoredProcedure [dbo].[cop_Forma_pago_Delete]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Forma_pago_Delete]
    @id_forma_pago    int
AS

DELETE FROM [dbo].[Forma_pago]
WHERE
    [id_forma_pago]  =  @id_forma_pago
GO
/****** Object:  StoredProcedure [dbo].[cop_Forma_pago_Exist]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Forma_pago_Exist]
    @id_tipo_forma_pago    int  ,
    @nombre_forma_pago    varchar  (50)
AS

DECLARE @total int
SET @total = 0

SELECT
    @total = id_forma_pago
FROM
    [dbo].[Forma_pago]
WHERE
    [id_tipo_forma_pago] = @id_tipo_forma_pago AND
    [nombre_forma_pago] = @nombre_forma_pago

IF @total IS NULL
BEGIN
    SET @total=0
END
SELECT @total AS Total
GO
/****** Object:  StoredProcedure [dbo].[cop_Forma_pago_Find]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Forma_pago_Find]
    @nombre NVARCHAR (30)=NULL
AS SET NOCOUNT ON

IF @nombre IS NOT NULL
BEGIN
SELECT @nombre=RTRIM(@nombre)+'%'
SELECT
    [id_forma_pago] AS Id_forma_pago ,
    [id_tipo_forma_pago] AS Id_tipo_forma_pago ,
    RTRIM(nombre_forma_pago) AS Nombre_forma_pago
FROM
    [dbo].[Forma_pago]
WHERE
    [id_tipo_forma_pago] LIKE @nombre+'%'
ORDER BY
    [id_tipo_forma_pago]
END
GO
/****** Object:  StoredProcedure [dbo].[cop_Forma_pago_GetAll]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Forma_pago_GetAll]
AS

SELECT
    [id_forma_pago] AS Id_forma_pago ,
    [id_tipo_forma_pago] AS Id_tipo_forma_pago ,
    RTRIM(nombre_forma_pago) AS Nombre_forma_pago
FROM
    [dbo].[Forma_pago]
ORDER BY
    [id_tipo_forma_pago]
GO
/****** Object:  StoredProcedure [dbo].[cop_Forma_pago_GetCmb]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Forma_pago_GetCmb]
AS

SELECT
    [id_forma_pago],
    [id_tipo_forma_pago],
    [nombre_forma_pago]
FROM
    [dbo].[Forma_pago]
ORDER BY
    [id_tipo_forma_pago]
GO
/****** Object:  StoredProcedure [dbo].[cop_Forma_pago_GetOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Forma_pago_GetOne]
    @id_forma_pago    int
AS

SELECT
    [id_forma_pago] AS Id_forma_pago ,
    [id_tipo_forma_pago] AS Id_tipo_forma_pago ,
    [nombre_forma_pago] AS Nombre_forma_pago
FROM
    [dbo].[Forma_pago]
WHERE
    [id_forma_pago]  =  @id_forma_pago
GO
/****** Object:  StoredProcedure [dbo].[cop_Forma_pago_Insert]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Forma_pago_Insert]
    @id_forma_pago    int  output,
    @id_tipo_forma_pago    int  ,
    @nombre_forma_pago    varchar  (50)
AS

INSERT INTO [dbo].[Forma_pago]
(
    [id_tipo_forma_pago],
    [nombre_forma_pago]
)
VALUES
(
    @id_tipo_forma_pago,
    @nombre_forma_pago
)
SET @id_forma_pago = @@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[cop_Forma_pago_InsertOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Forma_pago_InsertOne]
AS

INSERT INTO [dbo].[Forma_pago]
(
    [id_tipo_forma_pago],
    [nombre_forma_pago]
)
VALUES
(
    1,
    'Ninguno'
)
GO
/****** Object:  StoredProcedure [dbo].[cop_Forma_pago_Update]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Forma_pago_Update]
    @id_forma_pago    int  output,
    @id_tipo_forma_pago    int  ,
    @nombre_forma_pago    varchar  (50)
AS

UPDATE [dbo].[Forma_pago] SET
    [id_tipo_forma_pago] = @id_tipo_forma_pago,
    [nombre_forma_pago] = @nombre_forma_pago
WHERE
    [id_forma_pago]  =  @id_forma_pago
GO
/****** Object:  StoredProcedure [dbo].[cop_Grupo_Producto_Delete]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Grupo_Producto_Delete]
    @id_grupo_producto    int
AS

DELETE FROM [dbo].[GRUPO_PRODUCTO]
WHERE
    [id_grupo_producto]  =  @id_grupo_producto



GO
/****** Object:  StoredProcedure [dbo].[cop_Grupo_Producto_Exist]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Grupo_Producto_Exist]
    @nombre_grupo_producto    varchar  (50)
AS

DECLARE @total int
SET @total = 0

SELECT
    @total = id_grupo_producto
FROM
    [dbo].[GRUPO_PRODUCTO]
WHERE
    [nombre_grupo_producto] = @nombre_grupo_producto

IF @total IS NULL
BEGIN
    SET @total=0
END
SELECT @total AS Total



GO
/****** Object:  StoredProcedure [dbo].[cop_Grupo_Producto_Find]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[cop_Grupo_Producto_Find]
    @nombre NVARCHAR (30)=NULL
AS SET NOCOUNT ON

IF @nombre IS NOT NULL
BEGIN
SELECT @nombre=RTRIM(@nombre)+'%'
SELECT TOP 100
    [nombre_grupo_producto] AS [nombre grupo producto]
FROM
    [dbo].[GRUPO_PRODUCTO]
WHERE
    [nombre_grupo_producto] LIKE @nombre+'%'
ORDER BY
    [nombre_grupo_producto]
END




GO
/****** Object:  StoredProcedure [dbo].[cop_Grupo_Producto_GetAll]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cop_Grupo_Producto_GetAll]
AS

SELECT TOP 100
    [id_grupo_producto] AS [id grupo producto] ,
    RTRIM(nombre_grupo_producto) AS [nombre grupo producto]
FROM
    [dbo].[GRUPO_PRODUCTO]
ORDER BY
    [nombre_grupo_producto]

GO
/****** Object:  StoredProcedure [dbo].[cop_Grupo_Producto_GetAll_2]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Grupo_Producto_GetAll_2]
AS

SELECT
    [id_grupo_producto] AS [id grupo producto] ,
    RTRIM(nombre_grupo_producto) AS [nombre grupo producto]
FROM
    [dbo].[GRUPO_PRODUCTO]
WHERE
	[nombre_grupo_producto] <> 'Ninguno'
ORDER BY
    [nombre_grupo_producto]


GO
/****** Object:  StoredProcedure [dbo].[cop_Grupo_Producto_GetCmb]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Grupo_Producto_GetCmb]
AS

SELECT
    [id_grupo_producto],
    [nombre_grupo_producto]
FROM
    [dbo].[GRUPO_PRODUCTO]
ORDER BY
    [nombre_grupo_producto]



GO
/****** Object:  StoredProcedure [dbo].[cop_Grupo_Producto_GetOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cop_Grupo_Producto_GetOne]
    @id_grupo_producto    int
AS

SELECT
    [id_grupo_producto] AS [id grupo_producto] ,
    [nombre_grupo_producto] AS [nombre grupo producto]
FROM
    [dbo].[GRUPO_PRODUCTO]
WHERE
    [id_grupo_producto]  =  @id_grupo_producto


GO
/****** Object:  StoredProcedure [dbo].[cop_Grupo_Producto_Insert]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Grupo_Producto_Insert]
    @id_grupo_producto    int  output,
    @nombre_grupo_producto    varchar  (50)
AS

INSERT INTO [dbo].[GRUPO_PRODUCTO]
(
    [nombre_grupo_producto]
)
VALUES
(
    @nombre_grupo_producto
)
SET @id_grupo_producto = @@IDENTITY



GO
/****** Object:  StoredProcedure [dbo].[cop_Grupo_Producto_InsertOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Grupo_Producto_InsertOne]
AS

INSERT INTO [dbo].[GRUPO_PRODUCTO]
(
    [nombre_grupo_producto]
)
VALUES
(
    'Ninguno'
)



GO
/****** Object:  StoredProcedure [dbo].[cop_Grupo_Producto_Update]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Grupo_Producto_Update]
    @id_grupo_producto    int  output,
    @nombre_grupo_producto    varchar  (50)
AS

UPDATE [dbo].[GRUPO_PRODUCTO] SET
    [nombre_grupo_producto] = @nombre_grupo_producto
WHERE
    [id_grupo_producto]  =  @id_grupo_producto

GO
/****** Object:  StoredProcedure [dbo].[cop_Grupo_Usuario_Delete]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Grupo_Usuario_Delete]
    @id_grupo_usuario    int
AS

DELETE FROM [dbo].[GRUPO_USUARIO]
WHERE
    [id_grupo_usuario]  =  @id_grupo_usuario


GO
/****** Object:  StoredProcedure [dbo].[cop_Grupo_Usuario_Exist]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Grupo_Usuario_Exist]
    @nombre_GRUPO_USUARIO    varchar  (50)
AS

DECLARE @total int
SET @total = 0

SELECT
    @total = id_grupo_usuario
FROM
    [dbo].[GRUPO_USUARIO]
WHERE
    [nombre_GRUPO_USUARIO] = @nombre_GRUPO_USUARIO

IF @total IS NULL
BEGIN
    SET @total=0
END
SELECT @total AS Total


GO
/****** Object:  StoredProcedure [dbo].[cop_Grupo_Usuario_Find]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[cop_Grupo_Usuario_Find]
    @nombre NVARCHAR (30)=NULL
AS SET NOCOUNT ON

IF @nombre IS NOT NULL
BEGIN
SELECT @nombre=RTRIM(@nombre)+'%'
SELECT TOP 100
    [nombre_GRUPO_USUARIO] AS [nombre grupo usuario]
FROM
    [dbo].[GRUPO_USUARIO]
WHERE
    [nombre_GRUPO_USUARIO] LIKE @nombre+'%'
ORDER BY
    [nombre_GRUPO_USUARIO]
END



GO
/****** Object:  StoredProcedure [dbo].[cop_Grupo_Usuario_GetAll]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Grupo_Usuario_GetAll]
AS

SELECT TOP 100
    [id_grupo_usuario] AS [Id GRUPO_USUARIO] ,
    RTRIM(nombre_GRUPO_USUARIO) AS [Nombre grupo usuario]
FROM
    [dbo].[GRUPO_USUARIO]
ORDER BY
    [nombre_GRUPO_USUARIO]


GO
/****** Object:  StoredProcedure [dbo].[cop_Grupo_Usuario_GetCmb]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Grupo_Usuario_GetCmb]
AS

SELECT
    [id_grupo_usuario],
    [nombre_GRUPO_USUARIO]
FROM
    [dbo].[GRUPO_USUARIO]
ORDER BY
    [nombre_GRUPO_USUARIO]


GO
/****** Object:  StoredProcedure [dbo].[cop_Grupo_Usuario_GetOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Grupo_Usuario_GetOne]
    @id_grupo_usuario    int
AS

SELECT
    [id_grupo_usuario] AS [Id GRUPO_USUARIO] ,
    [nombre_GRUPO_USUARIO] AS [nombre grupo usuario]
FROM
    [dbo].[GRUPO_USUARIO]
WHERE
    [id_grupo_usuario]  =  @id_grupo_usuario


GO
/****** Object:  StoredProcedure [dbo].[cop_Grupo_Usuario_Insert]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Grupo_Usuario_Insert]
    @id_grupo_usuario    int  output,
    @nombre_GRUPO_USUARIO    varchar  (50)
AS

INSERT INTO [dbo].[GRUPO_USUARIO]
(
    [nombre_GRUPO_USUARIO]
)
VALUES
(
    @nombre_GRUPO_USUARIO
)
SET @id_grupo_usuario = @@IDENTITY


GO
/****** Object:  StoredProcedure [dbo].[cop_Grupo_Usuario_InsertOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Grupo_Usuario_InsertOne]
AS

INSERT INTO [dbo].[GRUPO_USUARIO]
(
    [nombre_GRUPO_USUARIO]
)
VALUES
(
    'Ninguno'
)


GO
/****** Object:  StoredProcedure [dbo].[cop_Grupo_Usuario_Update]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Grupo_Usuario_Update]
    @id_grupo_usuario    int  output,
    @nombre_GRUPO_USUARIO    varchar  (50)
AS

UPDATE [dbo].[GRUPO_USUARIO] SET
    [nombre_GRUPO_USUARIO] = @nombre_GRUPO_USUARIO
WHERE
    [id_grupo_usuario]  =  @id_grupo_usuario

GO
/****** Object:  StoredProcedure [dbo].[cop_Mesa_CantMesaRegistrada]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



create PROCEDURE [dbo].[cop_Mesa_CantMesaRegistrada]
AS

DECLARE @total int
SET @total = 0

SELECT
    @total = count(*)
FROM
    [dbo].[Mesa]

IF @total IS NULL
BEGIN
    SET @total=0
END
SELECT @total AS Total
GO
/****** Object:  StoredProcedure [dbo].[cop_Mesa_CantRegistrada]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[cop_Mesa_CantRegistrada]
AS

DECLARE @total int
SET @total = 0

SELECT
    @total = (sum(cantidad_persona) * 80) / 100
FROM
    [dbo].[Mesa]

IF @total IS NULL
BEGIN
    SET @total=0
END
SELECT @total AS Total

select sum(cantidad_persona) from mesa



GO
/****** Object:  StoredProcedure [dbo].[cop_Mesa_Delete]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Mesa_Delete]
    @id_mesa    int
AS

DELETE FROM [dbo].[Mesa]
WHERE
    [id_mesa]  =  @id_mesa
GO
/****** Object:  StoredProcedure [dbo].[cop_Mesa_Exist]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Mesa_Exist]
    @nombre_mesa    varchar  (50),
    @estado    varchar  (50),
    @id_reserva    int  ,
    @grupo_mesa    int  ,
    @cantidad_persona    decimal  (18,0)
AS

DECLARE @total int
SET @total = 0

SELECT
    @total = id_mesa
FROM
    [dbo].[Mesa]
WHERE
    [nombre_mesa] = @nombre_mesa AND
    [estado] = @estado AND
    [id_reserva] = @id_reserva AND
    [grupo_mesa] = @grupo_mesa AND
    [cantidad_persona] = @cantidad_persona

IF @total IS NULL
BEGIN
    SET @total=0
END
SELECT @total AS Total
GO
/****** Object:  StoredProcedure [dbo].[cop_Mesa_Find]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Mesa_Find]
    @nombre NVARCHAR (30)=NULL
AS SET NOCOUNT ON

IF @nombre IS NOT NULL
BEGIN
SELECT @nombre=RTRIM(@nombre)+'%'
SELECT
    [id_mesa] AS Id_mesa ,
    RTRIM(nombre_mesa) AS Nombre_mesa ,
    RTRIM(estado) AS Estado ,
    [id_reserva] AS Id_reserva ,
    [grupo_mesa] AS Grupo_mesa ,
    [cantidad_persona] AS Cantidad_persona
FROM
    [dbo].[Mesa]
WHERE
    [nombre_mesa] LIKE @nombre+'%'
ORDER BY
    [nombre_mesa]
END
GO
/****** Object:  StoredProcedure [dbo].[cop_Mesa_GetAgrupada]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[cop_Mesa_GetAgrupada]
	@grupo_mesa int
AS

SELECT
    [id_mesa] AS Id_mesa ,
    RTRIM(nombre_mesa) AS Nombre_mesa ,
    RTRIM(estado) AS Estado ,
    [id_reserva] AS Id_reserva ,
    [grupo_mesa] AS Grupo_mesa
FROM
    [dbo].[Mesa]
WHERE
	grupo_mesa = @grupo_mesa
ORDER BY
    [nombre_mesa]

GO
/****** Object:  StoredProcedure [dbo].[cop_Mesa_GetAgrupadaReserva]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[cop_Mesa_GetAgrupadaReserva]
	@id_reserva int
AS

SELECT
    [id_mesa] AS Id_mesa ,
    RTRIM(nombre_mesa) AS Nombre_mesa ,
    RTRIM(estado) AS Estado ,
    [id_reserva] AS Id_reserva ,
    [grupo_mesa] AS Grupo_mesa
FROM
    [dbo].[Mesa]
WHERE
	id_reserva = @id_reserva
ORDER BY
    [nombre_mesa]


GO
/****** Object:  StoredProcedure [dbo].[cop_Mesa_GetAll]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Mesa_GetAll]
AS

SELECT
    [id_mesa] AS Id_mesa ,
    RTRIM(nombre_mesa) AS Nombre_mesa ,
    RTRIM(estado) AS Estado ,
    [id_reserva] AS Id_reserva ,
    [grupo_mesa] AS Grupo_mesa ,
    [cantidad_persona] AS Cantidad_persona
FROM
    [dbo].[Mesa]
ORDER BY
    [nombre_mesa]
GO
/****** Object:  StoredProcedure [dbo].[cop_Mesa_GetCmb]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Mesa_GetCmb]
AS

SELECT
    [id_mesa],
    [nombre_mesa],
    [estado],
    [id_reserva],
    [grupo_mesa],
    [cantidad_persona]
FROM
    [dbo].[Mesa]
ORDER BY
    [nombre_mesa]
GO
/****** Object:  StoredProcedure [dbo].[cop_Mesa_GetOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Mesa_GetOne]
    @id_mesa    int
AS

SELECT
    [id_mesa] AS Id_mesa ,
    [nombre_mesa] AS Nombre_mesa ,
    [estado] AS Estado ,
    [id_reserva] AS Id_reserva ,
    [grupo_mesa] AS Grupo_mesa ,
    [cantidad_persona] AS Cantidad_persona
FROM
    [dbo].[Mesa]
WHERE
    [id_mesa]  =  @id_mesa
GO
/****** Object:  StoredProcedure [dbo].[cop_Mesa_Insert]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Mesa_Insert]
    @id_mesa    int  output,
    @nombre_mesa    varchar  (50),
    @estado    varchar  (50),
    @id_reserva    int  ,
    @grupo_mesa    int  ,
    @cantidad_persona    decimal  (18,0)
AS

INSERT INTO [dbo].[Mesa]
(
    [nombre_mesa],
    [estado],
    [id_reserva],
    [grupo_mesa],
    [cantidad_persona]
)
VALUES
(
    @nombre_mesa,
    @estado,
    @id_reserva,
    @grupo_mesa,
    @cantidad_persona
)
SET @id_mesa = @@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[cop_Mesa_InsertOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Mesa_InsertOne]
AS

INSERT INTO [dbo].[Mesa]
(
    [nombre_mesa],
    [estado],
    [id_reserva],
    [grupo_mesa],
    [cantidad_persona]
)
VALUES
(
    'Ninguno',
    'Ninguno',
    1,
    1,
     0 
)
GO
/****** Object:  StoredProcedure [dbo].[cop_Mesa_NextGrupo]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[cop_Mesa_NextGrupo]
AS

DECLARE @max int
SET @max = 0

SELECT
    @max = max(grupo_mesa)
FROM
    [dbo].[Mesa]

IF @max IS NULL
BEGIN
    SET @max=0
END
SELECT @max + 1 AS Total

GO
/****** Object:  StoredProcedure [dbo].[cop_Mesa_Update]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Mesa_Update]
    @id_mesa    int  output,
    @nombre_mesa    varchar  (50),
    @estado    varchar  (50),
    @id_reserva    int  ,
    @grupo_mesa    int  ,
    @cantidad_persona    decimal  (18,0)
AS

UPDATE [dbo].[Mesa] SET
    [nombre_mesa] = @nombre_mesa,
    [estado] = @estado,
    [id_reserva] = @id_reserva,
    [grupo_mesa] = @grupo_mesa,
    [cantidad_persona] = @cantidad_persona
WHERE
    [id_mesa]  =  @id_mesa
GO
/****** Object:  StoredProcedure [dbo].[cop_Opcion_Modificacion_Delete]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Opcion_Modificacion_Delete]
    @id_opcion_modificacion    int
AS

DELETE FROM [dbo].[OPCION_MODIFICACION]
WHERE
    [id_opcion_modificacion]  =  @id_opcion_modificacion



GO
/****** Object:  StoredProcedure [dbo].[cop_Opcion_Modificacion_Exist]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Opcion_Modificacion_Exist]
    @nombre_opcion_modificacion  varchar  (50)
AS

DECLARE @total int
SET @total = 0

SELECT
    @total = id_opcion_modificacion
FROM
    [dbo].[OPCION_MODIFICACION]
WHERE
    [nombre_opcion_modificacion] = @nombre_opcion_modificacion

IF @total IS NULL
BEGIN
    SET @total=0
END
SELECT @total AS Total



GO
/****** Object:  StoredProcedure [dbo].[cop_Opcion_Modificacion_Find]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Opcion_Modificacion_Find]
    @nombre NVARCHAR (30)=NULL
AS SET NOCOUNT ON

IF @nombre IS NOT NULL
BEGIN
SELECT @nombre=RTRIM(@nombre)+'%'
SELECT TOP 100
    [id_opcion_modificacion] AS [id opcion modificacion] ,
    [nombre_opcion_modificacion] AS [nombre opcion modificacion]
	
FROM
    [dbo].[OPCION_MODIFICACION]
WHERE
    [nombre_opcion_modificacion] LIKE @nombre+'%'
ORDER BY
    [nombre_opcion_modificacion]
END



GO
/****** Object:  StoredProcedure [dbo].[cop_Opcion_Modificacion_GetAll]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[cop_Opcion_Modificacion_GetAll]
AS

SELECT TOP 100
    [id_opcion_modificacion] AS [id opcion modificacion] ,
    [nombre_opcion_modificacion] AS [nombre opcion modificacion]
FROM
    [dbo].[OPCION_MODIFICACION]
ORDER BY
    [nombre_opcion_modificacion]




GO
/****** Object:  StoredProcedure [dbo].[cop_Opcion_Modificacion_GetCmb]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Opcion_Modificacion_GetCmb]
AS

SELECT
    [id_opcion_modificacion],
    [nombre_opcion_modificacion]
FROM
    [dbo].[OPCION_MODIFICACION]
ORDER BY
    [nombre_opcion_modificacion]



GO
/****** Object:  StoredProcedure [dbo].[cop_Opcion_Modificacion_GetOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Opcion_Modificacion_GetOne]
    @id_opcion_modificacion    int
AS

SELECT
    [id_opcion_modificacion] AS [id opcion modificacion] ,
    [nombre_opcion_modificacion] AS [nombre opcion modificacion]
FROM
    [dbo].[OPCION_MODIFICACION]
WHERE
    [id_opcion_modificacion]  =  @id_opcion_modificacion



GO
/****** Object:  StoredProcedure [dbo].[cop_Opcion_Modificacion_Insert]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Opcion_Modificacion_Insert]
    @id_opcion_modificacion    int  output,
    @nombre_opcion_modificacion    varchar  (50)
AS

INSERT INTO [dbo].[OPCION_MODIFICACION]
(
    [nombre_opcion_modificacion]
)
VALUES
(
    @nombre_opcion_modificacion
)
SET @id_opcion_modificacion = @@IDENTITY



GO
/****** Object:  StoredProcedure [dbo].[cop_Opcion_Modificacion_InsertOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Opcion_Modificacion_InsertOne]
AS

INSERT INTO [dbo].[OPCION_MODIFICACION]
(
    [nombre_opcion_modificacion]
)
VALUES
(
    'Ninguno'
)



GO
/****** Object:  StoredProcedure [dbo].[cop_Opcion_Modificacion_Producto_Delete]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Opcion_Modificacion_Producto_Delete]
    @id_opcion_modificacion_producto    int
AS

DELETE FROM [dbo].[OPCION_MODIFICACION_PRODUCTO]
WHERE
    [id_opcion_modificacion_producto]  =  @id_opcion_modificacion_producto



GO
/****** Object:  StoredProcedure [dbo].[cop_Opcion_Modificacion_Producto_Exist]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cop_Opcion_Modificacion_Producto_Exist]
	@descripcion varchar(50),
	@precio decimal(18,2),
	@id_opcion_modificacion int
AS

DECLARE @total int
SET @total = 0

SELECT
    @total = id_opcion_modificacion_producto
FROM
    [dbo].[OPCION_MODIFICACION_PRODUCTO]
WHERE
	[descripcion] = @descripcion and
	[precio] = @precio and
	[id_opcion_modificacion] = @id_opcion_modificacion

IF @total IS NULL
BEGIN
    SET @total=0
END
SELECT @total AS Total
GO
/****** Object:  StoredProcedure [dbo].[cop_Opcion_Modificacion_Producto_Find]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cop_Opcion_Modificacion_Producto_Find]
    @nombre NVARCHAR (30)=NULL
AS SET NOCOUNT ON

IF @nombre IS NOT NULL
BEGIN
SELECT @nombre=RTRIM(@nombre)+'%'
SELECT TOP 100
    [descripcion] as [descripcion],
	[precio] AS [precio],
	[id_opcion_modificacion] AS [id opcion modificacion]
	
FROM
    [dbo].[OPCION_MODIFICACION_PRODUCTO]

WHERE
    [descripcion] LIKE @nombre+'%'
ORDER BY
    [descripcion]
END
GO
/****** Object:  StoredProcedure [dbo].[cop_Opcion_Modificacion_Producto_Find_2]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Opcion_Modificacion_Producto_Find_2]
    @nombre NVARCHAR (30)=NULL
AS SET NOCOUNT ON

IF @nombre IS NOT NULL
BEGIN
SELECT @nombre=RTRIM(@nombre)+'%'
SELECT TOP 100
    [descripcion] as [descripcion],
	[precio] AS [precio],
	om.[nombre_opcion_modificacion] AS [nombre opcion modificacion]
	
FROM
    [dbo].[OPCION_MODIFICACION_PRODUCTO] omp, [dbo].[OPCION_MODIFICACION] om

WHERE
	omp.[id_opcion_modificacion] = om.[id_opcion_modificacion] and
    [descripcion] LIKE @nombre+'%'
ORDER BY
    [descripcion]
END

GO
/****** Object:  StoredProcedure [dbo].[cop_Opcion_Modificacion_Producto_GetAll]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cop_Opcion_Modificacion_Producto_GetAll]
AS

SELECT TOP 100
    [id_opcion_modificacion_producto] AS [id opcion modificacion producto] ,
	[descripcion] as [descripcion],
	[precio] AS [precio],
	[id_opcion_modificacion] AS [id opcion modificacion]
FROM
    [dbo].[OPCION_MODIFICACION_PRODUCTO]
ORDER BY
    [descripcion]
GO
/****** Object:  StoredProcedure [dbo].[cop_Opcion_Modificacion_Producto_GetAll_2]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cop_Opcion_Modificacion_Producto_GetAll_2]
AS

SELECT TOP 100
    [id_opcion_modificacion_producto] AS [id opcion modificacion producto] ,
	[descripcion] as [descripcion],
	[precio] AS [precio],
	[nombre_opcion_modificacion] AS [nombre opcion modificacion]
FROM
    [dbo].[OPCION_MODIFICACION_PRODUCTO] OMP, [dbo].[OPCION_MODIFICACION] OM
WHERE OMP.[id_opcion_modificacion] = OM.[id_opcion_modificacion]
ORDER BY
    [descripcion]
GO
/****** Object:  StoredProcedure [dbo].[cop_Opcion_Modificacion_Producto_GetCmb]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cop_Opcion_Modificacion_Producto_GetCmb]
AS

SELECT
    [id_opcion_modificacion_producto],
	[descripcion],
	[precio],
	[id_opcion_modificacion]
FROM
    [dbo].[OPCION_MODIFICACION_PRODUCTO]
ORDER BY
    [precio]
GO
/****** Object:  StoredProcedure [dbo].[cop_Opcion_Modificacion_Producto_GetOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cop_Opcion_Modificacion_Producto_GetOne]
    @id_opcion_modificacion_producto    int
AS

SELECT
    [id_opcion_modificacion_producto] AS [id opcion modificacion producto] ,
	[descripcion] as [descripcion],
	[precio] AS [precio],
	[id_opcion_modificacion] AS [id opcion modificacion]
FROM
    [dbo].[OPCION_MODIFICACION_PRODUCTO]
WHERE
    [id_opcion_modificacion_producto]  =  @id_opcion_modificacion_producto
GO
/****** Object:  StoredProcedure [dbo].[cop_Opcion_Modificacion_Producto_Insert]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cop_Opcion_Modificacion_Producto_Insert]
    @id_opcion_modificacion_producto    int  output,
	@descripcion varchar(50),
	@precio decimal(18,2),
	@id_opcion_modificacion int
AS

INSERT INTO [dbo].[OPCION_MODIFICACION_PRODUCTO]
(
	[descripcion],
	[precio],
	[id_opcion_modificacion]
)
VALUES
(
	@descripcion,
	@precio,
	@id_opcion_modificacion
)
SET @id_opcion_modificacion_producto = @@IDENTITY

GO
/****** Object:  StoredProcedure [dbo].[cop_Opcion_Modificacion_Producto_InsertOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cop_Opcion_Modificacion_Producto_InsertOne]
AS

INSERT INTO [dbo].[OPCION_MODIFICACION_PRODUCTO]
(	
	[descripcion],
	[precio],
	[id_opcion_modificacion]
)
VALUES
(
	'Ninguna',
	0.0,
	1
)
GO
/****** Object:  StoredProcedure [dbo].[cop_Opcion_Modificacion_Producto_Update]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cop_Opcion_Modificacion_Producto_Update]
    @id_opcion_modificacion_producto    int  output,
	@descripcion varchar(50),
	@precio decimal(18,2),
	@id_opcion_modificacion int
AS

UPDATE [dbo].[OPCION_MODIFICACION_PRODUCTO] SET
	[descripcion] = @descripcion,
	[precio] = @precio,
	[id_opcion_modificacion] = @id_opcion_modificacion

WHERE
    [id_opcion_modificacion_producto]  =  @id_opcion_modificacion_producto
GO
/****** Object:  StoredProcedure [dbo].[cop_Opcion_Modificacion_Update]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cop_Opcion_Modificacion_Update]
    @id_opcion_modificacion    int  output,
    @nombre_opcion_modificacion    varchar  (50)
AS

UPDATE [dbo].[OPCION_MODIFICACION] SET
    [nombre_opcion_modificacion] = @nombre_opcion_modificacion
WHERE
    [id_opcion_modificacion]  =  @id_opcion_modificacion
GO
/****** Object:  StoredProcedure [dbo].[cop_Pago_pedido_Delete]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Pago_pedido_Delete]
    @id_pago_pedido    int
AS

DELETE FROM [dbo].[Pago_pedido]
WHERE
    [id_pago_pedido]  =  @id_pago_pedido
GO
/****** Object:  StoredProcedure [dbo].[cop_Pago_pedido_DeletePorPedido]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[cop_Pago_pedido_DeletePorPedido]
    @id_pedido    int
AS

DELETE FROM [dbo].[Pago_pedido]
WHERE
    [id_pedido]  =  @id_pedido

GO
/****** Object:  StoredProcedure [dbo].[cop_Pago_pedido_Exist]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Pago_pedido_Exist]
    @id_pedido    int  ,
    @id_forma_pago    int  ,
    @importe    decimal  (18,2),
    @id_banco    int  ,
    @id_cliente    int  ,
    @nro_cheque    varchar  (50),
    @id_caja    int  
AS

DECLARE @total int
SET @total = 0

SELECT
    @total = id_pago_pedido
FROM
    [dbo].[Pago_pedido]
WHERE
    [id_pedido] = @id_pedido AND
    [id_forma_pago] = @id_forma_pago AND
    [importe] = @importe AND
    [id_banco] = @id_banco AND
    [id_cliente] = @id_cliente AND
    [nro_cheque] = @nro_cheque AND
    [id_caja] = @id_caja

IF @total IS NULL
BEGIN
    SET @total=0
END
SELECT @total AS Total
GO
/****** Object:  StoredProcedure [dbo].[cop_Pago_pedido_Find]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Pago_pedido_Find]
    @nombre NVARCHAR (30)=NULL
AS SET NOCOUNT ON

IF @nombre IS NOT NULL
BEGIN
SELECT @nombre=RTRIM(@nombre)+'%'
SELECT
    [id_pago_pedido] AS Id_pago_pedido ,
    [id_pedido] AS Id_pedido ,
    [id_forma_pago] AS Id_forma_pago ,
    [importe] AS Importe ,
    [id_banco] AS Id_banco ,
    [id_cliente] AS Id_cliente ,
    RTRIM(nro_cheque) AS Nro_cheque ,
    [id_caja] AS Id_caja
FROM
    [dbo].[Pago_pedido]
WHERE
    [id_pedido] LIKE @nombre+'%'
ORDER BY
    [id_pedido]
END
GO
/****** Object:  StoredProcedure [dbo].[cop_Pago_pedido_GetAll]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Pago_pedido_GetAll]
AS

SELECT
    [id_pago_pedido] AS Id_pago_pedido ,
    [id_pedido] AS Id_pedido ,
    [id_forma_pago] AS Id_forma_pago ,
    [importe] AS Importe ,
    [id_banco] AS Id_banco ,
    [id_cliente] AS Id_cliente ,
    RTRIM(nro_cheque) AS Nro_cheque ,
    [id_caja] AS Id_caja
FROM
    [dbo].[Pago_pedido]
ORDER BY
    [id_pedido]
GO
/****** Object:  StoredProcedure [dbo].[cop_Pago_Pedido_GetAllVenta]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[cop_Pago_Pedido_GetAllVenta]
	@id_pedido int
AS

SELECT
	dbo.pago_pedido.id_pago_pedido,
	dbo.tipo_forma_pago.nombre_tipo_forma_pago AS Tipo,
	dbo.Pago_Pedido.importe AS Importe,
	dbo.Forma_pago.nombre_forma_pago AS Forma
FROM
	dbo.forma_pago INNER JOIN
	dbo.pago_pedido ON dbo.forma_pago.id_forma_pago = dbo.pago_pedido.id_forma_pago INNER JOIN
	dbo.tipo_forma_pago ON dbo.forma_pago.id_tipo_forma_pago = tipo_forma_pago.id_tipo_forma_pago INNER JOIN
	dbo.pedido ON dbo.pago_pedido.id_pedido = dbo.pedido.id_pedido
WHERE
	dbo.pago_pedido.id_pedido = @id_pedido AND
	dbo.pedido.id_estado_pedido = 4
ORDER BY
	[nombre_tipo_forma_pago]


GO
/****** Object:  StoredProcedure [dbo].[cop_Pago_Pedido_GetAllVentaFiscal]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[cop_Pago_Pedido_GetAllVentaFiscal]
	@id_pedido int
AS

SELECT
	dbo.pago_pedido.id_pago_pedido,
	dbo.tipo_forma_pago.nombre_tipo_forma_pago AS Tipo,
	dbo.Pago_Pedido.importe AS Importe,
	dbo.Forma_pago.nombre_forma_pago AS Forma
FROM
	dbo.forma_pago INNER JOIN
	dbo.pago_pedido ON dbo.forma_pago.id_forma_pago = dbo.pago_pedido.id_forma_pago INNER JOIN
	dbo.tipo_forma_pago ON dbo.forma_pago.id_tipo_forma_pago = tipo_forma_pago.id_tipo_forma_pago INNER JOIN
	dbo.pedido ON dbo.pago_pedido.id_pedido = dbo.pedido.id_pedido
WHERE
	dbo.pago_pedido.id_pedido = @id_pedido
ORDER BY
	[nombre_tipo_forma_pago]



GO
/****** Object:  StoredProcedure [dbo].[cop_Pago_pedido_GetCaja]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[cop_Pago_pedido_GetCaja]
	@id_caja int
AS

SELECT
    [id_pago_pedido] AS Id_pago_pedido,
	tipo_forma_pago.id_tipo_forma_pago,
	[nombre_tipo_forma_pago] AS Movimiento,
    [importe] AS Importe,
	'Pago del pedido: ' + convert(varchar(50), id_pedido) AS Detalle  
    
FROM
    [dbo].[Pago_pedido] INNER JOIN
	[dbo].[forma_pago] ON [dbo].[Pago_pedido].id_forma_pago = [dbo].[forma_pago].id_forma_pago INNER JOIN
	[dbo].[tipo_forma_pago] ON [dbo].[forma_pago].id_tipo_forma_pago = [dbo].[tipo_forma_pago].id_tipo_forma_pago
WHERE 
	id_caja = @id_caja
ORDER BY
    [nombre_tipo_forma_pago]



GO
/****** Object:  StoredProcedure [dbo].[cop_Pago_pedido_GetCmb]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Pago_pedido_GetCmb]
AS

SELECT
    [id_pago_pedido],
    [id_pedido],
    [id_forma_pago],
    [importe],
    [id_banco],
    [id_cliente],
    [nro_cheque],
    [id_caja]
FROM
    [dbo].[Pago_pedido]
ORDER BY
    [id_pedido]
GO
/****** Object:  StoredProcedure [dbo].[cop_Pago_pedido_GetOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Pago_pedido_GetOne]
    @id_pago_pedido    int
AS

SELECT
    [id_pago_pedido] AS Id_pago_pedido ,
    [id_pedido] AS Id_pedido ,
    [id_forma_pago] AS Id_forma_pago ,
    [importe] AS Importe ,
    [id_banco] AS Id_banco ,
    [id_cliente] AS Id_cliente ,
    [nro_cheque] AS Nro_cheque ,
    [id_caja] AS Id_caja
FROM
    [dbo].[Pago_pedido]
WHERE
    [id_pago_pedido]  =  @id_pago_pedido
GO
/****** Object:  StoredProcedure [dbo].[cop_Pago_pedido_Insert]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Pago_pedido_Insert]
    @id_pago_pedido    int  output,
    @id_pedido    int  ,
    @id_forma_pago    int  ,
    @importe    decimal  (18,2),
    @id_banco    int  ,
    @id_cliente    int  ,
    @nro_cheque    varchar  (50),
    @id_caja    int  
AS

INSERT INTO [dbo].[Pago_pedido]
(
    [id_pedido],
    [id_forma_pago],
    [importe],
    [id_banco],
    [id_cliente],
    [nro_cheque],
    [id_caja]
)
VALUES
(
    @id_pedido,
    @id_forma_pago,
    @importe,
    @id_banco,
    @id_cliente,
    @nro_cheque,
    @id_caja
)
SET @id_pago_pedido = @@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[cop_Pago_pedido_InsertOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Pago_pedido_InsertOne]
AS

INSERT INTO [dbo].[Pago_pedido]
(
    [id_pedido],
    [id_forma_pago],
    [importe],
    [id_banco],
    [id_cliente],
    [nro_cheque],
    [id_caja]
)
VALUES
(
    1,
    1,
    0,
    1,
    1,
    'Ninguno',
     1 
)
GO
/****** Object:  StoredProcedure [dbo].[cop_Pago_pedido_SaldosPorCaja]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[cop_Pago_pedido_SaldosPorCaja]
    @id_caja    int  
AS

DECLARE @saldo_efectivo decimal(18,2)
SET @saldo_efectivo = 0
DECLARE @saldo_tarjeta decimal(18,2)
SET @saldo_tarjeta = 0
DECLARE @saldo_cheque decimal(18,2)
SET @saldo_cheque = 0


--Efectivo
SELECT @saldo_efectivo = sum(importe) FROM [dbo].[Pago_pedido]
WHERE [id_caja] = @id_caja AND id_forma_pago = 2

--Tarjeta
SELECT @saldo_tarjeta = sum(importe) FROM [dbo].[Pago_pedido]
WHERE [id_caja] = @id_caja AND id_forma_pago in (3,4,5,6,8,9,10,11,12,13)

--Cheque
SELECT @saldo_cheque = sum(importe) FROM [dbo].[Pago_pedido]
WHERE [id_caja] = @id_caja AND id_forma_pago = 7

--Verifico
IF @saldo_efectivo IS NULL
BEGIN
    SET @saldo_efectivo=0
END
IF @saldo_tarjeta IS NULL
BEGIN
    SET @saldo_tarjeta=0
END
IF @saldo_cheque IS NULL
BEGIN
    SET @saldo_cheque=0
END

SELECT @saldo_efectivo AS Efectivo,
 @saldo_tarjeta AS Tarjeta, @saldo_cheque AS Cheque



GO
/****** Object:  StoredProcedure [dbo].[cop_Pago_pedido_Update]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Pago_pedido_Update]
    @id_pago_pedido    int  output,
    @id_pedido    int  ,
    @id_forma_pago    int  ,
    @importe    decimal  (18,2),
    @id_banco    int  ,
    @id_cliente    int  ,
    @nro_cheque    varchar  (50),
    @id_caja    int  
AS

UPDATE [dbo].[Pago_pedido] SET
    [id_pedido] = @id_pedido,
    [id_forma_pago] = @id_forma_pago,
    [importe] = @importe,
    [id_banco] = @id_banco,
    [id_cliente] = @id_cliente,
    [nro_cheque] = @nro_cheque,
    [id_caja] = @id_caja
WHERE
    [id_pago_pedido]  =  @id_pago_pedido
GO
/****** Object:  StoredProcedure [dbo].[cop_Pedido_Delete]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[cop_Pedido_Delete]
    @id_pedido    int
AS

DELETE FROM [dbo].[Pedido]
WHERE
    [id_pedido]  =  @id_pedido

GO
/****** Object:  StoredProcedure [dbo].[cop_Pedido_Exist]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[cop_Pedido_Exist]
    @fecha    datetime  ,
    @importe    decimal  (18,2),
    @id_mesa    int  ,
    @fecha_entrega    datetime  ,
    @porcentaje_descuento    decimal  (18,2),
    @descuento    decimal  (18,2),
    @totals    decimal  (18,2),
    @id_estado_pedido    int  ,
    @pago_cliente    decimal  (18,2),
	@id_cliente int
AS

DECLARE @total int
SET @total = 0

SELECT
    @total = id_pedido
FROM
    [dbo].[Pedido]
WHERE
    [fecha] = @fecha AND
    [importe] = @importe AND
    [id_mesa] = @id_mesa AND
    [fecha_entrega] = @fecha_entrega AND
    [porcentaje_descuento] = @porcentaje_descuento AND
    [descuento] = @descuento AND
    [totals] = @totals AND
    [id_estado_pedido] = @id_estado_pedido AND
    [pago_cliente] = @pago_cliente AND
	id_cliente = @id_cliente

IF @total IS NULL
BEGIN
    SET @total=0
END
SELECT @total AS Total

GO
/****** Object:  StoredProcedure [dbo].[cop_Pedido_Find]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[cop_Pedido_Find]
    @nombre NVARCHAR (30)=NULL
AS SET NOCOUNT ON

IF @nombre IS NOT NULL
BEGIN
SELECT @nombre=RTRIM(@nombre)+'%'
SELECT
    [id_pedido] AS Id_pedido ,
    [fecha] AS Fecha ,
    [importe] AS Importe ,
    [id_mesa] AS Id_mesa ,
    [fecha_entrega] AS Fecha_entrega ,
    [porcentaje_descuento] AS Porcentaje_descuento ,
    [descuento] AS Descuento ,
    [totals] AS Totals ,
    [id_estado_pedido] AS Id_estado_pedido ,
    [pago_cliente] AS Pago_cliente,
	id_cliente AS Id_cliente
FROM
    [dbo].[Pedido]
WHERE
    [fecha] LIKE @nombre+'%'
ORDER BY
    [fecha]
END

GO
/****** Object:  StoredProcedure [dbo].[cop_Pedido_Find_2]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[cop_Pedido_Find_2]
    @nombre NVARCHAR (30)=NULL
AS SET NOCOUNT ON

IF @nombre IS NOT NULL
BEGIN
SELECT @nombre=RTRIM(@nombre)+'%'
SELECT TOP 100
    [id_pedido] AS [id pedido] ,
    [fecha] AS [fecha],
	[importe] as [importe],
	m.[nombre_mesa] as [nombre mesa]
	
FROM
    [dbo].[PEDIDO] pe, [dbo].[MESA] m
WHERE
	pe.[id_mesa] = m.[id_mesa] AND
    [fecha] LIKE @nombre+'%'
ORDER BY
    [fecha]
END





GO
/****** Object:  StoredProcedure [dbo].[cop_Pedido_GetAll]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[cop_Pedido_GetAll]
AS

SELECT
    [id_pedido] AS Id_pedido ,
    [fecha] AS Fecha ,
    [importe] AS Importe ,
    [id_mesa] AS Id_mesa ,
    [fecha_entrega] AS Fecha_entrega ,
    [porcentaje_descuento] AS Porcentaje_descuento ,
    [descuento] AS Descuento ,
    [totals] AS Totals ,
    [id_estado_pedido] AS Id_estado_pedido ,
    [pago_cliente] AS Pago_cliente,
	id_cliente AS Id_cliente
FROM
    [dbo].[Pedido]
ORDER BY
    [fecha]

GO
/****** Object:  StoredProcedure [dbo].[cop_Pedido_GetAll_2]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Pedido_GetAll_2]
AS

SELECT TOP 100
    [id_pedido] AS [id pedido] ,
    [fecha] AS [fecha],
	[importe] as [importe],
	[nombre_mesa] as [nombre mesa]
FROM
    [dbo].[PEDIDO] u, [dbo].[MESA] m
WHERE u.id_mesa = m.id_mesa
ORDER BY
    [fecha]



GO
/****** Object:  StoredProcedure [dbo].[cop_Pedido_GetCmb]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[cop_Pedido_GetCmb]
AS

SELECT
    [id_pedido],
    [fecha],
    [importe],
    [id_mesa],
    [fecha_entrega],
    [porcentaje_descuento],
    [descuento],
    [totals],
    [id_estado_pedido],
    [pago_cliente],
	id_cliente
FROM
    [dbo].[Pedido]
ORDER BY
    [fecha]

GO
/****** Object:  StoredProcedure [dbo].[cop_Pedido_GetMesa]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[cop_Pedido_GetMesa]
	@id_mesa int

AS

SELECT TOP 100
    [id_pedido] AS [id pedido] ,
    [fecha] AS [fecha],
	[importe] as [importe],
	[nombre_mesa] as [nombre mesa]
FROM
    [dbo].[PEDIDO] u, [dbo].[MESA] m
WHERE u.id_mesa = m.id_mesa and
	  m.id_mesa = @id_mesa
ORDER BY
    [fecha]




GO
/****** Object:  StoredProcedure [dbo].[cop_Pedido_GetOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[cop_Pedido_GetOne]
    @id_pedido    int
AS

SELECT
    [id_pedido] AS Id_pedido ,
    [fecha] AS Fecha ,
    [importe] AS Importe ,
    [id_mesa] AS Id_mesa ,
    [fecha_entrega] AS Fecha_entrega ,
    [porcentaje_descuento] AS Porcentaje_descuento ,
    [descuento] AS Descuento ,
    [totals] AS Totals ,
    [id_estado_pedido] AS Id_estado_pedido ,
    [pago_cliente] AS Pago_cliente,
	id_cliente AS Id_cliente
FROM
    [dbo].[Pedido]
WHERE
    [id_pedido]  =  @id_pedido

GO
/****** Object:  StoredProcedure [dbo].[cop_Pedido_Insert]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[cop_Pedido_Insert]
    @id_pedido    int  output,
    @fecha    datetime  ,
    @importe    decimal  (18,2),
    @id_mesa    int  ,
    @fecha_entrega    datetime  ,
    @porcentaje_descuento    decimal  (18,2),
    @descuento    decimal  (18,2),
    @totals    decimal  (18,2),
    @id_estado_pedido    int  ,
    @pago_cliente    decimal  (18,2),
	@id_cliente int
AS

INSERT INTO [dbo].[Pedido]
(
    [fecha],
    [importe],
    [id_mesa],
    [fecha_entrega],
    [porcentaje_descuento],
    [descuento],
    [totals],
    [id_estado_pedido],
    [pago_cliente],
	id_cliente
)
VALUES
(
    @fecha,
    @importe,
    @id_mesa,
    @fecha_entrega,
    @porcentaje_descuento,
    @descuento,
    @totals,
    @id_estado_pedido,
    @pago_cliente,
	@id_cliente
)
SET @id_pedido = @@IDENTITY

GO
/****** Object:  StoredProcedure [dbo].[cop_Pedido_InsertOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[cop_Pedido_InsertOne]
AS

INSERT INTO [dbo].[Pedido]
(
    [fecha],
    [importe],
    [id_mesa],
    [fecha_entrega],
    [porcentaje_descuento],
    [descuento],
    [totals],
    [id_estado_pedido],
    [pago_cliente],
	id_cliente
)
VALUES
(
    '01-01-2000',
    0,
    1,
    '01-01-2000',
    0,
    0,
    0,
    1,
     0 ,
	 1
)

GO
/****** Object:  StoredProcedure [dbo].[cop_Pedido_Update]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[cop_Pedido_Update]
    @id_pedido    int  output,
    @fecha    datetime  ,
    @importe    decimal  (18,2),
    @id_mesa    int  ,
    @fecha_entrega    datetime  ,
    @porcentaje_descuento    decimal  (18,2),
    @descuento    decimal  (18,2),
    @totals    decimal  (18,2),
    @id_estado_pedido    int  ,
    @pago_cliente    decimal  (18,2),
	@id_cliente int
AS

UPDATE [dbo].[Pedido] SET
    [fecha] = @fecha,
    [importe] = @importe,
    [id_mesa] = @id_mesa,
    [fecha_entrega] = @fecha_entrega,
    [porcentaje_descuento] = @porcentaje_descuento,
    [descuento] = @descuento,
    [totals] = @totals,
    [id_estado_pedido] = @id_estado_pedido,
    [pago_cliente] = @pago_cliente,
	id_cliente = @id_cliente
WHERE
    [id_pedido]  =  @id_pedido

GO
/****** Object:  StoredProcedure [dbo].[cop_Producto_Delete]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Producto_Delete]
    @id_producto   int
AS

DELETE FROM [dbo].[PRODUCTO]
WHERE
    [id_producto]  =  @id_producto



GO
/****** Object:  StoredProcedure [dbo].[cop_Producto_Exist]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cop_Producto_Exist]
    @nombre_producto  varchar  (50),
	@descripcion varchar(5000),
	@id_tipo_producto int,
	@receta varchar(5000),
	@precio decimal(18,2),
	@sin_disponibilidad bit,
	@icono varchar(5000),
	@id_opcion_modificacion int
AS

DECLARE @total int
SET @total = 0

SELECT
    @total = id_producto
FROM
    [dbo].[PRODUCTO]
WHERE
    [nombre_producto] = @nombre_producto and
	[descripcion] = @descripcion and
	[id_tipo_producto] = @id_tipo_producto and
	[receta] = @receta and
	[precio] = @precio and
	[sin_disponibilidad] = @sin_disponibilidad and
	[icono] = @icono and
	[id_opcion_modificacion] = @id_opcion_modificacion

IF @total IS NULL
BEGIN
    SET @total=0
END
SELECT @total AS Total
GO
/****** Object:  StoredProcedure [dbo].[cop_Producto_Find]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cop_Producto_Find]
    @nombre NVARCHAR (30)=NULL
AS SET NOCOUNT ON

IF @nombre IS NOT NULL
BEGIN
SELECT @nombre=RTRIM(@nombre)+'%'
SELECT TOP 100
    [id_producto] AS [id producto] ,
    [nombre_producto] AS [nombre producto],
	[descripcion] as [descripcion],
	[id_tipo_producto] as [id tipo producto],
	[receta] as [receta],
	[precio] as [precio],
	[sin_disponibilidad] as [sin disponibilidad],
	[icono] as [icono],
	[id_opcion_modificacion] as [id opcion modificacion]
	
FROM
    [dbo].[PRODUCTO]
WHERE
    [nombre_producto] LIKE @nombre+'%'
ORDER BY
    [nombre_producto]
END
GO
/****** Object:  StoredProcedure [dbo].[cop_Producto_Find_2]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Producto_Find_2]
    @nombre NVARCHAR (30)=NULL
AS SET NOCOUNT ON

IF @nombre IS NOT NULL
BEGIN
SELECT @nombre=RTRIM(@nombre)+'%'
SELECT TOP 100
    [id_producto] AS [id producto] ,
    [nombre_producto] AS [nombre producto],
	[descripcion] as [descripcion],
	[nombre_tipo_producto] as [nombre tipo producto],
	[nombre_opcion_modificacion] as [nombre opcion modificacion],
	[receta] as [receta],
	[precio] as [precio],
	[sin_disponibilidad] as [sin disponibilidad],
	pr.[icono] as [icono]
	
FROM
    [dbo].[PRODUCTO] pr, [dbo].[TIPO_PRODUCTO] tp, [dbo].[OPCION_MODIFICACION] om
WHERE
	pr.[id_tipo_producto] = tp.[id_tipo_producto] and
	pr.[id_opcion_modificacion] = om.[id_opcion_modificacion] and
    [nombre_producto] LIKE @nombre+'%'
ORDER BY
    [nombre_producto]
END

GO
/****** Object:  StoredProcedure [dbo].[cop_Producto_GetAll]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cop_Producto_GetAll]
AS

SELECT TOP 100
    [id_producto] AS [id producto] ,
    [nombre_producto] AS [nombre producto],
	[descripcion] as [descripcion],
	[id_tipo_producto] as [id tipo producto],
	[receta] as [receta],
	[precio] as [precio],
	[sin_disponibilidad] as [sin disponibilidad],
	[icono] as [icono],
	[id_opcion_modificacion] as [id opcion modificacion]
	
FROM
    [dbo].[PRODUCTO]
ORDER BY
    [nombre_producto]

GO
/****** Object:  StoredProcedure [dbo].[cop_Producto_GetAll_2]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[cop_Producto_GetAll_2]
AS

SELECT
    [id_producto] AS [id producto] ,
	[nombre_tipo_producto] as [nombre tipo producto],
    [nombre_producto] AS [nombre producto],
	[descripcion] as [descripcion],
	[nombre_opcion_modificacion] as [nombre opcion modificacion],
	[receta] as [receta],
	[precio] as [precio],
	[sin_disponibilidad] as [sin disponibilidad],
	p.[icono] as [icono]
FROM
    [dbo].[PRODUCTO] P, [dbo].[TIPO_PRODUCTO] TP, [dbo].OPCION_MODIFICACION OM
WHERE P.[id_tipo_producto] = TP.[id_tipo_producto] and
	  P.[id_opcion_modificacion] = OM.[id_opcion_modificacion]
ORDER BY
    [nombre_producto]



GO
/****** Object:  StoredProcedure [dbo].[cop_Producto_GetAll_Grupo]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[cop_Producto_GetAll_Grupo]
	@id_grupo_producto int
AS

SELECT
    [id_producto] AS [id producto] ,
	[nombre_tipo_producto] as [nombre tipo producto],
    [nombre_producto] AS [nombre producto],
	[descripcion] as [descripcion],
	[nombre_opcion_modificacion] as [nombre opcion modificacion],
	[receta] as [receta],
	[precio] as [precio],
	[sin_disponibilidad] as [sin disponibilidad],
	p.[icono] as [icono]
FROM
    [dbo].[PRODUCTO] P, [dbo].[TIPO_PRODUCTO] TP, [dbo].OPCION_MODIFICACION OM
WHERE P.[id_tipo_producto] = TP.[id_tipo_producto] and
	  P.[id_opcion_modificacion] = OM.[id_opcion_modificacion] AND
	  id_grupo_producto = @id_grupo_producto
ORDER BY
    [nombre_producto]



GO
/****** Object:  StoredProcedure [dbo].[cop_Producto_GetCmb]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cop_Producto_GetCmb]
AS

SELECT
    [id_producto],
    [nombre_producto],
	[descripcion],
	[id_tipo_producto],
	[receta],
	[precio],
	[sin_disponibilidad],
	[icono],
	[id_opcion_modificacion]
FROM
    [dbo].[PRODUCTO]
ORDER BY
    [nombre_producto]

GO
/****** Object:  StoredProcedure [dbo].[cop_Producto_GetConsultaMaestra]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[cop_Producto_GetConsultaMaestra]
	@id_grupo_producto int,
	@id_tipo_producto int,
	@nombre NVARCHAR (30) = NULL,
	@es_grupo bit,
	@es_tipo bit
AS


IF @nombre IS NOT NULL
BEGIN
SELECT @nombre=RTRIM(@nombre)+'%'
END

IF (@es_grupo = 0 and @es_tipo = 0)
	BEGIN
		SELECT
			[id_producto] AS [id producto] ,
			[nombre_producto] AS [nombre producto],
			[descripcion] as [descripcion],
			[nombre_tipo_producto] as [nombre tipo producto],
			[nombre_opcion_modificacion] as [nombre opcion modificacion],
			[receta] as [receta],
			[precio] as [precio],
			[sin_disponibilidad] as [sin disponibilidad],
			PRODUCTO.[icono] as [icono]
		FROM
			[dbo].[PRODUCTO] INNER JOIN
			[dbo].[TIPO_PRODUCTO] ON PRODUCTO.id_tipo_producto = TIPO_PRODUCTO.id_tipo_producto INNER JOIN
			OPCION_MODIFICACION ON OPCION_MODIFICACION.id_opcion_modificacion = PRODUCTO.id_opcion_modificacion
		WHERE
			[nombre_producto] LIKE '%'+@nombre+'%'
		ORDER BY
			[nombre_producto]

	END

ELSE IF  (@es_grupo = 1 and @es_tipo = 0)
	BEGIN
		SELECT
			[id_producto] AS [id producto] ,
			[nombre_producto] AS [nombre producto],
			[descripcion] as [descripcion],
			[nombre_tipo_producto] as [nombre tipo producto],
			[nombre_opcion_modificacion] as [nombre opcion modificacion],
			[receta] as [receta],
			[precio] as [precio],
			[sin_disponibilidad] as [sin disponibilidad],
			PRODUCTO.[icono] as [icono]
	
		FROM
			[dbo].[PRODUCTO] INNER JOIN
			[dbo].[TIPO_PRODUCTO] ON PRODUCTO.id_tipo_producto = TIPO_PRODUCTO.id_tipo_producto INNER JOIN
			OPCION_MODIFICACION ON OPCION_MODIFICACION.id_opcion_modificacion = PRODUCTO.id_opcion_modificacion
		WHERE
			TIPO_PRODUCTO.id_grupo_producto = @id_grupo_producto AND
			[nombre_producto] LIKE '%'+@nombre+'%'
		ORDER BY
			[nombre_producto]
	END

ELSE IF  (@es_grupo = 0 and @es_tipo = 1)
	BEGIN
		SELECT
			[id_producto] AS [id producto] ,
			[nombre_producto] AS [nombre producto],
			[descripcion] as [descripcion],
			[nombre_tipo_producto] as [nombre tipo producto],
			[nombre_opcion_modificacion] as [nombre opcion modificacion],
			[receta] as [receta],
			[precio] as [precio],
			[sin_disponibilidad] as [sin disponibilidad],
			PRODUCTO.[icono] as [icono]
	
		FROM
			[dbo].[PRODUCTO] INNER JOIN
			[dbo].[TIPO_PRODUCTO] ON PRODUCTO.id_tipo_producto = TIPO_PRODUCTO.id_tipo_producto INNER JOIN
			OPCION_MODIFICACION ON OPCION_MODIFICACION.id_opcion_modificacion = PRODUCTO.id_opcion_modificacion
		WHERE
			TIPO_PRODUCTO.id_tipo_producto = @id_tipo_producto AND
			[nombre_producto] LIKE '%'+@nombre+'%'
		ORDER BY
			[nombre_producto]
	END

ELSE IF  (@es_grupo = 1 and @es_tipo = 1)
	BEGIN
		SELECT
			[id_producto] AS [id producto] ,
			[nombre_producto] AS [nombre producto],
			[descripcion] as [descripcion],
			[nombre_tipo_producto] as [nombre tipo producto],
			[nombre_opcion_modificacion] as [nombre opcion modificacion],
			[receta] as [receta],
			[precio] as [precio],
			[sin_disponibilidad] as [sin disponibilidad],
			PRODUCTO.[icono] as [icono]
	
		FROM
			[dbo].[PRODUCTO] INNER JOIN
			[dbo].[TIPO_PRODUCTO] ON PRODUCTO.id_tipo_producto = TIPO_PRODUCTO.id_tipo_producto INNER JOIN
			OPCION_MODIFICACION ON OPCION_MODIFICACION.id_opcion_modificacion = PRODUCTO.id_opcion_modificacion
		WHERE
			TIPO_PRODUCTO.id_grupo_producto = @id_grupo_producto AND
			TIPO_PRODUCTO.id_tipo_producto = @id_tipo_producto AND
			[nombre_producto] LIKE '%'+@nombre+'%'
		ORDER BY
			[nombre_producto]
	END


GO
/****** Object:  StoredProcedure [dbo].[cop_Producto_GetOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cop_Producto_GetOne]
    @id_producto   int
AS

SELECT
    [id_producto] AS [id producto] ,
    [nombre_producto] AS [nombre producto],
	[descripcion] as [descripcion],
	[id_tipo_producto] as [id tipo producto],
	[receta] as [receta],
	[precio] as [precio],
	[sin_disponibilidad] as [sin disponibilidad],
	[icono] as [icono],
	[id_opcion_modificacion] as [id opcion modificacion]
FROM
    [dbo].[PRODUCTO]
WHERE
    [id_producto]  =  @id_producto
GO
/****** Object:  StoredProcedure [dbo].[cop_Producto_GetTipo_Pedido]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[cop_Producto_GetTipo_Pedido]
	@tipo_producto int
AS

SELECT TOP 100
    [id_producto] AS [id producto] ,
    [nombre_producto] AS [Productos]
	
FROM
    [dbo].[PRODUCTO] P, [dbo].[TIPO_PRODUCTO] TP
WHERE P.[id_tipo_producto] = TP.[id_tipo_producto] and
	  p.id_tipo_producto = @tipo_producto
ORDER BY
    [nombre_producto]


GO
/****** Object:  StoredProcedure [dbo].[cop_Producto_Insert]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cop_Producto_Insert]
    @id_producto   int  output,
    @nombre_producto    varchar  (50),
	@descripcion varchar(5000),
	@id_tipo_producto int,
	@receta varchar(5000),
 	@precio decimal(18,2),
	@sin_disponibilidad bit,
	@icono varchar(5000),
	@id_opcion_modificacion int
AS

INSERT INTO [dbo].[PRODUCTO]
(
    [nombre_producto],
	[descripcion],
	[id_tipo_producto],
	[receta],
	[precio],
	[sin_disponibilidad],
	[icono],
	[id_opcion_modificacion]
)
VALUES
(
    @nombre_producto,  
	@descripcion,
	@id_tipo_producto,
	@receta,
	@precio,
	@sin_disponibilidad,
	@icono,
	@id_opcion_modificacion
)
SET @id_producto= @@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[cop_Producto_InsertOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cop_Producto_InsertOne]
AS

INSERT INTO [dbo].[PRODUCTO]
(
    [nombre_producto],
	[descripcion],
	[id_tipo_producto],
	[receta],
	[precio],
	[sin_disponibilidad],
	[icono],
	[id_opcion_modificacion]
)
VALUES
(
    'Ninguno',
	'ninguna',
	1,
	'ninguno',
	1,
	1,
	'ninguna',
	1
)
GO
/****** Object:  StoredProcedure [dbo].[cop_Producto_Update]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cop_Producto_Update]
    @id_producto   int  output,
    @nombre_producto    varchar  (50),
	@descripcion varchar(5000),
	@id_tipo_producto int,
	@receta varchar(5000),
	@precio decimal(18,2),
	@sin_disponibilidad bit,
	@icono varchar(5000),
	@id_opcion_modificacion int
AS

UPDATE [dbo].[PRODUCTO] SET
    [nombre_producto] = @nombre_producto,
	[descripcion] = @descripcion,
	[id_tipo_producto] = @id_tipo_producto,
	[receta] = @receta,
	[precio] = @precio,
	[sin_disponibilidad] = @sin_disponibilidad,
	[icono] = @icono,
	[id_opcion_modificacion] = @id_opcion_modificacion
WHERE
    [id_producto]  =  @id_producto
GO
/****** Object:  StoredProcedure [dbo].[cop_Reserva_hora_Delete]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Reserva_hora_Delete]
    @id_reserva_hora    int
AS

DELETE FROM [dbo].[Reserva_hora]
WHERE
    [id_reserva_hora]  =  @id_reserva_hora
GO
/****** Object:  StoredProcedure [dbo].[cop_Reserva_hora_Exist]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Reserva_hora_Exist]
    @hora_reserva    datetime  ,
    @cantidad    decimal  (18,0)
AS

DECLARE @total int
SET @total = 0

SELECT
    @total = id_reserva_hora
FROM
    [dbo].[Reserva_hora]
WHERE
    [hora_reserva] = @hora_reserva AND
    [cantidad] = @cantidad

IF @total IS NULL
BEGIN
    SET @total=0
END
SELECT @total AS Total
GO
/****** Object:  StoredProcedure [dbo].[cop_Reserva_hora_Find]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Reserva_hora_Find]
    @nombre NVARCHAR (30)=NULL
AS SET NOCOUNT ON

IF @nombre IS NOT NULL
BEGIN
SELECT @nombre=RTRIM(@nombre)+'%'
SELECT
    [id_reserva_hora] AS Id_reserva_hora ,
    [hora_reserva] AS Hora_reserva ,
    [cantidad] AS Cantidad
FROM
    [dbo].[Reserva_hora]
WHERE
    [hora_reserva] LIKE @nombre+'%'
ORDER BY
    [hora_reserva]
END
GO
/****** Object:  StoredProcedure [dbo].[cop_Reserva_hora_GetAll]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Reserva_hora_GetAll]
AS

SELECT
    [id_reserva_hora] AS Id_reserva_hora ,
    [hora_reserva] AS Hora_reserva ,
    [cantidad] AS Cantidad
FROM
    [dbo].[Reserva_hora]
ORDER BY
    [hora_reserva]
GO
/****** Object:  StoredProcedure [dbo].[cop_Reserva_hora_GetAll_2]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[cop_Reserva_hora_GetAll_2]
AS

SELECT
    [id_reserva_hora] AS Id_reserva_hora ,
	CONVERT(nvarchar(5),[hora_reserva],108) AS [Hora],
	[cantidad] AS Cantidad
FROM
    [dbo].[Reserva_hora]
ORDER BY
    [hora_reserva]

GO
/****** Object:  StoredProcedure [dbo].[cop_Reserva_hora_GetCmb]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Reserva_hora_GetCmb]
AS

SELECT
    [id_reserva_hora],
    [hora_reserva],
    [cantidad]
FROM
    [dbo].[Reserva_hora]
ORDER BY
    [hora_reserva]
GO
/****** Object:  StoredProcedure [dbo].[cop_Reserva_hora_GetOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Reserva_hora_GetOne]
    @id_reserva_hora    int
AS

SELECT
    [id_reserva_hora] AS Id_reserva_hora ,
    [hora_reserva] AS Hora_reserva ,
    [cantidad] AS Cantidad
FROM
    [dbo].[Reserva_hora]
WHERE
    [id_reserva_hora]  =  @id_reserva_hora
GO
/****** Object:  StoredProcedure [dbo].[cop_Reserva_hora_Insert]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Reserva_hora_Insert]
    @id_reserva_hora    int  output,
    @hora_reserva    datetime  ,
    @cantidad    decimal  (18,0)
AS

INSERT INTO [dbo].[Reserva_hora]
(
    [hora_reserva],
    [cantidad]
)
VALUES
(
    @hora_reserva,
    @cantidad
)
SET @id_reserva_hora = @@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[cop_Reserva_hora_InsertOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Reserva_hora_InsertOne]
AS

INSERT INTO [dbo].[Reserva_hora]
(
    [hora_reserva],
    [cantidad]
)
VALUES
(
    '01-01-2000',
     0 
)
GO
/****** Object:  StoredProcedure [dbo].[cop_Reserva_hora_ResetTable]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[cop_Reserva_hora_ResetTable]
AS

UPDATE [dbo].[Reserva_hora] SET
		[cantidad] = 0

GO
/****** Object:  StoredProcedure [dbo].[cop_Reserva_hora_Update]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Reserva_hora_Update]
    @id_reserva_hora    int  output,
    @hora_reserva    datetime  ,
    @cantidad    decimal  (18,0)
AS

UPDATE [dbo].[Reserva_hora] SET
    [hora_reserva] = @hora_reserva,
    [cantidad] = @cantidad
WHERE
    [id_reserva_hora]  =  @id_reserva_hora
GO
/****** Object:  StoredProcedure [dbo].[cop_Reserva_hora_UpdateCantidad]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[cop_Reserva_hora_UpdateCantidad]
	@id_reserva_hora int,
	@cantidad int
AS

UPDATE [dbo].[Reserva_hora] SET [cantidad] = @cantidad
WHERE id_reserva_hora = @id_reserva_hora

GO
/****** Object:  StoredProcedure [dbo].[cop_Reserva_mesa_ConsultaxHora]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[cop_Reserva_mesa_ConsultaxHora]
	@hora_reserva varchar(50),
	@fecha_reserva datetime
AS

DECLARE @cantidad int
SET @cantidad = 0

SELECT
    @cantidad = sum(nro_huesped)
FROM
    [dbo].[Reserva_mesa]
WHERE
	day(fecha_reserva) = day(@fecha_reserva) AND
	month(fecha_reserva) = month(@fecha_reserva) AND
	year(fecha_reserva) = year(@fecha_reserva) AND
	hora_reserva - CAST(FLOOR(CAST(hora_reserva AS float)) AS datetime) = @Hora_reserva

IF @cantidad IS NULL
BEGIN
    SET @cantidad=0
END
SELECT @cantidad AS Cantidad


GO
/****** Object:  StoredProcedure [dbo].[cop_Reserva_mesa_Delete]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Reserva_mesa_Delete]
    @id_reserva_mesa    int
AS

DELETE FROM [dbo].[Reserva_mesa]
WHERE
    [id_reserva_mesa]  =  @id_reserva_mesa
GO
/****** Object:  StoredProcedure [dbo].[cop_Reserva_mesa_Exist]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Reserva_mesa_Exist]
    @fecha_reserva    datetime  ,
    @hora_reserva    datetime  ,
    @nro_huesped    decimal  (18,0),
    @id_mesa    int  ,
    @estado_reserva    varchar  (50),
    @id_cliente    int  ,
    @observacion    varchar  (5000)
AS

DECLARE @total int
SET @total = 0

SELECT
    @total = id_reserva_mesa
FROM
    [dbo].[Reserva_mesa]
WHERE
    [fecha_reserva] = @fecha_reserva AND
    [hora_reserva] = @hora_reserva AND
    [nro_huesped] = @nro_huesped AND
    [id_mesa] = @id_mesa AND
    [estado_reserva] = @estado_reserva AND
    [id_cliente] = @id_cliente AND
    [observacion] = @observacion

IF @total IS NULL
BEGIN
    SET @total=0
END
SELECT @total AS Total
GO
/****** Object:  StoredProcedure [dbo].[cop_Reserva_mesa_Find]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Reserva_mesa_Find]
    @nombre NVARCHAR (30)=NULL
AS SET NOCOUNT ON

IF @nombre IS NOT NULL
BEGIN
SELECT @nombre=RTRIM(@nombre)+'%'
SELECT
    [id_reserva_mesa] AS Id_reserva_mesa ,
    [fecha_reserva] AS Fecha_reserva ,
    [hora_reserva] AS Hora_reserva ,
    [nro_huesped] AS Nro_huesped ,
    [id_mesa] AS Id_mesa ,
    RTRIM(estado_reserva) AS Estado_reserva ,
    [id_cliente] AS Id_cliente ,
    RTRIM(observacion) AS Observacion
FROM
    [dbo].[Reserva_mesa]
WHERE
    [fecha_reserva] LIKE @nombre+'%'
ORDER BY
    [fecha_reserva]
END
GO
/****** Object:  StoredProcedure [dbo].[cop_Reserva_mesa_GetAll]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Reserva_mesa_GetAll]
AS

SELECT
    [id_reserva_mesa] AS Id_reserva_mesa ,
    [fecha_reserva] AS Fecha_reserva ,
    [hora_reserva] AS Hora_reserva ,
    [nro_huesped] AS Nro_huesped ,
    [id_mesa] AS Id_mesa ,
    RTRIM(estado_reserva) AS Estado_reserva ,
    [id_cliente] AS Id_cliente ,
    RTRIM(observacion) AS Observacion
FROM
    [dbo].[Reserva_mesa]
ORDER BY
    [fecha_reserva]
GO
/****** Object:  StoredProcedure [dbo].[cop_Reserva_mesa_GetAll_2]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO









CREATE PROCEDURE [dbo].[cop_Reserva_mesa_GetAll_2]
	@bandera int,
	@fecha_inicio datetime,
	@fecha_fin datetime,
	@id_reserva_mesa int,
	@hora_reserva varchar(50)
AS

IF @bandera = 1 BEGIN --Por dia
SELECT
    [id_reserva_mesa] AS Id_reserva_mesa ,
	DATEADD(dd, 0, DATEDIFF(dd, 0, [fecha_reserva])) AS [Fecha Reservada],
    CONVERT(nvarchar(5),[hora_reserva],108) AS [Hora Reservada] ,
    [nro_huesped] AS [Personas] ,
	[Estado_reserva] AS Estado,
    [apellido] + '-' +[nombre] AS [Cliente] ,
    RTRIM(observacion) AS Observacion
FROM
    [dbo].[Reserva_mesa] INNER JOIN
	[dbo].[Cliente] ON cliente.id_cliente = reserva_mesa.id_cliente
WHERE
	DATEPART(day, fecha_reserva) = DATEPART(day, GETDATE()) AND
	DATEPART(month, fecha_reserva) = DATEPART(month, GETDATE()) AND
	DATEPART(year, fecha_reserva) = DATEPART(year, GETDATE()) AND
	estado_reserva = 'Pendiente'
ORDER BY
    [fecha_reserva]


END



IF @bandera = 2 BEGIN -- Por Mes
SELECT
    [id_reserva_mesa] AS Id_reserva_mesa ,
	DATEADD(dd, 0, DATEDIFF(dd, 0, [fecha_reserva])) AS [Fecha Reservada],
    CONVERT(nvarchar(5),[hora_reserva],108) AS [Hora Reservada] ,
    [nro_huesped] AS [Personas] ,
	[Estado_reserva] AS Estado,
    [apellido] + '-' +[nombre] AS [Cliente] ,
    RTRIM(observacion) AS Observacion
FROM
    [dbo].[Reserva_mesa] INNER JOIN
	[dbo].[Cliente] ON cliente.id_cliente = reserva_mesa.id_cliente
WHERE
	DATEPART(month, fecha_reserva) = DATEPART(month, GETDATE()) AND
	DATEPART(year, fecha_reserva) = DATEPART(year, GETDATE()) AND
	estado_reserva = 'Pendiente'
ORDER BY
    [fecha_reserva]
END


IF @bandera = 3 BEGIN -- Por Año
SELECT
    [id_reserva_mesa] AS Id_reserva_mesa ,
	DATEADD(dd, 0, DATEDIFF(dd, 0, [fecha_reserva])) AS [Fecha Reservada],
    CONVERT(nvarchar(5),[hora_reserva],108) AS [Hora Reservada] ,
    [nro_huesped] AS [Personas] ,
	[Estado_reserva] AS Estado,
    [apellido] + '-' +[nombre] AS [Cliente] ,
    RTRIM(observacion) AS Observacion
FROM
    [dbo].[Reserva_mesa] INNER JOIN
	[dbo].[Cliente] ON cliente.id_cliente = reserva_mesa.id_cliente
WHERE
	DATEPART(year, fecha_reserva) = DATEPART(year, GETDATE()) AND
	estado_reserva = 'Pendiente'
ORDER BY
    [fecha_reserva]
END



IF @bandera = 4 BEGIN --Todo Por Fechas
SELECT
    [id_reserva_mesa] AS Id_reserva_mesa ,
	DATEADD(dd, 0, DATEDIFF(dd, 0, [fecha_reserva])) AS [Fecha Reservada],
    CONVERT(nvarchar(5),[hora_reserva],108) AS [Hora Reservada] ,
    [nro_huesped] AS [Personas] ,
	[Estado_reserva] AS Estado,
    [apellido] + '-' +[nombre] AS [Cliente] ,
    RTRIM(observacion) AS Observacion
FROM
    [dbo].[Reserva_mesa] INNER JOIN
	[dbo].[Cliente] ON cliente.id_cliente = reserva_mesa.id_cliente
WHERE
	fecha_reserva >= @fecha_inicio AND
	fecha_reserva < @fecha_fin AND
--	fecha_reserva between @fecha_inicio and @fecha_fin AND
	estado_reserva = 'Pendiente'
ORDER BY
    [fecha_reserva]
END

IF @bandera = 5 BEGIN --TODOS HISTORICAS
SELECT
    [id_reserva_mesa] AS Id_reserva_mesa ,
	DATEADD(dd, 0, DATEDIFF(dd, 0, [fecha_reserva])) AS [Fecha Reservada],
    CONVERT(nvarchar(5),[hora_reserva],108) AS [Hora Reservada] ,
    [nro_huesped] AS [Personas] ,
	[nombre_mesa] AS [Mesa],
	[Estado_reserva] AS Estado,
    [apellido] + '-' +[nombre] AS [Cliente] ,
    RTRIM(observacion) AS Observacion
FROM
    [dbo].[Reserva_mesa] INNER JOIN
	[dbo].[Cliente] ON cliente.id_cliente = reserva_mesa.id_cliente INNER JOIN
	[dbo].[Mesa] ON [dbo].[reserva_mesa].id_mesa = [dbo].[mesa].id_mesa
WHERE
	fecha_reserva >= @fecha_inicio AND
	fecha_reserva < @fecha_fin AND
--	fecha_reserva between @fecha_inicio and @fecha_fin AND
	estado_reserva = 'Finalizada'
ORDER BY
    [fecha_reserva]
END


IF @bandera = 6 BEGIN --POR MESA RESERVADA
SELECT
    [id_reserva_mesa] AS Id_reserva_mesa ,
	DATEADD(dd, 0, DATEDIFF(dd, 0, [fecha_reserva])) AS [Fecha Reservada],
    CONVERT(nvarchar(5),[hora_reserva],108) AS [Hora Reservada] ,
    [nro_huesped] AS [Personas] ,
	[Estado_reserva] AS Estado,
    [apellido] + '-' +[nombre] AS [Cliente] ,
    RTRIM(observacion) AS Observacion
FROM
    [dbo].[Reserva_mesa] INNER JOIN
	[dbo].[Cliente] ON cliente.id_cliente = reserva_mesa.id_cliente
WHERE
	id_reserva_mesa = @id_reserva_mesa
ORDER BY
    [fecha_reserva]
END

IF @bandera = 7 BEGIN --POR HORA
SELECT
    [id_reserva_mesa] AS Id_reserva_mesa ,
	DATEADD(dd, 0, DATEDIFF(dd, 0, [fecha_reserva])) AS [Fecha Reservada],
    CONVERT(nvarchar(5),[hora_reserva],108) AS [Hora Reservada] ,
    [nro_huesped] AS [Personas] ,
	[Estado_reserva] AS Estado,
    [apellido] + '-' +[nombre] AS [Cliente] ,
    RTRIM(observacion) AS Observacion
FROM
    [dbo].[Reserva_mesa] INNER JOIN
	[dbo].[Cliente] ON cliente.id_cliente = reserva_mesa.id_cliente
WHERE
	day(fecha_reserva) = day(getdate()) AND
	month(fecha_reserva) = month(getdate()) AND
	year(fecha_reserva) = year(getdate()) AND
	hora_reserva - CAST(FLOOR(CAST(hora_reserva AS float)) AS datetime) = @Hora_reserva
ORDER BY
    [fecha_reserva]
END



GO
/****** Object:  StoredProcedure [dbo].[cop_Reserva_Mesa_GetCantidadPosibles]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[cop_Reserva_Mesa_GetCantidadPosibles]

AS

DECLARE @mesa int
SET @mesa = 0
DECLARE @hora int
SET @hora = 0

SELECT
	@mesa = COUNT(*)
FROM MESA


select
	@hora = count(*)
from
	reserva_hora

IF @mesa IS NULL
BEGIN
    SET @mesa=0
END

IF @hora IS NULL
BEGIN
    SET @hora = 0
END

select @mesa * @hora 'Total'
GO
/****** Object:  StoredProcedure [dbo].[cop_Reserva_mesa_GetCmb]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Reserva_mesa_GetCmb]
AS

SELECT
    [id_reserva_mesa],
    [fecha_reserva],
    [hora_reserva],
    [nro_huesped],
    [id_mesa],
    [estado_reserva],
    [id_cliente],
    [observacion]
FROM
    [dbo].[Reserva_mesa]
ORDER BY
    [fecha_reserva]
GO
/****** Object:  StoredProcedure [dbo].[cop_Reserva_Mesa_GetDiaMesAño]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[cop_Reserva_Mesa_GetDiaMesAño]
AS

DECLARE @dia int
SET @dia = 0
DECLARE @mes int
SET @mes = 0
DECLARE @año int
SET @año = 0

SELECT
    @dia = count(*)
FROM
    [dbo].[Reserva_Mesa]
WHERE
	DATEPART(day, fecha_reserva) = DATEPART(day, GETDATE()) AND
	DATEPART(month, fecha_reserva) = DATEPART(month, GETDATE()) AND
	DATEPART(year, fecha_reserva) = DATEPART(year, GETDATE()) AND
	Estado_reserva = 'Pendiente'
	
SELECT
    @mes = count(*)
FROM
    [dbo].[Reserva_Mesa]
WHERE
	DATEPART(month, fecha_reserva) = DATEPART(month, GETDATE()) AND
	DATEPART(year, fecha_reserva) = DATEPART(year, GETDATE()) AND
	Estado_reserva = 'Pendiente'

SELECT
    @año = count(*)
FROM
    [dbo].[Reserva_Mesa]
WHERE
	DATEPART(year, fecha_reserva) = DATEPART(year, GETDATE()) AND
	Estado_reserva = 'Pendiente'

IF @dia IS NULL
BEGIN
    SET @dia=0
END

IF @mes IS NULL
BEGIN
    SET @mes = 0
END

IF @año IS NULL
BEGIN
    SET @mes = 0
END
SELECT @dia AS Dia, @mes AS Mes, @año AS Año



GO
/****** Object:  StoredProcedure [dbo].[cop_Reserva_Mesa_GetDistinctFecha]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[cop_Reserva_Mesa_GetDistinctFecha]
AS

SELECT DISTINCT
	Reserva_mesa.Fecha_reserva, COUNT(*) 'Total'

FROM RESERVA_MESA

GROUP BY
	FECHA_RESERVA


GO
/****** Object:  StoredProcedure [dbo].[cop_Reserva_mesa_GetOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Reserva_mesa_GetOne]
    @id_reserva_mesa    int
AS

SELECT
    [id_reserva_mesa] AS Id_reserva_mesa ,
    [fecha_reserva] AS Fecha_reserva ,
    [hora_reserva] AS Hora_reserva ,
    [nro_huesped] AS Nro_huesped ,
    [id_mesa] AS Id_mesa ,
    [estado_reserva] AS Estado_reserva ,
    [id_cliente] AS Id_cliente ,
    [observacion] AS Observacion
FROM
    [dbo].[Reserva_mesa]
WHERE
    [id_reserva_mesa]  =  @id_reserva_mesa
GO
/****** Object:  StoredProcedure [dbo].[cop_Reserva_mesa_GetOne_2]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[cop_Reserva_mesa_GetOne_2]
    @id_reserva_mesa    int
AS

SELECT
    [id_reserva_mesa] AS Id_reserva_mesa ,
    [fecha_reserva] AS Fecha_reserva ,
    CONVERT(nvarchar(5),Hora_reserva,108) AS Hora_reserva ,
    [nro_huesped] AS Nro_huesped ,
    [id_mesa] AS Id_mesa ,
    [estado_reserva] AS Estado_reserva ,
    [id_cliente] AS Id_cliente ,
    [observacion] AS Observacion
FROM
    [dbo].[Reserva_mesa]
WHERE
    [id_reserva_mesa]  =  @id_reserva_mesa

GO
/****** Object:  StoredProcedure [dbo].[cop_Reserva_mesa_Insert]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Reserva_mesa_Insert]
    @id_reserva_mesa    int  output,
    @fecha_reserva    datetime  ,
    @hora_reserva    datetime  ,
    @nro_huesped    decimal  (18,0),
    @id_mesa    int  ,
    @estado_reserva    varchar  (50),
    @id_cliente    int  ,
    @observacion    varchar  (5000)
AS

INSERT INTO [dbo].[Reserva_mesa]
(
    [fecha_reserva],
    [hora_reserva],
    [nro_huesped],
    [id_mesa],
    [estado_reserva],
    [id_cliente],
    [observacion]
)
VALUES
(
    @fecha_reserva,
    @hora_reserva,
    @nro_huesped,
    @id_mesa,
    @estado_reserva,
    @id_cliente,
    @observacion
)
SET @id_reserva_mesa = @@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[cop_Reserva_mesa_InsertOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Reserva_mesa_InsertOne]
AS

INSERT INTO [dbo].[Reserva_mesa]
(
    [fecha_reserva],
    [hora_reserva],
    [nro_huesped],
    [id_mesa],
    [estado_reserva],
    [id_cliente],
    [observacion]
)
VALUES
(
    '01-01-2000',
    '01-01-2000',
    0,
    1,
    'Ninguno',
    1,
    'Ninguno'
)
GO
/****** Object:  StoredProcedure [dbo].[cop_Reserva_mesa_Update]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Reserva_mesa_Update]
    @id_reserva_mesa    int  output,
    @fecha_reserva    datetime  ,
    @hora_reserva    datetime  ,
    @nro_huesped    decimal  (18,0),
    @id_mesa    int  ,
    @estado_reserva    varchar  (50),
    @id_cliente    int  ,
    @observacion    varchar  (5000)
AS

UPDATE [dbo].[Reserva_mesa] SET
    [fecha_reserva] = @fecha_reserva,
    [hora_reserva] = @hora_reserva,
    [nro_huesped] = @nro_huesped,
    [id_mesa] = @id_mesa,
    [estado_reserva] = @estado_reserva,
    [id_cliente] = @id_cliente,
    [observacion] = @observacion
WHERE
    [id_reserva_mesa]  =  @id_reserva_mesa
GO
/****** Object:  StoredProcedure [dbo].[cop_Temp_pedido_Delete]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Temp_pedido_Delete]
    @id_temp_pedido    int
AS

DELETE FROM [dbo].[Temp_pedido]
WHERE
    [id_temp_pedido]  =  @id_temp_pedido
GO
/****** Object:  StoredProcedure [dbo].[cop_Temp_pedido_Exist]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Temp_pedido_Exist]
    @fecha    datetime  ,
    @id_producto    int  ,
    @id_cuerpo_pedido    int  ,
    @id_mesa    int  ,
    @id_pedido    int  ,
    @precio    decimal  (18,2),
    @cantidad    decimal  (18,0)
AS

DECLARE @total int
SET @total = 0

SELECT
    @total = id_temp_pedido
FROM
    [dbo].[Temp_pedido]
WHERE
    [fecha] = @fecha AND
    [id_producto] = @id_producto AND
    [id_cuerpo_pedido] = @id_cuerpo_pedido AND
    [id_mesa] = @id_mesa AND
    [id_pedido] = @id_pedido AND
    [precio] = @precio AND
    [cantidad] = @cantidad

IF @total IS NULL
BEGIN
    SET @total=0
END
SELECT @total AS Total
GO
/****** Object:  StoredProcedure [dbo].[cop_Temp_pedido_Find]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Temp_pedido_Find]
    @nombre NVARCHAR (30)=NULL
AS SET NOCOUNT ON

IF @nombre IS NOT NULL
BEGIN
SELECT @nombre=RTRIM(@nombre)+'%'
SELECT
    [id_temp_pedido] AS Id_temp_pedido ,
    [fecha] AS Fecha ,
    [id_producto] AS Id_producto ,
    [id_cuerpo_pedido] AS Id_cuerpo_pedido ,
    [id_mesa] AS Id_mesa ,
    [id_pedido] AS Id_pedido ,
    [precio] AS Precio ,
    [cantidad] AS Cantidad
FROM
    [dbo].[Temp_pedido]
WHERE
    [fecha] LIKE @nombre+'%'
ORDER BY
    [fecha]
END
GO
/****** Object:  StoredProcedure [dbo].[cop_Temp_pedido_GetAll]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Temp_pedido_GetAll]
AS

SELECT
    [id_temp_pedido] AS Id_temp_pedido ,
    [fecha] AS Fecha ,
    [id_producto] AS Id_producto ,
    [id_cuerpo_pedido] AS Id_cuerpo_pedido ,
    [id_mesa] AS Id_mesa ,
    [id_pedido] AS Id_pedido ,
    [precio] AS Precio ,
    [cantidad] AS Cantidad
FROM
    [dbo].[Temp_pedido]
ORDER BY
    [fecha]
GO
/****** Object:  StoredProcedure [dbo].[cop_Temp_pedido_GetCmb]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Temp_pedido_GetCmb]
AS

SELECT
    [id_temp_pedido],
    [fecha],
    [id_producto],
    [id_cuerpo_pedido],
    [id_mesa],
    [id_pedido],
    [precio],
    [cantidad]
FROM
    [dbo].[Temp_pedido]
ORDER BY
    [fecha]
GO
/****** Object:  StoredProcedure [dbo].[cop_Temp_pedido_GetFiltro]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[cop_Temp_pedido_GetFiltro]
    @id_pedido    int,
	@id_cuerpo_pedido int
AS

SELECT
    [id_temp_pedido] AS Id_temp_pedido ,
    [fecha] AS Fecha ,
    [id_producto] AS Id_producto ,
    [id_cuerpo_pedido] AS Id_cuerpo_pedido ,
    [id_mesa] AS Id_mesa ,
    [id_pedido] AS Id_pedido ,
    [precio] AS Precio ,
    [cantidad] AS Cantidad
FROM
    [dbo].[Temp_pedido]
WHERE
    id_pedido = @id_pedido AND
	id_cuerpo_pedido = @id_cuerpo_pedido

GO
/****** Object:  StoredProcedure [dbo].[cop_Temp_pedido_GetOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Temp_pedido_GetOne]
    @id_temp_pedido    int
AS

SELECT
    [id_temp_pedido] AS Id_temp_pedido ,
    [fecha] AS Fecha ,
    [id_producto] AS Id_producto ,
    [id_cuerpo_pedido] AS Id_cuerpo_pedido ,
    [id_mesa] AS Id_mesa ,
    [id_pedido] AS Id_pedido ,
    [precio] AS Precio ,
    [cantidad] AS Cantidad
FROM
    [dbo].[Temp_pedido]
WHERE
    [id_temp_pedido]  =  @id_temp_pedido
GO
/****** Object:  StoredProcedure [dbo].[cop_Temp_pedido_GetPedido]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[cop_Temp_pedido_GetPedido]
    @id_pedido    int
AS

SELECT
    [id_temp_pedido] AS Id_temp_pedido ,
    [fecha] AS Fecha ,
    [id_producto] AS Id_producto ,
    [id_cuerpo_pedido] AS Id_cuerpo_pedido ,
    [id_mesa] AS Id_mesa ,
    [id_pedido] AS Id_pedido ,
    [precio] AS Precio ,
    [cantidad] AS Cantidad
FROM
    [dbo].[Temp_pedido]
WHERE
    id_pedido = @id_pedido


GO
/****** Object:  StoredProcedure [dbo].[cop_Temp_Pedido_GetPrint]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[cop_Temp_Pedido_GetPrint]
	@id_pedido int

AS

SELECT
    producto.[nombre_producto] as [nombre producto],
	TEMP_PEDIDO.[cantidad] as [cantidad],
	producto.[precio] as [precio],
	TEMP_PEDIDO.id_pedido,
	nombre_mesa
	
FROM
    [dbo].[temp_pedido] INNER JOIN
	cuerpo_pedido ON cuerpo_pedido.id_cuerpo_pedido = temp_pedido.id_cuerpo_pedido INNER JOIN
	pedido ON pedido.[id_pedido] = temp_pedido.[id_pedido] INNER JOIN
	mesa ON mesa.id_mesa = temp_pedido.id_mesa INNER JOIN
	PRODUCTO ON producto.id_producto = temp_pedido.id_producto
WHERE
	temp_pedido.id_pedido = @id_pedido
	
ORDER BY
    [nombre_producto]






GO
/****** Object:  StoredProcedure [dbo].[cop_Temp_pedido_Insert]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Temp_pedido_Insert]
    @id_temp_pedido    int  output,
    @fecha    datetime  ,
    @id_producto    int  ,
    @id_cuerpo_pedido    int  ,
    @id_mesa    int  ,
    @id_pedido    int  ,
    @precio    decimal  (18,2),
    @cantidad    decimal  (18,0)
AS

INSERT INTO [dbo].[Temp_pedido]
(
    [fecha],
    [id_producto],
    [id_cuerpo_pedido],
    [id_mesa],
    [id_pedido],
    [precio],
    [cantidad]
)
VALUES
(
    @fecha,
    @id_producto,
    @id_cuerpo_pedido,
    @id_mesa,
    @id_pedido,
    @precio,
    @cantidad
)
SET @id_temp_pedido = @@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[cop_Temp_pedido_InsertOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Temp_pedido_InsertOne]
AS

INSERT INTO [dbo].[Temp_pedido]
(
    [fecha],
    [id_producto],
    [id_cuerpo_pedido],
    [id_mesa],
    [id_pedido],
    [precio],
    [cantidad]
)
VALUES
(
    '01-01-2000',
    1,
    1,
    1,
    1,
    0,
     0 
)
GO
/****** Object:  StoredProcedure [dbo].[cop_Temp_pedido_Update]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Temp_pedido_Update]
    @id_temp_pedido    int  output,
    @fecha    datetime  ,
    @id_producto    int  ,
    @id_cuerpo_pedido    int  ,
    @id_mesa    int  ,
    @id_pedido    int  ,
    @precio    decimal  (18,2),
    @cantidad    decimal  (18,0)
AS

UPDATE [dbo].[Temp_pedido] SET
    [fecha] = @fecha,
    [id_producto] = @id_producto,
    [id_cuerpo_pedido] = @id_cuerpo_pedido,
    [id_mesa] = @id_mesa,
    [id_pedido] = @id_pedido,
    [precio] = @precio,
    [cantidad] = @cantidad
WHERE
    [id_temp_pedido]  =  @id_temp_pedido
GO
/****** Object:  StoredProcedure [dbo].[cop_Temp_ticket_Delete]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Temp_ticket_Delete]
    @id_temp_ticket    int
AS

DELETE FROM [dbo].[Temp_ticket]
WHERE
    [id_temp_ticket]  =  @id_temp_ticket
GO
/****** Object:  StoredProcedure [dbo].[cop_Temp_ticket_Exist]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Temp_ticket_Exist]
    @id_producto    int  ,
    @id_cuerpo_pedido    int  ,
    @id_pedido    int  ,
    @precio    decimal  (18,2),
    @cantidad    decimal  (18,2),
    @importe    decimal  (18,2),
    @totals    decimal  (18,2),
    @porcentaje_descuento    decimal  (18,2),
    @descuento    decimal  (18,2)
AS

DECLARE @total int
SET @total = 0

SELECT
    @total = id_temp_ticket
FROM
    [dbo].[Temp_ticket]
WHERE
    [id_producto] = @id_producto AND
    [id_cuerpo_pedido] = @id_cuerpo_pedido AND
    [id_pedido] = @id_pedido AND
    [precio] = @precio AND
    [cantidad] = @cantidad AND
    [importe] = @importe AND
    [totals] = @totals AND
    [porcentaje_descuento] = @porcentaje_descuento AND
    [descuento] = @descuento

IF @total IS NULL
BEGIN
    SET @total=0
END
SELECT @total AS Total
GO
/****** Object:  StoredProcedure [dbo].[cop_Temp_ticket_Find]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Temp_ticket_Find]
    @nombre NVARCHAR (30)=NULL
AS SET NOCOUNT ON

IF @nombre IS NOT NULL
BEGIN
SELECT @nombre=RTRIM(@nombre)+'%'
SELECT TOP 100
    [id_temp_ticket] AS [Id temp ticket] ,
    [id_producto] AS [Id producto] ,
    [id_cuerpo_pedido] AS [Id cuerpo pedido] ,
    [id_pedido] AS [Id pedido] ,
    [precio] AS [Precio] ,
    [cantidad] AS [Cantidad] ,
    [importe] AS [Importe] ,
    [totals] AS [Totals] ,
    [porcentaje_descuento] AS [Porcentaje descuento] ,
    [descuento] AS [Descuento]
FROM
    [dbo].[Temp_ticket]
WHERE
    [id_producto] LIKE @nombre+'%'
ORDER BY
    [id_producto]
END
GO
/****** Object:  StoredProcedure [dbo].[cop_Temp_ticket_GetAll]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Temp_ticket_GetAll]
AS

SELECT TOP 100
    [id_temp_ticket] AS [Id temp ticket] ,
    [id_producto] AS [Id producto] ,
    [id_cuerpo_pedido] AS [Id cuerpo pedido] ,
    [id_pedido] AS [Id pedido] ,
    [precio] AS [Precio] ,
    [cantidad] AS [Cantidad] ,
    [importe] AS [Importe] ,
    [totals] AS [Totals] ,
    [porcentaje_descuento] AS [Porcentaje descuento] ,
    [descuento] AS [Descuento]
FROM
    [dbo].[Temp_ticket]
ORDER BY
    [id_producto]
GO
/****** Object:  StoredProcedure [dbo].[cop_Temp_ticket_GetCmb]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Temp_ticket_GetCmb]
AS

SELECT
    [id_temp_ticket],
    [id_producto],
    [id_cuerpo_pedido],
    [id_pedido],
    [precio],
    [cantidad],
    [importe],
    [totals],
    [porcentaje_descuento],
    [descuento]
FROM
    [dbo].[Temp_ticket]
ORDER BY
    [id_producto]
GO
/****** Object:  StoredProcedure [dbo].[cop_Temp_ticket_GetOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Temp_ticket_GetOne]
    @id_temp_ticket    int
AS

SELECT
    [id_temp_ticket] AS [Id temp ticket] ,
    [id_producto] AS [Id producto] ,
    [id_cuerpo_pedido] AS [Id cuerpo pedido] ,
    [id_pedido] AS [Id pedido] ,
    [precio] AS [Precio] ,
    [cantidad] AS [Cantidad] ,
    [importe] AS [Importe] ,
    [totals] AS [Totals] ,
    [porcentaje_descuento] AS [Porcentaje descuento] ,
    [descuento] AS [Descuento]
FROM
    [dbo].[Temp_ticket]
WHERE
    [id_temp_ticket]  =  @id_temp_ticket
GO
/****** Object:  StoredProcedure [dbo].[cop_Temp_ticket_GetReporte]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[cop_Temp_ticket_GetReporte]
	@id_pedido int

AS
SELECT     
	dbo.PEDIDO.fecha,
	dbo.TEMP_TICKET.cantidad,
	dbo.PRODUCTO.precio, 
	dbo.PRODUCTO.nombre_producto,
	dbo.MESA.nombre_mesa,
	dbo.PEDIDO.id_pedido,
	dbo.TEMP_TICKET.importe,
	dbo.TEMP_TICKET.totals, 
	dbo.TEMP_TICKET.porcentaje_descuento, 
	dbo.TEMP_TICKET.descuento
FROM         
	dbo.TEMP_TICKET INNER JOIN
	dbo.CUERPO_PEDIDO ON CUERPO_PEDIDO.id_cuerpo_pedido = TEMP_TICKET.id_cuerpo_pedido INNER JOIN
	dbo.PEDIDO ON dbo.TEMP_TICKET.id_pedido = dbo.PEDIDO.id_pedido INNER JOIN
	dbo.PRODUCTO ON dbo.TEMP_TICKET.id_producto = dbo.PRODUCTO.id_producto INNER JOIN
	dbo.MESA ON dbo.PEDIDO.id_mesa = dbo.MESA.id_mesa
WHERE
	dbo.PEDIDO.id_pedido = @id_pedido

GO
/****** Object:  StoredProcedure [dbo].[cop_Temp_ticket_Insert]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Temp_ticket_Insert]
    @id_temp_ticket    int  output,
    @id_producto    int  ,
    @id_cuerpo_pedido    int  ,
    @id_pedido    int  ,
    @precio    decimal  (18,2),
    @cantidad    decimal  (18,2),
    @importe    decimal  (18,2),
    @totals    decimal  (18,2),
    @porcentaje_descuento    decimal  (18,2),
    @descuento    decimal  (18,2)
AS

INSERT INTO [dbo].[Temp_ticket]
(
    [id_producto],
    [id_cuerpo_pedido],
    [id_pedido],
    [precio],
    [cantidad],
    [importe],
    [totals],
    [porcentaje_descuento],
    [descuento]
)
VALUES
(
    @id_producto,
    @id_cuerpo_pedido,
    @id_pedido,
    @precio,
    @cantidad,
    @importe,
    @totals,
    @porcentaje_descuento,
    @descuento
)
SET @id_temp_ticket = @@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[cop_Temp_ticket_InsertOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Temp_ticket_InsertOne]
AS

INSERT INTO [dbo].[Temp_ticket]
(
    [id_producto],
    [id_cuerpo_pedido],
    [id_pedido],
    [precio],
    [cantidad],
    [importe],
    [totals],
    [porcentaje_descuento],
    [descuento]
)
VALUES
(
    1,
    1,
    1,
    0,
    0,
    0,
    0,
    0,
     0 
)
GO
/****** Object:  StoredProcedure [dbo].[cop_Temp_ticket_Update]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Temp_ticket_Update]
    @id_temp_ticket    int  output,
    @id_producto    int  ,
    @id_cuerpo_pedido    int  ,
    @id_pedido    int  ,
    @precio    decimal  (18,2),
    @cantidad    decimal  (18,2),
    @importe    decimal  (18,2),
    @totals    decimal  (18,2),
    @porcentaje_descuento    decimal  (18,2),
    @descuento    decimal  (18,2)
AS

UPDATE [dbo].[Temp_ticket] SET
    [id_producto] = @id_producto,
    [id_cuerpo_pedido] = @id_cuerpo_pedido,
    [id_pedido] = @id_pedido,
    [precio] = @precio,
    [cantidad] = @cantidad,
    [importe] = @importe,
    [totals] = @totals,
    [porcentaje_descuento] = @porcentaje_descuento,
    [descuento] = @descuento
WHERE
    [id_temp_ticket]  =  @id_temp_ticket
GO
/****** Object:  StoredProcedure [dbo].[cop_Tipo_dni_Delete]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Tipo_dni_Delete]
    @id_tipo_dni    int
AS

DELETE FROM [dbo].[Tipo_dni]
WHERE
    [id_tipo_dni]  =  @id_tipo_dni
GO
/****** Object:  StoredProcedure [dbo].[cop_Tipo_dni_Exist]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Tipo_dni_Exist]
    @nombre_tipo_dni    varchar  (50)
AS

DECLARE @total int
SET @total = 0

SELECT
    @total = id_tipo_dni
FROM
    [dbo].[Tipo_dni]
WHERE
    [nombre_tipo_dni] = @nombre_tipo_dni

IF @total IS NULL
BEGIN
    SET @total=0
END
SELECT @total AS Total
GO
/****** Object:  StoredProcedure [dbo].[cop_Tipo_dni_Find]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Tipo_dni_Find]
    @nombre NVARCHAR (30)=NULL
AS SET NOCOUNT ON

IF @nombre IS NOT NULL
BEGIN
SELECT @nombre=RTRIM(@nombre)+'%'
SELECT TOP 100
    [id_tipo_dni] AS [Id tipo dni] ,
    RTRIM(nombre_tipo_dni) AS [Nombre tipo dni]
FROM
    [dbo].[Tipo_dni]
WHERE
    [nombre_tipo_dni] LIKE @nombre+'%'
ORDER BY
    [nombre_tipo_dni]
END
GO
/****** Object:  StoredProcedure [dbo].[cop_Tipo_dni_GetAll]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Tipo_dni_GetAll]
AS

SELECT TOP 100
    [id_tipo_dni] AS [Id tipo dni] ,
    RTRIM(nombre_tipo_dni) AS [Nombre tipo dni]
FROM
    [dbo].[Tipo_dni]
ORDER BY
    [nombre_tipo_dni]
GO
/****** Object:  StoredProcedure [dbo].[cop_Tipo_dni_GetCmb]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Tipo_dni_GetCmb]
AS

SELECT
    [id_tipo_dni],
    [nombre_tipo_dni]
FROM
    [dbo].[Tipo_dni]
ORDER BY
    [nombre_tipo_dni]
GO
/****** Object:  StoredProcedure [dbo].[cop_Tipo_dni_GetOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Tipo_dni_GetOne]
    @id_tipo_dni    int
AS

SELECT
    [id_tipo_dni] AS [Id tipo dni] ,
    [nombre_tipo_dni] AS [Nombre tipo dni]
FROM
    [dbo].[Tipo_dni]
WHERE
    [id_tipo_dni]  =  @id_tipo_dni
GO
/****** Object:  StoredProcedure [dbo].[cop_Tipo_dni_Insert]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Tipo_dni_Insert]
    @id_tipo_dni    int  output,
    @nombre_tipo_dni    varchar  (50)
AS

INSERT INTO [dbo].[Tipo_dni]
(
    [nombre_tipo_dni]
)
VALUES
(
    @nombre_tipo_dni
)
SET @id_tipo_dni = @@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[cop_Tipo_dni_InsertOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Tipo_dni_InsertOne]
AS

INSERT INTO [dbo].[Tipo_dni]
(
    [nombre_tipo_dni]
)
VALUES
(
    'Ninguno'
)
GO
/****** Object:  StoredProcedure [dbo].[cop_Tipo_dni_Update]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Tipo_dni_Update]
    @id_tipo_dni    int  output,
    @nombre_tipo_dni    varchar  (50)
AS

UPDATE [dbo].[Tipo_dni] SET
    [nombre_tipo_dni] = @nombre_tipo_dni
WHERE
    [id_tipo_dni]  =  @id_tipo_dni
GO
/****** Object:  StoredProcedure [dbo].[cop_Tipo_forma_pago_Delete]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Tipo_forma_pago_Delete]
    @id_tipo_forma_pago    int
AS

DELETE FROM [dbo].[Tipo_forma_pago]
WHERE
    [id_tipo_forma_pago]  =  @id_tipo_forma_pago
GO
/****** Object:  StoredProcedure [dbo].[cop_Tipo_forma_pago_Exist]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Tipo_forma_pago_Exist]
    @nombre_tipo_forma_pago    varchar  (50)
AS

DECLARE @total int
SET @total = 0

SELECT
    @total = id_tipo_forma_pago
FROM
    [dbo].[Tipo_forma_pago]
WHERE
    [nombre_tipo_forma_pago] = @nombre_tipo_forma_pago

IF @total IS NULL
BEGIN
    SET @total=0
END
SELECT @total AS Total
GO
/****** Object:  StoredProcedure [dbo].[cop_Tipo_forma_pago_Find]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Tipo_forma_pago_Find]
    @nombre NVARCHAR (30)=NULL
AS SET NOCOUNT ON

IF @nombre IS NOT NULL
BEGIN
SELECT @nombre=RTRIM(@nombre)+'%'
SELECT
    [id_tipo_forma_pago] AS Id_tipo_forma_pago ,
    RTRIM(nombre_tipo_forma_pago) AS Nombre_tipo_forma_pago
FROM
    [dbo].[Tipo_forma_pago]
WHERE
    [nombre_tipo_forma_pago] LIKE @nombre+'%'
ORDER BY
    [nombre_tipo_forma_pago]
END
GO
/****** Object:  StoredProcedure [dbo].[cop_Tipo_forma_pago_GetAll]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Tipo_forma_pago_GetAll]
AS

SELECT
    [id_tipo_forma_pago] AS Id_tipo_forma_pago ,
    RTRIM(nombre_tipo_forma_pago) AS Nombre_tipo_forma_pago
FROM
    [dbo].[Tipo_forma_pago]
ORDER BY
    [nombre_tipo_forma_pago]
GO
/****** Object:  StoredProcedure [dbo].[cop_Tipo_forma_pago_GetCmb]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Tipo_forma_pago_GetCmb]
AS

SELECT
    [id_tipo_forma_pago],
    [nombre_tipo_forma_pago]
FROM
    [dbo].[Tipo_forma_pago]
ORDER BY
    [nombre_tipo_forma_pago]
GO
/****** Object:  StoredProcedure [dbo].[cop_Tipo_forma_pago_GetOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Tipo_forma_pago_GetOne]
    @id_tipo_forma_pago    int
AS

SELECT
    [id_tipo_forma_pago] AS Id_tipo_forma_pago ,
    [nombre_tipo_forma_pago] AS Nombre_tipo_forma_pago
FROM
    [dbo].[Tipo_forma_pago]
WHERE
    [id_tipo_forma_pago]  =  @id_tipo_forma_pago
GO
/****** Object:  StoredProcedure [dbo].[cop_Tipo_forma_pago_Insert]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Tipo_forma_pago_Insert]
    @id_tipo_forma_pago    int  output,
    @nombre_tipo_forma_pago    varchar  (50)
AS

INSERT INTO [dbo].[Tipo_forma_pago]
(
    [nombre_tipo_forma_pago]
)
VALUES
(
    @nombre_tipo_forma_pago
)
SET @id_tipo_forma_pago = @@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[cop_Tipo_forma_pago_InsertOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Tipo_forma_pago_InsertOne]
AS

INSERT INTO [dbo].[Tipo_forma_pago]
(
    [nombre_tipo_forma_pago]
)
VALUES
(
    'Ninguno'
)
GO
/****** Object:  StoredProcedure [dbo].[cop_Tipo_forma_pago_Update]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Tipo_forma_pago_Update]
    @id_tipo_forma_pago    int  output,
    @nombre_tipo_forma_pago    varchar  (50)
AS

UPDATE [dbo].[Tipo_forma_pago] SET
    [nombre_tipo_forma_pago] = @nombre_tipo_forma_pago
WHERE
    [id_tipo_forma_pago]  =  @id_tipo_forma_pago
GO
/****** Object:  StoredProcedure [dbo].[cop_Tipo_Producto_Delete]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Tipo_Producto_Delete]
    @id_tipo_producto    int
AS

DELETE FROM [dbo].[TIPO_PRODUCTO]
WHERE
    [id_tipo_producto]  =  @id_tipo_producto



GO
/****** Object:  StoredProcedure [dbo].[cop_Tipo_Producto_Exist]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cop_Tipo_Producto_Exist]
    @nombre_tipo_producto  varchar  (50),
	@icono varchar(5000),
	@id_grupo_producto int
AS

DECLARE @total int
SET @total = 0

SELECT
    @total = id_tipo_producto
FROM
    [dbo].[TIPO_PRODUCTO]
WHERE
    [nombre_tipo_producto] = @nombre_tipo_producto and
	[icono] = @icono and
	[id_grupo_producto] = @id_grupo_producto


IF @total IS NULL
BEGIN
    SET @total=0
END
SELECT @total AS Total


GO
/****** Object:  StoredProcedure [dbo].[cop_Tipo_Producto_Find]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Tipo_Producto_Find]
    @nombre NVARCHAR (30)=NULL
AS SET NOCOUNT ON

IF @nombre IS NOT NULL
BEGIN
SELECT @nombre=RTRIM(@nombre)+'%'
SELECT TOP 100
    [id_tipo_producto] AS  [id tipo producto],
    [nombre_tipo_producto] AS [nombre tipo producto],
	[icono] as [icono],
	[nombre_grupo_producto] as [grupo producto]

	
FROM
    [dbo].[TIPO_PRODUCTO] INNER JOIN
	[dbo].[GRUPO_PRODUCTO] ON GRUPO_PRODUCTO.id_grupo_producto = TIPO_PRODUCTO.id_grupo_producto
WHERE
    [nombre_tipo_producto] LIKE @nombre+'%'
ORDER BY
    [nombre_tipo_producto]
END

GO
/****** Object:  StoredProcedure [dbo].[cop_Tipo_Producto_GetAll]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cop_Tipo_Producto_GetAll]
AS

SELECT TOP 100
    [id_tipo_producto] AS [id tipo producto] ,
    [nombre_tipo_producto] AS [nombre tipo producto],
	[icono] as [icono],
	[id_grupo_producto] AS [id grupo producto]

FROM
    [dbo].[TIPO_PRODUCTO]
ORDER BY
    [nombre_tipo_producto]

GO
/****** Object:  StoredProcedure [dbo].[cop_Tipo_Producto_GetAll_2]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[cop_Tipo_Producto_GetAll_2]
AS

SELECT TOP 100
    [id_tipo_producto] AS [id tipo producto] ,
    [nombre_tipo_producto] AS [nombre tipo producto],
	[icono] as [icono],
	[nombre_grupo_producto] AS [grupo producto]

FROM
    [dbo].[TIPO_PRODUCTO] INNER JOIN
	[dbo].[GRUPO_PRODUCTO] ON GRUPO_PRODUCTO.id_grupo_producto = TIPO_PRODUCTO.id_grupo_producto
ORDER BY
    [nombre_tipo_producto]



GO
/****** Object:  StoredProcedure [dbo].[cop_Tipo_Producto_GetCmb]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cop_Tipo_Producto_GetCmb]
AS

SELECT
    [id_tipo_producto],
    [nombre_tipo_producto],
	[icono]
	[id_grupo_producto]
FROM
    [dbo].[TIPO_PRODUCTO]
ORDER BY
    [nombre_tipo_producto]


GO
/****** Object:  StoredProcedure [dbo].[cop_Tipo_Producto_GetCmb_2]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cop_Tipo_Producto_GetCmb_2]
	@id_grupo_producto int
AS

SELECT
    [id_tipo_producto],
    [nombre_tipo_producto],
	[icono]
FROM
    [dbo].[TIPO_PRODUCTO] INNER JOIN
	[dbo].[GRUPO_PRODUCTO] ON GRUPO_PRODUCTO.id_grupo_producto = TIPO_PRODUCTO.id_grupo_producto
WHERE
	tipo_producto.id_grupo_producto = @id_grupo_producto
ORDER BY
    [nombre_tipo_producto]


GO
/****** Object:  StoredProcedure [dbo].[cop_Tipo_Producto_GetGrupo_Producto]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cop_Tipo_Producto_GetGrupo_Producto]
	@id_grupo_producto int
AS

SELECT TOP 100
    [id_tipo_producto] AS [id tipo producto] ,
    [nombre_tipo_producto] AS [nombre tipo producto]

FROM
    [dbo].[TIPO_PRODUCTO] tp, [dbo].[GRUPO_PRODUCTO] gp
WHERE tp.id_grupo_producto = gp.id_grupo_producto and
      tp.id_grupo_producto = @id_grupo_producto
ORDER BY
    [nombre_tipo_producto]

GO
/****** Object:  StoredProcedure [dbo].[cop_Tipo_Producto_GetOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cop_Tipo_Producto_GetOne]
    @id_tipo_producto    int
AS

SELECT
    [id_tipo_producto] AS [id tipo producto] ,
    [nombre_tipo_producto] AS [nombre tipo producto],
	[icono] as [icono],
	[id_grupo_producto] AS [id grupo producto]
FROM
    [dbo].[TIPO_PRODUCTO]
WHERE
    [id_tipo_producto]  =  @id_tipo_producto

GO
/****** Object:  StoredProcedure [dbo].[cop_Tipo_Producto_Insert]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cop_Tipo_Producto_Insert]
    @id_tipo_producto    int  output,
    @nombre_tipo_producto    varchar  (50),
	@icono varchar(5000),
	@id_grupo_producto int
AS

INSERT INTO [dbo].[TIPO_PRODUCTO]
(
    [nombre_tipo_producto],
	[icono],
	[id_grupo_producto]
)
VALUES
(
    @nombre_tipo_producto,  
	@icono,
	@id_grupo_producto
)
SET @id_tipo_producto = @@IDENTITY

GO
/****** Object:  StoredProcedure [dbo].[cop_Tipo_Producto_InsertOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cop_Tipo_Producto_InsertOne]
AS

INSERT INTO [dbo].[TIPO_PRODUCTO]
(
    [nombre_tipo_producto],
	[icono],
	[id_grupo_producto]
)
VALUES
(
    'Ninguno',
	'ninguna',
	1
)
GO
/****** Object:  StoredProcedure [dbo].[cop_Tipo_Producto_Update]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cop_Tipo_Producto_Update]
    @id_tipo_producto    int  output,
    @nombre_tipo_producto    varchar  (50),
	@icono varchar(5000),
	@id_grupo_producto int
AS

UPDATE [dbo].[TIPO_PRODUCTO] SET
    [nombre_tipo_producto] = @nombre_tipo_producto,
	[icono] = @icono,
	[id_grupo_producto] = @id_grupo_producto
WHERE
    [id_tipo_producto]  =  @id_tipo_producto
GO
/****** Object:  StoredProcedure [dbo].[cop_Usuario_Delete]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Usuario_Delete]
    @id_usuario    int
AS

DELETE FROM [dbo].[USUARIO]
WHERE
    [id_usuario]  =  @id_usuario


GO
/****** Object:  StoredProcedure [dbo].[cop_Usuario_Exist]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Usuario_Exist]
    @nombre_USUARIO  varchar  (50),
	@password_usuario varchar(50),
	@id_grupo_usuario int,
	@mail varchar(50)
AS

DECLARE @total int
SET @total = 0

SELECT
    @total = id_usuario
FROM
    [dbo].[USUARIO]
WHERE
    [nombre_USUARIO] = @nombre_USUARIO and
	[password_usuario] = @password_usuario and
	[id_grupo_usuario] = @id_grupo_usuario and
	[mail] = @mail

IF @total IS NULL
BEGIN
    SET @total=0
END
SELECT @total AS Total


GO
/****** Object:  StoredProcedure [dbo].[cop_Usuario_Find]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Usuario_Find]
    @nombre NVARCHAR (30)=NULL
AS SET NOCOUNT ON

IF @nombre IS NOT NULL
BEGIN
SELECT @nombre=RTRIM(@nombre)+'%'
SELECT TOP 100
    [id_usuario] AS [Id USUARIO] ,
    [nombre_usuario] AS [Nombre USUARIO],
	[password_usuario] as [Password Usuario],
	[id_grupo_usuario] as [id grupo usuario],
	[mail] as [mail]
	
FROM
    [dbo].[USUARIO]
WHERE
    [nombre_USUARIO] LIKE @nombre+'%'
ORDER BY
    [nombre_USUARIO]
END


GO
/****** Object:  StoredProcedure [dbo].[cop_Usuario_Find_2]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[cop_Usuario_Find_2]
    @nombre NVARCHAR (30)=NULL
AS SET NOCOUNT ON

IF @nombre IS NOT NULL
BEGIN
SELECT @nombre=RTRIM(@nombre)+'%'
SELECT TOP 100
    [id_usuario] AS [Id USUARIO] ,
    [nombre_usuario] AS [Nombre USUARIO],
	[password_usuario] as [Password Usuario],
	gp.[nombre_grupo_usuario] as [nombre grupo usuario],
	[mail] as [mail]
	
FROM
    [dbo].[USUARIO] u, [dbo].[GRUPO_USUARIO] gp
WHERE
	u.[id_grupo_usuario] = gp.[id_grupo_usuario] and
    [nombre_USUARIO] LIKE @nombre+'%'
ORDER BY
    [nombre_USUARIO]
END



GO
/****** Object:  StoredProcedure [dbo].[cop_Usuario_GetAll]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Usuario_GetAll]
AS

SELECT TOP 100
    [id_usuario] AS [Id USUARIO] ,
    [nombre_usuario] AS [Nombre USUARIO],
	[password_usuario] as [password USUARIO],
	[id_grupo_usuario] as [id grupo usuario],
	[mail] as [mail]
FROM
    [dbo].[USUARIO]
ORDER BY
    [nombre_USUARIO]
GO
/****** Object:  StoredProcedure [dbo].[cop_Usuario_GetAll_2]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cop_Usuario_GetAll_2]
AS

SELECT TOP 100
    [id_usuario] AS [Id USUARIO] ,
    [nombre_usuario] AS [Nombre USUARIO],
	[password_usuario] as [password USUARIO],
	[nombre_grupo_usuario] as [nombre grupo usuario],
	[mail] as [mail]
FROM
    [dbo].[USUARIO] u, [dbo].[GRUPO_USUARIO] gu
WHERE u.id_grupo_usuario = gu.id_grupo_usuario
ORDER BY
    [nombre_USUARIO]

GO
/****** Object:  StoredProcedure [dbo].[cop_Usuario_GetCmb]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Usuario_GetCmb]
AS

SELECT
    [id_usuario],
    [nombre_USUARIO],
	[password_usuario],
	[id_grupo_usuario],
	[mail]
FROM
    [dbo].[USUARIO]
ORDER BY
    [nombre_USUARIO]


GO
/****** Object:  StoredProcedure [dbo].[cop_Usuario_GetOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Usuario_GetOne]
    @id_usuario    int
AS

SELECT
    [id_usuario] AS [Id USUARIO] ,
    [nombre_usuario] AS [Nombre USUARIO],
	[password_usuario] as [password USUARIO],
	[id_grupo_usuario] as [id_grupo_usuario],
	[mail] as [mail]
FROM
    [dbo].[USUARIO]
WHERE
    [id_usuario]  =  @id_usuario


GO
/****** Object:  StoredProcedure [dbo].[cop_Usuario_Insert]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Usuario_Insert]
    @id_usuario    int  output,
    @nombre_USUARIO    varchar  (50),
	@password_usuario varchar(50),
	@id_grupo_usuario int,
	@mail varchar(50)
AS

INSERT INTO [dbo].[USUARIO]
(
    [nombre_USUARIO],
	[password_usuario],
	[id_grupo_usuario],
	[mail]
)
VALUES
(
    @nombre_USUARIO,  
	@password_usuario,
	@id_grupo_usuario,
	@mail
)
SET @id_usuario = @@IDENTITY


GO
/****** Object:  StoredProcedure [dbo].[cop_Usuario_InsertOne]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cop_Usuario_InsertOne]
AS

INSERT INTO [dbo].[USUARIO]
(
    [nombre_USUARIO],
	[password_usuario],
	[id_grupo_usuario],
	[mail]
)
VALUES
(
    'Ninguno',
	'ninguna',
	1,
	'ninguno'
)


GO
/****** Object:  StoredProcedure [dbo].[cop_Usuario_logon]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[cop_Usuario_logon]
    @nombre_USUARIO  varchar  (50),
	@password_usuario varchar(50)
AS

DECLARE @total int
SET @total = 0

SELECT
    @total = count(*)
FROM
    [dbo].[USUARIO]
WHERE
    [nombre_USUARIO] = @nombre_USUARIO and
	[password_usuario] = @password_usuario

IF @total IS NULL
BEGIN
    SET @total=0
END
SELECT @total AS Total



GO
/****** Object:  StoredProcedure [dbo].[cop_Usuario_LogonID]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[cop_Usuario_LogonID]
    @nombre_USUARIO  varchar  (50),
	@password_usuario varchar(50)
AS

DECLARE @total int
SET @total = 0

SELECT
    @total = id_usuario
FROM
    [dbo].[USUARIO]
WHERE
    [nombre_USUARIO] = @nombre_USUARIO and
	[password_usuario] = @password_usuario

IF @total IS NULL
BEGIN
    SET @total=0
END
SELECT @total AS Total




GO
/****** Object:  StoredProcedure [dbo].[cop_Usuario_PaswwordMaster]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[cop_Usuario_PaswwordMaster]
	@password_usuario varchar(50)
AS

DECLARE @total int
SET @total = 0

SELECT
    @total = count(*)
FROM
    [dbo].[USUARIO] INNER JOIN
	[dbo].[GRUPO_USUARIO] ON [dbo].[USUARIO].id_grupo_usuario = [dbo].[GRUPO_USUARIO].id_grupo_usuario
WHERE
	[password_usuario] = @password_usuario AND
	nombre_grupo_usuario = 'Administrador'

IF @total IS NULL
BEGIN
    SET @total=0
END
SELECT @total AS Total
GO
/****** Object:  StoredProcedure [dbo].[cop_Usuario_Update]    Script Date: 27/07/2023 20:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cop_Usuario_Update]
    @id_usuario    int  output,
    @nombre_USUARIO    varchar  (50),
	@password_usuario varchar(50),
	@id_grupo_usuario int,
	@mail varchar(50)
AS

UPDATE [dbo].[USUARIO] SET
    [nombre_USUARIO] = @nombre_USUARIO,
	[password_usuario] = @password_usuario,
	[id_grupo_usuario] = @id_grupo_usuario,
	[mail] = @mail
WHERE
    [id_usuario]  =  @id_usuario
GO
