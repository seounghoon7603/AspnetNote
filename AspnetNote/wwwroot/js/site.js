
$(".editor").trumbowyg({
    lang: 'ko',
    btnsDef: {
        image: {
            dropdown: ['insertImage', 'upload'],
            ico:'insertImage'
        }
    },
    btns: [
        ['viewHTML'],
        ['undo', 'redo'], // Only supported in Blink browsers
        ['formatting'],
        ['strong', 'em', 'del'],
        ['superscript', 'subscript'],
        ['link'],
        'image',
        ['justifyLeft', 'justifyCenter', 'justifyRight', 'justifyFull'],
        ['unorderedList', 'orderedList'],
        ['horizontalRule'],
        ['removeformat'],
        ['fullscreen']
    ],
    plugins: {
        upload: {
            // Some upload plugin options, see details below
        }
    }
    /*
    ,
    btns: [
        ['giphy']
    ],
    plugins: {
        giphy: {
            apiKey: 'yourVeryOwnApiKey'
        }
    }
    */
});
$(document).ready(function () {
});