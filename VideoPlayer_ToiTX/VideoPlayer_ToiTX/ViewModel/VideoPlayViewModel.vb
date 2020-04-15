Imports GalaSoft.MvvmLight
Imports GalaSoft.MvvmLight.Command
Imports System.Collections.ObjectModel
Imports System.Windows.Threading

Public Class VideoPlayViewModel
    Inherits ViewModelBase

#Region "Property"

    Private Timer As DispatcherTimer

    Private _imagePath As String
    Public Property ImagePath() As String
        Get
            Return _imagePath
        End Get
        Set(ByVal value As String)
            _imagePath = value
            RaisePropertyChanged("ImagePath")
        End Set
    End Property
    Private _isSuffule As Boolean
    Public Property IsSuffule() As Boolean
        Get
            Return _isSuffule
        End Get
        Set(ByVal value As Boolean)
            _isSuffule = value
            RaisePropertyChanged("IsSuffule")
        End Set
    End Property
    Private _isRepeatOne As Boolean
    Public Property IsRepeatOne() As Boolean
        Get
            Return _isRepeatOne
        End Get
        Set(ByVal value As Boolean)
            _isRepeatOne = value
            RaisePropertyChanged("IsRepeatOne")
        End Set
    End Property

    Private _selectedVideo As Media
    Public Property SelectedVideo() As Media
        Get
            Return _selectedVideo
        End Get
        Set(ByVal value As Media)
            _selectedVideo = value
            RaisePropertyChanged("SelectedVideo")
        End Set
    End Property

    Private _isPlayIng As Boolean
    Public Property IsPlaying() As Boolean
        Get
            Return _isPlayIng
        End Get
        Set(ByVal value As Boolean)
            _isPlayIng = value
            RaisePropertyChanged("IsPlaying")
        End Set
    End Property
    Private _maxValue As Int64
    Public Property MaxValue() As Int64
        Get
            Return _maxValue
        End Get
        Set(ByVal value As Int64)
            _maxValue = value
            RaisePropertyChanged("MaxValue")
        End Set
    End Property

    Private _valueTime As Int64
    Public Property ValueTime() As Int64
        Get
            Return _valueTime
        End Get
        Set(ByVal value As Int64)
            _valueTime = value
            RaisePropertyChanged("ValueTime")
        End Set
    End Property
    Private _videoName As String
    Public Property VideoName() As String
        Get
            Return _videoName
        End Get
        Set(ByVal value As String)
            _videoName = value
            RaisePropertyChanged("VideoName")
        End Set
    End Property
    Private _nameSinger As String
    Public Property NameSinger() As String
        Get
            Return _nameSinger
        End Get
        Set(ByVal value As String)
            _nameSinger = value
            RaisePropertyChanged("NameSinger")
        End Set
    End Property

    Private _totalTime As String
    Public Property TotalTime() As String
        Get
            Return _totalTime
        End Get
        Set(ByVal value As String)
            _totalTime = value
            RaisePropertyChanged("TotalTime")
        End Set
    End Property

    Private _currentTime As String
    Public Property CurrentTime() As String
        Get
            Return _currentTime
        End Get
        Set(ByVal value As String)
            _currentTime = value
            RaisePropertyChanged("CurrentTime")
        End Set
    End Property

    Private _index As Int64
    Public Property Index() As Int64
        Get
            Return _index
        End Get
        Set(ByVal value As Int64)
            _index = value
            RaisePropertyChanged("Index")
        End Set
    End Property

    Private _listMedia As ObservableCollection(Of Media)
    Public Property ListMedia() As ObservableCollection(Of Media)
        Get
            Return _listMedia
        End Get
        Set(ByVal value As ObservableCollection(Of Media))
            _listMedia = value
            RaisePropertyChanged("ListMedia")
        End Set
    End Property


    Private _pathFileVideo As String
    Public Property PathFileVideo() As String
        Get
            Return _pathFileVideo
        End Get
        Set(ByVal value As String)
            _pathFileVideo = value
            RaisePropertyChanged("PathFileVideo")
        End Set
    End Property

    Private _myVideo As MediaElement
    Public Property MyVideo() As MediaElement
        Get
            Return _myVideo
        End Get
        Set(ByVal value As MediaElement)
            _myVideo = value
            RaisePropertyChanged("MyVideo")
        End Set
    End Property


