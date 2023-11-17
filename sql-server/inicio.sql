USE [master]

DECLARE @kill varchar(8000) = '';
SELECT @kill = @kill + 'kill ' + CONVERT(varchar(5), session_id) + ';'
FROM sys.dm_exec_sessions
WHERE database_id = db_id('Curso')

EXEC(@kill);

DROP DATABASE [Curso];

/**PRIMARY KEY([Id], [EMAIL]) composicao **/
CREATE TABLE [Aluno](
  [Id] INT NOT NULL,
  [Nome] NVARCHAR(80) NOT NULL,
  [Email] NVARCHAR(180) NOT NULL,
  [Nascimento] DATETIME NULL,
  [Active] BIT NOT NULL DEFAULT(0),

  CONSTRAINT [PK_Aluno] PRIMARY KEY([Id]),
  CONSTRAINT [UQ_Aluno_Email] UNIQUE([Email])
  
)
GO

/* criando indices para campos normalmente buscados */
CREATE INDEX [IX_Aluno_Email] ON [Aluno]([Email])

/* Apagando indice */
DROP INDEX [IX_Aluno_Email] ON [Aluno]

/* Tabela categoria */
CREATE TABLE [Categoria](
  [Id] INT NOT NULL,
  [Nome] NVARCHAR(80) NOT NULL,

  CONSTRAINT [PK_Categoria] PRIMARY KEY([Id])
)
GO


/* Tabela curso */
/*  [Id]  UNIQUEIDENTIFIER NOT NULL*/

CREATE TABLE [Curso](
  [Id] INT NOT NULL IDENTITY (1,1) ,
  [Nome] NVARCHAR(80) NOT NULL,
  [CategoriaId] INT NOT NULL,

  CONSTRAINT [PK_Curso] PRIMARY KEY([Id]),

  CONSTRAINT [PK_Curso_Categoria] FOREIGN KEY([CategoriaId])
	REFERENCES [Categoria]([Id])
)
GO

DROP TABLE [Curso];


CREATE TABLE [ProgressoCurso](
  [AlunoId] INT NOT NULL,
  [CursoId] INT NOT NULL,
  [Progresso] INT NOT NULL,
  [UltimaAtualizacao] DATETIME NOT NULL DEFAULT(GETDATE()),

  CONSTRAINT PK_ProgressoCurso PRIMARY KEY([AlunoId],[CursoID])
)
GO



DROP TABLE [ProgressoCurso];

DROP TABLE [Aluno];


ALTER TABLE [Aluno] 
	ADD [Document] NVARCHAR(11)

ALTER TABLE [Aluno]
    DROP COLUMN [Document]

ALTER TABLE [Aluno]
    ALTER COLUMN [Document] CHAR(11)

ALTER TABLE [Aluno]
    ALTER COLUMN [Active] BIT NOT NULL 