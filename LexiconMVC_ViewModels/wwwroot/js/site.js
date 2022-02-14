// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$("#details").on('click', function () {
    var ID = $("#inputId").val(); //retrieve id from textbox with id
    console.log(ID);
    $.ajax //Create Ajax call
        ({
            type: "GET", // Here we will use  "GET" method, as we are getting data
            url: "/People/Details", // Url of service/controller
            // dataType: "json", //Datatype 

             data: { id: ID },//This is how we post data inside braces like {fieldName: value, fieldName2: value and so on}
            success: function (result) { //results returned from server on success
                //Do something
                $("#people").html(result);
            },
            error: function () {
                //something went wrong 
                alert("Error")
            }
        })
})

$("#showPeople").on('click', function () {
    var ID = $("#inputId").val(); //retrieve id from textbox with id
    console.log(ID);
    $.ajax //Create Ajax call
        ({
            type: "GET", // Here we will use  "GET" method, as we are getting data
            url: "/Ajax/People", // Url of service/controller
           // dataType: "json", //Datatype 

           // data: { id: ID },//This is how we post data inside braces like {fieldName: value, fieldName2: value and so on}
            success: function (result) { //results returned from server on success
                //Do something
                $("#people").html(result);
            },
            error: function () {
                //something went wrong 
                alert("Error")
            }
        })
})

function submitDeleteForm() {
    alert("test");
    document.getElementById('formTest').submit();
}
