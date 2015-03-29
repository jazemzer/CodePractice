--Create a database named CrossOver and run the following scripts

IF NOT EXISTS (
SELECT  schema_name
FROM    information_schema.schemata
WHERE   schema_name = 'CrossOver' )
BEGIN
EXEC sp_executesql N'CREATE SCHEMA crossover'
END
GO



IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[UserProfile]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UserProfile](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](56) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO


IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[crossover].[NewsCategory]') AND type in (N'U'))
BEGIN
CREATE TABLE [crossover].NewsCategory (    
	[CategoryId] [int] primary key NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
)
END
GO



IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[crossover].[NewsArticle]') AND type in (N'U'))
BEGIN
CREATE TABLE [crossover].NewsArticle (    
	[ArticleId] [uniqueidentifier] primary key NOT NULL,
	[Title] [nvarchar](200) NOT NULL,	
	ImageTile nvarchar(200) null,
	[FormattedContent] [nvarchar](max) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[PublishedOn] [datetime] not null,
	[WrittenBy] [int] not null,
	Constraint FK_NewsCategory foreign key (CategoryId) references [crossover].NewsCategory(CategoryId),
	Constraint FK_UserProfile foreign key (WrittenBy) references UserProfile(UserId),
)

END
GO



--alter table crossover.Newsarticle
--Add ImageTile nvarchar(200) null

--Test data

--insert into CrossOver.newsCategory values(1, 'Sports')
--insert into CrossOver.newsCategory values(2, 'Entertainment')
--insert into CrossOver.newsCategory values(3, 'Health')
--insert into CrossOver.newsCategory values(4, 'World')
--insert into CrossOver.newsCategory values(5, 'Science')
--insert into CrossOver.newsCategory values(6, 'Business')
--insert into CrossOver.newsCategory values(7, 'Travel')
--insert into CrossOver.newsCategory values(8, 'LifeStyle')

