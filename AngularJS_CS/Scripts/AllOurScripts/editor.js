var html = '';
var editors = [];
function createEditor(i) {

    if (editors[i])
    {
        return;
    }

    html = document.getElementById('editor'+i).textContent;

    // Create a new editor instance inside the <div id="editor"> element,
    // setting its value to html.
    var config = {};
    editors[i] = CKEDITOR.replace('editor'+i, config, html);

    // Update button states.
    document.getElementById('remove_'+i).style.display = '';
    document.getElementById('create_'+i).style.display = 'none';
}

function removeEditor(i) {
    if (!editors[i])
    {
        return;
    }
    // Retrieve the editor content. In an Ajax application this data would be
    // sent to the server or used in any other way.
    html = editors[i].getData();

    // Update <div> with "Edited Content".
    document.getElementById('editor'+i).innerHTML = html;
    // Show <div> with "Edited Content".
    //document.getElementById('content1').style.display = '';
    // Update button states.
    document.getElementById('remove_'+i).style.display = 'none';
    document.getElementById('create_'+i).style.display = '';

    // Destroy the editor.
    editors[i].destroy();
    editors[i] = null;
}