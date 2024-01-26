'    Copyright (c) 2004 Software Conceptions, Inc.  All rights reserved.
'    Written by Paul Kimmel. pkimmel@softconcepts.com
'   
'    You must not remove this notice, or any other, from this software.
'   

Imports NUnit.Framework
Imports BLackJackLibVB
Imports System.Windows.Forms

<TestFixture()> _
Public Class BlackJackTests

  <Test()> _
  Public Sub CardSuitTest()
    Dim aceOfClubs As Ace = New Ace(Suit.Club)
    Console.WriteLine(aceOfClubs.GetCardValue())
    Assertion.AssertEquals("Expected 'AC'", aceOfClubs.GetCardValue(), "AC")
  End Sub

  <Test()> _
  Public Sub CardAceLowValueTest()
    Dim a As Ace = New Ace(Suit.Heart)
    Console.WriteLine(a.GetCardValue())
    Assertion.AssertEquals("Expected 1", 1, a.GetLowFaceValue())
  End Sub

  <Test()> _
  Public Sub CardAceHighValueTest()
    Dim a As Ace = New Ace(Suit.Heart)
    Console.WriteLine(a.GetCardValue())
    Assertion.AssertEquals("Expected 11", 11, a.GetHighFaceValue())
  End Sub

  Private spade As Ace
  <Test()> _
  Public Sub GraphicPaintAceTest()
    spade = New Ace(Suit.Spade)
    Dim F As Form = New Form
    AddHandler F.Paint, AddressOf OnPaint
    F.ShowDialog()
    Assertion.Assert(MsgBox("Did you see the ace of spades?", _
      MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Ace of Spades") _
      = MsgBoxResult.Yes)

  End Sub

  Private Sub OnPaint(ByVal sender As Object, ByVal e As PaintEventArgs)
    If (spade Is Nothing) Then Return
    spade.PaintGraphicFace(e.Graphics, 0, 0, 75, 100)
  End Sub

End Class
