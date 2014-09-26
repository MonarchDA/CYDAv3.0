Public Class clsAddExistingCodes

#Region "Private Variables"

    Public Shared _htExistingCostingCodeList As New Hashtable
    Public Shared _htTubeCostingCodeList As New Hashtable
    Public Shared _htRodCostingCodeList As New Hashtable

    'Primary Screen
    Public Const RODMATERIALCODE As String = "RodMaterialCode"
    Public Const STOPTUBECODE As String = "StopTubeCode"
    Public Const PISTONNUTCODE As String = "PistonNutCode"

    'Piston Screen
    Public Const PISTONCODE As String = "PistonCode"
    Public Const PISTONSEALCODE As String = "PistonSealCode"
    Public Const PISTONWEARRINGCODE As String = "PistonWearRingCode"

    'Head Screen
    Public Const CYLINDERHEADCODE As String = "CylinderHeadCode"
    Public Const RODSEALCODE As String = "RodSealCode"
    Public Const RODWEARRINGCODE As String = "RodWearRingCode"
    Public Const SNAPINWIPERCODE As String = "SnapinWiperCode"
    Public Const WNUCWIPERCODE As String = "WNUCWiperCode" 'anup01-02-2011
    Public Const RODSEALINSTALLATIONKITCODE As String = "RodSealInstallationKitcode"
    Public Const ORINGCODE As String = "OringCode"
    Public Const BACKUPRINGCODE As String = "BackupRingCode"
    Public Const EXTERNALWIRERINGCODE As String = "ExternalWireRingCode"
    Public Const INTERNALWIRERINGCODE As String = "InternalWireRingCode"

    'TubeEnd Screen
    Public Const TUBEMATERIALCODE As String = "TubeMaterialCode"
    Public Const CLEVISPLATECODE As String = "ClevisPlateCode"
    Public Const BASEENDCONFIGURATIONCODE As String = "BaseEndConfigurationCode"
    Public Const BUSHINGBASEENDCODE As String = "BushingBaseEndCode"
    Public Const ENDCOLLARCODE As String = "EndCollarCode"

    'RodEnd Screen
    Public Const RODENDCONFIGURATIONCODE As String = "RodEndConfigurationCode"
    Public Const BUSHINGRODENDCODE As String = "BushingRodEndCode"

    'PortDetails Screen
    Public Const BASEENDPORTCODE As String = "BaseEndPortCode"
    Public Const BASEENDPORTLOCATORCODE As String = "BaseEndPortLocatorCode"
    Public Const RODENDPORTCODE As String = "RodEndPortCode"
    Public Const RODENDPORTLOCATORCODE As String = "RodEndPortLocatorCode"

    'frmPin_Port_PaintAccessories Screen
    Public Const BASEENDPINCODE As String = "BaseEndPinCode"
    Public Const RODENDPINCODE As String = "RodEndPinCode"
    Public Const BASEENDCLIPCODE As String = "BaseEndClipCode"
    Public Const RODENDCLIPCODE As String = "RodEndClipCode"
    Public Const BASEENDPORTACCESSORYCODE As String = "BaseEndPortAccessoryCode"
    Public Const RODENDPORTACCESSORYCODE As String = "RodEndPortAccessoryCode"
    Public Const GREASEZERCCODE As String = "GreaseZercCode"
    Public Const PAINTCODE As String = "PaintCode"


#End Region

#Region "Properties"

    Public Shared ReadOnly Property HTExistingCostingCodeList() As Hashtable
        Get
            Return _htExistingCostingCodeList
        End Get
    End Property

    Public Shared ReadOnly Property HTTubeCostingCodeList() As Hashtable
        Get
            Return _htTubeCostingCodeList
        End Get
    End Property

    Public Shared ReadOnly Property HTRodCostingCodeList() As Hashtable
        Get
            Return _htRodCostingCodeList
        End Get
    End Property

#End Region

