unit Turnier;

interface

uses
  System.Generics.Collections,
  Spieler,
  Spiel,
  Spielrunde,
  SpielerRepository;

type
  TTurnier = class
  strict private
    FSpielerRepository: ISpielerRepository;
    FAktuelleSpielrunde: ISpielrunde;
  public
    constructor Create(aSpielerRepo: ISpielerRepository);

    procedure NeueSpielrunde;
    procedure Spielen;
    procedure EntferneVerlierer;

    property AktuellesSpielrunde: ISpielrunde read FAktuelleSpielrunde;
    function  Spieler: TArray<ISpieler>;
  end;

implementation

{ TTurnier }

constructor TTurnier.Create(aSpielerRepo: ISpielerRepository);
begin
  FSpielerRepository := aSpielerRepo;
end;

procedure TTurnier.EntferneVerlierer;
var
  spiel: ISpiel;
begin
  for spiel in FAktuelleSpielrunde.Spiele do begin
    FSpielerRepository.EntferneSpieler(spiel.Verlierer);
  end;
end;

procedure TTurnier.NeueSpielrunde;
begin
  FAktuelleSpielrunde := TSpielrunde.Create(FSpielerRepository.Spieler);
  FAktuelleSpielrunde.SpieleAuslosen;
end;

procedure TTurnier.Spielen;
var
  spiel: ISpiel;
begin
  for spiel in FAktuelleSpielrunde.Spiele do begin
    spiel.Spielen();
  end;
end;

function TTurnier.Spieler: TArray<ISpieler>;
begin
  Result := FSpielerRepository.Spieler.ToArray;
end;

end.
