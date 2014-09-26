Public Class frmHeadDesign

#Region "Private Variables"


    'TODO: ANUP 22-07-2010 12.14pm
    Private _blnIsPopulated As Boolean = False

    Public Property IsPopulated() As Boolean
        Get
            Return _blnIsPopulated
        End Get
        Set(ByVal value As Boolean)
            _blnIsPopulated = value
        End Set
    End Property

    Dim _oDataRow As DataRow
    Dim _oCylinderHeadDetailsDataRow As DataRow

    Private _dblTempBoreDiameter As Double = 0

    Private _dblTempRodDiameter As Double = 0

    Private _strCH_StandardorCompressed As String

    Private _dblCH_OverallLength As Double

    Private _dblCH_ShankLength As Double

    Private _dblCH_StaticSealPosition As Double

    Private _dblCH_StickoutfromTube As String

    Private _dblCH_RodBoreID_Seal As Double

    Private _dblCH_RodBoreID_Seal_TOL_UL As Double

    Private _dblCH_RodBoreID_Seal_TOL_LL As Double

    Private _dblCH_SealGrooveDiameter As Double

    Private _dblCH_SealGrooveDiameter_TOL_UL As Double

    Private _dblCH_SealGrooveDiameter_TOL_LL As Double

    Private _dblCH_SealGrooveWidth As Double

    Private _dblCH_SealGrooveWidth_TOL_UL As Double

    Private _dblCH_SealGrooveWidth_TOL_LL As Double

    Private _dblCH_RodBoreID_WearRing As Double

    'To be implemented
    Private _strCH_RodBoreID_WearRing_TOL_UL As String

    Private _strCH_RodBoreID_WearRing_TOL_LL As String
    '----------------

    Private _dblCH_WearRingGrooveDiameter As Double

    Private _dblCH_WearRingGrooveDiameter_TOL_UL As Double

    Private _dblCH_WearRingGrooveDiameter_TOL_LL As Double

    Private _dblCH_WearRingGrooveWidth As Double

    Private _dblCH_WearRingGrooveWidth_TOL_UL As Double

    Private _dblCH_WearRingGrooveWidth_TOL_LL As Double

    'To be implemented
    Private _strCH_RodBoreID_Wiper As String

    Private _strCH_RodBoreID_Wiper_TOL_UL As String

    Private _strCH_RodBoreID_Wiper_TOL_LL As String
    '------------------

    Private _dblCH_WiperGrooveDiameter As Double

    Private _dblCH_WiperGrooveDiameter_TOL_UL As Double

    Private _dblCH_WiperGrooveDiameter_TOL_LL As Double

    Private _dblCH_WiperGrooveWidth As Double

    Private _dblCH_WiperGrooveWidth_TOL_UL As Double

    Private _dblCH_WiperGrooveWidth_TOL_LL As Double

    Private _dblCH_WiperGrooveLeadInDia As Double

    Private _dblCH_WiperGrooveLeadInDia_TOL_UL As Double

    Private _dblCH_WiperGrooveLeadInDia_TOL_LL As Double

    Private _dblCH_StaticSealHeadDia As Double

    Private _dblCH_StaticSealHeadDia_TOL_UL As Double

    Private _dblCH_StaticSealHeadDia_TOL_LL As Double

    Private _dblCH_StaticSealNoseDia As Double

    Private _dblCH_StaticSealNoseDia_TOL_UL As Double

    Private _dblCH_StaticSealNoseDia_TOL_LL As Double

    Private _dblCH_StaticSealGrooveDia As Double

    Private _dblCH_StaticSealGrooveDia_TOL_UL As Double

    Private _dblCH_StaticSealGrooveDia_TOL_LL As Double

    Private _dblCH_StaticSealGrooveWidth As Double

    Private _dblCH_StaticSealGrooveWidth_TOL_UL As Double

    Private _dblCH_StaticSealGrooveWidth_TOL_LL As Double

    Public _strCH_CylinderHeadCode As String       '28_09_2010   RAGAVA

    Private _strCH_UCUP605_SealCode As String

    Private _strCH_ZMacro_SealCode As String

    Private _strCH_WearRingCode As String

    Private _strCH_SnapinWiperCode As String

    Private _strCH_RodSealInstallationKitcode As String

    Public _strIsExistingorNewDesign As String

    Private _strCH_ORING_CODE As String

    Private _strCH_BACKUP_RING_CODE As String

    Private _dblCH_HEAD_OD_MAX As Double

    Private _dblCH_HEAD_OD_MIN As Double

    Private _dblCH_ExternalWireRingGrooveDiaMax As Double

    Private _dblCH_ExternalWireRingGrooveDiaMin As Double

    Private _dblCH_ExternalWireRingGrooveWidthMax As Double

    Private _dblCH_ExternalWireRingGrooveWidthMin As Double

    Private _strCH_ExternalWireRingCode As String

    Private _dblCH_InternalWireRingGrooveDia_Dia2 As Double

    Private _dblCH_InternalWireRingGrooveDia_Dia1 As Double

    Private _dblCH_InternalWireRingGrooveWidthMax As Double

    Private _dblCH_InternalWireRingGrooveWidthMin As Double

    Private _strCH_InternalWireRingCode As String

    Private _dblCH_HeadProtrusion As Double

    Private _dblCH_TubeEndtoGrooveEnd As Double

    Private _dblCH_GrooveWidthTotalMin As Double

    Private _dblCH_GrooveWidthTotalMax As Double

    Private _dblCH_NoseLength As Double

    Private _dblCH_SealGrooveLocation As Double

    Private _dblCH_MAJOR_MAX As Double

    Private _dblCH_MAJOR_MIN As Double

    Private _strQuery As String

    Private _blnRowInserted As Boolean

    'ANUP 06-10-2010 START
    Public _strRodSealCode_Purchase As String = String.Empty
    Public _strWearRingCode_Purchase As String = String.Empty
    Public _strSanpInWiperCode_Purchase As String = String.Empty
    Private _strRodSealInstallationKitCode_Purchase As String = String.Empty
    Public _strORINGCode_Purchase As String = String.Empty
    Public _strBackupRINGCode_Purchase As String = String.Empty
    Public _strExternalWireRingCode_Purchase As String = String.Empty
    Public _strInternalWireCodeCode_Purchase As String = String.Empty
    'ANUP 06-10-2010 TILL HERE
#End Region

