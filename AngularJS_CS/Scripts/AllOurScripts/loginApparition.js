$('#loginform').click(function ()
{
    $('#hidden_div').removeClass('hidden');
    $('.formholder').fadeToggle('slow');
});

$(document).mouseup(function (e)
{
    var container = $(".formholder");

    // Si la cible du clic n'est pas le conteneur ou l'un de ses descendants, on le ferme
    if (!container.is(e.target) && container.has(e.target).length === 0)
        container.hide();
});