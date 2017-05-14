/* Set the width of the side navigation to 250px */


function openNav() {
    document.getElementById("Overlay").style.width = "100%";
    document.getElementById("Sidenav").style.width = "20%";

}

/* Set the width of the side navigation to 0 */
function closeNav() {
    document.getElementById("Overlay").style.width = "0";
    document.getElementById("Sidenav").style.width = "0";
}

function isopen() {
    return document.getElementById("Sidenav").style.width === "20%";
}

function navCall() {
    if (isopen())
        closeNav();
    else openNav();
}
function newDestin(value) {
    if (document.getElementById("destbox").value === '')
        document.getElementById("destbox").value = document.getElementById("destinchoi")[value].innerText + ';';
    else document.getElementById("destbox").value = document.getElementById("destbox").value + document.getElementById("destinchoi")[value].innerText + ';';
    document.getElementById("destinchoi").value = '';
}
function newDestgr(value) {
    if (document.getElementById("destbox").value === '')
        document.getElementById("destbox").value = document.getElementById("destgrchoi")[value].innerText + ';';
    else document.getElementById("destbox").value = document.getElementById("destbox").value + document.getElementById("destgrchoi")[value].innerText + ';';
    document.getElementById("destgrchoi").value = '';
}
function typechose(value) {
    document.getElementById("rep_list").value = "";
    switch (value) {
        case "1":
            document.getElementById("rep_list").options[1].selected = true;
            document.getElementById("rep_list").options[0].selected = true;
            break;
        case "2":
            document.getElementById("rep_list").options[0].selected = true;
            document.getElementById("rep_list").options[1].selected = true;
            document.getElementById("rep_list").options[2].selected = true;
            document.getElementById("rep_list").options[3].selected = true;
            break;
        case "3":
            document.getElementById("rep_list").options[4].selected = true;
            document.getElementById("rep_list").options[5].selected = true;
            document.getElementById("rep_list").options[6].selected = true;
            document.getElementById("rep_list").options[7].selected = true;
            document.getElementById("rep_list").options[9].selected = true;
            document.getElementById("rep_list").options[8].selected = true;
            break;
        case "4":
        default:
    }
}

function customtype() {
    document.getElementById("type_choice").value = '4';
}

function questionswitch(checkbocElem) {
    if (checkbocElem.checked) {
        document.getElementById("contentarea").style.width = "100%";
        document.getElementById("Title").textContent = "Nouveau Message";
        document.getElementById("rep_list").style.height = "0%";
        document.getElementById("rep_list").style.width = "25%";
        document.getElementById("type_choice").style.visibility = "hidden";
        document.getElementById("rep_list").style.visibility = "hidden";
        document.getElementById("repZone").style.visibility = "hidden";
        document.getElementById("type_choice").value = '4';
        //document.getElementById("rep_list").required = "False";
    }
    else {
        document.getElementById("contentarea").style.width = "74%";
        document.getElementById("Title").textContent = "Nouveau Questionnaire";
        document.getElementById("rep_list").style.height = "400px";
        document.getElementById("rep_list").style.width = "25%";
        document.getElementById("type_choice").style.visibility = "visible";
        document.getElementById("rep_list").style.visibility = "visible";
        document.getElementById("repZone").style.visibility = "visible";
        document.getElementById("type_choice").value = "";
        //document.getElementById("rep_list").required = "True";
    }
}
function show_messages(id_section) {

}