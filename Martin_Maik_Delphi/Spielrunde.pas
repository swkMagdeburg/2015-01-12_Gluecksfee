unit Spielrunde;

interface

uses
  System.Generics.Collections,
  Spieler,
  Spiel;

type
  ISpielrunde = interface
    ['{8BF9CF13-B7D8-4397-8FC5-96F8889A817C}']
    procedure SpieleAuslosen;

    function  GetSpiele: TArray<ISpiel>;

    property Spiele: TArray<ISpiel> read GetSpiele;
  end;

  TSpielrunde = class(TInterfacedObject, ISpielrunde)
  strict private
    FSpieler: TList<ISpieler>;
    FSpiele: TArray<ISpiel>;

    procedure AddSpiel(aHeimspieler, aGastspieler: ISpieler); overload;
    procedure AddSpiel(aSpiel: ISpiel); overload;
  public
    constructor Create(aSpieler: TList<ISpieler>);

    procedure SpieleAuslosen;

    function  GetSpiele: TArray<ISpiel>;
  end;

implementation

{ TSpielrunde }

procedure TSpielrunde.AddSpiel(aSpiel: ISpiel);
begin
  SetLength(FSpiele, Length(FSpiele) + 1);
  FSpiele[High(FSpiele)] := aSpiel;
end;

procedure TSpielrunde.AddSpiel(aHeimspieler, aGastspieler: ISpieler);
var
  spiel: ISpiel;
begin
  spiel := TSpiel.Create(aHeimspieler, aGastspieler);
  AddSpiel(spiel);
end;

constructor TSpielrunde.Create(aSpieler: TList<ISpieler>);
begin
  FSpieler := aSpieler;
end;

function TSpielrunde.GetSpiele: TArray<ISpiel>;
begin
  Result := FSpiele;
end;

procedure TSpielrunde.SpieleAuslosen;
var
  i: Integer;
  spiel: ISpiel;
begin
  i := 0;
  while i <= FSpieler.Count - 2 do begin
    AddSpiel(FSpieler[i], FSpieler[i + 1]);
    Inc(i, 2);
  end;
  if FSpieler.Count mod 2 = 1 then begin
    AddSpiel(FSpieler[FSpieler.Count - 1], TDummySpieler.Create());
  end;
end;

end.
