Imports GalaSoft.MvvmLight
Imports GalaSoft.MvvmLight.Command
Imports System.Collections.ObjectModel

Public Class TaskListViewModel
    Inherits ViewModelBase

#Region "Property"
    Private _listTask As ObservableCollection(Of Task)
    Public Property ListTask() As ObservableCollection(Of Task)
        Get
            Return _listTask
        End Get
        Set(ByVal value As ObservableCollection(Of Task))
            _listTask = value
            RaisePropertyChanged("ListTask")
        End Set
    End Property

    Private _selectedTask As Task
    Public Property SelectedTask() As Task
        Get
            Return _selectedTask
        End Get
        Set(ByVal value As Task)
            _selectedTask = value
            RaisePropertyChanged("SelectedTask")
        End Set
    End Property

    Private _addTaskVM As AddTaskViewModel
    Public Property AddTaskVM() As AddTaskViewModel
        Get
            Return _addTaskVM
        End Get
        Set(ByVal value As AddTaskViewModel)
            _addTaskVM = value
            RaisePropertyChanged("AddTaskVM")
        End Set
    End Property
#End Region

#Region "Icommand"
    Private _addCommand As ICommand
    Public ReadOnly Property AddCommand() As ICommand
        Get
            If _addCommand Is Nothing Then
                _addCommand = New RelayCommand(AddressOf OnAddCommand)
            End If
            Return _addCommand
        End Get

    End Property

    Private _editCmd As ICommand
    Public ReadOnly Property EditCmd() As ICommand
        Get
            If _editCmd Is Nothing Then
                _editCmd = New RelayCommand(AddressOf OnEditCommand)
            End If
            Return _editCmd
        End Get

    End Property
#End Region

#Region "Contructor"
    Public Sub New()
        ListTask = New ObservableCollection(Of Task)
        SelectedTask = New Task()
    End Sub
#End Region

#Region "Public function"

#End Region

#Region "Private function"
    Private Sub OnAddCommand()
        AddTaskVM = New AddTaskViewModel()
        Dim frm = New AddTaskView
        frm.Title = "Add New Task"
        frm.DataContext = AddTaskVM
        AddTaskVM.Task = New Task
        AddHandler AddTaskVM.SaveData, AddressOf addDataToTask
        frm.Show()
    End Sub

    Private Sub OnEditCommand()
        If SelectedTask.Name Is Nothing Then
            MessageBox.Show("Task is Empty ! Please Add New !")
            Return
        Else
            AddTaskVM = New AddTaskViewModel()
            Dim frm = New AddTaskView
            frm.Title = "Edit Task"
            frm.DataContext = AddTaskVM
            AddTaskVM.Task = SelectedTask
            AddHandler AddTaskVM.SaveData, AddressOf editDataToTask
            frm.Show()
        End If

    End Sub

    Private Sub addDataToTask(ByVal item As Task)
        ListTask.Add(item)
    End Sub

    Private Sub editDataToTask(ByVal item As Task)

        SelectedTask.Name = item.Name
        SelectedTask.Content = item.Content
        SelectedTask.Category = item.Category

    End Sub
#End Region
End Class
