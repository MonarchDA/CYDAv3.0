Imports System.IO
Public Class clsWeldedGlobalVariables
    Public oRenamingHashTable As New Hashtable          '14_07_2010    RAGAVA
    'Dim oClsReleaseCylinderFunctionality As New clsReleaseCylinderFunctionality          '23_06_2011   RAGAVA
#Region "Private Variables"

    Public strCast_Fabricated_1st As String = String.Empty          '15_03_2012   RAGAVA
    Public blnBaseEndCasting_New As Boolean = False         '15_03_2012   RAGAVA
    Public blnBaseEndFabrication_New As Boolean = False          '15_03_2012   RAGAVA
    Public strBaseEndCastingTable As String = String.Empty        '15_05_2012   RAGAVA
    Public strBaseEndFabricationTable As String = String.Empty        '15_05_2012   RAGAVA
    Public strBaseEndCastingPart As String = String.Empty        '15_05_2012   RAGAVA
    Public strBaseEndFabricationPart As String = String.Empty        '15_05_2012   RAGAVA

    Public blnNewCastingGenerated As Boolean = False         '17_10_2012   RAGAVA
    Public blnNewFabricationGenerated As Boolean = False         '17_10_2012   RAGAVA

    Public blnExistingPartSelected_BaseEnd As Boolean = False         '20_10_2010    RAGAVA
    Public blnExistingPartSelected_RodEnd As Boolean = False          '20_10_2010    RAGAVA
    Public blnExistingPartSelected_RodEnd2 As Boolean = False          '24_07_2012    RAGAVA
    Public strWC_619_622 As String = String.Empty   '30_12_2011   RAGAVA
    Public blnBendradius_error As Boolean = False            '05_01_2012   RAGAVA
    'Public blnFabricated2SingleLug As Boolean = False        '05_01_2012   RAGAVA
    'Public bln2SingleLugSelected As Boolean = False          '05_01_2012   RAGAVA

#Region "Primary Inputs"

    Private _dblDistanceFromPinholetoRodStop As Double           '27_02_2010   RAGAVA

    Private _strSeriesCode As String = String.Empty            '23_02_2010    RAGAVA

    Private _dblBoreDiameter As Double

    Private _dblWorkingPressure As Double

    Private _strColumnLoadDeratePressure As String = String.Empty

    Private _strPistonConnection As String = String.Empty

    Private _strPistonShankSeal As String = String.Empty

    Private _dblRodDiameter As Double

    Private _strSelectedClass As String = String.Empty

    Private _strPistonNutSizeInFractions As String = String.Empty

    Private _dblPistonNutSizeInDecimals As Double

    Private _dblNutSafetyFactor As Double

    Private _dblEndConditionSafetyFactor As Double

    Private _dblRetractedLength As Double

    Private _dblStrokeLength As Double

    Private _strBaseEndConfigurationDesign As String = String.Empty
    Private _strBaseEndConfigurationDesign2 As String = String.Empty          '13_03_2012   RAGAVA
    Private _strBaseEndConfigurationDesignType As String = String.Empty
    Private _strBaseEndConfigurationDesignType2 As String = String.Empty      '13_03_2012   RAGAVA
    Private _dblPistonNutActualSize As Double

    '18_02_2010
    Private _strGeneratePath As String = String.Empty
    Public AssyGeneratePath As String = String.Empty     '14_07_2010   RAGAVA
    Private _strGeneratePath_Drawings As String = String.Empty  '03_03_2010   RAGAVA
    Private _strcodeNumber As String = String.Empty

    Public strTubeWeldmentDescription As String = String.Empty    '21_04_2011   RAGAVA
    Public strRodWeldmentDescription As String = String.Empty     '21_04_2011   RAGAVA


    '16_08_2010    RAGAVA
    Public OriginalCodeNumber As String = String.Empty
    Public ImportBaseEndPartPath As String = String.Empty
    Public ImportBaseEndPortPartPath As String = String.Empty
    Public ImportRodEndPortPartPath As String = String.Empty
    Public ImportRodEndPartPath As String = String.Empty
    'Till  Here



    Private _dblStopTubeLength As Double
    '24_02_2010 Aruna Start
    Private _blnRodEndFabricationSelected As Boolean
    Private _blnRodEndFabricationSelected2 As Boolean      '24_07_2012   RAGAVA
    Private _blnRodEndDesignSelected As Boolean
    Private _blnRodEndDesignSelected2 As Boolean    '24_07_2012   RAGAVA
    Private _blnBaseEndFabricationSelected As Boolean
    Private _blnBaseEndDesignSelected As Boolean
    Private _blnBaseEndFabricationSelected2 As Boolean        '14_03_2012   RAGAVA
    Private _blnBaseEndDesignSelected2 As Boolean             '14_03_2012   RAGAVA

    Private _strPurchaseCode As String = String.Empty
    Private _strManufactureCode As String = String.Empty
    Private _strBaseEndPartName As String = String.Empty
    Private _strBaseEndPartName2 As String = String.Empty         '13_03_2012   RAGAVA
    Private _strRodEndPartName As String = String.Empty
    Private _strRodEndPartName2 As String = String.Empty   '24_07_2012    RAGAVA
    Private _strBaseEnd_NewDesign_TableName As String = String.Empty
    Private _strBaseEnd_NewDesign_TableName2 As String = String.Empty    '13_03_2012  RAGAVA
    Private _strRodEnd_NewDesign_TableName As String = String.Empty
    Public htStoreConfigurationCodeNumbers As New Hashtable
    '24_02_2010 Aruna end
    '02_03_2010 Aruna Start
    Private _strPinHoleType_RodEnd As String = String.Empty
    'Aruna 18_3_2010
    Private _dblPullForce As Double
    Private _dblPullForce_RodEnd As Double

    '29_03_2010     RAGAVA
    Private _strGeneralNotes As String = String.Empty
    Private _strPaintPackagingNotes As String = String.Empty
    Private _strAssemblyNotes As String = String.Empty
    Private _iAssyNotesCount As Integer
    Private _iPaintingNotesCount As Integer
    '29_03_2010     RAGAVA  Till  Here

    Private _dbltempWorkingPressure As Double            '31_03_2010   RAGAVA

    'TODO: ANUP 05-07-2010 11.02am
    Private _dblTempMaxNutThickness As Double

    'A0308: ANUP 04-08-2010 03.26pm
    Private _strRodMaterial As String = String.Empty

#End Region

#Region "Piston Design"

    Private _strSelectedPistonSeal As String = String.Empty

    Private _dblPistonWidth As Double

    '25-02-10 1pm sandeep
    Private _strPistonWearRing As String = String.Empty

    '25-02-10 1pm sandeep
    Private _dblPI_MaxDistance_from_RodSide_to_SealGrooveEnd As Double

#End Region

#Region "Head Design"

    Private _strCylinderHeadDesign As String = String.Empty

    Private _dblShankLength As Double

    Private _dblCounterBoreDepth As Double

    Private _dblNoseLength As Double

    Public CylinderHeadCode As String = String.Empty       '07_10_2010   RAGAVA

    Public Breather As Double        '07_10_2010   RAGAVA

#End Region

#Region "Tube Details"

    Private _strDesignType As String = String.Empty
    Private _strDesignType2 As String = String.Empty        '13_03_2012   RAGAVA

    Private _strBaseEndConfiguration As String = String.Empty
    Private _strBaseEndConfiguration2 As String = String.Empty    '13_03_2012   RAGAVA

    Private _strBaseEndPort As String = String.Empty

    Public BaseEndPortCode As String = String.Empty          '18_10_2010   RAGAVA
    Public RodEndPortCode As String = String.Empty           '18_10_2010   RAGAVA

    Private _strPortInsertion As String = String.Empty

    Private _dblTubeOD As Double

    Private _dblTubeWallThickness As Double

    Private _dblPinHoleSize As Double

    Private _dblLugGap As Double

    Private _dblBushingQuantity As Double

    Private _dblSwingClearance As Double
    Private _dblSwingClearance2 As Double       '13_03_2012   RAGAVA

    Private _dblBushingWidth As Double

    Private _dblLugThickness As Double
    Private _dblLugThickness2 As Double         '13_03_2012   RAGAVA

    Private _dblGreaseZercs As Double

    Private _dblGreaseZercAngle1 As Double

    Private _dblGreaseZercAngle2 As Double

    Private _strTubeMaterial As String = String.Empty

    Private _dblLugWidth As Double
    Private _dblLugWidth2 As Double            '13_03_2012   RAGAVA

    Private _strPinWithInTubeDiameter As String = String.Empty

    Private _dblAreaRequired As Double

    Private _dblYRequired As Double

    Private _dblOutSidePlugDiameter As Double

    Private _dblMilledFlatWidth As Double

    Private _dblCrossTubeWidth As Double
    Private _dblCrossTubeWidth2 As Double        '13_03_2012   RAGAVA

    Private _dblOffSet As Double

    'Added by Sandeep on 04-01-10
    Private _strPistonLocation As String = String.Empty

    Private _strWeldType As String = String.Empty

    Private _dblThreadDiameter As Double

    Private _dblThreadLength As Double
    Private _strPinHoleType As String = String.Empty
    Private _strSearchFound As String = String.Empty

    Private _dblToleranceUpperLimit As Double
    Private _dblToleranceLowerLimit As Double

    Private _dblSafetyFactor_BaseEnd As Double
    Private _dblSafetyFactor_BaseEnd2 As Double
    Private _dblSafetyFactor_RodEnd As Double
    Private _dblSafetyFactor_RodEnd2 As Double '24_07_2012   RAGAVA

    Private _strMilledFlat As String = String.Empty

    'TODO: ANUP 02-04-2010 01.19
    Private _dblRodLength As Double
    '***************

    'TODO: ANUP 20-04-2010 11.24am
    Private _dblBushingOD_BaseEnd As Double

    Private _strPinsYesOrNo As String = String.Empty

    '24_08_2010    RAGAVA
    Public strTubeWeldmentVolume As String = String.Empty
    Public strRodWeldmentVolume As String = String.Empty
    Public strWeldCylinderVolume As String = String.Empty
    '01_10_2010  RAGAVA
    Public strTubeWeldmentWeight As Double
    Public strRodWeldmentWeight As Double
    Public strWeldCylinderWeight As Double
    Public TubeWorkCenterList As New ArrayList
    Public RodWorkCenterList As New ArrayList
    Public TubeRuleId As Double = 0
    Public RodRuleId As Double = 0
    'Till   Here

    'ANUP 20-09-2010 START
    Private _strISBushingStyle_2BushingsIndividualBore As String = String.Empty
    Private _strISBushingStyle_2BushingsIndividualBore_RodEnd As String = String.Empty
    'ANUP 20-09-2010 TILL HERE

    'ANUP 27-09-2010 START 
    Private _dblDimension8 As Double
    Private _dblRulesID_Rod As Double
    'ANUP 27-09-2010 TILL HERE

#End Region

#Region "Port Details"
    Private _strPortType_RodEnd As String = String.Empty
    Private _strPortType_BaseEnd As String = String.Empty
    Private _dblPortFirstOrientation As Double
    Private _dblPortSecondOrientation As Double
    Private _intPortQuantity As Integer
    Private _dblOrificeSize_RodEnd As Double
    Private _dblOrificeSize_BaseEnd As Double

    Private _strPortSize_BaseEnd As String = String.Empty
    Private _strPortSize_RodEnd As String = String.Empty

    ' ANUP 10-03-2010 02.05
    Private _dblNoOfPorts As Double
    '******************


    'A0308: ANUP 03-08-2010 02.28pm
    Private _dblNoOfPorts_RodEnd As Double
    Private _dblPortAccessoryType_baseEnd As Double
    Private _dblPortAccessoryType_RodEnd As Double
    Private _dblFirstPortOrientation_BaseEnd As Double
    Private _dblSecondPortOrientation_BaseEnd As Double
    Private _dblFirstPortOrientation_RodEnd As Double
    Private _dblSecondPortOrientation_RodEnd As Double
    Private _dblStandardRunQuantity As Double
    '*************

#End Region

#Region "DLPortInTubeDetails"

    Private _oMatchedBEDLCastingDataTable As DataTable

    Private _strPartCodeFromUlugCode As String = String.Empty

    'TODO: ANUP 01-06-2010 04.45pm
    Private _dblBendRadius_BaseEnd As Double

#End Region

#Region "BasePlugDetails"
    Private _dblBPBushingWidth As Double
    'Private _dblBPOD As Double
    Private _dblBPODPortIntegral As Double
    Private _dblOutSidePlugDiameterRequiredPortIntegral As Double
    'Aruna 11_11_2009
    Private _blnMilledFlatWidthSelected As Boolean

    Private _oMatchedBEBPCastingDataTable As DataTable          '01_12_2009   RAGAVA

    Private _dblMilledFlatHeight As Double          '04_12_2009  RAGAVA

    Public BasePlugPinHoleSize As Double            '04_12_2009   RAGAVA
#End Region

#Region "BE ThreadedEnd"

    Private _oMatchedBEThreadedEndCastingDataTable As DataTable

#End Region

