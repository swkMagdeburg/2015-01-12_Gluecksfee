unit Main;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs,
  Turnier,
  SpielerRepository,
  Spieler,
  Spiel,
  Spielrunde,
  Vcl.StdCtrls;

type
  TForm1 = class(TForm)
    LbSpieler: TListBox;
    LbSpielrunde: TListBox;
    BtAuslosen: TButton;
    BtSpielen: TButton;
    procedure BtAuslosenClick(Sender: TObject);
    procedure BtSpielenClick(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure FormShow(Sender: TObject);
  strict private
    FTurnier: TTurnier;

    procedure SpielerAktualisieren;
    procedure SpielrundeAktualisieren;
  public
    destructor Destroy; override;
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
  FTurnier := TTurnier.Create(TSpielerRepository.Create);
end;

procedure TForm1.SpielerAktualisieren;
var
  spieler: ISpieler;
begin
  LbSpieler.Clear;
  for spieler in FTurnier.Spieler do begin
    LbSpieler.AddItem(spieler.Name, nil);
  end;
end;

procedure TForm1.SpielrundeAktualisieren;
var
  spiel: ISpiel;
  spieltext: string;
begin
  LbSpielrunde.Clear;
  for spiel in FTurnier.AktuellesSpielrunde.Spiele do begin
    spieltext := spiel.Heimspieler.Name + ' - ' + spiel.Gastspieler.Name;
    if Assigned(spiel.Gewinner) then begin
      spieltext := spieltext + ': ' + spiel.Gewinner.Name;
    end;
    LbSpielrunde.AddItem(spieltext, nil);
  end;
end;

{ TForm1 }

destructor TForm1.Destroy;
begin
  FTurnier.Free;
  inherited;
end;

procedure TForm1.BtAuslosenClick(Sender: TObject);
begin
  FTurnier.NeueSpielrunde;
  SpielrundeAktualisieren();
end;

procedure TForm1.BtSpielenClick(Sender: TObject);
begin
  FTurnier.Spielen;
  FTurnier.EntferneVerlierer;
  SpielerAktualisieren;
  SpielrundeAktualisieren;
end;

procedure TForm1.FormShow(Sender: TObject);
begin
  Self.SpielerAktualisieren();
end;

end.
