function removeElement(element) {    
    element.remove();
}

function showMessage(messageType, message) {
    var div = document.getElementById("messageDiv");
    div.innerHTML = "<div class=\"shadow p-3 mb-5 rounded alert alert-" + messageType + " border border-" + messageType + "\">" + message + "</div >";
    setTimeout(function () {
        div.innerHTML = "";
    }, 7000);
}

