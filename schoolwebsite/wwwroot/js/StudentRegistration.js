
function bordercolorchange1() {
    document.querySelector("#fullname").style.borderBottom = "2px solid #198a3e";
}
function borderColorChangeOnMouseLeave1() {
    document.querySelector("#fullname").style.borderBottom = "2px solid #ddd";
}


function bordercolorchange2() {
    document.querySelector("#class").style.borderBottom = "2px solid #198a3e";
}
function borderColorChangeOnMouseLeave2() {
    document.querySelector("#class").style.borderBottom = "2px solid #ddd";
}

function bordercolorchange3() {
    document.querySelector("#roll").style.borderBottom = "2px solid #198a3e";
}
function borderColorChangeOnMouseLeave3() {
    document.querySelector("#roll").style.borderBottom = "2px solid #ddd";
}

function bordercolorchange4() {
    document.querySelector("#section").style.borderBottom = "2px solid #198a3e";
}
function borderColorChangeOnMouseLeave4() {
    document.querySelector("#section").style.borderBottom = "2px solid #ddd";
}

function bordercolorchange5() {
    document.querySelector("#address").style.borderBottom = "2px solid #198a3e";
}
function borderColorChangeOnMouseLeave5() {
    document.querySelector("#address").style.borderBottom = "2px solid #ddd";
}

function bordercolorchange7() {
    document.querySelector("#username").style.borderBottom = "2px solid #198a3e";
}
function borderColorChangeOnMouseLeave7() {
    document.querySelector("#username").style.borderBottom = "2px solid #ddd";
}
function bordercolorchange8() {
    document.querySelector("#password").style.borderBottom = "2px solid #198a3e";
}
function borderColorChangeOnMouseLeave8() {
    document.querySelector("#password").style.borderBottom = "2px solid #ddd";
}
function bordercolorchange6() {
    document.querySelector("#contact").style.borderBottom = "2px solid #198a3e";
}
function borderColorChangeOnMouseLeave6() {
    document.querySelector("#contact").style.borderBottom = "2px solid #ddd";
}
$(function () {
    /*
    $("#datepicker").datepicker({
        dateFormat: "dd-mm-yy",
        showOn: "both",
        buttonText:"Calender",
        yearRange: "1964:",
        changeYear: true,
        changeMonth: true,
        //showOn: ''
    });
    $("#submit").click(function () {
        var datepicker = $("#datepicker").val();
        $("#datepicker").val(datepicker);
        console.log("datepicker value is  " + datepicker);
        console.log(typeof(datepicker));
    });

*/
   
   // $("#datepickeicon").click(function () {
   //     $("#datepicker").datepicker('show');
   // });



    //jsquery validation form

    $("#registration").validate({
        // Specify validation rules
        rules: {
            // The key name on the left side is the name attribute
            // of an input field. Validation rules are defined
            // on the right side
            firstname: {
                required: true,
                minlength: 5
            },
            lastname: "required",
            email: {
                required: true,
                // Specify that email should be validated
                // by the built-in "email" rule
                email: true
            },
            password: {
                required: true,
                minlength: 5
            }
        },
        // Specify validation error messages
        messages: {
            firstname: "Please enter your firstname",
            lastname: "Please enter your lastname",
            password: {
                required: "Please provide a password",
                minlength: "Your password must be at least 5 characters long"
            },
            email: "Please enter a valid email address"
        },
        // Make sure the form is submitted to the destination defined
        // in the "action" attribute of the form when valid
        //submitHandler: function (form) {
        //    form.submit();
        //}
    });

});