#Region "SLPortInTubeDetails"
    Public dblWeldsize_SL_BaseEnd As Double = 0     '20_01_2012    RAGAVA
    Private _oMatchedBESLCastingDataTable As DataTable
    Private _oMatchedBHCastingDataTable As DataTable
    '11_02_2010-ARUNA START
    Private _dblEndofTubetoRodStop As Double
    Private _dblEndofTubetoRodStop2 As Double     '06_06_2012   RAGAVA
    Private _strBaseEndCodeNumber90 As String = String.Empty   '25_05_2010   RAGAVA  CollarDetails
    Private _strBaseEndCodeNumber As String = String.Empty           '03_06_2010    RAGAVA
    Private _dblBaseEndDistanceFromPinholetoRodStop As Double
    Private _dblBaseEndDistanceFromPinholetoRodStop2 As Double         '15_05_2012  RAGAVA
    '11_02_2010-ARUNA END
#End Region

#Region "BECrossTubePortInTubeDetails"

    Private _oMatchedBECrossTubeCastingDataTable As DataTable

    Private _dblCrossTubeOD As Double
    Private _dblCrossTubeOD2 As Double      '13_03_2012   RAGAVA

#End Region

#Region "RodEnd Configuration"

    Private _strRodEndConfiguration As String = String.Empty

    Private _dblLugThickness_RodEnd As Double

    Private _dblLugGap_RodEnd As Double

    Private _dblSwingClearance_RodEnd As Double
    Private _dblSwingClearance_RodEnd2 As Double    '24_07_2012    RAGAVA

    Private _strPins_RodEnd As String = String.Empty

    Private _strClips_RodEnd As String = String.Empty
    Private _dblCrossTubeWidth_RodEnd As Double
    Private _dblCrossTubeWidth_RodEnd2 As Double '24_07_2012   RAGAVA

    Private _dblBushingQuantity_RodEnd As Double

    Private _dblBushingPinHoleSize_RodEnd As Double

    Private _dblBushingWidth_RodEnd As Double

    Private _dblPinHoleSize_RodEnd As Double

    Private _dblGreaseZercs_RodEnd As Double

    Private _strBushingType_RodEnd As String = String.Empty

    Private _dblGreaseZercAngle1_RodEnd As Double

    Private _dblGreaseZercAngle2_RodEnd As Double

    Private _dblCost_RodEnd As Double '---anup 29\01\10-------

    Private _dblCrossTubeOD_RodEnd As Double

    Private _dblCrossTubeOD_RodEnd2 As Double             '24_07_2012    RAGAVA

    Private _dblLugWidth_RodEnd As Double
    Private _dblLugWidth_RodEnd2 As Double       '24_07_2012    RAGAVA

    Private _dblAreaRequired_RodEnd As Double

    Private _dblYRequired_RodEnd As Double

    Private _dblToleranceUpperLimit_RodEnd As Double

    Private _dblToleranceLowerLimit_RodEnd As Double

    Private _strPinHoleSizeType As String = String.Empty

    Private _strPinHoleTypeThreaded_RE_DL As String = String.Empty

    Private _strConnectionType As String = String.Empty

    Private _dblREDistanceFromPinholetoRodStop As Double
    Private _dblREDistanceFromPinholetoRodStop2 As Double          '24_07_2012    RAGAVA

    Private _dblOffSet_RodEnd As Double

    Private _strConfigurationDesign_RodEnd As String = String.Empty
    Private _strConfigurationDesign_RodEnd2 As String = String.Empty   '24_07_2012   RAGAVA

    Private _strConfigurationDesignType_RodEnd As String = String.Empty
    Private _strConfigurationDesignType_RodEnd2 As String = String.Empty     '24_07_2012   RAGAVA

    Private _strConfigurationCode_RodEnd As String = String.Empty
    Private _strConfigurationCode_RodEnd2 As String = String.Empty   '24_07_2012   RAGAVA

    Public strSetScrew As String = String.Empty            '24_06_2010    RAGAVA

    Private _strRodEndConfigurationDesign As String = String.Empty            '18_02_2010    RAGAVA
    '02_03_2010 Aruna
    Private _dblLugHeight_RodEnd As Double
    Private _dblLugHeight_BaseEnd As Double

    Private _strMilledFlat_RE As String = String.Empty

    'TODO: ANUP 20-04-2010 02.52pm
    Private _strBushingPartCode_RodEnd As String = String.Empty
    Private _dblBushingOD_RodEnd As Double

    Private _strRodEndCollarCodeNumber As String = String.Empty     '25_05_2010   RAGAVA  CollarDetails
    Private _dblOriginalTubeLength As Double     '25_05_2010   RAGAVA  CollarDetails

    Public strSheetNumber_Tube As String = String.Empty      '23_09_2010    RAGAVA
    Public strSheetNumber_Rod As String = String.Empty      '23_09_2010    RAGAVA
    Public PortOD As Double = 0         '23_09_2010   RAGAVA
    Public PortLocatorCode_Tube As String = String.Empty      '23_09_2010   RAGAVA
    Public PortLocatorCode_Rod As String = String.Empty      '23_09_2010   RAGAVA
    Public WPDS_PortCode_Tube As String = String.Empty      '23_09_2010   RAGAVA
    Public WPDS_PortCode_Rod As String = String.Empty      '23_09_2010   RAGAVA
    Public Skived_Honed_Tube As String = String.Empty     '23_09_2010   RAGAVA
    Public Skived_Honed_Rod As String = String.Empty     '23_09_2010   RAGAVA

    'anup 10-02-2011 start
    Public _blnIsFocusedInRevision As Boolean = False
    'anup 10-02-2011 till here

#End Region

#Region "RE FlatWithChamfer"

    Private _dblChamferAngle_RodEnd As Double

    Private _dblChamferSize_RodEnd As Double

#End Region

#Region "RE Threaded Rod"
    Private _strThreadType_RodEnd As String = String.Empty

    Private _dblThreadSize_RodEnd As Double

    Private _dblThreadLength_RodEnd As Double

    Private _dblAcrossFlatValue_RodEnd As Double

    Private _dblFlatLength_RodEnd As Double

#End Region

#Region "RetractedLength Calculation"

    Private _dblOverAllCylinderLength As Double

    'ANUP 25-02-10 12pm
    Private _dblExtraRodButtonLength As Double

    Private _strExtraRodButton As String = String.Empty

    Private _strPortEndDistanceFromTubeEnd As String = String.Empty
    Private _dblCylinderThreadedHeadChamferLength As Double '25_02_2010 Aruna
    Private _blnIsCompressedSelected As Boolean
    '#############

    'TODO: ANUP 27-02-10 11pm
    Private _dblStickOut As Double
    Private _dblOffsetPortOrifice As Double
    Private _dblSkimWidth As Double
    '#############

    'TODO: ANUP 06-04-2010 02.12
    Private _blnISFabricationChecked As Boolean
    '*********

    'TODO: ANUP 06-04-2010 04.45
    Private _blnIsCounterBoreChecked As Boolean

    'TODO:  ANUP 22-04-2010 11.53am
    Private _blnSkipRetractedIfPositiveFromGenerate As Boolean

    'TODO:  ANUP 24-05-2010 10.36am
    Private _blnGoToBaseEndScreenFromRetractedScreen As Boolean
    Private _blnGoToRodEndScreenFromRetractedScreen As Boolean
    '********************

#End Region

#Region "RECrossTubeCastingDetails"
    Private _oMatchedRECrossTubeCastingDataTable As DataTable
#End Region

#Region "REDoubleLug"

    Private _dblWeldSize_REDL As Double

    Private _dblWeldSize_RECT As Double          '06_03_2010   RAGAVA

    Private _oMatchedREDlCastingDataTable As DataTable

    Private _oMatchedREDLThreadedDataTable As DataTable

    'TODO: ANUP 01-06-010 04.30pm
    Private _dblBendRadius_RodEnd As Double

    Private _strPilotHoleDiameter As String = String.Empty 'ANUP 07-07-2010

#End Region

#Region "Code Details"

    Private _strClevisPlateCode As String = String.Empty
    Private _strClevisPlateCode2 As String = String.Empty      '13_03_2012  RAGAVA

    Private _strConfigurationCode_BaseEnd As String = String.Empty
    Private _strConfigurationCode_BaseEnd2 As String = String.Empty      '13_03_2012  RAGAVA

    'ToDo:Anup 06-04-10 5pm
    Private _strCounterBoreClevisPlateCode As String = String.Empty

    Private _dblCounterBoreClevisPlateThickness As Double

    Private _dblCounterboredClevisPlateRodStopDistance As Double

#End Region

#Region "Clevis Plate Thickness"

    Private _dblClevisPlateThickness As Double
    Private _dblClevisPlateThickness2 As Double      '13_03_2012   RAGAVA

    '30_3_2010 ARuna
    Private _dblClevisPlateRodStopDistance As Double
    Private _strClevisplatePartFilePath As String = String.Empty

    'TODO: ANUP 23-04-2010 12.32pm
    Private _strClevisPlateImportOrExisting As String = String.Empty
    Private _strClevisPlateImportOrExisting2 As String = String.Empty
    '*****************

#End Region

    'Aruna 19_3_2010
#Region "Folder Deletion"
    Private _htFolderDeletion As New Hashtable
#End Region

    'TODO: ANUP 28-04-2010 01.03pm
#Region "Weld Variables for Casting/Fabrication"

    Private _dblWeldSize_RodEnd As Double
    Private _strWeldPreperation_RodEnd As String
    Private _dblJGrooveWidth_RodEnd As Double
    Private _dblJGrooveRadius_RodEnd As Double
#End Region

    ': ANUP 27-05-2010 01.51pm
#Region "Contract Details and Monarch Revision Variables"
    Private _strCustomerName_ContractDetails As String
    Private _strAssemblyType_ContractDetails As String
    Private _strPartCode_ContractDetails As String
    Private _strNew_Revision As String
    Private _blnCustomerNameComboBOxChanged As Boolean
#End Region

#End Region

#Region "Public Properties"
    Public blnInstallPinsandClips As Boolean = True                '06_06_2011   RAGAVA
    Public blnInstallPinsandClips_Checked As Boolean = False       '06_06_2011   RAGAVA
    Public strBaseEndKitCode As String = String.Empty              '06_06_2011   RAGAVA
    Public strRodEndKitCode As String = String.Empty               '06_06_2011   RAGAVA

    Public _intContractRevisionNumber As Integer = 0     '29_06_2010   RAGAVA
    Public intContractRevisionNumber As Integer     '30_06_2010   RAGAVA
    Private _strRevisionContractNo As String
    Public strNewPartCodeNumber_BeforeContractStart As String = ""       '11_10_2010   RAGAVA
    Public strRephasingType As String = ""               '20_12_2010   RAGAVA

    Public blnBasePlugTwoPorts As Boolean = False                '15_11_2011   RAGAVA
    Public blnBasePlugTwoPorts_RodEnd As Boolean = False         '15_11_2011   RAGAVA


    Public strBaseEndCastingTableName As String = String.Empty             '07_02_2011     RAGAVA
    Public strBaseEndCastingCodeNumber As String = String.Empty             '07_02_2011     RAGAVA
    Public strRodEndCastingTableName As String = String.Empty             '07_02_2011     RAGAVA
    Public strRodEndCastingCodeNumber As String = String.Empty             '07_02_2011     RAGAVA
    Public strRodEndCastingCodeNumber2 As String = String.Empty             '24_07_2012     RAGAVA

    Public Property RevisionContractNo() As String
        Get
            Return _strRevisionContractNo
        End Get
        Set(ByVal value As String)
            _strRevisionContractNo = value
        End Set
    End Property

    Private _htWeldedCompleteCylinderWCDetails As Hashtable
    Public Property WeldedCompleteCylinderWCDetails() As Hashtable
        Get
            Return _htWeldedCompleteCylinderWCDetails
        End Get
        Set(ByVal value As Hashtable)
            _htWeldedCompleteCylinderWCDetails = value
        End Set
    End Property

    Private _htWeldedTubeWCDetails As Hashtable
    Public Property WeldedTubeWCDetails() As Hashtable
        Get
            Return _htWeldedTubeWCDetails
        End Get
        Set(ByVal value As Hashtable)
            _htWeldedTubeWCDetails = value
        End Set
    End Property

    Private _htWeldedRodWCDetails As Hashtable
    Public Property WeldedRodWCDetails() As Hashtable
        Get
            Return _htWeldedRodWCDetails
        End Get
        Set(ByVal value As Hashtable)
            _htWeldedRodWCDetails = value
        End Set
    End Property

    Private _htWeldedBELugWCDetails As Hashtable
    Public Property WeldedBELugWCDetails() As Hashtable
        Get
            Return _htWeldedBELugWCDetails
        End Get
        Set(ByVal value As Hashtable)
            _htWeldedBELugWCDetails = value
        End Set
    End Property

    Private _htWeldedRELugWCDetails As Hashtable
    Public Property WeldedRELugWCDetails() As Hashtable
        Get
            Return _htWeldedRELugWCDetails
        End Get
        Set(ByVal value As Hashtable)
            _htWeldedRELugWCDetails = value
        End Set
    End Property


