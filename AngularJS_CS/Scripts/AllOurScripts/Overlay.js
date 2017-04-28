/* Set the width of the side navigation to 250px */


function openNav() {
    document.getElementById("Overlay").style.width = "100%";
    document.getElementById("Sidenav").style.width = "20%";
    document.body.style.backgroundColor = document.getElementById("head").style.backgroundColor="rgba(0,0,0,0.2)";
    
}
 
/* Set the width of the side navigation to 0 */
function closeNav() {
    document.getElementById("Overlay").style.width = "0";
    document.getElementById("Sidenav").style.width = "0";
    document.body.style.backgroundColor = document.getElementById("head").style.backgroundColor = "white";
}

function isopen() {
    return document.getElementById("Sidenav").style.width == "20%";
}

function navCall() {
    if (isopen())
        closeNav();
    else openNav();
}

function show_messages(id_section) {

}