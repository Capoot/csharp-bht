Die Linq Abfragen befinden sich alle in der Datei CalenderApp.cs

Durch die Linq Abfragen werden Objekte (Termine / Aufgaben) nach verschiedenen Kriterien gefiltert.
Zuerst wird eine Vorauswahl nach Typ getroffen, je nachdem welchen Radiobutton der Benutzer in der
UI ausgewählt hat. Anschließend wird eine komplexere Abfrage mit einem zusammengesetzten Prädikat
ausgeführt, wobei mehrere Eigenschaften der Objekte überprüft werden. Diese Prüfung geschieht durch
ein Regex matching.

Dadurch sind die gefilterten Ergebnisse stets inkrementell gefiltert. Zuerst greift die Typfilterung
und danach erst der Regex.