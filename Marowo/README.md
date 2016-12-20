# Case2
Case 2 .NET Minor

## Algemeen
Alle applicaties binnen deze repository bevatten hun eigen database voor het persisteren van data. Dit betreft in alle gevallen een SQL SERVER database van Microsoft. Wijs minimaal 4096MB RAM toe aan Docker. Dit is een vereiste van SQL SERVER.

Naast het toewijzen van RAM, moet via Docker de C-schijf worden gedeeld. Zowel RAM toewijzen als delen van de C-schijf kan worden ingesteld middels de Docker applicatie voor Windows.

Een Docker netwerk wordt gebruikt om de verschillende Docker containers met elkaar te kunnen laten communiceren. Dit netwerk moet handmatig worden aangemaakt. Voer volgende commando uit (cmd/powershell):

`docker network create marowo_main_network`

## Deployment
Navigeer naar de `Total` map in deze repository. Voer volgende commando uit (cmd/powershell):

`docker-compose up`

## Debugging
Volgorde van opstarten applicaties:

1. AuditLog solution
2. OnderhoudBeheer Service solution
3. Rdw Integration Service solution
4. GarageAdministratie Front end solution

Om te verbinden met de database kun je in sql server management studio de volgende connection gebruiken:

Server name: localhost,{poort}

Authentication: Sql server Authentication

Login: sa

Password: P@55w0rd

## Poorten
### GarageAdministratie FrontEnd
| Type 	    | Debug | Release |
|-----------|-------|---------|
| Webpage   | 8001  | 7000    |
| Database  | 9001  | 7001    |

### OnderhoudBeheer Service
| Type 	    | Debug | Release |
|-----------|-------|---------|
| Webapi    | 8002  | 7003    |
| Database  | 9004  | 7002    |

### RDW IntegrationService
| Type 	    | Debug | Release |
|-----------|-------|---------|
| Webapi    | 8000  | 7005    |
| Database  | 9000  | 7004    |

### Auditlog
| Type 	     | Debug | Release |
|------------|-------|---------|
| Management | 15673 | 7007    |
| Database   | 9002  | 7006    |
