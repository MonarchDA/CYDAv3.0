Imports SldWorks
Imports System.IO
Imports System.Threading
Public Class IFLSolidWorksClass
    Inherits IFLSolidWorksBaseClass
#Region "Variables"
    Private _strErrorMessage As String
    Private _oErrorObject As Exception
    Private _oCurrentSolidWorksObject As Object
    Dim oSelMgr As SldWorks.SelectionMgr
    Dim oSwFeat As SldWorks.Feature
    Dim oSwRootComp As SldWorks.Component2
    Dim oSwModelExt As SldWorks.ModelDocExtension
    Dim oSwSheet As SldWorks.Sheet
    Dim oSwMate1 As SldWorks.Mate2
    Dim oSwFrame As SldWorks.Frame
    Dim oSwSketchMgr As SldWorks.SketchManager
    Dim oSwBomFeat As SldWorks.BomFeature
    Dim oSwNote As SldWorks.Note
    Dim oSwMateEnt(2) As SldWorks.MateEntity2
    Dim oSwSheetMetal As SldWorks.SheetMetalFeatureData
    Dim oSwConf As SldWorks.Configuration
    Dim oIflBaseSolidWorksClass As IFLSolidWorksBaseClass
    Dim _alPartParameters As ArrayList
#End Region

#Region "Enums"
    Public Enum DelTypeEnum
        swDelPartOccurence = 1
        swDelPartPattern = 2
        swDelSheet = 3
        swDelView = 4
    End Enum
    Public Enum constEnvelopEnum
        swMM = 0
        swCM = 1
        swMETER = 2
        swINCHES = 3
        swFEET = 4
        swFEETINCHES = 5
        swANGSTROM = 6
        swNANOMETER = 7
        swMICRON = 8
        swMIL = 9
        swUIN = 10
        swNONE = 0
        swDECIMAL = 1
        swFRACTION = 2
    End Enum

#End Region

#Region "Properties"
    ''' <summary>
    ''' This property is used to assign the error message.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ErrorMessage()
        Get
            Return _strErrorMessage
        End Get
    End Property
    ''' <summary>
    ''' This property is used to assign the error object.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ErrorObject()
        Get
            Return _oErrorObject
        End Get
    End Property
    ''' <summary>
    ''' gets the Current Solidworks object.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IsCurrentSolidWorks() As Object
        Get
            Return _oCurrentSolidWorksObject
        End Get
    End Property
    ''' <summary>
    ''' sets the Selection manger object.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SwSelMgr() As Object
        Get
            Return oSelMgr
        End Get
    End Property
    ''' <summary>
    ''' gets the feature object of the model document.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SwFeature() As Object
        Get
            Return oSwFeat
        End Get
    End Property
#End Region

    Public Property PartParameters() As ArrayList
        Get
            If _alPartParameters Is Nothing Then
                _alPartParameters = New ArrayList
            End If
            Return _alPartParameters
        End Get
        Set(ByVal value As ArrayList)
            _alPartParameters = value
        End Set
    End Property

