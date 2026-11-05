CREATE  VIEW dbo.EGWR_DiagramasDiario
AS
SELECT     df.Fecha, CASE WHEN df.Id_Personal = 0 THEN '' ELSE df.Id_Personal END AS Legajo, CASE WHEN P.Apellido IS NULL THEN '' ELSE RTRIM(LTRIM(p.Apellido)) + ', ' + RTRIM(LTRIM(p.Nombre)) 
                      END AS Nombre, df.Id_Coche AS Interno, df.NroServicio, df.Turno, CONVERT(VARCHAR(5), ds.HoraCitacion, 114) AS Citacion, CONVERT(VARCHAR(5), ds.HoraFinalizacion, 114) AS Finalizacion, 
                      e.Nombre AS Empresa, l.Descripcion AS Linea, REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(r.Descripcion, 'º', ''), '°', 
                      ''), 'Á', 'A'), 'É', 'E'), 'Í', 'I'), 'Ó', 'O'), 'Ú', 'U'), 'á', 'a'), 'é', 'e'), 'í', 'i'), 'ó', 'o'), 'ú', 'u') AS Ramal, ts.Descripcion AS Servicio, l.Provincia, 
                      CASE WHEN ds.Comentario = '' THEN '' ELSE ds.Comentario + '/' END + ISNULL
                          ((SELECT     TOP (1) s.Descripcion
                              FROM         dbo.Diagramas_Detalle AS d INNER JOIN
                                                    dbo.Secciones AS s ON d.Id_Seccion = s.Id
                              WHERE     (d.NroServicio = ds.NroServicio) AND (d.Id_Diagrama = ds.Id_Diagrama) AND (d.UserDel IS NULL) AND (d.Hora > '20010101 00:00') AND (d.Turno = ds.Turno)
                              ORDER BY d.Turno, d.NroVuelta, s.Numero), '') AS LugarInicio
FROM         dbo.Diagramas_Fecha AS df INNER JOIN
                      dbo.Diagramas AS d ON df.Id_Diagrama = d.Id INNER JOIN
                      dbo.Diagramas_Servicios AS ds ON d.Id = ds.Id_Diagrama AND df.NroServicio = ds.NroServicio AND df.Turno = ds.Turno INNER JOIN
                      dbo.TipoServicios AS ts ON d.Id_TipoServicio = ts.Id INNER JOIN
                      dbo.Ramales AS r ON ts.Id_Ramal = r.Id INNER JOIN
                      dbo.Lineas AS l ON r.Id_Linea = l.Id INNER JOIN
                      dbo.Empresas AS e ON l.Id_Empresa = e.Id LEFT OUTER JOIN
                      dbo.Personal AS p ON df.Id_Personal = p.LaboralLegajo
WHERE     (df.UserDel IS NULL) AND (d.UserDel IS NULL) AND (ds.UserDel IS NULL)


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = -288
         Left = 0
      End
      Begin Tables = 
         Begin Table = "df"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 126
               Right = 236
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "d"
            Begin Extent = 
               Top = 6
               Left = 274
               Bottom = 126
               Right = 472
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ds"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 246
               Right = 236
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ts"
            Begin Extent = 
               Top = 126
               Left = 274
               Bottom = 246
               Right = 472
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "r"
            Begin Extent = 
               Top = 246
               Left = 38
               Bottom = 366
               Right = 236
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "l"
            Begin Extent = 
               Top = 246
               Left = 274
               Bottom = 366
               Right = 472
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "e"
            Begin Extent = 
               Top = 366
               Left = 38
               Bottom = 486
               Right = 236
            End
            DisplayFlags = 280
            TopColumn = 0
         ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'EGWR_DiagramasDiario';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'End
         Begin Table = "p"
            Begin Extent = 
               Top = 486
               Left = 38
               Bottom = 606
               Right = 249
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'EGWR_DiagramasDiario';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'EGWR_DiagramasDiario';

