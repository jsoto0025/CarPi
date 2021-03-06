
CREATE TABLE [dbo].[Position](
	[PositionId] [int] IDENTITY(1,1) NOT NULL,
	[RouteId] [int] NOT NULL,
	[Latitude] [float] NOT NULL,
	[Longitude] [float] NOT NULL,
	CONSTRAINT [PK_Position] PRIMARY KEY CLUSTERED 
(
	[PositionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE TABLE [dbo].[Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE [dbo].[RoleByUser](
	[RoleByUserId] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
  CONSTRAINT [PK_RoleByUser] PRIMARY KEY CLUSTERED 
(
	[RoleByUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[Route](
	[RouteId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Route] PRIMARY KEY CLUSTERED 
(
	[RouteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE [dbo].[Subscription](
	[SubscriptionId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RouteId] [int] NOT NULL,
 CONSTRAINT [PK_Subscription] PRIMARY KEY CLUSTERED 
(
	[SubscriptionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](40) NOT NULL,
  CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET IDENTITY_INSERT [dbo].[Position] ON 

INSERT [dbo].[Position] ([PositionId], [RouteId], [Latitude], [Longitude]) VALUES (1, 1, 6.1937122, -75.5773487)
INSERT [dbo].[Position] ([PositionId], [RouteId], [Latitude], [Longitude]) VALUES (3, 1, 6.2004108, -75.5732648)
INSERT [dbo].[Position] ([PositionId], [RouteId], [Latitude], [Longitude]) VALUES (5, 1, 6.2049641, -75.5722164)
INSERT [dbo].[Position] ([PositionId], [RouteId], [Latitude], [Longitude]) VALUES (6, 2, 6.1937122, -75.5773487)
INSERT [dbo].[Position] ([PositionId], [RouteId], [Latitude], [Longitude]) VALUES (7, 2, 6.2004108, -75.5732648)
INSERT [dbo].[Position] ([PositionId], [RouteId], [Latitude], [Longitude]) VALUES (8, 2, 6.2049641, -75.5722164)
INSERT [dbo].[Position] ([PositionId], [RouteId], [Latitude], [Longitude]) VALUES (10, 2, 6.201632, -75.567719)
SET IDENTITY_INSERT [dbo].[Position] OFF

SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleId], [Name]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([RoleId], [Name]) VALUES (2, N'User')
SET IDENTITY_INSERT [dbo].[Role] OFF

SET IDENTITY_INSERT [dbo].[RoleByUser] ON 

INSERT [dbo].[RoleByUser] ([RoleByUserId], [RoleId], [UserId]) VALUES (2, 2, 2)
INSERT [dbo].[RoleByUser] ([RoleByUserId], [RoleId], [UserId]) VALUES (4, 1, 7)
INSERT [dbo].[RoleByUser] ([RoleByUserId], [RoleId], [UserId]) VALUES (7, 1, 1)
INSERT [dbo].[RoleByUser] ([RoleByUserId], [RoleId], [UserId]) VALUES (8, 2, 1)

SET IDENTITY_INSERT [dbo].[RoleByUser] OFF

SET IDENTITY_INSERT [dbo].[Route] ON 

INSERT [dbo].[Route] ([RouteId], [Name]) VALUES (1, N'Trabajo-Casa')
INSERT [dbo].[Route] ([RouteId], [Name]) VALUES (2, N'Casa-Trabajo')

SET IDENTITY_INSERT [dbo].[Route] OFF

SET IDENTITY_INSERT [dbo].[Subscription] ON 

INSERT [dbo].[Subscription] ([SubscriptionId], [UserId], [RouteId]) VALUES (17, 1, 1)
INSERT [dbo].[Subscription] ([SubscriptionId], [UserId], [RouteId]) VALUES (18, 1, 2)

SET IDENTITY_INSERT [dbo].[Subscription] OFF

SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [Name], [Password]) VALUES (1, N'Mark', N'7c222fb2927d828af22f592134e8932480637c0d')
INSERT [dbo].[User] ([UserId], [Name], [Password]) VALUES (2, N'Luisa', N'7c222fb2927d828af22f592134e8932480637c0d')
INSERT [dbo].[User] ([UserId], [Name], [Password]) VALUES (7, N'rick', N'7110eda4d09e062aa5e4a390b0a572ac0d2c0220')

SET IDENTITY_INSERT [dbo].[User] OFF

ALTER TABLE [dbo].[Position]  WITH CHECK ADD  CONSTRAINT [FK_Position_Route] FOREIGN KEY([RouteId])
REFERENCES [dbo].[Route] ([RouteId])
GO

ALTER TABLE [dbo].[Position] CHECK CONSTRAINT [FK_Position_Route]
GO
ALTER TABLE [dbo].[RoleByUser]  WITH CHECK ADD  CONSTRAINT [FK_RoleByUser_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO

ALTER TABLE [dbo].[RoleByUser] CHECK CONSTRAINT [FK_RoleByUser_Role]
GO

ALTER TABLE [dbo].[RoleByUser]  WITH CHECK ADD  CONSTRAINT [FK_RoleByUser_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO

ALTER TABLE [dbo].[RoleByUser] CHECK CONSTRAINT [FK_RoleByUser_User]
GO

ALTER TABLE [dbo].[Subscription]  WITH CHECK ADD  CONSTRAINT [FK_Subscription_Route] FOREIGN KEY([RouteId])
REFERENCES [dbo].[Route] ([RouteId])
GO

ALTER TABLE [dbo].[Subscription] CHECK CONSTRAINT [FK_Subscription_Route]
GO

ALTER TABLE [dbo].[Subscription]  WITH CHECK ADD  CONSTRAINT [FK_Subscription_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO

ALTER TABLE [dbo].[Subscription] CHECK CONSTRAINT [FK_Subscription_User]
GO