#End Region

#Region "ICommand"


    Private _selectedMedia As ICommand
    Public ReadOnly Property SelectedMedia() As ICommand
        Get
            If _selectedMedia Is Nothing Then
                _selectedMedia = New RelayCommand(Of Media)(AddressOf SelectedMediaCommand)
            End If
            Return _selectedMedia
        End Get

    End Property


    Private _suffleCmd As ICommand
    Public ReadOnly Property SuffleCmd() As ICommand
        Get
            If _suffleCmd Is Nothing Then
                _suffleCmd = New RelayCommand(AddressOf OnSuffleCmd)
            End If
            Return _suffleCmd
        End Get

    End Property

    Private _reapetCmd As ICommand
    Public ReadOnly Property ReapetCmd() As ICommand
        Get
            If _reapetCmd Is Nothing Then
                _reapetCmd = New RelayCommand(AddressOf OnReaptOneCmd)
            End If
            Return _reapetCmd
        End Get

    End Property
    Private _playCmd As ICommand
    Public ReadOnly Property PlayCmd() As ICommand
        Get
            If _playCmd Is Nothing Then
                _playCmd = New RelayCommand(AddressOf OnPlayCmd)
            End If
            Return _playCmd
        End Get
    End Property

    Private _nextCmd As ICommand
    Public ReadOnly Property NextCmd() As ICommand
        Get
            If _nextCmd Is Nothing Then
                _nextCmd = New RelayCommand(AddressOf onNextCmd)
            End If
            Return _nextCmd
        End Get
    End Property

    Private _preCmd As ICommand
    Public ReadOnly Property PreCmd() As ICommand
        Get
            If _preCmd Is Nothing Then
                _preCmd = New RelayCommand(AddressOf OnPreCmd)
            End If
            Return _preCmd
        End Get

    End Property


#End Region

