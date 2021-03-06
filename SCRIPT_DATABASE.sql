CREATE DATABASE BD_APPLICANTS;

USE [BD_APPLICANTS]
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULT_APPLICANT_ALL]    Script Date: 2/13/2018 6:39:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,José Mauricio Galeano Castrillón>
-- Create date: <Create Date,,13/02/2018>
-- Description:	<Description,,Procedimiento almacenado para obtener los datos de todos aplicantes>
-- =============================================
CREATE PROCEDURE [dbo].[SP_CONSULT_APPLICANT_ALL]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT a.Consecutive
      ,a.ID_Job
      ,a.Firts_Name
      ,a.Second_Name
      ,a.First_Last_Name
      ,a.Second_Last_Name
      ,a.Email
      ,a.International_Phone_Number
      ,a.Biography
      ,a.Birtday
      ,a.Street_Adress
      ,a.City
      ,a.Country
      ,a.Postal_Code
      ,a.PathPhotoLocal
      ,a.PathPhotoURL
	  ,j.Name AS 'Name_Job'
	FROM Applicant a INNER JOIN Job j ON j.Consecutive = a.ID_Job;

END

GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULT_APPLICANT_BY_ID]    Script Date: 2/13/2018 6:39:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,José Mauricio Galeano Castrillón>
-- Create date: <Create Date,,13/02/2018>
-- Description:	<Description,,Procedimiento almacenado para obtener los datos de un aplicante por medio del consecutivo o id>
-- =============================================
CREATE PROCEDURE [dbo].[SP_CONSULT_APPLICANT_BY_ID]
	-- Add the parameters for the stored procedure here
	@Consecutive int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT a.Consecutive
      ,a.ID_Job
      ,a.Firts_Name
      ,a.Second_Name
      ,a.First_Last_Name
      ,a.Second_Last_Name
      ,a.Email
      ,a.International_Phone_Number
      ,a.Biography
      ,a.Birtday
      ,a.Street_Adress
      ,a.City
      ,a.Country
      ,a.Postal_Code
      ,a.PathPhotoLocal
      ,a.PathPhotoURL
	  ,j.Name AS 'Name_Job'
	FROM Applicant a INNER JOIN Job j ON j.Consecutive = a.ID_Job
	WHERE a.Consecutive = @Consecutive;

END

GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULT_FILE_ADJUNT]    Script Date: 2/13/2018 6:39:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,José Mauricio Galeano Castrillón>
-- Create date: <Create Date,,13/02/2018>
-- Description:	<Description,,Procedimiento almacenado para obtener los archivos adjuntos de un aplicante>
-- =============================================
CREATE PROCEDURE [dbo].[SP_CONSULT_FILE_ADJUNT]
	-- Add the parameters for the stored procedure here
	@ID_Applicant int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT a.Consecutive,
	f.File_Name,
	f.Tipe_File,
	f.Path_File_Local,
	f.Path_File_URL 
	FROM Applicant a INNER JOIN Files_Adjunt f ON a.Consecutive	= f.Id_Applicant
	WHERE a.Consecutive = @ID_Applicant;

END

