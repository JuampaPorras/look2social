angular
        .module("smartSocialApp")
    .controller("noReportCtrl", manageCtrl);

manageCtrl.$inject = ["$scope", "$routeParams"];

function manageCtrl($scope, $routeParams) {
    $scope.$on('$viewContentLoaded', function () {
        $("#Toogler").removeClass("hidden");
        $("#rightSideBar").addClass("col-lg-2 col-md-3 col-sm-3").removeClass("hidden");
        if ($("#rightSideBar").hasClass("hidden-lg")) {
            $("#mainBody").removeClass("col-lg-offset-2 col-lg-10 col-md-offset-3 col-md-9 col-sm-offset-3 col-sm-9 col-xs-12").addClass("col-lg-12 col-md-12 col-sm-12 col-xs-12");
        }
        else {
            $("#mainBody").addClass("col-lg-offset-2 col-lg-10 col-md-offset-3 col-md-9 col-sm-offset-3 col-sm-9 col-xs-12").removeClass("col-lg-12 col-md-12 col-sm-12 col-xs-12");
        }
        $(".activeReport").removeClass("activeReport")
    });

}