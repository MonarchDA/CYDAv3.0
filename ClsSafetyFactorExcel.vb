Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System.Data
Imports System.IO
Public Class ClsSafetyFactorExcel
    Private _strCurrentWorkingDirectory As String = System.Environment.CurrentDirectory
    Private _strMotherExcelPath As String = _strCurrentWorkingDirectory + "\SafetyFactorCalculation.xls"
    Private _strchildExcelPath As String = _strCurrentWorkingDirectory + "\Reports\" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber + "SafetyFactorCalculation.xls"
    Private _strCodeNumber As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber
    Public strSwingClearenceFileLocation As String = String.Empty
    Dim TempExcelApp As Excel.Application
    Dim TempWorkBook As Excel.Workbook
    Dim tempWorkSheet As Excel.Worksheet
    Dim Rng As Excel.Range

    Public Sub CalculateSafetyFactor()

        Try
            Dim TempExcelApp As Excel.Application
            Dim TempWorkBook As Excel.Workbook
            Dim tempWorkSheet As Excel.Worksheet
            Dim Rng As Excel.Range
            TempExcelApp = New Excel.Application
            TempExcelApp.Visible = False

            TempWorkBook = TempExcelApp.Workbooks.Open(System.Environment.CurrentDirectory & "\SafetyFactorCalculation.xls")
            tempWorkSheet = TempExcelApp.Sheets("SF and Stress Calcs")
            'cylinder forces
            Rng = tempWorkSheet.Range("B4")
            Rng.Value = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter
            Rng = tempWorkSheet.Range("B5")
            Rng.Value = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter
            Rng = tempWorkSheet.Range("B6")
            Rng.Value = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure

            'Double Lug Base End

            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" Then
                Rng = tempWorkSheet.Range("E17")
                Rng.Value = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                Rng = tempWorkSheet.Range("E18")
                Rng.Value = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth
                Rng = tempWorkSheet.Range("E19")
                Rng.Value = "2"
                Rng = tempWorkSheet.Range("E20")
                Rng.Value = Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize) + 0.01
            Else
                Rng = tempWorkSheet.Range("E17")
                Rng.Value = "0"
                Rng = tempWorkSheet.Range("E18")
                Rng.Value = "0"
                Rng = tempWorkSheet.Range("E19")
                Rng.Value = "0"
                Rng = tempWorkSheet.Range("E20")
                Rng.Value = "0"

            End If

            'Cross Tube 

            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Cross Tube" Then
                Rng = tempWorkSheet.Range("B17")
                Rng.Value = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD
                Rng = tempWorkSheet.Range("B18")
                Rng.Value = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth
                Rng = tempWorkSheet.Range("B19")
                Rng.Value = Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize) + 0.01
            Else
                Rng = tempWorkSheet.Range("B17")
                Rng.Value = "0"
                Rng = tempWorkSheet.Range("B18")
                Rng.Value = "0"
                Rng = tempWorkSheet.Range("B19")
                Rng.Value = "0"

            End If
            ' Rod End
            'Double Lug
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug" Then
                Rng = tempWorkSheet.Range("E44")
                Rng.Value = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd
                Rng = tempWorkSheet.Range("E45")
                Rng.Value = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd
                Rng = tempWorkSheet.Range("E46")
                Rng.Value = "2"
                Rng = tempWorkSheet.Range("E47")
                Rng.Value = Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize) + 0.01
            Else
                Rng = tempWorkSheet.Range("E44")
                Rng.Value = "0"
                Rng = tempWorkSheet.Range("E45")
                Rng.Value = "0"
                Rng = tempWorkSheet.Range("E46")
                Rng.Value = "0"
                Rng = tempWorkSheet.Range("E47")
                Rng.Value = "0"
            End If

            'Cross Tube 

            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Cross Tube" Then
                Rng = tempWorkSheet.Range("B44")
                Rng.Value = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD_RodEnd
                Rng = tempWorkSheet.Range("B45")
                Rng.Value = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd
                Rng = tempWorkSheet.Range("B46")
                Rng.Value = Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize) + 0.01
            Else
                Rng = tempWorkSheet.Range("B44")
                Rng.Value = "0"
                Rng = tempWorkSheet.Range("B45")
                Rng.Value = "0"
                Rng = tempWorkSheet.Range("B46")
                Rng.Value = "0"
            End If

            Rng = tempWorkSheet.Range("B32")
            Rng.Value = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonNutSizeInDecimals
            Rng = tempWorkSheet.Range("B38")
            Rng.Value = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadSize_RodEnd

            TempWorkBook.Save()
            TempWorkBook.Close()
            If Not Directory.Exists("K:\Design Engineering Files\Design review checklist & SF calculation sheet\SF calculation sheet\") Then
                Directory.CreateDirectory("K:\Design Engineering Files\Design review checklist & SF calculation sheet\SF calculation sheet\")
            End If
            File.Copy(_strMotherExcelPath, "K:\Design Engineering Files\Design review checklist & SF calculation sheet\SF calculation sheet\" + _strCodeNumber + " SafetyFactorCalculation.xls")
        Catch ex As Exception

        End Try



    End Sub
End Class
