Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Collections
Imports DevExpress.XtraVerticalGrid.ViewInfo
Imports DevExpress.XtraVerticalGrid.Events
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraEditors.DXErrorProvider

Namespace WindowsApplication1
	Partial Public Class Form1
		Inherits Form


		Public Sub New()
			InitializeComponent()
		End Sub

		Private Function GetRowInfo(ByVal e As CustomDrawRowValueCellEventArgs) As BaseRowViewInfo
			Dim rowsViewInfo As ArrayList = propertyGridControl1.ViewInfo.RowsViewInfo
			For i As Integer = 0 To rowsViewInfo.Count - 1
				Dim info As BaseRowViewInfo = TryCast(rowsViewInfo(i), BaseRowViewInfo)
                If info.Row.Equals(e.Row) Then
					Return info
				End If
			Next i
			Return Nothing
		End Function

		Public Function GetEditorViewInfo(ByVal rowInfo As BaseRowViewInfo, ByVal e As CustomDrawRowValueCellEventArgs) As BaseEditViewInfo
			If rowInfo Is Nothing Then
				Return Nothing
			End If
			For i As Integer = 0 To rowInfo.ValuesInfo.Count - 1
				Dim valuesInfo As RowValueInfo = rowInfo.ValuesInfo(i)
				If valuesInfo.RecordIndex = e.RecordIndex AndAlso valuesInfo.RowCellIndex = e.CellIndex Then
					Return valuesInfo.EditorViewInfo
				End If
			Next i
			Return Nothing
		End Function

		Private Sub propertyGridControl1_CustomDrawRowValueCell(ByVal sender As Object, ByVal e As CustomDrawRowValueCellEventArgs) Handles propertyGridControl1.CustomDrawRowValueCell
			If e.CellValue IsNot Nothing Then
				Return
			End If
			Dim rowInfo As BaseRowViewInfo = GetRowInfo(e)
			Dim editViewInfo As BaseEditViewInfo = GetEditorViewInfo(rowInfo, e)
			editViewInfo.ErrorIconText = "IsNull"
			editViewInfo.ShowErrorIcon = True
			editViewInfo.FillBackground = True
			editViewInfo.ErrorIcon = DXErrorProvider.GetErrorIconInternal(ErrorType.Critical)
			editViewInfo.CalcViewInfo(e.Graphics)
		End Sub



	End Class
End Namespace