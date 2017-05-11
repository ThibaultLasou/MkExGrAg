$('#repform').click(function () {
    $('#hidden_divrep').removeClass('hidden');
    $('.formrepholder').fadeToggle('slow');
});

$(document).mouseup(function (e) {
    var container = $(".formrepholder");

    // Si la cible du clic n'est pas le conteneur ou l'un de ses descendants, on le ferme
    if (!container.is(e.target) && container.has(e.target).length === 0)
        container.hide();
});

$('#rep_list').change(function () {
    document.getElementById("type_choice").value = '4';
    $('#type_choice').value = '4';
});