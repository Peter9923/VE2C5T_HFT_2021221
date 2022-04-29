let petowners = [];
let connection = null;

let petownerIdToUpdate = -1;

getdata();
setupSignalR();

async function getdata() {
    await fetch('http://localhost:60557/petowner')
        .then(x => x.json())
        .then(y => {
            petowners = y;
            //console.log(pets);
            display();
        });
}


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:60557/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("PetOwnerCreated", (user, message) => {
        getdata();
    });

    connection.on("PetOwnerDeleted", (user, message) => {
        getdata();
    });

    connection.on("PetOwnerUpdated", (user, message) => {
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
    petowners.forEach(p => {
        document
            .getElementById("resultArea")
            .innerHTML +=
            "<tr><td>" +
            p.id + "</td><td>" +
            p.name + "</td><td>" +
            p.phoneNumber + "</td><td>" +
            p.age + "</td><td>" +
            p.salaryInHUF + "</td><td>" +
            `<button type="button" onclick="remove(${p.id})">Delete</button>` +
            `<button type="button" onclick="showupdate(${p.id})">Update</button>` +
            "</td ></tr > "
        console.log(p.name);
    });
}


function createPetOwner() {
    let petOwnerName = document.getElementById("petownername").value;
    let petOwnerPhoneNumber = document.getElementById("petownerphonenumber").value;
    let petOwnerSalary = document.getElementById("petownerage").value;
    let petOwnerAge = document.getElementById("petownersalary").value;
    fetch('http://localhost:60557/petowner', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                name: petOwnerName,
                phoneNumber: petOwnerPhoneNumber,
                salaryInHUF: petOwnerSalary,
                age: petOwnerAge,
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Succes:', data);
            getdata();
        })
        .catch((error) => { console.log('Error:', errpr); });
}


function remove(id) {
    //alert(id);
    fetch('http://localhost:60557/petowner/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Succes:', data);
            getdata();
        })
        .catch((error) => { console.log('Error:', errpr); });
}

function showupdate(id) {
    document.getElementById('petownerToUpdateID').value = id;
    document.getElementById('petownerToUpdatename').value = petowners.find(t => t['id'] == id)['name'];
    document.getElementById('petownerToUpdatephonenumber').value = petowners.find(t => t['id'] == id)['phoneNumber'];
    document.getElementById('petownerToUpdateage').value = petowners.find(t => t['id'] == id)['age'];
    document.getElementById('petownerToUpdatesalary').value = petowners.find(t => t['id'] == id)['salaryInHUF'];
    document.getElementById('updateFormDiv').style.display = 'flex';
    document.getElementById('formDiv').style.display = 'none';
    petownerIdToUpdate = id;
   
}

function update() {
    let petownerName = document.getElementById("petownerToUpdatename").value;
    let petownerPhoneNumber = document.getElementById("petownerToUpdatephonenumber").value;
    let petownerSalary = document.getElementById("petownerToUpdatesalary").value;
    let petownerAge = document.getElementById("petownerToUpdateage").value;
    fetch('http://localhost:60557/petowner', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                id: petownerIdToUpdate,
                name: petownerName,
                phoneNumber: petownerPhoneNumber,
                age: petownerAge,
                salaryInHUF: petownerSalary,
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