Public Module Connection

    Private conn_server As String
    Private conn_uid As String
    Private conn_pwd As String
    Private conn_db As String
    Private conn_port As String
    Private sqlconn As String
    Private conn_connected As Boolean
    Private table As String

    Sub New()
        conn_server = ""
        conn_uid = ""
        conn_pwd = ""
        conn_db = ""
        conn_port = ""
    End Sub

    Public Property server As String
        Get
            Return conn_server
        End Get
        Set(value As String)
            conn_server = value
        End Set
    End Property

    Public Property uid As String
        Get
            Return conn_uid
        End Get
        Set(value As String)
            conn_uid = value
        End Set
    End Property

    Public Property pwd As String
        Get
            Return conn_pwd
        End Get
        Set(value As String)
            conn_pwd = value
        End Set
    End Property

    Public Property db As String
        Get
            Return conn_db
        End Get
        Set(value As String)
            conn_db = value
        End Set
    End Property

    Public Property port As String
        Get
            Return conn_port
        End Get
        Set(value As String)
            conn_port = value
        End Set
    End Property

    Public Property conn As String
        Get
            Return sqlconn
        End Get
        Set(value As String)
            sqlconn = value
        End Set
    End Property

    Public Property connected As Boolean
        Get
            Return conn_connected
        End Get
        Set(value As Boolean)
            conn_connected = value
        End Set
    End Property

    Public Property tableName As String
        Get
            Return table
        End Get
        Set(value As String)
            table = value
        End Set
    End Property
End Module