unit TestSpiel;
{

  Delphi DUnit-Testfall
  ----------------------
  Diese Unit enthält ein Skeleton einer Testfallklasse, das vom Experten für Testfälle erzeugt wurde.
  Ändern Sie den erzeugten Code so, dass er die Methoden korrekt einrichtet und aus der 
  getesteten Unit aufruft.

}

interface

uses
  TestFramework, Spiel, Spieler;

type
  // Testmethoden für Klasse ISpiel

  TestISpiel = class(TTestCase)
  strict private
    FISpiel: ISpiel;
  public
    procedure SetUp; override;
    procedure TearDown; override;
  published
    procedure TestSpielen;
  end;

implementation

procedure TestISpiel.SetUp;
begin
  FISpiel := TSpiel.Create(TSpieler.Create('Heim'), TSpieler.Create('Gast'));
end;

procedure TestISpiel.TearDown;
begin
  FISpiel := nil;
end;

procedure TestISpiel.TestSpielen;
begin
  CheckNull(FISpiel.Gewinner);
  FISpiel.Spielen;
  CheckNotNull(FISpiel.Gewinner);
end;

initialization
  // Alle Testfälle beim Testprogramm registrieren
  RegisterTest(TestISpiel.Suite);
end.

