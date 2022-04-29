let pets = [];
let connection = null;

let petIdToUpdate = -1;

getdata();
setupSignalR();

async function getdata() {
    await fetch('http://localhost:60557/pet')
        .then(x => x.json())
        .then(y => {
            pets = y;
            //console.log(pets);
            display();
        });
}


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:60557/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("PetCreated", (user, message) => {
        getdata();
    });

    connection.on("PetDeleted", (user, message) => {
        getdata();
    });

    connection.on("PetUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
            await start();
        });
    start();

}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};



function display() {
    document.getElementById("resultArea").innerHTML = "";
    pets.forEach(p => {
        document
            .getElementById("resultArea")
            .innerHTML +=
            "<tr><td>" +
            p.id + "</td><td>" +
            p.vetId + "</td><td>" +
            p.petOwnerId + "</td><td>" +
            p.name + "</td><td>" +
            p.species + "</td><td>" +
            p.weight + "</td><td>" +
            p.age + "</td><td>" +
            p.monthlyCostInHUF + "</td><td>" +
            `<button type="button" onclick="remove(${p.id})">Delete</button>` +
            `<button type="button" onclick="showupdate(${p.id})">Update</button>` +
            "</td ></tr > "
        console.log(p.name);
    });
}


function createPet() {
    let petName = document.getElementById("petname").value;
    let petPetOwnerId = document.getElementById("petpetownerid").value;
    let petVetId = document.getElementById("petvetid").value;
    let petSpecies = document.getElementById("petspecies").value;
    let petWeight = document.getElementById("petweight").value;
    let petAge = document.getElementById("petage").value;
    let petMonthlyCost = document.getElementById("petmonthlycost").value;
    fetch('http://localhost:60557/pet', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                name: petName,
                petOwnerId: petPetOwnerId,
                vetId: petVetId,
                species: petSpecies,
                weight: petWeight,
                age: petAge,
                monthlyCostInHUF: petMonthlyCost
            }),
    })
        .then(response => response)
        .then(data =>
        {
            console.log('Succes:', data);
            getdata();
        })
        .catch((error) => { console.log('Error:', errpr); });
}


function remove(id) {
    //alert(id);
    fetch('http://localhost:60557/pet/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null })
        .then(response => response)
        .then(data => {
            console.log('Succes:', data);
            getdata();
        })
        .catch((error) => { console.log('Error:', errpr); });
}

function showupdate(id) {
    document.getElementById('petToUpdateID').value = id;
    document.getElementById('petnametoupdate').value = pets.find(t => t['id'] == id)['name'];
    document.getElementById('petpetowneridtoupdate').value = pets.find(t => t['id'] == id)['petOwnerId'];
    document.getElementById('petvetidtoupdate').value = pets.find(t => t['id'] == id)['vetId'];
    document.getElementById('petspeciestoupdate').value = pets.find(t => t['id'] == id)['species'];
    document.getElementById('petweighttoupdate').value = pets.find(t => t['id'] == id)['weight'];
    document.getElementById('petagetoupdate').value = pets.find(t => t['id'] == id)['age'];
    document.getElementById('petmonthlycosttoupdate').value = pets.find(t => t['id'] == id)['monthlyCostInHUF'];
    document.getElementById('updateFormDiv').style.display = 'flex';
    document.getElementById('formDiv').style.display = 'none';
    petIdToUpdate = id;
}

function update() {
    let petName = document.getElementById("petnametoupdate").value;
    let petPetOwnerId = document.getElementById("petpetowneridtoupdate").value;
    let petVetId = document.getElementById("petvetidtoupdate").value;
    let petSpecies = document.getElementById("petspeciestoupdate").value;
    let petWeight = document.getElementById("petweighttoupdate").value;
    let petAge = document.getElementById("petagetoupdate").value;
    let petMonthlyCost = document.getElementById("petmonthlycosttoupdate").value;
    fetch('http://localhost:60557/pet', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                id: petIdToUpdate,
                name: petName,
                petOwnerId: petPetOwnerId,
                vetId: petVetId,
                species: petSpecies,
                weight: petWeight,
                age: petAge,
                monthlyCostInHUF: petMonthlyCost
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Succes:', data);
            getdata();
        })
        .catch((error) => { console.log('Error:', errpr); });

    document.getElementById('updateFormDiv').style.display = 'none';
    document.getElementById('formDiv').style.display = 'flex';
}