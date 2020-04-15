Class MainWindow
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Dim mediaPlay As VideoPlayViewModel = CType(sender, MainWindow).DataContext
        mediaPlay.MyVideo = CType(sender, MainWindow).playVideo
    End Sub
End Class
