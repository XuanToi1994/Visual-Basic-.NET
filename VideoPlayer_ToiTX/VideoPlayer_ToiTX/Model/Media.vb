Imports GalaSoft.MvvmLight

Public Class Media
    Inherits ViewModelBase

    Private _nameVideo As String
    Public Property NameVideo() As String
        Get
            Return _nameVideo
        End Get
        Set(ByVal value As String)
            _nameVideo = value
            RaisePropertyChanged("NameVideo")
        End Set

    End Property

    Private _pathFile As String
    Public Property PathFile() As String
        Get
            Return _pathFile
        End Get
        Set(ByVal value As String)
            _pathFile = value
            RaisePropertyChanged("PathFile")
        End Set
    End Property

    Private _singer As String
    Public Property Singer() As String
        Get
            Return _singer
        End Get
        Set(ByVal value As String)
            _singer = value
            RaisePropertyChanged("Singer")
        End Set
    End Property

    Private _pathImage As String
    Public Property PathImage() As String
        Get
            Return _pathImage
        End Get
        Set(ByVal value As String)
            _pathImage = value
            RaisePropertyChanged("PathImage")
        End Set
    End Property


End Class
