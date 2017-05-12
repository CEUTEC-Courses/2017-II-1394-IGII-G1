﻿
$(document).ready(function () {
    moment.locale("es");
});


$("*[data-class='ClaseNumber']").on("keypress", function (e) {
    if (!isNumberKey(e)) e.preventDefault();
})

function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))return false;
    return true;
}


function ShowboxError(message, title) {
    $.smallBox({
        title: title,
        content: message,
        color: "#C46A69",
        timeout: 20000,
        icon: "fa fa-warning shake animated"
    });
}

function ShowboxSuccess(message, title) {
    $.smallBox({
        title: title,
        content: message,
        color: "#739E73",
        timeout: 20000,
        icon: "fa fa-check shake animated"
    });
}

function ShowSmartAlert(Title, message, Funcion) {
    $.SmartMessageBox({
        title: Title,
        content: message,
        buttons: '[No][Yes]'
    }, function (ButtonPressed) {
        if (ButtonPressed === "Yes") {
            Funcion();
        }
        if (ButtonPressed === "No") {

        }
    });
}

function ShowForgotPassword()
{
    $.ajax({
        url: '/Account/ForgotPassword',
        type: "GET",
        success: function (data) {
            $("#MyModalBodyClean").html(data);
            $("#MyModalClean").modal("show");
           
        },
        error: function (data) {
            alert("error");
        }
    });

}


function ShowChangePasswordUserLogged() {
    $.ajax({
        url: "/Manage/ChangePassword",
        type: "GET",
        success: function (data) {
            $("#MyModalBodyClean").html(data);
            $("#MyModalClean").modal("show");
        },
        error: function (data) {
            alert("error");
        }
    });
}

function ShowboxWarning(message, title) {
    $.smallBox({
        title: title,
        content: message,
        color: "#E3A225",
        timeout: 10000,
        icon: "fa fa-warning shake animated"
    });
}



function  LoadWaitNotification() {
    $("#modalWaitingTime").modal({ backdrop: 'static', keyboard: false }, "show");
    $('#statusID').fadeIn();
}

function UnloadWaitNotification() {
    $("#modalWaitingTime").modal("hide");
    $('#statusID').hide();
}

