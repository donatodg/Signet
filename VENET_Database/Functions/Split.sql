
/*
SELECT * FROM dbo.Split('123,321',',')
*/

CREATE FUNCTION [dbo].[Split]
(
	@RowData VARCHAR(8000),
	@SplitOn VARCHAR(5)
)  
RETURNS @RtnValue TABLE
(
	Id INT IDENTITY(1, 1),
	Item NVARCHAR(MAX)
)
AS
BEGIN
	DECLARE @Cnt INT
	SET @Cnt = 1

	WHILE (CHARINDEX(@SplitOn, @RowData) > 0)
	BEGIN
		INSERT INTO @RtnValue (Item)
		SELECT Item = LTRIM(RTRIM(SUBSTRING(@RowData, 1, CHARINDEX(@SplitOn, @RowData) - 1)))

		SET @RowData = SUBSTRING(@RowData, CHARINDEX(@SplitOn, @RowData) + 1, LEN(@RowData))
		SET @Cnt = @Cnt + 1
	END
	
	INSERT INTO @RtnValue(Item)
	SELECT Item = LTRIM(RTRIM(@RowData))

	RETURN
END