#Region "Properties"

    Public ReadOnly Property ControlsData() As ArrayList
        Get
            ControlsData = New ArrayList
            ControlsData.Add(New Object(3) {"GUI", "CH_HeadType", "I3", cmbHeadType.Text})

            If _strCH_StandardorCompressed = "C" Then
                ControlsData.Add(New Object(3) {"UnKnown", "CH_Standard or Compressed", "I4", "Compressed"})
            ElseIf _strCH_StandardorCompressed = "S" Then
                ControlsData.Add(New Object(3) {"UnKnown", "CH_Standard or Compressed", "I4", "Standard"})
            End If

            ControlsData.Add(New Object(3) {"GUI", "CH_RodSeal", "I5", cmbRodSeal.Text})
            ControlsData.Add(New Object(3) {"GUI", "CH_Rod Wiper", "I6", cmbRodWiperType.Text})
            ControlsData.Add(New Object(3) {"GUI", "CH_RodWearRing", "I7", cmbRodWearRing.Text})
            ControlsData.Add(New Object(3) {"GUI", "CH_Rod Wear Ring Qty", "I8", cmbRodWearRingQty.Text})

            'ANUP 06-10-2010 START
            ControlsData.Add(New Object(3) {"DB", "CH_Cylinder Head Code", "I55", txtCylinderHeadCode.Text})
            clsAddExistingCodes.AddCylinderHeadCode(_strCH_CylinderHeadCode, 1, "EA")
            clsAddExistingCodes.AddStaticSealCode()       '07_10_2010   RAGAVA
            clsAddExistingCodes.GetWiperSealRodDiameter(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter) 'vamsi 13-08-2014

            '11_10_2010   RAGAVA

            'vamsi 12th August 2013 start
            'Try
            '    If ObjClsWeldedCylinderFunctionalClass.ObjFrmGenerate.chkPackCylinderInPlasticBag.Checked = True Then        '08_04_2011   RAGAVA
            '        Dim tempBoreDia As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter
            '        If tempBoreDia < 5 Then
            '            If tempBoreDia < 2 Then
            '                tempBoreDia = 2
            '            ElseIf tempBoreDia = 2.25 Then
            '                tempBoreDia = 2.5
            '            End If
            '            Dim strquery As String = "Select top 1 * from BagChart where BoreDia = " & tempBoreDia.ToString & " and RetractedLength >= " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RetractedLength
            '            Dim dr As DataRow = MonarchConnectionObject.GetDataRow(strquery)
            '            If Not IsDBNull(dr("BagPartNumber")) Then
            '                clsAddExistingCodes.AddExistingCodeToHashTable("PLASTIC BAG", dr("BagPartNumber"), 1, "EA")
            '            End If
            '        End If
            '    End If
            'Catch ex As Exception
            'End Try
            'Till   Here vamsi

            'ANUP 06-10-2010 TILL HERE

            ControlsData.Add(New Object(3) {"DB", "CH_Cylinder Head Design", "I60", _strIsExistingorNewDesign})
            ControlsData.Add(New Object(3) {"DB", "CH_Overall Length", "I9", _dblCH_OverallLength})
            ControlsData.Add(New Object(3) {"DB", "CH_Shank Length", "I10", _dblCH_ShankLength})
            ControlsData.Add(New Object(3) {"DB", "CH_Static Seal Position", "I11", _dblCH_StaticSealPosition})
            ControlsData.Add(New Object(3) {"DB", "CH_Stick out from Tube", "I12", _dblCH_StickoutfromTube})
            ControlsData.Add(New Object(3) {"DB", "CH_Rod Bore ID @ Seal", "I13", _dblCH_RodBoreID_Seal})
            ControlsData.Add(New Object(3) {"DB", "CH_Rod Bore ID @ Seal TOL_UL", "I14", _dblCH_RodBoreID_Seal_TOL_UL})
            ControlsData.Add(New Object(3) {"DB", "CH_Rod Bore ID @ Seal TOL_LL", "I15", _dblCH_RodBoreID_Seal_TOL_LL})
            ControlsData.Add(New Object(3) {"DB", "CH_Seal Groove Diameter", "I16", _dblCH_SealGrooveDiameter})
            ControlsData.Add(New Object(3) {"DB", "CH_Seal Groove Diameter TOL_UL", "I17", _dblCH_SealGrooveDiameter_TOL_UL})
            ControlsData.Add(New Object(3) {"DB", "CH_Seal Groove Diameter TOL_LL", "I18", _dblCH_SealGrooveDiameter_TOL_LL})
            ControlsData.Add(New Object(3) {"DB", "CH_Seal Groove Width", "I19", _dblCH_SealGrooveWidth})
            ControlsData.Add(New Object(3) {"DB", "CH_Seal Groove Width TOL_UL", "I20", _dblCH_SealGrooveWidth_TOL_UL})
            ControlsData.Add(New Object(3) {"DB", "CH_Seal Groove Width TOL_LL", "I21", _dblCH_SealGrooveWidth_TOL_LL})
            ControlsData.Add(New Object(3) {"DB", "CH_Rod Bore ID @ Wear Ring", "I22", _dblCH_RodBoreID_WearRing})
            ControlsData.Add(New Object(3) {"DB", "CH_Rod Bore ID @ Wear Ring TOL_UL", "I23", _strCH_RodBoreID_WearRing_TOL_UL})
            ControlsData.Add(New Object(3) {"DB", "CH_Rod Bore ID @ Wear Ring TOL_LL", "I24", _strCH_RodBoreID_WearRing_TOL_LL})
            ControlsData.Add(New Object(3) {"DB", "CH_Wear Ring Groove Diameter", "I25", _dblCH_WearRingGrooveDiameter})
            ControlsData.Add(New Object(3) {"DB", "CH_Wear Ring Groove Diameter TOL_UL", "I26", _dblCH_WearRingGrooveDiameter_TOL_UL})
            ControlsData.Add(New Object(3) {"DB", "CH_Wear Ring Groove Diameter TOL_LL", "I27", _dblCH_WearRingGrooveDiameter_TOL_LL})
            ControlsData.Add(New Object(3) {"DB", "CH_Wear Ring Groove Width", "I28", _dblCH_WearRingGrooveWidth})
            ControlsData.Add(New Object(3) {"DB", "CH_Wear Ring Groove Width TOL_UL", "I29", _dblCH_WearRingGrooveWidth_TOL_UL})
            ControlsData.Add(New Object(3) {"DB", "CH_Wear Ring Groove Width TOL_LL", "I30", _dblCH_WearRingGrooveWidth_TOL_LL})

            ControlsData.Add(New Object(3) {"DB", "CH_Rod Bore ID @ Wiper", "I31", _strCH_RodBoreID_Wiper})
            ControlsData.Add(New Object(3) {"DB", "CH_Rod Bore ID @ Wiper TOL_UL", "I32", _strCH_RodBoreID_Wiper_TOL_UL})
            ControlsData.Add(New Object(3) {"DB", "CH_Rod Bore ID @ Wiper TOL_LL", "I33", _strCH_RodBoreID_Wiper_TOL_LL})

            ControlsData.Add(New Object(3) {"DB", "CH_Wiper Groove Diameter", "I34", _dblCH_WiperGrooveDiameter})
            ControlsData.Add(New Object(3) {"DB", "CH_Wiper Groove Diameter TOL_UL", "I35", _dblCH_WiperGrooveDiameter_TOL_UL})
            ControlsData.Add(New Object(3) {"DB", "CH_Wiper Groove Diameter TOL_LL", "I36", _dblCH_WiperGrooveDiameter_TOL_LL})
            ControlsData.Add(New Object(3) {"DB", "CH_Wiper Groove Width", "I37", _dblCH_WiperGrooveWidth})
            ControlsData.Add(New Object(3) {"DB", "CH_Wiper Groove Width TOL_UL", "I38", _dblCH_WiperGrooveWidth_TOL_UL})
            ControlsData.Add(New Object(3) {"DB", "CH_Wiper Groove Width TOL_LL", "I39", _dblCH_WiperGrooveWidth_TOL_LL})
            ControlsData.Add(New Object(3) {"DB", "CH_Wiper Groove LeadInDia", "I40", _dblCH_WiperGrooveLeadInDia})
            ControlsData.Add(New Object(3) {"DB", "CH_Wiper Groove LeadInDia TOL_UL", "I41", _dblCH_WiperGrooveLeadInDia_TOL_UL})
            ControlsData.Add(New Object(3) {"DB", "CH_Wiper Groove LeadInDia TOL_LL", "I42", _dblCH_WiperGrooveLeadInDia_TOL_LL})

            'Static Seal Details
            ControlsData.Add(New Object(3) {"DB", "CH_Static Seal Head Dia", "I43", _dblCH_StaticSealHeadDia})
            ControlsData.Add(New Object(3) {"DB", "CH_Static Seal Head Dia TOL_UL", "I44", _dblCH_StaticSealHeadDia_TOL_UL})
            ControlsData.Add(New Object(3) {"DB", "CH_Static Seal Head Dia TOL_LL", "I45", _dblCH_StaticSealHeadDia_TOL_LL})
            ControlsData.Add(New Object(3) {"DB", "CH_Static Seal Nose Dia", "I46", _dblCH_StaticSealNoseDia})
            ControlsData.Add(New Object(3) {"DB", "CH_Static Seal Nose Dia TOL_UL", "I47", _dblCH_StaticSealNoseDia_TOL_UL})
            ControlsData.Add(New Object(3) {"DB", "CH_Static Seal Nose Dia TOL_LL", "I48", _dblCH_StaticSealNoseDia_TOL_LL})
            ControlsData.Add(New Object(3) {"DB", "CH_Static Seal Groove Dia", "I49", _dblCH_StaticSealGrooveDia})
            ControlsData.Add(New Object(3) {"DB", "CH_Static Seal Groove Dia TOL_UL", "I50", _dblCH_StaticSealGrooveDia_TOL_UL})
            ControlsData.Add(New Object(3) {"DB", "CH_Static Seal Groove Dia TOL_LL", "I51", _dblCH_StaticSealGrooveDia_TOL_LL})
            ControlsData.Add(New Object(3) {"DB", "CH_Static Seal Groove Width", "I52", _dblCH_StaticSealGrooveWidth})
            ControlsData.Add(New Object(3) {"DB", "CH_Static Seal Groove Width TOL_UL", "I53", _dblCH_StaticSealGrooveWidth_TOL_UL})
            ControlsData.Add(New Object(3) {"DB", "CH_Static Seal Groove Width TOL_LL", "I54", _dblCH_StaticSealGrooveWidth_TOL_LL})
            '-------------

            Dim strRodSeal As String = Nothing
            If cmbRodSeal.Text = "605-U Cup" OrElse cmbRodSeal.Text = "RU9 Rod Seal" Then        '30_09_2010  RAGAVA  "RU9 Rod Seal" added
                strRodSeal = _strCH_UCUP605_SealCode
            ElseIf cmbRodSeal.Text = "Z Macro" Then
                strRodSeal = _strCH_ZMacro_SealCode
            End If

            'ANUP 06-10-2010 START 
            Dim strPartCode As String = ObjClsWeldedCylinderFunctionalClass.PartCode_Purchased_Validation(strRodSeal)
            If Not String.IsNullOrEmpty(strPartCode) Then
                _strRodSealCode_Purchase = strPartCode
            Else
                _strRodSealCode_Purchase = strRodSeal
            End If
            ControlsData.Add(New Object(3) {"DB", "CH_Seal Code", "I56", strRodSeal})
            clsAddExistingCodes.AddRodSealCode(_strRodSealCode_Purchase, 1, "EA")

            ControlsData.Add(New Object(3) {"DB", "CH_Wear Ring Code", "I57", _strCH_WearRingCode})
            strPartCode = ObjClsWeldedCylinderFunctionalClass.PartCode_Purchased_Validation(_strCH_WearRingCode)
            If Not String.IsNullOrEmpty(strPartCode) Then
                _strWearRingCode_Purchase = strPartCode
            Else
                _strWearRingCode_Purchase = _strCH_WearRingCode
            End If
            clsAddExistingCodes.AddRodWearRingCode(_strWearRingCode_Purchase, 1, "EA")

            ControlsData.Add(New Object(3) {"DB", "CH_Snap in Wiper Code", "I58", _strCH_SnapinWiperCode})
            strPartCode = ObjClsWeldedCylinderFunctionalClass.PartCode_Purchased_Validation(_strCH_SnapinWiperCode)
            If Not String.IsNullOrEmpty(strPartCode) Then
                _strSanpInWiperCode_Purchase = strPartCode
            Else
                _strSanpInWiperCode_Purchase = _strCH_SnapinWiperCode
            End If
            clsAddExistingCodes.AddSnapInWiperCode(_strSanpInWiperCode_Purchase, 1, "EA")

            '09_10_2010  RAGAVA
            Try
                Dim strZDeepRodMacroSealCode As DataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetExistingCylinderDesignData(_strCH_CylinderHeadCode)
                clsAddExistingCodes.ZDeepMacroSeal(strZDeepRodMacroSealCode("ZDeepRodMacroSeal"), 1, "EA")
            Catch ex As Exception

            End Try
           
            ControlsData.Add(New Object(3) {"DB", "CH_Rod Seal Installation Kit code", "I59", _strCH_RodSealInstallationKitcode})
            strPartCode = ObjClsWeldedCylinderFunctionalClass.PartCode_Purchased_Validation(_strCH_RodSealInstallationKitcode)
            If Not String.IsNullOrEmpty(strPartCode) Then
                _strRodSealInstallationKitCode_Purchase = strPartCode
            Else
                _strRodSealInstallationKitCode_Purchase = _strCH_RodSealInstallationKitcode
            End If
            clsAddExistingCodes.AddRodSealInstallationKitCode(_strRodSealInstallationKitCode_Purchase, 1, "EA")

            'ANUP 06-10-2010 TILL HERE

            ControlsData.Add(New Object(3) {"DB", "CH_MAJOR_MAX", "I61", _dblCH_MAJOR_MAX})
            ControlsData.Add(New Object(3) {"DB", "CH_MAJOR_MIN", "I62", _dblCH_MAJOR_MIN})

            If _strCH_StandardorCompressed = "S" Then
                If (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter - ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter) / 2 < 0.5 Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CylinderThreadedHeadChamferLength = 0.13
                Else
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CylinderThreadedHeadChamferLength = 0.31
                End If
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CylinderThreadedHeadChamferLength = 0.13
            End If

            ControlsData.Add(New Object(3) {"DB", "CH_STD_CHAMFER_24", "I63", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CylinderThreadedHeadChamferLength})
            ControlsData.Add(New Object(3) {"DB", "CH_Wiper Groove LeadInWidth", "I64", 0.093})
            ControlsData.Add(New Object(3) {"DB", "CH_STD_DIA_THREAD_UNDERCUT", "I65", 3.547})

            'ANUP 06-10-2010 START 
            'Oring and Backup Ring
            ControlsData.Add(New Object(3) {"DB", "CH_ORING_CODE", "I66", _strCH_ORING_CODE})
            strPartCode = ObjClsWeldedCylinderFunctionalClass.PartCode_Purchased_Validation(_strCH_ORING_CODE)
            If Not String.IsNullOrEmpty(strPartCode) Then
                _strORINGCode_Purchase = strPartCode
            Else
                _strORINGCode_Purchase = _strCH_ORING_CODE
            End If
            clsAddExistingCodes.AddORingCode(_strORINGCode_Purchase, 1, "EA")

            ControlsData.Add(New Object(3) {"DB", "CH_BACKUP_RING_CODE", "I67", _strCH_BACKUP_RING_CODE})
            strPartCode = ObjClsWeldedCylinderFunctionalClass.PartCode_Purchased_Validation(_strCH_BACKUP_RING_CODE)
            If Not String.IsNullOrEmpty(strPartCode) Then
                _strBackupRINGCode_Purchase = strPartCode
            Else
                _strBackupRINGCode_Purchase = _strCH_BACKUP_RING_CODE
            End If
            clsAddExistingCodes.AddBackUpRingCode(_strBackupRINGCode_Purchase, 1, "EA")
            '___________________________
            'ANUP 06-10-2010 TILL HERE

            ControlsData.Add(New Object(3) {"DB", "CH_HEAD_OD_MAX", "I68", _dblCH_HEAD_OD_MAX})
            ControlsData.Add(New Object(3) {"DB", "CH_HEAD_OD_MIN", "I69", _dblCH_HEAD_OD_MIN})
            ControlsData.Add(New Object(3) {"DB", "CH_External Wire Ring Groove Dia Max", "I70", _dblCH_ExternalWireRingGrooveDiaMax})
            ControlsData.Add(New Object(3) {"DB", "CH_External Wire Ring Groove Dia Min", "I71", _dblCH_ExternalWireRingGrooveDiaMin})
            ControlsData.Add(New Object(3) {"DB", "CH_External Wire Ring Groove Width Max", "I72", _dblCH_ExternalWireRingGrooveWidthMax})
            ControlsData.Add(New Object(3) {"DB", "CH_External Wire Ring Groove Width Min", "I73", _dblCH_ExternalWireRingGrooveWidthMin})


            '10_10_2010   RAGAVA
            Try
                If cmbHeadType.Text = "WireRing" AndAlso Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign.txtCylinderHeadCode.Text) <> "" AndAlso Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign.txtCylinderHeadCode.Text).StartsWith("N") = False Then
                    Dim strquery As String = "Select * from Welded.CylinderHeadDetails where CylinderHeadCode = '" & Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign.txtCylinderHeadCode.Text) & "'"
                    Dim dr As DataRow = MonarchConnectionObject.GetDataRow(strquery)
                    If Not IsDBNull(dr("ExternalRetainingRing")) AndAlso dr("ExternalRetainingRing") <> "N/A" Then
                        _strCH_ExternalWireRingCode = dr("ExternalRetainingRing")
                    End If
                    If Not IsDBNull(dr("InternalRetainingRing")) AndAlso dr("InternalRetainingRing") <> "N/A" Then
                        _strCH_InternalWireRingCode = dr("InternalRetainingRing")
                    End If
                End If
            Catch ex As Exception
            End Try
            'Till    Here

            'ANUP 06-10-2010 START 

            If cmbHeadType.Text = "WireRing" Then       '09_10_2010    RAGAVA
                ControlsData.Add(New Object(3) {"DB", "CH_External Wire Ring Code", "I74", _strCH_ExternalWireRingCode})
                strPartCode = ObjClsWeldedCylinderFunctionalClass.PartCode_Purchased_Validation(_strCH_ExternalWireRingCode)
                If Not String.IsNullOrEmpty(strPartCode) Then
                    _strExternalWireRingCode_Purchase = strPartCode
                Else
                    _strExternalWireRingCode_Purchase = _strCH_ExternalWireRingCode
                End If
                clsAddExistingCodes.AddExternalWireRingCode(_strExternalWireRingCode_Purchase, 1, "EA")
            Else
                ControlsData.Add(New Object(3) {"DB", "CH_External Wire Ring Code", "I74", ""})
            End If
            '-------------------------------
            'ANUP 06-10-2010 TILL HERE

            ControlsData.Add(New Object(3) {"DB", "CH_Internal Wire Ring Groove Dia1", "I75", _dblCH_InternalWireRingGrooveDia_Dia2})
            ControlsData.Add(New Object(3) {"DB", "CH_Internal Wire Ring Groove Dia2", "I76", _dblCH_InternalWireRingGrooveDia_Dia1})
            ControlsData.Add(New Object(3) {"DB", "CH_Internal Wire Ring Groove Width Max", "I77", _dblCH_InternalWireRingGrooveWidthMax})
            ControlsData.Add(New Object(3) {"DB", "CH_Internal Wire Ring Groove Width Min", "I78", _dblCH_InternalWireRingGrooveWidthMin})
            
            If cmbHeadType.Text = "WireRing" Then       '09_10_2010    RAGAVA
                ControlsData.Add(New Object(3) {"DB", "CH_Internal Wire Ring Code", "I79", _strCH_InternalWireRingCode})
                strPartCode = ObjClsWeldedCylinderFunctionalClass.PartCode_Purchased_Validation(_strCH_InternalWireRingCode)
                If Not String.IsNullOrEmpty(strPartCode) Then
                    _strInternalWireCodeCode_Purchase = strPartCode
                Else
                    _strInternalWireCodeCode_Purchase = _strCH_InternalWireRingCode
                End If
                clsAddExistingCodes.AddInternalWireRingCode(_strInternalWireCodeCode_Purchase, 1, "EA")
            Else
                ControlsData.Add(New Object(3) {"DB", "CH_Internal Wire Ring Code", "I79", ""})
            End If

            '----------------------------------
            'ANUP 06-10-2010 TILL HERE

            ControlsData.Add(New Object(3) {"DB", "CH_Head(Protrusion)", "I80", _dblCH_HeadProtrusion})
            ControlsData.Add(New Object(3) {"DB", "CH_NOSE LENGTH", "I84", _dblCH_NoseLength})
            ControlsData.Add(New Object(3) {"DB", "CH_Tube End to Groove End", "I81", _dblCH_TubeEndtoGrooveEnd})
            ControlsData.Add(New Object(3) {"CONSTANT", "CH_GROOVE WIDTH TOTAL MIN", "I82", 0.203})
            ControlsData.Add(New Object(3) {"CONSTANT", "CH_GROOVE WIDTH TOTAL MAX", "I83", 0.207})
            ControlsData.Add(New Object(3) {"DB", "CH_SEAL GROOVE LOCATION", "I85", _dblCH_SealGrooveLocation})
            '   End If
            Return ControlsData
        End Get
    End Property

