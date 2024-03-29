USE [BookMyTickets]
GO
/****** Object:  Table [dbo].[Movie]    Script Date: 09-06-2022 19:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MovieName] [nvarchar](50) NOT NULL,
	[MovieDescription] [nvarchar](max) NULL,
	[MovieImage] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovieListing]    Script Date: 09-06-2022 19:21:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovieListing](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MovieName] [nvarchar](max) NOT NULL,
	[MovieDescription] [nvarchar](max) NULL,
	[MovieImage] [nvarchar](max) NULL,
	[Fare] [money] NOT NULL,
	[MovieDate] [date] NOT NULL,
	[MovieTime] [datetime] NOT NULL,
	[MaxSeats] [int] NULL,
	[AvailableSeats] [int] NULL,
 CONSTRAINT [PK_MovieListing] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovieSlot]    Script Date: 09-06-2022 19:21:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovieSlot](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MovieId] [int] NULL,
	[MovieTime] [datetime] NULL,
	[Fare] [money] NOT NULL,
	[MovieDate] [datetime2](7) NOT NULL,
	[MaxSeats] [int] NOT NULL,
	[AvailableSeats] [int] NOT NULL,
 CONSTRAINT [PK_MovieSlot] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 09-06-2022 19:21:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Gender] [nchar](10) NOT NULL,
	[Contact] [numeric](10, 0) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[IsAdmin] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserMovieBook]    Script Date: 09-06-2022 19:21:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserMovieBook](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MovieSlotId] [int] NULL,
	[SeatNos] [nvarchar](max) NOT NULL,
	[UserId] [int] NULL,
	[IsActive] [bit] NOT NULL,
	[NoOfTickets] [int] NOT NULL,
	[BookingDate] [datetime2](7) NOT NULL,
	[Rating] [int] NULL,
 CONSTRAINT [PK_UserMovieBook] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[MovieSlot]  WITH CHECK ADD  CONSTRAINT [FK_MovieSlot_Movie] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movie] ([Id])
GO
ALTER TABLE [dbo].[MovieSlot] CHECK CONSTRAINT [FK_MovieSlot_Movie]
GO
ALTER TABLE [dbo].[UserMovieBook]  WITH CHECK ADD  CONSTRAINT [FK_UserMovieBook_MovieSlot] FOREIGN KEY([MovieSlotId])
REFERENCES [dbo].[MovieSlot] ([Id])
GO
ALTER TABLE [dbo].[UserMovieBook] CHECK CONSTRAINT [FK_UserMovieBook_MovieSlot]
GO
ALTER TABLE [dbo].[UserMovieBook]  WITH CHECK ADD  CONSTRAINT [FK_UserMovieBook_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserMovieBook] CHECK CONSTRAINT [FK_UserMovieBook_User]
GO
