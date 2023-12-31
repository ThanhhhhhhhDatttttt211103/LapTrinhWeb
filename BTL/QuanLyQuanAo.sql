
USE QuanLySanBong
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 23/10/2023 20:18:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[InvoiceId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[DateCreate] [datetime2](7) NOT NULL,
	[Total] [int] NOT NULL,
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[InvoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvoiceDetail]    Script Date: 23/10/2023 20:18:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceDetail](
	[InvoiceDetailId] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceId] [int] NOT NULL,
	[YardDetailId] [int] NOT NULL,
	[DateBook] [datetime2](7) NOT NULL,
	[Price] [int] NOT NULL,
 CONSTRAINT [PK_InvoiceDetail] PRIMARY KEY CLUSTERED 
(
	[InvoiceDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlayGround]    Script Date: 23/10/2023 20:18:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlayGround](
	[PlayGroundId] [int] IDENTITY(1,1) NOT NULL,
	[PlayGroundName] [nvarchar](max) NOT NULL,
	[PhoneNumber] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Price] [int] NOT NULL,
	[Image] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_PlayGround] PRIMARY KEY CLUSTERED 
(
	[PlayGroundId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubYard]    Script Date: 23/10/2023 20:18:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubYard](
	[SubYardId] [int] IDENTITY(1,1) NOT NULL,
	[SubYardName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_SubYard] PRIMARY KEY CLUSTERED 
(
	[SubYardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TimeSlot]    Script Date: 23/10/2023 20:18:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeSlot](
	[TimeSlotId] [int] IDENTITY(1,1) NOT NULL,
	[TimeStart] [time](7) NOT NULL,
	[TimeEnd] [time](7) NOT NULL,
 CONSTRAINT [PK_TimeSlot] PRIMARY KEY CLUSTERED 
(
	[TimeSlotId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 23/10/2023 20:18:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[PhoneNumber] [nvarchar](max) NOT NULL,
	[LoaiUser] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[YardDetail]    Script Date: 23/10/2023 20:18:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[YardDetail](
	[YardDetailId] [int] IDENTITY(1,1) NOT NULL,
	[PlayGroundId] [int] NOT NULL,
	[SubYardId] [int] NOT NULL,
	[TimeSlotId] [int] NOT NULL,
 CONSTRAINT [PK_YardDetail] PRIMARY KEY CLUSTERED 
(
	[YardDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Invoice] ON 

INSERT [dbo].[Invoice] ([InvoiceId], [UserId], [DateCreate], [Total]) VALUES (10, 1, CAST(N'2023-10-23T13:41:10.9270000' AS DateTime2), 2025000)
INSERT [dbo].[Invoice] ([InvoiceId], [UserId], [DateCreate], [Total]) VALUES (11, 3, CAST(N'2023-10-23T13:41:38.6593375' AS DateTime2), 675000)
SET IDENTITY_INSERT [dbo].[Invoice] OFF
GO
SET IDENTITY_INSERT [dbo].[InvoiceDetail] ON 

INSERT [dbo].[InvoiceDetail] ([InvoiceDetailId], [InvoiceId], [YardDetailId], [DateBook], [Price]) VALUES (3, 10, 7, CAST(N'2023-10-24T00:00:00.0000000' AS DateTime2), 675000)
INSERT [dbo].[InvoiceDetail] ([InvoiceDetailId], [InvoiceId], [YardDetailId], [DateBook], [Price]) VALUES (4, 10, 7, CAST(N'2023-10-23T00:00:00.0000000' AS DateTime2), 675000)
INSERT [dbo].[InvoiceDetail] ([InvoiceDetailId], [InvoiceId], [YardDetailId], [DateBook], [Price]) VALUES (5, 10, 6, CAST(N'2023-10-24T00:00:00.0000000' AS DateTime2), 675000)
INSERT [dbo].[InvoiceDetail] ([InvoiceDetailId], [InvoiceId], [YardDetailId], [DateBook], [Price]) VALUES (6, 11, 16, CAST(N'2023-10-23T00:00:00.0000000' AS DateTime2), 675000)
SET IDENTITY_INSERT [dbo].[InvoiceDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[PlayGround] ON 

INSERT [dbo].[PlayGround] ([PlayGroundId], [PlayGroundName], [PhoneNumber], [Address], [Price], [Image], [Description]) VALUES (1, N'Sân bóng Thành Phát', N'0985592136', N'Số 2 Hoàng Minh Giám, phường Trung Hòa, quận Cầu Giấy, Hà Nội', 450000, N'Anhtest1', N'ghiChuTest1')
INSERT [dbo].[PlayGround] ([PlayGroundId], [PlayGroundName], [PhoneNumber], [Address], [Price], [Image], [Description]) VALUES (2, N'Sân bóng Yên Hòa', N'0985592136', N'Số 224 Trung Kính, Yên Hòa, Cầu Giấy, Hà Nội', 450000, N'Anhtest2', N'ghiChuTest2')
INSERT [dbo].[PlayGround] ([PlayGroundId], [PlayGroundName], [PhoneNumber], [Address], [Price], [Image], [Description]) VALUES (3, N'Sân bóng Hà Nội – Trung Kính Hạ', N'0858658899', N'Lô C10, 6 Nguyễn Chánh, khu đô thị Nam Trung Yên, thành phố Hà Nội', 400000, N'sanbongnhantao.jpg', N'Wifi miễn phí Có ưu đãi cho thành viên. Có chỗ đỗ oto. Bãi giữ xe máy miễn phí')
SET IDENTITY_INSERT [dbo].[PlayGround] OFF
GO
SET IDENTITY_INSERT [dbo].[SubYard] ON 

INSERT [dbo].[SubYard] ([SubYardId], [SubYardName]) VALUES (1, N'Sân 1')
INSERT [dbo].[SubYard] ([SubYardId], [SubYardName]) VALUES (2, N'Sân 2')
INSERT [dbo].[SubYard] ([SubYardId], [SubYardName]) VALUES (3, N'Sân 3')
INSERT [dbo].[SubYard] ([SubYardId], [SubYardName]) VALUES (4, N'Sân 4')
INSERT [dbo].[SubYard] ([SubYardId], [SubYardName]) VALUES (5, N'Sân 5')
SET IDENTITY_INSERT [dbo].[SubYard] OFF
GO
SET IDENTITY_INSERT [dbo].[TimeSlot] ON 

INSERT [dbo].[TimeSlot] ([TimeSlotId], [TimeStart], [TimeEnd]) VALUES (1, CAST(N'08:00:00' AS Time), CAST(N'09:30:00' AS Time))
INSERT [dbo].[TimeSlot] ([TimeSlotId], [TimeStart], [TimeEnd]) VALUES (2, CAST(N'09:30:00' AS Time), CAST(N'11:00:00' AS Time))
INSERT [dbo].[TimeSlot] ([TimeSlotId], [TimeStart], [TimeEnd]) VALUES (3, CAST(N'13:00:00' AS Time), CAST(N'14:30:00' AS Time))
INSERT [dbo].[TimeSlot] ([TimeSlotId], [TimeStart], [TimeEnd]) VALUES (4, CAST(N'14:30:00' AS Time), CAST(N'16:00:00' AS Time))
INSERT [dbo].[TimeSlot] ([TimeSlotId], [TimeStart], [TimeEnd]) VALUES (5, CAST(N'16:00:00' AS Time), CAST(N'17:30:00' AS Time))
INSERT [dbo].[TimeSlot] ([TimeSlotId], [TimeStart], [TimeEnd]) VALUES (6, CAST(N'17:30:00' AS Time), CAST(N'19:00:00' AS Time))
INSERT [dbo].[TimeSlot] ([TimeSlotId], [TimeStart], [TimeEnd]) VALUES (7, CAST(N'19:00:00' AS Time), CAST(N'20:30:00' AS Time))
INSERT [dbo].[TimeSlot] ([TimeSlotId], [TimeStart], [TimeEnd]) VALUES (8, CAST(N'20:30:00' AS Time), CAST(N'22:00:00' AS Time))
INSERT [dbo].[TimeSlot] ([TimeSlotId], [TimeStart], [TimeEnd]) VALUES (9, CAST(N'06:00:00' AS Time), CAST(N'07:30:00' AS Time))
INSERT [dbo].[TimeSlot] ([TimeSlotId], [TimeStart], [TimeEnd]) VALUES (10, CAST(N'07:30:00' AS Time), CAST(N'09:00:00' AS Time))
INSERT [dbo].[TimeSlot] ([TimeSlotId], [TimeStart], [TimeEnd]) VALUES (11, CAST(N'09:00:00' AS Time), CAST(N'10:30:00' AS Time))
SET IDENTITY_INSERT [dbo].[TimeSlot] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [Username], [Password], [PhoneNumber], [LoaiUser]) VALUES (1, N'thanhdat1', N'12345678', N'09855921360', 0)
INSERT [dbo].[User] ([UserId], [Username], [Password], [PhoneNumber], [LoaiUser]) VALUES (2, N'vanhoan1', N'12345678', N'09855921360', 1)
INSERT [dbo].[User] ([UserId], [Username], [Password], [PhoneNumber], [LoaiUser]) VALUES (3, N'viethoang689', N'123456', N'0123456789', 0)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[YardDetail] ON 

INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (1, 1, 1, 1)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (3, 1, 1, 2)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (4, 1, 1, 3)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (5, 1, 1, 4)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (6, 1, 1, 5)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (7, 1, 1, 6)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (8, 1, 1, 7)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (9, 1, 1, 8)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (10, 1, 2, 1)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (11, 1, 2, 2)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (12, 1, 2, 3)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (13, 1, 2, 4)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (14, 1, 2, 5)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (15, 1, 2, 6)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (16, 1, 2, 7)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (17, 1, 2, 8)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (18, 1, 3, 1)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (19, 1, 3, 2)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (20, 1, 3, 3)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (21, 1, 3, 4)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (22, 1, 3, 5)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (23, 1, 3, 6)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (24, 1, 3, 7)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (25, 1, 3, 8)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (26, 1, 4, 1)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (27, 1, 4, 2)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (28, 1, 4, 3)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (29, 1, 4, 4)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (30, 1, 4, 5)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (31, 1, 4, 6)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (32, 1, 4, 7)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (33, 1, 4, 8)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (34, 1, 5, 1)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (35, 1, 5, 2)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (36, 1, 5, 3)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (38, 1, 5, 4)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (39, 1, 5, 5)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (40, 1, 5, 6)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (41, 1, 5, 7)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (42, 1, 5, 8)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (43, 2, 1, 1)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (44, 2, 1, 2)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (45, 2, 1, 3)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (46, 2, 1, 4)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (47, 2, 1, 5)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (48, 2, 1, 6)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (49, 2, 1, 7)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (50, 2, 1, 8)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (51, 2, 2, 1)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (52, 2, 2, 2)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (53, 2, 2, 3)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (55, 2, 2, 4)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (56, 2, 2, 5)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (57, 2, 2, 6)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (58, 2, 2, 7)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (59, 2, 2, 8)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (61, 2, 3, 1)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (62, 2, 3, 2)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (63, 2, 3, 3)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (64, 2, 3, 4)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (65, 2, 3, 5)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (66, 2, 3, 6)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (67, 2, 3, 7)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (68, 2, 3, 8)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (69, 2, 4, 1)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (70, 2, 4, 2)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (71, 2, 4, 3)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (72, 2, 4, 4)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (73, 2, 4, 5)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (74, 2, 4, 6)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (75, 2, 4, 7)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (76, 2, 4, 8)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (77, 2, 5, 1)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (78, 2, 5, 2)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (79, 2, 5, 3)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (80, 2, 5, 4)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (81, 2, 5, 5)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (82, 2, 5, 6)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (83, 2, 5, 7)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (84, 2, 5, 8)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (85, 3, 1, 9)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (86, 3, 2, 10)
INSERT [dbo].[YardDetail] ([YardDetailId], [PlayGroundId], [SubYardId], [TimeSlotId]) VALUES (87, 3, 3, 11)
SET IDENTITY_INSERT [dbo].[YardDetail] OFF
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_User_UserId]
GO
ALTER TABLE [dbo].[InvoiceDetail]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetail_Invoice_InvoiceId] FOREIGN KEY([InvoiceId])
REFERENCES [dbo].[Invoice] ([InvoiceId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InvoiceDetail] CHECK CONSTRAINT [FK_InvoiceDetail_Invoice_InvoiceId]
GO
ALTER TABLE [dbo].[InvoiceDetail]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetail_YardDetail_YardDetailId] FOREIGN KEY([YardDetailId])
REFERENCES [dbo].[YardDetail] ([YardDetailId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InvoiceDetail] CHECK CONSTRAINT [FK_InvoiceDetail_YardDetail_YardDetailId]
GO
ALTER TABLE [dbo].[YardDetail]  WITH CHECK ADD  CONSTRAINT [FK_YardDetail_PlayGround_PlayGroundId] FOREIGN KEY([PlayGroundId])
REFERENCES [dbo].[PlayGround] ([PlayGroundId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[YardDetail] CHECK CONSTRAINT [FK_YardDetail_PlayGround_PlayGroundId]
GO
ALTER TABLE [dbo].[YardDetail]  WITH CHECK ADD  CONSTRAINT [FK_YardDetail_SubYard_SubYardId] FOREIGN KEY([SubYardId])
REFERENCES [dbo].[SubYard] ([SubYardId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[YardDetail] CHECK CONSTRAINT [FK_YardDetail_SubYard_SubYardId]
GO
ALTER TABLE [dbo].[YardDetail]  WITH CHECK ADD  CONSTRAINT [FK_YardDetail_TimeSlot_TimeSlotId] FOREIGN KEY([TimeSlotId])
REFERENCES [dbo].[TimeSlot] ([TimeSlotId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[YardDetail] CHECK CONSTRAINT [FK_YardDetail_TimeSlot_TimeSlotId]
GO
