USE [dev]
GO
/****** Object:  Trigger [tr_u_corrigirQuantidadeCarrinho]    Script Date: 07/12/2016 20:00:43 ******/
DROP TRIGGER [dbo].[tr_u_corrigirQuantidadeCarrinho]
GO
/****** Object:  Trigger [tr_i_corrigirQuantidadeCarrinho]    Script Date: 07/12/2016 20:00:43 ******/
DROP TRIGGER [dbo].[tr_i_corrigirQuantidadeCarrinho]
GO
/****** Object:  Trigger [t_calcularPrecoCarrinho]    Script Date: 07/12/2016 20:00:43 ******/
DROP TRIGGER [dbo].[t_calcularPrecoCarrinho]
GO
/****** Object:  StoredProcedure [dbo].[sp_calcularPrecoCarrinho]    Script Date: 07/12/2016 20:00:43 ******/
DROP PROCEDURE [dbo].[sp_calcularPrecoCarrinho]
GO
ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [FK__Usuario__aspnet___09A971A2]
GO
ALTER TABLE [dbo].[Telefone] DROP CONSTRAINT [FK__Telefone__Usuari__0C85DE4D]
GO
ALTER TABLE [dbo].[Mensagem] DROP CONSTRAINT [FK__Mensagem__Usuari__10566F31]
GO
ALTER TABLE [dbo].[Mensagem] DROP CONSTRAINT [FK__Mensagem__Usuari__0F624AF8]
GO
ALTER TABLE [dbo].[marcadorProduto] DROP CONSTRAINT [FK__marcadorP__Produ__236943A5]
GO
ALTER TABLE [dbo].[marcadorProduto] DROP CONSTRAINT [FK__marcadorP__Marca__245D67DE]
GO
ALTER TABLE [dbo].[itemEncomenda] DROP CONSTRAINT [FK__itemEncomenda__5E8A0973]
GO
ALTER TABLE [dbo].[itemEncomenda] DROP CONSTRAINT [FK__itemEncom__Encom__5D95E53A]
GO
ALTER TABLE [dbo].[itemCarrinho] DROP CONSTRAINT [FK__itemCarrinho__30C33EC3]
GO
ALTER TABLE [dbo].[itemCarrinho] DROP CONSTRAINT [FK__itemCarri__Carri__2FCF1A8A]
GO
ALTER TABLE [dbo].[Item] DROP CONSTRAINT [FK__Item__Tamanho_id__29221CFB]
GO
ALTER TABLE [dbo].[Item] DROP CONSTRAINT [FK__Item__Produto_id__2A164134]
GO
ALTER TABLE [dbo].[EnderecoUsuario] DROP CONSTRAINT [FK__EnderecoU__usuar__151B244E]
GO
ALTER TABLE [dbo].[EnderecoUsuario] DROP CONSTRAINT [FK__EnderecoU__local__160F4887]
GO
ALTER TABLE [dbo].[Encomenda] DROP CONSTRAINT [FK__Encomenda__Usuar__59C55456]
GO
ALTER TABLE [dbo].[Encomenda] DROP CONSTRAINT [FK__Encomenda__Statu__5BAD9CC8]
GO
ALTER TABLE [dbo].[Encomenda] DROP CONSTRAINT [FK__Encomenda__local__5AB9788F]
GO
ALTER TABLE [dbo].[Carrinho] DROP CONSTRAINT [FK__Carrinho__Usuari__2CF2ADDF]
GO
ALTER TABLE [dbo].[aspnet_UsersInRoles] DROP CONSTRAINT [FK__aspnet_Us__UserI__5CD6CB2B]
GO
ALTER TABLE [dbo].[aspnet_UsersInRoles] DROP CONSTRAINT [FK__aspnet_Us__RoleI__5DCAEF64]
GO
ALTER TABLE [dbo].[aspnet_Users] DROP CONSTRAINT [FK__aspnet_Us__Appli__2A4B4B5E]
GO
ALTER TABLE [dbo].[aspnet_Roles] DROP CONSTRAINT [FK__aspnet_Ro__Appli__59063A47]
GO
ALTER TABLE [dbo].[aspnet_Profile] DROP CONSTRAINT [FK__aspnet_Pr__UserI__4F7CD00D]
GO
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser] DROP CONSTRAINT [FK__aspnet_Pe__UserI__76969D2E]
GO
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser] DROP CONSTRAINT [FK__aspnet_Pe__PathI__75A278F5]
GO
ALTER TABLE [dbo].[aspnet_PersonalizationAllUsers] DROP CONSTRAINT [FK__aspnet_Pe__PathI__71D1E811]
GO
ALTER TABLE [dbo].[aspnet_Paths] DROP CONSTRAINT [FK__aspnet_Pa__Appli__6C190EBB]
GO
ALTER TABLE [dbo].[aspnet_Membership] DROP CONSTRAINT [FK__aspnet_Me__UserI__3B75D760]
GO
ALTER TABLE [dbo].[aspnet_Membership] DROP CONSTRAINT [FK__aspnet_Me__Appli__3A81B327]
GO
ALTER TABLE [dbo].[aspnet_Users] DROP CONSTRAINT [DF__aspnet_Us__IsAno__2D27B809]
GO
ALTER TABLE [dbo].[aspnet_Users] DROP CONSTRAINT [DF__aspnet_Us__Mobil__2C3393D0]
GO
ALTER TABLE [dbo].[aspnet_Users] DROP CONSTRAINT [DF__aspnet_Us__UserI__2B3F6F97]
GO
ALTER TABLE [dbo].[aspnet_Roles] DROP CONSTRAINT [DF__aspnet_Ro__RoleI__59FA5E80]
GO
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser] DROP CONSTRAINT [DF__aspnet_Perso__Id__74AE54BC]
GO
ALTER TABLE [dbo].[aspnet_Paths] DROP CONSTRAINT [DF__aspnet_Pa__PathI__6D0D32F4]
GO
ALTER TABLE [dbo].[aspnet_Membership] DROP CONSTRAINT [DF__aspnet_Me__Passw__3C69FB99]
GO
ALTER TABLE [dbo].[aspnet_Applications] DROP CONSTRAINT [DF__aspnet_Ap__Appli__276EDEB3]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 07/12/2016 20:00:43 ******/
DROP TABLE [dbo].[Usuario]
GO
/****** Object:  Table [dbo].[Telefone]    Script Date: 07/12/2016 20:00:43 ******/
DROP TABLE [dbo].[Telefone]
GO
/****** Object:  Table [dbo].[Tamanho]    Script Date: 07/12/2016 20:00:43 ******/
DROP TABLE [dbo].[Tamanho]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 07/12/2016 20:00:43 ******/
DROP TABLE [dbo].[Status]
GO
/****** Object:  Table [dbo].[Produto]    Script Date: 07/12/2016 20:00:43 ******/
DROP TABLE [dbo].[Produto]
GO
/****** Object:  Table [dbo].[Mensagem]    Script Date: 07/12/2016 20:00:43 ******/
DROP TABLE [dbo].[Mensagem]
GO
/****** Object:  Table [dbo].[marcadorProduto]    Script Date: 07/12/2016 20:00:43 ******/
DROP TABLE [dbo].[marcadorProduto]
GO
/****** Object:  Table [dbo].[Marcador]    Script Date: 07/12/2016 20:00:43 ******/
DROP TABLE [dbo].[Marcador]
GO
/****** Object:  Table [dbo].[localEntrega]    Script Date: 07/12/2016 20:00:43 ******/
DROP TABLE [dbo].[localEntrega]
GO
/****** Object:  Table [dbo].[itemEncomenda]    Script Date: 07/12/2016 20:00:43 ******/
DROP TABLE [dbo].[itemEncomenda]
GO
/****** Object:  Table [dbo].[itemCarrinho]    Script Date: 07/12/2016 20:00:43 ******/
DROP TABLE [dbo].[itemCarrinho]
GO
/****** Object:  Table [dbo].[Item]    Script Date: 07/12/2016 20:00:43 ******/
DROP TABLE [dbo].[Item]
GO
/****** Object:  Table [dbo].[EnderecoUsuario]    Script Date: 07/12/2016 20:00:43 ******/
DROP TABLE [dbo].[EnderecoUsuario]
GO
/****** Object:  Table [dbo].[Encomenda]    Script Date: 07/12/2016 20:00:43 ******/
DROP TABLE [dbo].[Encomenda]
GO
/****** Object:  Table [dbo].[Carrinho]    Script Date: 07/12/2016 20:00:43 ******/
DROP TABLE [dbo].[Carrinho]
GO
/****** Object:  Table [dbo].[aspnet_WebEvent_Events]    Script Date: 07/12/2016 20:00:43 ******/
DROP TABLE [dbo].[aspnet_WebEvent_Events]
GO
/****** Object:  Table [dbo].[aspnet_UsersInRoles]    Script Date: 07/12/2016 20:00:43 ******/
DROP TABLE [dbo].[aspnet_UsersInRoles]
GO
/****** Object:  Table [dbo].[aspnet_Users]    Script Date: 07/12/2016 20:00:43 ******/
DROP TABLE [dbo].[aspnet_Users]
GO
/****** Object:  Table [dbo].[aspnet_SchemaVersions]    Script Date: 07/12/2016 20:00:43 ******/
DROP TABLE [dbo].[aspnet_SchemaVersions]
GO
/****** Object:  Table [dbo].[aspnet_Roles]    Script Date: 07/12/2016 20:00:43 ******/
DROP TABLE [dbo].[aspnet_Roles]
GO
/****** Object:  Table [dbo].[aspnet_Profile]    Script Date: 07/12/2016 20:00:43 ******/
DROP TABLE [dbo].[aspnet_Profile]
GO
/****** Object:  Table [dbo].[aspnet_PersonalizationPerUser]    Script Date: 07/12/2016 20:00:43 ******/
DROP TABLE [dbo].[aspnet_PersonalizationPerUser]
GO
/****** Object:  Table [dbo].[aspnet_PersonalizationAllUsers]    Script Date: 07/12/2016 20:00:43 ******/
DROP TABLE [dbo].[aspnet_PersonalizationAllUsers]
GO
/****** Object:  Table [dbo].[aspnet_Paths]    Script Date: 07/12/2016 20:00:43 ******/
DROP TABLE [dbo].[aspnet_Paths]
GO
/****** Object:  Table [dbo].[aspnet_Membership]    Script Date: 07/12/2016 20:00:43 ******/
DROP TABLE [dbo].[aspnet_Membership]
GO
/****** Object:  Table [dbo].[aspnet_Applications]    Script Date: 07/12/2016 20:00:43 ******/
DROP TABLE [dbo].[aspnet_Applications]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_corrigirQuantidade]    Script Date: 07/12/2016 20:00:43 ******/
DROP FUNCTION [dbo].[fn_corrigirQuantidade]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_corrigirQuantidade]    Script Date: 07/12/2016 20:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Retorna 0 se a quantidade for menor que 0
CREATE FUNCTION [dbo].[fn_corrigirQuantidade] (@quantidade int)
RETURNS INT
AS
BEGIN
	IF (@quantidade >= 0)
		RETURN @quantidade
	RETURN 0