#Region "Primary Inputs"

    Public Property TempWorkingPressure() As Double
        Get
            Return _dbltempWorkingPressure
        End Get
        Set(ByVal value As Double)
            _dbltempWorkingPressure = value
        End Set
    End Property

    '29_03_2010     RAGAVA
    Public Property strPaintPackagingNotes() As String
        Get
            Return _strPaintPackagingNotes
        End Get
        Set(ByVal value As String)
            _strPaintPackagingNotes = value
        End Set
    End Property
    '29_03_2010     RAGAVA
    Public Property strAssemblyNotes() As String
        Get
            Return _strAssemblyNotes
        End Get
        Set(ByVal value As String)
            _strAssemblyNotes = value
        End Set
    End Property
    '29_03_2010     RAGAVA
    Public Property GeneralNotes() As String
        Get
            Return _strGeneralNotes
        End Get
        Set(ByVal value As String)
            _strGeneralNotes = value
        End Set
    End Property
    '29_03_2010     RAGAVA
    Public Property iAssyNotesCount() As Integer
        Get
            Return _iAssyNotesCount
        End Get
        Set(ByVal value As Integer)
            _iAssyNotesCount = value
        End Set
    End Property
    '29_03_2010     RAGAVA
    Public Property iPaintingNotesCount() As Integer
        Get
            Return _iPaintingNotesCount
        End Get
        Set(ByVal value As Integer)
            _iPaintingNotesCount = value
        End Set
    End Property



    '18_02_2010
    Public Property GeneratePath() As String
        Get
            Return _strGeneratePath
        End Get
        Set(ByVal value As String)
            _strGeneratePath = value
        End Set
    End Property

    '03_03_2010  RAGAVA
    Public Property GeneratePath_Drawings() As String
        Get
            Return _strGeneratePath_Drawings
        End Get
        Set(ByVal value As String)
            _strGeneratePath_Drawings = value
        End Set
    End Property


    Public Property CodeNumber() As String
        Get
            Return _strcodeNumber
        End Get
        Set(ByVal value As String)
            _strcodeNumber = value
        End Set
    End Property

    '27_02_2010    RAGAVA
    Public Property DistanceFromPinholetoRodStop() As Double
        Get
            Return _dblDistanceFromPinholetoRodStop
        End Get
        Set(ByVal value As Double)
            _dblDistanceFromPinholetoRodStop = value
        End Set
    End Property

    Public Property BoreDiameter() As Double
        Get
            Return _dblBoreDiameter
        End Get
        Set(ByVal value As Double)
            _dblBoreDiameter = value
        End Set
    End Property

    Public Property WorkingPressure() As Double
        Get
            Return _dblWorkingPressure
        End Get
        Set(ByVal value As Double)
            _dblWorkingPressure = value
        End Set
    End Property

    Public Property ColumnLoadDeratePressure() As String
        Get
            Return _strColumnLoadDeratePressure
        End Get
        Set(ByVal value As String)
            _strColumnLoadDeratePressure = value
        End Set
    End Property

    Public Property PistonConnection() As String
        Get
            Return _strPistonConnection
        End Get
        Set(ByVal value As String)
            _strPistonConnection = value
        End Set
    End Property

    Public Property PistonShankSeal() As String
        Get
            Return _strPistonShankSeal
        End Get
        Set(ByVal value As String)
            _strPistonShankSeal = value
        End Set
    End Property

    Public Property RodDiameter() As Double
        Get
            Return _dblRodDiameter
        End Get
        Set(ByVal value As Double)
            _dblRodDiameter = value
        End Set
    End Property

    Public Property SelectedClass() As String
        Get
            Return _strSelectedClass
        End Get
        Set(ByVal value As String)
            _strSelectedClass = value
        End Set
    End Property

    Public Property PistonNutSizeInFractions() As String
        Get
            Return _strPistonNutSizeInFractions
        End Get
        Set(ByVal value As String)
            _strPistonNutSizeInFractions = value
        End Set
    End Property

    Public Property PistonNutSizeInDecimals() As Double
        Get
            Return _dblPistonNutSizeInDecimals
        End Get
        Set(ByVal value As Double)
            _dblPistonNutSizeInDecimals = value
        End Set
    End Property

    '11_02_2010-ARUNA START
    Public Property PistonNutActualSize() As Double
        Get
            Return _dblPistonNutActualSize
        End Get
        Set(ByVal value As Double)
            _dblPistonNutActualSize = value
        End Set
    End Property

    '11_02_2010-ARUNA END
    Public Property NutSafetyFactor() As Double
        Get
            Return _dblNutSafetyFactor
        End Get
        Set(ByVal value As Double)
            _dblNutSafetyFactor = value
        End Set
    End Property

    Public Property EndConditionSafetyFactor() As Double
        Get
            Return _dblEndConditionSafetyFactor
        End Get
        Set(ByVal value As Double)
            _dblEndConditionSafetyFactor = value
        End Set
    End Property

    Public Property RetractedLength() As Double
        Get
            Return _dblRetractedLength
        End Get
        Set(ByVal value As Double)
            _dblRetractedLength = value
        End Set
    End Property

    Public Property StrokeLength() As Double
        Get
            Return _dblStrokeLength
        End Get
        Set(ByVal value As Double)
            _dblStrokeLength = value
        End Set
    End Property

    Public Property EndofTubetoRodStop() As Double
        Get
            Return _dblEndofTubetoRodStop
        End Get
        Set(ByVal value As Double)
            _dblEndofTubetoRodStop = value
        End Set
    End Property
    '06_06_2012    RAGAVA
    Public Property EndofTubetoRodStop2() As Double
        Get
            Return _dblEndofTubetoRodStop2
        End Get
        Set(ByVal value As Double)
            _dblEndofTubetoRodStop2 = value
        End Set
    End Property

    Public Property BaseEndDistanceFromPinholetoRodStop() As Double
        Get
            Return _dblBaseEndDistanceFromPinholetoRodStop
        End Get
        Set(ByVal value As Double)
            _dblBaseEndDistanceFromPinholetoRodStop = value
        End Set
    End Property
    '15_05_2012  RAGAVA
    Public Property BaseEndDistanceFromPinholetoRodStop2() As Double
        Get
            Return _dblBaseEndDistanceFromPinholetoRodStop2
        End Get
        Set(ByVal value As Double)
            _dblBaseEndDistanceFromPinholetoRodStop2 = value
        End Set
    End Property


    Public Property BaseEndConfigurationDesign() As String
        Get
            Return _strBaseEndConfigurationDesign

        End Get
        Set(ByVal value As String)
            _strBaseEndConfigurationDesign = value
        End Set
    End Property

    '13_03_2012  RAGAVA
    Public Property BaseEndConfigurationDesign2() As String
        Get
            Return _strBaseEndConfigurationDesign2

        End Get
        Set(ByVal value As String)
            _strBaseEndConfigurationDesign2 = value
        End Set
    End Property

    Public Property SearchFound() As String
        Get
            Return _strSearchFound

        End Get
        Set(ByVal value As String)
            _strSearchFound = value
        End Set
    End Property

    Public Property BaseEndConfigurationDesignType() As String
        Get
            Return _strBaseEndConfigurationDesignType

        End Get
        Set(ByVal value As String)
            _strBaseEndConfigurationDesignType = value
        End Set
    End Property

    '13_03_2012   RAGAVA
    Public Property BaseEndConfigurationDesignType2() As String
        Get
            Return _strBaseEndConfigurationDesignType2

        End Get
        Set(ByVal value As String)
            _strBaseEndConfigurationDesignType2 = value
        End Set
    End Property

    '11_02_2010-ARUNA END
    Public Property StopTubeLength() As Double
        Get
            Return _dblStopTubeLength
        End Get
        Set(ByVal value As Double)
            _dblStopTubeLength = value
        End Set
    End Property
    '24_02_2010 Aruna Start
    Public Property RodEndFabricationSelected() As Boolean
        Get
            Return _blnRodEndFabricationSelected
        End Get
        Set(ByVal value As Boolean)
            _blnRodEndFabricationSelected = value
        End Set
    End Property

    '24_07_2012   RAGAVA
    Public Property RodEndFabricationSelected2() As Boolean
        Get
            Return _blnRodEndFabricationSelected2
        End Get
        Set(ByVal value As Boolean)
            _blnRodEndFabricationSelected2 = value
        End Set
    End Property

    Public Property RodEndDesignSelected() As Boolean
        Get
            Return _blnRodEndDesignSelected
        End Get
        Set(ByVal value As Boolean)
            _blnRodEndDesignSelected = value
        End Set
    End Property

    '24_07_2012   RAGAVA
    Public Property RodEndDesignSelected2() As Boolean
        Get
            Return _blnRodEndDesignSelected2
        End Get
        Set(ByVal value As Boolean)
            _blnRodEndDesignSelected2 = value
        End Set
    End Property

    Public Property BaseEndFabricationSelected() As Boolean
        Get
            Return _blnBaseEndFabricationSelected
        End Get
        Set(ByVal value As Boolean)
            _blnBaseEndFabricationSelected = value
        End Set
    End Property

    '14_03_2012  RAGAVA
    Public Property BaseEndFabricationSelected2() As Boolean
        Get
            Return _blnBaseEndFabricationSelected2
        End Get
        Set(ByVal value As Boolean)
            _blnBaseEndFabricationSelected2 = value
        End Set
    End Property

    Public Property BaseEndDesignSelected() As Boolean
        Get
            Return _blnBaseEndDesignSelected
        End Get
        Set(ByVal value As Boolean)
            _blnBaseEndDesignSelected = value
        End Set
    End Property

    '14_03_2012  RAGAVA
    Public Property BaseEndDesignSelected2() As Boolean
        Get
            Return _blnBaseEndDesignSelected2
        End Get
        Set(ByVal value As Boolean)
            _blnBaseEndDesignSelected2 = value
        End Set
    End Property

    Public Property PurchaseCode() As String
        Get
            Return _strPurchaseCode
        End Get
        Set(ByVal value As String)
            _strPurchaseCode = value
        End Set
    End Property

    Public Property ManufactureCode() As String
        Get
            Return _strManufactureCode
        End Get
        Set(ByVal value As String)
            _strManufactureCode = value
        End Set
    End Property

    Public Property BaseEndPartName() As String
        Get
            Return _strBaseEndPartName
        End Get
        Set(ByVal value As String)
            _strBaseEndPartName = value
        End Set
    End Property

    '13_03_2012   RAGAVA
    Public Property BaseEndPartName2() As String
        Get
            Return _strBaseEndPartName2
        End Get
        Set(ByVal value As String)
            _strBaseEndPartName2 = value
        End Set
    End Property

    Public Property RodEndPartName() As String
        Get
            Return _strRodEndPartName
        End Get
        Set(ByVal value As String)
            _strRodEndPartName = value
        End Set
    End Property

    '24_07_2012    RAGAVA
    Public Property RodEndPartName2() As String
        Get
            Return _strRodEndPartName2
        End Get
        Set(ByVal value As String)
            _strRodEndPartName2 = value
        End Set
    End Property

    Public Property BaseEnd_NewDesign_TableName() As String
        Get
            Return _strBaseEnd_NewDesign_TableName
        End Get
        Set(ByVal value As String)
            _strBaseEnd_NewDesign_TableName = value
        End Set
    End Property

    '13_03_2012   RAGAVA
    Public Property BaseEnd_NewDesign_TableName2() As String
        Get
            Return _strBaseEnd_NewDesign_TableName2
        End Get
        Set(ByVal value As String)
            _strBaseEnd_NewDesign_TableName2 = value
        End Set
    End Property

    Public Property RodEnd_NewDesign_TableName() As String
        Get
            Return _strRodEnd_NewDesign_TableName
        End Get
        Set(ByVal value As String)
            _strRodEnd_NewDesign_TableName = value
        End Set
    End Property
    '24_02_2010 Aruna Ends--

    'TODO: ANUP 05-07-2010 11.02am
    Public Property PistonNutThickness() As Double
        Get
            Return _dblTempMaxNutThickness
        End Get
        Set(ByVal value As Double)
            _dblTempMaxNutThickness = value
        End Set
    End Property

    'A0308: ANUP 04-08-2010 03.26pm
    Public Property RodMaterial() As String
        Get
            Return _strRodMaterial
        End Get
        Set(ByVal value As String)
            _strRodMaterial = value
        End Set
    End Property

#End Region

#Region "Piston Design"

    Public Property SelectedPistonSeal() As String
        Get
            Return _strSelectedPistonSeal
        End Get
        Set(ByVal value As String)
            _strSelectedPistonSeal = value
        End Set
    End Property

    Public Property PistonWidth() As Double
        Get
            Return _dblPistonWidth
        End Get
        Set(ByVal value As Double)
            _dblPistonWidth = value
        End Set
    End Property

    '25-02-10 1pm sandeep
    Public Property PistonWearRing() As String
        Get
            Return _strPistonWearRing
        End Get
        Set(ByVal value As String)
            _strPistonWearRing = value
        End Set
    End Property

    '25-02-10 1pm sandeep
    Public Property PI_MaxDistance_from_RodSide_to_SealGrooveEnd() As Double
        Get
            Return _dblPI_MaxDistance_from_RodSide_to_SealGrooveEnd
        End Get
        Set(ByVal value As Double)
            _dblPI_MaxDistance_from_RodSide_to_SealGrooveEnd = value
        End Set
    End Property

#End Region

