//------------- Home page.js -------------//
//var url = "http://localhost:57893";
var currentLead = 0;

$(document).ready(function() {
    //$('#slider').removeClass('hided');
    /*Init revolution slider*/

    jQuery('.slider-inner').revolution(
    {
        dottedOverlay:"none",
        delay:9000,
        startwidth:1170,
        startheight:450,
        hideThumbs:10,
        navigationType:"bullet",
        navigationArrows:"solo",
        navigationStyle:"preview1",
        touchenabled:"on",
        onHoverStop:"on",
        
        swipe_velocity: 0.7,
        swipe_min_touches: 1,
        swipe_max_touches: 1,
        drag_block_vertical: false,
                                
        parallax:"mouse",
        parallaxBgFreeze:"on",
        parallaxLevels:[7,4,3,2,5,4,3,2,1,0],
                                
        keyboardNavigation:"on",
        hideTimerBar:"on",
        
        navigationHAlign:"center",
        navigationVAlign:"bottom",
        navigationHOffset:0,
        navigationVOffset:20,

        soloArrowLeftHalign:"left",
        soloArrowLeftValign:"center",
        soloArrowLeftHOffset:20,
        soloArrowLeftVOffset:0,

        soloArrowRightHalign:"right",
        soloArrowRightValign:"center",
        soloArrowRightHOffset:20,
        soloArrowRightVOffset:0,
                
        shadow:0,
        fullWidth:"on",
        fullScreen:"off",

        spinner:"spinner1",
        
        stopLoop:"off",
        stopAfterLoops:-1,
        stopAtSlide:-1,

        shuffle:"off",
        
        autoHeight:"off",
    });

    //Testimonials carousel
    $("#testimonials-carousel").owlCarousel({
        lazyLoad : true,
        navigation : true,
        slideSpeed : 500,
        paginationSpeed : 1000,
        singleItem:true,
        autoPlay: 7000,
        stopOnHover: true,
        navigationText: ["<i class='fa fa-angle-left'></i>","<i class='fa fa-angle-right'></i>"]
    }); 

    //Customers carousel
    $("#customers-carousel").owlCarousel({
        items: 4,
        lazyLoad : true,
        navigation : false,
        slideSpeed : 500,
        paginationSpeed : 1000,
        autoPlay: 7000,
        stopOnHover: true,
    }); 

    var validator = $("#userInformation").validate({
        submitHandler: function (form) {
            if ($("#userInformation").valid() &&
                validator.element("#txtEmail") &&
                validator.element( "#txtPhoneNumber" )&&
                $("#txtImportant").val() == "") {
                SendFirstStep();
            }
	    },
	    invalidHandler: function (event, validator) {
	        // 'this' refers to the form
	        var errors = validator.numberOfInvalids();
	        if (errors) {
	            var message = errors == 1
                  ? 'You missed 1 field. It has been highlighted'
                  : 'You missed ' + errors + ' fields. They have been highlighted';
	            $("div.error span").html(message);
	            $("div.error").show();
	        } else {
	            $("div.error").hide();
	        }
	    }
	});
});

function SendFirstStep() {
    var pathString = window.location.pathname;
    if(pathString.length > 0){
        if (pathString.charAt(pathString.length - 1) =='/') {
            pathString = pathString.slice(0, -1);
        }
    }

    //start spinner
     $("#spinner-image").show();

    // Sends the first group of fields to the database
	 $.ajax({
	    url: pathString + "/Lead/AddFirstStep",
        type: "POST",
		dataType: "json",
		data: { firstName: $("#txtFirstName").val(), lastName: $("#txtLastName").val(), email: $("#txtEmail").val(), countryCode: $("#ddlCountryCode").val(), phoneNumber: $("#txtPhoneNumber").val() },
		success: function (data) {
			// Stops the spinner
			$("#spinner-image").hide();
			if (data.Acknowledgment) {
			    sweetAlert('Your Information has been sent!', "Thank you for your interest in Smart Social Reports. We'll send you an Email with further instructions shortly.", 'success');
			    $("#txtFirstName").val("");
			    $("#txtLastName").val("");
			    $("#txtEmail").val("");
			    $("#ddlCountryCode").val("1"); // Set back to USA as default
			    $("#txtPhoneNumber").val("");
			} else {
			    sweetAlert('Error sending information', data.Message, 'error');
			}

		},
		error: function (error) {
			// Stops the spinner
			$("#spinner-image").hide();
			sweetAlert('Error sending information', 'There was an error processing your request. Please try again in a few minutes.', 'error');
		}
	 })
    
	 
}

