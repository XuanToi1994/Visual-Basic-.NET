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

    Private _size As String
    Public Property Size() As String
        Get
            Return _size
        End Get
        Set(ByVal value As String)
            _size = value
            RaisePropertyChanged("Size")
        End Set
    End Property

    Private _path As String
    Public Property Path() As String
        Get
            Return _path
        End Get
        Set(ByVal value As String)
            _path = value
            RaisePropertyChanged("Path")
        End Set
    End Property

    Private _comment As String
    Public Property Comment() As String
        Get
            Return _comment
        End Get
        Set(ByVal value As String)
            _comment = value
            RaisePropertyChanged("Comment")
        End Set
    End Property

    Private _timeChange As String
    Public Property TimeChange() As String
        Get
            Return _timeChange
        End Get
        Set(ByVal value As String)
            _timeChange = value
            RaisePropertyChanged("TimeChange")
        End Set
    End Property
End Class