#Region "Primary Inputs"

    Public Shared Sub AddRodMaterialCode(ByVal strRodMaterialCode As String, ByVal dblQuantity As Double, ByVal strUnit As String)
        If Not IsNothing(strRodMaterialCode) OrElse Trim(strRodMaterialCode).Length > 0 Then
            AddRodCodeToHashTable(RODMATERIALCODE, strRodMaterialCode, dblQuantity, strUnit)
        Else
            AddRodCodeToHashTable(RODMATERIALCODE, Nothing)
        End If
    End Sub

    Public Shared Sub AddStopTubeCode(ByVal strStopTubeCode As String, ByVal dblQuantity As Double, ByVal strUnit As String)
        If Not IsNothing(strStopTubeCode) OrElse Trim(strStopTubeCode).Length > 0 Then
            AddExistingCodeToHashTable(STOPTUBECODE, strStopTubeCode, dblQuantity, strUnit)
        Else
            AddExistingCodeToHashTable(STOPTUBECODE, Nothing)
        End If
    End Sub

    '07_10_2010    RAGAVA
    Public Shared Sub AddStaticSealCode()
        Try
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign.cmbHeadType.Text = "WireRing" Then
                Dim strquery As String = "Select ZDeepRodMacroSeal from CylinderHeadDetails where CylinderHeadCode = " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CylinderHeadCode
                Dim dr As DataRow = MonarchConnectionObject.GetDataRow(strquery)
                Dim SealCode As String = dr("ZDeepRodMacroSeal")
                AddExistingCodeToHashTable("StaticSealCode", SealCode, "1.00", "EA")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub AddPistonNutCode(ByVal strPistonNutCode As String, ByVal dblQuantity As Double, ByVal strUnit As String)
        If Not IsNothing(strPistonNutCode) OrElse Trim(strPistonNutCode).Length > 0 Then
            AddExistingCodeToHashTable(PISTONNUTCODE, strPistonNutCode, dblQuantity, strUnit)
        Else
            AddExistingCodeToHashTable(PISTONNUTCODE, Nothing)
        End If
    End Sub

    Public Shared Function RodWeight() As Double
        Dim dblRodLength As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodLength
        Dim dblRodWeight As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsMIL_TieRodDataClass.GetRodWeight(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter)
        Dim dblRodWeightPerFoot As Double = dblRodWeight
        Dim dblQuantityPerRodPart As Double = (dblRodLength + 0.25) * (dblRodWeightPerFoot / 12)
        Return dblQuantityPerRodPart
    End Function

    Public Shared Sub GetWiperSealRodDiameter(ByVal strMaterial As Double) 'vamsi 13-08-2014

        Try
            Dim strSQL As String
            strSQL = "Select PartNumber from WiperSealRodDiameter where RodDiameter='" & strMaterial & "'"
            Dim dr As DataRow = MonarchConnectionObject.GetDataRow(strSQL)
            Dim RodPartCode As String = dr("PartNumber")
            AddExistingCodeToHashTable("MASKWIPERSEAL", RodPartCode, "1.00", "EA")
        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region "Piston Details"

    Public Shared Sub AddPistonCode(ByVal strPistonCode As String, ByVal dblQuantity As Double, ByVal strUnit As String)
        If Not IsNothing(strPistonCode) OrElse Trim(strPistonCode).Length > 0 Then
            AddExistingCodeToHashTable(PISTONCODE, strPistonCode, dblQuantity, strUnit)
        Else
            AddExistingCodeToHashTable(PISTONCODE, Nothing)
        End If
    End Sub

    Public Shared Sub AddPistonSealCode(ByVal strPistonSealCode As String, ByVal dblQuantity As Double, ByVal strUnit As String)
        If Not IsNothing(strPistonSealCode) OrElse Trim(strPistonSealCode).Length > 0 Then
            AddExistingCodeToHashTable(PISTONSEALCODE, strPistonSealCode, dblQuantity, strUnit)
        Else
            AddExistingCodeToHashTable(PISTONSEALCODE, Nothing)
        End If
    End Sub

    Public Shared Sub AddPistonWearRingCode(ByVal strPistonWearRingCode As String, ByVal dblQuantity As Double, ByVal strUnit As String)
        If Not IsNothing(strPistonWearRingCode) OrElse Trim(strPistonWearRingCode).Length > 0 Then
            AddExistingCodeToHashTable(PISTONWEARRINGCODE, strPistonWearRingCode, dblQuantity, strUnit)
        Else
            AddExistingCodeToHashTable(PISTONWEARRINGCODE, Nothing)
        End If
    End Sub

#End Region

