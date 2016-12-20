#language Van de klant (en-GB/nl-NL)
Feature: Vaststellen geschiktheid bestuurder
als verhuurder
wil ik de geschiktheid van een bestuurder vaststellen
om te voldoen aan de wet en risico's te vermijden
Scenario Outline: Geldigheid rijbewijs bestuurder controle
Given Is minimaal 21 jaar oud
When bestuurder met <RIJBEWIJSTYPE> en komt uit <LAND RIJBEWIJSUITGIFTE> en heeft een <RIJBEWIJS TAAL>
Then is het rijbewijs <OUTPUT MESSAGE>

| RIJBEWIJSTYPE | LAND RIJBEWIJSUITGIFTE | RIJBEWIJS TAAL  | OUTPUT MESSAGE                                               |
| B             | Nederland              | Latijns schrift | geldig                                                       |
| B             | Nederland              | internationaal  | geldig                                                       |
| A             | Nederland              | Latijns schrift | ongeldig want de bestuurder heeft een verkeerd rijbewijstype |
| B             | Cyprus                 | Latijns schrift | ongeldig want de bestuurder komt uit een risicoland Cyprus   |
| B             | Malta                  | Latijns schrift | ongeldig want de bestuurder komt uit een risicoland          |
| B             | Nederland              | Chinees         | ongeldig want de rijbewijstaal is incorrect                  |


Scenario Outline: Vaststellen geschiktheid bestuurder met vaste data
Given vandaag is het 25-10-2016
And de huurperiode begint op 26-10-2016
And de huurperiode eindigd op 29-10-2016
When bestuurder is <AGE> met <RIJBEWIJS GELDIGHEID> welke geldig is tot <VERLOOPDATUM RIJBEWIJS>
Then bestuurder is <OUTPUT MESSAGE>

| AGE | RIJBEWIJS GELDIGHEID | VERLOOPDATUM RIJBEWIJS | OUTPUT MESSAGE                                                              |
| 21  | Geldig               | 30-10-2016             | geschikt                                                                    |
| 20  | Geldig               | 30-10-2016             | ongeschikt want de bestuurder is te jong                                    |
| 21  | Ongeldig             | 30-10-2016             | ongeschikt want het rijbewijs is ongeldig                                   |
| 21  | Geldig               | 28-10-2016             | ongeschikt want het rijbewijs is verlopen voor het einde van de huurperiode |







