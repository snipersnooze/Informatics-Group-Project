Public Class detailshiv
    Private nchildren As Integer 'number of children infected
    Private npreg As Integer 'pregnant woman infected with aids
    Private nfm(2) As Integer 'males and non pregnant females infected
    Private natvi As Integer 'infected and using anti viral therapy
    Public Sub New(males As Integer, females As Integer, preg As Integer, children As Integer)
        nfm(1) = males
        nfm(2) = females
        npreg = preg
        nchildren = children
    End Sub
    Public Property gnatvi As Integer
        Get
            Return natvi
        End Get
        Set(value As Integer)
            natvi = value
        End Set
    End Property

    Public ReadOnly Property gchildren As Integer
        Get
            Return nchildren
        End Get
    End Property

    Public ReadOnly Property gpreg As Integer
        Get
            Return npreg
        End Get
    End Property



    Public ReadOnly Property gnfm(i As Integer) As Integer
        Get
            Return nfm(i)
        End Get
    End Property

End Class
