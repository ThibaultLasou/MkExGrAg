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