#Region "HeadCylinder"

    Public Shared Sub AddCylinderHeadCode(ByVal strCylinderHeadCode As String, ByVal dblQuantity As Double, ByVal strUnit As String)
        If Not IsNothing(strCylinderHeadCode) OrElse Trim(strCylinderHeadCode).Length > 0 Then
            AddExistingCodeToHashTable(CYLINDERHEADCODE, strCylinderHeadCode, dblQuantity, strUnit)
        Else
            AddExistingCodeToHashTable(CYLINDERHEADCODE, Nothing)
        End If
    End Sub

    Public Shared Sub AddRodSealCode(ByVal strRodSealCode As String, ByVal dblQuantity As Double, ByVal strUnit As String)
        If Not IsNothing(strRodSealCode) OrElse Trim(strRodSealCode).Length > 0 Then
            AddExistingCodeToHashTable(RODSEALCODE, strRodSealCode, dblQuantity, strUnit)
        Else
            AddExistingCodeToHashTable(RODSEALCODE, Nothing)
        End If
    End Sub

    Public Shared Sub AddRodWearRingCode(ByVal strRodWearRingCode As String, ByVal dblQuantity As Double, ByVal strUnit As String)
        If Not IsNothing(strRodWearRingCode) OrElse Trim(strRodWearRingCode).Length > 0 Then
            AddExistingCodeToHashTable(RODWEARRINGCODE, strRodWearRingCode, dblQuantity, strUnit)
        Else
            AddExistingCodeToHashTable(RODWEARRINGCODE, Nothing)
        End If
    End Sub

    '09_10_2010  RAGAVA
    Public Shared Sub ZDeepMacroSeal(ByVal strZDeepMacroSealCode As String, ByVal dblQuantity As Double, ByVal strUnit As String)
        If Not IsNothing(strZDeepMacroSealCode) OrElse Trim(strZDeepMacroSealCode).Length > 0 Then
            AddExistingCodeToHashTable("ZDeepRodMacroSeal", strZDeepMacroSealCode, dblQuantity, strUnit)
        Else
            AddExistingCodeToHashTable("ZDeepRodMacroSeal", Nothing)
        End If
    End Sub


    Public Shared Sub AddSnapInWiperCode(ByVal strSnapInWiperCode As String, ByVal dblQuantity As Double, ByVal strUnit As String)
        'If Not IsNothing(strSnapInWiperCode) OrElse Trim(strSnapInWiperCode).Length > 0 Then
        '    AddExistingCodeToHashTable(SNAPINWIPERCODE, strSnapInWiperCode, dblQuantity, strUnit)
        'Else
        '    AddExistingCodeToHashTable(SNAPINWIPERCODE, Nothing)
        'End If
        'anup 01-02-2011 start
        If ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign.cmbRodWiperType.Text = "WNUC" Then
            If Not IsNothing(strSnapInWiperCode) OrElse Trim(strSnapInWiperCode).Length > 0 Then
                AddExistingCodeToHashTable(WNUCWIPERCODE, strSnapInWiperCode, dblQuantity, strUnit)
            Else
                AddExistingCodeToHashTable(WNUCWIPERCODE, Nothing)
            End If
        Else
            If Not IsNothing(strSnapInWiperCode) OrElse Trim(strSnapInWiperCode).Length > 0 Then
                AddExistingCodeToHashTable(SNAPINWIPERCODE, strSnapInWiperCode, dblQuantity, strUnit)
            Else
                AddExistingCodeToHashTable(SNAPINWIPERCODE, Nothing)
            End If
        End If
        'anup 01-02-2011 till here
    End Sub

    Public Shared Sub AddRodSealInstallationKitCode(ByVal strRodSealInstallationKitCode As String, ByVal dblQuantity As Double, ByVal strUnit As String)
        If Not IsNothing(strRodSealInstallationKitCode) OrElse Trim(strRodSealInstallationKitCode).Length > 0 Then
            AddExistingCodeToHashTable(RODSEALINSTALLATIONKITCODE, strRodSealInstallationKitCode, dblQuantity, strUnit)
        Else
            AddExistingCodeToHashTable(RODSEALINSTALLATIONKITCODE, Nothing)
        End If
    End Sub

    Public Shared Sub AddORingCode(ByVal strORingCode As String, ByVal dblQuantity As Double, ByVal strUnit As String)
        If Not IsNothing(strORingCode) OrElse Trim(strORingCode).Length > 0 Then
            AddExistingCodeToHashTable(ORINGCODE, strORingCode, dblQuantity, strUnit)
        Else
            AddExistingCodeToHashTable(ORINGCODE, Nothing)
        End If
    End Sub

    Public Shared Sub AddBackUpRingCode(ByVal strBackUpRingCode As String, ByVal dblQuantity As Double, ByVal strUnit As String)
        If Not IsNothing(strBackUpRingCode) OrElse Trim(strBackUpRingCode).Length > 0 Then
            AddExistingCodeToHashTable(BACKUPRINGCODE, strBackUpRingCode, dblQuantity, strUnit)
        Else
            AddExistingCodeToHashTable(BACKUPRINGCODE, Nothing)
        End If
    End Sub

    Public Shared Sub AddExternalWireRingCode(ByVal strExternalWireRingCode As String, ByVal dblQuantity As Double, ByVal strUnit As String)
        If Not IsNothing(strExternalWireRingCode) OrElse Trim(strExternalWireRingCode).Length > 0 Then
            AddExistingCodeToHashTable(EXTERNALWIRERINGCODE, strExternalWireRingCode, dblQuantity, strUnit)
        Else
            AddExistingCodeToHashTable(EXTERNALWIRERINGCODE, Nothing)
        End If
    End Sub

    Public Shared Sub AddInternalWireRingCode(ByVal strInternalWireRingCode As String, ByVal dblQuantity As Double, ByVal strUnit As String)
        If Not IsNothing(strInternalWireRingCode) OrElse Trim(strInternalWireRingCode).Length > 0 Then
            AddExistingCodeToHashTable(INTERNALWIRERINGCODE, strInternalWireRingCode, dblQuantity, strUnit)
        Else
            AddExistingCodeToHashTable(INTERNALWIRERINGCODE, Nothing)
        End If
    End Sub

