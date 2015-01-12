unit SpielerRepository;

interface

uses
  System.Generics.Collections,
  Spieler;

type
  ISpielerRepository = interface
    ['{B69D187B-F439-4375-B249-CDEC5BFF206F}']
    function  Spieler: TList<ISpieler>;
    procedure EntferneSpieler(aSpieler: ISpieler);
  end;

  TSpielerRepository = class(TInterfacedObject, ISpielerRepository)
  strict private
    FSpieler: TList<ISpieler>;
  public
    constructor Create;
    destructor Destroy; override;

    function  Spieler: TList<ISpieler>;
    procedure EntferneSpieler(aSpieler: ISpieler);
  end;

implementation

{ TSpielerRepository }

constructor TSpielerRepository.Create;
begin
  FSpieler := TList<ISpieler>.Create();

  FSpieler.Add(TSpieler.Create('Maik'));
  FSpieler.Add(TSpieler.Create('Martin'));
  FSpieler.Add(TSpieler.Create('Andreas'));
  FSpieler.Add(TSpieler.Create('Nico'));
  FSpieler.Add(TSpieler.Create('Tobias'));
  FSpieler.Add(TSpieler.Create('Matthias'));
  FSpieler.Add(TSpieler.Create('Katharina'));
end;

destructor TSpielerRepository.Destroy;
begin
  FSpieler.Free;
  inherited Destroy;
end;

procedure TSpielerRepository.EntferneSpieler(aSpieler: ISpieler);
begin
  FSpieler.Remove(aSpieler);
end;

function TSpielerRepository.Spieler: TList<ISpieler>;
begin
  Result := FSpieler;
end;

end.
