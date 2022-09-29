Public Module DataTables
    Private dt_prevUpdate As DataTable
    Private dt_prevInsert As DataTable
    Private dt_afterUpdate As DataTable
    Private dt_afterInsert As DataTable

    Public Property dataTable_prevUpdate As DataTable
        Get
            Return dt_prevUpdate
        End Get
        Set(value As DataTable)
            dt_prevUpdate = value
        End Set
    End Property

    Public Property dataTable_prevInsert As DataTable
        Get
            Return dt_prevInsert
        End Get
        Set(value As DataTable)
            dt_prevInsert = value
        End Set
    End Property

    Public Property dataTable_afterUpdate As DataTable
        Get
            Return dt_afterUpdate
        End Get
        Set(value As DataTable)
            dt_afterUpdate = value
        End Set
    End Property

    Public Property dataTable_afterInsert As DataTable
        Get
            Return dt_afterInsert
        End Get
        Set(value As DataTable)
            dt_afterInsert = value
        End Set
    End Property

End Module
