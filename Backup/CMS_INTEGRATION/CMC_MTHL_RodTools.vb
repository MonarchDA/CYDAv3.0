Public Class CMC_MTHL_RodTools

    Private RodToolList As New ArrayList
    Public SequenceCount As New ArrayList          '29_09_2010     RAGAVA

    Private _dblRodDiameter As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter
    Private _strRodMaterial As String = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodMaterial).ToUpper
    Private _strTubeWeight As String 'Should be assigned a value
    Private _dblPistonNutSize As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonNutSizeInDecimals
    Private _dblDimnesion8 As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.Dimension8
    Private _dblRulesId_Rod As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RulesID_Rod

    Private Const CONTACT_PROCESS_MANAGER As String = "299801"
    Private _strQuery As String = String.Empty
    Dim _strSheetNumber As String = String.Empty

    Public Function CMSMainFunction_Rod() As ArrayList
        Try

            If _dblRulesId_Rod = 1001 Then
                GetTools_010_Logic()
                GetSheetNames020_01_03()
                If Not String.IsNullOrEmpty(_strSheetNumber) Then
                    GetTools_020_Logic()
                End If
            ElseIf _dblRulesId_Rod = 1002 Then
                GetTools_010_Logic()
                GetSheetNames020_02_04()
                If Not String.IsNullOrEmpty(_strSheetNumber) Then
                    GetTools_020_Logic()
                End If
                IsSheet030_Cast_Lathe()
                IsSheet040_Manual()
                GetTools_41_1()      '08_10_2010   RAGAVA
            ElseIf _dblRulesId_Rod = 1003 Then
                GetTools_010_Logic()
                GetSheetNames020_02_04()
                If Not String.IsNullOrEmpty(_strSheetNumber) Then
                    GetTools_020_Logic()
                End If
                GetTools_050_Logic()
            ElseIf _dblRulesId_Rod = 1004 Then
                GetTools_010_Logic()
                GetSheetNames020_02_04()
                If Not String.IsNullOrEmpty(_strSheetNumber) Then
                    GetTools_020_Logic()
                End If
                IsSheet030_Cast_Lathe()
                IsSheet040_Manual()
                If ObjClsWeldedCylinderFunctionalClass.strManual_Lathe = "Manual" Then    '08_10_2010    RAGAVA
                    GetTools_41_1()
                    GetTools_050_Logic()
                Else
                    GetTools_050_Logic()
                End If
            ElseIf _dblRulesId_Rod = 1005 Then
                GetSheetNames020_01_03()
                If Not String.IsNullOrEmpty(_strSheetNumber) AndAlso _strSheetNumber = clsTableNames.strSheet_020_01 Then
                    GetTools_020_Logic()
                End If
            ElseIf _dblRulesId_Rod = 1006 Then
                GetSheetNames020_02_04()
                If Not String.IsNullOrEmpty(_strSheetNumber) AndAlso _strSheetNumber = clsTableNames.strSheet_020_02 Then
                    GetTools_020_Logic()
                End If
                IsSheet030_Cast_Lathe()
                IsSheet040_Manual()
                '08_10_2010   RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.strManual_Lathe = "Manual" Then
                    GetTools_41_1()
                End If
                'Till   Here
            ElseIf _dblRulesId_Rod = 1007 Then
                GetSheetNames020_02_04()
                If Not String.IsNullOrEmpty(_strSheetNumber) AndAlso _strSheetNumber = clsTableNames.strSheet_020_02 Then
                    GetTools_020_Logic()
                End If
                GetTools_050_Logic()
            ElseIf _dblRulesId_Rod = 1008 Then
                GetSheetNames020_02_04()
                If Not String.IsNullOrEmpty(_strSheetNumber) AndAlso _strSheetNumber = clsTableNames.strSheet_020_02 Then
                    GetTools_020_Logic()
                End If
                IsSheet030_Cast_Lathe()
                IsSheet040_Manual()
                If ObjClsWeldedCylinderFunctionalClass.strManual_Lathe = "Manual" Then
                    GetTools_41_1()
                    GetTools_050_Logic()
                Else
                    GetTools_050_Logic()
                End If
            End If
            Return RodToolList   'returning arraylist
        Catch ex As Exception

        End Try
    End Function

#Region "Sub Sheets"

