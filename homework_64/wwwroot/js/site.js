// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $("#password-view").on("click", function () {
        var type = $("#password").attr('type') === "text" ? "password" : "text";
        $("#password").prop('type', type);
    });

    $("#confirm-view").on("click", function () {
        var type = $("#confirm").attr('type') == "text" ? "password" : "text";
        $("#confirm").prop('type', type);
    });
    
    $("#password-view-login").on("click", function () {
        var type = $("#login-password").attr('type') == "text" ? "password" : "text";
        $("#login-password").prop('type', type);
    });

    let name = document.querySelector('#message');
    name.oninput = function () {
        this.value = this.value.substr(0, 150);
    }

    setInterval(updateMessages, 5000);
    function updateMessages() {
        fetch('https://localhost:5001/chat/getmessages', {
            method: 'get'
        }).then(response => {
            console.log(response);
            return response.text();
        }).then(text => {
            $(`div[id=messages]`).html(text);
            $("#message").val("");
            console.log(123)
        }).catch((error) => {
            alert(error);
        });
    }

    $('#post-message-form').on('submit', function (submitEvent){
        submitEvent.preventDefault();
        var value = $("#message").val();
        console.log(value);
        fetch('https://localhost:5001/chat/addmessage', {
            method: 'post',
            body: JSON.stringify({id: '0', description: value}),
            headers: {'content-type': 'application/json'}
        }).then(response => {
            console.log(response);
            return response.text();
        }).then(text => {
            $(`div[id=messages]`).html(text);
            $("#message").val("");
        }).catch((error) => {
            alert(error);
        });
    });
})