#End Region

#Region "Sub Procedures"

    Private Sub DefaultSettings()
        LoadWireRings()

        'ANUP 01-07-2010
        'cmbRodSeal.Items.Add("605-U Cup")
        'cmbRodSeal.Items.Add("Z Macro")
        'cmbRodSeal.SelectedIndex = 0
        'ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Rod Seal", cmbRodSeal.Text)

        'cmbRodWiperType.Items.Add("Snap In")
        cmbRodWiperType.Items.Add("DA24") 'anup 04-03-2011
        'anup 01-02-2011 start
        cmbRodWiperType.Items.Add("WNUC")
        cmbRodWiperType.SelectedIndex = 0 'anup 04-03-2011 vamsi changed index 08-05-2013
        cmbRodWiperType.Enabled = True
        'anup 01-02-2011 tilll here

        cmbRodWiperType.BackColor = Color.Empty

        txtCylinderHeadCode.Enabled = False
        txtCylinderHeadCode.BackColor = Color.Empty

        _dblTempBoreDiameter = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter
        _dblTempRodDiameter = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter
    End Sub

    Private Sub LoadWireRings()
        Try
            Dim dblBoreDiameter As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter
            cmbHeadType.Items.Clear()
            'ANUP 17-08-2010
            ' If (dblBoreDiameter >= 1.25 And dblBoreDiameter <= 3) OrElse (dblBoreDiameter >= 3.5 And dblBoreDiameter <= 4) Then
            cmbHeadType.Items.Add("WireRing")
            cmbHeadType.Items.Add("Threaded")
            cmbHeadType.SelectedIndex = 0
            cmbHeadType.Enabled = True
            'Else
            'cmbHeadType.Items.Add("Threaded")
            'cmbHeadType.SelectedIndex = 0
            'cmbHeadType.Enabled = False
            'cmbHeadType.BackColor = Color.Empty
            'End If
            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Head Type", cmbHeadType.Text)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub ManualLoad()
        SetValuesToTempVariables()
    End Sub

    Private Sub SetValuesToTempVariables()
        If Not _dblTempBoreDiameter = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter _
                OrElse Not _dblTempRodDiameter = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter Then
            LoadWireRings()
            _dblTempBoreDiameter = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter
            _dblTempRodDiameter = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter
            GetCylinderHeadCode()
        End If
    End Sub

    Public Sub GetCylinderHeadCode()
        Try
            If cmbHeadType.Text <> "" Then
                'TODO:Sandeep 01-03-10 4pm
                _strQuery = ""

                Dim strHeadType As String = Nothing
                If cmbHeadType.Text = "WireRing" Then
                    strHeadType = "RR"
                    _strCH_StandardorCompressed = "N/A"
                ElseIf cmbHeadType.Text = "Threaded" Then
                    strHeadType = "THD"
                    _strCH_StandardorCompressed = "S"
                    If ObjClsWeldedCylinderFunctionalClass.CompressCylinderChecked Then
                        _strCH_StandardorCompressed = "C"
                    End If
                End If
                '*****************************

                If cmbHeadType.Text = "Threaded" Then
                    If cmbRodSeal.Text <> "" AndAlso cmbRodWiperType.Text <> "" AndAlso cmbRodWearRing.Text <> "" AndAlso cmbRodWearRingQty.Text <> "" Then


                        'anup 01-02-2011 start
                        '  cmbRodWiperType.Text = "Snap In"
                        cmbRodWiperType.Text = "DA24" 'anup 04-03-2011 SnapIn changed to DA24
                        cmbRodWiperType.Enabled = False
                        'anup 01-02-2011 till here

                        Dim strRodSeal As String = Nothing
                        If cmbRodSeal.Text = "605-U Cup" Then
                            strRodSeal = "UCupRodSeal605"
                        ElseIf cmbRodSeal.Text = "Z Macro" Then
                            strRodSeal = "ZDeepRodMacroSeal"
                        End If

                        Dim strRodWiper As String = Nothing
                        '  If cmbRodWiperType.Text = "Snap In" Then
                        If cmbRodWiperType.Text = "DA24" Then 'anup 04-03-2011 SnapIn changed to DA24
                            strRodWiper = "SnapInRodWiper"
                        End If

                        Dim strWearRing As String = Nothing
                        If cmbRodWearRing.Text = "None" Then
                            strWearRing = ""
                        ElseIf cmbRodWearRing.Text = "Garlock" Then
                            strWearRing = "Garlock"
                        ElseIf cmbRodWearRing.Text = "Glass Filled Nylon" Then
                            strWearRing = "Glass Filled Nylon"
                        End If

                        Dim oCylinderHeadDetails As DataTable = Nothing
                        If cmbRodWearRingQty.Text = 0 Then
                            oCylinderHeadDetails = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                            GetCylinderHeadDetails(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, _
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter, strHeadType _
                            , strRodSeal, strRodWiper, " = 'N/A'", " = 'N/A'", strWearRing, _strCH_StandardorCompressed)
                        ElseIf cmbRodWearRingQty.Text = 1 Then
                            oCylinderHeadDetails = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                            GetCylinderHeadDetails(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, _
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter, strHeadType _
                            , strRodSeal, strRodWiper, " <> 'N/A'", " = 'N/A'", strWearRing, _strCH_StandardorCompressed)
                        ElseIf cmbRodWearRingQty.Text = 2 Then
                            oCylinderHeadDetails = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                         GetCylinderHeadDetails(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, _
                         ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter, strHeadType _
                         , strRodSeal, strRodWiper, " = 'N/A'", " <> 'N/A'", strWearRing, _strCH_StandardorCompressed)
                        End If
                        'TODO:01-03-10 Sandeep 3pm


                        If Not IsNothing(oCylinderHeadDetails) Then
                            '_strIsExistingorNewDesign = "Existing"
                            _oCylinderHeadDetailsDataRow = oCylinderHeadDetails.Rows(0)
                            CylinderHeadDetails_Threaded(_oCylinderHeadDetailsDataRow)
                            GettingStaticSeal_CylinderDesignData_WireRingDetailFromDB()
                            LableMessageDisplayAndButtonHidding()

                            'Commented by Sunny 02-08-10
                            'CylinderHeadRodWiper_CostingParameters(_oCylinderHeadDetailsDataRow)

                        Else

                            _strIsExistingorNewDesign = "New"
                            txtCylinderHeadCode.Text = ""
                            temCylinderHeadCode.Text = ""
                            _strCH_ORING_CODE = ""
                            _strCH_BACKUP_RING_CODE = ""
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OverAllCylinderLength = 0

                            Dim strMessage As String = "No matching CylinderHead found, a new CylinderHead will be generated" + vbCrLf
                            lblMessage.Text = strMessage
                            lblMessage.Location = New Point(142, 46)
                            btnHeadDesignContinue.Visible = True


                            'TODO:01-03-10 Sandeep
                            If ObjClsWeldedCylinderFunctionalClass.CompressCylinderChecked Then
                                If MessageBox.Show("No matching CylinderHead found, a new CylinderHead will be generated", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.ServiceNotification) = Windows.Forms.DialogResult.Yes Then
                                    btnHeadDesignContinue.PerformClick()
                                    ObjClsWeldedCylinderFunctionalClass.CompressCylinderChecked = False
                                End If
                            End If
                        End If
                    End If

                ElseIf cmbHeadType.Text = "WireRing" Then

                    cmbRodWiperType.Enabled = True 'anup 01-02-2011
                    Dim oDataTable As DataTable = GetCylinderHeadCode_WireRing()
                    If Not IsNothing(oDataTable) Then
                        _strIsExistingorNewDesign = "Existing"
                        _oDataRow = oDataTable.Rows(0)
                        CylinderHeadDetails_WireRing(_oDataRow)
                        GettingStaticSeal_CylinderDesignData_WireRingDetailFromDB()
                        LableMessageDisplayAndButtonHidding()
                        'Commented by Sunny 02-08-10
                        'CylinderHeadRodWiper_CostingParameters(_oDataRow)
                    End If
                End If

                'ANUP 06-10-2010 START 
                '          ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Cylinder Head Code", txtCylinderHeadCode.Text)
                Dim strPartCode As String = ObjClsWeldedCylinderFunctionalClass.PartCode_Purchased_Validation(txtCylinderHeadCode.Text)
                If Not String.IsNullOrEmpty(strPartCode) Then
                    ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Cylinder Head Code", strPartCode)
                    _strCH_CylinderHeadCode = strPartCode
                Else
                    ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Cylinder Head Code", txtCylinderHeadCode.Text)
                    _strCH_CylinderHeadCode = txtCylinderHeadCode.Text
                End If
                'ANUP 06-10-2010 TILL HERE

                'Commented by Sunny 02-08-10
                'CylinderHeadCode_CostingParameters()    'ANUP 13-07-2010
                '11_02_2010-ARUNA START
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CylinderHeadDesign = cmbHeadType.Text
                '11_02_2010-ARUNA END
            End If
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in GetCylinderHeadCode of frmHeadDesign " + ex.Message)
        End Try
    End Sub

    'Commented by sunny-02-08-10
    ''ANUP 13-07-2010
    'Private Sub CylinderHeadCode_CostingParameters()
    '    If ObjClsWeldedCylinderFunctionalClass.htCostingCodeList.ContainsKey("CylinderHeadCode") Then
    '        ObjClsWeldedCylinderFunctionalClass.htCostingCodeList("CylinderHeadCode") = _strCH_CylinderHeadCode
    '    Else
    '        ObjClsWeldedCylinderFunctionalClass.htCostingCodeList.Add("CylinderHeadCode", _strCH_CylinderHeadCode)
    '    End If
    'End Sub
    'Private Sub CylinderHeadRodWiper_CostingParameters(ByVal drDataRow As DataRow)
    '    If ObjClsWeldedCylinderFunctionalClass.htCostingCodeList.ContainsKey("CylinderHeadRodWiper") Then
    '        ObjClsWeldedCylinderFunctionalClass.htCostingCodeList("CylinderHeadRodWiper") = drDataRow("SnapInRodWiper")
    '    Else
    '        ObjClsWeldedCylinderFunctionalClass.htCostingCodeList.Add("CylinderHeadRodWiper", drDataRow("SnapInRodWiper"))
    '    End If
    'End Sub
    'Private Sub CylinderHeadWearRing_CostingParameters(ByVal strWearRing As String)
    '    If ObjClsWeldedCylinderFunctionalClass.htCostingCodeList.ContainsKey("CylinderHeadWearRing") Then
    '        ObjClsWeldedCylinderFunctionalClass.htCostingCodeList("CylinderHeadWearRing") = strWearRing
    '    Else
    '        ObjClsWeldedCylinderFunctionalClass.htCostingCodeList.Add("CylinderHeadWearRing", strWearRing)
    '    End If
    'End Sub
    'Private Sub CylinderHeadRodSealCode_CostingParameters(ByVal strRodSeal As String)
    '    If ObjClsWeldedCylinderFunctionalClass.htCostingCodeList.ContainsKey("CylinderHeadRodSealCode") Then
    '        ObjClsWeldedCylinderFunctionalClass.htCostingCodeList("CylinderHeadRodSealCode") = strRodSeal
    '    Else
    '        ObjClsWeldedCylinderFunctionalClass.htCostingCodeList.Add("CylinderHeadRodSealCode", strRodSeal)
    '    End If
    'End Sub

    Private Function GetCylinderHeadCode_WireRing() As DataTable
        GetCylinderHeadCode_WireRing = Nothing
        GetCylinderHeadCode_WireRing = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetCylinderHeadDetails_WireRing(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter)
        If Not IsNothing(GetCylinderHeadCode_WireRing) Then
            Return GetCylinderHeadCode_WireRing
        Else
            GetCylinderHeadCode_WireRing = Nothing
        End If
    End Function

    Private Sub CylinderHeadDetails_Threaded(ByVal oCylinderHeadDetailsDataRow As DataRow)
        Try
            'Sandeep 26-02-10-2pm
            If Not IsDBNull(oCylinderHeadDetailsDataRow("Part_Type")) Then
                If oCylinderHeadDetailsDataRow("Part_Type") = "IFL_PART" Then
                    _strIsExistingorNewDesign = "New"
                Else
                    _strIsExistingorNewDesign = "Existing"
                End If
            Else
                _strIsExistingorNewDesign = "Existing"
            End If
            '************************

            If Not IsDBNull(oCylinderHeadDetailsDataRow("CylinderHeadCode")) Then
                txtCylinderHeadCode.Text = oCylinderHeadDetailsDataRow("CylinderHeadCode")
                temCylinderHeadCode.Text = oCylinderHeadDetailsDataRow("CylinderHeadCode")
                _strCH_CylinderHeadCode = txtCylinderHeadCode.Text
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CylinderHeadCode = _strCH_CylinderHeadCode    '07_10_2010   RAGAVA
            End If



            If Not IsDBNull(oCylinderHeadDetailsDataRow("overalllength")) Then
                _dblCH_OverallLength = oCylinderHeadDetailsDataRow("overalllength")
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OverAllCylinderLength = oCylinderHeadDetailsDataRow("OverAllLength")
            End If

            If Not IsDBNull(oCylinderHeadDetailsDataRow("ShankLength")) Then
                _dblCH_ShankLength = oCylinderHeadDetailsDataRow("ShankLength")
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ShankLength = _dblCH_ShankLength
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ShankLength = 0
            End If

            If Not IsDBNull(oCylinderHeadDetailsDataRow("StaticSealPosition")) Then
                _dblCH_StaticSealPosition = oCylinderHeadDetailsDataRow("StaticSealPosition")
            End If

            If Not IsDBNull(oCylinderHeadDetailsDataRow("StickOutFromTube")) Then
                _dblCH_StickoutfromTube = oCylinderHeadDetailsDataRow("StickOutFromTube")
            End If
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub CylinderHeadDetails_WireRing(ByVal oDataRow As DataRow)
        Try
            If Not IsDBNull(oDataRow("CylinderHeadCode")) Then
                txtCylinderHeadCode.Text = oDataRow("CylinderHeadCode")
                temCylinderHeadCode.Text = oDataRow("CylinderHeadCode")
                _strCH_CylinderHeadCode = txtCylinderHeadCode.Text
            End If

            If Not IsDBNull(oDataRow("overalllength")) Then
                _dblCH_OverallLength = oDataRow("overalllength")
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OverAllCylinderLength = oDataRow("OverAllLength")
            End If

            If Not IsDBNull(oDataRow("ShankLength")) Then
                _dblCH_ShankLength = oDataRow("ShankLength")
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ShankLength = _dblCH_ShankLength
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ShankLength = 0
            End If

            If Not IsDBNull(oDataRow("StaticSealPosition")) Then
                _dblCH_StaticSealPosition = oDataRow("StaticSealPosition")
            End If

            If Not IsDBNull(oDataRow("StickOutFromTube")) Then
                _dblCH_StickoutfromTube = oDataRow("StickOutFromTube")
            End If
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub LableMessageDisplayAndButtonHidding()
        Dim strMessage As String = "This is an Existing CylinderHead"
        lblMessage.Text = strMessage
        lblMessage.Location = New Point(255, 46)
        btnHeadDesignContinue.Visible = False
    End Sub

    Private Sub GettingStaticSeal_CylinderDesignData_WireRingDetailFromDB()
        'Sandeep 17-02-10-------------------------------------------

        GetStaticSealDetailsFromDB()

        'CH_Seal details

        '30_09_2010    RAGAVA
        If txtCylinderHeadCode.Text = "New Design" OrElse txtCylinderHeadCode.Text.StartsWith("7") Then 'anup 
            Dim oCylinderDesignDataRow As DataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetCylinderDesignData _
                                               (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter)
            If Not IsNothing(oCylinderDesignDataRow) Then
                SealDetails(oCylinderDesignDataRow)
            End If
            GetWireRingDetailsFromDB()
        Else
            Dim oCylinderDesignDataRow As DataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetExistingCylinderDesignData _
                                                           (txtCylinderHeadCode.Text)
            If Not IsNothing(oCylinderDesignDataRow) Then
                GetExistingSealDetails(oCylinderDesignDataRow)
            End If
            GetWireRingDetailsFromDB()            '19_10_2010   RAGAVA  asper RAMKI
        End If
        'Dim oCylinderDesignDataRow As DataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetCylinderDesignData _
        '                                        (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter)
        'If Not IsNothing(oCylinderDesignDataRow) Then
        '    SealDetails(oCylinderDesignDataRow)
        'End If
        'GetWireRingDetailsFromDB()
        'Till  Here


        '--------------------------------------------------------

    End Sub

    Private Sub GetWireRingDetailsFromDB()
        Try
            Dim oWireRingDataRow As DataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
            GetWireRingDetails(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter)

            ':18-02-10
            If cmbHeadType.Text = "Threaded" Then
                Dim oThreadedHeadDataRow As DataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                                                     GetThreadedHeadDetails(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter)
                If Not IsDBNull(oThreadedHeadDataRow("PD_Max")) Then
                    _dblCH_HEAD_OD_MAX = oThreadedHeadDataRow("PD_Max")
                End If

                If Not IsDBNull(oThreadedHeadDataRow("PD_Min")) Then
                    _dblCH_HEAD_OD_MIN = oThreadedHeadDataRow("PD_Min")
                End If

                If Not IsDBNull(oThreadedHeadDataRow("Major_Min")) Then
                    _dblCH_MAJOR_MIN = oThreadedHeadDataRow("Major_Min")
                End If

                If Not IsDBNull(oThreadedHeadDataRow("Major_Max")) Then
                    _dblCH_MAJOR_MAX = oThreadedHeadDataRow("Major_Max")
                End If

            ElseIf cmbHeadType.Text = "WireRing" Then
                If Not IsNothing(oWireRingDataRow) Then
                    If Not IsDBNull(oWireRingDataRow("HeadOD_Max")) Then
                        _dblCH_HEAD_OD_MAX = oWireRingDataRow("HeadOD_Max")
                    End If

                    If Not IsDBNull(oWireRingDataRow("HeadOD_Min")) Then
                        _dblCH_HEAD_OD_MIN = oWireRingDataRow("HeadOD_Min")
                    End If
                End If
            End If

            If Not IsNothing(oWireRingDataRow) Then
                '11_02_2010-ARUNA START
                If Not IsDBNull(oWireRingDataRow("ExternalRing_GrooveDia_Max")) Then
                    _dblCH_ExternalWireRingGrooveDiaMax = oWireRingDataRow("ExternalRing_GrooveDia_Max")
                End If

                If Not IsDBNull(oWireRingDataRow("ExternalRing_GrooveDia_Min")) Then
                    _dblCH_ExternalWireRingGrooveDiaMin = oWireRingDataRow("ExternalRing_GrooveDia_Min")
                End If
                '11_02_2010-ARUNA END
                If Not IsDBNull(oWireRingDataRow("ExternalRing_GrooveWidth_Max")) Then
                    _dblCH_ExternalWireRingGrooveWidthMax = oWireRingDataRow("ExternalRing_GrooveWidth_Max")
                End If

                If Not IsDBNull(oWireRingDataRow("ExternalRing_GrooveWidth_Min")) Then
                    _dblCH_ExternalWireRingGrooveWidthMin = oWireRingDataRow("ExternalRing_GrooveWidth_Min")
                End If

                If Not IsDBNull(oWireRingDataRow("ExternalRingCode")) Then
                    _strCH_ExternalWireRingCode = oWireRingDataRow("ExternalRingCode")
                End If

                If Not IsDBNull(oWireRingDataRow("InternalRing_GrooveDia_Dia2")) Then
                    _dblCH_InternalWireRingGrooveDia_Dia2 = oWireRingDataRow("InternalRing_GrooveDia_Dia2")
                End If

                If Not IsDBNull(oWireRingDataRow("InternalRing_GrooveDia_Dia1")) Then
                    _dblCH_InternalWireRingGrooveDia_Dia1 = oWireRingDataRow("InternalRing_GrooveDia_Dia1")
                End If

                If Not IsDBNull(oWireRingDataRow("InternalRing_GrooveWidthInstallation_Max")) Then
                    _dblCH_InternalWireRingGrooveWidthMax = oWireRingDataRow("InternalRing_GrooveWidthInstallation_Max")
                End If

                If Not IsDBNull(oWireRingDataRow("InternalRing_GrooveWidthInstallation_Min")) Then
                    _dblCH_InternalWireRingGrooveWidthMin = oWireRingDataRow("InternalRing_GrooveWidthInstallation_Min")
                End If

                If Not IsDBNull(oWireRingDataRow("InternalRingCode")) Then
                    _strCH_InternalWireRingCode = oWireRingDataRow("InternalRingCode")
                End If

                If Not IsDBNull(oWireRingDataRow("HeadProtrusion")) Then
                    _dblCH_HeadProtrusion = oWireRingDataRow("HeadProtrusion")
                End If

                If Not IsDBNull(oWireRingDataRow("TubeEndtoGrooveEnd")) Then
                    _dblCH_TubeEndtoGrooveEnd = oWireRingDataRow("TubeEndtoGrooveEnd")
                End If

                If Not IsDBNull(oWireRingDataRow("InternalRing_GrooveWidthTotal_Min")) Then
                    _dblCH_GrooveWidthTotalMin = oWireRingDataRow("InternalRing_GrooveWidthTotal_Min")
                End If

                If Not IsDBNull(oWireRingDataRow("InternalRing_GrooveWidthTotal_Max")) Then
                    _dblCH_GrooveWidthTotalMax = oWireRingDataRow("InternalRing_GrooveWidthTotal_Max")
                End If

                If Not IsDBNull(oWireRingDataRow("NoseLength")) Then
                    _dblCH_NoseLength = oWireRingDataRow("NoseLength")
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoseLength = _dblCH_NoseLength
                Else
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoseLength = 0
                End If

                If Not IsDBNull(oWireRingDataRow("SealGrooveLocation")) Then
                    _dblCH_SealGrooveLocation = oWireRingDataRow("SealGrooveLocation")
                End If
                '11_02_2010-ARUNA START
                If Not IsDBNull(oWireRingDataRow("TubeEndtoGrooveEnd")) Then
                    _dblCH_TubeEndtoGrooveEnd = oWireRingDataRow("TubeEndtoGrooveEnd")
                End If
                _dblCH_StaticSealNoseDia = oWireRingDataRow("BoreDiameter") - 2 * oWireRingDataRow("nosestepdown")
                '11_02_2010-ARUNA END
            End If
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in GetWireRingDetailsFromDB of frmHeadDesign " + ex.Message)
        End Try
    End Sub

    Private Sub SetZeroToExcelVariables()

        _dblCH_OverallLength = 0

        _dblCH_ShankLength = 0

        _dblCH_StaticSealPosition = 0

        _dblCH_StickoutfromTube = 0

        _dblCH_RodBoreID_Seal = 0

        _dblCH_RodBoreID_Seal_TOL_UL = 0

        _dblCH_RodBoreID_Seal_TOL_LL = 0

        _dblCH_SealGrooveDiameter = 0

        _dblCH_SealGrooveDiameter_TOL_UL = 0

        _dblCH_SealGrooveDiameter_TOL_LL = 0

        _dblCH_SealGrooveWidth = 0

        _dblCH_RodBoreID_WearRing = 0

        _strCH_RodBoreID_WearRing_TOL_UL = ""

        _strCH_RodBoreID_WearRing_TOL_LL = ""

        _dblCH_WearRingGrooveDiameter = 0

        _dblCH_WearRingGrooveDiameter_TOL_UL = 0

        _dblCH_WearRingGrooveDiameter_TOL_LL = 0

        _dblCH_WearRingGrooveWidth = 0

        _dblCH_WearRingGrooveWidth_TOL_UL = 0

        _dblCH_WearRingGrooveWidth_TOL_LL = 0

        _strCH_RodBoreID_Wiper = ""

        _strCH_RodBoreID_Wiper_TOL_UL = ""

        _strCH_RodBoreID_Wiper_TOL_LL = ""

        _dblCH_WiperGrooveDiameter = 0

        _dblCH_WiperGrooveDiameter_TOL_UL = 0

        _dblCH_WiperGrooveDiameter_TOL_LL = 0

        _dblCH_WiperGrooveWidth = 0

        _dblCH_WiperGrooveWidth_TOL_UL = 0

        _dblCH_WiperGrooveWidth_TOL_LL = 0

        _dblCH_WiperGrooveLeadInDia = 0

        _dblCH_WiperGrooveLeadInDia_TOL_UL = 0

        _dblCH_WiperGrooveLeadInDia_TOL_LL = 0

        _strCH_UCUP605_SealCode = "N/A"

        _strCH_ZMacro_SealCode = "N/A"

        _strCH_WearRingCode = "N/A"

        _strCH_SnapinWiperCode = "N/A"

        _strCH_RodSealInstallationKitcode = "N/A"

        _dblCH_StaticSealHeadDia = 0

        _dblCH_StaticSealHeadDia_TOL_UL = 0

        _dblCH_StaticSealHeadDia_TOL_LL = 0

        _dblCH_StaticSealNoseDia = 0

        _dblCH_StaticSealNoseDia_TOL_UL = 0

        _dblCH_StaticSealNoseDia_TOL_LL = 0

        _dblCH_StaticSealGrooveDia = 0

        _dblCH_StaticSealGrooveDia_TOL_UL = 0

        _dblCH_StaticSealGrooveDia_TOL_LL = 0

        _dblCH_StaticSealGrooveWidth = 0

        _dblCH_StaticSealGrooveWidth_TOL_UL = 0

        _dblCH_StaticSealGrooveWidth_TOL_LL = 0

    End Sub

    Private Sub GetStaticSealDetailsFromDB()
        Try
            Dim oStaticSealDetailsRow As DataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
            GetStaticSealDetails(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter)

            If cmbHeadType.Text = "" Then

            End If

            If Not IsNothing(oStaticSealDetailsRow) Then
                If Not IsDBNull(oStaticSealDetailsRow("HeadDiameter")) Then
                    _dblCH_StaticSealHeadDia = oStaticSealDetailsRow("HeadDiameter")
                End If

                If Not IsDBNull(oStaticSealDetailsRow("HeadDiameter_UpperTolerance")) Then
                    _dblCH_StaticSealHeadDia_TOL_UL = oStaticSealDetailsRow("HeadDiameter_UpperTolerance")
                End If

                If Not IsDBNull(oStaticSealDetailsRow("HeadDiameter_LowerTolerance")) Then
                    _dblCH_StaticSealHeadDia_TOL_LL = oStaticSealDetailsRow("HeadDiameter_LowerTolerance")
                End If

                'goto GetWireRingDetailsFromDB for _dblCH_StaticSealNoseDia
                'If Not IsDBNull(oStaticSealDetailsRow("NoseDiameter")) Then
                '    _dblCH_StaticSealNoseDia = oStaticSealDetailsRow("NoseDiameter")
                'End If

                If Not IsDBNull(oStaticSealDetailsRow("NoseDiameter_UpperTolerance")) Then
                    _dblCH_StaticSealNoseDia_TOL_UL = oStaticSealDetailsRow("NoseDiameter_UpperTolerance")
                End If

                If Not IsDBNull(oStaticSealDetailsRow("NoseDiameter_LowerTolerance")) Then
                    _dblCH_StaticSealNoseDia_TOL_LL = oStaticSealDetailsRow("NoseDiameter_LowerTolerance")
                End If

                If Not IsDBNull(oStaticSealDetailsRow("GrooveDiameter")) Then
                    _dblCH_StaticSealGrooveDia = oStaticSealDetailsRow("GrooveDiameter")
                End If

                If Not IsDBNull(oStaticSealDetailsRow("GrooveDiameter_UpperTolerance")) Then
                    _dblCH_StaticSealGrooveDia_TOL_UL = oStaticSealDetailsRow("GrooveDiameter_UpperTolerance")
                End If

                If Not IsDBNull(oStaticSealDetailsRow("GrooveDiameter_LowerTolerance")) Then
                    _dblCH_StaticSealGrooveDia_TOL_LL = oStaticSealDetailsRow("GrooveDiameter_LowerTolerance")
                End If

                If Not IsDBNull(oStaticSealDetailsRow("GrooveWidth")) Then
                    _dblCH_StaticSealGrooveWidth = oStaticSealDetailsRow("GrooveWidth")
                End If

                If Not IsDBNull(oStaticSealDetailsRow("GrooveWidth_UpperTolerance")) Then
                    _dblCH_StaticSealGrooveWidth_TOL_UL = oStaticSealDetailsRow("GrooveWidth_UpperTolerance")
                End If

                If Not IsDBNull(oStaticSealDetailsRow("GrooveWidth_LowerTolerance")) Then
                    _dblCH_StaticSealGrooveWidth_TOL_LL = oStaticSealDetailsRow("GrooveWidth_LowerTolerance")
                End If

                If Not IsDBNull(oStaticSealDetailsRow("ORing")) Then
                    _strCH_ORING_CODE = oStaticSealDetailsRow("ORing")
                End If

                If Not IsDBNull(oStaticSealDetailsRow("BackUpRing")) Then
                    _strCH_BACKUP_RING_CODE = oStaticSealDetailsRow("BackUpRing")
                End If
            End If
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in GetStaticSealDetailsFromDB of frmHeadDesign " + ex.Message)
        End Try
    End Sub

    Private Sub NewCylinderHeadDesignFuncionality()
        Try
            SetZeroToExcelVariables()
            GetStaticSealDetailsFromDB()
            GetWireRingDetailsFromDB()
            Dim oCylinderDesignDataRow As DataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetCylinderDesignData _
            (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter)
            If Not IsNothing(oCylinderDesignDataRow) Then
                SealDetails(oCylinderDesignDataRow)
            End If
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in NewCylinderHeadDesignFuncionality of frmHeadDesign " + ex.Message)
        End Try
    End Sub

    '30_09_2010   RAGAVA
    Private Sub GetExistingSealDetails(ByVal oCylinderDesignDataRow As DataRow)
        Try
            If cmbRodSeal.Text = "RU9 Rod Seal" Then
                _strCH_UCUP605_SealCode = oCylinderDesignDataRow("UCupRodSeal605")
                If oCylinderDesignDataRow("SingleWearRing") Is Nothing AndAlso oCylinderDesignDataRow("SingleWearRing") = "N/A" Then
                    _strCH_WearRingCode = oCylinderDesignDataRow("DoubleWearRing")
                Else
                    _strCH_WearRingCode = oCylinderDesignDataRow("SingleWearRing")
                End If

                'anup 01-02-2011 start
                If cmbRodWiperType.Text = "WNUC" Then
                    _strCH_SnapinWiperCode = oCylinderDesignDataRow("WNUCRodWiper")
                Else
                    _strCH_SnapinWiperCode = oCylinderDesignDataRow("SnapInRodWiper")
                End If
                'anup 01-02-2011 till here

                _strCH_RodSealInstallationKitcode = oCylinderDesignDataRow("RodSealInstallationKit")
                _strCH_ORING_CODE = oCylinderDesignDataRow("ORing")
                _strCH_BACKUP_RING_CODE = oCylinderDesignDataRow("BackUpRing")
            ElseIf cmbRodSeal.Text = "Z Macro" Then
                _strCH_UCUP605_SealCode = oCylinderDesignDataRow("ZDeepRodMacroSeal")
                If oCylinderDesignDataRow("SingleWearRing") Is Nothing AndAlso oCylinderDesignDataRow("SingleWearRing") = "N/A" Then
                    _strCH_WearRingCode = oCylinderDesignDataRow("DoubleWearRing")
                Else
                    _strCH_WearRingCode = oCylinderDesignDataRow("SingleWearRing")
                End If

                'anup 01-02-2011 start
                If cmbRodWiperType.Text = "WNUC" Then
                    _strCH_SnapinWiperCode = oCylinderDesignDataRow("WNUCRodWiper")
                Else
                    _strCH_SnapinWiperCode = oCylinderDesignDataRow("SnapInRodWiper")
                End If
                'anup 01-02-2011 till here

                _strCH_RodSealInstallationKitcode = oCylinderDesignDataRow("RodSealInstallationKit")
                _strCH_ORING_CODE = oCylinderDesignDataRow("ORing")
                _strCH_BACKUP_RING_CODE = oCylinderDesignDataRow("BackUpRing")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SealDetails(ByVal oCylinderDesignDataRow As DataRow)
        If cmbRodSeal.Text = "605-U Cup" Then
            If cmbRodWearRing.Text <> "None" Then
                If Not IsDBNull(oCylinderDesignDataRow("UCUP605_With_WearRing_RodBoreID_AtSeal")) Then
                    _dblCH_RodBoreID_Seal = oCylinderDesignDataRow("UCUP605_With_WearRing_RodBoreID_AtSeal")
                End If

                If Not IsDBNull(oCylinderDesignDataRow("UCUP605_With_WearRing_RodBoreID_UpperTolerance")) Then
                    _dblCH_RodBoreID_Seal_TOL_UL = oCylinderDesignDataRow("UCUP605_With_WearRing_RodBoreID_UpperTolerance")
                End If

                If Not IsDBNull(oCylinderDesignDataRow("UCUP605_With_WearRing_RodBoreID_LowerTolerance")) Then
                    _dblCH_RodBoreID_Seal_TOL_LL = oCylinderDesignDataRow("UCUP605_With_WearRing_RodBoreID_LowerTolerance")
                End If

                'To Be verified Upper and Lower Tolerances to be added for _WearRing
                If Not IsDBNull(oCylinderDesignDataRow("UCUP605_With_WearRing_RodBoreID_AtWearRing")) Then
                    _dblCH_RodBoreID_WearRing = oCylinderDesignDataRow("UCUP605_With_WearRing_RodBoreID_AtWearRing")
                End If

                If Not IsDBNull(oCylinderDesignDataRow("UCUP605_With_WearRing_GrooveDiameter")) Then
                    _dblCH_WearRingGrooveDiameter = oCylinderDesignDataRow("UCUP605_With_WearRing_GrooveDiameter")
                End If

                If Not IsDBNull(oCylinderDesignDataRow("UCUP605_With_WearRing_GrooveDiameter_UpperTolerance")) Then
                    _dblCH_WearRingGrooveDiameter_TOL_UL = oCylinderDesignDataRow("UCUP605_With_WearRing_GrooveDiameter_UpperTolerance")
                End If

                If Not IsDBNull(oCylinderDesignDataRow("UCUP605_With_WearRing_GrooveDiameter_LowerTolerance")) Then
                    _dblCH_WearRingGrooveDiameter_TOL_LL = oCylinderDesignDataRow("UCUP605_With_WearRing_GrooveDiameter_LowerTolerance")
                End If

                If Not IsDBNull(oCylinderDesignDataRow("UCUP605_With_WearRing_GrooveWidth")) Then
                    _dblCH_WearRingGrooveWidth = oCylinderDesignDataRow("UCUP605_With_WearRing_GrooveWidth")
                End If

                If Not IsDBNull(oCylinderDesignDataRow("UCUP605_With_WearRing_GrooveWidth_UpperTolerance")) Then
                    _dblCH_WearRingGrooveWidth_TOL_UL = oCylinderDesignDataRow("UCUP605_With_WearRing_GrooveWidth_UpperTolerance")
                End If

                If Not IsDBNull(oCylinderDesignDataRow("UCUP605_With_WearRing_GrooveWidth_LowerTolerance")) Then
                    _dblCH_WearRingGrooveWidth_TOL_LL = oCylinderDesignDataRow("UCUP605_With_WearRing_GrooveWidth_LowerTolerance")
                End If

                If Not IsDBNull(oCylinderDesignDataRow("UCUP605_With_WearRing_GNFCode")) Then 'AndAlso oCylinderDesignDataRow("UCUP605_With_WearRing_GNFCode") <> "" Then
                    _strCH_WearRingCode = oCylinderDesignDataRow("UCUP605_With_WearRing_GNFCode")
                End If

                If Not IsDBNull(oCylinderDesignDataRow("UCUP605_Without_WearRing_Code")) Then 'AndAlso oCylinderDesignDataRow("UCUP605_With_WearRing_GNFCode") <> "" Then
                    _strCH_UCUP605_SealCode = oCylinderDesignDataRow("UCUP605_Without_WearRing_Code")
                End If
                '11_02_2010-ARUNA START
                If Not IsDBNull(oCylinderDesignDataRow("UCUP605_Without_WearRing_GrooveDiameter")) Then
                    _dblCH_SealGrooveDiameter = oCylinderDesignDataRow("UCUP605_Without_WearRing_GrooveDiameter")
                End If

                If Not IsDBNull(oCylinderDesignDataRow("UCUP605_Without_WearRing_GrooveDiameter_UpperTolerance")) Then
                    _dblCH_SealGrooveDiameter_TOL_UL = oCylinderDesignDataRow("UCUP605_Without_WearRing_GrooveDiameter_UpperTolerance")
                End If

                If Not IsDBNull(oCylinderDesignDataRow("UCUP605_Without_WearRing_GrooveDiameter_LowerTolerance")) Then
                    _dblCH_SealGrooveDiameter_TOL_LL = oCylinderDesignDataRow("UCUP605_Without_WearRing_GrooveDiameter_LowerTolerance")
                End If

                If Not IsDBNull(oCylinderDesignDataRow("UCUP605_Without_WearRing_GrooveWidth")) Then
                    _dblCH_SealGrooveWidth = oCylinderDesignDataRow("UCUP605_Without_WearRing_GrooveWidth")
                End If

                If Not IsDBNull(oCylinderDesignDataRow("UCUP605_Without_WearRing_GrooveWidth_UpperTolerance")) Then
                    _dblCH_SealGrooveWidth_TOL_UL = oCylinderDesignDataRow("UCUP605_Without_WearRing_GrooveWidth_UpperTolerance")
                End If

                If Not IsDBNull(oCylinderDesignDataRow("UCUP605_Without_WearRing_GrooveWidth_LowerTolerance")) Then
                    _dblCH_SealGrooveWidth_TOL_LL = oCylinderDesignDataRow("UCUP605_Without_WearRing_GrooveWidth_LowerTolerance")
                End If
                '11_02_2010-ARUNA END
            Else
                If Not IsDBNull(oCylinderDesignDataRow("UCUP605_Without_WearRing_RodBoreID")) Then
                    _dblCH_RodBoreID_Seal = oCylinderDesignDataRow("UCUP605_Without_WearRing_RodBoreID")
                End If

                If Not IsDBNull(oCylinderDesignDataRow("UCUP605_Without_WearRing_RodBoreID_UpperTolerance")) Then
                    _dblCH_RodBoreID_Seal_TOL_UL = oCylinderDesignDataRow("UCUP605_Without_WearRing_RodBoreID_UpperTolerance")
                End If

                If Not IsDBNull(oCylinderDesignDataRow("UCUP605_Without_WearRing_RodBoreID_LowerTolerance")) Then
                    _dblCH_RodBoreID_Seal_TOL_LL = oCylinderDesignDataRow("UCUP605_Without_WearRing_RodBoreID_LowerTolerance")
                End If

                If Not IsDBNull(oCylinderDesignDataRow("UCUP605_Without_WearRing_GrooveDiameter")) Then
                    _dblCH_SealGrooveDiameter = oCylinderDesignDataRow("UCUP605_Without_WearRing_GrooveDiameter")
                End If

                If Not IsDBNull(oCylinderDesignDataRow("UCUP605_Without_WearRing_GrooveDiameter_UpperTolerance")) Then
                    _dblCH_SealGrooveDiameter_TOL_UL = oCylinderDesignDataRow("UCUP605_Without_WearRing_GrooveDiameter_UpperTolerance")
                End If

                If Not IsDBNull(oCylinderDesignDataRow("UCUP605_Without_WearRing_GrooveDiameter_LowerTolerance")) Then
                    _dblCH_SealGrooveDiameter_TOL_LL = oCylinderDesignDataRow("UCUP605_Without_WearRing_GrooveDiameter_LowerTolerance")
                End If

                If Not IsDBNull(oCylinderDesignDataRow("UCUP605_Without_WearRing_GrooveWidth")) Then
                    _dblCH_SealGrooveWidth = oCylinderDesignDataRow("UCUP605_Without_WearRing_GrooveWidth")
                End If

                If Not IsDBNull(oCylinderDesignDataRow("UCUP605_Without_WearRing_GrooveWidth_UpperTolerance")) Then
                    _dblCH_SealGrooveWidth_TOL_UL = oCylinderDesignDataRow("UCUP605_Without_WearRing_GrooveWidth_UpperTolerance")
                End If

                If Not IsDBNull(oCylinderDesignDataRow("UCUP605_Without_WearRing_GrooveWidth_LowerTolerance")) Then
                    _dblCH_SealGrooveWidth_TOL_LL = oCylinderDesignDataRow("UCUP605_Without_WearRing_GrooveWidth_LowerTolerance")
                End If

                If Not IsDBNull(oCylinderDesignDataRow("UCUP605_Without_WearRing_Code")) Then 'AndAlso oCylinderDesignDataRow("UCUP605_With_WearRing_GNFCode") <> "" Then
                    _strCH_UCUP605_SealCode = oCylinderDesignDataRow("UCUP605_Without_WearRing_Code")
                End If
            End If
        ElseIf cmbRodSeal.Text = "Z Macro" Then
            If Not IsDBNull(oCylinderDesignDataRow("ZMacro_Without_WearRing_RodBoreID")) Then
                _dblCH_RodBoreID_Seal = oCylinderDesignDataRow("ZMacro_Without_WearRing_RodBoreID")
            End If

            If Not IsDBNull(oCylinderDesignDataRow("ZMacro_Without_WearRing_RodBoreID_UpperTolerance")) Then
                _dblCH_RodBoreID_Seal_TOL_UL = oCylinderDesignDataRow("ZMacro_Without_WearRing_RodBoreID_UpperTolerance")
            End If

            If Not IsDBNull(oCylinderDesignDataRow("ZMacro_Without_WearRing_RodBoreID_LowerTolerance")) Then
                _dblCH_RodBoreID_Seal_TOL_LL = oCylinderDesignDataRow("ZMacro_Without_WearRing_RodBoreID_LowerTolerance")
            End If

            If Not IsDBNull(oCylinderDesignDataRow("ZMacro_Without_WearRing_GrooveDiameter")) Then
                _dblCH_SealGrooveDiameter = oCylinderDesignDataRow("ZMacro_Without_WearRing_GrooveDiameter")
            End If

            If Not IsDBNull(oCylinderDesignDataRow("ZMacro_Without_WearRing_GrooveDiameter_UpperTolerance")) Then
                _dblCH_SealGrooveDiameter_TOL_UL = oCylinderDesignDataRow("ZMacro_Without_WearRing_GrooveDiameter_UpperTolerance")
            End If

            If Not IsDBNull(oCylinderDesignDataRow("ZMacro_Without_WearRing_GrooveDiameter_LowerTolerance")) Then
                _dblCH_SealGrooveDiameter_TOL_LL = oCylinderDesignDataRow("ZMacro_Without_WearRing_GrooveDiameter_LowerTolerance")
            End If

            If Not IsDBNull(oCylinderDesignDataRow("ZMacro_Without_WearRing_GrooveWidth")) Then
                _dblCH_SealGrooveWidth = oCylinderDesignDataRow("ZMacro_Without_WearRing_GrooveWidth")
            End If

            If Not IsDBNull(oCylinderDesignDataRow("ZMacro_Without_WearRing_GrooveWidth_UpperTolerance")) Then
                _dblCH_SealGrooveWidth_TOL_UL = oCylinderDesignDataRow("ZMacro_Without_WearRing_GrooveWidth_UpperTolerance")
            End If

            If Not IsDBNull(oCylinderDesignDataRow("ZMacro_Without_WearRing_GrooveWidth_LowerTolerance")) Then
                _dblCH_SealGrooveWidth_TOL_LL = oCylinderDesignDataRow("ZMacro_Without_WearRing_GrooveWidth_LowerTolerance")
            End If

            If Not IsDBNull(oCylinderDesignDataRow("ZMacro_Without_WearRing_Code")) Then 'AndAlso oCylinderDesignDataRow("UCUP605_With_WearRing_GNFCode") <> "" Then
                _strCH_ZMacro_SealCode = oCylinderDesignDataRow("ZMacro_Without_WearRing_Code")
            End If
        End If
        'If cmbRodWiperType.Text = "Snap In" Then
        If cmbRodWiperType.Text = "DA24" Then   'anup 04-03-2011 SnapIn changed to DA24
            If Not IsDBNull(oCylinderDesignDataRow("SnapInWiper_LeadInDiameter")) Then
                _strCH_RodBoreID_Wiper = oCylinderDesignDataRow("SnapInWiper_LeadInDiameter")
            End If

            If Not IsDBNull(oCylinderDesignDataRow("SnapInWiper_LeadInDiameter_UpperTolerance")) Then
                _strCH_RodBoreID_Wiper_TOL_UL = oCylinderDesignDataRow("SnapInWiper_LeadInDiameter_UpperTolerance")
            End If

            If Not IsDBNull(oCylinderDesignDataRow("SnapInWiper_LeadInDiameter_LowerTolerance")) Then
                _strCH_RodBoreID_Wiper_TOL_LL = oCylinderDesignDataRow("SnapInWiper_LeadInDiameter_LowerTolerance")
            End If

            If Not IsDBNull(oCylinderDesignDataRow("SnapInWiper_GrooveDiameter")) Then
                _dblCH_WiperGrooveDiameter = oCylinderDesignDataRow("SnapInWiper_GrooveDiameter")
            End If

            If Not IsDBNull(oCylinderDesignDataRow("SnapInWiper_GrooveDiameter_UpperTolerance")) Then
                _dblCH_WiperGrooveDiameter_TOL_UL = oCylinderDesignDataRow("SnapInWiper_GrooveDiameter_UpperTolerance")
            End If

            If Not IsDBNull(oCylinderDesignDataRow("SnapInWiper_GrooveDiameter_LowerTolerance")) Then
                _dblCH_WiperGrooveDiameter_TOL_LL = oCylinderDesignDataRow("SnapInWiper_GrooveDiameter_LowerTolerance")
            End If

            If Not IsDBNull(oCylinderDesignDataRow("SnapInWiper_GrooveWidth")) Then
                _dblCH_WiperGrooveWidth = oCylinderDesignDataRow("SnapInWiper_GrooveWidth")
            End If

            If Not IsDBNull(oCylinderDesignDataRow("SnapInWiper_GrooveWidth_UpperTolerance")) Then
                _dblCH_WiperGrooveWidth_TOL_UL = oCylinderDesignDataRow("SnapInWiper_GrooveWidth_UpperTolerance")
            End If

            If Not IsDBNull(oCylinderDesignDataRow("SnapInWiper_GrooveWidth_LowerTolerance")) Then
                _dblCH_WiperGrooveWidth_TOL_LL = oCylinderDesignDataRow("SnapInWiper_GrooveWidth_LowerTolerance")
            End If

            If Not IsDBNull(oCylinderDesignDataRow("SnapInWiper_LeadInDiameter")) Then
                _dblCH_WiperGrooveLeadInDia = oCylinderDesignDataRow("SnapInWiper_LeadInDiameter")
            End If

            If Not IsDBNull(oCylinderDesignDataRow("SnapInWiper_LeadInDiameter_UpperTolerance")) Then
                _dblCH_WiperGrooveLeadInDia_TOL_UL = oCylinderDesignDataRow("SnapInWiper_LeadInDiameter_UpperTolerance")
            End If

            If Not IsDBNull(oCylinderDesignDataRow("SnapInWiper_LeadInDiameter_LowerTolerance")) Then
                _dblCH_WiperGrooveLeadInDia_TOL_LL = oCylinderDesignDataRow("SnapInWiper_LeadInDiameter_LowerTolerance")
            End If

            If Not IsDBNull(oCylinderDesignDataRow("SnapInWiper_Code")) Then 'AndAlso oCylinderDesignDataRow("UCUP605_With_WearRing_GNFCode") <> "" Then
                _strCH_SnapinWiperCode = oCylinderDesignDataRow("SnapInWiper_Code")
            End If
        End If
    End Sub

    Private Sub InsertNewCylinderHeadDesignData()
        Try
            Dim strIFLID As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetMaxIFLID("Welded.CylinderHeadDetails")
            If Not IsNothing(strIFLID) Then
                strIFLID = Val(strIFLID) + 1
            Else
                strIFLID = 1001
            End If
            Dim strCylinderPartName As String = ""
            Dim strPartType As String = "IFL_PART"

            Dim strBoreDiameter As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter

            Dim strRodDiameter As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter

            Dim strHeadType As String = ""
            If cmbHeadType.Text = "WireRing" Then
                strHeadType = "RR"
                strCylinderPartName = "CYLINDER_HEAD_WIRE"
            ElseIf cmbHeadType.Text = "Threaded" Then
                strHeadType = "THD"
                strCylinderPartName = "CYLINDER_HEAD"
            End If
            '*******************************

            ' : 26-02-10 Sandeep 10am
            _strCH_CylinderHeadCode = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPurchaseAndManufactureCode(strCylinderPartName) '26-02-10 Sandeep 

            '*******************************

            'TODO:Sandeep 01-03-10 3pm
            txtCylinderHeadCode.Text = "New Design"
            temCylinderHeadCode.Text = "New Design"
            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Cylinder Head Code", "New Design")
            '**************************


            'To be verified
            Dim strRodCapDescription As String = "CYL HEAD " + strBoreDiameter + "-" + strRodDiameter + "-" + strHeadType

            '18-02-10 Sandeep
            If strHeadType = "RR" Then
                If Val(strBoreDiameter) <= 1.5 Then
                    _dblCH_OverallLength = 1.88
                    _dblCH_ShankLength = 1.678
                Else
                    _dblCH_OverallLength = 2
                    _dblCH_ShankLength = 1.8
                End If
                _dblCH_StaticSealPosition = 1.375
            ElseIf strHeadType = "THD" Then
                If _strCH_StandardorCompressed = "C" Then
                    _dblCH_OverallLength = 2
                    _dblCH_ShankLength = 1.63
                    _dblCH_StaticSealPosition = 1.375
                Else
                    _dblCH_OverallLength = 2.13
                    _dblCH_ShankLength = 1.75
                    _dblCH_StaticSealPosition = 1.375
                End If
            End If


            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ShankLength = _dblCH_ShankLength
            '18-02-10 Sandeep

            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OverAllCylinderLength = _dblCH_OverallLength

            _dblCH_StickoutfromTube = _dblCH_OverallLength - _dblCH_ShankLength

            Dim strInternalRetainingRing As String = "N/A"

            Dim strExternalRetainingRing As String = "N/A"

            'Get ORing and BackupRing codes from DB
            Dim strORing As String = "N/A"
            Dim strBackUpRing As String = "N/A"
            Dim oORing_BackUpCodesDatarow As DataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
            GetORing_BackUpCodes(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, strHeadType)
            If Not IsNothing(oORing_BackUpCodesDatarow) Then
                If Not IsDBNull(oORing_BackUpCodesDatarow("ORing")) Then
                    strORing = oORing_BackUpCodesDatarow("ORing")
                End If
                If Not IsDBNull(oORing_BackUpCodesDatarow("BackupRing")) Then
                    strBackUpRing = oORing_BackUpCodesDatarow("BackupRing")
                End If

            End If


            Dim strORingEnviromentalWireRing As String = "N/A"
            Dim strSingleWireRing As String = "N/A"
            Dim strDoubleWireRing As String = "N/A"
            If cmbRodWearRingQty.Text = 0 Then
                strSingleWireRing = "N/A"
                strDoubleWireRing = "N/A"
            ElseIf cmbRodWearRingQty.Text = 1 Then
                strSingleWireRing = _strCH_WearRingCode
                strDoubleWireRing = "N/A"
            ElseIf cmbRodWearRingQty.Text = 2 Then
                strDoubleWireRing = _strCH_WearRingCode
                strSingleWireRing = "N/A"
            End If

            'TODO:01-03-10 Sandeep 3pm
            Dim strNotes As String = ""
            If Not cmbRodWearRing.Text = "None" Then
                strNotes = cmbRodWearRing.Text
            End If
            _blnRowInserted = False
            _strQuery = "INSERT INTO Welded.CylinderHeadDetails VALUES('" + strIFLID + "', '" + _strCH_CylinderHeadCode + "', '" + strRodCapDescription + "', " + strBoreDiameter
            _strQuery += ", " + strRodDiameter + ", '" + strHeadType + "', '" + _strCH_StandardorCompressed + "', " + _dblCH_OverallLength.ToString + ", " + _dblCH_ShankLength.ToString
            _strQuery += ", " + _dblCH_StaticSealPosition.ToString + ", " + _dblCH_StickoutfromTube.ToString + ", '" + _strCH_SnapinWiperCode
            _strQuery += "', '" + strInternalRetainingRing + "', '" + strExternalRetainingRing
            _strQuery += "', '" + strORing + "', '" + strBackUpRing + "', '" + strORingEnviromentalWireRing
            _strQuery += "', '" + _strCH_UCUP605_SealCode + "', '" + _strCH_ZMacro_SealCode + "', '" + _strCH_RodSealInstallationKitcode + "', '" + strSingleWireRing
            _strQuery += "', '" + strDoubleWireRing + "', '" + strNotes + "','" + strPartType + "', Getdate())"
            'TODO:01-03-10 Sandeep 3pm
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.Add("CYL HEAD", _strCH_CylinderHeadCode)         '14_07_2010   RAGAVA
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured while inserting data to Welded.CylinderHeadDetails(InsertNewCylinderHeadDesignData) of frmHeadDesign " + ex.Message)
        End Try
    End Sub

    '01-03-10 Sandeep 3pm
    Public Sub ExecuteQuery_HeadDesign()
        Try
            If _strQuery <> "" Then
                If Not _blnRowInserted Then
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.InsertNewDetails(_strQuery) Then
                        Dim strMessage As String = "New CylinderHead is Generated"
                        lblMessage.Text = strMessage
                        lblMessage.Location = New Point(255, 46)
                        btnHeadDesignContinue.Visible = False
                        txtCylinderHeadCode.Text = _strCH_CylinderHeadCode
                        temCylinderHeadCode.Text = _strCH_CylinderHeadCode
                        ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Cylinder Head Code", _strCH_CylinderHeadCode)
                        _blnRowInserted = True
                    Else
                        Dim strMessage As String = "New CylinderHead is not Generated"
                        lblMessage.Text = strMessage
                        lblMessage.Location = New Point(255, 46)
                        btnHeadDesignContinue.Visible = False
                        txtCylinderHeadCode.Text = ""
                        temCylinderHeadCode.Text = ""
                        ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Cylinder Head Code", "")
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Events"

    Private Sub frmHeadDesign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()
        DefaultSettings()
        ObjClsWeldedCylinderFunctionalClass.AddColors(Me)
    End Sub

    Private Sub cmbHeadType_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbHeadType.SelectedValueChanged, _
    cmbRodWearRingQty.SelectedValueChanged, cmbRodWiperType.SelectedValueChanged
        If sender.Text <> "" Then
            If sender.Text <> sender.IFLDataTag Then
                sender.IFLDataTag = sender.Text
                If sender.name = "cmbHeadType" Then
                    ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Head Type", cmbHeadType.Text)
                End If
                GetCylinderHeadCode()
            End If
        Else
            sender.IFLDataTag = ""
        End If
    End Sub

    Private Sub cmbRodSeal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRodSeal.SelectedIndexChanged
        Try


            If cmbRodSeal.Text <> "" Then
                If cmbRodSeal.Text <> cmbRodSeal.IFLDataTag Then
                    cmbRodSeal.IFLDataTag = cmbRodSeal.Text
                    ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Rod Seal", cmbRodSeal.Text)
                    cmbRodWearRing.Items.Clear()
                    Dim strCylinderHeadRodSeal As String
                    If cmbRodSeal.Text = "Z Macro" Then
                        'cmbRodWearRing.SelectedIndex = 0
                        cmbRodWearRing.Enabled = False
                        cmbRodWearRing.BackColor = Color.Empty
                        If Not IsNothing(_oCylinderHeadDetailsDataRow) Then
                            If Not IsDBNull(_oCylinderHeadDetailsDataRow("ZDeepRodMacroSeal")) Then
                                strCylinderHeadRodSeal = _oCylinderHeadDetailsDataRow("ZDeepRodMacroSeal")
                            End If
                        End If
                    ElseIf cmbRodSeal.Text = "605-U Cup" Then
                        'TODO: ANUP 27-04-2010 09.38am
                        cmbRodWearRing.Items.Clear()
                        '**********
                        cmbRodWearRing.Enabled = True
                        cmbRodWearRing.Items.Add("None")
                        cmbRodWearRing.Items.Add("Garlock")
                        cmbRodWearRing.Items.Add("Glass Filled Nylon")
                        cmbRodWearRing.SelectedIndex = 1

                        If Not IsNothing(_oCylinderHeadDetailsDataRow) Then
                            If Not IsDBNull(_oCylinderHeadDetailsDataRow("UCupRodSeal605")) Then
                                strCylinderHeadRodSeal = _oCylinderHeadDetailsDataRow("UCupRodSeal605")
                            End If
                        End If
                    ElseIf cmbRodSeal.Text = "RU9 Rod Seal" Then
                        LoadRodWireRing()
                        cmbRodWearRing.Enabled = False
                        If Not IsNothing(_oDataRow) Then
                            If Not IsNothing(_oDataRow("UCupRodSeal605")) Then
                                strCylinderHeadRodSeal = _oDataRow("UCupRodSeal605")
                            End If
                        End If
                    End If
                    If Not IsNothing(strCylinderHeadRodSeal) Then
                        'Commented by Sunny 02-08-10
                        'CylinderHeadRodSealCode_CostingParameters(strCylinderHeadRodSeal)
                    End If
                End If
            Else
                cmbRodSeal.IFLDataTag = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbRodWearRing_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRodWearRing.SelectedIndexChanged
        Try


            If cmbRodWearRing.Text <> "" Then
                If cmbRodWearRing.Text <> cmbRodWearRing.IFLDataTag OrElse cmbRodWearRing.Text = cmbRodWearRing.IFLDataTag Then
                    GetCylinderHeadCode() '06_04_2010 Aruna
                    cmbRodWearRing.IFLDataTag = cmbRodWearRing.Text
                    cmbRodWearRingQty.Items.Clear()
                    Dim strWearRing_S_D As String
                    If cmbRodWearRing.Text = "None" Then
                        cmbRodWearRingQty.Items.Add(0)
                        cmbRodWearRingQty.SelectedIndex = 0
                        cmbRodWearRingQty.Enabled = False
                        cmbRodWearRingQty.BackColor = Color.Empty
                    ElseIf cmbRodWearRing.Text = "Garlock" OrElse cmbRodWearRing.Text = "Glass Filled Nylon" Then
                        cmbRodWearRingQty.Items.Add(1)
                        cmbRodWearRingQty.Items.Add(2)
                        cmbRodWearRingQty.SelectedIndex = 0
                        cmbRodWearRingQty.Enabled = True

                        If Not IsNothing(_oCylinderHeadDetailsDataRow) Then
                            If Not IsDBNull(_oCylinderHeadDetailsDataRow("SingleWearRing")) OrElse Not IsDBNull(_oCylinderHeadDetailsDataRow("DoubleWearRing")) Then
                                If Not IsNothing(_oCylinderHeadDetailsDataRow("SingleWearRing")) Then
                                    strWearRing_S_D = _oCylinderHeadDetailsDataRow("SingleWearRing")
                                ElseIf Not IsNothing(_oCylinderHeadDetailsDataRow("DoubleWearRing")) Then
                                    strWearRing_S_D = _oCylinderHeadDetailsDataRow("DoubleWearRing")
                                End If
                                'Commented by Sunny 02-08-10
                                'CylinderHeadWearRing_CostingParameters(strWearRing_S_D)
                            End If
                        End If

                    ElseIf cmbRodWearRing.Text = "YES" Then
                        If Not IsNothing(_oDataRow("SingleWearRing")) AndAlso (_oDataRow("SingleWearRing") <> "N/A") Then
                            cmbRodWearRingQty.Items.Add(1)
                            cmbRodWearRingQty.SelectedIndex = 0
                            ' cmbRodWearRingQty.Enabled = False
                        ElseIf Not IsNothing(_oDataRow("DoubleWearRing")) AndAlso (_oDataRow("DoubleWearRing")) Then
                            cmbRodWearRingQty.Items.Add(2)
                            cmbRodWearRingQty.SelectedIndex = 0
                            'cmbRodWearRingQty.Enabled = False
                        End If

                        If Not IsNothing(_oDataRow) Then
                            If Not IsNothing(_oDataRow("SingleWearRing")) AndAlso (_oDataRow("SingleWearRing") <> "N/A") Then
                                strWearRing_S_D = _oDataRow("SingleWearRing")
                            ElseIf Not IsNothing(_oDataRow("DoubleWearRing")) AndAlso (_oDataRow("DoubleWearRing")) Then
                                strWearRing_S_D = _oDataRow("DoubleWearRing")
                            End If
                            'Commented by Sunny 02-08-10
                            'CylinderHeadWearRing_CostingParameters(strWearRing_S_D)
                        End If
                    ElseIf cmbRodWearRing.Text = "NO" Then
                        cmbRodWearRingQty.Items.Add(0)
                        cmbRodWearRingQty.SelectedIndex = 0
                        cmbRodWearRingQty.Enabled = False
                    End If
                End If
            Else
                cmbRodWearRing.IFLDataTag = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHeadDesignContinue.Click
        NewCylinderHeadDesignFuncionality()
        InsertNewCylinderHeadDesignData()
    End Sub

    Private Sub cmbHeadType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbHeadType.SelectedIndexChanged
        'ANUP 01-07-2010
        'If cmbHeadType.Text = "Threaded" Then
        '    MessageBox.Show("WR Cylinder Design is not available for Threaded Heads", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
        'End If

        LoadRodSeals()
        cmbRodWearRing_SelectedIndexChanged(sender, e)

    End Sub

