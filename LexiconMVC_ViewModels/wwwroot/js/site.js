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

$("#delete").on('click', function () {
    var ID = $("#inputId").val(); //retrieve id from textbox with id
    console.log(ID);
    $.ajax //Create Ajax call
        ({
            type: "POST", // Here we will use  "GET" method, as we are getting data
            url: "/Ajax/Delete", // Url of service/controller
            // dataType: "json", //Datatype 

            data: { id: ID },//This is how we post data inside braces like {fieldName: value, fieldName2: value and so on}
            success: function (result) { //results returned from server on success
                //Do something
                var msg = "Deleted from system";
                $("#people").html(result + msg);
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


// setup typewriter effect in the about section
if (document.getElementsByClassName('demo').length > 0) {
    var i = 0;
    var txt = `Core information... 
            [Entry mode; press Ctrl+D to save and quit; press Ctrl+C to quit without saving]
            #TODO: Get a garden, play more with the dogs, write even better code 
            - Name = Johan Daniel Ivarsson
            - Age = 40
            - Location = Gamlestaden, Gothenburg
            - Interests = Dogs, plants and coding
            - Languages = C#, JS, PHP, Java, SQL
            - Tech = HTML, CSS, SASS, XML, CCNA, Linux ...
            - Creative solutions? true
            - Fullstack = true`;
    var speed = 60;

    function typeItOut() {
        if (i < txt.length) {
            document.getElementsByClassName('demo')[0].innerHTML += txt.charAt(i);
            i++;
            setTimeout(typeItOut, speed);
        }
    }

    setTimeout(typeItOut, 1400);
}

