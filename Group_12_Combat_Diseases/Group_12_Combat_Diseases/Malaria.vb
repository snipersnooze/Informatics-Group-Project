'*****************************************************************
' Team Number: 12
' Team Member 1 Details: Sedu, MSAS (220042255)
' Team Member 2 Details: Pathan, MP (220012601)
' Team Member 3 Details: Surname, Initials (Student #)
' Team Member 4 Details: e.g. Smith, J (202000001)
' Practical: Team Project
' Class name: Malaria
' *****************************************************************

Option Strict On
Option Infer Off
Option Explicit On

Public Class Malaria
    'Inherits Base Class Disease
    Inherits Disease
    'Implements the Interface
    Implements DiseaseCases

    'Variables
    Private _Nets As Integer
    Private _Mosquito As Integer
    Private _Area As Double
    Private _KlWater As Double

    'Constructor
    Public Sub New(Months As Integer, Cases As Integer, Mosquito As Integer, Area As Double, Water As Double, Nets As Integer)
        MyBase.New(Months)
        _Mosquito = enforceRange(Mosquito)
        _Area = enforceRange(Area)
        _KlWater = enforceRange(Water)
        _Nets = enforceRange(Nets)
    End Sub

    'Method
    'Recovery Rate
    Public Function RecoveryRate() As Double
        Dim Value As Double
        Value = (((_Nets * _Area) - (_Mosquito * _KlWater)) / TotalCases) * 100
        If Value >= 0 And Value <= 100 Then
            Return Value
        Else
            Return 0
        End If
    End Function
    'Details - Gives threat Level
    Public Function ThreatLevel() As String Implements DiseaseCases.ThreatLevel
        If RecoveryRate() >= 0 And RecoveryRate() <= 25 Then
            Return "Extreme Level Threat!"
        ElseIf RecoveryRate() > 25 And RecoveryRate() <= 50 Then
            Return "High Level Threat!"
        ElseIf RecoveryRate() > 50 And RecoveryRate() <= 90 Then
            Return "Medium Level Threat!"
        Else
            Return "Low Level Threat!"
        End If
    End Function
    'Symptoms Of Malaria
    Public Function Symptoms() As String Implements DiseaseCases.Symptoms
        Return "Symptoms of Malaria: " + Environment.NewLine + "-> Fever and Fatigue." _
                                       + Environment.NewLine + "-> Nausea and vomiting." _
                                       + Environment.NewLine + "-> Headache and Muscle Pain." _
                                       + Environment.NewLine + "-> Chills, Shivering and Sweating."
    End Function

	'polymorphism
    Public Overrides Function Display() As String'display the disease information and the added information about malaria 
        Dim output As String
        output = "Recovery rate: " & CStr(RecoveryRate()) & vbCrLf
        output += Symptoms() & vbCrLf
        output += "Threat level: " & CStr(ThreatLevel()) & vbCrLf

        Return MyBase.Display() & output
    End Function
End Class