#Region "Common"

    Private Sub TubeWeight(ByVal Sequence As String)
        If _strTubeWeight > 40 Then '40lbs should be converted
            RodToolList.Add(Sequence & "&" & "CAUTION WEIGHT")
        End If
    End Sub

    Private Sub WPDS_Logic(ByVal Sequence As String)
        Try
            If (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConnectionType = "Welded") _
                              OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Cross Tube" _
                              OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Single Lug" _
                              OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "BH" Then

                Dim dblWeldSize As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEnd
                Dim strWPDS_Value As String = String.Empty

                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Cross Tube" AndAlso ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Fabricated" Then
                    strWPDS_Value = CrossTube_Query(clsTableNames.strCrosstube_FabricationTableName, dblWeldSize)
                ElseIf ObjClsWeldedCylinderFunctionalClass.strManual_Lathe = "Manual" Then
                    strWPDS_Value = CrossTube_Query(clsTableNames.strULug_ManualTableName, dblWeldSize)
                ElseIf ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Cast" Then
                    strWPDS_Value = CrossTube_Query(clsTableNames.strCastingTableName, dblWeldSize)
                ElseIf ObjClsWeldedCylinderFunctionalClass.strManual_Lathe = "Lathe" Then
                    strWPDS_Value = CrossTube_Query(clsTableNames.strULug_LatheTableName, dblWeldSize)
                End If

                If Not String.IsNullOrEmpty(strWPDS_Value) Then
                    RodToolList.Add(Sequence & "&" & strWPDS_Value)
                Else
                    RodToolList.Add(Sequence & "299800")          '20_10_2010     RAGAVA
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CaliperLogic(ByVal Sequence As String)
        Try
            Dim dblRodLength As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodLength
            If dblRodLength < 8 Then
                RodToolList.Add(Sequence & "&" & "C0011")
            ElseIf dblRodLength >= 8 AndAlso dblRodLength < 24 Then
                'RodToolList.Add(Sequence & "&" & "C0022")
                RodToolList.Add(Sequence & "&" & "C0047")       '06_01_2011   RAGAVA
            ElseIf dblRodLength >= 24 AndAlso dblRodLength <= 40 Then
                'RodToolList.Add(Sequence & "&" & "C00184")
                RodToolList.Add(Sequence & "&" & "C0184")           '02_11_2010   RAGAVA
            ElseIf dblRodLength > 40 Then
                'RodToolList.Add(Sequence & "&" & "299801")         'CONTACT_PROCESS_MANAGER
                RodToolList.Add(Sequence & "&" & "500463")            '06_01_2011   RAGAVA
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ODMicrometerLogic(ByVal Sequence As String)
        Try
            If _dblPistonNutSize < 1 Then
                RodToolList.Add(Sequence & "&" & "M001")
            ElseIf _dblPistonNutSize >= 1 AndAlso _dblPistonNutSize < 2 Then
                RodToolList.Add(Sequence & "&" & "M002")
            End If
        Catch ex As Exception

        End Try
    End Sub

    'THIS IS THE CORRECT LOGIC 
    'IN EXCEL IT IS DIFFERENT
    Private Sub BladeMicrometerLogic(ByVal Sequence As String)
        Try
            Dim GrooveDiameter As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadSize_RodEnd
            If GrooveDiameter <= 1 Then
                RodToolList.Add(Sequence & "&" & "M003")
            ElseIf GrooveDiameter > 1 Then
                RodToolList.Add(Sequence & "&" & "M004")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PistonEndThreadAndShankGaugeLogic(ByVal Sequence As String)
        Try
            Dim strThreadGauge As String = String.Empty
            Dim strShankGauge As String = String.Empty
            If _dblPistonNutSize = 0.5 Then
                strThreadGauge = "v5"
                strShankGauge = "rg32"
            ElseIf _dblPistonNutSize = 0.625 Then
                strThreadGauge = "v7"
                strShankGauge = "rg34"
            ElseIf _dblPistonNutSize = 0.75 Then
                strThreadGauge = "v8"
                strShankGauge = "rg26"
            ElseIf _dblPistonNutSize = 0.875 Then
                strThreadGauge = "v9"
                strShankGauge = "rg33"
            ElseIf _dblPistonNutSize = 1.0 Then
                'strThreadGauge = "v50"
                strThreadGauge = "v11"            '05_01_2011    RAGAVA
                strShankGauge = "rg27"
            ElseIf _dblPistonNutSize = 1.125 Then
                strThreadGauge = "v12"
                strShankGauge = "rg28"
            ElseIf _dblPistonNutSize = 1.25 Then
                strThreadGauge = "v13"
                strShankGauge = "rg29"
            ElseIf _dblPistonNutSize = 1.5 Then
                strThreadGauge = "v14"
                strShankGauge = "rg30"
            End If
            If Not String.IsNullOrEmpty(strThreadGauge) Then
                RodToolList.Add(Sequence & "&" & strThreadGauge)
            End If
            If Not String.IsNullOrEmpty(strShankGauge) Then
                RodToolList.Add(Sequence & "&" & strShankGauge)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub InductionHardenedBlanksLogic(ByVal Sequence As String)
        Try
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.cmbRodMaterial.Text = "Induction Hardened" Then       '11_10_2010   RAGAVA
                Dim dblThreadedSize As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadSize_RodEnd
                Dim dblWeldedSize As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEnd + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SkimWidth
                Dim dblChamferSize As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ChamferSize_RodEnd
                Dim dblChamferAngle As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ChamferAngle_RodEnd
                Dim dblFlatWithChamferSize As Double = dblChamferSize * (Math.Tan(dblChamferAngle * (Math.PI / 180)))
                Dim strStamped_Load As String = String.Empty
                Dim dblDrilledPinHoleSize As Double = 0

                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Flat With Chamfer" Then
                    strStamped_Load = LoadStamped(dblFlatWithChamferSize)
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Drilled Pin Hole" Then
                    strStamped_Load = LoadStamped(dblDrilledPinHoleSize)
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Threaded Rod" OrElse _
                                                          (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug" AndAlso _
                                                           ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConnectionType = "Threaded") Then
                    strStamped_Load = LoadStamped(dblThreadedSize)
                Else
                    strStamped_Load = LoadStamped(dblWeldedSize)
                End If
                If Not String.IsNullOrEmpty(strStamped_Load) Then
                    RodToolList.Add(Sequence & "&" & strStamped_Load)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function LoadStamped(ByVal dblSize As Double) As String
        Try
            '07_12_2010    RAGAVA
            'LoadStamped = String.Empty
            'If _dblDimnesion8 > dblSize Then
            '    LoadStamped = "Load Stamped end out"
            'Else
            '    LoadStamped = "Load Stamped end in"
            'End If
            LoadStamped = ""
            If _dblDimnesion8 > dblSize Then
                LoadStamped = "LOAD ROD IN"
            Else
                LoadStamped = "LOAD ROD OUT"
            End If
            Return LoadStamped
            'Till    Here
        Catch ex As Exception
        End Try
    End Function

    Private Sub ClevisEndThreadGaugeLogic(ByVal Sequence As String)
        Try
            Dim dblClevisThreadSize As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadSize_RodEnd
            Dim strThreadGauge As String = String.Empty
            If dblClevisThreadSize = 1.125 Then
                strThreadGauge = "v31"
            ElseIf dblClevisThreadSize = 1.25 Then
                strThreadGauge = "v29"
            ElseIf dblClevisThreadSize = 1.375 Then
                strThreadGauge = "v30"
            ElseIf dblClevisThreadSize = 1.5 Then
                strThreadGauge = "v28"
            End If
            If Not String.IsNullOrEmpty(strThreadGauge) Then
                RodToolList.Add(Sequence & "&" & strThreadGauge)
            End If

        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region "Sheet 010"

    Private Sub GetTools_010_Logic()
        Try
            If _strRodMaterial = "CHROME" OrElse _strRodMaterial = "LION 1000" Then
                RodToolList.Add("10&WI10-E-25")
                RodToolList.Add("10&WI09-E-79")
            ElseIf UCase(_strRodMaterial).IndexOf("NITRO") <> -1 Then
                RodToolList.Add("10&WI10-E-25")
                RodToolList.Add("10&WI09-E-79")
            End If
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRodWeldmentWeight > 40 Then
                RodToolList.Add("10&CAUTION WEIGHT")
            End If
            Dim nCount As Integer = 0
            If SequenceCount.Count > 0 Then
                For i As Integer = 0 To SequenceCount.Count - 1
                    nCount = nCount + SequenceCount(i)
                Next
            End If
            SequenceCount.Add(RodToolList.Count - nCount)
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Sheet 020"

    Private Sub GetTools_020_Logic()
        Try

            RodToolList.Add("20&WI10-E-25")

            '08_10_2010    RAGAVA  Commented
            'Dim strPartNumber As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("ROD_WELDMENT")
            'If Not String.IsNullOrEmpty(strPartNumber) Then
            '    RodToolList.Add(strPartNumber)
            'End If

            CaliperLogic("20")
            ODMicrometerLogic("20")
            BladeMicrometerLogic("20")
            PistonEndThreadAndShankGaugeLogic("20")

            If _strSheetNumber = clsTableNames.strSheet_020_01 OrElse _strSheetNumber = clsTableNames.strSheet_020_03 Then
                ClevisEndThreadGaugeLogic("20")
            End If
            If _strSheetNumber = clsTableNames.strSheet_020_01 OrElse _strSheetNumber = clsTableNames.strSheet_020_02 Then
                InductionHardenedBlanksLogic("20")
            End If
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRodWeldmentWeight > 40 Then
                RodToolList.Add("20&CAUTION WEIGHT")
            End If
            Dim nCount As Integer = 0
            If SequenceCount.Count > 0 Then
                For i As Integer = 0 To SequenceCount.Count - 1
                    nCount = nCount + SequenceCount(i)
                Next
            End If
            SequenceCount.Add(RodToolList.Count - nCount)
        Catch ex As Exception

        End Try
    End Sub

   

    Private Sub GetSheetNames020_01_03()
        Try
            If _strRodMaterial = "CHROME" OrElse _strRodMaterial = "LION 1000" Then
                _strSheetNumber = clsTableNames.strSheet_020_01
            ElseIf UCase(_strRodMaterial).IndexOf("NITRO") <> -1 Then
                _strSheetNumber = clsTableNames.strSheet_020_03
            Else
                _strSheetNumber = String.Empty
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GetSheetNames020_02_04()
        Try
            If _strRodMaterial = "CHROME" OrElse _strRodMaterial = "LION 1000" Then
                _strSheetNumber = clsTableNames.strSheet_020_02
            ElseIf UCase(_strRodMaterial).IndexOf("NITRO") <> -1 Then       '02_11_2010   RAGAVA
                _strSheetNumber = clsTableNames.strSheet_020_04
            Else
                _strSheetNumber = String.Empty
            End If
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "Sheet 030"

    Private Sub GetTools_030_Logic()
        Try
            RodToolList.Add("30&WI09-E-65")
            WPDS_Logic("30")
            RodToolList.Add("30&299801")
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRodWeldmentWeight > 40 Then
                RodToolList.Add("30&CAUTION WEIGHT")
            End If


            '29_09_2010    RAGAVA
            Dim nCount As Integer = 0
            If SequenceCount.Count > 0 Then
                For i As Integer = 0 To SequenceCount.Count - 1
                    nCount = nCount + SequenceCount(i)
                Next
            End If
            SequenceCount.Add(RodToolList.Count - nCount)
            'Till   Here
        Catch ex As Exception

        End Try
    End Sub

    Private Sub IsSheet030_Cast_Lathe()
        Try
            'ONLY FOR CASTING OR U LUG LATHE
            If ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Cast" OrElse ObjClsWeldedCylinderFunctionalClass.strManual_Lathe = "Lathe" Then
                GetTools_030_Logic()
            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Sheet 040"

    Private Sub GetTools_040_Logic()
        Try
            RodToolList.Add("40&WI09-E-69")

            If _strSheetNumber = clsTableNames.strSheet_040_02 Then
                WPDS_Logic("40")
                RodToolList.Add("40&Roller Jig")
            Else
                RodToolList.Add("40&" & CONTACT_PROCESS_MANAGER)
            End If
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRodWeldmentWeight > 40 Then
                RodToolList.Add("40&CAUTION WEIGHT")
            End If

            '29_09_2010    RAGAVA
            Dim nCount As Integer = 0
            If SequenceCount.Count > 0 Then
                For i As Integer = 0 To SequenceCount.Count - 1
                    nCount = nCount + SequenceCount(i)
                Next
            End If
            SequenceCount.Add(RodToolList.Count - nCount)
            'Till   Here
        Catch ex As Exception

        End Try
    End Sub

    '08_10_2010   RAGAVA
    Private Sub GetTools_41_1()
        Try
            'ONLY FOR MANUAL 
            If ObjClsWeldedCylinderFunctionalClass.strManual_Lathe = "Manual" Then         '13_10_2010   RAGAVA
                RodToolList.Add("41&WI09-E-69")
                WPDS_Logic("41")
                RodToolList.Add("41&Roller Jig")
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRodWeldmentWeight > 40 Then
                    RodToolList.Add("41&CAUTION WEIGHT")
                End If
                Dim nCount As Integer = 0
                If SequenceCount.Count > 0 Then
                    For i As Integer = 0 To SequenceCount.Count - 1
                        nCount = nCount + SequenceCount(i)
                    Next
                End If
                SequenceCount.Add(RodToolList.Count - nCount)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub IsSheet040_Manual()
        Try
            'ONLY FOR MANUAL 
            If ObjClsWeldedCylinderFunctionalClass.strManual_Lathe = "Manual" Then
                GetTools_040_Logic()
            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Sheet 050"
    Private Sub GetTools_050_Logic()
        Try
            RodToolList.Add("50&" & CONTACT_PROCESS_MANAGER)
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRodWeldmentWeight > 40 Then
                RodToolList.Add("50&CAUTION WEIGHT")
            End If
            Dim nCount As Integer = 0
            If SequenceCount.Count > 0 Then
                For i As Integer = 0 To SequenceCount.Count - 1
                    nCount = nCount + SequenceCount(i)
                Next
            End If
            SequenceCount.Add(RodToolList.Count - nCount)
        Catch ex As Exception
        End Try
    End Sub