#End Region

#Region "Tube Details"

    Public Shared Sub AddTubeMaterialCode(ByVal strTubeMaterialCode As String, ByVal dblQuantity As Double, ByVal strUnit As String)
        If Not IsNothing(strTubeMaterialCode) OrElse Trim(strTubeMaterialCode).Length > 0 Then
            AddTubeCodeToHashTable(TUBEMATERIALCODE, strTubeMaterialCode, dblQuantity, strUnit)
        Else
            AddTubeCodeToHashTable(TUBEMATERIALCODE, Nothing)
        End If
    End Sub
    '07_03_2012   RAGAVA
    Public Shared Sub AddCheckBallCode(ByVal strCheckBallCode As String, ByVal dblQuantity As Double, ByVal strUnit As String)
        If Not IsNothing(strCheckBallCode) OrElse Trim(strCheckBallCode).Length > 0 Then
            AddTubeCodeToHashTable("BALL 3/16 DIA STEEL CHROME", strCheckBallCode, dblQuantity, strUnit, 0.02)
        Else
            AddTubeCodeToHashTable("BALL 3/16 DIA STEEL CHROME", Nothing)
        End If
    End Sub

    Public Shared Sub AddClevisPlateCode(ByVal strClevisPlateCode As String, ByVal dblQuantity As Double, ByVal strUnit As String)
        If Not IsNothing(strClevisPlateCode) OrElse Trim(strClevisPlateCode).Length > 0 Then
            AddTubeCodeToHashTable(CLEVISPLATECODE, strClevisPlateCode, dblQuantity, strUnit)
        Else
            AddTubeCodeToHashTable(CLEVISPLATECODE, Nothing)
        End If
    End Sub

    Public Shared Sub AddBaseEndConfigurationCode(ByVal strBaseEndConfigurationCode As String, ByVal dblQuantity As Double, ByVal strUnit As String)
        If Not IsNothing(strBaseEndConfigurationCode) OrElse Trim(strBaseEndConfigurationCode).Length > 0 Then
            Dim dblclsFindCastingCost As New clsFindCastingCost(True)
            AddTubeCodeToHashTable(BASEENDCONFIGURATIONCODE, strBaseEndConfigurationCode, dblQuantity, strUnit, dblclsFindCastingCost.GetCost())
        Else
            AddTubeCodeToHashTable(BASEENDCONFIGURATIONCODE, Nothing)
        End If
    End Sub

    Public Shared Sub AddBushingBaseEndCode(ByVal strBushingBaseEndCode As String, ByVal dblQuantity As Double, ByVal strUnit As String)
        If Not IsNothing(strBushingBaseEndCode) OrElse Trim(strBushingBaseEndCode).Length > 0 Then
            AddTubeCodeToHashTable(BUSHINGBASEENDCODE, strBushingBaseEndCode, dblQuantity, strUnit)
        Else
            AddTubeCodeToHashTable(BUSHINGBASEENDCODE, Nothing)
        End If
    End Sub

    Public Shared Sub AddEndCollarCode(ByVal strEndCollarCode As String, ByVal dblQuantity As Double, ByVal strUnit As String)
        If Not IsNothing(strEndCollarCode) OrElse Trim(strEndCollarCode).Length > 0 Then
            AddTubeCodeToHashTable(ENDCOLLARCODE, strEndCollarCode, dblQuantity, strUnit)
        Else
            AddTubeCodeToHashTable(ENDCOLLARCODE, Nothing)
        End If
    End Sub

    Public Shared Function GetTubeLength() As Double
        Dim dblTubeLength As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OriginalTubeLength
        GetTubeLength = (dblTubeLength + (3 / 8)) / 12
    End Function

