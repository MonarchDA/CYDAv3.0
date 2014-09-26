Imports SldWorks_ExtractBitmap
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
    Dim oSolidWorksDrawingDocument As SldWorks.DrawingDoc
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


                ' SolidWorksApplicationObject.SetUserPreferenceToggle(swUserPreferenceToggle_e.swShowErrorsEveryRebuild, False) 'vamsi 15-11-2013

                oIflBaseSolidWorksClass.SolidWorksApplicationObject.SetUserPreferenceToggle(77, False)


                'oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc
                oIflBaseSolidWorksClass.SolidWorksDrawingDocument = oIflBaseSolidWorksClass.SolidWorksModel
                oIflBaseSolidWorksClass.SolidWorksApplicationObject.SetUserPreferenceToggle(21, True)
                oIflBaseSolidWorksClass.SolidWorksApplicationObject.SetUserPreferenceToggle(_SwDXFDontShowMap, True)
                aSheetName = oIflBaseSolidWorksClass.SolidWorksDrawingDocument.GetSheetNames
                For i = 0 To UBound(aSheetName)
                    _blnRet = oIflBaseSolidWorksClass.SolidWorksDrawingDocument.ActivateSheet(aSheetName(i))
                    '_blnRet = oIflBaseSolidWorksClass.SolidWorksModel.SaveAs4(_strdestinationPath + "\DRAWINGS\" + ofileData.Name + aSheetName(i) & ".dxf", oSwSaveAsCurrentVersion, oSwSaveAsOptions_Silent, _lngErrors, _lngWarnings)
                    _blnRet = oIflBaseSolidWorksClass.SolidWorksModel.SaveAs4(_strdestinationPath + "\DRAWINGS\" + ofileData.Name + aSheetName(i) & ".dxf", oSwSaveAsCurrentVersion, oSwSaveAsOptions_Silent, 0, 0) 'vamsi 15-11-13
                Next i
                _blnRet = oIflBaseSolidWorksClass.SolidWorksDrawingDocument.ActivateSheet(aSheetName(0))
                oIflBaseSolidWorksClass.SolidWorksApplicationObject.SetUserPreferenceToggle(_SwDXFDontShowMap, _blnShowMap)
                oIflBaseSolidWorksClass.SaveDocument(_strDrawingFileName)
                oIflBaseSolidWorksClass.CloseAllDocuments()
            End If

        Catch oException As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Unable to convert drawing in to DXF FORMAT .System Generated Error: " + oException.Message)
            '_strErrorMessage = "UNABLE TO CONVERT THE DRAWING INTO DXF FORMAT !!" + vbNewLine
            '_strErrorMessage += "System generated error:-" + vbNewLine + oException.Message
            '_oErrorObject = oException
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
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Unable to delete attached dimension .System Generated Error: " + oException.Message)
            '_strErrorMessage = "Unable to delete unattached dimensions"
            '_strErrorMessage += "System generated Error" + oException.Message
            '_oErrorObject = oException
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
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Unable to DrawBox for the Model .System Generated Error: " + oException.Message)
            '_strErrorMessage = "Unable to DrawBox for the model" + vbNewLine
            '_strErrorMessage += "System generated Error" + oException.Message
            '_oErrorObject = oException
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
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Unable to get the mass properties of the model .System Generated Error: " + oException.Message)
            '_strErrorMessage = "Unable to get the mass properties of the model" + vbNewLine
            '_strErrorMessage += "System generated Error" + oException.Message
            '_oErrorObject = oException
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
                'oMatefeature = oIflBaseSolidWorksClass.SolidWorksAssembly.AddMate3(_strmate1, _intmate2, False, 0, 0, 0, 1, 1, 0, 0, 0, False, _iMateError)
                oMatefeature = oIflBaseSolidWorksClass.SolidWorksAssembly.AddMate3(_strmate1, _intmate2, False, 0, 0, 0, 1, 1, 0, 0, 0, False, 0)
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
                'SolidWorksApplicationObject.SetUserPreferenceToggle(swUserPreferenceToggle_e.swShowErrorsEveryRebuild, False) 'vamsi 15-11-2013
                oIflBaseSolidWorksClass.SolidWorksApplicationObject.SetUserPreferenceToggle(77, False)
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
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Unable to perform Replacment of the component .System Generated Error: " + oException.Message)
            '_strErrorMessage = "Unable to perform Replacment of the component" + vbNewLine
            '_strErrorMessage += "System generated error" + oException.Message
            '_oErrorObject = oException
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
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Unable to perform Reference-Cuts for the Component .System Generated Error: " + oException.Message)
            '_strErrorMessage = "Unable to perform Reference-Cuts for the Component" + vbNewLine
            '_strErrorMessage += "System generated error" + oException.Message
            '_oErrorObject = oException
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
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Unable to perform Enabling the configurations .System Generated Error: " + oException.Message)
            '_strErrorMessage = "Unable to perform Enabling the configurations" + vbNewLine
            '_strErrorMessage += "System generated error:" + oException.Message
            '_oErrorObject = oException
        End Try
    End Sub
    ''' <summary>
    ''' Deletes the Given configuration.
    ''' </summary>
    ''' <param name="_strConfigName"></param>
    ''' <remarks></remarks>
    Public Sub DeleteConfiguration(ByVal _strConfigName As String)
        Try
            ' Dim _blnRet As Boolean  'vamsi 23-05-14
            oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc
            '_blnRet = oIflBaseSolidWorksClass.SolidWorksModel.DeleteConfiguration2(_strConfigName)  'vamsi 23-05-14
            oIflBaseSolidWorksClass.SolidWorksModel.DeleteConfiguration(_strConfigName)  'vamsi 23-05-14
            oIflBaseSolidWorksClass.SolidWorksModel.EditRebuild3()
        Catch oException As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Unable to delete the configurations .System Generated Error: " + oException.Message)
            '_strErrorMessage = "Unable to Delete the configurations" + vbNewLine
            '_strErrorMessage += "System generated error:" + oException.Message
            '_oErrorObject = oException
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
                'Dim arDuplicateList As New ArrayList    '06_06_2012  RAGAVA
                'Dim blnTubeWeldment As Boolean = False  '06_06_2012  RAGAVA
                'ReDim Preserve _strCompName(UBound(_strCompName) - 1)       '02_09_2009  ragava
                oIflBaseSolidWorksClass.SolidWorksModel.ClearSelection2(True)
                oIflBaseSolidWorksClass.SolidWorksAssembly = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc
                '06_06_2012   RAGAVA
                oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc
                'If oIflBaseSolidWorksClass.SolidWorksModel.GetPathName.ToString.IndexOf("TUBE_WELDMENT") <> -1 Then
                '    arDuplicateList = _strCompName
                '    blnTubeWeldment = True
                'End If

                For i = 0 To _strCompName.Count - 1 '02_09_2009  ragava  For i = 0 To UBound(_strCompName)
                    oSwComp = oIflBaseSolidWorksClass.SolidWorksAssembly.FeatureByName(_strCompName(i))
                    If Not _strCompName Is Nothing Then
                        If Not oSwComp Is Nothing Then
                            '06_06_2012  RAGAVA
                            'If blnTubeWeldment Then
                            '    arDuplicateList.Remove(oSwComp.Name)
                            '    If arDuplicateList.Contains(oSwComp.Name) Then
                            '        _bRet = oSwComp.Select2(True, 0)
                            '        _bRet = oIflBaseSolidWorksClass.SolidWorksModel.DeleteSelection(False)
                            '    End If
                            'Else
                            _bRet = oSwComp.Select2(True, 0)
                            _bRet = oIflBaseSolidWorksClass.SolidWorksModel.DeleteSelection(False)
                            'End If
                            'Till  Here
                        End If
                    End If
                Next i
            End If
        Catch oException As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Unable to perform suppression parts deletion .System Generated Error: " + oException.Message)
            '_strErrorMessage = "Unable to perform Suppression parts deletions" + vbNewLine
            '_strErrorMessage += "System generated error:" + oException.Message
            '_oErrorObject = oException
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
            Dim _strCompName1 As New ArrayList     '20_06_2012   RAGAVA
            Dim _strCompName2 As New ArrayList     '20_06_2012   RAGAVA
            Dim oSwConf As SldWorks.Configuration
            Dim oSwRootComp As SldWorks.Component2
            oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc

            '20_06_2012   RAGAVA
            If oIflBaseSolidWorksClass.SolidWorksModel.GetPathName.ToString.IndexOf("TUBE_WELDMENT") <> -1 Then
                Dim oConf As String() = oIflBaseSolidWorksClass.SolidWorksModel.GetConfigurationNames
                oSwConf = oIflBaseSolidWorksClass.SolidWorksModel.GetConfigurationByName(oConf(0))
                oSwRootComp = oSwConf.GetRootComponent
                _strCompName1 = TraverseComponentForInstance(oSwRootComp, 1)
                oSwConf = oIflBaseSolidWorksClass.SolidWorksModel.GetConfigurationByName(oConf(1))
                oSwRootComp = oSwConf.GetRootComponent
                _strCompName2 = TraverseComponentForInstance(oSwRootComp, 1)
                If _strCompName1.Count >= _strCompName2.Count Then
                    For i As Integer = 0 To _strCompName1.Count - 1
                        If _strCompName2.Contains(_strCompName1.Item(i)) Then
                            _strCompName.Add(_strCompName1.Item(i))
                        End If
                    Next
                Else
                    For i As Integer = 0 To _strCompName2.Count - 1
                        If _strCompName1.Contains(_strCompName2.Item(i)) Then
                            _strCompName.Add(_strCompName2.Item(i))
                        End If
                    Next
                End If
            Else
                oSwConf = oIflBaseSolidWorksClass.SolidWorksModel.GetActiveConfiguration
                oSwRootComp = oSwConf.GetRootComponent
                _strCompName = TraverseComponentForInstance(oSwRootComp, 1)
            End If

            'Try
            '    If Not ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingYes.rdbUseSelectedSingleLugNo.Checked = True Then
            '        DeleteConfiguration("Default")
            '    End If
            'Catch ex As Exception

            'End Try
            'vamsi 23-05-14 start 
            'Try
            '    If Not ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingYes.chkDoubleLugFabricationRequired.Checked = True OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingYes.chkBHFabricationRequired.Checked = True OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingYes.chkCrossTubeFabricationRequired.Checked = True OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingYes.chkSingleLugFabricationRequired.Checked = True Then
            '        DeleteConfiguration("Default1")
            '    End If
            'Catch ex As Exception

            'End Try
            'End

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
        'SolidWorksApplicationObject.SetUserPreferenceToggle(swUserPreferenceToggle_e.swShowErrorsEveryRebuild, False) 'vamsi 15-11-2013
        oIflBaseSolidWorksClass.SolidWorksApplicationObject.SetUserPreferenceToggle(77, False)
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
            '_strErrorMessage = "Unable to perform Auto ballooning" + vbNewLine
            '_strErrorMessage += "System generated error:" + oException.Message
            '_oErrorObject = oException
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Unable to perform Auto Ballooing .System Generated Error: " + oException.Message)
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
            '_strErrorMessage = "Unable to perform Auto ballooning" + vbNewLine
            '_strErrorMessage += "System generated error:" + oException.Message
            '_oErrorObject = oException
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Unable to perform Auto Ballooing .System Generated Error: " + oException.Message)
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
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Unable to get the instance number of the component .System Generated Error: " + oException.Message)
            '_strErrorMessage = "Unable to get the instance number of the component" + vbNewLine
            '_strErrorMessage += "System generated Error" + oException.Message
            '_oErrorObject = oException
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
        'SolidWorksApplicationObject.SetUserPreferenceToggle(swUserPreferenceToggle_e.swShowErrorsEveryRebuild, False) 'vamsi 15-11-2013
        oIflBaseSolidWorksClass.SolidWorksApplicationObject.SetUserPreferenceToggle(77, False)
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
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Unable to delete the design table .System Generated Error: " + oException.Message)
            '_strErrorMessage = "UNABLE TO DELETE THE DESIGN TABLE !!" + vbCrLf
            '_strErrorMessage += "System generated error:-" + vbCrLf + oException.Message
            '_oErrorObject = oException
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
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Unable to convert the drawing in to dxf format .System Generated Error: " + oException.Message)
            '_strErrorMessage = "UNABLE TO CONVERT THE DRAWING INTO DXF FORMAT !!" + vbCrLf
            '_strErrorMessage += "System generated error:-" + vbCrLf + oException.Message
            '_oErrorObject = oException
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
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Unable to convert the drawing in to dxf format .System Generated Error: " + oException.Message)
            '_strErrorMessage = "UNABLE TO CONVERT THE DRAWING INTO DXF FORMAT !!" + vbCrLf
            '_strErrorMessage += "System generated error:-" + vbCrLf + oException.Message
            '_oErrorObject = oException
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
            '_strErrorMessage = "Unable to perform Envelop for the model document" + vbNewLine
            '_strErrorMessage += "System generated error:" + oException.Message
            '_oErrorObject = oException
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Unable to Perform Envelop for the model document .System Generated Error: " + oException.Message)
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
            '_strErrorMessage = "Unable to get the Configuration name" + vbNewLine
            '_strErrorMessage += "System generated error:" + oException.Message
            '_oErrorObject = oException
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Unable to get the configuration name .System Generated Error: " + oException.Message)
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
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("System Generated Error: " + oException.Message)
            '_strErrorMessage = "System generated error:" + oException.Message
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
            '_strErrorMessage = "System generated error:" + oException.Message
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("System Generated Error: " + oException.Message)
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
            '_strErrorMessage = "UNABLE TO Delete the feature" + vbNewLine
            '_strErrorMessage += "System generated error:-" + vbNewLine + oException.Message
            '_oErrorObject = oException
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Unable to delete the feature .System Generated Error: " + oException.Message)
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


    '02_08_2012   RAGAVA
    Public Function DeleteDanglingDimensions(ByVal strDrawingFile As String) As Boolean
        Try
            Dim SwAnn As SldWorks.Annotation
            Dim boolstatus As Boolean = False
            Dim strFileName As String = strDrawingFile.Substring((strDrawingFile.LastIndexOf("\")) + 1, strDrawingFile.Length - strDrawingFile.LastIndexOf("\") - 1)
            Dim bret As Boolean = openDocument(strDrawingFile)
            'SolidWorksApplicationObject.SetUserPreferenceToggle(swUserPreferenceToggle_e.swShowErrorsEveryRebuild, False) 'vamsi 15-11-2013
            oIflBaseSolidWorksClass.SolidWorksApplicationObject.SetUserPreferenceToggle(77, False)
            SolidWorksModel = SolidWorksApplicationObject.ActivateDoc(strFileName)
            oSolidWorksDrawingDocument = SolidWorksModel
            Dim swView As SldWorks.View = oSolidWorksDrawingDocument.GetFirstView
            Dim AL_Annotations As New ArrayList
            While Not swView Is Nothing
                boolstatus = SolidWorksDrawingDocument.ActivateView(swView.Name)
                SwAnn = swView.GetFirstAnnotation()
                If Not SwAnn Is Nothing Then
                    Dim SwAnn_Type As String = SwAnn.GetType
                    While Not SwAnn Is Nothing
                        If SwAnn.IsDangling Then
                            SwAnn.Select(True)
                        End If
                        SwAnn = SwAnn.GetNext3
                    End While
                    SolidWorksModel.EditDelete()
                    'If SwAnn_Type = "" Then
                    '    SwAnn_Type = "DIMENSION"
                    'End If
                    'For Each Ann As Object In AL_Annotations
                    '    boolstatus = SolidWorksModel.Extension.SelectByID2(Ann, SwAnn_Type, 0, 0, 0, False, 0, Nothing, 0)
                    '    SolidWorksModel.EditDelete()
                    'Next
                End If
                swView = swView.GetNextView
            End While
        Catch ex As Exception
        End Try

        'Try
        '    Dim oSolidWorksDispDim As SldWorks.DisplayDimension
        '    Dim oSolidWorksDim As SldWorks.Dimension
        '    Dim oSolidWorksAnn As SldWorks.Annotation
        '    Dim s1 As String = ""
        '    Dim sViewName As String = ""
        '    Dim attachedEntitiesArray As ArrayList
        '    Dim attachedEntityTypes As ArrayList
        '    Dim dwgNote As SldWorks.Note
        '    oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc
        '    'oIflBaseSolidWorksClass.SolidWorksDrawingDocument = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc
        '    oIflBaseSolidWorksClass.SolidWorksDrawingDocument = oIflBaseSolidWorksClass.SolidWorksModel
        '    oIflBaseSolidWorksClass.SolidWorksView = oIflBaseSolidWorksClass.SolidWorksDrawingDocument.GetFirstView

        '    Do While Not oIflBaseSolidWorksClass.SolidWorksView Is Nothing
        '        'Travserse Through the Dimensions
        '        oIflBaseSolidWorksClass.SolidWorksView = oIflBaseSolidWorksClass.SolidWorksView.GetNextView
        '        If Not oIflBaseSolidWorksClass.SolidWorksView Is Nothing Then
        '            sViewName = oIflBaseSolidWorksClass.SolidWorksView.Name
        '            'Travserse through all of the dimensions in this view
        '            oSolidWorksDispDim = oIflBaseSolidWorksClass.SolidWorksView.GetFirstDisplayDimension3
        '            Do While Not oSolidWorksDispDim Is Nothing
        '                oSolidWorksDim = oSolidWorksDispDim.GetDimension

        '                If oSolidWorksDim.Value = 0 Then
        '                    If oSolidWorksDim.FullName.IndexOf("Annotations") <> -1 Then
        '                        s1 = oSolidWorksDim.Name & "@" & sViewName
        '                    End If
        '                    oSolidWorksDispDim = oSolidWorksDispDim.GetNext3
        '                    oIflBaseSolidWorksClass.SolidWorksModel.Extension.SelectByID2(s1, "DIMENSION", 0, 0, 0, False, 0, Nothing, 0)
        '                    oIflBaseSolidWorksClass.SolidWorksModel.DeleteSelection(True)
        '                End If
        '            Loop
        '            'Travserse through all of the reference dimensions in this view
        '            oSolidWorksDispDim = oIflBaseSolidWorksClass.SolidWorksView.GetFirstDisplayDimension3
        '            Do While Not oSolidWorksDispDim Is Nothing
        '                oSolidWorksAnn = oSolidWorksDispDim.GetAnnotation
        '                'Only allow this to act on Reference Dimensions
        '                If oSolidWorksAnn.GetName.IndexOf("RD*") <> -1 Then
        '                    attachedEntitiesArray = oSolidWorksAnn.GetAttachedEntities
        '                    attachedEntityTypes = oSolidWorksAnn.GetAttachedEntityTypes
        '                    If attachedEntitiesArray.Count > 0 Then
        '                        'Delete the Ref Dim -  next one must be selected before this on can be removed
        '                        s1 = oSolidWorksAnn.GetName & "@" & oIflBaseSolidWorksClass.SolidWorksView.Name
        '                    ElseIf attachedEntityTypes(0) Is Nothing Or attachedEntitiesArray(0) Is Nothing Then        'Dangling
        '                        s1 = oSolidWorksAnn.GetName & "@" & oIflBaseSolidWorksClass.SolidWorksView.Name
        '                    ElseIf (attachedEntitiesArray.Count + 1) >= 2 Then
        '                        If attachedEntityTypes(1) Is Nothing Or attachedEntitiesArray(1) Is Nothing Then        'Dangling
        '                            'Delete the Ref Dim -  next one must be selected before this on can be removed
        '                            s1 = oSolidWorksAnn.GetName & "@" & oIflBaseSolidWorksClass.SolidWorksView.Name
        '                        End If
        '                    Else
        '                        'Attached
        '                    End If
        '                End If
        '                oSolidWorksDispDim = oSolidWorksDispDim.GetNext3
        '                oIflBaseSolidWorksClass.SolidWorksModel.Extension.SelectByID2(s1, "DIMENSION", 0, 0, 0, False, 0, Nothing, 0)
        '                oIflBaseSolidWorksClass.SolidWorksModel.DeleteSelection(True)
        '            Loop
        '            'Traverse through all of the notes in this drawing view
        '            dwgNote = oIflBaseSolidWorksClass.SolidWorksView.GetFirstNote
        '            Do While Not dwgNote Is Nothing
        '                Dim bRemoveLastFlag As Boolean = False
        '                oSolidWorksAnn = dwgNote.GetAnnotation
        '                attachedEntitiesArray = oSolidWorksAnn.GetAttachedEntities
        '                attachedEntityTypes = oSolidWorksAnn.GetAttachedEntityTypes
        '                If attachedEntitiesArray.Count > 0 Then
        '                    'Not Attached (And Never Was)
        '                ElseIf attachedEntityTypes(0) Is Nothing Or attachedEntitiesArray(0) Is Nothing Then        'Dangling
        '                    'Delete the Note
        '                    'The next note must be selected before this on can be removed
        '                    bRemoveLastFlag = True
        '                    s1 = dwgNote.GetName & "@" & sViewName  'oIflBaseSolidWorksClass.SolidWorksView.Name
        '                Else
        '                    'Attached
        '                End If
        '                dwgNote = dwgNote.GetNext
        '                If bRemoveLastFlag = True Then
        '                    oIflBaseSolidWorksClass.SolidWorksModel.Extension.SelectByID2(s1, "NOTE", 0, 0, 0, False, 0, Nothing, 0)
        '                    oIflBaseSolidWorksClass.SolidWorksModel.DeleteSelection(True)
        '                    bRemoveLastFlag = False
        '                End If
        '            Loop
        '            'Traverse through all of the welds in this drawing view
        '            Dim dwgWeld As SldWorks.WeldSymbol = oIflBaseSolidWorksClass.SolidWorksView.GetFirstWeldSymbol
        '            Do While Not dwgWeld Is Nothing
        '                oSolidWorksAnn = dwgWeld.GetAnnotation
        '                Dim bRemoveLastFlag As Boolean = False
        '                attachedEntitiesArray = oSolidWorksAnn.GetAttachedEntities
        '                attachedEntityTypes = oSolidWorksAnn.GetAttachedEntityTypes
        '                If attachedEntitiesArray.Count > 0 Then
        '                    'Not Attached (And Never Was)
        '                ElseIf attachedEntityTypes(0) Is Nothing Or attachedEntitiesArray(0) Is Nothing Then        'Dangling
        '                    'Delete the Note
        '                    'The next note must be selected before this one can be removed
        '                    bRemoveLastFlag = True
        '                    s1 = oSolidWorksAnn.GetName & "@" & sViewName
        '                Else
        '                    'Attached
        '                End If
        '                dwgWeld = dwgWeld.GetNext
        '                If bRemoveLastFlag = True Then
        '                    oIflBaseSolidWorksClass.SolidWorksModel.Extension.SelectByID2(s1, "WELD", 0, 0, 0, False, 0, Nothing, 0)
        '                    oIflBaseSolidWorksClass.SolidWorksModel.DeleteSelection(True)
        '                    bRemoveLastFlag = False
        '                End If
        '            Loop
        '        End If
        '    Loop

        'Catch ex As Exception

        'End Try
    End Function


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
        'Dim oSolidWorksDispDim As SldWorks.DisplayDimension
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
        'MyBase.New(True) vamsi changed to false 14-11-2013
        MyBase.New(False)

    End Sub

    '16_08_2010   RAGAVA
    Private Sub ImportPartReplacements(ByVal strAssyPath As String)
        Try
            '    Dim strDummyComponentName As String = "TUBE_WELDMENT-1@WELD_CYLINDER_ASSEMBLY/Import_Plate_Clevis-2@TUBE_WELDMENT"
            '    Dim strParentAssembly As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\WELD_CYLINDER_ASSEMBLY\WELD_CYLINDER_ASSEMBLY.SLDASM"
            '    IFLSolidWorksBaseClassObject.ReplaceComponentWithInstance(strParentAssembly, strDummyComponentName, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.clevisplatePartFilePath, "@WELD_CYLINDER_ASSEMBLY")
            If strAssyPath.IndexOf("TUBE_WELDMENT") <> -1 Then
                If Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.clevisplatePartFilePath) <> "" Then
                    ReplaceComponentWithInstance("TUBE_WELDMENT.SLDASM", "Import_Plate_Clevis-2@TUBE_WELDMENT", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.clevisplatePartFilePath, "@TUBE_WELDMENT")
                End If
                If Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ImportBaseEndPartPath) <> "" Then
                    ReplaceComponentWithInstance("TUBE_WELDMENT.SLDASM", "Import_Base_End-2@TUBE_WELDMENT", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ImportBaseEndPartPath, "@TUBE_WELDMENT")
                End If
                If Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ImportBaseEndPortPartPath) <> "" Then
                    ReplaceComponentWithInstance("TUBE_WELDMENT.SLDASM", "dummy_port-2@TUBE_WELDMENT", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ImportBaseEndPortPartPath, "@TUBE_WELDMENT")
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd > 1 Then
                        ReplaceComponentWithInstance("TUBE_WELDMENT.SLDASM", "dummy_port-3@TUBE_WELDMENT", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ImportBaseEndPortPartPath, "@TUBE_WELDMENT")
                    End If
                End If
                If Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ImportRodEndPortPartPath) <> "" Then
                    ReplaceComponentWithInstance("TUBE_WELDMENT.SLDASM", "dummy_port-1@TUBE_WELDMENT", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ImportRodEndPortPartPath, "@TUBE_WELDMENT")
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_RodEnd > 1 Then
                        ReplaceComponentWithInstance("TUBE_WELDMENT.SLDASM", "dummy_port-4@TUBE_WELDMENT", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ImportRodEndPortPartPath, "@TUBE_WELDMENT")
                    End If
                End If
            End If
            If strAssyPath.IndexOf("ROD_WELDMENT") <> -1 Then
                If Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ImportRodEndPartPath) <> "" Then
                    ReplaceComponentWithInstance("ROD_WELDMENT.SLDASM", "Import_Rod_End-1@ROD_WELDMENT", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ImportRodEndPartPath, "@ROD_WELDMENT")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub ProcessDirectory(ByVal targetDirectory As String, Optional ByVal blnSearchSubDir As Boolean = False)
        Try
            Dim strDrawingdoc As String = String.Empty
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
            'oIflBaseSolidWorksClass.SolidWorksApplicationObject.CommandInProgress = True
            Dim blnRet As Boolean = oIflBaseSolidWorksClass.SolidWorksApplicationObject.SetCurrentWorkingDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath)
            'oIflBaseSolidWorksClass.SolidWorksApplicationObject.CommandInProgress = False
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
                        'SolidWorksApplicationObject.SetUserPreferenceToggle(swUserPreferenceToggle_e.swShowErrorsEveryRebuild, False) 'vamsi 15-11-2013
                        oIflBaseSolidWorksClass.SolidWorksApplicationObject.SetUserPreferenceToggle(77, False)
                        'SolidWorksModel = SolidWorksApplicationObject.ActiveDoc
                        Try
                            oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc           '06_04_2010   RAGAVA
                            oIflBaseSolidWorksClass.SolidWorksModel.ViewZoomtofit2()            '02_09_2009   ragava
                        Catch ex As Exception

                        End Try

                        '16_08_2010   RAGAVA
                        Try
                            If arrAsmFileEntries(intCount).IndexOf("TUBE_WELDMENT") <> -1 Or arrAsmFileEntries(intCount).IndexOf("ROD_WELDMENT") <> -1 Then
                                ImportPartReplacements(arrAsmFileEntries(intCount))
                            End If
                        Catch ex As Exception
                        End Try
                        'Till   Here
                        '09_12_2010   RAGAVA
                        Try
                            If arrAsmFileEntries(intCount).IndexOf("TUBE_WELDMENT") <> -1 Or arrAsmFileEntries(intCount).IndexOf("ROD_WELDMENT") <> -1 Then
                                Dim filename1 As String = arrAsmFileEntries(intCount)
                                Dim arrpart1 As String() = filename1.Split("\")
                                Dim strPart1 As String = arrpart1(UBound(arrpart1))
                                Dim strCodeNumber1 As String = String.Empty

                                '20_04_2011   RAGAVA
                                'strCodeNumber1 = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPurchaseAndManufactureCode(strPart1.Substring(0, strPart1.IndexOf(".")))
                                If arrAsmFileEntries(intCount).IndexOf("TUBE_WELDMENT") <> -1 Then
                                    strCodeNumber1 = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("BORE_IFL")
                                ElseIf arrAsmFileEntries(intCount).IndexOf("ROD_WELDMENT") <> -1 Then
                                    strCodeNumber1 = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("Rod_Welded")
                                End If
                                If strCodeNumber1 = "" Then
                                    strCodeNumber1 = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPurchaseAndManufactureCode(strPart1.Substring(0, strPart1.IndexOf(".")))
                                End If
                                'Till  Here

                                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.ContainsKey(filename1.Substring(filename1.LastIndexOf("\") + 1, filename1.IndexOf(".") - filename1.LastIndexOf("\") - 1)) = False Then
                                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.Add(filename1.Substring(filename1.LastIndexOf("\") + 1, filename1.IndexOf(".") - filename1.LastIndexOf("\") - 1), strCodeNumber1)
                                Else
                                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(filename1.Substring(filename1.LastIndexOf("\") + 1, filename1.IndexOf(".") - filename1.LastIndexOf("\") - 1)) = strCodeNumber1
                                End If
                            End If
                        Catch ex As Exception
                        End Try
                        'Till   Here

                        Try
                            updateCustomProperties(arrAsmFileEntries(intCount))         '08_09_2009  ragava
                        Catch ex As Exception
                            'MsgBox("Error in Updating Custom Properties")
                            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error in Updating customer Properties ")
                        End Try
                        oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActivateDoc(arrAsmFileEntries(intCount))
                        oIflBaseSolidWorksClass.SolidWorksModel.EditRebuild3()             '02_09_2009   ragava

                        '24_08_2010    RAGAVA
                        Try
                            If arrAsmFileEntries(intCount).IndexOf("TUBE_WELDMENT") <> -1 Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strTubeWeldmentVolume = ObjClsWeldedCylinderFunctionalClass.GetCustomPropertyValue("Volume")
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strTubeWeldmentWeight = Math.Round(Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strTubeWeldmentVolume) * 0.281793, 2)        '01_10_2010   RAGAVA
                            ElseIf arrAsmFileEntries(intCount).IndexOf("ROD_WELDMENT") <> -1 Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRodWeldmentVolume = ObjClsWeldedCylinderFunctionalClass.GetCustomPropertyValue("Volume")
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRodWeldmentWeight = Math.Round(Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRodWeldmentVolume) * 0.281793, 2)        '01_10_2010   RAGAVA
                            ElseIf arrAsmFileEntries(intCount).IndexOf("WELD_CYLINDER_ASSEMBLY") <> -1 Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strWeldCylinderVolume = ObjClsWeldedCylinderFunctionalClass.GetCustomPropertyValue("Volume")
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strWeldCylinderWeight = Math.Round(Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strWeldCylinderVolume) * 0.281793, 2)        '01_10_2010   RAGAVA
                            End If
                        Catch ex As Exception
                        End Try
                        'Till    Here


                        '19_07_2012    RAGAVA
                        Try
                            If Not (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FirstPortOrientation_BaseEnd = 0 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Cross Tube") Then
                                DeleteSketch("CT_OD")
                                DeleteSketch("CT_WIDTH")
                            End If
                            If Not (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FirstPortOrientation_BaseEnd = 0 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug") Then
                                DeleteSketch("DL_THICKNESS_GAP")
                                DeleteSketch("DL_SWING_CLEARANCE")
                            End If
                            If Not (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FirstPortOrientation_BaseEnd = 0 AndAlso (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Single Lug" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "BH")) Then
                                DeleteSketch("SL_THICKNESS")
                                DeleteSketch("SL_SWING_CLEARANCE")
                            End If

                            If Not (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FirstPortOrientation_BaseEnd > 0 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Cross Tube") Then
                                DeleteSketch("CT_OD_90")
                                DeleteSketch("CT_WIDTH_90")
                            End If
                            If Not (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FirstPortOrientation_BaseEnd > 0 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug") Then
                                DeleteSketch("DL_THICKNESS_GAP_90")
                                DeleteSketch("DL_SWING_CLEARANCE_90")
                            End If
                            If Not (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FirstPortOrientation_BaseEnd > 0 AndAlso (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Single Lug" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "BH")) Then
                                DeleteSketch("SL_THICKNESS_90")
                                DeleteSketch("SL_SWING_CLEARANCE_90")
                            End If

                        Catch ex As Exception

                        End Try


                        Try
                            DeleteDesignTable(arrAsmFileEntries(intCount))        '02_09_2009   ragava
                            'strDrawingdoc = arrAsmFileEntries(intCount)
                            'strDrawingdoc = strDrawingdoc.Replace("SLDASM", "SLDDRW")
                            'DeleteDanglingDimensions(strDrawingdoc)
                        Catch ex As Exception

                        End Try
                        Common_TraversAndDeletions_And_SuppressionParts()
                        Try
                            oIflBaseSolidWorksClass.SaveAndCloseAllDocuments()       '02_09_2009   ragava
                            '07_06_2011   ragava
                            If arrAsmFileEntries(intCount).IndexOf("TUBE_WELDMENT") <> -1 OrElse arrAsmFileEntries(intCount).IndexOf("ROD_WELDMENT") <> -1 Then
                                oIflBaseSolidWorksClass.SaveAndCloseAllDocuments()
                            End If
                            'TILL   HERE
                        Catch ex As Exception
                        End Try



                        '14_07_2010   RAGAVA
                        'Renaming can start here
                        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable
                        Dim filename As String = arrAsmFileEntries(intCount)
                        Dim arrpart As String() = filename.Split("\")
                        Dim strPart As String = arrpart(UBound(arrpart))
                        If Not (strPart.IndexOf("PISTON") <> -1 OrElse strPart.IndexOf("CYL HEAD WIRE RING") <> -1 OrElse strPart.IndexOf("7") <> -1 OrElse strPart.IndexOf("6") <> -1 OrElse strPart.IndexOf("5") <> -1) Then
                            Dim strCodeNumber As String
                            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.ContainsKey(strPart.Substring(0, strPart.IndexOf("."))) OrElse (Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign.txtCylinderHeadCode.Text) <> "New Design" AndAlso Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign.txtCylinderHeadCode.Text) <> "" AndAlso strPart.IndexOf("CYL HEAD") <> -1) Then
                                If strPart.IndexOf("CYL HEAD") <> -1 Then
                                    If Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign.txtCylinderHeadCode.Text) <> "New Design" AndAlso Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign.txtCylinderHeadCode.Text) <> "" Then
                                        strCodeNumber = Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign.txtCylinderHeadCode.Text)
                                    Else
                                        strCodeNumber = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("CYL HEAD")
                                    End If
                                    'strCodeNumber = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("CYL HEAD")
                                Else
                                    strCodeNumber = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(strPart.Substring(0, strPart.IndexOf(".")))
                                End If
                            Else

                                If filename.IndexOf("WELD_CYLINDER_ASSEMBLY.SLDASM") <> -1 Then            '10_08_2010 RAGAVA
                                    strCodeNumber = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber      '10_08_2010 RAGAVA
                                Else
                                    If strPart.IndexOf("COLLAR") <> -1 Then          '21_12_2010  RAGAVA
                                        strCodeNumber = GetCollarCode()              '21_12_2010  RAGAVA
                                    Else
                                        strCodeNumber = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPurchaseAndManufactureCode(strPart.Substring(0, strPart.IndexOf(".")))
                                    End If
                                End If
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


                                '12_08_2010   RAGAVA
                                Try
                                    InsertTextBox()
                                Catch ex As Exception
                                End Try
                                'Till  Here


                                Dim bret As Boolean = False
                                Dim oDrawingPath As String = filename.Substring(0, filename.LastIndexOf("\")) & "\WELD_CYLINDER_ASSEMBLY.SLDDRW"
                                Rename(filename, strNewPartPath)
                                bret = SolidWorksApplicationObject.ReplaceReferencedDocument(oDrawingPath, filename, strNewPartPath)
                                Dim strAssy As String() = strNewPartPath.Split("\")
                                Dim strPartName As String = "\" & strAssy(UBound(strAssy))


                                '10_08_2010    RAGAVA
                                Try
                                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.ContainsKey(filename.Substring(filename.LastIndexOf("\") + 1, filename.IndexOf(".") - filename.LastIndexOf("\") - 1)) = False Then
                                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.Add(filename.Substring(filename.LastIndexOf("\") + 1, filename.IndexOf(".") - filename.LastIndexOf("\") - 1), strCodeNumber)
                                    Else
                                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(filename.Substring(filename.LastIndexOf("\") + 1, filename.IndexOf(".") - filename.LastIndexOf("\") - 1)) = strCodeNumber
                                    End If
                                Catch ex As Exception
                                End Try
                                'Till  Here
                                Try
                                    'FileCopy(strNewPartPath, strModelNetworkPath & strPartName)
                                    Dim nDrawingPath As String = filename.Substring(0, filename.LastIndexOf("\")) & strNewPartPath.Substring(strNewPartPath.LastIndexOf("\"), strNewPartPath.IndexOf(".") - strNewPartPath.LastIndexOf("\")) & ".SLDDRW"
                                    Rename(oDrawingPath, nDrawingPath)
                                    bret = SolidWorksApplicationObject.ReplaceReferencedDocument(strNewPartPath, oDrawingPath, nDrawingPath)
                                    '18_08_2010   RAGAVA
                                    If File.Exists(strModelNetworkPath & "\" & strCodeNumber.ToString & ".SLDASM") Then
                                        File.Delete(strModelNetworkPath & "\" & strCodeNumber.ToString & ".SLDASM")
                                    End If
                                    File.Copy(strNewPartPath, strModelNetworkPath & "\" & strCodeNumber.ToString & ".SLDASM")
                                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AssyGeneratePath = strModelNetworkPath & "\" & strCodeNumber.ToString & ".SLDASM"      '13_08_2010   RAGAVA
                                    bret = SolidWorksApplicationObject.ReplaceReferencedDocument(nDrawingPath, strNewPartPath, strModelNetworkPath & "\" & strCodeNumber.ToString & ".SLDASM")
                                    If Directory.Exists("W:\WeldedDrawings") = False Then
                                        Directory.CreateDirectory("W:\WeldedDrawings")
                                    End If
                                    '18_08_2010   RAGAVA
                                    If File.Exists("W:\WeldedDrawings\" & strCodeNumber.ToString & ".SLDDRW") Then
                                        File.Delete("W:\WeldedDrawings\" & strCodeNumber.ToString & ".SLDDRW")
                                    End If
                                    File.Copy(nDrawingPath, "W:\WeldedDrawings\" & strCodeNumber.ToString & ".SLDDRW")
                                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AssyGeneratePath = "W:\WeldedDrawings\" & strCodeNumber.ToString & ".SLDDRW"      '13_08_2010   RAGAVA
                                    bret = SolidWorksApplicationObject.ReplaceReferencedDocument(strModelNetworkPath & "\" & strCodeNumber.ToString & ".SLDASM", nDrawingPath, "W:\WeldedDrawings\" & strCodeNumber.ToString & ".SLDDRW")
                                Catch ex As Exception
                                End Try
                                Try
                                    'If Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strNewPartCodeNumber_BeforeContractStart) <= Val(strCodeNumber) Then
                                    SolidWorksModel = SolidWorksApplicationObject.OpenDoc6("W:\WeldedDrawings\" & strCodeNumber.ToString & ".SLDDRW", 3, SwConst.swOpenDocOptions_e.swOpenDocOptions_Silent, "", 0, 0)
                                    SolidWorksApplicationObject.UserControl = False 'vamsi 14-11-2013
                                    Thread.Sleep(2000)  '07_03_2011   RAGAVA
                                    SolidWorksApplicationObject.IActiveDoc.SaveAs2("W:\WeldedDrawings\" & strCodeNumber.ToString & ".SLDDRW", 3, True, True)
                                    'SolidWorksApplicationObject.CloseDoc(strCodeNumber.ToString & ".SLDDRW")
                                    SolidWorksApplicationObject.CloseAllDocuments(True)
                                    'End If
                                Catch ex As Exception
                                End Try
                            Else
                                '10_08_2010    RAGAVA
                                Try
                                    Dim strarr() As String = strNewPartPath.Split("\")
                                    Dim strNewPartName As String = strarr(UBound(strarr))
                                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.ContainsKey(filename.Substring(filename.LastIndexOf("\") + 1, filename.IndexOf(".") - filename.LastIndexOf("\") - 1)) = False Then
                                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.Add(filename.Substring(filename.LastIndexOf("\") + 1, filename.IndexOf(".") - filename.LastIndexOf("\") - 1), strNewPartName.Substring(0, strNewPartName.IndexOf("."))) ' strNewPartPath.Substring(strNewPartPath.LastIndexOf("\"), Len(strNewPartPath.Substring(0, strNewPartPath.LastIndexOf("."))) - strNewPartPath.LastIndexOf(".")))
                                    Else
                                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(filename.Substring(filename.LastIndexOf("\") + 1, filename.IndexOf(".") - filename.LastIndexOf("\") - 1)) = strNewPartName.Substring(0, strNewPartName.IndexOf("."))
                                    End If
                                Catch ex As Exception
                                End Try
                                'Till  Here
                                RenamePartFile(filename, strNewPartPath, strReferenceAssm)
                                FolderStructure(strReferenceAssm, strNewPartPath, strModelNetworkPath)
                                RenameDrawing(filename, strNewPartPath.Replace(".SLDASM", ".SLDDRW"), strNewPartPath, strModelNetworkPath & "\" & strCodeNumber.ToString & ".SLDASM")
                            End If
                        End If
                        'Till   Here
                    End If
                Next
            End If

            If blnSearchSubDir = True Then
                Dim subdirectoryEntries As String() = Directory.GetDirectories(targetDirectory)
                Dim subdirectory As String
                For Each subdirectory In subdirectoryEntries
                    ProcessDirectory(subdirectory)
                Next subdirectory
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub updatePartModels(ByVal fileName As String)
        Dim strpath As String = fileName.Replace("~$", "")
        If Not String.Compare(fileName, strpath) = 0 Then
            Exit Sub
        End If
        Dim blnRet As Boolean = oIflBaseSolidWorksClass.SolidWorksApplicationObject.SetCurrentWorkingDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath)
        'oIflBaseSolidWorksClass.SolidWorksApplicationObject.CommandInProgress = True
        Try
            'oIflBaseSolidWorksClass.SolidWorksApplicationObject.CommandInProgress = True
            'oIflBaseSolidWorksClass.SolidWorksApplicationObject.CommandInProgress = False
            oIflBaseSolidWorksClass.openDocument(fileName)
            'SolidWorksApplicationObject.SetUserPreferenceToggle(swUserPreferenceToggle_e.swShowErrorsEveryRebuild, False) 'vamsi 15-11-2013
            oIflBaseSolidWorksClass.SolidWorksApplicationObject.SetUserPreferenceToggle(77, False)
            'oIflBaseSolidWorksClass.SolidWorksApplicationObject.CommandInProgress = False
            '01_11_2010   RAGAVA
            'SolidWorksModel = SolidWorksApplicationObject.ActivateDoc(docName)
            'Dim boolstatus As Boolean = False
            Try
                'oIflBaseSolidWorksClass.SolidWorksModel = SolidWorksApplicationObject.ActiveDoc
                oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActivateDoc(fileName.Substring(fileName.LastIndexOf("\") + 1, (fileName.Length - fileName.LastIndexOf("\") - 1)))
                oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc
            Catch ex As Exception
            End Try
            'Till   Here

            'anup 14-03-2011 start
            Dim oDesignTable As SldWorks.DesignTable
            If IsCurrentSolidWorks Is Nothing Then
                oIflBaseSolidWorksClass = New IFLSolidWorksBaseClass(True)

            End If
            oIflBaseSolidWorksClass.SolidWorksModel = oIflBaseSolidWorksClass.SolidWorksApplicationObject.ActiveDoc
            oDesignTable = oIflBaseSolidWorksClass.SolidWorksModel.GetDesignTable

            'anup 14-03-2011 till here

            If Not oIflBaseSolidWorksClass.SolidWorksModel Is Nothing Then
                oIflBaseSolidWorksClass.SolidWorksModel.ViewZoomtofit2()
                Try
                    updateCustomProperties(fileName)         '08_09_2009  ragava
                Catch ex As Exception
                    'MsgBox("Error in Updating Custom Properties")
                    ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error in Updating customer Properties ")
                End Try
                oIflBaseSolidWorksClass.SolidWorksModel.EditRebuild3()
                oDesignTable = Nothing 'anup 14-03-2011
                Try
                    DeleteDesignTable(fileName)
                Catch EX As Exception
                End Try

                '02_11_2010   RAGAVA
                Try
                    If fileName.IndexOf("BASEPLUG") <> -1 Then
                        Dim dblWeight As Double = ObjClsWeldedCylinderFunctionalClass.GetCustomPropertyValue("Weight")
                        ObjClsWeldedCylinderFunctionalClass.BaseEndWeight = dblWeight
                    End If
                Catch ex As Exception
                End Try
                'Till  Here

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
                    Dim strCodeNumber As String = String.Empty
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.ContainsKey(strPart.Substring(0, strPart.IndexOf("."))) OrElse (Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign.txtCylinderHeadCode.Text) <> "New Design" AndAlso Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign.txtCylinderHeadCode.Text) <> "" AndAlso strPart.IndexOf("CYL HEAD") <> -1) Then
                        If strPart.IndexOf("CYL HEAD") <> -1 Then
                            If Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign.txtCylinderHeadCode.Text) <> "New Design" AndAlso Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign.txtCylinderHeadCode.Text) <> "" Then
                                strCodeNumber = Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign.txtCylinderHeadCode.Text)
                            Else
                                strCodeNumber = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("CYL HEAD")
                            End If
                        Else
                            strCodeNumber = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(strPart.Substring(0, strPart.IndexOf(".")))
                        End If
                    Else



                        '11_10_2010   RAGAVA
                        If strPart.IndexOf("COLLAR") <> -1 Then
                            strCodeNumber = GetCollarCode()
                        ElseIf strPart.IndexOf("BASE_CROSSTUBE", StringComparison.CurrentCultureIgnoreCase) <> -1 Then
                            strCodeNumber = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd
                        ElseIf strPart.IndexOf("ROD_CROSSTUBE", StringComparison.CurrentCultureIgnoreCase) <> -1 Then
                            strCodeNumber = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd

                        ElseIf strPart.IndexOf(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName) <> -1 AndAlso Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName) <> "" Then    '12_10_2010   RAGAVA 08-09-2014 vamsi index of second parameter '' StringComparison.CurrentCultureIgnoreCase''

                            If ObjClsWeldedCylinderFunctionalClass.strExistingBaseEndPartCode <> "" Then    '12_10_2010   RAGAVA
                                strCodeNumber = ObjClsWeldedCylinderFunctionalClass.strExistingBaseEndPartCode
                            End If

                        ElseIf strPart.IndexOf(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName) <> -1 AndAlso Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName) <> "" Then     '12_10_2010   RAGAVA
                            If ObjClsWeldedCylinderFunctionalClass.strExistingRodEndPartCode <> "" Then       '12_10_2010   RAGAVA
                                strCodeNumber = ObjClsWeldedCylinderFunctionalClass.strExistingRodEndPartCode
                            End If
                            'ElseIf strPart.IndexOf("Base_Crosstube") <> -1 Then

                            '    strCodeNumber = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.
                            Else

                                strCodeNumber = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPurchaseAndManufactureCode(strPart.Substring(0, strPart.IndexOf(".")))
                            End If
                            'strCodeNumber = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPurchaseAndManufactureCode(strPart.Substring(0, strPart.IndexOf(".")))
                            'Till  Here
                            '12_10_2010   RAGAVA
                            Try
                                If strCodeNumber = "" Then
                                    strCodeNumber = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPurchaseAndManufactureCode(strPart.Substring(0, strPart.IndexOf(".")))
                                End If
                            Catch ex As Exception
                            End Try
                    End If

                    '10_08_2010    RAGAVA
                    Try
                        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.ContainsKey(fileName.Substring(fileName.LastIndexOf("\") + 1, fileName.IndexOf(".") - fileName.LastIndexOf("\") - 1)) = False Then
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.Add(fileName.Substring(fileName.LastIndexOf("\") + 1, fileName.IndexOf(".") - fileName.LastIndexOf("\") - 1), strCodeNumber)
                        Else
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(fileName.Substring(fileName.LastIndexOf("\") + 1, fileName.IndexOf(".") - fileName.LastIndexOf("\") - 1)) = strCodeNumber
                        End If
                    Catch ex As Exception
                    End Try
                    'Till  Here


                    Dim strModelNetworkPath As String = "X:\WeldedModels"
                    Dim strNewPartPath As String = fileName.Substring(0, fileName.LastIndexOf("\")) & "\" & strCodeNumber.ToString & ".SLDPRT"
                    Dim strReferenceAssm As String
                    If fileName.IndexOf("BASE") <> -1 OrElse fileName.IndexOf("BEC") <> -1 OrElse fileName.IndexOf("COLLAR") <> -1 OrElse fileName.IndexOf("BORE_IFL") <> -1 OrElse fileName.IndexOf("CLEVIS_PLATE_WR") <> -1 Then
                        strReferenceAssm = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath & "\TUBE_WELDMENT\TUBE_WELDMENT.SLDASM"
                    ElseIf fileName.IndexOf("ROD") <> -1 Then
                        strReferenceAssm = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath & "\ROD_WELDMENT\ROD_WELDMENT.SLDASM"
                    ElseIf fileName.IndexOf("CYL HEAD") <> -1 Then
                        strReferenceAssm = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath & "\CYLINDER_HEAD\CYL HEAD ASSEMBLY.SLDASM"           '27_10_2010   RAGAVA
                    Else
                        strReferenceAssm = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath & "\WELD_CYLINDER_ASSEMBLY\WELD_CYLINDER_ASSEMBLY.SLDASM"
                    End If
                    RenamePartFile(fileName, strNewPartPath, strReferenceAssm)
                    FolderStructure(strReferenceAssm, strNewPartPath, strModelNetworkPath)
                    '11_10_2010   RAGAVA
                    If Not (strPart.IndexOf("COLLAR") <> -1 OrElse strPart.IndexOf("BORE_IFL") <> -1 OrElse strPart.IndexOf("Rod") <> -1) AndAlso Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strNewPartCodeNumber_BeforeContractStart) <= Val(strCodeNumber) Then         '12_10_2010   RAGAVA Then
                        RenameDrawing(fileName, strNewPartPath.Replace(".SLDPRT", ".SLDDRW"), strNewPartPath, strModelNetworkPath & "\" & strCodeNumber.ToString & ".SLDPRT")
                    End If
                    'RenameDrawing(fileName, strNewPartPath.Replace(".SLDPRT", ".SLDDRW"), strNewPartPath, strModelNetworkPath & "\" & strCodeNumber.ToString & ".SLDPRT")
                    'Till   Here
                End If
                'Till   Here
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Function GetCollarCode() As String
        Try
            '21_12_2010  RAGAVA
            Dim strQuery As String
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType = "Rephasing at Extension" Then
                strQuery = "Select * from CollarDetails_RodEndRephasing where BoreDiameter = " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " and " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + " between MinTubeWallThickness and MaxTubeWallThickness  and portSize = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeRodEnd.Text.ToString) + "' and PortAngle = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleRodEnd.Text.ToString) + "' and NumberOfPorts = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbNoofPortsRodEnd.Text.ToString) + "'"
            Else
                strQuery = "Select * from CollarDetails where BoreDiameter = " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " and " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + " between MinTubeWallThickness and MaxTubeWallThickness  and portSize = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeRodEnd.Text.ToString) + "' and PortAngle = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleRodEnd.Text.ToString) + "' and NumberOfPorts = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbNoofPortsRodEnd.Text.ToString) + "'"
                If Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleRodEnd.Text.ToString) = "90" Then
                    strQuery = strQuery + " and PortFacingEnd = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortFacingRodEnd.Text.ToString) + "'"
                End If
            End If
            'Dim strQuery As String = "Select * from CollarDetails where BoreDiameter = " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " and " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + " between MinTubeWallThickness and MaxTubeWallThickness  and portSize = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeRodEnd.Text.ToString) + "' and PortAngle = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleRodEnd.Text.ToString) + "' and NumberOfPorts = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbNoofPortsRodEnd.Text.ToString) + "'"
            'Till  Here
            Dim _oRow As DataRow = MonarchConnectionObject.GetDataRow(strQuery)
            If Not IsNothing(_oRow) Then
                Return _oRow("CodeNumber")
            End If
        Catch ex As Exception
        End Try
    End Function

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
                'File.Copy(strRenameDrawing, "W:\" & strDrawingName)
                File.Copy(strRenameDrawing, "W:\WeldedDrawings\" & strDrawingName)       '16_08_2010   RAGAVA
                'bret = SolidWorksApplicationObject.ReplaceReferencedDocument("W:\" & strDrawingName, ReNamePart, strPartNetworkpath)
                bret = SolidWorksApplicationObject.ReplaceReferencedDocument("W:\WeldedDrawings\" & strDrawingName, ReNamePart, strPartNetworkpath)       '09_12_2010   RAGAVA
                Thread.Sleep(2000)       '03_03_2011   RAGAVA
                If OriginalPartName.ToString.IndexOf("ROD_WELDMENT.SLDASM") = -1 Then        '08_03_2011    RAGAVA
                    If Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strNewPartCodeNumber_BeforeContractStart) <= Val(strDrawingName.Substring(0, strDrawingName.IndexOf("."))) Then
                        oIflBaseSolidWorksClass.SolidWorksApplicationObject.CommandInProgress = False
                        CheckCommandInProgress()    '04_03_2011    RAGAVA
                        Dim blnRet As Boolean = oIflBaseSolidWorksClass.SolidWorksApplicationObject.SetCurrentWorkingDirectory("W:\WeldedDrawings")      '03_03_2011   RAGAVA
                        SolidWorksModel = SolidWorksApplicationObject.OpenDoc6("W:\WeldedDrawings\" & strDrawingName, 3, SwConst.swOpenDocOptions_e.swOpenDocOptions_Silent, "", 0, 0)
                        'SolidWorksModel = SolidWorksApplicationObject.OpenDoc6("W:\WeldedDrawings\" & strDrawingName, 3, SwConst.swOpenDocOptions_e.swOpenDocOptions_Silent, "", 0, 0)
                        SolidWorksApplicationObject.IActiveDoc.SaveAs2("W:\WeldedDrawings\" & strDrawingName, 3, True, True)
                        SolidWorksApplicationObject.IActiveDoc.SaveSilent()
                        SolidWorksApplicationObject.CloseAllDocuments(True)
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    '29_03_2010  ragava
    Public Sub updateCustomProperties(ByVal strFileName As String)
        Try
            Dim strDrawingDoc As String = String.Empty
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
            'checkProperty("USERNAME", "M.Dickenson")          '25_06_2010    RAGAVA
            checkProperty("USERNAME", System.Environment.UserName.ToString)        '15_11_2011   RAGAVA
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






                '26_10_2010   RAGAVA
                If Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortTypeBaseEnd.SelectedItem) = "ORB" Then
                    If Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.SelectedItem) = "9/16" Then
                        checkProperty("BASE END PORT DESCRIPTION", ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text.ToString + "-18UNF " + ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortTypeBaseEnd.Text.ToString + " PORT TYP REF.")
                    ElseIf Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.SelectedItem) = "3/4" Then
                        checkProperty("BASE END PORT DESCRIPTION", ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text.ToString + "-16UNF " + ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortTypeBaseEnd.Text.ToString + " PORT TYP REF.")
                    Else
                        checkProperty("BASE END PORT DESCRIPTION", ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text.ToString + " " + ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortTypeBaseEnd.Text.ToString + " PORT TYP REF.")
                    End If
                Else
                    checkProperty("BASE END PORT DESCRIPTION", ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text.ToString + " " + ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortTypeBaseEnd.Text.ToString + " PORT TYP REF.")
                End If
                'checkProperty("BASE END PORT DESCRIPTION", ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text.ToString + " " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_BaseEnd.ToString + " PORT")
                'Till   Here



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
                    Try
                        If (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConnectionType = "Threaded") Then
                            Dim strQuery As String = "select * from Welded.REDLThreaded where PartCode ='" + ObjClsWeldedCylinderFunctionalClass.strExistingRodEndPartCode + "'"
                            Dim dr As DataRow = MonarchConnectionObject.GetDataRow(strQuery)
                            If Not dr Is Nothing Then
                                checkProperty("THREAD SIZE", dr("ThreadType"))
                            End If
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Threaded Rod" Then
                            checkProperty("THREAD SIZE", Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmREThreadedRod.cmbThreadSize_RodEnd.Text).ToString)
                        End If
                    Catch ex As Exception
                    End Try

                    '30_12_2010   RAGAVA
                    UpdateWeldDetails_RodWeldment()
                    'Till   Here
                ElseIf strFileName.IndexOf("CYLINDER_HEAD") <> -1 Then
                    checkProperty("Material", "C1045")
                ElseIf strFileName.IndexOf("STOP TUBE") <> -1 Then
                    checkProperty("Material", "C1020")
                End If
                checkProperty("Drawn", "INVILOGIC")
                checkProperty("Designed", UCase(System.Environment.UserName.ToString))
                checkProperty("Approved", "")
                checkProperty("Date", strDate)
                checkProperty("Scale", "NTS")
                checkProperty("Mat#", "")
                'checkProperty("Description", "NEED TO GET FROM MONARCH")   '21_04_2011   RAGAVA

                '09_12_2010   RAGAVA
                'checkProperty("Code", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd)
                If strFileName.IndexOf("TUBE_WELDMENT") <> -1 Then
                    checkProperty("Code", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("TUBE_WELDMENT"))
                    checkProperty("Description", Format(Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, 2), "0.00").ToString & "-" & Format(Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength, 2), "00.00").ToString & "-W")   '21_04_2011   RAGAVA
                ElseIf strFileName.IndexOf("ROD_WELDMENT") <> -1 Then
                    checkProperty("Code", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("ROD_WELDMENT"))
                    checkProperty("Description", Format(Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter, 2), "0.00").ToString & "-" & Format(Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength, 2), "00.00").ToString & "-" & Format(Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ShankLength), "00.00").ToString & "-W")   '21_04_2011   RAGAVA
                End If
                'Till   Here


                '28_06_2010   RAGAVA
                Dim strDocName As String = String.Empty
                If strFileName.IndexOf("TUBE_WELDMENT") <> -1 Then
                    strDrawingDoc = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\TUBE_WELDMENT\TUBE_WELDMENT.SLDDRW"
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
                        '09_11_2010    RAGAVA
                        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "FILLET" Then
                            DeleteView("Drawing View11")
                            DeleteSketchSegment("Arc14", "Drawing View3")
                            DeleteDetailedCircle("Detail Circle3")
                        End If
                        'Till   Here
                        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "New" Then
                            'DeleteView("Drawing View11")          '09_11_2010    RAGAVA
                            DeleteSketchSegment("Arc15", "Drawing View3")           '09_11_2010    RAGAVA
                            DeleteView("Drawing View12")
                            DeleteDetailedCircle("Detail Circle4")
                            DeleteSketchSegment("Arc15", "Drawing View3")           '09_11_2010    RAGAVA
                            UpdateWeldDetails("Drawing View3")    '29_12_2010   RAGAVA
                            DeleteDetailItem("DetailItem407@Drawing View3", "Drawing View3")
                            DeleteDetailItem("DetailItem408@Drawing View3", "Drawing View3")

                            '29_12_2010   RAGAVA
                            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion = "Flushed" Then
                                DeleteDetailItem("DetailItem410@Drawing View3", "Drawing View3")
                            Else
                                DeleteDetailItem("DetailItem400@Drawing View3", "Drawing View3")
                            End If
                            'Till  Here

                            DeleteDimension("D2@Sketch12@TUBE_WELDMENT", "Drawing View3")        '24_08_2010    RAGAVA
                            DeleteNote("DetailItem169@Drawing View3", "Drawing View3")       '27_08_2010    RAGAVA
                        Else
                            DeleteView("Drawing View10")
                            DeleteDetailedCircle("Detail Circle2")
                            UpdateWeldDetails("Drawing View3")    '29_12_2010   RAGAVA
                            DeleteDetailItem("DetailItem410@Drawing View3", "Drawing View3")
                            DeleteDetailItem("DetailItem409@Drawing View3", "Drawing View3")
                            If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port Integral" Then
                                DeleteDetailItem("DetailItem407@Drawing View3", "Drawing View3")
                            End If
                            DeleteSketchSegment("Arc13")
                        End If
                        '13_08_2010   RAGAVA
                        'BASE PLUG, SINGLE LUG & DOUBLE LUG
                        ' ''If Not (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Single Lug" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Base Plug") Then
                        ' ''    DeleteSketchSegment("Arc14")
                        ' ''End If
                        ' ''If Not (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Single Lug" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug") Then
                        ' ''    DeleteSketchSegment("Arc15")
                        ' ''End If


                        ' ''If ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories._blnIsBaseEndPinsPresent = False Then
                        ' ''    DeleteNote("DetailItem553@Drawing View2", "Drawing View2")
                        ' ''End If
                        ' ''If ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories._blnIsRodEndPinsPresent = False Then
                        ' ''    DeleteNote("DetailItem557@Drawing View2", "Drawing View2")
                        ' ''End If
                        'Till   Here
                    Catch ex As Exception
                    End Try
                    'Till   here
                ElseIf strFileName.IndexOf("ROD_WELDMENT") <> -1 Then
                    strDrawingDoc = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD_WELDMENT\ROD_WELDMENT.SLDDRW"
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
                strDrawingDoc = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\WELD_CYLINDER_ASSEMBLY\WELD_CYLINDER_ASSEMBLY.SLDDRW"
                '25_06_2010    RAGAVA
                Dim strGeneralNote As String
                'strGeneralNote = "BORE " + Format(Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, 2), "00.00") + " X " + Format(Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength, 2), "00.00") + vbNewLine + " Max. Working Pressure " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure.ToString + " PSI" + vbNewLine
                strGeneralNote = Format(Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, 2), "00.00") + " BORE" + " X " + Format(Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength, 2), "00.00") + " STROKE" + vbNewLine + " MAX. WORKING PRESSURE " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure.ToString + " PSI" + vbNewLine     '09_05_2011  RAGAVA
                '03_10_2011   RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ColumnLoadDeratePressure <> "N/A" Then
                    strGeneralNote = strGeneralNote & "MAX. WORKING PRESSURE " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ColumnLoadDeratePressure.ToString & " PSI FULL EXTENSION " & vbNewLine
                End If
                'Till   Here

                If ObjClsWeldedCylinderFunctionalClass.ObjFrmGenerate.chkSingleActingPullAppliction.Checked = True Then
                    strGeneralNote = strGeneralNote & " SINGLE ACTING PULL APPLICATION " & vbNewLine
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjFrmGenerate.chkSingleActingPushApplication.Checked = True Then
                    strGeneralNote = strGeneralNote & " SINGLE ACTING PUSH APPLICATION " & vbNewLine
                End If

                '28_07_2011  RAGAVA
                Dim strClassNote As String = String.Empty
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass = 1 Then
                    strClassNote = "CLASS 1-15,000 CYCLES"
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass = 2 Then
                    strClassNote = "CLASS 2-50,000 CYCLES"
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass = 3 Then
                    strClassNote = "CLASS 3-250,000 CYCLES"
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass = 4 Then
                    strClassNote = "CLASS 4-500,000 CYCLES"
                End If
                'Till   Here

                'strGeneralNote = strGeneralNote & "Monarch Cylinder - " & strClassNote & " as per WI04-E-11" + vbNewLine      '07_09_2010    RAGAVA
                strGeneralNote = strGeneralNote & "MONARCH CYLINDER " & strClassNote & " AS PER WI04-E-11" + vbNewLine      '12_03_2012    RAGAVA
                strGeneralNote = strGeneralNote & "CYLINDER CLEANLINESS CONTROLLED AS PER MONARCH WI10-E-50" + vbNewLine            '29_09_2010   RAGAVA

                Dim StrTempRange As String = String.Empty                                                                        'priyanka
                If (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedPistonSeal = "Wyn Seal" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedPistonSeal = "Glyd-P Seal") AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 3 Then
                    StrTempRange = " -25°C(-13°F) TO +100°C(210°F)"
                ElseIf (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedPistonSeal = "Wyn Seal" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedPistonSeal = "Glyd-P Seal") AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter > 3 Then
                    StrTempRange = " -30°C(-20°F) TO +100°C(210°F)"
                End If
                strGeneralNote = strGeneralNote & "ALLOWABLE TEMPERATURE RANGE:" & StrTempRange + vbNewLine

                'ANUP 04-10-2010 START
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.New_Revision = "Revision'" Then
                    Dim strCustomePartCode As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RevisionContractNo
                    Dim strCustomerPartCode As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetCustomerPartCode(strCustomePartCode)
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PartCode_ContractDetails = strCustomerPartCode
                End If
                'ANUP 04-10-2010 TILL HERE

                If Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PartCode_ContractDetails) <> "" Then
                    strGeneralNote = strGeneralNote + "CUSTOMER PART # " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PartCode_ContractDetails
                End If
                'Till  Here
                checkProperty("Material", "")
                checkProperty("Drawn", "INVILOGIC")
                checkProperty("Designed", UCase(System.Environment.UserName.ToString))
                checkProperty("Approved", "")
                checkProperty("Date", strDate)
                checkProperty("Scale", "NTS")
                checkProperty("Mat#", "")
                checkProperty("Description", "<MOD-DIAM> " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " Welded Cylinder")
                checkProperty("Customer Name", "For " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CustomerName_ContractDetails.ToString)
                checkProperty("Code", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString)     '06_07_2010   RAGAVA


                '26_10_2010   RAGAVA
                If Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortTypeRodEnd.SelectedItem) = "ORB" Then
                    If Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeRodEnd.SelectedItem) = "9/16" Then
                        checkProperty("PORT TYPE", ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeRodEnd.SelectedItem.ToString + "-18UNF " + ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortTypeRodEnd.SelectedItem.ToString + " PORT TYP REF.")
                    ElseIf Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeRodEnd.SelectedItem) = "3/4" Then
                        checkProperty("PORT TYPE", ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeRodEnd.SelectedItem.ToString + "-16UNF " + ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortTypeRodEnd.SelectedItem.ToString + " PORT TYP REF.")
                    Else
                        checkProperty("PORT TYPE", ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeRodEnd.SelectedItem.ToString + " " + ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortTypeRodEnd.SelectedItem.ToString + " PORT TYP REF.")
                    End If
                Else
                    checkProperty("PORT TYPE", ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeRodEnd.SelectedItem.ToString + " " + ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortTypeRodEnd.SelectedItem.ToString + " PORT TYP REF.")
                End If
                'Till   Here


                '26_10_2010    RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "New" Then
                    checkProperty("Cylinder Note", Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter * 10, 2).ToString + "WD" + (Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength, 2)).ToString + "-" + (Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter, 2) * 100).ToString)      '07_07_2010    RAGAVA changed WR to WD 25/05/14 as per kiran
                Else
                    '09_07_2011  RAGAVA
                    'checkProperty("Cylinder Note", Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter * 10, 2).ToString + "WD" + Format(Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength, 2), "00.00") + "-" + (Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter, 2) * 100).ToString)      '07_07_2010    RAGAVA
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength = 8 OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength = 16 Then
                        checkProperty("Cylinder Note", Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter * 10, 2).ToString + "WPC" + (Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength, 2)).ToString + "-" + (Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter, 2) * 100).ToString + "ASAE")  'changed WD to WPC 25th June 2013
                    Else 'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType=


                        'checkProperty("Cylinder Note", Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter * 10, 2).ToString + "WD" + Format(Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength, 2), "00.00") + "-" + (Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter, 2) * 100).ToString) 'Changed WPC to WD as per kiran
                        checkProperty("Cylinder Note", Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter * 10, 2).ToString + "WD" + (Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength, 2)).ToString + "-" + (Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter, 2) * 100).ToString) 'Changed WPC to WD as per kiran
                    End If
                    'TILL   HERE
                End If
                'checkProperty("Cylinder Note", Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter * 10, 2).ToString + "WD" + Format(Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength, 2), "00.00") + "-" + (Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter, 2) * 100).ToString)      '07_07_2010    RAGAVA
                'Till   Here

                checkProperty("General_Note", strGeneralNote)      '25_06_2010    RAGAVA
                checkProperty("EXTENDED LENGTH", Math.Round((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RetractedLength), 2))      '03_09_2010    RAGAVA
                UpdateAssemblyDrawing()

                '16_08_2010    RAGAVA
                Dim value As String = UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodMaterial)
                If value.IndexOf("NITRO") <> -1 Then
                    value = "NITROSTEEL"       '03_09_2010    RAGAVA
                End If
                OverwriteDimensionNote("ROD_OD@Sketch1@WELD_CYLINDER_ASSEMBLY-0-SectionAssembly-2-1@Drawing View4/WELD_CYLINDER_ASSEMBLY-1@WELD_CYLINDER_ASSEMBLY-SectionAssembly-2/" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("ROD_WELDMENT") & "-1@WELD_CYLINDER_ASSEMBLY/" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("Rod_Welded") & "-1@" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("ROD_WELDMENT"), value, "Drawing View4", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter)

                'value = Format(Math.Round((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RetractedLength), 2), "00.00") + " EXTENDED"      '07_09_2010   RAGAVA
                value = "(" + Format(Math.Round((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RetractedLength), 2), "00.00") + " EXTENDED)"      '21_12_2010  RAM     '07_09_2010   RAGAVA
                OverwriteRetractedDimensionNote("RD48@Drawing View4", value, "Drawing View4", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RetractedLength)      '07_09_2010   RAGAVA

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
            'If UCase(SolidWorksApplicationObject.IActiveDoc.GetPathName).ToString.IndexOf(".SLDDRW") <> -1 Then
            '    SolidWorksApplicationObject.IActiveDoc.SaveAs2(SolidWorksApplicationObject.IActiveDoc.GetPathName, 3, True, True)       '01_02_2011   RAGAVA
            'End If
            If strDrawingDoc <> "" Then
                DeleteDanglingDimensions(strDrawingDoc)
            End If
            SolidWorksApplicationObject.IActiveDoc.SaveSilent()
        Catch ex As Exception
            'MsgBox("Error in Updating Notes to CustomProperties")
        End Try
    End Sub

    '14_07_2010  ragava
    Public Sub DeleteSketchSegment(ByVal strItem As String, Optional ByVal strViewName As String = "Drawing View2")
        Try
            Dim boolstatus As Boolean = False
            SolidWorksModel = SolidWorksApplicationObject.ActiveDoc
            boolstatus = SolidWorksApplicationObject.ActiveDoc.ActivateView(strViewName)      '16_08_2010     RAGAVA
            boolstatus = SolidWorksModel.Extension.SelectByID2(strItem, "SKETCHSEGMENT", 0, 0, 0, False, 0, Nothing, 0)
            SolidWorksModel.EditDelete()
            SolidWorksModel.ClearSelection2(True)
        Catch ex As Exception
            'MsgBox("Error in Deleting SKETCH SEGMENT")
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error in Deleting SKETCH SEGMENT ")
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
            Dim strDrawingFile As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\WELD_CYLINDER_ASSEMBLY\WELD_CYLINDER_ASSEMBLY.SLDDRW"
            openAssemblyDrawingDocument(strDrawingFile)
            docName = "WELD_CYLINDER_ASSEMBLY.SLDDRW"
            'End If
            SolidWorksModel = SolidWorksApplicationObject.ActivateDoc(docName)
            If (Val(ObjClsWeldedCylinderFunctionalClass.TxtFirstPortOrientation_BaseEnd.Text) = 0 OrElse Trim(ObjClsWeldedCylinderFunctionalClass.TxtFirstPortOrientation_BaseEnd.Text) = "") Then
                DeleteView("Drawing View5")
            End If
            'If (Val(ObjClsWeldedCylinderFunctionalClass.FirstPortOrientation_RodEnd) = 0 OrElse Trim(ObjClsWeldedCylinderFunctionalClass.FirstPortOrientation_RodEnd) = "") Then
            If (Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationRodEnd.Text) = 0 OrElse Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationRodEnd.Text) = "") Then      '07_03_2011  RAGAVA
                DeleteView("Drawing View6")
            End If
            '14-08-10 RAM
            If Not (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Single Lug" _
            OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "BH" _
            OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Base Plug") Then
                DeleteSketchSegment("Arc14")
                DeleteSketchSegment("Arc12", "Section View A-A")          '09_11_2010   RAGAVA
            End If
            If Not (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Single Lug" _
            OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "BH" _
            OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug") Then
                DeleteSketchSegment("Arc15")
                DeleteSketchSegment("Arc13", "Section View A-A")          '09_11_2010   RAGAVA
            End If
            '09_11_2010   RAGAVA
            If (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Single Lug" _
OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "BH" _
OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Base Plug") Then
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd = 2 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_RodEnd = 1 AndAlso Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtSecondPortOrientationBaseEnd.Text) = "90" AndAlso Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationRodEnd.Text) = "90" Then
                    DeleteSketchSegment("Arc14")
                    DeleteSketchSegment("Arc15")
                    'Else
                    '    DeleteSketchSegment("Arc12")
                    '    DeleteSketchSegment("Arc13")
                End If
                If Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationBaseEnd.Text) = "90" Then
                    DeleteSketchSegment("Arc14")
                Else
                    DeleteSketchSegment("Arc12", "Section View A-A")
                End If
            End If
            If (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Single Lug" _
OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "BH" _
OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug") Then
                If Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationRodEnd.Text) = "90" Then
                    DeleteSketchSegment("Arc15")
                Else
                    DeleteSketchSegment("Arc13", "Section View A-A")
                End If
            End If
            'Till   Here

            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories._blnIsBaseEndPinsPresent = False Then
                DeleteNote("DetailItem553@Drawing View2", "Drawing View2")
            End If
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories._blnIsRodEndPinsPresent = False Then
                DeleteNote("DetailItem557@Drawing View2", "Drawing View2")
            End If
            'Till Here 

            '25_08_2010    RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmGenerate.chkStampCustomerPartOnTube.Checked = False Then
                DeleteBlocksFromAssyDrawing("Block4-1", "Drawing View2")
            End If
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmGenerate.chkStampCustomerPartandDate.Checked = False Then
                DeleteBlocksFromAssyDrawing("Block1-1", "Drawing View2")
            End If
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmGenerate.chkAffixLabel.Checked = False Then
                DeleteBlocksFromAssyDrawing("Block5-1", "Drawing View2")
            End If
            'Till    Here

            'vamsi 06/06/2014 start 
            If Not (ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingYes.chkDoubleLugFabricationRequired.Checked = True OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingYes.chkBHFabricationRequired.Checked = True OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingYes.chkCrossTubeFabricationRequired.Checked = True OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingYes.chkSingleLugFabricationRequired.Checked = True) Then
                DeleteView("Drawing View12")
            End If
            'end

            '26_08_2010   RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "New" Then
                DeleteNote("DetailItem166@Drawing View4", "Drawing View4")
            Else
                DeleteNote("DetailItem605@Drawing View4", "Drawing View4")
            End If
            'Till    Here

            '30_08_2010      RAGAVA
            Try
                If ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.cmbPinHole.Enabled = False Then
                    DeleteDimension("D1@BASE_PIN_HOLE_SIZE@WELD_CYLINDER_ASSEMBLY-2@Drawing View2", "Drawing View2")
                End If
                If ObjClsWeldedCylinderFunctionalClass.ObjFrmRodEndConfiguration.cmbPinHole_RodEnd.Enabled = False Then
                    DeleteDimension("D1@ROD_PIN_HOLE_SIZE@WELD_CYLINDER_ASSEMBLY-2@Drawing View2", "Drawing View2")
                End If

                '03_09_2010   RAGAVA
                If Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.cmbGreaseZercs.SelectedItem) = "0" OrElse Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.cmbGreaseZercs.SelectedItem) = "" Then
                    DeleteDimension("RD9@Drawing View2", "Drawing View2")
                    DeleteDimension("RD11@Drawing View2", "Drawing View2")
                ElseIf Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.cmbGreaseZercs.SelectedItem) = "1" Then
                    DeleteDimension("RD11@Drawing View2", "Drawing View2")
                End If

                If Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmRodEndConfiguration.cmbGreaseZercs_RodEnd.SelectedItem) = "0" OrElse Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmRodEndConfiguration.cmbGreaseZercs_RodEnd.SelectedItem) = "" Then
                    DeleteDimension("RD29@Drawing View2", "Drawing View2")
                    DeleteDimension("RD19@Drawing View2", "Drawing View2")
                ElseIf Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmRodEndConfiguration.cmbGreaseZercs_RodEnd.SelectedItem) = "1" Then
                    DeleteDimension("RD19@Drawing View2", "Drawing View2")
                End If
            Catch ex As Exception
            End Try
            'Till    Here

            


            '17_02_2011   RAGAVA
            Try
                If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                    DeleteDimension("D3@Sketch9@WELD_CYLINDER_ASSEMBLY.SLDDRW", "Section View A-A")
                Else
                    Dim boolstatus As Boolean = False
                    SolidWorksModel = SolidWorksApplicationObject.ActivateDoc("WELD_CYLINDER_ASSEMBLY.SLDDRW")
                    oIflBaseSolidWorksClass.SolidWorksModel = SolidWorksApplicationObject.ActiveDoc
                    boolstatus = SolidWorksModel.ActivateView("Section View A-A")
                    boolstatus = SolidWorksModel.Extension.SelectByID2("D3@Sketch9@WELD_CYLINDER_ASSEMBLY.SLDDRW", "DIMENSION", 0, 0, 0, False, 0, Nothing, 0)
                    boolstatus = SolidWorksModel.EditDimensionProperties2(2, Math.Round((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceUpperLimit * 0.0254), 3), Math.Round((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceLowerLimit * 0.0254), 3), "", "", True, 9, 2, True, 12, 12, "", "<MOD-DIAM>", True, "", "", True)
                    DeleteDimension("D1@BASE_PIN_HOLE_SIZE@WELD_CYLINDER_ASSEMBLY-2@Drawing View2", "Drawing View2")
                End If
                If ObjClsWeldedCylinderFunctionalClass.strPortAngle_RodEnd = "Straight" Then
                    DeleteDimension("D4@Sketch9@WELD_CYLINDER_ASSEMBLY.SLDDRW", "Section View A-A")
                Else
                    Dim boolstatus As Boolean = False
                    SolidWorksModel = SolidWorksApplicationObject.ActivateDoc("WELD_CYLINDER_ASSEMBLY.SLDDRW")
                    oIflBaseSolidWorksClass.SolidWorksModel = SolidWorksApplicationObject.ActiveDoc
                    boolstatus = SolidWorksModel.ActivateView("Section View A-A")
                    boolstatus = SolidWorksModel.Extension.SelectByID2("D4@Sketch9@WELD_CYLINDER_ASSEMBLY.SLDDRW", "DIMENSION", 0, 0, 0, False, 0, Nothing, 0)
                    boolstatus = SolidWorksModel.EditDimensionProperties2(2, Math.Round((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceUpperLimit_RodEnd * 0.0254), 3), Math.Round((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceLowerLimit_RodEnd * 0.0254), 3), "", "", True, 9, 2, True, 12, 12, "", "<MOD-DIAM>", True, "", "", True)
                    DeleteDimension("D1@ROD_PIN_HOLE_SIZE@WELD_CYLINDER_ASSEMBLY-2@Drawing View2", "Drawing View2")
                End If
            Catch ex As Exception
                'MsgBox("Error in updating Dimension of Weld Cylinder")
                ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error in Updating Dimension of weld Cylinder ")
            End Try


            '19_07_2012   RAGAVA
            Try
                If Not (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType.StartsWith("Rephasing") = True AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "Conventional") Then
                    DeleteView("Drawing View7")
                End If
                If Not ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType = "Rephasing at Extension" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType = "Rephasing at Bothends") AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "Conventional") Then
                    DeleteView("Drawing View8")
                End If
                If Not ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType = "Rephasing at Retraction" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType = "Rephasing at Bothends") AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "Conventional") Then
                    DeleteView("Drawing View9")
                End If
                If Not (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType.StartsWith("Rephnasing") = True AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "New") Then
                    DeleteView("Drawing View10")
                End If
                If Not (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType = "Rephasing at Extension" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "New") Then
                    DeleteView("Drawing View11")
                End If
                If Not (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Single Lug" _
                            OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "BH" _
                            OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" _
                OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Cross Tube") Then
                    DeleteView("Drawing View12")
                    DeleteView("Drawing View13")
                End If

                'VAMSI 23-05-14
                'Try
                '    If Not ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingYes.chkDoubleLugFabricationRequired.Checked = True OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingYes.chkBHFabricationRequired.Checked = True OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingYes.chkCrossTubeFabricationRequired.Checked = True OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingYes.chkSingleLugFabricationRequired.Checked = True Then
                '        DeleteView("Drawing View12")
                '    End If
                'Catch ex As Exception

                'End Try

                ''28_08_2012   RAGAVA
                'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType.StartsWith("Rephasing") = True Then
                '    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "Conventional" Then
                '        DeleteView("Drawing View10")
                '    Else  ' NEW
                '        DeleteView("Drawing View7")
                '    End If
                'Else ' No Rephasing
                '    DeleteView("Drawing View7")
                'End If
                'If Not ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType = "Rephasing at Extension" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType = "Rephasing at Bothends") AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "Conventional") Then
                '    DeleteView("Drawing View8")
                'End If
                'If Not ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType = "Rephasing at Retraction" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType = "Rephasing at Bothends") AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "Conventional") Then
                '    DeleteView("Drawing View9")
                'End If
                'If Not (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType = "Rephasing at Extension" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "New") Then
                '    DeleteView("Drawing View11")
                'End If
                'If Not (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Single Lug" _
                '            OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "BH" _
                '            OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" _
                'OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Cross Tube") Then
                '    DeleteView("Drawing View12")
                '    DeleteView("Drawing View13")
                'End If
            Catch ex As Exception
            End Try
            SolidWorksApplicationObject.IActiveDoc.SaveSilent()
        Catch ex As Exception
        End Try
    End Sub

    '19_07_2012   RAGAVA
    Private Sub DeleteSketch(ByVal strItem As String)
        Try
            Dim boolstatus As Boolean = False
            SolidWorksModel = SolidWorksApplicationObject.ActiveDoc
            SolidWorksModel.Extension.SelectByID2(strItem, "SKETCH", 0, 0, 0, False, 0, Nothing, 0)
            SolidWorksModel.EditDelete()
            SolidWorksModel.ClearSelection2(True)
        Catch ex As Exception
            'MsgBox("Error in Deleting Sketch")
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error in Deleting Sketch ")
        End Try
    End Sub

    '15_09_2009   ragava
    Public Sub OverwriteDimensionNote(ByVal strDimension As String, ByVal Value As String, ByVal strViewName As String, ByVal dblValue As Double, Optional ByVal strSheet As String = "Sheet1")
        Try
            Dim docName As String = "WELD_CYLINDER_ASSEMBLY.SLDDRW"
            SolidWorksModel = SolidWorksApplicationObject.ActivateDoc(docName)
            Dim boolstatus As Boolean = False
            oIflBaseSolidWorksClass.SolidWorksModel = SolidWorksApplicationObject.ActiveDoc
            boolstatus = SolidWorksModel.ActivateView(strViewName)
            boolstatus = SolidWorksModel.Extension.SelectByID2(strDimension, "DIMENSION", 0, 0, 0, False, 0, Nothing, 0)
            boolstatus = SolidWorksModel.EditDimensionProperties2(0, 0, 0, "", "", True, 9, 2, True, 12, 12, "", "<MOD-DIAM>" & Format(Math.Round(dblValue, 2), "0.00").ToString & " " & Value, False, "", "", True)
            'boolstatus = SolidWorksModel.EditDimensionProperties2(4, 0, 0, "", "", False, 9, 2, True, 12, 12, "", Value, True, "", "", True)
            SolidWorksModel.ClearSelection2(True)
            boolstatus = SolidWorksModel.ActivateSheet(strSheet)
            'IFLSolidWorksBaseClassObject.SolidWorksModel.SaveSilent()
        Catch ex As Exception
            'MsgBox("Error in Overwritting Dimensions")
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error in Overwritting Dimensions ")
        End Try
    End Sub
    '07_09_2010    RAGAVA
    Public Sub OverwriteRetractedDimensionNote(ByVal strDimension As String, ByVal Value As String, ByVal strViewName As String, ByVal dblValue As Double, Optional ByVal strSheet As String = "Sheet1")
        Try
            Dim docName As String = "WELD_CYLINDER_ASSEMBLY.SLDDRW"
            SolidWorksModel = SolidWorksApplicationObject.ActivateDoc(docName)
            Dim boolstatus As Boolean = False
            oIflBaseSolidWorksClass.SolidWorksModel = SolidWorksApplicationObject.ActiveDoc
            boolstatus = SolidWorksModel.ActivateView(strViewName)
            boolstatus = SolidWorksModel.Extension.SelectByID2(strDimension, "DIMENSION", 0, 0, 0, False, 0, Nothing, 0)
            'boolstatus = SolidWorksModel.EditDimensionProperties2(4, 0.0016, 0, "", "", False, 9, 2, True, 12, 12, "", " RETRACTED" & vbNewLine & Value, True, "", "", True)
            'TESTING
            boolstatus = SolidWorksModel.EditDimensionProperties2(4, 0.0016, 0, "", "", True, 9, 2, True, 12, 12, "", " RETRACTED", True, "", "", True)
            boolstatus = SolidWorksModel.EditDimensionProperties2(4, 0.0016, 0, "", "", True, 9, 2, True, 12, 12, "", " RETRACTED", True, "", Value, True)

            SolidWorksModel.ClearSelection2(True)
            boolstatus = SolidWorksModel.ActivateSheet(strSheet)
            'IFLSolidWorksBaseClassObject.SolidWorksModel.SaveSilent()
        Catch ex As Exception
            ' MsgBox("Error in Overwritting Dimensions")
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error in Overwritting Dimensions ")
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
            'MsgBox("Error in Deleting Detail Item")
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error in Deleting Details Item ")
        End Try
        'Part.Extension.SelectByID2("DetailItem150@Drawing View2", "GTOL", 0.2245335748516, 0.1509591747284, 0, False, 0, Nothing, 0)
    End Sub

    '29_12_2010   RAGAVA
    Public ReadOnly Property TubeWallThicknessInRation() As Hashtable
        Get
            TubeWallThicknessInRation = New Hashtable
            TubeWallThicknessInRation.Add("0.121", "1/8")
            TubeWallThicknessInRation.Add("0.125", "1/8")
            TubeWallThicknessInRation.Add("0.170", "3/16")
            TubeWallThicknessInRation.Add("0.183", "3/16")
            TubeWallThicknessInRation.Add("0.185", "3/16")
            TubeWallThicknessInRation.Add("0.188", "3/16")
            TubeWallThicknessInRation.Add("0.204", "3/16")
            TubeWallThicknessInRation.Add("0.235", "1/4")
            TubeWallThicknessInRation.Add("0.245", "1/4")
            TubeWallThicknessInRation.Add("0.248", "1/4")
            TubeWallThicknessInRation.Add("0.250", "1/4")
            TubeWallThicknessInRation.Add("0.311", "5/16")
            TubeWallThicknessInRation.Add("0.313", "5/16")
            TubeWallThicknessInRation.Add("0.375", "3/8")
        End Get
    End Property
    '29_12_2010   RAGAVA
    Private Function GetTubeWallThickness() As String
        Try
            GetTubeWallThickness = String.Empty
            GetTubeWallThickness = TubeWallThicknessInRation(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString)
            Return GetTubeWallThickness
        Catch ex As Exception
        End Try
    End Function

    '30_12_2010   RAGAVA
    Private Sub UpdateWeldDetails_RodWeldment() 'ByVal strViewName As String)
        Try
            Dim strValue As String = String.Empty
            Dim boolstatus As Boolean = False
            openAssemblyDrawingDocument(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD_WELDMENT\ROD_WELDMENT.SLDDRW")
            Dim strDocName As String = "ROD_WELDMENT.SLDDRW"
            SolidWorksModel = SolidWorksApplicationObject.ActivateDoc(strDocName)
            SolidWorksModel = SolidWorksApplicationObject.ActiveDoc
            'boolstatus = SolidWorksModel.ActivateView(strViewName)
            SolidWorksDrawingDocument = SolidWorksModel
            SolidWorksView = SolidWorksDrawingDocument.GetFirstView
            Dim iweldCount As Integer
            Dim Owelds As SldWorks.WeldSymbol
            Dim OweldsCollection() As Object
            Dim _oRow As DataRow
            While Not SolidWorksView Is Nothing
                iweldCount = SolidWorksView.GetWeldSymbolCount()
                If iweldCount > 0 Then
                    Owelds = SolidWorksView.GetFirstWeldSymbol()
                    OweldsCollection = SolidWorksView.GetWeldSymbols()
                    Try
                        Dim strquery As String = "select WeldSize from Welded.REULug_ManualWeldDetails where WeldSizeNumeric = " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEnd.ToString
                        _oRow = MonarchConnectionObject.GetDataRow(strquery)
                        strValue = IIf(IsDBNull(_oRow("WeldSize")), "0", _oRow("WeldSize").ToString)
                    Catch ex As Exception
                    End Try
                    For Each objWeld As Object In OweldsCollection
                        Owelds = objWeld
                        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldPreperation_RodEnd = "Chamfer" Then
                            Owelds.SetText(False, strValue, "<AWLD-FILL>", "", "", 1)
                        Else
                            If ObjClsWeldedCylinderFunctionalClass.strManual_Lathe = "Manual" Then
                                Owelds.SetText(False, strValue, "<AWLD-GJ>", "", "", 3)
                            ElseIf ObjClsWeldedCylinderFunctionalClass.strManual_Lathe = "Lathe" Then
                                Owelds.SetText(False, strValue, "<AWLD-GU>", "", "", 3)
                            End If
                        End If
                        Dim dblroddia As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter
                        Dim dblPullForce As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PullForce_RodEnd
                        Dim dblweldstress As Double = dblPullForce / ((Math.Pow(dblroddia, 2) - Math.Pow((dblroddia - (2 * ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEnd)), 2)) * (Math.PI / 4))
                        dblweldstress = Math.Ceiling(dblweldstress / 100) * 100
                        Owelds.SetProcess(True, dblweldstress.ToString & " PSI", False)
                    Next
                End If
                SolidWorksView = SolidWorksView.GetNextView
            End While
            SolidWorksApplicationObject.IActiveDoc.SaveSilent()
            SolidWorksApplicationObject.CloseDoc(strDocName)
        Catch ex As Exception

        End Try
    End Sub

    '29_12_2010   RAGAVA
    Private Sub UpdateWeldDetails(ByVal strViewName As String)
        Try
            Dim strvalue As String = String.Empty
            Dim strQuery As String = String.Empty
            Dim _oRow As DataRow
            strvalue = GetTubeWallThickness()
            Dim boolstatus As Boolean = False
            SolidWorksModel = SolidWorksApplicationObject.ActiveDoc
            boolstatus = SolidWorksModel.ActivateView(strViewName)
            SolidWorksDrawingDocument = SolidWorksModel
            SolidWorksView = SolidWorksDrawingDocument.GetFirstView
            Dim iweldCount As Integer
            Dim Owelds As SldWorks.WeldSymbol
            Dim OweldsCollection() As Object
            While Not SolidWorksView Is Nothing
                iweldCount = SolidWorksView.GetWeldSymbolCount()
                If iweldCount > 0 Then
                    Owelds = SolidWorksView.GetFirstWeldSymbol()
                    OweldsCollection = SolidWorksView.GetWeldSymbols()
                    iweldCount = 1
                    For Each objWeld As Object In OweldsCollection
                        Owelds = objWeld
                        If iweldCount < 5 Then
                            Owelds.SetText(False, strvalue, "<AWLD-FILL>", "", "", 1)
                        ElseIf iweldCount > 5 Then
                            If iweldCount > 7 Then
                                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion <> "Flushed" OrElse iweldCount = 8 Then
                                    strQuery = "Select * from CollarDetails where BoreDiameter = " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " and " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + " between MinTubeWallThickness and MaxTubeWallThickness  and portSize = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeRodEnd.Text.ToString) + "'"
                                    _oRow = MonarchConnectionObject.GetDataRow(strQuery)
                                    strvalue = IIf(IsDBNull(_oRow("WeldSize")), "0", _oRow("WeldSize").ToString)
                                Else
                                    strvalue = GetTubeWallThickness()
                                End If
                            End If
                            Owelds.SetText(False, strvalue, "<AWLD-FILL>", "", "", 1)
                        ElseIf iweldCount > 4 Then
                            strvalue = GetTubeWallThickness()
                            Owelds.SetText(False, strvalue, "<AWLD-GV>", "", "", 3)
                        End If
                        iweldCount = iweldCount + 1
                    Next
                End If
                SolidWorksView = SolidWorksView.GetNextView
            End While
        Catch ex As Exception
        End Try
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
            'MsgBox("Error in Deleting Notes")
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error in Deleting Notes")
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
            'MsgBox("Error in Deleting View")
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error in Deleting View ")
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
            'MsgBox("Error in Deleting Dimension")
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error in Deleting Dimensions ")
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
            'MsgBox("Error in Deleting Notes")
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error in Deleting Notes ")
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
            'MsgBox("Error in Breaking View")
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error in Breaking View ")
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
                ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Drawing file doesn't exist at path : " + openFileName)
            End If
            oIflBaseSolidWorksClass.openDocument(openFileName)
            'SolidWorksApplicationObject.SetUserPreferenceToggle(swUserPreferenceToggle_e.swShowErrorsEveryRebuild, False) 'vamsi 15-11-2013
            oIflBaseSolidWorksClass.SolidWorksApplicationObject.SetUserPreferenceToggle(77, False)
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
            SolidWorksApplicationObject.CloseAllDocuments(True)
        Catch ex As Exception

        End Try
        'TILL   HERE
    End Sub

    Public Sub getMaxContractRevisionNumber()
        Try
            Dim strSQL As String = ""
            strSQL = "Select  max(RevisionNumber) as RevisionNumber From revisionTable where ContractNumber='" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber & "'"
            Dim objDT As DataTable = MonarchConnectionObject.GetTable(strSQL)
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.intContractRevisionNumber = IIf(IsDBNull(objDT.Rows(0)("RevisionNumber")), 0, objDT.Rows(0)("RevisionNumber"))   '14_09_2010   RAGAVA
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
            strSQL = "select  top 7  * from revisionTable  where contractNumber='" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber & "' order by RevisionNumber"
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

    '25_10_2010   RAGAVA
    'Public Sub DisplaySelectedPartImage(ByVal strImagePath As String)
    '    'Dim Extractor As SldWorks_ExtractBitmap.ISldWorks_ExtractBitmap           '25_10_2010   RAGAVA

    '    'Try
    '    '    ObjClsWeldedCylinderFunctionalClass.MdiPictureBox.ImageLocation = Nothing
    '    '    File.Delete("c:\Test.bmp")
    '    'Catch ex As Exception

    '    'End Try
    '    Try
    '        Dim Extractor = Nothing
    '        Extractor = New SldWorks_ExtractBitmap.SldWorks_ExtractBitmap ' SW_EXTRACTBITMAPLib.SolidWorks_ExtractBitmap
    '        'Extractor = New SldWorks_ExtractBitmap.SldWorks_ExtractBitmap
    '        'Extractor = New SldWorks_ExtractBitmap.SldWorks_ExtractBitmapClass
    '        If File.Exists(strImagePath) Then
    '            Extractor.ExtractBitmap(strImagePath, "c:\Test.bmp", 300, 250)
    '            ObjClsWeldedCylinderFunctionalClass.MdiPictureBox.ImageLocation = "c:\Test.bmp"
    '        ElseIf strImagePath <> "" Then
    '            'MsgBox("File doesn't exist " & vbNewLine & strImagePath)
    '        Else
    '            ObjClsWeldedCylinderFunctionalClass.MdiPictureBox.ImageLocation = ""
    '        End If
    '    Catch ex As Exception
    '        'MsgBox("Error in displaying Part")
    '    End Try
    'End Sub
End Class
