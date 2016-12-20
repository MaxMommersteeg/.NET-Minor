
$removeContainers = Read-Host 'Wil je ALLE docker containers stoppen en verwijderen? (y/n)'
if($removeContainers -eq 'y'){
	echo "removing docker containers"
	docker stop $(docker ps -a -q)
	docker rm $(docker ps -a -q)
}


echo "Starting MaRoWo Garage Administratie"
echo "Dit kan enkele minuten duren."
echo "Wacht ongeveer 5 minuten en ga dan naar http://localhost:7000"
docker-compose up

PAUSE Enter to exit