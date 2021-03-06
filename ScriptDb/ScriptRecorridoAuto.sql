USE [DataBaseRecorridoAuto]
GO
/****** Object:  Table [dbo].[RecorridoHyundai30]    Script Date: 12/07/2018 13:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecorridoHyundai30](
	[IdRecorrido] [int] NOT NULL,
	[LugarSalida] [varchar](50) NOT NULL,
	[FechaSalida] [date] NOT NULL,
	[HoraSalida] [time](7) NOT NULL,
	[TanqueSalida(Km)] [int] NOT NULL,
	[KilometrajeSalida(Km)] [int] NOT NULL,
	[Ruta] [varchar](50) NULL,
	[LugarLlegada] [varchar](50) NOT NULL,
	[FechaLlegada] [date] NOT NULL,
	[HoraLlegada] [time](7) NOT NULL,
	[TanqueLlegada(Km)] [int] NOT NULL,
	[KilometrajeLlegada(Km)] [int] NOT NULL,
 CONSTRAINT [PK_RecorridoHyundai30] PRIMARY KEY CLUSTERED 
(
	[IdRecorrido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