#End Region

#Region "RodEnd Details"

    Public Shared Sub AddRodEndConfigurationCode(ByVal strRodEndConfigurationCode As String, ByVal dblQuantity As Double, ByVal strUnit As String)
        If Not IsNothing(strRodEndConfigurationCode) OrElse Trim(strRodEndConfigurationCode).Length > 0 Then
            Dim dblclsFindCastingCost As New clsFindCastingCost(False)
            AddRodCodeToHashTable(RODENDCONFIGURATIONCODE, strRodEndConfigurationCode, dblQuantity, strUnit, dblclsFindCastingCost.GetCost())
        Else
            AddRodCodeToHashTable(RODENDCONFIGURATIONCODE, Nothing)
        End If
    End Sub

    Public Shared Sub AddBushingRodEndCode(ByVal strBushingRodEndCode As String, ByVal dblQuantity As Double, ByVal strUnit As String)
        If Not IsNothing(strBushingRodEndCode) OrElse Trim(strBushingRodEndCode).Length > 0 Then
            AddRodCodeToHashTable(BUSHINGRODENDCODE, strBushingRodEndCode, dblQuantity, strUnit)
        Else
            AddRodCodeToHashTable(BUSHINGRODENDCODE, Nothing)
        End If
    End Sub

#End Region

#Region "PortDetails"

    Public Shared Sub AddBaseEndPortCode(ByVal strBaseEndPortCode As String, ByVal dblQuantity As Double, ByVal strUnit As String)
        If Not IsNothing(strBaseEndPortCode) OrElse Trim(strBaseEndPortCode).Length > 0 Then
            AddTubeCodeToHashTable(BASEENDPORTCODE, strBaseEndPortCode, dblQuantity, strUnit)
        Else
            AddTubeCodeToHashTable(BASEENDPORTCODE, Nothing)
        End If
    End Sub

    Public Shared Sub AddBaseEndPortLocatorCode(ByVal strBaseEndPortLocatorCode As String, ByVal dblQuantity As Double, ByVal strUnit As String)
        If Not IsNothing(strBaseEndPortLocatorCode) OrElse Trim(strBaseEndPortLocatorCode).Length > 0 Then
            AddExistingCodeToHashTable(BASEENDPORTLOCATORCODE, strBaseEndPortLocatorCode, dblQuantity, strUnit)
        Else
            AddExistingCodeToHashTable(BASEENDPORTLOCATORCODE, Nothing)
        End If
    End Sub

    Public Shared Sub AddRodEndPortCode(ByVal strRodEndPortCode As String, ByVal dblQuantity As Double, ByVal strUnit As String)
        If Not IsNothing(strRodEndPortCode) OrElse Trim(strRodEndPortCode).Length > 0 Then
            AddTubeCodeToHashTable(RODENDPORTCODE, strRodEndPortCode, dblQuantity, strUnit)
        Else
            AddTubeCodeToHashTable(RODENDPORTCODE, Nothing)
        End If
    End Sub

    Public Shared Sub AddRodEndPortLocatorCode(ByVal strRodEndPortLocatorCode As String, ByVal dblQuantity As Double, ByVal strUnit As String)
        If Not IsNothing(strRodEndPortLocatorCode) OrElse Trim(strRodEndPortLocatorCode).Length > 0 Then
            AddExistingCodeToHashTable(RODENDPORTLOCATORCODE, strRodEndPortLocatorCode, dblQuantity, strUnit)
        Else
            AddExistingCodeToHashTable(RODENDPORTLOCATORCODE, Nothing)
        End If
    End Sub

