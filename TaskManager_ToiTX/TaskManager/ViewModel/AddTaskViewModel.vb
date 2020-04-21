Imports GalaSoft.MvvmLight
Imports GalaSoft.MvvmLight.Command
Imports System.Collections.ObjectModel


Public Class AddTaskViewModel
    Inherits ViewModelBase

#Region "Property"
    Public Delegate Sub AddNewTask(ByVal task As Task)
    Public Event SaveData As AddNewTask


    Private _selectedTask As Task
    Public Property SelectedTask() As Task
        Get
            Return _selectedTask
        End Get
        Set(ByVal value As Task)
            _selectedTask = value
            RaisePropertyChanged("SelectedTask")
            If SelectedTask IsNot Nothing Then
                Task = New Task With {
                .Name = SelectedTask.Name,
                .Content = SelectedTask.Content,
                .Category = SelectedTask.Category
                }
            End If
        End Set
    End Property

    Private _task As Task
    Public Property Task() As Task
        Get
            Return _task
        End Get
        Set(ByVal value As Task)
            _task = value
            RaisePropertyChanged("Task")
        End Set
    End Property


#End Region

#Region "ICommand"
    Private _saveCmd As ICommand
    Public ReadOnly Property SaveCmd() As ICommand
        Get
            If _saveCmd Is Nothing Then
                _saveCmd = New RelayCommand(AddressOf OnSaveCmd)
            End If
            Return _saveCmd
        End Get

    End Property

#Region "Contructor"
    Public Sub New()
        Task = New Task()

    End Sub
#End Region

#End Region

#Region "Public Funtion"

#End Region

#Region "Private function"
    Private Sub OnSaveCmd()
        Dim item = New Task With {
            .Name = Task.Name,
            .Content = Task.Content,
            .Category = Task.Category
            }
        RaiseEvent SaveData(item)


    End Sub
#End Region



End Class
