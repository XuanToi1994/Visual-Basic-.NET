Imports GalaSoft.MvvmLight
Imports GalaSoft.MvvmLight.Command
Imports System.Collections.ObjectModel
Imports System.Windows.Threading
Imports System.IO
Imports System.Threading


Public Class ExploreViewModel
    Inherits ViewModelBase

    Private Delegate Sub InsertDelegate(ByVal item As Explore)
#Region "Property"
    Private _color As String
    Public Property Color() As String
        Get
            Return _color
        End Get
        Set(ByVal value As String)
            _color = value
            RaisePropertyChanged("Color")
        End Set
    End Property
    Private _listExplore As ObservableCollection(Of Explore)
    Public Property ListExplore() As ObservableCollection(Of Explore)
        Get
            Return _listExplore
        End Get
        Set(ByVal value As ObservableCollection(Of Explore))
            _listExplore = value
            RaisePropertyChanged("ListExplore")
        End Set
    End Property

    Private _log As ObservableCollection(Of String)
    Public Property Log() As ObservableCollection(Of String)
        Get
            Return _log
        End Get
        Set(ByVal value As ObservableCollection(Of String))
            _log = value
        End Set
    End Property

#End Region

#Region "Contructer"
    Public Sub New()
        ListExplore = New ObservableCollection(Of Explore)
        Log = New ObservableCollection(Of String)
        Color = "Red"
        Dim watcher As FileSystemWatcher = New FileSystemWatcher()
        ' Path your folder 
        watcher.Path = "C:\Users\Administrator\Desktop\ToiTX"
        watcher.Filter = "*"
        watcher.NotifyFilter = NotifyFilters.LastWrite Or NotifyFilters.FileName
        AddHandler watcher.Created, New FileSystemEventHandler(AddressOf OnChanged)
        AddHandler watcher.Changed, New FileSystemEventHandler(AddressOf OnChanged)
        AddHandler watcher.Deleted, New FileSystemEventHandler(AddressOf OnChanged)
        AddHandler watcher.Renamed, New RenamedEventHandler(AddressOf OnChanged)
        watcher.EnableRaisingEvents = True

    End Sub

#End Region

#Region "ICommand"

#End Region

#Region "public function"

    Public Sub OnChanged(ByVal source As Object, ByVal e As FileSystemEventArgs)



        '  Creat
        If e.ChangeType = WatcherChangeTypes.Created Then
            AddItem(e, "Creat")
        End If
        ' Delete
        If e.ChangeType = WatcherChangeTypes.Deleted Then
            AddItem(e, "Delete")
        End If
        'Changed
        If e.ChangeType = 4 Then
            AddItem(e, "Changed")
        End If
        'Renamed
        If e.ChangeType = 8 Then
            AddItem(e, "Renamed")
        End If
        'All
        If e.ChangeType = 15 Then
            AddItem(e, "All")
        End If
    End Sub

#End Region

#Region "Private Function"
    Private Sub AddItem(e As FileSystemEventArgs, comment As String)
        Dim myFile As New FileInfo(e.FullPath)
        Dim strFileSize As String = "0"
        If e.ChangeType = 2 Then
            strFileSize = "No Size"
        Else
            strFileSize = (Math.Round(myFile.Length / 1024)).ToString()
        End If

        Dim _item As Explore = New Explore With {
            .Name = e.Name,
            .Path = e.FullPath,
            .Comment = comment,
            .Size = strFileSize,
            .TimeChange = DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss")}
        'System.Windows.Application.Current.Dispatcher.Invoke(New InsertDelegate(AddressOf InsertItem), _item)
        System.Windows.Application.Current.Dispatcher.Invoke(Sub()
                                                                 ListExplore.Add(_item)
                                                             End Sub)
    End Sub
    Private Sub InsertItem(item As Explore)
        ListExplore.Add(item)
        Dim lg = $"File {item.Name} had {item.Comment} at {item.TimeChange}"
        Log.Add(lg)
    End Sub
#End Region
End Class
