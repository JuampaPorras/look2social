    angular
        .module("smartSocialApp")
    .directive("subscriptionEnd", function () {
        return {
            restrict: "A",
            link: function (scope, elm, attrs) {
                if (scope.$last) {
                    isMenusLoaded = true;
                }
            }
        };
    })
    .directive("sharedEnd", function () {
        return {
            restrict: "A",
            link: function (scope, elm, attrs) {
                isMenusLoaded = true;
            }
        };
    })
    .controller("leftBarCtrl", leftBarCtrl);

    leftBarCtrl.$inject = ["$scope", "$routeParams", "$location"];

    function leftBarCtrl($scope, $routeParams, $location) {
        $scope.init = function () {
            $(window).on("resize", function () {
                var windowHeight = $(window).innerHeight();
                $("#subscriptionsMenuContainer").height((windowHeight - 196) + "px").parent().height((windowHeight - 196) + "px")
            })
            $.ajax({
                url: "../Data/MainPageData",
                type: "GET",
                dataType: "Json",
                data: {},
                success: function (data) {
                    if (data.Acknowledgment) {
                        $scope.currentUserId = data.userResponse.User.UserId;
                        $scope.currentUserName = data.userResponse.User.UserName;
                        $scope.systemRole = data.SystemRoles[0];
                        $("#exportDialog").dialog({
                            autoOpen: false,
                            height: 300,
                            width: 450,
                            modal: true,
                            title: "Export Report to PDF",
                        });
                        $("#exportDialog").removeClass("hidden")
                        getOnceUserNotifications();
                        $scope.$apply(function () {
                                if (data.userSubscriptionsReponse.UserSubscriptionsObjects != null) {
                                $scope.subscriptionsModel = data.userSubscriptionsReponse.UserSubscriptionsObjects;
                            }
                            if (data.userSubscriptionsReponse.ShareWithMe != null) {
                                $scope.sharedModel = data.userSubscriptionsReponse.ShareWithMe;
                            }
                            $scope.isGuest = data.isGuest;
                            $scope.CompanyModel = data.userResponse.CompanyInformation;
                            $scope.billingPortalLink = data.billingPortalLink
                        })
                        $("#notificationsContainer").slimScroll({
                            width: "250px",
                            height: "calc(100vh - 84px)"
                        })
                        var windowHeight = $(window).innerHeight();
                        $("#subscriptionsMenuContainer").slimScroll({
                            width: "100%",
                            height: "calc(" + windowHeight + "px-196px)",
                            color: "#FFFFFF"
                        })
                        if (data.isTrialEnding) {
                            $("#trialEndingModal").modal("show");
                        }
                        if (data.isTrialEnded) {
                            $("#trialEndModal").modal("show");
                        }
                    }
                    else {
                        //do sometyhing if no subscriptions
                    }
                },
                error: function (error) {
                    //alert
                    //alert("We are unable to contact the server right now, try again in some minutes")
                }
            });

        }
        $scope.billingPortalLink =""
        $scope.isGuest = false;
        $scope.currentUserId = 0;
        $scope.currentUserName = "";
        $scope.systemRole = "";
        $scope.shiftPressed = false;

        $scope.shiftPress = function (e) {
            if (e.keyCode == 16) {
                $scope.shiftPressed = true;
            }
        }

        $scope.shiftUp = function (e) {
            if (e.keyCode == 16) {
                $scope.shiftPressed = false;
            }
        }
        
        $scope.getReports = function (reportId, allReports, e) {
            e.preventDefault();
            if ($scope.shiftPressed) {
                var ids = "";
                var isBetween = false;
                angular.forEach(allReports, function (report) {
                    if (!isBetween && (report.ReportId == $scope.firstReport || report.ReportId == reportId)) {
                        ids = report.ReportId;
                        isBetween = true;
                    }
                    else if (isBetween && (report.ReportId == reportId || report.ReportId == $scope.firstReport)) {
                        ids += "+" + report.ReportId;
                        isBetween = false;
                    }
                });
                $location.path("/MainReport/" + ids);
                $scope.firstReport = 0;
            }
            else {
                $location.path("/MainReport/" + reportId);
                $scope.firstReport = reportId;
                //change location normally
            }
        }
        $scope.firstReport = window.location.hash.split("/")[window.location.hash.split("/").length - 1].split("+")[0];
        $scope.init()
        $scope.notificationsNewCount = 0;
        $scope.dateDeliveries = "";
        $scope.reportName = "";
        $scope.withChartInsights = true;
        $scope.withInsights = true;
        $scope.withComments = true;
        $scope.notificationList = [];
        $scope.Deliveries = [];
        $scope.subscriptionsModel = [];
        $scope.sharedModel = [];
        $scope.toggleSidebar = function () {
            if ($(window).width() > 767) {

            if ($("#rightSideBar").hasClass("hidden-lg")) {
                $("#rightSideBar").addClass("col-lg-2 col-md-3 col-sm-3").removeClass("hidden-lg hidden-md hidden-sm");
                $("#mainBody").addClass("col-lg-offset-2 col-lg-10 col-md-offset-3 col-md-9 col-sm-offset-3 col-sm-9 col-xs-12").removeClass("col-lg-12 col-md-12 col-sm-12 col-xs-12");
                $(window).trigger("resize");
            }
            else {
                $("#rightSideBar").removeClass("col-lg-2 col-md-3 col-sm-3").addClass("hidden-lg hidden-md hidden-sm");
                $("#mainBody").removeClass("col-lg-offset-2 col-lg-10 col-md-offset-3 col-md-9 col-sm-offset-3 col-sm-9 col-xs-12").addClass("col-lg-12 col-md-12 col-sm-12 col-xs-12");
                $(window).trigger("resize");
            }
            }
            else {
                if ($("#rightSideBar").hasClass("hidden-xs")) {
                    $("#rightSideBar").addClass("col-xs-12").removeClass("hidden-xs");
                }
                else {
                    $("#rightSideBar").addClass("hidden-xs").removeClass("col-xs-12");
                }
            }
           
        }

        $scope.showWholeExport = function () {
            $("#exportDialog").dialog("open");
        }

        $scope.normalizeDate = function (date) {
            var date = new Date(date);
            var month = new Array();
            month[0] = "Jan";
            month[1] = "Feb";
            month[2] = "Mar";
            month[3] = "Apr";
            month[4] = "May";
            month[5] = "Jun";
            month[6] = "Jul";
            month[7] = "Aug";
            month[8] = "Sep";
            month[9] = "Oct";
            month[10] = "Nov";
            month[11] = "Dec";
            var stringResult = month[date.getMonth()] + ", " + date.getFullYear();
            return stringResult
        }

        $scope.normalizeDateTime = function (jsonDate) {
            var date = new Date(parseInt(jsonDate.substr(6)));
            var month = new Array();
            month[0] = "Jan";
            month[1] = "Feb";
            month[2] = "Mar";
            month[3] = "Apr";
            month[4] = "May";
            month[5] = "Jun";
            month[6] = "Jul";
            month[7] = "Aug";
            month[8] = "Sep";
            month[9] = "Oct";
            month[10] = "Nov";
            month[11] = "Dec";
            var minutes = date.getMinutes() > 9 ? date.getMinutes() : "0" + date.getMinutes();
            var stringResult = month[date.getMonth()] + " " + date.getDate() + ", " + date.getFullYear() + ", " + date.getHours() + ":" + minutes;
            return stringResult;
        }

        $scope.showMoreReports = false;

        $scope.showAllReports = function () {
            $scope.showMoreReports = true;
        }

        $scope.fromValue = "";
        $scope.toValue = "";
        $scope.getExportReport = function () {
            var reportId = window.location.hash.split("/")[window.location.hash.split("/").length - 1].split("+")[0];
            //var reportName = $("#ReportName").text();
            var withInsights = $scope.withInsights;
            var withChartInsights = $scope.withChartInsights;
            var withComments = $scope.withComments;
            $("#exportWholeModal").modal("hide");
            swal("", "You will be notified as soon as the PDF is ready", "success");
            $.ajax({
                url: "../Home/UrlAsPDF",
                type: "GET",
                dataType: "Json",
                data: { reportId: reportId, withInsights: withInsights, withChartInsights: withChartInsights, withComments: withComments, reportName: $scope.reportName, chartId: 0, from: $scope.fromValue, to: $scope.toValue},
                success: function (data) {
                    if (data.Acknowledgment) {
                        launchNotification(data.Notification.Text)
                        $scope.$apply(function () {
                            $scope.notificationsNewCount = $scope.notificationsNewCount + 1;
                            $scope.notificationList.unshift(data.Notification);
                        });
                    }
                }
            });
        };

        $scope.notificationsViewed = function () {
            $scope.notificationsNewCount = 0;
            $.ajax({
                url: "../Notifications/SetViewed",
                type: "Post",
                dataType: "Json",
                data: {},
                success: function (data) {
                    if (data.Acknowledgment) {

                    }
                    else {
                        //do sometyhing if no subscriptions
                    }
                },
                error: function (error) {
                    //alert
                    //alert("We are unable to contact the server right now, try again in some minutes")
                }
            });
        }

        var launchNotification = function (text) {
            $.gritter.add({
                // (string | mandatory) the heading of the notification
                title: 'Report is Ready!',
                // (string | mandatory) the text inside the notification
                text: text,
                // (string | optional) the image to display on the left
                image: 'http://www.iceni.com/blog/wp-content/uploads/2012/09/adobe_reader_logo.png',
                time: '5000',
                // (string) specify font-face icon  class for close message
                close_icon: 'l-arrows-remove s16',
                class_name: 'info-notice'
            });
        }
        var timeouts = [];

        var getOnceUserNotifications = function () {
            $.ajax({
                url: "../Notifications/GetUserNotifications",
                type: "GET",
                dataType: "Json",
                data: {},
                success: function (data) {
                    if (data.Acknowledgment) {
                        var newNotifications = 0
                        angular.forEach(data.NotificationsList, function (notification) {
                            if (!notification.WasViewed) {
                                newNotifications = newNotifications + 1;
                            }
                        });
                        $scope.$apply(function () {
                            $scope.notificationsNewCount = newNotifications;
                            $scope.notificationList = data.NotificationsList;
                        });
                    }
                    else {
                        //do sometyhing if no subscriptions
                    }
                },
                error: function (error) {
                    //alert
                    //alert("We are unable to contact the server right now, try again in some minutes")
                }
            });
        }

        function normalizeDate(jsonDate) {
            var date = new Date(parseInt(jsonDate.substr(6)));
            var month = new Array();
            month[0] = "Jan";
            month[1] = "Feb";
            month[2] = "Mar";
            month[3] = "Apr";
            month[4] = "May";
            month[5] = "Jun";
            month[6] = "Jul";
            month[7] = "Aug";
            month[8] = "Sep";
            month[9] = "Oct";
            month[10] = "Nov";
            month[11] = "Dec";
            var stringResult = month[date.getMonth()] + ", " + date.getFullYear();
            return stringResult
        }

        $scope.CompanyImageCorrectSource = function (companyId, ImageName) {
            return "../Images/CompanyImages/" + companyId + "/" + ImageName
        }


    };

var isMenusLoaded = false;
