unit Spiel;

interface

uses
  Spieler;

type
  ISpiel = interface
    ['{F5EB8E05-4D38-409A-A2FC-10610C4724E1}']
    procedure Spielen;

    function  GetHeimspieler: ISpieler;
    function  GetGastspieler: ISpieler;
    function  GetGewinner: ISpieler;
    function  GetVerlierer: ISpieler;

    property Heimspieler: ISpieler read GetHeimspieler;
    property Gastspieler: ISpieler read GetGastspieler;
    property Gewinner: ISpieler read GetGewinner;
    property Verlierer: ISpieler read GetVerlierer;
  end;

  TSpiel = class(TInterfacedObject, ISpiel)
  strict private
    FHeimspieler: ISpieler;
    FGastspieler: ISpieler;
    FGewinner: ISpieler;
    FVerlierer: ISpieler;
  public
    constructor Create(aHeimspieler, aGastspieler: ISpieler);

    procedure Spielen;

    function  GetHeimspieler: ISpieler;
    function  GetGastspieler: ISpieler;
    function  GetGewinner: ISpieler;
    function  GetVerlierer: ISpieler;
  end;

implementation

{ TSpiel }

function TSpiel.GetGewinner: ISpieler;
begin
  Result := FGewinner;
end;

constructor TSpiel.Create(aHeimspieler, aGastspieler: ISpieler);
begin
  FHeimspieler := aHeimspieler;
  FGastspieler := aGastspieler;
end;

function TSpiel.GetGastspieler: ISpieler;
begin
  Result := FGastspieler;
end;

function TSpiel.GetHeimspieler: ISpieler;
begin
  Result := FHeimspieler;
end;

function TSpiel.GetVerlierer: ISpieler;
begin
  Result := FVerlierer;
end;

procedure TSpiel.Spielen;
begin
  FGewinner := FHeimspieler;
  FVerlierer := FGastspieler;
end;

end.
