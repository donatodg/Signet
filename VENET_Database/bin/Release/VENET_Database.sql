/*
Script de implementación para VENET_Database

Una herramienta generó este código.
Los cambios realizados en este archivo podrían generar un comportamiento incorrecto y se perderán si
se vuelve a generar el código.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "VENET_Database"
:setvar DefaultFilePrefix "VENET_Database"
:setvar DefaultDataPath "C:\Users\Diego\AppData\Local\Microsoft\VisualStudio\SSDT\VisualErsaNET"
:setvar DefaultLogPath "C:\Users\Diego\AppData\Local\Microsoft\VisualStudio\SSDT\VisualErsaNET"

GO
:on error exit
GO
/*
Detectar el modo SQLCMD y deshabilitar la ejecución del script si no se admite el modo SQLCMD.
Para volver a habilitar el script después de habilitar el modo SQLCMD, ejecute lo siguiente:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'El modo SQLCMD debe estar habilitado para ejecutar correctamente este script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Creando [dbo].[Feriado]...';


GO
CREATE TABLE [dbo].[Feriado] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Fecha]       SMALLDATETIME NOT NULL,
    [Descripcion] VARCHAR (100) NOT NULL,
    [FechaAdd]    DATETIME      NOT NULL,
    [FechaMod]    DATETIME      NULL,
    [FechaDel]    DATETIME      NULL,
    [UserAdd]     INT           NOT NULL,
    [UserMod]     INT           NULL,
    [UserDel]     INT           NULL,
    CONSTRAINT [PK_Feriados] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creando [dbo].[Localidad]...';


GO
CREATE TABLE [dbo].[Localidad] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Id_Provincia] INT           NOT NULL,
    [Localidad]    VARCHAR (100) NOT NULL,
    [CodPostal]    INT           NOT NULL,
    [FechaAdd]     DATETIME      NOT NULL,
    [FechaMod]     DATETIME      NULL,
    [FechaDel]     DATETIME      NULL,
    [UserAdd]      INT           NOT NULL,
    [UserMod]      INT           NULL,
    [UserDel]      INT           NULL,
    CONSTRAINT [PK_Localidades] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creando [dbo].[PersonalNovedades]...';


GO
CREATE TABLE [dbo].[PersonalNovedades] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [Fecha]          DATE           NOT NULL,
    [Id_Personal]    INT            NOT NULL,
    [Id_TipoNovedad] INT            NOT NULL,
    [Observaciones]  VARCHAR (8000) NULL,
    [FechaAdd]       DATETIME       NOT NULL,
    [FechaMod]       DATETIME       NULL,
    [FechaDel]       DATETIME       NULL,
    [UserAdd]        INT            NOT NULL,
    [UserMod]        INT            NULL,
    [UserDel]        INT            NULL,
    CONSTRAINT [PK_PersonalNovedades] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creando [dbo].[Planificacion]...';


GO
CREATE TABLE [dbo].[Planificacion] (
    [Id]                INT           IDENTITY (1, 1) NOT NULL,
    [Id_UnidadNegocio]  INT           NOT NULL,
    [Descripcion]       VARCHAR (100) NOT NULL,
    [FechaDesde]        DATE          NOT NULL,
    [FechaHasta]        DATE          NOT NULL,
    [FechaConfirmacion] DATETIME      NULL,
    [FechaAdd]          DATETIME      NOT NULL,
    [FechaMod]          DATETIME      NULL,
    [FechaDel]          DATETIME      NULL,
    [UserAdd]           INT           NOT NULL,
    [UserMod]           INT           NULL,
    [UserDel]           INT           NULL,
    CONSTRAINT [PK_Planificacion] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creando [dbo].[PlanificacionDetalles]...';


GO
CREATE TABLE [dbo].[PlanificacionDetalles] (
    [Id]               INT          IDENTITY (1, 1) NOT NULL,
    [Id_Planificacion] INT          NOT NULL,
    [Id_Personal]      INT          NOT NULL,
    [Id_Coche]         INT          NOT NULL,
    [Id_TipoServicio]  INT          NOT NULL,
    [Fecha]            DATE         NOT NULL,
    [Novedad]          VARCHAR (15) NULL,
    [Id_Servicio]      INT          NULL,
    [Id_Novedad]       INT          NULL,
    [FechaAdd]         DATETIME     NOT NULL,
    [FechaMod]         DATETIME     NULL,
    [FechaDel]         DATETIME     NULL,
    [UserAdd]          INT          NOT NULL,
    [UserMod]          INT          NULL,
    [UserDel]          INT          NULL,
    CONSTRAINT [PK_PlanificacionDetalles] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creando [dbo].[PlanificacionDetallesCoches]...';


GO
CREATE TABLE [dbo].[PlanificacionDetallesCoches] (
    [Id]               INT      IDENTITY (1, 1) NOT NULL,
    [Id_Planificacion] INT      NOT NULL,
    [Id_Coche]         INT      NOT NULL,
    [Fecha]            DATE     NOT NULL,
    [Id_TipoServicio]  INT      NOT NULL,
    [Id_Diagrama]      INT      NOT NULL,
    [Id_Servicio]      INT      NOT NULL,
    [FechaAdd]         DATETIME NOT NULL,
    [FechaMod]         DATETIME NULL,
    [FechaDel]         DATETIME NULL,
    [UserAdd]          INT      NOT NULL,
    [UserMod]          INT      NULL,
    [UserDel]          INT      NULL,
    CONSTRAINT [PK_PlanificacionDetallesCoches] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creando [dbo].[PlanificacionDetallesCochesConfirmado]...';


GO
CREATE TABLE [dbo].[PlanificacionDetallesCochesConfirmado] (
    [Id]               INT      NOT NULL,
    [Id_Planificacion] INT      NOT NULL,
    [Id_Coche]         INT      NOT NULL,
    [Fecha]            DATE     NOT NULL,
    [Id_TipoServicio]  INT      NOT NULL,
    [Id_Diagrama]      INT      NOT NULL,
    [Id_Servicio]      INT      NOT NULL,
    [FechaAdd]         DATETIME NOT NULL,
    [FechaMod]         DATETIME NULL,
    [FechaDel]         DATETIME NULL,
    [UserAdd]          INT      NOT NULL,
    [UserMod]          INT      NULL,
    [UserDel]          INT      NULL,
    CONSTRAINT [PK_PlanificacionDetallesCochesConfirmado] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creando [dbo].[PlanificacionDetallesConfirmado]...';


GO
CREATE TABLE [dbo].[PlanificacionDetallesConfirmado] (
    [Id]               INT          NOT NULL,
    [Id_Planificacion] INT          NOT NULL,
    [Id_Personal]      INT          NOT NULL,
    [Id_Coche]         INT          NOT NULL,
    [Id_TipoServicio]  INT          NOT NULL,
    [Fecha]            DATE         NOT NULL,
    [Novedad]          VARCHAR (15) NULL,
    [Id_Servicio]      INT          NULL,
    [Id_Novedad]       INT          NULL,
    [FechaAdd]         DATETIME     NOT NULL,
    [FechaMod]         DATETIME     NULL,
    [FechaDel]         DATETIME     NULL,
    [UserAdd]          INT          NOT NULL,
    [UserMod]          INT          NULL,
    [UserDel]          INT          NULL,
    CONSTRAINT [PK_PlanificacionDetallesConfirmado] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creando [dbo].[PlanificacionHistorial]...';


GO
CREATE TABLE [dbo].[PlanificacionHistorial] (
    [Id_Planificacion] INT NOT NULL,
    [Id_TipoServicio]  INT NOT NULL,
    [Tipo_Dia]         INT NOT NULL,
    [Id_Coche]         INT NOT NULL
);


GO
PRINT N'Creando [dbo].[PlanificacionServicios]...';


GO
CREATE TABLE [dbo].[PlanificacionServicios] (
    [Id]                INT      IDENTITY (1, 1) NOT NULL,
    [Id_Planificacion]  INT      NOT NULL,
    [Id_TipoServicio]   INT      NOT NULL,
    [Id_Diagrama]       INT      NOT NULL,
    [Fecha]             DATE     NOT NULL,
    [CantidadServicios] INT      NOT NULL,
    [FechaAdd]          DATETIME NOT NULL,
    [FechaMod]          DATETIME NULL,
    [FechaDel]          DATETIME NULL,
    [UserAdd]           INT      NOT NULL,
    [UserMod]           INT      NULL,
    [UserDel]           INT      NULL,
    CONSTRAINT [PK_Planificacion_Fechas_Diagrama] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creando [dbo].[ProvFinancieros]...';


GO
CREATE TABLE [dbo].[ProvFinancieros] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]   VARCHAR (100) NOT NULL,
    [FechaAdd] DATETIME      NOT NULL,
    [FechaMod] DATETIME      NULL,
    [FechaDel] DATETIME      NULL,
    [UserAdd]  INT           NOT NULL,
    [UserMod]  INT           NULL,
    [UserDel]  INT           NULL,
    CONSTRAINT [PK_ProvFinancieros] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creando [dbo].[SeguridadGrupos]...';


GO
CREATE TABLE [dbo].[SeguridadGrupos] (
    [Id]              INT          IDENTITY (1, 1) NOT NULL,
    [Descripcion]     VARCHAR (50) NOT NULL,
    [EsAdministrador] BIT          NOT NULL,
    [FechaAdd]        DATETIME     NOT NULL,
    [FechaMod]        DATETIME     NULL,
    [FechaDel]        DATETIME     NULL,
    [UserAdd]         INT          NOT NULL,
    [UserMod]         INT          NULL,
    [UserDel]         INT          NULL,
    CONSTRAINT [PK_Seguridad_Grupos] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creando [dbo].[SeguridadGruposObjetos]...';


GO
CREATE TABLE [dbo].[SeguridadGruposObjetos] (
    [Id]        INT      IDENTITY (1, 1) NOT NULL,
    [Id_Grupo]  INT      NOT NULL,
    [Id_Objeto] INT      NOT NULL,
    [FechaAdd]  DATETIME NOT NULL,
    [FechaMod]  DATETIME NULL,
    [FechaDel]  DATETIME NULL,
    [UserAdd]   INT      NOT NULL,
    [UserMod]   INT      NULL,
    [UserDel]   INT      NULL,
    CONSTRAINT [PK_Seguridad_Grupos_Objetos] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creando [dbo].[SeguridadObjetos]...';


GO
CREATE TABLE [dbo].[SeguridadObjetos] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Modulo]     INT           NOT NULL,
    [Formulario] VARCHAR (50)  NOT NULL,
    [Permiso]    VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Seguridad_Objetos] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creando [dbo].[SeguridadUsuarios]...';


GO
CREATE TABLE [dbo].[SeguridadUsuarios] (
    [Id]       INT              IDENTITY (1, 1) NOT NULL,
    [Id_Grupo] INT              NOT NULL,
    [Username] VARCHAR (50)     NOT NULL,
    [Apellido] VARCHAR (50)     NOT NULL,
    [Nombre]   VARCHAR (50)     NOT NULL,
    [Clave]    VARCHAR (50)     NOT NULL,
    [Activo]   BIT              NOT NULL,
    [Email]    VARCHAR (50)     NULL,
    [Foto]     VARBINARY (8000) NULL,
    [FechaAdd] DATETIME         NOT NULL,
    [FechaMod] DATETIME         NULL,
    [FechaDel] DATETIME         NULL,
    [UserAdd]  INT              NOT NULL,
    [UserMod]  INT              NULL,
    [UserDel]  INT              NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creando [dbo].[SeguridadUsuariosCajas]...';


GO
CREATE TABLE [dbo].[SeguridadUsuariosCajas] (
    [Id]         INT      IDENTITY (1, 1) NOT NULL,
    [Id_Usuario] INT      NOT NULL,
    [Id_Caja]    INT      NOT NULL,
    [FechaAdd]   DATETIME NOT NULL,
    [FechaMod]   DATETIME NULL,
    [FechaDel]   DATETIME NULL,
    [UserAdd]    INT      NOT NULL,
    [UserMod]    INT      NULL,
    [UserDel]    INT      NULL,
    CONSTRAINT [PK_SeguridadUsuariosCajas] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creando [dbo].[SeguridadUsuariosCentrosCostos]...';


GO
CREATE TABLE [dbo].[SeguridadUsuariosCentrosCostos] (
    [Id]             INT      IDENTITY (1, 1) NOT NULL,
    [Id_Usuario]     INT      NOT NULL,
    [Id_CentroCosto] INT      NOT NULL,
    [FechaAdd]       DATETIME NOT NULL,
    [FechaMod]       DATETIME NULL,
    [FechaDel]       DATETIME NULL,
    [UserAdd]        INT      NOT NULL,
    [UserMod]        INT      NULL,
    [UserDel]        INT      NULL,
    CONSTRAINT [PK_SeguridadUsuariosCentrosCostos] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creando [dbo].[SeguridadUsuariosEmpresas]...';


GO
CREATE TABLE [dbo].[SeguridadUsuariosEmpresas] (
    [Id]         INT      IDENTITY (1, 1) NOT NULL,
    [Id_Usuario] INT      NOT NULL,
    [Id_Empresa] INT      NOT NULL,
    [FechaAdd]   DATETIME NOT NULL,
    [FechaMod]   DATETIME NULL,
    [FechaDel]   DATETIME NULL,
    [UserAdd]    INT      NOT NULL,
    [UserMod]    INT      NULL,
    [UserDel]    INT      NULL,
    CONSTRAINT [PK_Seguridad_Usuarios_Empresas] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creando [dbo].[SeguridadUsuariosPuntosVentas]...';


GO
CREATE TABLE [dbo].[SeguridadUsuariosPuntosVentas] (
    [Id]            INT      IDENTITY (1, 1) NOT NULL,
    [Id_Usuario]    INT      NOT NULL,
    [Id_PuntoVenta] INT      NOT NULL,
    [FechaAdd]      DATETIME NOT NULL,
    [FechaMod]      DATETIME NULL,
    [FechaDel]      DATETIME NULL,
    [UserAdd]       INT      NOT NULL,
    [UserMod]       INT      NULL,
    [UserDel]       INT      NULL,
    CONSTRAINT [PK_SeguridadUsuariosPuntosVentas] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creando [dbo].[SeguridadUsuariosSucursales]...';


GO
CREATE TABLE [dbo].[SeguridadUsuariosSucursales] (
    [Id]          INT      IDENTITY (1, 1) NOT NULL,
    [Id_Usuario]  INT      NOT NULL,
    [Id_Sucursal] INT      NOT NULL,
    [FechaAdd]    DATETIME NOT NULL,
    [FechaMod]    DATETIME NULL,
    [FechaDel]    DATETIME NULL,
    [UserAdd]     INT      NOT NULL,
    [UserMod]     INT      NULL,
    [UserDel]     INT      NULL,
    CONSTRAINT [PK_SeguridadUsuariosSucursales] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creando [dbo].[SeguridadUsuariosUnidadNegocios]...';


GO
CREATE TABLE [dbo].[SeguridadUsuariosUnidadNegocios] (
    [Id]               INT      IDENTITY (1, 1) NOT NULL,
    [Id_Usuario]       INT      NOT NULL,
    [Id_UnidadNegocio] INT      NOT NULL,
    [FechaAdd]         DATETIME NOT NULL,
    [FechaMod]         DATETIME NULL,
    [FechaDel]         DATETIME NULL,
    [UserAdd]          INT      NOT NULL,
    [UserMod]          INT      NULL,
    [UserDel]          INT      NULL,
    CONSTRAINT [PK_SeguridadUsuariosUnidadNegocios] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creando [dbo].[SistemaLog]...';


GO
CREATE TABLE [dbo].[SistemaLog] (
    [Id]         INT          IDENTITY (1, 1) NOT NULL,
    [Id_Usuario] INT          NOT NULL,
    [Accion]     INT          NOT NULL,
    [Fecha]      DATETIME     NOT NULL,
    [Host]       VARCHAR (50) NOT NULL,
    [UserLocal]  VARCHAR (50) NOT NULL,
    [IPLocal]    VARCHAR (50) NOT NULL,
    [IPPublica]  VARCHAR (50) NOT NULL,
    [BaseDatos]  VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_SistemaLog] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creando [dbo].[TalonariosComprobantes]...';


GO
CREATE TABLE [dbo].[TalonariosComprobantes] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [Id_Empresa]     INT           NOT NULL,
    [Id_Comprobante] INT           NOT NULL,
    [Letra]          VARCHAR (1)   NOT NULL,
    [Id_PuntoVenta]  INT           NOT NULL,
    [Electronico]    BIT           NOT NULL,
    [Impresora]      VARCHAR (100) NULL,
    [Copias]         INT           NULL,
    [FechaAdd]       DATETIME      NOT NULL,
    [FechaMod]       DATETIME      NULL,
    [FechaDel]       DATETIME      NULL,
    [UserAdd]        INT           NOT NULL,
    [UserMod]        INT           NULL,
    [UserDel]        INT           NULL,
    CONSTRAINT [PK_TalonariosComprobantes] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creando [dbo].[TalonariosComprobantesDetalle]...';


GO
CREATE TABLE [dbo].[TalonariosComprobantesDetalle] (
    [Id]                      INT           IDENTITY (1, 1) NOT NULL,
    [Id_TalonarioComprobante] INT           NOT NULL,
    [NroDesde]                INT           NOT NULL,
    [NroHasta]                INT           NOT NULL,
    [NroActual]               INT           NOT NULL,
    [FechaVencimiento]        SMALLDATETIME NOT NULL,
    [FechaAdd]                DATETIME      NOT NULL,
    [FechaMod]                DATETIME      NULL,
    [FechaDel]                DATETIME      NULL,
    [UserAdd]                 INT           NOT NULL,
    [UserMod]                 INT           NULL,
    [UserDel]                 INT           NULL,
    CONSTRAINT [PK_TalonariosComprobantesDetalle] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creando [dbo].[TipoComprobante]...';


GO
CREATE TABLE [dbo].[TipoComprobante] (
    [Id]               INT          IDENTITY (1, 1) NOT NULL,
    [Descripcion]      VARCHAR (50) NOT NULL,
    [DescripcionCorta] VARCHAR (4)  NULL,
    [InternoSistema]   BIT          NOT NULL,
    [FechaAdd]         DATETIME     NOT NULL,
    [FechaMod]         DATETIME     NULL,
    [FechaDel]         DATETIME     NULL,
    [UserAdd]          INT          NOT NULL,
    [UserMod]          INT          NULL,
    [UserDel]          INT          NULL,
    CONSTRAINT [PK_TipoMovimiento] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creando [dbo].[TipoNovedades]...';


GO
CREATE TABLE [dbo].[TipoNovedades] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [Descripcion]      VARCHAR (5)   NOT NULL,
    [DescripcionLarga] VARCHAR (100) NOT NULL,
    [RRHH]             BIT           NOT NULL,
    [ALaOrden]         BIT           NOT NULL,
    [FechaAdd]         DATETIME      NOT NULL,
    [FechaMod]         DATETIME      NULL,
    [FechaDel]         DATETIME      NULL,
    [UserAdd]          INT           NOT NULL,
    [UserMod]          INT           NULL,
    [UserDel]          INT           NULL,
    CONSTRAINT [PK_TipoNovedades] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creando [dbo].[UnidadNegocios]...';


GO
CREATE TABLE [dbo].[UnidadNegocios] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Descripcion] VARCHAR (100) NOT NULL,
    [FechaAdd]    DATETIME      NOT NULL,
    [FechaMod]    DATETIME      NULL,
    [FechaDel]    DATETIME      NULL,
    [UserAdd]     INT           NOT NULL,
    [UserMod]     INT           NULL,
    [UserDel]     INT           NULL,
    CONSTRAINT [PK_UnidadNegocios] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creando [dbo].[UnidadNegocios_Configuracion]...';


GO
CREATE TABLE [dbo].[UnidadNegocios_Configuracion] (
    [Id_UnidadNegocio] INT NOT NULL,
    [RotaHabil]        INT NOT NULL,
    [RotaSabado]       INT NOT NULL,
    [RotaFeriado]      INT NOT NULL,
    CONSTRAINT [PK_UnidadNegocios_Configuracion] PRIMARY KEY CLUSTERED ([Id_UnidadNegocio] ASC)
);


GO
PRINT N'Creando [dbo].[Vertical]...';


GO
CREATE TABLE [dbo].[Vertical] (
    [ordering] INT IDENTITY (1, 1) NOT NULL,
    [Value]    INT NOT NULL
);


GO
PRINT N'Creando [dbo].[DF_PersonalNovedades_Observaciones]...';


GO
ALTER TABLE [dbo].[PersonalNovedades]
    ADD CONSTRAINT [DF_PersonalNovedades_Observaciones] DEFAULT ('') FOR [Observaciones];


GO
PRINT N'Creando [dbo].[DF_TipoComprobante_InternoSistema]...';


GO
ALTER TABLE [dbo].[TipoComprobante]
    ADD CONSTRAINT [DF_TipoComprobante_InternoSistema] DEFAULT ((0)) FOR [InternoSistema];


GO
PRINT N'Creando [dbo].[DF_TipoNovedades_RRHH]...';


GO
ALTER TABLE [dbo].[TipoNovedades]
    ADD CONSTRAINT [DF_TipoNovedades_RRHH] DEFAULT ((0)) FOR [RRHH];


GO
PRINT N'Creando [dbo].[DF_TipoNovedades_ALaOrden]...';


GO
ALTER TABLE [dbo].[TipoNovedades]
    ADD CONSTRAINT [DF_TipoNovedades_ALaOrden] DEFAULT ((0)) FOR [ALaOrden];


GO
PRINT N'Creando [dbo].[FK_Seguridad_Grupos_Objetos_Seguridad_Grupos]...';


GO
ALTER TABLE [dbo].[SeguridadGruposObjetos] WITH NOCHECK
    ADD CONSTRAINT [FK_Seguridad_Grupos_Objetos_Seguridad_Grupos] FOREIGN KEY ([Id_Grupo]) REFERENCES [dbo].[SeguridadGrupos] ([Id]);


GO
PRINT N'Creando [dbo].[FK_SeguridadGruposObjetos_SeguridadObjetos]...';


GO
ALTER TABLE [dbo].[SeguridadGruposObjetos] WITH NOCHECK
    ADD CONSTRAINT [FK_SeguridadGruposObjetos_SeguridadObjetos] FOREIGN KEY ([Id_Objeto]) REFERENCES [dbo].[SeguridadObjetos] ([Id]);


GO
PRINT N'Creando [dbo].[FK_Seguridad_Usuarios_Seguridad_Grupos]...';


GO
ALTER TABLE [dbo].[SeguridadUsuarios] WITH NOCHECK
    ADD CONSTRAINT [FK_Seguridad_Usuarios_Seguridad_Grupos] FOREIGN KEY ([Id_Grupo]) REFERENCES [dbo].[SeguridadGrupos] ([Id]);


GO
PRINT N'Creando [dbo].[FK_SeguridadUsuariosCentrosCostos_SeguridadUsuarios]...';


GO
ALTER TABLE [dbo].[SeguridadUsuariosCentrosCostos] WITH NOCHECK
    ADD CONSTRAINT [FK_SeguridadUsuariosCentrosCostos_SeguridadUsuarios] FOREIGN KEY ([Id_Usuario]) REFERENCES [dbo].[SeguridadUsuarios] ([Id]);


GO
PRINT N'Creando [dbo].[FK_Seguridad_Usuarios_Empresas_Seguridad_Usuarios]...';


GO
ALTER TABLE [dbo].[SeguridadUsuariosEmpresas] WITH NOCHECK
    ADD CONSTRAINT [FK_Seguridad_Usuarios_Empresas_Seguridad_Usuarios] FOREIGN KEY ([Id_Usuario]) REFERENCES [dbo].[SeguridadUsuarios] ([Id]);


GO
PRINT N'Creando [dbo].[FK_TalonariosComprobantes_Empresas]...';


GO
ALTER TABLE [dbo].[TalonariosComprobantes] WITH NOCHECK
    ADD CONSTRAINT [FK_TalonariosComprobantes_Empresas] FOREIGN KEY ([Id_Empresa]) REFERENCES [dbo].[Empresas] ([Id]);


GO
PRINT N'Creando [dbo].[FK_TalonariosComprobantes_TipoComprobante]...';


GO
ALTER TABLE [dbo].[TalonariosComprobantes] WITH NOCHECK
    ADD CONSTRAINT [FK_TalonariosComprobantes_TipoComprobante] FOREIGN KEY ([Id_Comprobante]) REFERENCES [dbo].[TipoComprobante] ([Id]);


GO
PRINT N'Creando [dbo].[FK_TalonariosComprobantesDetalle_TalonariosComprobantes]...';


GO
ALTER TABLE [dbo].[TalonariosComprobantesDetalle] WITH NOCHECK
    ADD CONSTRAINT [FK_TalonariosComprobantesDetalle_TalonariosComprobantes] FOREIGN KEY ([Id_TalonarioComprobante]) REFERENCES [dbo].[TalonariosComprobantes] ([Id]);


GO
PRINT N'Creando [dbo].[FK_Cajas_Especies]...';


GO
ALTER TABLE [dbo].[Cajas] WITH NOCHECK
    ADD CONSTRAINT [FK_Cajas_Especies] FOREIGN KEY ([Id_Especie]) REFERENCES [dbo].[Especies] ([Id]);


GO
PRINT N'Creando [dbo].[FK_Cajas_Sucursales]...';


GO
ALTER TABLE [dbo].[Cajas] WITH NOCHECK
    ADD CONSTRAINT [FK_Cajas_Sucursales] FOREIGN KEY ([Id_Sucursal]) REFERENCES [dbo].[Sucursales] ([Id]);


GO
PRINT N'Creando [dbo].[FK_Cuadros_Servicios]...';


GO
ALTER TABLE [dbo].[Cuadros] WITH NOCHECK
    ADD CONSTRAINT [FK_Cuadros_Servicios] FOREIGN KEY ([Id_TipoServicio]) REFERENCES [dbo].[TipoServicios] ([Id]);


GO
PRINT N'Creando [dbo].[FK_Diagramas_TipoServicios]...';


GO
ALTER TABLE [dbo].[Diagramas] WITH NOCHECK
    ADD CONSTRAINT [FK_Diagramas_TipoServicios] FOREIGN KEY ([Id_TipoServicio]) REFERENCES [dbo].[TipoServicios] ([Id]);


GO
PRINT N'Creando [dbo].[FK_Diagrama_Detalle_Diagramas]...';


GO
ALTER TABLE [dbo].[Diagramas_Detalle] WITH NOCHECK
    ADD CONSTRAINT [FK_Diagrama_Detalle_Diagramas] FOREIGN KEY ([Id_Diagrama]) REFERENCES [dbo].[Diagramas] ([Id]);


GO
PRINT N'Creando [dbo].[FK_Diagrama_Detalle_Secciones]...';


GO
ALTER TABLE [dbo].[Diagramas_Detalle] WITH NOCHECK
    ADD CONSTRAINT [FK_Diagrama_Detalle_Secciones] FOREIGN KEY ([Id_Seccion]) REFERENCES [dbo].[Secciones] ([Id]);


GO
PRINT N'Creando [dbo].[FK_Diagrama_Fecha_Diagramas]...';


GO
ALTER TABLE [dbo].[Diagramas_Fecha] WITH NOCHECK
    ADD CONSTRAINT [FK_Diagrama_Fecha_Diagramas] FOREIGN KEY ([Id_Diagrama]) REFERENCES [dbo].[Diagramas] ([Id]);


GO
PRINT N'Creando [dbo].[FK_Lineas_Empresas]...';


GO
ALTER TABLE [dbo].[Lineas] WITH NOCHECK
    ADD CONSTRAINT [FK_Lineas_Empresas] FOREIGN KEY ([Id_Empresa]) REFERENCES [dbo].[Empresas] ([Id]);


GO
PRINT N'Creando [dbo].[FK_Personal_Empresas]...';


GO
ALTER TABLE [dbo].[Personal] WITH NOCHECK
    ADD CONSTRAINT [FK_Personal_Empresas] FOREIGN KEY ([Id_Empresa]) REFERENCES [dbo].[Empresas] ([Id]);


GO
PRINT N'Creando [dbo].[FK_Ramales_Lineas]...';


GO
ALTER TABLE [dbo].[Ramales] WITH NOCHECK
    ADD CONSTRAINT [FK_Ramales_Lineas] FOREIGN KEY ([Id_Linea]) REFERENCES [dbo].[Lineas] ([Id]);


GO
PRINT N'Creando [dbo].[FK_Secciones_TipoServicios]...';


GO
ALTER TABLE [dbo].[Secciones] WITH NOCHECK
    ADD CONSTRAINT [FK_Secciones_TipoServicios] FOREIGN KEY ([Id_TipoServicio]) REFERENCES [dbo].[TipoServicios] ([Id]);


GO
PRINT N'Creando [dbo].[FK_Servicios_Ramales]...';


GO
ALTER TABLE [dbo].[TipoServicios] WITH NOCHECK
    ADD CONSTRAINT [FK_Servicios_Ramales] FOREIGN KEY ([Id_Ramal]) REFERENCES [dbo].[Ramales] ([Id]);


GO
PRINT N'Creando [dbo].[EGWR_DiagramasDiario]...';


GO
CREATE VIEW dbo.EGWR_DiagramasDiario
AS
SELECT     df.Fecha, CASE WHEN df.Id_Personal = 0 THEN '' ELSE df.Id_Personal END AS Legajo, CASE WHEN P.Apellido IS NULL THEN '' ELSE RTRIM(LTRIM(p.Apellido)) + ', ' + RTRIM(LTRIM(p.Nombre)) 
                      END AS Nombre, df.Id_Coche AS Interno, df.NroServicio, df.Turno, CONVERT(VARCHAR(5), ds.HoraCitacion, 114) AS Citacion, CONVERT(VARCHAR(5), ds.HoraFinalizacion, 114) AS Finalizacion, 
                      e.Descripcion AS Empresa, l.Descripcion AS Linea, r.Descripcion AS Ramal, ts.Descripcion AS Servicio, l.Provincia
FROM         dbo.Diagramas_Fecha AS df INNER JOIN
                      dbo.Diagramas AS d ON df.Id_Diagrama = d.Id INNER JOIN
                      dbo.Diagramas_Servicios AS ds ON d.Id = ds.Id_Diagrama AND df.NroServicio = ds.NroServicio AND df.Turno = ds.Turno INNER JOIN
                      dbo.TipoServicios AS ts ON d.Id_TipoServicio = ts.Id INNER JOIN
                      dbo.Ramales AS r ON ts.Id_Ramal = r.Id INNER JOIN
                      dbo.Lineas AS l ON r.Id_Linea = l.Id INNER JOIN
                      dbo.Empresas AS e ON l.Id_Empresa = e.Id LEFT OUTER JOIN
                      dbo.Personal AS p ON df.Id_Personal = p.LaboralLegajo
GO
PRINT N'Modificando [dbo].[dba_Inicializacion]...';


GO
ALTER PROCEDURE [dbo].[dba_Inicializacion] 
	 
AS
BEGIN
	Delete CentrosCostos
	Delete Clientes
	Delete Cuentas
	Delete Especies
	Delete EspeciesCtaCte
	Delete Proveedores
	Delete Recibos_Detalle
	Delete Recibos
	Delete Rendiciones
	Delete Rendiciones_Detalle
	Delete Tarifas
	Delete Turnos
	Delete Vales
	Delete dbo.Coches
	Delete dbo.Coches_Publicidad
	Delete dbo.Tarifas
	Delete dbo.Cuadros
	Delete dbo.Diagramas_Servicios
	Delete dbo.Diagramas_Fecha
	Delete dbo.Diagramas_Detalle
	Delete dbo.Diagramas
	Delete dbo.EstadosCiviles
	delete dbo.Feriados
	Delete dbo.Secciones
	Delete dbo.TipoServicios
	Delete dbo.Ramales
	Delete dbo.Lineas
	Delete dbo.Sucursales
	Delete dbo.Parametros
	Delete dbo.Provincia
	Delete dbo.PuntosdePaso
	Delete dbo.PuntosVenta
	Delete dbo.TipoComprobante
	Delete dbo.TipoDia
	Delete dbo.TipoDoc
	Delete dbo.PersonalTipos
	Delete dbo.PersonalJerarquias
	Delete dbo.Personal 
	Delete dbo.Empresas
	Delete dbo.Seguridad_Grupos_Objetos
	Delete dbo.Seguridad_Grupos
	Delete dbo.Seguridad_Objetos
	Delete dbo.Seguridad_Usuarios_Empresas
	Delete dbo.Seguridad_Usuarios
	Delete dbo.usuarios
	 	
	DBCC CHECKIDENT (CentrosCostos, RESEED,0)
	DBCC CHECKIDENT (Clientes, RESEED,0)
	DBCC CHECKIDENT (Coches, RESEED,0)
	DBCC CHECKIDENT (Coches_Publicidad, RESEED,0)
	DBCC CHECKIDENT (Cuadros, RESEED,0)
	DBCC CHECKIDENT (Cuentas, RESEED,0)
	DBCC CHECKIDENT (Diagramas, RESEED,0)
	DBCC CHECKIDENT (Diagramas_Detalle, RESEED,0)
	DBCC CHECKIDENT (Diagramas_Fecha, RESEED,0)
	DBCC CHECKIDENT (Diagramas_Servicios, RESEED,0)
	DBCC CHECKIDENT (Empresas, RESEED,0)
	DBCC CHECKIDENT (Especies, RESEED,0)
	DBCC CHECKIDENT (EspeciesCtaCte, RESEED,0)
	DBCC CHECKIDENT (EstadosCiviles, RESEED,0)
	DBCC CHECKIDENT (Feriados, RESEED,0)
	DBCC CHECKIDENT (Lineas, RESEED,0)
	--DBCC CHECKIDENT (Parametros, RESEED,0)
	DBCC CHECKIDENT (Personal, RESEED,0)
	DBCC CHECKIDENT (PersonalJerarquias, RESEED,0)
	DBCC CHECKIDENT (PersonalTipos, RESEED,0)
	DBCC CHECKIDENT (Proveedores, RESEED,0)
	DBCC CHECKIDENT (Provincia, RESEED,0)
	DBCC CHECKIDENT (PuntosdePaso, RESEED,0)
	DBCC CHECKIDENT (PuntosVenta, RESEED,0)
	DBCC CHECKIDENT (Ramales, RESEED,0)
	DBCC CHECKIDENT (Recibos, RESEED,0)
	DBCC CHECKIDENT (Recibos_Detalle, RESEED,0)
	DBCC CHECKIDENT (Rendiciones, RESEED,0)
	DBCC CHECKIDENT (Rendiciones_Detalle, RESEED,0)
	DBCC CHECKIDENT (Secciones, RESEED,0)
	DBCC CHECKIDENT (Seguridad_Grupos, RESEED,0)
	DBCC CHECKIDENT (Seguridad_Grupos_Objetos, RESEED,0)
	DBCC CHECKIDENT (Seguridad_Objetos, RESEED,0)
	DBCC CHECKIDENT (Seguridad_Usuarios, RESEED,0)
	DBCC CHECKIDENT (Seguridad_Usuarios_Empresas, RESEED,0)
	DBCC CHECKIDENT (Sucursales, RESEED,0)
	DBCC CHECKIDENT (Tarifas, RESEED,0)
	DBCC CHECKIDENT (TipoDia, RESEED,0)
	DBCC CHECKIDENT (TipoDoc, RESEED,0)
	DBCC CHECKIDENT (TipoComprobante, RESEED,0)
	DBCC CHECKIDENT (TipoServicios, RESEED,0)
	DBCC CHECKIDENT (Turnos, RESEED,0)
	--DBCC CHECKIDENT (usuarios, RESEED,0)
	DBCC CHECKIDENT (Vales, RESEED,0)
	
 
	Insert Into CentrosCostos (Descripcion, FechaAdd, UserAdd) Values ('Default', GETDATE(), 0)
 
	Insert Into Cuentas (Descripcion, FechaAdd, UserAdd) Values ('Viaticos', GETDATE(), 0)
	Insert Into Cuentas (Descripcion, FechaAdd, UserAdd) Values ('Peajes', GETDATE(), 0)
	Insert Into Cuentas (Descripcion, FechaAdd, UserAdd) Values ('Combustibles', GETDATE(), 0)
	
	Insert Into EstadosCiviles (Descripcion) Values ('Soltero')
	Insert Into EstadosCiviles (Descripcion) Values ('Casado')
	Insert Into EstadosCiviles (Descripcion) Values ('Separado')
	Insert Into EstadosCiviles (Descripcion) Values ('Viudo')
	Insert Into EstadosCiviles (Descripcion) Values ('Concubinato')
	
	Insert Into Empresas (Descripcion, Cuit, FechaAdd, UserAdd) Values ('ERSA URBANO S.A.','30-70778883-2', GETDATE(), 0)
    Insert Into Empresas (Descripcion, Cuit, FechaAdd, UserAdd) Values ('EMPRESA DE TRANSPORTES FLUVIALES DEL LITORAL S.A.','30-54660726-3', GETDATE(), 0)
    Insert Into Empresas (Descripcion, Cuit, FechaAdd, UserAdd) Values ('C.O. SOCIEDAD ANONIMA','30-70883486-2', GETDATE(), 0)
    Insert Into Empresas (Descripcion, Cuit, FechaAdd, UserAdd) Values ('EL TIGRE S.A.T.I.C.A.F','33-56197051-9', GETDATE(), 0)
    Insert Into Empresas (Descripcion, Cuit, FechaAdd, UserAdd) Values ('MATYSUD S.A.','33-70814131-9', GETDATE(), 0)
    Insert Into Empresas (Descripcion, Cuit, FechaAdd, UserAdd) Values ('TRANSPORTE SAN LORENZO SA','30-70843643-3', GETDATE(), 0)
    Insert Into Empresas (Descripcion, Cuit, FechaAdd, UserAdd) Values ('TRANSPORTE MARIANO MORENO S.R.L.','33-54637496-9', GETDATE(), 0)
    Insert Into Empresas (Descripcion, Cuit, FechaAdd, UserAdd) Values ('ERSA CHACO S.A.','30-71004921-8', GETDATE(), 0)
    Insert Into Empresas (Descripcion, Cuit, FechaAdd, UserAdd) Values ('MICROOMNIBUS SAAVEDRA SATACI','30-54634060-7', GETDATE(), 0)

    Insert Into Especies (Descripcion, Sigla, Cotizacion, FechaAdd, UserAdd) Values ('Pesos','Pes', '1', GETDATE(), 0)

	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'L120','L120','SANTIAGO DEL ESTERO','PROV', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'L110','L110','SANTIAGO DEL ESTERO','SANTIAGO DEL ESTERO CAPITAL', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'L112A','L112A','SANTIAGO DEL ESTERO','SANTIAGO DEL ESTERO CAPITAL', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'L114A','L114A','SANTIAGO DEL ESTERO','SANTIAGO DEL ESTERO CAPITAL', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'L114B','L114B','SANTIAGO DEL ESTERO','SANTIAGO DEL ESTERO CAPITAL', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'L116A','L116A','SANTIAGO DEL ESTERO','SANTIAGO DEL ESTERO CAPITAL', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'L116B','L116B','SANTIAGO DEL ESTERO','SANTIAGO DEL ESTERO CAPITAL', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'L116C','L116C','SANTIAGO DEL ESTERO','SANTIAGO DEL ESTERO CAPITAL', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'L119','L119','SANTIAGO DEL ESTERO','SANTIAGO DEL ESTERO CAPITAL', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'L120','L120','SANTIAGO DEL ESTERO','SANTIAGO DEL ESTERO CAPITAL', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'L1','L1','SANTA FE','SANTA FE', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'L15','L15','SANTA FE','SANTA FE', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'L3','L3','SANTA FE','SANTA FE', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'L9','L9','SANTA FE','SANTA FE', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (2,'906','906','JN','JN', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (3,'108AB','108AB','CORRIENTES','CORRIENTES', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (3,'L108C','L108C','CORRIENTES','CORRIENTES', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (4,'L103A','L103A','CORRIENTES','CORRIENTES', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (4,'L103B','L103B','CORRIENTES','CORRIENTES', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'L102A','L102A','CORRIENTES','CORRIENTES', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'L102B','L102B','CORRIENTES','CORRIENTES', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'L102C','L102C','CORRIENTES','CORRIENTES', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'L106A','L106A','CORRIENTES','CORRIENTES', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'L106B','L106B','CORRIENTES','CORRIENTES', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'LCTCP','LCTCP','CORRIENTES','PROV', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'LCTR1','LCTR1','CORRIENTES','PROV', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'LCZMC','LCZMC','CORRIENTES','PROV', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (5,'L104A','L104A','CORRIENTES','CORRIENTES', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (5,'L104B','L104B','CORRIENTES','CORRIENTES', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (5,'L104C','L104C','CORRIENTES','CORRIENTES', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (5,'L104D','L104D','CORRIENTES','CORRIENTES', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (6,'L105A','L105A','CORRIENTES','CORRIENTES', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (6,'L105B','L105B','CORRIENTES','CORRIENTES', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (6,'L105C','L105C','CORRIENTES','CORRIENTES', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (6,'L109','L109','CORRIENTES','CORRIENTES', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (2,'PNAMG','PNAMG','ENTRE RIOS','PROV', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (2,'PNATB','PNATB','ENTRE RIOS','PROV', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (2,'PNAVL','PNAVL','ENTRE RIOS','PROV', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'1','1','ENTRE RIOS','PARANA', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'10','10','ENTRE RIOS','PARANA', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'1121','1121','ENTRE RIOS','PARANA', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'15','15','ENTRE RIOS','PARANA', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'22','22','ENTRE RIOS','PARANA', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'5','5','ENTRE RIOS','PARANA', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'6','6','ENTRE RIOS','PARANA', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (7,'12','12','ENTRE RIOS','PARANA', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (7,'14','14','ENTRE RIOS','PARANA', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (7,'2','2','ENTRE RIOS','PARANA', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (7,'20','20','ENTRE RIOS','PARANA', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (7,'3','3','ENTRE RIOS','PARANA', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (7,'4','4','ENTRE RIOS','PARANA', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (7,'7','7','ENTRE RIOS','PARANA', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (7,'8','8','ENTRE RIOS','PARANA', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (7,'9','9','ENTRE RIOS','PARANA', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (8,'L101','L101','CHACO','PROV', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (8,'L106A','L106A','CHACO','PROV', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (8,'L106B','L106B','CHACO','PROV', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (8,'L106C','L106C','CHACO','PROV', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (1,'L104','L104','CHACO','PROV', GETDATE(), 0)
	Insert Into Lineas (Id_Empresa, Descripcion, DescripcionCorta, Provincia, Municipio, FechaAdd, UserAdd) Values (9,'19','19','JN','JN', GETDATE(), 0)

	Insert Into TipoDia (Descripcion, FechaAdd, UserAdd) Values ('Habil', GETDATE(), 0)
	Insert Into TipoDia (Descripcion, FechaAdd, UserAdd) Values ('Sabado', GETDATE(), 0)
	Insert Into TipoDia (Descripcion, FechaAdd, UserAdd) Values ('Domingo', GETDATE(), 0)
	Insert Into TipoDia (Descripcion, FechaAdd, UserAdd) Values ('Feriados', GETDATE(), 0)
	
	Insert Into PersonalTipos (Descripcion, FechaAdd, UserAdd) Values ('Interno', GETDATE(), 0)
	Insert Into PersonalTipos (Descripcion, FechaAdd, UserAdd) Values ('Contratado', GETDATE(), 0)

	Insert Into PersonalJerarquias (Descripcion, FechaAdd, UserAdd) Values ('Conductor', GETDATE(), 0)

	Insert Into Provincia (Descripcion, Abreviatura) Values ('Buenos Aires','BA')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('Catamarca','CT')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('Chaco','CC')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('Chubut','CH')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('Córdoba','CD')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('Corrientes','CR')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('Entre Ríos','BA')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('Formosa','FO')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('Jujuy','JY')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('La Pampa','LP')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('La Rioja','LR')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('Mendoza','MZ')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('Misiones','MN')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('Neuquén','NQN')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('Río Negro','RN')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('Salta','SA')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('San Juan','SJ')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('San Luis','SL')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('Santa Cruz','SC')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('Santa Fe','SF')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('Santiago del Estero','SE')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('Tierra del Fuego, Antártida e Islas del Atlántico Sur','TF')
	Insert Into Provincia (Descripcion, Abreviatura) Values ('Tucumán','TM')
	
	Insert Into Sucursales (Descripcion, Id_Empresa, FechaAdd, UserAdd) Values ('Default', 1, GETDATE(), 0)
	
	Insert Into TipoDoc (Descripcion) Values ('DNI')
	Insert Into TipoDoc (Descripcion) Values ('CI')
	Insert Into TipoDoc (Descripcion) Values ('LE')
	Insert Into TipoDoc (Descripcion) Values ('LC')
	Insert Into TipoDoc (Descripcion) Values ('PAS')
	
	Insert Into TipoComprobante (Descripcion) Values ('Default')
	Insert Into TipoComprobante (Descripcion) Values ('Recibos')
	Insert Into TipoComprobante (Descripcion) Values ('Vales')
	Insert Into TipoComprobante (Descripcion) Values ('Rendiciones')
	
	Insert Into usuarios Values (1,'Admin','1234Ersa',1,0)
	Insert Into usuarios Values (2,'3','3',1,0)
	
END
GO
PRINT N'Modificando [dbo].[DiagramasPorFechas]...';


GO
ALTER PROCEDURE [dbo].[DiagramasPorFechas] 
	@Id_TipoServicio INT,
	@FechaDesde DATETIME,
	@FechaHasta DATETIME
AS
BEGIN
	 
SELECT DISTINCT(df.Fecha),
	   Dia = DATENAME(dw, df.Fecha),
	   df.Id_Diagrama, 
	   Diagrama = Min(d.Descripcion),
	   Tipo_Dia = MIN(t.Descripcion)   
	FROM Diagramas_Fecha df
	 	INNER JOIN Diagramas d on d.Id = df.Id_Diagrama
		INNER JOIN TipoDia t on d.Id_TipoDia = t.Id
			WHERE d.Id_TipoServicio = @Id_TipoServicio
				  AND df.Fecha BETWEEN @FechaDesde AND @FechaHasta
				  AND df.UserDel IS NULL
	GROUP BY df.Fecha, df.Id_Diagrama
	ORDER BY df.Fecha
END
GO
PRINT N'Modificando [dbo].[PlanillaViaje]...';


GO
ALTER PROCEDURE [dbo].[PlanillaViaje]
			@Id_Diagrama INT,
			@Fecha DATETIME,
			@NroServicio INT,
			@Turno INT,
			@IdaVuelta VARCHAR(1)

AS
BEGIN

	DECLARE @Columnas NVARCHAR(MAX) = ''
	DECLARE @SQLString NVARCHAR(MAX) = ''

	SELECT @Columnas =  COALESCE(@Columnas + '[' + CAST(DescripcionCorta as VARCHAR(20)) + '],', '')
		FROM (SELECT DescripcionCorta, Numero FROM Secciones WHERE UserDel IS NULL And Id_TipoServicio = (SELECT Id_TipoServicio FROM Diagramas WHERE Id = @Id_Diagrama and UserDel Is NULL) AND IdaVuelta = @IdaVuelta) AS DSC
	ORDER BY Numero

	SET @Columnas = LEFT(@Columnas,LEN(@Columnas)-1)
	
	IF (SELECT ts.BoletoEnPlanilla 
		FROM Diagramas d INNER JOIN TipoServicios ts on d.Id_TipoServicio = ts.Id 
		WHERE d.Id = @Id_Diagrama) = 0
	BEGIN	 
		SET @SQLString = N'
			SELECT *
				FROM
				(SELECT dd.NroVuelta, s.DescripcionCorta, Hora = (CASE WHEN Hora = ''2001-01-01 00:00'' THEN '' '' ELSE CONVERT(VARCHAR,RIGHT(''00'' + CONVERT(VARCHAR(2),DATEPART(HOUR,dd.Hora)), 2)+ '':'' + RIGHT(''00'' + CONVERT(VARCHAR(2),DATEPART(MINUTE,dd.Hora)), 2)) END)
					FROM Diagramas d
						INNER JOIN Diagramas_Detalle dd ON d.Id = dd.Id_Diagrama
						INNER JOIN Diagramas_Fecha df ON d.Id = df.Id_Diagrama 
						INNER JOIN Secciones s ON dd.Id_Seccion = s.Id
							WHERE
								d.Id = ' + CONVERT(VARCHAR,@Id_Diagrama) + '
								AND df.Fecha = ''' + RTRIM(CONVERT(CHAR,@Fecha,103))  + '''
								AND s.IdaVuelta = '''  + @IdaVuelta  + '''
								AND dd.NroServicio = ' + CONVERT(VARCHAR,@NroServicio) + '
								AND dd.Turno = ' + CONVERT(VARCHAR,@Turno) + '
								AND s.UserDel IS NUll
								AND dd.UserDel IS NUll
								AND df.UserDel IS NUll
				 ) AS SourceTable
				PIVOT
				(
					MIN(Hora)
					FOR DescripcionCorta IN (' + @columnas + ')
				) AS PivotTable'
	END
	ELSE
	BEGIN
		SET @SQLString = N'
			SELECT *
				FROM
				(SELECT dd.NroVuelta, s.DescripcionCorta, Hora = (CASE WHEN Hora = ''2001-01-01 00:00'' THEN ''      - Boleto:        '' ELSE CONVERT(VARCHAR,RIGHT(''00'' + CONVERT(VARCHAR(2),DATEPART(HOUR,dd.Hora)), 2)+ '':'' + RIGHT(''00'' + CONVERT(VARCHAR(2),DATEPART(MINUTE,dd.Hora)), 2) + '' - Boleto:        '') END)
					FROM Diagramas d
						INNER JOIN Diagramas_Detalle dd ON d.Id = dd.Id_Diagrama
						INNER JOIN Diagramas_Fecha df ON d.Id = df.Id_Diagrama 
						INNER JOIN Secciones s ON dd.Id_Seccion = s.Id
							WHERE
								d.Id = ' + CONVERT(VARCHAR,@Id_Diagrama) + '
								AND df.Fecha = ''' + RTRIM(CONVERT(CHAR,@Fecha,103))  + '''
								AND s.IdaVuelta = '''  + @IdaVuelta  + '''
								AND dd.NroServicio = ' + CONVERT(VARCHAR,@NroServicio) + '
								AND dd.Turno = ' + CONVERT(VARCHAR,@Turno) + '
								AND s.UserDel IS NUll
								AND dd.UserDel IS NUll
								AND df.UserDel IS NUll
				 ) AS SourceTable
				PIVOT
				(
					MIN(Hora)
					FOR DescripcionCorta IN (' + @columnas + ')
				) AS PivotTable'
		END	
		
	PRINT @SQLString
	EXECUTE sp_executesql @SQLString

END
GO
PRINT N'Creando [dbo].[Achicar_Log]...';


GO
CREATE PROCEDURE [dbo].[Achicar_Log]  
AS

declare @database varchar(100)

declare cursorDataBases cursor for
SELECT NAME FROM master..sysdatabases
where NAME not in ('master', 'tempdb', 'model', 'msdb')
and NAME not like '%ReportServer%'
and NAME not like '%-%'

open cursorDataBases
fetch next from cursorDataBases into @database
while @@fetch_status = 0
begin
	declare @sql varchar(1000)
	
	set @sql = 'ALTER DATABASE ' + @database + ' SET RECOVERY SIMPLE'
	
	print(@sql)
	exec(@sql)
	
	set @sql = 'USE ' + @database + '; declare @logfile varchar(1000); declare @logid int; set @logfile = (select name from sysfiles where groupid = 0); set @logid = (select fileid from sysfiles where groupid = 0); DBCC SHRINKFILE (@logid , 0, TRUNCATEONLY)'
	
	print(@sql)
	exec(@sql)
	
	set @sql = 'ALTER DATABASE ' + @database + ' SET RECOVERY FULL'
	
	print(@sql)
	exec(@sql)
	
	fetch next from cursorDataBases into @database
end

close cursorDataBases
deallocate cursorDataBases
GO
PRINT N'Creando [dbo].[AsignaServicio]...';


GO
CREATE PROCEDURE [dbo].[AsignaServicio]
	@IdPlanificacion INT = 12,
	@Fecha DATE = '20141228',
	@IdCoche INT = 44,
	@IdPersonal INT = 1,
	@Turno INT = 2
AS
BEGIN

	DECLARE @IdDiagrama INT = 0
	DECLARE @NroServicio INT = 0
	 
	SELECT @IdDiagrama = ds.Id_Diagrama, @NroServicio = ds.NroServicio 
		FROM PlanificacionDetallesCoches pdc 
		INNER JOIN Diagramas_Servicios ds ON pdc.Id_Servicio = ds.Id
			WHERE pdc.Id_Planificacion = @IdPlanificacion AND 
				  pdc.Fecha = @Fecha AND 
				  pdc.Id_Coche = @IdCoche

	DECLARE @IdServicio INT = 0
	DECLARE @Novedad VARCHAR(5) = ''

	SELECT @IdServicio = Id, @Novedad = Codigo
		FROM Diagramas_Servicios 
			WHERE Id_Diagrama = @IdDiagrama AND
				  NroServicio = @NroServicio AND
				  Turno = @Turno AND
				  Id NOT IN (SELECT Id_Servicio 
							 FROM PlanificacionDetalles
							 WHERE Id_Planificacion = @IdPlanificacion AND 
								   Fecha = @Fecha AND 
								   Id_Servicio > 0) 

	UPDATE PlanificacionDetalles
		SET Novedad = @Novedad, Id_Novedad = 0, Id_Servicio = @IdServicio
			WHERE Id_Planificacion = @IdPlanificacion AND 
			      Fecha = @Fecha AND
			      Id_Coche = @IdCoche AND 
				  Id_Personal = @IdPersonal 
 
END
GO
PRINT N'Creando [dbo].[DiagramasMarcadosPorFechas]...';


GO
CREATE PROCEDURE [dbo].[DiagramasMarcadosPorFechas]
	@IdPlanificacion INT

AS
BEGIN
 
SELECT COUNT(DISTINCT(ds.Id)), ds.Id_Diagrama, ps.Fecha
	FROM Diagramas_Servicios ds 
	INNER JOIN Diagramas_Detalle dd ON ds.Id_Diagrama = dd.Id_Diagrama AND ds.NroServicio = dd.NroServicio AND ds.Turno = dd.Turno
	INNER JOIN PlanificacionServicios ps ON ps.Id_Diagrama = ps.Id_Diagrama AND Id_Planificacion = @IdPlanificacion
WHERE ds.Id_Diagrama IN (SELECT Id_Diagrama FROM PlanificacionServicios WHERE Id_Planificacion = @IdPlanificacion) AND dd.Marcada = 1
GROUP BY ds.Id_Diagrama, ps.Fecha

END
GO
PRINT N'Creando [dbo].[DuplicaDiagrama]...';


GO
CREATE procedure [dbo].[DuplicaDiagrama]
		@Diagrama_Ant INT,
		@Diagrama_Nuevo INT
AS
BEGIN
 
INSERT INTO Diagramas_Detalle
SELECT @Diagrama_Nuevo,NroServicio,Turno,Id_Seccion,NroVuelta,Hora,Marcada,FechaAdd,FechaMod,FechaDel,UserAdd,UserMod,UserDel
FROM Diagramas_Detalle WHERE Id_Diagrama = @Diagrama_Ant

INSERT INTO Diagramas_Servicios
SELECT NroServicio,@Diagrama_Nuevo,Turno,HoraCitacion,HoraFinalizacion,Kms,Codigo,FechaAdd,FechaMod,FechaDel,UserAdd,UserMod,UserDel
FROM Diagramas_Servicios WHERE Id_Diagrama = @Diagrama_Ant

END
GO
PRINT N'Creando [dbo].[FieldList]...';


GO
CREATE Procedure [dbo].[FieldList]
@TABLE_NAME VARCHAR(255)
AS
DECLARE @Camp VARCHAR(MAX)
SET @Camp = ''
SELECT @Camp+=','+column_name FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME=@TABLE_NAME
PRINT SUBSTRING(@Camp,2,LEN(@Camp)-1)
GO
PRINT N'Creando [dbo].[PlanificacionBajaDiario]...';


GO
CREATE PROCEDURE [dbo].[PlanificacionBajaDiario]
	@IdPlanificacion INT,
	@Fecha DATE,
	@IdUser INT  
AS
BEGIN
 
	DECLARE @IdCoche INT = 0
	DECLARE @IdServicio INT = 0
	DECLARE @IdPersonal INT = 0
	
	UPDATE Diagramas_Fecha
		SET FechaDel = GETDATE(), UserDel = @IdUser
			WHERE Fecha = @Fecha AND
				  Id_Diagrama IN (SELECT Id_Diagrama FROM PlanificacionServicios WHERE Id_Planificacion = @IdPlanificacion)
  
	INSERT INTO Diagramas_Fecha (Fecha,Id_Diagrama,NroServicio,Turno,Id_Coche,Id_Personal,FechaAdd,UserAdd)
		(SELECT @Fecha, ps.Id_Diagrama, ds.NroServicio, ds.Turno, 0, 0, GETDATE(), @IdUser 
			FROM PlanificacionServicios ps
			INNER JOIN Diagramas_Servicios ds ON ps.Id_Diagrama = ds.Id_Diagrama
				WHERE ps.Id_Planificacion = @IdPlanificacion AND
					  ps.Fecha = @Fecha)
	
	DECLARE cur CURSOR FOR
		SELECT Interno, Id_Servicio 
			FROM PlanificacionDetallesCoches p 
			INNER JOIN Coches c on p.Id_Coche = c.Id
				WHERE p.Id_Planificacion = @IdPlanificacion AND
					  p.Fecha = @Fecha AND
					  p.Id_Servicio > 0 AND
				      p.UserDel IS NULL	

	OPEN cur
	FETCH NEXT FROM cur INTO @IdCoche, @IdServicio 

	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		UPDATE Diagramas_Fecha 
			SET Id_Coche = @IdCoche
				WHERE Id_Diagrama IN (SELECT Id_Diagrama FROM Diagramas_Servicios WHERE Id = @IdServicio) AND
				      NroServicio IN (SELECT NroServicio FROM Diagramas_Servicios WHERE Id = @IdServicio) AND
				      Fecha = @Fecha AND
				      UserDel IS NULL
				      
		FETCH NEXT FROM cur INTO @IdCoche, @IdServicio 
	
	END
	CLOSE cur 
	DEALLOCATE cur	
 
	DECLARE cur2 CURSOR FOR
		SELECT Id_Personal, Id_Servicio 
			FROM PlanificacionDetalles
				WHERE Id_Planificacion = @IdPlanificacion AND
					  Fecha = @Fecha AND 
					  Id_Servicio > 0 AND
				      UserDel IS NULL	

	OPEN cur2
	FETCH NEXT FROM cur2 INTO @IdPersonal, @IdServicio 

	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		UPDATE Diagramas_Fecha 
			SET Id_Personal = (SELECT ISNULL(LaboralLegajo, 0) from Personal WHERE Id = @IdPersonal)
				WHERE Id_Diagrama IN (SELECT Id_Diagrama FROM Diagramas_Servicios WHERE Id = @IdServicio) AND
				      NroServicio IN (SELECT NroServicio FROM Diagramas_Servicios WHERE Id = @IdServicio) AND
				      Turno IN (SELECT Turno FROM Diagramas_Servicios WHERE Id = @IdServicio) AND
				      Fecha = @Fecha AND
				      UserDel IS NULL	
				      		      
		FETCH NEXT FROM cur2 INTO @IdPersonal, @IdServicio 
	
	END
	CLOSE cur2
	DEALLOCATE cur2
  
END
GO
PRINT N'Creando [dbo].[PlanificacionConfirmar]...';


GO

CREATE PROCEDURE [dbo].[PlanificacionConfirmar]
	@IdPlanificacion INT 
AS
BEGIN
	
	INSERT INTO PlanificacionDetallesConfirmado 
		SELECT * 
			FROM PlanificacionDetalles
				WHERE Id_Planificacion = @IdPlanificacion

	INSERT INTO PlanificacionDetallesCochesConfirmado
		SELECT *
			FROM PlanificacionDetallesCoches
				WHERE Id_Planificacion = @IdPlanificacion
			
END
GO
PRINT N'Creando [dbo].[PlanificacionDetallesCochesDiaria]...';


GO
CREATE PROCEDURE [dbo].[PlanificacionDetallesCochesDiaria]
	@Id_Planificacion INT 
AS
BEGIN
	SET DATEFIRST 7; 
	
	DECLARE @IdCoche INT
	DECLARE @IdTipoServicio INT
	DECLARE @IdDiagrama INT
	DECLARE @Desde DATE
	DECLARE @Hasta DATE
	DECLARE @UserAdd INT 
	 
	DECLARE cur CURSOR FOR
		SELECT Id, Id_TipoServicio 
			FROM COCHES 
				WHERE Id IN (SELECT Id_Coche 
								FROM PlanificacionDetalles
									WHERE Id_Planificacion  = @Id_Planificacion)

	OPEN cur
	FETCH NEXT FROM cur INTO @IdCoche, @IdTipoServicio

	WHILE @@FETCH_STATUS = 0
	BEGIN
			
		SELECT @Desde = FechaDesde, @Hasta = FechaHasta, @UserAdd = UserAdd
			FROM Planificacion
				WHERE Id = @Id_Planificacion
		
		WHILE @Desde <= @Hasta
		BEGIN
			SET @IdDiagrama = 0
			
			SELECT @IdDiagrama = Id_Diagrama
				FROM PlanificacionServicios 
					WHERE Id_Planificacion = @Id_Planificacion AND
						  Id_TipoServicio = @IdTipoServicio AND 
						  Fecha = @Desde
			
			UPDATE PlanificacionDetallesCoches 
				SET Id_TipoServicio = @IdTipoServicio, Id_Diagrama = @IdDiagrama, Id_Servicio = 0
					WHERE Id_Planificacion = @Id_Planificacion AND Id_Coche = @IdCoche AND Fecha = @Desde
			
			IF @@rowcount = 0
			BEGIN
				INSERT INTO PlanificacionDetallesCoches (Id_Planificacion,Id_Coche,Fecha,Id_TipoServicio,Id_Diagrama,Id_Servicio,FechaAdd,UserAdd) 
					VALUES (@Id_Planificacion, @IdCoche, @Desde, @IdTipoServicio, @IdDiagrama, 0, GETDATE(), @UserAdd)
			END
				 
			SET @Desde = DATEADD(d, 1, @Desde) 
		
		END
		
		FETCH NEXT FROM cur INTO @IdCoche, @IdTipoServicio
	END
			
	CLOSE cur 
	DEALLOCATE cur

END
GO
PRINT N'Creando [dbo].[PlanificacionDiagramaServicios]...';


GO
CREATE PROCEDURE [dbo].[PlanificacionDiagramaServicios]
	@FechaDesde DATE,
	@FechaHasta DATE,
	@IdPersonal INT,
	@IdPlanificacion INT
AS
BEGIN

	SELECT Legajo = p.LaboralLegajo,
		   Personal = LTRIM(RTRIM(p.Apellido)) + ', ' + LTRIM(RTRIM(p.Nombre)),
		   Fecha = CONVERT(VARCHAR, Fecha, 103), 
		   Servicios = ISNULL(CONVERT(VARCHAR, ds.NroServicio), ISNULL(tn.DescripcionLarga, '')),
		   Turno = ISNULL(CONVERT(VARCHAR,ds.Turno), ''), 
		   Citacion =  ISNULL(LEFT(CONVERT(VARCHAR, ds.HoraCitacion, 114), 5), CASE WHEN tn.ALaOrden = 1 THEN ISNULL(tn.Descripcion,'') ELSE '' END),
		   Servicio = ISNULL((SELECT TOP 1 LEFT(CONVERT(VARCHAR, d.Hora, 114), 5)
					   FROM Diagramas_Detalle d
					   INNER JOIN Secciones s ON d.Id_Seccion = s.Id
					   WHERE d.NroServicio = ds.NroServicio AND 
							 d.Id_Diagrama = ds.Id_Diagrama AND
							 d.Hora > '20010101 00:00' AND
							 d.Turno = ds.Turno AND
							 d.UserDel IS NULL AND
							 s.UserDel IS NULL
					   ORDER BY Turno, NroVuelta, Numero), ''),
			Linea = ISNULL(l.DescripcionCorta, ''),
			Lugar = ISNULL((SELECT TOP 1 s.Descripcion
					 FROM Diagramas_Detalle d
					 INNER JOIN Secciones s ON d.Id_Seccion = s.Id
					 WHERE d.NroServicio = ds.NroServicio AND 
						   d.Id_Diagrama = ds.Id_Diagrama AND
						   d.Hora > '20010101 00:00' AND
						   d.Turno = ds.Turno AND
						   d.UserDel IS NULL AND
						   s.UserDel IS NULL
					 ORDER BY Turno, NroVuelta, Numero), '')
	FROM PlanificacionDetalles pd
	LEFT JOIN Diagramas_Servicios ds ON pd.Id_Servicio = ds.Id
	LEFT JOIN Diagramas d ON ds.Id_Diagrama = d.Id
	LEFT JOIN TipoServicios ts ON d.Id_TipoServicio = ts.Id
	LEFT JOIN Ramales r ON ts.Id_Ramal = r.Id
	LEFT join Lineas l ON r.Id_Linea = l.Id
	LEFT JOIN TipoNovedades tn ON pd.Id_Novedad = tn.Id
	INNER JOIN Personal p ON pd.Id_Personal = p.Id
		WHERE pd.Id_Planificacion = @IdPlanificacion AND
			  pd.Fecha BETWEEN @FechaDesde AND @FechaHasta AND
			  ds.UserDel IS NULL AND
			  pd.UserDel IS NULL AND
			  ds.UserDel IS NULL AND
			  ts.UserDel IS NULL AND
			  tn.UserDel IS NULL AND
			  r.UserDel IS NULL AND
			  l.UserDel IS NULL AND
			  p.UserDel IS NULL AND
			  pd.Id_Personal = @IdPersonal
	ORDER BY pd.Fecha

END
GO
PRINT N'Creando [dbo].[PlanificacionMensual]...';


GO
CREATE PROCEDURE [dbo].[PlanificacionMensual]
	@Id_Planificacion INT

AS
BEGIN
	DECLARE @Columnas NVARCHAR(MAX) = ''
	DECLARE @ColumnasDT NVARCHAR(MAX) = ''
	DECLARE @SQLString NVARCHAR(MAX) = ''

	DECLARE @Desde date
	DECLARE @Hasta date
	DECLARE @Desde2 date

	SELECT @Desde = FechaDesde,@Desde2 = FechaDesde, @Hasta = FechaHasta FROM Planificacion WHERE Id = @Id_Planificacion
	 
	WHILE @Desde2 <= @Hasta
	BEGIN
		SELECT @Columnas =  COALESCE(@Columnas + '[' + CAST(day(@desde2) AS VARCHAR(2)) + '],', '')
		SELECT @ColumnasDT =  COALESCE(@ColumnasDT + '[DN' + CAST(day(@desde2) AS VARCHAR(2)) + '],', '')
		
		SET @Desde2 = DATEADD(d,1,@Desde2)
	END
		 
	SET @Columnas = LEFT(@Columnas,LEN(@Columnas)-1)
	SET @ColumnasDT = LEFT(@ColumnasDT,LEN(@ColumnasDT)-1)

	--+ ''' + '-' + ''' + r2.Descripcion + ''' + '-' + ''' + ts2.Descripcion
	SET	@SQLString = N'
		SELECT PivotTable.*,' + @ColumnasDT + ' 
			FROM
			(SELECT Novedad = CASE WHEN l2.DescripcionCorta IS NULL THEN pd.Novedad ELSE pd.Novedad + ''' + '-' + ''' + l2.DescripcionCorta END, 
					Linea = l.Descripcion + ''' + ' - ' + ''' + r.Descripcion + ''' + ' - ' + ''' + ts.Descripcion, Id_TipoServicio = ts.Id, pd.Id_Coche, pd.Id_Personal, Dia = DAY(pd.Fecha), 
					Legajo = CONVERT(VARCHAR, pe.LaboralLegajo) + ''' + ' - ' + ''' + pe.Apellido + ''' +  ', ' + ''' +  pe.Nombre, 
					c.Interno
				FROM PlanificacionDetalles pd 
				LEFT JOIN TipoServicios ts ON pd.Id_TipoServicio = ts.Id
				LEFT JOIN Ramales r ON ts.Id_Ramal = r.Id
				LEFT JOIN Lineas l ON r.Id_Linea = l.Id
				LEFT JOIN Coches c ON pd.Id_Coche = c.Id
				left join Diagramas_Servicios ds on pd.Id_Servicio = ds.Id
				left join Diagramas d on ds.Id_Diagrama = d.Id
				left join TipoServicios ts2 on d.Id_TipoServicio = ts2.Id
				left join Ramales r2 on ts2.Id_Ramal = r2.Id
				left join Lineas l2 on r2.Id_Linea = l2.Id
				INNER JOIN Personal pe ON pd.Id_Personal = pe.Id
					WHERE pd.Id_Planificacion =' + CONVERT(VARCHAR,@Id_Planificacion) + '
			 ) AS SourceTable
			PIVOT
				(
					MAX(Novedad)
					FOR Dia IN (' + @columnas + ') 
				) AS PivotTable 
		INNER JOIN 
		(SELECT * 
			FROM
			(SELECT Novedad = ISNULL(pd.Id_Novedad, 0), Linea = l.Descripcion + ''' + ' - ' + ''' + r.Descripcion + ''' + ' - ' + ''' + ts.Descripcion,
					Id_Linea = l.Id, pd.Id_Coche, pd.Id_Personal, Dia = ''' + 'DN' + ''' + convert(varchar,DAY(pd.Fecha)), 
					Legajo = CONVERT(VARCHAR, pe.LaboralLegajo) + ''' + ' - ' + ''' + pe.Apellido + ''' +  ', ' + ''' +  pe.Nombre, 
					c.Interno
				FROM PlanificacionDetalles pd 
				LEFT JOIN TipoServicios ts ON pd.Id_TipoServicio = ts.Id
				LEFT JOIN Ramales r ON ts.Id_Ramal = r.Id
				LEFT JOIN Lineas l ON r.Id_Linea = l.Id
				LEFT JOIN Coches c ON pd.Id_Coche = c.Id
				INNER JOIN Personal pe ON pd.Id_Personal = pe.Id
					WHERE pd.Id_Planificacion =' + CONVERT(VARCHAR,@Id_Planificacion) + '
			 ) AS SourceTable
			PIVOT
				(
					MAX(Novedad)
					FOR Dia IN (' + @columnasDT + ') 
				) AS PivotTable ) AS T ON T.Legajo = PivotTable.Legajo 
		ORDER BY T.Linea DESC, T.Interno'
 
	PRINT @SQLString
	EXECUTE sp_executesql @SQLString

END
GO
PRINT N'Creando [dbo].[PlanificacionMensualCoches]...';


GO

CREATE PROCEDURE [dbo].[PlanificacionMensualCoches]
	@Id_Planificacion INT

AS
BEGIN
	DECLARE @Columnas NVARCHAR(MAX) = ''
	DECLARE @SQLString NVARCHAR(MAX) = ''

	DECLARE @Desde date
	DECLARE @Hasta date
	DECLARE @Desde2 date

	SELECT @Desde = FechaDesde,@Desde2 = FechaDesde, @Hasta = FechaHasta FROM Planificacion WHERE Id = @Id_Planificacion
	 
	WHILE @Desde2 <= @Hasta
	BEGIN
		SELECT @Columnas = COALESCE(@Columnas + '[' + CAST(day(@desde2) AS VARCHAR(2)) + '],', '')
		
		SET @Desde2 = DATEADD(d, 1, @Desde2)
	END
		 
	SET @Columnas = LEFT(@Columnas, LEN(@Columnas) - 1)

	--(SELECT Novedad = CASE WHEN ISNULL(ds.NroServicio,0) = 0 THEN ''' + ''' ELSE CONVERT(VARCHAR,ds.NroServicio) + ''' + '-' + ''' + l.DescripcionCorta + ''' + '-' + ''' + r.Descripcion + ''' + '-' + ''' + ts.Descripcion END, Linea = l.Descripcion + ''' + ' - ' + ''' + r.Descripcion + ''' + ' - ' + ''' + ts.Descripcion, pd.Id_Coche , Dia =  convert(varchar,DAY(pd.Fecha)), c.Interno, pd.Id_TipoServicio
	SET	@SQLString = N'
		SELECT * 
			FROM
			(SELECT Novedad = CASE WHEN ISNULL(ds.NroServicio,0) = 0 THEN ''' + ''' ELSE CONVERT(VARCHAR,ds.NroServicio) + ''' + '-' + ''' + (SELECT l1.DescripcionCorta FROM Diagramas_Servicios ds1
																																				INNER JOIN Diagramas d1 ON ds1.Id_Diagrama = d1.Id
																																				INNER JOIN TipoServicios ts1 ON d1.Id_TipoServicio = ts1.Id
																																				INNER JOIN Ramales r1 ON ts1.Id_Ramal = r1.Id
																																				INNER JOIN Lineas l1 ON r1.Id_Linea = l1.Id
																																				WHERE ds1.Id = ds.Id) 
			 END, Linea = l.Descripcion + ''' + ' - ' + ''' + r.Descripcion + ''' + ' - ' + ''' + ts.Descripcion, pd.Id_Coche , Dia =  convert(varchar,DAY(pd.Fecha)), c.Interno, pd.Id_TipoServicio
				FROM PlanificacionDetallesCoches pd 
				LEFT JOIN Diagramas_Servicios ds on pd.Id_Servicio = ds.Id
				LEFT JOIN TipoServicios ts ON pd.Id_TipoServicio = ts.Id
				LEFT JOIN Ramales r ON ts.Id_Ramal = r.Id
				LEFT JOIN Lineas l ON r.Id_Linea = l.Id
				LEFT JOIN Coches c ON pd.Id_Coche = c.Id
					WHERE pd.Id_Planificacion =' + CONVERT(VARCHAR,@Id_Planificacion) + ' 
			 ) AS SourceTable
			PIVOT
				(
					MAX(Novedad)
					FOR Dia IN (' + @columnas + ') 
				) AS PivotTable 
		ORDER BY Linea DESC, Interno DESC'
 
	PRINT @SQLString
	EXECUTE sp_executesql @SQLString

END
GO
PRINT N'Creando [dbo].[PlanificacionNovedades]...';


GO
 
CREATE PROCEDURE [dbo].[PlanificacionNovedades]
	@IdPlanificacion INT
AS
BEGIN

	DECLARE @Id INT = 0
	DECLARE @Desde DATE
	DECLARE @Hasta DATE
	DECLARE @FechaNovedad DATE
	DECLARE @IdPersonal INT
	DECLARE @IdNovedad INT
	DECLARE @Novedad Varchar(3)
	 	
	SELECT @Id = Id, @Desde = FechaDesde, @Hasta = FechaHasta
		FROM Planificacion 
			WHERE Id = @IdPlanificacion
		
	DECLARE Nov_cur CURSOR FOR
		SELECT p.Fecha, p.Id_Personal, n.Descripcion, p.Id_TipoNovedad 
			FROM PersonalNovedades p INNER JOIN TipoNovedades n ON p.Id_TipoNovedad = n.Id 
				WHERE p.Fecha BETWEEN @Desde AND @Hasta AND
					  p.UserDel IS NULL AND
					  n.UserDel IS NULL
					
	OPEN Nov_cur

	FETCH NEXT FROM Nov_cur INTO @FechaNovedad, @IdPersonal, @Novedad, @IdNovedad

	WHILE @@FETCH_STATUS = 0
		BEGIN
			UPDATE PlanificacionDetalles 
				SET Novedad = @Novedad, Id_Servicio = 0, Id_Novedad = @IdNovedad
					WHERE Fecha = @FechaNovedad AND Id_Personal = @IdPersonal 
		
			FETCH NEXT FROM Nov_cur INTO @FechaNovedad, @IdPersonal, @Novedad, @IdNovedad
		END 
		
	CLOSE Nov_cur 
	DEALLOCATE Nov_cur 
	
END
GO
PRINT N'Creando [dbo].[PlanificacionPlanillaCitacion]...';


GO
CREATE PROCEDURE [dbo].[PlanificacionPlanillaCitacion]
	@Fecha DATE,
	@IdPlanificacion INT,
	@IdTipoServicio INT

AS
BEGIN

SELECT Fecha, Linea, Servicio,  
	   Coche1 = Max(Coche1), Legajo1 = MAX(Legajo1), Personal1 = MAX(Personal1), Citacion1 = MAX(Citacion1),Deje1 = MAX(Deje1), ServicioTome1 = MAX(ServicioTome1), ServicioDeje1 = MAX(ServicioDeje1),
	   Coche2 = Max(Coche2), Legajo2 = MAX(Legajo2), Personal2 = MAX(Personal2), Citacion2 = MAX(Citacion2),Deje2 = MAX(Deje2), ServicioTome2 = MAX(ServicioTome2), ServicioDeje2 = MAX(ServicioDeje2),
	   Coche3 = Max(Coche3), Legajo3 = MAX(Legajo3), Personal3 = MAX(Personal3), Citacion3 = MAX(Citacion3),Deje3 = MAX(Deje3), ServicioTome3 = MAX(ServicioTome3), ServicioDeje3 = MAX(ServicioDeje3)
FROM
( 
	SELECT 
		Fecha = CONVERT(VARCHAR, Fecha, 103), 
		Linea = ISNULL(l.DescripcionCorta, ''),
		Servicio = CONVERT(VARCHAR, ds.NroServicio),
		Coche1 = ISNULL(CONVERT(VARCHAR, c.Interno), ''),
		Legajo1 = CONVERT(VARCHAR, p.LaboralLegajo),
		Personal1 = LTRIM(RTRIM(p.Apellido)) + ', ' + LTRIM(RTRIM(p.Nombre)),
		Citacion1 =  ISNULL(LEFT(CONVERT(VARCHAR, ds.HoraCitacion, 114), 5), CASE WHEN tn.ALaOrden = 1 THEN ISNULL(tn.Descripcion,'') ELSE '' END),
		Deje1 =  ISNULL(LEFT(CONVERT(VARCHAR, ds.HoraFinalizacion, 114), 5), CASE WHEN tn.ALaOrden = 1 THEN ISNULL(tn.Descripcion,'') ELSE '' END),
		ServicioTome1 = ISNULL((SELECT TOP 1 LEFT(CONVERT(VARCHAR, d.Hora, 114), 5)
			 			FROM Diagramas_Detalle d
			 			INNER JOIN Secciones s ON d.Id_Seccion = s.Id
			 			WHERE d.NroServicio = ds.NroServicio AND 
				 			  d.Id_Diagrama = ds.Id_Diagrama AND
				 			  d.Turno = 1 AND
				 			  d.UserDel IS NULL AND
							  Hora > '20010101 00:00'
			 			ORDER BY Turno, NroVuelta, Numero), ''),
		ServicioDeje1 = ISNULL((SELECT TOP 1 LEFT(CONVERT(VARCHAR, d.Hora, 114), 5)
			 			FROM Diagramas_Detalle d
			 			INNER JOIN Secciones s ON d.Id_Seccion = s.Id
			 			WHERE d.NroServicio = ds.NroServicio AND 
							  d.Id_Diagrama = ds.Id_Diagrama AND
							  d.Turno = 1 AND
				 			  d.UserDel IS NULL AND
							  Hora > '20010101 00:00'
			 			ORDER BY Turno, NroVuelta desc, Numero desc), ''),
		Coche2 = '', Legajo2 = '', Personal2 = '',Citacion2 = '', Deje2 = '', ServicioTome2 = '', ServicioDeje2 = '',
		Coche3 = '', Legajo3 = '', Personal3 = '',Citacion3 = '', Deje3 = '', ServicioTome3 = '', ServicioDeje3 = ''
		FROM PlanificacionDetalles pd
		LEFT JOIN Diagramas_Servicios ds ON pd.Id_Servicio = ds.Id
		LEFT JOIN Diagramas d ON ds.Id_Diagrama = d.Id
		LEFT JOIN TipoServicios ts ON d.Id_TipoServicio = ts.Id
		LEFT JOIN Ramales r ON ts.Id_Ramal = r.Id
		LEFT join Lineas l ON r.Id_Linea = l.Id
		LEFT JOIN TipoNovedades tn ON pd.Id_Novedad = tn.Id
		LEFT JOIN Coches c ON pd.Id_Coche = c.Id
		INNER JOIN Personal p ON pd.Id_Personal = p.Id
			WHERE pd.Id_Planificacion = @IdPlanificacion AND
				  pd.Fecha = @Fecha AND
				  pd.UserDel IS NULL AND
				  ds.Turno = 1 AND
				  ts.Id = @IdTipoServicio
	UNION
	SELECT 
		Fecha = CONVERT(VARCHAR, Fecha, 103), 
		Linea = ISNULL(l.DescripcionCorta, ''),
		Servicio = CONVERT(VARCHAR, ds.NroServicio),
		Coche1 = '', Legajo1 = '', Personal1 = '',Citacion1 = '', Deje1 = '', ServicioTome1 = '', ServicioDeje1 = '',
		Coche2 = ISNULL(CONVERT(VARCHAR, c.Interno),''),
		Legajo2 = CONVERT(VARCHAR, p.LaboralLegajo),
		Personal2 = LTRIM(RTRIM(p.Apellido)) + ', ' + LTRIM(RTRIM(p.Nombre)),
		Citacion2 =  ISNULL(LEFT(CONVERT(VARCHAR, ds.HoraCitacion, 114), 5), CASE WHEN tn.ALaOrden = 1 THEN ISNULL(tn.Descripcion,'') ELSE '' END),
		Deje2 =  ISNULL(LEFT(CONVERT(VARCHAR, ds.HoraFinalizacion, 114), 5), CASE WHEN tn.ALaOrden = 1 THEN ISNULL(tn.Descripcion,'') ELSE '' END),
		ServicioTome2 = ISNULL((SELECT TOP 1 LEFT(CONVERT(VARCHAR, d.Hora, 114), 5)
			 			FROM Diagramas_Detalle d
			 			INNER JOIN Secciones s ON d.Id_Seccion = s.Id
			 			WHERE d.NroServicio = ds.NroServicio AND 
				 			  d.Id_Diagrama = ds.Id_Diagrama AND
				 			  d.Turno = 2 AND
				 			  d.UserDel IS NULL AND
							  Hora > '20010101 00:00'
			 			ORDER BY Turno, NroVuelta, Numero), ''),
		ServicioDeje2 = ISNULL((SELECT TOP 1 LEFT(CONVERT(VARCHAR, d.Hora, 114), 5)
			 			FROM Diagramas_Detalle d
			 			INNER JOIN Secciones s ON d.Id_Seccion = s.Id
			 			WHERE d.NroServicio = ds.NroServicio AND 
							  d.Id_Diagrama = ds.Id_Diagrama AND 
							  d.Turno = 2 AND
				 			  d.UserDel IS NULL AND
							  Hora > '20010101 00:00'
			 			ORDER BY Turno, NroVuelta desc, Numero desc), ''),
		Coche3 = '', Legajo3 = '', Personal3 = '',Citacion3 = '', Deje3 = '', ServicioTome3 = '', ServicioDeje3 = '' 
		FROM PlanificacionDetalles pd
		LEFT JOIN Diagramas_Servicios ds ON pd.Id_Servicio = ds.Id
		LEFT JOIN Diagramas d ON ds.Id_Diagrama = d.Id
		LEFT JOIN TipoServicios ts ON d.Id_TipoServicio = ts.Id
		LEFT JOIN Ramales r ON ts.Id_Ramal = r.Id
		LEFT join Lineas l ON r.Id_Linea = l.Id
		LEFT JOIN TipoNovedades tn ON pd.Id_Novedad = tn.Id
		LEFT JOIN Coches c ON pd.Id_Coche = c.Id
		INNER JOIN Personal p ON pd.Id_Personal = p.Id
			WHERE pd.Id_Planificacion = @IdPlanificacion AND
				  pd.Fecha = @Fecha AND
				  pd.UserDel IS NULL AND
				  ds.Turno = 2 AND
				  ts.Id = @IdTipoServicio 
	UNION
	SELECT 
		Fecha = CONVERT(VARCHAR, Fecha, 103), 
		Linea = ISNULL(l.DescripcionCorta, ''),
		Servicio = CONVERT(VARCHAR, ds.NroServicio),
		Coche1 = '', Legajo1 = '', Personal1 = '',Citacion1 = '', Deje1 = '', ServicioTome1 = '', ServicioDeje1 = '',
		Coche2 = '', Legajo2 = '', Personal2 = '',Citacion2 = '', Deje2 = '', ServicioTome2 = '', ServicioDeje2 = '',
		Coche3 = ISNULL(CONVERT(VARCHAR, c.Interno), ''),
		Legajo3 = CONVERT(VARCHAR, p.LaboralLegajo),
		Personal3 = LTRIM(RTRIM(p.Apellido)) + ', ' + LTRIM(RTRIM(p.Nombre)),
		Citacion3 =  ISNULL(LEFT(CONVERT(VARCHAR, ds.HoraCitacion, 114), 5), CASE WHEN tn.ALaOrden = 1 THEN ISNULL(tn.Descripcion,'') ELSE '' END),
		Deje3 =  ISNULL(LEFT(CONVERT(VARCHAR, ds.HoraFinalizacion, 114), 5), CASE WHEN tn.ALaOrden = 1 THEN ISNULL(tn.Descripcion,'') ELSE '' END),
		ServicioTome3 = ISNULL((SELECT TOP 1 LEFT(CONVERT(VARCHAR, d.Hora, 114), 5)
			 			FROM Diagramas_Detalle d
			 			INNER JOIN Secciones s ON d.Id_Seccion = s.Id
			 			WHERE d.NroServicio = ds.NroServicio AND 
				 			  d.Id_Diagrama = ds.Id_Diagrama AND 
				 			  d.Turno = 3 AND
				 			  d.UserDel IS NULL AND
							  Hora > '20010101 00:00'
			 			ORDER BY Turno, NroVuelta, Numero), ''),
		ServicioDeje3 = ISNULL((SELECT TOP 1 LEFT(CONVERT(VARCHAR, d.Hora, 114), 5)
			 			FROM Diagramas_Detalle d
			 			INNER JOIN Secciones s ON d.Id_Seccion = s.Id
			 			WHERE d.NroServicio = ds.NroServicio AND 
							  d.Id_Diagrama = ds.Id_Diagrama AND
							  d.Turno = 3 AND
				 			  d.UserDel IS NULL AND
							  Hora > '20010101 00:00'
			 			ORDER BY Turno, NroVuelta desc, Numero desc), '')
			FROM PlanificacionDetalles pd
		LEFT JOIN Diagramas_Servicios ds ON pd.Id_Servicio = ds.Id
		LEFT JOIN Diagramas d ON ds.Id_Diagrama = d.Id
		LEFT JOIN TipoServicios ts ON d.Id_TipoServicio = ts.Id
		LEFT JOIN Ramales r ON ts.Id_Ramal = r.Id
		LEFT join Lineas l ON r.Id_Linea = l.Id
		LEFT JOIN TipoNovedades tn ON pd.Id_Novedad = tn.Id
		LEFT JOIN Coches c ON pd.Id_Coche = c.Id
		INNER JOIN Personal p ON pd.Id_Personal = p.Id
			WHERE pd.Id_Planificacion = @IdPlanificacion AND
				  pd.Fecha = @Fecha AND
				  pd.UserDel IS NULL AND
				  ds.Turno = 3 AND
				  ts.Id = @IdTipoServicio
	) AS T
GROUP BY Servicio, Fecha, Linea

END
GO
PRINT N'Creando [dbo].[PlanificacionPlanillaCitacionObservaciones]...';


GO
CREATE PROCEDURE [dbo].[PlanificacionPlanillaCitacionObservaciones]
	@Fecha DATE,
	@IdPlanificacion INT,
	@IdTipoServicio INT

AS
BEGIN
 
 SELECT  
	Legajo = p.LaboralLegajo,
	Personal = LTRIM(RTRIM(p.Apellido)) + ', ' + LTRIM(RTRIM(p.Nombre)),
	Servicio = ISNULL(tn.DescripcionLarga, '')
	FROM PlanificacionDetalles pd
	LEFT JOIN Diagramas_Servicios ds ON pd.Id_Servicio = ds.Id
	LEFT JOIN Diagramas d ON ds.Id_Diagrama = d.Id
	LEFT JOIN TipoServicios ts ON d.Id_TipoServicio = ts.Id
	LEFT JOIN Ramales r ON ts.Id_Ramal = r.Id
	LEFT join Lineas l ON r.Id_Linea = l.Id
	LEFT JOIN TipoNovedades tn ON pd.Id_Novedad = tn.Id
	LEFT JOIN Coches c ON pd.Id_Coche = c.Id
	INNER JOIN Personal p ON pd.Id_Personal = p.Id
		WHERE pd.Id_Planificacion = @IdPlanificacion AND
			  pd.Fecha = @Fecha AND
			  pd.UserDel IS NULL AND
			  ds.Turno IS NULL AND
			  pd.Id_TipoServicio = @IdTipoServicio AND
			  pd.Id_Novedad > 0
	ORDER BY tn.DescripcionLarga
		
END
GO
PRINT N'Creando [dbo].[PlanificacionRotacionChoferes]...';


GO
 
CREATE PROCEDURE [dbo].[PlanificacionRotacionChoferes]
	 @IdPlanificacion INT =  14
AS
BEGIN
	DECLARE @IdPlanificacionAnterior INT
	DECLARE @IdUN INT
	DECLARE @IdPersonal INT
	DECLARE @IdCoche INT
	DECLARE @DiaRotacion INT	
	DECLARE @CantDiasRotacion INT
	DECLARE @FechaDesde DATE
	DECLARE @Desde DATE
	DECLARE @Hasta DATE
	DECLARE @IdTurnoFijo INT

	DECLARE @Turno INT = 0
	DECLARE @TurnoAnt INT
	DECLARE @IdPD INT = 0
	DECLARE @Count INT
	--DECLARE @Flag INT 
	DECLARE @IdCocheAnt INT = 0
	DECLARE @IdPersonalAnt INT = 0
	
	SET DATEFIRST 7; 

	--PERSONAL QUE ROTA
	DECLARE cur CURSOR FOR
		SELECT DISTINCT(pd.Id_Personal) Id_Personal, MAX(pa.Id_UnidadNegocio), MAX(pd.Id_Coche) Id_Coche, MAX(p.LaboralDiaRotacion) LaboralDiaRotacion, MAX(p.LaboralDiasRotacion) LaboralDiasRotacion, MAX(pa.FechaDesde) FechaDesde, MAX(pa.FechaHasta) FechaHasta, MAX(LaboralTurnoFijo) LaboralTurnoFijo
			FROM PlanificacionDetalles pd 
			INNER JOIN Planificacion pa ON pd.Id_Planificacion = pa.Id
			INNER JOIN Personal p ON pd.Id_Personal = p.Id
				WHERE pd.Id_Planificacion = @IdPlanificacion AND
					  p.LaboralTurnoFijo > 3 
		GROUP BY pd.Id_Personal
		ORDER BY Id_Coche, Id_Personal

	OPEN cur
	FETCH NEXT FROM cur INTO @IdPersonal, @IdUN, @IdCoche, @DiaRotacion, @CantDiasRotacion, @Desde, @Hasta, @IdTurnoFijo

	WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @FechaDesde = @Desde
		
		WHILE @Desde <= @Hasta
		BEGIN
			
			IF @IdCocheAnt = @IdCoche
			BEGIN
				SELECT @Turno = ISNULL(Turno, 0)
					FROM PlanificacionDetalles pd INNER JOIN Diagramas_Servicios ds ON pd.Id_Servicio = ds.Id
						WHERE Id_Planificacion = @IdPlanificacion AND 
						      Fecha = @Desde AND
							  Id_Coche = @IdCoche AND 
					 		  Id_Personal = @IdPersonalAnt
				 
				IF @IdTurnoFijo = 4
					IF @Turno = 1
						SET @Turno = 2
					ELSE
					IF @Turno = 2
						SET @Turno = 1
					
				IF @IdTurnoFijo = 5
					IF @Turno = 1
						SET @Turno = 2
					ELSE
					IF @Turno = 2
						SET @Turno = 3
					ELSE
					IF @Turno = 3
						SET @Turno = 1
						 
				SET @Count = 0 
			END
			ELSE
			BEGIN
				IF @FechaDesde = @Desde
				BEGIN
					--BUSCA ULTIMA PLANIFICACION CONFIRMADA PARA ROTACION
					SELECT @IdPlanificacionAnterior = Id 
					FROM Planificacion  
						WHERE Id_UnidadNegocio = @IdUN AND 
							  FechaHasta < @Desde AND 
							  UserDel IS NULL AND 
							  FechaConfirmacion IS NOT NULL
					ORDER BY FechaDesde, Id
					
					SELECT @Turno =  ISNULL(ds.Turno, 0)
						FROM PlanificacionDetalles pd
							INNER JOIN Diagramas_Servicios ds ON pd.Id_Servicio = ds.Id
								WHERE pd.Id_Planificacion = @IdPlanificacionAnterior AND
									  pd.Id_Personal = @IdPersonal AND 
									  pd.Id_Servicio > 0 
					ORDER BY pd.Fecha DESC
					
					IF @IdTurnoFijo = 4
						IF @Turno = 1
							SET @Turno = 2
						ELSE
						IF @Turno = 2
							SET @Turno = 1
					
					IF @IdTurnoFijo = 5
						IF @Turno = 1
							SET @Turno = 2
						ELSE
						IF @Turno = 2
							SET @Turno = 3
						ELSE
						IF @Turno = 3
							SET @Turno = 1
					
					SET @Count = 0
					
				END
				ELSE
				BEGIN
					--VER SI ROTA
					IF @CantDiasRotacion > 0
						IF @Count = @CantDiasRotacion
						BEGIN
							IF @IdTurnoFijo = 4
							BEGIN
								IF @Turno = 1
									SET @Turno = 2
								ELSE
								IF @Turno = 2
									SET @Turno = 1
							END
					
							IF @IdTurnoFijo = 5
							BEGIN
								IF @Turno = 1
									SET @Turno = 2
								ELSE
								IF @Turno = 2
									SET @Turno = 3
								ELSE
								IF @Turno = 3
									SET @Turno = 1
							END
					
						SET @Count = 0
						END
					ELSE
						SET @Turno = @TurnoAnt
				END
			END
			
			IF @Turno = 0
				SET @Turno = 1
		
			SET @TurnoAnt = @Turno
			
			--BUSCO QUE NO TENGA UNA NOVEDAD ASIGNADA	
		 	SELECT @IdPD = ISNULL(Id, 0)
				FROM PlanificacionDetalles 
					WHERE Id_Planificacion = @IdPlanificacion AND
						  Fecha = @Desde AND
						  Id_Personal = @IdPersonal AND
						  Id_Novedad = 0 AND
						  Id_Servicio = 0
						  
			--ASIGNAR SERVICIO
			IF @IdPD > 0
				EXEC AsignaServicio @IdPlanificacion, @Desde, @IdCoche, @IdPersonal, @Turno
			
			SET @Count = @Count + 1
			SET @IdPD = 0
			
			SET @Desde = DATEADD(d, 1, @Desde)
		END
		
		SET @IdCocheAnt = @IdCoche
		SET @IdPersonalAnt = @IdPersonal
		
		FETCH NEXT FROM cur INTO @IdPersonal, @IdUN, @IdCoche, @DiaRotacion, @CantDiasRotacion, @Desde, @Hasta, @IdTurnoFijo
	END
		
	CLOSE cur 
	DEALLOCATE cur
	
END
GO
PRINT N'Creando [dbo].[PlanificacionRotacionServicioFijo]...';


GO
CREATE PROCEDURE [dbo].[PlanificacionRotacionServicioFijo]
	@Id_Planificacion INT
AS
BEGIN
	SET DATEFIRST 7; 
	
	DECLARE @TipoDia INT = 0
	DECLARE @Fecha DATE
	DECLARE @IdCoche INT
	DECLARE @Servicio INT
	DECLARE @IdServicio INT
	DECLARE @IdDiagrama INT
	
		
	DECLARE curFechas CURSOR FOR
		SELECT DISTINCT(Fecha) Fecha
			FROM PlanificacionDetallesCoches 
				WHERE Id_Planificacion = @Id_Planificacion  
		ORDER BY Fecha
	OPEN curFechas
	FETCH NEXT FROM curFechas INTO @Fecha 

	WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @TipoDia = ISNULL((SELECT CASE WHEN Id > 0 THEN 4 ELSE 1 END
						   FROM Feriado WHERE Fecha = @Fecha), 1)
		IF @TipoDia = 1
		BEGIN
			IF (DATEPART(dw, @Fecha) = 1) --Domingo
				SET @TipoDia = 3
			IF (DATEPART(dw, @Fecha) = 7) --Sabado
				SET @TipoDia = 2
		END
			
		--PEDIR LOS COCHES PARA SERVICIO FIJO HABILES
		IF @TipoDia = 1 
		BEGIN
			DECLARE curCoches CURSOR FOR
				SELECT DISTINCT(c.Id), c.HabilServicioFijo, pdc.Id_Diagrama
					FROM Coches c INNER JOIN PlanificacionDetallesCoches pdc ON c.Id = pdc.Id_Coche
						WHERE c.HabilServicioFijo > 0 AND Fecha = @Fecha
			OPEN curCoches
			FETCH NEXT FROM curCoches INTO @IdCoche, @Servicio, @IdDiagrama
			
			WHILE @@FETCH_STATUS = 0
			BEGIN
			
				SET @IdServicio = 0
				
				--VER SI ESTA EL SERVICIO DISPONIBLE
				SELECT @IdServicio = Min(ID) 
					FROM Diagramas_Servicios 
						WHERE Id_Diagrama = @IdDiagrama
							  AND NroServicio = @Servicio
				GROUP BY NroServicio
				HAVING NroServicio NOT IN (SELECT ds.NroServicio 
										   FROM PlanificacionDetallesCoches pdc 
										   INNER JOIN Diagramas_Servicios ds ON pdc.Id_Servicio = ds.Id 
										   WHERE Id_Planificacion = @Id_Planificacion AND
										   ds.Id_Diagrama = @IdDiagrama AND 
										   Fecha = @Fecha)
				
				IF @IdServicio > 0
					UPDATE PlanificacionDetallesCoches 
							SET Id_Servicio = @IdServicio 
						WHERE Id_Planificacion = @Id_Planificacion AND
							  Id_Coche = @IdCoche AND 
							  Fecha = @Fecha
				
				FETCH NEXT FROM curCoches INTO @IdCoche, @Servicio, @IdDiagrama
			END
			
			CLOSE curCoches
			DEALLOCATE curCoches
		END
		
		IF @TipoDia = 2 
		BEGIN
			DECLARE curCoches CURSOR FOR
				SELECT DISTINCT(c.Id), c.SabadoServicioFijo, pdc.Id_Diagrama
					FROM Coches c INNER JOIN PlanificacionDetallesCoches pdc ON c.Id = pdc.Id_Coche
						WHERE c.SabadoServicioFijo > 0 AND Fecha = @Fecha
			OPEN curCoches
			FETCH NEXT FROM curCoches INTO @IdCoche, @Servicio, @IdDiagrama
			
			WHILE @@FETCH_STATUS = 0
			BEGIN
			
				SET @IdServicio = 0
				
				--VER SI ESTA EL SERVICIO DISPONIBLE
				SELECT @IdServicio = Min(ID) 
					FROM Diagramas_Servicios 
						WHERE Id_Diagrama = @IdDiagrama
							  AND NroServicio = @Servicio
				GROUP BY NroServicio
				HAVING NroServicio NOT IN (SELECT ds.NroServicio 
										   FROM PlanificacionDetallesCoches pdc 
										   INNER JOIN Diagramas_Servicios ds ON pdc.Id_Servicio = ds.Id 
										   WHERE Id_Planificacion = @Id_Planificacion AND
										   ds.Id_Diagrama = @IdDiagrama AND 
										   Fecha = @Fecha)
				
				IF @IdServicio > 0
					UPDATE PlanificacionDetallesCoches 
							SET Id_Servicio = @IdServicio 
						WHERE Id_Planificacion = @Id_Planificacion AND
							  Id_Coche = @IdCoche AND 
							  Fecha = @Fecha
				
				FETCH NEXT FROM curCoches INTO @IdCoche, @Servicio, @IdDiagrama
			END
			
			CLOSE curCoches
			DEALLOCATE curCoches
		END
		
		IF @TipoDia = 3 
		BEGIN
			DECLARE curCoches CURSOR FOR
				SELECT DISTINCT(c.Id), c.DomingoServicioFijo, pdc.Id_Diagrama
					FROM Coches c INNER JOIN PlanificacionDetallesCoches pdc ON c.Id = pdc.Id_Coche
						WHERE c.DomingoServicioFijo > 0 AND Fecha = @Fecha 
			OPEN curCoches
			FETCH NEXT FROM curCoches INTO @IdCoche, @Servicio, @IdDiagrama
			
			WHILE @@FETCH_STATUS = 0
			BEGIN
			
				SET @IdServicio = 0
				
				--VER SI ESTA EL SERVICIO DISPONIBLE
				SELECT @IdServicio = Min(ID) 
					FROM Diagramas_Servicios 
						WHERE Id_Diagrama = @IdDiagrama
							  AND NroServicio = @Servicio
				GROUP BY NroServicio
				HAVING NroServicio NOT IN (SELECT ds.NroServicio 
										   FROM PlanificacionDetallesCoches pdc 
										   INNER JOIN Diagramas_Servicios ds ON pdc.Id_Servicio = ds.Id 
										   WHERE Id_Planificacion = @Id_Planificacion AND
										   ds.Id_Diagrama = @IdDiagrama AND 
										   Fecha = @Fecha)
				
				IF @IdServicio > 0
					UPDATE PlanificacionDetallesCoches 
							SET Id_Servicio = @IdServicio 
						WHERE Id_Planificacion = @Id_Planificacion AND
							  Id_Coche = @IdCoche AND 
							  Fecha = @Fecha
				
				FETCH NEXT FROM curCoches INTO @IdCoche, @Servicio, @IdDiagrama
			END
			
			CLOSE curCoches
			DEALLOCATE curCoches
		END
		
		IF @TipoDia = 4 
		BEGIN
			DECLARE curCoches CURSOR FOR
				SELECT DISTINCT(c.Id), c.FeriadoServicioFijo, pdc.Id_Diagrama
					FROM Coches c INNER JOIN PlanificacionDetallesCoches pdc ON c.Id = pdc.Id_Coche
						WHERE FeriadoServicioFijo > 0 AND Fecha = @Fecha
			OPEN curCoches
			FETCH NEXT FROM curCoches INTO @IdCoche, @Servicio, @IdDiagrama
			
			WHILE @@FETCH_STATUS = 0
			BEGIN
			
				SET @IdServicio = 0
				
				--VER SI ESTA EL SERVICIO DISPONIBLE
				SELECT @IdServicio = Min(ID) 
					FROM Diagramas_Servicios 
						WHERE Id_Diagrama = @IdDiagrama
							  AND NroServicio = @Servicio
				GROUP BY NroServicio
				HAVING NroServicio NOT IN (SELECT ds.NroServicio 
										   FROM PlanificacionDetallesCoches pdc 
										   INNER JOIN Diagramas_Servicios ds ON pdc.Id_Servicio = ds.Id 
										   WHERE Id_Planificacion = @Id_Planificacion AND
										   ds.Id_Diagrama = @IdDiagrama AND 
										   Fecha = @Fecha)
				
				IF @IdServicio > 0
					UPDATE PlanificacionDetallesCoches 
							SET Id_Servicio = @IdServicio 
						WHERE Id_Planificacion = @Id_Planificacion AND
							  Id_Coche = @IdCoche AND 
							  Fecha = @Fecha
				
				FETCH NEXT FROM curCoches INTO @IdCoche, @Servicio, @IdDiagrama
			END
			
			CLOSE curCoches
			DEALLOCATE curCoches
		END
		
		
		FETCH NEXT FROM curFechas INTO @Fecha
	END

	CLOSE curFechas
	DEALLOCATE curFechas

END
GO
PRINT N'Creando [dbo].[PlanillaVertical]...';


GO
CREATE PROCEDURE [dbo].[PlanillaVertical]
			@IdDiagrama INT = 236 
AS
BEGIN
 	DECLARE @ColumnasIda NVARCHAR(MAX) = ''
	DECLARE @SQLString NVARCHAR(MAX) = ''
	DECLARE @ColumnasIdaSelect NVARCHAR(MAX) = ''
	DECLARE @PrimerColumnaIda NVARCHAR(MAX) = ''
	DECLARE @PrimerColumnaVuelta NVARCHAR(MAX) = ''
	DECLARE @UltimaColumnaVuelta NVARCHAR(MAX) = ''
	DECLARE @ColumnasVuelta NVARCHAR(MAX) = ''
	DECLARE @ColumnasVueltasSelect NVARCHAR(MAX) = ''
	Declare @Id INT
	Declare @Id1 INT
	Declare @Id2 INT
	Declare @Hora1 NVarchar(MAX)
	Declare @Hora2 NVarchar(MAX)
	DECLARE @ParmDefinition nvarchar(MAX)
	DECLARE @retval int;  
	DECLARE @retvalHora nvarchar(500) 
	
	BEGIN TRY
		DELETE Vertical
 		DROP TABLE T1
		DROP TABLE T2
	END TRY	
	BEGIN CATCH
	END CATCH
	
	SELECT @ColumnasIda = COALESCE(@ColumnasIda + '[' + CAST(DescripcionCorta as VARCHAR(20)) + '],', ''),
		   @ColumnasIdaSelect = COALESCE(@ColumnasIdaSelect + 'T.[' + CAST(DescripcionCorta as VARCHAR(20)) + '],', '')
		FROM (SELECT DescripcionCorta, Numero FROM Secciones WHERE UserDel IS NULL And Id_TipoServicio = (SELECT Id_TipoServicio FROM Diagramas WHERE Id = @IdDiagrama and UserDel Is NULL) AND IdaVuelta = 'I') AS DSC
	ORDER BY Numero
	
	SET @ColumnasIdaSelect = LEFT(@ColumnasIdaSelect, LEN(@ColumnasIdaSelect) -1)
	SET @ColumnasIda = LEFT(@ColumnasIda, LEN(@ColumnasIda) -1)
   
	SET @SQLString = N'
		SELECT * INTO T1 
			FROM
			(SELECT Id = CONVERT(VARCHAR,dd.NroServicio) + CONVERT(VARCHAR,dd.Turno) + CONVERT(VARCHAR,dd.NroVuelta),
				    dd.NroServicio, dd.Turno, dd.NroVuelta, s.DescripcionCorta, Hora = (CASE WHEN Hora = ''2001-01-01 00:00'' THEN '' '' ELSE CONVERT(VARCHAR,RIGHT(''00'' + CONVERT(VARCHAR(2),DATEPART(HOUR,dd.Hora)), 2)+ '':'' + RIGHT(''00'' + CONVERT(VARCHAR(2),DATEPART(MINUTE,dd.Hora)), 2)) END)
				FROM Diagramas d
					INNER JOIN Diagramas_Detalle dd ON d.Id = dd.Id_Diagrama
					INNER JOIN Diagramas_Fecha df ON d.Id = df.Id_Diagrama 
					INNER JOIN Secciones s ON dd.Id_Seccion = s.Id
						WHERE
							d.Id = ' + CONVERT(VARCHAR, @IdDiagrama) + '
							AND s.IdaVuelta = ''I''
							AND s.UserDel IS NUll
							AND dd.UserDel IS NUll
							AND df.UserDel IS NUll
			 ) AS SourceTable
			PIVOT
			(
				MIN(Hora)
				FOR DescripcionCorta IN (' + @ColumnasIda + ')
			) AS PivotTable'

	EXECUTE sp_executesql @SQLString
	
	SELECT @PrimerColumnaIda = '[' + COLUMN_NAME + ']' FROM INFORMATION_SCHEMA.COLUMNS
							   WHERE TABLE_NAME = 'T1' AND ORDINAL_POSITION = '5'
	
	SELECT @ColumnasVuelta = COALESCE(@ColumnasVuelta + '[' + CAST(DescripcionCorta as VARCHAR(20)) + '],', ''),
		   @ColumnasVueltasSelect = COALESCE(@ColumnasVueltasSelect + 'TT.[' + CAST(DescripcionCorta as VARCHAR(20)) + ' ],', '')
		FROM (SELECT DescripcionCorta, Numero FROM Secciones WHERE UserDel IS NULL And Id_TipoServicio = (SELECT Id_TipoServicio FROM Diagramas WHERE Id = @IdDiagrama and UserDel Is NULL) AND IdaVuelta = 'V') AS DSC
	ORDER BY Numero

	SET @ColumnasVuelta = LEFT(@ColumnasVuelta, LEN(@ColumnasVuelta) -1)
	SET @ColumnasVueltasSelect = LEFT(@ColumnasVueltasSelect, LEN(@ColumnasVueltasSelect) -1)
 	
 	SET @SQLString = N'
		SELECT * INTO T2 
			FROM
			(SELECT Id = CONVERT(VARCHAR,dd.NroServicio) + CONVERT(VARCHAR,dd.Turno) + CONVERT(VARCHAR,dd.NroVuelta), 
				    dd.NroServicio, dd.Turno, dd.NroVuelta, s.DescripcionCorta, Hora = (CASE WHEN Hora = ''2001-01-01 00:00'' THEN '' '' ELSE CONVERT(VARCHAR,RIGHT(''00'' + CONVERT(VARCHAR(2),DATEPART(HOUR,dd.Hora)), 2)+ '':'' + RIGHT(''00'' + CONVERT(VARCHAR(2),DATEPART(MINUTE,dd.Hora)), 2)) END)
				FROM Diagramas d
					INNER JOIN Diagramas_Detalle dd ON d.Id = dd.Id_Diagrama
					INNER JOIN Diagramas_Fecha df ON d.Id = df.Id_Diagrama 
					INNER JOIN Secciones s ON dd.Id_Seccion = s.Id
						WHERE
							d.Id = ' + CONVERT(VARCHAR, @IdDiagrama) + '
							AND s.IdaVuelta = ''V''
							AND s.UserDel IS NUll
							AND dd.UserDel IS NUll
							AND df.UserDel IS NUll
			 ) AS SourceTable
			PIVOT
			(
				MIN(Hora)
				FOR DescripcionCorta IN (' + @ColumnasVuelta + ')
			) AS PivotTable'
		 
	EXECUTE sp_executesql @SQLString
	
	SELECT @PrimerColumnaVuelta = '[' + COLUMN_NAME + ']' FROM INFORMATION_SCHEMA.COLUMNS
							   WHERE TABLE_NAME = 'T2' AND ORDINAL_POSITION = '5'
							   
	DECLARE @CantCol Varchar(3)
	SELECT @CantCol = COUNT(*) FROM information_schema.columns WHERE table_name = 'T2' 
			  		   
	SELECT @UltimaColumnaVuelta = '[' + COLUMN_NAME + ']' FROM INFORMATION_SCHEMA.COLUMNS
							   WHERE TABLE_NAME = 'T2' AND ORDINAL_POSITION = @CantCol

	DECLARE cur CURSOR FOR	
		SELECT Id FROM T1
	OPEN cur
	FETCH NEXT FROM cur INTO @Id 
	WHILE @@FETCH_STATUS = 0
	BEGIN
		
		SELECT @SQLString = N'SELECT @retvalOUT = MIN(Id) FROM T1 WHERE ' + @PrimerColumnaIda + ' = (SELECT MIN(' + @PrimerColumnaIda + ') FROM T1 WHERE ' + @PrimerColumnaIda + ' <> '' ' + ''' AND Id NOT IN (SELECT Value FROM Vertical))'
		SET @ParmDefinition = N'@retvalOUT int OUTPUT';
		EXEC sp_executesql @SQLString, @ParmDefinition, @retvalOUT = @Id1 OUTPUT  
	
		IF @Id1 IS NULL
		BEGIN
			SELECT @SQLString = N'SELECT @retvalOUT = MIN(Id) FROM T1 WHERE Id NOT IN (SELECT Value FROM Vertical)'
			SET @ParmDefinition = N'@retvalOUT int OUTPUT';
			EXEC sp_executesql @SQLString, @ParmDefinition, @retvalOUT = @Id1 OUTPUT  
		END
		
		SELECT @SQLString = N'SELECT @retvalHoraOUT = T1.' + @PrimerColumnaIda + ' FROM T1 WHERE Id = ' + CONVERT(VARCHAR,@Id1)  
		SET @ParmDefinition = N'@retvalHoraOUT NVarchar(MAX) OUTPUT';
		EXEC sp_executesql @SQLString, @ParmDefinition, @retvalHoraOUT = @Hora1 OUTPUT  
		   
		SELECT @SQLString = N'SELECT @retvalOUT = MIN(Id) FROM T2 WHERE ' + @PrimerColumnaVuelta + ' = (SELECT MIN(' + @PrimerColumnaVuelta + ') FROM T2 WHERE ' + @PrimerColumnaVuelta + ' <> '' ' + ''' AND Id NOT IN (SELECT Value FROM Vertical))'
		SET @ParmDefinition = N'@retvalOUT int OUTPUT';
		EXEC sp_executesql @SQLString, @ParmDefinition, @retvalOUT = @Id2 OUTPUT  
	
		IF @Id2 IS NULL
		BEGIN
			SELECT @SQLString = N'SELECT @retvalOUT = MIN(Id) FROM T2 WHERE Id NOT IN (SELECT Value FROM Vertical)'
			SET @ParmDefinition = N'@retvalOUT int OUTPUT';
			EXEC sp_executesql @SQLString, @ParmDefinition, @retvalOUT = @Id2 OUTPUT  
		END
		
		SELECT @SQLString = N'SELECT @retvalHoraOUT = T2.' + @PrimerColumnaVuelta + ' FROM T2 WHERE Id = ' + CONVERT(VARCHAR,@Id2)
		SET @ParmDefinition = N'@retvalHoraOUT NVarchar(MAX) OUTPUT';
		EXEC sp_executesql @SQLString, @ParmDefinition, @retvalHoraOUT = @Hora2 OUTPUT  
		 
		IF @Id1 <> @Id2
			IF @Hora1 < @Hora2
			BEGIN
				INSERT INTO Vertical VALUES (@Id1)
			END
			ELSE
			BEGIN
				INSERT INTO Vertical VALUES (@Id2)
			END
		ELSE
			BEGIN
				IF @Id1 is not null
				 INSERT INTO Vertical VALUES (@Id1)
			END
		 
	FETCH NEXT FROM cur INTO @Id 
	END

	CLOSE cur 
	DEALLOCATE cur  
		
	SET @SQLString = N'
		SELECT 
			Servicio = ISNULL(T.NroServicio, TT.NroServicio),
			Turno = ISNULL(T.Turno, TT.Turno),
			Vuelta = ISNULL(T.NroVuelta, TT.NroVuelta), ' +
			@ColumnasIdaSelect + ', ' +
			'[//] = ''//'' ,' +
			@ColumnasVueltasSelect + ', 
			[T.Vuelta] = RTRIM(CONVERT(VARCHAR(5),(CASE WHEN RTRIM(LTRIM(T.' + @PrimerColumnaIda + ')) = '''' THEN '''' 
											 	   WHEN RTRIM(LTRIM(TT.' + @UltimaColumnaVuelta + ')) = '''' THEN '''' 
												   WHEN CONVERT(DATETIME, TT.' + @UltimaColumnaVuelta + ') > CONVERT(DATETIME, T.' + @PrimerColumnaIda + ') 
												   THEN CONVERT(DATETIME, TT.' + @UltimaColumnaVuelta + ') - CONVERT(DATETIME, T.' + @PrimerColumnaIda + ')
												   ELSE 
												   DATEADD(DD, 1,  CONVERT(DATETIME, TT.' + @UltimaColumnaVuelta + ')) - CONVERT(DATETIME, T.' + @PrimerColumnaIda + ')
												   END),114))
			FROM Vertical T3
			INNER JOIN T1 T ON T3.Value = T.ID
			INNER JOIN T2 TT ON T.ID = TT.ID 
		ORDER BY T3.ordering'
		
	print @SQLString
	EXECUTE sp_executesql @SQLString
		
	--DELETE Vertical
 				
	--DROP TABLE T1
	--DROP TABLE T2

END
GO
PRINT N'Creando [dbo].[Search]...';


GO

create Procedure [dbo].[Search]
	@SearchText VarChar(500)
	, @SearchInData Int = 0
As

Set NoCount On

Create Table #Tmp
(
	Name VarChar(MAX)
	, ObjectType VarChar(50)
	, Reference VarChar(MAX)
	, IsPK Int Null
)

-- Busca en stored procedures
Insert Into #Tmp
Select Distinct
	SO.Name
	, 'C - Stored Procedure' ObjectType
	, Null --SubString(SC.Text, CharIndex(SC.Text, @SearchText), 50)
	, Null
From
	SysObjects SO Inner Join SysComments SC
		On SO.Id = SC.Id
Where
	SC.Text Like '%' + @SearchText + '%'
	And SO.Type = 'P'


-- Busca en nombres de objetos
Insert Into #Tmp
Select Distinct
	SO.Name
	, 'A - Table' ObjectType
	, 'Select * From ' + SO.Name + ' (NoLock)'
	, Null
From
	SysObjects SO
Where
	SO.Name Like '%' + @SearchText + '%'
	And SO.Type = 'U'


-- Busca en columnas de tablas
Insert Into #Tmp
Select Distinct
	SO.Name + '.' + SC.Name Name
	, 'B - Column' ObjectType
	, 'Select Distinct ' + SC.Name + ' From ' + SO.Name + ' (NoLock) GO Select * From ' + SO.Name + ' (NoLock)'
	, (
		Select
			Count(1)
		From
			SysIndexes si Join SysObjects so2
				On si.Id = so2.Id
			Join SysObjects pk
				On si.Name = pk.Name
				And pk.parent_obj = si.Id
				And pk.xtype = 'PK'
			Join SysIndexkeys ik
				On si.Id = ik.Id
				And si.IndId = ik.IndId
			Join SysColumns sc2
				On ik.Id = sc2.Id
				And ik.ColId = sc2.ColId
		Where
			so2.Id = SO.Id
			And sc2.ColId = SC.ColId
	)
From
	SysObjects SO Inner Join SysColumns SC
		On SO.Id = SC.Id
Where
	SC.Name Like '%' + @SearchText + '%'
	And SO.Type = 'U'


-- Busca en parámetros de stored procedures
Insert Into #Tmp
Select Distinct
	SO.Name + '.' + SC.Name Name
	, 'D - Parameter' ObjectType
	, Null
	, Null
From
	SysObjects SO Inner Join SysColumns SC
		On SO.Id = SC.Id
Where
	SC.Name Like '%' + @SearchText + '%'
	And SO.Type = 'P'





-- Busca en datos
If @SearchInData = 1
Begin
	Declare @IsGUID Int
	Declare @TmpGUID UniqueIdentifier

	Begin Try
		Set @TmpGUID = Convert(UniqueIdentifier, @SearchText)
		Set @IsGUID = 1
	End Try
	Begin Catch
		Set @IsGUID = 0
	End Catch

	Declare @SQL VarChar(MAX)
	Declare @Reference VarChar(MAX)
	Declare @Condition VarChar(MAX)
	Declare @TableName VarChar(500)
	Declare @TableId Int
	Declare @ColumnName VarChar(500)
	Declare @ColumnDataType Int

	Declare curTables INSENSITIVE Cursor For
	Select
		so.Id
		, so.Name
	From
		SysObjects so
	Where
		so.Type = 'U'

	Open curTables
	Fetch Next From curTables Into @TableId, @TableName
	While @@Fetch_Status = 0
	Begin
		Declare curColumns INSENSITIVE Cursor For
		Select
			sc.Name
			, sc.xType
		From
			SysColumns sc
		Where
			sc.Id = @TableId

		Open curColumns
		Fetch Next From curColumns Into @ColumnName, @ColumnDataType
		While @@Fetch_Status = 0
		Begin
			Set @Condition = Null

			If @IsGUID = 1 And @ColumnDataType = 36 --UniqueIdentifier
			Begin
				Set @Condition = '''%' + @SearchText + '%'''
			End
	
			If @ColumnDataType = 167 --VarChar
			Begin
				Set @Condition = '''%' + @SearchText + '%'''
			End

			If @Condition Is Not Null
			Begin

				Declare @IsKey Int

				Select
					@IsKey = Count(1)
				From
					SysIndexes si Join SysObjects so
						On si.Id = so.Id
					Join SysObjects pk
						On si.Name = pk.Name
						And pk.parent_obj = si.Id
						And pk.xtype = 'PK'
					Join SysIndexkeys ik
						On si.Id = ik.Id
						And si.IndId = ik.IndId
					Join SysColumns sc
						On ik.Id = sc.Id
						And ik.ColId = sc.ColId
				Where
					so.Id = @TableId
					And sc.Name = @ColumnName


				Set @Reference = 'Select ' + @ColumnName + ', * From ' + @TableName + ' (NoLock) Where [' + @ColumnName + '] Like ' + @Condition
				Set @Reference = Replace(@Reference, '''', '''''')
				Set @SQL = 'Insert Into #Tmp Select Distinct ''' + @TableName + ''', ''E - Data'', ''' + @Reference + ''', ' + Convert(VarChar(10), @IsKey) + ' From ' + @TableName + ' (NoLock) Where [' + @ColumnName + '] Like ' + @Condition

				Execute (@Sql)
				--Print @SQL
			End

			Fetch Next From curColumns Into @ColumnName, @ColumnDataType
		End
		Close curColumns
		Deallocate curColumns

		Fetch Next From curTables Into @TableId, @TableName
	End
	Close curTables
	Deallocate curTables

End

-- Muestra el resultado
Select
	IsPK = Case IsPK
		When 0 Then 'N'
		When 1 Then 'Y'
		Else 'NA'
	End
	, Name
	, SubString(ObjectType, 5, 200) ObjectType
	, Reference
From
	#Tmp
Order By
	#Tmp.ObjectType
	, IsPK Desc
	, #Tmp.Name

Drop Table #Tmp
GO
PRINT N'Creando [dbo].[PlanificacionFechasDiagrama]...';


GO

CREATE TRIGGER [dbo].[PlanificacionFechasDiagrama]
   ON  [dbo].[Planificacion] 
   AFTER INSERT
AS 
BEGIN
	SET DATEFIRST 7; 
	SET NOCOUNT ON;

	DECLARE @TipoDia INT = 1 --Habil
	DECLARE @Desde DATE
	DECLARE @Hasta DATE
	DECLARE @Desde2 DATE
	DECLARE @Id_UnidadNegocio INT
	DECLARE @Id_TipoServicio INT = 1
	DECLARE @Id_Diagrama INT = 0
	DECLARE @Id INT = 0
	DECLARE @UserAdd INT 
	DECLARE @Columnas NVARCHAR(MAX) = ''
	DECLARE @Cant INT
	DECLARE @FechaNovedad DATE
	DECLARE @IdPersonal INT
	DECLARE @IdCoche INT
	DECLARE @Novedad Varchar(3)
	DECLARE @IdPlanificacionDetalle INT
	
	--ASIGNA DIAGRAMA
	---------------------------------------------------	
	SELECT @Id = Id, @Id_UnidadNegocio = Id_UnidadNegocio, @UserAdd = UserAdd, @Desde = FechaDesde, @Desde2 = FechaDesde, @Hasta = FechaHasta FROM inserted
	
	SELECT @Columnas =  COALESCE(@Columnas + CAST(Id AS VARCHAR(12)) + ',', '') FROM
						(SELECT ts.Id 
						 FROM TipoServicios ts 
						 INNER JOIN Ramales r ON ts.Id_Ramal = r.Id
						 INNER JOIN Lineas l ON r.Id_Linea = l.Id 
						 INNER JOIN UnidadNegocios c ON l.Id_UnidadNegocio = c.Id
						 WHERE c.Id = @Id_UnidadNegocio
							   AND c.UserDel IS NULL
							   AND r.UserDel IS NULL
							   AND l.UserDel IS NULL
							   AND ts.UserDel IS NULL) AS t
	
	WHILE LEN(@Columnas) > 0
	BEGIN
		
		SELECT @Id_TipoServicio = SUBSTRING(@Columnas, 1, CHARINDEX(',',@Columnas,0) - 1)
		
		WHILE @Desde2 <= @Hasta AND @Id_TipoServicio > 0
		BEGIN
		 
			SET @TipoDia = ISNULL((SELECT CASE WHEN Id > 0 THEN 4 ELSE 1 END
								   FROM Feriado WHERE Fecha = @Desde2),1)
			IF @TipoDia = 1
			BEGIN
				IF (DATEPART(dw,@Desde2) = 1) --Domingo
					SET @TipoDia = 3
				IF (DATEPART(dw,@Desde2) = 7) --Sabado
					SET @TipoDia = 2
			END
				
			SET @Id_Diagrama = ISNULL((SELECT Top 1 Id
									   FROM Diagramas 
									   WHERE Id_TipoDia = @TipoDia 
								 			 AND Id_TipoServicio = @Id_TipoServicio 
											 AND @Desde2 BETWEEN VigenciaDesde AND VigenciaHasta
											 And UserDel IS NULL
									   ORDER BY Id DESC),0) 
			
			SELECT @Cant = COUNT(Id) FROM Diagramas_Servicios WHERE Id_Diagrama = @Id_Diagrama AND UserDel IS NULL
			
			INSERT INTO PlanificacionServicios (Id_Planificacion, Id_TipoServicio, Id_Diagrama, Fecha, CantidadServicios, FechaAdd, UserAdd) 
				Values (@Id, @Id_TipoServicio, @Id_Diagrama, @Desde2, @Cant, GETDATE(), @UserAdd)
			 
			SET @Desde2 = DATEADD(d, 1, @Desde2)
		END
		
		SET @Columnas = RTRIM(LTRIM(SUBSTRING(@Columnas, CHARINDEX (',',@Columnas,0) + 1 ,500)))
		
		SET @Desde2 = @Desde
	END
	---------------------------------------------------	
	
	--GRABA TITULARES DE COCHES
	---------------------------------------------------	
	DECLARE Titulares_cur CURSOR FOR
		--SELECT cp.Id_Personal, c.Id, c.Id_TipoServicio
		--	FROM Planificacion p
		--	INNER JOIN Lineas l ON p.Id_UnidadNegocio = l.Id_UnidadNegocio
		--	INNER JOIN Ramales r ON r.Id_Linea = l.Id
		--	INNER JOIN TipoServicios ts ON ts.Id_Ramal = r.Id
		--	INNER JOIN Coches c ON ts.Id = c.Id_TipoServicio
		--	INNER JOIN Coches_Personal cp ON c.Id = cp.Id_Coche
		--	INNER JOIN Personal pe on cp.Id_Personal = pe.Id
		--	WHERE p.Id = @Id AND
		--		  pe.Id_Jerarquia = 1 AND
		--		  l.UserDel IS NULL AND
		--		  r.UserDel IS NULL AND
		--		  ts.UserDel IS NULL AND
		--		  c.UserDel IS NULL AND
		--		  cp.UserDel IS NULL
		SELECT cp.Id_Personal, c.Id coche,  c.Id_TipoServicio
			FROM Coches c 
			INNER JOIN Coches_Personal cp ON c.Id = cp.Id_Coche
			INNER JOIN Personal pe on cp.Id_Personal = pe.Id
			WHERE pe.Id_Jerarquia = 1 AND
				  c.UserDel IS NULL AND
				  cp.UserDel IS NULL and
				  c.Id_TipoServicio in (SELECT ts.Id 
						 FROM TipoServicios ts 
						 INNER JOIN Ramales r ON ts.Id_Ramal = r.Id
						 INNER JOIN Lineas l ON r.Id_Linea = l.Id 
						 INNER JOIN UnidadNegocios u ON l.Id_UnidadNegocio = u.Id
						 WHERE u.Id = @Id_UnidadNegocio
							   AND u.UserDel IS NULL
							   AND r.UserDel IS NULL
							   AND l.UserDel IS NULL
							   AND ts.UserDel IS NULL) 
	OPEN Titulares_cur

	FETCH NEXT FROM Titulares_cur INTO @IdPersonal, @IdCoche, @Id_TipoServicio

	WHILE @@FETCH_STATUS = 0
	BEGIN
				
		SET @Desde2 = @Desde
		WHILE @Desde2 <= @Hasta
		BEGIN
			 
			INSERT INTO PlanificacionDetalles (Id_Planificacion,Id_Personal,Id_Coche,Id_TipoServicio,Fecha,Novedad,FechaAdd,UserAdd)
				VALUES (@Id, @IdPersonal, @IdCoche, @Id_TipoServicio, @Desde2, '', GETDATE(), @UserAdd)
			
			SET @Desde2 = DATEADD(d, 1, @Desde2)
		END
	
		FETCH NEXT FROM Titulares_cur INTO @IdPersonal, @IdCoche, @Id_TipoServicio
	END 
	
	CLOSE Titulares_cur 
	DEALLOCATE Titulares_cur 
	---------------------------------------------------	
		 
	--SUPLENTES
	---------------------------------------------------	
	DECLARE Suplentes_cur CURSOR FOR
		SELECT  Id, 0, 0
			FROM Personal 
				WHERE LaboralId_UnidadNegocio = @Id_UnidadNegocio AND
					  Id_Jerarquia = 1 AND
					  Id NOT IN (SELECT DISTINCT(Id_Personal) FROM PlanificacionDetalles WHERE Id_Planificacion = @Id)
	OPEN Suplentes_cur

	FETCH NEXT FROM Suplentes_cur INTO @IdPersonal, @IdCoche, @Id_TipoServicio

	WHILE @@FETCH_STATUS = 0
	BEGIN
				
		SET @Desde2 = @Desde
		WHILE @Desde2 <= @Hasta
		BEGIN
			 
			INSERT INTO PlanificacionDetalles (Id_Planificacion,Id_Personal,Id_Coche,Id_TipoServicio,Fecha, Novedad,FechaAdd,UserAdd)
				VALUES (@Id, @IdPersonal, @IdCoche, @Id_TipoServicio, @Desde2, '', GETDATE(), @UserAdd)
			
			SET @Desde2 = DATEADD(d, 1, @Desde2)
		END
	
		FETCH NEXT FROM Suplentes_cur INTO @IdPersonal, @IdCoche, @Id_TipoServicio
	END 
	
	CLOSE Suplentes_cur 
	DEALLOCATE Suplentes_cur 
	---------------------------------------------------	
	
	--PASAJE DE NOVEDADES
	---------------------------------------------------	
	DECLARE Nov_cur CURSOR FOR
		SELECT p.Fecha, p.Id_Personal, n.Descripcion 
			FROM PersonalNovedades p INNER JOIN TipoNovedades n ON p.Id_TipoNovedad = n.Id 
				WHERE p.Fecha BETWEEN @Desde AND @Hasta
		
	OPEN Nov_cur

	FETCH NEXT FROM Nov_cur INTO @FechaNovedad, @IdPersonal, @Novedad

	WHILE @@FETCH_STATUS = 0
	BEGIN
		UPDATE PlanificacionDetalles SET Novedad = @Novedad
			WHERE Id_Planificacion = @Id AND 
				  Fecha = @FechaNovedad And
				  Id_Personal = @IdPersonal
	
		FETCH NEXT FROM Nov_cur INTO @FechaNovedad, @IdPersonal, @Novedad
	END
	
	CLOSE Nov_cur 
	DEALLOCATE Nov_cur 
	---------------------------------------------------	
	
	--INICIALIZA PLANIFICACIONDETALLESCOCHES
	---------------------------------------------------	
	EXEC PlanificacionDetallesCochesDiaria @Id
	---------------------------------------------------	
	
END
GO
PRINT N'Creando [dbo].[PlanificacionFrancoSegunCoche]...';


GO
CREATE PROCEDURE [dbo].[PlanificacionFrancoSegunCoche]
	@IdPlanificacion INT
AS
BEGIN
	DECLARE @Fecha DATE 
	DECLARE @IdCoche INT 
	DECLARE @IdPersonal INT  
	DECLARE @Turno INT  
	
	--INICIALIZA TODO
	UPDATE PlanificacionDetalles
		SET Id_Servicio = 0, Novedad = '', Id_Novedad = 0
	WHERE Id_Planificacion = @IdPlanificacion

	--PASA FRANCOS
	UPDATE PlanificacionDetalles
		SET Id_Servicio = 0, Novedad = 'F', Id_Novedad = 1
	FROM PlanificacionDetallesCoches pdc
		INNER JOIN PlanificacionDetalles pd ON pdc.Id_Planificacion = pd.Id_Planificacion AND pdc.Id_Coche = pd.Id_Coche AND pdc.Fecha = pd.Fecha
	WHERE pdc.Id_Planificacion = @IdPlanificacion AND 
		  pdc.Id_Servicio = 0 AND 
		  (pd.Id_Novedad is null or pd.Id_Novedad = 0)
		  
	--ASIGNA SERVICIOS FIJOS
	DECLARE curFijos CURSOR FOR
		SELECT Fecha, Id_Coche, Id_Personal, LaboralTurnoFijo
			FROM PlanificacionDetalles pd
			INNER JOIN Personal p ON pd.Id_Personal = p.Id
				WHERE pd.Id_Planificacion = @IdPlanificacion AND
					  pd.Id_Novedad = 0 AND
					  p.LaboralTurnoFijo < 4

	OPEN curFijos
		FETCH NEXT FROM curFijos INTO @Fecha, @IdCoche, @IdPersonal, @Turno 

		WHILE @@FETCH_STATUS = 0
		BEGIN

			EXEC AsignaServicio @IdPlanificacion, @Fecha, @IdCoche, @IdPersonal, @Turno
			
			FETCH NEXT FROM curFijos INTO @Fecha, @IdCoche, @IdPersonal, @Turno 
		END
			
	CLOSE curFijos 
	DEALLOCATE curFijos
		 
	--TRASPASA NOVEDADES
	EXEC PlanificacionNovedades @IdPlanificacion
	
	--ROTACION DE CHOFERES
	EXEC PlanificacionRotacionChoferes @IdPlanificacion
END
GO
PRINT N'Creando [dbo].[PlanificacionRotacion]...';


GO
CREATE PROCEDURE [dbo].[PlanificacionRotacion]
	@Id_Planificacion INT
	 
AS
BEGIN
	SET DATEFIRST 7; 
	
	DECLARE @IdTipoServicio INT
	DECLARE @IdUN INT
	DECLARE @Desde DATE
	DECLARE @Desde2 DATE
	DECLARE @Hasta DATE
	DECLARE @Fecha DATE
	DECLARE @TipoDia INT  
	DECLARE @ListCochesDuplicado NVARCHAR(MAX) = ''
	DECLARE @ListCochesHabil NVARCHAR(MAX) = ''
	DECLARE @ListCochesSabado NVARCHAR(MAX) = ''
	DECLARE @ListCochesFeriado NVARCHAR(MAX) = ''
	DECLARE @IdDiagrama INT
	DECLARE @ContHabil INT = 0
	DECLARE @ContSabado INT = 0 
	DECLARE @ContFeriado INT = 0
	DECLARE @RotaHabil INT 
	DECLARE @RotaSabado INT 
	DECLARE @RotaFeriado INT 
	DECLARE @CantServicios INT = 0
	DECLARE @CountServicios INT = 0
	DECLARE @IdServicio INT = 0
	DECLARE @IdPlanificacionAnterior INT = 0
	DECLARE @IdCocheAnteriorHabil INT = 0
	DECLARE @IdCocheAnteriorSabado INT = 0
	DECLARE @IdCocheAnteriorFeriado INT = 0
	
	
	--BORRA LOS SERVICIOS ACTUALES
	UPDATE PlanificacionDetallesCoches SET Id_Servicio = 0 WHERE Id_Planificacion = @Id_Planificacion
 	
 	--BORRA HISTORIAL
 	DELETE PlanificacionHistorial WHERE Id_Planificacion = @Id_Planificacion
 	
 	--MARCA LOS SERVICIOS FIJOS
	EXEC PlanificacionRotacionServicioFijo @Id_Planificacion
 	
 	--CARGA VARIABLES
 	SELECT @Desde = FechaDesde, @Desde2 = FechaDesde, @Hasta = FechaHasta, @IdUN = Id_UnidadNegocio
 		FROM Planificacion 
 			WHERE Id = @Id_Planificacion

	--SETEO DE DIAS DE ROTACION
	SELECT @RotaHabil = RotaHabil, @RotaSabado = RotaSabado, @RotaFeriado = RotaFeriado
		FROM UnidadNegocios_Configuracion 
			WHERE Id_UnidadNegocio = @IdUN
	
	--BUSCA ULTIMA PLANIFICACION CONFIRMADA PARA ROTACION
	SELECT @IdPlanificacionAnterior = Id 
		FROM Planificacion  
			WHERE Id_UnidadNegocio = @IdUN AND 
				  FechaHasta < @Desde AND 
				  UserDel IS NULL AND 
				  FechaConfirmacion IS NOT NULL
	ORDER BY FechaDesde, Id
 			
	--POR CADA TIPO DE SERVICIO
	DECLARE curTipoServicio CURSOR FOR
		SELECT DISTINCT(Id_TipoServicio)
			FROM PlanificacionDetallesCoches 
				WHERE Id_Planificacion = @Id_Planificacion  
			
	OPEN curTipoServicio
	FETCH NEXT FROM curTipoServicio INTO @IdTipoServicio 

	WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @ListCochesDuplicado = ''
		SET @ListCochesHabil = ''
		SET @ListCochesSabado = ''
		SET @ListCochesFeriado = ''
		
		SET @ContHabil = 0
		SET @ContSabado = 0
		SET @ContFeriado = 0
		
		SELECT @ListCochesHabil = COALESCE(@ListCochesHabil + CONVERT(VARCHAR, Id_Coche) + ',' , '')
		FROM (SELECT DISTINCT(Id_Coche) Id_Coche, Interno
			  FROM PlanificacionDetallesCoches pdc
			  INNER JOIN Coches c ON pdc.Id_Coche = c.Id
			  WHERE pdc.Id_Planificacion = @Id_Planificacion AND 
					pdc.Id_TipoServicio = @IdTipoServicio AND
			        c.HabilServicioFijo = 0  
		      ) AS T ORDER BY Interno DESC
 		SET @ListCochesHabil = LEFT(@ListCochesHabil, LEN(@ListCochesHabil) - 1)
 		
 		SELECT @ListCochesSabado = COALESCE(@ListCochesSabado + CONVERT(VARCHAR, Id_Coche) + ',' , '')
		FROM (SELECT DISTINCT(Id_Coche) Id_Coche, Interno
			  FROM PlanificacionDetallesCoches pdc
			  INNER JOIN Coches c ON pdc.Id_Coche = c.Id
			  WHERE pdc.Id_Planificacion = @Id_Planificacion AND 
					pdc.Id_TipoServicio = @IdTipoServicio AND
			        c.SabadoServicioFijo = 0  
		      ) AS T ORDER BY Interno DESC
 		SET @ListCochesSabado = LEFT(@ListCochesSabado, LEN(@ListCochesSabado) - 1)
 		
 		SELECT @ListCochesFeriado = COALESCE(@ListCochesFeriado + CONVERT(VARCHAR, Id_Coche) + ',' , '')
		FROM (SELECT DISTINCT(Id_Coche) Id_Coche, Interno
			  FROM PlanificacionDetallesCoches pdc
			  INNER JOIN Coches c ON pdc.Id_Coche = c.Id
			  WHERE pdc.Id_Planificacion = @Id_Planificacion AND 
					pdc.Id_TipoServicio = @IdTipoServicio AND
			        c.FeriadoServicioFijo = 0  
		      ) AS T ORDER BY Interno DESC
 		SET @ListCochesFeriado = LEFT(@ListCochesFeriado, LEN(@ListCochesFeriado) - 1)
		
		--SELECCIONAR DE LA ULTIMA PLANIFICACION
		SELECT @IdCocheAnteriorHabil = Id_Coche 
			FROM PlanificacionHistorial
				WHERE Id_Planificacion = @Id_Planificacion AND
					  Id_TipoServicio = @IdTipoServicio AND 
					  Tipo_Dia = 1
					  
		SELECT @IdCocheAnteriorSabado = Id_Coche 
			FROM PlanificacionHistorial
				WHERE Id_Planificacion = @Id_Planificacion AND
					  Id_TipoServicio = @IdTipoServicio AND 
					  Tipo_Dia = 2
					  
		SELECT @IdCocheAnteriorFeriado = Id_Coche 
			FROM PlanificacionHistorial
				WHERE Id_Planificacion = @Id_Planificacion AND
					  Id_TipoServicio = @IdTipoServicio AND 
					  Tipo_Dia = 4
					  	  
		--ACOMODAR LISTA SEGUN ULTIMO ID COCHE
		IF @IdCocheAnteriorHabil > 0
			SET @ListCochesHabil = SUBSTRING(@ListCochesHabil, CHARINDEX(CONVERT(VARCHAR, @IdCocheAnteriorHabil) + ',', @ListCochesHabil), LEN(@ListCochesHabil)) + ',' + SUBSTRING(@ListCochesHabil, 0,  CHARINDEX(',', @ListCochesHabil)) + ',' + SUBSTRING(@ListCochesHabil, 0, CHARINDEX(CONVERT(VARCHAR, @IdCocheAnteriorHabil) + ',', @ListCochesHabil) -1)
		IF @IdCocheAnteriorSabado > 0
			SET @ListCochesSabado = SUBSTRING(@ListCochesSabado, CHARINDEX(CONVERT(VARCHAR, @IdCocheAnteriorSabado) + ',', @ListCochesSabado), LEN(@ListCochesSabado)) + ',' + SUBSTRING(@ListCochesSabado, 0,  CHARINDEX(',', @ListCochesSabado)) + ',' + SUBSTRING(@ListCochesSabado, 0, CHARINDEX(CONVERT(VARCHAR, @IdCocheAnteriorSabado) + ',', @ListCochesSabado) -1)
		IF @IdCocheAnteriorFeriado > 0
			SET @ListCochesFeriado = SUBSTRING(@ListCochesFeriado, CHARINDEX(CONVERT(VARCHAR, @IdCocheAnteriorFeriado) + ',', @ListCochesFeriado), LEN(@ListCochesFeriado)) + ',' + SUBSTRING(@ListCochesFeriado, 0,  CHARINDEX(',', @ListCochesFeriado)) + ',' + SUBSTRING(@ListCochesFeriado, 0, CHARINDEX(CONVERT(VARCHAR, @IdCocheAnteriorFeriado) + ',', @ListCochesFeriado) -1)

		--POR CADA FECHA
		SET @Desde = @Desde2
		WHILE @Desde <= @Hasta
		BEGIN
			SET @Fecha = @Desde
			
			SELECT @IdDiagrama = Id_Diagrama 
 				FROM PlanificacionDetallesCoches 
 					WHERE Id_Planificacion = @Id_Planificacion AND
 						  Id_TipoServicio = @IdTipoServicio AND
 						  Fecha = @Fecha 
 							
			SET @TipoDia = ISNULL((SELECT CASE WHEN Id > 0 THEN 4 ELSE 1 END
						   FROM Feriado WHERE Fecha = @Fecha), 1)
			IF @TipoDia = 1
			BEGIN
				IF (DATEPART(dw, @Fecha) = 1) --Domingo
					SET @TipoDia = 3
				IF (DATEPART(dw, @Fecha) = 7) --Sabado
					SET @TipoDia = 2
			END
						
			IF @TipoDia = 1 
			BEGIN
				IF @ContHabil >= @RotaHabil
				BEGIN
					SET @ListCochesHabil = SUBSTRING(@ListCochesHabil, CHARINDEX(',', @ListCochesHabil) + 1 , LEN(@ListCochesHabil)) + ',' + SUBSTRING(@ListCochesHabil, 0,  CHARINDEX(',', @ListCochesHabil)) 
					SET @ListCochesHabil = SUBSTRING(@ListCochesHabil, CHARINDEX(',', @ListCochesHabil) + 1 , LEN(@ListCochesHabil)) + ',' + SUBSTRING(@ListCochesHabil, 0,  CHARINDEX(',', @ListCochesHabil)) 
					SET @ContHabil = 0
				END
				SET @ListCochesDuplicado = @ListCochesHabil
				SET @ContHabil = @ContHabil + 1
				
			END
			
			IF @TipoDia = 2 --OR @TipoDia = 3 
			BEGIN
				--SELECT @CantServicios = COUNT(DISTINCT(NroServicio))
				--		FROM Diagramas_Servicios 
				--			WHERE Id_Diagrama = @IdDiagrama
							
				IF @ContSabado >= @RotaSabado
				BEGIN
					--SET @ListCochesSabado = SUBSTRING(@ListCochesSabado, CHARINDEX(',', @ListCochesSabado) + 1 , LEN(@ListCochesSabado)) + ',' + SUBSTRING(@ListCochesSabado, 0,  CHARINDEX(',', @ListCochesSabado)) 
					--SET @ListCochesSabado = SUBSTRING(@ListCochesSabado, CHARINDEX(',', @ListCochesSabado) + 1 , LEN(@ListCochesSabado)) + ',' + SUBSTRING(@ListCochesSabado, 0,  CHARINDEX(',', @ListCochesSabado)) 
					SET @CountServicios = 0
					
					WHILE @CountServicios < @CantServicios
					BEGIN	
						SET @ListCochesSabado = SUBSTRING(@ListCochesSabado, CHARINDEX(',', @ListCochesSabado) + 1 , LEN(@ListCochesSabado)) + ',' + SUBSTRING(@ListCochesSabado, 0,  CHARINDEX(',', @ListCochesSabado)) 
						
						SET @CountServicios = @CountServicios + 1
					END
					
					SET @ContSabado = 0
				END
				SELECT @CantServicios = COUNT(DISTINCT(NroServicio))
						FROM Diagramas_Servicios 
							WHERE Id_Diagrama = @IdDiagrama AND
								  UserDel IS NULL
							
				SET @ContSabado = @ContSabado + 1
				SET @ListCochesDuplicado = @ListCochesSabado
			END
			
			IF @TipoDia = 3
			BEGIN
				SET @CountServicios = 0
					
				WHILE @CountServicios < @CantServicios
				BEGIN	
					SET @ListCochesSabado = SUBSTRING(@ListCochesSabado, CHARINDEX(',', @ListCochesSabado) + 1 , LEN(@ListCochesSabado)) + ',' + SUBSTRING(@ListCochesSabado, 0,  CHARINDEX(',', @ListCochesSabado)) 
					
					SET @CountServicios = @CountServicios + 1
				END
				
				SELECT @CantServicios = COUNT(DISTINCT(NroServicio))
						FROM Diagramas_Servicios 
							WHERE Id_Diagrama = @IdDiagrama AND
							      UserDel IS NULL
							
				SET @ContSabado = @ContSabado + 1	
				SET @ListCochesDuplicado = @ListCochesSabado
			END
			
			IF @TipoDia = 4 
			BEGIN
				--SUMA UN DIA PARA CUANDO EL FERIADO ES DIA DE SEMANA
				IF ((DATEPART(dw, @Fecha) <> 1) OR (DATEPART(dw, @Fecha) <> 7))
					SET @ContHabil = @ContHabil + 1
					
				IF @ContFeriado >= @RotaFeriado
				BEGIN
					SET @ListCochesFeriado = SUBSTRING(@ListCochesFeriado, CHARINDEX(',', @ListCochesFeriado) + 1 , LEN(@ListCochesFeriado)) + ',' + SUBSTRING(@ListCochesFeriado, 0,  CHARINDEX(',', @ListCochesFeriado)) 
					SET @ListCochesFeriado = SUBSTRING(@ListCochesFeriado, CHARINDEX(',', @ListCochesFeriado) + 1 , LEN(@ListCochesFeriado)) + ',' + SUBSTRING(@ListCochesFeriado, 0,  CHARINDEX(',', @ListCochesFeriado)) 
					 SET @ContFeriado = 0
				END
				SET @ListCochesDuplicado = @ListCochesFeriado
				SET @ContFeriado = @ContFeriado + 1
				
			END
			
			DECLARE curServicios CURSOR FOR
 				SELECT Min(ID) Id 
					FROM Diagramas_Servicios 
						WHERE Id_Diagrama = @IdDiagrama AND
							  UserDel IS NULL
				GROUP BY NroServicio
				HAVING NroServicio NOT IN (SELECT ds.NroServicio 
										   FROM PlanificacionDetallesCoches pdc 
										   INNER JOIN Diagramas_Servicios ds ON pdc.Id_Servicio = ds.Id 
										   WHERE Id_Planificacion = @Id_Planificacion AND
												 ds.Id_Diagrama = @IdDiagrama AND 
												 Fecha = @Fecha AND
												 ds.UserDel IS NULL)
			OPEN curServicios
			FETCH NEXT FROM curServicios INTO @IdServicio  
			
			WHILE @@FETCH_STATUS = 0
			BEGIN
			
				UPDATE PlanificacionDetallesCoches 
					SET Id_Servicio = @IdServicio 
				WHERE Id_Planificacion = @Id_Planificacion AND
					  Id_Coche = SUBSTRING(@ListCochesDuplicado, 0,  CHARINDEX(',', @ListCochesDuplicado)) AND 
					  Fecha = @Fecha
				
				SET @ListCochesDuplicado = SUBSTRING(@ListCochesDuplicado, CHARINDEX(',', @ListCochesDuplicado) + 1 , LEN(@ListCochesDuplicado)) + ',' + SUBSTRING(@ListCochesDuplicado, 0,  CHARINDEX(',', @ListCochesDuplicado))
				 
				FETCH NEXT FROM curServicios INTO @IdServicio
			END
			
			CLOSE curServicios 
			DEALLOCATE curServicios
			
			SET @Desde = DATEADD(d, 1, @Desde)
		END
		
		SET @ListCochesHabil = SUBSTRING(@ListCochesHabil, CHARINDEX(',', @ListCochesHabil) + 1 , LEN(@ListCochesHabil)) + ',' + SUBSTRING(@ListCochesHabil, 0,  CHARINDEX(',', @ListCochesHabil)) 
		SET @ListCochesHabil = SUBSTRING(@ListCochesHabil, CHARINDEX(',', @ListCochesHabil) + 1 , LEN(@ListCochesHabil)) + ',' + SUBSTRING(@ListCochesHabil, 0,  CHARINDEX(',', @ListCochesHabil)) 
		
		SET @ListCochesSabado = SUBSTRING(@ListCochesSabado, CHARINDEX(',', @ListCochesSabado) + 1 , LEN(@ListCochesSabado)) + ',' + SUBSTRING(@ListCochesSabado, 0,  CHARINDEX(',', @ListCochesSabado)) 
		SET @ListCochesSabado = SUBSTRING(@ListCochesSabado, CHARINDEX(',', @ListCochesSabado) + 1 , LEN(@ListCochesSabado)) + ',' + SUBSTRING(@ListCochesSabado, 0,  CHARINDEX(',', @ListCochesSabado)) 
		
		SET @ListCochesFeriado = SUBSTRING(@ListCochesFeriado, CHARINDEX(',', @ListCochesFeriado) + 1 , LEN(@ListCochesFeriado)) + ',' + SUBSTRING(@ListCochesFeriado, 0,  CHARINDEX(',', @ListCochesFeriado)) 
		SET @ListCochesFeriado = SUBSTRING(@ListCochesFeriado, CHARINDEX(',', @ListCochesFeriado) + 1 , LEN(@ListCochesFeriado)) + ',' + SUBSTRING(@ListCochesFeriado, 0,  CHARINDEX(',', @ListCochesFeriado)) 
		
		INSERT INTO PlanificacionHistorial VALUES (@Id_Planificacion, @IdTipoServicio, 1,  SUBSTRING(@ListCochesHabil, 0,  CHARINDEX(',', @ListCochesHabil)))
		INSERT INTO PlanificacionHistorial VALUES (@Id_Planificacion, @IdTipoServicio, 2,  SUBSTRING(@ListCochesSabado, 0,  CHARINDEX(',', @ListCochesSabado)))
		INSERT INTO PlanificacionHistorial VALUES (@Id_Planificacion, @IdTipoServicio, 4,  SUBSTRING(@ListCochesFeriado, 0,  CHARINDEX(',', @ListCochesFeriado)))
		 
		
		FETCH NEXT FROM curTipoServicio INTO @IdTipoServicio
	END
		
	CLOSE curTipoServicio 
	DEALLOCATE curTipoServicio
	
END
GO
PRINT N'Creando [dbo].[SistemaLog].[Accion].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'1-Entra, 0-Sale', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SistemaLog', @level2type = N'COLUMN', @level2name = N'Accion';


GO
PRINT N'Creando [dbo].[EGWR_DiagramasDiario].[MS_DiagramPane1]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "df"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 126
               Right = 236
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "d"
            Begin Extent = 
               Top = 6
               Left = 274
               Bottom = 126
               Right = 472
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ds"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 246
               Right = 236
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ts"
            Begin Extent = 
               Top = 126
               Left = 274
               Bottom = 246
               Right = 472
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "r"
            Begin Extent = 
               Top = 246
               Left = 38
               Bottom = 366
               Right = 236
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "l"
            Begin Extent = 
               Top = 246
               Left = 274
               Bottom = 366
               Right = 472
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "e"
            Begin Extent = 
               Top = 366
               Left = 38
               Bottom = 486
               Right = 236
            End
            DisplayFlags = 280
            TopColumn = 0
         End', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'EGWR_DiagramasDiario';


GO
PRINT N'Creando [dbo].[EGWR_DiagramasDiario].[MS_DiagramPane2]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'
         Begin Table = "p"
            Begin Extent = 
               Top = 486
               Left = 38
               Bottom = 606
               Right = 249
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'EGWR_DiagramasDiario';


GO
PRINT N'Creando [dbo].[EGWR_DiagramasDiario].[MS_DiagramPaneCount]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'EGWR_DiagramasDiario';


GO
PRINT N'Comprobando los datos existentes con las restricciones recién creadas';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[SeguridadGruposObjetos] WITH CHECK CHECK CONSTRAINT [FK_Seguridad_Grupos_Objetos_Seguridad_Grupos];

ALTER TABLE [dbo].[SeguridadGruposObjetos] WITH CHECK CHECK CONSTRAINT [FK_SeguridadGruposObjetos_SeguridadObjetos];

ALTER TABLE [dbo].[SeguridadUsuarios] WITH CHECK CHECK CONSTRAINT [FK_Seguridad_Usuarios_Seguridad_Grupos];

ALTER TABLE [dbo].[SeguridadUsuariosCentrosCostos] WITH CHECK CHECK CONSTRAINT [FK_SeguridadUsuariosCentrosCostos_SeguridadUsuarios];

ALTER TABLE [dbo].[SeguridadUsuariosEmpresas] WITH CHECK CHECK CONSTRAINT [FK_Seguridad_Usuarios_Empresas_Seguridad_Usuarios];

ALTER TABLE [dbo].[TalonariosComprobantes] WITH CHECK CHECK CONSTRAINT [FK_TalonariosComprobantes_Empresas];

ALTER TABLE [dbo].[TalonariosComprobantes] WITH CHECK CHECK CONSTRAINT [FK_TalonariosComprobantes_TipoComprobante];

ALTER TABLE [dbo].[TalonariosComprobantesDetalle] WITH CHECK CHECK CONSTRAINT [FK_TalonariosComprobantesDetalle_TalonariosComprobantes];

ALTER TABLE [dbo].[Cajas] WITH CHECK CHECK CONSTRAINT [FK_Cajas_Especies];

ALTER TABLE [dbo].[Cajas] WITH CHECK CHECK CONSTRAINT [FK_Cajas_Sucursales];

ALTER TABLE [dbo].[Cuadros] WITH CHECK CHECK CONSTRAINT [FK_Cuadros_Servicios];

ALTER TABLE [dbo].[Diagramas] WITH CHECK CHECK CONSTRAINT [FK_Diagramas_TipoServicios];

ALTER TABLE [dbo].[Diagramas_Detalle] WITH CHECK CHECK CONSTRAINT [FK_Diagrama_Detalle_Diagramas];

ALTER TABLE [dbo].[Diagramas_Detalle] WITH CHECK CHECK CONSTRAINT [FK_Diagrama_Detalle_Secciones];

ALTER TABLE [dbo].[Diagramas_Fecha] WITH CHECK CHECK CONSTRAINT [FK_Diagrama_Fecha_Diagramas];

ALTER TABLE [dbo].[Lineas] WITH CHECK CHECK CONSTRAINT [FK_Lineas_Empresas];

ALTER TABLE [dbo].[Personal] WITH CHECK CHECK CONSTRAINT [FK_Personal_Empresas];

ALTER TABLE [dbo].[Ramales] WITH CHECK CHECK CONSTRAINT [FK_Ramales_Lineas];

ALTER TABLE [dbo].[Secciones] WITH CHECK CHECK CONSTRAINT [FK_Secciones_TipoServicios];

ALTER TABLE [dbo].[TipoServicios] WITH CHECK CHECK CONSTRAINT [FK_Servicios_Ramales];


GO
PRINT N'Actualización completada.';


GO
