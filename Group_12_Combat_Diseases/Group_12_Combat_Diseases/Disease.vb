'*****************************************************************
' Team Number: 12
' Team Member 1 Details: Sedu, MSAS (220042255)
' Team Member 2 Details: Pathan, MP (220012601)
' Team Member 3 Details: Surname, Initials (Student #)
' Team Member 4 Details: e.g. Smith, J (202000001)
' Practical: Team Project
' Class name: Disease
' *****************************************************************

Option Strict On
Option Infer Off
Option Explicit On

Public Class Disease
    'Variables
    Private _cases() As Integer
    Private _months As Integer
    Private _totalCases As Integer
    Private _deaths As Integer

    'Constructor
    Public Sub New(months As Integer, Cases As Integer)
        _months = enforceRange(months)
        'Resize the Cases array
        ReDim _cases(Cases)
    End Sub

    'properties
    Public Property Deaths As Integer
        Get
            Return _deaths
        End Get
        Set(value As Integer)
            _deaths = enforceRange(value)
        End Set
    End Property

    Public Property Cases(i As Integer) As Integer
        Get
            If i >= 1 And i <= _months Then
                Return _cases(i)
            Else
                Return -1
            End If
        End Get
        Set(value As Integer)
            If i >= 1 And i <= _months Then
                Cases(i) = enforceRange(value)
            End If
        End Set
    End Property

    Public ReadOnly Property TotalCases As Integer
        Get
            Return _totalCases
        End Get
    End Property

    Public Function AvgCases() As Double 'the average number of cases
        For i As Integer = 1 To _months
            _totalCases += _cases(i)
        Next i
        Return _totalCases / _months
    End Function

    Public Function DeathRate() As Double 'death rate for the disease
        Return _deaths / _totalCases * 100
    End Function

    Public Overridable Function Display() As String 'displays the disease information
        Dim output As String
        output = "Months monitored: " & _months & vbCrLf
        output += "Total cases: " & _totalCases & vbCrLf
        output += "Deaths: " & _deaths & vbCrLf
        Return output
    End Function

    Protected Function enforceRange(val As Integer) As Integer
        If val < 0 Then
            Return val * -1
        Else
            Return val
        End If
    End Function
    Protected Function enforceRange(val As Double) As Double
        If val < 0 Then
            Return val * -1
        Else
            Return val
        End If
    End Function
End Class
