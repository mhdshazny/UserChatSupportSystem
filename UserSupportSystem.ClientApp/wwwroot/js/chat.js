////"use strict";

//const { signalR } = require( import "./signalr/dist/browser/signalr.js");

//const { signalR } = require("./signalr/dist/browser/signalr");

//const { signalR } = require("/browser/signalr.js");
//const { signalR } = require("/browser/signalr.min.js");

//var connection = new signalR.HubConnectionBuilder.withUrl("/chatHub").build();

//document.getElementById("btnSend").disabled = true;

//connection.on("RecieveMessage", function (user, message) {
//    var msgLi = document.createElement("msgLi");
//    document.getElementById("messages").appendChild(msgLi);

//    msgLi.textContent = '${ user } - ${ message }';
//});

//connection.start().then(function () {
//    document.getElementById("btnSend").disabled = false;
//}).catch(function (err) {
//    return console.error(err.toString());
//});

//document.getElementById("btnSend").addEventListener("click", function (event)
//{
//    var user = document.getElementById("userInput").value;
//    var message = document.getElementById("messageInput").value;
//    connection.invoke("sendMessage", user, message).catch(function(err)
//    {
//        return console.error(err.toString());
//    })
//    event.preventDefault();
//})