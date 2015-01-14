unit TestSpielrunde;
{

  Delphi DUnit-Testfall
  ----------------------
  Diese Unit enthält ein Skeleton einer Testfallklasse, das vom Experten für Testfälle erzeugt wurde.
  Ändern Sie den erzeugten Code so, dass er die Methoden korrekt einrichtet und aus der
  getesteten Unit aufruft.

}

interface

uses
  TestFramework,
  System.Generics.Collections,
  System.SysUtils,
  Spielrunde, Spiel, Spieler;

type
  // Testmethoden für Klasse TSpielrunde

  TestTSpielrunde = class(TTestCase)
  strict private
    FSpieler: TList<ISpieler>;
    FSpielrunde: ISpielrunde;
  public
    procedure SetUp; override;
    procedure TearDown; override;
  published
    procedure SpieleAuslosen_VierSpieler;
    procedure SpieleAuslosen_DreiSpieler_MitDummy;
  end;

implementation

procedure TestTSpielrunde.SetUp;
begin
  FSpieler := TList<ISpieler>.Create();
  FSpielrunde := TSpielrunde.Create(FSpieler);
end;

procedure TestTSpielrunde.TearDown;
begin
  FSpielrunde := nil;
  FSpieler.Free;
end;

procedure TestTSpielrunde.SpieleAuslosen_VierSpieler;
begin
  FSpieler.Add(TSpieler.Create('1'));
  FSpieler.Add(TSpieler.Create('2'));
  FSpieler.Add(TSpieler.Create('3'));
  FSpieler.Add(TSpieler.Create('4'));

  FSpielrunde.SpieleAuslosen;

  CheckEquals(2, Length(FSpielrunde.Spiele));
  CheckEquals(FSpieler[0].Name, FSpielrunde.Spiele[0].Heimspieler.Name);
  CheckEquals(FSpieler[1].Name, FSpielrunde.Spiele[0].Gastspieler.Name);
  CheckEquals(FSpieler[2].Name, FSpielrunde.Spiele[1].Heimspieler.Name);
  CheckEquals(FSpieler[3].Name, FSpielrunde.Spiele[1].Gastspieler.Name);
end;

procedure TestTSpielrunde.SpieleAuslosen_DreiSpieler_MitDummy;
begin
  FSpieler.Add(TSpieler.Create('1'));
  FSpieler.Add(TSpieler.Create('2'));
  FSpieler.Add(TSpieler.Create('3'));

  FSpielrunde.SpieleAuslosen;

  CheckEquals(2, Length(FSpielrunde.Spiele));
  CheckEquals(FSpieler[0].Name, FSpielrunde.Spiele[0].Heimspieler.Name);
  CheckEquals(FSpieler[1].Name, FSpielrunde.Spiele[0].Gastspieler.Name);
  CheckEquals(FSpieler[2].Name, FSpielrunde.Spiele[1].Heimspieler.Name);
  CheckTrue(Supports(FSpielrunde.Spiele[1].Gastspieler, IDummySpieler));
end;


initialization
  RegisterTest(TestTSpielrunde.Suite);

end.