#Region "Head Design"

    Public Property CylinderHeadDesign() As String
        Get
            Return _strCylinderHeadDesign
        End Get
        Set(ByVal value As String)
            _strCylinderHeadDesign = value
        End Set
    End Property

    Public Property ShankLength() As Double
        Get
            Return _dblShankLength
        End Get
        Set(ByVal value As Double)
            _dblShankLength = value
        End Set
    End Property

    Public Property CounterBoreDepth() As Double
        Get
            Return _dblCounterBoreDepth
        End Get
        Set(ByVal value As Double)
            _dblCounterBoreDepth = value
        End Set
    End Property

    Public Property NoseLength() As Double
        Get
            Return _dblNoseLength
        End Get
        Set(ByVal value As Double)
            _dblNoseLength = value
        End Set
    End Property
    '25_02_2010 Aruna
    Public Property CylinderThreadedHeadChamferLength() As Double
        Get
            Return _dblCylinderThreadedHeadChamferLength
        End Get
        Set(ByVal value As Double)
            _dblCylinderThreadedHeadChamferLength = value
        End Set
    End Property
    Property IsCompressedSelected() As Boolean
        Get
            Return _blnIsCompressedSelected
        End Get
        Set(ByVal value As Boolean)
            _blnIsCompressedSelected = value
        End Set
    End Property
#End Region

#Region "Tube Details"

    '25_05_2010  RAGAVA   CollarDetails
    Public Property BaseEndCodeNumber90() As String
        Get
            Return _strBaseEndCodeNumber90
        End Get
        Set(ByVal value As String)
            _strBaseEndCodeNumber90 = value
        End Set
    End Property


    '03_06_2010  RAGAVA   CollarDetails
    Public Property BaseEndCodeNumber() As String
        Get
            Return _strBaseEndCodeNumber
        End Get
        Set(ByVal value As String)
            _strBaseEndCodeNumber = value
        End Set
    End Property

    '25_05_2010   RAGAVA  CollarDetails
    Public Property CollarCodeNumber() As String
        Get
            Return _strRodEndCollarCodeNumber
        End Get
        Set(ByVal value As String)
            _strRodEndCollarCodeNumber = value
        End Set
    End Property

    '25_05_2010   RAGAVA  CollarDetails
    Public Property OriginalTubeLength() As Double
        Get
            Return _dblOriginalTubeLength
        End Get
        Set(ByVal value As Double)
            _dblOriginalTubeLength = value
        End Set
    End Property

    Public Property DesignType() As String
        Get
            Return _strDesignType
        End Get
        Set(ByVal value As String)
            _strDesignType = value
        End Set
    End Property

    '13_03_2012   RAGAVA
    Public Property DesignType2() As String
        Get
            Return _strDesignType2
        End Get
        Set(ByVal value As String)
            _strDesignType2 = value
        End Set
    End Property

    Public Property BaseEndConfiguration() As String
        Get
            Return _strBaseEndConfiguration
        End Get
        Set(ByVal value As String)
            _strBaseEndConfiguration = value
        End Set
    End Property

    Public Property BaseEndPort() As String
        Get
            Return _strBaseEndPort
        End Get
        Set(ByVal value As String)
            _strBaseEndPort = value
        End Set
    End Property

    Public Property PortInsertion() As String
        Get
            Return _strPortInsertion
        End Get
        Set(ByVal value As String)
            _strPortInsertion = value
        End Set
    End Property

    Public Property TubeOD() As Double
        Get
            Return _dblTubeOD
        End Get
        Set(ByVal value As Double)
            _dblTubeOD = value
        End Set
    End Property

    Public Property TubeWallThickness() As Double
        Get
            Return _dblTubeWallThickness
        End Get
        Set(ByVal value As Double)
            _dblTubeWallThickness = value
        End Set
    End Property

    Public Property PinHoleSize() As Double
        Get
            Return _dblPinHoleSize
        End Get
        Set(ByVal value As Double)
            _dblPinHoleSize = value
        End Set
    End Property

    Public Property LugGap() As Double
        Get
            Return _dblLugGap
        End Get
        Set(ByVal value As Double)
            _dblLugGap = value
        End Set
    End Property

    Public Property BushingQuantity() As Double
        Get
            Return _dblBushingQuantity
        End Get
        Set(ByVal value As Double)
            _dblBushingQuantity = value
        End Set
    End Property

    Public Property SwingClearance() As Double
        Get
            Return _dblSwingClearance
        End Get
        Set(ByVal value As Double)
            _dblSwingClearance = value
        End Set
    End Property

    '13_03_2012  RAGAVA
    Public Property SwingClearance2() As Double
        Get
            Return _dblSwingClearance2
        End Get
        Set(ByVal value As Double)
            _dblSwingClearance2 = value
        End Set
    End Property


    Public Property BushingWidth() As Double
        Get
            Return _dblBushingWidth
        End Get
        Set(ByVal value As Double)
            _dblBushingWidth = value
        End Set
    End Property

    Public Property LugThickness() As Double
        Get
            Return _dblLugThickness
        End Get
        Set(ByVal value As Double)
            _dblLugThickness = value
        End Set
    End Property

    '13_03_2012  RAGAVA
    Public Property LugThickness2() As Double
        Get
            Return _dblLugThickness2
        End Get
        Set(ByVal value As Double)
            _dblLugThickness2 = value
        End Set
    End Property

    Public Property GreaseZercs() As Double
        Get
            Return _dblGreaseZercs
        End Get
        Set(ByVal value As Double)
            _dblGreaseZercs = value
        End Set
    End Property

    Public Property GreaseZercAngle1() As Double
        Get
            Return _dblGreaseZercAngle1
        End Get
        Set(ByVal value As Double)
            _dblGreaseZercAngle1 = value
        End Set
    End Property

    Public Property GreaseZercAngle2() As Double
        Get
            Return _dblGreaseZercAngle2
        End Get
        Set(ByVal value As Double)
            _dblGreaseZercAngle2 = value
        End Set
    End Property

    Public Property TubeMaterial() As String
        Get
            Return _strTubeMaterial
        End Get
        Set(ByVal value As String)
            _strTubeMaterial = value
        End Set
    End Property

    Public Property LugWidth() As Double
        Get
            Return _dblLugWidth
        End Get
        Set(ByVal value As Double)
            _dblLugWidth = value
        End Set
    End Property


    '13_03_2012  RAGAVA
    Public Property LugWidth2() As Double
        Get
            Return _dblLugWidth2
        End Get
        Set(ByVal value As Double)
            _dblLugWidth2 = value
        End Set
    End Property

    Public Property PinWithInTubeDiameter() As String
        Get
            Return _strPinWithInTubeDiameter
        End Get
        Set(ByVal value As String)
            _strPinWithInTubeDiameter = value
        End Set
    End Property

    Public Property AreaRequired() As Double
        Get
            Return _dblAreaRequired
        End Get
        Set(ByVal value As Double)
            _dblAreaRequired = value
        End Set
    End Property

    Public Property YRequired() As Double
        Get
            Return _dblYRequired
        End Get
        Set(ByVal value As Double)
            _dblYRequired = value
        End Set
    End Property

    Public Property OutSidePlugDiameter() As Double
        Get
            Return _dblOutSidePlugDiameter
        End Get
        Set(ByVal value As Double)
            _dblOutSidePlugDiameter = value
        End Set
    End Property

    Public Property MilledFlatWidth() As Double
        Get
            Return _dblMilledFlatWidth
        End Get
        Set(ByVal value As Double)
            _dblMilledFlatWidth = value
        End Set
    End Property

    Public Property MilledFlatHeight() As Double
        Get
            Return _dblMilledFlatHeight
        End Get
        Set(ByVal value As Double)
            _dblMilledFlatHeight = value
        End Set
    End Property

    Public Property CrossTubeWidth() As Double
        Get
            Return _dblCrossTubeWidth
        End Get
        Set(ByVal value As Double)
            _dblCrossTubeWidth = value
        End Set
    End Property

    '13_03_2012  RAGAVA
    Public Property CrossTubeWidth2() As Double
        Get
            Return _dblCrossTubeWidth2
        End Get
        Set(ByVal value As Double)
            _dblCrossTubeWidth2 = value
        End Set
    End Property

    Public Property OffSet() As Double
        Get
            Return _dblOffSet
        End Get
        Set(ByVal value As Double)
            _dblOffSet = value
        End Set
    End Property

    Public Property PistonLocation() As String
        Get
            Return UCase(_strPistonLocation)
        End Get
        Set(ByVal value As String)
            _strPistonLocation = value
        End Set
    End Property

    Public Property WeldType() As String
        Get
            Return UCase(_strWeldType)
        End Get
        Set(ByVal value As String)
            _strWeldType = value
        End Set
    End Property

    Public Property ThreadDiameter() As Double
        Get
            Return _dblThreadDiameter
        End Get
        Set(ByVal value As Double)
            _dblThreadDiameter = value
        End Set
    End Property

    Public Property ThreadLength() As Double
        Get
            Return _dblThreadLength
        End Get
        Set(ByVal value As Double)
            _dblThreadLength = value
        End Set
    End Property

    Public Property PinHoleType() As String
        Get
            Return _strPinHoleType
        End Get
        Set(ByVal value As String)
            _strPinHoleType = value
        End Set
    End Property

    Public Property ToleranceUpperLimit() As Double
        Get
            Return _dblToleranceUpperLimit
        End Get
        Set(ByVal value As Double)
            _dblToleranceUpperLimit = value
        End Set
    End Property

    Public Property ToleranceLowerLimit() As Double
        Get
            Return _dblToleranceLowerLimit
        End Get
        Set(ByVal value As Double)
            _dblToleranceLowerLimit = value
        End Set
    End Property

    Public Property SafetyFactor_BaseEnd() As Double
        Get
            Return _dblSafetyFactor_BaseEnd
        End Get
        Set(ByVal value As Double)
            _dblSafetyFactor_BaseEnd = value
        End Set
    End Property
    '15_05_2012  RAGAVA
    Public Property SafetyFactor_BaseEnd2() As Double
        Get
            Return _dblSafetyFactor_BaseEnd2
        End Get
        Set(ByVal value As Double)
            _dblSafetyFactor_BaseEnd2 = value
        End Set
    End Property

    Public Property SafetyFactor_RodEnd() As Double
        Get
            Return _dblSafetyFactor_RodEnd
        End Get
        Set(ByVal value As Double)
            _dblSafetyFactor_RodEnd = value
        End Set
    End Property
    '24_07_2012   RAGAVA
    Public Property SafetyFactor_RodEnd2() As Double
        Get
            Return _dblSafetyFactor_RodEnd2
        End Get
        Set(ByVal value As Double)
            _dblSafetyFactor_RodEnd2 = value
        End Set
    End Property

    Public Property MilledFlat() As String
        Get
            Return _strMilledFlat
        End Get
        Set(ByVal value As String)
            _strMilledFlat = value
        End Set
    End Property
    'TODO: ANUP 02-04-2010 01.19

    Public Property RodLength() As Double
        Get
            Return _dblRodLength
        End Get
        Set(ByVal value As Double)
            _dblRodLength = value
        End Set
    End Property

    '***************

    'TODO: ANUP 20-04-2010 11.24am
    Public Property BushingOD_BaseEnd() As Double
        Get
            Return _dblBushingOD_BaseEnd
        End Get
        Set(ByVal value As Double)
            _dblBushingOD_BaseEnd = value
        End Set
    End Property

    Public Property PinsYesOrNo() As String
        Get
            Return _strPinsYesOrNo
        End Get
        Set(ByVal value As String)
            _strPinsYesOrNo = value
        End Set
    End Property

    'ANUP 20-09-2010 START
    Public Property ISBushingStyle_2BushingsIndividualBore() As String
        Get
            Return _strISBushingStyle_2BushingsIndividualBore
        End Get
        Set(ByVal value As String)
            _strISBushingStyle_2BushingsIndividualBore = value
        End Set
    End Property
    Public Property ISBushingStyle_2BushingsIndividualBore_RodEnd() As String
        Get
            Return _strISBushingStyle_2BushingsIndividualBore_RodEnd
        End Get
        Set(ByVal value As String)
            _strISBushingStyle_2BushingsIndividualBore_RodEnd = value
        End Set
    End Property
    'ANUP 20-09-2010 TILL HERE

    'ANUP 27-09-2010 START 
    Public Property Dimension8() As Double
        Get
            Return _dblDimension8
        End Get
        Set(ByVal value As Double)
            _dblDimension8 = value
        End Set
    End Property

    Public Property RulesID_Rod() As Double
        Get
            Return _dblRulesID_Rod
        End Get
        Set(ByVal value As Double)
            _dblRulesID_Rod = value
        End Set
    End Property
    'ANUP 27-09-2010 TILL HERE

#End Region

