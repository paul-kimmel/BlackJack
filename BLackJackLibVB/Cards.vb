'    Copyright (c) 2004 Software Conceptions, Inc.  All rights reserved.
'    Written by Paul Kimmel. pkimmel@softconcepts.com
'   
'    You must not remove this notice, or any other, from this software.
'   

Imports System
Imports System.Drawing

Public MustInherit Class Card
  Private FCardFace As Face
  Private FHighFaceValue As Integer
  Private FLowFaceValue As Integer
  Private FCardSuit As Suit

#Region "External methods and related fields"
  Private width As Integer = 0
  Private height As Integer = 0

  Declare Function cdtInit Lib "cards.dll" (ByRef width As Integer, _
    ByRef height As Integer) As Boolean
  Declare Function cdtDrawExt Lib "cards.dll" (ByVal hdc As IntPtr, _
    ByVal x As Integer, ByVal y As Integer, ByVal dx As Integer, _
    ByVal dy As Integer, ByVal card As Integer, _
    ByVal suit As Integer, ByVal color As Long) As Boolean
  Declare Sub cdtTerm Lib "cards.dll" ()
#End Region

  Public Sub New(ByVal lowValue As Integer, ByVal highValue As Integer, _
    ByVal cardSuit As Suit, ByVal cardFace As face)

    cdtInit(width, height)
    FHighFaceValue = highValue
    FLowFaceValue = lowValue
    FCardSuit = cardSuit
    FCardFace = cardFace

  End Sub

  Public Function GetLowFaceValue() As Integer
    Return FLowFaceValue
  End Function

  Public Function GetHighFaceValue() As Integer
    Return FHighFaceValue
  End Function

  Public Function GetFaceValue() As Integer
    Return FLowFaceValue
  End Function

  Public Property CardSuit() As Suit
  Get
    Return FCardSuit
  End Get
  Set(ByVal Value As Suit)
    FCardSuit = Value
  End Set
  End Property

  ' TODO: Convert various paint styles to interface
  Public Sub PaintTextFace()
    Console.WriteLine(GetCardValue())
  End Sub

  Public Sub PaintGraphicFace(ByVal g As Graphics, ByVal x As Integer, _
    ByVal y As Integer, ByVal dx As Integer, ByVal dy As Integer)

    Dim hdc As IntPtr = g.GetHdc()
    Try
      Dim Card As Integer = CType(Me.FCardFace, Integer)
      cdtDrawExt(hdc, x, y, dx, dy, Card, 0, 0)
    Finally
      ' If Intellisense doesn't show this method unhine advanced members in Tools|Options
      g.ReleaseHdc(hdc)
    End Try
  End Sub

  Public Sub PaintGraphicBack(ByVal g As Graphics, ByVal x As Integer, _
    ByVal y As Integer, ByVal dx As Integer, ByVal dy As Integer)

    Dim hdc As IntPtr = g.GetHdc()
    Try
      ' TODO: Make card style (hardcoded 61) a configurable property
      cdtDrawExt(hdc, x, y, dx, dy, 61, 0, 0)
    Finally
      g.ReleaseHdc(hdc)
    End Try

  End Sub

  Protected Overridable Function GetTextValue() As String
    Return GetLowFacevalue().ToString()
  End Function

  Protected Function GetTextSuit() As String
    Return FCardSuit.ToString().Chars(0).ToString
  End Function

  Public Overridable Function GetCardValue() As String
    Return String.Format("{0}{1}", GetTextValue(), GetTextSuit())
  End Function
End Class

Public Class Ace
  Inherits Card

  Public Sub New(ByVal cardSuit As Suit)
    MyBase.New(1, 11, cardSuit, Face.One)
  End Sub

  Protected Overrides Function GetTextValue() As String
    Return "A"
  End Function
 End Class

