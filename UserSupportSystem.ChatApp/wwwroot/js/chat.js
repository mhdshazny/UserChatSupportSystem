"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();


connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    li.textContent = `${user} : ${message}`;
});

connection.on("JoinGroup", function (message,groupid) {
    var li = document.createElement("li");
    var groupName = document.getElementById("group-name").value = groupid;
    document.getElementById("messagesList").appendChild(li);
    //document.getElementById("group-name").append(groupName);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    li.textContent = `${message}`;
    //groupName.value = `${groupid}`;

    if (groupid != null || groupid != '')
            document.getElementById("sendButton").disabled = false;

});

connection.start().then(function () {
    //document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    var groupname = document.getElementById("group-name").value;
    connection.invoke("SendMessage", user, message, groupname).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

document.getElementById("join-group").addEventListener("click", async (event) => {
    var user = document.getElementById("userInput").value;
    var groupName = document.getElementById("group-name").value;
    if ((user != null & user != "") && (groupName == null & groupName == '')) {
        try {
            await connection.invoke("AddToGroup", user, null);
        }
        catch (e) {
            console.error(e.toString());
        }
        event.preventDefault();
    }
    else if ((user != null & user != "")/* && (groupName == null || groupName == '')*/)
    {
        try {
            await connection.invoke("AddToGroup", user, groupName);
        }
        catch (e) {
            console.error(e.toString());
        }
        event.preventDefault();
    }
});