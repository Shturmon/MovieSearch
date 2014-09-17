$(document).ready(function () {
    $('.col-md-10').click(function (event) {
        event.preventDefault();

        $('#dialog')
            .dialog({
                title: 'Detail',
                close: function () { $('#dialog').dialog('close'); },
                modal: true,
                autoOpen: false,
                height: 'auto',
                width: 'auto',
            })
            .load(this.href, function () {
                $('#dialog').dialog('open');
            });
    });

    $('.ratting-item').rating(function (vote, event) {
        var anchor = $(event.currentTarget),
                    pid = anchor.closest(".ratting-item").data("pid");
        $.ajax({
                url: "/Movie/Rate",
                type: "POST",
                data: { rate: vote, id: pid },
                error: function(err) {
                    $('#result').text(err);
                }
            })
            .done(function (response) {
                $('#movieRating').html(response);
            });
    });

    $('#commentForm').submit(function (event) {
        event.preventDefault();
        var form = $(this).closest('form');
        var resultMessage = $('#commentResult');
        resultMessage.hide();
        var resultMessageText = $('#commentResultText');

        if (validateComment(form, resultMessageText) == false) {
            resultMessage.fadeIn();
            return false;
        }
        
        var data = $(this).serialize();
        var url = $(this).attr('action');

        $.post(url, data)
            .done(function(response) {
                $('#comments').append(response);
                $('#textArea').val('');
            })
            .fail(function() {
                resultMessageText.html('An error has occurred');
            });
        return true;
    });
});

function Show() {
    $("#dialog:ui-dialog").dialog("destroy");
    $("#dialog-modal").dialog({
        height: 470,
        width: 550,
        modal: true
    });
}

var validateComment = function (commentForm, resultMessage) {
    var isValid = true;
    var errorText = '';

    var body = $('#textArea', commentForm);
    if (body.val().length == 0) {
        errorText += 'The Body field is required.<br />';
        isValid = false;
    }

    if (isValid == false) {
        resultMessage.html(errorText);
    }

    return isValid;
};