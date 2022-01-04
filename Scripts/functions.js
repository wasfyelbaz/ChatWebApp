function deleteChild() {

    var messages = document.getElementById("messages");

    var child = messages.lastElementChild;

    while (child) {
        messages.removeChild(child);
        child = messages.lastElementChild;
    }
}

var btn = document.getElementById(
    "submit").onclick = function () {
        deleteChild();
    }

// test@test.test:Test@1test