#Region "Port Details"
    Public Property PortType_RodEnd() As String
        Get
            Return _strPortType_RodEnd
        End Get
        Set(ByVal value As String)
            _strPortType_RodEnd = value
        End Set
    End Property

    Public Property PortType_BaseEnd() As String
        Get
            Return _strPortType_BaseEnd
        End Get
        Set(ByVal value As String)
            _strPortType_BaseEnd = value
        End Set
    End Property

    Public Property PortFirstOrientation() As Double
        Get
            Return _dblPortFirstOrientation
        End Get
        Set(ByVal value As Double)
            _dblPortFirstOrientation = value
        End Set
    End Property

    Public Property PortSecondOrientation() As Double
        Get
            Return _dblPortSecondOrientation
        End Get
        Set(ByVal value As Double)
            _dblPortSecondOrientation = value
        End Set
    End Property

    Public Property PortSize_BaseEnd() As String
        Get
            Return _strPortSize_BaseEnd
        End Get
        Set(ByVal value As String)
            _strPortSize_BaseEnd = value
        End Set
    End Property

    Public Property PortSize_RodEnd() As String
        Get
            Return _strPortSize_RodEnd
        End Get
        Set(ByVal value As String)
            _strPortSize_RodEnd = value
        End Set
    End Property

    Public Property PortQuantity() As Integer
        Get
            Return _intPortQuantity
        End Get
        Set(ByVal value As Integer)
            _intPortQuantity = value
        End Set
    End Property

    Public Property OrificeSize_RodEnd() As Double
        Get
            Return _dblOrificeSize_RodEnd
        End Get
        Set(ByVal value As Double)
            _dblOrificeSize_RodEnd = value
        End Set
    End Property

    Public Property OrificeSize_BaseEnd() As Double
        Get
            Return _dblOrificeSize_BaseEnd
        End Get
        Set(ByVal value As Double)
            _dblOrificeSize_BaseEnd = value
        End Set
    End Property

    ' ANUP 10-03-2010 02.05
    Public Property NoOfPorts_BaseEnd() As Double
        Get
            Return _dblNoOfPorts
        End Get
        Set(ByVal value As Double)
            _dblNoOfPorts = value
        End Set
    End Property
    '***********************

    'A0308: ANUP 03-08-2010 02.28pm
    Public Property NoOfPorts_RodEnd() As Double
        Get
            Return _dblNoOfPorts_RodEnd
        End Get
        Set(ByVal value As Double)
            _dblNoOfPorts_RodEnd = value
        End Set
    End Property

    Public Property PortAccessoryType_BaseEnd() As Double
        Get
            Return _dblPortAccessoryType_baseEnd
        End Get
        Set(ByVal value As Double)
            _dblPortAccessoryType_baseEnd = value
        End Set
    End Property

    Public Property PortAccessoryType_RodEnd() As Double
        Get
            Return _dblPortAccessoryType_RodEnd
        End Get
        Set(ByVal value As Double)
            _dblPortAccessoryType_RodEnd = value
        End Set
    End Property

    Public Property FirstPortOrientation_BaseEnd() As Double
        Get
            Return _dblFirstPortOrientation_BaseEnd
        End Get
        Set(ByVal value As Double)
            _dblFirstPortOrientation_BaseEnd = value
        End Set
    End Property

    Public Property SecondPortOrientation_BaseEnd() As Double
        Get
            Return _dblSecondPortOrientation_BaseEnd
        End Get
        Set(ByVal value As Double)
            _dblSecondPortOrientation_BaseEnd = value
        End Set
    End Property

    Public Property FirstPortOrientation_RodEnd() As Double
        Get
            Return _dblFirstPortOrientation_RodEnd
        End Get
        Set(ByVal value As Double)
            _dblFirstPortOrientation_RodEnd = value
        End Set
    End Property

    Public Property SecondPortOrientation_RodEnd() As Double
        Get
            Return _dblSecondPortOrientation_RodEnd
        End Get
        Set(ByVal value As Double)
            _dblSecondPortOrientation_RodEnd = value
        End Set
    End Property

    Public Property StandardRunQuantity() As Double
        Get
            Return _dblStandardRunQuantity
        End Get
        Set(ByVal value As Double)
            _dblStandardRunQuantity = value
        End Set
    End Property

#End Region

#Region "DLPortInTubeDetails"

    Public Property MatchedBEDLCastingDataTable() As DataTable
        Get
            Return _oMatchedBEDLCastingDataTable
        End Get
        Set(ByVal value As DataTable)
            _oMatchedBEDLCastingDataTable = value
        End Set
    End Property

    Public Property PartCodeFromUlugCode() As String
        Get
            Return _strPartCodeFromUlugCode
        End Get
        Set(ByVal value As String)
            _strPartCodeFromUlugCode = value
        End Set
    End Property

    'TODO: ANUP 01-06-2010 04.45pm
    Public Property BendRadius_BaseEnd() As Double
        Get
            Return _dblBendRadius_BaseEnd
        End Get
        Set(ByVal value As Double)
            _dblBendRadius_BaseEnd = value
        End Set
    End Property

#End Region

#Region "BasePlugDetails"

    '01_12_2009   RAGAVA
    Public Property MatchedBEBPCastingDataTable() As DataTable
        Get
            Return _oMatchedBEBPCastingDataTable
        End Get
        Set(ByVal value As DataTable)
            _oMatchedBEBPCastingDataTable = value
        End Set
    End Property

    Public Property BPBushingWidth() As Double
        Get
            Return _dblBPBushingWidth
        End Get
        Set(ByVal value As Double)
            _dblBPBushingWidth = value
        End Set
    End Property

    'Public Property BasePlugOD() As Double
    '    Get
    '        Return _dblBPOD
    '    End Get
    '    Set(ByVal value As Double)
    '        _dblBPOD = value
    '    End Set
    'End Property

    Public Property BasePlugODPortIntegral() As Double
        Get
            Return _dblBPODPortIntegral
        End Get
        Set(ByVal value As Double)
            _dblBPODPortIntegral = value
        End Set
    End Property

    Public Property BasePlugOutSidePlugDiameterRequiredPortIntegral() As Double
        Get
            Return _dblOutSidePlugDiameterRequiredPortIntegral
        End Get
        Set(ByVal value As Double)
            _dblOutSidePlugDiameterRequiredPortIntegral = value
        End Set
    End Property

#End Region

#Region "ThreadedEnd"

    Public Property BEMatchedThreadedEndcastingDataTable() As DataTable
        Get
            Return _oMatchedBEThreadedEndCastingDataTable
        End Get
        Set(ByVal value As DataTable)
            _oMatchedBEThreadedEndCastingDataTable = value
        End Set
    End Property

#End Region

#Region "BHCastingDetails"

    Public Property MatchedBHCastingDataTable() As DataTable
        Get
            Return _oMatchedBHCastingDataTable
        End Get
        Set(ByVal value As DataTable)
            _oMatchedBHCastingDataTable = value
        End Set
    End Property

#End Region

#Region "SLPortInTubeDetails"

    Public Property MatchedBESLCastingDataTable() As DataTable
        Get
            Return _oMatchedBESLCastingDataTable
        End Get
        Set(ByVal value As DataTable)
            _oMatchedBESLCastingDataTable = value
        End Set
    End Property

#End Region

#Region "BECrossTubePortInTubeDetails"

    Public Property MatchedBECrossTubeCastingDataTable() As DataTable
        Get
            Return _oMatchedBECrossTubeCastingDataTable
        End Get
        Set(ByVal value As DataTable)
            _oMatchedBECrossTubeCastingDataTable = value
        End Set
    End Property

    Public Property CrossTubeOD() As Double
        Get
            Return _dblCrossTubeOD
        End Get
        Set(ByVal value As Double)
            If value > 0 Then
                value = Math.Round(value / 0.125)
                value = value * 0.125
            End If
            _dblCrossTubeOD = value
        End Set
    End Property

    '13_03_2012   RAGAVA
    Public Property CrossTubeOD2() As Double
        Get
            Return _dblCrossTubeOD2
        End Get
        Set(ByVal value As Double)
            If value > 0 Then
                value = Math.Round(value / 0.125)
                value = value * 0.125
            End If
            _dblCrossTubeOD2 = value
        End Set
    End Property


#End Region

