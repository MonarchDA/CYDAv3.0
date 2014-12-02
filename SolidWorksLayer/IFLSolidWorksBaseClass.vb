Imports SldWorks
Imports System.IO
Imports System.Threading
'Imports SolidWorks.Interop.sldworks
'Imports SolidWorks.Interop.swconst
' ''Imports SolidWorks
'Imports SolidWorks.Interop


Public Class IFLSolidWorksBaseClass
    'Inherits IFLSolidWorksClass ' BBL.IFLSolidWorks
#Region "Variables"
    Public _htDocumentInstances As New Hashtable()     '27_07_2009  ragava
    Public blnVisibleSolidWorks As Boolean = True
    Private _strErrorMessage As String
    Private _oErrorObject As Exception
    'Private _oCurrentSolidWorksObject As Object        '04_03_2011   RAGAVA
    Private _oCurrentSolidWorksObject As SldWorks.SldWorks  '04_03_2011   RAGAVA
    Dim oSolidWorksApplication As SldWorks.SldWorks
    Dim oSolidWorksModel As SldWorks.ModelDoc2
    Dim oSolidWorksAssembly As SldWorks.AssemblyDoc
    Dim oSolidWorksPartDocument As SldWorks.PartDoc
    Dim oSolidWorksDrawingDocument As SldWorks.DrawingDoc
    Dim oSolidWorksView As SldWorks.View       '16_09_2009    ragava
    Dim nWarnings As Long
    Dim Errors As Long
    Dim boolStatus As Boolean

    Private swApp As SldWorks.SldWorks
 



    Public swModelExt As SldWorks.ModelDocExtension         '22_09_2009  ragava
    Public swOleObj As SldWorks.SwOLEObject                 '22_09_2009  ragava
#End Region



    Public Sub New(ByVal blnVisibleSolidworks As Boolean)


        blnVisibleSolidworks = blnVisibleSolidworks
        If SolidWorksApplicationObject() Is Nothing Then
            If Not ConnectSolidWorks() Then
                _strErrorMessage = "Unable to Connect To SolidWorks" + vbNewLine
                _strErrorMessage += "System Generated Error"
            End If

        End If
    End Sub

 
#Region "Properties[Dont Delete this line]"


    Public Property SolidWorksApplicationObject() As SldWorks.SldWorks
        Get
            Return oSolidWorksApplication
        End Get
        Set(ByVal value As SldWorks.SldWorks)

            oSolidWorksApplication = value


        End Set
    End Property

    Public Property SolidWorksModel() As SldWorks.ModelDoc2
        Get
            Return oSolidWorksModel
        End Get
        Set(ByVal value As SldWorks.ModelDoc2)
            oSolidWorksModel = value
        End Set
    End Property

    Public Property SolidWorksAssembly() As SldWorks.AssemblyDoc
        Get
            Return oSolidWorksAssembly
        End Get
        Set(ByVal value As SldWorks.AssemblyDoc)
            oSolidWorksAssembly = value
        End Set
    End Property

    Public Property SolidWorksPartDocument() As SldWorks.PartDoc
        Get
            Return oSolidWorksPartDocument
        End Get
        Set(ByVal value As SldWorks.PartDoc)
            oSolidWorksPartDocument = value
        End Set
    End Property

    Public Property SolidWorksDrawingDocument() As SldWorks.DrawingDoc
        Get
            Return oSolidWorksDrawingDocument
        End Get
        Set(ByVal value As SldWorks.DrawingDoc)
            oSolidWorksDrawingDocument = value
        End Set
    End Property
    '16_09_2009   ragava
    Public Property SolidWorksView() As SldWorks.View
        Get
            oSolidWorksView.BreakLineGap = 0.00254        '29_09_2009  ragava
            Return oSolidWorksView
        End Get
        Set(ByVal value As SldWorks.View)
            oSolidWorksView = value
            oSolidWorksView.BreakLineGap = 0.00254        '29_09_2009  ragava
        End Set
    End Property

    '24_09_2009  ragava
    Public ReadOnly Property selectOLE() As Boolean
        Get
            Dim bret As Boolean = False
            bret = SolidWorksModel.Extension.SelectByID2("Worksheet", "OLEITEM", 0.05817688726539, 0.2160797219023, 0, False, 0, Nothing, 0)
            If bret = False Then
                SolidWorksModel.Extension.SelectByID2("Worksheet", "OLEITEM", 0.07228921126611, 0.2439971402624, 0, False, 0, Nothing, 0)
            End If
        End Get
    End Property
