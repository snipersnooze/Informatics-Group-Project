Public Class HIV
    Inherits Disease
    Private details() As detailshiv

    Public Sub New(months As Integer, males As Integer, females As Integer, npreg As Integer, nchildren As Integer)
        MyBase.New(months)
        ReDim details(months)
        For x As Integer = 1 To months
            details(x) = New detailshiv(males, females, npreg, nchildren)
        Next

    End Sub
    Public Property gdet(i As Integer) As detailshiv
        Get
            Return details(i)
        End Get
        Set(value As detailshiv)
            details(i) = value
        End Set
    End Property
    Private Function ad(i As Integer, z As Integer) As Integer
        Dim ttl = 0
        Select Case i
            Case 1
                For x As Integer = 1 To _months
                    ttl += details(x).gchildren
                Next
                Return ttl
            Case 2
                For x As Integer = 1 To _months
                    ttl += details(x).gnfm(z)
                Next
                Return ttl
            Case 3
                For x As Integer = 1 To _months
                    ttl += details(x).gpreg
                Next
                Return ttl
            Case 4
                For x As Integer = 1 To _months
                    ttl += details(x).gnatvi
                Next
                Return ttl
        End Select
    End Function


    Public Sub settotal(i As Integer) 'set number of ppl infected in that year
        Cases(i) = details(i).gnfm(1) + details(i).gnfm(2) + details(i).gpreg + details(i).gchildren
    End Sub


    Public Function progress(c As Integer) As String 'trend here if it decreased becasue of anti or other,if anti increased
        Dim isdec As Boolean = True
        Dim cont As Integer = 1
        While isdec = True And cont < _cases.Length - 2
            If Cases(cont) > Cases(cont + 1) And details(cont).gnatvi < details(cont + 1).gnatvi Then
                cont += 1
            Else
                isdec = False
            End If

        End While

        If isdec = True Then
            Return "Infections decreased and use of anti viral therapy increased"
        Else
            Return " Awareness of HIV and anti viral therapy needs to increase to reduce Hiv Infection"

        End If

    End Function

    Public Overrides Function Display() As String 'displays the disease information
        Dim output As String


        output += MyBase.Display() + vbCrLf + "Children infected " + CStr(ad(1, 0)) + vbCrLf + "Total adults infected " + CStr(ad(2, 0)) + vbCrLf
        output += "Total Males infected " + CStr(ad(2, 1)) + "Total Females infected " + CStr(ad(2, 2)) + vbCrLf + "Pregnant woman infected " + CStr(ad(3, 3)) + vbCrLf
        output += "Infected and using avt " + CStr(ad(4, 5)) + vbCrLf
        output += "Goal status/recomendation regarding HIV"
        Return output
    End Function

End Class
