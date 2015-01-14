object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Form1'
  ClientHeight = 300
  ClientWidth = 635
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Microsoft Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 13
  object LbSpieler: TListBox
    Left = 0
    Top = 0
    Width = 241
    Height = 300
    Align = alLeft
    ItemHeight = 13
    TabOrder = 0
  end
  object LbSpielrunde: TListBox
    Left = 368
    Top = 0
    Width = 267
    Height = 300
    Align = alRight
    ItemHeight = 13
    TabOrder = 1
  end
  object BtAuslosen: TButton
    Left = 272
    Top = 72
    Width = 75
    Height = 41
    Caption = 'Ziehung'
    TabOrder = 2
    OnClick = BtAuslosenClick
  end
  object BtSpielen: TButton
    Left = 272
    Top = 176
    Width = 75
    Height = 25
    Caption = 'Spielen'
    TabOrder = 3
    OnClick = BtSpielenClick
  end
end
