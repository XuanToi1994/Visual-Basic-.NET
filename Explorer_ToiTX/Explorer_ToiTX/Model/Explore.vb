Imports GalaSoft.MvvmLight

Public Class Explore
    Inherits ViewModelBase

    Private _name As String
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
            RaisePropertyChanged("Name")
        End Set
    End Property

    Private _dateModified As DateTime
    Public Property DateModified() As DateTime
        Get
            Return _dateModified
        End Get
        Set(ByVal value As DateTime)
            _dateModified = value
            RaisePropertyChanged("DateModified")
        End Set
    End Property
    Private _pathFoler As String
    Public Property PathFoler() As String
        Get
            Return _pathFoler
        End Get
        Set(ByVal value As String)
            _pathFoler = value
            RaisePropertyChanged("PathFoler")
        End Set
    End Property

    Private _type As TypeEnum
    Public Property Type() As TypeEnum
        Get
            Return _type
        End Get
        Set(ByVal value As TypeEnum)
            _type = value
            RaisePropertyChanged("Type")
        End Set
    End Property

    Private _size As Int64
    Public Property Size() As Int64
        Get
            Return _size
        End Get
        Set(ByVal value As Int64)
            _size = value
            RaisePropertyChanged("Size")
        End Set
    End Property

    Public Enum TypeEnum
        Folder
        File
    End Enum
End Class