#End Region

#Region "MODIFIED CODE"
    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_GreenBorder_ColoringTheScreens(LabelGradient3, LabelGradient5, LabelGradient4, LabelGradient2)
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(lblHeadDesign)
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(lblInsertIntoDb)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblHeadDesignIndex)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblInsertCylinderHeadDetails)
    End Sub


    Private Sub LoadRodSeals()
        Try
            cmbRodSeal.Items.Clear()
            cmbRodSeal.Enabled = True
            txtSealType.Visible = False    '28_10_2010   RAGAVA
            cmbRodWearRingQty.Enabled = True   '28_10_2010   RAGAVA
            cmbRodWearRing.Enabled = True  '28_10_2010   RAGAVA
            If cmbHeadType.Text = "Threaded" Then
                cmbRodSeal.Items.Add("605-U Cup")
                cmbRodSeal.SelectedIndex = 0
                cmbRodSeal.Enabled = False    '28_10_2010   RAGAVA
                txtSealType.Visible = True    '28_10_2010   RAGAVA
                txtSealType.Enabled = False   '28_10_2010   RAGAVA
                cmbRodWearRingQty.Enabled = False   '28_10_2010   RAGAVA
                cmbRodWearRing.Enabled = False  '28_10_2010   RAGAVA
                'cmbRodSeal.Items.Add("Z Macro")        '28_10_2010   RAGAVA
                MessageBox.Show("WR Cylinder Design is not available for Threaded Heads", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
            ElseIf cmbHeadType.Text = "WireRing" Then
                cmbRodSeal.Items.Add("RU9 Rod Seal")
                cmbRodSeal.SelectedIndex = 0
                cmbRodSeal.Enabled = False

            End If
            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Rod Seal", cmbRodSeal.Text)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadRodWireRing()
        Try
            cmbRodWearRing.Items.Clear()
            If _oDataRow("SingleWearRing") <> "N/A" OrElse _oDataRow("DoubleWearRing") <> "N/A" Then
                cmbRodWearRing.Items.Add("YES")
            Else
                cmbRodWearRing.Items.Add("NO")
            End If

            'Commented by Sunny 02-08-10
            'ANUP 13-07-2010
            'If ObjClsWeldedCylinderFunctionalClass.htCostingCodeList.ContainsKey("CylinderHeadWearRing") Then
            '    ObjClsWeldedCylinderFunctionalClass.htCostingCodeList("CylinderHeadWearRing") = _oDataRow("SingleWearRing")
            'Else
            '    ObjClsWeldedCylinderFunctionalClass.htCostingCodeList.Add("CylinderHeadWearRing", _oDataRow("SingleWearRing"))
            'End If

            cmbRodWearRing.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Sub

#End Region

End Class