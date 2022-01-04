function deleteChild() {

    var messages = document.getElementById("messages");

    var child = messages.lastElementChild;

    while (child) {
        messages.removeChild(child);
        child = messages.lastElementChild;
    }
}

var submitBtn = document.getElementById(
    "submit").onclick = function () {
        deleteChild();
        //document.getElementById('msg').value = '';
    }

var refreshBtn = document.getElementById(
    "refresh").onclick = function () {
        deleteChild();
    }

var refresh = document.getElementById("refresh");
setInterval(function () { refresh.click(); }, 10000);

// test@test.test:Test@1test