#End Region
#Region "Enums"
    Public Enum SolidworksDocumentType
        PartDocument = 1
        AssemblyDocument = 2
        DrawingDocument = 3
        None = 4
    End Enum
    'vamsi 15-11-2013
    
#End Region
#Region "SolidWorks Connection "
    ''' <summary>
    ''' Opens the solidworks Session.
    ''' </summary>
    ''' <remarks></remarks>
    Public Function ConnectSolidWorks() As Boolean
        ConnectSolidWorks = False
        Try
            SolidWorksApplicationObject = CreateObject("SldWorks.Application")
            If Not SolidWorksApplicationObject Is Nothing Then

                SolidWorksApplicationObject.Visible = True
                _oCurrentSolidWorksObject = SolidWorksApplicationObject

                ConnectSolidWorks = True

            End If
        Catch oException As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("UNABLE TO OPEN THE SOLIDWORKS!! .System Generated Error: " + oException.Message)
            '_strErrorMessage = "UNABLE TO OPEN THE SOLIDWORKS!!" + vbCrLf
            '_strErrorMessage += "System generated error:-" + vbCrLf + oException.Message
            '_oErrorObject = oException
        End Try
    End Function
    
    ''' <summary>
    ''' </summary>
    ''' <remarks></remarks>
    Public Function SaveAndCloseAllDocuments() As Boolean
        Try
            SolidWorksModel = SolidWorksApplicationObject.ActiveDoc
            'If SolidWorksModel.GetPathName.ToString.IndexOf(".slddrw") <> -1 OrElse SolidWorksModel.GetPathName.ToString.IndexOf(".SLDDRW") <> -1 Then
            '    SolidWorksModel.SaveAs2(SolidWorksModel.GetPathName, 3, True, True)      '01_02_2011   RAGAVA
            'End If
            SolidWorksModel.SaveSilent()
            SolidWorksModel.Quit()
            SolidWorksApplicationObject.CloseAllDocuments(False)
            'SolidWorksModel = SolidWorksApplicationObject.ActiveDoc
            'If _htDocumentInstances.Count > 0 Then
            '    For Each strFile As String In _htDocumentInstances.Keys
            '        SaveAndCloseAllDocuments = SaveAndCloseDocument(strFile)
            '    Next
            '    _htDocumentInstances.Clear()
            'End If
        Catch oException As Exception

            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Unable to close Documents Some files are not saved Properly .System Generated Error: " + oException.Message)
            'vamsi nov 14th comment
            '_strErrorMessage = "Unable to Close Documents!" + vbNewLine
            '_strErrorMessage += "Some files are not saved properly" + vbNewLine
            '_strErrorMessage += "System generated error:-" + vbNewLine + oException.Message
            '_oErrorObject = oException
        End Try
    End Function

    '29_03_2010  ragava
    Public Sub checkProperty(ByVal propertyName As String, ByVal value As Object)
        Try
            SolidWorksModel = SolidWorksApplicationObject.ActiveDoc
            SolidWorksModel.DeleteCustomInfo(propertyName)
            SolidWorksModel.AddCustomInfo(propertyName, "Text", value)

        Catch ex As Exception
        End Try
    End Sub

    Public Function CloseAllDocuments() As Boolean
        Try
            SolidWorksApplicationObject.CloseAllDocuments(False)
            'SolidWorksModel = SolidWorksApplicationObject.ActiveDoc
            'If _htDocumentInstances.Count > 0 Then
            '    For Each strFile As String In _htDocumentInstances.Keys
            'CloseAllDocuments = CloseDocument(strFile)
            '    Next
            '_htDocumentInstances.Clear()
            'End If
        Catch oException As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Unable to close Documents Some files are not saved Properly .System Generated Error: " + oException.Message)
            'vamsi 14th nov 13
            '_strErrorMessage = "Unable to Close Documents!" + vbNewLine
            '_strErrorMessage += "Some files are not saved properly" + vbNewLine
            '_strErrorMessage += "System generated error:-" + vbNewLine + oException.Message
            '_oErrorObject = oException
        End Try
    End Function
    ''' <summary>
    ''' Closes the specified document.
    ''' </summary>
    ''' <param name="docName"></param>
    ''' <remarks></remarks>
    Public Function SaveAndCloseDocument(ByVal docName As String) As Boolean
        Try
            'If _htDocumentInstances.ContainsKey(docName) = True Then
            'SaveDocument(_htDocumentInstances(docName))
            SolidWorksModel = SolidWorksApplicationObject.ActivateDoc(docName)


            'If SolidWorksModel.GetPathName.ToString.IndexOf(".slddrw") <> -1 OrElse SolidWorksModel.GetPathName.ToString.IndexOf(".SLDDRW") <> -1 Then
            '    SolidWorksApplicationObject.IActiveDoc.SaveAs2(SolidWorksModel.GetPathName, 3, True, True)      '01_02_2011   RAGAVA
            'End If
            SolidWorksApplicationObject.IActiveDoc.SaveSilent()
            'SolidWorksModel.SaveSilent()
            SolidWorksApplicationObject.Close()
            SaveAndCloseDocument = CloseDocument(docName)
            'End If
        Catch oException As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Unable to close Documents Some files are not saved Properly .System Generated Error: " + oException.Message)
            'vamsi 14th nov 13
            '_strErrorMessage = "Unable to Close Document!" + vbNewLine
            '_strErrorMessage += "file is not saved properly" + vbNewLine
            '_strErrorMessage += "or file is not updated properly" + vbNewLine
            '_strErrorMessage += "System generated error:-" + vbNewLine + oException.Message
            '_oErrorObject = oException
        End Try
    End Function
    Public Function CloseDocument(ByVal _strDocName As String) As Boolean
        Try
            'If _htDocumentInstances.ContainsKey(_strDocName) = True Then

            SolidWorksApplicationObject.CloseDoc(_strDocName)
            CloseDocument = True
            '27_07_2009  ragava Below
            'If _htDocumentInstances.ContainsKey(_strDocName) = True Then
            '    _htDocumentInstances.Remove(_strDocName)
            'End If
            'End If
        Catch oException As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Unable to close Documents Some files are not saved Properly .System Generated Error: " + oException.Message)

            '_strErrorMessage = "Unable to Close Document!" + vbNewLine
            '_strErrorMessage += "file is not saved properly" + vbNewLine
            '_strErrorMessage += "or file is not updated properly" + vbNewLine
            '_strErrorMessage += "System generated error:-" + vbNewLine + oException.Message
            '_oErrorObject = oException
        End Try
    End Function
    ''' <summary>
    ''' Opens the document.
    ''' </summary>
    ''' <param name="_strDocName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function openDocument(ByVal _strDocName As String) As Boolean
        Dim oSwModel As SldWorks.ModelDoc2
        'Dim fileData As FileInfo = My.Computer.FileSystem.GetFileInfo(docName)
        Dim lnDoc As Long = CheckFileType(_strDocName)
        openDocument = False
        '27_07_2009  ragava Below
        'If _htDocumentInstances.ContainsKey(_strDocName) = True Then
        '    SolidWorksModel = _htDocumentInstances(_strDocName)
        '    openDocument = True
        'Else
        Try
            Dim blnRet As Boolean = False
            '04_03_2011    RAGAVA
            SolidWorksApplicationObject.CommandInProgress = False
            CheckCommandInProgress()         '04_03_2011   RAGAVA
            'Till  Here
            blnRet = SolidWorksApplicationObject.SetCurrentWorkingDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath)
            'SolidWorksApplicationObject.UserControl = False
            SolidWorksApplicationObject.Visible = True
            'pFrame = SolidWorksApplicationObject.Frame()
            'pFrame.KeepInvisible = True
            SolidWorksModel = SolidWorksApplicationObject.OpenDoc6(_strDocName, lnDoc, SwConst.swOpenDocOptions_e.swOpenDocOptions_Silent, "", 0, 0) 'VAMSI CHANGED ERRORS AND nWARNING TO 0 0

            ' SolidWorksModel = SolidWorksApplicationObject.OpenDoc6(_strDocName, lnDoc, SwConst.swOpenDocOptions_e.swOpenDocOptions_Silent, "", Errors, nWarnings)
            ' MessageBox.Show(Errors, nWarnings)
            oSwModel = SolidWorksModel
            '_htDocumentInstances.Add(_strDocName, oSwModel)
            openDocument = True

        Catch oException As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Unable to open Documents check file format .System Generated Error: " + oException.Message)
            '_strErrorMessage = "Unable to open file" + vbNewLine
            '_strErrorMessage += "Check file format" + vbNewLine
            '_strErrorMessage += "System generated error" + oException.Message
            '_oErrorObject = oException
            openDocument = False
        End Try
        'End If
    End Function
    '04_03_2011     RAGAVA
    Public Sub CheckCommandInProgress()
        Try

            If SolidWorksApplicationObject.CommandInProgress = True Then
                Dim iCount As Integer = 0
                While (iCount < 10)
                    SolidWorksApplicationObject.CommandInProgress = False      '03_03_2011    RAGAVA
                    If SolidWorksApplicationObject.CommandInProgress = False Then
                        Exit Try
                    End If
                    iCount = iCount + 1
                End While
                SetCommandInProgress()
            End If
        Catch ex As Exception
        End Try
    End Sub

    '04_03_2011    RAGAVA
    Public Sub SetCommandInProgress()
        Try

            KillAllSolidWorksServices()
            SolidWorksApplicationObject = Nothing
            ObjClsWeldedCylinderFunctionalClass.CloseExcel()
            ConnectSolidWorks()
            SolidWorksApplicationObject.CommandInProgress = False
        Catch ex As Exception

        End Try
    End Sub

    Public Function openAssemblyDrawingDocument(ByVal _strDocName As String) As Boolean
        Dim oSwModel As SldWorks.ModelDoc2
        Dim lnDoc As Long = CheckFileType(_strDocName)
        openAssemblyDrawingDocument = False
        Try
            '04_03_2011    RAGAVA
            SolidWorksApplicationObject.CommandInProgress = False
            CheckCommandInProgress()
            'Till  Here
            'SolidWorksModel = SolidWorksApplicationObject.OpenDoc6(_strDocName, 3, SwConst.swOpenDocOptions_e.swOpenDocOptions_LoadModel, "", Errors, nWarnings)'vamsi 14-11-2013
            SolidWorksModel = SolidWorksApplicationObject.OpenDoc6(_strDocName, 3, SwConst.swOpenDocOptions_e.swOpenDocOptions_LoadModel, "", 0, 0)
            oSwModel = SolidWorksModel
            openAssemblyDrawingDocument = True

        Catch oException As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Unable to open Documents check file format .System Generated Error: " + oException.Message)
            '_strErrorMessage = "Unable to open file" + vbNewLine
            '_strErrorMessage += "Check file format" + vbNewLine
            '_strErrorMessage += "System generated error" + oException.Message
            '_oErrorObject = oException
            openAssemblyDrawingDocument = False
        End Try
        'End If
    End Function

    ''' <summary>
    ''' Checks the type of the documet[i.e , part or assembly or drawing]
    ''' </summary>
    ''' <param name="_strPartAssemblyFileName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckFileType(ByVal _strPartAssemblyFileName As String) As Long
        Try
            Dim fileData As FileInfo = My.Computer.FileSystem.GetFileInfo(_strPartAssemblyFileName)
            If fileData.Extension = ".SLDASM" Then
                CheckFileType = SwConst.swDocumentTypes_e.swDocASSEMBLY
            ElseIf fileData.Extension = ".SLDPRT" Then
                CheckFileType = SwConst.swDocumentTypes_e.swDocPART
            ElseIf fileData.Extension = ".SLDDRW" Then
                CheckFileType = SwConst.swDocumentTypes_e.swDocDRAWING
            Else
                CheckFileType = SwConst.swDocumentTypes_e.swDocNONE
            End If
            Return CheckFileType
        Catch oException As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Access Denied . " + vbNewLine + "File Name:" + _strPartAssemblyFileName + vbNewLine + "System Generated Error:" + oException.Message)
            '_strErrorMessage = "Access Denied" + vbNewLine
            '_strErrorMessage += "File Name:" + _strPartAssemblyFileName + vbNewLine
            '_strErrorMessage += "System Generated Error:" + oException.Message
            '_oErrorObject = oException
        End Try
    End Function
    ''' <summary>
    ''' SolidWorks session process will be killed in case of unhandled exception case.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub killSolidWorks(ByVal _strProcessName As String)
        Dim proc As System.Diagnostics.Process
        Try
            For Each proc In System.Diagnostics.Process.GetProcessesByName(_strProcessName)
                If proc.HasExited = False Then
                    proc.Kill()
                End If
            Next
        Catch oException As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Unable to kill the Service .System Generated Error: " + oException.Message)
            '_strErrorMessage = "Unable to kill the Service" + vbNewLine
            '_strErrorMessage += "System Generated Error" + oException.Message
            '_oErrorObject = oException
        End Try
    End Sub
    Public Sub KillAllSolidWorksServices()
        killSolidWorks("SLDWORKS")
        killSolidWorks("SolidWorksLicTemp.0001")
        killSolidWorks("SolidWorksLicensing")
        killSolidWorks("swvbaserver")
    End Sub

    Private Function SaveDocument(ByVal oSolidWorksModel As SldWorks.ModelDoc2) As Boolean
        Try
            'If oSolidWorksModel.GetPathName.ToString.IndexOf(".slddrw") <> -1 OrElse oSolidWorksModel.GetPathName.ToString.IndexOf(".SLDDRW") <> -1 Then
            '    SaveDocument = oSolidWorksModel.SaveAs2(oSolidWorksModel.GetPathName, 3, True, True)      '01_02_2011   RAGAVA
            'End If

            SaveDocument = oSolidWorksModel.SaveSilent()
        Catch oException As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Unable to kill the Service .System Generated Error: " + oException.Message)
            '_strErrorMessage = "Unable to kill the Service" + vbNewLine
            '_strErrorMessage += "System Generated Error" + oException.Message
            '_oErrorObject = oException
        End Try
    End Function
    Public Function SaveDocument(ByVal _strDocName As String) As Boolean
        Try
            'If _htDocumentInstances.ContainsKey(_strDocName) = True Then
            '    SaveDocument = SaveDocument(_htDocumentInstances(_strDocName))
            'End If
            'If oSolidWorksModel.GetPathName.ToString.IndexOf(".slddrw") <> -1 OrElse oSolidWorksModel.GetPathName.ToString.IndexOf(".SLDDRW") <> -1 Then
            '    SaveDocument = oSolidWorksModel.SaveAs2(oSolidWorksModel.GetPathName, 3, True, True)      '01_02_2011   RAGAVA
            'End If

            SaveDocument = oSolidWorksModel.SaveSilent()
        Catch oException As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Unable to kill the Service .System Generated Error: " + oException.Message)
            '_strErrorMessage = "Unable to kill the Service" + vbNewLine
            '_strErrorMessage += "System Generated Error" + oException.Message
            '_oErrorObject = oException
        End Try
    End Function
    '27_07_2009  ragava
    'Public Function Save() As Boolean
    '    Save = False
    '    Try
    '        Save = SolidWorksApplicationObject.IActiveDoc2.SaveSilent()
    '    Catch oException As Exception
    '        _strErrorMessage = "UNABLE TO SAVE THE PART OR ASSEMBLY !!" + vbCrLf
    '        _strErrorMessage += "System generated error:-" + vbCrLf + oException.Message
    '        _oErrorObject = oException
    '    End Try
    'End Function

    Public Function deleteFile(ByVal strfilename As String) As Boolean
        deleteFile = False
        Try

            deleteFile = SolidWorksModel.Extension.SelectByID2(strfilename, "COMPONENT", 0, 0, 0, True, 0, Nothing, 0)
            Return deleteFile = SolidWorksModel.DeleteSelection(False)
        Catch oException As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Unable to perform delete operation.System Generated Error: " + oException.Message)
            '_strErrorMessage = "Unable to perform Delete Operation" + vbNewLine
            '_strErrorMessage += "System Generated Error:" + vbNewLine + oException.Message
            '_oErrorObject = oException
        End Try
    End Function
    Public Function ActivateDocument(ByVal fileName As String) As Boolean
        ActivateDocument = False
        Try
            SolidWorksApplicationObject.Visible = True  '12-11-2013
            SolidWorksApplicationObject.ActivateDoc2(fileName, True, 0)

        Catch oException As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Unable to activate the Document.System Generated Error: " + oException.Message)
            '_strErrorMessage = "Unable to Activate the Document" + vbNewLine
            '_strErrorMessage += "System generated Error" + vbNewLine + oException.Message
            '_oErrorObject = oException
        End Try
    End Function

  
#End Region
End Class
