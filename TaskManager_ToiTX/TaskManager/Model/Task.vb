Imports GalaSoft.MvvmLight
Public Class Task
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

    Private _content As String
    Public Property Content() As String
        Get
            Return _content
        End Get
        Set(ByVal value As String)
            _content = value
            RaisePropertyChanged("Content")
        End Set
    End Property

    Private _category As String
    Public Property Category() As String
        Get
            Return _category
        End Get
        Set(ByVal value As String)
            _category = value
            RaisePropertyChanged("Category")
        End Set
    End Property
End Class
