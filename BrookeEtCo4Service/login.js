function getInfo() {
    var username = document.getElementById("txtCourriel").value
    var password = document.getElementById("txtPassword").value

    for (i = 0; i < objPeople.length; i++)
}

function onSignIn(googleUser) {    
    var profile = googleUser.getBasicProfile();
    console.log('ID: ' + profile.getId()); // Do not send to your backend! Use an ID token instead.
    console.log('Name: ' + profile.getName());
    console.log('Image URL: ' + profile.getImageUrl());
    console.log('Email: ' + profile.getEmail()); // This is null if the 'email' scope is not present.
    var id_token = googleUser.getAuthResponse().id_token;
    console.log(id_token);
    if (profile.getName != "NULL" || "") {
        location.href = "http://localhost:56408/AllProducts.html";
    }
}

function signOut() {
    var auth2 = gapi.auth2.getAuthInstance();
    auth2.signOut().then(function () {
        console.log('User signed out.');
    });    
}