#Region "Contructor"
    Public Sub New()
        Dim video = New Media
        Dim lstVideo = New ObservableCollection(Of Media)
        ' Add path file videos and images 
        video.NameVideo = "Intro headPhone "
        video.PathFile = "C:\Users\Administrator\Desktop\VideoPlayer_ToiTX\VideoPlayer_ToiTX\videos\VIDEO0000.mp4"
        video.Singer = "China Techonoly"
        video.PathImage = "C:\Users\Administrator\Desktop\VideoPlayer_ToiTX\VideoPlayer_ToiTX\images\cho.jpg"
        lstVideo.Add(video)

        video = New Media
        video.NameVideo = "Kẻ cắp gặp bà già"
        video.PathFile = "C:\Users\Administrator\Desktop\VideoPlayer_ToiTX\VideoPlayer_ToiTX\videos\Next.mp4"
        video.Singer = "Hoàng Thùy Linh"
        video.PathImage = "C:\Users\Administrator\Desktop\VideoPlayer_ToiTX\VideoPlayer_ToiTX\images\dog.jpg"
        lstVideo.Add(video)

        video = New Media
        video.NameVideo = "Intro Sky"
        video.PathFile = "C:\Users\Administrator\Desktop\VideoPlayer_ToiTX\VideoPlayer_ToiTX\videos\Video00001.mp4"
        video.Singer = "Intro Video "
        video.PathImage = "C:\Users\Administrator\Desktop\VideoPlayer_ToiTX\VideoPlayer_ToiTX\images\music1.png"
        lstVideo.Add(video)

        video = New Media
        video.NameVideo = "Đừng chờ anh nữa "
        video.PathFile = "C:\Users\Administrator\Desktop\VideoPlayer_ToiTX\VideoPlayer_ToiTX\videos\DungChoAnhNua.mp4"
        video.Singer = "Tăng Phúc"
        video.PathImage = "C:\Users\Administrator\Desktop\VideoPlayer_ToiTX\VideoPlayer_ToiTX\images\music0.png"
        lstVideo.Add(video)

        video = New Media
        video.NameVideo = " Alan Walker - Alone"
        video.PathFile = "C:\Users\Administrator\Desktop\VideoPlayer_ToiTX\VideoPlayer_ToiTX\videos\Alan Walker - Alone.mp4"
        video.Singer = " Alan Walker"
        video.PathImage = "C:\Users\Administrator\Desktop\VideoPlayer_ToiTX\VideoPlayer_ToiTX\images\alan.jpg"
        lstVideo.Add(video)

        video = New Media
        video.NameVideo = "Sing Me To Sleep.mp4"
        video.PathFile = "C:\Users\Administrator\Desktop\VideoPlayer_ToiTX\VideoPlayer_ToiTX\videos\Alan Walker - Sing Me To Sleep.mp4"
        video.Singer = " Alan Walker"
        video.PathImage = "C:\Users\Administrator\Desktop\VideoPlayer_ToiTX\VideoPlayer_ToiTX\images\singme.jpg"
        lstVideo.Add(video)

        video = New Media
        video.NameVideo = "Chiếc lá mùa đông"
        video.PathFile = "C:\Users\Administrator\Desktop\VideoPlayer_ToiTX\VideoPlayer_ToiTX\videos\ChiecLaMuaDong.mp4"
        video.Singer = "Thu Phương "
        video.PathImage = "C:\Users\Administrator\Desktop\VideoPlayer_ToiTX\VideoPlayer_ToiTX\images\music.png"
        lstVideo.Add(video)

        video = New Media
        video.NameVideo = "Don't Let Me Down"
        video.PathFile = "C:\Users\Administrator\Desktop\VideoPlayer_ToiTX\VideoPlayer_ToiTX\videos\Don't Let Me Down -- Wanda Maximoff.mp4"
        video.Singer = "Wanda Maximoff"
        video.PathImage = "C:\Users\Administrator\Desktop\VideoPlayer_ToiTX\VideoPlayer_ToiTX\images\music1.png"
        lstVideo.Add(video)

        video = New Media
        video.NameVideo = "Legends Never Die"
        video.PathFile = "C:\Users\Administrator\Desktop\VideoPlayer_ToiTX\VideoPlayer_ToiTX\videos\Legends Never Die - Avengers- Endgame.mp4"
        video.Singer = "Avengers- Endgame"
        video.PathImage = "C:\Users\Administrator\Desktop\VideoPlayer_ToiTX\VideoPlayer_ToiTX\images\cho.jpg"
        lstVideo.Add(video)

        video = New Media
        video.NameVideo = "Two Steps From Hell"
        video.PathFile = "C:\Users\Administrator\Desktop\VideoPlayer_ToiTX\VideoPlayer_ToiTX\videos\Two Steps From Hell.mp4"
        video.Singer = "No name"
        video.PathImage = "C:\Users\Administrator\Desktop\VideoPlayer_ToiTX\VideoPlayer_ToiTX\images\music0.png"
        lstVideo.Add(video)

        ListMedia = lstVideo
        Index = 0
        PathFileVideo = ListMedia(Index).PathFile
        NameSinger = ListMedia(Index).Singer
        VideoName = ListMedia(Index).NameVideo
        ImagePath = ListMedia(Index).PathImage
        MaxValue = 0
        ValueTime = 0
        IsPlaying = False
        SelectedVideo = ListMedia(Index)

        Timer = New DispatcherTimer()
        Timer.Interval = TimeSpan.FromMilliseconds(0.001)
        AddHandler Timer.Tick, AddressOf TimeTicker
        CurrentTime = "00:00:00"
        TotalTime = "00:00:00"
        IsRepeatOne = False
        IsSuffule = False

    End Sub
#End Region

#Region "Public function"

#End Region

