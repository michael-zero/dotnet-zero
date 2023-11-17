SELECT * FROM vwContagemCursosPorCategoria
WHERE [CURSOS]=2;



-- Procedure

CREATE OR ALTER PROCEDURE [spListCourse] AS
  SELECT * FROM [Curso]

EXEC [spListCourse];
DROP PROCEDURE [spListCourse];