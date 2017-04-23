/* Set the width of the side navigation to 250px */


function openNav() {
    document.getElementById("Sidenav").style.width = "20%";
    document.body.style.backgroundColor = "rgba(0,0,0,0.4)";
}
 
/* Set the width of the side navigation to 0 */
function closeNav() {
    document.getElementById("Sidenav").style.width = "0";
    document.body.style.backgroundColor = "white";
}

function isopen() {
    return document.getElementById("Sidenav").style.width == "20%";
}

function navCall() {
    if (isopen())
        closeNav();
    else openNav();
}