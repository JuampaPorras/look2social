smartSocialApp.controller('loginCtrl', ['$scope', function ($scope) {
    $scope.model = { userName: "", password: "", rememberMe: false, validationError: "" };
    $scope.login = function () {
        if ($scope.model.userName != "" && $scope.model.password != "") {
            var spinner = new Spinner(opts).spin(document.getElementById('spinner'));
            $.ajax({
                url: window.location.href + "/Account/Login",
                type: "POST",
                dataType: "Json",
                data: { userName: $scope.model.userName, password: $scope.model.password, rememberMe: $scope.model.rememberMe },
                success: function (data) {
                    if (data.Acknowledgment) {
                        company = data.CompanyInformation;
                        if (data.userLastReportId > 0) {
                            $(location).attr("href", window.location.href + "Home/Main#/MainReport/" + data.userLastReportId);
                        } else {
                            $(location).attr("href", window.location.href + "Home/Main");
                        }
                        
                    }
                    else {
                        $scope.$apply(function () {
                            $scope.model.validationError = data.Message
                        });
                        spinner.stop();
                    }
                },
                error: function (error) {
                    //alert
                    alert("We are unable to contact the server right now, try again in some minutes")
                }
            })
        }
        else {
            $scope.model.validationError = "Please type a valid email address and password";
        }
    };
}]);


var opts = {
    lines: 9 // The number of lines to draw
, length: 0 // The length of each line
, width: 4 // The line thickness
, radius: 7 // The radius of the inner circle
, scale: 1 // Scales overall size of the spinner
, corners: 1 // Corner roundness (0..1)
, color: '#455264' // #rgb or #rrggbb or array of colors
, opacity: 0.25 // Opacity of the lines
, rotate: 0 // The rotation offset
, direction: 1 // 1: clockwise, -1: counterclockwise
, speed: 1 // Rounds per second
, trail: 34 // Afterglow percentage
, fps: 20 // Frames per second when using setTimeout() as a fallback for CSS
, zIndex: 2e9 // The z-index (defaults to 2000000000)
, className: 'spinner' // The CSS class to assign to the spinner
, top: '50%' // Top position relative to parent
, left: '50%' // Left position relative to parent
, shadow: true // Whether to render a shadow
, hwaccel: false // Whether to use hardware acceleration
, position: 'absolute' // Element positioning
}
