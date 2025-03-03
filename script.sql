USE [MegaMindsDB]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 7/6/2024 4:15:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone_Number] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[State] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[Agree] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Proc_Delete]    Script Date: 7/6/2024 4:15:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Proc_Delete]
@ID INT
AS
BEGIN
DELETE FROM DBO.Employee WHERE ID=@ID;
END
GO
/****** Object:  StoredProcedure [dbo].[Proc_GetEmployee]    Script Date: 7/6/2024 4:15:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Proc_GetEmployee]
AS
BEGIN
SELECT * FROM DBO.Employee
END
GO
/****** Object:  StoredProcedure [dbo].[Proc_GetEmployeeByID]    Script Date: 7/6/2024 4:15:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Proc_GetEmployeeByID]
@ID INT
AS
BEGIN
SELECT * FROM DBO.Employee WHERE ID=@ID;
END
GO
/****** Object:  StoredProcedure [dbo].[Proc_SaveEmployee]    Script Date: 7/6/2024 4:15:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Proc_SaveEmployee] 
    @ID INT,
    @Name NVARCHAR(50),
    @Email NVARCHAR(50),
    @Phone_Number NVARCHAR(50),
	@Address NVARCHAR(50),
	@State NVARCHAR(50),
	@City NVARCHAR(50),
	@Agree bit
AS
BEGIN
    IF @ID > 0
    BEGIN
        UPDATE Employee
        SET Name = @Name,
            Email= @Email,
            Phone_Number = @Phone_Number,
			Address=@Address,
			State=@State,
			City=@City,
			Agree=@Agree
        WHERE ID = @ID;
    END
    ELSE
    BEGIN
        INSERT INTO Employee (Name, Email, Phone_Number,Address,State,City,Agree)
        VALUES (@Name, @Email, @Phone_Number,@Address,@State,@City,@Agree);
    END
END;
GO
