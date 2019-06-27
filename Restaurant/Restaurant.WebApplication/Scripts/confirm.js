function ConfirmDialog(options) {
    this.ConfimButtonClasses = options.ConfimButtonClasses || "btn btn-success";
    this.DeclineButtonClasses = options.DeclineButtonClasses || "btn btn-danger";
    this.ModalSizeClasses = options.DeclineButtonClasses || "btn btn-danger";
}

ConfirmDialog.prototype.ShowDialog = function (title, message, titleButtonTrue, titleButtonFalse, yesCallback, noCallback) {
    var content =
        "<div class='confirm'>" +
            "<div class='confirm-popup confirm-xs'>" +
                "<div class='content'>" +
                    "<div class='confirm-header'>" +
                        "<button type='button' class='close' data-dismiss='modal' aria-label='Close'><span aria-hidden='true'></span></button>" +
                        "<p class='confirm-title'>" + title + "</p>" +
                    "</div>" +
                    "<div class='confirm-body font-size-md'>" +
                        "<p>" + message + "</p>" +
                    "</div>" +
                    "<div class='confirm-popup-footer '>" + "<div class='row'>" +
                        "<div class = 'col-xs-6'>" +
                            '<button class="cancelAction btn-lg btn-big-lg ' + this.DeclineButtonClasses + '" > ' + titleButtonFalse + '</button > ' +
                       "</div>" +
                        "<div class = 'col-xs-6'>" +
                            '<button class="doAction btn-lg btn-big-lg right ' + this.ConfimButtonClasses + '">' + titleButtonTrue + '</button>' +
                       "</div>" + "</div>" +
                    "</div>" +
                "</div>" +
            "</div>" +
        "</div>";
    $('body').prepend($(content));

    $('.doAction').on('click', function () {
        closeConfirmDialog($(this));
        yesCallback();
    });
    $('.cancelAction').click(function () {
        closeConfirmDialog($(this));
        noCallback();
    });
    function closeConfirmDialog(clickedButton) {
        clickedButton.parents('.content').fadeOut(200, function () {
            $(this).closest('.confirm').remove();
        });
    }
};