#End Region

#Region "DB Queries"

    Private Function CrossTube_Query(ByVal strTableName As String, ByVal dblWeldSize As Double) As Double

        CrossTube_Query = 0
        Try
            '12_10_2010    RAGAVA
            If (strTableName).IndexOf("REWeldSizeDetails_Casting") <> -1 Then
                _strQuery = "select top 1 WPDS from " + strTableName + " where RodDiameter = " + _dblRodDiameter.ToString + " and WeldSizeNumeric >= " + dblWeldSize.ToString
            ElseIf (strTableName).IndexOf("REULug_ManualWeldDetails") <> -1 Then
                _strQuery = "select top 1 WPDS from " + strTableName + " where RodDiameter = " + _dblRodDiameter.ToString + " and WeldSizeNumeric >= " + dblWeldSize.ToString
            ElseIf (strTableName).IndexOf("REULug_LatheWeldDetails") <> -1 Then
                _strQuery = "select top 1 WPDS from " + strTableName + " where RodDiameter = " + _dblRodDiameter.ToString + " and WeldSize >= " + dblWeldSize.ToString
            Else
                _strQuery = "select WPDS from " + strTableName + " where RodDiameter = " + _dblRodDiameter.ToString + " and WeldSize = " + dblWeldSize.ToString
            End If
            '_strQuery = "select WPDS from " + strTableName + " where RodDiameter = " + _dblRodDiameter.ToString + " and WeldSize = " + dblWeldSize.ToString
            'Till   here
            CrossTube_Query = MonarchConnectionObject.GetValue(_strQuery)
        Catch ex As Exception
            CrossTube_Query = 0
        End Try
    End Function

#End Region

#End Region

End Class

Public Class clsTableNames

    Public Const strCastingTableName As String = "Welded.REWeldSizeDetails_Casting"
    Public Const strCrosstube_FabricationTableName As String = "dbo.RECT_ManualWeldDetails"
    Public Const strULug_ManualTableName As String = "Welded.REULug_ManualWeldDetails"
    Public Const strULug_LatheTableName As String = "Welded.REULug_LatheWeldDetails"

    Public Const strSheet_020_01 As String = "Sheet 020-01"
    Public Const strSheet_020_02 As String = "Sheet 020-02"
    Public Const strSheet_020_03 As String = "Sheet 020-03"
    Public Const strSheet_020_04 As String = "Sheet 020-04"
    Public Const strSheet_040_02 As String = "Sheet 040-02"
End Class