#Region "RodEnd Configuration"

    Public ReadOnly Property RadiusConstant() As Double
        Get
            Return 0.06
        End Get
    End Property

    Public Property RodEndConfiguration() As String
        Get
            Return _strRodEndConfiguration
        End Get
        Set(ByVal value As String)
            _strRodEndConfiguration = value
        End Set
    End Property

    Public Property LugThickness_RodEnd() As Double
        Get
            Return _dblLugThickness_RodEnd
        End Get
        Set(ByVal value As Double)
            _dblLugThickness_RodEnd = value
        End Set
    End Property

    Public Property LugGap_RodEnd() As Double
        Get
            Return _dblLugGap_RodEnd
        End Get
        Set(ByVal value As Double)
            _dblLugGap_RodEnd = value
        End Set
    End Property

    Public Property SwingClearance_RodEnd() As Double
        Get
            Return _dblSwingClearance_RodEnd
        End Get
        Set(ByVal value As Double)
            _dblSwingClearance_RodEnd = value
        End Set
    End Property
    '24_07_2012    RAGAVA
    Public Property SwingClearance_RodEnd2() As Double
        Get
            Return _dblSwingClearance_RodEnd2
        End Get
        Set(ByVal value As Double)
            _dblSwingClearance_RodEnd2 = value
        End Set
    End Property

    '02_03_2010 Aruna
    'lugHeight_RodEnd
    Public Property lugHeight_RodEnd() As Double
        Get
            Return _dblLugHeight_RodEnd
        End Get
        Set(ByVal value As Double)
            _dblLugHeight_RodEnd = value
        End Set
    End Property
    Public Property lugHeight_BaseEnd() As Double
        Get
            Return _dblLugHeight_BaseEnd
        End Get
        Set(ByVal value As Double)
            _dblLugHeight_BaseEnd = value
        End Set
    End Property
    Public Property Pins_RodEnd() As String
        Get
            Return _strPins_RodEnd
        End Get
        Set(ByVal value As String)
            _strPins_RodEnd = value
        End Set
    End Property

    Public Property Clips_RodEnd() As String
        Get
            Return _strClips_RodEnd
        End Get
        Set(ByVal value As String)
            _strClips_RodEnd = value
        End Set
    End Property

    Public Property CrossTubeWidth_RodEnd() As Double
        Get
            Return _dblCrossTubeWidth_RodEnd
        End Get
        Set(ByVal value As Double)
            _dblCrossTubeWidth_RodEnd = value
        End Set
    End Property
    '24_07_2012   RAGAVA
    Public Property CrossTubeWidth_RodEnd2() As Double
        Get
            Return _dblCrossTubeWidth_RodEnd2
        End Get
        Set(ByVal value As Double)
            _dblCrossTubeWidth_RodEnd2 = value
        End Set
    End Property

    Public Property BushingQuantity_RodEnd() As Double
        Get
            Return _dblBushingQuantity_RodEnd
        End Get
        Set(ByVal value As Double)
            _dblBushingQuantity_RodEnd = value
        End Set
    End Property

    Public Property BushingPinHoleSize_RodEnd() As Double
        Get
            Return _dblBushingPinHoleSize_RodEnd
        End Get
        Set(ByVal value As Double)
            _dblBushingPinHoleSize_RodEnd = value
        End Set
    End Property

    Public Property BushingWidth_RodEnd() As Double
        Get
            Return _dblBushingWidth_RodEnd
        End Get
        Set(ByVal value As Double)
            _dblBushingWidth_RodEnd = value
        End Set
    End Property

    Public Property PinHoleSize_RodEnd() As Double
        Get
            Return _dblPinHoleSize_RodEnd
        End Get
        Set(ByVal value As Double)
            _dblPinHoleSize_RodEnd = value
        End Set
    End Property

    Public Property GreaseZercs_RodEnd() As Double
        Get
            Return _dblGreaseZercs_RodEnd
        End Get
        Set(ByVal value As Double)
            _dblGreaseZercs_RodEnd = value
        End Set
    End Property

    Public Property BushingType_RodEnd() As String
        Get
            Return _strBushingType_RodEnd
        End Get
        Set(ByVal value As String)
            _strBushingType_RodEnd = value
        End Set
    End Property

    Public Property GreaseZercAngle1_RodEnd() As Double
        Get
            Return _dblGreaseZercAngle1_RodEnd
        End Get
        Set(ByVal value As Double)
            _dblGreaseZercAngle1_RodEnd = value
        End Set
    End Property

    Public Property GreaseZercAngle2_RodEnd() As Double
        Get
            Return _dblGreaseZercAngle2_RodEnd
        End Get
        Set(ByVal value As Double)
            _dblGreaseZercAngle2_RodEnd = value
        End Set
    End Property

    Public Property Cost_RodEnd() As Double
        Get
            Return _dblCost_RodEnd
        End Get
        Set(ByVal value As Double)
            _dblCost_RodEnd = value
        End Set
    End Property

    Public Property LugWidth_RodEnd() As Double
        Get
            Return _dblLugWidth_RodEnd
        End Get
        Set(ByVal value As Double)
            _dblLugWidth_RodEnd = value
        End Set
    End Property

    '24_07_2012    RAGAVA
    Public Property LugWidth_RodEnd2() As Double
        Get
            Return _dblLugWidth_RodEnd2
        End Get
        Set(ByVal value As Double)
            _dblLugWidth_RodEnd2 = value
        End Set
    End Property


    Public Property AreaRequired_RodEnd() As Double
        Get
            Return _dblAreaRequired_RodEnd
        End Get
        Set(ByVal value As Double)
            _dblAreaRequired_RodEnd = value
        End Set
    End Property

    Public Property YRequired_RodEnd() As Double
        Get
            Return _dblYRequired_RodEnd
        End Get
        Set(ByVal value As Double)
            _dblYRequired_RodEnd = value
        End Set
    End Property

    Public Property ToleranceUpperLimit_RodEnd() As Double
        Get
            Return _dblToleranceUpperLimit_RodEnd
        End Get
        Set(ByVal value As Double)
            _dblToleranceUpperLimit_RodEnd = value
        End Set
    End Property

    Public Property ToleranceLowerLimit_RodEnd() As Double
        Get
            Return _dblToleranceLowerLimit_RodEnd
        End Get
        Set(ByVal value As Double)
            _dblToleranceLowerLimit_RodEnd = value
        End Set
    End Property

    Public Property PinHoleSizeType_RodEnd() As String
        Get
            Return _strPinHoleSizeType
        End Get
        Set(ByVal value As String)
            _strPinHoleSizeType = value
        End Set
    End Property

    Public Property PinHoleType_Threaded_RodEnd_DL() As String
        Get
            Return _strPinHoleTypeThreaded_RE_DL
        End Get
        Set(ByVal value As String)
            _strPinHoleTypeThreaded_RE_DL = value
        End Set
    End Property


    Public Property ConnectionType() As String
        Get
            Return _strConnectionType
        End Get
        Set(ByVal value As String)
            _strConnectionType = value
        End Set
    End Property
    ''11_02_2010-ARUNA START
    Public Property REDistanceFromPinholetoRodStop() As Double
        Get
            Dim dblValue As Double
            'ANUP 12-08-2010 
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd = "Cast" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd = "NewDesign" Then
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug" Then
                    dblValue = (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd / 2) + 0.5 + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd
                Else
                    dblValue = 0.5 + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd
                End If
                Return dblValue
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd = "Fabricated" Then
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Cross Tube" Then
                    dblValue = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD_RodEnd / 2
                    Return dblValue
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug" Then
                    Dim dblBendRadius As Double
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd <= 0.5 Then
                        dblBendRadius = 0.25
                    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd <= 0.63 Then
                        dblBendRadius = 0.5
                    Else
                        dblBendRadius = 0.625
                    End If
                    dblValue = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd + dblBendRadius + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd
                    Return dblValue
                End If
            End If
            Return _dblREDistanceFromPinholetoRodStop
        End Get
        Set(ByVal value As Double)

            _dblREDistanceFromPinholetoRodStop = value
        End Set
    End Property

    '24_07_2012   RAGAVA
    Public Property REDistanceFromPinholetoRodStop2() As Double
        Get
            Dim dblValue As Double
            'ANUP 12-08-2010 
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd2 = "Cast" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd2 = "NewDesign" Then
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug" Then
                    dblValue = (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd / 2) + 0.5 + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd
                Else
                    dblValue = 0.5 + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd2
                End If
                Return dblValue
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd = "Fabricated" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd2 = "Fabricated" Then
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Cross Tube" Then
                    dblValue = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD_RodEnd2 / 2
                    Return dblValue
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug" Then
                    Dim dblBendRadius As Double
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd <= 0.5 Then
                        dblBendRadius = 0.25
                    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd <= 0.63 Then
                        dblBendRadius = 0.5
                    Else
                        dblBendRadius = 0.625
                    End If
                    dblValue = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd + dblBendRadius + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd
                    Return dblValue
                End If
            End If
            Return _dblREDistanceFromPinholetoRodStop2
        End Get
        Set(ByVal value As Double)

            _dblREDistanceFromPinholetoRodStop2 = value
        End Set
    End Property




    '11_02_2010-ARUNA END

    Public Property OffSet_RodEnd() As Double
        Get
            Return _dblOffSet_RodEnd
        End Get
        Set(ByVal value As Double)
            _dblOffSet_RodEnd = value
        End Set
    End Property

    Public Property ConfigurationDesign_RodEnd() As String
        Get
            Return _strConfigurationDesign_RodEnd
        End Get
        Set(ByVal value As String)
            _strConfigurationDesign_RodEnd = value
        End Set
    End Property
    '24_07_2012   RAGAVA
    Public Property ConfigurationDesign_RodEnd2() As String
        Get
            Return _strConfigurationDesign_RodEnd2
        End Get
        Set(ByVal value As String)
            _strConfigurationDesign_RodEnd2 = value
        End Set
    End Property

    Public Property ConfigurationDesignType_RodEnd() As String
        Get
            Return _strConfigurationDesignType_RodEnd
        End Get
        Set(ByVal value As String)
            _strConfigurationDesignType_RodEnd = value
        End Set
    End Property
    '24_07_2012   RAGAVA
    Public Property ConfigurationDesignType_RodEnd2() As String
        Get
            Return _strConfigurationDesignType_RodEnd2
        End Get
        Set(ByVal value As String)
            _strConfigurationDesignType_RodEnd2 = value
        End Set
    End Property


    Public Property ConfigurationCode_RodEnd() As String
        Get
            Return _strConfigurationCode_RodEnd
        End Get
        Set(ByVal value As String)
            _strConfigurationCode_RodEnd = value
        End Set
    End Property
    '24_07_2012    RAGAVA
    Public Property ConfigurationCode_RodEnd2() As String
        Get
            Return _strConfigurationCode_RodEnd2
        End Get
        Set(ByVal value As String)
            _strConfigurationCode_RodEnd2 = value
        End Set
    End Property


    '26_02_2010   RAGAVA
    Public Property strRodEndConfigurationDesign() As String
        Get
            Return _strRodEndConfigurationDesign
        End Get
        Set(ByVal value As String)
            _strRodEndConfigurationDesign = value
        End Set
    End Property
    '02_03_2010 Aruna
    Public Property PinHoleType_RodEnd() As String
        Get
            Return _strPinHoleType_RodEnd
        End Get
        Set(ByVal value As String)
            _strPinHoleType_RodEnd = value
        End Set
    End Property

    Public Property MilledFlat_RE() As String
        Get
            Return _strMilledFlat_RE
        End Get
        Set(ByVal value As String)
            _strMilledFlat_RE = value
        End Set
    End Property

    'TODO: ANUP 20-04-2010 02.52pm
    Public Property BushingPartCode_RodEnd() As String
        Get
            Return _strBushingPartCode_RodEnd
        End Get
        Set(ByVal value As String)
            _strBushingPartCode_RodEnd = value
        End Set
    End Property

    Public Property BushingOD_RodEnd() As Double
        Get
            Return _dblBushingOD_RodEnd
        End Get
        Set(ByVal value As Double)
            _dblBushingOD_RodEnd = value
        End Set
    End Property

#End Region

#Region "RE FlatWithChamfer"

    Public Property ChamferAngle_RodEnd() As Double
        Get
            Return _dblChamferAngle_RodEnd
        End Get
        Set(ByVal value As Double)
            _dblChamferAngle_RodEnd = value
        End Set
    End Property

    Public Property ChamferSize_RodEnd() As Double
        Get
            Return _dblChamferSize_RodEnd
        End Get
        Set(ByVal value As Double)
            _dblChamferSize_RodEnd = value
        End Set
    End Property

#End Region

#Region "RE Threaded Rod"
    Public Property ThreadType_RodEnd() As String
        Get
            Return _strThreadType_RodEnd
        End Get
        Set(ByVal value As String)
            _strThreadType_RodEnd = value
        End Set
    End Property

    Public Property ThreadSize_RodEnd() As Double
        Get
            Return _dblThreadSize_RodEnd
        End Get
        Set(ByVal value As Double)
            _dblThreadSize_RodEnd = value
        End Set
    End Property

    Public Property ThreadLength_RodEnd() As Double
        Get
            Return _dblThreadLength_RodEnd
        End Get
        Set(ByVal value As Double)
            _dblThreadLength_RodEnd = value
        End Set
    End Property


    Public Property AcrossFlatValue_RodEnd() As Double
        Get
            Return _dblAcrossFlatValue_RodEnd
        End Get
        Set(ByVal value As Double)
            _dblAcrossFlatValue_RodEnd = value
        End Set
    End Property

    Public Property FlatLength_RodEnd() As Double
        Get
            Return _dblFlatLength_RodEnd
        End Get
        Set(ByVal value As Double)
            _dblFlatLength_RodEnd = value
        End Set
    End Property

#End Region

#Region "RetractedLength Calculation"

    Public Property OverAllCylinderLength() As Double
        Get
            Return _dblOverAllCylinderLength
        End Get
        Set(ByVal value As Double)
            _dblOverAllCylinderLength = value
        End Set
    End Property

    'ANUP 25-02-10 12pm
    Public Property ExtraRodButtonLength() As Double
        Get
            Return _dblExtraRodButtonLength
        End Get
        Set(ByVal value As Double)
            _dblExtraRodButtonLength = value
        End Set
    End Property
    Public Property ExtraRodButton() As String
        Get
            Return _strExtraRodButton
        End Get
        Set(ByVal value As String)
            _strExtraRodButton = value
        End Set
    End Property

    Public Property PortEndDistanceFromTubeEnd() As Double
        Get
            Return _strPortEndDistanceFromTubeEnd
        End Get
        Set(ByVal value As Double)
            _strPortEndDistanceFromTubeEnd = value
        End Set
    End Property

    '#############

    'TODO: ANUP 27-02-2010 12.54
    Public Property OffsetPortOrifice() As Double
        Get
            Return _dblOffsetPortOrifice
        End Get
        Set(ByVal value As Double)
            _dblOffsetPortOrifice = value
        End Set
    End Property
    Public Property StickOut() As Double
        Get
            Return _dblStickOut
        End Get
        Set(ByVal value As Double)
            _dblStickOut = value
        End Set
    End Property

    Public Property SkimWidth() As Double
        Get
            Return _dblSkimWidth
        End Get
        Set(ByVal value As Double)
            _dblSkimWidth = value
        End Set
    End Property
    '*******************

    'TODO: ANUP 06-04-2010 02.12
    Public Property ISFabricationChecked() As Boolean
        Get
            Return _blnISFabricationChecked
        End Get
        Set(ByVal value As Boolean)
            _blnISFabricationChecked = value
        End Set
    End Property
    '*************

    'TODO: ANUP 06-04-2010 04.45
    Public Property IsCounterBoreChecked() As Boolean
        Get
            Return _blnIsCounterBoreChecked
        End Get
        Set(ByVal value As Boolean)
            _blnIsCounterBoreChecked = value
        End Set
    End Property

    'TODO:  ANUP 22-04-2010 11.53am
    Public Property SkipRetractedIfPositiveFromGenerate() As Boolean
        Get
            Return _blnSkipRetractedIfPositiveFromGenerate
        End Get
        Set(ByVal value As Boolean)
            _blnSkipRetractedIfPositiveFromGenerate = value
        End Set
    End Property
    '******************


    'TODO:  ANUP 24-05-2010 10.36am
    Public Property GoToBaseEndScreenFromRetractedScreen() As Boolean
        Get
            Return _blnGoToBaseEndScreenFromRetractedScreen
        End Get
        Set(ByVal value As Boolean)
            _blnGoToBaseEndScreenFromRetractedScreen = value
        End Set
    End Property

    Public Property GoToRodEndScreenFromRetractedScreen() As Boolean
        Get
            Return _blnGoToRodEndScreenFromRetractedScreen
        End Get
        Set(ByVal value As Boolean)
            _blnGoToRodEndScreenFromRetractedScreen = value
        End Set
    End Property
    '******************


#End Region

#Region "RECrossTube"

    Public Property MatchedRECrossTubeCastingDataTable() As DataTable
        Get
            Return _oMatchedRECrossTubeCastingDataTable
        End Get
        Set(ByVal value As DataTable)
            _oMatchedRECrossTubeCastingDataTable = value
        End Set
    End Property

    Public Property CrossTubeOD_RodEnd() As Double
        Get
            Return _dblCrossTubeOD_RodEnd
        End Get
        Set(ByVal value As Double)
            If value > 0 Then
                value = Math.Round(value / 0.125)
                value = value * 0.125
            End If
            _dblCrossTubeOD_RodEnd = value
        End Set
    End Property

    '24_07_2012    RAGAVA
    Public Property CrossTubeOD_RodEnd2() As Double
        Get
            Return _dblCrossTubeOD_RodEnd2
        End Get
        Set(ByVal value As Double)
            If value > 0 Then
                value = Math.Round(value / 0.125)
                value = value * 0.125
            End If
            _dblCrossTubeOD_RodEnd2 = value
        End Set
    End Property
#End Region

#Region "REDoubleLug"

    '06_03_2010  RAGAVA
    Public Property WeldSize_RodEndCT() As Double
        Get
            Return _dblWeldSize_RECT
        End Get
        Set(ByVal value As Double)
            _dblWeldSize_RECT = value
        End Set
    End Property


    Public Property WeldSize_RodEndDL() As Double
        Get
            Return _dblWeldSize_REDL
        End Get
        Set(ByVal value As Double)
            _dblWeldSize_REDL = value
        End Set
    End Property

    Public Property MatchedREDLCastingDataTable() As DataTable
        Get
            Return _oMatchedREDlCastingDataTable
        End Get
        Set(ByVal value As DataTable)
            _oMatchedREDlCastingDataTable = value
        End Set
    End Property

    Public Property MatchedREDLThreadedDataTable() As DataTable
        Get
            Return _oMatchedREDLThreadedDataTable
        End Get
        Set(ByVal value As DataTable)
            _oMatchedREDLThreadedDataTable = value
        End Set
    End Property

    'TODO: ANUP 01-06-010 04.30pm
    Public Property BendRadius_RodEnd() As Double
        Get
            Return _dblBendRadius_RodEnd
        End Get
        Set(ByVal value As Double)
            _dblBendRadius_RodEnd = value
        End Set
    End Property

    'ANUP 07-07-2010
    Public Property PilotHoleDiameter() As String
        Get
            Return _strPilotHoleDiameter
        End Get
        Set(ByVal value As String)
            _strPilotHoleDiameter = value
        End Set
    End Property

