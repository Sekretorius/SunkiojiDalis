import { connection } from "./canvas"

connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    li.textContent = `${user} says ${message}`;
});


document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = (<HTMLInputElement>document.getElementById("userInput")).value;
    var message = (<HTMLInputElement>document.getElementById("messageInput")).value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});