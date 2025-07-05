# SessiaApi

USE [SessiaCarService]
GO
SET IDENTITY_INSERT [dbo].[Parts] ON 

INSERT [dbo].[Parts] ([Id], [Name], [Quantity], [Price]) VALUES (1, N'Фильтр салона', 10, CAST(1200.00 AS Decimal(18, 2)))
INSERT [dbo].[Parts] ([Id], [Name], [Quantity], [Price]) VALUES (2, N'Компрессор кондиционера', 2, CAST(15000.00 AS Decimal(18, 2)))
INSERT [dbo].[Parts] ([Id], [Name], [Quantity], [Price]) VALUES (3, N'Нош', 100, CAST(100.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Parts] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [Name]) VALUES (1, N'Мастер')
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (2, N'Менеджер')
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (3, N'Клиент')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [UserName], [PasswordHash], [RoleId]) VALUES (1, N'manager1', N'hash1', 1)
INSERT [dbo].[Users] ([Id], [UserName], [PasswordHash], [RoleId]) VALUES (2, N'master1', N'hash2', 2)
INSERT [dbo].[Users] ([Id], [UserName], [PasswordHash], [RoleId]) VALUES (3, N'client1', N'hash3', 3)
INSERT [dbo].[Users] ([Id], [UserName], [PasswordHash], [RoleId]) VALUES (5, N'3', N'123', 3)
INSERT [dbo].[Users] ([Id], [UserName], [PasswordHash], [RoleId]) VALUES (6, N'2', N'123', 2)
INSERT [dbo].[Users] ([Id], [UserName], [PasswordHash], [RoleId]) VALUES (7, N'zxc', N'123', 2)
INSERT [dbo].[Users] ([Id], [UserName], [PasswordHash], [RoleId]) VALUES (9, N'1', N'123', 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[Cars] ON 

INSERT [dbo].[Cars] ([Id], [OwnerId], [Brand], [Model], [LicensePlate], [Year], [UserId]) VALUES (1, 5, N'Toyota', N'Camry', N'A123BC77', 2018, NULL)
INSERT [dbo].[Cars] ([Id], [OwnerId], [Brand], [Model], [LicensePlate], [Year], [UserId]) VALUES (2, 5, N'123', N'егор', N'егор', 2019, NULL)
SET IDENTITY_INSERT [dbo].[Cars] OFF
GO
SET IDENTITY_INSERT [dbo].[RepairRequests] ON 

INSERT [dbo].[RepairRequests] ([Id], [CarId], [ClientId], [ManagerId], [MasterId], [Description], [Status], [CreatedAt], [UpdatedAt], [DesiredDate]) VALUES (1, 2, 3, NULL, 9, N'лол', N'Ожидает клиента', CAST(N'2025-07-04T14:03:22.2133333' AS DateTime2), CAST(N'2025-07-05T00:50:03.9627460' AS DateTime2), CAST(N'2025-07-04T22:52:03.7790767' AS DateTime2))
INSERT [dbo].[RepairRequests] ([Id], [CarId], [ClientId], [ManagerId], [MasterId], [Description], [Status], [CreatedAt], [UpdatedAt], [DesiredDate]) VALUES (8, 1, 5, NULL, 9, N'Все плохо', N'Выполнено', CAST(N'2025-07-04T18:03:23.8675977' AS DateTime2), NULL, CAST(N'2027-01-25T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[RepairRequests] ([Id], [CarId], [ClientId], [ManagerId], [MasterId], [Description], [Status], [CreatedAt], [UpdatedAt], [DesiredDate]) VALUES (9, 1, 5, 6, 9, N'фыв', N'Выполнено', CAST(N'2025-07-04T18:03:53.4489213' AS DateTime2), CAST(N'2025-07-05T01:49:32.2894707' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[RepairRequests] OFF
GO
SET IDENTITY_INSERT [dbo].[RepairParts] ON 

INSERT [dbo].[RepairParts] ([Id], [RepairRequestId], [PartId], [Quantity]) VALUES (2, 1, 2, 1)
INSERT [dbo].[RepairParts] ([Id], [RepairRequestId], [PartId], [Quantity]) VALUES (3, 9, 1, 1)
INSERT [dbo].[RepairParts] ([Id], [RepairRequestId], [PartId], [Quantity]) VALUES (4, 9, 2, 1)
SET IDENTITY_INSERT [dbo].[RepairParts] OFF
GO
SET IDENTITY_INSERT [dbo].[ChatMessages] ON 

INSERT [dbo].[ChatMessages] ([Id], [RepairRequestId], [SenderId], [MessageText], [SentAt]) VALUES (1, 1, 3, N'Когда будет готово?', CAST(N'2025-07-04T14:03:22.2300000' AS DateTime2))
INSERT [dbo].[ChatMessages] ([Id], [RepairRequestId], [SenderId], [MessageText], [SentAt]) VALUES (2, 1, 1, N'Ожидаем запчасти, ориентировочно завтра.', CAST(N'2025-07-04T14:03:22.2300000' AS DateTime2))
INSERT [dbo].[ChatMessages] ([Id], [RepairRequestId], [SenderId], [MessageText], [SentAt]) VALUES (3, 8, 5, N'привет', CAST(N'2025-07-04T19:11:42.6180072' AS DateTime2))
INSERT [dbo].[ChatMessages] ([Id], [RepairRequestId], [SenderId], [MessageText], [SentAt]) VALUES (4, 8, 5, N'привет', CAST(N'2025-07-04T20:03:05.0891583' AS DateTime2))
INSERT [dbo].[ChatMessages] ([Id], [RepairRequestId], [SenderId], [MessageText], [SentAt]) VALUES (5, 8, 5, N'f', CAST(N'2025-07-04T20:23:40.2708247' AS DateTime2))
INSERT [dbo].[ChatMessages] ([Id], [RepairRequestId], [SenderId], [MessageText], [SentAt]) VALUES (6, 8, 6, N'салам', CAST(N'2025-07-04T22:47:47.6036896' AS DateTime2))
INSERT [dbo].[ChatMessages] ([Id], [RepairRequestId], [SenderId], [MessageText], [SentAt]) VALUES (7, 8, 9, N'привет', CAST(N'2025-07-05T00:40:28.9323919' AS DateTime2))
SET IDENTITY_INSERT [dbo].[ChatMessages] OFF
GO
SET IDENTITY_INSERT [dbo].[RepairReports] ON 

INSERT [dbo].[RepairReports] ([Id], [RepairRequestId], [MasterId], [ReportText], [CreatedAt]) VALUES (1, 1, 2, N'Заменен компрессор кондиционера и фильтр салона.', CAST(N'2025-07-04T14:03:22.2133333' AS DateTime2))
INSERT [dbo].[RepairReports] ([Id], [RepairRequestId], [MasterId], [ReportText], [CreatedAt]) VALUES (2, 9, 9, N'все круто', CAST(N'2025-07-05T01:48:41.4488062' AS DateTime2))
SET IDENTITY_INSERT [dbo].[RepairReports] OFF
GO
SET IDENTITY_INSERT [dbo].[RepairRequestStatusHistories] ON 

INSERT [dbo].[RepairRequestStatusHistories] ([Id], [RepairRequestId], [Status], [ChangedAt], [ChangedById], [Comment]) VALUES (2, 1, N'В работе', CAST(N'2025-07-05T00:49:51.6299441' AS DateTime2), 9, N'Изменение статуса')
INSERT [dbo].[RepairRequestStatusHistories] ([Id], [RepairRequestId], [Status], [ChangedAt], [ChangedById], [Comment]) VALUES (3, 1, N'Ожидает клиента', CAST(N'2025-07-05T00:50:03.9648527' AS DateTime2), 9, N'Изменение статуса')
INSERT [dbo].[RepairRequestStatusHistories] ([Id], [RepairRequestId], [Status], [ChangedAt], [ChangedById], [Comment]) VALUES (4, 9, N'Выполнено', CAST(N'2025-07-05T01:48:37.0725643' AS DateTime2), 9, N'Изменение статуса')
SET IDENTITY_INSERT [dbo].[RepairRequestStatusHistories] OFF
GO
SET IDENTITY_INSERT [dbo].[Payments] ON 

INSERT [dbo].[Payments] ([Id], [RepairRequestId], [Amount], [PaidAt], [Status]) VALUES (4, 9, CAST(24300.00 AS Decimal(18, 2)), CAST(N'2025-07-05T01:07:19.3725490' AS DateTime2), N'Оплачено')
SET IDENTITY_INSERT [dbo].[Payments] OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250704110249_fixed', N'9.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250704152823_fifth', N'9.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250704234315_ten', N'9.0.6')
GO
SET IDENTITY_INSERT [dbo].[Reviews] ON 

INSERT [dbo].[Reviews] ([Id], [RepairRequestId], [ClientId], [MasterId], [Rating], [Comment], [CreatedAt]) VALUES (1, 9, 5, 9, 5, N'ИМБА!!!', CAST(N'2025-07-05T02:50:06.2618718' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Reviews] OFF
GO