GO
/****** Object:  StoredProcedure [dbo].[SP_DELETE_APPLICANT]    Script Date: 2/13/2018 6:39:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,José Mauricio Galeano Castrillón>
-- Create date: <Create Date,,13/02/2018>
-- Description:	<Description,,Procedimiento almacenado para eliminar un aplicante>
-- =============================================
CREATE PROCEDURE [dbo].[SP_DELETE_APPLICANT]
	-- Add the parameters for the stored procedure here
	@Consecutive int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM [dbo].[Applicant]
	WHERE Consecutive = @Consecutive;
 
END

GO
/****** Object:  StoredProcedure [dbo].[SP_DELETE_FILE_ADJUNT]    Script Date: 2/13/2018 6:39:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,José Mauricio Galeano Castrillón>
-- Create date: <Create Date,,13/02/2018>
-- Description:	<Description,,Procedimiento almacenado para eliminar un archivo ajunto cargado por el aplicante>
-- =============================================
CREATE PROCEDURE [dbo].[SP_DELETE_FILE_ADJUNT]
	-- Add the parameters for the stored procedure here
	@Consecutive int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM [dbo].[Files_Adjunt]
	WHERE Consecutive = @Consecutive;
 
END

GO
/****** Object:  StoredProcedure [dbo].[SP_EDIT_APPLICANT]    Script Date: 2/13/2018 6:39:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,José Mauricio Galeano Castrillón>
-- Create date: <Create Date,,13/02/2018>
-- Description:	<Description,,Procedimiento almacenado para actualizar los datos de un aplicante>
-- =============================================
CREATE PROCEDURE [dbo].[SP_EDIT_APPLICANT]
	-- Add the parameters for the stored procedure here
	@Consecutive int,
	@ID_Job int,
	@Firts_Name varchar(30),
	@Second_Name varchar(30),
	@First_Last_Name varchar(30),
	@Second_Last_Name varchar(30),
	@Email varchar(50),
	@International_Phone_Number varchar(14),
	@Biography varchar(200),
	@Birtday date,
	@Street_Adress varchar(100),
	@City varchar(50),
	@Country varchar(50),
	@Postal_Code varchar(5),
	@PathPhotoLocal varchar(300),
	@PathPhotoURL varchar(300)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
UPDATE [dbo].[Applicant]
   SET ID_Job = @ID_Job
      ,Firts_Name = @Firts_Name
      ,Second_Name = @Second_Name
      ,First_Last_Name = @First_Last_Name
      ,Second_Last_Name = @Second_Last_Name
      ,Email = @Email
      ,International_Phone_Number = @International_Phone_Number
      ,Biography = @Biography
      ,Birtday = @Birtday
      ,Street_Adress = @Street_Adress
      ,City = @City
      ,Country = @Country
      ,Postal_Code = @Postal_Code
      ,PathPhotoLocal = @PathPhotoLocal
      ,PathPhotoURL = @PathPhotoURL
 WHERE Consecutive = @Consecutive
 
END

GO
/****** Object:  StoredProcedure [dbo].[SP_INSERT_APPLICANT]    Script Date: 2/13/2018 6:39:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,José Mauricio Galeano Castrillón>
-- Create date: <Create Date,,13/02/2018>
-- Description:	<Description,,Procedimiento almacenado para crear un aplicante>
-- =============================================
CREATE PROCEDURE [dbo].[SP_INSERT_APPLICANT]
	-- Add the parameters for the stored procedure here
	@ID_Job int,
	@Firts_Name varchar(30),
	@Second_Name varchar(30),
	@First_Last_Name varchar(30),
	@Second_Last_Name varchar(30),
	@Email varchar(50),
	@International_Phone_Number varchar(14),
	@Biography varchar(200),
	@Birtday date,
	@Street_Adress varchar(100),
	@City varchar(50),
	@Country varchar(50),
	@Postal_Code varchar(5),
	@PathPhotoLocal varchar(300),
	@PathPhotoURL varchar(300)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Applicant]
           ([ID_Job]
           ,[Firts_Name]
           ,[Second_Name]
           ,[First_Last_Name]
           ,[Second_Last_Name]
           ,[Email]
           ,[International_Phone_Number]
           ,[Biography]
           ,[Birtday]
           ,[Street_Adress]
           ,[City]
           ,[Country]
           ,[Postal_Code]
           ,[PathPhotoLocal]
           ,[PathPhotoURL])
     VALUES
           (@ID_Job
           ,@Firts_Name
           ,@Second_Name
           ,@First_Last_Name
           ,@Second_Last_Name
           ,@Email
           ,@International_Phone_Number
           ,@Biography
           ,@Birtday
           ,@Street_Adress
           ,@City
           ,@Country
           ,@Postal_Code
           ,@PathPhotoLocal
           ,@PathPhotoURL);
END

GO
/****** Object:  StoredProcedure [dbo].[SP_INSERT_FILE_ADJUNT]    Script Date: 2/13/2018 6:39:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,José Mauricio Galeano Castrillón>
-- Create date: <Create Date,,13/02/2018>
-- Description:	<Description,,Procedimiento almacenado para crear adicionar un archivo adjunto del aplicante>
-- =============================================
CREATE PROCEDURE [dbo].[SP_INSERT_FILE_ADJUNT]
	-- Add the parameters for the stored procedure here
	@Id_Applicant int,
	@File_Name varchar,
	@Tipe_File varchar(3),
	@Size numeric(12, 2),
	@Path_File_Local varchar(300),
	@Path_File_URL varchar(300),
	@Description_File varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Files_Adjunt]
           ([Id_Applicant]
           ,[File_Name]
           ,[Tipe_File]
           ,[Size]
           ,[Path_File_Local]
           ,[Path_File_URL]
           ,[Description_File])
     VALUES
           (@Id_Applicant
           ,@File_Name
           ,@Tipe_File
           ,@Size
           ,@Path_File_Local
           ,@Path_File_URL
           ,@Description_File);
END

GO
/****** Object:  Table [dbo].[Administrator]    Script Date: 2/13/2018 6:39:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Administrator](
	[Consecutive] [int] IDENTITY(1,1) NOT NULL,
	[First_Name] [varchar](30) NOT NULL,
	[Second_Name] [varchar](30) NOT NULL,
	[First_Last_Name] [varchar](30) NOT NULL,
	[Second_Last_Name] [varchar](30) NOT NULL,
	[Email] [varchar](50) NULL,
	[Phone] [varchar](14) NULL,
 CONSTRAINT [PK_Administrator] PRIMARY KEY CLUSTERED 
(
	[Consecutive] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Applicant]    Script Date: 2/13/2018 6:39:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Applicant](
	[Consecutive] [int] IDENTITY(1,1) NOT NULL,
	[ID_Job] [int] NULL,
	[Firts_Name] [varchar](30) NOT NULL,
	[Second_Name] [varchar](30) NOT NULL,
	[First_Last_Name] [varchar](30) NOT NULL,
	[Second_Last_Name] [varchar](30) NOT NULL,
	[Email] [varchar](50) NULL,
	[International_Phone_Number] [varchar](14) NULL,
	[Biography] [varchar](200) NOT NULL,
	[Birtday] [date] NOT NULL,
	[Street_Adress] [varchar](100) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[Country] [varchar](50) NOT NULL,
	[Postal_Code] [varchar](5) NULL,
	[PathPhotoLocal] [varchar](300) NULL,
	[PathPhotoURL] [varchar](300) NULL,
 CONSTRAINT [PK_Applicant] PRIMARY KEY CLUSTERED 
(
	[Consecutive] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Files_Adjunt]    Script Date: 2/13/2018 6:39:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Files_Adjunt](
	[Consecutive] [int] IDENTITY(1,1) NOT NULL,
	[Id_Applicant] [int] NOT NULL,
	[File_Name] [varchar](100) NOT NULL,
	[Tipe_File] [varchar](3) NOT NULL,
	[Size] [numeric](12, 2) NOT NULL,
	[Path_File_Local] [varchar](300) NOT NULL,
	[Path_File_URL] [varchar](300) NOT NULL,
	[Description_File] [varchar](100) NULL,
 CONSTRAINT [PK_Files_Adjunt] PRIMARY KEY CLUSTERED 
(
	[Consecutive] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Job]    Script Date: 2/13/2018 6:39:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Job](
	[Consecutive] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varbinary](50) NULL,
 CONSTRAINT [PK_Job] PRIMARY KEY CLUSTERED 
(
	[Consecutive] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Número Consecutivo de los Aplicantes' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Applicant', @level2type=N'COLUMN',@level2name=N'Consecutive'
GO