#Region "Private function"

    Private Sub TimeTicker(ByVal sender As Object, ByVal e As EventArgs)
        If MyVideo.NaturalDuration.HasTimeSpan Then
            CurrentTime = New TimeSpan().FromSeconds(MyVideo.Position.TotalSeconds).ToString("hh\:mm\:ss")
            TotalTime = MyVideo.NaturalDuration.TimeSpan.ToString("hh\:mm\:ss")
            MaxValue = MyVideo.NaturalDuration.TimeSpan.TotalSeconds
            ValueTime = MyVideo.Position.TotalSeconds
            Timer.Start()

            If ValueTime = MaxValue Then

                If IsSuffule Then
                    Dim Rand As New Random()
                    Index = Rand.Next(0, ListMedia.Count - 1)
                    SelectedVideo = ListMedia(Index)
                    PathFileVideo = ListMedia(Index).PathFile
                    VideoName = ListMedia(Index).NameVideo
                    NameSinger = ListMedia(Index).Singer
                    ImagePath = ListMedia(Index).PathImage
                End If
                If IsRepeatOne Then
                    Index = Index
                    SelectedVideo = ListMedia(Index)
                    PathFileVideo = ListMedia(Index).PathFile
                Else
                    If Index = (ListMedia.Count - 1) Then
                        MessageBox.Show("Done ! Stop ")
                        MyVideo.Stop()
                        IsPlaying = False
                        Timer.Stop()
                        Return
                    Else
                        Index = Index + 1
                        SelectedVideo = ListMedia(Index)
                        PathFileVideo = ListMedia(Index).PathFile
                        VideoName = ListMedia(Index).NameVideo
                        NameSinger = ListMedia(Index).Singer
                        ImagePath = ListMedia(Index).PathImage
                    End If
                End If
            End If

        End If
    End Sub
    Private Sub OnPlayCmd()
        If IsPlaying Then
            MyVideo.Pause()
            Timer.Start()
            IsPlaying = False
        Else
            MyVideo.Play()
            Timer.Start()
            IsPlaying = True
        End If
    End Sub

    Private Sub onNextCmd()
        MyVideo.Stop()
        Timer.Stop()

        If IsSuffule Then
            Dim Rand As New Random()
            Index = Rand.Next(0, ListMedia.Count - 1)
            SelectedVideo = ListMedia(Index)
            PathFileVideo = ListMedia(Index).PathFile
            VideoName = ListMedia(Index).NameVideo
            NameSinger = ListMedia(Index).Singer
            ImagePath = ListMedia(Index).PathImage
        End If

        If Index = (ListMedia.Count - 1) Then
            MessageBox.Show("Can not Next this is Last")
            Return
        Else
            Index = Index + 1
            SelectedVideo = ListMedia(Index)
            PathFileVideo = ListMedia(Index).PathFile
            VideoName = ListMedia(Index).NameVideo
            NameSinger = ListMedia(Index).Singer
            ImagePath = ListMedia(Index).PathImage
            Timer.Start()
        End If
        MyVideo.Play()
        IsPlaying = True
    End Sub

    Private Sub OnReaptOneCmd()
        If IsRepeatOne Then
            IsRepeatOne = False
        Else
            IsRepeatOne = True
        End If
    End Sub

    Private Sub RandomIndex()

        If IsRepeatOne Then
            Index = Index
        End If
        If IsSuffule Then
            Dim Rand As New Random()
            Index = Rand.Next(0, ListMedia.Count - 1)
        End If
    End Sub
    Private Sub OnSuffleCmd()
        If IsSuffule Then
            IsSuffule = False
        Else
            IsSuffule = True
        End If
    End Sub

    Private Sub OnPreCmd()
        MyVideo.Stop()
        Timer.Stop()
        If IsSuffule Then
            Dim Rand As New Random()
            Index = Rand.Next(0, ListMedia.Count - 1)
            SelectedVideo = ListMedia(Index)
            PathFileVideo = ListMedia(Index).PathFile
            VideoName = ListMedia(Index).NameVideo
            NameSinger = ListMedia(Index).Singer
            ImagePath = ListMedia(Index).PathImage
        End If

        If Index = 0 Then
            MessageBox.Show("Can not Previous This is last")
            Timer.Stop()
            Return
        Else
            Index = Index - 1
            SelectedVideo = ListMedia(Index)
            PathFileVideo = ListMedia(Index).PathFile
            VideoName = ListMedia(Index).NameVideo
            NameSinger = ListMedia(Index).Singer
            ImagePath = ListMedia(Index).PathImage
            Timer.Start()
        End If
        MyVideo.Play()
        IsPlaying = True
    End Sub

    Private Sub SelectedMediaCommand(ByVal media As Media)
        Index = ListMedia.IndexOf(media)
        PathFileVideo = media.PathFile
        MyVideo.Play()
        IsPlaying = True
        Timer.Start()
    End Sub

#End Region
End Class
