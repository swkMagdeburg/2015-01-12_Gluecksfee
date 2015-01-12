program GluecksfeeModelTests;
{

  Delphi DUnit-Testprojekt
  -------------------------
  Dieses Projekt enth�lt das DUnit-Test-Framework und die GUI/Konsolen-Test-Runner.
  F�gen Sie den Bedingungen in den Projektoptionen "CONSOLE_TESTRUNNER" hinzu,
  um den Konsolen-Test-Runner zu verwenden.  Ansonsten wird standardm��ig der
  GUI-Test-Runner verwendet.

}

{$IFDEF CONSOLE_TESTRUNNER}
{$APPTYPE CONSOLE}
{$ENDIF}

uses
  DUnitTestRunner,
  TestSpielrunde in 'TestSpielrunde.pas',
  Spielrunde in '..\Spielrunde.pas',
  Spieler in '..\Spieler.pas',
  Spiel in '..\Spiel.pas',
  TestSpiel in 'TestSpiel.pas';

{$R *.RES}

begin
  DUnitTestRunner.RunRegisteredTests;
end.