#End Region

#Region "Code Details"

    Public Property ClevisPlateCode() As String
        Get
            Return _strClevisPlateCode
        End Get
        Set(ByVal value As String)
            _strClevisPlateCode = value
        End Set
    End Property

    '13_03_2012   RAGAVA
    Public Property ClevisPlateCode2() As String
        Get
            Return _strClevisPlateCode2
        End Get
        Set(ByVal value As String)
            _strClevisPlateCode2 = value
        End Set
    End Property

    Public Property ConfigurationCode_BaseEnd() As String
        Get
            Return _strConfigurationCode_BaseEnd
        End Get
        Set(ByVal value As String)
            _strConfigurationCode_BaseEnd = value
        End Set
    End Property

    '13_03_2012   RAGAVA
    Public Property ConfigurationCode_BaseEnd2() As String
        Get
            Return _strConfigurationCode_BaseEnd2
        End Get
        Set(ByVal value As String)
            _strConfigurationCode_BaseEnd2 = value
        End Set
    End Property

    'ToDo:Anup 06-04-10 5pm
    Public Property CounterBoreClevisPlateCode() As String
        Get
            Return _strCounterBoreClevisPlateCode
        End Get
        Set(ByVal value As String)
            _strCounterBoreClevisPlateCode = value
        End Set
    End Property

    Public Property CounterBoreClevisPlateThickness() As Double
        Get
            Return _dblCounterBoreClevisPlateThickness
        End Get
        Set(ByVal value As Double)
            _dblCounterBoreClevisPlateThickness = value
        End Set
    End Property
    Public Property CounterboredClevisPlateRodStopDistance() As Double
        Get
            Return _dblCounterboredClevisPlateRodStopDistance
        End Get
        Set(ByVal value As Double)
            _dblCounterboredClevisPlateRodStopDistance = value
        End Set
    End Property

#End Region

#Region "Clevis Plate Thickness"

    Public Property ClevisPlateThickness() As Double
        Get
            Return _dblClevisPlateThickness
        End Get
        Set(ByVal value As Double)
            _dblClevisPlateThickness = value
        End Set
    End Property

    '13_03_2012  RAGAVA
    Public Property ClevisPlateThickness2() As Double
        Get
            Return _dblClevisPlateThickness2
        End Get
        Set(ByVal value As Double)
            _dblClevisPlateThickness2 = value
        End Set
    End Property
     
    Public Property ClevisPlateRodStopDistance() As Double
        Get
            Return _dblClevisPlateRodStopDistance
        End Get
        Set(ByVal value As Double)
            _dblClevisPlateRodStopDistance = value
        End Set
    End Property
    '
    Public Property clevisplatePartFilePath() As String
        Get
            Return _strClevisplatePartFilePath
        End Get
        Set(ByVal value As String)
            _strClevisplatePartFilePath = value
        End Set
    End Property


    'TODO: ANUP 23-04-2010 12.32pm
    Public Property ClevisPlateImportOrExisting() As String
        Get
            Return _strClevisPlateImportOrExisting
        End Get
        Set(ByVal value As String)
            _strClevisPlateImportOrExisting = value
        End Set
    End Property

    Public Property ClevisPlateImportOrExisting2() As String
        Get
            Return _strClevisPlateImportOrExisting2
        End Get
        Set(ByVal value As String)
            _strClevisPlateImportOrExisting2 = value
        End Set
    End Property
    '*****************
#End Region


#Region "PullForce Base End"

    Public Property PullForce() As Double
        Get
            Return _dblPullForce
        End Get
        Set(ByVal value As Double)
            _dblPullForce = value
        End Set
    End Property
#End Region

#Region "PullForce Rod End"

    Public Property PullForce_RodEnd() As Double
        Get
            Return _dblPullForce_RodEnd
        End Get
        Set(ByVal value As Double)
            _dblPullForce_RodEnd = value
        End Set
    End Property
#End Region

    'Aruna `9_3_2010
#Region "Folder Deletion"
    Public Property FolderDeletionHashTable() As Hashtable
        Get
            Return _htFolderDeletion
        End Get
        Set(ByVal value As Hashtable)
            _htFolderDeletion = value
        End Set
    End Property
#End Region

    'TODO: ANUP 28-04-2010 01.03pm
#Region "Weld Variables for Casting/Fabrication"

    Public Property WeldSize_RodEnd() As Double
        Get
            Return _dblWeldSize_RodEnd
        End Get
        Set(ByVal value As Double)
            _dblWeldSize_RodEnd = value
        End Set
    End Property

    Public Property JGrooveWidth_RodEnd() As Double
        Get
            Return _dblJGrooveWidth_RodEnd
        End Get
        Set(ByVal value As Double)
            _dblJGrooveWidth_RodEnd = value
        End Set
    End Property

    Public Property JGrooveRadius_RodEnd() As Double
        Get
            Return _dblJGrooveRadius_RodEnd
        End Get
        Set(ByVal value As Double)
            _dblJGrooveRadius_RodEnd = value
        End Set
    End Property

    Public Property WeldPreperation_RodEnd() As String
        Get
            Return _strWeldPreperation_RodEnd
        End Get
        Set(ByVal value As String)
            _strWeldPreperation_RodEnd = value
        End Set
    End Property

#End Region

    ': ANUP 27-05-2010 01.51pm
#Region "Contract Details and Monarch Revision Variables"

    Public Property CustomerName_ContractDetails() As String
        Get
            Return _strCustomerName_ContractDetails
        End Get
        Set(ByVal value As String)
            _strCustomerName_ContractDetails = value
        End Set
    End Property

    Public Property AssemblyType_ContractDetails() As String
        Get
            Return _strAssemblyType_ContractDetails
        End Get
        Set(ByVal value As String)
            _strAssemblyType_ContractDetails = value
        End Set
    End Property

    Public Property PartCode_ContractDetails() As String
        Get
            Return _strPartCode_ContractDetails
        End Get
        Set(ByVal value As String)
            _strPartCode_ContractDetails = value
        End Set
    End Property

    Public Property New_Revision() As String
        Get
            Return _strNew_Revision
        End Get
        Set(ByVal value As String)
            _strNew_Revision = value
        End Set
    End Property

    Public Property CustomerNameComboBOxChanged() As Boolean
        Get
            Return _blnCustomerNameComboBOxChanged
        End Get
        Set(ByVal value As Boolean)
            _blnCustomerNameComboBOxChanged = value
        End Set
    End Property
#End Region

