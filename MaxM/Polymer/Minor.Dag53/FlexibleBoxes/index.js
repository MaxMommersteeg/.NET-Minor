var tripsKey = 'trips';

function initTrips() {
    window.localStorage.setItem(tripsKey, undefined);

    var trips = [
    {
        title: 'Rome',
        description: 'Had a great time, good food and splendid weather.',
        tripDate: '12/5/2005'
    },
    {
        title: 'London',
        description: 'Best holiday ever, plenty free museums, history on every street corner and the weather wasn\'t that bad.',
        tripDate: '4/1/1989'
    },
    {
        title: 'Madrid',
        description: 'Great town, too many tourists, very hot summer',
        tripDate: '7/5/2005'
    },
    {
        title: 'Los Angeles',
        description: 'Huge town, make sure you know a couple of natives that can show you around, nice climate.',
        tripDate: '4/9/2011'
    }
    ];
    window.localStorage.setItem(tripsKey, JSON.stringify(trips));
}

function loadTrips () {
    var trips = JSON.parse(window.localStorage.getItem(tripsKey));
    for(var i = 0; i < trips.length; i++) {
        console.log(trips[i].title);
        console.log(trips[i].description);
        console.log(trips[i].tripDate);
        console.log('-------------------------------');
    }
}