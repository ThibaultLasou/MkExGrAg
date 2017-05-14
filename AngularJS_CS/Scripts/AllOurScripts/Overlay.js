/* Set the width of the side navigation to 250px */


function openNav() {
    document.getElementById("Overlay").style.width = "100%";
    document.getElementById("Sidenav").style.width = "20%";
    document.body.style.backgroundColor = document.getElementById("head").style.backgroundColor = "rgba(0,0,0,0.2)";

}

/* Set the width of the side navigation to 0 */
function closeNav() {
    document.getElementById("Overlay").style.width = "0";
    document.getElementById("Sidenav").style.width = "0";
    document.body.style.backgroundColor = document.getElementById("head").style.backgroundColor = "white";
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

function customtype(){
    document.getElementById("type_choice").value = '4';
}

function show_messages(id_section) {

}

function submitFormWithModel(id, url, sujet, dest, rep, repChosen) {
    $.ajax({
        url: '@Url.Action("Retorque", "Question")',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify({
            mod: {
                Id_message: id,
                ActualUrl: url,
                Subject: sujet,
                Dest: dest,
            }
        })
    });
}