#End Region

#Region "Pin Clip Paint Accessories"

    Public Shared Sub AddBaseEndPinCode(ByVal strBaseEndPinCode As String, ByVal dblQuantity As Double, ByVal strUnit As String)
        If Not IsNothing(strBaseEndPinCode) OrElse Trim(strBaseEndPinCode).Length > 0 Then
            AddExistingCodeToHashTable(BASEENDPINCODE, strBaseEndPinCode, dblQuantity, strUnit)
        Else
            AddExistingCodeToHashTable(BASEENDPINCODE, Nothing)
        End If
    End Sub

    Public Shared Sub AddRodEndPinCode(ByVal strRodEndPinCode As String, ByVal dblQuantity As Double, ByVal strUnit As String)
        If Not IsNothing(strRodEndPinCode) OrElse Trim(strRodEndPinCode).Length > 0 Then
            AddExistingCodeToHashTable(RODENDPINCODE, strRodEndPinCode, dblQuantity, strUnit)
        Else
            AddExistingCodeToHashTable(RODENDPINCODE, Nothing)
        End If
    End Sub

    Public Shared Sub AddBaseEndClipCode(ByVal strBaseEndClipCode As String, ByVal dblQuantity As Double, ByVal strUnit As String)
        If Not IsNothing(strBaseEndClipCode) OrElse Trim(strBaseEndClipCode).Length > 0 Then
            AddExistingCodeToHashTable(BASEENDCLIPCODE, strBaseEndClipCode, dblQuantity, strUnit)
        Else
            AddExistingCodeToHashTable(BASEENDCLIPCODE, Nothing)
        End If
    End Sub

    Public Shared Sub AddRodEndClipCode(ByVal strRodEndClipCode As String, ByVal dblQuantity As Double, ByVal strUnit As String)
        If Not IsNothing(strRodEndClipCode) OrElse Trim(strRodEndClipCode).Length > 0 Then
            AddExistingCodeToHashTable(RODENDCLIPCODE, strRodEndClipCode, dblQuantity, strUnit)
        Else
            AddExistingCodeToHashTable(RODENDCLIPCODE, Nothing)
        End If
    End Sub

    Public Shared Sub AddBaseEndPortAccessoryCode(ByVal strBaseEndPortAccessoryCode As String, ByVal dblQuantity As Double, ByVal strUnit As String)
        If Not IsNothing(strBaseEndPortAccessoryCode) OrElse Trim(strBaseEndPortAccessoryCode).Length > 0 Then
            AddExistingCodeToHashTable(BASEENDPORTACCESSORYCODE, strBaseEndPortAccessoryCode, dblQuantity, strUnit)
        Else
            AddExistingCodeToHashTable(BASEENDPORTACCESSORYCODE, Nothing)
        End If
    End Sub

    Public Shared Sub AddRodEndPortAccessoryCode(ByVal strRodEndPortAccessoryCode As String, ByVal dblQuantity As Double, ByVal strUnit As String)
        If Not IsNothing(strRodEndPortAccessoryCode) OrElse Trim(strRodEndPortAccessoryCode).Length > 0 Then
            AddExistingCodeToHashTable(RODENDPORTACCESSORYCODE, strRodEndPortAccessoryCode, dblQuantity, strUnit)
        Else
            AddExistingCodeToHashTable(RODENDPORTACCESSORYCODE, Nothing)
        End If
    End Sub

    Public Shared Sub AddGreaseZercCode(ByVal strGreaseZercCode As String, ByVal dblQuantity As Double, ByVal strUnit As String)
        If Not IsNothing(strGreaseZercCode) OrElse Trim(strGreaseZercCode).Length > 0 Then
            AddExistingCodeToHashTable(GREASEZERCCODE, strGreaseZercCode, dblQuantity, strUnit)
        Else
            AddExistingCodeToHashTable(GREASEZERCCODE, Nothing)
        End If
    End Sub

    Public Shared Sub AddPaintCode(ByVal strPaintCode As String, ByVal dblQuantity As Double, ByVal strUnit As String)
        If Not IsNothing(strPaintCode) OrElse Trim(strPaintCode).Length > 0 Then
            AddExistingCodeToHashTable(PAINTCODE, strPaintCode, dblQuantity, strUnit)
        Else
            AddExistingCodeToHashTable(PAINTCODE, Nothing)
        End If
    End Sub

    Public Shared Sub AddLable(ByVal IsRephasing As Boolean, ByVal RodMaterial As String)    'Neeraja
        If IsRephasing = True Then
            AddExistingCodeToHashTable("DECAL WP3000 CYL LION", "233067", 1, "EA")
        End If
        If IsRephasing = False And RodMaterial = "Chrome" Then
            AddExistingCodeToHashTable("DECAL WD3000 CYL LION", "233066", 1, "EA")
        Else
            AddExistingCodeToHashTable("DECAL LION 1000 CHROME", "232990", 1, "EA")
        End If
    End Sub

