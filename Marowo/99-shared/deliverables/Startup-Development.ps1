echo "Hallo, welkom bij het development startup programma"
echo ""

echo "Om te beginnen druk op enter"
PAUSE
echo "Ga nu het volgende halen: "
echo ""
echo "- 1 kop koffie"

SLEEP 5

echo "Restoring projects packages with dotnet restore"
cd ../..
dotnet restore

echo "Starting MaRoWo Garage Administratie (Development)"
docker network create marowo_main_network

SLEEP 5

echo "Opening frontend"
start .\Case2.MaRoWo.GarageAdministratie.FrontEnd\Case2.MaRoWo.GarageAdministratie.FrontEnd.sln

SLEEP 5
echo "Opening onderhoudsbeheer"
start .\Case2.MaRoWo.OnderhoudBeheer.Service\Case2.MaRoWo.OnderhoudBeheer.Service.sln

SLEEP 5
echo "Opening rwd integration"
start .\Case2.MaRoWo.RDW.IntegrationService\Case2.MaRoWo.RDW.IntegrationService.sln

SLEEP 5
echo "Opening auditlog"
start .\Minor.RoWe.AuditLog\Minor.RoWe.AuditLog.sln

PAUSE