END

GO
/****** Object:  Table [dbo].[aspnet_Applications]    Script Date: 07/12/2016 20:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_Applications](
	[ApplicationName] [nvarchar](256) NOT NULL,
	[LoweredApplicationName] [nvarchar](256) NOT NULL,
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](256) NULL,
PRIMARY KEY NONCLUSTERED 
(
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[LoweredApplicationName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[ApplicationName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[aspnet_Membership]    Script Date: 07/12/2016 20:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_Membership](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[PasswordFormat] [int] NOT NULL,
	[PasswordSalt] [nvarchar](128) NOT NULL,
	[MobilePIN] [nvarchar](16) NULL,
	[Email] [nvarchar](256) NULL,
	[LoweredEmail] [nvarchar](256) NULL,
	[PasswordQuestion] [nvarchar](256) NULL,
	[PasswordAnswer] [nvarchar](128) NULL,
	[IsApproved] [bit] NOT NULL,
	[IsLockedOut] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastLoginDate] [datetime] NOT NULL,
	[LastPasswordChangedDate] [datetime] NOT NULL,
	[LastLockoutDate] [datetime] NOT NULL,
	[FailedPasswordAttemptCount] [int] NOT NULL,
	[FailedPasswordAttemptWindowStart] [datetime] NOT NULL,
	[FailedPasswordAnswerAttemptCount] [int] NOT NULL,
	[FailedPasswordAnswerAttemptWindowStart] [datetime] NOT NULL,
	[Comment] [ntext] NULL,
PRIMARY KEY NONCLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[aspnet_Paths]    Script Date: 07/12/2016 20:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_Paths](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[PathId] [uniqueidentifier] NOT NULL,
	[Path] [nvarchar](256) NOT NULL,
	[LoweredPath] [nvarchar](256) NOT NULL,
PRIMARY KEY NONCLUSTERED 
(
	[PathId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[aspnet_PersonalizationAllUsers]    Script Date: 07/12/2016 20:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_PersonalizationAllUsers](
	[PathId] [uniqueidentifier] NOT NULL,
	[PageSettings] [image] NOT NULL,
	[LastUpdatedDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PathId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[aspnet_PersonalizationPerUser]    Script Date: 07/12/2016 20:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_PersonalizationPerUser](
	[Id] [uniqueidentifier] NOT NULL,
	[PathId] [uniqueidentifier] NULL,
	[UserId] [uniqueidentifier] NULL,
	[PageSettings] [image] NOT NULL,
	[LastUpdatedDate] [datetime] NOT NULL,
PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[aspnet_Profile]    Script Date: 07/12/2016 20:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_Profile](
	[UserId] [uniqueidentifier] NOT NULL,
	[PropertyNames] [ntext] NOT NULL,
	[PropertyValuesString] [ntext] NOT NULL,
	[PropertyValuesBinary] [image] NOT NULL,
	[LastUpdatedDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[aspnet_Roles]    Script Date: 07/12/2016 20:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_Roles](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
	[RoleName] [nvarchar](256) NOT NULL,
	[LoweredRoleName] [nvarchar](256) NOT NULL,
	[Description] [nvarchar](256) NULL,
PRIMARY KEY NONCLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[aspnet_SchemaVersions]    Script Date: 07/12/2016 20:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_SchemaVersions](
	[Feature] [nvarchar](128) NOT NULL,
	[CompatibleSchemaVersion] [nvarchar](128) NOT NULL,
	[IsCurrentVersion] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Feature] ASC,
	[CompatibleSchemaVersion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[aspnet_Users]    Script Date: 07/12/2016 20:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_Users](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[LoweredUserName] [nvarchar](256) NOT NULL,
	[MobileAlias] [nvarchar](16) NULL,
	[IsAnonymous] [bit] NOT NULL,
	[LastActivityDate] [datetime] NOT NULL,
PRIMARY KEY NONCLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[aspnet_UsersInRoles]    Script Date: 07/12/2016 20:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_UsersInRoles](
	[UserId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[aspnet_WebEvent_Events]    Script Date: 07/12/2016 20:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[aspnet_WebEvent_Events](
	[EventId] [char](32) NOT NULL,
	[EventTimeUtc] [datetime] NOT NULL,
	[EventTime] [datetime] NOT NULL,
	[EventType] [nvarchar](256) NOT NULL,
	[EventSequence] [decimal](19, 0) NOT NULL,
	[EventOccurrence] [decimal](19, 0) NOT NULL,
	[EventCode] [int] NOT NULL,
	[EventDetailCode] [int] NOT NULL,
	[Message] [nvarchar](1024) NULL,
	[ApplicationPath] [nvarchar](256) NULL,
	[ApplicationVirtualPath] [nvarchar](256) NULL,
	[MachineName] [nvarchar](256) NOT NULL,
	[RequestUrl] [nvarchar](1024) NULL,
	[ExceptionType] [nvarchar](256) NULL,
	[Details] [ntext] NULL,
PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Carrinho]    Script Date: 07/12/2016 20:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carrinho](
	[Usuario_id] [int] NOT NULL,
	[precoTotal] [numeric](10, 2) NOT NULL,
	[subTotal] [numeric](10, 2) NULL,
	[desconto] [numeric](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Usuario_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Encomenda]    Script Date: 07/12/2016 20:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Encomenda](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Usuario_id] [int] NOT NULL,
	[precoTotal] [numeric](10, 2) NOT NULL,
	[localEntrega_id] [int] NOT NULL,
	[Status_id] [int] NOT NULL,
	[dataEntrega] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EnderecoUsuario]    Script Date: 07/12/2016 20:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EnderecoUsuario](
	[usuario_id] [int] NOT NULL,
	[localentrega_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[usuario_id] ASC,
	[localentrega_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Item]    Script Date: 07/12/2016 20:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item](
	[Tamanho_id] [int] NOT NULL,
	[Produto_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Tamanho_id] ASC,
	[Produto_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[itemCarrinho]    Script Date: 07/12/2016 20:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[itemCarrinho](
	[Carrinho_id] [int] NOT NULL,
	[item_tamanho_id] [int] NOT NULL,
	[item_Produto_id] [int] NOT NULL,
	[quantidade] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Carrinho_id] ASC,
	[item_tamanho_id] ASC,
	[item_Produto_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[itemEncomenda]    Script Date: 07/12/2016 20:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[itemEncomenda](
	[Encomenda_id] [int] NOT NULL,
	[item_tamanho_id] [int] NOT NULL,
	[item_Produto_id] [int] NOT NULL,
	[precoUnitario] [numeric](10, 2) NOT NULL,
	[quantidade] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[localEntrega]    Script Date: 07/12/2016 20:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[localEntrega](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[rua] [varchar](50) NOT NULL,
	[numero] [int] NOT NULL,
	[bairro] [varchar](30) NOT NULL,
	[complemento] [varchar](50) NOT NULL,
	[descricao] [varchar](50) NOT NULL,
	[cep] [varchar](8) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Marcador]    Script Date: 07/12/2016 20:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Marcador](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descricao] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[marcadorProduto]    Script Date: 07/12/2016 20:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[marcadorProduto](
	[Produto_id] [int] NOT NULL,
	[Marcador_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Marcador_id] ASC,
	[Produto_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Mensagem]    Script Date: 07/12/2016 20:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mensagem](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[data] [datetime] NOT NULL,
	[corpo] [text] NOT NULL,
	[visualizada] [bit] NOT NULL,
	[UsuarioDestinatario_id] [int] NOT NULL,
	[UsuarioRemetente_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Produto]    Script Date: 07/12/2016 20:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Produto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descricao] [varchar](20) NOT NULL,
	[imagem] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Status]    Script Date: 07/12/2016 20:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Status](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descricao] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tamanho]    Script Date: 07/12/2016 20:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tamanho](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descricao] [varchar](20) NOT NULL,
	[precoUnitario] [numeric](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Telefone]    Script Date: 07/12/2016 20:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Telefone](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[numero] [varchar](11) NOT NULL,
	[Usuario_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 07/12/2016 20:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[aspnet_id] [uniqueidentifier] NULL,
	[nome] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[aspnet_Applications] ADD  DEFAULT (newid()) FOR [ApplicationId]
GO
ALTER TABLE [dbo].[aspnet_Membership] ADD  DEFAULT ((0)) FOR [PasswordFormat]
GO
ALTER TABLE [dbo].[aspnet_Paths] ADD  DEFAULT (newid()) FOR [PathId]
GO
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser] ADD  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[aspnet_Roles] ADD  DEFAULT (newid()) FOR [RoleId]
GO
ALTER TABLE [dbo].[aspnet_Users] ADD  DEFAULT (newid()) FOR [UserId]
GO
ALTER TABLE [dbo].[aspnet_Users] ADD  DEFAULT (NULL) FOR [MobileAlias]
GO
ALTER TABLE [dbo].[aspnet_Users] ADD  DEFAULT ((0)) FOR [IsAnonymous]
GO
ALTER TABLE [dbo].[aspnet_Membership]  WITH CHECK ADD FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[aspnet_Applications] ([ApplicationId])
GO
ALTER TABLE [dbo].[aspnet_Membership]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[aspnet_Users] ([UserId])
GO
ALTER TABLE [dbo].[aspnet_Paths]  WITH CHECK ADD FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[aspnet_Applications] ([ApplicationId])
GO
ALTER TABLE [dbo].[aspnet_PersonalizationAllUsers]  WITH CHECK ADD FOREIGN KEY([PathId])
REFERENCES [dbo].[aspnet_Paths] ([PathId])
GO
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser]  WITH CHECK ADD FOREIGN KEY([PathId])
REFERENCES [dbo].[aspnet_Paths] ([PathId])
GO
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[aspnet_Users] ([UserId])
GO
ALTER TABLE [dbo].[aspnet_Profile]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[aspnet_Users] ([UserId])
GO
ALTER TABLE [dbo].[aspnet_Roles]  WITH CHECK ADD FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[aspnet_Applications] ([ApplicationId])
GO
ALTER TABLE [dbo].[aspnet_Users]  WITH CHECK ADD FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[aspnet_Applications] ([ApplicationId])
GO
ALTER TABLE [dbo].[aspnet_UsersInRoles]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[aspnet_Roles] ([RoleId])
GO
ALTER TABLE [dbo].[aspnet_UsersInRoles]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[aspnet_Users] ([UserId])
GO
ALTER TABLE [dbo].[Carrinho]  WITH CHECK ADD FOREIGN KEY([Usuario_id])
REFERENCES [dbo].[Usuario] ([id])
GO
ALTER TABLE [dbo].[Encomenda]  WITH CHECK ADD FOREIGN KEY([localEntrega_id])
REFERENCES [dbo].[localEntrega] ([id])
GO
ALTER TABLE [dbo].[Encomenda]  WITH CHECK ADD FOREIGN KEY([Status_id])
REFERENCES [dbo].[Status] ([id])
GO
ALTER TABLE [dbo].[Encomenda]  WITH CHECK ADD FOREIGN KEY([Usuario_id])
REFERENCES [dbo].[Usuario] ([id])
GO
ALTER TABLE [dbo].[EnderecoUsuario]  WITH CHECK ADD FOREIGN KEY([localentrega_id])
REFERENCES [dbo].[localEntrega] ([id])
GO
ALTER TABLE [dbo].[EnderecoUsuario]  WITH CHECK ADD FOREIGN KEY([usuario_id])
REFERENCES [dbo].[Usuario] ([id])
GO
ALTER TABLE [dbo].[Item]  WITH CHECK ADD FOREIGN KEY([Produto_id])
REFERENCES [dbo].[Produto] ([id])
GO
ALTER TABLE [dbo].[Item]  WITH CHECK ADD FOREIGN KEY([Tamanho_id])
REFERENCES [dbo].[Tamanho] ([id])
GO
ALTER TABLE [dbo].[itemCarrinho]  WITH CHECK ADD FOREIGN KEY([Carrinho_id])
REFERENCES [dbo].[Carrinho] ([Usuario_id])
GO
ALTER TABLE [dbo].[itemCarrinho]  WITH CHECK ADD FOREIGN KEY([item_tamanho_id], [item_Produto_id])
REFERENCES [dbo].[Item] ([Tamanho_id], [Produto_id])
GO
ALTER TABLE [dbo].[itemEncomenda]  WITH CHECK ADD FOREIGN KEY([Encomenda_id])
REFERENCES [dbo].[Encomenda] ([id])
GO
ALTER TABLE [dbo].[itemEncomenda]  WITH CHECK ADD FOREIGN KEY([item_tamanho_id], [item_Produto_id])
REFERENCES [dbo].[Item] ([Tamanho_id], [Produto_id])
GO
ALTER TABLE [dbo].[marcadorProduto]  WITH CHECK ADD FOREIGN KEY([Marcador_id])
REFERENCES [dbo].[Marcador] ([id])
GO
ALTER TABLE [dbo].[marcadorProduto]  WITH CHECK ADD FOREIGN KEY([Produto_id])
REFERENCES [dbo].[Produto] ([id])
GO
ALTER TABLE [dbo].[Mensagem]  WITH CHECK ADD FOREIGN KEY([UsuarioDestinatario_id])
REFERENCES [dbo].[Usuario] ([id])
GO
ALTER TABLE [dbo].[Mensagem]  WITH CHECK ADD FOREIGN KEY([UsuarioRemetente_id])
REFERENCES [dbo].[Usuario] ([id])
GO
ALTER TABLE [dbo].[Telefone]  WITH CHECK ADD FOREIGN KEY([Usuario_id])
REFERENCES [dbo].[Usuario] ([id])
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD FOREIGN KEY([aspnet_id])
REFERENCES [dbo].[aspnet_Users] ([UserId])
GO
/****** Object:  StoredProcedure [dbo].[sp_calcularPrecoCarrinho]    Script Date: 07/12/2016 20:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_calcularPrecoCarrinho]
	@idCarrinho INT
AS
BEGIN
	DECLARE 
		@precoTotal NUMERIC(10,2),
		@subTotal NUMERIC(10,2),
		@desconto NUMERIC(10,2),
		@quantidadeDeItens INT
	
	SET @desconto = 0

	-- Sub total sem descontos.	
	SELECT @subTotal = 
		(SELECT SUM(ic.quantidade * t.precoUnitario) 'subTotal' 
			FROM itemCarrinho ic 
			INNER JOIN Tamanho t 
			ON t.id = ic.item_tamanho_id 
			WHERE ic.Carrinho_id = @idCarrinho)

	-- Quantidade total de itens
	SELECT @quantidadeDeItens = 
		SUM(quantidade) 
		FROM ItemCarrinho 
		WHERE Carrinho_id = @idCarrinho

	-- Calculo de descontos

	-- Se itens for menor que 50, desconto absoluto.
	IF(@quantidadeDeItens < 50)
	BEGIN
		SET @desconto = @quantidadeDeItens/3
	END

	-- Itens maior que 50 e menor que 100 itens, desconto de 20%
	ELSE IF (@quantidadeDeItens >= 50 AND @quantidadeDeItens < 100)
	BEGIN
		SET @desconto = @subTotal * 0.2
	END

	-- Itens maior que 100 de 40%
	ELSE
	BEGIN
		SET @desconto = @subTotal * 0.4
	END

	SET @precoTotal = @subTotal - @desconto

	UPDATE Carrinho SET precoTotal = @precoTotal, desconto = @desconto, subTotal = @subtotal WHERE Usuario_id = @idCarrinho
END
GO
/****** Object:  Trigger [dbo].[t_calcularPrecoCarrinho]    Script Date: 07/12/2016 20:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[t_calcularPrecoCarrinho] ON [dbo].[itemCarrinho]
AFTER INSERT, UPDATE
AS
	DECLARE @id INT
	SELECT @id = carrinho_id FROM INSERTED
	
	EXEC sp_calcularPrecoCarrinho @id

GO
ALTER TABLE [dbo].[itemCarrinho] ENABLE TRIGGER [t_calcularPrecoCarrinho]
GO
/****** Object:  Trigger [dbo].[tr_i_corrigirQuantidadeCarrinho]    Script Date: 07/12/2016 20:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Triggers
CREATE TRIGGER [dbo].[tr_i_corrigirQuantidadeCarrinho] ON [dbo].[itemCarrinho]
INSTEAD OF INSERT
AS
	DECLARE @quantidade INT
	DECLARE @idCarrinho INT
	DECLARE @idTamanho INT
	DECLARE @idProduto INT
	
	SELECT @quantidade = dbo.fn_corrigirQuantidade(quantidade),
		@idCarrinho = Carrinho_id,
		@idTamanho = item_tamanho_id,
		@idProduto = item_Produto_id
	FROM inserted

	INSERT INTO itemCarrinho(Carrinho_id, item_Produto_id, item_tamanho_id, quantidade) VALUES (@idCarrinho, @idProduto, @idTamanho, @quantidade)

GO
ALTER TABLE [dbo].[itemCarrinho] ENABLE TRIGGER [tr_i_corrigirQuantidadeCarrinho]
GO
/****** Object:  Trigger [dbo].[tr_u_corrigirQuantidadeCarrinho]    Script Date: 07/12/2016 20:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[tr_u_corrigirQuantidadeCarrinho] ON [dbo].[itemCarrinho]
INSTEAD OF UPDATE
AS
	DECLARE @quantidade INT
	DECLARE @idCarrinho INT
	DECLARE @idTamanho INT
	DECLARE @idProduto INT
	
	SELECT @quantidade = dbo.fn_corrigirQuantidade(quantidade),
		@idCarrinho = Carrinho_id,
		@idTamanho = item_tamanho_id,
		@idProduto = item_Produto_id
	FROM inserted

	UPDATE itemCarrinho SET quantidade = @quantidade WHERE Carrinho_id = @idCarrinho AND item_Produto_id = @idProduto AND item_tamanho_id = @idTamanho

GO
ALTER TABLE [dbo].[itemCarrinho] ENABLE TRIGGER [tr_u_corrigirQuantidadeCarrinho]
GO