#End Region

#Region "Common"

    Public Shared Sub AddExistingCodeToHashTable(ByVal strCodeKey As String, ByVal strCodeValue As String, Optional ByVal dblQuantity As Double = 1, Optional ByVal strUnit As String = "EA")
        If _htExistingCostingCodeList.ContainsKey(strCodeKey) Then
            If Not IsNothing(strCodeValue) AndAlso strCodeValue.Length >= 1 AndAlso strCodeValue <> "N/A" Then   '09_10_2010   RAGAVA  "N/A" condition added
                Dim oList As New clsList
                oList.strPartCode = strCodeValue
                oList.dblQuantity = dblQuantity
                oList.strUnit = strUnit
                _htExistingCostingCodeList(strCodeKey) = oList
            Else
                _htExistingCostingCodeList.Remove(strCodeKey)
            End If
        Else
            If Not IsNothing(strCodeValue) AndAlso strCodeValue.Length >= 1 AndAlso strCodeValue <> "N/A" Then   '09_10_2010   RAGAVA  "N/A" condition added
                Dim oList As New clsList
                oList.strPartCode = strCodeValue
                oList.dblQuantity = dblQuantity
                oList.strUnit = strUnit
                _htExistingCostingCodeList.Add(strCodeKey, oList)
            End If
        End If
    End Sub

    Public Shared Sub AddTubeCodeToHashTable(ByVal strCodeKey As String, ByVal strCodeValue As String, Optional ByVal dblQuantity As Double = 1, Optional ByVal strUnit As String = "EA", Optional ByVal dblCost As Double = 0)
        If _htTubeCostingCodeList.ContainsKey(strCodeKey) Then
            If Not IsNothing(strCodeValue) AndAlso strCodeValue.Length >= 1 Then
                Dim oList As New clsList
                oList.strPartCode = strCodeValue
                oList.dblQuantity = dblQuantity
                oList.strUnit = strUnit
                oList.dblCost = dblCost
                _htTubeCostingCodeList(strCodeKey) = oList
            Else
                _htTubeCostingCodeList.Remove(strCodeKey)
            End If
        Else
            If Not IsNothing(strCodeValue) AndAlso strCodeValue.Length >= 1 Then
                Dim oList As New clsList
                oList.strPartCode = strCodeValue
                oList.dblQuantity = dblQuantity
                oList.strUnit = strUnit
                oList.dblCost = dblCost
                _htTubeCostingCodeList.Add(strCodeKey, oList)
            End If
        End If
    End Sub

    Private Shared Sub AddRodCodeToHashTable(ByVal strCodeKey As String, ByVal strCodeValue As String, Optional ByVal dblQuantity As Double = 1, Optional ByVal strUnit As String = "EA", Optional ByVal dblCost As Double = 0)
        If _htRodCostingCodeList.ContainsKey(strCodeKey) Then
            If Not IsNothing(strCodeValue) AndAlso strCodeValue.Length >= 1 Then
                Dim oList As New clsList
                oList.strPartCode = strCodeValue
                oList.dblQuantity = dblQuantity
                oList.strUnit = strUnit
                oList.dblCost = dblCost
                _htRodCostingCodeList(strCodeKey) = oList
            Else
                _htRodCostingCodeList.Remove(strCodeKey)
            End If
        Else
            If Not IsNothing(strCodeValue) AndAlso strCodeValue.Length >= 1 Then
                Dim oList As New clsList
                oList.strPartCode = strCodeValue
                oList.dblQuantity = dblQuantity
                oList.strUnit = strUnit
                oList.dblCost = dblCost
                _htRodCostingCodeList.Add(strCodeKey, oList)
            End If
        End If
    End Sub

#End Region

End Class
