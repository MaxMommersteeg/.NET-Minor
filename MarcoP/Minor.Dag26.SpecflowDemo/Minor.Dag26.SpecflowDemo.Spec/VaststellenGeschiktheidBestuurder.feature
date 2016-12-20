#language: Kees de Koning
Feature: Vaststellen Geschiktheid Bestuurder

Om auto’s te verhuren volgens wettelijke bepalingen en om risico’s te vermijden
wil ik, als autoverhuurder,
vast kunnen stellen of iemand een geschikte bestuurder is

Scenario Outline: Vaststellen geschiktheid bestuurder
Een geschikte bestuurder is 
 - bij de aanvang van huur minimaal 21 jaar oud
 - in het bezit van een geldig rijbewijs (voor gehele huurperiode)
 - niet afkomstige uit een risicoland

Given de aanvang van de huurperiode is 31 mei 2016
And de risicolanden zijn Malta en Cyprus
And 134654554 is het nummer van een geldig rijbewijs
And 645642356 is het nummer van een ongeldig rijbewijs
When een bestuurder met <Geboortedatum> uit <Land van herkomst> met <rijbewijsnummer> wil een auto huren
Then dan is de bestuurder <uitslag>
Examples:
| Geboortedatum | Land van herkomst | rijbewijsnummer | uitslag                        |
| 31-05-1995    | Nederland         | 134654554       | geschikt                       |
| 01-06-1995    | Nederland         | 134654554       | ongeschikt: te jong            |
| 31-05-1995    | Malta             | 134654554       | ongeschikt: uit een risicoland |
| 31-05-1995    | Nederland         | 645642356       | ongeschikt: ongeldig rijbewijs |


Scenario Outline: Vaststellen geldigheid rijbewijs 
Een rijbewijs is geldig (voor gehele huurperiode) als
 - het rijbewijs ingaat op of voor de eerste dag van de huurperiode
 - het rijbewijs verloopt na de laatste dag van de huurperiode
 - het rijbewijs van type B is
 - het rijbewijs leesbaar is

Given de eerste dag van de huurperiode is 11 mei 2016
And  de laatste dag van de huurperiode is 17 mei 2016
And <rijbewijsnummer> is een <leesbaarheid> rijbewijs
| rijbewijsnummer | leesbaarheid  |
| 134654554       | leesbaar      |
| 293475672       | niet leesbaar |
| 645642356       | leesbaar      |
When het rijbewijs met <rijbewijsnummer>, <ingangsdatum>, <verloopdatum>, <type> en <leesbaarheid> op geldigheid wordt gecontroleerd,
Then is het rijbewijs <uitslag>
Examples:
| rijbewijsnummer | ingangsdatum | verloopdatum | type | uitslag                                          |
| 134654554       | 11 mei 2016  | 11 mei 2026  | B    | geldig                                           |
| 293475672       | 11 mei 2016  | 11 mei 2026  | B    | ongeldig: niet leesbaar                          |
| 645642356       | 12 mei 2016  | 12 mei 2026  | B    | ongeldig: gaat in NA eerste dag huurperiode      |
| 645642356       | 17 mei 2006  | 17 mei 2016  | B    | ongeldig: verloopt OP de laatste dag huurperiode |


Scenario: Vaststellen leesbaarheid rijbewijs 
Een rijbewijs is geldig (voor gehele huurperiode) als
  - het latijns alfabet uitgegeven is,
    of vergezeld is van een internationaal rijbewijs