#End Region

    '07_02_2011    RAGAVA
    Public Function UpdateExistedCasting() As Boolean
        Try
            Dim success As Boolean = False
            If ObjClsWeldedCylinderFunctionalClass.IsNew_Revision_Released = "Released" Then
                Dim strQuery As String = "Update " & strBaseEndCastingTableName & " set IsExisted = 'True' where PartCode = " & strBaseEndCastingCodeNumber
                success = MonarchConnectionObject.ExecuteQuery(strQuery)
                strQuery = "Update " & strRodEndCastingTableName & " set IsExisted = 'True' where PartCode = " & strRodEndCastingCodeNumber
                success = MonarchConnectionObject.ExecuteQuery(strQuery)
            End If
            Return success
        Catch ex As Exception

        End Try
    End Function


    '31_05_2011  RAGAVA
    Public Function SetSafetyFactorForExisting(ByVal strPartCode_Purchase As String) As Double
        Try
            SetSafetyFactorForExisting = 0
            'If ObjClsWeldedCylinderFunctionalClass.IsNew_Revision_Released = "Released" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.New_Revision.IndexOf("Revision") <> -1 Then
            Dim strQuery As String = String.Empty
            'strQuery = "select BaseEndSafetyFactor from Contract_SafetyFactor_Details where ContractNumber = '" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber & "' and BaseEndCodeNumber = '" & strPartCode_Purchase & "'"
            strQuery = "select BaseEndSafetyFactor from Contract_SafetyFactor_Details where BaseEndCodeNumber = '" & strPartCode_Purchase & "'"
            Dim Objdt As DataTable
            Objdt = MonarchConnectionObject.GetTable(strQuery)
            If Objdt.Rows.Count > 0 Then
                SetSafetyFactorForExisting = Objdt.Rows(0)(0)
            End If
            Return SetSafetyFactorForExisting
            'End If
        Catch ex As Exception

        End Try
    End Function
    '31_05_2011  RAGAVA
    Public Function SetSafetyFactorForExisting_RodEnd(ByVal strPartCode_Purchase As String) As Double
        Try
            SetSafetyFactorForExisting_RodEnd = 0
            'If ObjClsWeldedCylinderFunctionalClass.IsNew_Revision_Released = "Released" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.New_Revision.IndexOf("Revision") <> -1 Then
            Dim strQuery As String = String.Empty
            'strQuery = "select RodEndSafetyFactor from Contract_SafetyFactor_Details where ContractNumber = '" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber & "' and RodEndCodeNumber = '" & strPartCode_Purchase & "'"
            strQuery = "select RodEndSafetyFactor from Contract_SafetyFactor_Details where RodEndCodeNumber = '" & strPartCode_Purchase & "'"
            Dim Objdt As DataTable
            Objdt = MonarchConnectionObject.GetTable(strQuery)
            If Objdt.Rows.Count > 0 Then
                SetSafetyFactorForExisting_RodEnd = Objdt.Rows(0)(0)
            End If
            Return SetSafetyFactorForExisting_RodEnd
            'End If
        Catch ex As Exception

        End Try
    End Function

    '13_06_2011   RAGAVA
    Public Function GetWC_619_622() As String
        Try
            GetWC_619_622 = String.Empty
            If (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OriginalTubeLength + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonWidth) < 6 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "New" Then
                GetWC_619_622 = "WC622"
                Return GetWC_619_622
            End If

            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "Conventional" AndAlso _
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter >= 0.5 AndAlso _
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter <= 2.5 AndAlso _
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodLength <= 44 AndAlso _
            (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodLength - _
            ObjClsWeldedCylinderFunctionalClass.ObjFrmRetractedLengthValidation.Dim8FromPistonEndofRod) >= 10.75 _
            AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OriginalTubeLength <= 54 AndAlso _
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth <= 6.75 Then
                GetWC_619_622 = "WC619"
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "New" _
            AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength >= 8 AndAlso _
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter >= 1.5 AndAlso _
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 3.0 Then
                GetWC_619_622 = "WC619"
            Else
                GetWC_619_622 = "WC622"
            End If

            Return GetWC_619_622
        Catch ex As Exception

        End Try
    End Function

    '23_06_2011   RAGAVA
    Public Function ECR_MainFunctionality() As Boolean
        ECR_MainFunctionality = False
        Try
            Dim oClsReleaseCylinderFunctionality As New clsReleaseCylinderFunctionality          '23_06_2011   RAGAVA
            If oClsReleaseCylinderFunctionality.ReleaseExcelFunctionality() Then
                If ECR_NewPartsUpdation_ReleaseMenuItem(oClsReleaseCylinderFunctionality) Then
                    'If DropReleasedCodeNumbersToDB_ReleaseMenuItemClick() Then
                    ECR_MainFunctionality = True
                    'End If
                End If
            End If
        Catch ex As Exception
            ECR_MainFunctionality = False
        End Try
    End Function

    '23_06_2011   RAGAVA
    Public Function DropReleasedCodeNumbersToDB_ReleaseMenuItemClick() As Boolean          '23_06_2011   RAGAVA   private to public
        DropReleasedCodeNumbersToDB_ReleaseMenuItemClick = False
        Try
            If ObjClsWeldedCylinderFunctionalClass.IsNew_Revision_Released = "Released" OrElse ObjClsWeldedCylinderFunctionalClass.IsNew_Revision_Released = "Revision" Then 'anup 21-03-2011 added revision
                Dim strQuery1 As String = String.Empty
                strQuery1 = "DELETE FROM [MIL_WELDED].[dbo].[ReleasedCylinderCodes] WHERE ReleasedCylinderCodeNumber = '" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber & "'"
                MonarchConnectionObject.ExecuteQuery(strQuery1)

                Dim strQuery As String = String.Empty
                strQuery = "INSERT INTO dbo.ReleasedCylinderCodes(ReleasedCylinderCodeNumber) VALUES(" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber & ")"
                DropReleasedCodeNumbersToDB_ReleaseMenuItemClick = MonarchConnectionObject.ExecuteQuery(strQuery)
                If DropReleasedCodeNumbersToDB_ReleaseMenuItemClick = False Then
                    MessageBox.Show("Error in updating Released Cylinder Code to Data Table", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                End If
            Else
                Return True
            End If
        Catch ex As Exception
            DropReleasedCodeNumbersToDB_ReleaseMenuItemClick = False
        End Try
    End Function

    '23_06_2011   RAGAVA
    Public Function ECR_NewPartsUpdation_ReleaseMenuItem(ByRef oClsReleaseCylinderFunctionality As clsReleaseCylinderFunctionality) As Boolean
        ECR_NewPartsUpdation_ReleaseMenuItem = False
        Try
            Dim _blnIsNewTubeWeldment As Boolean
            Dim _blnIsNewRodWeldment As Boolean
            Dim _blnIsNewCylinderHead As Boolean
            Dim _blnIsNewPiston As Boolean
            Dim _blnIsNewSteelCasting_BaseEnd As Boolean
            Dim _blnIsNewSteelCasting_RodEnd As Boolean
            Dim _blnIsNewCrossTube_BaseEnd As Boolean
            Dim _blnIsNewCrossTube_RodEnd As Boolean
            Dim _blnIsNewStopTube As Boolean
            Dim _blnIsNewLug_BaseEnd As Boolean
            Dim _blnIsNewLug_RodEnd As Boolean
            'Dim oClsReleaseCylinderFunctionality As New clsReleaseCylinderFunctionality
            Dim _strQuery As String = String.Empty
            Dim drECR_Details As DataRow
            _strQuery = "select * from StoreECR_PartsDetails_ReleaseOnClick where ContractNumber = '" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber + "'"
            drECR_Details = MonarchConnectionObject.GetDataRow(_strQuery)
            If IsNothing(drECR_Details) = False OrElse drECR_Details.ItemArray.Length > 0 Then
                Dim strTubeWeldment As String = drECR_Details("TUBEWELDMENT")
                Dim strRodWeldment As String = drECR_Details("RODWELDMENT")
                Dim strStopTube As String = drECR_Details("Stoptube")
                Dim strSteelCasting_BaseEnd As String = drECR_Details("BaseEndSteelCasting")
                Dim strSteelCasting_RodEnd As String = drECR_Details("RodEndSteelCasting")
                Dim strCrossTube_BaseEnd As String = drECR_Details("CrossTube_BaseEnd")
                Dim strCrossTube_RodEnd As String = drECR_Details("CrossTube_RodEnd")
                Dim strLug_BaseEnd As String = drECR_Details("Lug_baseEnd")
                Dim strLug_RodEnd As String = drECR_Details("Lug_RodEnd")
                Dim strCylinderHeadCode As String = drECR_Details("CylinderHead")
                Dim strPistonCode As String = drECR_Details("Piston")
                Dim strCylinderCode As String = drECR_Details("ContractNumber")
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTableName = drECR_Details("BaseEndCastingTable")
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRodEndCastingTableName = drECR_Details("RodEndCastingTable")
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingCodeNumber = drECR_Details("BaseEndCastingCode")
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRodEndCastingCodeNumber = drECR_Details("RodEndCastingCode")
                If oClsReleaseCylinderFunctionality.CreateDirectoryForNewExcel() Then

                    If strCylinderCode <> "" Then
                        oClsReleaseCylinderFunctionality._htCodeNumbers.Add("CYLINDER_CODE", strCylinderCode)
                        _blnIsNewTubeWeldment = True
                    End If

                    If strTubeWeldment <> "" Then
                        oClsReleaseCylinderFunctionality._htCodeNumbers.Add("TUBE_WELDMENT", strTubeWeldment)
                        _blnIsNewTubeWeldment = drECR_Details("IsNewTubeWeldment")
                    End If
                    If strRodWeldment <> "" Then
                        oClsReleaseCylinderFunctionality._htCodeNumbers.Add("ROD_WELDMENT", strRodWeldment)
                        _blnIsNewRodWeldment = drECR_Details("IsNewRodWeldment")
                    End If
                    If strCylinderHeadCode <> "" Then
                        oClsReleaseCylinderFunctionality._htCodeNumbers.Add("CYL HEAD", strCylinderHeadCode)
                        _blnIsNewCylinderHead = drECR_Details("IsNewCylinderHead")
                    End If
                    If strPistonCode <> "" Then
                        oClsReleaseCylinderFunctionality._htCodeNumbers.Add("PISTONCODE", strPistonCode)
                        _blnIsNewPiston = drECR_Details("IsNewPiston")
                    End If
                    If strSteelCasting_BaseEnd <> "" Then
                        oClsReleaseCylinderFunctionality._htCodeNumbers.Add("BASEEND_STEELCASTING", strSteelCasting_BaseEnd)
                        _blnIsNewSteelCasting_BaseEnd = drECR_Details("IsNewBaseEndSteelCasting")
                    End If
                    If strSteelCasting_RodEnd <> "" Then
                        oClsReleaseCylinderFunctionality._htCodeNumbers.Add("RODEND_STEELCASTING", strSteelCasting_RodEnd)
                        _blnIsNewSteelCasting_RodEnd = drECR_Details("IsNewRodEndSteelCasting")
                    End If
                    If strCrossTube_BaseEnd <> "" Then
                        oClsReleaseCylinderFunctionality._htCodeNumbers.Add("CROSSTUBE_BASEEND", strCrossTube_BaseEnd)
                        _blnIsNewCrossTube_BaseEnd = drECR_Details("IsNewCrossTube_BaseEnd")
                    End If
                    If strCrossTube_RodEnd <> "" Then
                        oClsReleaseCylinderFunctionality._htCodeNumbers.Add("CROSSTUBE_RODEND", strCrossTube_RodEnd)
                        _blnIsNewCrossTube_RodEnd = drECR_Details("IsNewCrossTube_RodEnd")
                    End If
                    If strStopTube <> "" Then
                        oClsReleaseCylinderFunctionality._htCodeNumbers.Add("Stop_tube", strStopTube)
                        _blnIsNewStopTube = drECR_Details("IsNewStopTube")
                    End If
                    If strLug_BaseEnd <> "" Then
                        oClsReleaseCylinderFunctionality._htCodeNumbers.Add("LUG_BASEEND", strLug_BaseEnd)
                        _blnIsNewLug_BaseEnd = drECR_Details("IsNewLug_baseEnd")
                    End If
                    If strLug_RodEnd <> "" Then
                        oClsReleaseCylinderFunctionality._htCodeNumbers.Add("LUG_RodEND", strLug_RodEnd)
                        _blnIsNewLug_RodEnd = drECR_Details("IsNewLug_RodEnd")
                    End If
                    Try
                        DropReleasedCodeNumbersToDB_ReleaseMenuItemClick()      '27_06_2011   RAGAVA
                        If oClsReleaseCylinderFunctionality.DropDataToNewExcelSheet(drECR_Details) Then
                            ECR_NewPartsUpdation_ReleaseMenuItem = True
                            oClsReleaseCylinderFunctionality.DropRod_Tube_StoptubeCodesToDB(strTubeWeldment, strRodWeldment, strLug_BaseEnd, strLug_RodEnd, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber, _
                   strCylinderHeadCode, strPistonCode, strCrossTube_BaseEnd, strCrossTube_RodEnd, strSteelCasting_BaseEnd, strSteelCasting_RodEnd, strStopTube)
                        End If
                    Catch ex As Exception

                    End Try
                   
                End If
                '24_06_2011   RAGAVA
                'If Not Directory.Exists("W:\WELDED\CMS\" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString & "_CMS") Then          '14_07_2011  RAGAVA
                If Directory.Exists("W:\WELDED\CMS\" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString & "_CMS") Then
                    Directory.Delete("W:\WELDED\CMS\" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString & "_CMS")
                End If

                Dim fso As New Scripting.FileSystemObject
                My.Computer.FileSystem.MoveDirectory("C:\WELDED_TESTING\CMS_TEMP\" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString & "_CMS", "W:\WELDED\CMS\" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString & "_CMS")     '19_12_2011   RAGAVA
                'Directory.Move("C:\WELDED_TESTING\CMS_TEMP\" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString & "_CMS", "W:\WELDED\CMS\" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString & "_CMS")
                If File.Exists("W:\WELDED\CNC\" & "0" & strRodWeldment & "1.MIN") Then
                    File.Delete("W:\WELDED\CNC\" & "0" & strRodWeldment & "1.MIN")
                End If
                My.Computer.FileSystem.MoveFile("C:\WELDED_TESTING\CNC_TEMP\" & "0" & strRodWeldment & "1.MIN", "W:\WELDED\CNC\" & "0" & strRodWeldment & "1.MIN")
                'File.Move("C:\WELDED_TESTING\CNC_TEMP\" & "0" & strRodWeldment & "1.MIN", "W:\WELDED\CNC\" & "0" & strRodWeldment & "1.MIN")
                'End If
            End If
        Catch ex As Exception
            ECR_NewPartsUpdation_ReleaseMenuItem = False
        End Try
    End Function

    '23_06_2011   RAGAVA
    Public Function InsertData_PartsDetails_ReleaseOnClick() As Boolean
        Try
            InsertData_PartsDetails_ReleaseOnClick = False
            Dim strQuery As String = String.Empty
            Dim strTubeWeldment As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("TUBE_WELDMENT")
            Dim strRodWeldment As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("ROD_WELDMENT")
            Dim strStopTube As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("Stop_tube")
            Dim strSteelCasting_BaseEnd As String = String.Empty
            Dim strSteelCasting_RodEnd As String = String.Empty
            '19_07_2012    RAGAVA   commented
            'If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType) = "CAST" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Plate Clevis" Then
            '    If Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd) <> "" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.ContainsKey(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName) Then
            '        strSteelCasting_BaseEnd = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd)
            '        If strSteelCasting_BaseEnd = "" Then
            '            strSteelCasting_BaseEnd = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
            '        End If
            '    End If
            'End If
            strSteelCasting_BaseEnd = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingPart)       '19_07_2012    RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd = "Cast" Then
                strSteelCasting_RodEnd = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName)
            End If
            Dim strCrossTube_BaseEnd As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("BASE_CROSSTUBE_IFL")
            Dim strCrossTube_RodEnd As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("CROSSTUBE_ROD")
            Dim strLug_BaseEnd As String = String.Empty
            Dim strLug_RodEnd As String = String.Empty
            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration.IndexOf("Lug") <> -1 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Fabricated" Then
            '    strLug_BaseEnd = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd 'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
            'End If
            strLug_BaseEnd = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndFabricationPart)       '19_07_2012    RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration.IndexOf("Lug") <> -1 AndAlso ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Fabricated" Then
                strLug_RodEnd = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd
            End If
            Dim strCylinderHeadCode As String = ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign._strCH_CylinderHeadCode
            Dim oExistingListItems_Piston As clsList = clsAddExistingCodes._htExistingCostingCodeList(clsAddExistingCodes.PISTONCODE)
            Dim strPistonCode As String = oExistingListItems_Piston.strPartCode
            Dim strCylinderCode As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber
            Dim strBaseTableName As String = String.Empty
            Dim strRodEndTableName As String = String.Empty
            strBaseTableName = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName
            strRodEndTableName = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEnd_NewDesign_TableName
            If strBaseTableName = "" Then
                strBaseTableName = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTableName
            End If
            If strRodEndTableName = "" Then
                strRodEndTableName = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRodEndCastingTableName
            End If
            strQuery = "Insert into StoreECR_PartsDetails_ReleaseOnClick values('" _
            & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber & "','" & strTubeWeldment & "','" _
            & strRodWeldment & "','" & strStopTube & "','" & strCylinderHeadCode & "','" & strPistonCode & "','" & _
            strSteelCasting_BaseEnd & "','" & strSteelCasting_RodEnd & "','" & strCrossTube_BaseEnd & "','" & _
            strCrossTube_RodEnd & "','" & strLug_BaseEnd & "','" & strLug_RodEnd & "'," & CheckForNewOrExisting(strTubeWeldment) _
            & "," & CheckForNewOrExisting(strRodWeldment) & "," & CheckForNewOrExisting(strStopTube) & "," & _
            CheckForNewOrExisting(strCylinderHeadCode) & "," & CheckForNewOrExisting(strPistonCode) & "," & _
            CheckForNewOrExisting(strSteelCasting_BaseEnd) & "," & CheckForNewOrExisting(strSteelCasting_RodEnd) & _
            "," & CheckForNewOrExisting(strCrossTube_BaseEnd) & "," & CheckForNewOrExisting(strCrossTube_RodEnd) & _
            "," & CheckForNewOrExisting(strLug_BaseEnd) & "," & CheckForNewOrExisting(strLug_RodEnd) & ",'" & _
            strBaseTableName & "','" & strRodEndTableName & "','" & _
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingCodeNumber & "','" & _
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRodEndCastingCodeNumber & "')"
            InsertData_PartsDetails_ReleaseOnClick = MonarchConnectionObject.ExecuteQuery(strQuery)
        Catch ex As Exception

        End Try
    End Function
    Public Function CheckForNewOrExisting(ByVal strCode As String) As Integer         '23_06_2011  RAGAVA   Private to Public
        Try
            CheckForNewOrExisting = 0
            If Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strNewPartCodeNumber_BeforeContractStart) <= Val(strCode) Then
                Return 1
            End If
        Catch ex As Exception

        End Try
    End Function
End Class
