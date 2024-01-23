CREATE PROCEDURE Valores_InsertarListado
@ListadoValores ListadoValores READONLY

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	TRUNCATE TABLE Valores

	INSERT INTO Valores
	SELECT valor
	FROM @ListadoValores

END
GO