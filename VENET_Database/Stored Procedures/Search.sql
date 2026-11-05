
create Procedure [dbo].[Search]
	@SearchText VarChar(500)
	, @SearchInData Int = 0
As

Set NoCount On

Create Table #Tmp
(
	Name VarChar(MAX)
	, ObjectType VarChar(50)
	, Reference VarChar(MAX)
	, IsPK Int Null
)

-- Busca en stored procedures
Insert Into #Tmp
Select Distinct
	SO.Name
	, 'C - Stored Procedure' ObjectType
	, Null --SubString(SC.Text, CharIndex(SC.Text, @SearchText), 50)
	, Null
From
	SysObjects SO Inner Join SysComments SC
		On SO.Id = SC.Id
Where
	SC.Text Like '%' + @SearchText + '%'
	And SO.Type = 'P'


-- Busca en nombres de objetos
Insert Into #Tmp
Select Distinct
	SO.Name
	, 'A - Table' ObjectType
	, 'Select * From ' + SO.Name + ' (NoLock)'
	, Null
From
	SysObjects SO
Where
	SO.Name Like '%' + @SearchText + '%'
	And SO.Type = 'U'


-- Busca en columnas de tablas
Insert Into #Tmp
Select Distinct
	SO.Name + '.' + SC.Name Name
	, 'B - Column' ObjectType
	, 'Select Distinct ' + SC.Name + ' From ' + SO.Name + ' (NoLock) GO Select * From ' + SO.Name + ' (NoLock)'
	, (
		Select
			Count(1)
		From
			SysIndexes si Join SysObjects so2
				On si.Id = so2.Id
			Join SysObjects pk
				On si.Name = pk.Name
				And pk.parent_obj = si.Id
				And pk.xtype = 'PK'
			Join SysIndexkeys ik
				On si.Id = ik.Id
				And si.IndId = ik.IndId
			Join SysColumns sc2
				On ik.Id = sc2.Id
				And ik.ColId = sc2.ColId
		Where
			so2.Id = SO.Id
			And sc2.ColId = SC.ColId
	)
From
	SysObjects SO Inner Join SysColumns SC
		On SO.Id = SC.Id
Where
	SC.Name Like '%' + @SearchText + '%'
	And SO.Type = 'U'


-- Busca en parámetros de stored procedures
Insert Into #Tmp
Select Distinct
	SO.Name + '.' + SC.Name Name
	, 'D - Parameter' ObjectType
	, Null
	, Null
From
	SysObjects SO Inner Join SysColumns SC
		On SO.Id = SC.Id
Where
	SC.Name Like '%' + @SearchText + '%'
	And SO.Type = 'P'





-- Busca en datos
If @SearchInData = 1
Begin
	Declare @IsGUID Int
	Declare @TmpGUID UniqueIdentifier

	Begin Try
		Set @TmpGUID = Convert(UniqueIdentifier, @SearchText)
		Set @IsGUID = 1
	End Try
	Begin Catch
		Set @IsGUID = 0
	End Catch

	Declare @SQL VarChar(MAX)
	Declare @Reference VarChar(MAX)
	Declare @Condition VarChar(MAX)
	Declare @TableName VarChar(500)
	Declare @TableId Int
	Declare @ColumnName VarChar(500)
	Declare @ColumnDataType Int

	Declare curTables INSENSITIVE Cursor For
	Select
		so.Id
		, so.Name
	From
		SysObjects so
	Where
		so.Type = 'U'

	Open curTables
	Fetch Next From curTables Into @TableId, @TableName
	While @@Fetch_Status = 0
	Begin
		Declare curColumns INSENSITIVE Cursor For
		Select
			sc.Name
			, sc.xType
		From
			SysColumns sc
		Where
			sc.Id = @TableId

		Open curColumns
		Fetch Next From curColumns Into @ColumnName, @ColumnDataType
		While @@Fetch_Status = 0
		Begin
			Set @Condition = Null

			If @IsGUID = 1 And @ColumnDataType = 36 --UniqueIdentifier
			Begin
				Set @Condition = '''%' + @SearchText + '%'''
			End
	
			If @ColumnDataType = 167 --VarChar
			Begin
				Set @Condition = '''%' + @SearchText + '%'''
			End

			If @Condition Is Not Null
			Begin

				Declare @IsKey Int

				Select
					@IsKey = Count(1)
				From
					SysIndexes si Join SysObjects so
						On si.Id = so.Id
					Join SysObjects pk
						On si.Name = pk.Name
						And pk.parent_obj = si.Id
						And pk.xtype = 'PK'
					Join SysIndexkeys ik
						On si.Id = ik.Id
						And si.IndId = ik.IndId
					Join SysColumns sc
						On ik.Id = sc.Id
						And ik.ColId = sc.ColId
				Where
					so.Id = @TableId
					And sc.Name = @ColumnName


				Set @Reference = 'Select ' + @ColumnName + ', * From ' + @TableName + ' (NoLock) Where [' + @ColumnName + '] Like ' + @Condition
				Set @Reference = Replace(@Reference, '''', '''''')
				Set @SQL = 'Insert Into #Tmp Select Distinct ''' + @TableName + ''', ''E - Data'', ''' + @Reference + ''', ' + Convert(VarChar(10), @IsKey) + ' From ' + @TableName + ' (NoLock) Where [' + @ColumnName + '] Like ' + @Condition

				Execute (@Sql)
				--Print @SQL
			End

			Fetch Next From curColumns Into @ColumnName, @ColumnDataType
		End
		Close curColumns
		Deallocate curColumns

		Fetch Next From curTables Into @TableId, @TableName
	End
	Close curTables
	Deallocate curTables

End

-- Muestra el resultado
Select
	IsPK = Case IsPK
		When 0 Then 'N'
		When 1 Then 'Y'
		Else 'NA'
	End
	, Name
	, SubString(ObjectType, 5, 200) ObjectType
	, Reference
From
	#Tmp
Order By
	#Tmp.ObjectType
	, IsPK Desc
	, #Tmp.Name

Drop Table #Tmp

