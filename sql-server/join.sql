USE [Cursos];
-- View 
CREATE OR ALTER VIEW vwContagemCursosPorCategoria AS
	SELECT TOP 100
		[Categoria].[Nome],
		COUNT([CURSO].[CategoriaId]) as [Cursos]
	 FROM
		 [Categoria]
		 INNER JOIN [Curso] ON [Curso].[CategoriaId] = [Categoria].[Id]
	 GROUP BY
		 [Categoria].[Nome],
		 [Curso].[CategoriaId]
	 HAVING
		 COUNT([CURSO].[CategoriaId]) = 2 

-- Group by
SELECT TOP 100
    [Categoria].[Nome],
	COUNT([CURSO].[CategoriaId]) as [Cursos]
 FROM
	 [Categoria]
	 INNER JOIN [Curso] ON [Curso].[CategoriaId] = [Categoria].[Id]
 GROUP BY
     [Categoria].[Nome],
	 [Curso].[CategoriaId]

-- having
-- todas as categorias q tenha 2 cursos
SELECT TOP 100
    [Categoria].[Nome],
	COUNT([CURSO].[CategoriaId]) as [Cursos]
 FROM
	 [Categoria]
	 INNER JOIN [Curso] ON [Curso].[CategoriaId] = [Categoria].[Id]
 GROUP BY
     [Categoria].[Nome],
	 [Curso].[CategoriaId]
 HAVING
     COUNT([CURSO].[CategoriaId]) = 2 

-- JOIN ------------------------------------------------
-- Inner JOIN - U

SELECT TOP 100
 [Curso].[Id],
 [Curso].[Nome],
 [Categoria].[Id] as [Categoria_id],
 [Categoria].[Nome] as [Nome_categoria]
 FROM
 [Curso]
 INNER JOIN [Categoria]
 ON [Curso].[CategoriaId] = [Categoria].[Id]

-- LEFT JOIN
-- traz todos os curso mesmo que não exista categoria
SELECT TOP 100
[Curso].[Id],
[Curso].[Nome],
[Categoria].[Id] as [Categoria_id],
[Categoria].[Nome] as [Nome_categoria]
FROM
[Curso]
LEFT JOIN [Categoria]
ON [Curso].[CategoriaId] = [Categoria].[Id]


-- RIGHT JOIN
-- traz todas as categorias mesmo que não exista cursos
SELECT TOP 100
[Curso].[Id],
[Curso].[Nome],
[Categoria].[Id] as [Categoria_id],
[Categoria].[Nome] as [Nome_categoria]
FROM
[Curso]
RIGHT JOIN [Categoria]
ON [Curso].[CategoriaId] = [Categoria].[Id]

-- FULL JOIN
-- traz todos os cursos e categorias
SELECT TOP 100
[Curso].[Id],
[Curso].[Nome],
[Categoria].[Id] as [Categoria_id],
[Categoria].[Nome] as [Nome_categoria]
FROM
[Curso]
FULL JOIN [Categoria]
ON [Curso].[CategoriaId] = [Categoria].[Id]

-- union: mesmos campos

SELECT TOP 100
 [Id],[Nome]
FROM
[Curso]
UNION

SELECT TOP 100
[Id],[Nome]
from
[Categoria]