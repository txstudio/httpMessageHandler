--儲存雙數月份的 WebApi 呼叫記錄內容
CREATE TABLE [dbo].[HttpMessageHandler-0] (
	[No] BIGINT NOT NULL IDENTITY(1, 1)
	,[TimeUtc] DATETIME DEFAULT(GETDATE()) NOT NULL
	,[Method] VARCHAR(5) NOT NULL
	,[IPAddress] VARCHAR(150) NOT NULL
	,[RequestUrl] NVARCHAR(150) NOT NULL
	,[RequestMessage] NVARCHAR(MAX) NULL
	,[ResponseMessage] NVARCHAR(MAX) NULL
	,CONSTRAINT [PK_dbo_HttpMessageHandler-0_No] PRIMARY KEY CLUSTERED ([No] ASC) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

--儲存單數月份的 WebApi 呼叫記錄內容
CREATE TABLE [dbo].[HttpMessageHandler-1] (
	[No] BIGINT NOT NULL IDENTITY(1, 1)
	,[TimeUtc] DATETIME DEFAULT(GETDATE()) NOT NULL
	,[Method] VARCHAR(5) NOT NULL
	,[IPAddress] VARCHAR(150) NOT NULL
	,[RequestUrl] NVARCHAR(150) NOT NULL
	,[RequestMessage] NVARCHAR(MAX) NULL
	,[ResponseMessage] NVARCHAR(MAX) NULL
	,CONSTRAINT [PK_dbo_HttpMessageHandler-1_No] PRIMARY KEY CLUSTERED ([No] ASC) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

--紀錄 WebApi 呼叫記錄內容
CREATE PROCEDURE [dbo].[sp_AddHttpMessageHandler] @Method VARCHAR(5)
	,@IPAddress VARCHAR(150)
	,@RequestUrl NVARCHAR(150)
	,@RequestMessage NVARCHAR(MAX)
	,@ResponseMessage NVARCHAR(MAX)
AS
SET NOCOUNT ON

--
--使用月份判斷儲存的目的資料表
--
IF (DATEPART(MONTH, GETDATE()) % 2) = 0
BEGIN
	INSERT INTO [dbo].[HttpMessageHandler-0] (
		[Method]
		,[IPAddress]
		,[RequestUrl]
		,[RequestMessage]
		,[ResponseMessage]
		)
	VALUES (
		@Method
		,@IPAddress
		,@RequestUrl
		,@RequestMessage
		,@ResponseMessage
		)
END
ELSE
BEGIN
	INSERT INTO [dbo].[HttpMessageHandler-1] (
		[Method]
		,[IPAddress]
		,[RequestUrl]
		,[RequestMessage]
		,[ResponseMessage]
		)
	VALUES (
		@Method
		,@IPAddress
		,@RequestUrl
		,@RequestMessage
		,@ResponseMessage
		)
END
GO