#Region "Procedures"
    ''' <summary>
    ''' Converts the Drawing document to DXF.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DxfConversion1(ByVal _strDrawingFileName As String, ByVal _strdestinationPath As String)
        Dim aSheetName As Array
        Dim _lngErrors As Long
        Dim _lngWarnings As Long
        Dim _blnShowMap As Boolean
        Dim i As Long
        Dim _blnRet As Boolean
        Dim _SwDXFDontShowMap As Integer = 21
        Dim oSwSaveAsCurrentVersion = 0  '  default
        Dim oSwSaveAsOptions_Silent = &H1

        Dim ofileData As FileInfo = My.Computer.FileSystem.GetFileInfo(_strDrawingFileName)
        Try
            If IsCurrentSolidWorks Is Nothing Then
                oIflBaseSolidWorksClass.ConnectSolidWorks()
            End If
            If ofileData.Extension = ".SLDDRW" Then
                oIflBaseSolidWorksClass.openDocument(_strDrawingFileName)
                oIflBaseSolidWorksClass.SolidWorksApplicationObject.Visible = True
                'oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc
                oIflBaseSolidWorksClass.SolidWorksDrawingDocument = oIflBaseSolidWorksClass.SolidWorksModel
                oIflBaseSolidWorksClass.SolidWorksApplicationObject.SetUserPreferenceToggle(21, True)
                oIflBaseSolidWorksClass.SolidWorksApplicationObject.SetUserPreferenceToggle(_SwDXFDontShowMap, True)
                aSheetName = oIflBaseSolidWorksClass.SolidWorksDrawingDocument.GetSheetNames
                For i = 0 To UBound(aSheetName)
                    _blnRet = oIflBaseSolidWorksClass.SolidWorksDrawingDocument.ActivateSheet(aSheetName(i))
                    _blnRet = oIflBaseSolidWorksClass.SolidWorksModel.SaveAs4(_strdestinationPath + "\DRAWINGS\" + ofileData.Name + aSheetName(i) & ".dxf", oSwSaveAsCurrentVersion, oSwSaveAsOptions_Silent, _lngErrors, _lngWarnings)
                Next i
                _blnRet = oIflBaseSolidWorksClass.SolidWorksDrawingDocument.ActivateSheet(aSheetName(0))
                oIflBaseSolidWorksClass.SolidWorksApplicationObject.SetUserPreferenceToggle(_SwDXFDontShowMap, _blnShowMap)
                oIflBaseSolidWorksClass.SaveDocument(_strDrawingFileName)
                oIflBaseSolidWorksClass.CloseAllDocuments()
            End If

        Catch oException As Exception
            _strErrorMessage = "UNABLE TO CONVERT THE DRAWING INTO DXF FORMAT !!" + vbNewLine
            _strErrorMessage += "System generated error:-" + vbNewLine + oException.Message
            _oErrorObject = oException
        End Try
    End Sub

    ''' <summary>
    ''' Deletes the unattached dimensions in the drawing document.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub deleteUnattached_Dimensions()
        Try
            Dim _lngI As Long
            Dim _strColour As String
            Dim _lngRetVal As Long
            Dim _blnRet As Boolean
            Dim oSwAnn As SldWorks.Annotation
            Dim oSwView As SldWorks.View
            _lngRetVal = oIflBaseSolidWorksClass.SolidWorksDrawingDocument.GetSheetCount
            For _lngI = 1 To _lngRetVal
                oIflBaseSolidWorksClass.SolidWorksDrawingDocument.SheetPrevious()
            Next _lngI
            For _lngI = 1 To _lngRetVal
                oIflBaseSolidWorksClass.SolidWorksModel.ClearSelection2(True)
                oSwView = oIflBaseSolidWorksClass.SolidWorksDrawingDocument.GetFirstView
                While Not oSwView Is Nothing
                    oSwAnn = oSwView.GetFirstAnnotation2
                    While Not oSwAnn Is Nothing
                        _strColour = CStr(oSwAnn.Color)
                        If _strColour = "32896" Then
                            ' This Below Code is to Select all The Dimensions Which are Unattached
                            _blnRet = oSwAnn.Select2(True, 0)
                        End If
                        oSwAnn = oSwAnn.GetNext2
                    End While
                    oSwView = oSwView.GetNextView
                End While
                _blnRet = oIflBaseSolidWorksClass.SolidWorksModel.DeleteSelection(True)
                oIflBaseSolidWorksClass.SolidWorksDrawingDocument.SheetNext()
            Next _lngI
        Catch oException As Exception
            _strErrorMessage = "Unable to delete unattached dimensions"
            _strErrorMessage += "System generated Error" + oException.Message
            _oErrorObject = oException
        End Try
    End Sub

    ''' <summary>
    ''' Creates the Envelop box to the model document.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DrawBox()
        Try
            Dim oswSketchPt(8) As SldWorks.SketchPoint
            Dim oswSketchSeg(12) As SldWorks.SketchSegment
            Dim oCorners As Object
            '28_07_2009  ragava
            If (oIflBaseSolidWorksClass.SolidWorksModel.GetType = SwConst.swDocumentTypes_e.swDocPART) Then
                oCorners = oIflBaseSolidWorksClass.SolidWorksModel.GetPartBox(True)         ' True comes back as system units - meters
            ElseIf oIflBaseSolidWorksClass.SolidWorksModel.GetType = SwConst.swDocumentTypes_e.swDocASSEMBLY Then  ' Units will come back as meters
                oCorners = oIflBaseSolidWorksClass.SolidWorksModel.GetBox(0)
            Else
                Exit Sub
            End If
            '28_07_2009  ragava   Till  Here

            oIflBaseSolidWorksClass.SolidWorksModel.Insert3DSketch2(True)
            oIflBaseSolidWorksClass.SolidWorksModel.SetAddToDB(True)
            oIflBaseSolidWorksClass.SolidWorksModel.SetDisplayWhenAdded(False)
            'Draw points at each corner of bounding box
            oswSketchPt(0) = oIflBaseSolidWorksClass.SolidWorksModel.CreatePoint2(oCorners(3), oCorners(1), oCorners(5))
            oswSketchPt(1) = oIflBaseSolidWorksClass.SolidWorksModel.CreatePoint2(oCorners(0), oCorners(1), oCorners(5))
            oswSketchPt(2) = oIflBaseSolidWorksClass.SolidWorksModel.CreatePoint2(oCorners(0), oCorners(1), oCorners(2))
            oswSketchPt(3) = oIflBaseSolidWorksClass.SolidWorksModel.CreatePoint2(oCorners(3), oCorners(1), oCorners(2))
            oswSketchPt(4) = oIflBaseSolidWorksClass.SolidWorksModel.CreatePoint2(oCorners(3), oCorners(4), oCorners(5))
            oswSketchPt(5) = oIflBaseSolidWorksClass.SolidWorksModel.CreatePoint2(oCorners(0), oCorners(4), oCorners(5))
            oswSketchPt(6) = oIflBaseSolidWorksClass.SolidWorksModel.CreatePoint2(oCorners(0), oCorners(4), oCorners(2))
            oswSketchPt(7) = oIflBaseSolidWorksClass.SolidWorksModel.CreatePoint2(oCorners(3), oCorners(4), oCorners(2))

            ' Now draw bounding box
            oswSketchSeg(0) = oIflBaseSolidWorksClass.SolidWorksModel.CreateLine2(oswSketchPt(0).X, oswSketchPt(0).Y, oswSketchPt(0).Z, oswSketchPt(1).X, oswSketchPt(1).Y, oswSketchPt(1).Z)
            oswSketchSeg(1) = oIflBaseSolidWorksClass.SolidWorksModel.CreateLine2(oswSketchPt(1).X, oswSketchPt(1).Y, oswSketchPt(1).Z, oswSketchPt(2).X, oswSketchPt(2).Y, oswSketchPt(2).Z)
            oswSketchSeg(2) = oIflBaseSolidWorksClass.SolidWorksModel.CreateLine2(oswSketchPt(2).X, oswSketchPt(2).Y, oswSketchPt(2).Z, oswSketchPt(3).X, oswSketchPt(3).Y, oswSketchPt(3).Z)
            oswSketchSeg(3) = oIflBaseSolidWorksClass.SolidWorksModel.CreateLine2(oswSketchPt(3).X, oswSketchPt(3).Y, oswSketchPt(3).Z, oswSketchPt(0).X, oswSketchPt(0).Y, oswSketchPt(0).Z)
            oswSketchSeg(4) = oIflBaseSolidWorksClass.SolidWorksModel.CreateLine2(oswSketchPt(0).X, oswSketchPt(0).Y, oswSketchPt(0).Z, oswSketchPt(4).X, oswSketchPt(4).Y, oswSketchPt(4).Z)
            oswSketchSeg(5) = oIflBaseSolidWorksClass.SolidWorksModel.CreateLine2(oswSketchPt(1).X, oswSketchPt(1).Y, oswSketchPt(1).Z, oswSketchPt(5).X, oswSketchPt(5).Y, oswSketchPt(5).Z)
            oswSketchSeg(6) = oIflBaseSolidWorksClass.SolidWorksModel.CreateLine2(oswSketchPt(2).X, oswSketchPt(2).Y, oswSketchPt(2).Z, oswSketchPt(6).X, oswSketchPt(6).Y, oswSketchPt(6).Z)
            oswSketchSeg(7) = oIflBaseSolidWorksClass.SolidWorksModel.CreateLine2(oswSketchPt(3).X, oswSketchPt(3).Y, oswSketchPt(3).Z, oswSketchPt(7).X, oswSketchPt(7).Y, oswSketchPt(7).Z)
            oswSketchSeg(8) = oIflBaseSolidWorksClass.SolidWorksModel.CreateLine2(oswSketchPt(4).X, oswSketchPt(4).Y, oswSketchPt(4).Z, oswSketchPt(5).X, oswSketchPt(5).Y, oswSketchPt(5).Z)
            oswSketchSeg(9) = oIflBaseSolidWorksClass.SolidWorksModel.CreateLine2(oswSketchPt(5).X, oswSketchPt(5).Y, oswSketchPt(5).Z, oswSketchPt(6).X, oswSketchPt(6).Y, oswSketchPt(6).Z)
            oswSketchSeg(10) = oIflBaseSolidWorksClass.SolidWorksModel.CreateLine2(oswSketchPt(6).X, oswSketchPt(6).Y, oswSketchPt(6).Z, oswSketchPt(7).X, oswSketchPt(7).Y, oswSketchPt(7).Z)
            oswSketchSeg(11) = oIflBaseSolidWorksClass.SolidWorksModel.CreateLine2(oswSketchPt(7).X, oswSketchPt(7).Y, oswSketchPt(7).Z, oswSketchPt(4).X, oswSketchPt(4).Y, oswSketchPt(4).Z)
            oIflBaseSolidWorksClass.SolidWorksModel.SetDisplayWhenAdded(True)
            oIflBaseSolidWorksClass.SolidWorksModel.SetAddToDB(False)
            oIflBaseSolidWorksClass.SolidWorksModel.Insert3DSketch2(True)
            oIflBaseSolidWorksClass.SolidWorksModel.EditRebuild3()
        Catch oException As Exception
            _strErrorMessage = "Unable to DrawBox for the model" + vbNewLine
            _strErrorMessage += "System generated Error" + oException.Message
            _oErrorObject = oException
        End Try
    End Sub

    ''' <summary>
    ''' Gets or sets the mass properties of the model document.
    ''' </summary>
    ''' <param name="cg_x"></param>
    ''' <param name="cg_y"></param>
    ''' <param name="cg_z"></param>
    ''' <param name="mass"></param>
    ''' <remarks></remarks>
    Public Sub getMassProperties(ByRef cg_x As Double, ByRef cg_y As Double, ByRef cg_z As Double, ByRef mass As Double)
        Try
            Dim _lngRetVal As Long
            Dim objMassProp As Object
            oIflBaseSolidWorksClass.SolidWorksModel = Nothing
            oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc
            oIflBaseSolidWorksClass.SolidWorksModel.EditRebuild3()
            oSwModelExt = oIflBaseSolidWorksClass.SolidWorksModel.Extension
            objMassProp = oSwModelExt.GetMassProperties(1, _lngRetVal)
            If Not (objMassProp) Is Nothing Then
                cg_x = (objMassProp(0)) * 1000
                cg_y = (objMassProp(1)) * 1000
                cg_z = (objMassProp(2)) * 1000
                mass = (objMassProp(5)) * 1000
            End If
        Catch oException As Exception
            _strErrorMessage = "Unable to get the mass properties of the model" + vbNewLine
            _strErrorMessage += "System generated Error" + oException.Message
            _oErrorObject = oException
        End Try
    End Sub

    ''' <summary>
    ''' mates  components in an assembly document.
    ''' </summary>
    ''' <param name="_strPlane1"></param>
    ''' <param name="_strPlane2"></param>
    ''' <param name="_strmate1"></param>
    ''' <param name="_strmate2"></param>
    ''' <remarks></remarks>
    Public Sub mateConstraints(ByVal _strPlane1 As String, ByVal _strPlane2 As String, ByVal _strmate1 As Integer, ByVal _strmate2 As String)
        Try
            Dim _bRet As Boolean = False
            Dim _intmate2 As Integer
            Dim _blnNone As Boolean = False
            Dim _iMateError As Long
            If Trim(_strmate2) = Trim("SwConst.swMateAlign_e.swMateAlignALIGNED") Then
                _intmate2 = SwConst.swMateAlign_e.swMateAlignALIGNED
            ElseIf Trim(_strmate2) = Trim("SwConst.swMateAlign_e.swMateAlignANTI_ALIGNED") Then
                _intmate2 = SwConst.swMateAlign_e.swMateAlignANTI_ALIGNED
            ElseIf Trim(_strmate2) = Trim("") Or Trim(_strmate2) = Nothing Then
                _intmate2 = SwConst.swMateAlign_e.swAlignNONE
                _blnNone = True
            End If
            If _blnNone = False Then
                Dim oMatefeature
                _bRet = oIflBaseSolidWorksClass.SolidWorksModel.Extension.SelectByID2(_strPlane1, "PLANE", 0, 0, 0, True, 0, Nothing, 0)
                _bRet = oIflBaseSolidWorksClass.SolidWorksModel.Extension.SelectByID2(_strPlane2, "PLANE", 0, 0, 0, True, 0, Nothing, 0)
                oMatefeature = oIflBaseSolidWorksClass.SolidWorksAssembly.AddMate3(_strmate1, _intmate2, False, 0, 0, 0, 1, 1, 0, 0, 0, False, _iMateError)
                oIflBaseSolidWorksClass.SolidWorksAssembly.EditRebuild()
            End If
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Replacement of the component in an assembly document.
    ''' </summary>
    ''' <param name="_strCompName"></param>
    ''' <param name="_strReplaceCompName"></param>
    ''' <param name="_strTransformerType"></param>
    ''' <remarks></remarks>
    Public Function ReplaceComponentWithInstance(ByVal _strMainFile As String, ByVal _strCompName As String, ByVal _strReplaceCompName As String, ByVal _strTransformerType As String) As String
        Try
            '31_3_2010 Aruna
            Dim blnRet As Boolean
            ReplaceComponentWithInstance = ""
            If Trim(_strReplaceCompName) <> "" Then
                Dim _bRet As Boolean = False
                If IsCurrentSolidWorks Is Nothing Then
                    oIflBaseSolidWorksClass = New IFLSolidWorksBaseClass(True)
                End If
                blnRet = oIflBaseSolidWorksClass.SolidWorksApplicationObject.SetCurrentWorkingDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath)

                oIflBaseSolidWorksClass.openDocument(_strMainFile)
                oIflBaseSolidWorksClass.SolidWorksModel.ViewZoomtofit2()
                oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActivateDoc(_strMainFile)
                _bRet = oIflBaseSolidWorksClass.SolidWorksModel.Extension.SelectByID2(_strCompName, "COMPONENT", 0, 0, 0, True, 0, Nothing, SwConst.swSelectOption_e.swSelectOptionDefault)
                If _bRet = True Then
                    Dim _strPart As String
                    oIflBaseSolidWorksClass.SolidWorksAssembly = oIflBaseSolidWorksClass.SolidWorksModel
                    _bRet = oIflBaseSolidWorksClass.SolidWorksAssembly.ReplaceComponents(_strReplaceCompName, "", False, True)
                    _strPart = getPartNumber(_strReplaceCompName)
                    ReplaceComponentWithInstance = _strPart & "-" & getInstanceNumber(_strPart & _strTransformerType)
                    oIflBaseSolidWorksClass.SolidWorksAssembly.EditRebuild()
                End If
            End If
        Catch oException As Exception
            _strErrorMessage = "Unable to perform Replacment of the component" + vbNewLine
            _strErrorMessage += "System generated error" + oException.Message
            _oErrorObject = oException
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' performs the reference cut of the component.
    ''' </summary>
    ''' <param name="_strCompName"></param>
    ''' <param name="_strPlaneName"></param>
    ''' <param name="_strSketchName"></param>
    ''' <param name="_strTransformerType"></param>
    ''' <remarks></remarks>
    Public Sub ReferenceCutLogics(ByVal _strCompName As String, ByVal _strPlaneName As String, ByVal _strSketchName As String, ByVal _strTransformerType As String, ByVal _strFinalpath As String)
        Try
            Dim _bRet As Boolean = False
            _bRet = oIflBaseSolidWorksClass.SolidWorksModel.Extension.SelectByID2(_strCompName, "COMPONENT", 0, 0, 0, False, 0, Nothing, 0)
            If _bRet = True Then
                oIflBaseSolidWorksClass.SolidWorksModel.EditPart()
                _bRet = oIflBaseSolidWorksClass.SolidWorksModel.Extension.SelectByID2(_strPlaneName, "PLANE", 0, 0, 0, False, 0, Nothing, 0)
                oIflBaseSolidWorksClass.SolidWorksModel.SketchManager.InsertSketch(True)
                _bRet = oIflBaseSolidWorksClass.SolidWorksModel.Extension.SelectByID2(_strSketchName & _strFinalpath & _strTransformerType, "SKETCH", 0, 0, 0, False, 0, Nothing, 0)
                _bRet = oIflBaseSolidWorksClass.SolidWorksModel.SketchUseEdge2(False)
                oIflBaseSolidWorksClass.SolidWorksModel.FeatureManager.FeatureCut(True, False, False, 2, 0, 0.01, 0.01, False, False, False, False, 0.01745329251994, 0.01745329251994, False, False, False, False, 0, 1, 1)
                oIflBaseSolidWorksClass.SolidWorksModel.SelectionManager.EnableContourSelection = 0
                oIflBaseSolidWorksClass.SolidWorksModel.EditAssembly()
            End If
            oIflBaseSolidWorksClass.SolidWorksModel.Save2(True)
        Catch oException As Exception
            _strErrorMessage = "Unable to perform Reference-Cuts for the Component" + vbNewLine
            _strErrorMessage += "System generated error" + oException.Message
            _oErrorObject = oException
        End Try
    End Sub

    ''' <summary>
    ''' sets the feature suppression of the model document.
    ''' </summary>
    ''' <param name="_SearchStr"></param>
    ''' <remarks></remarks>
    Public Sub FeatureSuppression(ByVal _SearchStr)
        Dim _strfeatureName As String
        Dim _blnRet As Boolean
        Try
            oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc
            oSwFeat = oIflBaseSolidWorksClass.SolidWorksModel.FirstFeature
            Do While Not oSwFeat Is Nothing
                _strfeatureName = oSwFeat.Name
                If InStr(1, _strfeatureName, _SearchStr, 1) Then
                    _blnRet = oIflBaseSolidWorksClass.SolidWorksModel.SelectByID(_strfeatureName, "BODYFEATURE", 0, 0, 0) 'Select the Feature
                    _blnRet = oIflBaseSolidWorksClass.SolidWorksModel.EditUnsuppress() ' Unsuppress the feature
                    _blnRet = oIflBaseSolidWorksClass.SolidWorksModel.SelectByID(_strfeatureName, "BODYFEATURE", 0, 0, 0) 'Select teh Feature
                    _blnRet = oIflBaseSolidWorksClass.SolidWorksModel.EditSuppress() ' Suppress the feature
                End If
                oSwFeat = oSwFeat.GetNextFeature()     ' Get the next feature
            Loop
        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' Performs the distance matings of the two components.
    ''' </summary>
    ''' <param name="_strPlane1"></param>
    ''' <param name="_strPlane2"></param>
    ''' <param name="_strmate1"></param>
    ''' <param name="_strmate2"></param>
    ''' <param name="_dblDistance"></param>
    ''' <param name="_blnFlip"></param>
    ''' <remarks></remarks>
    Public Sub DistanceMating(ByVal _strPlane1 As String, ByVal _strPlane2 As String, ByVal _strmate1 As String, ByVal _strmate2 As String, ByVal _dblDistance As Double, ByVal _blnFlip As Boolean)
        Try
            Dim _intmate2 As Integer
            Dim _blnNone As Boolean = False
            If Trim(_strmate2) = Trim("SwConst.swMateAlign_e.swMateAlignALIGNED") Then
                _intmate2 = SwConst.swMateAlign_e.swMateAlignALIGNED
            ElseIf Trim(_strmate2) = Trim("SwConst.swMateAlign_e.swMateAlignANTI_ALIGNED") Then
                _intmate2 = SwConst.swMateAlign_e.swMateAlignANTI_ALIGNED
            ElseIf Trim(_strmate2) = Trim("") Or Trim(_strmate2) = Nothing Then
                _intmate2 = SwConst.swMateAlign_e.swAlignNONE
                _blnNone = True
            End If
            If _blnNone = False Then
                Dim Matefeature
                Dim bRet As Boolean
                bRet = oIflBaseSolidWorksClass.SolidWorksModel.Extension.SelectByID2(_strPlane1, "PLANE", 0, 0, 0, True, 0, Nothing, 0)
                bRet = oIflBaseSolidWorksClass.SolidWorksModel.Extension.SelectByID2(_strPlane2, "PLANE", 0, 0, 0, True, 0, Nothing, 0)
                Matefeature = oIflBaseSolidWorksClass.SolidWorksAssembly.AddMate3(_strmate1, _intmate2, _blnFlip, _dblDistance, _dblDistance, _dblDistance, 1, 1, 0, 0, 0, False, 0) ' MateError)
                oIflBaseSolidWorksClass.SolidWorksAssembly.EditRebuild()
                oIflBaseSolidWorksClass.SolidWorksModel.ClearSelection()
            End If
        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' Enables the Configurations of the model document.
    ''' </summary>
    ''' <param name="_strconfigName"></param>
    ''' <remarks></remarks>
    Public Sub EnableConfigurations(ByVal _strconfigName As String, ByVal _strPath As String)
        Try
            Dim _blnRet As Boolean
            SetCurrentWorkingDirectory(_strPath)
            oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc
            If oIflBaseSolidWorksClass.SolidWorksModel.GetType = 2 Then
                oIflBaseSolidWorksClass.SolidWorksAssembly = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc
                oIflBaseSolidWorksClass.SolidWorksAssembly.ResolveAllLightWeightComponents(False)
            End If
            _blnRet = oIflBaseSolidWorksClass.SolidWorksModel.ShowConfiguration2(_strconfigName)
            oIflBaseSolidWorksClass.SolidWorksApplicationObject.CommandInProgress = True
            If _blnRet = True Then
                oIflBaseSolidWorksClass.SolidWorksModel.EditRebuild3()
                oIflBaseSolidWorksClass.SolidWorksApplicationObject.CommandInProgress = True
                oIflBaseSolidWorksClass.SolidWorksApplicationObject.IActiveDoc2.SaveSilent()
                oIflBaseSolidWorksClass.SolidWorksApplicationObject.CommandInProgress = True
            End If
        Catch oException As Exception
            _strErrorMessage = "Unable to perform Enabling the configurations" + vbNewLine
            _strErrorMessage += "System generated error:" + oException.Message
            _oErrorObject = oException
        End Try
    End Sub
    ''' <summary>
    ''' Deletes the Given configuration.
    ''' </summary>
    ''' <param name="_strConfigName"></param>
    ''' <remarks></remarks>
    Public Sub DeleteConfiguration(ByVal _strConfigName As String)
        Try
            Dim _blnRet As Boolean
            oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc
            _blnRet = oIflBaseSolidWorksClass.SolidWorksModel.DeleteConfiguration2(_strConfigName)
            oIflBaseSolidWorksClass.SolidWorksModel.EditRebuild3()
        Catch oException As Exception
            _strErrorMessage = "Unable to Delete the configurations" + vbNewLine
            _strErrorMessage += "System generated error:" + oException.Message
            _oErrorObject = oException
        End Try
    End Sub

    ''' <summary>
    ''' Deletes the suppression parts.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub deleteSuppressParts(ByVal _strCompName As ArrayList)    '02_09_2009  ragava         'Public Sub deleteSuppressParts(ByVal _strCompName As String())

        Try
            If _strCompName.Count = 0 Then     '02_09_2009  ragava 'If UBound(_strCompName) = 0 Then
                Exit Sub
            Else
                Dim i As Long
                Dim oSwComp
                Dim _bRet As Boolean
                'ReDim Preserve _strCompName(UBound(_strCompName) - 1)       '02_09_2009  ragava
                oIflBaseSolidWorksClass.SolidWorksModel.ClearSelection2(True)
                oIflBaseSolidWorksClass.SolidWorksAssembly = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc
                For i = 0 To _strCompName.Count - 1 '02_09_2009  ragava  For i = 0 To UBound(_strCompName)
                    oSwComp = oIflBaseSolidWorksClass.SolidWorksAssembly.FeatureByName(_strCompName(i))
                    If Not _strCompName Is Nothing Then
                        If Not oSwComp Is Nothing Then
                            _bRet = oSwComp.Select2(True, 0)
                            _bRet = oIflBaseSolidWorksClass.SolidWorksModel.DeleteSelection(False)
                        End If
                    End If
                Next i
            End If
        Catch oException As Exception
            _strErrorMessage = "Unable to perform Suppression parts deletions" + vbNewLine
            _strErrorMessage += "System generated error:" + oException.Message
            _oErrorObject = oException
        End Try
    End Sub

    ''' <summary>
    ''' Traverses the components and 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Common_TraversAndDeletions_And_SuppressionParts()
        Try
            oIflBaseSolidWorksClass.SolidWorksApplicationObject.CommandInProgress = True
            'Dim _strCompName As String()      '02_09_2009  ragava
            Dim _strCompName As New ArrayList
            Dim oSwConf As SldWorks.Configuration
            Dim oSwRootComp As SldWorks.Component2
            oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc
            oSwConf = oIflBaseSolidWorksClass.SolidWorksModel.GetActiveConfiguration
            oSwRootComp = oSwConf.GetRootComponent
            'ReDim _strCompName(0)
            _strCompName = TraverseComponentForInstance(oSwRootComp, 1)
            oIflBaseSolidWorksClass.SolidWorksApplicationObject.CommandInProgress = True
            deleteSuppressParts(_strCompName)
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Updating the scaling dimensions to the individual views of the drawing document.
    ''' </summary>
    ''' <param name="_dScaleRatio"></param>
    ''' <param name="_strDrawigFileName"></param>
    ''' <remarks></remarks>
    Public Sub ViewScaling(ByVal _dScaleRatio As Decimal, ByVal _strDrawigFileName As String, ByVal _strSheetName As String)
        '24_06_09 Satish

        Dim _strPath As String = _strDrawigFileName.Replace("~$", "")
        If Not String.Compare(_strDrawigFileName, _strPath) = 0 Then
            Exit Sub
        End If
        oIflBaseSolidWorksClass.SolidWorksDrawingDocument = Nothing
        oIflBaseSolidWorksClass.SolidWorksApplicationObject.CommandInProgress = True
        oIflBaseSolidWorksClass.openDocument(_strDrawigFileName)
        'oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc
        System.Threading.Thread.Sleep(1000)
        If oIflBaseSolidWorksClass._htDocumentInstances.ContainsKey(_strDrawigFileName) = True Then
            If oIflBaseSolidWorksClass.SolidWorksModel.GetPathName.IndexOf(".SLDDRW") <> -1 Then
                oIflBaseSolidWorksClass.SolidWorksDrawingDocument = oIflBaseSolidWorksClass._htDocumentInstances(_strDrawigFileName)    '28_07_2009  ragava
                'oIflBaseSolidWorksClass.SolidWorksDrawingDocument = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc
            End If
        End If
        If oIflBaseSolidWorksClass.SolidWorksDrawingDocument Is Nothing Then
            Exit Sub
        Else
            Dim _iNumShts As Integer
            Dim _strSheetNames
            Dim oSwView As SldWorks.View
            Dim vScaleRatio
            Dim _blnRet As Boolean
            _iNumShts = oIflBaseSolidWorksClass.SolidWorksDrawingDocument.GetSheetCount
            _strSheetNames = oIflBaseSolidWorksClass.SolidWorksDrawingDocument.GetSheetNames
            For i As Integer = 0 To _iNumShts - 1
                oIflBaseSolidWorksClass.SolidWorksDrawingDocument.SheetPrevious()
            Next i
            If Trim(_strSheetName) <> "" Then
                _blnRet = oIflBaseSolidWorksClass.SolidWorksDrawingDocument.ActivateSheet(_strSheetName)
            Else
                _iNumShts = oIflBaseSolidWorksClass.SolidWorksDrawingDocument.GetSheetCount
            End If

            For i As Integer = 0 To _iNumShts - 1
                If _strSheetNames(i) <> "DXF" Then
                    oIflBaseSolidWorksClass.SolidWorksModel.ClearSelection2(True)
                    oSwView = oIflBaseSolidWorksClass.SolidWorksDrawingDocument.GetFirstView
                    oIflBaseSolidWorksClass.SolidWorksModel.ViewZoomtofit2()
                    vScaleRatio = oSwView.ScaleRatio
                    oSwView.ScaleDecimal = 1 / (1 / Math.Round(Val(_dScaleRatio)))
                    oSwView = oSwView.GetNextView
                    If Trim(_strSheetName) <> "" Then
                        Exit For
                    Else
                        oIflBaseSolidWorksClass.SolidWorksDrawingDocument.SheetNext()
                    End If

                End If
            Next i
            oIflBaseSolidWorksClass.SolidWorksApplicationObject.CommandInProgress = True
            oIflBaseSolidWorksClass.SolidWorksApplicationObject.IActiveDoc2.SaveSilent()
            oIflBaseSolidWorksClass.SolidWorksApplicationObject.CommandInProgress = False
        End If
    End Sub

    ''' <summary>
    ''' Sets the individual view scaling for the views.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ScalingForOneView(ByVal _strSheetName As String, ByVal _strViewName As String, ByVal _dScaleValue As Decimal)
        Dim _blnRet As Boolean
        Dim oSwView As SldWorks.View
        Dim vScaleRatio
        Dim oSwSelMgr As SldWorks.SelectionMgr
        oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc
        oIflBaseSolidWorksClass.SolidWorksDrawingDocument = oIflBaseSolidWorksClass.SolidWorksModel
        _blnRet = oIflBaseSolidWorksClass.SolidWorksDrawingDocument.ActivateSheet(_strSheetName)
        _blnRet = oIflBaseSolidWorksClass.SolidWorksModel.SelectByID(_strViewName, "DRAWINGVIEW", 0, 0, 0) '21
        _blnRet = oIflBaseSolidWorksClass.SolidWorksDrawingDocument.ActivateView(_strViewName)
        oSwSelMgr = oIflBaseSolidWorksClass.SolidWorksModel.SelectionManager
        oSwView = SwSelMgr.GetSelectedObject5(1)
        vScaleRatio = oSwView.ScaleRatio
        oSwView.ScaleDecimal = Math.Round(1 / Math.Round(Val(_dScaleValue)), 3)
        _blnRet = oIflBaseSolidWorksClass.SolidWorksModel.EditRebuild3
        oIflBaseSolidWorksClass.SolidWorksApplicationObject.CommandInProgress = True
        oIflBaseSolidWorksClass.SolidWorksApplicationObject.IActiveDoc2.SaveSilent()
        oIflBaseSolidWorksClass.SolidWorksApplicationObject.CommandInProgress = False
    End Sub

    ''' <summary>
    ''' Sets the auto ballooning for the selected view
    ''' </summary>
    ''' <param name="_strSheetName"></param>
    ''' <param name="_strViewName"></param>
    ''' <remarks></remarks>
    Public Sub AutoBallooning(ByVal _strSheetName As String, ByVal _strViewName As String)
        Dim oNotes As Object
        Dim _bRet As Boolean
        Try
            _bRet = oIflBaseSolidWorksClass.SolidWorksDrawingDocument.ActivateSheet(_strSheetName)
            oIflBaseSolidWorksClass.SolidWorksModel.ViewZoomtofit2()
            oSelMgr = oIflBaseSolidWorksClass.SolidWorksModel.SelectionManager
            _bRet = oIflBaseSolidWorksClass.SolidWorksModel.SelectByID(_strViewName, "DRAWINGVIEW", 0, 0, 0) '21
            _bRet = oIflBaseSolidWorksClass.SolidWorksDrawingDocument.ActivateView(_strViewName)
            oNotes = oIflBaseSolidWorksClass.SolidWorksDrawingDocument.AutoBalloon3(1, True, 1, 2, 1, "", 2, "", "0")
            oNotes = Nothing
        Catch oException As Exception
            _strErrorMessage = "Unable to perform Auto ballooning" + vbNewLine
            _strErrorMessage += "System generated error:" + oException.Message
            _oErrorObject = oException
        End Try
    End Sub

    ''' <summary>
    ''' gets the Auto ballooning for the drawing document.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub AutoBallooning()
        Try
            Dim _blnRet As Boolean
            Dim _strViewName As String
            Dim oSwView As SldWorks.View
            Const swDetailingBalloonLayout_Default = 1
            Dim oNoteArr As Object
            oIflBaseSolidWorksClass.SolidWorksDrawingDocument = oIflBaseSolidWorksClass.SolidWorksModel
            oSelMgr = oIflBaseSolidWorksClass.SolidWorksModel.SelectionManager
            _strViewName = oIflBaseSolidWorksClass.SolidWorksDrawingDocument.GetFirstView()
            oSwView = oSelMgr.GetSelectedObject5(1)
            _blnRet = oIflBaseSolidWorksClass.SolidWorksDrawingDocument.ActivateView(oSwView.Name)
            oNoteArr = oIflBaseSolidWorksClass.SolidWorksDrawingDocument.AutoBalloon2(swDetailingBalloonLayout_Default, True)
        Catch oException As Exception
            _strErrorMessage = "Unable to perform Auto ballooning" + vbNewLine
            _strErrorMessage += "System generated error:" + oException.Message
            _oErrorObject = oException
        End Try
    End Sub
#End Region

#Region "Functions"
    ''' <summary>
    ''' Gets the part number of the document.
    ''' </summary>
    ''' <param name="_strPartPath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getPartNumber(ByVal _strPartPath As String) As String
        getPartNumber = ""
        Try
            Dim _strSplit
            Dim _strSplitPartNumber As String
            _strSplit = Split(_strPartPath, "\")
            _strSplitPartNumber = _strSplit(UBound(_strSplit))
            _strSplit = Split(_strSplitPartNumber, ".")
            _strSplitPartNumber = _strSplit(0)
            Return _strSplitPartNumber
        Catch oException As Exception
            _strErrorMessage = "Unable to get the instance number of the component" + vbNewLine
            _strErrorMessage += "System generated Error" + oException.Message
            _oErrorObject = oException
        End Try
    End Function


    ''' <summary>
    ''' Gets the parameters of the modele document.
    ''' </summary>
    ''' <param name="_strPartAssemblyFileName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetParameters(ByVal _strPartAssemblyFileName As String) As ArrayList
        PartParameters = Nothing
        GetParameters = Nothing
        Dim oSwConf As SldWorks.Configuration
        Dim oSwRootComp As SldWorks.Component2
        If IsCurrentSolidWorks Is Nothing Then
            oIflBaseSolidWorksClass = New IFLSolidWorksBaseClass(True)
        End If
        oIflBaseSolidWorksClass.openDocument(_strPartAssemblyFileName)
        oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc
        oSwFeat = oIflBaseSolidWorksClass.SolidWorksModel.FirstFeature
        oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc
        oSwConf = oIflBaseSolidWorksClass.SolidWorksModel.GetActiveConfiguration
        oSwRootComp = oSwConf.GetRootComponent
        'Debug.Print("File = " & oIflBaseSolidWorksClass.SolidWorksModel.GetPathName)
        TraverseModelFeatures(oIflBaseSolidWorksClass.SolidWorksModel, 1)
        TraverseComponent(oSwRootComp, 1)
        GetParameters = PartParameters
    End Function


    '    End Function
    ''' <summary>
    ''' Deletes the design table.
    ''' </summary>
    ''' <param name="strPartFileName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DeleteDesignTable(ByVal strPartFileName As String) As Boolean
        DeleteDesignTable = False
        Try
            Dim oDesignTable As SldWorks.DesignTable
            If IsCurrentSolidWorks Is Nothing Then
                oIflBaseSolidWorksClass = New IFLSolidWorksBaseClass(True)
            End If
            oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc
            oDesignTable = oIflBaseSolidWorksClass.SolidWorksModel.GetDesignTable
            oDesignTable.Detach()
            oIflBaseSolidWorksClass.SolidWorksModel.DeleteDesignTable()
            DeleteDesignTable = True
        Catch oException As Exception
            _strErrorMessage = "UNABLE TO DELETE THE DESIGN TABLE !!" + vbCrLf
            _strErrorMessage += "System generated error:-" + vbCrLf + oException.Message
            _oErrorObject = oException
        End Try

    End Function

    ''' <summary>
    ''' Deletes the equation of model document.
    ''' </summary>
    ''' <param name="_strPartAssemblyFileName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DeleteEquation(ByVal _strPartAssemblyFileName As String) As Boolean
        DeleteEquation = False
        Try
            If IsCurrentSolidWorks Is Nothing Then
                oIflBaseSolidWorksClass.ConnectSolidWorks()
            End If
            Dim oPart As Object
            oPart = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc
            oSelMgr = oPart.SelectionManager
            DeleteEquation = oPart.DeleteAllRelations
        Catch oException As Exception
            _strErrorMessage = "UNABLE TO CONVERT THE DRAWING INTO DXF FORMAT !!" + vbCrLf
            _strErrorMessage += "System generated error:-" + vbCrLf + oException.Message
            _oErrorObject = oException
        End Try
    End Function

    ''' <summary>
    ''' sets the current working directory.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetCurrentWorkingDirectory(ByVal _strSetPath As String) As Boolean
        SetCurrentWorkingDirectory = False
        Try
            If IsCurrentSolidWorks Is Nothing Then
                oIflBaseSolidWorksClass = New IFLSolidWorksBaseClass(True)
            End If
            SetCurrentWorkingDirectory = oIflBaseSolidWorksClass.SolidWorksApplicationObject.SetCurrentWorkingDirectory(_strSetPath)
        Catch oException As Exception
            _strErrorMessage = "UNABLE TO CONVERT THE DRAWING INTO DXF FORMAT !!" + vbCrLf
            _strErrorMessage += "System generated error:-" + vbCrLf + oException.Message
            _oErrorObject = oException
        End Try
        Return SetCurrentWorkingDirectory
    End Function

    ''' <summary>
    ''' Creates the Envelop for the assembly document.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function createEnvelop() As Double
        Try
            oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc
            If oIflBaseSolidWorksClass.SolidWorksModel Is Nothing Then
                Exit Function
            Else
                Dim oCorners As Object
                Dim _dblConvFactor As Double
                Dim _dblAddFactor As Double
                Dim _lngLength As Long
                Dim _lngHeight As Long
                Dim _lngWidth As Long
                Dim _blnRet As Boolean
                Dim _intMsgResponse As Integer
                Dim oUserUnits As Object
                _dblAddFactor = 0.015 ' This is the amount added - change to suit

                If (oIflBaseSolidWorksClass.SolidWorksModel.GetType = SwConst.swDocumentTypes_e.swDocPART) Then
                    oCorners = oIflBaseSolidWorksClass.SolidWorksModel.GetPartBox(True)         ' True comes back as system units - meters
                ElseIf oIflBaseSolidWorksClass.SolidWorksModel.GetType = SwConst.swDocumentTypes_e.swDocASSEMBLY Then  ' Units will come back as meters
                    oCorners = oIflBaseSolidWorksClass.SolidWorksModel.GetBox(0)
                Else
                    Exit Function
                End If
                oUserUnits = oIflBaseSolidWorksClass.SolidWorksModel.GetUnits()
                Select Case oIflBaseSolidWorksClass.SolidWorksModel.GetUnits(0)
                    Case constEnvelopEnum.swMM
                        _dblConvFactor = 1 * 1000
                    Case constEnvelopEnum.swCM
                        _dblConvFactor = 1 * 100
                    Case constEnvelopEnum.swMETER
                        _dblConvFactor = 1
                    Case constEnvelopEnum.swINCHES
                        _dblConvFactor = 1 / 0.0254
                    Case constEnvelopEnum.swFEET
                        _dblConvFactor = 1 / (0.0254 * 12)
                    Case constEnvelopEnum.swFEETINCHES
                        _dblConvFactor = 1 / 0.0254  ' Pass inches through
                    Case constEnvelopEnum.swANGSTROM
                        _dblConvFactor = 10000000000.0#
                    Case constEnvelopEnum.swNANOMETER
                        _dblConvFactor = 1000000000
                    Case constEnvelopEnum.swMICRON
                        _dblConvFactor = 1000000
                    Case constEnvelopEnum.swMIL
                        _dblConvFactor = (1 / 0.0254) * 1000
                    Case constEnvelopEnum.swUIN
                        _dblConvFactor = (1 / 0.0254) * 1000000
                End Select
                _lngHeight = Math.Round((Math.Abs(oCorners(4) - oCorners(1)) * _dblConvFactor) + _dblAddFactor, oUserUnits(3)) ' Z axis
                _lngWidth = Math.Round((Math.Abs(oCorners(5) - oCorners(2)) * _dblConvFactor) + _dblAddFactor, oUserUnits(3))  ' Y axis
                _lngLength = Math.Round((Math.Abs(oCorners(3) - oCorners(0)) * _dblConvFactor) + _dblAddFactor, oUserUnits(3)) ' X axis
                ' Check for either (Feet-Inches OR Inches) AND fractions  If so, return Ft-In
                If (oUserUnits(0) = 5 Or oUserUnits(0) = 3) And oUserUnits(1) = 2 Then
                    _lngHeight = DecimalToFeetInches(_lngHeight, Val(oUserUnits(2)))
                    _lngWidth = DecimalToFeetInches(_lngWidth, Val(oUserUnits(2)))
                    _lngLength = DecimalToFeetInches(_lngLength, Val(oUserUnits(2)))
                End If
                GetCurrentConfigName()
                ' See what config we are now on
                _blnRet = oIflBaseSolidWorksClass.SolidWorksModel.DeleteCustomInfo2(GetCurrentConfigName, "BoundingSize") 'Remove existing properties
                _blnRet = oIflBaseSolidWorksClass.SolidWorksModel.AddCustomInfo3(GetCurrentConfigName, "BoundingSize", SwConst.swCustomInfoType_e.swCustomInfoText, _
                         _lngHeight & " x " & _lngWidth & " x " & _lngLength)  'Add latest values
                _intMsgResponse = vbNo
                If _intMsgResponse = vbYes Then
                    Call DrawBox()
                End If
                Return Math.Max(Math.Max(_lngWidth, _lngLength), _lngHeight)
            End If

        Catch oException As Exception
            _strErrorMessage = "Unable to perform Envelop for the model document" + vbNewLine
            _strErrorMessage += "System generated error:" + oException.Message
            _oErrorObject = oException
        End Try
    End Function

    ''' <summary>
    ''' Gets the configuration name of the model document.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetCurrentConfigName() As String
        Try
            Dim oSwConfig As SldWorks.Configuration
            GetCurrentConfigName = ""
            oSwConfig = oIflBaseSolidWorksClass.SolidWorksModel.GetActiveConfiguration
            GetCurrentConfigName = oIflBaseSolidWorksClass.SolidWorksModel.GetActiveConfiguration.Name
            Return GetCurrentConfigName
        Catch oException As Exception
            _strErrorMessage = "Unable to get the Configuration name" + vbNewLine
            _strErrorMessage += "System generated error:" + oException.Message
            _oErrorObject = oException
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Convertion of Decimal to feet inches for creating the envelop box boundaries.
    ''' </summary>
    ''' <param name="oDecimalLength"></param>
    ''' <param name="_iDenominator"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function DecimalToFeetInches(ByVal oDecimalLength As Object, ByVal _iDenominator As Integer) As String
        Dim _intFeet As Integer
        Dim _intInches As Integer
        Dim _intFractions As Integer
        Dim _dblFractToDecimal As Double
        Dim _dblremainder As Double
        Dim _dbltmpVal As Double
        ' compute whole feet
        _intFeet = Int(oDecimalLength / 12)
        _dblremainder = oDecimalLength - (_intFeet * 12)
        _dbltmpVal = CDbl(_iDenominator)
        ' compute whole inches
        _intInches = Int(_dblremainder)
        _dblremainder = _dblremainder - _intInches
        ' compute fractional inches & check for division by zero
        If Not (_dblremainder = 0) Then
            If Not (_iDenominator = 0) Then
                _dblFractToDecimal = 1 / _dbltmpVal
                If _dblFractToDecimal > 0 Then
                    _intFractions = Int(_dblremainder / _dblFractToDecimal)
                    If (_dblremainder / _dblFractToDecimal) - _intFractions > 0 Then  ' Round up so bounding box is always larger.
                        _intFractions = _intFractions + 1
                    End If
                End If
            End If
        End If
        Call FractUp(_intFeet, _intInches, _intFractions, _iDenominator) ' Simplify up & down
        DecimalToFeetInches = LTrim$(Str$(_intFeet)) & "'-"
        DecimalToFeetInches = DecimalToFeetInches & LTrim$(Str$(_intInches))
        If _intFractions > 0 Then
            DecimalToFeetInches = DecimalToFeetInches & " "
            DecimalToFeetInches = DecimalToFeetInches & LTrim$(Str$(_intFractions))
            DecimalToFeetInches = DecimalToFeetInches & "\" & LTrim$(Str$(_iDenominator))
        End If
        DecimalToFeetInches = DecimalToFeetInches & Chr(34)
    End Function

    ''' <summary>
    '''  Measures the inches for creating the envelop box boundaries.
    ''' </summary>
    ''' <param name="_iInputFt"></param>
    ''' <param name="_iInputInch"></param>
    ''' <param name="_iInputNum"></param>
    ''' <param name="_iInputDenom"></param>
    ''' <remarks></remarks>
    Private Sub FractUp(ByVal _iInputFt As Integer, ByVal _iInputInch As Integer, ByVal _iInputNum As Integer, ByVal _iInputDenom As Integer)
        While _iInputNum Mod 2 = 0 And _iInputDenom Mod 2 = 0
            _iInputNum = _iInputNum / 2
            _iInputDenom = _iInputDenom / 2
        End While
        ' See if we now have a full inch or 12 inches.  If so, bump stuff up
        If _iInputDenom = 1 Then  ' Full inch
            _iInputInch = _iInputInch + 1
            _iInputNum = 0
            If _iInputInch = 12 Then  ' Full foot
                _iInputFt = _iInputFt + 1
                _iInputInch = 0
            End If
        End If
    End Sub

    ''' <summary>
    ''' Gets the instance number of the model by traverses the model tree.
    ''' </summary>
    ''' <param name="oSwComp"></param>
    ''' <param name="_nLevel"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function TraverseComponentForInstance(ByVal oSwComp As SldWorks.Component2, ByVal _nLevel As Long) As ArrayList     '02_09_2009  ragava
        TraverseComponentForInstance = Nothing
        Try
            Dim _sPadStr As String = ""
            Dim VchildComp
            Dim i As Long = 0
            For i = 0 To _nLevel - 1
                _sPadStr = _sPadStr + "  "
            Next i
            'Dim sCompName As String()           '02_09_2009  ragava
            Dim sCompName As New ArrayList
            If Not oSwComp Is Nothing Then
                VchildComp = oSwComp.GetChildren
                If VchildComp.Length > 0 Then
                    Dim swChildComp As SldWorks.Component2
                    For i = 0 To UBound(VchildComp)
                        swChildComp = VchildComp(i)
                        TraverseComponentForInstance(swChildComp, _nLevel + 1)
                        If swChildComp.IsSuppressed = True Then
                            'sCompName(UBound(sCompName)) = swChildComp.Name         '02_09_2009  ragava
                            sCompName.Add(swChildComp.Name)
                            'ReDim Preserve sCompName(UBound(sCompName) + 1)           '02_09_2009  ragava
                        End If
                    Next i
                End If
            End If
            Return sCompName
        Catch oException As Exception
            _strErrorMessage = "System generated error:" + oException.Message
        End Try
    End Function


    ''' <summary>
    ''' Gets the maximum number of instance number of the model document.
    ''' </summary>
    ''' <param name="_strReplacedComponent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getInstanceNumber(ByVal _strReplacedComponent As String) As Integer
        Try
            Dim _intMaxInstanceNumber As Integer
            Dim oSwParentName As SldWorks.Component2
            Dim _bRet As Boolean
            oSwConf = oIflBaseSolidWorksClass.SolidWorksModel.GetActiveConfiguration
            oSwRootComp = oSwConf.GetRootComponent
            oSelMgr = oIflBaseSolidWorksClass.SolidWorksModel.SelectionManager
            oSwFeat = oIflBaseSolidWorksClass.SolidWorksModel.FirstFeature
            _bRet = oIflBaseSolidWorksClass.SolidWorksModel.Extension.SelectByID2(_strReplacedComponent, "COMPONENT", 0, 0, 0, True, 0, Nothing, SwConst.swSelectOption_e.swSelectOptionDefault)
            oSwParentName = oSelMgr.GetSelectedObjectsComponent(1)
            _intMaxInstanceNumber = TraverseComponent(oSwRootComp, 1, oSwParentName)
            Return _intMaxInstanceNumber
        Catch ex As Exception
        End Try
    End Function

    ''' <summary>
    ''' Traverses the entire tree and returns the maximum instance number of the component.
    ''' </summary>
    ''' <param name="oSwComp"></param>
    ''' <param name="_nLevel"></param>
    ''' <param name="oSwComp1"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function TraverseComponent(ByVal oSwComp As SldWorks.Component2, ByVal _nLevel As Long, ByVal oSwComp1 As SldWorks.Component2) As Integer
        Try
            Dim vChildComp As Object
            Dim oSwChildComp As SldWorks.Component2
            Dim _sPadStr As String = ""
            Dim spltRslt
            Dim spltRslt1
            Dim strDefaultComponent As String
            Dim strTrvComponent As String
            Dim intI As Long
            Dim _instanceCount As Integer
            spltRslt = Split(oSwComp1.Name, "-")
            strDefaultComponent = spltRslt(0)
            For intJ As Integer = 1 To (UBound(spltRslt)) - 1
                strDefaultComponent = strDefaultComponent & "-" & spltRslt(intJ)
            Next
            For intI = 0 To _nLevel - 1
                _sPadStr = _sPadStr + " "
            Next intI
            vChildComp = oSwComp.GetChildren
            For intI = 0 To UBound(vChildComp)
                oSwChildComp = vChildComp(intI)
                spltRslt1 = Split(oSwChildComp.Name, "-")
                strTrvComponent = spltRslt1(0)
                For intK As Integer = 1 To (UBound(spltRslt1)) - 1
                    strTrvComponent = strTrvComponent & "-" & spltRslt1(intK)
                Next
                If strDefaultComponent = strTrvComponent Then
                    _instanceCount = _instanceCount + 1
                End If
            Next intI
            Return _instanceCount
        Catch oException As Exception
            _strErrorMessage = "System generated error:" + oException.Message
        End Try
    End Function

    ''' <summary>
    ''' Deletes the Feature.
    ''' </summary>
    ''' <param name="_strFeatureName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DeleteFeatures(ByVal _strFeatureName As String) As Boolean
        DeleteFeatures = False
        Dim _blnRet As Boolean
        Try
            oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc
            _blnRet = oIflBaseSolidWorksClass.SolidWorksModel.SelectByID(_strFeatureName, "BODYFEATURE", 0, 0, 0)
            If _blnRet = True Then
                Dim _longstatus As Long
                Dim solidWorksModelDocExt As SldWorks.ModelDocExtension
                oSelMgr = oIflBaseSolidWorksClass.SolidWorksModel.SelectionManager
                solidWorksModelDocExt = oIflBaseSolidWorksClass.SolidWorksModel.Extension
                _longstatus = solidWorksModelDocExt.DeleteSelection2(SwConst.swDeleteSelectionOptions_e.swDelete_Absorbed)
            End If
        Catch oException As Exception
            _strErrorMessage = "UNABLE TO Delete the feature" + vbNewLine
            _strErrorMessage += "System generated error:-" + vbNewLine + oException.Message
            _oErrorObject = oException
        End Try
    End Function


    Public Sub UpdateDimensions(ByVal _strParameterName As String, ByVal oValue As Object)
        If oValue = 0 Then
            oValue = 1
        End If

        If IsNPATTERN(_strParameterName) Then
            oValue = oValue * 1000
        End If
        oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc
        oIflBaseSolidWorksClass.SolidWorksModel.Parameter(_strParameterName).SystemValue = oValue / 1000
        oIflBaseSolidWorksClass.SolidWorksModel.EditRebuild3()
    End Sub
    Private Function IsNPATTERN(ByVal _strParameterName As String) As Boolean
        IsNPATTERN = False
        Dim str() As String
        str = _strParameterName.Split("@")
        If str(0).Contains("PATTERN") Then
            IsNPATTERN = True
        End If
    End Function
#End Region
    'Private Function TraverseFeatureFeatures(ByVal swFeat As SldWorks.Feature, ByVal nLevel As Long) As ArrayList
    Private Sub TraverseFeatureFeatures(ByVal swFeat As SldWorks.Feature, ByVal nLevel As Long)
        Dim sPadStr As String = ""
        Dim oSolidWorksSubFeat As SldWorks.Feature
        Dim oSolidWorksDispDim As SldWorks.DisplayDimension
        Dim oSolidWorksDim As SldWorks.Dimension
        Dim oSolidWorksAnn As SldWorks.Annotation
        If IsCurrentSolidWorks Is Nothing Then
            oIflBaseSolidWorksClass = New IFLSolidWorksBaseClass(True)
        End If
        Do While Not oSwFeat Is Nothing
            oSolidWorksSubFeat = oSwFeat.GetFirstSubFeature
            Do While Not oSolidWorksSubFeat Is Nothing
                oSolidWorksDispDim = oSolidWorksSubFeat.GetFirstDisplayDimension
                Do While Not oSolidWorksDispDim Is Nothing
                    oSolidWorksAnn = oSolidWorksDispDim.GetAnnotation
                    oSolidWorksDim = oSolidWorksDispDim.GetDimension
                    PartParameters.Add(oSolidWorksDim.FullName)
                    oSolidWorksDispDim = oSolidWorksSubFeat.GetNextDisplayDimension(oSolidWorksDispDim)
                Loop
                oSolidWorksSubFeat = oSolidWorksSubFeat.GetNextSubFeature
            Loop
            oSolidWorksDispDim = oSwFeat.GetFirstDisplayDimension
            Do While Not oSolidWorksDispDim Is Nothing
                oSolidWorksAnn = oSolidWorksDispDim.GetAnnotation
                oSolidWorksDim = oSolidWorksDispDim.GetDimension
                PartParameters.Add(oSolidWorksDim.FullName)
                oSolidWorksDispDim = oSwFeat.GetNextDisplayDimension(oSolidWorksDispDim)
            Loop
            oSwFeat = oSwFeat.GetNextFeature
        Loop
    End Sub

    Sub TraverseComponentFeatures(ByVal oSwComp As SldWorks.Component2, ByVal _nLevel As Long)
        oSwFeat = oSwComp.FirstFeature
        TraverseFeatureFeatures(oSwFeat, _nLevel)
    End Sub

    Sub TraverseComponent(ByVal oSwComp As SldWorks.Component2, ByVal _nLevel As Long)
        Dim vChildComp As Object
        Dim oSwChildComp As SldWorks.Component2
        Dim _strPadStr As String = ""
        Dim i As Long
        For i = 0 To _nLevel - 1
            _strPadStr = _strPadStr + "  "
        Next i
        vChildComp = oSwComp.GetChildren
        For i = 0 To UBound(vChildComp)
            oSwChildComp = vChildComp(i)
            TraverseComponentFeatures(oSwChildComp, _nLevel)
            TraverseComponent(oSwChildComp, _nLevel + 1)
        Next i
    End Sub

    Public Sub TraverseModelFeatures(ByVal oSwModel As SldWorks.ModelDoc2, ByVal _nLevel As Long)
        Dim oSwFeat As SldWorks.Feature
        oSwFeat = oSwModel.FirstFeature
        TraverseFeatureFeatures(oSwFeat, _nLevel)
    End Sub

    Public Function GetPartParameters(ByVal _strPartFileName As String) As ArrayList
        GetPartParameters = Nothing
        PartParameters = Nothing
        Dim oSolidWorksSubFeat As SldWorks.Feature
        Dim oSolidWorksDispDim As SldWorks.DisplayDimension
        Dim oSolidWorksDim As SldWorks.Dimension
        Dim oSolidWorksAnn As SldWorks.Annotation
        If IsCurrentSolidWorks Is Nothing Then
            oIflBaseSolidWorksClass = New IFLSolidWorksBaseClass(True)
        End If
        oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc
        oSwFeat = oIflBaseSolidWorksClass.SolidWorksModel.FirstFeature
        Do While Not oSwFeat Is Nothing
            oSolidWorksSubFeat = oSwFeat.GetFirstSubFeature
            Do While Not oSolidWorksSubFeat Is Nothing
                oSolidWorksDispDim = oSolidWorksSubFeat.GetFirstDisplayDimension
                Do While Not oSolidWorksDispDim Is Nothing
                    oSolidWorksAnn = oSolidWorksDispDim.GetAnnotation
                    oSolidWorksDim = oSolidWorksDispDim.GetDimension
                    PartParameters.Add(oSolidWorksDim.FullName)
                    oSolidWorksDispDim = oSolidWorksSubFeat.GetNextDisplayDimension(oSolidWorksDispDim)
                Loop
                oSolidWorksSubFeat = oSolidWorksSubFeat.GetNextSubFeature
            Loop
            oSolidWorksDispDim = oSwFeat.GetFirstDisplayDimension
            Do While Not oSolidWorksDispDim Is Nothing
                oSolidWorksAnn = oSolidWorksDispDim.GetAnnotation
                oSolidWorksDim = oSolidWorksDispDim.GetDimension
                PartParameters.Add(oSolidWorksDim.FullName)
                oSolidWorksDispDim = oSwFeat.GetNextDisplayDimension(oSolidWorksDispDim)
            Loop
            oSwFeat = oSwFeat.GetNextFeature
        Loop
        GetPartParameters = PartParameters
    End Function

    Public Function GetPartParametersPartAndAssemblies(ByVal _strPartFileName As String) As ArrayList
        GetPartParametersPartAndAssemblies = Nothing
        PartParameters = Nothing
        Dim oSolidWorksSubFeat As SldWorks.Feature
        Dim oSolidWorksDispDim As SldWorks.DisplayDimension
        Dim oSolidWorksDim As SldWorks.Dimension
        Dim oSolidWorksAnn As SldWorks.Annotation
        If IsCurrentSolidWorks Is Nothing Then
            oIflBaseSolidWorksClass = New IFLSolidWorksBaseClass(True)
        End If
        oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc
        oSwFeat = oIflBaseSolidWorksClass.SolidWorksModel.FirstFeature
        Do While Not oSwFeat Is Nothing
            oSolidWorksSubFeat = oSwFeat.GetFirstSubFeature
            Do While Not oSolidWorksSubFeat Is Nothing
                'oSolidWorksDispDim = oSolidWorksSubFeat.GetFirstDisplayDimension
                'Do While Not oSolidWorksDispDim Is Nothing
                '    oSolidWorksAnn = oSolidWorksDispDim.GetAnnotation
                '    oSolidWorksDim = oSolidWorksDispDim.GetDimension
                '    PartParameters.Add(oSolidWorksDim.FullName)
                '    oSolidWorksDispDim = oSolidWorksSubFeat.GetNextDisplayDimension(oSolidWorksDispDim)
                'Loop
                PartParameters.Add(oSolidWorksSubFeat.Name)
                oSolidWorksSubFeat = oSolidWorksSubFeat.GetNextSubFeature
            Loop
            'oSolidWorksDispDim = oSwFeat.GetFirstDisplayDimension
            'Do While Not oSolidWorksDispDim Is Nothing
            '    oSolidWorksAnn = oSolidWorksDispDim.GetAnnotation
            '    oSolidWorksDim = oSolidWorksDispDim.GetDimension
            '    PartParameters.Add(oSolidWorksDim.FullName)
            '    oSolidWorksDispDim = oSwFeat.GetNextDisplayDimension(oSolidWorksDispDim)
            'Loop
            oSwFeat = oSwFeat.GetNextFeature
        Loop
        GetPartParametersPartAndAssemblies = PartParameters
    End Function


    'Public Sub DxfConversion(ByVal _strDrawingFileName As String)
    '    Dim aSheetName As Array
    '    Dim _lngErrors As Long
    '    Dim _lngWarnings As Long
    '    Dim _blnShowMap As Boolean
    '    Dim i As Long
    '    Dim _blnRet As Boolean
    '    Dim oSwModel As SldWorks.ModelDoc2 = Nothing
    '    Dim oSwDraw As SldWorks.DrawingDoc = Nothing
    '    Dim oSwDXFDontShowMap As Integer = 21
    '    Dim oSwSaveAsCurrentVersion = 0  '  default
    '    Dim oSwSaveAsFormatProE = 2
    '    Dim oSwSaveAsOptions_Silent = &H1

    '    Dim oFileData As FileInfo = My.Computer.FileSystem.GetFileInfo(_strDrawingFileName)
    '    Try
    '        If IsCurrentSolidWorks Is Nothing Then
    '            oIflBaseSolidWorksClass = New IFLSolidWorksBaseClass(True)
    '        End If

    '        If oFileData.Extension = ".SLDDRW" Then
    '            oIflBaseSolidWorksClass.openDocument(_strDrawingFileName)
    '            oIflBaseSolidWorksClass.SolidWorksApplicationObject.Visible = True
    '            'oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc
    '            oSwDraw = oSwModel
    '            oIflBaseSolidWorksClass.SolidWorksApplicationObject.SetUserPreferenceToggle(21, True)
    '            oIflBaseSolidWorksClass.SolidWorksApplicationObject.SetUserPreferenceToggle(oSwDXFDontShowMap, True)

    '            aSheetName = oSwDraw.GetSheetNames
    '            For i = 0 To UBound(aSheetName)

    '                _blnRet = oSwDraw.ActivateSheet(aSheetName(i))
    '                _blnRet = oSwModel.SaveAs4(aSheetName(i) & ".dxf", oSwSaveAsCurrentVersion, oSwSaveAsOptions_Silent, _lngErrors, _lngWarnings)
    '                Debug.Assert(_blnRet)
    '            Next i
    '            _blnRet = oSwDraw.ActivateSheet(aSheetName(0))
    '            oIflBaseSolidWorksClass.SolidWorksApplicationObject.SetUserPreferenceToggle(oSwDXFDontShowMap, _blnShowMap)
    '        End If

    '    Catch oException As Exception
    '        _strErrorMessage = "UNABLE TO CONVERT THE DRAWING INTO DXF FORMAT !!" + vbCrLf
    '        _strErrorMessage += "System generated error:-" + vbCrLf + oException.Message
    '        _oErrorObject = oException
    '    End Try
    'End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Sub New()
        MyBase.New(True)
    End Sub

    Public Sub ProcessDirectory(ByVal targetDirectory As String, Optional ByVal blnSearchSubDir As Boolean = False)
        Dim arrAsmFileEntries As String()
        Dim arrPartFileEntries As String()
        Dim sCompName As String()
        Dim intI As Integer
        Dim intJ As Integer
        intI = 0
        intJ = 0
        Dim strSplit
        Dim strFileName As String
        arrAsmFileEntries = Nothing
        arrPartFileEntries = Nothing
        If IsCurrentSolidWorks Is Nothing Then
            oIflBaseSolidWorksClass = New IFLSolidWorksBaseClass(True)
        End If
        oIflBaseSolidWorksClass.SolidWorksApplicationObject.CommandInProgress = True
        Dim blnRet As Boolean = oIflBaseSolidWorksClass.SolidWorksApplicationObject.SetCurrentWorkingDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath)
        oIflBaseSolidWorksClass.SolidWorksApplicationObject.CommandInProgress = False
        Dim arrFileEntries As String() = Directory.GetFiles(targetDirectory)
        ReDim sCompName(0)
        strFileName = Nothing

        For intCount As Integer = 0 To UBound(arrFileEntries)
            strSplit = Split(arrFileEntries(intCount), ".")
            If UCase(strSplit(UBound(strSplit))) = UCase("SLDASM") Then
                If arrAsmFileEntries Is Nothing Then
                    ReDim arrAsmFileEntries(intI)
                    arrAsmFileEntries(intI) = arrFileEntries(intCount)
                Else
                    intI = intI + 1
                    ReDim Preserve arrAsmFileEntries(intI)
                    arrAsmFileEntries(intI) = arrFileEntries(intCount)
                End If
            ElseIf UCase(strSplit(UBound(strSplit))) = UCase("SLDPRT") Then
                If arrPartFileEntries Is Nothing Then
                    ReDim arrPartFileEntries(intJ)
                    arrPartFileEntries(intJ) = arrFileEntries(intCount)
                Else
                    intJ = intJ + 1
                    ReDim Preserve arrPartFileEntries(intJ)
                    arrPartFileEntries(intJ) = arrFileEntries(intCount)
                End If
            End If
        Next intCount

        If Not arrPartFileEntries Is Nothing Then
            For intCount As Integer = 0 To UBound(arrPartFileEntries)
                If arrPartFileEntries(intCount).ToString.IndexOf("~$") = -1 Then         '02_10_2009    ragava
                    updatePartModels(arrPartFileEntries(intCount))
                End If
            Next
        End If
        If Not arrAsmFileEntries Is Nothing Then
            For intCount As Integer = 0 To UBound(arrAsmFileEntries)
                If arrAsmFileEntries(intCount).ToString.IndexOf("~$") = -1 Then         '02_10_2009    ragava
                    'Dim strpath As String = arrAsmFileEntries(intCount).Replace("~$", "")
                    If IsCurrentSolidWorks Is Nothing Then
                        oIflBaseSolidWorksClass = New IFLSolidWorksBaseClass(True)
                    End If
                    blnRet = oIflBaseSolidWorksClass.SolidWorksApplicationObject.SetCurrentWorkingDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath)

                    oIflBaseSolidWorksClass.openDocument(arrAsmFileEntries(intCount))
                    'SolidWorksModel = SolidWorksApplicationObject.ActiveDoc
                    Try
                        oIflBaseSolidWorksClass.SolidWorksModel = SolidWorksApplicationObject.ActiveDoc           '06_04_2010   RAGAVA
                        oIflBaseSolidWorksClass.SolidWorksModel.ViewZoomtofit2()            '02_09_2009   ragava
                    Catch ex As Exception

                    End Try


                    Try
                        updateCustomProperties(arrAsmFileEntries(intCount))         '08_09_2009  ragava
                    Catch ex As Exception
                        MsgBox("Error in Updating Custom Properties")
                    End Try
                    oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActivateDoc(arrAsmFileEntries(intCount))


                    oIflBaseSolidWorksClass.SolidWorksModel.EditRebuild3()             '02_09_2009   ragava
                    Try
                        DeleteDesignTable(arrAsmFileEntries(intCount))        '02_09_2009   ragava
                    Catch ex As Exception

                    End Try
                    Common_TraversAndDeletions_And_SuppressionParts()
                    oIflBaseSolidWorksClass.SaveAndCloseAllDocuments()       '02_09_2009   ragava


                    '14_07_2010   RAGAVA
                    'Renaming can start here
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable
                    Dim filename As String = arrAsmFileEntries(intCount)
                    Dim arrpart As String() = filename.Split("\")
                    Dim strPart As String = arrpart(UBound(arrpart))
                    If Not (strPart.IndexOf("PISTON") <> -1 OrElse strPart.IndexOf("CYL HEAD WIRE RING") <> -1 OrElse strPart.IndexOf("7") <> -1 OrElse strPart.IndexOf("6") <> -1 OrElse strPart.IndexOf("5") <> -1) Then
                        Dim strCodeNumber As String
                        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.ContainsKey(strPart.Substring(0, strPart.IndexOf("."))) Then
                            If strPart.IndexOf("CYL HEAD") <> -1 Then
                                strCodeNumber = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("CYL HEAD")
                            Else
                                strCodeNumber = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(strPart.Substring(0, strPart.IndexOf(".")))
                            End If
                        Else
                            strCodeNumber = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPurchaseAndManufactureCode(strPart.Substring(0, strPart.IndexOf(".")))
                        End If
                        Dim strModelNetworkPath As String = "X:\WeldedModels"
                        Dim strNewPartPath As String = filename.Substring(0, filename.LastIndexOf("\")) & "\" & strCodeNumber.ToString & ".SLDASM"
                        Dim strReferenceAssm As String
                        If filename.IndexOf("BASE") <> -1 OrElse filename.IndexOf("BEC") <> -1 OrElse filename.IndexOf("COLLAR") <> -1 OrElse filename.IndexOf("BORE_IFL") <> -1 Then
                            strReferenceAssm = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath & "\TUBE_WELDMENT\TUBE_WELDMENT.SLDASM"
                        ElseIf filename.IndexOf("ROD") <> -1 AndAlso filename.IndexOf("ROD_WELDMENT.SLDASM") = -1 Then
                            strReferenceAssm = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath & "\ROD_WELDMENT\ROD_WELDMENT.SLDASM"
                        Else
                            strReferenceAssm = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath & "\WELD_CYLINDER_ASSEMBLY\WELD_CYLINDER_ASSEMBLY.SLDASM"
                        End If
                        If filename.IndexOf("WELD_CYLINDER_ASSEMBLY.SLDASM") <> -1 Then
                            Dim bret As Boolean = False
                            Try
                                InsertTextBox()            '02_08_2010    RAGAVA
                                strNewPartPath = filename.Substring(0, filename.LastIndexOf("\")) & "\" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber & ".SLDASM"
                                Dim oDrawingPath As String = filename.Substring(0, filename.LastIndexOf("\")) & "\WELD_CYLINDER_ASSEMBLY.SLDDRW"
                                Rename(filename, strNewPartPath)
                                bret = SolidWorksApplicationObject.ReplaceReferencedDocument(oDrawingPath, filename, strNewPartPath)
                                Dim strAssy As String() = strNewPartPath.Split("\")
                                Dim strPartName As String = "\" & strAssy(UBound(strAssy))
                                'FileCopy(strNewPartPath, strModelNetworkPath & strPartName)
                                Dim nDrawingPath As String = filename.Substring(0, filename.LastIndexOf("\")) & strNewPartPath.Substring(strNewPartPath.LastIndexOf("\"), strNewPartPath.IndexOf(".") - strNewPartPath.LastIndexOf("\")) & ".SLDDRW"
                                Rename(oDrawingPath, nDrawingPath)
                                bret = SolidWorksApplicationObject.ReplaceReferencedDocument(strNewPartPath, oDrawingPath, nDrawingPath)
                                If File.Exists(strModelNetworkPath & "\" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString & ".SLDASM") = True Then
                                    Try
                                        File.Delete(strModelNetworkPath & "\" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString & ".SLDASM")
                                    Catch ex As Exception
                                        MsgBox("Error in Deleting " & strModelNetworkPath & "\" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString & ".SLDASM")
                                    End Try
                                End If
                                File.Copy(strNewPartPath, strModelNetworkPath & "\" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString & ".SLDASM")
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AssyGeneratePath = strModelNetworkPath & "\" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString & ".SLDASM"
                                bret = SolidWorksApplicationObject.ReplaceReferencedDocument(nDrawingPath, strNewPartPath, strModelNetworkPath & "\" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString & ".SLDASM")
                                If Directory.Exists("W:\WeldedDrawings") = False Then
                                    Directory.CreateDirectory("W:\WeldedDrawings")
                                End If
                                If File.Exists("W:\WeldedDrawings\" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString & ".SLDDRW") = True Then
                                    Try
                                        File.Delete("W:\WeldedDrawings\" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString & ".SLDDRW")
                                    Catch ex As Exception
                                        MsgBox("Error in deleting " & "W:\WeldedDrawings\" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString & ".SLDDRW")
                                    End Try
                                End If
                                File.Copy(nDrawingPath, "W:\WeldedDrawings\" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString & ".SLDDRW")
                                bret = SolidWorksApplicationObject.ReplaceReferencedDocument(strModelNetworkPath & "\" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString & ".SLDASM", nDrawingPath, "W:\WeldedDrawings\" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString & ".SLDDRW")
                            Catch ex As Exception

                            End Try
                        Else
                            RenamePartFile(filename, strNewPartPath, strReferenceAssm)
                            FolderStructure(strReferenceAssm, strNewPartPath, strModelNetworkPath)
                            RenameDrawing(filename, strNewPartPath.Replace(".SLDASM", ".SLDDRW"), strNewPartPath, strModelNetworkPath & "\" & strCodeNumber.ToString & ".SLDASM")
                        End If
                    End If
                    'Till   Here


                End If
                'Opening Drawing
                'IFLSolidWorksBaseClassObject.openDocument(arrAsmFileEntries(intCount).Replace(".SLDASM", ".SLDDRW"))           '02_09_2009   ragava
            Next
        End If

        If blnSearchSubDir = True Then
            Dim subdirectoryEntries As String() = Directory.GetDirectories(targetDirectory)
            Dim subdirectory As String
            For Each subdirectory In subdirectoryEntries
                ProcessDirectory(subdirectory)
            Next subdirectory
        End If
    End Sub
    Public Sub updatePartModels(ByVal fileName As String)
        Dim strpath As String = fileName.Replace("~$", "")
        If Not String.Compare(fileName, strpath) = 0 Then
            Exit Sub
        End If
        Dim blnRet As Boolean = oIflBaseSolidWorksClass.SolidWorksApplicationObject.SetCurrentWorkingDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath)
        oIflBaseSolidWorksClass.SolidWorksApplicationObject.CommandInProgress = True
        Try
            oIflBaseSolidWorksClass.SolidWorksApplicationObject.CommandInProgress = True
            oIflBaseSolidWorksClass.openDocument(fileName)
            oIflBaseSolidWorksClass.SolidWorksApplicationObject.CommandInProgress = False
            If Not oIflBaseSolidWorksClass.SolidWorksModel Is Nothing Then
                oIflBaseSolidWorksClass.SolidWorksModel.ViewZoomtofit2()
                Try
                    updateCustomProperties(fileName)         '08_09_2009  ragava
                Catch ex As Exception
                    MsgBox("Error in Updating Custom Properties")
                End Try
                oIflBaseSolidWorksClass.SolidWorksModel.EditRebuild3()
                Try
                    DeleteDesignTable(fileName)
                Catch EX As Exception
                End Try
                Try
                    oIflBaseSolidWorksClass.SaveAndCloseAllDocuments()
                Catch ex As Exception
                End Try
                '14_07_2010   RAGAVA
                'Renaming can start here
                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable
                Dim arrpart As String() = fileName.Split("\")
                Dim strPart As String = arrpart(UBound(arrpart))
                If Not (strPart.IndexOf("PISTON") <> -1 OrElse strPart.IndexOf("CYL HEAD WIRE RING") <> -1 OrElse strPart.IndexOf("7") <> -1 OrElse strPart.IndexOf("6") <> -1 OrElse strPart.IndexOf("5") <> -1) Then
                    Dim strCodeNumber As String
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.ContainsKey(strPart.Substring(0, strPart.IndexOf("."))) Then
                        If strPart.IndexOf("CYL HEAD") <> -1 Then
                            strCodeNumber = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("CYL HEAD")
                        Else
                            strCodeNumber = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(strPart.Substring(0, strPart.IndexOf(".")))
                        End If
                    Else
                        strCodeNumber = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPurchaseAndManufactureCode(strPart.Substring(0, strPart.IndexOf(".")))
                    End If
                    Dim strModelNetworkPath As String = "X:\WeldedModels"
                    Dim strNewPartPath As String = fileName.Substring(0, fileName.LastIndexOf("\")) & "\" & strCodeNumber.ToString & ".SLDPRT"
                    Dim strReferenceAssm As String
                    If fileName.IndexOf("BASE") <> -1 OrElse fileName.IndexOf("BEC") <> -1 OrElse fileName.IndexOf("COLLAR") <> -1 OrElse fileName.IndexOf("BORE_IFL") <> -1 Then
                        strReferenceAssm = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath & "\TUBE_WELDMENT\TUBE_WELDMENT.SLDASM"
                    ElseIf fileName.IndexOf("ROD") <> -1 Then
                        strReferenceAssm = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath & "\ROD_WELDMENT\ROD_WELDMENT.SLDASM"
                    Else
                        strReferenceAssm = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath & "\WELD_CYLINDER_ASSEMBLY\WELD_CYLINDER_ASSEMBLY.SLDASM"
                    End If
                    RenamePartFile(fileName, strNewPartPath, strReferenceAssm)
                    FolderStructure(strReferenceAssm, strNewPartPath, strModelNetworkPath)
                    RenameDrawing(fileName, strNewPartPath.Replace(".SLDPRT", ".SLDDRW"), strNewPartPath, strModelNetworkPath & "\" & strCodeNumber.ToString & ".SLDPRT")
                End If
                'Till   Here
            End If
        Catch ex As Exception
        End Try
    End Sub

    '14_07_2010   RAGAVA
    Private Sub RenameDrawing(ByVal OriginalPartName As String, ByVal DrawingPath As String, ByVal ReNamePart As String, ByVal strPartNetworkpath As String)
        Try
            'Dim Drawingpath As String = PartPath.Substring(0, PartPath.IndexOf(".")) & ".SLDDRW"
            Dim bret As Boolean = False
            Dim OriginalDrawingPath As String = OriginalPartName.Substring(0, OriginalPartName.IndexOf(".")) & ".SLDDRW"
            If File.Exists(OriginalDrawingPath) = True Then
                bret = SolidWorksApplicationObject.ReplaceReferencedDocument(OriginalDrawingPath, OriginalPartName, ReNamePart)
                Dim strRenameDrawing As String = ReNamePart.Substring(0, ReNamePart.IndexOf(".")) & ".SLDDRW"
                Rename(OriginalDrawingPath, strRenameDrawing)
                'can be skiped
                'bret = SolidWorksApplicationObject.ReplaceReferencedDocument(strRenameDrawing, ReNamePart, strPartNetworkpath)
                Dim strDrawing As String() = strRenameDrawing.Split("\")
                Dim strDrawingName As String = strDrawing(UBound(strDrawing))
                File.Copy(strRenameDrawing, "W:\" & strDrawingName)
                bret = SolidWorksApplicationObject.ReplaceReferencedDocument("W:\" & strDrawingName, ReNamePart, strPartNetworkpath)
            End If
        Catch ex As Exception
        End Try
    End Sub

    '29_03_2010  ragava
    Public Sub updateCustomProperties(ByVal strFileName As String)
        Try
            Dim strMaterial, strDescription, strCode, strMar, strDesignation As String
            Dim strAssyNotes, strPaintNotes, strGeneralNotes As String
            Dim strDate As String = UCase(Format(Date.Today, "dMMMyy"))
            strAssyNotes = String.Empty
            strPaintNotes = String.Empty
            strGeneralNotes = String.Empty
            strMaterial = String.Empty
            strDescription = String.Empty
            strCode = String.Empty
            strMar = String.Empty
            strDesignation = String.Empty
            If strFileName.IndexOf("\BASE_CROSSTUBE\") <> -1 Then
                strCode = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd
            End If
            checkProperty("DATE", strDate)
            checkProperty("USERNAME", "M.Dickenson")          '25_06_2010    RAGAVA
            If strFileName.IndexOf(".SLDASM") <> -1 Or strFileName.IndexOf(".sldasm") <> -1 Then
                checkProperty("ROD END PORT DESCRIPTION THREAD", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_RodEnd + " - " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_RodEnd + " PORT TYP.")
                checkProperty("TUBE MATERIAL AND DIMENSIONS", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " ID-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeOD.ToString + " OD " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeMaterial + " - " + ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.TubeMaterialCode)
                checkProperty("CYLINDER THREAD DETAILS", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadSize_RodEnd.ToString)
                checkProperty("TUBE HARDENED AND WELD SYMBOLS", "")
                checkProperty("BASE END EXISTING FABRICATED WELD DESCRIPTION", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ColumnLoadDeratePressure.ToString + " PSI WELD")
                checkProperty("TUBE WELDMENT SYMBOL", ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text.ToString + " WELD SYMBOL")
                checkProperty("PORT IN CASTING THREAD DESCRIPTION", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadSize_RodEnd.ToString + " THREADED STD")
                checkProperty("ZERK1 DESCRIPTION", "1/4 TAPPED THREAD")
                checkProperty("ZERK2 DESCRIPTION", "1/4 TAPPED THREAD")
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_RodEnd Is Nothing Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_RodEnd = ""
                End If
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_RodEnd Is Nothing Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_RodEnd = ""
                End If
                checkProperty("PORT ASSEMBLY WELDING DESCRIPTION", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_RodEnd.ToString + " " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_RodEnd.ToString + " WELD")
                checkProperty("BASE END PORT DESCRIPTION", ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text.ToString + " " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_BaseEnd.ToString + " PORT")
                checkProperty("BASE END PORT WELDING DESCRIPTION", ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text.ToString + " WELD")
                checkProperty("ROD END PORT WELDING DESCRIPTION", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_RodEnd.ToString + " WELD")
                checkProperty("CODE", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString)
                checkProperty("Painting_Optional_Note", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strPaintPackagingNotes)      '31_03_2010    RAGAVA
                checkProperty("Assembly_Optional_Note", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strAssemblyNotes)      '31_03_2010    RAGAVA
            ElseIf strFileName.IndexOf(".SLDPRT") <> -1 Or strFileName.IndexOf(".sldprt") <> -1 Then
                If strFileName.IndexOf("ROD") = -1 Then
                    checkProperty("CODE", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd)
                    checkProperty("PORT SIZE DETAILS", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_BaseEnd)
                Else
                    checkProperty("CODE", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd)
                    checkProperty("PORT SIZE DETAILS", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_RodEnd)
                End If
                checkProperty("THREAD_NOTE", "RAGAVA")
                'STANDARD_CALL_OUT                 for Rod_Weldment
                If strFileName.IndexOf("TUBE_WELDMENT") <> -1 Then
                    'TUBE WELDMENT
                    checkProperty("ROD END PORT DESCRIPTION THREAD", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_RodEnd)
                    'TUBE MATERIAL AND DI,MENSIONS
                    'CYLINDER THREAD DETAILS
                    'TUBE HARDENED AND WELD SYMBOLS
                    'BASE END EXISTING FABRICATED WELD DESRIP
                    'TUBE WELDMENT SYMBOL
                    'PORT IN CASTING THREAD DESCRIPTION
                    'ZERK1 DESCRIPTION
                    'ZERK2 DESCRIPTION
                    'PORT ASSEMBLY WELDING DESCRI
                    'BASE END PORT DESCRIPTION
                    'BASE END PORT WELDING DESC
                    'ROD END PORT WELDING DESCRIPTION
                End If
            End If
            '****************************************************
            '22_06_2010   RAGAVA
            If strFileName.IndexOf("TUBE_WELDMENT") <> -1 Or strFileName.IndexOf("PISTON") <> -1 Or strFileName.IndexOf("ROD_WELDMENT") <> -1 Or strFileName.IndexOf("CYLINDER_HEAD") <> -1 Or strFileName.IndexOf("STOP TUBE") <> -1 Or (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected = True AndAlso (strFileName.IndexOf("SINGLELUG") <> -1 OrElse strFileName.IndexOf("DOUBLELUG") <> -1 OrElse strFileName.IndexOf("THREADEDEND") <> -1 OrElse strFileName.IndexOf("CROSSTUBE") <> -1 OrElse strFileName.IndexOf("BASEPLUG") <> -1)) Then
                If strFileName.IndexOf("ROD_WELDMENT") <> -1 Then
                    checkProperty("Material", "")
                ElseIf strFileName.IndexOf("CYLINDER_HEAD") <> -1 Then
                    checkProperty("Material", "C1045")
                ElseIf strFileName.IndexOf("STOP TUBE") <> -1 Then
                    checkProperty("Material", "C1020")
                End If
                checkProperty("Drawn", "IdolaFori")
                checkProperty("Designed", UCase(System.Environment.UserName.ToString))
                checkProperty("Approved", "")
                checkProperty("Date", strDate)
                checkProperty("Scale", "NTS")
                checkProperty("Mat#", "")
                checkProperty("Description", "NEED TO GET FROM MONARCH")
                checkProperty("Code", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd)

                '28_06_2010   RAGAVA
                Dim strDocName As String = String.Empty
                If strFileName.IndexOf("TUBE_WELDMENT") <> -1 Then
                    'If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                    openAssemblyDrawingDocument(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\TUBE_WELDMENT\TUBE_WELDMENT.SLDDRW")
                    strDocName = "TUBE_WELDMENT.SLDDRW"
                    'Else
                    '    openAssemblyDrawingDocument(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\TUBE_WELDMENT\TUBE_WELDMENT_90DEG.SLDDRW")
                    '    strDocName = "TUBE_WELDMENT_90DEG.SLDDRW"
                    'End If
                    SolidWorksModel = SolidWorksApplicationObject.ActivateDoc(strDocName)
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength >= 25 Then
                        BreakView("Drawing View1")
                        SolidWorksModel = SolidWorksApplicationObject.ActivateDoc(strDocName)
                        BreakView("Section View A-A")
                    End If
                    '14_07_2010   RAGAVA
                    Try
                        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "New" Then
                            DeleteView("Drawing View11")
                            DeleteView("Drawing View12")
                            DeleteDetailedCircle("Detail Circle3")
                            DeleteDetailedCircle("Detail Circle4")
                            DeleteDetailItem("DetailItem407@Drawing View3", "Drawing View3")
                            DeleteDetailItem("DetailItem408@Drawing View3", "Drawing View3")
                            DeleteSketchSegment("Arc14")
                            DeleteSketchSegment("Arc15")
                        Else
                            DeleteView("Drawing View10")
                            DeleteDetailedCircle("Detail Circle2")
                            DeleteDetailItem("DetailItem410@Drawing View3", "Drawing View3")
                            DeleteDetailItem("DetailItem409@Drawing View3", "Drawing View3")
                            If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port Integral" Then
                                DeleteDetailItem("DetailItem407@Drawing View3", "Drawing View3")
                            End If
                            DeleteSketchSegment("Arc13")
                        End If
                    Catch ex As Exception
                    End Try
                    'Till   here
                ElseIf strFileName.IndexOf("ROD_WELDMENT") <> -1 Then
                    openAssemblyDrawingDocument(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD_WELDMENT\ROD_WELDMENT.SLDDRW")
                    SolidWorksModel = SolidWorksApplicationObject.ActivateDoc("ROD_WELDMENT.SLDDRW")
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength >= 25 Then
                        BreakView("Drawing View1")
                        SolidWorksModel = SolidWorksApplicationObject.ActivateDoc("ROD_WELDMENT.SLDDRW")
                        BreakView("Drawing View2")
                    End If
                End If
                'Till   Here
            ElseIf strFileName.IndexOf("WELD_CYLINDER_ASSEMBLY") <> -1 Then
                '25_06_2010    RAGAVA
                Dim strGeneralNote As String
                strGeneralNote = "BORE " + Format(Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, 2), "00.00") + " X " + Format(Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength, 2), "00.00") + vbNewLine + " Max. Working Pressure " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure.ToString + " PSI" + vbNewLine
                If Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PartCode_ContractDetails) <> "" Then
                    strGeneralNote = strGeneralNote + "Customer Part # " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PartCode_ContractDetails
                End If
                'Till  Here
                checkProperty("Material", "")
                checkProperty("Drawn", "IdolaFori")
                checkProperty("Designed", UCase(System.Environment.UserName.ToString))
                checkProperty("Approved", "")
                checkProperty("Date", strDate)
                checkProperty("Scale", "NTS")
                checkProperty("Mat#", "")
                checkProperty("Description", "<MOD-DIAM> " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " Welded Cylinder")
                checkProperty("Customer Name", "For " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CustomerName_ContractDetails.ToString)
                checkProperty("Code", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString)     '06_07_2010   RAGAVA
                checkProperty("PORT TYPE", ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeRodEnd.SelectedItem.ToString + " " + ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortTypeRodEnd.SelectedItem.ToString + " PORT TYP REF.")           '06_07_2010   RAGAVA
                checkProperty("Cylinder Note", Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter * 10, 2).ToString + "WD" + Format(Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength, 2), "00.00") + "-" + (Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter, 2) * 100).ToString)      '07_07_2010    RAGAVA
                checkProperty("General_Note", strGeneralNote)      '25_06_2010    RAGAVA
                UpdateAssemblyDrawing()        '23_06_2010   RAGAVA
                '28_06_2010   RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength >= 25 Then
                    'If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                    '    openAssemblyDrawingDocument(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\WELD_CYLINDER_ASSEMBLY\WELD_CYLINDER_ASSEMBLY-0.SLDDRW")
                    '    SolidWorksModel = SolidWorksApplicationObject.ActivateDoc("WELD_CYLINDER_ASSEMBLY-0.SLDDRW")
                    'ElseIf ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "90" Then
                    openAssemblyDrawingDocument(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\WELD_CYLINDER_ASSEMBLY\WELD_CYLINDER_ASSEMBLY.SLDDRW")
                    SolidWorksModel = SolidWorksApplicationObject.ActivateDoc("WELD_CYLINDER_ASSEMBLY.SLDDRW")
                    'End If
                    BreakView("Drawing View2")
                    BreakView("Section View A-A")
            End If
                'Till   Here
            End If
            SolidWorksApplicationObject.IActiveDoc.SaveSilent()
        Catch ex As Exception
            MsgBox("Error in Updating Notes to CustomProperties")
        End Try
    End Sub

    '14_07_2010  ragava
    Public Sub DeleteSketchSegment(ByVal strItem As String)
        Try
            Dim boolstatus As Boolean = False
            SolidWorksModel = SolidWorksApplicationObject.ActiveDoc
            boolstatus = SolidWorksModel.Extension.SelectByID2(strItem, "SKETCHSEGMENT", 0, 0, 0, False, 0, Nothing, 0)
            SolidWorksModel.EditDelete()
            SolidWorksModel.ClearSelection2(True)
        Catch ex As Exception
            MsgBox("Error in Deleting SKETCH SEGMENT")
        End Try
    End Sub

    '14_07_2010   RAGAVA
    Public Sub RenamePartFile(ByVal strOldName As String, ByVal strNewName As String, ByVal strReferencingDoc As String)
        Try
            Dim bret As Boolean = False
            Rename(strOldName, strNewName)
            bret = SolidWorksApplicationObject.ReplaceReferencedDocument(strReferencingDoc, strOldName, strNewName)
        Catch ex As Exception
        End Try
    End Sub
    '14_07_2010   RAGAVA
    Public Sub FolderStructure(ByVal strReferenceDoc As String, ByVal strNewPartPath As String, ByVal strNetworkPath As String)
        Try
            Dim bRet As Boolean = False
            Dim strPart() As String = strNewPartPath.Split("\")
            Dim strPartName As String = "\" & strPart(UBound(strPart))
            FileCopy(strNewPartPath, strNetworkPath & strPartName)
            bRet = SolidWorksApplicationObject.ReplaceReferencedDocument(strReferenceDoc, strNewPartPath, strNetworkPath & strPartName)
        Catch ex As Exception
        End Try
    End Sub
    '14_07_2010   RAGAVA
    Public Sub MoveDrawingFile(ByVal strOldDrawingPath As String, ByVal strNewPartPath As String, ByVal strNetworkDrawingPath As String, ByVal strNetworkPartPath As String)
        Try
            Dim bRet As Boolean = False

            'If File.Exists(strNetworkPath) = False Then
            FileCopy(strOldDrawingPath, strNetworkDrawingPath)
            bRet = SolidWorksApplicationObject.ReplaceReferencedDocument(strNetworkDrawingPath, strNewPartPath, strNetworkPartPath)
        Catch ex As Exception
        End Try
    End Sub

    '14_07_2010   RAGAVA
    Public Sub RenameDrawingFile(ByVal strReferencingDoc As String, ByVal strOldName As String, ByVal strNewName As String)
        Try
            Dim bret As Boolean = False
            bret = SolidWorksApplicationObject.ReplaceReferencedDocument(strReferencingDoc, strOldName, strNewName)
            strOldName = strReferencingDoc
            If strNewName.IndexOf(".SLDPRT") <> -1 Then
                Rename(strOldName, strNewName.Replace(".SLDPRT", ".SLDDRW"))
            Else
                Rename(strOldName, strNewName.Replace(".SLDASM", ".SLDDRW"))
            End If
        Catch ex As Exception
        End Try
    End Sub

    '23_06_2010   RAGAVA
    Public Sub UpdateAssemblyDrawing()
        Dim docName As String = String.Empty
        Try
            'If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
            '    openAssemblyDrawingDocument(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\WELD_CYLINDER_ASSEMBLY\WELD_CYLINDER_ASSEMBLY-0.SLDDRW")
            '    docName = "WELD_CYLINDER_ASSEMBLY-0.SLDDRW"
            'ElseIf ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "90" Then
            openAssemblyDrawingDocument(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\WELD_CYLINDER_ASSEMBLY\WELD_CYLINDER_ASSEMBLY.SLDDRW")
            docName = "WELD_CYLINDER_ASSEMBLY.SLDDRW"
            'End If
            SolidWorksModel = SolidWorksApplicationObject.ActivateDoc(docName)
            If (Val(ObjClsWeldedCylinderFunctionalClass.TxtFirstPortOrientation_BaseEnd.Text) = 0 OrElse Trim(ObjClsWeldedCylinderFunctionalClass.TxtFirstPortOrientation_BaseEnd.Text) = "") Then
                DeleteView("Drawing View5")
            End If
            If (Val(ObjClsWeldedCylinderFunctionalClass.FirstPortOrientation_RodEnd) = 0 OrElse Trim(ObjClsWeldedCylinderFunctionalClass.FirstPortOrientation_RodEnd) = "") Then
                DeleteView("Drawing View6")
            End If
            '02_08_2010   RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories._blnIsBaseEndPinsPresent = False Then
                DeleteNote("DetailItem553@Drawing View2", "Drawing View2")
            End If
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories._blnIsRodEndPinsPresent = False Then
                DeleteNote("DetailItem557@Drawing View2", "Drawing View2")
            End If
            If Not (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Base Plug" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Single Lug" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug") Then
                DeleteSketchItem("Arc14", "Drawing View2")
            End If
            If Not (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Single Lug" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug") Then
                DeleteSketchItem("Arc15", "Drawing View2")
            End If
            'Till   Here
            SolidWorksApplicationObject.IActiveDoc.SaveSilent()
        Catch ex As Exception
        End Try
    End Sub

    '02_08_2010  RAGAVA
    Public Sub DeleteSketchItem(ByVal strSketchName As String, ByVal strViewName As String)
        Try
            Dim boolstatus As Boolean = False
            SolidWorksModel = SolidWorksApplicationObject.ActiveDoc
            boolstatus = SolidWorksModel.ActivateView(strViewName)
            boolstatus = SolidWorksModel.Extension.SelectByID2(strSketchName, "SKETCHSEGMENT", 0, 0, 0, False, 0, Nothing, 0)
            SolidWorksModel.EditDelete()
            SolidWorksModel.ClearSelection2(True)
        Catch ex As Exception
            MsgBox("Error in deleting SketchSegment")
        End Try
    End Sub

    '15_09_2009   ragava
    Public Sub OverwriteDimensionNote(ByVal strDimension As String, ByVal Value As String, ByVal strViewName As String, Optional ByVal strSheet As String = "Sheet1")
        Try
            Dim boolstatus As Boolean = False
            oIflBaseSolidWorksClass.SolidWorksModel = SolidWorksApplicationObject.ActiveDoc
            boolstatus = SolidWorksModel.ActivateView(strViewName)
            boolstatus = SolidWorksModel.Extension.SelectByID2(strDimension, "DIMENSION", 0, 0, 0, False, 0, Nothing, 0)
            boolstatus = SolidWorksModel.EditDimensionProperties2(0, 0, 0, "", "", True, 9, 2, True, 12, 12, Value, "", False, "", "", True)
            SolidWorksModel.ClearSelection2(True)
            boolstatus = SolidWorksModel.ActivateSheet(strSheet)
            'IFLSolidWorksBaseClassObject.SolidWorksModel.SaveSilent()
        Catch ex As Exception
            MsgBox("Error in Overwritting Dimensions")
        End Try
    End Sub

    '15_09_2009   ragava
    Public Sub DeleteDetailItem(ByVal strDetailItem As String, ByVal strViewName As String)
        Try
            Dim boolstatus As Boolean = False
            SolidWorksModel = SolidWorksApplicationObject.ActiveDoc
            boolstatus = SolidWorksModel.ActivateView(strViewName)
            boolstatus = SolidWorksModel.Extension.SelectByID2(strDetailItem, "WELD", 0, 0, 0, False, 0, Nothing, 0)          '14_07_2010    RAGAVA
            SolidWorksModel.EditDelete()
            SolidWorksModel.ClearSelection2(True)
        Catch ex As Exception
            MsgBox("Error in Deleting Detail Item")
        End Try
        'Part.Extension.SelectByID2("DetailItem150@Drawing View2", "GTOL", 0.2245335748516, 0.1509591747284, 0, False, 0, Nothing, 0)
    End Sub
    '16_09_2009  ragava
    Public Sub DeleteDetailedCircle(ByVal strItem As String)
        Try
            Dim boolstatus As Boolean = False
            SolidWorksModel = SolidWorksApplicationObject.ActiveDoc
            boolstatus = SolidWorksModel.Extension.SelectByID2(strItem, "DETAILCIRCLE", 0, 0, 0, False, 0, Nothing, 0)
            SolidWorksModel.EditDelete()
            SolidWorksModel.ClearSelection2(True)
        Catch ex As Exception
            MsgBox("Error in Deleting Notes")
        End Try
    End Sub
    '15_09_2009  ragava
    Public Sub DeleteView(ByVal strViewItem As String) ', ByVal strViewName As String)
        Try
            Dim boolstatus As Boolean = False
            SolidWorksModel = SolidWorksApplicationObject.ActiveDoc
            boolstatus = SolidWorksModel.Extension.SelectByID2(strViewItem, "DRAWINGVIEW", 0, 0, 0, False, 0, Nothing, 0)
            SolidWorksModel.EditDelete()
            SolidWorksModel.ClearSelection2(True)
        Catch ex As Exception
            MsgBox("Error in Deleting View")
        End Try
        'boolstatus = Part.Extension.SelectByID2("Drawing View15", "DRAWINGVIEW", 0.1869608025198, 0.1926634818219, 0, False, 0, Nothing, 0)
    End Sub

    '15_09_2009  ragava
    Public Sub DeleteDimension(ByVal strDimension As String, ByVal strViewName As String)
        Try
            Dim boolstatus As Boolean = False
            SolidWorksModel = SolidWorksApplicationObject.ActiveDoc
            boolstatus = SolidWorksModel.ActivateView(strViewName)
            boolstatus = SolidWorksModel.Extension.SelectByID2(strDimension, "DIMENSION", 0, 0, 0, False, 0, Nothing, 0)
            SolidWorksModel.EditDelete()
            SolidWorksModel.ClearSelection2(True)
        Catch ex As Exception
            MsgBox("Error in Deleting Dimension")
        End Try
    End Sub

    '15_09_2009  ragava
    Public Sub DeleteNote(ByVal strNote As String, ByVal strViewName As String)
        Try
            Dim boolstatus As Boolean = False
            SolidWorksModel = SolidWorksApplicationObject.ActiveDoc
            boolstatus = SolidWorksModel.ActivateView(strViewName)
            boolstatus = SolidWorksModel.Extension.SelectByID2(strNote, "NOTE", 0, 0, 0, False, 0, Nothing, 0)
            SolidWorksModel.EditDelete()
            SolidWorksModel.ClearSelection2(True)
        Catch ex As Exception
            MsgBox("Error in Deleting Notes")
        End Try
    End Sub


    '28_06_2010  ragava
    Public Sub BreakView(ByVal strViewName As String) ', ByVal Length As Double, ByVal dblConst As Double, Optional ByVal strSheet As String = "Sheet1")
        Try
            Dim boolstatus As Boolean = False
            Dim sldBreakView As SldWorks.BreakLine
            SolidWorksModel = SolidWorksApplicationObject.ActiveDoc
            boolstatus = SolidWorksModel.ActivateView(strViewName)
            boolstatus = SolidWorksModel.Extension.SelectByID2(strViewName, "DRAWINGVIEW", 0, 0, 0, False, 0, Nothing, 0)
            SolidWorksView = SolidWorksModel.SelectionManager.GetSelectedObject5(1)
            sldBreakView = SolidWorksView.InsertBreak(0, -((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength - 5) * 25.4 / 4000), ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength - 5) * 25.4 / 4000), 2)             '04_11_2009   Ragava
            If sldBreakView Is Nothing Then
                sldBreakView = SolidWorksView.InsertBreak(0, -0.05, 0.05, 2)
            End If
            SolidWorksModel.BreakView()
            SolidWorksModel.EditRebuild3()
            SolidWorksModel.ClearSelection2(True)
            SolidWorksApplicationObject.IActiveDoc.SaveSilent()
        Catch ex As Exception
            MsgBox("Error in Breaking View")
        End Try
    End Sub

    Public Sub insertNewRow(ByVal RevisionNumber As Integer, ByVal nNumRow As Integer, ByVal swTable As SldWorks.TableAnnotation)
        ' RevisionNumber = RevisionNumber - 1
        If RevisionNumber >= 1 Then
            nNumRow = swTable.RowCount
            Dim boolstatus As Boolean = False
            boolstatus = swTable.InsertRow(SwConst.swTableItemInsertPosition_e.swTableItemInsertPosition_After, nNumRow - 1)
        End If
    End Sub
    '12_10_2009   ragava
    Public Sub DeleteBlocksFromAssyDrawing(ByVal strBlockName As String, Optional ByVal strViewName As String = "Drawing View1")
        Try
            Dim boolstatus As Boolean = False
            SolidWorksModel = SolidWorksApplicationObject.ActiveDoc
            SolidWorksDrawingDocument = SolidWorksModel
            boolstatus = SolidWorksDrawingDocument.ActivateView(strViewName)
            boolstatus = SolidWorksModel.Extension.SelectByID2(strBlockName, "SUBSKETCHINST", 0, 0, 0, False, 0, Nothing, 0)
            SolidWorksModel.EditDelete()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub DeleteNotes(ByVal NoteName As String, ByVal SheetName As String, ByVal type As String)
        Try
            Dim boolstatus As Boolean = False
            SolidWorksModel = SolidWorksApplicationObject.ActiveDoc
            SolidWorksDrawingDocument = SolidWorksModel
            boolstatus = SolidWorksDrawingDocument.ActivateSheet(SheetName)
            'boolstatus = SolidWorksModel.Extension.SelectByID2(NoteName, "ANNOTATIONTABLES", 0.02899951513396, 0.1938605657194, 0, False, 0, Nothing, 0)
            boolstatus = SolidWorksModel.Extension.SelectByID2(NoteName, type, 0.02899951513396, 0.1938605657194, 0, False, 0, Nothing, 0)

            SolidWorksModel.EditDelete()

        Catch ex As Exception

        End Try
    End Sub
    '20_10_2009  ragava
    Public Sub EditRetractedDimension(ByVal ExtendedLength As Double)
        Try
            'boolstatus = Part.ActivateView("Drawing View6")
            'boolstatus = Part.Extension.SelectByID2("RD3@Drawing View6", "DIMENSION", 0.1641108917438, 0.08079359789575, 0, False, 0, Nothing, 0)
            'boolstatus = Part.EditDimensionProperties2(4, 0.001524, 0, "", "", True, 9, 2, True, 12, 12, "", " RETRACTED", True, "", "", True)
            'boolstatus = Part.EditDimensionProperties2(4, 0.001524, 0, "", "", True, 9, 2, True, 12, 12, "", " RETRACTED", True, "", "(80.25 EXTENDED)", True)
            'Part.ClearSelection2(True)
            Dim boolstatus As Boolean = False
            SolidWorksModel = SolidWorksApplicationObject.ActiveDoc
            SolidWorksDrawingDocument = SolidWorksModel
            boolstatus = SolidWorksDrawingDocument.ActivateView("Drawing View6")
            boolstatus = SolidWorksModel.Extension.SelectByID2("RD3@Drawing View6", "DIMENSION", 0, 0, 0, False, 0, Nothing, 0)
            boolstatus = SolidWorksModel.EditDimensionProperties2(4, 0.001524, 0, "", "", True, 9, 2, True, 12, 12, "", " RETRACTED", True, "", "", True)
            boolstatus = SolidWorksModel.EditDimensionProperties2(4, 0.001524, 0, "", "", True, 9, 2, True, 12, 12, "", " RETRACTED", True, "", "(" & Math.Round(ExtendedLength, 2).ToString & " EXTENDED)", True)
            SolidWorksModel.ClearSelection2(True)
        Catch ex As Exception

        End Try
    End Sub
    '24_02_2010 Aruna Start
    Public Sub AddConfiguration(ByVal openFileName As String, ByVal Name As String, ByVal Comment As String, ByVal AlternateName As String)
        Try
            Dim instance As IModelDoc = Nothing
            Dim SuppressByDefault As Boolean
            Dim HideByDefault As Boolean
            Dim MinFeatureManager As Boolean
            Dim InheritProperties As Boolean
            Dim Flags As UInteger
            'X:\WELDED_STD_PARTS
            If IsCurrentSolidWorks Is Nothing Then
                oIflBaseSolidWorksClass = New IFLSolidWorksBaseClass(True)
            End If
            '02_03_2010   RAGVA
            If File.Exists(openFileName) = False Then
                'MsgBox("Drawing file doesn't exist at path : " + openFileName)
            End If
            oIflBaseSolidWorksClass.openDocument(openFileName)
            instance = SolidWorksApplicationObject.ActiveDoc
            instance.AddConfiguration(Name, Comment, AlternateName, SuppressByDefault, HideByDefault, MinFeatureManager, InheritProperties, Flags)
        Catch ex As Exception
        End Try
    End Sub


    '01_04_2010   ragava
    Public Sub InsertTableRowDrawing(ByVal iAssycount As Integer, ByVal iPaintcount As Integer, ByVal RevisionNumber As Integer, ByVal alGetRevisionTableData As ArrayList)
        Try
            Dim ArrswTable As Object
            Dim swTable As SldWorks.TableAnnotation
            Dim boolstatus As Boolean = False
            SolidWorksDrawingDocument = SolidWorksApplicationObject.ActiveDoc
            Dim myModelView As Object
            myModelView = SolidWorksDrawingDocument.ActiveView
            myModelView.FrameState = SwConst.swWindowState_e.swWindowMaximized
            SolidWorksModel = SolidWorksApplicationObject.ActiveDoc
            SolidWorksDrawingDocument = SolidWorksModel

            SolidWorksView = SolidWorksDrawingDocument.GetFirstView
            ArrswTable = SolidWorksView.GetTableAnnotations
            If SolidWorksView.GetTableAnnotationCount > 0 Then
                ' Get the Assembly Table
                swTable = ArrswTable(1)
                For i As Integer = 1 To iAssycount - 1
                    boolstatus = swTable.InsertRow(SwConst.swTableItemInsertPosition_e.swTableItemInsertPosition_After, 0)
                Next
            End If

            If SolidWorksView.GetTableAnnotationCount > 1 Then
                swTable = Nothing
                ' Get the Paint Table
                swTable = ArrswTable(2)
                If iPaintcount > 0 Then
                    For i As Integer = 1 To iPaintcount - 1
                        boolstatus = swTable.InsertRow(SwConst.swTableItemInsertPosition_e.swTableItemInsertPosition_After, 0)
                    Next
                Else

                End If

            End If
            If SolidWorksView.GetTableAnnotationCount > 2 Then
                swTable = Nothing
                ' Get the Revision Table
                Dim ntable As Integer = 0
                swTable = ArrswTable(ntable)
                Dim nNumRow As Integer
                '06_04_2010   RAGAVA
                swTable.Text(1, 0) = "P00"
                swTable.Text(1, 3) = UCase(Format(DateTime.Now, "ddMMMyy"))
                nNumRow = swTable.RowCount
                insertNewRow(RevisionNumber, nNumRow, swTable)
                'Till   Here
                If alGetRevisionTableData.Count > 0 Then
                    For Each oItem As Object In alGetRevisionTableData
                        nNumRow = swTable.RowCount
                        'swTable.Text(nNumRow - 1, 0) = oItem(0)
                        swTable.Text(nNumRow - 1, 0) = "P0" + oItem(0).ToString    '06_04_2010   RAGAVA
                        swTable.Text(nNumRow - 1, 1) = oItem(1)
                        swTable.Text(nNumRow - 1, 2) = UCase(oItem(2).ToString)
                        swTable.Text(nNumRow - 1, 3) = UCase(oItem(3).ToString)
                        swTable.Text(nNumRow - 1, 4) = UCase(oItem(4).ToString)
                        RevisionNumber = RevisionNumber - 1
                        insertNewRow(RevisionNumber, nNumRow, swTable)
                    Next
                End If
            End If
            SolidWorksModel.SaveSilent()
        Catch ex As Exception

        End Try
    End Sub
    '01_04_2010   RAGAVA
    Public Sub InsertTextBox()
        Dim docName As String = String.Empty
        Try
            'If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
            '    openAssemblyDrawingDocument(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\WELD_CYLINDER_ASSEMBLY\WELD_CYLINDER_ASSEMBLY-0.SLDDRW")
            '    docName = "WELD_CYLINDER_ASSEMBLY-0"
            'ElseIf ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "90" Then
            openAssemblyDrawingDocument(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\WELD_CYLINDER_ASSEMBLY\WELD_CYLINDER_ASSEMBLY.SLDDRW")
            docName = "WELD_CYLINDER_ASSEMBLY.SLDDRW"
            'End If
            SolidWorksModel = SolidWorksApplicationObject.ActivateDoc(docName)
            getMaxContractRevisionNumber()      '30_06_2010   RAGAVA
            InsertTableRowDrawing(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.iAssyNotesCount, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.iPaintingNotesCount, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.intContractRevisionNumber, getRevisionTableData)
            SolidWorksApplicationObject.IActiveDoc.SaveSilent()
            oIflBaseSolidWorksClass.SaveAndCloseAllDocuments()
        Catch ex As Exception

        End Try
        'TILL   HERE
    End Sub

    Public Sub getMaxContractRevisionNumber()
        Try
            Dim strSQL As String = ""
            strSQL = "Select  max(RevisionNumber) as RevisionNumber From revisionTable where ContractNumber='" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber & "'"
            Dim objDT As DataTable = MonarchConnectionObject.GetTable(strSQL)
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.intContractRevisionNumber = objDT.Rows(0)("RevisionNumber")
        Catch ex As Exception

        End Try
    End Sub

    '30_06_2010   RAGAVA
    Public Function getRevisionTableData() As ArrayList
        getRevisionTableData = Nothing
        Try
            getRevisionTableData = New ArrayList
            Dim strSQL As String
            Dim intCount As Integer
            Dim objDT As DataTable
            strSQL = "select  top 7  * from revisionTable  where contractNumber='" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber & "'"
            objDT = MonarchConnectionObject.GetTable(strSQL)
            If Not IsNothing(objDT) AndAlso objDT.Rows.Count < 7 Then
                intCount = objDT.Rows.Count
            Else
                intCount = 7
            End If
            For intj As Integer = 0 To intCount - 1
                getRevisionTableData.Add(New Object(4) {objDT.Rows(intj)("RevisionNumber"), objDT.Rows(intj)("ECR_Number"), objDT.Rows(intj)("DESCRIPTION"), objDT.Rows(intj)("DATE"), objDT.Rows(intj)("REVISEDBy")})
            Next
            Return getRevisionTableData
        Catch ex As Exception

        End Try
    End Function

    '30_06_2010   RAGAVA
    Public Sub UpdateRevisionTable(ByVal Description As String, ByVal Revision As String)
        Try
            Dim strDate As String = UCase(Format(Date.Today, "dMMMyy"))
            Dim strDescription As String
            Dim PropertyName As String
            PropertyName = "DESCRIPTION_"

            'Checking For Empty Description
            For i As Integer = 1 To 7
                strDescription = SolidWorksModel.GetCustomInfoValue("", PropertyName & i.ToString)
                If Trim(strDescription) = "" Then
                    checkProperty("DESCRIPTION_" & i.ToString, "ADD CODE # " & Description)
                    checkProperty("NO_" & i.ToString, Revision)
                    checkProperty("DATE_" & i.ToString, strDate)
                    Exit Sub
                End If
            Next
            'Checking For RevisionNumber
            PropertyName = "NO_"
            Dim iRevision, iRevision7 As Integer
            Dim strRevision As String = String.Empty
            For i As Integer = 7 To 1 Step -1        '23_10_2009  ragava
                strRevision = SolidWorksModel.GetCustomInfoValue("", PropertyName & i.ToString)
                If Trim(strRevision) = "-" Then
                    checkProperty("DESCRIPTION_" & i.ToString, "ADD CODE # " & Description)
                    checkProperty("NO_" & i.ToString, Revision)
                    checkProperty("DATE_" & i.ToString, strDate)
                    Exit Sub
                End If
            Next
            strRevision = SolidWorksModel.GetCustomInfoValue("", PropertyName & "7")
            iRevision7 = Convert.ToInt16(strRevision)
            For i As Integer = 2 To 7                 '23_10_2009   ragava
                strRevision = SolidWorksModel.GetCustomInfoValue("", PropertyName & i.ToString)
                If Trim(strRevision) <> "-" Then
                    iRevision = Convert.ToInt16(strRevision)
                    If iRevision <= iRevision7 Then
                        '23_10_2009   ragava
                        If i < 7 Then
                            For k As Integer = i To 6
                                strRevision = SolidWorksModel.GetCustomInfoValue("", "NO_" & (k + 1).ToString)
                                strDescription = SolidWorksModel.GetCustomInfoValue("", "DESCRIPTION_" & (k + 1).ToString)
                                Dim MyDate As String = SolidWorksModel.GetCustomInfoValue("", "DATE_" & (k + 1).ToString)
                                checkProperty("DESCRIPTION_" & k.ToString, "ADD CODE # " & strDescription)
                                checkProperty("NO_" & k.ToString, strRevision)
                                checkProperty("DATE_" & k.ToString, MyDate)
                            Next
                        End If
                        '23_10_2009   ragava    Till   Here
                        checkProperty("DESCRIPTION_" & i.ToString, "ADD CODE # " & Description)
                        checkProperty("NO_" & i.ToString, Revision)
                        checkProperty("DATE_" & i.ToString, strDate)
                        Exit Sub
                    End If
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub

End Class
