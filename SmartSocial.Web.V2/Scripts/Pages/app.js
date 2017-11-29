angular.module("smartSocialApp", ["ngRoute", "ngSanitize"]).config(router);
    router.$inject = ["$routeProvider"]
    function router($routeProvider) {
        $routeProvider.
            when("/MainReport/:reportId", {
                templateUrl: "../App/MainReport.html",
                controller: "mainReportCtrl"
            }).
        when("/ManageAccount", {
            templateUrl: "../App/ManageAccount.html",
            controller: "manageCtrl"
        }).
        when("/NoReport", {
            templateUrl: "../App/NoReport.html",
            controller: "noReportCtrl"
        })
    }
