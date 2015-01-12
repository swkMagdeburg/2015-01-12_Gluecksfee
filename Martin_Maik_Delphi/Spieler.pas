unit Spieler;

interface

type
  ISpieler = interface
    ['{C449DB9F-FF3A-48C2-96AF-B3F938C986BE}']
    function  GetName: string;

    property Name: string read GetName;
  end;

  IDummySpieler = interface
    ['{FC61D1F1-B610-4217-9047-7321DF39EAF9}']
  end;

  TSpieler = class(TInterfacedObject, ISpieler)
  strict private
    FName: string;
  public
    constructor Create(aName: string);

    function  GetName: string;

    property Name: string read GetName;
  end;

  TDummySpieler = class(TInterfacedObject, ISpieler, IDummySpieler)
  public
    function  GetName: string;
  end;

implementation

{ TSpieler }

constructor TSpieler.Create(aName: string);
begin
  FName := aName;
end;

function TSpieler.GetName: string;
begin
  Result := FName;
end;

{ TDummySpieler }

function TDummySpieler.GetName: string;
begin
  REsult := 'Dummy';
end;

end.
