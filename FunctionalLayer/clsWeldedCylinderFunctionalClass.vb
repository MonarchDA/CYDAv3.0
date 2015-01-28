Imports Microsoft.Win32.Registry
Imports Microsoft.Win32.RegistryKey
Imports System.Diagnostics.Process
Imports Microsoft.Office.Interop
Imports Microsoft.Win32
Imports System.IO
Imports IFLBaseDataLayer
Imports IFLCommonLayer
Imports System.Threading


Public Class clsWeldedCylinderFunctionalClass

#Region "Variables"

#Region "Form Declarations"


    Private _oClsListViewMIL As clsListViewMIL

    Private _oClsWeldedDataClass As clsWeldedDataClass

    Private _oClsWeldedGlobalVariables As clsWeldedGlobalVariables

    Private _oClsSolidWorksBaseClass As IFLSolidWorksBaseClass      '09_11_2009  Ragava

    Public _oClsExcelClass As ExcelClass                        '09_11_2009  Ragava

    '------------------Primary-------------

    Private _oFrmPrimaryInputs As frmPrimaryInputs

    Private _oFrmPistonDesign As frmPistonDesign

    Private _oFrmTubeDetails As frmTubeDetails

    Private _oFrmHeadDesign As frmHeadDesign

    Private _oFrmPortDetails As frmPortDetails

    Private _oFrmRodEndConfiguration As frmRodEndConfiguration

    Private _oFrmPin_Port_PaintAccessories As frmPin_Port_PaintAccessories

    '-------------------------------------------

    '------------------Double Lug-------------

    Private _oFrmDLPortInTubeDetails As frmDLPortInTubeDetails
    Private _oFrmDLPortInTubeDetails2 As frmDLPortInTubeDetails2

    Private _oFrmDLCastingYes As frmDLCastingYes

    Private _oFrmDLCastingNo_PortInTube As frmDLCastingNo_PortInTube
    Private _oFrmDLCastingNo_PortInTube2 As frmDLCastingNo_PortInTube2

    Private _oFrmDLPortIntegral As frmDLPortIntegral
    Private _oFrmDLPortIntegral2 As frmDLPortIntegral2

    Private _oFrmDLFabrication As frmDLFabrication

    Private _oFrmDLDesignACasting As frmDLDesignACasting

    Private _oFrmDLFabrication2 As frmDLFabrication2

    Private _oFrmDLDesignACasting2 As frmDLDesignACasting2
    Private _oFrmDLCastingYes2 As frmDLCastingYes2

    Private _oFrmDLCastingNo_PortIntegral As frmDLCastingNo_PortIntegral

    Private _oFrmDLCastingNo_PortIntegral2 As frmDLCastingNo_PortIntegral2  '26-04-2012 MANJULA

    Private _oFrmFabricatedSingleLug As frmFabricatedSingleLug_RetractedLength         '06_01_2012   RAGAVA
    Private _oFrmFabricatedSingleLug2 As frmFabricatedSingleLug_RetractedLength2         '30_05_2012   RAGAVA

    '-------------------------------------------

    'MANJULA ADDED
    '-------------------BH-------------

    Private _oFrmBHCastingNo_PortIntegral As frmBHCastingNo_PortIntegral

    Private _oFrmBHCastingNo_PortInTube As frmBHCastingNo_PortInTube

    Private _oFrmBHCastingYes As frmBHCastingYes

    Private _oFrmBHDesignACasting As frmBHDesignACasting

    Private _oFrmBHFabrication As frmBHFabrication

    Private _oFrmBHPortIntegral As frmBHPortIntegral

    Private _oFrmBHPortinTube As frmBHPortInTube

    Private _oFrmBHCastingNo_PortIntegral2 As frmBHCastingNo_PortIntegral2

    Private _oFrmBHCastingNo_PortInTube2 As frmBHCastingNo_PortInTube2

    Private _oFrmBHCastingYes2 As frmBHCastingYes2

    Private _oFrmBHDesignACasting2 As frmBHDesignACasting2

    Private _oFrmBHFabrication2 As frmBHFabrication2

    Private _oFrmBHPortIntegral2 As frmBHPortIntegral2

    Private _oFrmBHPortinTube2 As frmBHPortInTube2

    '-----------------------------------------



    '-------------------Single Lug-------------
    Private _oFrmSLCastingNo_PortIntegral As frmSLCastingNo_PortIntegral

    Private _oFrmSLCastingNo_PortInTube As frmSLCastingNo_PortInTube

    Private _oFrmSLCastingYes As frmSLCastingYes

    Private _oFrmSLDesignACasting As frmSLDesignACasting

    Private _oFrmSLFabrication As frmSLFabrication

    Private _oFrmSLPortIntegral As frmSLPortIntegral

    Private _oFrmSLPortinTube As frmSLPortinTube

    Private _oFrmSLCastingNo_PortIntegral2 As frmSLCastingNo_PortIntegral2

    Private _oFrmSLCastingNo_PortInTube2 As frmSLCastingNo_PortInTube2

    Private _oFrmSLCastingYes2 As frmSLCastingYes2

    Private _oFrmSLDesignACasting2 As frmSLDesignACasting2

    Private _oFrmSLFabrication2 As frmSLFabrication2

    Private _oFrmSLPortIntegral2 As frmSLPortIntegral2

    Private _oFrmSLPortinTube2 As frmSLPortinTube2

    '-----------------------------------------

    'Aruna 9_11_2009
    '-------------------Base Plug-------------
    Private _oFrmBasePlugCastingYes As frmBasePlugCastingYes

    Private _oFrmBasePlugPortInTube As frmBasePlugPortInTube

    Private _oFrmBasePlugPortIntegral As frmBasePlugPortIntegral

    Private _oFrmDesignABasePlug As frmDesignABasePlug       '04_12_2009   RAGAVA

    ' ANUP 08-03-2010 10.50
    Private _oFrmBasePlugCastingYesPortIntegral As frmBasePlugCastingYesPortIntegral

    Private _oFrmBasePlugCastingNoPortIntegral As frmBasePlugCastingNoPortIntegral
    '*********************

    'TODO: ANUP 08-03-2010 10.50

    '---------------------------------------------

    '------------------Plate Clevis-------------

    Private _oFrmConPlateClevis As frmConPlateClevis

    '---------------------------------------------
    '----------------- THREADED END -------------
    Dim _oFrmThreadedCastingYes As frmThreadedEndCastingYes           '09_12_2009    RAGAVA

    Dim _oFrmThreadedPortInTube As frmThreadedEndPortInTube           '09_12_2009    RAGAVA

    Dim _oFrmDesignAThreadedCasting As frmDesignAThreadedCasting      '09_12_2009    RAGAVA

    Dim _oFrmThreadedEndPortIntegral As frmThreadedEndPortIntegral

    Dim _oFrmBEThreadedEndCastingNo_PortIntegral As frmBEThreadedEndCastingNo_PortIntegral

    'TODO: ANUP 10-03-2010 02.40
    Dim _ofrmThreadedEndCastingYes_PortIntegral As frmThreadedEndCastingYes_PortIntegral
    '*******************

    '-------------------------------------------------
    '------------------Cross Tube-----------------
    '---------------Sandeep 01-12-09--------------

    Private _oFrmCTPortInTube As frmCTPortInTube

    Private _oFrmCTPortIntegral As frmCTPortIntegral

    Private _oFrmCTFabrication As frmCTFabrication

    Private _oFrmCTDesignACasting As frmCTDesignACasting

    Private _oFrmCTCastingYes As frmCTCastingYes

    Private _oFrmCTCastingNo_PortInTube As frmCTCastingNo_PortInTube

    Private _oFrmCTCastingNo_PortIntegral As frmCTCastingNo_PortIntegral

    Private _oFrmCTPortInTube2 As frmCTPortInTube2

    Private _oFrmCTPortIntegral2 As frmCTPortIntegral2

    Private _oFrmCTFabrication2 As frmCTFabrication2

    Private _oFrmCTDesignACasting2 As frmCTDesignACasting2

    Private _oFrmCTCastingYes2 As frmCTCastingYes2

    Private _oFrmCTCastingNo_PortInTube2 As frmCTCastingNo_PortInTube2

    Private _oFrmCTCastingNo_PortIntegral2 As frmCTCastingNo_PortIntegral2

    '-------------------------------------------------
    '------------------Single Lug Rod End-----------------
    '---------------Sandeep 21-12-09--------------

    Private _oFrmRESingleLugDetails As frmRESingleLugDetails

    Private _oFrmRESingleLugExistingNotSelected As frmRESingleLugExistingNotSelected


    '----------------- BH Rod End---------------------
    '------------------MANJULA 14-03-2012------------

    Private _oFrmREBHDetails As frmREBHDetails

    Private _oFrmREBHExistingNotSelected As frmREBHExistingNotSelected


    '--------------Flat With Chamfer Rod End---------------
    '--------------Anup 22-01-2010--------------------------

    Private _oFrmFlatWithChamfer As frmFlatWithChamfer



    '---------------------------------------------

    '---------------Drilled Pin Hole Rod End-----------------
    '---------------Anup 22-01-2010--------------------------

    Private _oFrmREDrilledPinHole As frmREDrilledPinHole

    '-------------------------------------------------------

    '-------------Threaded Rod _ Rod End---------------------------

    '-------------Anup 25-01-2010---------------------------
    Private _oFrmREThreadedRod As frmREThreadedRod

    '----------------------------------------------------------

    Private _oFrmRetractedLengthValidation As frmRetractedLengthValidation

    '-------------Cross Tube _ Rod End---------------------------

    '-------------Anup 25-01-2010---------------------------

    Private _oFrmRECrossTube As frmRECrossTube

    Private _oFrmCastingYes_RECT As frmCastingYes_RECT

    Private _oFrmCastingNo_RECT As frmCastingNo_RECT

    Private _oFrmDesignACasting_RECT As frmDesignACasting_RECT

    Private _oFrmFabrication_RECT As frmFabrication_RECT

    '31_08_2012   RAGAVA   Commented  Weldment

    'Private _oFrmRECrossTube2 As frmRECrossTube2

    'Private _oFrmCastingYes_RECT2 As frmCastingYes_RECT2

    'Private _oFrmCastingNo_RECT2 As frmCastingNo_RECT2

    'Private _oFrmDesignACasting_RECT2 As frmDesignACasting_RECT2

    'Private _oFrmFabrication_RECT2 As frmFabrication_RECT2

    '----------------------------------------------------------

    '-------------generate---------------------------

    '-------------sandeep 17-02-010---------------------------
    Private _oFrmGenerate As frmGenerate
    '----------------------------------------------------------

    ' ANUP 27-05-2010 01.51pm
    '-------------Contarct Details---------------------------
    Private _oFrmContractDetails As frmContractDetails
    Private _oFrmMonarchRevision As frmMonarchRevision
    '<<--9-12-2010 Aruna-->>
    Private _ofrmUpdateRecords As frmUpdateDatabaseRecords

#Region "REDoubleLug"

    Private _oFrmREDLCasting As frmREDLCasting

    Private _oFrmREDLThreaded As frmREDLThreaded

    Private _oFrmREDLWelded As frmREDLWelded

#End Region

#Region "Imports Forms"
    'A0308: ANUP 09-08-2010 02.15pm
    Private _oFrmImportBaseEnd As frmImportBaseEnd
    Private _oFrmImportRodEnd As frmImportRodEnd
#End Region


#End Region

#Region "General"

    'Dim Extractor As SldWorks_ExtractBitmap.SldWorks_ExtractBitmapClass       '27_10_2010   RAGAVA

    ' 009 start
    'new variable for batchrun   3-12-2013
    '------------------------------------------------------------------------------------------009
    Public batchrunEnable As Boolean = False
    Public MultiGenerate As Boolean = False
    Public RowCount As Integer = Nothing
    Public startTime As String = Nothing
    Public Fabricated_1_batchrun As Boolean = Nothing
    Public Fabricated_2_batchrun As Boolean = Nothing

    '------------------------------------------------------------------------------------------009
    '009 end

    Public _blnIsNewTube As Boolean = False         '09_10_2010  RAGAVA
    Public _blnIsNewRod As Boolean = False         '09_10_2010   RAGAVA
    Public METHDM_Cylinder_ToolsList As ArrayList  '09_10_2010   RAGAVA
    Public METHDM_ROD_ToolsList As ArrayList  '14_10_2010   RAGAVA
    Public METHDM_TUBE_ToolsList As ArrayList  '14_10_2010   RAGAVA
    Public PaintStandardCost As String = String.Empty             '09_10_2010   RAGAVA
    Public PistonCodeNumber As String = String.Empty   '10_10_2010    RAGAVA
    Public strExistingBaseEndPartCode As String = String.Empty   '12_10_2010   RAGAVA
    Public strExistingBaseEndPartCode2 As String = String.Empty   '15_05_2012   RAGAVA
    Public strExistingRodEndPartCode As String = String.Empty   '12_10_2010   RAGAVA
    Public strExistingRodEndPartCode2 As String = String.Empty   '24_07_2012   RAGAVA

    Private _blnShowCasting_Thru_ExistingRESL As Boolean
    Private _blnShowCasting_Thru_ExistingREBH As Boolean

    Private _aFormNavigationOrder As ArrayList

    Private _oCurrentForm As Object

    Private _btnNextClick As Button

    Private _btnBackClick As Button

    Private _aEmptyControlData As ArrayList

    Private _strCurrentWorkingDirectory As String = System.Environment.CurrentDirectory

    Private _strMotherExcelPath As String = _strCurrentWorkingDirectory + "\WELD_GUI_PARAMETERS.xls"

    Private _strchildExcelPath As String = String.Empty

    Private _oExApplication As Excel.Application

    Private _oExWorkbook As Excel.Workbook

    Private _oExSheetGUI As Excel.Worksheet

    Private _intGUIExcelRange As Integer

    Private _aAllControlData As ArrayList

    Private _aSingleFormControlData As ArrayList

    Private _lvwGeneralInformation As ListView

    Private _aGeneralInformation As ArrayList

    Private _rtxtMessages As RichTextBox

    Private _htControlValues_ToExcel As New Hashtable

    Public _strIsPortIntegral_or_PortInTube As String = String.Empty           '08_10_2010   RAGAVA

    Private _blnShowPortInTube_Thru_PortIntegral As Boolean

    Private _blnShowCastingNo_Thru_CastingYes As Boolean

    Private _blnShowCastingNo_Thru_CastingYes_RodEnd As Boolean

    Private _blnShowFabricNo_Thru_FabricYes As Boolean

    Private _htNewDesignPartParams As New Hashtable                   '09_11_2009  Ragava

    Private _blnNewCastingPartCopied As Boolean                           '11_11_2009  Ragava

    Private _blnNewBasePlugPartCopied As Boolean                           '04_12_2009   Ragava

    Private _blnNewSLCastingPartCopied As Boolean                           '16_11_2009  Ragava

    Private _blnNewUlugPartCopied As Boolean                           '12_11_2009  Ragava

    Private _dblBendRadius As Double                                '13_11_2009  Ragava

    Private _dblTopRadius As Double                                '13_11_2009  Ragava

    Private _rdbFabrication As RadioButton

    Private _rdbDesignANewCasting As RadioButton

    Private _blnGenerateULug As Boolean                      '20_11_2009   Ragava

    Private _blnGenerateCasting As Boolean                      '20_11_2009   Ragava

    Private _alParameters As ArrayList

    Public oExcelClass As New ExcelClass

    Private _oErrorObject As Exception

    Private _strErrorMessage As String = String.Empty

    Private _oFileStream As FileStream

    Private _oStreamWriter As StreamWriter

    Private _intLineNumber As Integer

    '15-02-10-Sandeep
    Private _blnShowWelded_Thru_Threaded_REDL As Boolean

    Private _blnShowCasting_Thru_Welded_REDL As Boolean

    Private _intPinHoleSize_Source As Integer

    Private _intPinHoleSize_source_RodEnd As Integer

    Private _strIsExact_NewDesign_Resize As String = String.Empty
    Private _strIsExact_NewDesign_Resize2 As String = String.Empty     '15_05_2012   RAGAVA

    Private _strIsExact_NewDesign_Resize_RodEnd As String = String.Empty
    Private _strIsExact_NewDesign_Resize_RodEnd2 As String = String.Empty '24_07_2012   RAGAVA

    Private _strFacricatedPart As String = String.Empty
    Private _strFacricatedPart2 As String = String.Empty        '15_05_2012  RAGAVA
    Public strManual_Lathe2 As String = String.Empty '24_07_2012   RAGAVA
    Public strManual_Lathe As String = String.Empty          '17_02_2010   RAGAVA

    Public strRE_Cast_Fabricated As String = String.Empty    '17_02_2010   RAGAVA
    '31_08_2012   RAGAVA   Commented  Weldment
    'Public strRE_Cast_Fabricated2 As String = String.Empty    '24_07_2012   RAGAVA

    Public dblDL_LugGap As Double                            '17_02_2010   RAGAVA
    Public dblDL_LugGap2 As Double                            '15_05_2012   RAGAVA

    Public strPortAngle_BaseEnd As String = String.Empty             '03_03_2010    RAGAVA
    Public strPortAngle_RodEnd As String = String.Empty             '27_09_2010    RAGAVA

    Private _blnRetractedLengthChangedFromRetractedValidationScreen As Boolean

    'Sandeep 01-03-10 3pm
    Private _blnCompressCylinderChecked As Boolean

    '&&&&&&&&&&&&&&


    ' ANUP 19-03-2010 11.00
    Private _oPnlChildFormArea As Panel
    '***********

    ''TODO: ANUP 23-03-2010 11.42
    'Private _blnSkipRetractedIfNegative As Boolean
    ''**************

    'TODO: Sunny 31-03-10
    Private _oMdiPictureBox As PictureBox

    Private _oCurrentForm_Object As Object

    'TODO: ANUP 31-05-2010 10.13am
    Private _oIsWeldSizeLess As Boolean
    '*********************

    'TODO:Sunny 04-06-10
    Private _blnPortIntegral_ExistingDetailsFound As Boolean

    ' ANUP 02-07-2010
    Private _blnIsCounterBoreOrNot As Boolean

    'TODO: ANUP 21-07-2010 02-15pm
    Private _blnIsPackPinsAndClipsInPlasticBagChecked As Boolean

    'ANUP 11-08-2010
    Private _blnIsPort_BaseEndOrRodEnd As Boolean
    Private _blnIsImportPortsButtonClicked As Boolean

    Public strCMSfileLocation As String = String.Empty          '13_08_2010    RAGAVA

    'ANUP 16-08-2010 
    Private _blnIsBaseEndPortImported As Boolean
    Private _blnIsRodEndPortImported As Boolean
    Private _blnIsBaseEndPartImported As Boolean
    Private _blnIsRodEndPartImported As Boolean
    Private _blnIsPlateClevisImported As Boolean

    'ANUP 07-10-2010 START
    Public _htPartCode_Purchase_ListViewSelectedValidation As New Hashtable
    'ANUP 07-10-2010 TILL HERE


    'ANUP 11-10-2010 START
    Private _blnIsValueChanged_Revision As Boolean
    'ANUP 11-10-2010 TILL HERE

    'ANUP 01-11-2010 START 
    Private _blnIsReleaseCylinderChecked As Boolean
    Private _strIsNew_Revision_Released As String
    'ANUP 01-11-2010 TILL HERE

    'anup 17-02-2011 start
    Private _blnIsExistingButNotReleased_TubeWeldment As Boolean
    Private _blnIsExistingButNotReleased_RodWeldment As Boolean
    Private _blnIsExistingButNotReleased_Lug_BE As Boolean
    Private _blnIsExistingButNotReleased_Lug_RE As Boolean
    Private _blnIsExistingButNotReleased_CylinderHead As Boolean
    Private _blnIsExistingButNotReleased_Piston As Boolean
    Private _blnIsExistingButNotReleased_CrossTube_BE As Boolean
    Private _blnIsExistingButNotReleased_CrossTube_RE As Boolean
    Private _blnIsExistingButNotReleased_Casting_BE As Boolean
    Private _blnIsExistingButNotReleased_Casting_RE As Boolean
    Private _blnIsExistingButNotReleased_StopTube As Boolean

    'anup 17-02-2011 till here

    Public METHDM_LUG_TUBE_HashTable As Hashtable  'anup 21-03-2011
    Public METHDM_LUG_ROD_HashTable As Hashtable   'anup 21-03-2011

    Private _prb As ProgressBar  'vamsi 11-06
    Private _oThreadProgressBarStepping As Threading.Thread  'vamsi 11-06


#Region "TextBox Objects"

    Private _oTxtLugThickness_BaseEnd As TextBox

    Private _oTxtCrossTubeWidth_BaseEnd As TextBox

    Private _oTxtSwingClearance_BaseEnd As TextBox

    Private _oTxtLugGap_BaseEnd As TextBox

    Private _oCmbBushingPinHoleSize_BaseEnd As ComboBox

    Private _oCmbPinHoleSize_BaseEnd As ComboBox

    Private _oTxtPinHoleSize_BaseEnd As TextBox

    Private _oCmbGreaseZercs_BaseEnd As ComboBox

    Private _oTxtAngleOfGreaseZercs1_BaseEnd As TextBox

    Private _oTxtAngleOfGreaseZercs2_BaseEnd As TextBox

    Private _oTxtLugThickness_RodEnd As TextBox

    Private _oTxtCrossTubeWidth_RodEnd As TextBox

    Private _oTxtSwingClearance_RodEnd As TextBox

    Private _oCmbPinHoleSize_RodEnd As ComboBox

    Private _oTxtPinHoleSize_RodEnd As TextBox

    Private _oCmbGreaseZercs_RodEnd As ComboBox

    Private _oTxtAngleOfGreaseZercs1_RodEnd As TextBox

    Private _oTxtAngleOfGreaseZercs2_RodEnd As TextBox

    Private _oTxtLugGap_RodEnd As TextBox

    Private _oCmbBushingPinHoleSize_RodEnd As ComboBox
    Private _oTxtRetractedLength As TextBox '25_02_2010 Anup
    '26_10_2010 Aruna Start
    Private _oTxtCrossTubeOffset_RodEnd As TextBox
    Private _oTxtCrossTubeOffset_BaseEnd As TextBox
    '26_10_2010 Aruna Ends

    Private _oCmbPortSizeBaseEnd As ComboBox 'Anup  26_02_2010

    ' ANUP 02-03-2010 12.01
    Private _oTxtBasePlugDia_BaseEnd As TextBox
    Private _oCmbPortType_BaseEnd As ComboBox
    Private _oTxtFirstPortOrientation_BaseEnd As TextBox
    Public FirstPortOrientation_RodEnd As String = String.Empty          '23_06_2010    RAGAVA
    Private _oTxtSecondPortOrientation_BaseEnd As TextBox

    ' ANUP 10-03-2010 03.42
    Private _oTxtThreadDiameter_BaseEnd As ComboBox
    Private _oTxtThreadLength_BaseEnd As TextBox
    '*********************


    ' ANUP 11-03-2010 02.44
    Private _oTxtToleranceUpperLimit_RodEnd As TextBox
    Private _oTxtToleranceLowerLimit_RodEnd As TextBox
    '*********************

    'TODO ANUP 02-04-2010 11.15
    Private _oCmbRodEndConfiguration_RodEnd As ComboBox
    '*********************

    Private _ocmbConnectionType_RodEnd As ComboBox 'Sunny 11-05-10

    'TODO: ANUP 05-07-2010 11.02am
    Private _oCmbWeldType_BaseEnd As ComboBox

    'TODO: ANUP 12-07-2010 12.03pm
    Private _oCmbBaseEndConfiguration As ComboBox

    'TODO: ANUP 23-07-2010 09.24am
    Private _oCmbPins_BaseEnd As ComboBox
    Private _oCmbPins_RodEnd As ComboBox

    Private _oCmbClips_BaseEnd As ComboBox
    Private _oCmbClips_RodEnd As ComboBox

    'anup 31-08-2010 
    Private _oTxtToleranceUpperLimit As TextBox
    Private _oTxtToleranceLowerLimit As TextBox

#End Region

#End Region

#End Region

#Region "Enums"

    'TODO: ANUP 28-04-2010 01.03pm
    Public Enum ConfigurationTypes
        CrossTube
        Ulug
        UGroove
        ULugLathe
    End Enum

    Public Enum WeldType
        ManualWeld
        LatheWeld
    End Enum

    Public Enum EOrderOfFormNavigationArraylist
        CurrentFormName = 0
        CurrentFormObject = 1
        PreviousFormObject = 2
        NextFormObject = 3
    End Enum

    Public Enum EExcel_GUIControls_Relation
        GUIControlName = 0
        ExcelCellContent = 1
        ExcelRange = 2
        GUIControlValue = 3
    End Enum

    Public Enum YeildStrengthConstants
        CrossTube = 30000
        CrossTube_Cast_NoPort = 36000
        CrossTube_Cast_FlushedPort = 36000
        CrossTube_Cast_RaisedPort = 36000
        CrossTube_RodEnd_Casting = 79000

        'MANJULA 16-02-12
        BH = 44000
        BH_Cast_NoPort = 36000
        BH_Cast_FlushedPort = 36000
        '*********

        SingleLug = 44000
        SingleLug_Cast_NoPort = 36000
        SingleLug_Cast_FlushedPort = 36000
        ULug = 44000
        DoubleLug_Cast_NoPort = 36000
        DoubleLug_Cast_FlushedPort = 36000
        BasePlug_NoPort = 30000
        BasePlug_withPort = 30000
    End Enum

    Public Enum PinHoleSourceTypes
        BushingPinHole = 0
        PinHoleCustom = 1
        PinHoleStandard = 2
    End Enum

    Private Enum StandardPinHoles
        UserSelectedPinHole = 0
        StandardPinHole = 1
    End Enum

#End Region

#Region "Properties"


#Region "REDoubleLug"
    Private _blnShowNewDesign_Thru_ExistingDesign_DoubleLug As Boolean
    Private _oFrmREDLExistingDesign As frmREDLExistingDesign

    Private _oFrmREDLNewDesign As frmREDLNewDesign

    'Sunny 03-06-10
    Public Property BlnShowNewDesign_Thru_ExistingDesign_DoubleLug() As Boolean
        Get
            Return _blnShowNewDesign_Thru_ExistingDesign_DoubleLug
        End Get
        Set(ByVal value As Boolean)
            _blnShowNewDesign_Thru_ExistingDesign_DoubleLug = value
        End Set
    End Property

    Public Property ObjFrmREDLExistingDesign() As frmREDLExistingDesign
        Get
            Return _oFrmREDLExistingDesign
        End Get
        Set(ByVal value As frmREDLExistingDesign)
            _oFrmREDLExistingDesign = value
        End Set
    End Property

    Public Property ObjFrmREDLNewDesign() As frmREDLNewDesign
        Get
            Return _oFrmREDLNewDesign
        End Get
        Set(ByVal value As frmREDLNewDesign)
            _oFrmREDLNewDesign = value
        End Set
    End Property

#End Region

#Region "Form Declarations Properties"

    '09_11_2009  Ragava
    Public ReadOnly Property IFLSolidWorksBaseClassObject() As Object
        Get
            If _oClsSolidWorksBaseClass Is Nothing Then
                _oClsSolidWorksBaseClass = New IFLSolidWorksClass
                _oClsSolidWorksBaseClass.ConnectSolidWorks()

            End If
            Return _oClsSolidWorksBaseClass
        End Get
    End Property

    Public Property ObjClsListViewMIL() As clsListViewMIL
        Get
            Return _oClsListViewMIL
        End Get
        Set(ByVal value As clsListViewMIL)
            _oClsListViewMIL = value
        End Set
    End Property

    Public Property ObjClsWeldedDataClass() As clsWeldedDataClass
        Get
            Return _oClsWeldedDataClass
        End Get
        Set(ByVal value As clsWeldedDataClass)
            _oClsWeldedDataClass = value
        End Set
    End Property

    Public Property ObjClsWeldedGlobalVariables() As clsWeldedGlobalVariables
        Get
            Return _oClsWeldedGlobalVariables
        End Get
        Set(ByVal value As clsWeldedGlobalVariables)
            _oClsWeldedGlobalVariables = value
        End Set
    End Property

    Public Property ObjClsExcelClass() As ExcelClass
        Get
            Return _oClsExcelClass
        End Get
        Set(ByVal value As ExcelClass)
            _oClsExcelClass = value
        End Set
    End Property

    '-----------------Primary------------------------

    Public Property ObjFrmPrimaryInputs() As frmPrimaryInputs
        Get
            Return _oFrmPrimaryInputs
        End Get
        Set(ByVal value As frmPrimaryInputs)
            _oFrmPrimaryInputs = value
        End Set
    End Property

    Public Property ObjFrmPistonDesign() As frmPistonDesign
        Get
            Return _oFrmPistonDesign
        End Get
        Set(ByVal value As frmPistonDesign)
            _oFrmPistonDesign = value
        End Set
    End Property

    Public Property ObjFrmHeadDesign() As frmHeadDesign
        Get
            Return _oFrmHeadDesign
        End Get
        Set(ByVal value As frmHeadDesign)
            _oFrmHeadDesign = value
        End Set
    End Property

    Public Property ObjFrmRodEndConfiguration() As frmRodEndConfiguration
        Get
            Return _oFrmRodEndConfiguration
        End Get
        Set(ByVal value As frmRodEndConfiguration)
            _oFrmRodEndConfiguration = value
        End Set
    End Property

    Public Property ObjFrmPin_Port_PaintAccessories() As frmPin_Port_PaintAccessories
        Get
            Return _oFrmPin_Port_PaintAccessories
        End Get
        Set(ByVal value As frmPin_Port_PaintAccessories)
            _oFrmPin_Port_PaintAccessories = value
        End Set
    End Property


    '08_12_2009   RAGAVA
    Public Property ObjFrmThreadedCastingYes() As frmThreadedEndCastingYes
        Get
            Return _oFrmThreadedCastingYes
        End Get
        Set(ByVal value As frmThreadedEndCastingYes)
            _oFrmThreadedCastingYes = value
        End Set
    End Property

    '09_12_2009   RAGAVA
    Public Property ObjFrmThreadedEndPortInTube() As frmThreadedEndPortInTube
        Get
            Return _oFrmThreadedPortInTube
        End Get
        Set(ByVal value As frmThreadedEndPortInTube)
            _oFrmThreadedPortInTube = value
        End Set
    End Property

    '09_12_2009   RAGAVA
    Public Property ObjFrmDesignAThreadedCasting() As frmDesignAThreadedCasting
        Get
            Return _oFrmDesignAThreadedCasting
        End Get
        Set(ByVal value As frmDesignAThreadedCasting)
            _oFrmDesignAThreadedCasting = value
        End Set
    End Property

    Public Property ObjFrmThreadedEndPortIntegral() As frmThreadedEndPortIntegral
        Get
            Return _oFrmThreadedEndPortIntegral
        End Get
        Set(ByVal value As frmThreadedEndPortIntegral)
            _oFrmThreadedEndPortIntegral = value
        End Set
    End Property

    Public Property ObjFrmBEThreadedEndCastingNo_PortIntegral() As frmBEThreadedEndCastingNo_PortIntegral
        Get
            Return _oFrmBEThreadedEndCastingNo_PortIntegral
        End Get
        Set(ByVal value As frmBEThreadedEndCastingNo_PortIntegral)
            _oFrmBEThreadedEndCastingNo_PortIntegral = value
        End Set
    End Property

    ' ANUP 10-03-2010 02.44
    Public Property ObjFrmThreadedEndCastingYes_PortIntegral() As frmThreadedEndCastingYes_PortIntegral
        Get
            Return _ofrmThreadedEndCastingYes_PortIntegral
        End Get
        Set(ByVal value As frmThreadedEndCastingYes_PortIntegral)
            _ofrmThreadedEndCastingYes_PortIntegral = value
        End Set
    End Property
    '*********************

    Public Property ObjFrmTubeDetails() As frmTubeDetails
        Get
            Return _oFrmTubeDetails
        End Get
        Set(ByVal value As frmTubeDetails)
            _oFrmTubeDetails = value
        End Set
    End Property

    Public Property ObjFrmPortDetails() As frmPortDetails
        Get
            Return _oFrmPortDetails
        End Get
        Set(ByVal value As frmPortDetails)
            _oFrmPortDetails = value
        End Set
    End Property

    '------------------------------------------------

    '-----------------Double Lug------------------------

    Public Property ObjFrmDLPortInTubeDetails() As frmDLPortInTubeDetails
        Get
            Return _oFrmDLPortInTubeDetails
        End Get
        Set(ByVal value As frmDLPortInTubeDetails)
            _oFrmDLPortInTubeDetails = value
        End Set
    End Property
    '26-04-2012 manjula
    Public Property ObjFrmDLPortInTubeDetails2() As frmDLPortInTubeDetails2
        Get
            Return _oFrmDLPortInTubeDetails2
        End Get
        Set(ByVal value As frmDLPortInTubeDetails2)
            _oFrmDLPortInTubeDetails2 = value
        End Set
    End Property

    Public Property ObjFrmDLCastingYes() As frmDLCastingYes
        Get
            Return _oFrmDLCastingYes
        End Get
        Set(ByVal value As frmDLCastingYes)
            _oFrmDLCastingYes = value
        End Set
    End Property

    Public Property ObjFrmDLCastingYes2() As frmDLCastingYes2
        Get
            Return _oFrmDLCastingYes2
        End Get
        Set(ByVal value As frmDLCastingYes2)
            _oFrmDLCastingYes2 = value
        End Set
    End Property

    Public Property ObjFrmDLCastingNo_PortInTube() As frmDLCastingNo_PortInTube
        Get
            Return _oFrmDLCastingNo_PortInTube
        End Get
        Set(ByVal value As frmDLCastingNo_PortInTube)
            _oFrmDLCastingNo_PortInTube = value
        End Set
    End Property
    Public Property ObjFrmDLCastingNo_PortInTube2() As frmDLCastingNo_PortInTube2
        Get
            Return _oFrmDLCastingNo_PortInTube2
        End Get
        Set(ByVal value As frmDLCastingNo_PortInTube2)
            _oFrmDLCastingNo_PortInTube2 = value
        End Set
    End Property

    Public Property ObjFrmDLPortIntegral() As frmDLPortIntegral
        Get
            Return _oFrmDLPortIntegral
        End Get
        Set(ByVal value As frmDLPortIntegral)
            _oFrmDLPortIntegral = value
        End Set
    End Property

    Public Property ObjFrmDLPortIntegral2() As frmDLPortIntegral2
        Get
            Return _oFrmDLPortIntegral2
        End Get
        Set(ByVal value As frmDLPortIntegral2)
            _oFrmDLPortIntegral2 = value
        End Set
    End Property

    Public Property ObjFrmDLFabrication() As frmDLFabrication
        Get
            Return _oFrmDLFabrication
        End Get
        Set(ByVal value As frmDLFabrication)
            _oFrmDLFabrication = value
        End Set
    End Property

    Public Property ObjFrmDLFabrication2() As frmDLFabrication2
        Get
            Return _oFrmDLFabrication2
        End Get
        Set(ByVal value As frmDLFabrication2)
            _oFrmDLFabrication2 = value
        End Set
    End Property
    '06_01_2012    RAGAVA
    Public Property objfrmFabricatedSingleLug() As frmFabricatedSingleLug_RetractedLength
        Get
            Return _oFrmFabricatedSingleLug
        End Get
        Set(ByVal value As frmFabricatedSingleLug_RetractedLength)
            _oFrmFabricatedSingleLug = value
        End Set
    End Property

    '30_05_2012   RAGAVA
    Public Property objfrmFabricatedSingleLug2() As frmFabricatedSingleLug_RetractedLength2
        Get
            Return _oFrmFabricatedSingleLug2
        End Get
        Set(ByVal value As frmFabricatedSingleLug_RetractedLength2)
            _oFrmFabricatedSingleLug2 = value
        End Set
    End Property

    '04_12_2009   RAGAVA
    Public Property ObjFrmDesignABasePlug() As frmDesignABasePlug
        Get
            Return _oFrmDesignABasePlug
        End Get
        Set(ByVal value As frmDesignABasePlug)
            _oFrmDesignABasePlug = value
        End Set
    End Property

    Public Property ObjFrmDLDesignACasting() As frmDLDesignACasting
        Get
            Return _oFrmDLDesignACasting
        End Get
        Set(ByVal value As frmDLDesignACasting)
            _oFrmDLDesignACasting = value
        End Set
    End Property

    Public Property ObjFrmDLDesignACasting2() As frmDLDesignACasting2
        Get
            Return _oFrmDLDesignACasting2
        End Get
        Set(ByVal value As frmDLDesignACasting2)
            _oFrmDLDesignACasting2 = value
        End Set
    End Property

    Public Property ObjFrmDLCastingNo_PortIntegral() As frmDLCastingNo_PortIntegral
        Get
            Return _oFrmDLCastingNo_PortIntegral
        End Get
        Set(ByVal value As frmDLCastingNo_PortIntegral)
            _oFrmDLCastingNo_PortIntegral = value
        End Set
    End Property

    ' 25-04-2012 manjula

    Public Property ObjFrmDLCastingNo_PortIntegral2() As frmDLCastingNo_PortIntegral2
        Get
            Return _oFrmDLCastingNo_PortIntegral2
        End Get
        Set(ByVal value As frmDLCastingNo_PortIntegral2)
            _oFrmDLCastingNo_PortIntegral2 = value
        End Set
    End Property

    '---------------------------------------------------
    'MANJULA ADDED
    '-----------------BH------------------------

    Public Property ObjFrmBHCastingNo_PortIntegral() As frmBHCastingNo_PortIntegral
        Get
            Return _oFrmBHCastingNo_PortIntegral
        End Get
        Set(ByVal value As frmBHCastingNo_PortIntegral)
            _oFrmBHCastingNo_PortIntegral = value
        End Set
    End Property

    Public Property ObjFrmBHCastingNo_PortInTube() As frmBHCastingNo_PortInTube
        Get
            Return _oFrmBHCastingNo_PortInTube
        End Get
        Set(ByVal value As frmBHCastingNo_PortInTube)
            _oFrmBHCastingNo_PortInTube = value
        End Set
    End Property

    Public Property ObjFrmBHCastingYes() As frmBHCastingYes
        Get
            Return _oFrmBHCastingYes
        End Get
        Set(ByVal value As frmBHCastingYes)
            _oFrmBHCastingYes = value
        End Set
    End Property

    Public Property ObjFrmBHDesignACasting() As frmBHDesignACasting
        Get
            Return _oFrmBHDesignACasting
        End Get
        Set(ByVal value As frmBHDesignACasting)
            _oFrmBHDesignACasting = value
        End Set
    End Property

    Public Property ObjFrmBHFabrication() As frmBHFabrication
        Get
            Return _oFrmBHFabrication
        End Get
        Set(ByVal value As frmBHFabrication)
            _oFrmBHFabrication = value
        End Set
    End Property

    Public Property ObjFrmBHPortIntegral() As frmBHPortIntegral
        Get
            Return _oFrmBHPortIntegral
        End Get
        Set(ByVal value As frmBHPortIntegral)
            _oFrmBHPortIntegral = value
        End Set
    End Property

    Public Property ObjFrmBHPortinTube() As frmBHPortInTube
        Get
            Return _oFrmBHPortinTube
        End Get
        Set(ByVal value As frmBHPortInTube)
            _oFrmBHPortinTube = value
        End Set
    End Property

    Public Property ObjFrmBHCastingNo_PortIntegral2() As frmBHCastingNo_PortIntegral2
        Get
            Return _oFrmBHCastingNo_PortIntegral2
        End Get
        Set(ByVal value As frmBHCastingNo_PortIntegral2)
            _oFrmBHCastingNo_PortIntegral2 = value
        End Set
    End Property

    Public Property ObjFrmBHCastingNo_PortInTube2() As frmBHCastingNo_PortInTube2
        Get
            Return _oFrmBHCastingNo_PortInTube2
        End Get
        Set(ByVal value As frmBHCastingNo_PortInTube2)
            _oFrmBHCastingNo_PortInTube2 = value
        End Set
    End Property

    Public Property ObjFrmBHCastingYes2() As frmBHCastingYes2
        Get
            Return _oFrmBHCastingYes2
        End Get
        Set(ByVal value As frmBHCastingYes2)
            _oFrmBHCastingYes2 = value
        End Set
    End Property

    Public Property ObjFrmBHDesignACasting2() As frmBHDesignACasting2
        Get
            Return _oFrmBHDesignACasting2
        End Get
        Set(ByVal value As frmBHDesignACasting2)
            _oFrmBHDesignACasting2 = value
        End Set
    End Property

    Public Property ObjFrmBHFabrication2() As frmBHFabrication2
        Get
            Return _oFrmBHFabrication2
        End Get
        Set(ByVal value As frmBHFabrication2)
            _oFrmBHFabrication2 = value
        End Set
    End Property

    Public Property ObjFrmBHPortIntegral2() As frmBHPortIntegral2
        Get
            Return _oFrmBHPortIntegral2
        End Get
        Set(ByVal value As frmBHPortIntegral2)
            _oFrmBHPortIntegral2 = value
        End Set
    End Property

    Public Property ObjFrmBHPortinTube2() As frmBHPortInTube2
        Get
            Return _oFrmBHPortinTube2
        End Get
        Set(ByVal value As frmBHPortInTube2)
            _oFrmBHPortinTube2 = value
        End Set
    End Property
    '---------------------------------------------------



    '-----------------Single Lug------------------------

    Public Property ObjFrmSLCastingNo_PortIntegral() As frmSLCastingNo_PortIntegral
        Get
            Return _oFrmSLCastingNo_PortIntegral
        End Get
        Set(ByVal value As frmSLCastingNo_PortIntegral)
            _oFrmSLCastingNo_PortIntegral = value
        End Set
    End Property

    Public Property ObjFrmSLCastingNo_PortInTube() As frmSLCastingNo_PortInTube
        Get
            Return _oFrmSLCastingNo_PortInTube
        End Get
        Set(ByVal value As frmSLCastingNo_PortInTube)
            _oFrmSLCastingNo_PortInTube = value
        End Set
    End Property

    Public Property ObjFrmSLCastingYes() As frmSLCastingYes
        Get
            Return _oFrmSLCastingYes
        End Get
        Set(ByVal value As frmSLCastingYes)
            _oFrmSLCastingYes = value
        End Set
    End Property

    Public Property ObjFrmSLDesignACasting() As frmSLDesignACasting
        Get
            Return _oFrmSLDesignACasting
        End Get
        Set(ByVal value As frmSLDesignACasting)
            _oFrmSLDesignACasting = value
        End Set
    End Property

    Public Property ObjFrmSLFabrication() As frmSLFabrication
        Get
            Return _oFrmSLFabrication
        End Get
        Set(ByVal value As frmSLFabrication)
            _oFrmSLFabrication = value
        End Set
    End Property

    Public Property ObjFrmSLPortIntegral() As frmSLPortIntegral
        Get
            Return _oFrmSLPortIntegral
        End Get
        Set(ByVal value As frmSLPortIntegral)
            _oFrmSLPortIntegral = value
        End Set
    End Property

    Public Property ObjFrmSLPortinTube() As frmSLPortinTube
        Get
            Return _oFrmSLPortinTube
        End Get
        Set(ByVal value As frmSLPortinTube)
            _oFrmSLPortinTube = value
        End Set
    End Property

    Public Property ObjFrmSLCastingNo_PortIntegral2() As frmSLCastingNo_PortIntegral2
        Get
            Return _oFrmSLCastingNo_PortIntegral2
        End Get
        Set(ByVal value As frmSLCastingNo_PortIntegral2)
            _oFrmSLCastingNo_PortIntegral2 = value
        End Set
    End Property

    Public Property ObjFrmSLCastingNo_PortInTube2() As frmSLCastingNo_PortInTube2
        Get
            Return _oFrmSLCastingNo_PortInTube2
        End Get
        Set(ByVal value As frmSLCastingNo_PortInTube2)
            _oFrmSLCastingNo_PortInTube2 = value
        End Set
    End Property

    Public Property ObjFrmSLCastingYes2() As frmSLCastingYes2
        Get
            Return _oFrmSLCastingYes2
        End Get
        Set(ByVal value As frmSLCastingYes2)
            _oFrmSLCastingYes2 = value
        End Set
    End Property

    Public Property ObjFrmSLDesignACasting2() As frmSLDesignACasting2
        Get
            Return _oFrmSLDesignACasting2
        End Get
        Set(ByVal value As frmSLDesignACasting2)
            _oFrmSLDesignACasting2 = value
        End Set
    End Property

    Public Property ObjFrmSLFabrication2() As frmSLFabrication2
        Get
            Return _oFrmSLFabrication2
        End Get
        Set(ByVal value As frmSLFabrication2)
            _oFrmSLFabrication2 = value
        End Set
    End Property

    Public Property ObjFrmSLPortIntegral2() As frmSLPortIntegral2
        Get
            Return _oFrmSLPortIntegral2
        End Get
        Set(ByVal value As frmSLPortIntegral2)
            _oFrmSLPortIntegral2 = value
        End Set
    End Property

    Public Property ObjFrmSLPortinTube2() As frmSLPortinTube2
        Get
            Return _oFrmSLPortinTube2
        End Get
        Set(ByVal value As frmSLPortinTube2)
            _oFrmSLPortinTube2 = value
        End Set
    End Property

    '---------------------------------------------------

    '-----------------Clevis Plate------------------------

    Public Property ObjFrmConPlateClevis() As frmConPlateClevis
        Get
            Return _oFrmConPlateClevis
        End Get
        Set(ByVal value As frmConPlateClevis)
            _oFrmConPlateClevis = value
        End Set
    End Property

    '---------------------------------------------------

    '-----------------Base Plug------------------------

    Public Property ObjFrmBasePlugCastingYes() As frmBasePlugCastingYes
        Get
            Return _oFrmBasePlugCastingYes
        End Get
        Set(ByVal value As frmBasePlugCastingYes)
            _oFrmBasePlugCastingYes = value
        End Set
    End Property

    Public Property ObjFrmBasePlugPortInTube() As frmBasePlugPortInTube
        Get
            Return _oFrmBasePlugPortInTube
        End Get
        Set(ByVal value As frmBasePlugPortInTube)
            _oFrmBasePlugPortInTube = value
        End Set
    End Property

    Public Property ObjFrmBasePlugPortIntegral() As frmBasePlugPortIntegral
        Get
            Return _oFrmBasePlugPortIntegral
        End Get
        Set(ByVal value As frmBasePlugPortIntegral)
            _oFrmBasePlugPortIntegral = value
        End Set
    End Property



    Public Property ObjFrmBasePlugCastingYesPortIntegral() As frmBasePlugCastingYesPortIntegral
        Get
            Return _oFrmBasePlugCastingYesPortIntegral
        End Get
        Set(ByVal value As frmBasePlugCastingYesPortIntegral)
            _oFrmBasePlugCastingYesPortIntegral = value
        End Set
    End Property

    Public Property ObjFrmBasePlugCastingNoPortIntegral() As frmBasePlugCastingNoPortIntegral
        Get
            Return _oFrmBasePlugCastingNoPortIntegral
        End Get
        Set(ByVal value As frmBasePlugCastingNoPortIntegral)
            _oFrmBasePlugCastingNoPortIntegral = value
        End Set
    End Property
    '*********************
    '04_12_2009   Ragava
    Public Property NewBasePlugPartCopied() As Boolean
        Get
            Return _blnNewBasePlugPartCopied
        End Get
        Set(ByVal value As Boolean)
            _blnNewBasePlugPartCopied = value
        End Set
    End Property
    '---------------------------------------------------   


    '-----------------Cross Tube------------------------

    Public Property ObjFrmCTPortInTube() As frmCTPortInTube
        Get
            Return _oFrmCTPortInTube
        End Get
        Set(ByVal value As frmCTPortInTube)
            _oFrmCTPortInTube = value
        End Set
    End Property

    Public Property ObjFrmCTPortIntegral() As frmCTPortIntegral
        Get
            Return _oFrmCTPortIntegral
        End Get
        Set(ByVal value As frmCTPortIntegral)
            _oFrmCTPortIntegral = value
        End Set
    End Property

    Public Property ObjFrmCTFabrication() As frmCTFabrication
        Get
            Return _oFrmCTFabrication
        End Get
        Set(ByVal value As frmCTFabrication)
            _oFrmCTFabrication = value
        End Set
    End Property

    Public Property ObjFrmCTDesignACasting() As frmCTDesignACasting
        Get
            Return _oFrmCTDesignACasting
        End Get
        Set(ByVal value As frmCTDesignACasting)
            _oFrmCTDesignACasting = value
        End Set
    End Property

    Public Property ObjFrmCTCastingYes() As frmCTCastingYes
        Get
            Return _oFrmCTCastingYes
        End Get
        Set(ByVal value As frmCTCastingYes)
            _oFrmCTCastingYes = value
        End Set
    End Property

    Public Property ObjFrmCTCastingNo_PortInTube() As frmCTCastingNo_PortInTube
        Get
            Return _oFrmCTCastingNo_PortInTube
        End Get
        Set(ByVal value As frmCTCastingNo_PortInTube)
            _oFrmCTCastingNo_PortInTube = value
        End Set
    End Property

    Public Property ObjFrmCTCastingNo_PortIntegral() As frmCTCastingNo_PortIntegral
        Get
            Return _oFrmCTCastingNo_PortIntegral
        End Get
        Set(ByVal value As frmCTCastingNo_PortIntegral)
            _oFrmCTCastingNo_PortIntegral = value
        End Set
    End Property


    Public Property ObjFrmCTPortInTube2() As frmCTPortInTube2
        Get
            Return _oFrmCTPortInTube2
        End Get
        Set(ByVal value As frmCTPortInTube2)
            _oFrmCTPortInTube2 = value
        End Set
    End Property

    Public Property ObjFrmCTPortIntegral2() As frmCTPortIntegral2
        Get
            Return _oFrmCTPortIntegral2
        End Get
        Set(ByVal value As frmCTPortIntegral2)
            _oFrmCTPortIntegral2 = value
        End Set
    End Property

    Public Property ObjFrmCTFabrication2() As frmCTFabrication2
        Get
            Return _oFrmCTFabrication2
        End Get
        Set(ByVal value As frmCTFabrication2)
            _oFrmCTFabrication2 = value
        End Set
    End Property

    Public Property ObjFrmCTDesignACasting2() As frmCTDesignACasting2
        Get
            Return _oFrmCTDesignACasting2
        End Get
        Set(ByVal value As frmCTDesignACasting2)
            _oFrmCTDesignACasting2 = value
        End Set
    End Property

    Public Property ObjFrmCTCastingYes2() As frmCTCastingYes2
        Get
            Return _oFrmCTCastingYes2
        End Get
        Set(ByVal value As frmCTCastingYes2)
            _oFrmCTCastingYes2 = value
        End Set
    End Property

    Public Property ObjFrmCTCastingNo_PortInTube2() As frmCTCastingNo_PortInTube2
        Get
            Return _oFrmCTCastingNo_PortInTube2
        End Get
        Set(ByVal value As frmCTCastingNo_PortInTube2)
            _oFrmCTCastingNo_PortInTube2 = value
        End Set
    End Property

    Public Property ObjFrmCTCastingNo_PortIntegral2() As frmCTCastingNo_PortIntegral2
        Get
            Return _oFrmCTCastingNo_PortIntegral2
        End Get
        Set(ByVal value As frmCTCastingNo_PortIntegral2)
            _oFrmCTCastingNo_PortIntegral2 = value
        End Set
    End Property

    '--------------------------------------------------

    '-----------------Rod End Single Lug---------------

    Public Property ObjFrmRESLDetails() As frmRESingleLugDetails
        Get
            Return _oFrmRESingleLugDetails
        End Get
        Set(ByVal value As frmRESingleLugDetails)
            _oFrmRESingleLugDetails = value
        End Set
    End Property

    Public Property ObjFrmRESingleLugExistingNotSelected() As frmRESingleLugExistingNotSelected
        Get
            Return _oFrmRESingleLugExistingNotSelected
        End Get
        Set(ByVal value As frmRESingleLugExistingNotSelected)
            _oFrmRESingleLugExistingNotSelected = value
        End Set
    End Property

    '--------------------------------------------------
    'MANJULA ADDED
    '-----------------Rod End BH---------------

    Public Property ObjFrmREBHDetails() As frmREBHDetails
        Get
            Return _oFrmREBHDetails
        End Get
        Set(ByVal value As frmREBHDetails)
            _oFrmREBHDetails = value
        End Set
    End Property

    Public Property ObjFrmREBHExistingNotSelected() As frmREBHExistingNotSelected
        Get
            Return _oFrmREBHExistingNotSelected
        End Get
        Set(ByVal value As frmREBHExistingNotSelected)
            _oFrmREBHExistingNotSelected = value
        End Set
    End Property

    '--------------------------------------------------

    '--------------------------------------------------

    '-----------------Rod End Flat With Chamfer-------------

    Public Property ObjFrmFlatWithChamper() As frmFlatWithChamfer
        Get
            Return _oFrmFlatWithChamfer
        End Get
        Set(ByVal value As frmFlatWithChamfer)
            _oFrmFlatWithChamfer = value
        End Set
    End Property

    '---------------------------------------------------------

    '--------------Drilled Pin Hole Rod End-------------------

    Public Property ObjFrmREDrilledPinHole() As frmREDrilledPinHole
        Get
            Return _oFrmREDrilledPinHole
        End Get
        Set(ByVal value As frmREDrilledPinHole)
            _oFrmREDrilledPinHole = value
        End Set
    End Property

    '---------------------------------------------------------

    '------------------Threded Rod _ Rod End------------------
    Public Property ObjFrmREThreadedRod() As frmREThreadedRod
        Get
            Return _oFrmREThreadedRod
        End Get
        Set(ByVal value As frmREThreadedRod)
            _oFrmREThreadedRod = value
        End Set
    End Property

    Public Property ObjFrmRetractedLengthValidation() As frmRetractedLengthValidation
        Get
            Return _oFrmRetractedLengthValidation
        End Get
        Set(ByVal value As frmRetractedLengthValidation)
            _oFrmRetractedLengthValidation = value
        End Set
    End Property

    '-----------------------------------------------------------

    '-------------------CRoss Tube - Rod End--------------------

    Public Property ObjFrmRECrossTube() As frmRECrossTube
        Get
            Return _oFrmRECrossTube
        End Get
        Set(ByVal value As frmRECrossTube)
            _oFrmRECrossTube = value
        End Set
    End Property

    Public Property ObjFrmCastingYes_RECT() As frmCastingYes_RECT
        Get
            Return _oFrmCastingYes_RECT
        End Get
        Set(ByVal value As frmCastingYes_RECT)
            _oFrmCastingYes_RECT = value
        End Set
    End Property

    Public Property ObjFrmCastingNo_RECT() As frmCastingNo_RECT
        Get
            Return _oFrmCastingNo_RECT
        End Get
        Set(ByVal value As frmCastingNo_RECT)
            _oFrmCastingNo_RECT = value
        End Set
    End Property

    Public Property ObjFrmDesignACasting_RECT() As frmDesignACasting_RECT
        Get
            Return _oFrmDesignACasting_RECT
        End Get
        Set(ByVal value As frmDesignACasting_RECT)
            _oFrmDesignACasting_RECT = value
        End Set
    End Property

    Public Property ObjFrmFabrication_RECT() As frmFabrication_RECT
        Get
            Return _oFrmFabrication_RECT
        End Get
        Set(ByVal value As frmFabrication_RECT)
            _oFrmFabrication_RECT = value
        End Set
    End Property

    '31_08_2012   RAGAVA   Commented  Weldment
    'Public Property ObjFrmRECrossTube2() As frmRECrossTube2
    '    Get
    '        Return _oFrmRECrossTube2
    '    End Get
    '    Set(ByVal value As frmRECrossTube2)
    '        _oFrmRECrossTube2 = value
    '    End Set
    'End Property
    '31_08_2012   RAGAVA   Commented  Weldment
    'Public Property ObjFrmCastingYes_RECT2() As frmCastingYes_RECT2
    '    Get
    '        Return _oFrmCastingYes_RECT2
    '    End Get
    '    Set(ByVal value As frmCastingYes_RECT2)
    '        _oFrmCastingYes_RECT2 = value
    '    End Set
    'End Property
    '31_08_2012   RAGAVA   Commented  Weldment
    'Public Property ObjFrmCastingNo_RECT2() As frmCastingNo_RECT2
    '    Get
    '        Return _oFrmCastingNo_RECT2
    '    End Get
    '    Set(ByVal value As frmCastingNo_RECT2)
    '        _oFrmCastingNo_RECT2 = value
    '    End Set
    'End Property
    '31_08_2012   RAGAVA   Commented  Weldment
    'Public Property ObjFrmDesignACasting_RECT2() As frmDesignACasting_RECT2
    '    Get
    '        Return _oFrmDesignACasting_RECT2
    '    End Get
    '    Set(ByVal value As frmDesignACasting_RECT2)
    '        _oFrmDesignACasting_RECT2 = value
    '    End Set
    'End Property
    '31_08_2012   RAGAVA   Commented  Weldment
    'Public Property ObjFrmFabrication_RECT2() As frmFabrication_RECT2
    '    Get
    '        Return _oFrmFabrication_RECT2
    '    End Get
    '    Set(ByVal value As frmFabrication_RECT2)
    '        _oFrmFabrication_RECT2 = value
    '    End Set
    'End Property

    ''-----------------------------------------------------------------------

    Public Property ObjFrmGenerate() As frmGenerate
        Get
            Return _oFrmGenerate
        End Get
        Set(ByVal value As frmGenerate)
            _oFrmGenerate = value
        End Set
    End Property

    ' ANUP 27-05-2010 01.51pm
    '-------------Contarct Details---------------------------

    Public Property ObjFrmContractDetails() As frmContractDetails
        Get
            Return _oFrmContractDetails
        End Get
        Set(ByVal value As frmContractDetails)
            _oFrmContractDetails = value
        End Set
    End Property


    Public Property ObjFrmMonarchRevision() As frmMonarchRevision
        Get
            Return _oFrmMonarchRevision
        End Get
        Set(ByVal value As frmMonarchRevision)
            _oFrmMonarchRevision = value
        End Set
    End Property

#Region "REDoubleLug"

    Public Property ObjFrmREDLCasting() As frmREDLCasting
        Get
            Return _oFrmREDLCasting
        End Get
        Set(ByVal value As frmREDLCasting)
            _oFrmREDLCasting = value
        End Set
    End Property

    Public Property ObjFrmREDLThreaded() As frmREDLThreaded
        Get
            Return _oFrmREDLThreaded
        End Get
        Set(ByVal value As frmREDLThreaded)
            _oFrmREDLThreaded = value
        End Set
    End Property

    Public Property ObjFrmREDLWelded() As frmREDLWelded
        Get
            Return _oFrmREDLWelded
        End Get
        Set(ByVal value As frmREDLWelded)
            _oFrmREDLWelded = value
        End Set
    End Property

#End Region

#Region "Imports Forms"
    'A0308: ANUP 09-08-2010 02.15pm
    Public Property ObjFrmImportBaseEnd() As frmImportBaseEnd
        Get
            Return _oFrmImportBaseEnd
        End Get
        Set(ByVal value As frmImportBaseEnd)
            _oFrmImportBaseEnd = value
        End Set
    End Property

    Public Property ObjFrmImportRodEnd() As frmImportRodEnd
        Get
            Return _oFrmImportRodEnd
        End Get
        Set(ByVal value As frmImportRodEnd)
            _oFrmImportRodEnd = value
        End Set
    End Property

#End Region

#End Region

#Region "General Properties"


    '12_10_2010    RAGAVA
    Public ReadOnly Property RodSequence_Details() As Hashtable
        Get
            RodSequence_Details = New Hashtable
            RodSequence_Details.Add("WC093", 10)
            RodSequence_Details.Add("WC122", 20)
            RodSequence_Details.Add("WC123", 20)
            RodSequence_Details.Add("WC553", 40)
            RodSequence_Details.Add("WC550", 40)        '03_11_2010   RAGAVA
            RodSequence_Details.Add("WC550_1", 41)      '03_11_2010   RAGAVA
            RodSequence_Details.Add("WC199", 42)
        End Get
    End Property

    Public TubeSequence_Details As New Hashtable        '12_10_20110    RAGAVA

    Public Property ShowCasting_Thru_ExistingRESL() As Boolean
        Get
            Return _blnShowCasting_Thru_ExistingRESL
        End Get
        Set(ByVal value As Boolean)
            _blnShowCasting_Thru_ExistingRESL = value
        End Set
    End Property


    Public Property ShowCasting_Thru_ExistingREBH() As Boolean
        Get
            Return _blnShowCasting_Thru_ExistingREBH
        End Get
        Set(ByVal value As Boolean)
            _blnShowCasting_Thru_ExistingREBH = value
        End Set
    End Property

    '20_11_2009  Ragava
    Public Property GenerateULug() As Boolean
        Get
            Return _blnGenerateULug
        End Get
        Set(ByVal value As Boolean)
            _blnGenerateULug = value
        End Set
    End Property

    '20_11_2009  Ragava
    Public Property GenerateCasting() As Boolean
        Get
            Return _blnGenerateCasting
        End Get
        Set(ByVal value As Boolean)
            _blnGenerateCasting = value
        End Set
    End Property

    '13_11_2009  Ragava
    Public Property BendRadius() As Double
        Get
            Return _dblBendRadius
        End Get
        Set(ByVal value As Double)
            _dblBendRadius = value
        End Set
    End Property

    '13_11_2009  Ragava
    Public Property TopRadius() As Double
        Get
            Return _dblTopRadius
        End Get
        Set(ByVal value As Double)
            _dblTopRadius = value
        End Set
    End Property

    '12_11_2009  Ragava
    Public Property NewUlugPartCopied() As Boolean
        Get
            Return _blnNewUlugPartCopied
        End Get
        Set(ByVal value As Boolean)
            _blnNewUlugPartCopied = value
        End Set
    End Property

    '11_11_2009  Ragava
    Public Property NewSLCastingPartCopied() As Boolean
        Get
            Return _blnNewSLCastingPartCopied
        End Get
        Set(ByVal value As Boolean)
            _blnNewSLCastingPartCopied = value
        End Set
    End Property

    '11_11_2009  Ragava
    Public Property NewCastingPartCopied() As Boolean
        Get
            Return _blnNewCastingPartCopied
        End Get
        Set(ByVal value As Boolean)
            _blnNewCastingPartCopied = value
        End Set
    End Property

    Public Property IsPortIntegral_or_PortInTube() As String
        Get
            Return _strIsPortIntegral_or_PortInTube
        End Get
        Set(ByVal value As String)
            _strIsPortIntegral_or_PortInTube = value
        End Set
    End Property

    Public Property ShowPortInTube_Thru_PortIntegral() As Boolean
        Get
            Return _blnShowPortInTube_Thru_PortIntegral
        End Get
        Set(ByVal value As Boolean)
            _blnShowPortInTube_Thru_PortIntegral = value
        End Set
    End Property

    Public Property ShowCastingNo_Thru_CastingYes() As Boolean
        Get
            Return _blnShowCastingNo_Thru_CastingYes
        End Get
        Set(ByVal value As Boolean)
            _blnShowCastingNo_Thru_CastingYes = value
        End Set
    End Property

    Public Property ShowCastingNo_Thru_CastingYes_RodEnd() As Boolean
        Get
            Return _blnShowCastingNo_Thru_CastingYes_RodEnd
        End Get
        Set(ByVal value As Boolean)
            _blnShowCastingNo_Thru_CastingYes_RodEnd = value
        End Set
    End Property

    Public ReadOnly Property FormNavigationOrder() As ArrayList
        Get
            FormNavigationOrder = New ArrayList


            'ANUP 27-05-2010 01.51pm
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.New_Revision = "New'" Then
                FormNavigationOrder.Add(New Object(3) {"frmContractDetails", _oFrmContractDetails, Nothing, _oFrmPrimaryInputs})   ' current, previous , next
                FormNavigationOrder.Add(New Object(3) {"frmPrimaryInputs", _oFrmPrimaryInputs, _oFrmContractDetails, _oFrmPistonDesign})
            Else
                FormNavigationOrder.Add(New Object(3) {"frmMonarchRevision", _oFrmMonarchRevision, Nothing, _oFrmPrimaryInputs})
                FormNavigationOrder.Add(New Object(3) {"frmPrimaryInputs", _oFrmPrimaryInputs, _oFrmMonarchRevision, _oFrmPistonDesign})
            End If
            '*****************
            FormNavigationOrder.Add(New Object(3) {"frmPistonDesign", _oFrmPistonDesign, _oFrmPrimaryInputs, _oFrmHeadDesign})
            FormNavigationOrder.Add(New Object(3) {"frmHeadDesign", _oFrmHeadDesign, _oFrmPistonDesign, _oFrmTubeDetails})
            FormNavigationOrder.Add(New Object(3) {"frmTubeDetails", _oFrmTubeDetails, _oFrmHeadDesign, _oFrmPortDetails})

            ''*******************DoubleLub**************************************
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" Then
                'Try

                '    If _strIsPortIntegral_or_PortInTube = "Port Integral" Then
                '        FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmDLPortIntegral})
                '        If PortIntegral_ExistingDetailsFound Then
                '            If ShowCastingNo_Thru_CastingYes Then
                '                FormNavigationOrder.Add(New Object(3) {"frmDLPortIntegral", _oFrmDLPortIntegral, _oFrmPortDetails, _oFrmDLCastingNo_PortIntegral})
                '                FormNavigationOrder.Add(New Object(3) {"frmDLCastingNo_PortIntegral", _oFrmDLCastingNo_PortIntegral, _oFrmDLPortIntegral, _oFrmRodEndConfiguration})
                '                RodEndNavigationOrder(_oFrmDLCastingNo_PortIntegral, FormNavigationOrder)
                '            Else
                '                '13_03_2012  RAGAVA
                '                'FormNavigationOrder.Add(New Object(3) {"frmDLPortIntegral", _oFrmDLPortIntegral, _oFrmPortDetails, _oFrmRodEndConfiguration})
                '                FormNavigationOrder.Add(New Object(3) {"frmDLPortIntegral", _oFrmDLPortIntegral, _oFrmPortDetails, _oFrmDLCastingNo_PortIntegral})
                '                FormNavigationOrder.Add(New Object(3) {"frmDLCastingNo_PortIntegral", _oFrmDLCastingNo_PortIntegral, _oFrmDLPortIntegral, _oFrmRodEndConfiguration})
                '                'Till  Here
                '                RodEndNavigationOrder(_oFrmDLPortIntegral, FormNavigationOrder)
                '            End If
                '        Else
                '            FormNavigationOrder.Add(New Object(3) {"frmDLPortIntegral", _oFrmDLPortIntegral, _oFrmPortDetails, _oFrmRodEndConfiguration})
                '            RodEndNavigationOrder(_oFrmDLPortIntegral, FormNavigationOrder)
                '        End If
                '    ElseIf _strIsPortIntegral_or_PortInTube = "Port In Tube" Then
                '        FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmDLPortInTubeDetails})
                '        If ShowCastingNo_Thru_CastingYes Then
                '            ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.rdbDesignACasting.Enabled = True
                '            FormNavigationOrder.Add(New Object(3) {"frmDLPortInTubeDetails", _oFrmDLPortInTubeDetails, _oFrmPortDetails, _oFrmDLCastingNo_PortInTube})
                '            FormNavigationOrder.Add(New Object(3) {"frmDLCastingNo_PortInTube", _oFrmDLCastingNo_PortInTube, _oFrmDLPortInTubeDetails, _oFrmRodEndConfiguration})
                '            RodEndNavigationOrder(_oFrmDLCastingNo_PortInTube, FormNavigationOrder)
                '    Else
                '        '13_03_2012  RAGAVA
                '        'FormNavigationOrder.Add(New Object(3) {"frmDLPortInTubeDetails", _oFrmDLPortInTubeDetails, _oFrmPortDetails, _oFrmRodEndConfiguration})
                '            FormNavigationOrder.Add(New Object(3) {"frmDLPortInTubeDetails", _oFrmDLPortInTubeDetails, _oFrmPortDetails, _oFrmDLCastingNo_PortInTube})
                '            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                '                ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.rdbDesignACasting.Enabled = False        '15_03_2012  RAGAVA
                '            End If
                '            FormNavigationOrder.Add(New Object(3) {"frmDLCastingNo_PortInTube", _oFrmDLCastingNo_PortInTube, _oFrmDLPortInTubeDetails, _oFrmRodEndConfiguration})
                '            'Till Here
                '            RodEndNavigationOrder(_oFrmDLPortInTubeDetails, FormNavigationOrder)
                '            End If
                '        End If

                'Catch ex As Exception

                'End Try


                'priyanka
                ''Try
                ''    If _strIsPortIntegral_or_PortInTube = "Port Integral" Then
                ''        FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmDLPortIntegral})
                ''        If PortIntegral_ExistingDetailsFound Then
                ''            If ShowCastingNo_Thru_CastingYes Then
                ''                FormNavigationOrder.Add(New Object(3) {"frmDLPortIntegral", _oFrmDLPortIntegral, _oFrmPortDetails, _oFrmDLCastingNo_PortIntegral})
                ''                FormNavigationOrder.Add(New Object(3) {"frmDLCastingNo_PortIntegral", _oFrmDLCastingNo_PortIntegral, _oFrmDLPortIntegral, _oFrmDLCastingNo_PortIntegral2})
                ''                FormNavigationOrder.Add(New Object(3) {"frmDLCastingNo_PortIntegral2", _oFrmDLCastingNo_PortIntegral2, _oFrmDLCastingNo_PortIntegral, _oFrmRodEndConfiguration})
                ''                RodEndNavigationOrder(_oFrmDLCastingNo_PortIntegral2, FormNavigationOrder)
                ''            Else
                ''                FormNavigationOrder.Add(New Object(3) {"frmDLPortIntegral", _oFrmDLPortIntegral, _oFrmPortDetails, _oFrmDLCastingNo_PortIntegral2})
                ''                FormNavigationOrder.Add(New Object(3) {"frmDLCastingNo_PortIntegral2", _oFrmDLCastingNo_PortIntegral2, _oFrmDLPortIntegral, _oFrmRodEndConfiguration})
                ''                RodEndNavigationOrder(_oFrmDLCastingNo_PortIntegral2, FormNavigationOrder)
                ''            End If
                ''        Else
                ''            FormNavigationOrder.Add(New Object(3) {"frmDLPortIntegral", _oFrmDLPortIntegral, _oFrmPortDetails, _oFrmDLPortIntegral2})
                ''            FormNavigationOrder.Add(New Object(3) {"frmDLPortIntegral2", _oFrmDLPortIntegral2, _oFrmDLPortIntegral, _oFrmRodEndConfiguration})
                ''            RodEndNavigationOrder(_oFrmDLPortIntegral2, FormNavigationOrder)

                ''        End If
                ''    ElseIf _strIsPortIntegral_or_PortInTube = "Port In Tube" Then
                ''        FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmDLPortInTubeDetails})
                ''        If PortIntegral_ExistingDetailsFound Then
                ''            If ShowCastingNo_Thru_CastingYes Then
                ''                FormNavigationOrder.Add(New Object(3) {"frmDLPortInTubeDetails", _oFrmDLPortInTubeDetails, _oFrmPortDetails, _oFrmDLCastingNo_PortInTube})
                ''                FormNavigationOrder.Add(New Object(3) {"frmDLCastingNo_PortInTube", _oFrmDLCastingNo_PortInTube, _oFrmDLPortInTubeDetails, _oFrmDLCastingNo_PortInTube2})
                ''                FormNavigationOrder.Add(New Object(3) {"frmDLCastingNo_PortInTube2", _oFrmDLCastingNo_PortInTube2, _oFrmDLCastingNo_PortInTube, _oFrmRodEndConfiguration})
                ''                RodEndNavigationOrder(_oFrmDLCastingNo_PortInTube2, FormNavigationOrder)
                ''            Else
                ''                FormNavigationOrder.Add(New Object(3) {"frmDLPortInTubeDetails", _oFrmDLPortInTubeDetails, _oFrmPortDetails, _oFrmDLCastingNo_PortInTube2})
                ''                FormNavigationOrder.Add(New Object(3) {"frmDLCastingNo_PortInTube2", _oFrmDLCastingNo_PortInTube2, _oFrmDLPortInTubeDetails, _oFrmRodEndConfiguration})
                ''                RodEndNavigationOrder(_oFrmDLCastingNo_PortInTube2, FormNavigationOrder)

                ''            End If
                ''        Else
                ''            FormNavigationOrder.Add(New Object(3) {"frmDLPortInTubeDetails", _oFrmDLPortInTubeDetails, _oFrmPortDetails, _oFrmDLPortInTubeDetails2})
                ''            FormNavigationOrder.Add(New Object(3) {"frmDLPortInTubeDetails2", _oFrmDLPortInTubeDetails2, _oFrmDLPortInTubeDetails, _oFrmRodEndConfiguration})
                ''            RodEndNavigationOrder(_oFrmDLPortInTubeDetails2, FormNavigationOrder)

                ''        End If
                ''    End If
                ''Catch ex As Exception
                ''End Try
                Try
                    If _strIsPortIntegral_or_PortInTube = "Port Integral" Then
                        FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmDLPortIntegral})
                        If PortIntegral_ExistingDetailsFound Then
                            If ShowCastingNo_Thru_CastingYes Then

                                If ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral.chkDoubleLugFabricationRequired.Checked = True Then
                                    FormNavigationOrder.Add(New Object(3) {"frmDLPortIntegral", _oFrmDLPortIntegral, _oFrmPortDetails, _oFrmDLCastingNo_PortIntegral})
                                    FormNavigationOrder.Add(New Object(3) {"frmDLCastingNo_PortIntegral", _oFrmDLCastingNo_PortIntegral, _oFrmDLPortIntegral, _oFrmDLCastingNo_PortIntegral2})
                                    FormNavigationOrder.Add(New Object(3) {"frmDLCastingNo_PortIntegral2", _oFrmDLCastingNo_PortIntegral2, _oFrmDLCastingNo_PortIntegral, _oFrmRodEndConfiguration})
                                    RodEndNavigationOrder(_oFrmDLCastingNo_PortIntegral2, FormNavigationOrder)
                                Else
                                    FormNavigationOrder.Add(New Object(3) {"frmDLPortIntegral", _oFrmDLPortIntegral, _oFrmPortDetails, _oFrmDLCastingNo_PortIntegral})
                                    FormNavigationOrder.Add(New Object(3) {"frmDLCastingNo_PortIntegral", _oFrmDLCastingNo_PortIntegral, _oFrmDLPortIntegral, _oFrmRodEndConfiguration})
                                    RodEndNavigationOrder(_oFrmDLCastingNo_PortIntegral, FormNavigationOrder)
                                End If
                            Else
                                If ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingYes.chkDoubleLugFabricationRequired.Checked = True OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingYes.rdbNewCasting.Checked = True Then
                                    FormNavigationOrder.Add(New Object(3) {"frmDLPortIntegral", _oFrmDLPortIntegral, _oFrmPortDetails, _oFrmDLCastingNo_PortIntegral2})
                                    FormNavigationOrder.Add(New Object(3) {"frmDLCastingNo_PortIntegral2", _oFrmDLCastingNo_PortIntegral2, _oFrmDLPortIntegral, _oFrmRodEndConfiguration})
                                    RodEndNavigationOrder(_oFrmDLCastingNo_PortIntegral2, FormNavigationOrder)

                                Else
                                    FormNavigationOrder.Add(New Object(3) {"frmDLPortIntegral", _oFrmDLPortIntegral, _oFrmPortDetails, _oFrmRodEndConfiguration})
                                    RodEndNavigationOrder(_oFrmDLPortIntegral, FormNavigationOrder)
                                End If

                            End If
                        Else

                            If ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral.chkDoubleLugFabricationRequired.Checked = True Then
                                FormNavigationOrder.Add(New Object(3) {"frmDLPortIntegral", _oFrmDLPortIntegral, _oFrmPortDetails, _oFrmDLPortIntegral2})
                                FormNavigationOrder.Add(New Object(3) {"frmDLPortIntegral2", _oFrmDLPortIntegral2, _oFrmDLPortIntegral, _oFrmRodEndConfiguration})
                                RodEndNavigationOrder(_oFrmDLPortIntegral2, FormNavigationOrder)
                            Else
                                FormNavigationOrder.Add(New Object(3) {"frmDLPortIntegral", _oFrmDLPortIntegral, _oFrmPortDetails, _oFrmRodEndConfiguration})
                                RodEndNavigationOrder(_oFrmDLPortIntegral, FormNavigationOrder)
                            End If
                        End If

                        ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral.chkDoubleLugFabricationRequired.Visible = False
                        If ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral.rdbDesignACasting.Checked = True Then
                            ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral.chkDoubleLugFabricationRequired.Visible = True
                        Else
                            ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral.chkDoubleLugFabricationRequired.Visible = False
                        End If
                    ElseIf _strIsPortIntegral_or_PortInTube = "Port In Tube" Then
                        FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmDLPortInTubeDetails})
                        If PortIntegral_ExistingDetailsFound Then
                            If ShowCastingNo_Thru_CastingYes Then

                                If ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.chkDoubleLugFabricationRequired.Checked = True Then
                                    FormNavigationOrder.Add(New Object(3) {"frmDLPortInTubeDetails", _oFrmDLPortInTubeDetails, _oFrmPortDetails, _oFrmDLCastingNo_PortInTube})
                                    FormNavigationOrder.Add(New Object(3) {"frmDLCastingNo_PortInTube", _oFrmDLCastingNo_PortInTube, _oFrmDLPortInTubeDetails, _oFrmDLCastingNo_PortInTube2})
                                    FormNavigationOrder.Add(New Object(3) {"frmDLCastingNo_PortInTube2", _oFrmDLCastingNo_PortInTube2, _oFrmDLCastingNo_PortInTube, _oFrmRodEndConfiguration})
                                    RodEndNavigationOrder(_oFrmDLCastingNo_PortInTube2, FormNavigationOrder)
                                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube2.rdbFabrication.Checked = True
                                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube2.rdbDesignACasting.Enabled = False
                                Else
                                    FormNavigationOrder.Add(New Object(3) {"frmDLPortInTubeDetails", _oFrmDLPortInTubeDetails, _oFrmPortDetails, _oFrmDLCastingNo_PortInTube})
                                    FormNavigationOrder.Add(New Object(3) {"frmDLCastingNo_PortInTube", _oFrmDLCastingNo_PortInTube, _oFrmDLPortInTubeDetails, _oFrmRodEndConfiguration})
                                    RodEndNavigationOrder(_oFrmDLCastingNo_PortInTube, FormNavigationOrder)

                                End If

                            Else
                                'vamsi commented 18-02-14
                                'FormNavigationOrder.Add(New Object(3) {"frmDLPortInTubeDetails", _oFrmDLPortInTubeDetails, _oFrmPortDetails, _oFrmDLCastingNo_PortInTube2})
                                'FormNavigationOrder.Add(New Object(3) {"frmDLCastingNo_PortInTube2", _oFrmDLCastingNo_PortInTube2, _oFrmDLPortInTubeDetails, _oFrmRodEndConfiguration})
                                'RodEndNavigationOrder(_oFrmDLCastingNo_PortInTube2, FormNavigationOrder)

                                'vamsi 18-02-14

                                If ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingYes.chkDoubleLugFabricationRequired.Checked = True OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingYes.rdbNewCasting.Checked = True Then

                                    FormNavigationOrder.Add(New Object(3) {"frmDLPortInTubeDetails", _oFrmDLPortInTubeDetails, _oFrmPortDetails, _oFrmDLCastingNo_PortInTube2})
                                    FormNavigationOrder.Add(New Object(3) {"frmDLCastingNo_PortInTube2", _oFrmDLCastingNo_PortInTube2, _oFrmDLPortInTubeDetails, _oFrmRodEndConfiguration})
                                    RodEndNavigationOrder(_oFrmDLCastingNo_PortInTube2, FormNavigationOrder)
                                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube2.rdbFabrication.Checked = True
                                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube2.rdbDesignACasting.Enabled = False
                                Else
                                    FormNavigationOrder.Add(New Object(3) {"frmDLPortInTubeDetails", _oFrmDLPortInTubeDetails, _oFrmPortDetails, _oFrmRodEndConfiguration})
                                    RodEndNavigationOrder(_oFrmDLPortInTubeDetails, FormNavigationOrder)
                                End If


                            End If
                        Else
                            If ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.chkDoubleLugFabricationRequired.Checked = True Then
                                FormNavigationOrder.Add(New Object(3) {"frmDLPortInTubeDetails", _oFrmDLPortInTubeDetails, _oFrmPortDetails, _oFrmDLPortInTubeDetails2})
                                FormNavigationOrder.Add(New Object(3) {"frmDLPortInTubeDetails2", _oFrmDLPortInTubeDetails2, _oFrmDLPortInTubeDetails, _oFrmRodEndConfiguration})
                                RodEndNavigationOrder(_oFrmDLPortInTubeDetails2, FormNavigationOrder)
                            Else
                                FormNavigationOrder.Add(New Object(3) {"frmDLPortInTubeDetails", _oFrmDLPortInTubeDetails, _oFrmPortDetails, _oFrmRodEndConfiguration})
                                RodEndNavigationOrder(_oFrmDLPortInTubeDetails, FormNavigationOrder)

                            End If
                        End If

                        ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.chkDoubleLugFabricationRequired.Visible = False
                        If ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.rdbDesignACasting.Checked = True Then
                            ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.chkDoubleLugFabricationRequired.Visible = True
                        Else
                            ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.chkDoubleLugFabricationRequired.Visible = False
                        End If

                    End If

                Catch ex As Exception

                End Try

                'till here priyanka

                ''*******************PlateClevis**************************************
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Plate Clevis" Then
                FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmConPlateClevis})
                FormNavigationOrder.Add(New Object(3) {"frmConPlateClevis", _oFrmConPlateClevis, _oFrmPortDetails, _oFrmRodEndConfiguration})
                RodEndNavigationOrder(_oFrmConPlateClevis, FormNavigationOrder)
                ''*********************************************************


                ''*******************BH**************************************
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "BH" Then

                '    If _strIsPortIntegral_or_PortInTube = "Port Integral" Then
                '        FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmBHPortIntegral})
                '        If PortIntegral_ExistingDetailsFound Then
                '            If ShowCastingNo_Thru_CastingYes Then
                '                FormNavigationOrder.Add(New Object(3) {"frmBHPortIntegral", _oFrmBHPortIntegral, _oFrmPortDetails, _oFrmBHCastingNo_PortIntegral})
                '                FormNavigationOrder.Add(New Object(3) {"frmBHCastingNo_PortIntegral", _oFrmBHCastingNo_PortIntegral, _oFrmBHPortIntegral, _oFrmRodEndConfiguration})
                '                RodEndNavigationOrder(_oFrmBHCastingNo_PortIntegral, FormNavigationOrder)
                '            Else
                '                FormNavigationOrder.Add(New Object(3) {"frmBHPortIntegral", _oFrmBHPortIntegral, _oFrmPortDetails, _oFrmRodEndConfiguration})
                '                'ANUP 10-11-2010 START
                '                '   RodEndNavigationOrder(_oFrmSLPortinTube, FormNavigationOrder)
                '                RodEndNavigationOrder(_oFrmBHPortIntegral, FormNavigationOrder)
                '                'ANUP 10-11-2010 TILL HERE
                '            End If
                '        Else
                '            FormNavigationOrder.Add(New Object(3) {"frmBHPortIntegral", _oFrmBHPortIntegral, _oFrmPortDetails, _oFrmRodEndConfiguration})
                '            RodEndNavigationOrder(_oFrmBHPortIntegral, FormNavigationOrder)
                '        End If
                '    ElseIf _strIsPortIntegral_or_PortInTube = "Port In Tube" Then
                '        FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmBHPortinTube})
                '        If ShowCastingNo_Thru_CastingYes Then
                '            FormNavigationOrder.Add(New Object(3) {"frmBHPortInTube", _oFrmBHPortinTube, _oFrmPortDetails, _oFrmBHCastingNo_PortInTube})
                '            FormNavigationOrder.Add(New Object(3) {"frmBHCastingNo_PortInTube", _oFrmBHCastingNo_PortInTube, _oFrmBHPortinTube, _oFrmRodEndConfiguration})
                '            RodEndNavigationOrder(_oFrmBHCastingNo_PortInTube, FormNavigationOrder)
                '        Else
                '            FormNavigationOrder.Add(New Object(3) {"frmBHPortInTube", _oFrmBHPortinTube, _oFrmPortDetails, _oFrmRodEndConfiguration})
                '            RodEndNavigationOrder(_oFrmBHPortinTube, FormNavigationOrder)
                '        End If
                '    End If


                'priyanka

                ''If _strIsPortIntegral_or_PortInTube = "Port Integral" Then
                ''    FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmBHPortIntegral})

                ''    If PortIntegral_ExistingDetailsFound Then

                ''        If ShowCastingNo_Thru_CastingYes Then
                ''            FormNavigationOrder.Add(New Object(3) {"frmBHPortIntegral", _oFrmBHPortIntegral, _oFrmPortDetails, _oFrmBHCastingNo_PortIntegral})
                ''            FormNavigationOrder.Add(New Object(3) {"frmBHCastingNo_PortIntegral", _oFrmBHCastingNo_PortIntegral, _oFrmBHPortIntegral, _oFrmBHCastingNo_PortIntegral2})
                ''            FormNavigationOrder.Add(New Object(3) {"frmBHCastingNo_PortIntegral2", _oFrmBHCastingNo_PortIntegral2, _oFrmBHCastingNo_PortIntegral, _oFrmRodEndConfiguration})
                ''            RodEndNavigationOrder(_oFrmBHCastingNo_PortIntegral2, FormNavigationOrder)
                ''        Else
                ''            FormNavigationOrder.Add(New Object(3) {"frmBHPortIntegral", _oFrmBHPortIntegral, _oFrmPortDetails, _oFrmBHCastingNo_PortIntegral2})
                ''            FormNavigationOrder.Add(New Object(3) {"frmBHCastingNo_PortIntegral2", _oFrmBHCastingNo_PortIntegral2, _oFrmBHPortIntegral, _oFrmRodEndConfiguration})
                ''            RodEndNavigationOrder(_oFrmBHCastingNo_PortIntegral2, FormNavigationOrder)

                ''        End If
                ''    Else

                ''        FormNavigationOrder.Add(New Object(3) {"frmBHPortIntegral", _oFrmBHPortIntegral, _oFrmPortDetails, _oFrmBHPortIntegral2})
                ''        FormNavigationOrder.Add(New Object(3) {"frmBHPortIntegral2", _oFrmBHPortIntegral2, _oFrmBHPortIntegral, _oFrmRodEndConfiguration})
                ''        RodEndNavigationOrder(_oFrmBHPortIntegral2, FormNavigationOrder)

                ''    End If
                ''ElseIf _strIsPortIntegral_or_PortInTube = "Port In Tube" Then
                ''    FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmBHPortinTube})

                ''    If PortIntegral_ExistingDetailsFound Then

                ''        If ShowCastingNo_Thru_CastingYes Then
                ''            FormNavigationOrder.Add(New Object(3) {"frmBHPortInTube", _oFrmBHPortinTube, _oFrmPortDetails, _oFrmBHCastingNo_PortInTube})
                ''            FormNavigationOrder.Add(New Object(3) {"frmBHCastingNo_PortInTube", _oFrmBHCastingNo_PortInTube, _oFrmBHPortinTube, _oFrmBHCastingNo_PortInTube2})
                ''            FormNavigationOrder.Add(New Object(3) {"frmBHCastingNo_PortInTube2", _oFrmBHCastingNo_PortInTube2, _oFrmBHCastingNo_PortInTube, _oFrmRodEndConfiguration})
                ''            RodEndNavigationOrder(_oFrmBHCastingNo_PortInTube2, FormNavigationOrder)
                ''        Else
                ''            FormNavigationOrder.Add(New Object(3) {"frmBHPortInTube", _oFrmBHPortinTube, _oFrmPortDetails, _oFrmBHCastingNo_PortInTube2})
                ''            FormNavigationOrder.Add(New Object(3) {"frmBHCastingNo_PortInTube2", _oFrmBHCastingNo_PortInTube2, _oFrmBHPortinTube, _oFrmRodEndConfiguration})
                ''            RodEndNavigationOrder(_oFrmBHCastingNo_PortInTube2, FormNavigationOrder)

                ''        End If
                ''    Else
                ''        FormNavigationOrder.Add(New Object(3) {"frmBHPortInTube", _oFrmBHPortinTube, _oFrmPortDetails, _oFrmBHPortinTube2})
                ''        FormNavigationOrder.Add(New Object(3) {"frmBHPortInTube2", _oFrmBHPortinTube2, _oFrmBHPortinTube, _oFrmRodEndConfiguration})
                ''        RodEndNavigationOrder(_oFrmBHPortinTube2, FormNavigationOrder)
                ''    End If

                ''End If




                If _strIsPortIntegral_or_PortInTube = "Port Integral" Then
                    FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmBHPortIntegral})

                    If PortIntegral_ExistingDetailsFound Then

                        If ShowCastingNo_Thru_CastingYes Then

                            If ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingNo_PortIntegral.chkBHFabricationRequired.Checked = True Then
                                FormNavigationOrder.Add(New Object(3) {"frmBHPortIntegral", _oFrmBHPortIntegral, _oFrmPortDetails, _oFrmBHCastingNo_PortIntegral})
                                FormNavigationOrder.Add(New Object(3) {"frmBHCastingNo_PortIntegral", _oFrmBHCastingNo_PortIntegral, _oFrmBHPortIntegral, _oFrmBHCastingNo_PortIntegral2})
                                FormNavigationOrder.Add(New Object(3) {"frmBHCastingNo_PortIntegral2", _oFrmBHCastingNo_PortIntegral2, _oFrmBHCastingNo_PortIntegral, _oFrmRodEndConfiguration})
                                RodEndNavigationOrder(_oFrmBHCastingNo_PortIntegral2, FormNavigationOrder)
                            Else
                                FormNavigationOrder.Add(New Object(3) {"frmBHPortIntegral", _oFrmBHPortIntegral, _oFrmPortDetails, _oFrmBHCastingNo_PortIntegral})
                                FormNavigationOrder.Add(New Object(3) {"frmBHCastingNo_PortIntegral", _oFrmBHCastingNo_PortIntegral, _oFrmBHPortIntegral, _oFrmRodEndConfiguration})
                                'FormNavigationOrder.Add(New Object(3) {"frmBHCastingNo_PortIntegral2", _oFrmBHCastingNo_PortIntegral2, _oFrmBHCastingNo_PortIntegral, _oFrmRodEndConfiguration})
                                RodEndNavigationOrder(_oFrmBHCastingNo_PortIntegral, FormNavigationOrder)
                            End If

                        Else
                            If ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingYes.chkBHFabricationRequired.Checked = True OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingYes.rdbNewCasting.Checked = True Then
                                FormNavigationOrder.Add(New Object(3) {"frmBHPortIntegral", _oFrmBHPortIntegral, _oFrmPortDetails, _oFrmBHCastingNo_PortIntegral2})
                                FormNavigationOrder.Add(New Object(3) {"frmBHCastingNo_PortIntegral2", _oFrmBHCastingNo_PortIntegral2, _oFrmBHPortIntegral, _oFrmRodEndConfiguration})
                                RodEndNavigationOrder(_oFrmBHCastingNo_PortIntegral2, FormNavigationOrder)
                            Else
                                FormNavigationOrder.Add(New Object(3) {"frmBHPortIntegral", _oFrmBHPortIntegral, _oFrmPortDetails, _oFrmRodEndConfiguration})
                                'FormNavigationOrder.Add(New Object(3) {"frmBHCastingNo_PortIntegral2", _oFrmBHCastingNo_PortIntegral2, _oFrmBHPortIntegral, _oFrmRodEndConfiguration})
                                RodEndNavigationOrder(_oFrmBHPortIntegral, FormNavigationOrder)
                            End If
                        End If
                    Else
                        If ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingNo_PortIntegral.chkBHFabricationRequired.Checked = True Then
                            FormNavigationOrder.Add(New Object(3) {"frmBHPortIntegral", _oFrmBHPortIntegral, _oFrmPortDetails, _oFrmBHPortIntegral2})
                            FormNavigationOrder.Add(New Object(3) {"frmBHPortIntegral2", _oFrmBHPortIntegral2, _oFrmBHPortIntegral, _oFrmRodEndConfiguration})
                            RodEndNavigationOrder(_oFrmBHPortIntegral2, FormNavigationOrder)
                        Else
                            FormNavigationOrder.Add(New Object(3) {"frmBHPortIntegral", _oFrmBHPortIntegral, _oFrmPortDetails, _oFrmRodEndConfiguration})
                            'FormNavigationOrder.Add(New Object(3) {"frmBHPortIntegral2", _oFrmBHPortIntegral2, _oFrmBHPortIntegral, _oFrmRodEndConfiguration})
                            RodEndNavigationOrder(_oFrmBHPortIntegral, FormNavigationOrder)
                        End If
                    End If

                    ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingNo_PortIntegral.chkBHFabricationRequired.Visible = False
                    If ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingNo_PortIntegral.rdbDesignACasting.Checked = True Then
                        ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingNo_PortIntegral.chkBHFabricationRequired.Visible = True
                    Else
                        ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingNo_PortIntegral.chkBHFabricationRequired.Visible = False
                    End If

                ElseIf _strIsPortIntegral_or_PortInTube = "Port In Tube" Then
                    FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmBHPortinTube})

                    If PortIntegral_ExistingDetailsFound Then

                        If ShowCastingNo_Thru_CastingYes Then

                            If ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingNo_PortInTube.chkBHFabricationRequired.Checked = True Then
                                FormNavigationOrder.Add(New Object(3) {"frmBHPortInTube", _oFrmBHPortinTube, _oFrmPortDetails, _oFrmBHCastingNo_PortInTube})
                                FormNavigationOrder.Add(New Object(3) {"frmBHCastingNo_PortInTube", _oFrmBHCastingNo_PortInTube, _oFrmBHPortinTube, _oFrmBHCastingNo_PortInTube2})
                                FormNavigationOrder.Add(New Object(3) {"frmBHCastingNo_PortInTube2", _oFrmBHCastingNo_PortInTube2, _oFrmBHCastingNo_PortInTube, _oFrmRodEndConfiguration})
                                RodEndNavigationOrder(_oFrmBHCastingNo_PortInTube2, FormNavigationOrder)
                            Else
                                FormNavigationOrder.Add(New Object(3) {"frmBHPortInTube", _oFrmBHPortinTube, _oFrmPortDetails, _oFrmBHCastingNo_PortInTube})
                                FormNavigationOrder.Add(New Object(3) {"frmBHCastingNo_PortInTube", _oFrmBHCastingNo_PortInTube, _oFrmBHPortinTube, _oFrmRodEndConfiguration})
                                'FormNavigationOrder.Add(New Object(3) {"frmBHCastingNo_PortInTube2", _oFrmBHCastingNo_PortInTube2, _oFrmBHCastingNo_PortInTube, _oFrmRodEndConfiguration})
                                RodEndNavigationOrder(_oFrmBHCastingNo_PortInTube, FormNavigationOrder)
                            End If

                        Else
                            If ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingYes.chkBHFabricationRequired.Checked = True OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingYes.rdbNewCasting.Checked = True Then
                                FormNavigationOrder.Add(New Object(3) {"frmBHPortInTube", _oFrmBHPortinTube, _oFrmPortDetails, _oFrmBHCastingNo_PortInTube2})
                                FormNavigationOrder.Add(New Object(3) {"frmBHCastingNo_PortInTube2", _oFrmBHCastingNo_PortInTube2, _oFrmBHPortinTube, _oFrmRodEndConfiguration})
                                RodEndNavigationOrder(_oFrmBHCastingNo_PortInTube2, FormNavigationOrder)
                            Else
                                FormNavigationOrder.Add(New Object(3) {"frmBHPortInTube", _oFrmBHPortinTube, _oFrmPortDetails, _oFrmRodEndConfiguration})
                                'FormNavigationOrder.Add(New Object(3) {"frmBHCastingNo_PortInTube2", _oFrmBHCastingNo_PortInTube2, _oFrmBHPortinTube, _oFrmRodEndConfiguration})
                                RodEndNavigationOrder(_oFrmBHPortinTube, FormNavigationOrder)
                            End If
                        End If
                    Else
                        If ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingNo_PortInTube.chkBHFabricationRequired.Checked = True Then
                            FormNavigationOrder.Add(New Object(3) {"frmBHPortInTube", _oFrmBHPortinTube, _oFrmPortDetails, _oFrmBHPortinTube2})
                            FormNavigationOrder.Add(New Object(3) {"frmBHPortInTube2", _oFrmBHPortinTube2, _oFrmBHPortinTube, _oFrmRodEndConfiguration})
                            RodEndNavigationOrder(_oFrmBHPortinTube2, FormNavigationOrder)
                        Else
                            FormNavigationOrder.Add(New Object(3) {"frmBHPortInTube", _oFrmBHPortinTube, _oFrmPortDetails, _oFrmRodEndConfiguration})
                            'FormNavigationOrder.Add(New Object(3) {"frmBHPortInTube2", _oFrmBHPortinTube2, _oFrmBHPortinTube, _oFrmRodEndConfiguration})
                            RodEndNavigationOrder(_oFrmBHPortinTube, FormNavigationOrder)
                        End If
                    End If
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingNo_PortInTube.chkBHFabricationRequired.Visible = False
                    If ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingNo_PortInTube.rdbDesignACasting.Checked = True Then
                        ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingNo_PortInTube.chkBHFabricationRequired.Visible = True
                    Else
                        ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingNo_PortInTube.chkBHFabricationRequired.Visible = False
                    End If
                End If
                'tillhere priyanka

                ''*********************************************************



                ''*******************SingleLug**************************************
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Single Lug" Then
                'If _strIsPortIntegral_or_PortInTube = "Port Integral" Then
                '    FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmSLPortIntegral})
                '    If PortIntegral_ExistingDetailsFound Then
                '        If ShowCastingNo_Thru_CastingYes Then
                '            FormNavigationOrder.Add(New Object(3) {"frmSLPortIntegral", _oFrmSLPortIntegral, _oFrmPortDetails, _oFrmSLCastingNo_PortIntegral})
                '            FormNavigationOrder.Add(New Object(3) {"frmSLCastingNo_PortIntegral", _oFrmSLCastingNo_PortIntegral, _oFrmSLPortIntegral, _oFrmRodEndConfiguration})
                '            RodEndNavigationOrder(_oFrmSLCastingNo_PortIntegral, FormNavigationOrder)
                '        Else
                '            '19_04_2012   RAGAVA
                '            'FormNavigationOrder.Add(New Object(3) {"frmSLPortIntegral", _oFrmSLPortIntegral, _oFrmPortDetails, _oFrmRodEndConfiguration})
                '            FormNavigationOrder.Add(New Object(3) {"frmSLPortIntegral", _oFrmSLPortIntegral, _oFrmPortDetails, _oFrmSLCastingNo_PortIntegral})
                '            FormNavigationOrder.Add(New Object(3) {"frmSLCastingNo_PortIntegral", _oFrmSLCastingNo_PortIntegral, _oFrmSLPortIntegral, _oFrmRodEndConfiguration})
                '            'Till  Here
                '            RodEndNavigationOrder(_oFrmSLPortIntegral, FormNavigationOrder)
                '        End If
                '    Else
                '        FormNavigationOrder.Add(New Object(3) {"frmSLPortIntegral", _oFrmSLPortIntegral, _oFrmPortDetails, _oFrmRodEndConfiguration})
                '        RodEndNavigationOrder(_oFrmSLPortIntegral, FormNavigationOrder)
                '    End If
                'ElseIf _strIsPortIntegral_or_PortInTube = "Port In Tube" Then
                '    FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmSLPortinTube})
                '    If ShowCastingNo_Thru_CastingYes Then
                '        FormNavigationOrder.Add(New Object(3) {"frmSLPortinTube", _oFrmSLPortinTube, _oFrmPortDetails, _oFrmSLCastingNo_PortInTube})
                '        FormNavigationOrder.Add(New Object(3) {"frmSLCastingNo_PortInTube", _oFrmSLCastingNo_PortInTube, _oFrmSLPortinTube, _oFrmRodEndConfiguration})
                '        RodEndNavigationOrder(_oFrmSLCastingNo_PortInTube, FormNavigationOrder)
                '    Else
                '        '19_04_2012  RAGAVA
                '        'FormNavigationOrder.Add(New Object(3) {"frmSLPortinTube", _oFrmSLPortinTube, _oFrmPortDetails, _oFrmRodEndConfiguration})
                '        FormNavigationOrder.Add(New Object(3) {"frmSLPortinTube", _oFrmSLPortinTube, _oFrmPortDetails, _oFrmSLCastingNo_PortInTube})
                '        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                '            ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortInTube.rdbDesignACasting.Enabled = False
                '        End If
                '        FormNavigationOrder.Add(New Object(3) {"frmSLCastingNo_PortInTube", _oFrmSLCastingNo_PortInTube, _oFrmSLPortinTube, _oFrmRodEndConfiguration})
                '        'Till Here
                '        RodEndNavigationOrder(_oFrmSLPortinTube, FormNavigationOrder)
                '    End If

                'End If


                'priyanka
                ''If _strIsPortIntegral_or_PortInTube = "Port Integral" Then
                ''    FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmSLPortIntegral})
                ''    If PortIntegral_ExistingDetailsFound Then
                ''        If ShowCastingNo_Thru_CastingYes Then
                ''            FormNavigationOrder.Add(New Object(3) {"frmSLPortIntegral", _oFrmSLPortIntegral, _oFrmPortDetails, _oFrmSLCastingNo_PortIntegral})
                ''            FormNavigationOrder.Add(New Object(3) {"frmSLCastingNo_PortIntegral", _oFrmSLCastingNo_PortIntegral, _oFrmSLPortIntegral, _oFrmSLCastingNo_PortIntegral2})
                ''            FormNavigationOrder.Add(New Object(3) {"frmSLCastingNo_PortIntegral2", _oFrmSLCastingNo_PortIntegral2, _oFrmSLCastingNo_PortIntegral, _oFrmRodEndConfiguration})
                ''            RodEndNavigationOrder(_oFrmSLCastingNo_PortIntegral2, FormNavigationOrder)

                ''        Else
                ''            '19_04_2012   RAGAVA
                ''            'FormNavigationOrder.Add(New Object(3) {"frmSLPortIntegral", _oFrmSLPortIntegral, _oFrmPortDetails, _oFrmRodEndConfiguration})
                ''            FormNavigationOrder.Add(New Object(3) {"frmSLPortIntegral", _oFrmSLPortIntegral, _oFrmPortDetails, _oFrmSLCastingNo_PortIntegral2})
                ''            FormNavigationOrder.Add(New Object(3) {"frmSLCastingNo_PortIntegral2", _oFrmSLCastingNo_PortIntegral2, _oFrmSLPortIntegral, _oFrmRodEndConfiguration})
                ''            'Till  Here
                ''            RodEndNavigationOrder(_oFrmSLCastingNo_PortIntegral2, FormNavigationOrder)

                ''        End If
                ''    Else
                ''        FormNavigationOrder.Add(New Object(3) {"frmSLPortIntegral", _oFrmSLPortIntegral, _oFrmPortDetails, _oFrmSLPortIntegral2})
                ''        FormNavigationOrder.Add(New Object(3) {"frmSLPortIntegral2", _oFrmSLPortIntegral2, _oFrmSLPortIntegral, _oFrmRodEndConfiguration})
                ''        RodEndNavigationOrder(_oFrmSLPortIntegral2, FormNavigationOrder)

                ''    End If
                ''ElseIf _strIsPortIntegral_or_PortInTube = "Port In Tube" Then
                ''    FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmSLPortinTube})
                ''    If PortIntegral_ExistingDetailsFound Then

                ''        If ShowCastingNo_Thru_CastingYes Then
                ''            FormNavigationOrder.Add(New Object(3) {"frmSLPortinTube", _oFrmSLPortinTube, _oFrmPortDetails, _oFrmSLCastingNo_PortInTube})
                ''            FormNavigationOrder.Add(New Object(3) {"frmSLCastingNo_PortInTube", _oFrmSLCastingNo_PortInTube, _oFrmSLPortinTube, _oFrmSLCastingNo_PortInTube2})
                ''            FormNavigationOrder.Add(New Object(3) {"frmSLCastingNo_PortInTube2", _oFrmSLCastingNo_PortInTube2, _oFrmSLCastingNo_PortInTube, _oFrmRodEndConfiguration})
                ''            RodEndNavigationOrder(_oFrmSLCastingNo_PortInTube2, FormNavigationOrder)

                ''        Else
                ''            '19_04_2012  RAGAVA
                ''            'FormNavigationOrder.Add(New Object(3) {"frmSLPortinTube", _oFrmSLPortinTube, _oFrmPortDetails, _oFrmRodEndConfiguration})
                ''            FormNavigationOrder.Add(New Object(3) {"frmSLPortinTube", _oFrmSLPortinTube, _oFrmPortDetails, _oFrmSLCastingNo_PortInTube2})
                ''            FormNavigationOrder.Add(New Object(3) {"frmSLCastingNo_PortInTube2", _oFrmSLCastingNo_PortInTube2, _oFrmSLPortinTube, _oFrmRodEndConfiguration})
                ''            'Till Here
                ''            RodEndNavigationOrder(_oFrmSLCastingNo_PortInTube2, FormNavigationOrder)

                ''        End If
                ''    Else
                ''        FormNavigationOrder.Add(New Object(3) {"frmSLPortinTube", _oFrmSLPortinTube, _oFrmPortDetails, _oFrmSLPortinTube2})
                ''        FormNavigationOrder.Add(New Object(3) {"frmSLPortinTube2", _oFrmSLPortinTube2, _oFrmSLPortinTube, _oFrmRodEndConfiguration})
                ''        'Till Here
                ''        RodEndNavigationOrder(_oFrmSLPortinTube2, FormNavigationOrder)

                ''    End If



                ''End If






                If _strIsPortIntegral_or_PortInTube = "Port Integral" Then
                    FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmSLPortIntegral})
                    If PortIntegral_ExistingDetailsFound Then
                        If ShowCastingNo_Thru_CastingYes Then

                            If ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortIntegral.chkSingleLugFabricationRequired.Checked = True Then

                                FormNavigationOrder.Add(New Object(3) {"frmSLPortIntegral", _oFrmSLPortIntegral, _oFrmPortDetails, _oFrmSLCastingNo_PortIntegral})
                                FormNavigationOrder.Add(New Object(3) {"frmSLCastingNo_PortIntegral", _oFrmSLCastingNo_PortIntegral, _oFrmSLPortIntegral, _oFrmSLCastingNo_PortIntegral2})
                                FormNavigationOrder.Add(New Object(3) {"frmSLCastingNo_PortIntegral2", _oFrmSLCastingNo_PortIntegral2, _oFrmSLCastingNo_PortIntegral, _oFrmRodEndConfiguration})
                                RodEndNavigationOrder(_oFrmSLCastingNo_PortIntegral2, FormNavigationOrder)

                            Else

                                FormNavigationOrder.Add(New Object(3) {"frmSLPortIntegral", _oFrmSLPortIntegral, _oFrmPortDetails, _oFrmSLCastingNo_PortIntegral})
                                FormNavigationOrder.Add(New Object(3) {"frmSLCastingNo_PortIntegral", _oFrmSLCastingNo_PortIntegral, _oFrmSLPortIntegral, _oFrmRodEndConfiguration})
                                'FormNavigationOrder.Add(New Object(3) {"frmSLCastingNo_PortIntegral2", _oFrmSLCastingNo_PortIntegral2, _oFrmSLCastingNo_PortIntegral, _oFrmRodEndConfiguration})
                                RodEndNavigationOrder(_oFrmSLCastingNo_PortIntegral, FormNavigationOrder)

                            End If

                        Else

                            If ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingYes.chkSingleLugFabricationRequired.Checked = True OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingYes.rdbNewCasting.Checked = True Then

                                FormNavigationOrder.Add(New Object(3) {"frmSLPortIntegral", _oFrmSLPortIntegral, _oFrmPortDetails, _oFrmSLCastingNo_PortIntegral2})
                                FormNavigationOrder.Add(New Object(3) {"frmSLCastingNo_PortIntegral2", _oFrmSLCastingNo_PortIntegral2, _oFrmSLPortIntegral, _oFrmRodEndConfiguration})
                                'Till  Here
                                RodEndNavigationOrder(_oFrmSLCastingNo_PortIntegral2, FormNavigationOrder)

                            Else

                                FormNavigationOrder.Add(New Object(3) {"frmSLPortIntegral", _oFrmSLPortIntegral, _oFrmPortDetails, _oFrmRodEndConfiguration})
                                RodEndNavigationOrder(_oFrmSLPortIntegral, FormNavigationOrder)

                            End If
                            FormNavigationOrder.Add(New Object(3) {"frmSLPortIntegral", _oFrmSLPortIntegral, _oFrmPortDetails, _oFrmSLCastingNo_PortIntegral2})
                            FormNavigationOrder.Add(New Object(3) {"frmSLCastingNo_PortIntegral2", _oFrmSLCastingNo_PortIntegral2, _oFrmSLPortIntegral, _oFrmRodEndConfiguration})
                            'Till  Here
                            RodEndNavigationOrder(_oFrmSLCastingNo_PortIntegral2, FormNavigationOrder)

                        End If
                    Else

                        If ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortIntegral.chkSingleLugFabricationRequired.Checked = True Then
                            FormNavigationOrder.Add(New Object(3) {"frmSLPortIntegral", _oFrmSLPortIntegral, _oFrmPortDetails, _oFrmSLPortIntegral2})
                            FormNavigationOrder.Add(New Object(3) {"frmSLPortIntegral2", _oFrmSLPortIntegral2, _oFrmSLPortIntegral, _oFrmRodEndConfiguration})
                            RodEndNavigationOrder(_oFrmSLPortIntegral2, FormNavigationOrder)

                        Else
                            FormNavigationOrder.Add(New Object(3) {"frmSLPortIntegral", _oFrmSLPortIntegral, _oFrmPortDetails, _oFrmRodEndConfiguration})
                            'FormNavigationOrder.Add(New Object(3) {"frmSLPortIntegral2", _oFrmSLPortIntegral2, _oFrmSLPortIntegral, _oFrmRodEndConfiguration})
                            RodEndNavigationOrder(_oFrmSLPortIntegral, FormNavigationOrder)
                        End If

                    End If

                    ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortIntegral.chkSingleLugFabricationRequired.Visible = False
                    If ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortIntegral.rdbDesignACasting.Checked = True Then
                        ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortIntegral.chkSingleLugFabricationRequired.Visible = True
                    Else
                        ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortIntegral.chkSingleLugFabricationRequired.Visible = False

                    End If
                ElseIf _strIsPortIntegral_or_PortInTube = "Port In Tube" Then
                    FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmSLPortinTube})
                    If PortIntegral_ExistingDetailsFound Then

                        If ShowCastingNo_Thru_CastingYes Then

                            If ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortInTube.chkSingleLugFabricationRequired.Checked = True Then
                                FormNavigationOrder.Add(New Object(3) {"frmSLPortinTube", _oFrmSLPortinTube, _oFrmPortDetails, _oFrmSLCastingNo_PortInTube})
                                FormNavigationOrder.Add(New Object(3) {"frmSLCastingNo_PortInTube", _oFrmSLCastingNo_PortInTube, _oFrmSLPortinTube, _oFrmSLCastingNo_PortInTube2})
                                FormNavigationOrder.Add(New Object(3) {"frmSLCastingNo_PortInTube2", _oFrmSLCastingNo_PortInTube2, _oFrmSLCastingNo_PortInTube, _oFrmRodEndConfiguration})
                                RodEndNavigationOrder(_oFrmSLCastingNo_PortInTube2, FormNavigationOrder)

                            Else
                                FormNavigationOrder.Add(New Object(3) {"frmSLPortinTube", _oFrmSLPortinTube, _oFrmPortDetails, _oFrmSLCastingNo_PortInTube})
                                FormNavigationOrder.Add(New Object(3) {"frmSLCastingNo_PortInTube", _oFrmSLCastingNo_PortInTube, _oFrmSLPortinTube, _oFrmRodEndConfiguration})
                                ' FormNavigationOrder.Add(New Object(3) {"frmSLCastingNo_PortInTube2", _oFrmSLCastingNo_PortInTube2, _oFrmSLCastingNo_PortInTube, _oFrmRodEndConfiguration})
                                RodEndNavigationOrder(_oFrmSLCastingNo_PortInTube, FormNavigationOrder)

                            End If
                        Else

                            If ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingYes.chkSingleLugFabricationRequired.Checked = True OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingYes.rdbNewCasting.Checked = True Then
                                FormNavigationOrder.Add(New Object(3) {"frmSLPortinTube", _oFrmSLPortinTube, _oFrmPortDetails, _oFrmSLCastingNo_PortInTube2})
                                FormNavigationOrder.Add(New Object(3) {"frmSLCastingNo_PortInTube2", _oFrmSLCastingNo_PortInTube2, _oFrmSLPortinTube, _oFrmRodEndConfiguration})
                                RodEndNavigationOrder(_oFrmSLCastingNo_PortInTube2, FormNavigationOrder)

                            Else
                                FormNavigationOrder.Add(New Object(3) {"frmSLPortinTube", _oFrmSLPortinTube, _oFrmPortDetails, _oFrmRodEndConfiguration})
                                'FormNavigationOrder.Add(New Object(3) {"frmSLCastingNo_PortInTube2", _oFrmSLCastingNo_PortInTube2, _oFrmSLPortinTube, _oFrmRodEndConfiguration})
                                RodEndNavigationOrder(_oFrmSLPortinTube, FormNavigationOrder)
                            End If
                            ''FormNavigationOrder.Add(New Object(3) {"frmSLPortinTube", _oFrmSLPortinTube, _oFrmPortDetails, _oFrmRodEndConfiguration})
                            'FormNavigationOrder.Add(New Object(3) {"frmSLPortinTube", _oFrmSLPortinTube, _oFrmPortDetails, _oFrmSLCastingNo_PortInTube2})
                            'FormNavigationOrder.Add(New Object(3) {"frmSLCastingNo_PortInTube2", _oFrmSLCastingNo_PortInTube2, _oFrmSLPortinTube, _oFrmRodEndConfiguration})
                            'RodEndNavigationOrder(_oFrmSLCastingNo_PortInTube2, FormNavigationOrder)

                        End If
                    Else

                        If ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortInTube.chkSingleLugFabricationRequired.Checked = True Then
                            FormNavigationOrder.Add(New Object(3) {"frmSLPortinTube", _oFrmSLPortinTube, _oFrmPortDetails, _oFrmSLPortinTube2})
                            FormNavigationOrder.Add(New Object(3) {"frmSLPortinTube2", _oFrmSLPortinTube2, _oFrmSLPortinTube, _oFrmRodEndConfiguration})
                            RodEndNavigationOrder(_oFrmSLPortinTube2, FormNavigationOrder)

                        Else
                            FormNavigationOrder.Add(New Object(3) {"frmSLPortinTube", _oFrmSLPortinTube, _oFrmPortDetails, _oFrmRodEndConfiguration})
                            'FormNavigationOrder.Add(New Object(3) {"frmSLPortinTube2", _oFrmSLPortinTube2, _oFrmSLPortinTube, _oFrmRodEndConfiguration})
                            RodEndNavigationOrder(_oFrmSLPortinTube, FormNavigationOrder)

                        End If

                    End If

                    ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortInTube.chkSingleLugFabricationRequired.Visible = False
                    If ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortInTube.rdbDesignACasting.Checked = True Then
                        ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortInTube.chkSingleLugFabricationRequired.Visible = True
                    Else
                        ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortInTube.chkSingleLugFabricationRequired.Visible = False

                    End If
                End If

                'till here priyanka
                ''*********************************************************


                'Try

                '    If _strIsPortIntegral_or_PortInTube = "Port Integral" Then
                '        FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmDLPortIntegral})
                '        If PortIntegral_ExistingDetailsFound Then
                '            If ShowCastingNo_Thru_CastingYes Then
                '                FormNavigationOrder.Add(New Object(3) {"frmDLPortIntegral", _oFrmDLPortIntegral, _oFrmPortDetails, _oFrmDLCastingNo_PortIntegral})
                '                FormNavigationOrder.Add(New Object(3) {"frmDLCastingNo_PortIntegral", _oFrmDLCastingNo_PortIntegral, _oFrmDLPortIntegral, _oFrmRodEndConfiguration})
                '                RodEndNavigationOrder(_oFrmDLCastingNo_PortIntegral, FormNavigationOrder)
                '            Else
                '                '13_03_2012  RAGAVA
                '                'FormNavigationOrder.Add(New Object(3) {"frmDLPortIntegral", _oFrmDLPortIntegral, _oFrmPortDetails, _oFrmRodEndConfiguration})
                '                FormNavigationOrder.Add(New Object(3) {"frmDLPortIntegral", _oFrmDLPortIntegral, _oFrmPortDetails, _oFrmDLCastingNo_PortIntegral})
                '                FormNavigationOrder.Add(New Object(3) {"frmDLCastingNo_PortIntegral", _oFrmDLCastingNo_PortIntegral, _oFrmDLPortIntegral, _oFrmRodEndConfiguration})
                '                'Till  Here
                '                RodEndNavigationOrder(_oFrmDLPortIntegral, FormNavigationOrder)
                '            End If
                '        Else
                '            FormNavigationOrder.Add(New Object(3) {"frmDLPortIntegral", _oFrmDLPortIntegral, _oFrmPortDetails, _oFrmRodEndConfiguration})
                '            RodEndNavigationOrder(_oFrmDLPortIntegral, FormNavigationOrder)
                '        End If
                '    ElseIf _strIsPortIntegral_or_PortInTube = "Port In Tube" Then
                '        FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmDLPortInTubeDetails})
                '        If ShowCastingNo_Thru_CastingYes Then
                '            ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.rdbDesignACasting.Enabled = True
                '            FormNavigationOrder.Add(New Object(3) {"frmDLPortInTubeDetails", _oFrmDLPortInTubeDetails, _oFrmPortDetails, _oFrmDLCastingNo_PortInTube})
                '            FormNavigationOrder.Add(New Object(3) {"frmDLCastingNo_PortInTube", _oFrmDLCastingNo_PortInTube, _oFrmDLPortInTubeDetails, _oFrmRodEndConfiguration})
                '            RodEndNavigationOrder(_oFrmDLCastingNo_PortInTube, FormNavigationOrder)
                '        Else
                '            '13_03_2012  RAGAVA
                '            'FormNavigationOrder.Add(New Object(3) {"frmDLPortInTubeDetails", _oFrmDLPortInTubeDetails, _oFrmPortDetails, _oFrmRodEndConfiguration})
                '            FormNavigationOrder.Add(New Object(3) {"frmDLPortInTubeDetails", _oFrmDLPortInTubeDetails, _oFrmPortDetails, _oFrmDLCastingNo_PortInTube})
                '            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                '                ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.rdbDesignACasting.Enabled = False        '15_03_2012  RAGAVA
                '            End If
                '            FormNavigationOrder.Add(New Object(3) {"frmDLCastingNo_PortInTube", _oFrmDLCastingNo_PortInTube, _oFrmDLPortInTubeDetails, _oFrmRodEndConfiguration})
                '            'Till Here
                '            RodEndNavigationOrder(_oFrmDLPortInTubeDetails, FormNavigationOrder)
                '        End If
                '    End If

                'Catch ex As Exception

                'End Try



                ' ANUP 08-03-2010 04.26
                ''*******************Base Plug**************************************
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Base Plug" Then
                If _strIsPortIntegral_or_PortInTube = "Port Integral" Then
                    FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmBasePlugPortIntegral})
                    If PortIntegral_ExistingDetailsFound Then
                        If ShowCastingNo_Thru_CastingYes Then
                            FormNavigationOrder.Add(New Object(3) {"frmBasePlugPortIntegral", _oFrmBasePlugPortIntegral, _oFrmPortDetails, _oFrmBasePlugCastingNoPortIntegral})
                            FormNavigationOrder.Add(New Object(3) {"frmBasePlugCastingNoPortIntegral", _oFrmBasePlugCastingNoPortIntegral, _oFrmBasePlugPortIntegral, _oFrmRodEndConfiguration})
                            RodEndNavigationOrder(_oFrmBasePlugCastingNoPortIntegral, FormNavigationOrder)
                        Else
                            FormNavigationOrder.Add(New Object(3) {"frmBasePlugPortIntegral", _oFrmBasePlugPortIntegral, _oFrmPortDetails, _oFrmRodEndConfiguration})
                            'ANUP 10-11-2010 START
                            '   RodEndNavigationOrder(_oFrmBasePlugPortInTube, FormNavigationOrder)
                            RodEndNavigationOrder(_oFrmBasePlugPortIntegral, FormNavigationOrder)
                            'ANUP 10-11-2010 TILL HERE
                        End If
                    Else
                        FormNavigationOrder.Add(New Object(3) {"frmBasePlugPortIntegral", _oFrmBasePlugPortIntegral, _oFrmPortDetails, _oFrmRodEndConfiguration})
                        RodEndNavigationOrder(_oFrmBasePlugPortIntegral, FormNavigationOrder)
                    End If
                ElseIf _strIsPortIntegral_or_PortInTube = "Port In Tube" Then
                    FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmBasePlugPortInTube})
                    If ShowCastingNo_Thru_CastingYes Then
                        FormNavigationOrder.Add(New Object(3) {"frmBasePlugPortInTube", _oFrmBasePlugPortInTube, _oFrmPortDetails, _oFrmDesignABasePlug})
                        FormNavigationOrder.Add(New Object(3) {"frmDesignABasePlug", _oFrmDesignABasePlug, _oFrmBasePlugPortInTube, _oFrmRodEndConfiguration})
                        RodEndNavigationOrder(_oFrmDesignABasePlug, FormNavigationOrder)
                    Else
                        FormNavigationOrder.Add(New Object(3) {"frmBasePlugPortInTube", _oFrmBasePlugPortInTube, _oFrmPortDetails, _oFrmRodEndConfiguration})
                        RodEndNavigationOrder(_oFrmBasePlugPortInTube, FormNavigationOrder)
                    End If
                End If
                ''*********************************************************

                ''*******************Cross Tube**************************************
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Cross Tube" Then
                'If _strIsPortIntegral_or_PortInTube = "Port Integral" Then
                '    FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmCTPortIntegral})
                '    If PortIntegral_ExistingDetailsFound Then
                '        If ShowCastingNo_Thru_CastingYes Then
                '            FormNavigationOrder.Add(New Object(3) {"frmCTPortIntegral", _oFrmCTPortIntegral, _oFrmPortDetails, _oFrmCTCastingNo_PortIntegral})
                '            FormNavigationOrder.Add(New Object(3) {"frmCTCastingNo_PortIntegral", _oFrmCTCastingNo_PortIntegral, _oFrmCTPortIntegral, _oFrmRodEndConfiguration})
                '            RodEndNavigationOrder(_oFrmCTCastingNo_PortIntegral, FormNavigationOrder)
                '        Else
                '            FormNavigationOrder.Add(New Object(3) {"frmCTPortIntegral", _oFrmCTPortIntegral, _oFrmPortDetails, _oFrmRodEndConfiguration})
                '            RodEndNavigationOrder(_oFrmCTPortIntegral, FormNavigationOrder)
                '        End If
                '    Else
                '        FormNavigationOrder.Add(New Object(3) {"frmCTPortIntegral", _oFrmCTPortIntegral, _oFrmPortDetails, _oFrmRodEndConfiguration})
                '        RodEndNavigationOrder(_oFrmCTPortIntegral, FormNavigationOrder)
                '    End If
                'ElseIf _strIsPortIntegral_or_PortInTube = "Port In Tube" Then
                '    FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmCTPortInTube})
                '    If ShowCastingNo_Thru_CastingYes Then
                '        FormNavigationOrder.Add(New Object(3) {"frmCTPortInTube", _oFrmCTPortInTube, _oFrmPortDetails, _oFrmCTCastingNo_PortInTube})
                '        FormNavigationOrder.Add(New Object(3) {"frmCTCastingNo_PortInTube", _oFrmCTCastingNo_PortInTube, _oFrmCTPortInTube, _oFrmRodEndConfiguration})
                '        RodEndNavigationOrder(_oFrmCTCastingNo_PortInTube, FormNavigationOrder)
                '    Else
                '        FormNavigationOrder.Add(New Object(3) {"frmCTPortInTube", _oFrmCTPortInTube, _oFrmPortDetails, _oFrmRodEndConfiguration})
                '        RodEndNavigationOrder(_oFrmCTPortInTube, FormNavigationOrder)
                '    End If
                'End If

                'priyanka
                ''If _strIsPortIntegral_or_PortInTube = "Port Integral" Then
                ''    FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmCTPortIntegral})
                ''    If PortIntegral_ExistingDetailsFound Then
                ''        If ShowCastingNo_Thru_CastingYes Then
                ''            FormNavigationOrder.Add(New Object(3) {"frmCTPortIntegral", _oFrmCTPortIntegral, _oFrmPortDetails, _oFrmCTCastingNo_PortIntegral})
                ''            FormNavigationOrder.Add(New Object(3) {"frmCTCastingNo_PortIntegral", _oFrmCTCastingNo_PortIntegral, _oFrmCTPortIntegral, _oFrmCTCastingNo_PortIntegral2})
                ''            FormNavigationOrder.Add(New Object(3) {"frmCTCastingNo_PortIntegral2", _oFrmCTCastingNo_PortIntegral2, _oFrmCTCastingNo_PortIntegral, _oFrmRodEndConfiguration})
                ''            RodEndNavigationOrder(_oFrmCTCastingNo_PortIntegral2, FormNavigationOrder)
                ''        Else
                ''            FormNavigationOrder.Add(New Object(3) {"frmCTPortIntegral", _oFrmCTPortIntegral, _oFrmPortDetails, _oFrmCTCastingNo_PortIntegral2})
                ''            FormNavigationOrder.Add(New Object(3) {"frmCTCastingNo_PortIntegral2", _oFrmCTCastingNo_PortIntegral2, _oFrmCTPortIntegral, _oFrmRodEndConfiguration})
                ''            RodEndNavigationOrder(_oFrmCTCastingNo_PortIntegral2, FormNavigationOrder)
                ''        End If
                ''    Else
                ''        FormNavigationOrder.Add(New Object(3) {"frmCTPortIntegral", _oFrmCTPortIntegral, _oFrmPortDetails, _oFrmCTPortIntegral2})
                ''        FormNavigationOrder.Add(New Object(3) {"frmCTPortIntegral2", _oFrmCTPortIntegral2, _oFrmCTPortIntegral, _oFrmRodEndConfiguration})
                ''        RodEndNavigationOrder(_oFrmCTPortIntegral2, FormNavigationOrder)
                ''    End If
                ''ElseIf _strIsPortIntegral_or_PortInTube = "Port In Tube" Then
                ''    FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmCTPortInTube})
                ''    If PortIntegral_ExistingDetailsFound Then
                ''        If ShowCastingNo_Thru_CastingYes Then
                ''            FormNavigationOrder.Add(New Object(3) {"frmCTPortInTube", _oFrmCTPortInTube, _oFrmPortDetails, _oFrmCTCastingNo_PortInTube})
                ''            FormNavigationOrder.Add(New Object(3) {"frmCTCastingNo_PortInTube", _oFrmCTCastingNo_PortInTube, _oFrmCTPortInTube, _oFrmCTCastingNo_PortInTube2})
                ''            FormNavigationOrder.Add(New Object(3) {"frmCTCastingNo_PortInTube2", _oFrmCTCastingNo_PortInTube2, _oFrmCTCastingNo_PortInTube, _oFrmRodEndConfiguration})
                ''            RodEndNavigationOrder(_oFrmCTCastingNo_PortInTube2, FormNavigationOrder)
                ''        Else
                ''            FormNavigationOrder.Add(New Object(3) {"frmCTPortInTube", _oFrmCTPortInTube, _oFrmPortDetails, _oFrmCTCastingNo_PortInTube2})
                ''            FormNavigationOrder.Add(New Object(3) {"frmCTCastingNo_PortInTube2", _oFrmCTCastingNo_PortInTube2, _oFrmCTPortInTube, _oFrmRodEndConfiguration})
                ''            RodEndNavigationOrder(_oFrmCTCastingNo_PortInTube2, FormNavigationOrder)
                ''        End If
                ''    Else
                ''        FormNavigationOrder.Add(New Object(3) {"frmCTPortInTube", _oFrmCTPortInTube, _oFrmPortDetails, _oFrmCTPortInTube2})
                ''        FormNavigationOrder.Add(New Object(3) {"frmCTPortInTube2", _oFrmCTPortInTube2, _oFrmCTPortInTube, _oFrmRodEndConfiguration})
                ''        RodEndNavigationOrder(_oFrmCTPortInTube2, FormNavigationOrder)
                ''    End If

                ''End If




                If _strIsPortIntegral_or_PortInTube = "Port Integral" Then
                    FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmCTPortIntegral})
                    If PortIntegral_ExistingDetailsFound Then
                        If ShowCastingNo_Thru_CastingYes Then

                            If ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortIntegral.chkCrossTubeFabricationRequired.Checked = True Then
                                FormNavigationOrder.Add(New Object(3) {"frmCTPortIntegral", _oFrmCTPortIntegral, _oFrmPortDetails, _oFrmCTCastingNo_PortIntegral})
                                FormNavigationOrder.Add(New Object(3) {"frmCTCastingNo_PortIntegral", _oFrmCTCastingNo_PortIntegral, _oFrmCTPortIntegral, _oFrmCTCastingNo_PortIntegral2})
                                FormNavigationOrder.Add(New Object(3) {"frmCTCastingNo_PortIntegral2", _oFrmCTCastingNo_PortIntegral2, _oFrmCTCastingNo_PortIntegral, _oFrmRodEndConfiguration})
                                RodEndNavigationOrder(_oFrmCTCastingNo_PortIntegral2, FormNavigationOrder)

                            Else
                                FormNavigationOrder.Add(New Object(3) {"frmCTPortIntegral", _oFrmCTPortIntegral, _oFrmPortDetails, _oFrmCTCastingNo_PortIntegral})
                                FormNavigationOrder.Add(New Object(3) {"frmCTCastingNo_PortIntegral", _oFrmCTCastingNo_PortIntegral, _oFrmCTPortIntegral, _oFrmRodEndConfiguration})
                                'FormNavigationOrder.Add(New Object(3) {"frmCTCastingNo_PortIntegral2", _oFrmCTCastingNo_PortIntegral2, _oFrmCTCastingNo_PortIntegral, _oFrmRodEndConfiguration})
                                RodEndNavigationOrder(_oFrmCTCastingNo_PortIntegral, FormNavigationOrder)
                            End If
                        Else

                            If ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingYes.chkCrossTubeFabricationRequired.Checked = True OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingYes.rdbNewCasting.Checked = True Then
                                FormNavigationOrder.Add(New Object(3) {"frmCTPortIntegral", _oFrmCTPortIntegral, _oFrmPortDetails, _oFrmCTCastingNo_PortIntegral2})
                                FormNavigationOrder.Add(New Object(3) {"frmCTCastingNo_PortIntegral2", _oFrmCTCastingNo_PortIntegral2, _oFrmCTPortIntegral, _oFrmRodEndConfiguration})
                                RodEndNavigationOrder(_oFrmCTCastingNo_PortIntegral2, FormNavigationOrder)

                            Else
                                FormNavigationOrder.Add(New Object(3) {"frmCTPortIntegral", _oFrmCTPortIntegral, _oFrmPortDetails, _oFrmRodEndConfiguration})
                                ' FormNavigationOrder.Add(New Object(3) {"frmCTCastingNo_PortIntegral2", _oFrmCTCastingNo_PortIntegral2, _oFrmCTPortIntegral, _oFrmRodEndConfiguration})
                                RodEndNavigationOrder(_oFrmCTPortIntegral, FormNavigationOrder)
                            End If
                        End If
                    Else
                        If ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortIntegral.chkCrossTubeFabricationRequired.Checked = True Then
                            FormNavigationOrder.Add(New Object(3) {"frmCTPortIntegral", _oFrmCTPortIntegral, _oFrmPortDetails, _oFrmCTPortIntegral2})
                            FormNavigationOrder.Add(New Object(3) {"frmCTPortIntegral2", _oFrmCTPortIntegral2, _oFrmCTPortIntegral, _oFrmRodEndConfiguration})
                            RodEndNavigationOrder(_oFrmCTPortIntegral2, FormNavigationOrder)
                        Else
                            FormNavigationOrder.Add(New Object(3) {"frmCTPortIntegral", _oFrmCTPortIntegral, _oFrmPortDetails, _oFrmRodEndConfiguration})
                            ' FormNavigationOrder.Add(New Object(3) {"frmCTPortIntegral2", _oFrmCTPortIntegral2, _oFrmCTPortIntegral, _oFrmRodEndConfiguration})
                            RodEndNavigationOrder(_oFrmCTPortIntegral, FormNavigationOrder)

                        End If
                    End If

                    ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortIntegral.chkCrossTubeFabricationRequired.Visible = False
                    If ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortIntegral.rdbDesignACasting.Checked = True Then
                        ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortIntegral.chkCrossTubeFabricationRequired.Visible = True
                    Else
                        ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortIntegral.chkCrossTubeFabricationRequired.Visible = False

                    End If

                ElseIf _strIsPortIntegral_or_PortInTube = "Port In Tube" Then
                    FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmCTPortInTube})
                    If PortIntegral_ExistingDetailsFound Then
                        If ShowCastingNo_Thru_CastingYes Then

                            If ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortInTube.chkCrossTubeFabricationRequired.Checked = True Then
                                FormNavigationOrder.Add(New Object(3) {"frmCTPortInTube", _oFrmCTPortInTube, _oFrmPortDetails, _oFrmCTCastingNo_PortInTube})
                                FormNavigationOrder.Add(New Object(3) {"frmCTCastingNo_PortInTube", _oFrmCTCastingNo_PortInTube, _oFrmCTPortInTube, _oFrmCTCastingNo_PortInTube2})
                                FormNavigationOrder.Add(New Object(3) {"frmCTCastingNo_PortInTube2", _oFrmCTCastingNo_PortInTube2, _oFrmCTCastingNo_PortInTube, _oFrmRodEndConfiguration})
                                RodEndNavigationOrder(_oFrmCTCastingNo_PortInTube2, FormNavigationOrder)

                            Else
                                FormNavigationOrder.Add(New Object(3) {"frmCTPortInTube", _oFrmCTPortInTube, _oFrmPortDetails, _oFrmCTCastingNo_PortInTube})
                                FormNavigationOrder.Add(New Object(3) {"frmCTCastingNo_PortInTube", _oFrmCTCastingNo_PortInTube, _oFrmCTPortInTube, _oFrmRodEndConfiguration})
                                'FormNavigationOrder.Add(New Object(3) {"frmCTCastingNo_PortInTube2", _oFrmCTCastingNo_PortInTube2, _oFrmCTCastingNo_PortInTube, _oFrmRodEndConfiguration})
                                RodEndNavigationOrder(_oFrmCTCastingNo_PortInTube, FormNavigationOrder)
                            End If
                        Else

                            If ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingYes.chkCrossTubeFabricationRequired.Checked = True OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingYes.rdbNewCasting.Checked = True Then
                                FormNavigationOrder.Add(New Object(3) {"frmCTPortInTube", _oFrmCTPortInTube, _oFrmPortDetails, _oFrmCTCastingNo_PortInTube2})
                                FormNavigationOrder.Add(New Object(3) {"frmCTCastingNo_PortInTube2", _oFrmCTCastingNo_PortInTube2, _oFrmCTPortInTube, _oFrmRodEndConfiguration})
                                RodEndNavigationOrder(_oFrmCTCastingNo_PortInTube2, FormNavigationOrder)

                            Else
                                FormNavigationOrder.Add(New Object(3) {"frmCTPortInTube", _oFrmCTPortInTube, _oFrmPortDetails, _oFrmRodEndConfiguration})
                                'FormNavigationOrder.Add(New Object(3) {"frmCTCastingNo_PortInTube2", _oFrmCTCastingNo_PortInTube2, _oFrmCTPortInTube, _oFrmRodEndConfiguration})
                                RodEndNavigationOrder(_oFrmCTPortInTube, FormNavigationOrder)
                            End If
                        End If
                    Else

                        If ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortInTube.chkCrossTubeFabricationRequired.Checked = True Then
                            FormNavigationOrder.Add(New Object(3) {"frmCTPortInTube", _oFrmCTPortInTube, _oFrmPortDetails, _oFrmCTPortInTube2})
                            FormNavigationOrder.Add(New Object(3) {"frmCTPortInTube2", _oFrmCTPortInTube2, _oFrmCTPortInTube, _oFrmRodEndConfiguration})
                            RodEndNavigationOrder(_oFrmCTPortInTube2, FormNavigationOrder)

                        Else
                            FormNavigationOrder.Add(New Object(3) {"frmCTPortInTube", _oFrmCTPortInTube, _oFrmPortDetails, _oFrmRodEndConfiguration})
                            'FormNavigationOrder.Add(New Object(3) {"frmCTPortInTube2", _oFrmCTPortInTube2, _oFrmCTPortInTube, _oFrmRodEndConfiguration})
                            RodEndNavigationOrder(_oFrmCTPortInTube, FormNavigationOrder)
                        End If

                    End If

                    ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortInTube.chkCrossTubeFabricationRequired.Visible = False
                    If ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortInTube.rdbDesignACasting.Checked = True Then
                        ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortInTube.chkCrossTubeFabricationRequired.Visible = True
                    Else
                        ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortInTube.chkCrossTubeFabricationRequired.Visible = False

                    End If
                End If

                'Till Here priyanka 






                ''*********************************************************

                ''*******************Threaded End**************************************
                '09_12_2009  RAGAVA
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Threaded End" Then
                If _strIsPortIntegral_or_PortInTube = "Port Integral" Then
                    FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmThreadedEndPortIntegral})
                    If PortIntegral_ExistingDetailsFound Then
                        If ShowCastingNo_Thru_CastingYes Then
                            FormNavigationOrder.Add(New Object(3) {"frmThreadedEndPortIntegral", _oFrmThreadedEndPortIntegral, _oFrmPortDetails, _oFrmBEThreadedEndCastingNo_PortIntegral})
                            FormNavigationOrder.Add(New Object(3) {"frmBEThreadedEndCastingNo_PortIntegral", _oFrmBEThreadedEndCastingNo_PortIntegral, _oFrmThreadedEndPortIntegral, _oFrmRodEndConfiguration})
                            RodEndNavigationOrder(_oFrmBEThreadedEndCastingNo_PortIntegral, FormNavigationOrder)
                        Else
                            FormNavigationOrder.Add(New Object(3) {"frmThreadedEndPortIntegral", _oFrmThreadedEndPortIntegral, _oFrmPortDetails, _oFrmRodEndConfiguration})
                            RodEndNavigationOrder(_oFrmThreadedEndPortIntegral, FormNavigationOrder)
                        End If
                    Else
                        FormNavigationOrder.Add(New Object(3) {"frmThreadedEndPortIntegral", _oFrmThreadedEndPortIntegral, _oFrmPortDetails, _oFrmRodEndConfiguration})
                        RodEndNavigationOrder(_oFrmThreadedEndPortIntegral, FormNavigationOrder)
                    End If
                ElseIf _strIsPortIntegral_or_PortInTube = "Port In Tube" Then
                    FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmThreadedPortInTube})
                    If ShowCastingNo_Thru_CastingYes Then
                        FormNavigationOrder.Add(New Object(3) {"frmThreadedEndPortInTube", _oFrmThreadedPortInTube, _oFrmPortDetails, _oFrmDesignAThreadedCasting})
                        FormNavigationOrder.Add(New Object(3) {"frmDesignAThreadedCasting", _oFrmDesignAThreadedCasting, _oFrmThreadedPortInTube, _oFrmRodEndConfiguration})
                        RodEndNavigationOrder(_oFrmDesignAThreadedCasting, FormNavigationOrder)
                    Else
                        FormNavigationOrder.Add(New Object(3) {"frmThreadedEndPortInTube", _oFrmThreadedPortInTube, _oFrmPortDetails, _oFrmRodEndConfiguration})
                        RodEndNavigationOrder(_oFrmThreadedPortInTube, FormNavigationOrder)
                    End If
                End If
                '09_12_2009  RAGAVA Till Here
                ''*********************************************************

                'A0308: ANUP 09-08-2010 02.15pm
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Import" Then
                FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmImportBaseEnd})
                FormNavigationOrder.Add(New Object(3) {"frmImportBaseEnd", _oFrmImportBaseEnd, _oFrmPortDetails, _oFrmRodEndConfiguration})
                RodEndNavigationOrder(_oFrmImportBaseEnd, FormNavigationOrder)
            End If

            Return FormNavigationOrder
        End Get
    End Property

    'Public ReadOnly Property FormNavigationOrder() As ArrayList
    '    Get
    '        FormNavigationOrder = New ArrayList
    '        ': ANUP 27-05-2010 01.51pm
    '        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.New_Revision = "New'" Then
    '            FormNavigationOrder.Add(New Object(3) {"frmContractDetails", _oFrmContractDetails, Nothing, _oFrmPrimaryInputs})
    '            FormNavigationOrder.Add(New Object(3) {"frmPrimaryInputs", _oFrmPrimaryInputs, _oFrmContractDetails, _oFrmPistonDesign})
    '        Else
    '            FormNavigationOrder.Add(New Object(3) {"frmMonarchRevision", _oFrmMonarchRevision, Nothing, _oFrmPrimaryInputs})
    '            'FormNavigationOrder.Add(New Object(3) {"frmContractDetails", _oFrmContractDetails, _oFrmMonarchRevision, _oFrmPrimaryInputs})
    '            FormNavigationOrder.Add(New Object(3) {"frmPrimaryInputs", _oFrmPrimaryInputs, _oFrmContractDetails, _oFrmPistonDesign})
    '        End If
    '        '*****************
    '        'FormNavigationOrder.Add(New Object(3) {"frmPrimaryInputs", _oFrmPrimaryInputs, Nothing, _oFrmPistonDesign})
    '        FormNavigationOrder.Add(New Object(3) {"frmPistonDesign", _oFrmPistonDesign, _oFrmPrimaryInputs, _oFrmHeadDesign})
    '        FormNavigationOrder.Add(New Object(3) {"frmHeadDesign", _oFrmHeadDesign, _oFrmPistonDesign, _oFrmTubeDetails})
    '        FormNavigationOrder.Add(New Object(3) {"frmTubeDetails", _oFrmTubeDetails, _oFrmHeadDesign, _oFrmPortDetails})
    '        ''*******************DoubleLub**************************************
    '        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" Then
    '            If _strIsPortIntegral_or_PortInTube = "Port Integral" Then
    '                FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmDLPortIntegral})
    '                If _blnShowPortInTube_Thru_PortIntegral Then

    '                    FormNavigationOrder.Add(New Object(3) {"frmDLPortIntegral", _oFrmDLPortIntegral, _oFrmPortDetails, _oFrmDLPortInTubeDetails})
    '                    ''TODO: ANUP 26-05-2010 10.08am
    '                    'FormNavigationOrder.Add(New Object(3) {"frmDLPortIntegral", _oFrmDLPortIntegral, _oFrmPortDetails, _oFrmPortDetails})
    '                    'FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmDLPortInTubeDetails})
    '                    '' *************************

    '                    If ShowCastingNo_Thru_CastingYes Then
    '                        FormNavigationOrder.Add(New Object(3) {"frmDLPortInTubeDetails", _oFrmDLPortInTubeDetails, _oFrmDLPortIntegral, _oFrmDLCastingNo_PortIntegral})
    '                        FormNavigationOrder.Add(New Object(3) {"frmDLCastingNo_PortIntegral", _oFrmDLCastingNo_PortIntegral, _oFrmDLPortInTubeDetails, _oFrmRodEndConfiguration})
    '                        RodEndNavigationOrder(_oFrmDLCastingNo_PortIntegral, FormNavigationOrder)
    '                    Else
    '                        FormNavigationOrder.Add(New Object(3) {"frmDLPortInTubeDetails", _oFrmDLPortInTubeDetails, _oFrmDLPortIntegral, _oFrmRodEndConfiguration})
    '                        RodEndNavigationOrder(_oFrmDLPortInTubeDetails, FormNavigationOrder)
    '                    End If
    '                Else
    '                    FormNavigationOrder.Add(New Object(3) {"frmDLPortIntegral", _oFrmDLPortIntegral, _oFrmPortDetails, _oFrmRodEndConfiguration})
    '                    RodEndNavigationOrder(_oFrmDLPortIntegral, FormNavigationOrder)
    '                End If
    '            ElseIf _strIsPortIntegral_or_PortInTube = "Port In Tube" Then
    '                FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmDLPortInTubeDetails})
    '                If ShowCastingNo_Thru_CastingYes Then
    '                    FormNavigationOrder.Add(New Object(3) {"frmDLPortInTubeDetails", _oFrmDLPortInTubeDetails, _oFrmPortDetails, _oFrmDLCastingNo_PortInTube})
    '                    FormNavigationOrder.Add(New Object(3) {"frmDLCastingNo_PortInTube", _oFrmDLCastingNo_PortInTube, _oFrmDLPortInTubeDetails, _oFrmRodEndConfiguration})
    '                    RodEndNavigationOrder(_oFrmDLCastingNo_PortInTube, FormNavigationOrder)
    '                Else
    '                    FormNavigationOrder.Add(New Object(3) {"frmDLPortInTubeDetails", _oFrmDLPortInTubeDetails, _oFrmPortDetails, _oFrmRodEndConfiguration})
    '                    RodEndNavigationOrder(_oFrmDLPortInTubeDetails, FormNavigationOrder)
    '                End If
    '            End If
    '            ''*********************************************************




    '            ''*******************PlateClevis**************************************
    '        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Plate Clevis" Then
    '            FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmConPlateClevis})
    '            FormNavigationOrder.Add(New Object(3) {"frmConPlateClevis", _oFrmConPlateClevis, _oFrmPortDetails, _oFrmRodEndConfiguration})
    '            RodEndNavigationOrder(_oFrmConPlateClevis, FormNavigationOrder)
    '            ''*********************************************************




    '            ''*******************SingleLug**************************************
    '        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Single Lug" Then
    '            If _strIsPortIntegral_or_PortInTube = "Port Integral" Then
    '                FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmSLPortIntegral})
    '                If _blnShowPortInTube_Thru_PortIntegral Then
    '                    FormNavigationOrder.Add(New Object(3) {"frmSLPortIntegral", _oFrmSLPortIntegral, _oFrmPortDetails, _oFrmSLPortinTube})
    '                    ''TODO: ANUP 26-05-2010 10.08am
    '                    'FormNavigationOrder.Add(New Object(3) {"frmSLPortIntegral", _oFrmSLPortIntegral, _oFrmPortDetails, _oFrmPortDetails})
    '                    'FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmSLPortinTube})
    '                    ''*************************

    '                    If ShowCastingNo_Thru_CastingYes Then
    '                        FormNavigationOrder.Add(New Object(3) {"frmSLPortinTube", _oFrmSLPortinTube, _oFrmSLPortIntegral, _oFrmSLCastingNo_PortIntegral})
    '                        FormNavigationOrder.Add(New Object(3) {"frmSLCastingNo_PortIntegral", _oFrmSLCastingNo_PortIntegral, _oFrmSLPortinTube, _oFrmRodEndConfiguration})
    '                        RodEndNavigationOrder(_oFrmSLCastingNo_PortIntegral, FormNavigationOrder)
    '                    Else
    '                        FormNavigationOrder.Add(New Object(3) {"frmSLPortinTube", _oFrmSLPortinTube, _oFrmSLPortIntegral, _oFrmRodEndConfiguration})
    '                        RodEndNavigationOrder(_oFrmSLPortinTube, FormNavigationOrder)
    '                    End If
    '                Else
    '                    FormNavigationOrder.Add(New Object(3) {"frmSLPortIntegral", _oFrmSLPortIntegral, _oFrmPortDetails, _oFrmRodEndConfiguration})
    '                    RodEndNavigationOrder(_oFrmSLCastingNo_PortIntegral, FormNavigationOrder)
    '                End If
    '            ElseIf _strIsPortIntegral_or_PortInTube = "Port In Tube" Then
    '                FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmSLPortinTube})
    '                If ShowCastingNo_Thru_CastingYes Then
    '                    FormNavigationOrder.Add(New Object(3) {"frmSLPortinTube", _oFrmSLPortinTube, _oFrmPortDetails, _oFrmSLCastingNo_PortInTube})
    '                    FormNavigationOrder.Add(New Object(3) {"frmSLCastingNo_PortInTube", _oFrmSLCastingNo_PortInTube, _oFrmSLPortinTube, _oFrmRodEndConfiguration})
    '                    RodEndNavigationOrder(_oFrmSLCastingNo_PortInTube, FormNavigationOrder)
    '                    'FormNavigationOrder.Add(New Object(3) {"frmRodEndConfiguration", _oFrmRodEndConfiguration, _oFrmSLCastingNo_PortInTube, Nothing})
    '                Else
    '                    FormNavigationOrder.Add(New Object(3) {"frmSLPortinTube", _oFrmSLPortinTube, _oFrmPortDetails, _oFrmRodEndConfiguration})
    '                    RodEndNavigationOrder(_oFrmSLPortinTube, FormNavigationOrder)
    '                    'FormNavigationOrder.Add(New Object(3) {"frmRodEndConfiguration", _oFrmRodEndConfiguration, _oFrmSLPortinTube, Nothing})
    '                End If
    '            End If
    '            ''*********************************************************




    '            '    ''*******************Base Plug**************************************
    '            'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Base Plug" Then
    '            '    If _strIsPortIntegral_or_PortInTube = "Port Integral" Then
    '            '        FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmBasePlugPortIntegral})
    '            '        FormNavigationOrder.Add(New Object(3) {"frmBasePlugPortIntegral", _oFrmBasePlugPortIntegral, _oFrmPortDetails, _oFrmRodEndConfiguration})
    '            '        RodEndNavigationOrder(_oFrmBasePlugPortIntegral, FormNavigationOrder)
    '            '    ElseIf _strIsPortIntegral_or_PortInTube = "Port In Tube" Then
    '            '        FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmBasePlugPortInTube})
    '            '        If ShowCastingNo_Thru_CastingYes Then
    '            '            FormNavigationOrder.Add(New Object(3) {"frmBasePlugPortInTube", _oFrmBasePlugPortInTube, _oFrmPortDetails, _oFrmDesignABasePlug})
    '            '            FormNavigationOrder.Add(New Object(3) {"frmDesignABasePlug", _oFrmDesignABasePlug, _oFrmBasePlugPortInTube, _oFrmRodEndConfiguration})
    '            '            RodEndNavigationOrder(_oFrmDesignABasePlug, FormNavigationOrder)
    '            '        Else
    '            '            FormNavigationOrder.Add(New Object(3) {"frmBasePlugPortInTube", _oFrmBasePlugPortInTube, _oFrmPortDetails, _oFrmRodEndConfiguration})
    '            '            RodEndNavigationOrder(_oFrmBasePlugPortInTube, FormNavigationOrder)
    '            '        End If
    '            '    End If
    '            '    ''*********************************************************

    '            ' ANUP 08-03-2010 04.26
    '            ''*******************Base Plug**************************************
    '        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Base Plug" Then
    '            If _strIsPortIntegral_or_PortInTube = "Port Integral" Then
    '                FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmBasePlugPortIntegral})
    '                If _blnShowPortInTube_Thru_PortIntegral Then

    '                    FormNavigationOrder.Add(New Object(3) {"frmBasePlugPortIntegral", _oFrmBasePlugPortIntegral, _oFrmPortDetails, _oFrmBasePlugPortInTube})
    '                    ''TODO: ANUP 26-05-2010 10.08am
    '                    'FormNavigationOrder.Add(New Object(3) {"frmBasePlugPortIntegral", _oFrmBasePlugPortIntegral, _oFrmPortDetails, _oFrmPortDetails})
    '                    'FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmBasePlugPortInTube})
    '                    ''*************************

    '                    If ShowCastingNo_Thru_CastingYes Then
    '                        FormNavigationOrder.Add(New Object(3) {"frmBasePlugPortInTube", _oFrmBasePlugPortInTube, _oFrmPortDetails, _oFrmDesignABasePlug})
    '                        FormNavigationOrder.Add(New Object(3) {"frmDesignABasePlug", _oFrmDesignABasePlug, _oFrmBasePlugPortInTube, _oFrmRodEndConfiguration})
    '                        RodEndNavigationOrder(_oFrmDesignABasePlug, FormNavigationOrder)
    '                    Else
    '                        FormNavigationOrder.Add(New Object(3) {"frmBasePlugPortInTube", _oFrmBasePlugPortInTube, _oFrmBasePlugPortIntegral, _oFrmRodEndConfiguration})
    '                        RodEndNavigationOrder(_oFrmBasePlugPortInTube, FormNavigationOrder)
    '                    End If
    '                Else
    '                    FormNavigationOrder.Add(New Object(3) {"frmBasePlugPortIntegral", _oFrmBasePlugPortIntegral, _oFrmPortDetails, _oFrmRodEndConfiguration})
    '                    RodEndNavigationOrder(_oFrmBasePlugPortIntegral, FormNavigationOrder)
    '                End If
    '            ElseIf _strIsPortIntegral_or_PortInTube = "Port In Tube" Then
    '                FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmBasePlugPortInTube})
    '                If ShowCastingNo_Thru_CastingYes Then
    '                    FormNavigationOrder.Add(New Object(3) {"frmBasePlugPortInTube", _oFrmBasePlugPortInTube, _oFrmPortDetails, _oFrmDesignABasePlug})
    '                    FormNavigationOrder.Add(New Object(3) {"frmDesignABasePlug", _oFrmDesignABasePlug, _oFrmBasePlugPortInTube, _oFrmRodEndConfiguration})
    '                    RodEndNavigationOrder(_oFrmDesignABasePlug, FormNavigationOrder)
    '                Else
    '                    FormNavigationOrder.Add(New Object(3) {"frmBasePlugPortInTube", _oFrmBasePlugPortInTube, _oFrmPortDetails, _oFrmRodEndConfiguration})
    '                    RodEndNavigationOrder(_oFrmBasePlugPortInTube, FormNavigationOrder)
    '                End If
    '            End If
    '            ''*********************************************************
    '            ''*******************Cross Tube**************************************
    '        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Cross Tube" Then
    '            If _strIsPortIntegral_or_PortInTube = "Port Integral" Then
    '                FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmCTPortIntegral})
    '                If _blnShowPortInTube_Thru_PortIntegral Then

    '                    FormNavigationOrder.Add(New Object(3) {"frmCTPortIntegral", _oFrmCTPortIntegral, _oFrmPortDetails, _oFrmCTPortInTube})
    '                    ''TODO: ANUP 26-05-2010 10.08am
    '                    'FormNavigationOrder.Add(New Object(3) {"frmCTPortIntegral", _oFrmCTPortIntegral, _oFrmPortDetails, _oFrmPortDetails})
    '                    'FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmCTPortInTube})
    '                    ''*************************

    '                    If ShowCastingNo_Thru_CastingYes Then
    '                        FormNavigationOrder.Add(New Object(3) {"frmCTPortInTube", _oFrmCTPortInTube, _oFrmCTPortIntegral, _oFrmCTCastingNo_PortIntegral})
    '                        FormNavigationOrder.Add(New Object(3) {"frmCTCastingNo_PortIntegral", _oFrmCTCastingNo_PortIntegral, _oFrmCTPortInTube, _oFrmRodEndConfiguration})
    '                        RodEndNavigationOrder(_oFrmCTCastingNo_PortIntegral, FormNavigationOrder)
    '                    Else
    '                        FormNavigationOrder.Add(New Object(3) {"frmCTPortInTube", _oFrmCTPortInTube, _oFrmCTPortIntegral, _oFrmRodEndConfiguration})
    '                        RodEndNavigationOrder(_oFrmCTPortInTube, FormNavigationOrder)
    '                    End If
    '                Else
    '                    FormNavigationOrder.Add(New Object(3) {"frmCTPortIntegral", _oFrmCTPortIntegral, _oFrmPortDetails, _oFrmRodEndConfiguration})
    '                    RodEndNavigationOrder(_oFrmCTPortIntegral, FormNavigationOrder)
    '                End If
    '            ElseIf _strIsPortIntegral_or_PortInTube = "Port In Tube" Then
    '                FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmCTPortInTube})
    '                If ShowCastingNo_Thru_CastingYes Then
    '                    FormNavigationOrder.Add(New Object(3) {"frmCTPortInTube", _oFrmCTPortInTube, _oFrmPortDetails, _oFrmCTCastingNo_PortInTube})
    '                    FormNavigationOrder.Add(New Object(3) {"frmCTCastingNo_PortInTube", _oFrmCTCastingNo_PortInTube, _oFrmCTPortInTube, _oFrmRodEndConfiguration})
    '                    RodEndNavigationOrder(_oFrmCTCastingNo_PortInTube, FormNavigationOrder)
    '                Else
    '                    FormNavigationOrder.Add(New Object(3) {"frmCTPortInTube", _oFrmCTPortInTube, _oFrmPortDetails, _oFrmRodEndConfiguration})
    '                    RodEndNavigationOrder(_oFrmCTPortInTube, FormNavigationOrder)
    '                End If
    '            End If
    '            ''*********************************************************
    '            ''*******************Threaded End**************************************
    '            '09_12_2009  RAGAVA
    '        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Threaded End" Then
    '            If _strIsPortIntegral_or_PortInTube = "Port Integral" Then
    '                FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmThreadedEndPortIntegral})
    '                If _blnShowPortInTube_Thru_PortIntegral Then

    '                    FormNavigationOrder.Add(New Object(3) {"frmThreadedEndPortIntegral", _oFrmThreadedEndPortIntegral, _oFrmPortDetails, _oFrmThreadedPortInTube})
    '                    ''TODO: ANUP 26-05-2010 10.08am
    '                    'FormNavigationOrder.Add(New Object(3) {"frmThreadedEndPortIntegral", _oFrmThreadedEndPortIntegral, _oFrmPortDetails, _oFrmPortDetails})
    '                    'FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmThreadedPortInTube})
    '                    ''*************************

    '                    If ShowCastingNo_Thru_CastingYes Then
    '                        FormNavigationOrder.Add(New Object(3) {"frmThreadedEndPortInTube", _oFrmThreadedPortInTube, _oFrmPortDetails, _oFrmDesignAThreadedCasting})
    '                        FormNavigationOrder.Add(New Object(3) {"frmDesignAThreadedCasting", _oFrmDesignAThreadedCasting, _oFrmThreadedPortInTube, _oFrmRodEndConfiguration})
    '                        RodEndNavigationOrder(_oFrmDesignAThreadedCasting, FormNavigationOrder)
    '                    Else
    '                        FormNavigationOrder.Add(New Object(3) {"frmThreadedEndPortInTube", _oFrmThreadedPortInTube, _oFrmPortDetails, _oFrmRodEndConfiguration})
    '                        RodEndNavigationOrder(_oFrmThreadedPortInTube, FormNavigationOrder)
    '                    End If
    '                Else
    '                    FormNavigationOrder.Add(New Object(3) {"frmThreadedEndPortIntegral", _oFrmThreadedEndPortIntegral, _oFrmPortDetails, _oFrmRodEndConfiguration})
    '                    RodEndNavigationOrder(_oFrmThreadedEndPortIntegral, FormNavigationOrder)
    '                End If
    '            ElseIf _strIsPortIntegral_or_PortInTube = "Port In Tube" Then
    '                FormNavigationOrder.Add(New Object(3) {"frmPortDetails", _oFrmPortDetails, _oFrmTubeDetails, _oFrmThreadedPortInTube})
    '                If ShowCastingNo_Thru_CastingYes Then
    '                    FormNavigationOrder.Add(New Object(3) {"frmThreadedEndPortInTube", _oFrmThreadedPortInTube, _oFrmPortDetails, _oFrmDesignAThreadedCasting})
    '                    FormNavigationOrder.Add(New Object(3) {"frmDesignAThreadedCasting", _oFrmDesignAThreadedCasting, _oFrmThreadedPortInTube, _oFrmRodEndConfiguration})
    '                    RodEndNavigationOrder(_oFrmDesignAThreadedCasting, FormNavigationOrder)
    '                Else
    '                    FormNavigationOrder.Add(New Object(3) {"frmThreadedEndPortInTube", _oFrmThreadedPortInTube, _oFrmPortDetails, _oFrmRodEndConfiguration})
    '                    RodEndNavigationOrder(_oFrmThreadedPortInTube, FormNavigationOrder)
    '                End If
    '            End If
    '            '09_12_2009  RAGAVA Till Here
    '            ''*********************************************************
    '        End If
    '        Return FormNavigationOrder
    '    End Get
    'End Property

    ' _oFrmGenerate

    'TODO: ANUP 22-04-2010 03.08pm
    Private Sub RodEndNavigationOrder(ByVal oFrmPrevious As Form, ByVal aNavigationOrder As ArrayList)
        ''*******************Flat With Chamfer***********************************************
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Flat With Chamfer" Then

            aNavigationOrder.Add(New Object(3) {"frmRodEndConfiguration", _oFrmRodEndConfiguration, oFrmPrevious, _oFrmFlatWithChamfer})
            aNavigationOrder.Add(New Object(3) {"frmFlatWithChamfer", _oFrmFlatWithChamfer, _oFrmRodEndConfiguration, _oFrmRetractedLengthValidation})
            aNavigationOrder.Add(New Object(3) {"frmRetractedLengthValidation", _oFrmRetractedLengthValidation, _oFrmFlatWithChamfer, _oFrmPin_Port_PaintAccessories})
            If ObjClsWeldedGlobalVariables.SkipRetractedIfPositiveFromGenerate Then
                aNavigationOrder.Add(New Object(3) {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmFlatWithChamfer, _oFrmGenerate})
            Else
                aNavigationOrder.Add(New Object(3) {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmRetractedLengthValidation, _oFrmGenerate})
            End If
            aNavigationOrder.Add(New Object(3) {"frmGenerate", _oFrmGenerate, _oFrmPin_Port_PaintAccessories, Nothing})
            ''***************************************************************************


            ''*******************Drilled Pin Hole***********************************************
        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Drilled Pin Hole" Then

            'TODO: ANUP 22-04-2010 10.41am
            aNavigationOrder.Add(New Object(3) {"frmRodEndConfiguration", _oFrmRodEndConfiguration, oFrmPrevious, _oFrmRetractedLengthValidation})
            aNavigationOrder.Add(New Object(3) {"frmRetractedLengthValidation", _oFrmRetractedLengthValidation, _oFrmRodEndConfiguration, _oFrmPin_Port_PaintAccessories})
            If ObjClsWeldedGlobalVariables.SkipRetractedIfPositiveFromGenerate Then
                aNavigationOrder.Add(New Object(3) {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmRodEndConfiguration, _oFrmGenerate})
            Else
                aNavigationOrder.Add(New Object(3) {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmRetractedLengthValidation, _oFrmGenerate})
            End If
            aNavigationOrder.Add(New Object(3) {"frmGenerate", _oFrmGenerate, _oFrmPin_Port_PaintAccessories, Nothing})
            '*****************



            ''***************************************************************************


            ''*******************Threaded Rod***********************************************
        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Threaded Rod" Then
            aNavigationOrder.Add(New Object(3) {"frmRodEndConfiguration", _oFrmRodEndConfiguration, oFrmPrevious, _oFrmREThreadedRod})
            aNavigationOrder.Add(New Object(3) {"frmREThreadedRod", _oFrmREThreadedRod, _oFrmRodEndConfiguration, _oFrmRetractedLengthValidation})
            aNavigationOrder.Add(New Object(3) {"frmRetractedLengthValidation", _oFrmRetractedLengthValidation, _oFrmREThreadedRod, _oFrmPin_Port_PaintAccessories})
            If ObjClsWeldedGlobalVariables.SkipRetractedIfPositiveFromGenerate Then
                aNavigationOrder.Add(New Object(3) {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmFlatWithChamfer, _oFrmGenerate})
            Else
                aNavigationOrder.Add(New Object(3) {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmRetractedLengthValidation, _oFrmGenerate})
            End If
            aNavigationOrder.Add(New Object(3) {"frmGenerate", _oFrmGenerate, _oFrmPin_Port_PaintAccessories, Nothing})

            ''***************************************************************************



            ''*******************Single Lug***********************************************
        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Single Lug" Then
            aNavigationOrder.Add(New Object(3) {"frmRodEndConfiguration", _oFrmRodEndConfiguration, oFrmPrevious, _oFrmRESingleLugDetails})
            If ShowCasting_Thru_ExistingRESL Then
                aNavigationOrder.Add(New Object(3) {"frmRESingleLugDetails", _oFrmRESingleLugDetails, _oFrmRodEndConfiguration, _oFrmRESingleLugExistingNotSelected})
                aNavigationOrder.Add(New Object(3) {"frmRESingleLugExistingNotSelected", _oFrmRESingleLugExistingNotSelected, _oFrmRESingleLugDetails, _oFrmRetractedLengthValidation})
            Else
                aNavigationOrder.Add(New Object(3) {"frmRESingleLugDetails", _oFrmRESingleLugDetails, _oFrmRodEndConfiguration, _oFrmRetractedLengthValidation})
            End If
            aNavigationOrder.Add(New Object(3) {"frmRetractedLengthValidation", _oFrmRetractedLengthValidation, _oFrmRESingleLugDetails, _oFrmPin_Port_PaintAccessories})
            If ObjClsWeldedGlobalVariables.SkipRetractedIfPositiveFromGenerate Then
                aNavigationOrder.Add(New Object(3) {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmRESingleLugDetails, _oFrmGenerate})
            Else
                aNavigationOrder.Add(New Object(3) {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmRetractedLengthValidation, _oFrmGenerate})
            End If
            aNavigationOrder.Add(New Object(3) {"frmGenerate", _oFrmGenerate, _oFrmPin_Port_PaintAccessories, Nothing})



            ''***************************************************************************


            ''******************* BH ***********************************************
        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "BH" Then
            aNavigationOrder.Add(New Object(3) {"frmRodEndConfiguration", _oFrmRodEndConfiguration, oFrmPrevious, _oFrmREBHDetails})
            If ShowCasting_Thru_ExistingREBH Then
                aNavigationOrder.Add(New Object(3) {"frmREBHDetails", _oFrmREBHDetails, _oFrmRodEndConfiguration, _oFrmREBHExistingNotSelected})
                aNavigationOrder.Add(New Object(3) {"frmREBHExistingNotSelected", _oFrmREBHExistingNotSelected, _oFrmREBHDetails, _oFrmRetractedLengthValidation})
            Else
                aNavigationOrder.Add(New Object(3) {"frmREBHDetails", _oFrmREBHDetails, _oFrmRodEndConfiguration, _oFrmRetractedLengthValidation})
            End If
            aNavigationOrder.Add(New Object(3) {"frmRetractedLengthValidation", _oFrmRetractedLengthValidation, _oFrmREBHDetails, _oFrmPin_Port_PaintAccessories})
            If ObjClsWeldedGlobalVariables.SkipRetractedIfPositiveFromGenerate Then
                aNavigationOrder.Add(New Object(3) {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmREBHDetails, _oFrmGenerate})
            Else
                aNavigationOrder.Add(New Object(3) {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmRetractedLengthValidation, _oFrmGenerate})
            End If
            aNavigationOrder.Add(New Object(3) {"frmGenerate", _oFrmGenerate, _oFrmPin_Port_PaintAccessories, Nothing})



            ''***************************************************************************


            ''*******************Double Lug***********************************************
        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug" Then

            '10-03-14 VAMSI START
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConnectionType = "Threaded" Then
                aNavigationOrder.Add(New Object(3) {"frmRodEndConfiguration", _oFrmRodEndConfiguration, oFrmPrevious, _oFrmREDLThreaded})
                If ObjClsWeldedCylinderFunctionalClass.ShowWelded_Thru_Threaded_REDL Then 'OrElse ShowCastingNo_Thru_CastingYes Then
                    aNavigationOrder.Add(New Object(3) {"frmREDLThreaded", _oFrmREDLThreaded, _oFrmRodEndConfiguration, _oFrmREDLWelded})
                    'ANUP 23-03-2010 12.24
                    aNavigationOrder.Add(New Object(3) {"frmREDLWelded", _oFrmREDLWelded, _oFrmREDLThreaded, _oFrmRetractedLengthValidation})
                    aNavigationOrder.Add(New Object(3) {"frmRetractedLengthValidation", _oFrmRetractedLengthValidation, _oFrmREDLThreaded, _oFrmPin_Port_PaintAccessories})
                    If ObjClsWeldedGlobalVariables.SkipRetractedIfPositiveFromGenerate Then
                        aNavigationOrder.Add(New Object(3) {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmREDLThreaded, _oFrmGenerate})
                    Else
                        aNavigationOrder.Add(New Object(3) {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmRetractedLengthValidation, _oFrmGenerate})
                    End If
                    aNavigationOrder.Add(New Object(3) {"frmGenerate", _oFrmGenerate, _oFrmPin_Port_PaintAccessories, Nothing})
                Else
                    aNavigationOrder.Add(New Object(3) {"frmREDLThreaded", _oFrmREDLThreaded, _oFrmRodEndConfiguration, _oFrmRetractedLengthValidation})
                    aNavigationOrder.Add(New Object(3) {"frmRetractedLengthValidation", _oFrmRetractedLengthValidation, _oFrmREDLThreaded, _oFrmPin_Port_PaintAccessories})
                    If ObjClsWeldedGlobalVariables.SkipRetractedIfPositiveFromGenerate Then
                        aNavigationOrder.Add(New Object(3) {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmREDLThreaded, _oFrmGenerate})
                    Else
                        aNavigationOrder.Add(New Object(3) {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmRetractedLengthValidation, _oFrmGenerate})
                    End If
                    aNavigationOrder.Add(New Object(3) {"frmGenerate", _oFrmGenerate, _oFrmPin_Port_PaintAccessories, Nothing})
                End If

            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConnectionType = "Welded" Then
                'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass = 1 OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass = 2 Then
                '    aNavigationOrder.Add(New Object(3) {"frmRodEndConfiguration", _oFrmRodEndConfiguration, oFrmPrevious, _oFrmREDLWelded})
                '    If ObjClsWeldedCylinderFunctionalClass.ShowCasting_Thru_Welded_REDL Then
                '        aNavigationOrder.Add(New Object(3) {"frmREDLWelded", _oFrmREDLWelded, _oFrmRodEndConfiguration, _oFrmREDLCasting})
                '        aNavigationOrder.Add(New Object(3) {"frmREDLCasting", _oFrmREDLCasting, _oFrmREDLWelded, _oFrmRetractedLengthValidation})
                '        aNavigationOrder.Add(New Object(3) {"frmRetractedLengthValidation", _oFrmRetractedLengthValidation, _oFrmREDLWelded, _oFrmGenerate})
                '        If ObjClsWeldedGlobalVariables.SkipRetractedIfPositiveFromGenerate Then
                '            aNavigationOrder.Add(New Object(3) {"frmGenerate", _oFrmGenerate, _oFrmREDLWelded, Nothing})
                '        Else
                '            aNavigationOrder.Add(New Object(3) {"frmGenerate", _oFrmGenerate, _oFrmRetractedLengthValidation, Nothing})
                '        End If
                '    Else
                '        aNavigationOrder.Add(New Object(3) {"frmREDLWelded", _oFrmREDLWelded, _oFrmRodEndConfiguration, _oFrmRetractedLengthValidation})
                '        aNavigationOrder.Add(New Object(3) {"frmRetractedLengthValidation", _oFrmRetractedLengthValidation, _oFrmREDLWelded, _oFrmGenerate})
                '        If ObjClsWeldedGlobalVariables.SkipRetractedIfPositiveFromGenerate Then
                '            aNavigationOrder.Add(New Object(3) {"frmGenerate", _oFrmGenerate, _oFrmREDLWelded, Nothing})
                '        Else
                '            aNavigationOrder.Add(New Object(3) {"frmGenerate", _oFrmGenerate, _oFrmRetractedLengthValidation, Nothing})
                '        End If
                '    End If
                'Else
                '    aNavigationOrder.Add(New Object(3) {"frmRodEndConfiguration", _oFrmRodEndConfiguration, oFrmPrevious, _oFrmREDLCasting})
                '    aNavigationOrder.Add(New Object(3) {"frmREDLCasting", _oFrmREDLCasting, _oFrmRodEndConfiguration, _oFrmRetractedLengthValidation})
                '    aNavigationOrder.Add(New Object(3) {"frmRetractedLengthValidation", _oFrmRetractedLengthValidation, _oFrmREDLCasting, _oFrmGenerate})
                '    If ObjClsWeldedGlobalVariables.SkipRetractedIfPositiveFromGenerate Then
                '        aNavigationOrder.Add(New Object(3) {"frmGenerate", _oFrmGenerate, _oFrmREDLCasting, Nothing})
                '    Else
                '        aNavigationOrder.Add(New Object(3) {"frmGenerate", _oFrmGenerate, _oFrmRetractedLengthValidation, Nothing})
                '    End If
                'End If

                aNavigationOrder.Add(New Object(3) {"frmRodEndConfiguration", _oFrmRodEndConfiguration, oFrmPrevious, _oFrmREDLWelded})
                If BlnShowNewDesign_Thru_ExistingDesign_DoubleLug Then
                    aNavigationOrder.Add(New Object(3) {"frmREDLWelded", _oFrmREDLWelded, _oFrmRodEndConfiguration, _oFrmREDLNewDesign})
                    aNavigationOrder.Add(New Object(3) {"frmREDLNewDesign", _oFrmREDLNewDesign, _oFrmREDLWelded, _oFrmRetractedLengthValidation})
                    aNavigationOrder.Add(New Object(3) {"frmRetractedLengthValidation", _oFrmRetractedLengthValidation, _oFrmREDLNewDesign, _oFrmPin_Port_PaintAccessories})
                    If ObjClsWeldedGlobalVariables.SkipRetractedIfPositiveFromGenerate Then
                        aNavigationOrder.Add(New Object(3) {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmREDLNewDesign, _oFrmGenerate})
                    Else
                        aNavigationOrder.Add(New Object(3) {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmRetractedLengthValidation, _oFrmGenerate})
                    End If
                    aNavigationOrder.Add(New Object(3) {"frmGenerate", _oFrmGenerate, _oFrmPin_Port_PaintAccessories, Nothing})
                Else
                    aNavigationOrder.Add(New Object(3) {"frmREDLWelded", _oFrmREDLWelded, _oFrmRodEndConfiguration, _oFrmRetractedLengthValidation})
                    aNavigationOrder.Add(New Object(3) {"frmRetractedLengthValidation", _oFrmRetractedLengthValidation, _oFrmREDLWelded, _oFrmPin_Port_PaintAccessories})
                    If ObjClsWeldedGlobalVariables.SkipRetractedIfPositiveFromGenerate Then
                        aNavigationOrder.Add(New Object(3) {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmREDLWelded, _oFrmGenerate})
                    Else
                        aNavigationOrder.Add(New Object(3) {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmRetractedLengthValidation, _oFrmGenerate})
                    End If
                    aNavigationOrder.Add(New Object(3) {"frmGenerate", _oFrmGenerate, _oFrmPin_Port_PaintAccessories, Nothing})
                End If
            Else
                'aNavigationOrder.Add(New Object(3) {"frmRodEndConfiguration", _oFrmRodEndConfiguration, oFrmPrevious, Nothing})
                aNavigationOrder.Add(New Object(3) {"frmRodEndConfiguration", _oFrmRodEndConfiguration, oFrmPrevious, _oFrmREDLCasting})
                aNavigationOrder.Add(New Object(3) {"frmREDLCasting", _oFrmREDLCasting, _oFrmRodEndConfiguration, _oFrmRetractedLengthValidation})
                aNavigationOrder.Add(New Object(3) {"frmRetractedLengthValidation", _oFrmRetractedLengthValidation, _oFrmREDLCasting, _oFrmPin_Port_PaintAccessories})
                If ObjClsWeldedGlobalVariables.SkipRetractedIfPositiveFromGenerate Then
                    aNavigationOrder.Add(New Object(3) {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmREDLCasting, _oFrmGenerate})
                Else
                    aNavigationOrder.Add(New Object(3) {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmRetractedLengthValidation, _oFrmGenerate})
                End If
                aNavigationOrder.Add(New Object(3) {"frmGenerate", _oFrmGenerate, _oFrmPin_Port_PaintAccessories, Nothing})
            End If


            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass = 1 OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass = 2 Then

            '    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConnectionType = "Threaded" Then

            '        aNavigationOrder.Add(New Object(3) {"frmRodEndConfiguration", _oFrmRodEndConfiguration, oFrmPrevious, _oFrmREDLThreaded})
            '        If ObjClsWeldedCylinderFunctionalClass.ShowWelded_Thru_Threaded_REDL OrElse ObjClsWeldedCylinderFunctionalClass.ShowCastingNo_Thru_CastingYes Then
            '            aNavigationOrder.Add(New Object(3) {"frmREDLThreaded", _oFrmREDLThreaded, _oFrmRodEndConfiguration, _oFrmREDLWelded})
            '            'ANUP 23-03-2010 12.24
            '            aNavigationOrder.Add(New Object(3) {"frmREDLWelded", _oFrmREDLWelded, _oFrmREDLThreaded, _oFrmRetractedLengthValidation})
            '            aNavigationOrder.Add(New Object(3) {"frmRetractedLengthValidation", _oFrmRetractedLengthValidation, _oFrmREDLThreaded, _oFrmGenerate})
            '            If ObjClsWeldedGlobalVariables.SkipRetractedIfPositiveFromGenerate Then
            '                aNavigationOrder.Add(New Object(3) {"frmGenerate", _oFrmGenerate, _oFrmREDLThreaded, Nothing})
            '            Else
            '                aNavigationOrder.Add(New Object(3) {"frmGenerate", _oFrmGenerate, _oFrmRetractedLengthValidation, Nothing})
            '            End If
            '        Else
            '            aNavigationOrder.Add(New Object(3) {"frmREDLThreaded", _oFrmREDLThreaded, _oFrmRodEndConfiguration, _oFrmRetractedLengthValidation})
            '            aNavigationOrder.Add(New Object(3) {"frmRetractedLengthValidation", _oFrmRetractedLengthValidation, _oFrmREDLThreaded, _oFrmGenerate})
            '            If ObjClsWeldedGlobalVariables.SkipRetractedIfPositiveFromGenerate Then
            '                aNavigationOrder.Add(New Object(3) {"frmGenerate", _oFrmGenerate, _oFrmREDLThreaded, Nothing})
            '            Else
            '                aNavigationOrder.Add(New Object(3) {"frmGenerate", _oFrmGenerate, _oFrmRetractedLengthValidation, Nothing})
            '            End If
            '        End If
            '    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConnectionType = "Welded" Then
            '        aNavigationOrder.Add(New Object(3) {"frmRodEndConfiguration", _oFrmRodEndConfiguration, oFrmPrevious, _oFrmREDLWelded})
            '        If ObjClsWeldedCylinderFunctionalClass.ShowCasting_Thru_Welded_REDL Then
            '            aNavigationOrder.Add(New Object(3) {"frmREDLWelded", _oFrmREDLWelded, _oFrmRodEndConfiguration, _oFrmREDLCasting})
            '            aNavigationOrder.Add(New Object(3) {"frmREDLCasting", _oFrmREDLCasting, _oFrmREDLWelded, _oFrmRetractedLengthValidation})
            '            aNavigationOrder.Add(New Object(3) {"frmRetractedLengthValidation", _oFrmRetractedLengthValidation, _oFrmREDLWelded, _oFrmGenerate})
            '            If ObjClsWeldedGlobalVariables.SkipRetractedIfPositiveFromGenerate Then
            '                aNavigationOrder.Add(New Object(3) {"frmGenerate", _oFrmGenerate, _oFrmREDLWelded, Nothing})
            '            Else
            '                aNavigationOrder.Add(New Object(3) {"frmGenerate", _oFrmGenerate, _oFrmRetractedLengthValidation, Nothing})
            '            End If
            '        Else
            '            aNavigationOrder.Add(New Object(3) {"frmREDLWelded", _oFrmREDLWelded, _oFrmRodEndConfiguration, _oFrmRetractedLengthValidation})
            '            aNavigationOrder.Add(New Object(3) {"frmRetractedLengthValidation", _oFrmRetractedLengthValidation, _oFrmREDLWelded, _oFrmGenerate})
            '            If ObjClsWeldedGlobalVariables.SkipRetractedIfPositiveFromGenerate Then
            '                aNavigationOrder.Add(New Object(3) {"frmGenerate", _oFrmGenerate, _oFrmREDLWelded, Nothing})
            '            Else
            '                aNavigationOrder.Add(New Object(3) {"frmGenerate", _oFrmGenerate, _oFrmRetractedLengthValidation, Nothing})
            '            End If
            '        End If
            '    Else
            '        'aNavigationOrder.Add(New Object(3) {"frmRodEndConfiguration", _oFrmRodEndConfiguration, oFrmPrevious, Nothing})
            '        aNavigationOrder.Add(New Object(3) {"frmRodEndConfiguration", _oFrmRodEndConfiguration, oFrmPrevious, _oFrmREDLCasting})
            '        aNavigationOrder.Add(New Object(3) {"frmREDLCasting", _oFrmREDLCasting, _oFrmRodEndConfiguration, _oFrmRetractedLengthValidation})
            '        aNavigationOrder.Add(New Object(3) {"frmRetractedLengthValidation", _oFrmRetractedLengthValidation, _oFrmREDLCasting, _oFrmGenerate})
            '        If ObjClsWeldedGlobalVariables.SkipRetractedIfPositiveFromGenerate Then
            '            aNavigationOrder.Add(New Object(3) {"frmGenerate", _oFrmGenerate, _oFrmREDLCasting, Nothing})
            '        Else
            '            aNavigationOrder.Add(New Object(3) {"frmGenerate", _oFrmGenerate, _oFrmRetractedLengthValidation, Nothing})
            '        End If
            '    End If
            'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass = 3 OrElse _
            'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass = 4 OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass = 5 Then
            '    aNavigationOrder.Add(New Object(3) {"frmRodEndConfiguration", _oFrmRodEndConfiguration, oFrmPrevious, _oFrmREDLCasting})
            '    aNavigationOrder.Add(New Object(3) {"frmREDLCasting", _oFrmREDLCasting, _oFrmRodEndConfiguration, _oFrmRetractedLengthValidation})
            '    aNavigationOrder.Add(New Object(3) {"frmRetractedLengthValidation", _oFrmRetractedLengthValidation, _oFrmREDLCasting, _oFrmGenerate})
            '    If ObjClsWeldedGlobalVariables.SkipRetractedIfPositiveFromGenerate Then
            '        aNavigationOrder.Add(New Object(3) {"frmGenerate", _oFrmGenerate, _oFrmREDLCasting, Nothing})
            '    Else
            '        aNavigationOrder.Add(New Object(3) {"frmGenerate", _oFrmGenerate, _oFrmRetractedLengthValidation, Nothing})
            '    End If
            'End If

            ''***************************************************************************



            ''*******************Cross Tube***********************************************

        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Cross Tube" Then

            aNavigationOrder.Add(New Object(3) {"frmRodEndConfiguration", _oFrmRodEndConfiguration, oFrmPrevious, _oFrmRECrossTube})
            If ShowCastingNo_Thru_CastingYes_RodEnd Then
                aNavigationOrder.Add(New Object(3) {"frmRECrossTube", _oFrmRECrossTube, _oFrmRodEndConfiguration, _oFrmCastingNo_RECT})
                'ANUP 23-03-2010 12.24
                aNavigationOrder.Add(New Object(3) {"frmCastingNo_RECT", _oFrmCastingNo_RECT, _oFrmRECrossTube, _oFrmRetractedLengthValidation})
                aNavigationOrder.Add(New Object(3) {"frmRetractedLengthValidation", _oFrmRetractedLengthValidation, _oFrmCastingNo_RECT, _oFrmPin_Port_PaintAccessories})
                If ObjClsWeldedGlobalVariables.SkipRetractedIfPositiveFromGenerate Then
                    aNavigationOrder.Add(New Object(3) {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmCastingNo_RECT, _oFrmGenerate})
                Else
                    aNavigationOrder.Add(New Object(3) {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmRetractedLengthValidation, _oFrmGenerate})
                End If
                aNavigationOrder.Add(New Object(3) {"frmGenerate", _oFrmGenerate, _oFrmPin_Port_PaintAccessories, Nothing})
            Else
                aNavigationOrder.Add(New Object(3) {"frmRECrossTube", _oFrmRECrossTube, _oFrmRodEndConfiguration, _oFrmRetractedLengthValidation})
                aNavigationOrder.Add(New Object(3) {"frmRetractedLengthValidation", _oFrmRetractedLengthValidation, _oFrmRECrossTube, _oFrmPin_Port_PaintAccessories})
                If ObjClsWeldedGlobalVariables.SkipRetractedIfPositiveFromGenerate Then
                    aNavigationOrder.Add(New Object(3) {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmRECrossTube, _oFrmGenerate})
                Else
                    aNavigationOrder.Add(New Object(3) {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmRetractedLengthValidation, _oFrmGenerate})
                End If
                aNavigationOrder.Add(New Object(3) {"frmGenerate", _oFrmGenerate, _oFrmPin_Port_PaintAccessories, Nothing})
            End If

            '31_08_2012   RAGAVA   Commented  Weldment
            'aNavigationOrder.Add(New Object(3) {"frmRodEndConfiguration", _oFrmRodEndConfiguration, oFrmPrevious, _oFrmRECrossTube})
            'If ShowCastingNo_Thru_CastingYes_RodEnd Then
            '    aNavigationOrder.Add(New Object(3) {"frmRECrossTube", _oFrmRECrossTube, _oFrmRodEndConfiguration, _oFrmCastingNo_RECT})
            '    aNavigationOrder.Add(New Object(3) {"frmCastingNo_RECT", _oFrmCastingNo_RECT, _oFrmRECrossTube, _oFrmCastingNo_RECT2})
            '    'ANUP 23-03-2010 12.24
            '    aNavigationOrder.Add(New Object(3) {"frmCastingNo_RECT2", _oFrmCastingNo_RECT2, _oFrmCastingNo_RECT, _oFrmRetractedLengthValidation})
            '    aNavigationOrder.Add(New Object(3) {"frmRetractedLengthValidation", _oFrmRetractedLengthValidation, _oFrmCastingNo_RECT2, _oFrmPin_Port_PaintAccessories})
            '    If ObjClsWeldedGlobalVariables.SkipRetractedIfPositiveFromGenerate Then
            '        aNavigationOrder.Add(New Object(3) {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmCastingNo_RECT2, _oFrmGenerate})
            '    Else
            '        aNavigationOrder.Add(New Object(3) {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmRetractedLengthValidation, _oFrmGenerate})
            '    End If
            '    aNavigationOrder.Add(New Object(3) {"frmGenerate", _oFrmGenerate, _oFrmPin_Port_PaintAccessories, Nothing})
            'Else
            '    'aNavigationOrder.Add(New Object(3) {"frmRECrossTube", _oFrmRECrossTube, _oFrmRodEndConfiguration, _oFrmCastingNo_RECT2})
            '    'aNavigationOrder.Add(New Object(3) {"frmCastingNo_RECT2", _oFrmCastingNo_RECT2, _oFrmRECrossTube, _oFrmRetractedLengthValidation})
            '    'aNavigationOrder.Add(New Object(3) {"frmRetractedLengthValidation", _oFrmRetractedLengthValidation, _oFrmCastingNo_RECT2, _oFrmPin_Port_PaintAccessories})
            '    'If ObjClsWeldedGlobalVariables.SkipRetractedIfPositiveFromGenerate Then
            '    '    aNavigationOrder.Add(New Object(3) {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmCastingNo_RECT2, _oFrmGenerate})
            '    'Else
            '    '    aNavigationOrder.Add(New Object(3) {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmRetractedLengthValidation, _oFrmGenerate})
            '    'End If
            '    'aNavigationOrder.Add(New Object(3) {"frmGenerate", _oFrmGenerate, _oFrmPin_Port_PaintAccessories, Nothing})


            '    aNavigationOrder.Add(New Object(3) {"frmRECrossTube", _oFrmRECrossTube, _oFrmRodEndConfiguration, _oFrmRECrossTube2})
            '    aNavigationOrder.Add(New Object(3) {"frmRECrossTube2", _oFrmRECrossTube2, _oFrmRECrossTube, _oFrmRetractedLengthValidation})
            '    aNavigationOrder.Add(New Object(3) {"frmRetractedLengthValidation", _oFrmRetractedLengthValidation, _oFrmRECrossTube2, _oFrmPin_Port_PaintAccessories})
            '    If ObjClsWeldedGlobalVariables.SkipRetractedIfPositiveFromGenerate Then
            '        aNavigationOrder.Add(New Object(3) {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmRECrossTube2, _oFrmGenerate})
            '    Else
            '        aNavigationOrder.Add(New Object(3) {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmRetractedLengthValidation, _oFrmGenerate})
            '    End If
            '    aNavigationOrder.Add(New Object(3) {"frmGenerate", _oFrmGenerate, _oFrmPin_Port_PaintAccessories, Nothing})
            'End If
            ''***************************************************************************



            ''*******************Import Special***********************************************
        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Import Special" Then
            'ANUP 23-03-2010 12.24
            aNavigationOrder.Add(New Object(3) {"frmRodEndConfiguration", _oFrmRodEndConfiguration, oFrmPrevious, _oFrmRetractedLengthValidation})
            aNavigationOrder.Add(New Object(3) {"frmRetractedLengthValidation", _oFrmRetractedLengthValidation, _oFrmRodEndConfiguration, _oFrmPin_Port_PaintAccessories})
            If ObjClsWeldedGlobalVariables.SkipRetractedIfPositiveFromGenerate Then
                aNavigationOrder.Add(New Object(3) {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmRodEndConfiguration, _oFrmGenerate})
            Else
                aNavigationOrder.Add(New Object(3) {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmRetractedLengthValidation, _oFrmGenerate})
            End If
            aNavigationOrder.Add(New Object(3) {"frmGenerate", _oFrmGenerate, _oFrmPin_Port_PaintAccessories, Nothing})

            'ANUP 16-08-2010
        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Import" Then
            aNavigationOrder.Add(New Object(3) {"frmRodEndConfiguration", _oFrmRodEndConfiguration, oFrmPrevious, _oFrmImportRodEnd})
            aNavigationOrder.Add(New Object(3) {"frmImportRodEnd", _oFrmImportRodEnd, _oFrmRodEndConfiguration, _oFrmRetractedLengthValidation})
            aNavigationOrder.Add(New Object(3) {"frmRetractedLengthValidation", _oFrmRetractedLengthValidation, _oFrmRodEndConfiguration, _oFrmPin_Port_PaintAccessories})
            aNavigationOrder.Add(New Object(3) {"frmPin_Port_PaintAccessories", _oFrmPin_Port_PaintAccessories, _oFrmRetractedLengthValidation, _oFrmGenerate})
            aNavigationOrder.Add(New Object(3) {"frmGenerate", _oFrmGenerate, _oFrmPin_Port_PaintAccessories, Nothing})
        End If
        ''***************************************************************************
    End Sub
    '*****************

    Public Property ObjCurrentForm() As Object
        Get
            Return _oCurrentForm
        End Get
        Set(ByVal value As Object)
            _oCurrentForm = value
        End Set
    End Property

    Public Property BackClick() As Button
        Get
            Return _btnBackClick
        End Get
        Set(ByVal value As Button)
            _btnBackClick = value
        End Set
    End Property

    Public Property NextClick() As Button
        Get
            Return _btnNextClick
        End Get
        Set(ByVal value As Button)
            _btnNextClick = value
        End Set
    End Property

    Public Property CurrentWorkingDirectory() As String
        Get
            Return _strCurrentWorkingDirectory
        End Get
        Set(ByVal value As String)
            _strCurrentWorkingDirectory = value
        End Set
    End Property

    Public Property ChildExcelPath() As String
        Get
            Return _strchildExcelPath
        End Get
        Set(ByVal value As String)
            _strchildExcelPath = value
        End Set
    End Property

    Public Property ExWorkbook() As Excel.Workbook
        Get
            Return _oExWorkbook
        End Get
        Set(ByVal value As Excel.Workbook)
            _oExWorkbook = value
        End Set
    End Property

    Public Property ExApplication() As Excel.Application
        Get
            Return _oExApplication
        End Get
        Set(ByVal value As Excel.Application)
            _oExApplication = value
        End Set
    End Property

    Public Property GeneralInformationListview() As ListView
        Get
            Return _lvwGeneralInformation
        End Get
        Set(ByVal value As ListView)
            _lvwGeneralInformation = value
        End Set
    End Property

    Public Property GeneralInformation() As ArrayList
        Get
            _aGeneralInformation = New ArrayList
            _aGeneralInformation.Add(New Object(1) {"Working Pressure", ""})
            _aGeneralInformation.Add(New Object(1) {"Column Load Derate Pressure", ""})
            _aGeneralInformation.Add(New Object(1) {"Bore Diameter", ""})
            _aGeneralInformation.Add(New Object(1) {"Rod Diameter", ""})
            _aGeneralInformation.Add(New Object(1) {"Piston Nut Size", ""})
            _aGeneralInformation.Add(New Object(1) {"Rod Material Code", ""})
            _aGeneralInformation.Add(New Object(1) {"Piston Nut Code", ""})
            _aGeneralInformation.Add(New Object(1) {"Piston Nut Max Thickness", ""})
            _aGeneralInformation.Add(New Object(1) {"Stop Tube Length", ""})
            _aGeneralInformation.Add(New Object(1) {"Stop Tube Code", ""})

            _aGeneralInformation.Add(New Object(1) {"Piston Code", ""})
            _aGeneralInformation.Add(New Object(1) {"Piston Seal Code", ""})
            _aGeneralInformation.Add(New Object(1) {"Piston WareRing Code", ""})
            _aGeneralInformation.Add(New Object(1) {"Piston Seal", ""})
            _aGeneralInformation.Add(New Object(1) {"Piston Width", ""})
            _aGeneralInformation.Add(New Object(1) {"CounterBoreDepth", ""})
            _aGeneralInformation.Add(New Object(1) {"Min Distance from RodSide to Seal Groove Start", ""})
            _aGeneralInformation.Add(New Object(1) {"Max Distance from RodSide to Seal Groove End", ""})
            _aGeneralInformation.Add(New Object(1) {"Head Type", ""})
            _aGeneralInformation.Add(New Object(1) {"Rod Seal", ""})

            _aGeneralInformation.Add(New Object(1) {"Cylinder Head Code", ""})
            _aGeneralInformation.Add(New Object(1) {"Tube Code", ""})
            _aGeneralInformation.Add(New Object(1) {"Tube Wall Thickness", ""})
            _aGeneralInformation.Add(New Object(1) {"Tube Material", ""})
            _aGeneralInformation.Add(New Object(1) {"TubeOD", ""})

            _aGeneralInformation.Add(New Object(1) {"BaseEnd Port Code", ""})
            _aGeneralInformation.Add(New Object(1) {"RodEnd Port Code", ""})
            _aGeneralInformation.Add(New Object(1) {"BaseEnd PortLocator Code", ""})
            _aGeneralInformation.Add(New Object(1) {"RodEnd PortLocator Code", ""})

            _aGeneralInformation.Add(New Object(1) {"DoubleLug without Port Code", ""})
            _aGeneralInformation.Add(New Object(1) {"ClevisPlate Code", ""})
            _aGeneralInformation.Add(New Object(1) {"ULug Code", ""})
            _aGeneralInformation.Add(New Object(1) {"SingleLug without Port Code", ""})
            _aGeneralInformation.Add(New Object(1) {"SingleLug Code", ""})
            _aGeneralInformation.Add(New Object(1) {"CrossTube without Port Code", ""})
            _aGeneralInformation.Add(New Object(1) {"CrossTube Code", ""})
            _aGeneralInformation.Add(New Object(1) {"ThreadedEnd without Port Code", ""})
            _aGeneralInformation.Add(New Object(1) {"ULug Lathe Code", ""})
            Return _aGeneralInformation
        End Get
        Set(ByVal value As ArrayList)
            _aGeneralInformation = value
        End Set
    End Property

    Public Property MessagesRichTextBox() As RichTextBox
        Get
            Return _rtxtMessages
        End Get
        Set(ByVal value As RichTextBox)
            _rtxtMessages = value
        End Set
    End Property

    Public ReadOnly Property NutSizesInFractions() As ArrayList
        Get
            NutSizesInFractions = New ArrayList
            NutSizesInFractions.Add(New Object(1) {"3 / 8", 0.375})
            NutSizesInFractions.Add(New Object(1) {"1 / 2", 0.5})
            NutSizesInFractions.Add(New Object(1) {"5 / 8", 0.625})
            NutSizesInFractions.Add(New Object(1) {"3 / 4", 0.75})
            NutSizesInFractions.Add(New Object(1) {"7 / 8", 0.875})
            NutSizesInFractions.Add(New Object(1) {"1", 1})
            NutSizesInFractions.Add(New Object(1) {"1 1/8", 1.125})
            NutSizesInFractions.Add(New Object(1) {"1 1/4", 1.25})
            NutSizesInFractions.Add(New Object(1) {"1 1/2", 1.5})
            NutSizesInFractions.Add(New Object(1) {"1 3/4", 1.75})
            Return NutSizesInFractions
        End Get
    End Property

    'Public ReadOnly Property NutSizesInFractions() As ArrayList
    '    Get
    '        NutSizesInFractions = New ArrayList
    '        NutSizesInFractions.Add(New Object(1) {"3 / 8", 0.38})
    '        NutSizesInFractions.Add(New Object(1) {"1 / 2", 0.5})
    '        NutSizesInFractions.Add(New Object(1) {"5 / 8", 0.63})
    '        NutSizesInFractions.Add(New Object(1) {"3 / 4", 0.75})
    '        NutSizesInFractions.Add(New Object(1) {"7 / 8", 0.88})
    '        NutSizesInFractions.Add(New Object(1) {"1", 1})
    '        NutSizesInFractions.Add(New Object(1) {"1 1/8", 1.13})
    '        NutSizesInFractions.Add(New Object(1) {"1 1/4", 1.25})
    '        NutSizesInFractions.Add(New Object(1) {"1 1/2", 1.5})
    '        Return NutSizesInFractions
    '    End Get
    'End Property


    Private ReadOnly Property StandardPinHoleSizes() As ArrayList
        Get
            StandardPinHoleSizes = New ArrayList
            StandardPinHoleSizes.Add(New Object(1) {0.5, 0.5})
            StandardPinHoleSizes.Add(New Object(1) {0.75, 0.765})
            StandardPinHoleSizes.Add(New Object(1) {1, 1.015})
            StandardPinHoleSizes.Add(New Object(1) {1.13, 1.14})
            StandardPinHoleSizes.Add(New Object(1) {1.25, 1.265})
            StandardPinHoleSizes.Add(New Object(1) {1.38, 1.39})
            StandardPinHoleSizes.Add(New Object(1) {1.5, 1.515})
            StandardPinHoleSizes.Add(New Object(1) {1.63, 1.64})
            StandardPinHoleSizes.Add(New Object(1) {1.75, 1.765})
            StandardPinHoleSizes.Add(New Object(1) {2, 2.015})
            Return StandardPinHoleSizes
        End Get
    End Property

    Public Property RdbFabrication() As RadioButton
        Get
            Return _rdbFabrication
        End Get
        Set(ByVal value As RadioButton)
            _rdbFabrication = value
        End Set
    End Property

    Public Property RdbDesignANewCasting() As RadioButton
        Get
            Return _rdbDesignANewCasting
        End Get
        Set(ByVal value As RadioButton)
            _rdbDesignANewCasting = value
        End Set
    End Property

    Public Property EmptyControlData() As ArrayList
        Get
            Return _aEmptyControlData
        End Get
        Set(ByVal value As ArrayList)
            _aEmptyControlData = value
        End Set
    End Property

    '15-02-10-Sandeep
    Public Property ShowWelded_Thru_Threaded_REDL() As Boolean
        Get
            Return _blnShowWelded_Thru_Threaded_REDL
        End Get
        Set(ByVal value As Boolean)
            _blnShowWelded_Thru_Threaded_REDL = value
        End Set
    End Property

    Public Property ShowCasting_Thru_Welded_REDL() As Boolean
        Get
            Return _blnShowCasting_Thru_Welded_REDL
        End Get
        Set(ByVal value As Boolean)
            _blnShowCasting_Thru_Welded_REDL = value
        End Set
    End Property

    Public Property PinHoleSize_Source() As Integer
        Get
            Return _intPinHoleSize_Source
        End Get
        Set(ByVal value As Integer)
            _intPinHoleSize_Source = value
        End Set
    End Property

    Public Property PinHoleSize_source_RodEnd() As Integer
        Get
            Return _intPinHoleSize_source_RodEnd
        End Get
        Set(ByVal value As Integer)
            _intPinHoleSize_source_RodEnd = value
        End Set
    End Property

    Public Property IsExact_NewDesign_Resize() As String
        Get
            Return _strIsExact_NewDesign_Resize
        End Get
        Set(ByVal value As String)
            _strIsExact_NewDesign_Resize = value
        End Set
    End Property

    '15_05_2012   RAGAVA
    Public Property IsExact_NewDesign_Resize2() As String
        Get
            Return _strIsExact_NewDesign_Resize2
        End Get
        Set(ByVal value As String)
            _strIsExact_NewDesign_Resize2 = value
        End Set
    End Property

    Public Property IsExact_NewDesign_Resize_RodEnd() As String
        Get
            Return _strIsExact_NewDesign_Resize_RodEnd
        End Get
        Set(ByVal value As String)
            _strIsExact_NewDesign_Resize_RodEnd = value
        End Set
    End Property

    '24_07_2012   RAGAVA
    Public Property IsExact_NewDesign_Resize_RodEnd2() As String
        Get
            Return _strIsExact_NewDesign_Resize_RodEnd2
        End Get
        Set(ByVal value As String)
            _strIsExact_NewDesign_Resize_RodEnd2 = value
        End Set
    End Property


    Public Property FacricatedPart() As String
        Get
            Return _strFacricatedPart
        End Get
        Set(ByVal value As String)
            _strFacricatedPart = value
        End Set
    End Property

    '15_05_2012   RAGAVA
    Public Property FacricatedPart2() As String
        Get
            Return _strFacricatedPart2
        End Get
        Set(ByVal value As String)
            _strFacricatedPart2 = value
        End Set
    End Property

    Public Property RetractedLengthChangedFromRetractedValidationScreen() As Boolean
        Get
            Return _blnRetractedLengthChangedFromRetractedValidationScreen
        End Get
        Set(ByVal value As Boolean)
            _blnRetractedLengthChangedFromRetractedValidationScreen = value
        End Set
    End Property

    'Sandeep 01-03-10 3pm
    Public Property CompressCylinderChecked() As Boolean
        Get
            Return _blnCompressCylinderChecked
        End Get
        Set(ByVal value As Boolean)
            _blnCompressCylinderChecked = value
        End Set
    End Property

    '&&&&&&&&&&&&&&&&&&&&&&&&&

    ' ANUP 19-03-2010 11.00
    Public Property ObjPnlChildFormArea() As Panel
        Get
            Return _oPnlChildFormArea
        End Get
        Set(ByVal value As Panel)
            _oPnlChildFormArea = value
        End Set
    End Property
    '****************

    ''TODO: ANUP 23-03-2010 11.42
    'Public Property SkipRetractedIfNegative() As Boolean
    '    Get
    '        Return _blnSkipRetractedIfNegative
    '    End Get
    '    Set(ByVal value As Boolean)
    '        _blnSkipRetractedIfNegative = value
    '    End Set
    'End Property
    ''**************

    Public Property MdiPictureBox() As PictureBox
        Get
            Return _oMdiPictureBox
        End Get
        Set(ByVal value As PictureBox)
            _oMdiPictureBox = value
        End Set
    End Property

    Public Property CurrentForm_Object() As Object
        Get
            Return _oCurrentForm_Object
        End Get
        Set(ByVal value As Object)
            _oCurrentForm_Object = value
        End Set
    End Property

    'TODO: ANUP 31-05-2010 10.13am
    Public Property IsWeldSizeLess() As Boolean
        Get
            Return _oIsWeldSizeLess
        End Get
        Set(ByVal value As Boolean)
            _oIsWeldSizeLess = value
        End Set
    End Property
    '*********************

    'TODO:Sunny 04-06-10
    Public Property PortIntegral_ExistingDetailsFound() As Boolean
        Get
            Return _blnPortIntegral_ExistingDetailsFound
        End Get
        Set(ByVal value As Boolean)
            _blnPortIntegral_ExistingDetailsFound = value
        End Set
    End Property

    ' ANUP 02-07-2010
    Public Property IsCounterBoreOrNot() As Boolean
        Get
            Return _blnIsCounterBoreOrNot
        End Get
        Set(ByVal value As Boolean)
            _blnIsCounterBoreOrNot = value
        End Set
    End Property

    'TODO: ANUP 21-07-2010 02-15pm
    Public Property IsPackPinsAndClipsInPlasticBagChecked() As Boolean
        Get
            Return _blnIsPackPinsAndClipsInPlasticBagChecked
        End Get
        Set(ByVal value As Boolean)
            _blnIsPackPinsAndClipsInPlasticBagChecked = value
        End Set
    End Property

    Public ReadOnly Property PinHoleSizes_DefaultSettings() As Hashtable
        Get
            Dim htPinHoleSizes_DefaultSettings As New Hashtable()
            htPinHoleSizes_DefaultSettings.Add(1.0, "0.500")
            htPinHoleSizes_DefaultSettings.Add(1.25, "0.500")
            htPinHoleSizes_DefaultSettings.Add(1.5, "0.750")
            htPinHoleSizes_DefaultSettings.Add(1.75, "0.750")
            htPinHoleSizes_DefaultSettings.Add(2.0, "1.000")
            htPinHoleSizes_DefaultSettings.Add(2.25, "1.000")
            htPinHoleSizes_DefaultSettings.Add(2.5, "1.000")
            htPinHoleSizes_DefaultSettings.Add(2.75, "1.000")
            htPinHoleSizes_DefaultSettings.Add(3.0, "1.000")
            htPinHoleSizes_DefaultSettings.Add(3.25, "1.000")
            htPinHoleSizes_DefaultSettings.Add(3.5, "1.000")
            htPinHoleSizes_DefaultSettings.Add(3.75, "1.000")
            htPinHoleSizes_DefaultSettings.Add(4.0, "1.000")
            htPinHoleSizes_DefaultSettings.Add(4.5, "1.250")
            htPinHoleSizes_DefaultSettings.Add(5.0, "1.250")
            htPinHoleSizes_DefaultSettings.Add(5.5, "1.500")
            htPinHoleSizes_DefaultSettings.Add(6.0, "1.500")
            Return htPinHoleSizes_DefaultSettings
        End Get
    End Property

    'ANUP 11-08-2010
    Public Property IsPort_BaseEndOrRodEnd() As Boolean
        Get
            Return _blnIsPort_BaseEndOrRodEnd
        End Get
        Set(ByVal value As Boolean)
            _blnIsPort_BaseEndOrRodEnd = value
        End Set
    End Property

    Public Property IsImportPortsButtonClicked() As Boolean
        Get
            Return _blnIsImportPortsButtonClicked
        End Get
        Set(ByVal value As Boolean)
            _blnIsImportPortsButtonClicked = value
        End Set
    End Property

    'ANUP 16-08-2010 

    Public Property IsBaseEndPortImported() As Boolean
        Get
            Return _blnIsBaseEndPortImported
        End Get
        Set(ByVal value As Boolean)
            _blnIsBaseEndPortImported = value
        End Set
    End Property

    Public Property IsRodEndPortImported() As Boolean
        Get
            Return _blnIsRodEndPortImported
        End Get
        Set(ByVal value As Boolean)
            _blnIsRodEndPortImported = value
        End Set
    End Property

    Public Property IsBaseEndPartImported() As Boolean
        Get
            Return _blnIsBaseEndPartImported
        End Get
        Set(ByVal value As Boolean)
            _blnIsBaseEndPartImported = value
        End Set
    End Property

    Public Property IsRodEndPartImported() As Boolean
        Get
            Return _blnIsRodEndPartImported
        End Get
        Set(ByVal value As Boolean)
            _blnIsRodEndPartImported = value
        End Set
    End Property

    Public Property IsPlateClevisImported() As Boolean
        Get
            Return _blnIsPlateClevisImported
        End Get
        Set(ByVal value As Boolean)
            _blnIsPlateClevisImported = value
        End Set
    End Property

    'ANUP 11-10-2010 START
    Public Property IsValueChanged_Revision() As Boolean
        Get
            Return _blnIsValueChanged_Revision
        End Get
        Set(ByVal value As Boolean)
            _blnIsValueChanged_Revision = value
        End Set
    End Property
    'ANUP 11-10-2010 TILL HERE

    'ANUP 01-11-2010 START 
    Public Property IsReleaseCylinderChecked() As Boolean
        Get
            Return _blnIsReleaseCylinderChecked
        End Get
        Set(ByVal value As Boolean)
            _blnIsReleaseCylinderChecked = value
        End Set
    End Property

    Public Property IsNew_Revision_Released() As String
        Get
            Return _strIsNew_Revision_Released
        End Get
        Set(ByVal value As String)
            _strIsNew_Revision_Released = value
        End Set
    End Property
    'ANUP 01-11-2010 TILL HERE

    'anup 17-02-2011 start
    Public Property IsExistingButNotReleased_TubeWeldment() As Boolean
        Get
            Return _blnIsExistingButNotReleased_TubeWeldment
        End Get
        Set(ByVal value As Boolean)
            _blnIsExistingButNotReleased_TubeWeldment = value
        End Set
    End Property

    Public Property IsExistingButNotReleased_RodWeldment() As Boolean
        Get
            Return _blnIsExistingButNotReleased_RodWeldment
        End Get
        Set(ByVal value As Boolean)
            _blnIsExistingButNotReleased_RodWeldment = value
        End Set
    End Property

    Public Property IsExistingButNotReleased_Lug_BE() As Boolean
        Get
            Return _blnIsExistingButNotReleased_Lug_BE
        End Get
        Set(ByVal value As Boolean)
            _blnIsExistingButNotReleased_Lug_BE = value
        End Set
    End Property
    Public Property IsExistingButNotReleased_Lug_RE() As Boolean
        Get
            Return _blnIsExistingButNotReleased_Lug_RE
        End Get
        Set(ByVal value As Boolean)
            _blnIsExistingButNotReleased_Lug_RE = value
        End Set
    End Property
    Public Property IsExistingButNotReleased_CylinderHead() As Boolean
        Get
            Return _blnIsExistingButNotReleased_CylinderHead
        End Get
        Set(ByVal value As Boolean)
            _blnIsExistingButNotReleased_CylinderHead = value
        End Set
    End Property
    Public Property IsExistingButNotReleased_Piston() As Boolean
        Get
            Return _blnIsExistingButNotReleased_Piston
        End Get
        Set(ByVal value As Boolean)
            _blnIsExistingButNotReleased_Piston = value
        End Set
    End Property
    Public Property IsExistingButNotReleased_CrossTube_BE() As Boolean
        Get
            Return _blnIsExistingButNotReleased_CrossTube_BE
        End Get
        Set(ByVal value As Boolean)
            _blnIsExistingButNotReleased_CrossTube_BE = value
        End Set
    End Property
    Public Property IsExistingButNotReleased_CrossTube_RE() As Boolean
        Get
            Return _blnIsExistingButNotReleased_CrossTube_RE
        End Get
        Set(ByVal value As Boolean)
            _blnIsExistingButNotReleased_CrossTube_RE = value
        End Set
    End Property
    Public Property IsExistingButNotReleased_Casting_BE() As Boolean
        Get
            Return _blnIsExistingButNotReleased_Casting_BE
        End Get
        Set(ByVal value As Boolean)
            _blnIsExistingButNotReleased_Casting_BE = value
        End Set
    End Property
    Public Property IsExistingButNotReleased_Casting_RE() As Boolean
        Get
            Return _blnIsExistingButNotReleased_Casting_RE
        End Get
        Set(ByVal value As Boolean)
            _blnIsExistingButNotReleased_Casting_RE = value
        End Set
    End Property
    Public Property IsExistingButNotReleased_StopTube() As Boolean
        Get
            Return _blnIsExistingButNotReleased_StopTube
        End Get
        Set(ByVal value As Boolean)
            _blnIsExistingButNotReleased_StopTube = value
        End Set
    End Property
    'anup 17-02-2011 till here

#Region "TextBox Objects"

    Public Property TxtLugThickness_BaseEnd() As TextBox
        Get
            Return _oTxtLugThickness_BaseEnd
        End Get
        Set(ByVal value As TextBox)
            _oTxtLugThickness_BaseEnd = value
        End Set
    End Property

    Public Property TxtCrossTubeWidth_BaseEnd() As TextBox
        Get
            Return _oTxtCrossTubeWidth_BaseEnd
        End Get
        Set(ByVal value As TextBox)
            _oTxtCrossTubeWidth_BaseEnd = value
        End Set
    End Property

    Public Property TxtSwingClearance_BaseEnd() As TextBox
        Get
            Return _oTxtSwingClearance_BaseEnd
        End Get
        Set(ByVal value As TextBox)
            _oTxtSwingClearance_BaseEnd = value
        End Set
    End Property

    Public Property TxtLugGap_BaseEnd() As TextBox
        Get
            Return _oTxtLugGap_BaseEnd
        End Get
        Set(ByVal value As TextBox)
            _oTxtLugGap_BaseEnd = value
        End Set
    End Property

    Public Property CmbBushingPinHoleSize_BaseEnd() As ComboBox
        Get
            Return _oCmbBushingPinHoleSize_BaseEnd
        End Get
        Set(ByVal value As ComboBox)
            _oCmbBushingPinHoleSize_BaseEnd = value
        End Set
    End Property

    Public Property CmbPinHoleSize_BaseEnd() As ComboBox
        Get
            Return _oCmbPinHoleSize_BaseEnd
        End Get
        Set(ByVal value As ComboBox)
            _oCmbPinHoleSize_BaseEnd = value
        End Set
    End Property

    Public Property TxtPinHoleSize_BaseEnd() As TextBox
        Get
            Return _oTxtPinHoleSize_BaseEnd
        End Get
        Set(ByVal value As TextBox)
            _oTxtPinHoleSize_BaseEnd = value
        End Set
    End Property

    Public Property CmbGreaseZercs_BaseEnd() As ComboBox
        Get
            Return _oCmbGreaseZercs_BaseEnd
        End Get
        Set(ByVal value As ComboBox)
            _oCmbGreaseZercs_BaseEnd = value
        End Set
    End Property

    Public Property TxtAngleOfGreaseZercs1_BaseEnd() As TextBox
        Get
            Return _oTxtAngleOfGreaseZercs1_BaseEnd
        End Get
        Set(ByVal value As TextBox)
            _oTxtAngleOfGreaseZercs1_BaseEnd = value
        End Set
    End Property

    Public Property TxtAngleOfGreaseZercs2_BaseEnd() As TextBox
        Get
            Return _oTxtAngleOfGreaseZercs2_BaseEnd
        End Get
        Set(ByVal value As TextBox)
            _oTxtAngleOfGreaseZercs2_BaseEnd = value
        End Set
    End Property

    Public Property TxtLugThickness_RodEnd() As TextBox
        Get
            Return _oTxtLugThickness_RodEnd
        End Get
        Set(ByVal value As TextBox)
            _oTxtLugThickness_RodEnd = value
        End Set
    End Property

    Public Property TxtSwingClearance_RodEnd() As TextBox
        Get
            Return _oTxtSwingClearance_RodEnd
        End Get
        Set(ByVal value As TextBox)
            _oTxtSwingClearance_RodEnd = value
        End Set
    End Property

    Public Property CmbPinHoleSize_RodEnd() As ComboBox
        Get
            Return _oCmbPinHoleSize_RodEnd
        End Get
        Set(ByVal value As ComboBox)
            _oCmbPinHoleSize_RodEnd = value
        End Set
    End Property
    Public Property TxtPinHoleSize_RodEnd() As TextBox
        Get
            Return _oTxtPinHoleSize_RodEnd
        End Get
        Set(ByVal value As TextBox)
            _oTxtPinHoleSize_RodEnd = value
        End Set
    End Property


    Public Property CmbGreaseZercs_RodEnd() As ComboBox
        Get
            Return _oCmbGreaseZercs_RodEnd
        End Get
        Set(ByVal value As ComboBox)
            _oCmbGreaseZercs_RodEnd = value
        End Set
    End Property

    Public Property TxtAngleOfGreaseZercs1_RodEnd() As TextBox
        Get
            Return _oTxtAngleOfGreaseZercs1_RodEnd
        End Get
        Set(ByVal value As TextBox)
            _oTxtAngleOfGreaseZercs1_RodEnd = value
        End Set
    End Property

    Public Property TxtAngleOfGreaseZercs2_RodEnd() As TextBox
        Get
            Return _oTxtAngleOfGreaseZercs2_RodEnd
        End Get
        Set(ByVal value As TextBox)
            _oTxtAngleOfGreaseZercs2_RodEnd = value
        End Set
    End Property

    Public Property TxtCrossTubeWidth_RodEnd() As TextBox
        Get
            Return _oTxtCrossTubeWidth_RodEnd
        End Get
        Set(ByVal value As TextBox)
            _oTxtCrossTubeWidth_RodEnd = value
        End Set
    End Property

    Public Property TxtLugGap_RodEnd() As TextBox
        Get
            Return _oTxtLugGap_RodEnd
        End Get
        Set(ByVal value As TextBox)
            _oTxtLugGap_RodEnd = value
        End Set
    End Property

    Public Property CmbBushingPinHoleSize_RodEnd() As ComboBox
        Get
            Return _oCmbBushingPinHoleSize_RodEnd
        End Get
        Set(ByVal value As ComboBox)
            _oCmbBushingPinHoleSize_RodEnd = value
        End Set
    End Property

    Public Property TxtRetractedLength() As TextBox
        Get
            Return _oTxtRetractedLength
        End Get
        Set(ByVal value As TextBox)
            _oTxtRetractedLength = value
        End Set
    End Property
    '26_02_2010 Aruna Start

    Public Property TxtCrossTubeOffset_BaseEnd() As TextBox
        Get
            Return _oTxtCrossTubeOffset_BaseEnd
        End Get
        Set(ByVal value As TextBox)
            _oTxtCrossTubeOffset_BaseEnd = value
        End Set
    End Property
    Public Property TxtCrossTubeOffset_RodEnd() As TextBox
        Get
            Return _oTxtCrossTubeOffset_RodEnd
        End Get
        Set(ByVal value As TextBox)
            _oTxtCrossTubeOffset_RodEnd = value
        End Set
    End Property
    '26_02_2010 Aruna Ends

    'Anup  26_02_2010
    Public Property CmbPortSizeBaseEnd() As ComboBox
        Get
            Return _oCmbPortSizeBaseEnd
        End Get
        Set(ByVal value As ComboBox)
            _oCmbPortSizeBaseEnd = value
        End Set
    End Property

    ' ANUP 02-03-2010 12.01

    Public Property TxtBasePlugDia_BaseEnd() As TextBox
        Get
            Return _oTxtBasePlugDia_BaseEnd
        End Get
        Set(ByVal value As TextBox)
            _oTxtBasePlugDia_BaseEnd = value
        End Set
    End Property

    Public Property CmbPortType_BaseEnd() As ComboBox
        Get
            Return _oCmbPortType_BaseEnd
        End Get
        Set(ByVal value As ComboBox)
            _oCmbPortType_BaseEnd = value
        End Set
    End Property

    Public Property TxtFirstPortOrientation_BaseEnd() As TextBox
        Get
            Return _oTxtFirstPortOrientation_BaseEnd
        End Get
        Set(ByVal value As TextBox)
            _oTxtFirstPortOrientation_BaseEnd = value
        End Set
    End Property
    Public Property TxtSecondPortOrientation_BaseEnd() As TextBox
        Get
            Return _oTxtSecondPortOrientation_BaseEnd
        End Get
        Set(ByVal value As TextBox)
            _oTxtSecondPortOrientation_BaseEnd = value
        End Set
    End Property
    '******************

    ' ANUP 10-03-2010 03.42
    Public Property TxtThreadDiameter_BaseEnd() As ComboBox
        Get
            Return _oTxtThreadDiameter_BaseEnd
        End Get
        Set(ByVal value As ComboBox)
            _oTxtThreadDiameter_BaseEnd = value
        End Set
    End Property

    Public Property TxtThreadLength_BaseEnd() As TextBox
        Get
            Return _oTxtThreadLength_BaseEnd
        End Get
        Set(ByVal value As TextBox)
            _oTxtThreadLength_BaseEnd = value
        End Set
    End Property
    '*********************


    ' ANUP 11-03-2010 02.44

    Public Property TxtToleranceUpperLimit_RodEnd() As TextBox
        Get
            Return _oTxtToleranceUpperLimit_RodEnd
        End Get
        Set(ByVal value As TextBox)
            _oTxtToleranceUpperLimit_RodEnd = value
        End Set
    End Property

    Public Property TxtToleranceLowerLimit_RodEnd() As TextBox
        Get
            Return _oTxtToleranceLowerLimit_RodEnd
        End Get
        Set(ByVal value As TextBox)
            _oTxtToleranceLowerLimit_RodEnd = value
        End Set
    End Property
    '*********************

    'TODO ANUP 02-04-2010 11.15
    Public Property CmbRodEndConfiguration_RodEnd() As ComboBox
        Get
            Return _oCmbRodEndConfiguration_RodEnd
        End Get
        Set(ByVal value As ComboBox)
            _oCmbRodEndConfiguration_RodEnd = value
        End Set
    End Property
    '*********************

    'Sunny 11-05-10
    Public Property cmbConnectionType_RodEnd() As ComboBox
        Get
            Return _ocmbConnectionType_RodEnd
        End Get
        Set(ByVal value As ComboBox)
            _ocmbConnectionType_RodEnd = value
        End Set
    End Property

    'TODO: ANUP 05-07-2010 11.02am
    Public Property CmbWeldType_BaseEnd() As ComboBox
        Get
            Return _oCmbWeldType_BaseEnd
        End Get
        Set(ByVal value As ComboBox)
            _oCmbWeldType_BaseEnd = value
        End Set
    End Property

    'TODO: ANUP 12-07-2010 12.03pm
    Public Property CmbBaseEndConfiguration() As ComboBox
        Get
            Return _oCmbBaseEndConfiguration
        End Get
        Set(ByVal value As ComboBox)
            _oCmbBaseEndConfiguration = value
        End Set
    End Property

    'TODO: ANUP 23-07-2010 09.24am
    Public Property CmbPins_BaseEnd() As ComboBox
        Get
            Return _oCmbPins_BaseEnd
        End Get
        Set(ByVal value As ComboBox)
            _oCmbPins_BaseEnd = value
        End Set
    End Property


    Public Property CmbPins_RodEnd() As ComboBox
        Get
            Return _oCmbPins_RodEnd
        End Get
        Set(ByVal value As ComboBox)
            _oCmbPins_RodEnd = value
        End Set
    End Property

    Public Property CmbClips_BaseEnd() As ComboBox
        Get
            Return _oCmbClips_BaseEnd
        End Get
        Set(ByVal value As ComboBox)
            _oCmbClips_BaseEnd = value
        End Set
    End Property

    Public Property CmbClips_RodEnd() As ComboBox
        Get
            Return _oCmbClips_RodEnd
        End Get
        Set(ByVal value As ComboBox)
            _oCmbClips_RodEnd = value
        End Set
    End Property

    'anup 31-08-2010 
    Public Property TxtToleranceUpperLimit() As TextBox
        Get
            Return _oTxtToleranceUpperLimit
        End Get
        Set(ByVal value As TextBox)
            _oTxtToleranceUpperLimit = value
        End Set
    End Property

    Public Property TxtToleranceLowerLimit() As TextBox
        Get
            Return _oTxtToleranceLowerLimit
        End Get
        Set(ByVal value As TextBox)
            _oTxtToleranceLowerLimit = value
        End Set
    End Property



#End Region

#End Region

#Region "MILDB"

    Private _oClsCostingMILDB As clsCostingMILDB
    Public Property ObjClsMIL_TieRodDataClass() As clsCostingMILDB
        Get
            Return _oClsCostingMILDB
        End Get
        Set(ByVal value As clsCostingMILDB)
            _oClsCostingMILDB = value
        End Set
    End Property
#End Region

#Region "Base_RodEnd Weight"

    Private _dblBaseEndWeight As Double

    Public Property BaseEndWeight() As Double
        Get
            Return _dblBaseEndWeight
        End Get
        Set(ByVal value As Double)
            _dblBaseEndWeight = value
        End Set
    End Property


    Private _dblRodEndWeight As Double

    Public Property RodEndWeight() As Double
        Get
            Return _dblRodEndWeight
        End Get
        Set(ByVal value As Double)
            _dblRodEndWeight = value
        End Set
    End Property

#End Region
    '<<--9-12-2010 Aruna--

    Public Property ObjFrmUpdateRecords() As frmUpdateDatabaseRecords
        Get
            Return _ofrmUpdateRecords
        End Get
        Set(ByVal value As frmUpdateDatabaseRecords)
            _ofrmUpdateRecords = value
        End Set
    End Property
    '--29-10-2010 Aruna-->>
    'vamsi 11-06-14 
    Public Property MonarchProgressbar() As ProgressBar
        Get
            Return _prb
        End Get
        Set(ByVal value As ProgressBar)
            _prb = value
        End Set
    End Property
    'vamsi 11-06-14 
    Public WriteOnly Property StopWatchAndProgressBar() As String
        Set(ByVal value As String)
            If value = "Start" Then
                MonarchProgressBar.Visible = True
                Control.CheckForIllegalCrossThreadCalls = False
                _oThreadProgressBarStepping = New Thread(New ThreadStart(AddressOf StartStepingProgressBar))
                _oThreadProgressBarStepping.IsBackground = True
                _oThreadProgressBarStepping.Start()
            ElseIf value = "Stop" Then
                If _oThreadProgressBarStepping.IsAlive Then
                    MonarchProgressBar.Value = MonarchProgressBar.Maximum
                    MonarchProgressBar.Value = 0
                    _oThreadProgressBarStepping.Abort()
                    MonarchProgressBar.Visible = False
                End If
            End If
        End Set
    End Property

#End Region

#Region "Function ProtoTypes"

    Declare Sub Sleep Lib "kernel32" (ByVal milliSec As Integer) '09_11_2009  Ragava

    '25_10_2010   RAGAVA
    'Public Sub DisplaySelectedPartImage(ByVal strImagePath As String)
    '    Try
    '        ObjClsWeldedCylinderFunctionalClass.MdiPictureBox.ImageLocation = Nothing
    '        Sleep(1000)
    '        File.Delete("c:\Test.bmp")
    '    Catch ex As Exception

    '    End Try
    '    Try
    '        Extractor = Nothing
    '        Extractor = New SldWorks_ExtractBitmap.SldWorks_ExtractBitmapClass
    '        If File.Exists(strImagePath) Then
    '            Extractor.ExtractBitmap(strImagePath, "c:\Test.bmp", 300, 250)
    '            ObjClsWeldedCylinderFunctionalClass.MdiPictureBox.ImageLocation = "c:\Test.bmp"
    '        ElseIf strImagePath <> "" Then
    '            'MsgBox("File doesn't exist " & vbNewLine & strImagePath)
    '        Else
    '            ObjClsWeldedCylinderFunctionalClass.MdiPictureBox.ImageLocation = ""
    '        End If
    '    Catch ex As Exception
    '        MsgBox("Error in displaying Part")
    '    End Try
    'End Sub

#End Region

#Region "SubProcedures"

    Public Sub New()
        DeletePreviousErrorLogFile()
        InitialiseAllChildFormObjects()
    End Sub
    Public Sub StartStepingProgressBar()   'vamsi 11-06-14 

        While Not MonarchProgressbar.Value = MonarchProgressbar.Maximum + 1
            If MonarchProgressbar.Value = MonarchProgressbar.Maximum Then
                MonarchProgressbar.Value = 0
            End If
            MonarchProgressbar.Value += 1
            Application.DoEvents()
            System.Threading.Thread.Sleep(100)
        End While

    End Sub
    Private Sub InitialiseAllChildFormObjects()
        Try
            _oClsListViewMIL = New clsListViewMIL
            _oClsWeldedDataClass = New clsWeldedDataClass
            _oClsCostingMILDB = New clsCostingMILDB
            _oClsWeldedGlobalVariables = New clsWeldedGlobalVariables
            _oFrmPortDetails = New frmPortDetails
            _oClsExcelClass = New ExcelClass

            '----------Primary--------------
            _oFrmPrimaryInputs = New frmPrimaryInputs
            _oFrmPistonDesign = New frmPistonDesign
            _oFrmTubeDetails = New frmTubeDetails
            _oFrmHeadDesign = New frmHeadDesign
            _oFrmRodEndConfiguration = New frmRodEndConfiguration
            '---------------------------------

            '----------PlateClevis--------------
            _oFrmConPlateClevis = New frmConPlateClevis
            '---------------------------------

            '----------DoubleLug--------------
            _oFrmDLPortInTubeDetails = New frmDLPortInTubeDetails
            _oFrmDLPortInTubeDetails2 = New frmDLPortInTubeDetails2
            _oFrmDLCastingYes = New frmDLCastingYes
            _oFrmDLCastingYes2 = New frmDLCastingYes2
            _oFrmDLCastingNo_PortInTube = New frmDLCastingNo_PortInTube
            _oFrmDLCastingNo_PortInTube2 = New frmDLCastingNo_PortInTube2
            _oFrmDLPortIntegral = New frmDLPortIntegral
            _oFrmDLPortIntegral2 = New frmDLPortIntegral2
            _oFrmDLFabrication = New frmDLFabrication
            _oFrmDLFabrication2 = New frmDLFabrication2

            _oFrmDLDesignACasting = New frmDLDesignACasting
            _oFrmDLDesignACasting2 = New frmDLDesignACasting2
            _oFrmDLCastingNo_PortIntegral = New frmDLCastingNo_PortIntegral
            _oFrmFabricatedSingleLug = New frmFabricatedSingleLug_RetractedLength            '06_01_2012   RAGAVA
            _oFrmFabricatedSingleLug2 = New frmFabricatedSingleLug_RetractedLength2          '30_05_2012   RAGAVA
            _oFrmDLCastingNo_PortIntegral2 = New frmDLCastingNo_PortIntegral2         ' 26-04-2012 MANJULA
            '---------------------------------

            'MANJULA ADDED
            '----------BH--------------
            _oFrmBHCastingNo_PortIntegral = New frmBHCastingNo_PortIntegral
            _oFrmBHCastingNo_PortInTube = New frmBHCastingNo_PortInTube
            _oFrmBHCastingYes = New frmBHCastingYes
            _oFrmBHDesignACasting = New frmBHDesignACasting
            _oFrmBHFabrication = New frmBHFabrication
            _oFrmBHPortIntegral = New frmBHPortIntegral
            _oFrmBHPortinTube = New frmBHPortInTube

            _oFrmBHCastingNo_PortIntegral2 = New frmBHCastingNo_PortIntegral2
            _oFrmBHCastingNo_PortInTube2 = New frmBHCastingNo_PortInTube2
            _oFrmBHCastingYes2 = New frmBHCastingYes2
            _oFrmBHDesignACasting2 = New frmBHDesignACasting2
            _oFrmBHFabrication2 = New frmBHFabrication2
            _oFrmBHPortIntegral2 = New frmBHPortIntegral2
            _oFrmBHPortinTube2 = New frmBHPortInTube2
            '---------------------------------


            '----------SingleLug--------------
            _oFrmSLCastingNo_PortIntegral = New frmSLCastingNo_PortIntegral
            _oFrmSLCastingNo_PortInTube = New frmSLCastingNo_PortInTube
            _oFrmSLCastingYes = New frmSLCastingYes
            _oFrmSLDesignACasting = New frmSLDesignACasting
            _oFrmSLFabrication = New frmSLFabrication
            _oFrmSLPortIntegral = New frmSLPortIntegral
            _oFrmSLPortinTube = New frmSLPortinTube

            _oFrmSLCastingNo_PortIntegral2 = New frmSLCastingNo_PortIntegral2
            _oFrmSLCastingNo_PortInTube2 = New frmSLCastingNo_PortInTube2
            _oFrmSLCastingYes2 = New frmSLCastingYes2
            _oFrmSLDesignACasting2 = New frmSLDesignACasting2
            _oFrmSLFabrication2 = New frmSLFabrication2
            _oFrmSLPortIntegral2 = New frmSLPortIntegral2
            _oFrmSLPortinTube2 = New frmSLPortinTube2
            '---------------------------------

            'Aruna 9_11_2009-----BasePlug
            _oFrmBasePlugCastingYes = New frmBasePlugCastingYes
            _oFrmBasePlugPortIntegral = New frmBasePlugPortIntegral
            _oFrmBasePlugPortInTube = New frmBasePlugPortInTube
            ' ANUP 08-03-2010 11.13
            _oFrmBasePlugCastingYesPortIntegral = New frmBasePlugCastingYesPortIntegral
            _oFrmBasePlugCastingNoPortIntegral = New frmBasePlugCastingNoPortIntegral
            '---------------------------------

            '---------- THREADED END ----------------
            _oFrmThreadedCastingYes = New frmThreadedEndCastingYes          '09_12_2009   RAGAVA
            _oFrmDesignAThreadedCasting = New frmDesignAThreadedCasting     '09_12_2009   RAGAVA
            _oFrmThreadedPortInTube = New frmThreadedEndPortInTube          '09_12_2009   RAGAVA
            _oFrmThreadedEndPortIntegral = New frmThreadedEndPortIntegral
            _oFrmBEThreadedEndCastingNo_PortIntegral = New frmBEThreadedEndCastingNo_PortIntegral

            ' ANUP 10-03-2010 02.40
            _ofrmThreadedEndCastingYes_PortIntegral = New frmThreadedEndCastingYes_PortIntegral
            '*******************
            '----------------------------------------
            '----------CrossTube--------------

            _oFrmCTPortInTube = New frmCTPortInTube
            _oFrmCTPortIntegral = New frmCTPortIntegral
            _oFrmCTFabrication = New frmCTFabrication
            _oFrmCTDesignACasting = New frmCTDesignACasting
            _oFrmCTCastingYes = New frmCTCastingYes
            _oFrmCTCastingNo_PortInTube = New frmCTCastingNo_PortInTube
            _oFrmCTCastingNo_PortIntegral = New frmCTCastingNo_PortIntegral
            _oFrmDesignABasePlug = New frmDesignABasePlug           '04_12_2009   RAGAVA

            _oFrmCTPortInTube2 = New frmCTPortInTube2
            _oFrmCTPortIntegral2 = New frmCTPortIntegral2
            _oFrmCTFabrication2 = New frmCTFabrication2
            _oFrmCTDesignACasting2 = New frmCTDesignACasting2
            _oFrmCTCastingYes2 = New frmCTCastingYes2
            _oFrmCTCastingNo_PortInTube2 = New frmCTCastingNo_PortInTube2
            _oFrmCTCastingNo_PortIntegral2 = New frmCTCastingNo_PortIntegral2
            '---------------------------------

            '----------RodEnd SingleLug--------------
            _oFrmRESingleLugDetails = New frmRESingleLugDetails
            _oFrmRESingleLugExistingNotSelected = New frmRESingleLugExistingNotSelected
            '---------------------------------
            'MANJULA ADDED
            '----------RodEnd BH--------------
            _oFrmREBHDetails = New frmREBHDetails
            _oFrmREBHExistingNotSelected = New frmREBHExistingNotSelected
            '---------------------------------

            '----------Rod End Flat With Chamfer-------------
            _oFrmFlatWithChamfer = New frmFlatWithChamfer

            '---------------------------------------------

            '----------Drilled Pin Hole Rod End--------------

            _oFrmREDrilledPinHole = New frmREDrilledPinHole

            '-------------------------------------------------

            '----------Threaded End _ Rod End-----------------

            _oFrmREThreadedRod = New frmREThreadedRod

            '------------------------------------------------

            _oFrmRetractedLengthValidation = New frmRetractedLengthValidation


            '--------------RodEndDoubleLug------------------

            _oFrmREDLCasting = New frmREDLCasting

            _oFrmREDLThreaded = New frmREDLThreaded

            _oFrmREDLWelded = New frmREDLWelded

            _oFrmREDLExistingDesign = New frmREDLExistingDesign

            _oFrmREDLNewDesign = New frmREDLNewDesign

            '-----------------------------------------------

            '-----------Cross Tube - Rod End------------------

            _oFrmRECrossTube = New frmRECrossTube

            _oFrmCastingYes_RECT = New frmCastingYes_RECT

            _oFrmCastingNo_RECT = New frmCastingNo_RECT

            _oFrmDesignACasting_RECT = New frmDesignACasting_RECT

            _oFrmFabrication_RECT = New frmFabrication_RECT
            '31_08_2012   RAGAVA   Commented  Weldment
            '_oFrmRECrossTube2 = New frmRECrossTube2

            '_oFrmCastingYes_RECT2 = New frmCastingYes_RECT2

            '_oFrmCastingNo_RECT2 = New frmCastingNo_RECT2

            '_oFrmDesignACasting_RECT2 = New frmDesignACasting_RECT2

            '_oFrmFabrication_RECT2 = New frmFabrication_RECT2

            '---------------------------------------------------

            '-----------------------------------------------

            '-----------Generate------------------
            _oFrmGenerate = New frmGenerate
            '-----------------------------------------------

            ': ANUP 27-05-2010 01.51pm
            '-------------Contract Details---------------------------
            _oFrmContractDetails = New frmContractDetails
            _oFrmMonarchRevision = New frmMonarchRevision
            _oFrmPin_Port_PaintAccessories = New frmPin_Port_PaintAccessories

            'A0308: ANUP 09-08-2010 02.15pm
            _oFrmImportBaseEnd = New frmImportBaseEnd
            _oFrmImportRodEnd = New frmImportRodEnd

            '<<--9-12-2010 Aruna-->>
            _ofrmUpdateRecords = New frmUpdateDatabaseRecords
        Catch ex As Exception

        End Try
    End Sub

    Public Sub AddItemsToGeneralInformationListView()
        _lvwGeneralInformation.Columns.Clear()
        _lvwGeneralInformation.Items.Clear()
        _lvwGeneralInformation.Columns.Add("Property", 190, HorizontalAlignment.Center)
        _lvwGeneralInformation.Columns.Add("Value", 115, HorizontalAlignment.Center)
        Dim intCount As Integer = 0
        For Each oGeneralInformationItem As Object In GeneralInformation
            Dim oGeneralListViewItem As ListViewItem
            oGeneralListViewItem = _lvwGeneralInformation.Items.Add(oGeneralInformationItem(0))
            _lvwGeneralInformation.Items(intCount).SubItems.Add(oGeneralInformationItem(1))
            intCount += 1
        Next
    End Sub

    Public Sub AddGeneralInformationValues(ByVal strKey As String, ByVal strValue As String)
        For Each oGeneralInformationListViewItem As Object In _lvwGeneralInformation.Items
            If oGeneralInformationListViewItem.SubItems.Item(0).Text.Equals(strKey) Then
                oGeneralInformationListViewItem.SubItems.Item(1).Text = strValue
                Exit For
            End If
        Next
    End Sub

    Public Sub AddTextToRichTextBox(ByVal strMessage As String)
        Dim oFont As New Font(_rtxtMessages.Font, FontStyle.Bold)
        _rtxtMessages.Text = strMessage
        _rtxtMessages.SelectionBullet = True
        _rtxtMessages.Font = oFont
        _rtxtMessages.ForeColor = Color.Black
    End Sub

    Public Sub DeleteTextFromRichTextBox()
        If Not IsNothing(_rtxtMessages) Then
            _rtxtMessages.Text = ""
        End If
    End Sub

    '14_07_2010    RAGAVA
    Private Function GetCylinderCodeNumber() As String
        GetCylinderCodeNumber = ""
        Try
            Dim iContractNumber As Long = 677500 'vamsi changed for IFL System as per updates from 675000
            Dim strQuery As String = String.Empty
            strQuery = "select top 1 ContractNumber from ContractNumberDetails order by ContractNumber Desc"
            Dim objDT As DataTable = MonarchConnectionObject.GetTable(strQuery)
            If objDT.Rows.Count > 0 Then
                iContractNumber = Val(objDT.Rows(0).Item("ContractNumber").ToString)
                iContractNumber = iContractNumber + 1
            End If
            Try
                strQuery = "Insert into ContractNumberDetails Values ('" & iContractNumber.ToString & "')"
                objDT = MonarchConnectionObject.GetTable(strQuery)
            Catch ex As Exception
            End Try
            GetCylinderCodeNumber = iContractNumber.ToString
        Catch ex As Exception
        End Try
        Return GetCylinderCodeNumber
    End Function


    '12_11_2009  Ragava
    Public Sub Area_Y_LugWidth_LugThickness_Calculation(Optional ByVal dblSafetyFactor As Double = 0, Optional ByVal chkOptimizer As Boolean = False, Optional ByVal dblYeildStrength As Double = 36000, Optional ByVal str1st_2nd As String = "1")     '15_05_2012   RAGAVA
        Try
            Dim dblWorkingPressure As Double
            Dim dblRodDiameter As Double
            '26_10_2010   RAGAVA
            Try
                Dim oRodDiameters As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetRodDiameters(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter)
                If chkOptimizer = True Then
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure < 3000 Then
                        dblWorkingPressure = 3000
                    Else
                        dblWorkingPressure = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure
                    End If
                    dblRodDiameter = oRodDiameters.Rows(0)("RODDIAMETER")
                Else
                    dblWorkingPressure = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure
                    dblRodDiameter = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter
                End If
            Catch ex As Exception
            End Try
            'Till   Here

            '15_05_2012   RAGAVA
            Dim dblBoreDiameter As Double = 0
            Dim dblRequiredLugThickness As Double = 0
            Dim dblCrossTubeWidth As Double = 0


            'If str1st_2nd = "1" Then
            dblBoreDiameter = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter
            dblRequiredLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
            dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth
            'Else
            '    dblBoreDiameter = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter
            '    dblRequiredLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2
            '    dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth2
            'End If

            Dim dblBushingQuantity As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity
            Dim dblRequiredPinHoleSize As Double
            Dim dblRequiredPinHoleSize_CrossTube As Double
            If dblBushingQuantity = 0 Then
                dblRequiredPinHoleSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
                dblRequiredPinHoleSize_CrossTube = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetNominalPinHoleSize(dblRequiredPinHoleSize)
                If dblRequiredPinHoleSize_CrossTube = 0 Then
                    dblRequiredPinHoleSize_CrossTube = dblRequiredPinHoleSize
                End If
            Else
                dblRequiredPinHoleSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingOD_BaseEnd
                dblRequiredPinHoleSize_CrossTube = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingOD_BaseEnd
            End If
            '*********************

            Dim dblCylindricalPullForce As Double = dblWorkingPressure * (Math.PI / 4) * (Math.Pow(dblBoreDiameter, 2) - Math.Pow(dblRodDiameter, 2))   '12_11_2009  Ragava

            Dim dblNutSafetyFactor As Double
            If Not dblSafetyFactor = 0 Then
                dblNutSafetyFactor = dblSafetyFactor
            Else
                dblNutSafetyFactor = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NutSafetyFactor
            End If

            Dim dblRequiredArea As Double = Math.Round((dblCylindricalPullForce * dblNutSafetyFactor) / dblYeildStrength, 2)      '12_11_2009  Ragava
            Dim dblYRequired As Double = 0
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Cross Tube" Then
                dblYRequired = (2 * dblRequiredArea) / (3 * dblCrossTubeWidth)
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" Then   '24_02_2010    RAGAVA
                dblYRequired = dblRequiredArea / (4 * dblRequiredLugThickness)                              '24_02_2010    RAGAVA
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Base Plug" Then   '18_03_2010    RAGAVA
                dblYRequired = 0.45  ' dblRequiredArea / (2 * dblRequiredLugThickness)        '18_03_2010    RAGAVA
                Dim dblAreaOfRod As Double = AreaOfRodWithPinHoleCalculation(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OutSidePlugDiameter, dblRequiredPinHoleSize)
                If dblAreaOfRod < dblRequiredArea Then
                    Dim strMessage As String = "Area is not suffiecient for the selected BasePlug or PinHoleDia, Please change one of them. "
                    MessageBox.Show(strMessage, "Area is not suffiecient", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
                End If
            Else
                dblYRequired = dblRequiredArea / (2 * dblRequiredLugThickness)
            End If
            Dim dblRequiredLugWidth As Double = (2 * dblYRequired) + dblRequiredPinHoleSize

            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Cross Tube" Then
                Dim dblCrossTubeOD1 As Double = dblRequiredPinHoleSize_CrossTube + (2 * dblYRequired)
                Dim dblCrossTubeOD2 As Double = dblRequiredPinHoleSize_CrossTube + 0.5
                '15_05_2012  RAGAVA
                If str1st_2nd = "1" Then
                    If dblCrossTubeOD1 < dblCrossTubeOD2 Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD = dblCrossTubeOD2
                    Else
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD = dblCrossTubeOD1
                    End If
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD / 2 + _
                                                                                                     ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OffSet
                Else
                    If dblCrossTubeOD1 < dblCrossTubeOD2 Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD2 = dblCrossTubeOD2
                    Else
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD2 = dblCrossTubeOD1
                    End If
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance2 = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD2 / 2 + _
                                                                                                     ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OffSet
                End If
            End If
            '15_05_2012  RAGAVA
            If str1st_2nd = "1" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth = dblRequiredLugWidth
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth2 = dblRequiredLugWidth
            End If
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired = dblRequiredArea
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.YRequired = dblYRequired
            'Aruna 18_3_2010 
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PullForce = dblCylindricalPullForce

        Catch ex As Exception

        End Try
    End Sub

    Public Sub Area_Y_LugWidth_LugThickness_Calculation_RodEnd(Optional ByVal dblSafetyFactor As Double = 0, Optional ByVal dblYeildStrength As Double = 36000, Optional ByVal str1st_2nd As String = "1")          '24_07_2012    RAGAVA
        Dim dblWorkingPressure As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure
        Dim dblBoreDiameter As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter
        Dim dblRodDiameter As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter
        Dim dblRequiredLugThickness_RodEnd As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd
        Dim dblCrossTubeWidth_RodEnd As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd

        'Dim dblRequiredPinHoleSize_RodEnd As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd
        Dim dblBushingQuantity_RodEnd As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity_RodEnd
        Dim dblRequiredPinHoleSize_RodEnd As Double
        Dim dblRequiredPinHoleSize_CrossTube As Double
        If dblBushingQuantity_RodEnd = 0 Then
            dblRequiredPinHoleSize_RodEnd = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd
            dblRequiredPinHoleSize_CrossTube = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetNominalPinHoleSize(dblRequiredPinHoleSize_RodEnd)
            'ANUP 17-08-2010
            If dblRequiredPinHoleSize_CrossTube = 0 Then
                dblRequiredPinHoleSize_CrossTube = dblRequiredPinHoleSize_RodEnd
            End If
            'TILL HERE ANUP
        Else
            dblRequiredPinHoleSize_RodEnd = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingOD_RodEnd
            dblRequiredPinHoleSize_CrossTube = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingOD_RodEnd
        End If

        Dim dblCylindricalPullForce_RodEnd As Double = dblWorkingPressure * (Math.PI / 4) * (Math.Pow(dblBoreDiameter, 2) - Math.Pow(dblRodDiameter, 2))   '12_11_2009  Ragava

        Dim dblNutSafetyFactor_RodEnd As Double
        If Not dblSafetyFactor = 0 Then
            dblNutSafetyFactor_RodEnd = dblSafetyFactor
        Else
            dblNutSafetyFactor_RodEnd = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NutSafetyFactor
        End If

        Dim dblRequiredArea_RodEnd As Double = Math.Round((dblCylindricalPullForce_RodEnd * dblNutSafetyFactor_RodEnd) / dblYeildStrength, 2)      '12_11_2009  Ragava

        'LugWidth calculation
        Dim dblYRequired_RodEnd As Double = 0
        'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Cross Tube" Then
        '    dblYRequired_RodEnd = Math.Round(dblRequiredArea_RodEnd / (2 * dblCrossTubeWidth_RodEnd), 2)
        'Else
        '    dblYRequired_RodEnd = Math.Round(dblRequiredArea_RodEnd / (2 * dblRequiredLugThickness_RodEnd), 2)
        'End If

        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Cross Tube" Then
            dblYRequired_RodEnd = (2 * dblRequiredArea_RodEnd) / (3 * dblCrossTubeWidth_RodEnd)
        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug" Then
            dblYRequired_RodEnd = dblRequiredArea_RodEnd / (4 * dblRequiredLugThickness_RodEnd)
        Else
            dblYRequired_RodEnd = dblRequiredArea_RodEnd / (2 * dblRequiredLugThickness_RodEnd)
        End If

        Dim dblRequiredLugWidth_RodEnd As Double = Math.Round((2 * dblYRequired_RodEnd) + dblRequiredPinHoleSize_RodEnd, 3)
        'Dim dblRequiredLugWidth_RodEnd As Double = (2 * dblYRequired_RodEnd) + dblRequiredPinHoleSize_RodEnd

        '24_07_2012   RAGAVA
        If str1st_2nd = "1" Then
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Cross Tube" Then
                Dim dblCrossTubeOD1_RodEnd As Double = dblRequiredPinHoleSize_CrossTube + (2 * dblYRequired_RodEnd)
                Dim dblCrossTubeOD2_RodEnd As Double = dblRequiredPinHoleSize_CrossTube + 0.5
                If dblCrossTubeOD1_RodEnd < dblCrossTubeOD2_RodEnd Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD_RodEnd = dblCrossTubeOD2_RodEnd
                Else
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD_RodEnd = dblCrossTubeOD1_RodEnd
                End If
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD_RodEnd / 2 + _
                                                                                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OffSet_RodEnd
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd = dblRequiredLugWidth_RodEnd         '25_07_2012   RAGAVA
            End If
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd = dblRequiredLugWidth_RodEnd
        Else
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Cross Tube" Then
                Dim dblCrossTubeOD1_RodEnd As Double = dblRequiredPinHoleSize_CrossTube + (2 * dblYRequired_RodEnd)
                Dim dblCrossTubeOD2_RodEnd As Double = dblRequiredPinHoleSize_CrossTube + 0.5
                If dblCrossTubeOD1_RodEnd < dblCrossTubeOD2_RodEnd Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD_RodEnd2 = dblCrossTubeOD2_RodEnd
                Else
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD_RodEnd2 = dblCrossTubeOD1_RodEnd
                End If
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd2 = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD_RodEnd2 / 2 + _
                                                                                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OffSet_RodEnd
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd2 = dblRequiredLugWidth_RodEnd         '25_07_2012   RAGAVA
            End If
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd2 = dblRequiredLugWidth_RodEnd
        End If
        
        '--------------------

        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired_RodEnd = dblRequiredArea_RodEnd
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.YRequired_RodEnd = dblYRequired_RodEnd
        'Aruna 18_3_2010 
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PullForce_RodEnd = dblCylindricalPullForce_RodEnd
    End Sub

    Public Function ValidationFunctionality(ByVal oFrom As Control) As Boolean
        ValidationFunctionality = True
        _aEmptyControlData = New ArrayList
        ValidateFormControls(oFrom)
        If _aEmptyControlData.Count > 0 Then
            ValidationFunctionality = False
        End If
    End Function

    Private Sub ValidateFormControls(ByVal oForm As Control)
        For Each oControl As Control In oForm.Controls
            If oControl.HasChildren = True Then
                ValidateFormControls(oControl)
            Else
                CheckControlData(oControl)
            End If
        Next
    End Sub

    Private Sub CheckControlData(ByVal oControl As Control)
        If (TypeOf (oControl) Is TextBox Or TypeOf (oControl) Is ComboBox) Then

            '''''''PART CODE IS OPTIONAL -----  This is in Contract Details Screen'''''''''''''''''''''''''''
            'Sandeep 27-05-2010
            If oControl.Name = "txtlPartCode" Then
                'Dim txtbx As TextBox = CType(oControl, TextBox)
                'If txtbx.Text = "" Then
                '    oControl.BackColor = Color.LightGreen
                '    _aEmptyControlData.Add("Please Enter TBA or PartNumber") 'vamsi 11-11-2013    22-04-14


                'End If
            ElseIf oControl.Visible = True And oControl.Enabled = True Then
                    If oControl.Text = "" Then
                        _aEmptyControlData.Add("Value not entered in " + oControl.Name.Substring(3))
                        oControl.BackColor = Color.LightGreen
                    End If
                End If
            End If
            If TypeOf (oControl) Is ListView Then
                If oControl.Tag <> "" Then
                    If oControl.Tag = "Validation Required" Then
                        If oControl.Visible = True And oControl.Enabled = True Then
                            Dim oListViewControl As ListView = DirectCast(oControl, ListView)
                            If oListViewControl.Items.Count <= 0 OrElse oListViewControl.SelectedItems.Count <= 0 Then
                                _aEmptyControlData.Add("No rows are selected in listview " + oListViewControl.Name.Substring(3))
                            End If
                        End If
                    End If
                Else
                    If oControl.Visible = True And oControl.Enabled = True Then
                        Dim oListViewControl As ListView = DirectCast(oControl, ListView)
                        If oListViewControl.Items.Count <= 0 OrElse oListViewControl.SelectedItems.Count <= 0 Then
                            _aEmptyControlData.Add("No rows are selected in listview " + oListViewControl.Name.Substring(3))
                        End If
                    End If
                End If
            ElseIf TypeOf (oControl) Is Button Then
                If oControl.Name = "btnRadioButtonsSelectionMessage" Then
                    'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnFabricated2SingleLug = False Then      '05_01_2012  RAGAVA
                    If oControl.Enabled = True Then
                    _aEmptyControlData.Add("Kindly select any one of the radio buttons")

                    End If
                    'End If
                End If
            'ElseIf TypeOf (oControl) Is CheckBox Then
            '    If oControl.Name = "chkRephasing" Then

            '        Dim chkbx As CheckBox = CType(oControl, CheckBox)
            '        If chkbx.Checked = False Then
            '            _aEmptyControlData.Add("Are you Sure that This is not Rephasing Cylinder")
            '            If DialogResult.OK Then
            '                Resume Next

            '            End If

            '        End If


            '    End If
        End If
    End Sub

    '24_02_2010 Aruna Modified
    'Public Sub storeData(ByVal TableName As String, ByVal partName As String, Optional ByVal specialCondition As String = "")
    '    Try

    '        ' ObjClsWeldedCylinderFunctionalClass.ObjFrmPistonDesign.ExecuteQuery_PistonDesign() 'ANUP 30-06-2010
    '        'ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign.ExecuteQuery_HeadDesign() 'ANUP 27-10-2010

    '        Dim objDT As New DataTable
    '        Dim strQuery As String = ""
    '        Dim strIFLID As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetMaxIFLID(TableName)

    '        If Not IsNothing(strIFLID) Then
    '            strIFLID = Val(strIFLID) + 1
    '        Else
    '            strIFLID = 1001
    '        End If
    '        Dim strPartCode As String = ""
    '        Dim strDescription As String = ""
    '        Dim dblWallThicknessLower As Double = 0
    '        Dim dblWallThicknessUpper As Double = 0
    '        Dim dblLugHeight As Double = 0
    '        Dim dblArea As Double = 0
    '        Dim dblEndofTubetoRodStop As Double = 0
    '        Dim dblDistancefromPinholetoRodStop As Double = 0
    '        Dim strPinHoleType As String = ""
    '        Dim strPinHoleCustomID As String = ""
    '        Dim dblPinHole_Combined As Double = 0
    '        Dim dblPinHoleCustomUpperTolerance As Double = 0
    '        Dim dblPinHoleCustomLowerTolerance As Double = 9
    '        Dim dblBushingHousingDimensionsID As Double = 0
    '        Dim dblBushingHousingDimensionsUpperTolerance As Double = 0
    '        Dim dblBushingHousingDimensionsLowerTolerance As Double = 0
    '        Dim dblDepth As Double = 0
    '        Dim dblRawID As Double = 0
    '        Dim strGeraseZerk As String = ""
    '        Dim strGreaseZerkAngle As String = ""
    '        Dim strSecondGreaseZerkAngle As String = ""
    '        Dim strMaterial As String = ""
    '        Dim strNotes As String = ""
    '        Dim strCost As String = ""
    '        Dim dblYieldStrength As Double = 0
    '        Dim strBearingHouse As String = ""
    '        Dim strWeldSize As String = ""
    '        Dim strPilotDiameter As String = "0.25"
    '        Dim dblHeight As Double = 0
    '        Dim dblLugDiagonal As Double = 0
    '        Dim dblRadius As Double = 0
    '        Dim dblSlotHeight As Double = 0
    '        Dim dblSlotWidth As Double = 0
    '        Dim dblCrossTubeOD As Double = 0
    '        Dim dblCrossTubeWidth As Double = 0
    '        Dim dbloffSet As Double = 0
    '        Dim strPortFacingAtBaseEnd As String = ""
    '        Dim slotHeight As Double = 0
    '        Dim slotWidth As Double = 0
    '        Dim strMaterialCode As String = ""
    '        Dim strPurchaseManufacturer As String = ""
    '        Dim dblLugWidth As Double
    '        Dim dblPinholeSize As Double
    '        strPartCode = ObjClsWeldedDataClass.GetPurchaseAndManufactureCode(partName)
    '        Try
    '            UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.htStoreConfigurationCodeNumbers, partName, strPartCode)
    '            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.ContainsKey(partName) = False Then     '14_07_2010   RAGAVA
    '                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.Add(partName, strPartCode)            '14_07_2010   RAGAVA
    '            End If
    '        Catch ex As Exception
    '        End Try
    '        TableName = UCase(TableName)


    '        '18_03_2010   RAGAVA  
    '        If UCase(TableName) = UCase("WELDED.BEBasePlugCastWithOutPort") Then
    '            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode
    '            Dim dblPlugOverAllLength As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OutSidePlugDiameter
    '            strDescription = "BASE PLUG " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeOD.ToString + "-" + dblPlugOverAllLength.ToString
    '            dblEndofTubetoRodStop = -0.125
    '            'dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + 0.5
    '            'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = dblDistancefromPinholetoRodStop
    '            strPinHoleType = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType)     '01_06_2010    RAGAVA
    '            strPinHoleCustomID = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
    '            dblPinHoleCustomUpperTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceUpperLimit.Text))
    '            dblPinHoleCustomLowerTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceLowerLimit.Text))
    '            strGeraseZerk = "1/4-28 UNF-2B"
    '            strGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1.ToString
    '            strSecondGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2.ToString
    '            strMaterial = "ASTM A216 70-36 GRADE WCB"
    '            dblYieldStrength = 30000
    '            dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize))
    '            Dim oSelectedRESLDataRow As DataRow = Nothing
    '            oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWallThicknessUpperAndLowerLimits(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure)
    '            If Not IsNothing(oSelectedRESLDataRow) Then
    '                If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")) Then
    '                    dblWallThicknessLower = oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")
    '                End If
    '                If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")) Then
    '                    dblWallThicknessUpper = oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")
    '                End If
    '            End If
    '            '  dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness * (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth - dblPinHole_Combined)
    '            dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired
    '            strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString
    '            strQuery += ", " + dblWallThicknessLower.ToString + "," + dblWallThicknessUpper.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OutSidePlugDiameter.ToString + "," + dblPlugOverAllLength.ToString + ", " + dblEndofTubetoRodStop.ToString
    '            strQuery += "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop.ToString + "," + Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance - 0.0625).ToString + ",'" + IIf(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlatWidth.ToString = "0", "N/A", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlatWidth.ToString)
    '            strQuery += "','" + IIf(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlatHeight.ToString = "0", "N/A", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlatHeight.ToString) + "', " + dblArea.ToString
    '            strQuery += ", '" + strPinHoleType.ToString + "'," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + ", " + strPinHoleCustomID + ", " + dblPinHoleCustomUpperTolerance.ToString + ", " + dblPinHoleCustomLowerTolerance.ToString + ", " + dblBushingHousingDimensionsID.ToString + ", " + dblBushingHousingDimensionsUpperTolerance.ToString
    '            strQuery += ", " + dblBushingHousingDimensionsLowerTolerance.ToString + ", " + dblDepth.ToString + ", " + dblRawID.ToString + ", '" + strGeraseZerk + "', '" + IIf(strGreaseZerkAngle = "0", "N/A", strGreaseZerkAngle) + "', '" + IIf(strSecondGreaseZerkAngle = "0", "N/A", strSecondGreaseZerkAngle)
    '            strQuery += "', " + dblYieldStrength.ToString + ", '" + strCost + "', Getdate() ,'IFL_PART')"
    '        End If
    '        If UCase(TableName) = UCase("WELDED.BasePlugFlushedPort") Then
    '            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode
    '            Dim dblPlugOverAllLength As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OutSidePlugDiameter
    '            strDescription = "BASE PLUG " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeOD.ToString + "-" + dblPlugOverAllLength.ToString
    '            dblEndofTubetoRodStop = -0.125
    '            'dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + 0.5
    '            'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = dblDistancefromPinholetoRodStop
    '            strPinHoleType = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType)     '01_06_2010    RAGAVA
    '            strPinHoleCustomID = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
    '            dblPinHoleCustomUpperTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceUpperLimit.Text))
    '            dblPinHoleCustomLowerTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceLowerLimit.Text))
    '            strGeraseZerk = "1/4-28 UNF-2B"
    '            strGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1.ToString
    '            strSecondGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2.ToString
    '            dblYieldStrength = 30000
    '            strMaterial = "1020"
    '            dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize))
    '            Dim oSelectedRESLDataRow As DataRow = Nothing
    '            oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWallThicknessUpperAndLowerLimits(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure)
    '            If Not IsNothing(oSelectedRESLDataRow) Then
    '                If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")) Then
    '                    dblWallThicknessLower = oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")
    '                End If
    '                If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")) Then
    '                    dblWallThicknessUpper = oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")
    '                End If
    '            End If
    '            '  dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness * (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth - dblPinHole_Combined)
    '            dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired
    '            strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString
    '            strQuery += ", " + dblWallThicknessLower.ToString + "," + dblWallThicknessUpper.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OutSidePlugDiameter.ToString + "," + dblPlugOverAllLength.ToString + ", " + dblEndofTubetoRodStop.ToString
    '            strQuery += "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop.ToString + ",'N/A','N/A'," + Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance - 0.0625).ToString + ",'" + IIf(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlatHeight.ToString = "0", "N/A", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlatWidth.ToString)
    '            strQuery += "','" + IIf(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlatHeight.ToString = "0", "N/A", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlatHeight.ToString) + "', '" + dblArea.ToString
    '            strQuery += "', '" + strPinHoleType.ToString + "'," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + ", '" + strPinHoleCustomID.ToString + "', " + dblPinHole_Combined.ToString + ", " + dblPinHoleCustomUpperTolerance.ToString + ", " + dblPinHoleCustomLowerTolerance.ToString + ", " + dblBushingHousingDimensionsID.ToString + ", " + dblBushingHousingDimensionsUpperTolerance.ToString
    '            strQuery += ", " + dblBushingHousingDimensionsLowerTolerance.ToString + ", " + dblDepth.ToString + ", " + dblRawID.ToString + ", " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortQuantity.ToString + ",'" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_BaseEnd.ToString + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_BaseEnd.ToString + ", " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortFirstOrientation.ToString + ", " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSecondOrientation.ToString + ", '" + strGeraseZerk + "', ' " + IIf(strGreaseZerkAngle = "0", "N/A", strGreaseZerkAngle) + "', ' " + IIf(strSecondGreaseZerkAngle = "0", "N/A", strSecondGreaseZerkAngle)
    '            strQuery += "', '" + strMaterial + "', " + dblYieldStrength.ToString + ", '" + strNotes + "','" + strCost + "', Getdate() ,'IFL_PART')"
    '        End If
    '        '18_03_2010   RAGAVA   TILL   HERE

    '        '27_04_2010   RAGAVA  NEW DESIGN
    '        Try
    '            If TableName = UCase("BEDLCastWithRaisedPort") Or TableName = UCase("BEDLCastWithRaisedPort90") Then       '19_05_2010   RAGAVA   NEW  DESIGN
    '                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode        '12_08_2010   RAGAVA
    '                strDescription = "END CAP 2 LUG " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness.ToString
    '                dblEndofTubetoRodStop = -0.125
    '                '22_04_2010    ragava
    '                If Not ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port Integral" Then
    '                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = -0.125
    '                End If
    '                'Till   here
    '                dblEndofTubetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop
    '                'dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + 0.5
    '                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DistanceFromPinholetoRodStop = dblDistancefromPinholetoRodStop
    '                strPinHoleCustomID = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
    '                dblPinHoleCustomUpperTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceUpperLimit.Text))
    '                dblPinHoleCustomLowerTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceLowerLimit.Text))
    '                'ANUP 13-10-2010 START
    '                ' strGeraseZerk = "1/4-28 UNF-2B"
    '                strGeraseZerk = "N/A"
    '                'ANUP 13-10-2010 TILL HERE
    '                strGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1.ToString
    '                strSecondGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2.ToString
    '                strMaterial = "ASTM A216 70-36 GRADE WCB"
    '                dblYieldStrength = 36000
    '                dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize))
    '                Dim oSelectedBEDLDataRow As DataRow = Nothing
    '                oSelectedBEDLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWallThicknessUpperAndLowerLimits(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure)
    '                If Not IsNothing(oSelectedBEDLDataRow) Then
    '                    If Not IsDBNull(oSelectedBEDLDataRow("WALLTHICKNESSLOWERLIMIT")) Then
    '                        dblWallThicknessLower = oSelectedBEDLDataRow("WALLTHICKNESSLOWERLIMIT")
    '                    End If
    '                    If Not IsDBNull(oSelectedBEDLDataRow("WALLTHICKNESSUPPERLIMIT")) Then
    '                        dblWallThicknessUpper = oSelectedBEDLDataRow("WALLTHICKNESSUPPERLIMIT")
    '                    End If
    '                End If
    '                dblLugHeight = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth / 2) + (2 * ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness)            '06_03_2010  RAGAVA
    '                Dim dblLugGap As Double = dblDL_LugGap
    '                dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness * (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth - dblPinHole_Combined)
    '                strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString
    '                strQuery += ", " + dblWallThicknessLower.ToString + "," + dblWallThicknessUpper.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth.ToString + ", " + dblLugHeight.ToString + ", " + dblLugGap.ToString
    '                strQuery += "," + dblArea.ToString + "," + Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance - 0.0625).ToString + "," + dblEndofTubetoRodStop.ToString
    '                strQuery += "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop.ToString
    '                strQuery += ", " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + ", '" + strPinHoleCustomID + "', " + dblPinHole_Combined.ToString + ", " + dblPinHoleCustomUpperTolerance.ToString + ", " + dblPinHoleCustomLowerTolerance.ToString
    '                strQuery += ", '" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_BaseEnd.ToString + "', '" + _oFrmPortDetails.cmbPortSizeBaseEnd.Text.ToString + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortFirstOrientation.ToString
    '                strQuery += ", '" + strGeraseZerk + "', '" + IIf(strGreaseZerkAngle = "0", "N/A", strGreaseZerkAngle) + "', '" + IIf(strSecondGreaseZerkAngle = "0", "N/A", strSecondGreaseZerkAngle)
    '                strQuery += "', '" + strMaterial + "', '" + strCost + "', Getdate(),'IFL_PART')"
    '            End If
    '        Catch ex As Exception
    '        End Try
    '        'Till   Here

    '        '27_04_2010   RAGAVA
    '        If UCase(TableName) = UCase("BasePlugRaisedPort") Or UCase(TableName) = UCase("BasePlugRaisedPort90") Then          '19_05_2010   RAGAVA
    '            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode
    '            Dim dblPlugOverAllLength As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OutSidePlugDiameter
    '            strDescription = "BASE PLUG " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeOD.ToString + "-" + dblPlugOverAllLength.ToString
    '            If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
    '                dblEndofTubetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop
    '            Else
    '                dblEndofTubetoRodStop = -0.125
    '            End If
    '            strPinHoleType = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType)     '01_06_2010    RAGAVA
    '            strPinHoleCustomID = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
    '            dblPinHoleCustomUpperTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceUpperLimit.Text))
    '            dblPinHoleCustomLowerTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceLowerLimit.Text))
    '            strGeraseZerk = "1/4-28 UNF-2B"
    '            strGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1.ToString
    '            strSecondGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2.ToString
    '            dblYieldStrength = 30000
    '            strMaterial = "1020"
    '            dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize))
    '            Dim oSelectedRESLDataRow As DataRow = Nothing
    '            oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWallThicknessUpperAndLowerLimits(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure)
    '            If Not IsNothing(oSelectedRESLDataRow) Then
    '                If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")) Then
    '                    dblWallThicknessLower = oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")
    '                End If
    '                If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")) Then
    '                    dblWallThicknessUpper = oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")
    '                End If
    '            End If
    '            dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired
    '            strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString
    '            strQuery += ", " + dblWallThicknessLower.ToString + "," + dblWallThicknessUpper.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OutSidePlugDiameter.ToString + "," + dblPlugOverAllLength.ToString + ", " + dblEndofTubetoRodStop.ToString
    '            strQuery += "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop.ToString + ",'N/A','N/A'," + Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance - 0.0625).ToString + ",'" + IIf(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlatHeight.ToString = "0", "N/A", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlatWidth.ToString)
    '            strQuery += "','" + IIf(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlatHeight.ToString = "0", "N/A", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlatHeight.ToString) + "', '" + dblArea.ToString
    '            strQuery += "', '" + strPinHoleType.ToString + "'," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + ", '" + strPinHoleCustomID.ToString + "', " + dblPinHole_Combined.ToString + ", " + dblPinHoleCustomUpperTolerance.ToString + ", " + dblPinHoleCustomLowerTolerance.ToString + ", " + dblBushingHousingDimensionsID.ToString + ", " + dblBushingHousingDimensionsUpperTolerance.ToString
    '            strQuery += ", " + dblBushingHousingDimensionsLowerTolerance.ToString + ", " + dblDepth.ToString + ", " + dblRawID.ToString + ", " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortQuantity.ToString + ",'" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_BaseEnd.ToString + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_BaseEnd.ToString + ", " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortFirstOrientation.ToString + ", " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSecondOrientation.ToString + ", '" + strGeraseZerk + "', ' " + IIf(strGreaseZerkAngle = "0", "N/A", strGreaseZerkAngle) + "', ' " + IIf(strSecondGreaseZerkAngle = "0", "N/A", strSecondGreaseZerkAngle)
    '            strQuery += "', '" + strMaterial + "', " + dblYieldStrength.ToString + ", '" + strNotes + "','" + strCost + "', Getdate() ,'IFL_PART')"
    '        End If

    '        If UCase(TableName) = "BESLCASTINGRAISEDPORT" Or UCase(TableName) = "BESLCASTINGRAISEDPORT90" Then       '19_05_2010   RAGAVA   NEW  DESIGN
    '            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode
    '            Dim oSelectedRESLDataRow As DataRow = Nothing
    '            oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPortBossDiaAndBaseDia(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter)
    '            strDescription = "END CAP 1 LUG" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness.ToString
    '            strPinHoleType = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType)     '01_06_2010    RAGAVA
    '            strPinHoleCustomID = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
    '            dblPinHoleCustomUpperTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceUpperLimit.Text))
    '            dblPinHoleCustomLowerTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceLowerLimit.Text))
    '            strGeraseZerk = "1/4-28 UNF-2B"
    '            strGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1.ToString
    '            strSecondGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2.ToString
    '            strMaterial = "ASTM A216 70-36 GRADE WCB"
    '            dblYieldStrength = 36000
    '            dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize))
    '            oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWallThicknessUpperAndLowerLimits(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure)
    '            If Not IsNothing(oSelectedRESLDataRow) Then
    '                If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")) Then
    '                    dblWallThicknessLower = oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")
    '                End If
    '                If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")) Then
    '                    dblWallThicknessUpper = oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")
    '                End If
    '            End If
    '            strBearingHouse = "N/A"
    '            dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired
    '            strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString
    '            strQuery += ", " + dblWallThicknessUpper.ToString + "," + dblWallThicknessLower.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth.ToString + ", " + dblLugHeight.ToString
    '            strQuery += "," + dblArea.ToString + "," + Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance - 0.0625).ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop.ToString
    '            strQuery += "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop.ToString + ", '" + strPinHoleType.ToString
    '            strQuery += "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + ", '" + strPinHoleCustomID + "', " + dblPinHole_Combined.ToString + ", " + dblPinHoleCustomUpperTolerance.ToString + ", " + dblPinHoleCustomLowerTolerance.ToString + ", " + dblBushingHousingDimensionsID.ToString + ", " + dblBushingHousingDimensionsUpperTolerance.ToString
    '            strQuery += ", " + dblBushingHousingDimensionsLowerTolerance.ToString + ", " + dblDepth.ToString + ", " + dblRawID.ToString + ", '" + strBearingHouse + "','" + strGeraseZerk + "', ' " + IIf(strGreaseZerkAngle = "0", "N/A", strGreaseZerkAngle) + "', ' " + IIf(strSecondGreaseZerkAngle = "0", "N/A", strSecondGreaseZerkAngle)
    '            strQuery += "', '" + strMaterial + "', '" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortQuantity.ToString + "', '" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_BaseEnd.ToString + "','"
    '            strQuery += IIf(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_BaseEnd Is Nothing, "0", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_BaseEnd) + "','" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortFirstOrientation.ToString + "','" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSecondOrientation.ToString + "','" + strNotes + "', '" + strCost + "',  Getdate() ,'IFL_PART'" + ")"
    '        End If

    '        If UCase(TableName) = UCase("BECrossTubeRaisedPort") Or UCase(TableName) = UCase("BECrossTubeRaisedPort90") Then         '19_05_2010    RAGAVA    NEW DESIGN
    '            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode
    '            Dim oSelectedRESLDataRow As DataRow = Nothing
    '            strDescription = "END CAP X TUBE" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth.ToString
    '            dbloffSet = ObjClsWeldedGlobalVariables.OffSet

    '            'ANUP 10-10-2010 START 
    '            'dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + 0.5
    '            'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DistanceFromPinholetoRodStop = dblDistancefromPinholetoRodStop
    '            dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop
    '            'ANUP 10-10-2010 TILL HERE

    '            strPinHoleType = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType)     '01_06_2010    RAGAVA
    '            strPinHoleCustomID = Trim(_oFrmTubeDetails.txtPinHoleSize.Text)
    '            dblPinHoleCustomUpperTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceUpperLimit.Text))
    '            dblPinHoleCustomLowerTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceLowerLimit.Text))
    '            strGeraseZerk = "1/4-28 UNF-2B"
    '            strGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1.ToString
    '            strSecondGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2.ToString
    '            strMaterial = "ASTM A216 70-36 GRADE WCB"
    '            dblYieldStrength = 36000
    '            dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize))
    '            oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWallThicknessUpperAndLowerLimits(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure)
    '            If Not IsNothing(oSelectedRESLDataRow) Then
    '                If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")) Then
    '                    dblWallThicknessLower = oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")
    '                End If
    '                If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")) Then
    '                    dblWallThicknessUpper = oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")
    '                End If
    '            End If
    '            strBearingHouse = "N/A"
    '            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD < Val(Trim(_oFrmCTDesignACasting.txtPinHoleSize_DesignCrossTubeCasting.Text)) + 0.5 Then
    '                UpdateHashTableValues(_htNewDesignPartParams, "CROSS TUBE OD", Val(Trim(_oFrmCTDesignACasting.txtPinHoleSize_DesignCrossTubeCasting.Text)) + 0.5)
    '                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD = Val(Trim(_oFrmCTDesignACasting.txtPinHoleSize_DesignCrossTubeCasting.Text)) + 0.5
    '            End If
    '            dblCrossTubeOD = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD
    '            dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth
    '            strPortFacingAtBaseEnd = ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortFacingBaseEnd.Text
    '            '  dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness * (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth - dblPinHole_Combined)
    '            dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired
    '            strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString
    '            strQuery += ", " + dblWallThicknessUpper.ToString + "," + dblWallThicknessLower.ToString + "," + dblCrossTubeOD.ToString + "," + dblCrossTubeWidth.ToString + "," + dblArea.ToString
    '            strQuery += "," + Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance - 0.0625).ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop.ToString + "," + dbloffSet.ToString
    '            strQuery += "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop.ToString + ", '" + strPinHoleType.ToString
    '            strQuery += "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + ", '" + strPinHoleCustomID + "', " + dblPinHole_Combined.ToString + ", " + dblPinHoleCustomUpperTolerance.ToString + ", " + dblPinHoleCustomLowerTolerance.ToString + ", " + dblBushingHousingDimensionsID.ToString + ", " + dblBushingHousingDimensionsUpperTolerance.ToString
    '            strQuery += ", " + dblBushingHousingDimensionsLowerTolerance.ToString + ", " + dblDepth.ToString + ", " + dblRawID.ToString + ", '" + strGeraseZerk + "', ' " + IIf(strGreaseZerkAngle = "0", "N/A", strGreaseZerkAngle) + "', ' " + IIf(strSecondGreaseZerkAngle = "0", "N/A", strSecondGreaseZerkAngle)
    '            strQuery += "', '" + strMaterial + "', " + dblYieldStrength.ToString + ",'" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortQuantity.ToString + "', '" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_BaseEnd.ToString + "','"
    '            strQuery += IIf(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_BaseEnd Is Nothing, "0", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_BaseEnd) + "','" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortFirstOrientation.ToString + "','" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSecondOrientation.ToString + "','" + strPortFacingAtBaseEnd + "','" + strNotes + "', '" + strCost + "',  Getdate() ,'IFL_PART','" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ISBushingStyle_2BushingsIndividualBore + "')"     'ANUP 20-09-2010 START
    '        End If
    '        'Till   Here
    '        If UCase(TableName) = UCase("WELDED.BESLCASTINGNOPORT") Then
    '            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode
    '            strDescription = "END CAP 1 LUG" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness.ToString
    '            strPinHoleType = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType)     '01_06_2010    RAGAVA
    '            strPinHoleCustomID = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
    '            dblPinHoleCustomUpperTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceUpperLimit.Text))
    '            dblPinHoleCustomLowerTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceLowerLimit.Text))
    '            strGeraseZerk = "1/4-28 UNF-2B"
    '            strGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1.ToString
    '            strSecondGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2.ToString
    '            strMaterial = "ASTM A216 70-36 GRADE WCB"
    '            dblYieldStrength = 36000
    '            dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize))
    '            Dim oSelectedRESLDataRow As DataRow = Nothing
    '            oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWallThicknessUpperAndLowerLimits(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure)
    '            If Not IsNothing(oSelectedRESLDataRow) Then
    '                If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")) Then
    '                    dblWallThicknessLower = oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")
    '                End If
    '                If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")) Then
    '                    dblWallThicknessUpper = oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")
    '                End If
    '            End If
    '            dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired
    '            strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString
    '            strQuery += ", " + dblWallThicknessLower.ToString + "," + dblWallThicknessUpper.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth.ToString + ", " + dblLugHeight.ToString
    '            strQuery += "," + dblArea.ToString + "," + Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance - 0.0625).ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop.ToString
    '            strQuery += "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop.ToString + ", '" + strPinHoleType.ToString
    '            strQuery += "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + ", '" + strPinHoleCustomID + "', " + dblPinHole_Combined.ToString + ", " + dblPinHoleCustomUpperTolerance.ToString + ", " + dblPinHoleCustomLowerTolerance.ToString + ", " + dblBushingHousingDimensionsID.ToString + ", " + dblBushingHousingDimensionsUpperTolerance.ToString
    '            strQuery += ", " + dblBushingHousingDimensionsLowerTolerance.ToString + ", " + dblDepth.ToString + ", " + dblRawID.ToString + ", '" + strGeraseZerk + "', ' " + IIf(strGreaseZerkAngle = "0", "N/A", strGreaseZerkAngle) + "', ' " + IIf(strSecondGreaseZerkAngle = "0", "N/A", strSecondGreaseZerkAngle)
    '            strQuery += "', '" + strMaterial + "', '" + strNotes + "', '" + strCost + "', " + dblYieldStrength.ToString + ", Getdate() ,'IFL_PART')"
    '        End If
    '        If UCase(TableName) = "WELDED.BESLCASTINGFLUSHPORT" Then
    '            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode
    '            Dim oSelectedRESLDataRow As DataRow = Nothing
    '            oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPortBossDiaAndBaseDia(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter)
    '            strDescription = "END CAP 1 LUG" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness.ToString
    '            strPinHoleType = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType)     '01_06_2010    RAGAVA
    '            strPinHoleCustomID = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
    '            dblPinHoleCustomUpperTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceUpperLimit.Text))
    '            dblPinHoleCustomLowerTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceLowerLimit.Text))
    '            strGeraseZerk = "1/4-28 UNF-2B"
    '            strGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1.ToString
    '            strSecondGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2.ToString
    '            strMaterial = "ASTM A216 70-36 GRADE WCB"
    '            dblYieldStrength = 36000
    '            dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize))
    '            oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWallThicknessUpperAndLowerLimits(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure)
    '            If Not IsNothing(oSelectedRESLDataRow) Then
    '                If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")) Then
    '                    dblWallThicknessLower = oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")
    '                End If
    '                If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")) Then
    '                    dblWallThicknessUpper = oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")
    '                End If
    '            End If
    '            strBearingHouse = "N/A"
    '            dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired
    '            strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString
    '            strQuery += ", " + dblWallThicknessUpper.ToString + "," + dblWallThicknessLower.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth.ToString + ", " + dblLugHeight.ToString
    '            strQuery += "," + dblArea.ToString + "," + Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance - 0.0625).ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop.ToString
    '            strQuery += "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop.ToString + ", '" + strPinHoleType.ToString
    '            strQuery += "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + ", '" + strPinHoleCustomID + "', " + dblPinHole_Combined.ToString + ", " + dblPinHoleCustomUpperTolerance.ToString + ", " + dblPinHoleCustomLowerTolerance.ToString + ", " + dblBushingHousingDimensionsID.ToString + ", " + dblBushingHousingDimensionsUpperTolerance.ToString
    '            strQuery += ", " + dblBushingHousingDimensionsLowerTolerance.ToString + ", " + dblDepth.ToString + ", " + dblRawID.ToString + ", '" + strBearingHouse + "','" + strGeraseZerk + "', ' " + IIf(strGreaseZerkAngle = "0", "N/A", strGreaseZerkAngle) + "', ' " + IIf(strSecondGreaseZerkAngle = "0", "N/A", strSecondGreaseZerkAngle)
    '            strQuery += "', '" + strMaterial + "', '" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortQuantity.ToString + "', '" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_BaseEnd.ToString + "','"
    '            strQuery += IIf(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_BaseEnd Is Nothing, "0", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_BaseEnd) + "','" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortFirstOrientation.ToString + "','" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSecondOrientation.ToString + "','" + strNotes + "', '" + strCost + "',  Getdate() ,'IFL_PART'" + ")"
    '        End If

    '        If UCase(TableName) = UCase("WELDED.RESLDetails") Then
    '            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd = strPartCode
    '            strDescription = "ROD END 1 LUG" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd.ToString
    '            'ANUP 10-10-2010 START 
    '            'dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + 0.5
    '            'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DistanceFromPinholetoRodStop = dblDistancefromPinholetoRodStop
    '            'dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop
    '            'ANUP 10-10-2010 TILL HERE
    '            strPinHoleType = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType_RodEnd)     '01_06_2010    RAGAVA
    '            strPinHoleCustomID = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd
    '            dblPinHoleCustomUpperTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceUpperLimit.Text))
    '            dblPinHoleCustomLowerTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceLowerLimit.Text))
    '            strGeraseZerk = "1/4-28 UNF-2B"
    '            strGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1.ToString
    '            strSecondGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2.ToString
    '            strMaterial = "ASTM A216 70-36 GRADE WCB"
    '            dblYieldStrength = 36000
    '            dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize))
    '            Dim oSelectedRESLDataRow As DataRow = Nothing
    '            oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWallThicknessUpperAndLowerLimits(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure)
    '            If Not IsNothing(oSelectedRESLDataRow) Then
    '                If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")) Then
    '                    dblWallThicknessLower = oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")
    '                End If
    '                If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")) Then
    '                    dblWallThicknessUpper = oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")
    '                End If
    '            End If
    '            'strWeldSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWeldSize_RESL(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter).ToString
    '            strWeldSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEnd.ToString    '01_06_2010   RAGAVA
    '            dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired_RodEnd
    '            strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter.ToString
    '            strQuery += ", " + IIf(strWeldSize = "", "0", strWeldSize) + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd.ToString + ", "
    '            strQuery += Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd - 0.0625).ToString + "," + IIf(strPilotDiameter = "", "0", strPilotDiameter) + "," + dblArea.ToString 'ANUP 07-12-2010 START
    '            strQuery += "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop.ToString + ", '" + strPinHoleType.ToString
    '            strQuery += "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + ", '" + strPinHoleCustomID + "', " + dblPinHole_Combined.ToString + ", " + dblPinHoleCustomUpperTolerance.ToString + ", " + dblPinHoleCustomLowerTolerance.ToString + ", " + dblBushingHousingDimensionsID.ToString + ", " + dblBushingHousingDimensionsUpperTolerance.ToString
    '            strQuery += ", " + dblBushingHousingDimensionsLowerTolerance.ToString + ", " + dblDepth.ToString + ", " + dblRawID.ToString + ", '" + strGeraseZerk + "', ' " + IIf(strGreaseZerkAngle = "0", "N/A", strGreaseZerkAngle) + "', ' " + IIf(strSecondGreaseZerkAngle = "0", "N/A", strSecondGreaseZerkAngle)
    '            strQuery += "', '" + strMaterial + "', " + dblYieldStrength.ToString + ",'" + strCost + "'" + ", Getdate() ,'IFL_PART')"
    '        End If
    '        If UCase(TableName) = UCase("WELDED.besinglelugdetails") Then
    '            If specialCondition = "Base End" Then
    '                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode
    '                dblHeight = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.lugHeight_BaseEnd
    '                strDescription = "LUG" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth.ToString + "-" + dblHeight.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness.ToString
    '                dblLugDiagonal = Math.Sqrt(Math.Pow(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness, 2) + Math.Pow(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth, 2))
    '                dblRadius = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness / 2
    '                strPinHoleType = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType)     '01_06_2010    RAGAVA
    '                strPinHoleCustomID = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
    '                dblPinHoleCustomUpperTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceUpperLimit.Text))
    '                dblPinHoleCustomLowerTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceLowerLimit.Text))
    '                strGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1.ToString
    '                strSecondGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2.ToString
    '                dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize))
    '                dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired
    '                dblLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth.ToString
    '                dblPinholeSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
    '            Else
    '                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd = strPartCode          '20_10_2010    RAGAVA
    '                dblHeight = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.lugHeight_RodEnd
    '                strDescription = "LUG" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd.ToString + "-" + dblHeight.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd.ToString
    '                dblLugDiagonal = Math.Sqrt(Math.Pow(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd, 2) + Math.Pow(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd, 2))
    '                dblRadius = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd / 2
    '                strPinHoleType = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType_RodEnd)
    '                strPinHoleCustomID = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd
    '                dblPinHoleCustomUpperTolerance = Val(Trim(_oFrmRodEndConfiguration.txtToleranceUpperLimit_RodEnd.Text))
    '                dblPinHoleCustomLowerTolerance = Val(Trim(_oFrmRodEndConfiguration.txtToleranceLowerLimit_RodEnd.Text))
    '                strGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1_RodEnd.ToString
    '                strSecondGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2_RodEnd.ToString
    '                dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd))
    '                dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired_RodEnd
    '                dblLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd
    '                dblPinholeSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd
    '            End If
    '            strGeraseZerk = "1/4-28 UNF-2B"
    '            strMaterial = "ASTM A216 70-36 GRADE WCB"
    '            dblYieldStrength = 44000
    '            Dim oSelectedRESLDataRow As DataRow = Nothing
    '            oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWallThicknessUpperAndLowerLimits(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure)
    '            If Not IsNothing(oSelectedRESLDataRow) Then
    '                If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")) Then
    '                    dblWallThicknessLower = oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")
    '                End If
    '                If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")) Then
    '                    dblWallThicknessUpper = oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")
    '                End If
    '            End If
    '            strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness.ToString
    '            strQuery += ", " + dblLugWidth.ToString + ", " + dblLugDiagonal.ToString + "," + dblArea.ToString + "," + dblHeight.ToString
    '            strQuery += "," + dblPinholeSize.ToString + ", '" + strPinHoleCustomID + "', " + dblPinHole_Combined.ToString + ", " + dblPinHoleCustomUpperTolerance.ToString + ", " + dblPinHoleCustomLowerTolerance.ToString
    '            strQuery += ", " + dblSlotHeight.ToString + "," + dblSlotWidth.ToString + "," + dblRadius.ToString + ", '" + strGeraseZerk + "', ' " + IIf(strGreaseZerkAngle = "0", "N/A", strGreaseZerkAngle) + "', ' " + IIf(strSecondGreaseZerkAngle = "0", "N/A", strSecondGreaseZerkAngle)
    '            strQuery += "', '" + strMaterial + "', '" + strMaterialCode + "'," + dblYieldStrength.ToString + ", '" + strPurchaseManufacturer + "','" + strCost + "' " + ", Getdate() ,'IFL_PART')"
    '        End If

    '        If UCase(TableName) = UCase("WELDED.BECrossTubeFlushPort") Then
    '            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode
    '            Dim oSelectedRESLDataRow As DataRow = Nothing
    '            strDescription = "END CAP X TUBE" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth.ToString
    '            dbloffSet = ObjClsWeldedGlobalVariables.OffSet
    '            'ANUP 10-10-2010 START 
    '            'dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + 0.5
    '            'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DistanceFromPinholetoRodStop = dblDistancefromPinholetoRodStop
    '            dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop
    '            'ANUP 10-10-2010 TILL HERE
    '            strPinHoleType = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType)     '01_06_2010    RAGAVA
    '            strPinHoleCustomID = Trim(_oFrmTubeDetails.txtPinHoleSize.Text)
    '            dblPinHoleCustomUpperTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceUpperLimit.Text))
    '            dblPinHoleCustomLowerTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceLowerLimit.Text))
    '            strGeraseZerk = "1/4-28 UNF-2B"
    '            strGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1.ToString
    '            strSecondGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2.ToString
    '            strMaterial = "ASTM A216 70-36 GRADE WCB"
    '            dblYieldStrength = 36000
    '            dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize))
    '            oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWallThicknessUpperAndLowerLimits(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure)
    '            If Not IsNothing(oSelectedRESLDataRow) Then
    '                If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")) Then
    '                    dblWallThicknessLower = oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")
    '                End If
    '                If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")) Then
    '                    dblWallThicknessUpper = oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")
    '                End If
    '            End If
    '            strBearingHouse = "N/A"
    '            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD < Val(Trim(_oFrmCTDesignACasting.txtPinHoleSize_DesignCrossTubeCasting.Text)) + 0.5 Then
    '                UpdateHashTableValues(_htNewDesignPartParams, "CROSS TUBE OD", Val(Trim(_oFrmCTDesignACasting.txtPinHoleSize_DesignCrossTubeCasting.Text)) + 0.5)
    '                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD = Val(Trim(_oFrmCTDesignACasting.txtPinHoleSize_DesignCrossTubeCasting.Text)) + 0.5
    '            End If
    '            dblCrossTubeOD = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD
    '            dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth
    '            strPortFacingAtBaseEnd = ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortFacingBaseEnd.Text
    '            '  dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness * (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth - dblPinHole_Combined)
    '            dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired
    '            strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString
    '            strQuery += ", " + dblWallThicknessUpper.ToString + "," + dblWallThicknessLower.ToString + "," + dblCrossTubeOD.ToString + "," + dblCrossTubeWidth.ToString + "," + dblArea.ToString
    '            strQuery += "," + Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance - 0.0625).ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop.ToString + "," + dbloffSet.ToString
    '            strQuery += "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop.ToString + ", '" + strPinHoleType.ToString
    '            strQuery += "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + ", '" + strPinHoleCustomID + "', " + dblPinHole_Combined.ToString + ", " + dblPinHoleCustomUpperTolerance.ToString + ", " + dblPinHoleCustomLowerTolerance.ToString + ", " + dblBushingHousingDimensionsID.ToString + ", " + dblBushingHousingDimensionsUpperTolerance.ToString
    '            strQuery += ", " + dblBushingHousingDimensionsLowerTolerance.ToString + ", " + dblDepth.ToString + ", " + dblRawID.ToString + ", '" + strGeraseZerk + "', ' " + IIf(strGreaseZerkAngle = "0", "N/A", strGreaseZerkAngle) + "', ' " + IIf(strSecondGreaseZerkAngle = "0", "N/A", strSecondGreaseZerkAngle)
    '            strQuery += "', '" + strMaterial + "', " + dblYieldStrength.ToString + ",'" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortQuantity.ToString + "', '" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_BaseEnd.ToString + "','"
    '            strQuery += IIf(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_BaseEnd Is Nothing, "0", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_BaseEnd) + "','" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortFirstOrientation.ToString + "','" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSecondOrientation.ToString + "','" + strPortFacingAtBaseEnd + "','" + strNotes + "', '" + strCost + "',  Getdate() ,'IFL_PART','" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ISBushingStyle_2BushingsIndividualBore + "')"     'ANUP 20-09-2010 START
    '        End If
    '        If UCase(TableName) = UCase("WELDED.BECrossTubeCastingWithoutPort") Then
    '            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode
    '            Dim oSelectedRESLDataRow As DataRow = Nothing
    '            strDescription = "END CAP X TUBE" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth.ToString
    '            dbloffSet = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OffSet
    '            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD < Val(Trim(_oFrmCTDesignACasting.txtPinHoleSize_DesignCrossTubeCasting.Text)) + 0.5 Then
    '                UpdateHashTableValues(_htNewDesignPartParams, "CROSS TUBE OD", Val(Trim(_oFrmCTDesignACasting.txtPinHoleSize_DesignCrossTubeCasting.Text)) + 0.5)
    '                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD = Val(Trim(_oFrmCTDesignACasting.txtPinHoleSize_DesignCrossTubeCasting.Text)) + 0.5
    '            End If
    '            strPinHoleType = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType)     '01_06_2010    RAGAVA
    '            strPinHoleCustomID = Trim(_oFrmTubeDetails.txtPinHoleSize.Text)
    '            dblPinHoleCustomUpperTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceUpperLimit.Text))
    '            dblPinHoleCustomLowerTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceLowerLimit.Text))
    '            strGeraseZerk = "1/4-28 UNF-2B"
    '            strGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1.ToString
    '            strSecondGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2.ToString
    '            strMaterial = "ASTM A216 70-36 GRADE WCB"
    '            dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize))
    '            oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWallThicknessUpperAndLowerLimits(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure)
    '            If Not IsNothing(oSelectedRESLDataRow) Then
    '                If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")) Then
    '                    dblWallThicknessLower = oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")
    '                End If
    '                If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")) Then
    '                    dblWallThicknessUpper = oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")
    '                End If
    '            End If
    '            strBearingHouse = "N/A"
    '            dblYieldStrength = 36000
    '            strPortFacingAtBaseEnd = ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortFacingBaseEnd.Text
    '            dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired
    '            dblCrossTubeOD = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD
    '            strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString
    '            strQuery += "," + dblWallThicknessLower.ToString + "," + dblWallThicknessUpper.ToString + "," + dblCrossTubeOD.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth.ToString + "," + dblArea.ToString        '04_03_2010   RAGAVA
    '            strQuery += "," + Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance - 0.0625).ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop.ToString + "," + dbloffSet.ToString
    '            strQuery += "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop.ToString + ", '" + strPinHoleType.ToString
    '            strQuery += "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + ", '" + strPinHoleCustomID + "', " + dblPinHole_Combined.ToString + ", " + dblPinHoleCustomUpperTolerance.ToString + ", " + dblPinHoleCustomLowerTolerance.ToString + ", " + dblBushingHousingDimensionsID.ToString + ", " + dblBushingHousingDimensionsUpperTolerance.ToString
    '            strQuery += ", " + dblBushingHousingDimensionsLowerTolerance.ToString + ", " + dblDepth.ToString + ", " + dblRawID.ToString + ", '" + strGeraseZerk + "', ' " + IIf(strGreaseZerkAngle = "0", "N/A", strGreaseZerkAngle) + "', ' " + IIf(strSecondGreaseZerkAngle = "0", "N/A", strSecondGreaseZerkAngle)
    '            strQuery += "', '" + strMaterial + "', " + dblYieldStrength.ToString + ", '" + strCost + "',  Getdate() ,'IFL_PART','" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ISBushingStyle_2BushingsIndividualBore + "')"     'ANUP 20-09-2010 START
    '        End If
    '        If UCase(TableName) = UCase("Welded.RECrossTubeCasting") Then
    '            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd = strPartCode
    '            Dim oSelectedRESLDataRow As DataRow = Nothing
    '            strDescription = "END CAP X TUBE" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth.ToString
    '            dbloffSet = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OffSet_RodEnd
    '            strPinHoleType = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType_RodEnd)     '01_06_2010    RAGAVA
    '            strPinHoleCustomID = Trim(_oFrmTubeDetails.txtPinHoleSize.Text)
    '            dblPinHoleCustomUpperTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceUpperLimit.Text))
    '            dblPinHoleCustomLowerTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceLowerLimit.Text))
    '            strGeraseZerk = "1/4-28 UNF-2B"
    '            strGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1.ToString
    '            strSecondGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2.ToString
    '            strMaterial = "8620"
    '            dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize))
    '            oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWallThicknessUpperAndLowerLimits(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure)
    '            If Not IsNothing(oSelectedRESLDataRow) Then
    '                If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")) Then
    '                    dblWallThicknessLower = oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")
    '                End If
    '                If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")) Then
    '                    dblWallThicknessUpper = oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")
    '                End If
    '            End If
    '            strBearingHouse = "N/A"
    '            dblYieldStrength = 79000
    '            'strWeldSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWeldSize_RESL(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter).ToString
    '            strWeldSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEnd.ToString    '01_06_2010   RAGAVA
    '            strPortFacingAtBaseEnd = ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortFacingBaseEnd.Text
    '            dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired_RodEnd
    '            dblCrossTubeOD = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD_RodEnd
    '            dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd
    '            strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter.ToString
    '            strQuery += ", " + IIf(strWeldSize = "", "0", strWeldSize) + "," + dblCrossTubeOD.ToString + "," + dblCrossTubeWidth.ToString
    '            strQuery += "," + IIf(strPilotDiameter = "", "0", strPilotDiameter) + "," + dblArea.ToString
    '            strQuery += "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop.ToString + ", '" + strPinHoleType.ToString
    '            strQuery += "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + ", '" + strPinHoleCustomID + "', " + dblPinHole_Combined.ToString + ", " + dblPinHoleCustomUpperTolerance.ToString + ", " + dblPinHoleCustomLowerTolerance.ToString + ", " + dblBushingHousingDimensionsID.ToString + ", " + dblBushingHousingDimensionsUpperTolerance.ToString
    '            strQuery += ", " + dblBushingHousingDimensionsLowerTolerance.ToString + ", " + dblDepth.ToString + ", " + dblRawID.ToString + ", '" + strGeraseZerk + "', ' " + IIf(strGreaseZerkAngle = "0", "N/A", strGreaseZerkAngle) + "', ' " + IIf(strSecondGreaseZerkAngle = "0", "N/A", strSecondGreaseZerkAngle)
    '            strQuery += "', '" + strMaterial + "'," + dblYieldStrength.ToString + ",'" + strCost + "' " + ", Getdate() ,'IFL_PART','" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ISBushingStyle_2BushingsIndividualBore_RodEnd + "')"   'ANUP 20-09-2010 START
    '        End If

    '        If UCase(TableName) = UCase("Welded.becrossTubeDetails") Then
    '            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode
    '            strPinHoleType = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType)     '01_06_2010    RAGAVA
    '            strPinHoleCustomID = Trim(_oFrmTubeDetails.txtPinHoleSize.Text)
    '            dblPinHoleCustomUpperTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceUpperLimit.Text))
    '            dblPinHoleCustomLowerTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceLowerLimit.Text))
    '            dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize))
    '            strGeraseZerk = "1/4-28 UNF-2B"
    '            strGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1.ToString
    '            strSecondGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2.ToString
    '            dblYieldStrength = 30000

    '            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Cross Tube" Then
    '                dblCrossTubeOD = ((4 / 3) * (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired / Val(Trim(_oFrmCTFabrication.txtCrossTubeWidth_DesignCrossTube.Text)))) + Val(Trim(_oFrmCTFabrication.txtPinHoleSize_DesignCrossTube.Text))
    '                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD < Val(Trim(_oFrmCTFabrication.txtPinHoleSize_DesignCrossTube.Text)) + 0.5 Then
    '                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD = Val(Trim(_oFrmCTFabrication.txtPinHoleSize_DesignCrossTube.Text)) + 0.5
    '                End If
    '                strDescription = "CROSS TUBE" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth.ToString
    '                dblCrossTubeOD = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD
    '                dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth
    '                dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired
    '            End If
    '            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Cross Tube" Then
    '                dblCrossTubeOD = ((4 / 3) * (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired_RodEnd / Val(Trim(_oFrmFabrication_RECT.txtCrossTubeWidth_RECT.Text)))) + Val(Trim(_oFrmFabrication_RECT.txtPinHoleSize_DesignCrossTubeCT_RECT.Text))
    '                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD_RodEnd < Val(Trim(_oFrmFabrication_RECT.txtPinHoleSize_DesignCrossTubeCT_RECT.Text)) + 0.5 Then
    '                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD_RodEnd = Val(Trim(_oFrmFabrication_RECT.txtPinHoleSize_DesignCrossTubeCT_RECT.Text)) + 0.5
    '                End If
    '                strDescription = "CROSS TUBE" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD_RodEnd.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd.ToString
    '                dblCrossTubeOD = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD_RodEnd
    '                dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd
    '                dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired_RodEnd
    '            End If
    '            strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription
    '            strQuery += "', " + dblCrossTubeOD.ToString + "," + dblCrossTubeWidth.ToString
    '            strQuery += "," + dblArea.ToString
    '            strQuery += ", " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + ", '" + strPinHoleCustomID + "', " + dblPinHole_Combined.ToString + ", " + dblPinHoleCustomUpperTolerance.ToString + ", " + dblPinHoleCustomLowerTolerance.ToString
    '            strQuery += ", '" + strGeraseZerk + "', ' " + IIf(strGreaseZerkAngle = "0", "N/A", strGreaseZerkAngle) + "', ' " + IIf(strSecondGreaseZerkAngle = "0", "N/A", strSecondGreaseZerkAngle)
    '            strQuery += "', '" + strMaterial + "'," + dblYieldStrength.ToString + ",'" + strCost + "' " + ", Getdate() ,'IFL_PART','" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ISBushingStyle_2BushingsIndividualBore + "')"     'ANUP 20-09-2010 START
    '        End If
    '        Try
    '            If UCase(TableName) = UCase("WELDED.BEDLCastWithOutPort") Then
    '                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode          '20_10_2010    RAGAVA
    '                strDescription = "END CAP 2 LUG " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness.ToString
    '                dblEndofTubetoRodStop = -0.125
    '                '22_04_2010    ragava
    '                If Not ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port Integral" Then
    '                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = -0.125
    '                End If
    '                'Till   here
    '                dblEndofTubetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop
    '                'ANUP 10-10-2010 START 
    '                'dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + 0.5
    '                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DistanceFromPinholetoRodStop = dblDistancefromPinholetoRodStop
    '                dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop
    '                'ANUP 10-10-2010 TILL HERE
    '                strPinHoleCustomID = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
    '                dblPinHoleCustomUpperTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceUpperLimit.Text))
    '                dblPinHoleCustomLowerTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceLowerLimit.Text))
    '                'ANUP 13-10-2010 START
    '                ' strGeraseZerk = "1/4-28 UNF-2B"
    '                strGeraseZerk = "N/A"
    '                'ANUP 13-10-2010 TILL HERE
    '                strGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1.ToString
    '                strSecondGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2.ToString
    '                strMaterial = "ASTM A216 70-36 GRADE WCB"
    '                dblYieldStrength = 36000
    '                dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize))
    '                Dim oSelectedBEDLDataRow As DataRow = Nothing
    '                oSelectedBEDLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWallThicknessUpperAndLowerLimits(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure)
    '                If Not IsNothing(oSelectedBEDLDataRow) Then
    '                    If Not IsDBNull(oSelectedBEDLDataRow("WALLTHICKNESSLOWERLIMIT")) Then
    '                        dblWallThicknessLower = oSelectedBEDLDataRow("WALLTHICKNESSLOWERLIMIT")
    '                    End If
    '                    If Not IsDBNull(oSelectedBEDLDataRow("WALLTHICKNESSUPPERLIMIT")) Then
    '                        dblWallThicknessUpper = oSelectedBEDLDataRow("WALLTHICKNESSUPPERLIMIT")
    '                    End If
    '                End If
    '                dblLugHeight = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth / 2) + (2 * ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness)       '06_03_2010    RAGAVA
    '                Dim dblLugGap As Double = dblDL_LugGap
    '                dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness * (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth - dblPinHole_Combined)
    '                strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString
    '                strQuery += ", " + dblWallThicknessLower.ToString + "," + dblWallThicknessUpper.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth.ToString + ", " + dblLugHeight.ToString + ", " + dblLugGap.ToString
    '                strQuery += "," + dblArea.ToString + "," + Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance - 0.0625).ToString + "," + dblEndofTubetoRodStop.ToString
    '                strQuery += "," + dblDistancefromPinholetoRodStop.ToString
    '                strQuery += ", " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + ", '" + strPinHoleCustomID + "', " + dblPinHole_Combined.ToString + ", " + dblPinHoleCustomUpperTolerance.ToString + ", " + dblPinHoleCustomLowerTolerance.ToString
    '                strQuery += ", '" + strGeraseZerk + "', ' " + IIf(strGreaseZerkAngle = "0", "N/A", strGreaseZerkAngle) + "', ' " + IIf(strSecondGreaseZerkAngle = "0", "N/A", strSecondGreaseZerkAngle)
    '                'strQuery += "', '" + strMaterial + "', '" + strNotes + "', '" + strCost + "', " + dblYieldStrength.ToString + ", Getdate())"
    '                strQuery += "', '" + strMaterial + "', '" + strNotes + "', '" + strCost + "', " + dblYieldStrength.ToString + ", Getdate(),'IFL_PART')"        '01_03_2010   RAGAVA
    '            End If
    '        Catch ex As Exception
    '        End Try

    '        Try
    '            If TableName = UCase("WELDED.BEDLCastWithFlushPort") Then
    '                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode          '20_10_2010    RAGAVA
    '                strDescription = "END CAP 2 LUG " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness.ToString
    '                dblEndofTubetoRodStop = -0.125
    '                '22_04_2010    ragava
    '                If Not ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port Integral" Then
    '                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = -0.125
    '                End If
    '                'Till   here
    '                dblEndofTubetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop
    '                'ANUP 10-10-2010 START 
    '                'dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + 0.5
    '                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DistanceFromPinholetoRodStop = dblDistancefromPinholetoRodStop
    '                dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop
    '                'ANUP 10-10-2010 TILL HERE

    '                strPinHoleCustomID = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
    '                dblPinHoleCustomUpperTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceUpperLimit.Text))
    '                dblPinHoleCustomLowerTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceLowerLimit.Text))
    '                'ANUP 13-10-2010 START
    '                ' strGeraseZerk = "1/4-28 UNF-2B"
    '                strGeraseZerk = "N/A"
    '                'ANUP 13-10-2010 TILL HERE
    '                strGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1.ToString
    '                strSecondGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2.ToString
    '                strMaterial = "ASTM A216 70-36 GRADE WCB"
    '                dblYieldStrength = 36000
    '                dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize))
    '                Dim oSelectedBEDLDataRow As DataRow = Nothing
    '                oSelectedBEDLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWallThicknessUpperAndLowerLimits(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure)
    '                If Not IsNothing(oSelectedBEDLDataRow) Then
    '                    If Not IsDBNull(oSelectedBEDLDataRow("WALLTHICKNESSLOWERLIMIT")) Then
    '                        dblWallThicknessLower = oSelectedBEDLDataRow("WALLTHICKNESSLOWERLIMIT")
    '                    End If
    '                    If Not IsDBNull(oSelectedBEDLDataRow("WALLTHICKNESSUPPERLIMIT")) Then
    '                        dblWallThicknessUpper = oSelectedBEDLDataRow("WALLTHICKNESSUPPERLIMIT")
    '                    End If
    '                End If
    '                dblLugHeight = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth / 2) + (2 * ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness)            '06_03_2010  RAGAVA
    '                Dim dblLugGap As Double = dblDL_LugGap
    '                dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness * (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth - dblPinHole_Combined)
    '                strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString
    '                strQuery += ", " + dblWallThicknessLower.ToString + "," + dblWallThicknessUpper.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth.ToString + ", " + dblLugHeight.ToString + ", " + dblLugGap.ToString
    '                strQuery += "," + dblArea.ToString + "," + Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance - 0.0625).ToString + "," + dblEndofTubetoRodStop.ToString
    '                strQuery += "," + dblDistancefromPinholetoRodStop.ToString
    '                strQuery += ", " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + ", '" + strPinHoleCustomID + "', " + dblPinHole_Combined.ToString + ", " + dblPinHoleCustomUpperTolerance.ToString + ", " + dblPinHoleCustomLowerTolerance.ToString
    '                strQuery += ", '" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_BaseEnd.ToString + "', '" + _oFrmPortDetails.cmbPortSizeBaseEnd.Text.ToString + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortFirstOrientation.ToString
    '                strQuery += ", '" + strGeraseZerk + "', '" + IIf(strGreaseZerkAngle = "0", "N/A", strGreaseZerkAngle) + "', '" + IIf(strSecondGreaseZerkAngle = "0", "N/A", strSecondGreaseZerkAngle)
    '                'strQuery += "', '" + strMaterial + "', '" + strCost + "', Getdate())"
    '                strQuery += "', '" + strMaterial + "', '" + strCost + "', Getdate(),'IFL_PART')"         '01_03_2010   RAGAVA
    '            End If
    '        Catch ex As Exception
    '        End Try
    '        Try
    '            If TableName = UCase("WELDED.BEULDetails") Then
    '                Dim strSingle_DoubleRadii As String = "D"
    '                Dim strPilotHoleYesNo As String = "N"
    '                Dim strPinHole As String = "N/A"
    '                Dim dblHeightToRadiusEnd As Double
    '                Dim dblLugGap As Double
    '                Dim dblPinHoleToBottomOfULug As Double = 0 '07_04_2010 Aruna
    '                Dim dblSwingClearance As Double = 0 '07_04_2010 Aruna
    '                If partName = "Base_U_Lug_IFL" Then
    '                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode          '20_10_2010    RAGAVA
    '                    dblLugHeight = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth / 2) + (2 * ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness)
    '                    dblHeightToRadiusEnd = dblLugHeight - (2 * ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness)
    '                    dblLugDiagonal = Math.Sqrt(Math.Pow(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth, 2) + Math.Pow(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap + (2 * ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness), 2))
    '                    strDescription = "CLEVIS 2 LUG " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth.ToString + "-" + dblLugHeight.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap.ToString
    '                    strPinHoleCustomID = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
    '                    dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize))
    '                    dblLugGap = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap
    '                    dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness * (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth - dblPinHole_Combined)
    '                    '07-04_2010 Aruna
    '                    dblPinHoleToBottomOfULug = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
    '                    dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
    '                Else
    '                    'ANUP 23-09-2010 START
    '                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd = strPartCode
    '                    'ANUP 23-09-2010 TILL HERE
    '                    dblLugHeight = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd + (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd / 2) + (2 * ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd)
    '                    dblHeightToRadiusEnd = dblLugHeight - (2 * ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd)
    '                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd          '14_04_2010  RAGAVA
    '                    dblLugDiagonal = Math.Sqrt(Math.Pow(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd, 2) + Math.Pow(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap_RodEnd + (2 * ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd), 2))
    '                    strDescription = "CLEVIS 2 LUG " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd.ToString + "-" + dblLugHeight.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap_RodEnd.ToString
    '                    strPinHoleCustomID = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd
    '                    dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd))
    '                    dblLugGap = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap_RodEnd
    '                    dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd * (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd - dblPinHole_Combined)
    '                    '07-04_2010 Aruna
    '                    dblPinHoleToBottomOfULug = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd
    '                    dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd
    '                End If
    '                strMaterial = "44W"
    '                dblYieldStrength = 44000
    '                strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', '" + strSingle_DoubleRadii  ' ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter.ToString
    '                strQuery += "', '" + strPilotHoleYesNo + "','N/A'," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd.ToString + ", " + dblLugGap.ToString
    '                'strQuery += "," + dblLugDiagonal.ToString + "," + dblArea.ToString + "," + dblLugHeight.ToString + "," + dblHeightToRadiusEnd.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance.ToString '07-04_2010 Aruna
    '                strQuery += "," + dblLugDiagonal.ToString + "," + dblArea.ToString + "," + dblLugHeight.ToString + "," + dblHeightToRadiusEnd.ToString + "," + dblSwingClearance.ToString '07-04_2010 Aruna
    '                'strQuery += ",'N/A','" + strManual_Lathe + "','N/A','N/A'," + dblPinHole_Combined.ToString + ",'N/A','N/A','" + strCost.ToString + "','" + strMaterial + "'," + dblYieldStrength.ToString + ", Getdate(),'IFL_PART')"'07-04_2010 Aruna
    '                strQuery += "," + dblPinHoleToBottomOfULug.ToString + ",'" + strManual_Lathe + "','N/A','N/A'," + dblPinHole_Combined.ToString + ",'N/A','N/A','" + strCost.ToString + "','" + strMaterial + "'," + dblYieldStrength.ToString + ", Getdate(),'IFL_PART')" '07-04_2010 Aruna

    '            End If
    '        Catch ex As Exception
    '        End Try
    '        Try
    '            If TableName = UCase("WELDED.REDLCasting") Then
    '                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd = strPartCode          '20_10_2010    RAGAVA
    '                strDescription = "ROD END 2 LUG " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd.ToString
    '                'ANUP 10-10-2010 START 
    '                '  dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd + 0.36
    '                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DistanceFromPinholetoRodStop = dblDistancefromPinholetoRodStop
    '                dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop
    '                'ANUP 10-10-2010 TILL HERE
    '                strPinHoleCustomID = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd.ToString
    '                dblPinHoleCustomUpperTolerance = Val(Trim(_oFrmRodEndConfiguration.txtToleranceUpperLimit_RodEnd.Text))
    '                dblPinHoleCustomLowerTolerance = Val(Trim(_oFrmRodEndConfiguration.txtToleranceLowerLimit_RodEnd.Text))
    '                'ANUP 13-10-2010 START
    '                ' strGeraseZerk = "1/4-28 UNF-2B"
    '                strGeraseZerk = "N/A"
    '                'ANUP 13-10-2010 TILL HERE
    '                strGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1_RodEnd.ToString
    '                strSecondGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2_RodEnd.ToString
    '                strMaterial = "A148 90-60"
    '                dblYieldStrength = 79000
    '                dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd))
    '                Dim dblLugGap As Double = Val(Trim(_oFrmREDLCasting.txtLugGap_REDL.Text))
    '                dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd * (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd - dblPinHole_Combined)
    '                strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter.ToString
    '                'ANUP 16-11-2010 START
    '                'strQuery += ", " + IIf(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEndDL.ToString = "", 0, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEndDL.ToString) + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd.ToString + ", " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap_RodEnd.ToString
    '                strQuery += ", " + IIf(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEnd.ToString = "", 0, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEnd.ToString) + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd.ToString + ", " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap_RodEnd.ToString
    '                'strQuery += "," + IIf(strPilotDiameter = "", 0, strPilotDiameter.ToString) + "," + dblArea.ToString + "," + Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance - 0.0625).ToString
    '                strQuery += "," + IIf(strPilotDiameter = "", 0, strPilotDiameter.ToString) + "," + dblArea.ToString + "," + Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd - 0.0625).ToString
    '                'ANUP 16-11-2010 TILL HERE
    '                strQuery += "," + dblDistancefromPinholetoRodStop.ToString
    '                strQuery += ", " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd.ToString + ", '" + strPinHoleCustomID + "', " + dblPinHole_Combined.ToString + ", " + dblPinHoleCustomUpperTolerance.ToString + ", " + dblPinHoleCustomLowerTolerance.ToString
    '                strQuery += ", '" + strGeraseZerk + "', ' " + IIf(strGreaseZerkAngle = "0", "N/A", strGreaseZerkAngle) + "', ' " + IIf(strSecondGreaseZerkAngle = "0", "N/A", strSecondGreaseZerkAngle)
    '                strQuery += "', '" + strMaterial + "', " + dblYieldStrength.ToString + ",'" + strNotes + "', '" + strCost + "', Getdate(),'IFL_PART')"
    '            End If
    '        Catch ex As Exception
    '        End Try
    '        'Aruna:02-4-2010
    '        Try
    '            If TableName = UCase("WELDED.BEThreadedBaseNoPort") Then
    '                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode          '20_10_2010    RAGAVA
    '                strDescription = "Base Plug " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OutSidePlugDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadDiameter.ToString + " TH"
    '                Dim oSelectedBEDLDataRow As DataRow = Nothing
    '                oSelectedBEDLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWallThicknessUpperAndLowerLimits(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure)
    '                If Not IsNothing(oSelectedBEDLDataRow) Then
    '                    If Not IsDBNull(oSelectedBEDLDataRow("WALLTHICKNESSLOWERLIMIT")) Then
    '                        dblWallThicknessLower = oSelectedBEDLDataRow("WALLTHICKNESSLOWERLIMIT")
    '                    End If
    '                    If Not IsDBNull(oSelectedBEDLDataRow("WALLTHICKNESSUPPERLIMIT")) Then
    '                        dblWallThicknessUpper = oSelectedBEDLDataRow("WALLTHICKNESSUPPERLIMIT")
    '                    End If
    '                End If
    '                strMaterial = "CD 1144"
    '                dblYieldStrength = 0
    '                strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString
    '                'strQuery += ", " + IIf(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEndDL.ToString = "", 0, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEndDL.ToString) + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd.ToString + ", " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap_RodEnd.ToString
    '                strQuery += "," + dblWallThicknessLower.ToString + "," + dblWallThicknessUpper.ToString + ",'" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadDiameter.ToString + "'"
    '                strQuery += "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadLength.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop.ToString
    '                strQuery += ", " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop.ToString + ", " + Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance - 0.0625).ToString
    '                strQuery += ",'" + strMaterial + "', " + dblYieldStrength.ToString + ",'" + strCost + "', Getdate(),'IFL_PART')"
    '            End If
    '        Catch ex As Exception
    '        End Try

    '        '02_04_2010 Aruna

    '        Try
    '            If TableName = UCase("WELDED.BEThreadedEndFlushPort") Then
    '                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode          '20_10_2010    RAGAVA
    '                strDescription = "Base Plug " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OutSidePlugDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadDiameter.ToString + " TH"
    '                Dim oSelectedBEDLDataRow As DataRow = Nothing
    '                oSelectedBEDLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWallThicknessUpperAndLowerLimits(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure)
    '                If Not IsNothing(oSelectedBEDLDataRow) Then
    '                    If Not IsDBNull(oSelectedBEDLDataRow("WALLTHICKNESSLOWERLIMIT")) Then
    '                        dblWallThicknessLower = oSelectedBEDLDataRow("WALLTHICKNESSLOWERLIMIT")
    '                    End If
    '                    If Not IsDBNull(oSelectedBEDLDataRow("WALLTHICKNESSUPPERLIMIT")) Then
    '                        dblWallThicknessUpper = oSelectedBEDLDataRow("WALLTHICKNESSUPPERLIMIT")
    '                    End If
    '                End If
    '                strMaterial = "CD 1144"
    '                dblYieldStrength = 0
    '                strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString
    '                'strQuery += ", " + IIf(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEndDL.ToString = "", 0, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEndDL.ToString) + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd.ToString + ", " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap_RodEnd.ToString
    '                strQuery += "," + dblWallThicknessLower.ToString + "," + dblWallThicknessUpper.ToString + ",'" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadDiameter.ToString + "'"
    '                strQuery += "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadLength.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop.ToString
    '                strQuery += ", " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop.ToString + ", " + Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance - 0.0625).ToString
    '                strQuery += ", '" + strMaterial + "', " + dblYieldStrength.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortQuantity.ToString
    '                strQuery += ",'" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_BaseEnd.ToString + "', '" + _oFrmPortDetails.cmbPortSizeBaseEnd.Text.ToString + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSecondOrientation.ToString
    '                strQuery += ",'" + strNotes + "','" + strCost + "', Getdate(),'IFL_PART')"
    '            End If
    '        Catch ex As Exception
    '        End Try

    '        '27_04_2010   RAGAVA       NEW DESIGN
    '        Try
    '            If TableName = UCase("BEThreadedEndRaisedPort") Then
    '                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode          '20_10_2010    RAGAVA
    '                strDescription = "BaseThreaded " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OutSidePlugDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadDiameter.ToString + " TH"
    '                Dim oSelectedBEDLDataRow As DataRow = Nothing
    '                oSelectedBEDLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWallThicknessUpperAndLowerLimits(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure)
    '                If Not IsNothing(oSelectedBEDLDataRow) Then
    '                    If Not IsDBNull(oSelectedBEDLDataRow("WALLTHICKNESSLOWERLIMIT")) Then
    '                        dblWallThicknessLower = oSelectedBEDLDataRow("WALLTHICKNESSLOWERLIMIT")
    '                    End If
    '                    If Not IsDBNull(oSelectedBEDLDataRow("WALLTHICKNESSUPPERLIMIT")) Then
    '                        dblWallThicknessUpper = oSelectedBEDLDataRow("WALLTHICKNESSUPPERLIMIT")
    '                    End If
    '                End If
    '                strMaterial = "CD 1144"
    '                dblYieldStrength = 0
    '                strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString
    '                'strQuery += ", " + IIf(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEndDL.ToString = "", 0, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEndDL.ToString) + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd.ToString + ", " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap_RodEnd.ToString
    '                strQuery += "," + dblWallThicknessLower.ToString + "," + dblWallThicknessUpper.ToString + ",'" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadDiameter.ToString + "'"
    '                strQuery += "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadLength.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop.ToString
    '                strQuery += ", " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop.ToString + ", " + Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance - 0.0625).ToString
    '                strQuery += ", '" + strMaterial + "', " + dblYieldStrength.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortQuantity.ToString
    '                strQuery += ",'" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_BaseEnd.ToString + "', '" + _oFrmPortDetails.cmbPortSizeBaseEnd.Text.ToString + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSecondOrientation.ToString
    '                strQuery += ",'" + strNotes + "','" + strCost + "', Getdate(),'IFL_PART')"
    '            End If
    '        Catch ex As Exception
    '        End Try
    '        'Till    Here

    '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.InsertNewDetails(strQuery)
    '    Catch ex As Exception
    '        ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in storeData of clsWeldedCylinderFunctionalClass " + ex.Message)
    '    End Try
    'End Sub

    '24_02_2010 Aruna Modified
    Public Sub storeData(ByVal TableName As String, ByVal partName As String, Optional ByVal specialCondition As String = "", Optional ByVal blnFromCasting As Boolean = False)        '15_05_2012   RAGAVA
        Try
            Dim dblLugThickness As Double = 0   '15_05_2012   RAGAVA
            Dim dblSwingClearance As Double = 0   '15_05_2012   RAGAVA
            Dim dblLugGap As Double = 0   '15_05_2012   RAGAVA
            'Dim dblLugThickness As Double = 0   '15_05_2012   RAGAVA
            'Dim dblLugThickness As Double = 0   '15_05_2012   RAGAVA
            'Dim dblLugThickness As Double = 0   '15_05_2012   RAGAVA

            ' ObjClsWeldedCylinderFunctionalClass.ObjFrmPistonDesign.ExecuteQuery_PistonDesign() 'ANUP 30-06-2010
            'ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign.ExecuteQuery_HeadDesign() 'ANUP 27-10-2010

            Dim objDT As New DataTable
            Dim strQuery As String = ""
            Dim strIFLID As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetMaxIFLID(TableName)

            If Not IsNothing(strIFLID) Then
                strIFLID = Val(strIFLID) + 1
            Else
                strIFLID = 1001
            End If
            Dim strPartCode As String = ""
            Dim strDescription As String = ""
            Dim dblWallThicknessLower As Double = 0
            Dim dblWallThicknessUpper As Double = 0
            Dim dblLugHeight As Double = 0
            Dim dblArea As Double = 0
            Dim dblEndofTubetoRodStop As Double = 0
            Dim dblDistancefromPinholetoRodStop As Double = 0
            Dim strPinHoleType As String = ""
            Dim strPinHoleCustomID As String = ""
            Dim dblPinHole_Combined As Double = 0
            Dim dblPinHoleCustomUpperTolerance As Double = 0
            Dim dblPinHoleCustomLowerTolerance As Double = 9
            Dim dblBushingHousingDimensionsID As Double = 0
            Dim dblBushingHousingDimensionsUpperTolerance As Double = 0
            Dim dblBushingHousingDimensionsLowerTolerance As Double = 0
            Dim dblDepth As Double = 0
            Dim dblRawID As Double = 0
            Dim strGeraseZerk As String = ""
            Dim strGreaseZerkAngle As String = ""
            Dim strSecondGreaseZerkAngle As String = ""
            Dim strMaterial As String = ""
            Dim strNotes As String = ""
            Dim strCost As String = ""
            Dim dblYieldStrength As Double = 0
            Dim strBearingHouse As String = ""
            Dim strWeldSize As String = ""
            Dim strPilotDiameter As String = "0.25"
            Dim dblHeight As Double = 0
            Dim dblLugDiagonal As Double = 0
            Dim dblRadius As Double = 0
            Dim dblSlotHeight As Double = 0
            Dim dblSlotWidth As Double = 0
            Dim dblCrossTubeOD As Double = 0
            Dim dblCrossTubeWidth As Double = 0
            Dim dbloffSet As Double = 0
            Dim strPortFacingAtBaseEnd As String = ""
            Dim slotHeight As Double = 0
            Dim slotWidth As Double = 0
            Dim strMaterialCode As String = ""
            Dim strPurchaseManufacturer As String = ""
            Dim dblLugWidth As Double
            Dim dblPinholeSize As Double
            strPartCode = ObjClsWeldedDataClass.GetPurchaseAndManufactureCode(partName)
            Try
                UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.htStoreConfigurationCodeNumbers, partName, strPartCode)
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.ContainsKey(partName) = False Then     '14_07_2010   RAGAVA
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.Add(partName, strPartCode)            '14_07_2010   RAGAVA
                End If
            Catch ex As Exception
            End Try
            TableName = UCase(TableName)



            '18_03_2010   RAGAVA  
            If UCase(TableName) = UCase("WELDED.BEBasePlugCastWithOutPort") Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode
                Dim dblPlugOverAllLength As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OutSidePlugDiameter
                strDescription = "BASE PLUG " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeOD.ToString + "-" + dblPlugOverAllLength.ToString
                dblEndofTubetoRodStop = -0.125
                'dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + 0.5
                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = dblDistancefromPinholetoRodStop
                strPinHoleType = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType)     '01_06_2010    RAGAVA
                strPinHoleCustomID = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
                dblPinHoleCustomUpperTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceUpperLimit.Text))
                dblPinHoleCustomLowerTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceLowerLimit.Text))
                strGeraseZerk = "1/4-28 UNF-2B"
                strGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1.ToString
                strSecondGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2.ToString
                '05_08_2011  RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs = 0 Then
                    strGreaseZerkAngle = "N/A"
                    strSecondGreaseZerkAngle = "N/A"
                End If
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs = 1 Then
                    strSecondGreaseZerkAngle = "N/A"
                End If
                'Till  Here

                strMaterial = "ASTM A216 70-36 GRADE WCB"
                dblYieldStrength = 30000
                dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize))
                Dim oSelectedRESLDataRow As DataRow = Nothing
                oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWallThicknessUpperAndLowerLimits(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure)
                If Not IsNothing(oSelectedRESLDataRow) Then
                    If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")) Then
                        dblWallThicknessLower = oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")
                    End If
                    If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")) Then
                        dblWallThicknessUpper = oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")
                    End If
                End If
                '  dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness * (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth - dblPinHole_Combined)
                dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired
                strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString
                strQuery += ", " + dblWallThicknessLower.ToString + "," + dblWallThicknessUpper.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OutSidePlugDiameter.ToString + "," + dblPlugOverAllLength.ToString + ", " + dblEndofTubetoRodStop.ToString
                strQuery += "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance.ToString + ",'" + IIf(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlatWidth.ToString = "0", "N/A", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlatWidth.ToString) 'anup 02-02-2011 dont subtract Swing Clearance with - 0.0625
                strQuery += "','" + IIf(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlatHeight.ToString = "0", "N/A", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlatHeight.ToString) + "', " + dblArea.ToString
                strQuery += ", '" + strPinHoleType.ToString + "'," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + ", " + strPinHoleCustomID + ", " + dblPinHoleCustomUpperTolerance.ToString + ", " + dblPinHoleCustomLowerTolerance.ToString + ", " + dblBushingHousingDimensionsID.ToString + ", " + dblBushingHousingDimensionsUpperTolerance.ToString
                strQuery += ", " + dblBushingHousingDimensionsLowerTolerance.ToString + ", " + dblDepth.ToString + ", " + dblRawID.ToString + ", '" + strGeraseZerk + "', '" + strGreaseZerkAngle + "', '" + strSecondGreaseZerkAngle
                strQuery += "', " + dblYieldStrength.ToString + ", '" + strCost + "', Getdate() ,'IFL_PART',0)" 'anup 21-12-2010
            End If
            If UCase(TableName) = UCase("WELDED.BasePlugFlushedPort") Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode
                Dim dblPlugOverAllLength As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OutSidePlugDiameter
                strDescription = "BASE PLUG " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeOD.ToString + "-" + dblPlugOverAllLength.ToString
                dblEndofTubetoRodStop = -0.125
                'dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + 0.5
                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = dblDistancefromPinholetoRodStop
                strPinHoleType = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType)     '01_06_2010    RAGAVA
                strPinHoleCustomID = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
                dblPinHoleCustomUpperTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceUpperLimit.Text))
                dblPinHoleCustomLowerTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceLowerLimit.Text))
                strGeraseZerk = "1/4-28 UNF-2B"
                strGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1.ToString
                strSecondGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2.ToString
                '05_08_2011  RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs = 0 Then
                    strGreaseZerkAngle = "N/A"
                    strSecondGreaseZerkAngle = "N/A"
                End If
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs = 1 Then
                    strSecondGreaseZerkAngle = "N/A"
                End If
                'Till  Here

                dblYieldStrength = 30000
                strMaterial = "1020"
                dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize))
                Dim oSelectedRESLDataRow As DataRow = Nothing
                oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWallThicknessUpperAndLowerLimits(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure)
                If Not IsNothing(oSelectedRESLDataRow) Then
                    If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")) Then
                        dblWallThicknessLower = oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")
                    End If
                    If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")) Then
                        dblWallThicknessUpper = oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")
                    End If
                End If
                '  dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness * (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth - dblPinHole_Combined)
                dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired
                strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString
                strQuery += ", " + dblWallThicknessLower.ToString + "," + dblWallThicknessUpper.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OutSidePlugDiameter.ToString + "," + dblPlugOverAllLength.ToString + ", " + dblEndofTubetoRodStop.ToString
                strQuery += "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop.ToString + ",'N/A','N/A'," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance.ToString + ",'" + IIf(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlatHeight.ToString = "0", "N/A", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlatWidth.ToString) 'anup 02-02-2011 dont subtract Swing Clearance with - 0.0625
                strQuery += "','" + IIf(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlatHeight.ToString = "0", "N/A", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlatHeight.ToString) + "', '" + dblArea.ToString
                strQuery += "', '" + strPinHoleType.ToString + "'," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + ", '" + strPinHoleCustomID.ToString + "', " + dblPinHole_Combined.ToString + ", " + dblPinHoleCustomUpperTolerance.ToString + ", " + dblPinHoleCustomLowerTolerance.ToString + ", " + dblBushingHousingDimensionsID.ToString + ", " + dblBushingHousingDimensionsUpperTolerance.ToString
                strQuery += ", " + dblBushingHousingDimensionsLowerTolerance.ToString + ", " + dblDepth.ToString + ", " + dblRawID.ToString + ", " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortQuantity.ToString + ",'" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_BaseEnd.ToString + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_BaseEnd.ToString + ", " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortFirstOrientation.ToString + ", " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSecondOrientation.ToString + ", '" + strGeraseZerk + "', ' " + strGreaseZerkAngle + "', ' " + strSecondGreaseZerkAngle
                strQuery += "', '" + strMaterial + "', " + dblYieldStrength.ToString + ", '" + strNotes + "','" + strCost + "', Getdate() ,'IFL_PART',0)" 'anup 21-12-2010
            End If
            '18_03_2010   RAGAVA   TILL   HERE

            '27_04_2010   RAGAVA  NEW DESIGN
            Try
                If TableName = UCase("BEDLCastWithRaisedPort") Or TableName = UCase("BEDLCastWithRaisedPort90") Then       '19_05_2010   RAGAVA   NEW  DESIGN

                    dblEndofTubetoRodStop = -0.125
                    '22_04_2010    ragava
                    
                    'Till   here

                    '30_05_2012   RAGAVA
                    If (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" AndAlso blnFromCasting = True) _
                                       OrElse (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" AndAlso blnFromCasting = False) Then         '30_05_2012   RAGAVA
                        dblLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                        dblLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth
                        dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode
                        If Not ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port Integral" Then
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = -0.125
                        End If
                        dblEndofTubetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop
                        dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop    '25_06_2012   RAGAVA
                        dblLugGap = dblDL_LugGap     '12_06_2012    RAGAVA
                    Else
                        dblLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2
                        dblLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth2
                        dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance2
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd2 = strPartCode
                        If Not ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port Integral" Then
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop2 = -0.125
                        End If
                        dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop2    '25_06_2012   RAGAVA
                        dblEndofTubetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop2
                        dblLugGap = dblDL_LugGap2     '12_06_2012    RAGAVA
                    End If

                    ''15_05_2012   RAGAVA
                    'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then 'blnFromCasting = True AndAlso 
                    '    dblLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                    '    dblLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth
                    '    dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
                    '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode
                    'Else
                    '    dblLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2
                    '    dblLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth2
                    '    dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance2
                    '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd2 = strPartCode
                    'End If
                    'Till   Here

                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode        '12_08_2010   RAGAVA
                    strDescription = "END CAP 2 LUG " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + "-" + dblLugThickness.ToString
                    

                    'dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + 0.5
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DistanceFromPinholetoRodStop = dblDistancefromPinholetoRodStop
                    strPinHoleCustomID = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
                    dblPinHoleCustomUpperTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceUpperLimit.Text))
                    dblPinHoleCustomLowerTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceLowerLimit.Text))
                    'ANUP 13-10-2010 START
                    ' strGeraseZerk = "1/4-28 UNF-2B"
                    strGeraseZerk = "N/A"
                    'ANUP 13-10-2010 TILL HERE
                    strGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1.ToString
                    strSecondGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2.ToString
                    '05_08_2011  RAGAVA
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs = 0 Then
                        strGreaseZerkAngle = "N/A"
                        strSecondGreaseZerkAngle = "N/A"
                    End If
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs = 1 Then
                        strSecondGreaseZerkAngle = "N/A"
                    End If
                    'Till  Here

                    strMaterial = "ASTM A216 70-36 GRADE WCB"
                    dblYieldStrength = 36000
                    dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize))
                    Dim oSelectedBEDLDataRow As DataRow = Nothing
                    oSelectedBEDLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWallThicknessUpperAndLowerLimits(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure)
                    If Not IsNothing(oSelectedBEDLDataRow) Then
                        If Not IsDBNull(oSelectedBEDLDataRow("WALLTHICKNESSLOWERLIMIT")) Then
                            dblWallThicknessLower = oSelectedBEDLDataRow("WALLTHICKNESSLOWERLIMIT")
                        End If
                        If Not IsDBNull(oSelectedBEDLDataRow("WALLTHICKNESSUPPERLIMIT")) Then
                            dblWallThicknessUpper = oSelectedBEDLDataRow("WALLTHICKNESSUPPERLIMIT")
                        End If
                    End If

                    '15_05_2012   RAGAVA
                    dblLugHeight = dblSwingClearance + (dblLugWidth / 2) + (2 * dblLugThickness)            '06_03_2010  RAGAVA
                    'Dim dblLugGap As Double = dblDL_LugGap    '12_06_2012   RAGAVA
                    dblArea = dblLugThickness * (dblLugWidth - dblPinHole_Combined)
                    strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString
                    strQuery += ", " + dblWallThicknessLower.ToString + "," + dblWallThicknessUpper.ToString + "," + dblLugThickness.ToString + "," + dblLugWidth.ToString + ", " + dblLugHeight.ToString + ", " + dblLugGap.ToString
                    'strQuery += "," + dblArea.ToString + "," + Val(dblSwingClearance - 0.0625).ToString + "," + dblEndofTubetoRodStop.ToString
                    strQuery += "," + dblArea.ToString + "," + Val(dblSwingClearance).ToString + "," + dblEndofTubetoRodStop.ToString
                    strQuery += "," + dblDistancefromPinholetoRodStop.ToString
                    strQuery += ", " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + ", '" + strPinHoleCustomID + "', " + dblPinHole_Combined.ToString + ", " + dblPinHoleCustomUpperTolerance.ToString + ", " + dblPinHoleCustomLowerTolerance.ToString
                    strQuery += ", '" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_BaseEnd.ToString + "', '" + _oFrmPortDetails.cmbPortSizeBaseEnd.Text.ToString + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortFirstOrientation.ToString
                    strQuery += ", '" + strGeraseZerk + "', '" + strGreaseZerkAngle + "', '" + strSecondGreaseZerkAngle
                    strQuery += "', '" + strMaterial + "', '" + strCost + "', Getdate(),'IFL_PART',0)"  'anup21-12-2010

                End If
            Catch ex As Exception
            End Try
            'Till   Here

            '27_04_2010   RAGAVA
            If UCase(TableName) = UCase("BasePlugRaisedPort") Or UCase(TableName) = UCase("BasePlugRaisedPort90") Then          '19_05_2010   RAGAVA
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode
                Dim dblPlugOverAllLength As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OutSidePlugDiameter
                strDescription = "BASE PLUG " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeOD.ToString + "-" + dblPlugOverAllLength.ToString
                If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
                    dblEndofTubetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop
                Else
                    dblEndofTubetoRodStop = -0.125
                End If
                strPinHoleType = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType)     '01_06_2010    RAGAVA
                strPinHoleCustomID = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
                dblPinHoleCustomUpperTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceUpperLimit.Text))
                dblPinHoleCustomLowerTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceLowerLimit.Text))
                strGeraseZerk = "1/4-28 UNF-2B"
                strGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1.ToString
                strSecondGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2.ToString
                '05_08_2011  RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs = 0 Then
                    strGreaseZerkAngle = "N/A"
                    strSecondGreaseZerkAngle = "N/A"
                End If
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs = 1 Then
                    strSecondGreaseZerkAngle = "N/A"
                End If
                'Till  Here

                dblYieldStrength = 30000
                strMaterial = "1020"
                dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize))
                Dim oSelectedRESLDataRow As DataRow = Nothing
                oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWallThicknessUpperAndLowerLimits(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure)
                If Not IsNothing(oSelectedRESLDataRow) Then
                    If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")) Then
                        dblWallThicknessLower = oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")
                    End If
                    If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")) Then
                        dblWallThicknessUpper = oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")
                    End If
                End If
                dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired
                strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString
                strQuery += ", " + dblWallThicknessLower.ToString + "," + dblWallThicknessUpper.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OutSidePlugDiameter.ToString + "," + dblPlugOverAllLength.ToString + ", " + dblEndofTubetoRodStop.ToString
                strQuery += "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop.ToString + ",'N/A','N/A'," + Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance).ToString + ",'" + IIf(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlatHeight.ToString = "0", "N/A", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlatWidth.ToString)
                strQuery += "','" + IIf(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlatHeight.ToString = "0", "N/A", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlatHeight.ToString) + "', '" + dblArea.ToString
                strQuery += "', '" + strPinHoleType.ToString + "'," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + ", '" + strPinHoleCustomID.ToString + "', " + dblPinHole_Combined.ToString + ", " + dblPinHoleCustomUpperTolerance.ToString + ", " + dblPinHoleCustomLowerTolerance.ToString + ", " + dblBushingHousingDimensionsID.ToString + ", " + dblBushingHousingDimensionsUpperTolerance.ToString
                strQuery += ", " + dblBushingHousingDimensionsLowerTolerance.ToString + ", " + dblDepth.ToString + ", " + dblRawID.ToString + ", " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortQuantity.ToString + ",'" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_BaseEnd.ToString + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_BaseEnd.ToString + ", " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortFirstOrientation.ToString + ", " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSecondOrientation.ToString + ", '" + strGeraseZerk + "', ' " + strGreaseZerkAngle + "', ' " + strSecondGreaseZerkAngle
                strQuery += "', '" + strMaterial + "', " + dblYieldStrength.ToString + ", '" + strNotes + "','" + strCost + "', Getdate() ,'IFL_PART',0)"  'anup 21-12-2010 
            End If

            If UCase(TableName) = "BESLCASTINGRAISEDPORT" Or UCase(TableName) = "BESLCASTINGRAISEDPORT90" Then       '19_05_2010   RAGAVA   NEW  DESIGN
                ' ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode





                '25_06_2012   RAGAVA
                'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then 'blnFromCasting = True AndAlso 
                If (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" AndAlso blnFromCasting = True) _
                                  OrElse (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" AndAlso blnFromCasting = False) Then
                    dblLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                    dblLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth
                    dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode
                    dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop    '25_06_2012   RAGAVA
                    dblEndofTubetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop   '25_06_2012   RAGAVA
                Else
                    dblLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2
                    dblLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth2
                    dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance2
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd2 = strPartCode
                    dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop2    '25_06_2012   RAGAVA
                    dblEndofTubetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop2   '25_06_2012   RAGAVA
                End If


                Dim oSelectedRESLDataRow As DataRow = Nothing
                oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPortBossDiaAndBaseDia(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter)
                strDescription = "END CAP 1 LUG" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + "-" + dblLugThickness.ToString
                strPinHoleType = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType)     '01_06_2010    RAGAVA
                strPinHoleCustomID = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
                dblPinHoleCustomUpperTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceUpperLimit.Text))
                dblPinHoleCustomLowerTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceLowerLimit.Text))
                strGeraseZerk = "1/4-28 UNF-2B"
                strGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1.ToString
                strSecondGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2.ToString
                '05_08_2011  RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs = 0 Then
                    strGreaseZerkAngle = "N/A"
                    strSecondGreaseZerkAngle = "N/A"
                End If
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs = 1 Then
                    strSecondGreaseZerkAngle = "N/A"
                End If
                'Till  Here

                strMaterial = "ASTM A216 70-36 GRADE WCB"
                dblYieldStrength = 36000
                dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize))
                oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWallThicknessUpperAndLowerLimits(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure)
                If Not IsNothing(oSelectedRESLDataRow) Then
                    If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")) Then
                        dblWallThicknessLower = oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")
                    End If
                    If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")) Then
                        dblWallThicknessUpper = oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")
                    End If
                End If
                strBearingHouse = "N/A"
                dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired
                '15_05_2012   RAGAVA
                strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString
                strQuery += ", " + dblWallThicknessUpper.ToString + "," + dblWallThicknessLower.ToString + "," + dblLugThickness.ToString + "," + dblLugWidth.ToString + ", " + dblLugHeight.ToString
                strQuery += "," + dblArea.ToString + "," + Val(dblSwingClearance).ToString + "," + dblEndofTubetoRodStop.ToString
                strQuery += "," + dblDistancefromPinholetoRodStop.ToString + ", '" + strPinHoleType.ToString
                strQuery += "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + ", '" + strPinHoleCustomID + "', " + dblPinHole_Combined.ToString + ", " + dblPinHoleCustomUpperTolerance.ToString + ", " + dblPinHoleCustomLowerTolerance.ToString + ", " + dblBushingHousingDimensionsID.ToString + ", " + dblBushingHousingDimensionsUpperTolerance.ToString
                strQuery += ", " + dblBushingHousingDimensionsLowerTolerance.ToString + ", " + dblDepth.ToString + ", " + dblRawID.ToString + ", '" + strBearingHouse + "','" + strGeraseZerk + "', ' " + strGreaseZerkAngle + "', ' " + strSecondGreaseZerkAngle
                strQuery += "', '" + strMaterial + "', '" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortQuantity.ToString + "', '" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_BaseEnd.ToString + "','"
                strQuery += IIf(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_BaseEnd Is Nothing, "0", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_BaseEnd) + "','" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortFirstOrientation.ToString + "','" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSecondOrientation.ToString + "','" + strNotes + "', '" + strCost + "',  Getdate() ,'IFL_PART'" + ",0)" 'anup21-12-2010 


            End If

            'MANJULA ADDED
            If UCase(TableName) = "BEBHCastingRaisedPort" Or UCase(TableName) = "BEBHCastingRaisedPort90" Then       '19_05_2010   RAGAVA   NEW  DESIGN

                '25_06_2012   RAGAVA
                'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then 'blnFromCasting = True AndAlso 
                If (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" AndAlso blnFromCasting = True) _
                                  OrElse (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" AndAlso blnFromCasting = False) Then
                    dblLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                    dblLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth
                    dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode
                    dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop    '25_06_2012   RAGAVA
                    dblEndofTubetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop   '25_06_2012   RAGAVA
                Else
                    dblLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2
                    dblLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth2
                    dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance2
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd2 = strPartCode
                    dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop2    '25_06_2012   RAGAVA
                    dblEndofTubetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop2   '25_06_2012   RAGAVA
                End If
                'Till  Here

                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode
                Dim oSelectedRESLDataRow As DataRow = Nothing
                oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPortBossDiaAndBaseDia(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter)
                strDescription = "END CAP 1 LUG" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + "-" + dblLugThickness.ToString
                strPinHoleType = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType)     '01_06_2010    RAGAVA
                strPinHoleCustomID = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
                dblPinHoleCustomUpperTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceUpperLimit.Text))
                dblPinHoleCustomLowerTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceLowerLimit.Text))
                strGeraseZerk = "1/4-28 UNF-2B"
                strGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1.ToString
                strSecondGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2.ToString
                '05_08_2011  RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs = 0 Then
                    strGreaseZerkAngle = "N/A"
                    strSecondGreaseZerkAngle = "N/A"
                End If
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs = 1 Then
                    strSecondGreaseZerkAngle = "N/A"
                End If
                'Till  Here

                strMaterial = "ASTM A216 70-36 GRADE WCB"
                dblYieldStrength = 36000
                dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize))
                oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWallThicknessUpperAndLowerLimits(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure)
                If Not IsNothing(oSelectedRESLDataRow) Then
                    If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")) Then
                        dblWallThicknessLower = oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")
                    End If
                    If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")) Then
                        dblWallThicknessUpper = oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")
                    End If
                End If
                strBearingHouse = "N/A"

                '15_05_2012   RAGAVA  
                dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired
                strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString
                strQuery += ", " + dblWallThicknessUpper.ToString + "," + dblWallThicknessLower.ToString + "," + dblLugThickness.ToString + "," + dblLugWidth.ToString + ", " + dblLugHeight.ToString
                strQuery += "," + dblArea.ToString + "," + Val(dblSwingClearance).ToString + "," + dblEndofTubetoRodStop.ToString
                strQuery += "," + dblDistancefromPinholetoRodStop.ToString + ", '" + strPinHoleType.ToString
                strQuery += "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + ", '" + strPinHoleCustomID + "', " + dblPinHole_Combined.ToString + ", " + dblPinHoleCustomUpperTolerance.ToString + ", " + dblPinHoleCustomLowerTolerance.ToString + ", " + dblBushingHousingDimensionsID.ToString + ", " + dblBushingHousingDimensionsUpperTolerance.ToString
                strQuery += ", " + dblBushingHousingDimensionsLowerTolerance.ToString + ", " + dblDepth.ToString + ", " + dblRawID.ToString + ", '" + strBearingHouse + "','" + strGeraseZerk + "', ' " + strGreaseZerkAngle + "', ' " + strSecondGreaseZerkAngle
                strQuery += "', '" + strMaterial + "', '" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortQuantity.ToString + "', '" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_BaseEnd.ToString + "','"
                strQuery += IIf(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_BaseEnd Is Nothing, "0", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_BaseEnd) + "','" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortFirstOrientation.ToString + "','" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSecondOrientation.ToString + "','" + strNotes + "', '" + strCost + "',  Getdate() ,'IFL_PART'" + ",0)" 'anup21-12-2010 
            End If
            If UCase(TableName) = UCase("BECrossTubeRaisedPort") Or UCase(TableName) = UCase("BECrossTubeRaisedPort90") Then         '19_05_2010    RAGAVA    NEW DESIGN

                '25_06_2012   RAGAVA
                'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then 'blnFromCasting = True AndAlso 
                If (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" AndAlso blnFromCasting = True) _
                                    OrElse (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" AndAlso blnFromCasting = False) Then
                    dblLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                    dblLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth
                    dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode
                    dblCrossTubeOD = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD
                    dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth
                    dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop    '25_06_2012   RAGAVA
                    dblEndofTubetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop   '25_06_2012   RAGAVA
                Else
                    dblLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2
                    dblLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth2
                    dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance2
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd2 = strPartCode
                    dblCrossTubeOD = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD2
                    dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth2
                    dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop2    '25_06_2012   RAGAVA
                    dblEndofTubetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop2   '25_06_2012   RAGAVA
                End If
                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode
                'Till  Here
                Dim oSelectedRESLDataRow As DataRow = Nothing
                strDescription = "END CAP X TUBE" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + "-" + dblCrossTubeWidth.ToString   '15_05_2012  RAGAVA
                dbloffSet = ObjClsWeldedGlobalVariables.OffSet

                'ANUP 10-10-2010 START 
                'dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + 0.5
                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DistanceFromPinholetoRodStop = dblDistancefromPinholetoRodStop
                'dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop
                'ANUP 10-10-2010 TILL HERE

                strPinHoleType = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType)     '01_06_2010    RAGAVA
                strPinHoleCustomID = Trim(_oFrmTubeDetails.txtPinHoleSize.Text)
                dblPinHoleCustomUpperTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceUpperLimit.Text))
                dblPinHoleCustomLowerTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceLowerLimit.Text))
                strGeraseZerk = "1/4-28 UNF-2B"
                strGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1.ToString
                strSecondGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2.ToString
                '05_08_2011  RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs = 0 Then
                    strGreaseZerkAngle = "N/A"
                    strSecondGreaseZerkAngle = "N/A"
                End If
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs = 1 Then
                    strSecondGreaseZerkAngle = "N/A"
                End If
                'Till  Here

                strMaterial = "ASTM A216 70-36 GRADE WCB"
                dblYieldStrength = 36000
                dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize))
                oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWallThicknessUpperAndLowerLimits(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure)
                If Not IsNothing(oSelectedRESLDataRow) Then
                    If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")) Then
                        dblWallThicknessLower = oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")
                    End If
                    If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")) Then
                        dblWallThicknessUpper = oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")
                    End If
                End If
                strBearingHouse = "N/A"

                If dblCrossTubeOD < Val(Trim(_oFrmCTDesignACasting.txtPinHoleSize_DesignCrossTubeCasting.Text)) + 0.5 Then   '15_05_2012  RAGAVA
                    UpdateHashTableValues(_htNewDesignPartParams, "CROSS TUBE OD", Val(Trim(_oFrmCTDesignACasting.txtPinHoleSize_DesignCrossTubeCasting.Text)) + 0.5)
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD = Val(Trim(_oFrmCTDesignACasting.txtPinHoleSize_DesignCrossTubeCasting.Text)) + 0.5
                End If
                '15_05_2012   RAGAVA
                'dblCrossTubeOD = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD
                'dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth
                'Till   Here
                strPortFacingAtBaseEnd = ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortFacingBaseEnd.Text
                '  dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness * (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth - dblPinHole_Combined)
                dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired
                '15_05_2012  RAGAVA
                strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString
                strQuery += ", " + dblWallThicknessUpper.ToString + "," + dblWallThicknessLower.ToString + "," + dblCrossTubeOD.ToString + "," + dblCrossTubeWidth.ToString + "," + dblArea.ToString
                'strQuery += "," + Val(dblSwingClearance - 0.0625).ToString + "," + dblEndofTubetoRodStop.ToString + "," + dbloffSet.ToString
                strQuery += "," + Val(dblSwingClearance).ToString + "," + dblEndofTubetoRodStop.ToString + "," + dbloffSet.ToString
                strQuery += "," + dblDistancefromPinholetoRodStop.ToString + ", '" + strPinHoleType.ToString
                strQuery += "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + ", '" + strPinHoleCustomID + "', " + dblPinHole_Combined.ToString + ", " + dblPinHoleCustomUpperTolerance.ToString + ", " + dblPinHoleCustomLowerTolerance.ToString + ", " + dblBushingHousingDimensionsID.ToString + ", " + dblBushingHousingDimensionsUpperTolerance.ToString
                strQuery += ", " + dblBushingHousingDimensionsLowerTolerance.ToString + ", " + dblDepth.ToString + ", " + dblRawID.ToString + ", '" + strGeraseZerk + "', ' " + strGreaseZerkAngle + "', ' " + strSecondGreaseZerkAngle
                strQuery += "', '" + strMaterial + "', " + dblYieldStrength.ToString + ",'" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortQuantity.ToString + "', '" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_BaseEnd.ToString + "','"
                strQuery += IIf(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_BaseEnd Is Nothing, "0", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_BaseEnd) + "','" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortFirstOrientation.ToString + "','" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSecondOrientation.ToString + "','" + strPortFacingAtBaseEnd + "','" + strNotes + "', '" + strCost + "',  Getdate() ,'IFL_PART','" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ISBushingStyle_2BushingsIndividualBore + "',0)"     'ANUP 20-09-2010 START  'anup 21-12-2010

            End If
            'Till   Here
            'MANJULA ADDED
            '************ BH ***************

            If UCase(TableName) = UCase("WELDED.Base_End_BH_No_Port") Then

                '25_06_2012   RAGAVA
                'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then 'blnFromCasting = True AndAlso 
                If (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" AndAlso blnFromCasting = True) _
                                    OrElse (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" AndAlso blnFromCasting = False) Then
                    dblLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                    dblLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth
                    dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode
                    dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop    '25_06_2012   RAGAVA
                    dblEndofTubetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop   '25_06_2012   RAGAVA
                Else
                    dblLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2
                    dblLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth2
                    dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance2
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd2 = strPartCode
                    dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop2    '25_06_2012   RAGAVA
                    dblEndofTubetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop2   '25_06_2012   RAGAVA
                End If
                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode
                'Till  Here
                strDescription = "END CAP 1 LUG" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + "-" + dblLugThickness.ToString        '15_05_2012  RAGAVA
                strPinHoleType = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType)     '01_06_2010    RAGAVA
                strPinHoleCustomID = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
                dblPinHoleCustomUpperTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceUpperLimit.Text))
                dblPinHoleCustomLowerTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceLowerLimit.Text))
                strGeraseZerk = "1/4-28 UNF-2B"
                strGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1.ToString
                strSecondGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2.ToString
                '05_08_2011  RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs = 0 Then
                    strGreaseZerkAngle = "N/A"
                    strSecondGreaseZerkAngle = "N/A"
                End If
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs = 1 Then
                    strSecondGreaseZerkAngle = "N/A"
                End If
                'Till  Here

                strMaterial = "ASTM A216 70-36 GRADE WCB"
                dblYieldStrength = 36000
                dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize))
                Dim oSelectedRESLDataRow As DataRow = Nothing
                oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWallThicknessUpperAndLowerLimits(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure)
                If Not IsNothing(oSelectedRESLDataRow) Then
                    If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")) Then
                        dblWallThicknessLower = oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")
                    End If
                    If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")) Then
                        dblWallThicknessUpper = oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")
                    End If
                End If
                dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired

                '15_05_2012   RAGAVA
                strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "','" + strPartCode + "','" + strDescription + "'," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString
                strQuery += "," + dblWallThicknessUpper.ToString + "," + dblWallThicknessLower.ToString + "," + dblLugThickness.ToString + "," + dblLugWidth.ToString
                'strQuery += "," + dblArea.ToString + "," + Val(dblSwingClearance - 0.0625).ToString + "," + dblEndofTubetoRodStop.ToString
                strQuery += "," + dblArea.ToString + "," + Val(dblSwingClearance).ToString + "," + dblEndofTubetoRodStop.ToString
                strQuery += "," + dblDistancefromPinholetoRodStop.ToString + ",'" + strPinHoleType.ToString + "'," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString
                'strQuery += "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + ", '" + strPinHoleCustomID + "', " + dblPinHole_Combined.ToString + ", " + dblPinHoleCustomUpperTolerance.ToString + ", " + dblPinHoleCustomLowerTolerance.ToString + ", " + dblBushingHousingDimensionsID.ToString + ", " + dblBushingHousingDimensionsUpperTolerance.ToString
                'strQuery += ", " + dblBushingHousingDimensionsLowerTolerance.ToString + ", " + dblDepth.ToString + ", " + dblRawID.ToString + ", '" + strGeraseZerk + "', ' " + strGreaseZerkAngle + "', ' " + strSecondGreaseZerkAngle
                strQuery += ",'" + strMaterial + "'," + dblYieldStrength.ToString + ", Getdate() ,'IFL_PART')"  '10_07_2012   RAGAVA
            End If
            If UCase(TableName) = "WELDED.Base_End_BH_Flush_Port" Then
                '25_06_2012   RAGAVA
                'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then 'blnFromCasting = True AndAlso 
                If (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" AndAlso blnFromCasting = True) _
                                    OrElse (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" AndAlso blnFromCasting = False) Then
                    dblLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                    dblLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth
                    dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode
                    dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop    '25_06_2012   RAGAVA
                    dblEndofTubetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop   '25_06_2012   RAGAVA
                Else
                    dblLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2
                    dblLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth2
                    dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance2
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd2 = strPartCode
                    dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop2    '25_06_2012   RAGAVA
                    dblEndofTubetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop2   '25_06_2012   RAGAVA
                End If
                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode
                'Till  Here

                Dim oSelectedRESLDataRow As DataRow = Nothing
                oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPortBossDiaAndBaseDia(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter)
                strDescription = "END CAP 1 LUG" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + "-" + dblLugThickness.ToString       '15_05_2012  RAGAVA
                strPinHoleType = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType)     '01_06_2010    RAGAVA
                strPinHoleCustomID = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
                dblPinHoleCustomUpperTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceUpperLimit.Text))
                dblPinHoleCustomLowerTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceLowerLimit.Text))
                strGeraseZerk = "1/4-28 UNF-2B"
                strGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1.ToString
                strSecondGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2.ToString
                '05_08_2011  RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs = 0 Then
                    strGreaseZerkAngle = "N/A"
                    strSecondGreaseZerkAngle = "N/A"
                End If
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs = 1 Then
                    strSecondGreaseZerkAngle = "N/A"
                End If
                'Till  Here

                strMaterial = "ASTM A216 70-36 GRADE WCB"
                dblYieldStrength = 36000
                dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize))
                oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWallThicknessUpperAndLowerLimits(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure)
                If Not IsNothing(oSelectedRESLDataRow) Then
                    If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")) Then
                        dblWallThicknessLower = oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")
                    End If
                    If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")) Then
                        dblWallThicknessUpper = oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")
                    End If
                End If
                strBearingHouse = "N/A"
                dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired


                '15_05_2012  RAGAVA
                strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "','" + strPartCode + "','" + strDescription + "'," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString
                strQuery += "," + dblWallThicknessUpper.ToString + "," + dblWallThicknessLower.ToString + "," + dblLugThickness.ToString + "," + dblLugWidth.ToString + "," + dblLugHeight.ToString
                'strQuery += ",'" + dblArea.ToString + "'," + Val(dblSwingClearance - 0.0625).ToString + "," + dblEndofTubetoRodStop.ToString
                strQuery += ",'" + dblArea.ToString + "'," + Val(dblSwingClearance).ToString + "," + dblEndofTubetoRodStop.ToString
                strQuery += "," + dblDistancefromPinholetoRodStop.ToString + ",'" + strPinHoleType.ToString
                strQuery += "'," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString
                'strQuery += ", " + strPinHoleCustomID + "', " + dblPinHole_Combined.ToString + ", " + dblPinHoleCustomUpperTolerance.ToString + ", " + dblPinHoleCustomLowerTolerance.ToString + ", " + dblBushingHousingDimensionsID.ToString + ", " + dblBushingHousingDimensionsUpperTolerance.ToString
                'strQuery += ", " + dblBushingHousingDimensionsLowerTolerance.ToString + ", " + dblDepth.ToString + ", " + dblRawID.ToString + ", '" + strBearingHouse + "','"
                strQuery += ",'" + strGeraseZerk + "','" + strGreaseZerkAngle + "','" + strSecondGreaseZerkAngle
                strQuery += "'," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortQuantity.ToString + ",'" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_BaseEnd.ToString + "','"
                strQuery += IIf(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_BaseEnd Is Nothing, "0", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_BaseEnd) + "','" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortFirstOrientation.ToString + "','" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSecondOrientation.ToString + "','" + strMaterial + "'," + dblYieldStrength.ToString + ", Getdate() ,'IFL_PART')"  '10_07_2012   RAGAVA
            End If

            If UCase(TableName) = UCase("WELDED.Rod_End_BH") Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd = strPartCode
                strDescription = "ROD END 1 LUG" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd.ToString
                'ANUP 10-10-2010 START 
                'dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + 0.5
                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DistanceFromPinholetoRodStop = dblDistancefromPinholetoRodStop
                'dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop
                'ANUP 10-10-2010 TILL HERE
                strPinHoleType = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType_RodEnd)     '01_06_2010    RAGAVA
                strPinHoleCustomID = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd
                dblPinHoleCustomUpperTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceUpperLimit.Text))
                dblPinHoleCustomLowerTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceLowerLimit.Text))
                strGeraseZerk = "1/4-28 UNF-2B"
                strGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1.ToString
                strSecondGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2.ToString
                '05_08_2011  RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs_RodEnd = 0 Then
                    strGreaseZerkAngle = "N/A"
                    strSecondGreaseZerkAngle = "N/A"
                End If
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs_RodEnd = 1 Then
                    strSecondGreaseZerkAngle = "N/A"
                End If
                'Till  Here

                strMaterial = "ASTM A216 WCB"   ' "ASTM A216 70-36 GRADE WCB" Priyanka changed material 
                dblYieldStrength = 36000
                dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize))
                Dim oSelectedRESLDataRow As DataRow = Nothing
                oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWallThicknessUpperAndLowerLimits(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure)
                If Not IsNothing(oSelectedRESLDataRow) Then
                    If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")) Then
                        dblWallThicknessLower = oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")
                    End If
                    If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")) Then
                        dblWallThicknessUpper = oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")
                    End If
                End If
                'strWeldSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWeldSize_RESL(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter).ToString
                strWeldSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEnd.ToString    '01_06_2010   RAGAVA
                dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired_RodEnd
                strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "','" + strPartCode + "', '" + strDescription + "'," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter.ToString
                strQuery += ",'" + IIf(strWeldSize = "", "0", strWeldSize) + "'," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd.ToString + ",'"
                'strQuery += Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd - 0.0625).ToString + "'," + IIf(strPilotDiameter = "", "0", strPilotDiameter) + ",'" + dblArea.ToString 'ANUP 07-12-2010 START
                strQuery += Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd).ToString + "'," + IIf(strPilotDiameter = "", "0", strPilotDiameter) + ",'" + dblArea.ToString 'ANUP 07-12-2010 START
                strQuery += "'," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop.ToString + ", '" + strPinHoleType.ToString
                strQuery += "'," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + ",'" + dblPinHole_Combined.ToString + "','" + strGeraseZerk + "','" + strGreaseZerkAngle + "','" + strSecondGreaseZerkAngle
                strQuery += "','" + strMaterial + "'," + dblYieldStrength.ToString + ",'" + strCost + "', Getdate() ,'IFL_PART')"  '10_07_2012   RAGAVA



            End If
            If UCase(TableName) = UCase("WELDED.BEBHDetails") Then


                If specialCondition = "Base End" Then

                    '25_06_2012   RAGAVA
                    'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then 'blnFromCasting = True AndAlso 
                    If (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" AndAlso blnFromCasting = True) _
                                        OrElse (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" AndAlso blnFromCasting = False) Then
                        dblLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                        dblLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth
                        dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode
                        dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop    '25_06_2012   RAGAVA
                        dblEndofTubetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop   '25_06_2012   RAGAVA
                    Else
                        dblLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2
                        dblLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth2
                        dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance2
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd2 = strPartCode
                        dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop2    '25_06_2012   RAGAVA
                        dblEndofTubetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop2   '25_06_2012   RAGAVA
                    End If
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode

                    dblHeight = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.lugHeight_BaseEnd
                    strDescription = "LUG" + dblLugWidth.ToString + "-" + dblHeight.ToString + "-" + dblLugThickness.ToString
                    dblLugDiagonal = Math.Sqrt(Math.Pow(dblLugThickness, 2) + Math.Pow(dblLugWidth, 2))
                    dblRadius = dblLugThickness / 2
                    strPinHoleType = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType)     '01_06_2010    RAGAVA
                    strPinHoleCustomID = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
                    dblPinHoleCustomUpperTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceUpperLimit.Text))
                    dblPinHoleCustomLowerTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceLowerLimit.Text))
                    strGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1.ToString
                    strSecondGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2.ToString
                    dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize))
                    dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired
                    dblLugWidth = dblLugWidth.ToString
                    dblPinholeSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
                    'Till Here


                Else
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd = strPartCode          '20_10_2010    RAGAVA
                    dblHeight = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.lugHeight_RodEnd
                    strDescription = "LUG" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd.ToString + "-" + dblHeight.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd.ToString
                    dblLugDiagonal = Math.Sqrt(Math.Pow(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd, 2) + Math.Pow(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd, 2))
                    dblRadius = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd / 2
                    strPinHoleType = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType_RodEnd)
                    strPinHoleCustomID = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd
                    dblPinHoleCustomUpperTolerance = Val(Trim(_oFrmRodEndConfiguration.txtToleranceUpperLimit_RodEnd.Text))
                    dblPinHoleCustomLowerTolerance = Val(Trim(_oFrmRodEndConfiguration.txtToleranceLowerLimit_RodEnd.Text))
                    strGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1_RodEnd.ToString
                    strSecondGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2_RodEnd.ToString
                    dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd))
                    dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired_RodEnd
                    dblLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd
                    dblPinholeSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd
                End If
                '05_08_2011  RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs = 0 Then
                    strGreaseZerkAngle = "N/A"
                    strSecondGreaseZerkAngle = "N/A"
                End If
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs = 1 Then
                    strSecondGreaseZerkAngle = "N/A"
                End If
                'Till  Here

                strGeraseZerk = "1/4-28 UNF-2B"
                strMaterial = "ASTM A216 70-36 GRADE WCB"
                dblYieldStrength = 44000
                Dim oSelectedRESLDataRow As DataRow = Nothing
                oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWallThicknessUpperAndLowerLimits(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure)
                If Not IsNothing(oSelectedRESLDataRow) Then
                    If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")) Then
                        dblWallThicknessLower = oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")
                    End If
                    If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")) Then
                        dblWallThicknessUpper = oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")
                    End If
                End If
                
                '15_05_2012   RAGAVA
                strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', " + (dblLugThickness).ToString
                strQuery += ", " + dblLugWidth.ToString + ", " + dblLugDiagonal.ToString + "," + dblArea.ToString + "," + dblHeight.ToString
                strQuery += "," + dblPinholeSize.ToString + ", '" + strPinHoleCustomID + "', " + dblPinHole_Combined.ToString + ", " + dblPinHoleCustomUpperTolerance.ToString + ", " + dblPinHoleCustomLowerTolerance.ToString
                strQuery += ", " + dblSlotHeight.ToString + "," + dblSlotWidth.ToString + "," + dblRadius.ToString + ", '" + strGeraseZerk + "', ' " + strGreaseZerkAngle + "', ' " + strSecondGreaseZerkAngle
                strQuery += "', '" + strMaterial + "', '" + strMaterialCode + "'," + dblYieldStrength.ToString + ", '" + strPurchaseManufacturer + "','" + strCost + "' " + ", Getdate() ,'IFL_PART')"

            End If

            '**********************


            If UCase(TableName) = UCase("WELDED.BESLCASTINGNOPORT") Then
                '25_06_2012   RAGAVA
                'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then 'blnFromCasting = True AndAlso 
                If (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" AndAlso blnFromCasting = True) _
                                    OrElse (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" AndAlso blnFromCasting = False) Then
                    dblLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                    dblLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth
                    dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode
                    dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop    '25_06_2012   RAGAVA
                    dblEndofTubetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop   '25_06_2012   RAGAVA
                Else
                    dblLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2
                    dblLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth2
                    dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance2
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd2 = strPartCode
                    dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop2    '25_06_2012   RAGAVA
                    dblEndofTubetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop2   '25_06_2012   RAGAVA
                End If
                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode
                'Till  Here

                strDescription = "END CAP 1 LUG" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + "-" + dblLugThickness.ToString
                strPinHoleType = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType)     '01_06_2010    RAGAVA
                strPinHoleCustomID = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
                dblPinHoleCustomUpperTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceUpperLimit.Text))
                dblPinHoleCustomLowerTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceLowerLimit.Text))
                strGeraseZerk = "1/4-28 UNF-2B"
                strGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1.ToString
                strSecondGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2.ToString
                '05_08_2011  RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs = 0 Then
                    strGreaseZerkAngle = "N/A"
                    strSecondGreaseZerkAngle = "N/A"
                End If
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs = 1 Then
                    strSecondGreaseZerkAngle = "N/A"
                End If
                'Till  Here

                strMaterial = "ASTM A216 70-36 GRADE WCB"
                dblYieldStrength = 36000
                dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize))
                Dim oSelectedRESLDataRow As DataRow = Nothing
                oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWallThicknessUpperAndLowerLimits(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure)
                If Not IsNothing(oSelectedRESLDataRow) Then
                    If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")) Then
                        dblWallThicknessLower = oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")
                    End If
                    If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")) Then
                        dblWallThicknessUpper = oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")
                    End If
                End If
                dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired
                '15_05_2012  RAGAVA
                strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString
                strQuery += ", " + dblWallThicknessLower.ToString + "," + dblWallThicknessUpper.ToString + "," + dblLugThickness.ToString + "," + dblLugWidth.ToString + ", " + dblLugHeight.ToString
                'strQuery += "," + dblArea.ToString + "," + Val(dblSwingClearance - 0.0625).ToString + "," + dblEndofTubetoRodStop.ToString
                strQuery += "," + dblArea.ToString + "," + Val(dblSwingClearance).ToString + "," + dblEndofTubetoRodStop.ToString
                strQuery += "," + dblDistancefromPinholetoRodStop.ToString + ", '" + strPinHoleType.ToString
                strQuery += "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + ", '" + strPinHoleCustomID + "', " + dblPinHole_Combined.ToString + ", " + dblPinHoleCustomUpperTolerance.ToString + ", " + dblPinHoleCustomLowerTolerance.ToString + ", " + dblBushingHousingDimensionsID.ToString + ", " + dblBushingHousingDimensionsUpperTolerance.ToString
                strQuery += ", " + dblBushingHousingDimensionsLowerTolerance.ToString + ", " + dblDepth.ToString + ", " + dblRawID.ToString + ", '" + strGeraseZerk + "', ' " + strGreaseZerkAngle + "', ' " + strSecondGreaseZerkAngle
                strQuery += "', '" + strMaterial + "', '" + strNotes + "', '" + strCost + "', " + dblYieldStrength.ToString + ", Getdate() ,'IFL_PART',0)"  'anup 21-12-2010
            End If

            If UCase(TableName) = "WELDED.BESLCASTINGFLUSHPORT" Then
                '25_06_2012   RAGAVA
                'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then 'blnFromCasting = True AndAlso 
                If (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" AndAlso blnFromCasting = True) _
                                    OrElse (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" AndAlso blnFromCasting = False) Then
                    dblLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                    dblLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth
                    dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode
                    dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop    '25_06_2012   RAGAVA
                    dblEndofTubetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop   '25_06_2012   RAGAVA
                Else
                    dblLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2
                    dblLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth2
                    dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance2
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd2 = strPartCode
                    dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop2    '25_06_2012   RAGAVA
                    dblEndofTubetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop2   '25_06_2012   RAGAVA
                End If
                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode
                'Till  Here
                Dim oSelectedRESLDataRow As DataRow = Nothing
                oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPortBossDiaAndBaseDia(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter)
                '15_05_2012   RAGAVA
                strDescription = "END CAP 1 LUG" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + "-" + dblLugThickness.ToString
                strPinHoleType = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType)     '01_06_2010    RAGAVA
                strPinHoleCustomID = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
                dblPinHoleCustomUpperTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceUpperLimit.Text))
                dblPinHoleCustomLowerTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceLowerLimit.Text))
                strGeraseZerk = "1/4-28 UNF-2B"
                strGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1.ToString
                strSecondGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2.ToString
                '05_08_2011  RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs = 0 Then
                    strGreaseZerkAngle = "N/A"
                    strSecondGreaseZerkAngle = "N/A"
                End If
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs = 1 Then
                    strSecondGreaseZerkAngle = "N/A"
                End If
                'Till  Here

                strMaterial = "ASTM A216 70-36 GRADE WCB"
                dblYieldStrength = 36000
                dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize))
                oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWallThicknessUpperAndLowerLimits(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure)
                If Not IsNothing(oSelectedRESLDataRow) Then
                    If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")) Then
                        dblWallThicknessLower = oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")
                    End If
                    If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")) Then
                        dblWallThicknessUpper = oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")
                    End If
                End If
                strBearingHouse = "N/A"
                dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired
                '15_05_2012   RAGAVA
                strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString
                strQuery += ", " + dblWallThicknessUpper.ToString + "," + dblWallThicknessLower.ToString + "," + dblLugThickness.ToString + "," + dblLugWidth.ToString + ", " + dblLugHeight.ToString
                'strQuery += "," + dblArea.ToString + "," + Val(dblSwingClearance - 0.0625).ToString + "," + dblEndofTubetoRodStop.ToString
                strQuery += "," + dblArea.ToString + "," + Val(dblSwingClearance).ToString + "," + dblEndofTubetoRodStop.ToString
                strQuery += "," + dblDistancefromPinholetoRodStop.ToString + ", '" + strPinHoleType.ToString
                strQuery += "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + ", '" + strPinHoleCustomID + "', " + dblPinHole_Combined.ToString + ", " + dblPinHoleCustomUpperTolerance.ToString + ", " + dblPinHoleCustomLowerTolerance.ToString + ", " + dblBushingHousingDimensionsID.ToString + ", " + dblBushingHousingDimensionsUpperTolerance.ToString
                strQuery += ", " + dblBushingHousingDimensionsLowerTolerance.ToString + ", " + dblDepth.ToString + ", " + dblRawID.ToString + ", '" + strBearingHouse + "','" + strGeraseZerk + "', ' " + strGreaseZerkAngle + "', ' " + strSecondGreaseZerkAngle
                strQuery += "', '" + strMaterial + "', '" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortQuantity.ToString + "', '" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_BaseEnd.ToString + "','"
                strQuery += IIf(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_BaseEnd Is Nothing, "0", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_BaseEnd) + "','" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortFirstOrientation.ToString + "','" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSecondOrientation.ToString + "','" + strNotes + "', '" + strCost + "',  Getdate() ,'IFL_PART'" + ",0)" 'anup 21-12-2010 
            End If

            If UCase(TableName) = UCase("WELDED.RESLDetails") Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd = strPartCode
                strDescription = "ROD END 1 LUG" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd.ToString
                'ANUP 10-10-2010 START 
                'dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + 0.5
                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DistanceFromPinholetoRodStop = dblDistancefromPinholetoRodStop
                'dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop
                'ANUP 10-10-2010 TILL HERE
                strPinHoleType = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType_RodEnd)     '01_06_2010    RAGAVA
                strPinHoleCustomID = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd
                dblPinHoleCustomUpperTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceUpperLimit.Text))
                dblPinHoleCustomLowerTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceLowerLimit.Text))
                strGeraseZerk = "1/4-28 UNF-2B"
                strGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1.ToString
                strSecondGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2.ToString
                '05_08_2011  RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs_RodEnd = 0 Then
                    strGreaseZerkAngle = "N/A"
                    strSecondGreaseZerkAngle = "N/A"
                End If
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs_RodEnd = 1 Then
                    strSecondGreaseZerkAngle = "N/A"
                End If
                'Till  Here

                strMaterial = "ASTM A216 WCB" ' "ASTM A216 70-36 GRADE WCB" Priyanka changed material 
                dblYieldStrength = 36000
                dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize))
                Dim oSelectedRESLDataRow As DataRow = Nothing
                oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWallThicknessUpperAndLowerLimits(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure)
                If Not IsNothing(oSelectedRESLDataRow) Then
                    If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")) Then
                        dblWallThicknessLower = oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")
                    End If
                    If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")) Then
                        dblWallThicknessUpper = oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")
                    End If
                End If
                'strWeldSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWeldSize_RESL(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter).ToString
                strWeldSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEnd.ToString    '01_06_2010   RAGAVA
                dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired_RodEnd
                strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter.ToString
                strQuery += ", " + IIf(strWeldSize = "", "0", strWeldSize) + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd.ToString + ", "
                'strQuery += Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd - 0.0625).ToString + "," + IIf(strPilotDiameter = "", "0", strPilotDiameter) + "," + dblArea.ToString 'ANUP 07-12-2010 START
                strQuery += Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd).ToString + "," + IIf(strPilotDiameter = "", "0", strPilotDiameter) + "," + dblArea.ToString 'ANUP 07-12-2010 START
                strQuery += "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop.ToString + ", '" + strPinHoleType.ToString
                strQuery += "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + ", '" + strPinHoleCustomID + "', " + dblPinHole_Combined.ToString + ", " + dblPinHoleCustomUpperTolerance.ToString + ", " + dblPinHoleCustomLowerTolerance.ToString + ", " + dblBushingHousingDimensionsID.ToString + ", " + dblBushingHousingDimensionsUpperTolerance.ToString
                strQuery += ", " + dblBushingHousingDimensionsLowerTolerance.ToString + ", " + dblDepth.ToString + ", " + dblRawID.ToString + ", '" + strGeraseZerk + "', ' " + strGreaseZerkAngle + "', ' " + strSecondGreaseZerkAngle
                strQuery += "', '" + strMaterial + "', " + dblYieldStrength.ToString + ",'" + strCost + "'" + ", Getdate() ,'IFL_PART',0)" 'anup 21-12-2010 
            End If
            If UCase(TableName) = UCase("WELDED.besinglelugdetails") Then
                If specialCondition = "Base End" Then

                    '15_05_2012   RAGAVA
                    If (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" AndAlso blnFromCasting = True) _
                    OrElse (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" AndAlso blnFromCasting = False) Then         '30_05_2012   RAGAVA
                        dblLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                        dblLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth
                        dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode
                        strDescription = "LUG" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth.ToString + "-" + dblHeight.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness.ToString
                        dblLugDiagonal = Math.Sqrt(Math.Pow(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness, 2) + Math.Pow(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth, 2))
                        dblRadius = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness / 2
                        dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop    '25_06_2012   RAGAVA
                        dblEndofTubetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop   '25_06_2012   RAGAVA
                    Else
                        dblLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2
                        dblLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth2
                        dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance2
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd2 = strPartCode
                        strDescription = "LUG" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth2.ToString + "-" + dblHeight.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2.ToString
                        dblLugDiagonal = Math.Sqrt(Math.Pow(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2, 2) + Math.Pow(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth2, 2))
                        dblRadius = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2 / 2
                        dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop2    '25_06_2012   RAGAVA
                        dblEndofTubetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop2   '25_06_2012   RAGAVA
                    End If
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode

                    'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                    '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode
                    '    strDescription = "LUG" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth.ToString + "-" + dblHeight.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness.ToString
                    '    dblLugDiagonal = Math.Sqrt(Math.Pow(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness, 2) + Math.Pow(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth, 2))
                    '    dblRadius = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness / 2
                    '    dblLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth.ToString
                    'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                    '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd2 = strPartCode
                    '    strDescription = "LUG" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth2.ToString + "-" + dblHeight.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2.ToString
                    '    dblLugDiagonal = Math.Sqrt(Math.Pow(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2, 2) + Math.Pow(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth2, 2))
                    '    dblRadius = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2 / 2
                    '    dblLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth2.ToString
                    'End If
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode
                    'strDescription = "LUG" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth.ToString + "-" + dblHeight.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness.ToString
                    'dblLugDiagonal = Math.Sqrt(Math.Pow(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness, 2) + Math.Pow(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth, 2))
                    'dblRadius = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness / 2
                    'dblLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth.ToString
                    'Till   Here

                    dblHeight = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.lugHeight_BaseEnd
                    strPinHoleType = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType)     '01_06_2010    RAGAVA
                    strPinHoleCustomID = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
                    dblPinHoleCustomUpperTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceUpperLimit.Text))
                    dblPinHoleCustomLowerTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceLowerLimit.Text))
                    strGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1.ToString
                    strSecondGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2.ToString
                    dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize))
                    dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired
                    dblPinholeSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
                Else
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd = strPartCode          '20_10_2010    RAGAVA
                    dblHeight = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.lugHeight_RodEnd
                    strDescription = "LUG" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd.ToString + "-" + dblHeight.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd.ToString
                    dblLugDiagonal = Math.Sqrt(Math.Pow(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd, 2) + Math.Pow(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd, 2))
                    dblRadius = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd / 2
                    strPinHoleType = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType_RodEnd)
                    strPinHoleCustomID = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd
                    dblPinHoleCustomUpperTolerance = Val(Trim(_oFrmRodEndConfiguration.txtToleranceUpperLimit_RodEnd.Text))
                    dblPinHoleCustomLowerTolerance = Val(Trim(_oFrmRodEndConfiguration.txtToleranceLowerLimit_RodEnd.Text))
                    strGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1_RodEnd.ToString
                    strSecondGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2_RodEnd.ToString
                    dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd))
                    dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired_RodEnd
                    dblLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd
                    dblPinholeSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd
                End If
                '05_08_2011  RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs = 0 Then
                    strGreaseZerkAngle = "N/A"
                    strSecondGreaseZerkAngle = "N/A"
                End If
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs = 1 Then
                    strSecondGreaseZerkAngle = "N/A"
                End If
                'Till  Here

                strGeraseZerk = "1/4-28 UNF-2B"
                strMaterial = "ASTM A216 70-36 GRADE WCB"
                dblYieldStrength = 44000
                Dim oSelectedRESLDataRow As DataRow = Nothing
                oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWallThicknessUpperAndLowerLimits(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure)
                If Not IsNothing(oSelectedRESLDataRow) Then
                    If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")) Then
                        dblWallThicknessLower = oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")
                    End If
                    If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")) Then
                        dblWallThicknessUpper = oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")
                    End If
                End If

                '15_05_2012   RAGAVA
                strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', " + dblLugThickness.ToString
                strQuery += ", " + dblLugWidth.ToString + ", " + dblLugDiagonal.ToString + "," + dblArea.ToString + "," + dblHeight.ToString
                strQuery += "," + dblPinholeSize.ToString + ", '" + strPinHoleCustomID + "', " + dblPinHole_Combined.ToString + ", " + dblPinHoleCustomUpperTolerance.ToString + ", " + dblPinHoleCustomLowerTolerance.ToString
                strQuery += ", " + dblSlotHeight.ToString + "," + dblSlotWidth.ToString + "," + dblRadius.ToString + ", '" + strGeraseZerk + "', ' " + strGreaseZerkAngle + "', ' " + strSecondGreaseZerkAngle
                strQuery += "', '" + strMaterial + "', '" + strMaterialCode + "'," + dblYieldStrength.ToString + ", '" + strPurchaseManufacturer + "','" + strCost + "' " + ", Getdate() ,'IFL_PART')"
            End If
            
            If UCase(TableName) = UCase("WELDED.BECrossTubeFlushPort") Then
                '25_06_2012   RAGAVA
                'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then 'blnFromCasting = True AndAlso 
                If (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" AndAlso blnFromCasting = True) _
                                    OrElse (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" AndAlso blnFromCasting = False) Then
                    dblLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                    dblLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth
                    dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode
                    dblCrossTubeOD = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD
                    dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth
                    dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop    '25_06_2012   RAGAVA
                    dblEndofTubetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop   '25_06_2012   RAGAVA
                Else
                    dblLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2
                    dblLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth2
                    dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance2
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd2 = strPartCode
                    dblCrossTubeOD = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD2
                    dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth2
                    dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop2    '25_06_2012   RAGAVA
                    dblEndofTubetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop2   '25_06_2012   RAGAVA
                End If
                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode
                'Till  Here
                Dim oSelectedRESLDataRow As DataRow = Nothing
                strDescription = "END CAP X TUBE" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + "-" + dblCrossTubeWidth.ToString
                dbloffSet = ObjClsWeldedGlobalVariables.OffSet
                'ANUP 10-10-2010 START 
                'dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + 0.5
                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DistanceFromPinholetoRodStop = dblDistancefromPinholetoRodStop
                'dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop
                'ANUP 10-10-2010 TILL HERE
                strPinHoleType = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType)     '01_06_2010    RAGAVA
                strPinHoleCustomID = Trim(_oFrmTubeDetails.txtPinHoleSize.Text)
                dblPinHoleCustomUpperTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceUpperLimit.Text))
                dblPinHoleCustomLowerTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceLowerLimit.Text))
                strGeraseZerk = "1/4-28 UNF-2B"
                strGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1.ToString
                strSecondGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2.ToString
                '05_08_2011  RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs = 0 Then
                    strGreaseZerkAngle = "N/A"
                    strSecondGreaseZerkAngle = "N/A"
                End If
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs = 1 Then
                    strSecondGreaseZerkAngle = "N/A"
                End If
                'Till  Here

                strMaterial = "ASTM A216 70-36 GRADE WCB"
                dblYieldStrength = 36000
                dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize))
                oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWallThicknessUpperAndLowerLimits(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure)
                If Not IsNothing(oSelectedRESLDataRow) Then
                    If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")) Then
                        dblWallThicknessLower = oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")
                    End If
                    If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")) Then
                        dblWallThicknessUpper = oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")
                    End If
                End If
                strBearingHouse = "N/A"
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD < Val(Trim(_oFrmCTDesignACasting.txtPinHoleSize_DesignCrossTubeCasting.Text)) + 0.5 Then
                    UpdateHashTableValues(_htNewDesignPartParams, "CROSS TUBE OD", Val(Trim(_oFrmCTDesignACasting.txtPinHoleSize_DesignCrossTubeCasting.Text)) + 0.5)
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD = Val(Trim(_oFrmCTDesignACasting.txtPinHoleSize_DesignCrossTubeCasting.Text)) + 0.5
                End If
                '15_05_2012   RAGAVA
                'dblCrossTubeOD = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD
                'dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth 
                strPortFacingAtBaseEnd = ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortFacingBaseEnd.Text
                '  dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness * (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth - dblPinHole_Combined)
                dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired
                strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString
                strQuery += ", " + dblWallThicknessUpper.ToString + "," + dblWallThicknessLower.ToString + "," + dblCrossTubeOD.ToString + "," + dblCrossTubeWidth.ToString + "," + dblArea.ToString
                'strQuery += "," + Val(dblSwingClearance - 0.0625).ToString + "," + dblEndofTubetoRodStop.ToString + "," + dbloffSet.ToString
                strQuery += "," + Val(dblSwingClearance).ToString + "," + dblEndofTubetoRodStop.ToString + "," + dbloffSet.ToString
                strQuery += "," + dblDistancefromPinholetoRodStop.ToString + ", '" + strPinHoleType.ToString
                strQuery += "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + ", '" + strPinHoleCustomID + "', " + dblPinHole_Combined.ToString + ", " + dblPinHoleCustomUpperTolerance.ToString + ", " + dblPinHoleCustomLowerTolerance.ToString + ", " + dblBushingHousingDimensionsID.ToString + ", " + dblBushingHousingDimensionsUpperTolerance.ToString
                strQuery += ", " + dblBushingHousingDimensionsLowerTolerance.ToString + ", " + dblDepth.ToString + ", " + dblRawID.ToString + ", '" + strGeraseZerk + "', ' " + strGreaseZerkAngle + "', ' " + strSecondGreaseZerkAngle
                strQuery += "', '" + strMaterial + "', " + dblYieldStrength.ToString + ",'" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortQuantity.ToString + "', '" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_BaseEnd.ToString + "','"
                strQuery += IIf(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_BaseEnd Is Nothing, "0", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_BaseEnd) + "','" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortFirstOrientation.ToString + "','" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSecondOrientation.ToString + "','" + strPortFacingAtBaseEnd + "','" + strNotes + "', '" + strCost + "',  Getdate() ,'IFL_PART','" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ISBushingStyle_2BushingsIndividualBore + "',0)"     'ANUP 20-09-2010 START 'anup 21-12-2010 
            End If
            If UCase(TableName) = UCase("WELDED.BECrossTubeCastingWithoutPort") Then
                '25_06_2012   RAGAVA
                'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then 'blnFromCasting = True AndAlso 
                If (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" AndAlso blnFromCasting = True) _
                                    OrElse (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" AndAlso blnFromCasting = False) Then
                    dblLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                    dblLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth
                    dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode
                    dblCrossTubeOD = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD
                    dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth
                    dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop    '25_06_2012   RAGAVA
                    dblEndofTubetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop   '25_06_2012   RAGAVA
                Else
                    dblLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2
                    dblLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth2
                    dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance2
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd2 = strPartCode
                    dblCrossTubeOD = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD2
                    dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth2
                    dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop2    '25_06_2012   RAGAVA
                    dblEndofTubetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop2   '25_06_2012   RAGAVA
                End If
                If dblCrossTubeOD < Val(Trim(_oFrmCTDesignACasting.txtPinHoleSize_DesignCrossTubeCasting.Text)) + 0.5 Then
                    UpdateHashTableValues(_htNewDesignPartParams, "CROSS TUBE OD", Val(Trim(_oFrmCTDesignACasting.txtPinHoleSize_DesignCrossTubeCasting.Text)) + 0.5)
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD = Val(Trim(_oFrmCTDesignACasting.txtPinHoleSize_DesignCrossTubeCasting.Text)) + 0.5
                End If
                'Till  Here

                Dim oSelectedRESLDataRow As DataRow = Nothing
                '15_05_2012   RAGAVA
                strDescription = "END CAP X TUBE" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + "-" + dblCrossTubeWidth.ToString
                dbloffSet = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OffSet
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD < Val(Trim(_oFrmCTDesignACasting.txtPinHoleSize_DesignCrossTubeCasting.Text)) + 0.5 Then
                    UpdateHashTableValues(_htNewDesignPartParams, "CROSS TUBE OD", Val(Trim(_oFrmCTDesignACasting.txtPinHoleSize_DesignCrossTubeCasting.Text)) + 0.5)
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD = Val(Trim(_oFrmCTDesignACasting.txtPinHoleSize_DesignCrossTubeCasting.Text)) + 0.5
                End If
                strPinHoleType = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType)     '01_06_2010    RAGAVA
                strPinHoleCustomID = Trim(_oFrmTubeDetails.txtPinHoleSize.Text)
                dblPinHoleCustomUpperTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceUpperLimit.Text))
                dblPinHoleCustomLowerTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceLowerLimit.Text))
                strGeraseZerk = "1/4-28 UNF-2B"
                strGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1.ToString
                strSecondGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2.ToString
                '05_08_2011  RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs = 0 Then
                    strGreaseZerkAngle = "N/A"
                    strSecondGreaseZerkAngle = "N/A"
                End If
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs = 1 Then
                    strSecondGreaseZerkAngle = "N/A"
                End If
                'Till  Here

                strMaterial = "ASTM A216 70-36 GRADE WCB"
                dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize))
                oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWallThicknessUpperAndLowerLimits(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure)
                If Not IsNothing(oSelectedRESLDataRow) Then
                    If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")) Then
                        dblWallThicknessLower = oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")
                    End If
                    If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")) Then
                        dblWallThicknessUpper = oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")
                    End If
                End If
                strBearingHouse = "N/A"
                dblYieldStrength = 36000
                strPortFacingAtBaseEnd = ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortFacingBaseEnd.Text
                dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired
                ' dblCrossTubeOD = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD
                '15_05_2012   RAGAVA
                strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString
                strQuery += "," + dblWallThicknessLower.ToString + "," + dblWallThicknessUpper.ToString + "," + dblCrossTubeOD.ToString + "," + dblCrossTubeWidth.ToString + "," + dblArea.ToString        '04_03_2010   RAGAVA
                'strQuery += "," + Val(dblSwingClearance - 0.0625).ToString + "," + dblEndofTubetoRodStop.ToString + "," + dbloffSet.ToString
                strQuery += "," + Val(dblSwingClearance).ToString + "," + dblEndofTubetoRodStop.ToString + "," + dbloffSet.ToString
                strQuery += "," + dblDistancefromPinholetoRodStop.ToString + ", '" + strPinHoleType.ToString
                strQuery += "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + ", '" + strPinHoleCustomID + "', " + dblPinHole_Combined.ToString + ", " + dblPinHoleCustomUpperTolerance.ToString + ", " + dblPinHoleCustomLowerTolerance.ToString + ", " + dblBushingHousingDimensionsID.ToString + ", " + dblBushingHousingDimensionsUpperTolerance.ToString
                strQuery += ", " + dblBushingHousingDimensionsLowerTolerance.ToString + ", " + dblDepth.ToString + ", " + dblRawID.ToString + ", '" + strGeraseZerk + "', ' " + strGreaseZerkAngle + "', ' " + strSecondGreaseZerkAngle
                strQuery += "', '" + strMaterial + "', " + dblYieldStrength.ToString + ", '" + strCost + "',  Getdate() ,'IFL_PART','" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ISBushingStyle_2BushingsIndividualBore + "',0)"     'ANUP 20-09-2010 START 'anup 21-12-2010 
            End If

            If UCase(TableName) = UCase("Welded.RECrossTubeCasting") Then
                '25_07_2012   RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Cast" Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd = strPartCode
                    dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd
                    dblCrossTubeOD = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD_RodEnd
                    '31_08_2012   RAGAVA  Commented   Weldment
                    'ElseIf ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated2 = "Cast" Then
                    '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd2 = strPartCode
                    '    dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd2
                    '    dblCrossTubeOD = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD_RodEnd2
                End If
                'Till  Here
                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd = strPartCode
                Dim oSelectedRESLDataRow As DataRow = Nothing
                strDescription = "END CAP X TUBE" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + "-" + dblCrossTubeWidth.ToString
                dbloffSet = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OffSet_RodEnd
                strPinHoleType = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType_RodEnd)     '01_06_2010    RAGAVA
                'anup 03-022011 start
                'strPinHoleCustomID = Trim(_oFrmTubeDetails.txtPinHoleSize.Text)
                'dblPinHoleCustomUpperTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceUpperLimit.Text))
                'dblPinHoleCustomLowerTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceLowerLimit.Text))
                strPinHoleCustomID = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd)
                dblPinHoleCustomUpperTolerance = Val(Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceUpperLimit_RodEnd))
                dblPinHoleCustomLowerTolerance = Val(Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceLowerLimit_RodEnd))
                'anup 03-022011 till here
                strGeraseZerk = "1/4-28 UNF-2B"
                strGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1.ToString
                strSecondGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2.ToString
                '05_08_2011  RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs_RodEnd = 0 Then
                    strGreaseZerkAngle = "N/A"
                    strSecondGreaseZerkAngle = "N/A"
                End If
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs_RodEnd = 1 Then
                    strSecondGreaseZerkAngle = "N/A"
                End If
                'Till  Here

                strMaterial = "ASTM A216 WCB"    '"8620" Priyanka changed material 
                dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize))
                oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWallThicknessUpperAndLowerLimits(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure)
                If Not IsNothing(oSelectedRESLDataRow) Then
                    If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")) Then
                        dblWallThicknessLower = oSelectedRESLDataRow("WALLTHICKNESSLOWERLIMIT")
                    End If
                    If Not IsDBNull(oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")) Then
                        dblWallThicknessUpper = oSelectedRESLDataRow("WALLTHICKNESSUPPERLIMIT")
                    End If
                End If
                strBearingHouse = "N/A"
                dblYieldStrength = 36000 '79000 Priyanka changed to 36000 
                'strWeldSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWeldSize_RESL(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter).ToString
                strWeldSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEnd.ToString    '01_06_2010   RAGAVA
                strPortFacingAtBaseEnd = ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortFacingBaseEnd.Text
                dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired_RodEnd
                'dblCrossTubeOD = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD_RodEnd
                'dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd
                strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter.ToString
                strQuery += ", " + IIf(strWeldSize = "", "0", strWeldSize) + "," + dblCrossTubeOD.ToString + "," + dblCrossTubeWidth.ToString
                strQuery += "," + IIf(strPilotDiameter = "", "0", strPilotDiameter) + "," + dblArea.ToString
                strQuery += "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop.ToString + ", '" + strPinHoleType.ToString
                strQuery += "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + ", '" + strPinHoleCustomID + "', " + dblPinHole_Combined.ToString + ", " + dblPinHoleCustomUpperTolerance.ToString + ", " + dblPinHoleCustomLowerTolerance.ToString + ", " + dblBushingHousingDimensionsID.ToString + ", " + dblBushingHousingDimensionsUpperTolerance.ToString
                strQuery += ", " + dblBushingHousingDimensionsLowerTolerance.ToString + ", " + dblDepth.ToString + ", " + dblRawID.ToString + ", '" + strGeraseZerk + "', ' " + strGreaseZerkAngle + "', ' " + strSecondGreaseZerkAngle
                strQuery += "', '" + strMaterial + "'," + dblYieldStrength.ToString + ",'" + strCost + "' " + ", Getdate() ,'IFL_PART','" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ISBushingStyle_2BushingsIndividualBore_RodEnd + "',0)"   'ANUP 20-09-2010 START 'anup 21-12-2010
            End If

            If UCase(TableName) = UCase("Welded.becrossTubeDetails") Then
                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode
                strPinHoleType = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType)     '01_06_2010    RAGAVA
                strPinHoleCustomID = Trim(_oFrmTubeDetails.txtPinHoleSize.Text)
                dblPinHoleCustomUpperTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceUpperLimit.Text))
                dblPinHoleCustomLowerTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceLowerLimit.Text))
                dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize))
                strGeraseZerk = "1/4-28 UNF-2B"
                strGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1.ToString
                strSecondGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2.ToString
                dblYieldStrength = 30000
                '25_06_2012   RAGAVA
                If specialCondition = "Base End" Then
                    'ObjClsWeldedCylinderFunctionalClass.strExistingBaseEndPartCode = strPartCode
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Cross Tube" Then
                        dblCrossTubeOD = ((4 / 3) * (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired / Val(Trim(_oFrmCTFabrication.txtCrossTubeWidth_DesignCrossTube.Text)))) + Val(Trim(_oFrmCTFabrication.txtPinHoleSize_DesignCrossTube.Text))
                        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD < Val(Trim(_oFrmCTFabrication.txtPinHoleSize_DesignCrossTube.Text)) + 0.5 Then
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD = Val(Trim(_oFrmCTFabrication.txtPinHoleSize_DesignCrossTube.Text)) + 0.5
                        End If
                        dblCrossTubeOD = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD
                        dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth
                        dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired
                    End If
                    '25_06_2012   RAGAVA
                    'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then 'blnFromCasting = True AndAlso 
                    If (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" AndAlso blnFromCasting = True) _
                                        OrElse (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" AndAlso blnFromCasting = False) Then
                        dblLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                        dblLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth
                        dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode
                        dblCrossTubeOD = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD
                        dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth
                        dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop    '25_06_2012   RAGAVA
                        dblEndofTubetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop   '25_06_2012   RAGAVA
                    Else
                        dblLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2
                        dblLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth2
                        dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance2
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd2 = strPartCode
                        dblCrossTubeOD = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD2
                        dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth2
                        dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop2    '25_06_2012   RAGAVA
                        dblEndofTubetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop2   '25_06_2012   RAGAVA
                    End If
                    strDescription = "CROSS TUBE" + dblCrossTubeOD.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + "-" + dblCrossTubeWidth.ToString

                Else
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Cross Tube" Then
                        If ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Fabricated" Then
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd = strPartCode
                            dblCrossTubeOD = ((4 / 3) * (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired_RodEnd / Val(Trim(_oFrmFabrication_RECT.txtCrossTubeWidth_RECT.Text)))) + Val(Trim(_oFrmFabrication_RECT.txtPinHoleSize_DesignCrossTubeCT_RECT.Text))
                            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD_RodEnd < Val(Trim(_oFrmFabrication_RECT.txtPinHoleSize_DesignCrossTubeCT_RECT.Text)) + 0.5 Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD_RodEnd = Val(Trim(_oFrmFabrication_RECT.txtPinHoleSize_DesignCrossTubeCT_RECT.Text)) + 0.5
                            End If
                            strDescription = "CROSS TUBE" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD_RodEnd.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd.ToString
                            dblCrossTubeOD = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD_RodEnd
                            dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd
                            dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired_RodEnd
                            '31_08_2012   RAGAVA  Commented   Weldment
                            'ElseIf ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated2 = "Fabricated" Then
                            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd2 = strPartCode
                            '    dblCrossTubeOD = ((4 / 3) * (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired_RodEnd / Val(Trim(_oFrmFabrication_RECT2.txtCrossTubeWidth_RECT.Text)))) + Val(Trim(_oFrmFabrication_RECT2.txtPinHoleSize_DesignCrossTubeCT_RECT.Text))
                            '    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD_RodEnd < Val(Trim(_oFrmFabrication_RECT2.txtPinHoleSize_DesignCrossTubeCT_RECT.Text)) + 0.5 Then
                            '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD_RodEnd = Val(Trim(_oFrmFabrication_RECT2.txtPinHoleSize_DesignCrossTubeCT_RECT.Text)) + 0.5
                            '    End If
                            '    strDescription = "CROSS TUBE" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD_RodEnd2.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd2.ToString
                            '    dblCrossTubeOD = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD_RodEnd2
                            '    dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd2
                            '    dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired_RodEnd
                        End If
                    End If
                End If






                    '05_08_2011  RAGAVA
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs = 0 Then
                        strGreaseZerkAngle = "N/A"
                        strSecondGreaseZerkAngle = "N/A"
                    End If
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs = 1 Then
                        strSecondGreaseZerkAngle = "N/A"
                    End If
                    'Till  Here

                    '15_02_2011   RAGAVA
                    Dim str2BushingsIndividualbore As String = String.Empty
                    If partName.StartsWith("BEC") = True OrElse partName.StartsWith("Base") = True Then
                        str2BushingsIndividualbore = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ISBushingStyle_2BushingsIndividualBore
                    Else
                        str2BushingsIndividualbore = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ISBushingStyle_2BushingsIndividualBore_RodEnd
                    End If
                    'Till   Here
                    strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription
                    strQuery += "', " + dblCrossTubeOD.ToString + "," + dblCrossTubeWidth.ToString
                    strQuery += "," + dblArea.ToString
                    strQuery += ", " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + ", '" + strPinHoleCustomID + "', " + dblPinHole_Combined.ToString + ", " + dblPinHoleCustomUpperTolerance.ToString + ", " + dblPinHoleCustomLowerTolerance.ToString
                    strQuery += ", '" + strGeraseZerk + "', ' " + strGreaseZerkAngle + "', ' " + strSecondGreaseZerkAngle
                    'strQuery += "', '" + strMaterial + "'," + dblYieldStrength.ToString + ",'" + strCost + "' " + ", Getdate() ,'IFL_PART','" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ISBushingStyle_2BushingsIndividualBore + "')"     'ANUP 20-09-2010 START
                    strQuery += "', '" + strMaterial + "'," + dblYieldStrength.ToString + ",'" + strCost + "' " + ", Getdate() ,'IFL_PART','" + str2BushingsIndividualbore + "')"          '15_02_2011   RAGAVA
            End If
            Try
                If UCase(TableName) = UCase("WELDED.BEDLCastWithOutPort") Then
                    dblEndofTubetoRodStop = -0.125
                    '25_06_2012   RAGAVA
                    'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then 'blnFromCasting = True AndAlso 
                    If (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" AndAlso blnFromCasting = True) _
                                        OrElse (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" AndAlso blnFromCasting = False) Then
                        dblLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                        dblLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth
                        dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode
                        If Not ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port Integral" Then
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = -0.125
                        End If
                        dblEndofTubetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop
                        dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop
                        dblLugGap = dblDL_LugGap     '12_06_2012    RAGAVA
                    Else
                        dblLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2
                        dblLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth2
                        dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance2
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd2 = strPartCode
                        If Not ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port Integral" Then
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop2 = -0.125
                        End If
                        dblEndofTubetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop2
                        dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop2
                        dblLugGap = dblDL_LugGap2    '12_06_2012    RAGAVA
                    End If
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode          '20_10_2010    RAGAVA
                    'Till   Here
                    'strDescription = "END CAP 2 LUG " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness.ToString
                    strDescription = "END CAP 2 LUG WP STD " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString        '15_11_2011   RAGAVA


                    'ANUP 10-10-2010 START 
                    'dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + 0.5
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DistanceFromPinholetoRodStop = dblDistancefromPinholetoRodStop
                    'ANUP 10-10-2010 TILL HERE
                    strPinHoleCustomID = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
                    dblPinHoleCustomUpperTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceUpperLimit.Text))
                    dblPinHoleCustomLowerTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceLowerLimit.Text))
                    'ANUP 13-10-2010 START
                    ' strGeraseZerk = "1/4-28 UNF-2B"
                    strGeraseZerk = "N/A"
                    'ANUP 13-10-2010 TILL HERE
                    strGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1.ToString
                    strSecondGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2.ToString
                    '05_08_2011  RAGAVA
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs = 0 Then
                        strGreaseZerkAngle = "N/A"
                        strSecondGreaseZerkAngle = "N/A"
                    End If
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs = 1 Then
                        strSecondGreaseZerkAngle = "N/A"
                    End If
                    'Till  Here

                    strMaterial = "ASTM A216 70-36 GRADE WCB"
                    dblYieldStrength = 36000
                    dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize))
                    Dim oSelectedBEDLDataRow As DataRow = Nothing
                    oSelectedBEDLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWallThicknessUpperAndLowerLimits(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure)
                    If Not IsNothing(oSelectedBEDLDataRow) Then
                        If Not IsDBNull(oSelectedBEDLDataRow("WALLTHICKNESSLOWERLIMIT")) Then
                            dblWallThicknessLower = oSelectedBEDLDataRow("WALLTHICKNESSLOWERLIMIT")
                        End If
                        If Not IsDBNull(oSelectedBEDLDataRow("WALLTHICKNESSUPPERLIMIT")) Then
                            dblWallThicknessUpper = oSelectedBEDLDataRow("WALLTHICKNESSUPPERLIMIT")
                        End If
                    End If
                    dblLugHeight = dblSwingClearance + (dblLugWidth / 2) + (2 * dblLugThickness)       '06_03_2010    RAGAVA
                    'Dim dblLugGap As Double = dblDL_LugGap      '12_06_2012    RAGAVA
                    '15_05_2012   RAGAVA
                    dblArea = dblLugThickness * (dblLugWidth - dblPinHole_Combined)
                    strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString
                    strQuery += ", " + dblWallThicknessLower.ToString + "," + dblWallThicknessUpper.ToString + "," + dblLugThickness.ToString + "," + dblLugWidth.ToString + ", " + dblLugHeight.ToString + ", " + dblLugGap.ToString
                    'strQuery += "," + dblArea.ToString + "," + Val(dblSwingClearance - 0.0625).ToString + "," + dblEndofTubetoRodStop.ToString
                    strQuery += "," + dblArea.ToString + "," + Val(dblSwingClearance).ToString + "," + dblEndofTubetoRodStop.ToString
                    strQuery += "," + dblDistancefromPinholetoRodStop.ToString
                    strQuery += ", " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + ", '" + strPinHoleCustomID + "', " + dblPinHole_Combined.ToString + ", " + dblPinHoleCustomUpperTolerance.ToString + ", " + dblPinHoleCustomLowerTolerance.ToString
                    strQuery += ", '" + strGeraseZerk + "', ' " + strGreaseZerkAngle + "', ' " + strSecondGreaseZerkAngle
                    'strQuery += "', '" + strMaterial + "', '" + strNotes + "', '" + strCost + "', " + dblYieldStrength.ToString + ", Getdate())"
                    strQuery += "', '" + strMaterial + "', '" + strNotes + "', '" + strCost + "', " + dblYieldStrength.ToString + ", Getdate(),'IFL_PART',0)"        '01_03_2010   RAGAVA  'anup 21-12-2010 
                End If
            Catch ex As Exception
            End Try

            Try
                If TableName = UCase("WELDED.BEDLCastWithFlushPort") Then
                    ' ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode          '20_10_2010    RAGAVA
                    dblEndofTubetoRodStop = -0.125
                    '25_06_2012   RAGAVA
                    'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then 'blnFromCasting = True AndAlso 
                    If (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" AndAlso blnFromCasting = True) _
                                        OrElse (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" AndAlso blnFromCasting = False) Then
                        dblLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                        dblLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth
                        dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode
                        If Not ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port Integral" Then
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = -0.125
                        End If
                        dblEndofTubetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop
                        dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop
                        dblLugGap = dblDL_LugGap     '12_06_2012    RAGAVA
                    Else
                        dblLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2
                        dblLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth2
                        dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance2
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd2 = strPartCode
                        If Not ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port Integral" Then
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop2 = -0.125
                        End If
                        dblEndofTubetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop2
                        dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop2
                        dblLugGap = dblDL_LugGap2     '12_06_2012    RAGAVA
                    End If
                    strDescription = "END CAP 2 LUG " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + "-" + dblLugThickness.ToString
                    'Till  Here


                    'ANUP 10-10-2010 START 
                    'dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + 0.5
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DistanceFromPinholetoRodStop = dblDistancefromPinholetoRodStop
                    'ANUP 10-10-2010 TILL HERE

                    strPinHoleCustomID = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
                    dblPinHoleCustomUpperTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceUpperLimit.Text))
                    dblPinHoleCustomLowerTolerance = Val(Trim(_oFrmTubeDetails.txtToleranceLowerLimit.Text))
                    'ANUP 13-10-2010 START
                    ' strGeraseZerk = "1/4-28 UNF-2B"
                    strGeraseZerk = "N/A"
                    'ANUP 13-10-2010 TILL HERE
                    strGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1.ToString
                    strSecondGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2.ToString
                    '05_08_2011  RAGAVA
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs = 0 Then
                        strGreaseZerkAngle = "N/A"
                        strSecondGreaseZerkAngle = "N/A"
                    End If
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs = 1 Then
                        strSecondGreaseZerkAngle = "N/A"
                    End If
                    'Till  Here

                    strMaterial = "ASTM A216 70-36 GRADE WCB"
                    dblYieldStrength = 36000
                    dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize))
                    Dim oSelectedBEDLDataRow As DataRow = Nothing
                    oSelectedBEDLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWallThicknessUpperAndLowerLimits(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure)
                    If Not IsNothing(oSelectedBEDLDataRow) Then
                        If Not IsDBNull(oSelectedBEDLDataRow("WALLTHICKNESSLOWERLIMIT")) Then
                            dblWallThicknessLower = oSelectedBEDLDataRow("WALLTHICKNESSLOWERLIMIT")
                        End If
                        If Not IsDBNull(oSelectedBEDLDataRow("WALLTHICKNESSUPPERLIMIT")) Then
                            dblWallThicknessUpper = oSelectedBEDLDataRow("WALLTHICKNESSUPPERLIMIT")
                        End If
                    End If
                    'dblLugHeight = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth / 2) + (2 * ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness)            '06_03_2010  RAGAVA
                    dblLugHeight = dblSwingClearance + (dblLugWidth / 2) + (2 * dblLugThickness)            '12_06_2012  RAGAVA
                    'Dim dblLugGap As Double = dblDL_LugGap        '12_06_2012    RAGAVA
                    '15_05_2012    RAGAVA
                    dblArea = dblLugThickness * (dblLugWidth - dblPinHole_Combined)
                    strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString
                    strQuery += ", " + dblWallThicknessLower.ToString + "," + dblWallThicknessUpper.ToString + "," + dblLugThickness.ToString + "," + dblLugWidth.ToString + ", " + dblLugHeight.ToString + ", " + dblLugGap.ToString
                    'strQuery += "," + dblArea.ToString + "," + Val(dblSwingClearance - 0.0625).ToString + "," + dblEndofTubetoRodStop.ToString
                    strQuery += "," + dblArea.ToString + "," + Val(dblSwingClearance).ToString + "," + dblEndofTubetoRodStop.ToString
                    strQuery += "," + dblDistancefromPinholetoRodStop.ToString
                    strQuery += ", " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize.ToString + ", '" + strPinHoleCustomID + "', " + dblPinHole_Combined.ToString + ", " + dblPinHoleCustomUpperTolerance.ToString + ", " + dblPinHoleCustomLowerTolerance.ToString
                    strQuery += ", '" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_BaseEnd.ToString + "', '" + _oFrmPortDetails.cmbPortSizeBaseEnd.Text.ToString + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortFirstOrientation.ToString
                    strQuery += ", '" + strGeraseZerk + "', '" + strGreaseZerkAngle + "', '" + strSecondGreaseZerkAngle
                    'strQuery += "', '" + strMaterial + "', '" + strCost + "', Getdate())"
                    strQuery += "', '" + strMaterial + "', '" + strCost + "', Getdate(),'IFL_PART',0)"         '01_03_2010   RAGAVA 'anup 21-12-2010
                End If

            Catch ex As Exception
            End Try
            Try
                If TableName = UCase("WELDED.BEULDetails") Then
                    Dim strSingle_DoubleRadii As String = "D"
                    Dim strPilotHoleYesNo As String = "N"
                    Dim strPinHole As String = "N/A"
                    Dim dblHeightToRadiusEnd As Double
                    Dim dblPinHoleToBottomOfULug As Double = 0 '07_04_2010 Aruna
                    'Dim dblSwingClearance As Double = 0 '15_05_2012    RAGAVA '07_04_2010 Aruna
                    If UCase(partName) = "BASE_U_LUG_IFL" Then
                        '15_05_2012   RAGAVA
                        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then 'blnFromCasting = True AndAlso 
                            dblLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                            dblLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth
                            dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode
                            dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop    '25_06_2012   RAGAVA
                            dblEndofTubetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop   '25_06_2012   RAGAVA
                        Else
                            dblLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2
                            dblLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth2
                            dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance2
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd2 = strPartCode
                            dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop2    '25_06_2012   RAGAVA
                            dblEndofTubetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop2   '25_06_2012   RAGAVA
                        End If
                        dblLugHeight = dblSwingClearance + (dblLugWidth / 2) + (2 * dblLugThickness)
                        dblHeightToRadiusEnd = dblLugHeight - (2 * dblLugThickness)
                        dblLugDiagonal = Math.Sqrt(Math.Pow(dblLugWidth, 2) + Math.Pow(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap + (2 * dblLugThickness), 2))
                        strDescription = "CLEVIS 2 LUG " + dblLugWidth.ToString + "-" + dblLugHeight.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap.ToString
                        strPinHoleCustomID = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
                        dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize))
                        dblLugGap = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap
                        dblArea = dblLugThickness * (dblLugWidth - dblPinHole_Combined)
                        '07-04_2010 Aruna
                        dblPinHoleToBottomOfULug = dblLugThickness + dblSwingClearance
                    Else
                        'ANUP 23-09-2010 START
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd = strPartCode
                        'ANUP 23-09-2010 TILL HERE
                        dblLugHeight = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd + (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd / 2) + (2 * ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd)
                        dblHeightToRadiusEnd = dblLugHeight - (2 * ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd)
                        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd          '14_04_2010  RAGAVA
                        dblLugDiagonal = Math.Sqrt(Math.Pow(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd, 2) + Math.Pow(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap_RodEnd + (2 * ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd), 2))
                        strDescription = "CLEVIS 2 LUG " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd.ToString + "-" + dblLugHeight.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap_RodEnd.ToString
                        strPinHoleCustomID = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd
                        dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd))
                        dblLugGap = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap_RodEnd
                        dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd * (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd - dblPinHole_Combined)
                        '07-04_2010 Aruna
                        dblPinHoleToBottomOfULug = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd
                        dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd
                    End If
                    strMaterial = "44W"
                    dblYieldStrength = 44000
                    '15_05_2012   RAGAVA
                    strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', '" + strSingle_DoubleRadii  ' ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter.ToString
                    strQuery += "', '" + strPilotHoleYesNo + "','N/A'," + (dblLugThickness).ToString + "," + dblLugWidth.ToString + ", " + dblLugGap.ToString
                    strQuery += "," + dblLugDiagonal.ToString + "," + dblArea.ToString + "," + dblLugHeight.ToString + "," + dblHeightToRadiusEnd.ToString + "," + dblSwingClearance.ToString '07-04_2010 Aruna
                    strQuery += "," + dblPinHoleToBottomOfULug.ToString + ",'" + strManual_Lathe + "','N/A','N/A'," + dblPinHole_Combined.ToString + ",'N/A','N/A','" + strCost.ToString + "','" + strMaterial + "'," + dblYieldStrength.ToString + ", Getdate(),'IFL_PART',0)"

                    'strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', '" + strSingle_DoubleRadii  ' ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter.ToString
                    'strQuery += "', '" + strPilotHoleYesNo + "','N/A'," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd.ToString + ", " + dblLugGap.ToString
                    ''strQuery += "," + dblLugDiagonal.ToString + "," + dblArea.ToString + "," + dblLugHeight.ToString + "," + dblHeightToRadiusEnd.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance.ToString '07-04_2010 Aruna
                    'strQuery += "," + dblLugDiagonal.ToString + "," + dblArea.ToString + "," + dblLugHeight.ToString + "," + dblHeightToRadiusEnd.ToString + "," + dblSwingClearance.ToString '07-04_2010 Aruna
                    ''strQuery += ",'N/A','" + strManual_Lathe + "','N/A','N/A'," + dblPinHole_Combined.ToString + ",'N/A','N/A','" + strCost.ToString + "','" + strMaterial + "'," + dblYieldStrength.ToString + ", Getdate(),'IFL_PART')"'07-04_2010 Aruna
                    'strQuery += "," + dblPinHoleToBottomOfULug.ToString + ",'" + strManual_Lathe + "','N/A','N/A'," + dblPinHole_Combined.ToString + ",'N/A','N/A','" + strCost.ToString + "','" + strMaterial + "'," + dblYieldStrength.ToString + ", Getdate(),'IFL_PART',0)" '07-04_2010 Aruna    'anup 21-12-2010 
                    'Till  Here

                End If
            Catch ex As Exception
            End Try
            Try
                If TableName = UCase("WELDED.REDLCasting") Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd = strPartCode          '20_10_2010    RAGAVA
                    strDescription = "ROD END 2 LUG " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd.ToString
                    'ANUP 10-10-2010 START 
                    '  dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd + 0.36
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DistanceFromPinholetoRodStop = dblDistancefromPinholetoRodStop
                    dblDistancefromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop
                    'ANUP 10-10-2010 TILL HERE
                    strPinHoleCustomID = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd.ToString
                    dblPinHoleCustomUpperTolerance = Val(Trim(_oFrmRodEndConfiguration.txtToleranceUpperLimit_RodEnd.Text))
                    dblPinHoleCustomLowerTolerance = Val(Trim(_oFrmRodEndConfiguration.txtToleranceLowerLimit_RodEnd.Text))
                    'ANUP 13-10-2010 START
                    ' strGeraseZerk = "1/4-28 UNF-2B"
                    strGeraseZerk = "N/A"
                    'ANUP 13-10-2010 TILL HERE
                    strGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1_RodEnd.ToString
                    strSecondGreaseZerkAngle = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2_RodEnd.ToString
                    '05_08_2011  RAGAVA
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs_RodEnd = 0 Then
                        strGreaseZerkAngle = "N/A"
                        strSecondGreaseZerkAngle = "N/A"
                    End If
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs_RodEnd = 1 Then
                        strSecondGreaseZerkAngle = "N/A"
                    End If
                    'Till  Here

                    strMaterial = "ASTM A216 WCB"    ' "A148 90-60" Priyanka changed material 
                    dblYieldStrength = 36000       'priyanka changed from 79000 to 36000
                    dblPinHole_Combined = Val(IIf(strPinHoleCustomID <> "", strPinHoleCustomID, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd))
                    dblLugGap = Val(Trim(_oFrmREDLCasting.txtLugGap_REDL.Text))
                    dblArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd * (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd - dblPinHole_Combined)
                    strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter.ToString
                    'ANUP 16-11-2010 START
                    'strQuery += ", " + IIf(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEndDL.ToString = "", 0, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEndDL.ToString) + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd.ToString + ", " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap_RodEnd.ToString
                    strQuery += ", " + IIf(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEnd.ToString = "", 0, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEnd.ToString) + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd.ToString + ", " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap_RodEnd.ToString
                    'strQuery += "," + IIf(strPilotDiameter = "", 0, strPilotDiameter.ToString) + "," + dblArea.ToString + "," + Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance - 0.0625).ToString
                    strQuery += "," + IIf(strPilotDiameter = "", 0, strPilotDiameter.ToString) + "," + dblArea.ToString + "," + Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd - 0.0625).ToString
                    'ANUP 16-11-2010 TILL HERE
                    strQuery += "," + dblDistancefromPinholetoRodStop.ToString
                    strQuery += ", " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd.ToString + ", '" + strPinHoleCustomID + "', " + dblPinHole_Combined.ToString + ", " + dblPinHoleCustomUpperTolerance.ToString + ", " + dblPinHoleCustomLowerTolerance.ToString
                    strQuery += ", '" + strGeraseZerk + "', ' " + strGreaseZerkAngle + "', ' " + strSecondGreaseZerkAngle
                    strQuery += "', '" + strMaterial + "', " + dblYieldStrength.ToString + ",'" + strNotes + "', '" + strCost + "', Getdate(),'IFL_PART',0)"  'anup 21-12-2010 
                End If
            Catch ex As Exception
            End Try
            'Aruna:02-4-2010
            Try
                If TableName = UCase("WELDED.BEThreadedBaseNoPort") Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode          '20_10_2010    RAGAVA
                    strDescription = "Base Plug " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OutSidePlugDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadDiameter.ToString + " TH"
                    Dim oSelectedBEDLDataRow As DataRow = Nothing
                    oSelectedBEDLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWallThicknessUpperAndLowerLimits(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure)
                    If Not IsNothing(oSelectedBEDLDataRow) Then
                        If Not IsDBNull(oSelectedBEDLDataRow("WALLTHICKNESSLOWERLIMIT")) Then
                            dblWallThicknessLower = oSelectedBEDLDataRow("WALLTHICKNESSLOWERLIMIT")
                        End If
                        If Not IsDBNull(oSelectedBEDLDataRow("WALLTHICKNESSUPPERLIMIT")) Then
                            dblWallThicknessUpper = oSelectedBEDLDataRow("WALLTHICKNESSUPPERLIMIT")
                        End If
                    End If
                    strMaterial = "CD 1144"
                    dblYieldStrength = 0
                    strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString
                    'strQuery += ", " + IIf(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEndDL.ToString = "", 0, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEndDL.ToString) + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd.ToString + ", " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap_RodEnd.ToString
                    strQuery += "," + dblWallThicknessLower.ToString + "," + dblWallThicknessUpper.ToString + ",'" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadDiameter.ToString + "'"
                    strQuery += "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadLength.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop.ToString
                    'strQuery += ", " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop.ToString + ", " + Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance - 0.0625).ToString
                    strQuery += ", " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop.ToString + ", " + Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance).ToString
                    strQuery += ",'" + strMaterial + "', " + dblYieldStrength.ToString + ",'" + strCost + "', Getdate(),'IFL_PART',0)"  'anup 21-12-2010
                End If
            Catch ex As Exception
            End Try

            '02_04_2010 Aruna

            Try
                If TableName = UCase("WELDED.BEThreadedEndFlushPort") Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode          '20_10_2010    RAGAVA
                    strDescription = "Base Plug " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OutSidePlugDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadDiameter.ToString + " TH"
                    Dim oSelectedBEDLDataRow As DataRow = Nothing
                    oSelectedBEDLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWallThicknessUpperAndLowerLimits(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure)
                    If Not IsNothing(oSelectedBEDLDataRow) Then
                        If Not IsDBNull(oSelectedBEDLDataRow("WALLTHICKNESSLOWERLIMIT")) Then
                            dblWallThicknessLower = oSelectedBEDLDataRow("WALLTHICKNESSLOWERLIMIT")
                        End If
                        If Not IsDBNull(oSelectedBEDLDataRow("WALLTHICKNESSUPPERLIMIT")) Then
                            dblWallThicknessUpper = oSelectedBEDLDataRow("WALLTHICKNESSUPPERLIMIT")
                        End If
                    End If
                    strMaterial = "CD 1144"
                    dblYieldStrength = 0
                    strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString
                    'strQuery += ", " + IIf(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEndDL.ToString = "", 0, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEndDL.ToString) + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd.ToString + ", " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap_RodEnd.ToString
                    strQuery += "," + dblWallThicknessLower.ToString + "," + dblWallThicknessUpper.ToString + ",'" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadDiameter.ToString + "'"
                    strQuery += "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadLength.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop.ToString
                    strQuery += ", " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop.ToString + ", " + Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance - 0.0625).ToString
                    strQuery += ", '" + strMaterial + "', " + dblYieldStrength.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortQuantity.ToString
                    strQuery += ",'" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_BaseEnd.ToString + "', '" + _oFrmPortDetails.cmbPortSizeBaseEnd.Text.ToString + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSecondOrientation.ToString
                    strQuery += ",'" + strNotes + "','" + strCost + "', Getdate(),'IFL_PART',0)" 'anup 21-12-2010
                End If
            Catch ex As Exception
            End Try

            '27_04_2010   RAGAVA       NEW DESIGN
            Try
                If TableName = UCase("BEThreadedEndRaisedPort") Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCode          '20_10_2010    RAGAVA
                    strDescription = "BaseThreaded " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OutSidePlugDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadDiameter.ToString + " TH"
                    Dim oSelectedBEDLDataRow As DataRow = Nothing
                    oSelectedBEDLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWallThicknessUpperAndLowerLimits(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure)
                    If Not IsNothing(oSelectedBEDLDataRow) Then
                        If Not IsDBNull(oSelectedBEDLDataRow("WALLTHICKNESSLOWERLIMIT")) Then
                            dblWallThicknessLower = oSelectedBEDLDataRow("WALLTHICKNESSLOWERLIMIT")
                        End If
                        If Not IsDBNull(oSelectedBEDLDataRow("WALLTHICKNESSUPPERLIMIT")) Then
                            dblWallThicknessUpper = oSelectedBEDLDataRow("WALLTHICKNESSUPPERLIMIT")
                        End If
                    End If
                    strMaterial = "CD 1144"
                    dblYieldStrength = 0

                    strQuery = "INSERT INTO " + TableName + " VALUES('" + strIFLID + "', '" + strPartCode + "', '" + strDescription + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString
                    'strQuery += ", " + IIf(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEndDL.ToString = "", 0, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEndDL.ToString) + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd.ToString + ", " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap_RodEnd.ToString
                    strQuery += "," + dblWallThicknessLower.ToString + "," + dblWallThicknessUpper.ToString + ",'" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadDiameter.ToString + "'"
                    strQuery += "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadLength.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop.ToString
                    strQuery += ", " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop.ToString + ", " + Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance - 0.0625).ToString
                    strQuery += ", '" + strMaterial + "', " + dblYieldStrength.ToString + "," + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortQuantity.ToString
                    strQuery += ",'" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_BaseEnd.ToString + "', '" + _oFrmPortDetails.cmbPortSizeBaseEnd.Text.ToString + "', " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSecondOrientation.ToString
                    strQuery += ",'" + strNotes + "','" + strCost + "', Getdate(),'IFL_PART',0)" 'anup 21-12-2010 
                End If
            Catch ex As Exception
            End Try
            'Till    Here

            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.InsertNewDetails(strQuery)
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in storeData of clsWeldedCylinderFunctionalClass " + ex.Message)
        End Try
    End Sub

#Region "For Designing New Piston"

    '09_11_2009   Ragava
    Public Sub Design_New_Part(ByVal strFilePath As String, ByVal strDesignTableExcelPath As String, ByVal strName As String)
        Try
            'Dim strPartArr() As String = strFilePath.Split("\")
            'Dim strPartName As String = strPartArr(UBound(strPartArr))
            Dim strPartArr
            strPartArr = Split(strFilePath, "\")
            Dim strPartName As String = strPartArr(UBound(strPartArr))
            Dim blnOpened As Boolean
            'UpdateNewDesignParams(strDesignTableExcelPath, strName)
            blnOpened = IFLSolidWorksBaseClassObject.openDocument(strFilePath)
            'swApp.SetUserPreferenceToggle(swUserPreferenceToggle_e.swShowErrorsEveryRebuild, False)

            'IFLSolidWorksBaseClassObject.SetUserPreferenceToggle(swUserPreferenceToggle_e.swShowErrorsEveryRebuild, False) 'vamsi 15-11-2013
            IFLSolidWorksBaseClassObject.SolidWorksApplicationObject.SetUserPreferenceToggle(77, False)
            IFLSolidWorksBaseClassObject.ActivateDocument(strPartName)
            UpdateNewDesignParams(strDesignTableExcelPath, strName)              '22_04_2010   RAGAVA
            IFLSolidWorksBaseClassObject.SaveDocument(strPartName)
        Catch ex As Exception
        End Try
    End Sub

    '24_11_2009    Ragava
    Public Function GetCustomPropertyValue(ByVal PropertyName As String) As String
        IFLSolidWorksBaseClassObject.SolidWorksModel = IFLSolidWorksBaseClassObject.SolidWorksApplicationObject.ActiveDoc  '30_11_2009   Ragava
        GetCustomPropertyValue = IFLSolidWorksBaseClassObject.SolidWorksModel.GetCustomInfoValue("", PropertyName)
        Return GetCustomPropertyValue
    End Function

    Private Sub UpdateAllExcelFiles()

        Dim alExcelList As New ArrayList

        Dim strFilePath As String = "C:\WELD_DESIGN_TABLES\"

        alExcelList.Add(strFilePath & "Base_Cross_Tube.xls")

        alExcelList.Add(strFilePath & "BASE_CROSSTUBE.xls")

        alExcelList.Add(strFilePath & "BASE_END_DOUBLE_LUG.xls")

        alExcelList.Add(strFilePath & "BASE_END_SINGLE_LUG_CAST.xls")

        alExcelList.Add(strFilePath & "BASE_SINGLE_LUG.xls")

        alExcelList.Add(strFilePath & "BASE_SINGLE_LUG_IFL.xls")

        alExcelList.Add(strFilePath & "BASE_U_LUG.xls")

        alExcelList.Add(strFilePath & "BE_Baseplug_IFL.xls")

        alExcelList.Add(strFilePath & "BEC_FL_PI_GR_BASEPLUG.xls")

        alExcelList.Add(strFilePath & "BEC_FL_PI_GR_CROSSTUBE.xls")

        alExcelList.Add(strFilePath & "BEC_FL_PI_GR_DOUBLELUG.xls")

        alExcelList.Add(strFilePath & "BEC_FL_PI_GR_SINGLELUG.xls")
        alExcelList.Add(strFilePath & "BEC_FL_PI_GR_BH.xls")

        alExcelList.Add(strFilePath & "BEC_FL_PI_GR_THREADEDEND.xls")

        alExcelList.Add(strFilePath & "BEC_NO_PO_GR_BASEPLUG.xls")

        alExcelList.Add(strFilePath & "BEC_NO_PO_GR_CROSSTUBE.xls")

        alExcelList.Add(strFilePath & "BEC_NO_PO_GR_DOUBLELUG.xls")

        alExcelList.Add(strFilePath & "BEC_NO_PO_GR_SINGLELUG.xls")
        alExcelList.Add(strFilePath & "BEC_NO_PO_GR_BH.xls")

        alExcelList.Add(strFilePath & "BEC_NO_PO_GR_THREADEDEND.xls")

        alExcelList.Add(strFilePath & "BEC_RA_PI_FI_BASEPLUG.xls")

        alExcelList.Add(strFilePath & "BEC_RA_PI_FI_CROSSTUBE.xls")

        alExcelList.Add(strFilePath & "BEC_RA_PI_FI_DOUBLELUG.xls")

        alExcelList.Add(strFilePath & "BEC_RA_PI_FI_SINGLELUG.xls")
        alExcelList.Add(strFilePath & "BEC_RA_PI_FI_BH.xls")

        alExcelList.Add(strFilePath & "BEC_RA_PI_FI_THREADEDEND.xls")

        alExcelList.Add(strFilePath & "BORE.xls")

        alExcelList.Add(strFilePath & "BUSH_DESIGN.xls")

        alExcelList.Add(strFilePath & "CLEVISPLATE_WITHPORTS.xls")

        alExcelList.Add(strFilePath & "CROSSTUBE_ROD.xls")

        alExcelList.Add(strFilePath & "CYL HEAD.xls")

        alExcelList.Add(strFilePath & "CYL HEAD ASSEMBLY.xls")

        alExcelList.Add(strFilePath & "CYL HEAD WIRE RING.xls")

        alExcelList.Add(strFilePath & "CYL HEAD WIRE RING ASSEMBLY.xls")

        alExcelList.Add(strFilePath & "OLD_WELD_GUI_PARAMETERS.xls")

        alExcelList.Add(strFilePath & "PISTON.xls")

        alExcelList.Add(strFilePath & "PISTON_PTFE.xls")

        alExcelList.Add(strFilePath & "PISTON_PTFE_SUB_ASSEM.xls")

        alExcelList.Add(strFilePath & "PISTON_SUB_ASSEM.xls")

        alExcelList.Add(strFilePath & "ROD_END_CROSS_TUBE_CASTING.xls")

        alExcelList.Add(strFilePath & "ROD_END_DOUBLE_LUG_CAST.xls")

        alExcelList.Add(strFilePath & "ROD_END_DOUBLE_LUG_CASTING.xls")

        alExcelList.Add(strFilePath & "ROD_END_SINGLE_LUG_CAST.xls")
        alExcelList.Add(strFilePath & "ROD_END_BH_CAST.xls")

        alExcelList.Add(strFilePath & "Rod_Welded.xls")

        alExcelList.Add(strFilePath & "ROD_WELDMENT.xls")

        alExcelList.Add(strFilePath & "SINGLE_LUG_ROD.xls")

        alExcelList.Add(strFilePath & "STD_PISTON.xls")

        alExcelList.Add(strFilePath & "Stop_tube.xls")

        alExcelList.Add(strFilePath & "TUBE_WELDMENT.xls")

        alExcelList.Add(strFilePath & "U_LUG_ROD.xls")

        alExcelList.Add(strFilePath & "WELD_CYLINDER_ASSEMBLY.xls")

        For Each oItem As String In alExcelList


            _oClsExcelClass.objApp.Workbooks.Open(oItem)                            ' priyanka     
            _oClsExcelClass.objApp.ActiveWorkbook.Save()
            '_oClsExcelClass.objBook = _oClsExcelClass.objApp.Workbooks.Open(oItem)
            '_oClsExcelClass.objApp.DisplayAlerts = False
            '_oClsExcelClass.objBook.Save()
            ''_oClsExcelClass.objBook.Close(oItem) 
            '_oClsExcelClass.objBook.Close()            ' till Here  priyanka
            ''ANuP 03-11-2010 START

            _oClsExcelClass.objBook.EnableAutoRecover = False
            '   _oClsExcelClass.objApp.AutoRecover.Enabled = False 'anup 14-03-2011 
            ''ANUP 03-11-2010 TILL HERE

        Next

    End Sub


    '09_11_2009   Ragava
    Public Sub UpdateNewDesignParams(ByVal strDesignTableExcelPath As String, ByVal strName As String)
        Try
            '10_11_2009  Ragava
            CloseExcel()
            _oClsExcelClass.objApp = Nothing
            _oClsExcelClass.checkExcelInstance()
            '10_11_2009  Ragava  Till  Here
            _oClsExcelClass.checkExcelInstance()
            '  _oClsExcelClass.objApp.AutoRecover.Enabled = False 'anup 14-03-2011 
            _oClsExcelClass.objBook = _oClsExcelClass.objApp.Workbooks.Open("C:\WELD_DESIGN_TABLES\WELD_GUI_PARAMETERS.xls")

            ''ANUP 03-11-2010 START
            _oClsExcelClass.objBook.EnableAutoRecover = False
            ''ANUP 03-11-2010 TILL HERE


            _oClsExcelClass.objSheet = _oClsExcelClass.objBook.Worksheets("Welded_Inputs")
            UpdateNewDesignPartParams(strName)
            Try       '30_05_2012    RAGAVA
                UpdateAllExcelFiles()
            Catch ex As Exception

            End Try
            '_oClsExcelClass.objBook = _oClsExcelClass.objApp.Workbooks.Open("C:\WELD_DESIGN_TABLES\WELD_GUI_PARAMETERS.xls")  'priyanka
            _oClsExcelClass.objBook.Save()



            Try
                _oClsExcelClass.objSheet = _oClsExcelClass.objBook.Worksheets("Welded_Inputs2")
                _oClsExcelClass.objSheet.Range("L77").Value() = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign2
                _oClsExcelClass.objSheet.Range("L64").Value() = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd2
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                    _oClsExcelClass.objSheet.Range("L78").Value() = "Cast"
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                    _oClsExcelClass.objSheet.Range("L78").Value() = "Fabricated"
                End If
                '21_06_2012   RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "New" Then
                    _oClsExcelClass.objSheet.Range("L71").Value() = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop      '06_06_2012   RAGAVA
                    _oClsExcelClass.objSheet.Range("L70").Value() = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop     '06_06_2012    RAGAVA
                Else
                    _oClsExcelClass.objSheet.Range("L71").Value() = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop2      '06_06_2012   RAGAVA
                    _oClsExcelClass.objSheet.Range("L70").Value() = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop2     '06_06_2012    RAGAVA
                End If
                'Till   Here
                _oClsExcelClass.objSheet.Range("L76").Value() = ObjClsWeldedCylinderFunctionalClass.FacricatedPart2
                _oClsExcelClass.objSheet.Range("L84").Value() = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateImportOrExisting2
                _oClsExcelClass.objSheet.Range("L7").Value() = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance2
                _oClsExcelClass.objSheet.Range("L9").Value() = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth2
                _oClsExcelClass.objSheet.Range("L42").Value() = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2
                _oClsExcelClass.objSheet.Range("L8").Value() = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth2
                _oClsExcelClass.objSheet.Range("L14").Value() = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateCode2
                _oClsExcelClass.objSheet.Range("L39").Value() = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness2
                _oClsExcelClass.objSheet.Range("L43").Value() = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD2
                _oClsExcelClass.objSheet.Range("L93").Value() = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2
                _oClsExcelClass.objBook.Save()

                'ROD END updation
                '24_07_2012   RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Cross Tube" Then
                    _oClsExcelClass.objSheet.Range("O11").Value() = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration
                    _oClsExcelClass.objSheet.Range("O12").Value() = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd2
                    _oClsExcelClass.objSheet.Range("O13").Value() = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd2
                    _oClsExcelClass.objSheet.Range("O14").Value() = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd2
                    _oClsExcelClass.objSheet.Range("O15").Value() = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd
                    _oClsExcelClass.objSheet.Range("O16").Value() = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd2
                    _oClsExcelClass.objSheet.Range("O42").Value() = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateCode2
                    _oClsExcelClass.objSheet.Range("O43").Value() = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness2
                    _oClsExcelClass.objSheet.Range("O52").Value() = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD_RodEnd2
                End If
            Catch ex As Exception

            End Try


            _oClsExcelClass.objApp.DisplayAlerts = False     '15_10_2012   RAGAVA
            '_oClsExcelClass.objBook.Close()
            ' _oClsExcelClass.objApp.Workbooks.Close()  ' Priyanka
            _oClsExcelClass.objApp.DisplayAlerts = True      '15_10_2012   RAGAVA
            _oClsExcelClass.objApp.Quit()
            CloseExcel()
            _oClsExcelClass.objApp = Nothing
            If Not strDesignTableExcelPath Is Nothing Then
                _oClsExcelClass.checkExcelInstance()
                _oClsExcelClass.objBook = _oClsExcelClass.objApp.Workbooks.Open(strDesignTableExcelPath)
                _oClsExcelClass.objSheet = _oClsExcelClass.objBook.Worksheets("Sheet1")
                _oClsExcelClass.objBook.Save()
                _oClsExcelClass.objBook.Close()
                _oClsExcelClass.objApp.Quit()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub checkAndCreateDirectory(ByVal directoryName As String)
        If Directory.Exists(directoryName) = False Then
            ' Directory.Delete(directoryName, True)
            Directory.CreateDirectory(directoryName)
        End If

    End Sub

    Public Sub UpdateNewDesignPartParams(ByVal strName As String)
        Try
            Dim oNavigatedFormName As New ArrayList
            For Each oItem As Object In FormNavigationOrder
                oNavigatedFormName.Add(oItem(EOrderOfFormNavigationArraylist.CurrentFormObject))
            Next
            For Each oNavigatedFormItem As Object In oNavigatedFormName
                Try
                    For Each oControlValue As Object In oNavigatedFormItem.ControlsData

                        If Not IsNothing(oControlValue(EExcel_GUIControls_Relation.GUIControlValue)) Then
                            ObjClsExcelClass.objSheet.Range(oControlValue(EExcel_GUIControls_Relation.ExcelRange)).Value = oControlValue(EExcel_GUIControls_Relation.GUIControlValue).ToString
                        End If
                    Next
                Catch ex As Exception
                End Try
            Next

            'If UCase(strName) = UCase("GenerateULug") Then           '20_11_2009   Ragava
            '    UpdateHashTableValues(_htNewDesignPartParams, "Swing Clearance", Trim(_oFrmDLFabrication.txtSwingClearance_DesignULug.Text))
            '    UpdateHashTableValues(_htNewDesignPartParams, "Lug width", Trim(_oFrmDLFabrication.txtLugWidth_DesignULug.Text))
            '    UpdateHashTableValues(_htNewDesignPartParams, "Lug Thickness", Trim(_oFrmDLFabrication.txtLugThickness_DesignULug.Text))
            '    UpdateHashTableValues(_htNewDesignPartParams, "Lug Gap", Trim(_oFrmDLFabrication.txtLugGap_DesignULug.Text))
            '    UpdateHashTableValues(_htNewDesignPartParams, "PinHoleSize", Trim(_oFrmDLFabrication.txtPinHoleSize_DesignULug.Text))
            '    UpdateHashTableValues(_htNewDesignPartParams, "Area Required", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired)
            '    UpdateHashTableValues(_htNewDesignPartParams, "Y required", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.YRequired)

            'ElseIf UCase(strName) = UCase("NewBasePlugPartCopied") Then  '04_12_2009   Ragava
            '    UpdateHashTableValues(_htNewDesignPartParams, "Swing Clearance", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance)
            '    UpdateHashTableValues(_htNewDesignPartParams, "BASE PLUG OD", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BasePlugOD)
            '    UpdateHashTableValues(_htNewDesignPartParams, "BASE END_ACROSS FLAT", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlatWidth)
            '    UpdateHashTableValues(_htNewDesignPartParams, "BASE END_FLAT LENGTH", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlatHeight)
            '    UpdateHashTableValues(_htNewDesignPartParams, "PinHoleSize", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BasePlugPinHoleSize)
            '    UpdateHashTableValues(_htNewDesignPartParams, "Y required", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.YRequired)

            'ElseIf UCase(strName) = UCase("NewSingleLugCastingPartCopied") Then
            '    UpdateHashTableValues(_htNewDesignPartParams, "Swing Clearance", Trim(_oFrmSLDesignACasting.txtSwingClearance.Text))
            '    UpdateHashTableValues(_htNewDesignPartParams, "Lug width", Trim(_oFrmSLDesignACasting.txtLugWidth.Text))
            '    UpdateHashTableValues(_htNewDesignPartParams, "Lug Thickness", Trim(_oFrmSLDesignACasting.txtLugThickness.Text))
            '    UpdateHashTableValues(_htNewDesignPartParams, "Lug Gap", Trim(_oFrmDLDesignACasting.txtLugGap.Text))
            '    UpdateHashTableValues(_htNewDesignPartParams, "PinHoleSize", Trim(_oFrmSLDesignACasting.txtPinHoleSize.Text))
            '    UpdateHashTableValues(_htNewDesignPartParams, "Area Required", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired)
            '    UpdateHashTableValues(_htNewDesignPartParams, "Y required", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.YRequired)

            'ElseIf UCase(strName) = UCase("NewDoubleLugCastingPartCopied") Then
            '    UpdateHashTableValues(_htNewDesignPartParams, "Swing Clearance", Trim(_oFrmDLDesignACasting.txtSwingClearance.Text))
            '    UpdateHashTableValues(_htNewDesignPartParams, "Lug width", Trim(_oFrmDLDesignACasting.txtLugWidth.Text))
            '    UpdateHashTableValues(_htNewDesignPartParams, "Lug Thickness", Trim(_oFrmDLDesignACasting.txtLugThickness.Text))
            '    UpdateHashTableValues(_htNewDesignPartParams, "Lug Gap", Trim(_oFrmDLDesignACasting.txtLugGap.Text))
            '    UpdateHashTableValues(_htNewDesignPartParams, "PinHoleSize", Trim(_oFrmDLDesignACasting.txtPinHoleSize.Text))
            '    UpdateHashTableValues(_htNewDesignPartParams, "Area Required", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired)
            '    UpdateHashTableValues(_htNewDesignPartParams, "Y required", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.YRequired)

            'ElseIf UCase(strName) = UCase("NewSingleLugFabrication") Then
            '    UpdateHashTableValues(_htNewDesignPartParams, "Swing Clearance", Trim(_oFrmSLFabrication.txtSwingClearance_DesignSingleLug.Text))
            '    UpdateHashTableValues(_htNewDesignPartParams, "Lug width", Trim(_oFrmSLFabrication.txtLugWidth_DesignSingleLug.Text))
            '    UpdateHashTableValues(_htNewDesignPartParams, "Lug Thickness", Trim(_oFrmSLFabrication.txtLugThickness_DesignSingleLug.Text))
            '    UpdateHashTableValues(_htNewDesignPartParams, "Lug Gap", Trim(_oFrmSLFabrication.txtLugGap.Text))
            '    UpdateHashTableValues(_htNewDesignPartParams, "PinHoleSize", Trim(_oFrmSLFabrication.txtPinHoleSize_DesignSingleLug.Text))
            '    UpdateHashTableValues(_htNewDesignPartParams, "Area Required", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired)
            '    UpdateHashTableValues(_htNewDesignPartParams, "Y required", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.YRequired)

            'ElseIf UCase(strName) = UCase("NewCrossTubeFabrication") Then
            '    UpdateHashTableValues(_htNewDesignPartParams, "CROSS TUBE WIDTH", Trim(_oFrmCTFabrication.txtCrossTubeWidth_DesignCrossTube.Text))
            '    UpdateHashTableValues(_htNewDesignPartParams, "PINHOLESIZE", Trim(_oFrmCTFabrication.txtPinHoleSize_DesignCrossTube.Text))
            '    UpdateHashTableValues(_htNewDesignPartParams, "GREASE ZERCS", Trim(_oFrmCTFabrication.txtGreaseZerk.Text))
            '    UpdateHashTableValues(_htNewDesignPartParams, "ANGLE OF GREASSE ZERC 1", Trim(_oFrmCTFabrication.txtRequiredAngle1.Text))
            '    UpdateHashTableValues(_htNewDesignPartParams, "ANGLE OF GREASSE ZERC 2", Trim(_oFrmCTFabrication.txtRequiredAngle2.Text))
            '    UpdateHashTableValues(_htNewDesignPartParams, "CROSS TUBE OD", Trim(_oFrmCTFabrication.txtCrossTubeOD_DesignCrossTube.Text))

            'ElseIf UCase(strName) = UCase("BaseEndSingleLugFound") Then
            '    UpdateHashTableValues(_htNewDesignPartParams, "Swing Clearance", Trim(_oFrmSLCastingYes.txtSwingClearance.Text))
            '    UpdateHashTableValues(_htNewDesignPartParams, "Lug width", Trim(_oFrmSLCastingYes.txtLugsWidth.Text))
            '    UpdateHashTableValues(_htNewDesignPartParams, "Lug Thickness", Trim(_oFrmSLCastingYes.txtLugThickness.Text))
            '    UpdateHashTableValues(_htNewDesignPartParams, "PinHoleSize", Trim(_oFrmSLCastingYes.txtPinHoleSize.Text))
            '    UpdateHashTableValues(_htNewDesignPartParams, "Area Required", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired)
            '    UpdateHashTableValues(_htNewDesignPartParams, "Y required", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.YRequired)

            '    '12_02_2010 Aruna Start

            'ElseIf UCase(strName) = UCase("CrossTubeCastBaseEnd") Then
            '    UpdateHashTableValues(_htNewDesignPartParams, "CROSS TUBE WIDTH", Trim(_oFrmCTDesignACasting.txtCrossTubeWidth_DesignCrossTubeCasting.Text))
            '    UpdateHashTableValues(_htNewDesignPartParams, "PINHOLESIZE", Trim(_oFrmCTDesignACasting.txtPinHoleSize_DesignCrossTubeCasting.Text))
            '    UpdateHashTableValues(_htNewDesignPartParams, "GREASE ZERCS", Trim(_oFrmTubeDetails.cmbGreaseZercs.Text))
            '    UpdateHashTableValues(_htNewDesignPartParams, "ANGLE OF GREASSE ZERC 1", Trim(_oFrmTubeDetails.txtAngleOfGreaseZercs1.Text))
            '    UpdateHashTableValues(_htNewDesignPartParams, "ANGLE OF GREASSE ZERC 2", Trim(_oFrmTubeDetails.txtAngleOfGreaseZercs2.Text))
            '    UpdateHashTableValues(_htNewDesignPartParams, "Area Required", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired)
            '    UpdateHashTableValues(_htNewDesignPartParams, "Y required", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.YRequired)
            '    Dim dblCrossTubeOD As Double
            '    dblCrossTubeOD = ((4 / 3) * (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired / Val(Trim(_oFrmCTDesignACasting.txtCrossTubeWidth_DesignCrossTubeCasting.Text)))) + Val(Trim(_oFrmCTDesignACasting.txtPinHoleSize_DesignCrossTubeCasting.Text))
            '    If dblCrossTubeOD >= Val(Trim(_oFrmCTDesignACasting.txtPinHoleSize_DesignCrossTubeCasting.Text)) + 0.5 Then
            '        UpdateHashTableValues(_htNewDesignPartParams, "CROSS TUBE OD", dblCrossTubeOD)
            '    Else
            '        UpdateHashTableValues(_htNewDesignPartParams, "CROSS TUBE OD", Val(Trim(_oFrmCTDesignACasting.txtPinHoleSize_DesignCrossTubeCasting.Text)) + 0.5)
            '    End If

            'ElseIf UCase(strName) = UCase("CrossTubeCastRodEnd") Then
            '    UpdateHashTableValues(_htNewDesignPartParams, "CROSS TUBE WIDTH", Trim(_oFrmDesignACasting_RECT.txtCrossTubeWidth_DesignCrossTubeCasting_RECT.Text))
            '    UpdateHashTableValues(_htNewDesignPartParams, "PINHOLESIZE", Trim(_oFrmDesignACasting_RECT.txtPinHoleSize_DesignCrossTubeCasting_RECT.Text))
            '    UpdateHashTableValues(_htNewDesignPartParams, "GREASE ZERCS", Trim(_oFrmRodEndConfiguration.cmbGreaseZercs_RodEnd.Text))
            '    UpdateHashTableValues(_htNewDesignPartParams, "ANGLE OF GREASSE ZERC 1", Trim(_oFrmRodEndConfiguration.txtAngleOfGreaseZercs1_RodEnd.Text))
            '    UpdateHashTableValues(_htNewDesignPartParams, "ANGLE OF GREASSE ZERC 2", Trim(_oFrmRodEndConfiguration.txtAngleOfGreaseZercs2_RodEnd.Text))
            '    Dim dblCrossTubeOD As Double
            '    dblCrossTubeOD = ((4 / 3) * (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired_RodEnd / Val(Trim(_oFrmDesignACasting_RECT.txtCrossTubeWidth_DesignCrossTubeCasting_RECT.Text)))) + Val(Trim(_oFrmDesignACasting_RECT.txtPinHoleSize_DesignCrossTubeCasting_RECT.Text))
            '    If dblCrossTubeOD >= Val(Trim(_oFrmDesignACasting_RECT.txtPinHoleSize_DesignCrossTubeCasting_RECT.Text)) + 0.5 Then
            '        UpdateHashTableValues(_htNewDesignPartParams, "CROSS TUBE OD", dblCrossTubeOD)
            '    Else
            '        UpdateHashTableValues(_htNewDesignPartParams, "CROSS TUBE OD", Val(Trim(_oFrmDesignACasting_RECT.txtPinHoleSize_DesignCrossTubeCasting_RECT.Text)) + 0.5)
            '    End If
            '    '12_02_2010 Aruna End
            '    UpdateHashTableValues(_htNewDesignPartParams, "Area Required", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired_RodEnd)
            '    UpdateHashTableValues(_htNewDesignPartParams, "Y required", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.YRequired_RodEnd)



            '26_02_2010   RAGAVA  Need to check with Sandeep
            '' ''if
            '' ''    '17_02_2010   RAGAVA
            ''  ElseIf UCase(strName) = UCase("NewDoubleLugWeldedLathePartCopied") Then
            ''    UpdateHashTableValues(_htNewDesignPartParams, "RW_ROD END CONFIGURATION", "Double Lug")
            ''    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRodEndConfigurationDesign = "" Then
            ''        UpdateHashTableValues(_htNewDesignPartParams, "RW_ROD END CONFIGURATION DESIGN", "NewDesign")
            ''    Else
            ''        UpdateHashTableValues(_htNewDesignPartParams, "RW_ROD END CONFIGURATION DESIGN", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRodEndConfigurationDesign)
            ''    End If
            ''    UpdateHashTableValues(_htNewDesignPartParams, "RW_PIN HOLE", Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmRodEndConfiguration.cmbPinHole_RodEnd.Text))
            ''    UpdateHashTableValues(_htNewDesignPartParams, "RW_PIN HOLE TYPE", Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmRodEndConfiguration.cmbPinHoleSizeType_RodEnd.Text))
            ''    UpdateHashTableValues(_htNewDesignPartParams, "RW_ROD END CONFIGURATION DESIGNTYPE", ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated)
            ''    UpdateHashTableValues(_htNewDesignPartParams, "RW_WELD TYPE", ObjClsWeldedCylinderFunctionalClass.strManual_Lathe)
            ''    UpdateHashTableValues(_htNewDesignPartParams, "RW_AREA REQUIRED", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired_RodEnd)
            ''    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop = 0.36 + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
            ''    UpdateHashTableValues(_htNewDesignPartParams, "RW_RODEND PIN HOLE TO ROD STOP DISTANCE", (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RetractedLength - ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop - ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DistanceFromPinholetoRodStop) + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop)


            ''    Dim dblLugDiagonal As Double = Math.Sqrt(Math.Pow(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd, 2) + Math.Pow(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap_RodEnd + (2 * ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd), 2))
            ''    If ObjClsWeldedCylinderFunctionalClass.strManual_Lathe = "Manual" Then
            ''        UpdateHashTableValues(_htNewDesignPartParams, "RW_PILOT HOLE DIAMETER", 0.1)
            ''    ElseIf ObjClsWeldedCylinderFunctionalClass.strManual_Lathe = "Lathe" Then
            ''        If dblLugDiagonal > 2.5 Then
            ''            UpdateHashTableValues(_htNewDesignPartParams, "RW_PILOT HOLE DIAMETER", 0.375)
            ''        Else
            ''            UpdateHashTableValues(_htNewDesignPartParams, "RW_PILOT HOLE DIAMETER", 0.188)
            ''        End If
            ''    End If

            ''    'Available only for Fabrication
            ''    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd = 1.25 Or ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd = 1.5 Then
            ''        UpdateHashTableValues(_htNewDesignPartParams, "RW_U LUG TOP RADIUS", 1)
            ''    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd = 1.75 Or ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd = 2.0 Then
            ''        UpdateHashTableValues(_htNewDesignPartParams, "RW_U LUG TOP RADIUS", 1.25)
            ''    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd = 2.5 Or ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd = 3.0 Then
            ''        UpdateHashTableValues(_htNewDesignPartParams, "RW_U LUG TOP RADIUS", 1.75)
            ''    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd = 2.5 Then
            ''        UpdateHashTableValues(_htNewDesignPartParams, "RW_U LUG TOP RADIUS", 2)
            ''    End If
            ''    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd <= 0.5 Then
            ''        UpdateHashTableValues(_htNewDesignPartParams, "RW_U LUG BEND RADIUS", 0.25)
            ''    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd <= 0.63 Then
            ''        UpdateHashTableValues(_htNewDesignPartParams, "RW_U LUG BEND RADIUS", 0.5)
            ''    Else 'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd <= 0.75 Then
            ''        UpdateHashTableValues(_htNewDesignPartParams, "RW_U LUG BEND RADIUS", 0.625)
            ''    End If



            ''ElseIf UCase(strName) = UCase("NewDoubleLugCastPartCopied") Then
            ''    UpdateHashTableValues(_htNewDesignPartParams, "RW_ROD END CONFIGURATION", "Double Lug")
            ''    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRodEndConfigurationDesign = "" Then
            ''        UpdateHashTableValues(_htNewDesignPartParams, "RW_ROD END CONFIGURATION DESIGN", "NewDesign")
            ''    Else
            ''        UpdateHashTableValues(_htNewDesignPartParams, "RW_ROD END CONFIGURATION DESIGN", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRodEndConfigurationDesign)
            ''    End If
            ''    UpdateHashTableValues(_htNewDesignPartParams, "RW_PIN HOLE", Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmRodEndConfiguration.cmbPinHole_RodEnd.Text))
            ''    UpdateHashTableValues(_htNewDesignPartParams, "RW_PIN HOLE TYPE", Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmRodEndConfiguration.cmbPinHoleSizeType_RodEnd.Text))
            ''    UpdateHashTableValues(_htNewDesignPartParams, "RW_ROD END CONFIGURATION DESIGNTYPE", ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated)
            ''    UpdateHashTableValues(_htNewDesignPartParams, "RW_WELD TYPE", ObjClsWeldedCylinderFunctionalClass.strManual_Lathe)
            ''    UpdateHashTableValues(_htNewDesignPartParams, "RW_AREA REQUIRED", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired_RodEnd)
            ''    UpdateHashTableValues(_htNewDesignPartParams, "RW_RODEND PIN HOLE TO ROD STOP DISTANCE", (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RetractedLength - ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop - ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DistanceFromPinholetoRodStop) + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop)
            ''    Dim dblLugDiagonal As Double = Math.Sqrt(Math.Pow(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd, 2) + Math.Pow(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap_RodEnd + (2 * ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd), 2))
            ''    If ObjClsWeldedCylinderFunctionalClass.strManual_Lathe = "Manual" Then
            ''        UpdateHashTableValues(_htNewDesignPartParams, "RW_PILOT HOLE DIAMETER", 0.1)
            ''    ElseIf ObjClsWeldedCylinderFunctionalClass.strManual_Lathe = "Lathe" Then
            ''        If dblLugDiagonal > 2.5 Then
            ''            UpdateHashTableValues(_htNewDesignPartParams, "RW_PILOT HOLE DIAMETER", 0.375)
            ''        Else
            ''            UpdateHashTableValues(_htNewDesignPartParams, "RW_PILOT HOLE DIAMETER", 0.188)
            ''        End If
            ''    End If
            ''End If
            'Till   Here
        Catch ex As Exception
        End Try
    End Sub

    '09_11_2009   Ragava
    Public Sub UpdateHashTableValues(ByVal hashTab As Hashtable, ByVal key As String, ByVal value As Object, Optional ByVal DefaultValue As Object = "")
        If hashTab.Contains(key) = True Then
            hashTab(key) = value
        Else
            hashTab.Add(key, value)
        End If
    End Sub

#End Region

#Region "Excel Functions"

    Public Function CheckForExcel() As Boolean
        CheckForExcel = True
        Dim strSubKey As String = "Excel.Application"
        Dim oKey As RegistryKey = Registry.ClassesRoot
        Dim oSubKey As RegistryKey = oKey.OpenSubKey("Word.Application")
        If Not IsNothing(oSubKey) Then
            oKey.Close()
            Return True
        Else
            MessageBox.Show("Error with Excel" + vbCrLf + "Kindly check whether the Excel is installed" + vbCrLf + _
             "You can proceed with application but, Excel report will not be generated", "Error with Excel", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2)
            Return False
        End If
    End Function

    Public Function GetPathForExcel() As Boolean
        GetPathForExcel = False
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.Filter = "Excel files (*.xls)|*.xls"
        SaveFileDialog.Title = "Save Report"
        SaveFileDialog.CheckFileExists = False
        SaveFileDialog.FilterIndex = 2
        SaveFileDialog.RestoreDirectory = True
        If SaveFileDialog.ShowDialog() = DialogResult.OK Then
            If Not SaveFileDialog.FileName.Equals("") Then
                _strchildExcelPath = SaveFileDialog.FileName.ToString()
                GetPathForExcel = True
            End If
        Else
            GetPathForExcel = False
        End If
    End Function

    Public Function CopyTheMasterFile() As Boolean
        CopyTheMasterFile = False
        Dim blnIsProcessSuccessfull As Boolean = False
        Dim sErrorMessage As String = "Report Master file does not exist"
        CloseExcel()
        ' This function checks if the master report format exists
        If IsMasterReportFileExists() Then
            Try
                ' Check if file already exists
                If File.Exists(_strchildExcelPath) Then
                    If Not IsNothing(ExApplication) Then
                        ExApplication = Nothing
                    End If
                    CloseExcel()
                    ' Delete the existing file first
                    File.Delete(_strchildExcelPath)
                    System.Threading.Thread.Sleep(1000)
                End If
                File.Copy(_strMotherExcelPath, _strchildExcelPath)
                CopyTheMasterFile = True
                blnIsProcessSuccessfull = True
            Catch oException As Exception
                sErrorMessage = "Unable to copy the source file" + vbCrLf + vbCrLf + oException.Message
            End Try
        End If
        If Not blnIsProcessSuccessfull Then
            CopyTheMasterFile = False
            MessageBox.Show(sErrorMessage, "Error in file creation", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return blnIsProcessSuccessfull
    End Function

    'ONSITE:Excel- displaying the message before closing the excel documents
    Public Sub CloseExcel(Optional ByVal blnStatus As Boolean = False)
        Dim Count As Integer = 0
        For Each oProcess As Process In Process.GetProcesses
            If oProcess.ProcessName = "EXCEL" Then
                If blnStatus = True AndAlso Count = 0 Then
                    Dim strMessage As String = "Please Save Your Excel Documents and Then Click OK."
                    If MessageBox.Show(strMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) = DialogResult.OK Then
                    End If
                End If
                oProcess.Kill()
                Application.DoEvents()
                System.Threading.Thread.Sleep(1000)
                Count += 1
            End If
        Next
        GC.Collect()
    End Sub

    Public Function IsMasterReportFileExists() As Boolean
        IsMasterReportFileExists = File.Exists(_strMotherExcelPath)
    End Function

    Public Function CreateExcel() As Boolean
        CreateExcel = True
        Try
            _oExApplication = New Excel.Application
            _oExApplication.Visible = False
            _oExWorkbook = _oExApplication.Workbooks.Open(_strchildExcelPath)
            _oExSheetGUI = _oExApplication.Sheets(1)
        Catch ex As Exception
            CreateExcel = False
            MessageBox.Show("Unable to open Excel sheet", "Information", MessageBoxButtons.OK, _
            MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Try
    End Function

    Public Sub WriteGUIDataToExcel()
        Dim oNavigatedFormName As New ArrayList
        For Each oItem As Object In FormNavigationOrder
            oNavigatedFormName.Add(oItem(EOrderOfFormNavigationArraylist.CurrentFormObject))
        Next
        For Each oNavigatedFormItem As Object In oNavigatedFormName
            Try
                For Each oControlValue As Object In oNavigatedFormItem.ControlsData
                    If Not IsNothing(oControlValue(EExcel_GUIControls_Relation.GUIControlValue)) Then
                        _oExSheetGUI.Range(oControlValue(EExcel_GUIControls_Relation.ExcelRange)).Value = oControlValue(EExcel_GUIControls_Relation.GUIControlValue).ToString
                    End If
                Next
            Catch ex As Exception

            End Try
            'If oNavigatedFormItem.name.Equals(_oCurrentForm.name) OrElse oNavigatedFormItem.name.Equals("frmRodEndConfiguration") Then
            '    Exit For
            'End If
        Next
        _oExWorkbook.Save()
    End Sub

#End Region

    Public Sub generateMainAssembly()
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SearchFound = "" Then
            UpdateNewDesignParams("", "")
        Else
            UpdateNewDesignParams("", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SearchFound)
        End If
        Try
            KillAllSolidWorksServices()
            IFLSolidWorksBaseClassObject.SolidWorksApplicationObject = Nothing
        Catch ex As Exception

        End Try
        oExcelClass.getExcelFiles("C:\WELD_DESIGN_TABLES")

        Try

            ObjClsWeldedCylinderFunctionalClass.CloseExcel()
            IFLSolidWorksBaseClassObject.ConnectSolidWorks()       '02_03_2010   RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "NewDesign" Then
                IFLSolidWorksBaseClassObject.AddConfiguration("X:\WELDED_STD_PARTS\" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName + ".SLDPRT", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.htStoreConfigurationCodeNumbers(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName), "", "")
            End If
        Catch ex As Exception

        End Try
        Try

            ObjClsWeldedCylinderFunctionalClass.CloseExcel()
            If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = "NewDesign" Then
                IFLSolidWorksBaseClassObject.AddConfiguration("X:\WELDED_STD_PARTS\" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName + ".SLDPRT", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.htStoreConfigurationCodeNumbers(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName), "", "")
            End If
        Catch ex As Exception

        End Try
        Try
            ObjClsWeldedCylinderFunctionalClass.CloseExcel()

        Catch ex As Exception

        End Try
        Try

            IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BORE")
            'Aruna 19_3_2010
            ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BORE", True)

        Catch ex As Exception
        End Try

        '12_08_2010   RAGAVA
        'If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
        Try
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "New" Then          '22_06_2010  RAGAVA
                '21_12_2010    RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.chkRephasing.Checked = True Then
                    'COLLAR_REPHAZING
                    File.Delete(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\COLLAR\END_COLLAR_90.SLDPRT")
                    File.Delete(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\COLLAR\END_COLLAR_90.SLDDRW")
                    File.Delete(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\COLLAR\END_COLLAR.SLDPRT")
                    File.Delete(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\COLLAR\END_COLLAR.SLDDRW")
                Else
                    If UCase(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleRodEnd.SelectedItem) = "STRAIGHT" Then
                        File.Delete(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\COLLAR\END_COLLAR_90.SLDPRT")
                        File.Delete(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\COLLAR\END_COLLAR_90.SLDDRW")
                    Else
                        File.Delete(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\COLLAR\END_COLLAR.SLDPRT")
                        File.Delete(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\COLLAR\END_COLLAR.SLDDRW")
                    End If
                    File.Delete(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\COLLAR\COLLAR_REPHAZING.SLDPRT")
                    If File.Exists(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\COLLAR\COLLAR_REPHAZING.SLDDRW") Then
                        File.Delete(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\COLLAR\COLLAR_REPHAZING.SLDDRW")
                    End If
                End If
                'Till   Here
                ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\COLLAR", True)
                IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\COLLAR")
            End If
            'Till   Here
        Catch ex As Exception

        End Try

        '24_01_2012    RAGAVA
        Try
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType <> "Conventional" Then
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected = True AndAlso UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
                    If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                        ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\CLEVIS_PLATE_WR", True)
                        IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\CLEVIS_PLATE_WR")
                    ElseIf ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "90" Then           '23_06_2010      RAGAVA
                        ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\CLEVIS_PLATE_WR_90", True)
                        IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\CLEVIS_PLATE_WR_90")
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
        'Till   Here

        'If Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign) <> "Existing" Then          '18_08_2010     RAGAVA
        'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" AndAlso Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign) <> "Existing" Then           '17_10_2012   RAGAVA
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Single Lug" Then
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnNewCastingGenerated = True Then           '17_10_2012   RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port In Tube" AndAlso _
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "OUTSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_NO_PO_GR_SINGLELUG", True)
                    '17_10_2012   RAGAVA
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_NO_PO_GR_SINGLELUG"
                    Else
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_NO_PO_GR_SINGLELUG"
                    End If
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_NO_PO_GR_SINGLELUG"
                    'Till   Here
                    IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_NO_PO_GR_SINGLELUG")           '29_03_2010   RAGAVA
                ElseIf UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "FLUSHED" AndAlso _
                                 ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "INSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PI_GR_SINGLELUG", True)
                    '17_10_2012   RAGAVA
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_FL_PI_GR_SINGLELUG"
                    Else
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_FL_PI_GR_SINGLELUG"
                    End If
                    'Till   Here
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_FL_PI_GR_SINGLELUG"            '19_10_2010    RAGAVA
                    IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PI_GR_SINGLELUG")           '29_03_2010   RAGAVA
                ElseIf UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "FLUSHED" AndAlso _
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "OUTSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PO_GR_SINGLELUG", True)
                    '17_10_2012   RAGAVA
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_FL_PO_GR_SINGLELUG"
                    Else
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_FL_PO_GR_SINGLELUG"
                    End If
                    'Till   Here
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_FL_PO_GR_SINGLELUG"            '19_10_2010    RAGAVA
                    IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PO_GR_SINGLELUG")           '29_03_2010   RAGAVA
                ElseIf UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" AndAlso _
                       ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "INSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_GR_SINGLELUG", True)
                    '17_10_2012   RAGAVA
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_GR_SINGLELUG"
                    Else
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_RA_PI_GR_SINGLELUG"
                    End If
                    'Till   Here
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_GR_SINGLELUG"            '19_10_2010    RAGAVA
                    IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_GR_SINGLELUG")           '29_03_2010   RAGAVA
                ElseIf UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" AndAlso _
                  ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "INSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "FILLET" Then
                    'ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_SINGLELUG", True)
                    'IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_SINGLELUG")           '29_03_2010   RAGAVA
                    '19_05_2010   RAGAVA     NEW DESIGN
                    If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                        ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_SINGLELUG", True)
                        '17_10_2012   RAGAVA
                        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_SINGLELUG"
                        Else
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_RA_PI_FI_SINGLELUG"
                        End If
                        'Till   Here
                        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_SINGLELUG"            '19_10_2010    RAGAVA
                        IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_SINGLELUG")           '29_03_2010   RAGAVA
                    Else
                        ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_SINGLELUG_90", True)
                        '17_10_2012   RAGAVA
                        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_SINGLELUG_90"
                        Else
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_RA_PI_FI_SINGLELUG_90"
                        End If
                        'Till   Here
                        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_SINGLELUG_90"            '19_10_2010    RAGAVA
                        IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_SINGLELUG_90")           '29_03_2010   RAGAVA
                    End If
                    'Till   here
                End If
            End If
            '09_07_2012   RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnNewFabricationGenerated = True Then           '17_10_2012   RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected = True OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected2 = True Then       '05_07_2012   RAGAVA
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BASE_SINGLE_LUG", True)
                    IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BASE_SINGLE_LUG")           '29_03_2010   RAGAVA
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected = True Then
                        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "Base_Single_Lug_IFL"     'VAMSI 28-01-2015       '19_10_2010    RAGAVA
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BASE_SINGLE_LUG_IFL"
                    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected2 = True Then
                        ''ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "Base_Single_Lug_IFL"   'VAMSI 28-01-2015         '19_10_2010    RAGAVA
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BASE_SINGLE_LUG_IFL"
                    End If
                End If
            End If
        End If

        'MANJULA 13-03-2012
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "BH" Then
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnNewCastingGenerated = True Then           '17_10_2012   RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port In Tube" AndAlso _
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "OUTSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_NO_PO_GR_BH", True)
                    '17_10_2012   RAGAVA
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_NO_PO_GR_BH"
                    Else
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_NO_PO_GR_BH"
                    End If
                    'Till   Here
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_NO_PO_GR_BH"            '19_10_2010    RAGAVA
                    IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_NO_PO_GR_BH")           '29_03_2010   RAGAVA
                ElseIf UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "FLUSHED" AndAlso _
                                 ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "INSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PI_GR_BH", True)
                    '17_10_2012   RAGAVA
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_FL_PI_GR_BH"
                    Else
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_FL_PI_GR_BH"
                    End If
                    'Till   Here
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_FL_PI_GR_BH"            '19_10_2010    RAGAVA
                    IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PI_GR_BH")           '29_03_2010   RAGAVA
                ElseIf UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "FLUSHED" AndAlso _
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "OUTSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PO_GR_BH", True)
                    '17_10_2012   RAGAVA
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_FL_PO_GR_BH"
                    Else
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_FL_PO_GR_BH"
                    End If
                    'Till   Here
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_FL_PO_GR_BH"            '19_10_2010    RAGAVA
                    IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PO_GR_BH")           '29_03_2010   RAGAVA
                ElseIf UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" AndAlso _
                       ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "INSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_GR_BH", True)
                    '17_10_2012   RAGAVA
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_GR_BH"
                    Else
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_RA_PI_GR_BH"
                    End If
                    'Till   Here
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_GR_BH"            '19_10_2010    RAGAVA
                    IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_GR_BH")           '29_03_2010   RAGAVA
                ElseIf UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" AndAlso _
                  ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "INSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "FILLET" Then
                    'ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_SINGLELUG", True)
                    'IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_SINGLELUG")           '29_03_2010   RAGAVA
                    '19_05_2010   RAGAVA     NEW DESIGN
                    If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                        ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_BH", True)
                        '17_10_2012   RAGAVA
                        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_BH"
                        Else
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_RA_PI_FI_BH"
                        End If
                        'Till   Here
                        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_BH"            '19_10_2010    RAGAVA
                        IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_BH")           '29_03_2010   RAGAVA
                    Else
                        ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_BH_90", True)
                        '17_10_2012   RAGAVA
                        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_BH_90"
                        Else
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_RA_PI_FI_BH_90"
                        End If
                        'Till   Here
                        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_BH_90"            '19_10_2010    RAGAVA
                        IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_BH_90")           '29_03_2010   RAGAVA
                    End If
                    'Till   here
                End If
            End If
            '09_07_2012  RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnNewFabricationGenerated = True Then           '17_10_2012   RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected = True OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected2 = True Then      '05_07_2012   RAGAVA
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BASE_BH_LUG", True)
                    IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BASE_BH_LUG")           '29_03_2010   RAGAVA
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected = True Then
                        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "Base_BH_Lug_IFL" 'VAMSI 28-01-2015
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BASE_BH_LUG_IFL"
                    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected2 = True Then
                        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "Base_BH_Lug_IFL" 'VAMSI 28-01-2015
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BASE_BH_LUG_IFL"
                    End If
                End If
            End If
        End If
        '*********
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Cross Tube" Then
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnNewFabricationGenerated = True Then           '17_10_2012   RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected = True OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected2 = True Then        '05_07_2012   RAGAVA
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BASE_CROSSTUBE", True)
                    IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BASE_CROSSTUBE")           '29_03_2010   RAGAVA
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected = True Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BASE_CROSSTUBE_IFL"
                    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected2 = True Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BASE_CROSSTUBE_IFL"
                    End If
                End If
            End If
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnNewCastingGenerated = True Then           '17_10_2012   RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port In Tube" AndAlso _
                                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "OUTSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_NO_PO_GR_CROSSTUBE", True)
                    '17_10_2012   RAGAVA
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_NO_PO_GR_CROSSTUBE"
                    Else
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_NO_PO_GR_CROSSTUBE"
                    End If
                    'Till   Here
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_NO_PO_GR_CROSSTUBE"            '19_10_2010    RAGAVA
                    IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_NO_PO_GR_CROSSTUBE")           '29_03_2010   RAGAVA
                ElseIf UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "FLUSHED" AndAlso _
                                 ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "INSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PI_GR_CROSSTUBE", True)
                    '17_10_2012   RAGAVA
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_FL_PI_GR_CROSSTUBE"
                    Else
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_FL_PI_GR_CROSSTUBE"
                    End If
                    'Till   Here
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_FL_PI_GR_CROSSTUBE"            '19_10_2010    RAGAVA
                    IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PI_GR_CROSSTUBE")           '29_03_2010   RAGAVA
                ElseIf UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "FLUSHED" AndAlso _
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "OUTSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
                    ObjClsWeldedCylinderFunctionalClass.checkAndCreateDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PO_GR_CROSSTUBE")
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PO_GR_CROSSTUBE", True)
                    '17_10_2012   RAGAVA
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_FL_PO_GR_CROSSTUBE"
                    Else
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_FL_PO_GR_CROSSTUBE"
                    End If
                    'Till   Here
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_FL_PO_GR_CROSSTUBE"            '19_10_2010    RAGAVA
                    IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PO_GR_CROSSTUBE")           '29_03_2010   RAGAVA
                ElseIf UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" AndAlso _
                       ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "INSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_GR_CROSSTUBE", True)
                    '17_10_2012   RAGAVA
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_GR_CROSSTUBE"
                    Else
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_RA_PI_GR_CROSSTUBE"
                    End If
                    'Till   Here
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_GR_CROSSTUBE"            '19_10_2010    RAGAVA
                    IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_GR_CROSSTUBE")           '29_03_2010   RAGAVA
                ElseIf UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" AndAlso _
                  ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "INSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "FILLET" Then
                    'ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_CROSSTUBE", True)
                    'IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_CROSSTUBE")           '29_03_2010   RAGAVA
                    '19_05_2010   RAGAVA     NEW DESIGN
                    If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                        ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_CROSSTUBE", True)
                        '17_10_2012   RAGAVA
                        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_CROSSTUBE"
                        Else
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_RA_PI_FI_CROSSTUBE"
                        End If
                        'Till   Here
                        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_CROSSTUBE"            '19_10_2010    RAGAVA
                        IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_CROSSTUBE")           '29_03_2010   RAGAVA
                    Else
                        ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_CROSSTUBE_90", True)
                        '17_10_2012   RAGAVA
                        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_CROSSTUBE_90"
                        Else
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_RA_PI_FI_CROSSTUBE_90"
                        End If
                        'Till   Here
                        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_CROSSTUBE_90"            '19_10_2010    RAGAVA
                        IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_CROSSTUBE_90")           '29_03_2010   RAGAVA
                    End If
                    'Till   Here
                End If
            End If
            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected = True Then
            '    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BASE_CROSSTUBE", True)
            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BASE_CROSSTUBE_IFL"            '19_10_2010    RAGAVA
            '    IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BASE_CROSSTUBE")           '29_03_2010   RAGAVA
            'End If
        End If
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Base Plug" Then
            If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port In Tube" Then
                ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_NO_PO_GR_BASEPLUG", True)
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_NO_PO_GR_BASEPLUG"            '19_10_2010    RAGAVA
                IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_NO_PO_GR_BASEPLUG")           '29_03_2010   RAGAVA
            ElseIf ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port Integral" Then
                '27_04_2010   RAGAVA   NEW DESIGN
                If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
                    'ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_BASEPLUG", True)
                    'IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_BASEPLUG")
                    '19_05_2010   RAGAVA     NEW DESIGN
                    If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                        ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_BASEPLUG", True)
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_BASEPLUG"            '19_10_2010    RAGAVA
                        IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_BASEPLUG")
                    Else
                        ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_BASEPLUG_90", True)
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_BASEPLUG_90"            '19_10_2010    RAGAVA
                        IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_BASEPLUG_90")
                    End If
                    'Till   Here
                Else
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PI_GR_BASEPLUG", True)
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_FL_PI_GR_BASEPLUG"            '19_10_2010    RAGAVA
                    IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PI_GR_BASEPLUG")
                End If
                'ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PI_GR_BASEPLUG", True)
                'IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PI_GR_BASEPLUG")
                'Till    here
            End If
        End If

        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" Then
            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected = False Then     '06_06_2012   RAGAVA
            'If Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign) <> "Existing" Then          '16_10_2012    RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnNewCastingGenerated = True Then           '17_10_2012   RAGAVA
                'CASTING
                If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port In Tube" AndAlso _
                                   ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "OUTSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_NO_PO_GR_DOUBLELUG", True)
                    '17_10_2012   RAGAVA
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_NO_PO_GR_DOUBLELUG"
                    Else
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_NO_PO_GR_DOUBLELUG"
                    End If
                    'Till   Here
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_NO_PO_GR_DOUBLELUG"            '19_10_2010    RAGAVA
                    IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_NO_PO_GR_DOUBLELUG")           '29_03_2010   RAGAVA
                ElseIf UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "FLUSHED" AndAlso _
                                 ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "INSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PI_GR_DOUBLELUG", True)
                    '17_10_2012   RAGAVA
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_FL_PI_GR_DOUBLELUG"
                    Else
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_FL_PI_GR_DOUBLELUG"
                    End If
                    'Till   Here
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_FL_PI_GR_DOUBLELUG"            '19_10_2010    RAGAVA
                    IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PI_GR_DOUBLELUG")           '29_03_2010   RAGAVA
                ElseIf UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "FLUSHED" AndAlso _
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "OUTSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PO_GR_DOUBLELUG", True)
                    '17_10_2012   RAGAVA
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_FL_PO_GR_DOUBLELUG"
                    Else
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_FL_PO_GR_DOUBLELUG"
                    End If
                    'Till   Here
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_FL_PO_GR_DOUBLELUG"            '19_10_2010    RAGAVA
                    IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PO_GR_DOUBLELUG")           '29_03_2010   RAGAVA
                ElseIf UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" AndAlso _
                       ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "INSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_GR_DOUBLELUG", True)
                    '17_10_2012   RAGAVA
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_GR_DOUBLELUG"
                    Else
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_RA_PI_GR_DOUBLELUG"
                    End If
                    'Till   Here
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_GR_DOUBLELUG"            '19_10_2010    RAGAVA
                    IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_GR_DOUBLELUG")           '29_03_2010   RAGAVA
                ElseIf UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" AndAlso _
                  ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "INSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "FILLET" Then
                    'ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_DOUBLELUG", True)
                    'IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_DOUBLELUG")           '29_03_2010   RAGAVA
                    '19_05_2010   RAGAVA     NEW DESIGN
                    If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                        ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_DOUBLELUG", True)
                        '17_10_2012   RAGAVA
                        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_DOUBLELUG"
                        Else
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_RA_PI_FI_DOUBLELUG"
                        End If
                        'Till   Here
                        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_DOUBLELUG"            '19_10_2010    RAGAVA
                        IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_DOUBLELUG")           '29_03_2010   RAGAVA
                    Else
                        ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_DOUBLELUG_90", True)
                        '17_10_2012   RAGAVA
                        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_DOUBLELUG_90"
                        Else
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_RA_PI_FI_DOUBLELUG_90"
                        End If
                        'Till   Here
                        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_DOUBLELUG_90"            '19_10_2010    RAGAVA
                        IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_DOUBLELUG_90")
                    End If
                    'Till  Here
                End If
            End If

            '06_06_2012   RAGAVA
            'FABRICATION
            'If ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.chkDoubleLug.Checked = True OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral.chkDoubleLug.Checked = True Then
            '    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BASE_SINGLE_LUG", True)
            '    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BASE_SINGLE_LUG_IFL"            '19_10_2010    RAGAVA
            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "Base_Single_Lug_IFL"
            '    IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BASE_SINGLE_LUG")           '29_03_2010   RAGAVA
            'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.chkULug.Checked = True OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral.chkULug.Checked = True Then
            '    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BASE_U_LUG", True)
            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BASE_U_LUG_IFL"            '19_10_2010    RAGAVA
            '    IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BASE_U_LUG")           '29_03_2010   RAGAVA
            'End If
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnNewFabricationGenerated = True Then           '17_10_2012   RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.chkDoubleLug.Checked = True OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral.chkDoubleLug.Checked = True Then
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BASE_SINGLE_LUG", True)
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BASE_SINGLE_LUG_IFL"           
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "Base_Single_Lug_IFL"  '27-01-2015 vamsi
                    IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BASE_SINGLE_LUG")
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.chkULug.Checked = True OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral.chkULug.Checked = True Then
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BASE_U_LUG", True)
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BASE_U_LUG_IFL"
                    IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BASE_U_LUG")
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube2.chkDoubleLug.Checked = True OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral2.chkDoubleLug.Checked = True Then
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BASE_SINGLE_LUG", True)
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BASE_SINGLE_LUG_IFL"
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "Base_Single_Lug_IFL"
                    IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BASE_SINGLE_LUG")
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube2.chkULug.Checked = True OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral2.chkULug.Checked = True Then
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BASE_U_LUG", True)
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BASE_U_LUG_IFL"
                    IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BASE_U_LUG")
                End If
                'Till  Here
            End If
        End If
        'End If
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Plate Clevis" Then
            If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
                If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "CLEVIS_PLATE_WR"            '19_10_2010    RAGAVA
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\CLEVIS_PLATE_WR", True)
                ElseIf ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "90" Then           '23_06_2010      RAGAVA
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "CLEVIS_PLATE_WR_90"            '19_10_2010    RAGAVA
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\CLEVIS_PLATE_WR_90", True)
                End If
                '23_06_2010      RAGAVA
            ElseIf UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "FLUSHED" Then
                ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PI_GR_CLEVIS", True)
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_FL_PI_GR_CLEVIS"            '19_10_2010    RAGAVA
                IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PI_GR_CLEVIS")
            End If
            'Till  Here
        End If

        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Plate Clevis" Then
            '03_06_2010    RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType <> "Conventional" Then     '08_03_2011   RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\CLEVIS_PLATE_WR", True)
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "CLEVIS_PLATE_WR"            '19_10_2010    RAGAVA
                    IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\CLEVIS_PLATE_WR")
                ElseIf ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "90" Then           '23_06_2010      RAGAVA
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\CLEVIS_PLATE_WR_90", True)
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "CLEVIS_PLATE_WR_90"            '19_10_2010    RAGAVA
                    IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\CLEVIS_PLATE_WR_90")
                End If
            End If
            'Till   Here
        End If
        If Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign) <> "Existing" Then          '18_08_2010     RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Threaded End" Then
                If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port In Tube" Then
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_NO_PO_GR_THREADEDEND", True)
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_NO_PO_GR_THREADEDEND"            '19_10_2010    RAGAVA
                    IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_NO_PO_GR_THREADEDEND")           '29_03_2010   RAGAVA
                Else
                    '14_05_2010   RAGAVA   NEW DESIGN
                    If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
                        'ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_THREADEDEND", True)
                        'IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_THREADEDEND")
                        '19_05_2010   RAGAVA     NEW DESIGN
                        If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                            ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_THREADEDEND", True)
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_THREADEDEND"            '19_10_2010    RAGAVA
                            IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_THREADEDEND")
                        Else
                            ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_THREADEDEND_90", True)
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_THREADEDEND_90"            '19_10_2010    RAGAVA
                            IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_THREADEDEND_90")
                        End If
                        'Till  Here
                    Else
                        '08_06_2010   RAGAVA
                        'ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_NO_PO_GR_THREADEDEND", True)
                        'IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_NO_PO_GR_THREADEDEND")
                        ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PI_GR_THREADEDEND", True)
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_FL_PI_GR_THREADEDEND"            '19_10_2010    RAGAVA
                        IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PI_GR_THREADEDEND")
                        'Till   Here
                    End If
                    'ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_NO_PO_GR_THREADEDEND", True)
                    'IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_NO_PO_GR_THREADEDEND")           '29_03_2010   RAGAVA
                    'Till    Here
                End If
            End If
        End If     '18_08_2010   RAGAVA

        '18_08_2010   RAGAVA    COMMENTED ASPER RAM
        'Try
        '    If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port Integral" Then
        '        ObjClsWeldedCylinderFunctionalClass.CloseExcel()
        '        IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\CLEVISPLATE_WITHPORTS")
        '        'Aruna 19_3_2010
        '        ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\CLEVISPLATE_WITHPORTS", True)
        '    End If
        'Catch ex As Exception

        'End Try


        '03_03_2011   RAGAVA
        ' '' ''Try
        ' '' ''    ObjClsWeldedCylinderFunctionalClass.CloseExcel()
        ' '' ''    KillAllSolidWorksServices()
        ' '' ''    IFLSolidWorksBaseClassObject.SolidWorksApplicationObject = Nothing
        ' '' ''    IFLSolidWorksBaseClassObject.ConnectSolidWorks()
        ' '' ''Catch ex As Exception

        ' '' ''End Try








        Try
            IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\TUBE_WELDMENT")
            'Aruna 19_3_2010
            ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\TUBE_WELDMENT", True)
            ObjClsWeldedCylinderFunctionalClass.CloseExcel()
        Catch ex As Exception

        End Try
        Try
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPistonDesign._strIsExistingorNewDesign <> "Existing" Then        '18_08_2010    RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedPistonSeal = "PTFE" Then
                    IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\PISTON_PTFE")
                    Try
                        Directory.Delete(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\PISTON", True)
                    Catch ex As Exception
                    End Try
                    'Aruna 06_04_2010
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\PISTON_PTFE", True)
                Else
                    IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\PISTON")
                    Try
                        Directory.Delete(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\PISTON_PTFE", True)
                    Catch ex As Exception
                    End Try
                    'Aruna 06_04_2010
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\PISTON", True)
                End If
            End If
        Catch ex As Exception

        End Try
        Try
            ObjClsWeldedCylinderFunctionalClass.CloseExcel()
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign._strIsExistingorNewDesign = "New" Then               '18_08_2010   RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CylinderHeadDesign = "WireRing" Then
                    IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\CYLINDER_HEAD_WIRE")
                    Try
                        Directory.Delete(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\CYLINDER_HEAD", True)
                    Catch ex As Exception
                    End Try
                    'Aruna 26_3_2010
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\CYLINDER_HEAD_WIRE", True)

                Else
                    IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\CYLINDER_HEAD")
                    Try
                        Directory.Delete(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\CYLINDER_HEAD_WIRE", True)
                    Catch ex As Exception
                    End Try
                    'Aruna 26_3_2010
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\CYLINDER_HEAD", True)
                End If
            End If
        Catch ex As Exception

        End Try
        Try
            ObjClsWeldedCylinderFunctionalClass.CloseExcel()
            IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD")
            ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD", True)

            '12_08_2010    RAGAVA
            'ObjClsWeldedCylinderFunctionalClass.CloseExcel()
            'IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD")
            'ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD", True)
        Catch ex As Exception

        End Try



        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd <> "Existing" Then          '18_08_2010   RAGAVA
            '12_08_2010   RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Single Lug" Then
                ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD_END_SINGLE_LUG_CAST", True)
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName = "ROD_END_SINGLE_LUG_CAST"            '19_10_2010    RAGAVA
                IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD_END_SINGLE_LUG_CAST")           '29_03_2010   RAGAVA
            End If
            'MANJULA ADDED
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "BH" Then
                ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD_END_BH_CAST", True)
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName = "ROD_END_BH_CAST"            '19_10_2010    RAGAVA
                IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD_END_BH_CAST")           '29_03_2010   RAGAVA
            End If
            '24_07_2012   RAGAVA Commented
            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Cross Tube" Then
            '    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD END CROSS TUBE CASTING", True)
            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName = "ROD_END_CROSS_TUBE_CASTING"            '19_10_2010    RAGAVA
            '    IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD END CROSS TUBE CASTING")           '29_03_2010   RAGAVA
            'End If
            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Cross Tube" Then
            '    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD END CROSS TUBE CASTING", True)
            '    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndFabricationSelected = True Then
            '        ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD_CROSSTUBE", True)
            '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName = "ROD_CROSSTUBE_IFL"            '19_10_2010    RAGAVA
            '        IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD_CROSSTUBE")           '29_03_2010   RAGAVA
            '    End If
            'End If

            '18_08_2010   RAGAVA
            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug" AndAlso ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Cast" Then        '12_08_2010     RAGAVA
            '    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD_END_DOUBLE_LUG_CASTING", True)
            '    IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD_END_DOUBLE_LUG_CASTING")           '29_03_2010   RAGAVA
            'End If
            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug" Then
            '    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD_END_DOUBLE_LUG_CASTING", True)
            '    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConnectionType = "Welded" AndAlso Not (ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Cast") Then
            '        ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\U_LUG_ROD", True)
            '        IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\U_LUG_ROD")           '29_03_2010   RAGAVA
            '    End If
            'End If
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug" AndAlso Not (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConnectionType = "Threaded") Then
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConnectionType = "Welded" AndAlso Not (ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Cast") Then
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\U_LUG_ROD", True)
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName = "U_LUG_ROD"            '19_10_2010    RAGAVA
                    IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\U_LUG_ROD")           '29_03_2010   RAGAVA
                Else
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD_END_DOUBLE_LUG_CASTING", True)
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName = "ROD_END_DOUBLE_LUG_CASTING"            '19_10_2010    RAGAVA
                    IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD_END_DOUBLE_LUG_CASTING")           '29_03_2010   RAGAVA
                End If
            End If
            'Till   Here
        End If


        '24_07_2012   RAGAVA Commented
        'Try
        '    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Cross Tube" Then
        '        ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD END CROSS TUBE CASTING", True)
        '        If ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Cast" Then
        '            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName = "ROD_END_CROSS_TUBE_CASTING"            '19_10_2010    RAGAVA
        '            '31_08_2012   RAGAVA  Commented   Weldment
        '            'ElseIf ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated2 = "Cast" Then
        '            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName2 = "ROD_END_CROSS_TUBE_CASTING"            '19_10_2010    RAGAVA
        '        End If
        '        IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD END CROSS TUBE CASTING")           '29_03_2010   RAGAVA
        '    End If
        '    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Cross Tube" Then
        '        'ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD END CROSS TUBE CASTING", True)
        '        'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndFabricationSelected = True Then
        '        ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD_CROSSTUBE", True)
        '        If ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Fabricated" Then
        '            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName = "ROD_CROSSTUBE_IFL"            '19_10_2010    RAGAVA
        '            '31_08_2012   RAGAVA  Commented   Weldment
        '            'ElseIf ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated2 = "Fabricated" Then
        '            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName2 = "ROD_CROSSTUBE_IFL"            '19_10_2010    RAGAVA
        '        End If
        '        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName = "ROD_CROSSTUBE_IFL"            '19_10_2010    RAGAVA
        '        IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD_CROSSTUBE")           '29_03_2010   RAGAVA
        '        'End If
        '    End If
        'Catch ex As Exception

        'End Try
        'vamsi 08-09-2014 start
        Try
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Cross Tube" Then
                If ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Cast" Then
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD END CROSS TUBE CASTING", True)

                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName = "ROD_END_CROSS_TUBE_CASTING"            '19_10_2010    RAGAVA
                    '31_08_2012   RAGAVA  Commented   Weldment
                    'ElseIf ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated2 = "Cast" Then
                    '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName2 = "ROD_END_CROSS_TUBE_CASTING"            '19_10_2010    RAGAVA
                    IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD END CROSS TUBE CASTING")           '29_03_2010   RAGAVA
                Else
                    'ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD END CROSS TUBE CASTING", True)
                    'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndFabricationSelected = True Then
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD_CROSSTUBE", True)
                    If ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Fabricated" Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName = "ROD_CROSSTUBE_IFL"            '19_10_2010    RAGAVA
                        '31_08_2012   RAGAVA  Commented   Weldment
                        'ElseIf ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated2 = "Fabricated" Then
                        '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName2 = "ROD_CROSSTUBE_IFL"            '19_10_2010    RAGAVA
                    End If
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName = "ROD_CROSSTUBE_IFL"            '19_10_2010    RAGAVA
                    IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD_CROSSTUBE")           '29_03_2010   RAGAVA
                    'End If

                End If

                
            End If
        Catch ex As Exception

        End Try
        'vamsi 08-09-2014 end

        'vamsi commented 21st May 2013
        Try
            ObjClsWeldedCylinderFunctionalClass.CloseExcel()
            IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD_WELDMENT")
            ''IFLSolidWorksBaseClassObject.SolidWorksModel.EditSuppress() 'vamsi 7th June 2013
            'Aruna 19_3_2010
            ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD_WELDMENT", True)

        Catch ex As Exception

        End Try
        'vamsi 21st may 2013 start 
        'Try
        '    ObjClsWeldedCylinderFunctionalClass.CloseExcel()

        '    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug" AndAlso (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConnectionType = "Threaded") Then

        '        IFLSolidWorksBaseClassObject.AddConfiguration("X:\WELDED_STD_PARTS\" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName + ".SLDASM", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.htStoreConfigurationCodeNumbers(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName), "", "")
        '        IFLSolidWorksBaseClassObject.deleteunattached_Dimensions()  'vamsi 27th may 2013

        '        IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD_WELDMENT")
        '    End If

        'vamsi  End

        'Aruna 19_3_2010
        'ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD_WELDMENT", True)

        'Catch ex As Exception

        'End Try


        'vamsi 21st may 2013 End


        Try
            ObjClsWeldedCylinderFunctionalClass.CloseExcel()
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.chkStopTube.Checked Then
                IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\STOP TUBE")
                'Aruna 19_3_2010
                ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\STOP TUBE", True)
            End If
        Catch ex As Exception

        End Try
        '12_3_2010 Aruna


        '03_03_2011   RAGAVA
        ' '' '' ''Try
        ' '' '' ''    ObjClsWeldedCylinderFunctionalClass.CloseExcel()
        ' '' '' ''    KillAllSolidWorksServices()
        ' '' '' ''    IFLSolidWorksBaseClassObject.SolidWorksApplicationObject = Nothing
        ' '' '' ''    IFLSolidWorksBaseClassObject.ConnectSolidWorks()
        ' '' '' ''Catch ex As Exception

        ' '' '' ''End Try



        Try
            ObjClsWeldedCylinderFunctionalClass.CloseExcel()
            IFLSolidWorksBaseClassObject.ProcessDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\WELD_CYLINDER_ASSEMBLY")
            IFLSolidWorksBaseClassObject.SolidWorksModel.EditUnsuppress() 'vamsi 7th Jume 2013
            'Aruna 19_3_2010
            ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\WELD_CYLINDER_ASSEMBLY", True)
        Catch ex As Exception

        End Try

        ' ''24_11_2010   RAGAVA
        ''Try
        ''    Dim strDummyComponentName As String = "TUBE_WELDMENT-1@WELD_CYLINDER_ASSEMBLY/Import_Plate_Clevis-2@TUBE_WELDMENT"
        ''    Dim strParentAssembly As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\WELD_CYLINDER_ASSEMBLY\WELD_CYLINDER_ASSEMBLY.SLDASM"
        ''    IFLSolidWorksBaseClassObject.ReplaceComponentWithInstance(strParentAssembly, strDummyComponentName, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.clevisplatePartFilePath, "@WELD_CYLINDER_ASSEMBLY")
        ''Catch ex As Exception

        ''End Try




        Try
            ProcessAllTheFiles(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath, True)
        Catch ex As Exception

        End Try


        '03_03_2010   RAGAVA
        Try

            'WELD_CYLINDER_ASSEMBLY\WELD_CYLINDER_ASSEMBLY.SLDDRW
            'If strPortAngle_BaseEnd = "Straight" Then
            '    File.Copy(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\TUBE_WELDMENT\TUBE_WELDMENT.SLDDRW", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath_Drawings + "\TUBE_WELDMENT.SLDDRW")
            '    File.Copy(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\WELD_CYLINDER_ASSEMBLY\WELD_CYLINDER_ASSEMBLY-0.SLDDRW", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath_Drawings + "\WELD_CYLINDER_ASSEMBLY-0.SLDDRW")
            'ElseIf strPortAngle_BaseEnd = "90" Then
            'File.Copy(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\TUBE_WELDMENT\TUBE_WELDMENT.SLDDRW", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath_Drawings + "\TUBE_WELDMENT_90DEG.SLDDRW")
            'File.Copy(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\WELD_CYLINDER_ASSEMBLY\WELD_CYLINDER_ASSEMBLY.SLDDRW", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath_Drawings + "\WELD_CYLINDER_ASSEMBLY.SLDDRW")
            ''End If
            'File.Copy(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD_WELDMENT\ROD_WELDMENT.SLDDRW", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath_Drawings + "\ROD_WELDMENT.SLDDRW")
        Catch ex As Exception
            'MsgBox("Error in Copying Drawing Files")
        End Try
    End Sub

    Public Sub ProcessAllTheFiles(ByVal targetDirectory As String, ByVal blnSearchSubDir As Boolean)
        Dim arrFileEntries As String() = Directory.GetFiles(targetDirectory)
        Try
            Dim IDEnumeratorFolderDeletions As IDictionaryEnumerator
            IDEnumeratorFolderDeletions = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable.GetEnumerator
            For intCount As Integer = 0 To UBound(arrFileEntries)
                Dim fileName As String = String.Empty
                fileName = arrFileEntries(intCount).Substring(0, arrFileEntries(intCount).LastIndexOf("\"))
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable.ContainsKey(fileName) = False Then
                    File.Delete(arrFileEntries(intCount))
                End If
            Next intCount
            Try
                Dim files
                files = Directory.GetFiles(targetDirectory)
                If files.length = 0 Then
                    Directory.Delete(targetDirectory)
                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception
        End Try
        Try
            If blnSearchSubDir = True Then
                Dim subdirectoryEntries As String() = Directory.GetDirectories(targetDirectory)
                Dim subdirectory As String
                For Each subdirectory In subdirectoryEntries
                    ProcessAllTheFiles(subdirectory, True)
                Next subdirectory
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub KillAllSolidWorksServices()
        killSolidWorks("SLDWORKS")
        killSolidWorks("SolidWorksLicTemp.0001")
        killSolidWorks("SolidWorksLicensing")
        killSolidWorks("swvbaserver")

    End Sub

    Public Sub killSolidWorks(ByVal _strProcessName As String)
        Dim proc As System.Diagnostics.Process
        Try
            For Each proc In System.Diagnostics.Process.GetProcessesByName(_strProcessName)
                If proc.HasExited = False Then
                    proc.Kill()
                End If
            Next
        Catch oException As Exception
        End Try
    End Sub

    '06_03_2010    RAGAVA
    Public Function WeldSizeCalculation() As Double
        IsWeldSizeLess = False
        WeldSizeCalculation = 0
        Try
            Dim dblMinWeldArea As Double = 0

            '07_01_2011       RAGAVA
            Dim dblStressValue As Double = 12500
            If Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.cmbClass.Text) = "1" Then
                dblStressValue = 20000
            ElseIf Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.cmbClass.Text) = "2" Then
                dblStressValue = 12500
            ElseIf Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.cmbClass.Text) = "3" Then
                dblStressValue = 9000
            ElseIf Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.cmbClass.Text) = "4" Then
                dblStressValue = 7500
            End If
            'Till   Here

            'dblMinWeldArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PullForce_RodEnd / 12500
            dblMinWeldArea = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PullForce_RodEnd / dblStressValue       'RAM Modification 07JAN11
            '=SQRT(C30^2-4*B281/3.1415)
            Dim dblMaxButtonDiameter As Double = 0
            Dim ButtonDiaSquqre As Double = Math.Abs((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter ^ 2) - (4 * dblMinWeldArea / 3.1415))
            dblMaxButtonDiameter = Math.Sqrt(ButtonDiaSquqre)

            'TODO: ANUP 05-07-2010 03.08pm
            If Not ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter < 1 Then
                'TODO: ANUP 31-05-2010 10.13am
                If dblMaxButtonDiameter < 0.5 Then
                    ' MessageBox.Show(" Rod diameter is not sufficient for the required weld size", "Change Rod Diameter", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
                    IsWeldSizeLess = True
                Else
                    IsWeldSizeLess = False
                End If
            End If

            Dim dblMinWeldSize As Double = 0
            dblMinWeldSize = (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter - dblMaxButtonDiameter) / 2
            WeldSizeCalculation = Math.Round(dblMinWeldSize, 3)
            '*****************


            'TODO: ANUP 28-04-2010 01.03pm
            'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEndCT = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWeldSize_RE(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter, dblMinWeldSize)

        Catch ex As Exception

        End Try
    End Function

    'TODO: ANUP 04-06-2010 05.31pm
    Public Sub LugGapValidation()
        Dim dblBendRadius As Double
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd < 0.625 Then
            dblBendRadius = 0.25
        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd = 0.625 Then
            dblBendRadius = 0.5
        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd > 0.625 Then
            dblBendRadius = 0.75
        End If
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap_RodEnd < 2 * dblBendRadius Then
            Dim strMessage As String = "LugGap is not sufficient for the selected LugThickness, kindly change the lugthickness"
            strMessage += "LugGap should be greater than " + (2 * dblBendRadius).ToString
            MessageBox.Show(strMessage, "LugGap is not sufficient", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
        End If
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BendRadius_RodEnd = dblBendRadius
    End Sub
    '--------------------------------

#Region "LogFile"

    Public Function WriteLogInformation(ByVal strMessage As String) As Boolean

        Try
            _intLineNumber = _intLineNumber + 1
            _oFileStream = New FileStream(CurrentWorkingDirectory & "\ErrorLog.txt", FileMode.Append, FileAccess.Write)
            _oStreamWriter = New StreamWriter(_oFileStream)
            _oStreamWriter.WriteLine("Error " + _intLineNumber.ToString + " :   " + strMessage + "   Time : " + Date.Today.ToString)
            _oStreamWriter.WriteLine("  ")
            _oStreamWriter.Close()
            _oFileStream.Close()
        Catch oException As Exception
            _oErrorObject = oException
            _strErrorMessage = "Error occured while Logiing Information" + vbCrLf + "System thrown error:-" + vbCrLf + oException.Message
            _oStreamWriter.Close()
            _oFileStream.Close()
        End Try


    End Function
    'vamsi  log 14-11-2013
    Public Function WriteErrorToLogFile(ByVal strMessage As String) As Boolean
        WriteErrorToLogFile = True
        _intLineNumber = _intLineNumber + 1
        Try
            If Not File.Exists(CurrentWorkingDirectory & "\ErrorLog.txt") Then
                CreateErrorLogFile()
                WriteLogInformation("Error : " + _intLineNumber.ToString + "  " + strMessage + "   Time : " + Date.Today.TimeOfDay.ToString)
            Else
                WriteLogInformation("Error : " + _intLineNumber.ToString + "  " + strMessage + "   Time : " + Date.Today.TimeOfDay.ToString)
            End If
        Catch oException As Exception
            _oErrorObject = oException
            _strErrorMessage = "Error occured while writing Information to LogFile" + vbCrLf + "System thrown error:-" + vbCrLf + oException.Message
            _oStreamWriter.Close()
            _oFileStream.Close()
        End Try
    End Function

    'Public Sub WriteLogInformation(ByVal strMessage As String)
    '    Try
    '        _oStreamWriter.WriteLine(strMessage)
    '        '_oStreamWriter.WriteLine()
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Public Sub CreateErrorLogFile()
        Try
            _oFileStream = New FileStream(CurrentWorkingDirectory & "\ErrorLog.txt", FileMode.Append, FileAccess.Write)
            _oStreamWriter = New StreamWriter(_oFileStream)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub CloseErrorLogFile()
        Try
            _oStreamWriter.Close()
            _oFileStream.Close()
        Catch ex As Exception

        End Try
    End Sub

    'vamsi till here log 14-11-2013

    Private Sub DeletePreviousErrorLogFile()
        Try
            If File.Exists(CurrentWorkingDirectory & "\ErrorLog.txt") Then
                File.Delete(CurrentWorkingDirectory & "\ErrorLog.txt")
            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Control Color Functionality"

    Public Function AddColors(ByVal oForm As Control) As Boolean
        For Each oControl As Control In oForm.Controls
            If oControl.HasChildren = True Then
                AddColors(oControl)
            Else
                ColorControls(oControl)
            End If
        Next
    End Function

    Public Sub ColorControls(ByVal oControl As Control)
        If (TypeOf (oControl) Is TextBox) Then
            If oControl.Visible = True And oControl.Enabled = True Then
                If oControl.Text = "" Then
                    oControl.BackColor = Color.LightGreen
                Else
                    oControl.BackColor = Color.White
                End If
            Else
                oControl.BackColor = Color.Empty
            End If
        ElseIf (TypeOf (oControl) Is ComboBox) Then
            If oControl.Visible = True And oControl.Enabled = True Then
                If oControl.Text = "" Then
                    oControl.BackColor = Color.LightGreen
                Else
                    oControl.BackColor = Color.White
                End If
            Else
                oControl.BackColor = Color.Empty
            End If
        ElseIf (TypeOf (oControl) Is LabelGradient.LabelGradient) Then
            oControl.ForeColor = Color.White
        End If
    End Sub

#End Region


    Public Function RoundUp(ByVal number As Double, ByVal significant As Integer) As Double
        RoundUp = Math.Round(number, significant)
        If RoundUp < number Then
            RoundUp = RoundUp + (1 / Math.Pow(10, significant))
            RoundUp = Math.Round(RoundUp, significant)
        End If
    End Function

    Public Function AreaOfRodWithPinHoleCalculation(ByVal dblRodDiameter As Double, ByVal dblPinHoleSize As Double) As Double
        AreaOfRodWithPinHoleCalculation = 0
        Try

            Dim dblRodDiameter_AreaOfRodWithPinHoleCalculation As Double = dblRodDiameter
            Dim dblPinHoleSize_AreaOfRodWithPinHoleCalculation As Double = dblPinHoleSize

            Dim dblAreaOfRod As Double = 3.14 / 4 * (dblRodDiameter_AreaOfRodWithPinHoleCalculation * dblRodDiameter_AreaOfRodWithPinHoleCalculation)

            Dim dblAngle As Double = 2 * (90 - (Math.Acos(dblPinHoleSize_AreaOfRodWithPinHoleCalculation / dblRodDiameter_AreaOfRodWithPinHoleCalculation) * 180 / 3.14))

            Dim PinHoleLengthInRod As Double = (Math.Sqrt((dblRodDiameter_AreaOfRodWithPinHoleCalculation / 2) ^ 2 - (dblPinHoleSize_AreaOfRodWithPinHoleCalculation / 2) ^ 2)) * 2

            Dim dblAreaRemovedDueToPinHole As Double = (2 * dblAreaOfRod * dblAngle / 360) + (PinHoleLengthInRod * dblPinHoleSize_AreaOfRodWithPinHoleCalculation / 2)

            If dblPinHoleSize_AreaOfRodWithPinHoleCalculation / dblRodDiameter_AreaOfRodWithPinHoleCalculation >= 1 Then
                AreaOfRodWithPinHoleCalculation = 0
            Else
                AreaOfRodWithPinHoleCalculation = Math.Round(dblAreaOfRod - dblAreaRemovedDueToPinHole, 3)
            End If

        Catch ex As Exception

        End Try
    End Function


#Region "ONSITE"

    'ONSITE: 19-05-2010 Disable the groupbox based on the difference of pinhole sizes r less than 0.015
    Public Function PinHoleSizeDiffere(ByVal dblPinHoleSize As Double, ByVal dblReqPinHoleSize As Double) As Boolean
        Dim dblPinHoleSizeDiff As Double = dblPinHoleSize - dblReqPinHoleSize
        If Math.Abs(dblPinHoleSizeDiff) > 0.015 Then
            Return False
        Else
            Return True
        End If
    End Function

    'ONSITE: DL - Changing the screens flow when if u select the port in tube option
    Public Sub ChangeScreensFlow()
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
        ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.cmbBaseEndPort.Text = "Port In Tube"
        Dim oForm As Form = ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails
        ObjClsWeldedCylinderFunctionalClass.ObjPnlChildFormArea.Controls.Clear()
        ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm = oForm
        oForm.TopLevel = False
        oForm.Dock = DockStyle.Fill
        If oForm.Created Then
            ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm.ManualLoad()
        End If
        oForm.Show()
        ObjClsWeldedCylinderFunctionalClass.ObjPnlChildFormArea.Controls.Add(oForm)
    End Sub

    'ONSITE:27-05-2010 To get the Greek Zerc Quantity based on angles
    Public Function GetGreekZercQty(ByVal strAngle1 As String, ByVal strAngle2 As String) As Integer
        Dim intCount As Integer = 0
        If strAngle1 <> "" Then
            If IsNumeric(strAngle1) Then
                intCount += 1
            End If
        End If

        If strAngle2 <> "" Then
            If IsNumeric(strAngle2) Then
                intCount += 1
            End If
        End If
        Return intCount
    End Function


#End Region

    Public Function LugWidth_SingleLugOrULug_Fabrication(ByVal dblLugWidth As Double) As Double

        Dim oLugWidthDataTable As New DataTable
        oLugWidthDataTable.Columns.Add("LugWidth", GetType(System.Double))
        oLugWidthDataTable.Rows.Add(1.25)
        oLugWidthDataTable.Rows.Add(1.5)
        oLugWidthDataTable.Rows.Add(1.75)
        oLugWidthDataTable.Rows.Add(2)
        oLugWidthDataTable.Rows.Add(2.5)
        oLugWidthDataTable.Rows.Add(3)
        oLugWidthDataTable.Rows.Add(3.5)
        Try
            Dim oDataRow As DataRow() = oLugWidthDataTable.Select("LugWidth >= " + dblLugWidth.ToString)
            If oDataRow.Length > 0 Then
                LugWidth_SingleLugOrULug_Fabrication = oDataRow(0).Item(0).ToString
            Else
                LugWidth_SingleLugOrULug_Fabrication = 0
                MessageBox.Show("Calculated Lug Width > 3.5, Please change the inputs", "Lug Width", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
            End If
        Catch ex As Exception

        End Try
    End Function


    'TODO: ANUP 23-07-2010
    Public Sub LabelGradient_GreenBorder_ColoringTheScreens(ByVal LabelGradient1 As LabelGradient.LabelGradient, ByVal LabelGradient2 As LabelGradient.LabelGradient, ByVal LabelGradient3 As LabelGradient.LabelGradient, ByVal LabelGradient4 As LabelGradient.LabelGradient)
        LabelGradient1.GradientColorOne = Color.Black
        LabelGradient1.GradientColorTwo = Color.Black

        LabelGradient2.GradientColorOne = Color.Black
        LabelGradient2.GradientColorTwo = Color.FromArgb(255, 47, 23)
        LabelGradient2.GradientMode = Drawing2D.LinearGradientMode.Horizontal

        LabelGradient3.GradientColorOne = Color.FromArgb(255, 47, 23)
        LabelGradient3.GradientColorTwo = Color.FromArgb(255, 47, 23)

        LabelGradient4.GradientColorOne = Color.Black
        LabelGradient4.GradientColorTwo = Color.FromArgb(255, 47, 23)
        LabelGradient4.GradientMode = Drawing2D.LinearGradientMode.Horizontal


    End Sub

    Public Sub LabelGradient_OrangeBorder_ColoringTheScreens(ByVal LabelGradient As LabelGradient.LabelGradient)
        LabelGradient.GradientColorOne = Color.Black
        LabelGradient.GradientColorTwo = Color.White
        LabelGradient.GradientMode = Drawing2D.LinearGradientMode.Horizontal
    End Sub

    Public Sub subLabelGradient_Child_ColoringScreens(ByVal LabelGradient As LabelGradient.LabelGradient)
        LabelGradient.GradientColorOne = Color.Azure
        LabelGradient.GradientColorTwo = Color.FromArgb(255, 47, 23)
        LabelGradient.GradientMode = Drawing2D.LinearGradientMode.Horizontal
    End Sub
    'ANUP 17-09-2010 START 
#Region "Swing Clearance Validation based on Part"

    Public Function SwingClearanceValidation_PartCondition_BaseEnd() As Boolean
        SwingClearanceValidation_PartCondition_BaseEnd = False
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration <> "Cross Tube" Then
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" OrElse _
               ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Single Lug" OrElse _
               ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "BH" Then
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Cast" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType2 = "Cast" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDesignSelected OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDesignSelected2 Then '12_06_2012    RAGAVA
                    If (ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port In Tube" AndAlso _
                                          ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "OUTSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE") OrElse _
                                          (UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "FLUSHED" AndAlso _
                                               ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "INSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE") OrElse _
                                               (UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" AndAlso _
                                               ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "INSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "FILLET" AndAlso _
                             (ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" OrElse Not (ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight"))) Then
                        Return True
                    End If
                End If
            End If
        End If
    End Function

    Public Function SwingClearanceValidation_PartCondition_RodEnd() As Boolean
        SwingClearanceValidation_PartCondition_RodEnd = False
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Single Lug" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "BH" Then
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd = "NewDesign" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd = "Cast" Then
                Return True
            End If
        End If
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug" AndAlso Not (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConnectionType = "Threaded") Then
            If ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Cast" Then
                Return True
            End If
        End If
    End Function


#End Region
    'ANUP 17-09-2010 TILL HERE 

    'ANUP 07-10-2010 START
    Public Function PartCode_Purchased_Validation(ByVal strPartCode As String) As String
        PartCode_Purchased_Validation = String.Empty
        Try
            Dim oMIL_DB As New clsCostingMILDB
            PartCode_Purchased_Validation = oMIL_DB.GetPurchasedPartCode(strPartCode)
            If String.IsNullOrEmpty(PartCode_Purchased_Validation) Then
                Return String.Empty
            End If
        Catch ex As Exception

        End Try
    End Function

    Public Function PartCOde_Purchased_ListViewClickedValidation(ByVal strPartCode_call As String) As String
        PartCOde_Purchased_ListViewClickedValidation = String.Empty
        Try
            Dim strPartCode As String = ObjClsWeldedCylinderFunctionalClass.PartCode_Purchased_Validation(strPartCode_call)
            If Not String.IsNullOrEmpty(strPartCode) Then
                PartCOde_Purchased_ListViewClickedValidation = strPartCode
                ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.Add(strPartCode, strPartCode_call)
            Else
                PartCOde_Purchased_ListViewClickedValidation = strPartCode_call
            End If
        Catch ex As Exception

        End Try
    End Function
    'ANUP 07-10-2010 TILL HERE

    'ANUP 11-10-2010 START
    Public Function IsAnyValueChangedWhileRevision() As Boolean
        Try
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.New_Revision = "Revision'" Then
                If ObjClsWeldedCylinderFunctionalClass.IsValueChanged_Revision Then
                    Return True
                End If
            End If
            Return False
        Catch ex As Exception

        End Try
    End Function
    'ANUP 11-10-2010 TILL HERE

    '18_01_2012   RAGAVA
    'Public Sub GetClevisPlateDetails_WR(ByRef oClevisPlateDetails As DataTable)
    Public Sub GetClevisPlateDetails_WR(ByRef oClevisPlateDetails As DataTable, Optional ByVal str1st_2nd As String = "1")      '06_06_2012   RAGAVA
        Try
            oClevisPlateDetails = Nothing
            Dim _strQuery As String = ""
            Dim oSelectedDataRow As DataRow = Nothing
            If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
                If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                    _strQuery = "Select * from PortIntegralRaisedPortDetails where NominalBoreDia = " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " and " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + " between MinTubeWallThickness and MaxTubeWallThickness and portSize = " + IIf(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text = "3/4", 0.75, 0.5625).ToString
                    oSelectedDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetButtonPlane(_strQuery)
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = 0
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = 0
                    If Not IsNothing(oSelectedDataRow) Then
                        If Not IsDBNull(oSelectedDataRow("StickOut")) Then
                            '06_06_2012   RAGAVA
                            If str1st_2nd = "1" Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = oSelectedDataRow("StickOut")
                            Else
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop2 = oSelectedDataRow("StickOut")
                            End If
                            'Till  Here
                        End If
                    End If
                Else
                    _strQuery = "Select * from PortIntegralRaisedPortDetails90 where NominalBoreDia = " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " and " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + " between MinTubeWallThickness and MaxTubeWallThickness and portSize = " + IIf(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text = "3/4", 0.75, 0.5625).ToString
                    oSelectedDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetButtonPlane(_strQuery)
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = 0
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = 0
                    If Not IsNothing(oSelectedDataRow) Then
                        If Not IsDBNull(oSelectedDataRow("DistanceFromTubeEndToRodStop")) Then
                            '06_06_2012   RAGAVA
                            If str1st_2nd = "1" Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = oSelectedDataRow("DistanceFromTubeEndToRodStop")
                            Else
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop2 = oSelectedDataRow("DistanceFromTubeEndToRodStop")
                            End If
                            'Till  Here
                            'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = oSelectedDataRow("DistanceFromTubeEndToRodStop")
                        End If
                    End If
                End If
                oClevisPlateDetails = MonarchConnectionObject.GetTable(_strQuery)
                '06_06_2012   RAGAVA
                If str1st_2nd = "1" Then
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Single Lug" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "BH" OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.chkDoubleLug.Checked = True OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral.chkDoubleLug.Checked = True Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = oSelectedDataRow("ButtonHeight") + oSelectedDataRow("MinWallThickness") + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.dblWeldsize_SL_BaseEnd
                    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Cross Tube" Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = oSelectedDataRow("ButtonHeight") + oSelectedDataRow("MinWallThickness") + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
                    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.chkULug.Checked = True OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral.chkULug.Checked = True Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = oSelectedDataRow("ButtonHeight") + oSelectedDataRow("MinWallThickness") + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BendRadius_BaseEnd + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                    End If
                Else
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Single Lug" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "BH" OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.chkDoubleLug.Checked = True OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral.chkDoubleLug.Checked = True Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop2 = oSelectedDataRow("ButtonHeight") + oSelectedDataRow("MinWallThickness") + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance2 + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.dblWeldsize_SL_BaseEnd
                    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Cross Tube" Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop2 = oSelectedDataRow("ButtonHeight") + oSelectedDataRow("MinWallThickness") + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance2
                    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.chkULug.Checked = True OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral.chkULug.Checked = True Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop2 = oSelectedDataRow("ButtonHeight") + oSelectedDataRow("MinWallThickness") + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance2 + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BendRadius_BaseEnd + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2
                    End If
                End If
                'Till  Here

            End If
        Catch ex As Exception

        End Try
    End Sub

    '20_01_2012   RAGAVA
    Public Function WeldSize_Validation_SL_BaseEnd() As Boolean
        Try
            WeldSize_Validation_SL_BaseEnd = True
            Dim oExcelSheet As Excel.Worksheet
            CheckForExcel()
            _oExApplication = New Excel.Application
            _oExApplication.Visible = False
            Dim strPath As String = Application.StartupPath + "\BaseEndWeldStressCalc.xls"
            _oExWorkbook = _oExApplication.Workbooks.Open(strPath)
            _oExWorkbook.EnableAutoRecover = False
            oExcelSheet = _oExApplication.Sheets(1)
            oExcelSheet.Range("H22").Value = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter
            oExcelSheet.Range("H23").Value = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter
            oExcelSheet.Range("H24").Value = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure
            oExcelSheet.Range("H27").Value = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth
            oExcelSheet.Range("H28").Value = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
            Dim dblPressure As Double = 0
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.cmbClass.Text = "1" Then
                dblPressure = 20000
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.cmbClass.Text = "2" Then
                dblPressure = 12500
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.cmbClass.Text = "3" Then
                dblPressure = 9000
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.cmbClass.Text = "4" Then
                dblPressure = 7500
            End If
            Dim blnWeldsizeValidaition As Boolean = True
            For i As Integer = 1 To 7
                If i = 7 Then
                    i = 8
                End If
                Dim Weldsize As Double = Val(Val(2 + i) / 16)
                oExcelSheet.Range("H26").Value = Weldsize
                Dim dblweldStress As Double = oExcelSheet.Range("H34").Value
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.dblWeldsize_SL_BaseEnd = Weldsize
                If dblweldStress < dblPressure Then
                    blnWeldsizeValidaition = False
                    WeldSize_Validation_SL_BaseEnd = False
                    Exit For
                End If
            Next
            If blnWeldsizeValidaition Then
                MsgBox("Weldsize doesn't satisfy the design, Please increase the LugWidth or LugThickness", MsgBoxStyle.OkOnly, "WeldSize Insufficient")
            End If
            Return WeldSize_Validation_SL_BaseEnd
        Catch ex As Exception

        End Try
    End Function
#End Region
    '26_11_2012  RAGAVA
    Public Sub GetCost_Sales(ByVal strPartCode As String, ByRef oListView As ListView, ByVal intcount As Integer)
        Try
            Dim _strQuery As String = ""
            _strQuery = "SELECT * FROM CostingDetails WHERE PartCode = '" + strPartCode + "'"
            Dim dr As DataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsMIL_TieRodDataClass.MILConnectionObject.GetDataRow(_strQuery)
            'Dim dr As DataRow = MonarchConnectionObject.GetDataRow(_strQuery) 'vamsi added 08-05-2013

            If Not dr Is Nothing Then
                If Not IsDBNull(dr("Cost")) Then
                    oListView.Items(intcount).SubItems.Add(dr("Cost"))
                Else
                    oListView.Items(intcount).SubItems.Add("NULL")
                End If
                If Not IsDBNull(dr("Sales")) Then
                    oListView.Items(intcount).SubItems.Add(dr("Sales"))
                Else
                    oListView.Items(intcount).SubItems.Add("NULL")
                End If
            Else
                oListView.Items(intcount).SubItems.Add("NULL")
                oListView.Items(intcount).SubItems.Add("NULL")
            End If
        Catch ex As Exception

        End Try
        'TILL  HERE
    End Sub

End Class


