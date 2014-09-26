Imports System.IO
Public Class clsCNCUtil

    Private _message As String

    Public ReadOnly Property Message() As String
        Get
            Return _message
        End Get
    End Property

    Public Function DoCNCCodeGeneration() As Boolean

        Try
            _message = String.Empty
            Dim oCYLRos As CYL_Rod
            oCYLRos = CreateInstance()
            ' oCYLRos = Test()
            CNCFilePath()
            Dim strFilePath As String = StringConstants.CNCC.FolderPath & oCYLRos.ProgNo


            '22_06_2011   RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.IsReleaseCylinderChecked = False Then
                strFilePath = "C:\WELDED_TESTING\CNC_TEMP\" & oCYLRos.ProgNo
                If Not Directory.Exists("C:\WELDED_TESTING\CNC_TEMP\") Then
                    Directory.CreateDirectory("C:\WELDED_TESTING\CNC_TEMP\")
                End If
            End If
            'Till   Here


            Dim oCYL_RodService As New CYL_RodService
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.DoesPartCodeExist(oCYLRos) Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.UpdateCyl_RodData(oCYLRos)
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.InsertCyl_RodData(oCYLRos)
            End If

            If oCYL_RodService.Start(strFilePath, oCYLRos) Then
                Return True
            Else
                _message = oCYL_RodService.Message
                Return False
            End If

        Catch ex As Exception
            _message = "CNC Code Generation Failed." & vbLf & ex.Message
            Return False
        End Try
    End Function

    Private Sub CNCFilePath()
        Try
            If Not Directory.Exists(StringConstants.CNCC.FolderPath) Then
                Directory.CreateDirectory(StringConstants.CNCC.FolderPath)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function Test() As CYL_Rod
        Dim oCYLRos As New CYL_Rod
        oCYLRos.NominalThreadDia = 1
        oCYLRos.LargeDia = 1.25
        oCYLRos.SmallDia = 1.001
        oCYLRos.TH_Per_IN = 14
        oCYLRos.ShoulderType = "Chamfer"
        oCYLRos.RodType = "Chrome"
        oCYLRos.PartNo = "111111"
        oCYLRos.ByName = "MD"
        ' SetRodEndConfigValues(oCYLRos)
        oCYLRos.setDescription("RD CYL 1.00-16.00-1.25-1.13")
        oCYLRos.output2ndop = True
        oCYLRos.Secondthreaddia = 1.25
        oCYLRos.Secondoptype = "Threaded"
        oCYLRos.Secondthreadnum = 14

        oCYLRos.Drawing_Num = Val(oCYLRos.PartNo)
        oCYLRos.Xhome = 20
        oCYLRos.Zhome = 20
        oCYLRos.Operation = 20
        oCYLRos.WorkCenter = 122
        oCYLRos.AutoDoor = True
        oCYLRos.Drawing_Rev = 1
        oCYLRos.Secondopzzero = -0.03
        oCYLRos.Secondthreadcornerrad = 0.06
        oCYLRos.Secondshoulder = -0.03
        oCYLRos.skimdiameter = 1.24
        oCYLRos.chamferdepthofcut = 0.19
        ' SetExcelValues(oCYLRos)
        oCYLRos.Length = 25.26
        oCYLRos.Th_Length = 1.14
        oCYLRos.Secondthreadlength = 1.13

        oCYLRos.Secondchamfer = 0
        oCYLRos.skimlength = 0



        Return oCYLRos
    End Function


    Private Function CreateInstance() As CYL_Rod
        Dim oCYLRos As New CYL_Rod

        'ANUP 23-09-2010 START 
        Dim oRenamingHashTable As Hashtable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable
        'ANUP 23-09-2010 TILL HERE 

        oCYLRos.NominalThreadDia = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonNutSizeInDecimals
        oCYLRos.LargeDia = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter
        oCYLRos.SmallDia = oCYLRos.NominalThreadDia + 0.001
        oCYLRos.TH_Per_IN = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetTH_Per_In(oCYLRos.NominalThreadDia)
        oCYLRos.ShoulderType = "Chamfer"
        oCYLRos.RodType = RodMaterialValue()
        'ANUP 23-09-2010 START 
        oCYLRos.PartNo = oRenamingHashTable("Rod_Welded")
        'ANUP 23-09-2010 TILL HERE
        oCYLRos.ByName = "MD"
        SetRodEndConfigValues(oCYLRos)
        oCYLRos.Drawing_Num = oCYLRos.PartNo
        oCYLRos.Xhome = 20
        oCYLRos.Zhome = 20
        oCYLRos.Operation = 20
        oCYLRos.WorkCenter = 122
        oCYLRos.AutoDoor = AutoDoorValidation(oCYLRos.WorkCenter)
        oCYLRos.Drawing_Rev = 1
        oCYLRos.Secondopzzero = -0.03
        oCYLRos.Secondthreadcornerrad = 0.06
        oCYLRos.skimdiameter = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter - 0.015
        oCYLRos.chamferdepthofcut = 0.19
        SetExcelValues(oCYLRos)
        oCYLRos.Secondshoulder = Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodLength - oCYLRos.Secondthreadlength, 3)
        Return oCYLRos
    End Function


    Private Function AutoDoorValidation(ByVal dblWorkCenter As Double) As Boolean
        If dblWorkCenter = 122 Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub SetExcelValues(ByVal oCYLRos As CYL_Rod)
        Dim oReadExcel As New ReadExcel
        If Not oReadExcel.Open(StringConstants.CNCC.RodWelded_ExcelPath) Then
            Return
        End If
        oCYLRos.Length = Val(oReadExcel.Read("C5"))
        oCYLRos.Th_Length = Val(oReadExcel.Read("G5"))
        oCYLRos.Secondthreadlength = Val(oReadExcel.Read("Z5"))
        oReadExcel.Close()
    End Sub

    Private Function RodMaterialValue() As String
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodMaterial = "LION 1000" Then
            RodMaterialValue = "Chrome"
        Else
            RodMaterialValue = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodMaterial
        End If
    End Function

    Private Sub SetRodEndConfigValues(ByVal oCYLRos As CYL_Rod)
        Dim dblPistonNutS As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonNutSizeInDecimals
        Dim dblStrokeLength As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Threaded Rod" _
            OrElse (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug" _
            AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConnectionType = "Threaded") Then
            Dim dblThreadedSize As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadSize_RodEnd
            Dim dblThreadedLegth As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadLength_RodEnd

            oCYLRos.setDescription(dblPistonNutS, dblStrokeLength, dblThreadedSize, dblThreadedLegth)
            oCYLRos.output2ndop = True
            oCYLRos.Secondthreaddia = dblThreadedSize
            oCYLRos.Secondoptype = StringConstants.CNCC.Threaded
            oCYLRos.Secondthreadnum = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetTH_Per_In(dblThreadedSize)
            Return
        End If

        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Flat With Chamfer" Then
            Dim dblChamferSize As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ChamferSize_RodEnd
            oCYLRos.setDescription(dblPistonNutS, dblStrokeLength, dblChamferSize)
            oCYLRos.output2ndop = True
            oCYLRos.Secondoptype = StringConstants.CNCC.ChamferOnly
            oCYLRos.Secondchamfer = dblChamferSize
            oCYLRos.skimlength = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SkimWidth + dblChamferSize
            Return
        End If

        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Drilled Pin Hole" Then
            oCYLRos.setDescription(dblPistonNutS, dblStrokeLength)
            oCYLRos.output2ndop = False
            oCYLRos.Secondoptype = String.Empty
            Return
        End If

        'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Single Lug" _
        '  OrElse (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug" _
        '  AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConnectionType = "Welded") _
        '  OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Cross Tube" Then

        Dim dblWeldSize As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEnd
        oCYLRos.setDescription(dblPistonNutS, dblStrokeLength, dblWeldSize)

        If ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Fabricated" Then
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldPreperation_RodEnd = "Chamfer" Then
                oCYLRos.output2ndop = True
                oCYLRos.Secondoptype = StringConstants.CNCC.ChamferAndSkim
                oCYLRos.Secondchamfer = dblWeldSize
                oCYLRos.skimlength = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SkimWidth + dblWeldSize
            Else
                oCYLRos.output2ndop = False
                oCYLRos.Secondoptype = String.Empty
            End If
        Else
            oCYLRos.output2ndop = False
            oCYLRos.Secondoptype = String.Empty
        End If
        'End If

    End Sub


End Class
