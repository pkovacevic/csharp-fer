
$(document).ready(function () {

    // Submit form inside link element.
    function submitChildForm($btn) {
        var $childForm = $btn.children("form");
        $childForm.submit();
    }

    // Support posting to server when clicking to link
    $("a.cw-post-link").click(function () {

        // Wrap click on button in jQuery object.
        var $btn = $(this);

        // Get data-confirm-text attribute value.
        var confirmText = $btn.data("confirm-text");

        // If confirm text was suplied.
        if (confirmText) {

            // Present user with a choice.
            if (confirm(confirmText)) {
                submitChildForm($btn);
            }
        }
        // Submit form without confirmation
        else {
            submitChildForm($btn);
        }
    });


    // Init data table if exists.
    $(".table").DataTable();

});
