CREATE DATABASE [Cursos]
GO


USE [Cursos];

/* Tabela categoria */
CREATE TABLE [Categoria](
  [Id] INT NOT NULL IDENTITY(1,1),
  [Nome] NVARCHAR(80) NOT NULL,

  CONSTRAINT [PK_Categoria] PRIMARY KEY([Id])
)
GO


/* Tabela curso */
CREATE TABLE [Curso](
  [Id] INT NOT NULL IDENTITY (1,1) ,
  [Nome] NVARCHAR(80) NOT NULL,
  [CategoriaId] INT NOT NULL,

  CONSTRAINT [PK_Curso] PRIMARY KEY([Id]),

  CONSTRAINT [PK_Curso_Categoria] FOREIGN KEY([CategoriaId])
	REFERENCES [Categoria]([Id])
)
GO

--select
Select TOP 10 
  [Nome]
  from Curso
  Order by
	[Nome] DESC
 
 -- UPDATE
 BEGIN TRANSACTION
	UPDATE
		[Categoria]
	SET
	    [Nome] = 'Backend Dotnet'
	WHERE
	    [Id] = 1
	COMMIT
 --ROLLBACK


 -- categoria id
 select * from Curso;
  select * from [Categoria];

 --DELETE
  BEGIN TRANSACTION
	DELETE
		Curso
	WHERE
	    [Id] = 4
	COMMIT

  BEGIN TRANSACTION
	DELETE
		[Categoria]
	WHERE
	    [Id] = 3
  --ROLLBACK
    COMMIT


 Select * from [Categoria];

 Select MIN([Id]) as [Minimo] from [Categoria];
 Select COUNT([Id]) as [Total] from [Categoria] ;
 Select AVG([Id]) from [Categoria];
 Select SUM([Id]) from [Categoria];

-- LIKE ------------------------------------------------
--contem 
Select * from Curso;
Select TOP 100
 *
 from [Curso] 
 where [Nome] LIKE '%Fundamentos%'

--começa com
Select TOP 100
 *
 from [Curso] 
 where [Nome] LIKE 'A%'

--termina com
Select TOP 100
 *
 from [Curso] 
 where [Nome] LIKE '%C#'


--between and in
Select TOP 100
 *
 from [Curso] 
 where [Id] IN(1,3)

Select TOP 100
 *
 from [Curso] 
 where [Id] BETWEEN 2 AND 3


