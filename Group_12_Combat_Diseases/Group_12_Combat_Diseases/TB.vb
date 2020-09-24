'*****************************************************************
' Team Number: 12
' Team Member 1 Details: Sedu, MSAS (220042255)
' Team Member 2 Details: Pathan, MP (220012601)
' Team Member 3 Details: Surname, Initials (Student #)
' Team Member 4 Details: e.g. Smith, J (202000001)
' Practical: Team Project
' Class name: TB
' *****************************************************************

Option Strict On
Option Infer Off
Option Explicit On

Public Class TB
    Inherits Disease

    Private _medMonths As Integer ' number of months the medication needs to be taken

    Public Sub New(months As Integer, medMonths As Integer)
        MyBase.New(months)
        _medMonths = enforceRange(medMonths)
    End Sub

    Public Function TBType() As String
        Select Case _medMonths
            Case 0 To 6
                Return "Normal TB"
            Case 7 To 9
                Return "Drug resistant TB"
            Case 10 To 11
                Return "Multi-Drug resistant TB"
            Case Else
                Return "Extreme drug resistant TB"
        End Select
    End Function

    Public Overrides Function Display() As String
        Return MyBase.Display() + "TB type: " & TBType()
    End Function

End Class
