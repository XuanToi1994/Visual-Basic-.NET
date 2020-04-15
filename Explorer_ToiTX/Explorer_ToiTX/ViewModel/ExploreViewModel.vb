Imports GalaSoft.MvvmLight
Imports GalaSoft.MvvmLight.Command
Imports System.Collections.ObjectModel
Imports System.Windows.Threading
Imports System.IO


Public Class ExploreViewModel
    Inherits ViewModelBase

#Region "Property"
    Private _listFile As ObservableCollection(Of Explore)
    Public Property ListFile() As ObservableCollection(Of Explore)
        Get
            Return _listFile
        End Get
        Set(ByVal value As ObservableCollection(Of Explore))
            _listFile = value
            RaisePropertyChanged("ListFile")
        End Set
    End Property

    Private _selectedExplore As Explore
    Public Property SelectedExplore() As Explore
        Get
            Return _selectedExplore
        End Get
        Set(ByVal value As Explore)
            _selectedExplore = value
            RaisePropertyChanged("SelectedExplore")
        End Set
    End Property

#End Region

#Region "Contructor"
    Public Sub New()

        Dim path As String = "C:\Users\Administrator\Desktop"
        ListFile = GetListExplore(path)
        SelectedExplore = ListFile(0)

    End Sub
#End Region

#Region "ICommand"
    Private _selectedFoler As ICommand
    Public ReadOnly Property SelectedFoler() As ICommand
        Get
            If _selectedFoler Is Nothing Then
                _selectedFoler = New RelayCommand(Of Explore)(AddressOf SelectedFolderCmd)
            End If
            Return _selectedFoler
        End Get
    End Property

    Private _backBtnCmd As ICommand
    Public ReadOnly Property BackBtnCmd() As ICommand
        Get
            If _backBtnCmd Is Nothing Then
                _backBtnCmd = New RelayCommand(AddressOf OnBackCmd)
            End If
            Return _backBtnCmd
        End Get
    End Property
#End Region

#Region "private Function"

#End Region

#Region "Private Function"

#End Region

    Private Sub SelectedFolderCmd(ByVal explore As Explore)
        If explore.Type = Type.File Then
            MessageBox.Show("Can not Open this is File ")
        Else
            ListFile = GetListExplore(explore.PathFoler)

            If ListFile.Count = 0 Then

                Dim path = explore.PathFoler
                Dim split As String() = path.Split("\")
                Dim parentFolder As String = split(split.Length - 1)
                Dim pathBack = path.Remove(path.Length - parentFolder.Length - 1, parentFolder.Length + 1)
                ListFile = GetListExplore(pathBack)
                SelectedExplore = ListFile(0)
            Else
                SelectedExplore = ListFile(0)
            End If

        End If
    End Sub

    Private Sub OnBackCmd()
        Dim path = SelectedExplore.PathFoler
        Dim split As String() = path.Split("\")
        Dim parentFolder As String = split(split.Length - 1)
        Dim subParent As String = split(split.Length - 2)
        Dim pathBack = path.Remove(path.Length - parentFolder.Length - subParent.Length - 2, parentFolder.Length + subParent.Length + 2)

        ListFile = GetListExplore(pathBack)
        SelectedExplore = ListFile(0)

    End Sub

    Function GetListExplore(ByVal pathE As String) As ObservableCollection(Of Explore)
        Dim explore = New Explore
        Dim listExplore = New ObservableCollection(Of Explore)
        For Each Dir As String In Directory.GetDirectories(pathE)
            Dim foldePath As String = Dir
            Dim split As String() = foldePath.Split("\")
            Dim parentFolder As String = split(split.Length - 1)
            explore = New Explore
            explore.Name = parentFolder
            explore.Type = Type.Folder
            explore.PathFoler = foldePath
            explore.DateModified = Directory.GetLastWriteTime(foldePath)
            explore.Size = 0
            listExplore.Add(explore)
        Next

        'Với File 
        Dim strFileSize As String = ""
        Dim di As New IO.DirectoryInfo(pathE)
        Dim aryFi As IO.FileInfo() = di.GetFiles()
        Dim fi As IO.FileInfo
        For Each fi In aryFi
            strFileSize = (Math.Round(fi.Length / 1024)).ToString()
            explore = New Explore
            explore.Name = fi.Name
            explore.PathFoler = fi.FullName
            explore.Type = Type.File
            explore.DateModified = fi.LastAccessTime
            explore.Size = strFileSize
            listExplore.Add(explore)

        Next
        If listExplore.Count = 0 Then
            MessageBox.Show("This folder is empty")
        End If
        Return listExplore

    End Function

    Public Enum Type
        Folder
        File
    End Enum
End Class
