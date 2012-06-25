Die Linq Abfragen befinden sich alle in der Datei CalenderApp.cs

Durch die Linq Abfragen werden Objekte (Termine / Aufgaben) nach verschiedenen Kriterien gefiltert.
Zuerst wird eine Vorauswahl nach Typ getroffen, je nachdem welchen Radiobutton der Benutzer in der
UI ausgew�hlt hat. Anschlie�end wird eine komplexere Abfrage mit einem zusammengesetzten Pr�dikat
ausgef�hrt, wobei mehrere Eigenschaften der Objekte �berpr�ft werden. Diese Pr�fung geschieht durch
ein Regex matching.

Dadurch sind die gefilterten Ergebnisse stets inkrementell gefiltert. Zuerst greift die Typfilterung
und danach erst der Regex.