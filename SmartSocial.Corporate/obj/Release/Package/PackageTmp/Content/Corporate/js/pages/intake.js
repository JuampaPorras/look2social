$("#idWizardFormMore").validate(); // Initialize Validator
$(document).ready(function () {
    $("#btnFinishMore").click(function () {
        //Validates last TAB. Next button validation is done at moreInformation.js
        if ($("#idWizardFormMore").valid()) {
            SendSecondStep();
        }
        else {
            $("#idWizardFormMore").validate().focusInvalid();
        }
    });
});

function SendSecondStep() {
    /*var pathString = window.location.pathname;
    if (pathString.length > 0) {
        if (pathString.charAt(pathString.length - 1) == '/') {
            pathString = pathString.slice(0, -1);
        }
    }*/
    var token = decodeURIComponent(window.location.search.match(/(\?|&)token\=([^&]*)/)[2]);//jQuery.getUrlVar('token');
    
    var myFormData;
    
    myFormData = {
        token: token,
        //TODO actualizar los fields
        firstName: $("#txtFirstName").val(),
        lastName: $("#txtLastName").val(),
        countryCode:$("#ddlCountryCode").val(),
        phoneNumber: $("#txtPhoneNumber").val(),
        email: $("#txtWorkEmail").val(),
        //From the new step 
        aliases: $("#txtAliases").val(),
        keywords: $("#txtKeywords").val(),
        productName: $("#txtProductName").val(),
        productURL: $("#txtProductURL").val(),
        marketSegments: $("#hiddenMarketSegments").html(),
        otherMarketSegments: $("#txtOtherMarketSegments").val(),
        competitors: "Competitor Product 1: " + $("#txtCompetitorProduct1").val() + " Product URL 1: " + $("#txtCompetitorProductURL1").val() + " | " + 
            "Competitor Product 2: " + $("#txtCompetitorProduct2").val() + " Product URL 2: " + $("#txtCompetitorProductURL2").val() + " | " + 
            "Competitor Product 3: " + $("#txtCompetitorProduct3").val() + " Product URL 3: " + $("#txtCompetitorProductURL3").val(),
        notes: "",
        idLead: $("#idLead").val()
    }

    //start spinner
    $("#spinner-image").show();

    //Start AJAX call
    $.ajax({
        url: "../Lead/AddSecondStep",
        type: "POST",
        dataType: "json",
        data: myFormData,
        success: function (data) {
            //stop spinner
            $("#spinner-image").hide();
            if (data.Acknowledgment) {
                sweetAlert({ title: 'Congratulations!', text: 'Your information has been successfully sent to us. Our analysts will start preparing your report very soon.', type: 'success' }, function () { window.location.href = "../"; });

            } else {
                sweetAlert('Error sending information', 'There was an error processing your request. Please try again in a few minutes.', 'error');
            }
        },
        error: function (error) {
            //stop spinner
            $("#spinner-image").hide();
            sweetAlert('Error sending information', 'There was an error processing your request. Please try again in a few minutes.', 'error');
        }
    });
}

jQuery.extend({
    getUrlVars: function () {
        var vars = [], hash;
        var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
        for (var i = 0; i < hashes.length; i++) {
            hash = hashes[i].split('=');
            vars.push(hash[0]);
            vars[hash[0]] = hash[1];
        }
        return vars;
    },
    getUrlVar: function (name) {
        return $.getUrlVars()[name];
    }
});