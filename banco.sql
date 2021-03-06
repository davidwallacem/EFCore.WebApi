USE [HeroiApp]
GO
/****** Object:  Table [dbo].[Armas]    Script Date: 19/11/2020 07:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Armas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NULL,
	[HeroiId] [int] NOT NULL,
 CONSTRAINT [PK_Armas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Batalhas]    Script Date: 19/11/2020 07:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Batalhas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NULL,
	[Descricao] [nvarchar](max) NULL,
	[DtInicio] [datetime2](7) NOT NULL,
	[DtFim] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Batalhas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HeroiBatalha]    Script Date: 19/11/2020 07:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HeroiBatalha](
	[HeroiId] [int] NOT NULL,
	[BatalhaId] [int] NOT NULL,
 CONSTRAINT [PK_HeroiBatalha] PRIMARY KEY CLUSTERED 
(
	[BatalhaId] ASC,
	[HeroiId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Herois]    Script Date: 19/11/2020 07:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Herois](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](15) NULL,
 CONSTRAINT [PK_Herois] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IdentidadeSecreta]    Script Date: 19/11/2020 07:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentidadeSecreta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NomeReal] [nvarchar](max) NULL,
	[HeroiId] [int] NOT NULL,
 CONSTRAINT [PK_IdentidadeSecreta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Armas]  WITH CHECK ADD  CONSTRAINT [FK_Armas_Herois_HeroiId] FOREIGN KEY([HeroiId])
REFERENCES [dbo].[Herois] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Armas] CHECK CONSTRAINT [FK_Armas_Herois_HeroiId]
GO
ALTER TABLE [dbo].[HeroiBatalha]  WITH CHECK ADD  CONSTRAINT [FK_HeroiBatalha_Batalhas_BatalhaId] FOREIGN KEY([BatalhaId])
REFERENCES [dbo].[Batalhas] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HeroiBatalha] CHECK CONSTRAINT [FK_HeroiBatalha_Batalhas_BatalhaId]
GO
ALTER TABLE [dbo].[HeroiBatalha]  WITH CHECK ADD  CONSTRAINT [FK_HeroiBatalha_Herois_HeroiId] FOREIGN KEY([HeroiId])
REFERENCES [dbo].[Herois] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HeroiBatalha] CHECK CONSTRAINT [FK_HeroiBatalha_Herois_HeroiId]
GO
ALTER TABLE [dbo].[IdentidadeSecreta]  WITH CHECK ADD  CONSTRAINT [FK_IdentidadeSecreta_Herois_HeroiId] FOREIGN KEY([HeroiId])
REFERENCES [dbo].[Herois] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[IdentidadeSecreta] CHECK CONSTRAINT [FK_IdentidadeSecreta_Herois_HeroiId]
GO
