Imports IFLBaseDataLayer
Imports IFLCommonLayer
Module modWeldedCylinder

#Region "Variables"

    Private _oClsWeldedCylinderFunctionalClass As clsWeldedCylinderFunctionalClass

    Private _oMonarchConnectionObject As IFLConnectionClass

#End Region

#Region "Properties"

    Public Property ObjClsWeldedCylinderFunctionalClass() As clsWeldedCylinderFunctionalClass
        Get
            Return _oClsWeldedCylinderFunctionalClass
        End Get
        Set(ByVal value As clsWeldedCylinderFunctionalClass)
            _oClsWeldedCylinderFunctionalClass = value
        End Set
    End Property

    Public Property MonarchConnectionObject() As IFLConnectionClass
        Get
            Return _oMonarchConnectionObject
        End Get
        Set(ByVal value As IFLConnectionClass)
            _oMonarchConnectionObject = value
        End Set
    End Property

#End Region

End Module
