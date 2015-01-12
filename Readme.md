# Idee

Die Auslosung des ersten Gewinners einer JetBrains Lizenz soll ein selbstgeschriebenes Programm übernehmen. Was liegt also näher, die Aufgabe in eine Kata zu verpacken und diese von den Teilnehmern selbst umsetzen zu lassen.

Die einzelnen Lösungen des Katas finden sich in den Unterordnern in diesem Repsository.


# Kata Glücksfee

Die Glücksfee ermittelt aus einer beliebigen Anzahl an Spielern einen Gewinner im Sinne einer K.O. Runde.

## Regeln
Die Ziehung der Gewinner erfolgt rundenbasiert. In jeder Runde werden durch ein Zufallspinzip die noch im Spiel befindlichen Teilnehmer in Paare aufgeteilt. Diese Paare treten pro Runde in einem Spiel gegeneinander an. Der Gewinner jedes Spieles erreicht die nächste Runde, bis nur noch ein Spieler übrig ist.

Die Eingabe der Spieler erfolgt beim Start der Glücksfee durch das Laden einer Spielerdatei. In der Datei ist jeder Spieler auf einer separaten Zeile anzugeben. Beispielhaft könnte der Inhalt einer solchen Datei wie folgt aussehen:

    Brasilien
    Deutschaland
    Niederlande
    Argentinien 

Vor jeder Runde sollen die Paarungen angezeigt werden und die Spiele nach Bestätigung durch den Anwender starten. Das Ergebnis jedes Spieles, welches durch ein Zufallsprinzip ermittelt wird, sollen dem Anwender so angzeigt werden, dass der Gewinner und Verlierer ersichtlich sind. Ein genaues Ergebnis wie zum Beispiel beim Fussball ist nicht notwendig. 

Nach der Finalrunde soll der Gesamtsieger separat angezeigt und beglückwünscht werden.

## Sonderfälle

### Ungerade Anzahl an Spielern beim Auslosen der Spiele
Ist die Anzal der Spieler kein Vielfaches von 2 oder eine ungerade Anzahl, so kommt es beim Auslosen von Spielen zu der Situation, in der ein Spieler fehlt. Eine der folgenden Möglichkeiten ist in diesem Fall zu wählen:

1. Der zuletzt ausgeloste Spieler spielt gegen einen Dummy, der im Gewinnfall nicht in die nächste Runde kommt
2. Der zuletzt ausgeloste Spieler spielt gegen sich selbst und erhält somit ein Freilos.
