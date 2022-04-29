let vets = [];
let connection = null;

let vetIdToUpdate = -1;

getdata();
setupSignalR();

async function getdata() {
    await fetch('http://localhost:60557/vet')
        .then(x => x.json())
        .then(y => {
            vets = y;
            //console.log(pets);
            display();
        });
}


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:60557/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("VetCreated", (user, message) => {
        getdata();
    });

    connection.on("VetDeleted", (user, message) => {
        getdata();
    });

    connection.on("VetUpdated", (user, message) => {
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
    vets.forEach(p => {
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


function createVet() {
    let vetName = document.getElementById("vetname").value;
    let vetPhoneNumber = document.getElementById("vetphonenumber").value;
    let vetSalary = document.getElementById("vetsalary").value;
    let vetAge = document.getElementById("vetage").value;
    fetch('http://localhost:60557/vet', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                name: vetName,
                phoneNumber: vetPhoneNumber,
                salaryInHUF: vetSalary,
                age: vetAge,
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
    fetch('http://localhost:60557/vet/' + id, {
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
    document.getElementById('vetToUpdateID').value = id;
    document.getElementById('vetToUpdatename').value = vets.find(t => t['id'] == id)['name'];
    document.getElementById('vetToUpdatephonenumber').value = vets.find(t => t['id'] == id)['phoneNumber'];
    document.getElementById('vetToUpdateage').value = vets.find(t => t['id'] == id)['age'];
    document.getElementById('vetToUpdatesalary').value = vets.find(t => t['id'] == id)['salaryInHUF'];
    document.getElementById('updateFormDiv').style.display = 'flex';
    document.getElementById('formDiv').style.display = 'none';
    vetIdToUpdate = id;
}

function update() {
    let vetName = document.getElementById("vetToUpdatename").value;
    let vetPhoneNumber = document.getElementById("vetToUpdatephonenumber").value;
    let vetSalary = document.getElementById("vetToUpdatesalary").value;
    let vetAge = document.getElementById("vetToUpdateage").value;
    fetch('http://localhost:60557/vet', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                id: vetIdToUpdate,
                name: vetName,
                phoneNumber: vetPhoneNumber,
                age: vetAge,
                salaryInHUF: vetSalary,
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