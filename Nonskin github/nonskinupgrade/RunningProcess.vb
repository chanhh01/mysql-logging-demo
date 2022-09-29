Public Module RunningProcess
    Public ruStat As Boolean
    Public mcStat As Boolean
    Public ruProc As Integer
    Public mcProc As Integer

    Sub New()
        ruStat = False
        mcStat = False
        ruProc = 0
        mcProc = 0
    End Sub

    Public Property randomUploadStatus As Boolean
        Get
            Return ruStat
        End Get
        Set(value As Boolean)
            ruStat = value
        End Set
    End Property

    Public Property monitorChangeStatus As Boolean
        Get
            Return mcStat
        End Get
        Set(value As Boolean)
            mcStat = value
        End Set
    End Property

    Public Property randomUploadProcess As Integer
        Get
            Return ruProc
        End Get
        Set(value As Integer)
            ruProc = value
        End Set
    End Property

    Public Property monitorChangeProcess As Integer
        Get
            Return mcProc
        End Get
        Set(value As Integer)
            mcProc = value
        End Set
    End Property
End Module
