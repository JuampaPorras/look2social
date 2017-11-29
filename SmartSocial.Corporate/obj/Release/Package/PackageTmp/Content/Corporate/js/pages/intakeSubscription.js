$("#idWizardForm").validate(); // Initialize Validator
$(document).ready(function () {
    $("#btnFinish").click(function () {
        //Validates last TAB. Next button validation is done at moreInformation.js
        if ($("#idWizardForm").valid()) {
            AddLead();
        }
        else {
            $("#idWizardForm").validate().focusInvalid();
        }
    });
});

function AddLead() {
    /*var pathString = window.location.pathname;
    if (pathString.length > 0) {
        if (pathString.charAt(pathString.length - 1) == '/') {
            pathString = pathString.slice(0, -1);
        }
    }*/
    var token = "";//$.getUrlVar('token');
    
    var myFormData;

    var product = decodeURIComponent(window.location.search.match(/(\?|&)ProductType\=([^&]*)/)[2]);

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
        idLead: $("#idLead").val(),
        ProductType: product,
    }

    //start spinner
    $("#spinner-image").show();

    //Start AJAX call
    $.ajax({
        url: "../Lead/AddLead",
        type: "POST",
        dataType: "json",
        data: myFormData,
        success: function (data) {
            if (!data.success) {
                //stop spinner
                $("#spinner-image").hide();
                sweetAlert('Error sending information', data.message, 'error');
            } else
            {
                window.location = data.toUrl;
            }
        },
        error: function (error) {
            //stop spinner
            $("#spinner-image").hide();
            sweetAlert('Error sending information', 'There was an error processing your request. Please try again in a few minutes.', 'error');
        }
    });
}

$.extend({
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