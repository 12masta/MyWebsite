$(document).ready(function () {
    $("#contactButton").click(function () {
        if ($("#contact-section").hasClass("hidden")) {
            $("#contact-section").removeClass();
        } else {
            $("#contact-section").addClass("hidden");
        }
    });
});

$(document).ready(function () {
    $("#contact-submit").click(function () {
        var url = "/Home/SendEmailAsync";
        var name = $("#name").val();
        var email = $("#email").val();
        var subject = $("#subject").val();
        var message = $("#message").val();        
        var $form = $('form');
        if ($form.valid()) {
            $.post(url, { name: name, email: email, subject: subject, message: message });
            $.notify({
                icon: 'glyphicon glyphicon glyphicon-ok',
                message: 'Message was sent. Thank you for a message :)'
            }, {
                offset: {
                    x: 20,
                    y: 90
                },
                type: 'success'
            });
        }
        else {
            $.notify({
                icon: 'glyphicon glyphicon-warning-sign',
                message: 'Message was not sent, please fill fields with correct values'
            }, {
                offset: {
                    x: 20,
                    y: 90
                },
                type: 'danger'             
            });
        }
    });
});
