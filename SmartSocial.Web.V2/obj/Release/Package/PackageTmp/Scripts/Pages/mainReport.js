
var wordCloudsImages = []

var activeSpinners = [];
var newActiveSpinner = function (spinner, id) {
    var spinToAdd = { spin: spinner, chartId: id };
    activeSpinners.push(spinToAdd);
}
angular
    .module("smartSocialApp")
    .filter('to_trusted', ['$sce', function ($sce) {
        return function (text) {
            return $sce.trustAsHtml(text);
        };
    }])
    .directive('spin', function () {
        return {
            restrict: 'A',
            link: function (scope, elm, attrs) {
                var spinner = new Spinner(opts).spin(elm[0]);
                newActiveSpinner(spinner, scope.chart.idSmartChart)
            }
        };
    }).controller("mainReportCtrl", mainReportCtrl);


mainReportCtrl.$inject = ['$scope', '$routeParams', '$compile', '$sce'];


function mainReportCtrl($scope, $routeParams, $compile, $sce) {

    $scope.$on('$viewContentLoaded', function () {
        ProcessLeftBarMenu();
        $.ajax({
            url: "../Data/GetChartsBySmartReportId",
            type: "GET",
            dataType: "Json",
            data: { smartReportId: $routeParams.reportId.split("+")[0] },
            success: function (data) {
                $("#Toogler").removeClass("hidden");
                $("#rightSideBar").addClass("col-lg-2 col-md-3 col-sm-3").removeClass("hidden");
                if ($("#rightSideBar").hasClass("hidden-lg")) {
                    $("#mainBody").removeClass("col-lg-offset-2 col-lg-10 col-md-offset-3 col-md-9 col-sm-offset-3 col-sm-9 col-xs-12").addClass("col-lg-12 col-md-12 col-sm-12 col-xs-12");
                }
                else {
                    $("#mainBody").addClass("col-lg-offset-2 col-lg-10 col-md-offset-3 col-md-9 col-sm-offset-3 col-sm-9 col-xs-12").removeClass("col-lg-12 col-md-12 col-sm-12 col-xs-12");
                }
                if (data.Acknowledgment) {
                    //Create dialog for socialPost
                    $("#reportInsights").dialog({
                        height: 550,
                        width: 650,
                        title: "Insights",
                        autoOpen: false
                    })
                    $("#socialPostWindow").dialog({
                        height: 550,
                        width: 650,
                        title: "Social Posts",
                        autoOpen: false
                    });
                    $("#socialPostWindow").on("dialogclose", function (event, ui) {
                        $('#socialPostContainer').slimScroll({
                            scrollTo: '0px',
                            height: "100%"
                        });
                        $scope.$apply(function () {
                            $scope.socialPostModel = [];
                        });
                        //$("#socialPostContainer").html("");
                        $("#socialPostContainer").hide();
                        $("#loadingImg").show();
                        $("#noItems").hide();
                    });
                    $("#socialContainer").slimScroll({
                        height: "100%"
                    }).bind('slimscroll', function (e, pos) {
                        if (pos == "bottom") {
                            conversationAjaxCallback();
                        }
                    });
                    if (data.SmartReport.Insights != "") {
                        $("#windowButton").removeClass("hidden");
                    }
                    $("#shareBtn").removeClass("hidden");
                    $("#shareWindow").removeClass("hidden");
                    $("#loadingImg").show();
                    
                    var subsRole = "";
                    for (var e = 0; e < $scope.$parent.subscriptionsModel.length; e++) {
                        for (var r = 0; r < $scope.$parent.subscriptionsModel[e].Reports.length; r++) {
                            for (var it = 0; it < $scope.$parent.subscriptionsModel[e].Reports[r].Items.length; it++) {
                                if ($scope.$parent.subscriptionsModel[e].Reports[r].Items[it].ReportId == $routeParams.reportId.split("+")[0]) {
                                    subsRole = $scope.$parent.subscriptionsModel[e].ServiceSubscription.SubscriptionRoleName
                                }
                            }
                        }
                    }
                    $scope.$apply(function () {
                        $scope.subscriptionRole = subsRole;
                        $scope.reportModel = data.SmartReport;
                        $scope.$parent.reportName = data.SmartReport.ReportName;
                        $scope.deliveryModel = data.Delivery;
                        $scope.chartsModel = data.SmartCharts;
                    });
                    $("#exportReportBut").show();
                }
                else {
                    //do sometyhing if no subscriptions
                }
            },
            error: function (error) {
                //alert
                //alert("We are unable to contact the server right now, try again in some minutes");
            }
        });
    });

    $scope.isMenuProcess = false;

    $scope.$on('$routeChangeStart', function (next, current) {
        $("#loadingImg").hide();
        var ua = window.navigator.userAgent;
        var msie = ua.indexOf("MSIE ");
        if (msie > 0 || !!navigator.userAgent.match(/Trident.*rv\:11\./))
            window.document.execCommand('Stop');
        else
            window.stop();
        $("#socialPostWindow").dialog("destroy");
        $("#shareWindow").dialog("destroy");
        $("#reportInsights").dialog("destroy");
        $(".popover").popover("hide");
    });

    $scope.reportsIdInRange = [];
    $scope.isSharedWithMe = true;
    $scope.subscriptionRole = "";
    $scope.reportModel = {};
    $scope.chartsModel = [];
    $scope.reportsRange = [];
    $scope.shareComment = "";
    $scope.deliveryModel = {};
    $scope.shareUrl = "";
    $scope.exportChartName = "";

    $scope.searchUserByEmail = function (e) {
        if (e.keyCode != 13) {
            if ($("#txtSearchEmail").val().length > 2) {
                $.ajax({
                    url: "../Share/User?email=" + $("#txtSearchEmail").val(),
                    type: "GET",
                    dataType: "Json",
                    success: function (data) {
                        if (data.Acknowledgment) {
                            var dataNames = new Array();
                            for (var i = 0; i < data.Users.length; i++) {
                                dataNames[i] = data.Users[i].UserName;
                            }
                            $("#txtSearchEmail").autocomplete({
                                source: dataNames
                            });
                        } else {

                        }
                    },
                    error: function (error) {
                    }
                })
            }
        }
        else {
            return false;
        }
    }
    $scope.updateReport = function () {
        var charts = $scope.chartsModel;
        $scope.chartsModel = [];
        $scope.$apply();
        var ua = window.navigator.userAgent;
        var msie = ua.indexOf("MSIE ");
        if (msie > 0 || !!navigator.userAgent.match(/Trident.*rv\:11\./))
            window.document.execCommand('Stop');
        else
            window.stop();
        $scope.fromValue = $scope.fromDropdownValue.date;
        $scope.toValue = $scope.toDropdownValue.date;
        $scope.$parent.fromValue = $scope.fromDropdownValue.date;
        $scope.$parent.toValue = $scope.toDropdownValue.date;
        $(".activeReport").removeClass("activeReport").addClass("reportDelivered");
        var reportsInRange = [];
        var isBetween = false;
        for (var i = 0; i < $scope.reportsRange.length; i++) {
            if ($scope.toDropdownValue.date == $scope.reportsRange[i].dateReport) {
                if ($scope.reportsRange[i].dateReport != $scope.fromDropdownValue.date) {
                    reportsInRange.push($scope.reportsRange[i].reportId);
                }
                $("#report" + $scope.reportsRange[i].reportId).addClass("activeReport");

                isBetween = false
            }
            if (isBetween) {
                $("#report" + $scope.reportsRange[i].reportId).addClass("activeReport");
                reportsInRange.push($scope.reportsRange[i].reportId);
            }
            if ($scope.fromDropdownValue.date == $scope.reportsRange[i].dateReport) {
                reportsInRange.push($scope.reportsRange[i].reportId);
                $("#report" + $scope.reportsRange[i].reportId).addClass("activeReport");
                if ($scope.fromDropdownValue.date != $scope.toDropdownValue.date) {
                    isBetween = true;
                }
            }
        }
        $scope.reportsIdInRange = reportsInRange;
        $scope.$apply();
        $scope.chartsModel = charts;
        $scope.$apply();
    }
    $scope.withChartInsights = true;
    $scope.withComments = true;

    $scope.getExportChart = function () {
        $("#exportChartModal").modal("hide");
        swal("", "You will be notified as soon as the PDF is ready", "success");
        $.ajax({
            url: "../Home/ChartAsPDF",
            type: "GET",
            dataType: "Json",
            data: { reportId: $routeParams.reportId.split("+")[0], chartId: $scope.currentExportId, withChartInsights: $scope.withChartInsights, withComments: $scope.withComments, reportName: $scope.exportChartName, chartName: $scope.currentExportName, from: $scope.fromValue, to: $scope.toValue },
            success: function (data) {
                if (data.Acknowledgment) {
                    launchNotification(data.Notification.Text)
                    $scope.$apply(function () {
                        $scope.$parent.notificationsNewCount = $scope.$parent.notificationsNewCount + 1;
                        $scope.$parent.notificationList.unshift(data.Notification);
                    });
                }
            }
        });
    }
    $scope.deleteComment = function () {
        var commentId = $("#commentToDelete").val();
        var idSmartChart = $("#commentChartIdToDelete").val();
        $(".popover  #comment_" + commentId).hide();
        $(".popover  #commentDate_" + commentId).hide();
        var commentCount = $('#' + idSmartChart + '_CommentCounter').text();
        $('#' + idSmartChart + '_CommentCounter').text(parseInt(commentCount) - 1);
        commentCount = parseInt(commentCount) - 1;
        if (commentCount == "0") {
            $('#' + idSmartChart + '_CommentCounter').css("visibility", 'hidden');
        }

        $.ajax({
            url: "../Comments/DeactivateChartComment",
            type: "POST",
            dataType: "Json",
            data: { idComment: commentId },
            success: function (data) {
                if (data.Acknowledgment) {
                }
            }
        });
    }
    $scope.getChartData = function (thisChart) {
        getchartDataRecurrent(thisChart);
    }
    var getchartDataRecurrent = function (thisChart) {
        setTimeout(function () {
            if (typeof $scope.fromValue !== "undefined" && typeof thisChart.chart !== "undefined" && $scope.fromValue != "" && $scope.toValue != "" && $scope.isMenuProcess) {
                var successCallback = function () { };
                var errorCallBack = function () { };
                switch (thisChart.chart.IdChartType) {
                    //Column
                    case 1:
                        successCallback = DrawColumnChart;
                        break;
                        //Linear
                    case 2:
                        successCallback = DrawLinearChart;
                        break;
                        //StackedColums
                    case 3:
                        successCallback = DrawStackedColumnChart;
                        break;
                        //WordCloud
                    case 5:
                        //
                        successCallback = DrawWordCloud;
                        break;
                        //MostProlificUsers
                    case 7:
                        //
                        successCallback = DrawProlificUser;
                        break;
                        //LocationAnalysis
                    case 8:
                        successCallback = DrawLocationAnalysis;
                        break;
                        //Pie
                    case 6:
                        successCallback = DrawPieChart;
                        break;
                        //Summary Reach
                    case 9:
                        successCallback = DrawSummaryReach;
                        break;
                        //Summary Mentions
                    case 11:
                        successCallback = DrawSummaryMentions;
                        break;
                        //Summary Best Day
                    case 12:
                        successCallback = DrawSummaryDay;
                        break;
                        //Summary Top User
                    case 13:
                        successCallback = DrawSummaryUser;
                        break;
                        //Summary Top User
                    case 14:
                        successCallback = DrawTopPost;
                        break;
                    case 15:
                        successCallback = DrawTopPosts;
                        break;
                };
                $.ajax({
                    url: "../Data/GetChartDataByChartTypeId",
                    type: "GET",
                    data: { chartTypeId: thisChart.chart.IdChartType, smartChartId: thisChart.chart.idSmartChart, from: $scope.fromValue, to:$scope.toValue },
                    dataType: "Json",
                    success: function (data) {
                        if (data.Acknowledgment) {
                            successCallback(data, thisChart.chart.idSmartChart, thisChart.chart.ChartName, thisChart.chart.CommentsCount);
                            $(window).trigger("resize")
                            for (var i = 0; i < activeSpinners.length; i++) {
                                if (activeSpinners[i].chartId == thisChart.chart.idSmartChart) {
                                    activeSpinners[i].spin.stop();
                                }
                            }
                            var commentCount = $('#' + thisChart.chart.idSmartChart + '_CommentCounter').text();
                            if (commentCount > "0") {
                                $('#' + thisChart.chart.idSmartChart + '_CommentCounter').css("visibility", 'visible');
                            }
                        } else {
                            errorCallBack();
                            for (var i = 0; i < activeSpinners.length; i++) {
                                if (activeSpinners[i].chartId == thisChart.chart.idSmartChart) {
                                    activeSpinners[i].spin.stop();
                                }
                            }
                        }

                    },
                    error: function (error) {
                        errorCallBack();
                    }
                })
            } else {
                getchartDataRecurrent(thisChart);
            }
        }, 50)
    }


    $scope.shareReport = function () {
        GetSharedreport($scope.shareComment, $routeParams.reportId.split("+")[0], window.location.href);

    }

    $scope.shareByEmailReport = function () {
        var validator = $("#formShareEmail").validate({
            submitHandler: function (form) {
                if ($("#formShareEmail").valid() &&
                    validator.element("#txtSearchEmail")) {
                    ShareByEmail($routeParams.reportId.split("+")[0]);
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
    }

    $scope.showReportInsights = function () {
        $("#reportInsights").dialog("open");
    }

    $scope.showShareReport = function () {
        $("#shareWindow").dialog("open");
    }
    $scope.$watch("shareUrl", function () {
        if ($scope.shareUrl != "") {
            $("#shareCompleteContainer").removeClass("hidden");
            $("#shareInProcess").addClass("hidden");
        }
        else {
            $("#shareCompleteContainer").addClass("hidden");
            $("#shareInProcess").removeClass("hidden");
        }
    })
    $scope.normalizeDate = function (jsonDate) {
        if (jsonDate != undefined) {
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
            var stringResult = month[date.getMonth()] + " " + date.getDate() + ", " + date.getFullYear();
            return stringResult
        }
        else {
            return jsonDate
        }
    }

    $scope.conversationStreamWordCloud = function (chartId, term) {
        $("#socialPostWindow").dialog("open");
        $scope.socialPostFilter = chartId + "|" + term;
        conversationAjaxCallback();
    }

    $scope.conversationStreamWordCloudPerMessage = function (chartId, message) {
        $("#socialPostWindow").dialog("open");
        $scope.socialPostFilterMessage = chartId + "|" + message;
        conversationAjaxCallbackMessage();
    }

    $scope.changeIconOpenTab = function (element) {
        if ($("#iconGraphChart_" + element.chart.idSmartChart).attr('class') == "l-software-layout-8boxes") {
            $("#iconGraphChart_" + element.chart.idSmartChart).removeClass("l-software-layout-8boxes");
            $("#iconGraphChart_" + element.chart.idSmartChart).addClass("l-ecommerce-graph1");
            $("#atablePill_" + element.chart.idSmartChart).tab('show')
        } else {
            $("#iconGraphChart_" + element.chart.idSmartChart).removeClass("l-ecommerce-graph1");
            $("#iconGraphChart_" + element.chart.idSmartChart).addClass("l-software-layout-8boxes");
            $("#achartPill_" + element.chart.idSmartChart).tab('show')
        }
    }

    $scope.processImage = function (imageSrc) {
        return ProcessImage(imageSrc);
    }

    $scope.processScreenName = function (name) {
        return ProcessScreenName(name);
    }

    $scope.processSocialNetwork = function (socialNetwork) {
        return ProcessSocialNetwork(socialNetwork);
    }

    $scope.processMessagePreview = function (message) {
        var messageProcessed = $("<div>" + message + "</div>").text();
        return messageProcessed
    }

    $scope.processMessage = function (message) {
        return "<div>" + message + "</div>"
    }

    var AppendFlag = function (country) {
        if (isoCountries.hasOwnProperty(country)) {
            return isoCountries[country];
        } else {
            return country;
        }
    };

    $scope.shareComment = "I wanted to share this report with you.";

    $scope.shareCopyMe = false;

    $scope.activeReports = [];

    $scope.shareByEmail = function () {
        var spinner = new Spinner(opts).spin($('#spinnerShare')[0]);
        var ranges = $scope.fromValue == $scope.toValue ? $scope.fromValue : $scope.fromValue + " - " + $scope.toValue;
        jQuery.ajaxSettings.traditional = true;
        $.ajax({
            url: "../Share/Invite",
            type: "POST",
            dataType: "json",
            data: {
                //string email, int[] smartReportid,string comment,string ranges,string reportName,bool sendMeACopy
                email: $("#txtSearchEmail").val(), smartReportid: $scope.reportsIdInRange, comment: $scope.shareComment, ranges: ranges, reportName: $scope.reportModel.ReportName, sendMeACopy: $scope.shareCopyMe
            },
            success: function (data) {
                if (data.Acknowledgment) {
                    swal("Report has been shared with", $("#txtSearchEmail").val(), "success");
                    $("#shareModal").modal("hide")
                    spinner.stop();
                } else {
                    $("#shareMessage").text(data.message);
                    spinner.stop();
                }

            },
            error: function (error) {
            }
        })
    }

    $scope.rowsSkipped = 0;

    $scope.socialPostModel = [];

    $scope.lunchPopOver = function (thisElement) {
        var genericCloseBtnHtml = '<button onclick="closePopOver(this,' + thisElement.chart.idSmartChart + ');" type="button" class="close" aria-hidden="true">&times;</button>';
        var idElement = thisElement.chart.idSmartChart + "CommentsMenu";
        $("#" + idElement).popover({
            html: true,
            title: 'Comments ' + genericCloseBtnHtml,
            content: function () {
                return $('.content-popup_' + thisElement.chart.idSmartChart).html();
            },
            container: 'body',
            placement: 'auto right'
        });
        var popoverId = $("#" + idElement).attr("aria-describedby");
        if (!$("#" + popoverId).hasClass("in")) {
            getCommentsBySmartCharId(thisElement.chart.idSmartChart, function (data) {
                $('#commentsField_' + thisElement.chart.idSmartChart).html('');
                var commentsFromServer = "";
                for (var i = 0; i < data.Comments.length; i++) {
                    var button = "";
                    if (data.Comments[i].IdUser == $scope.$parent.currentUserId || $scope.$parent.systemRole == "Administrator" || $scope.subscriptionRole == "Admin") {
                        button = "<button data-toggle=\"modal\" data-target=\"#deleteComment\" onclick=\"deleteCommentPopUp(" + data.Comments[i].IdComment + ", " + thisElement.chart.idSmartChart + ")\" type=\" button\" class=\"close\" aria-hidden=\"true\">×</button>";
                    }
                    $('#commentsField_' + thisElement.chart.idSmartChart).append("<div id=\"comment_" + data.Comments[i].IdComment + "\" class=\"bg-info commentPopup\" class=\"commentPopup\">" + button + data.Comments[i].Message + "</div><span id=\"commentDate_" + data.Comments[i].IdComment + "\" class=\"help-block text-right\">" + GetSmallDate(data.Comments[i].DatePosted) + " by " + data.Comments[i].UserName + "</span>");

                }
                $("#" + idElement).popover('show');
                $('.popover #commentsField_' + thisElement.chart.idSmartChart).scrollTop($('.popover #commentsField_' + thisElement.chart.idSmartChart).prop('scrollHeight'));
            }, function () {
                alert("unable to load Comments for Chart Id: " + thisElement.chart.idSmartChart);
            });

        } else {
            $('#commentsField_' + thisElement.chart.idSmartChart).empty();
        }


    }


    $scope.toDropdownValue = {};

    $scope.fromDropdownValue = {};

    $scope.changeToDate = function (thisElement) {
        $scope.toDropdownValue = { date: thisElement.dateReport, order: thisElement.order };
        if ($scope.fromDropdownValue.order > thisElement.order) {
            $scope.fromDropdownValue = { date: thisElement.dateReport, order: thisElement.order };
        }
    }

    $scope.changeFromDate = function (thisElement) {
        $scope.fromDropdownValue = { date: thisElement.dateReport, order: thisElement.order };
        if ($scope.toDropdownValue.order < thisElement.order) {
            $scope.toDropdownValue = { date: thisElement.dateReport, order: thisElement.order };
        }
    }
    var launchNotification = function (text) {
        $.gritter.add({
            // (string | mandatory) the heading of the notification
            title: 'Chart is Ready!',
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
    var JSONToCSVConvertor = function (JSONData, ReportTitle, ShowLabel, FileName) {
        //If JSONData is not an object then JSON.parse will parse the JSON string in an Object
        var arrData = typeof JSONData != 'object' ? JSON.parse(JSONData) : JSONData;

        var CSV = '';
        //Set Report title in first row or line

        CSV += ReportTitle + '\r\n\n';

        //This condition will generate the Label/Header
        if (ShowLabel) {
            var row = "";

            //This loop will extract the label from 1st index of on array
            for (var index in arrData[0]) {

                //Now convert each value to string and comma-seprated
                row += index + ',';
            }

            row = row.slice(0, -1);

            //append Label row with line break
            CSV += row + '\r\n';
        }

        //1st loop is to extract each row
        for (var i = 0; i < arrData.length; i++) {
            var row = "";

            //2nd loop will extract each column and convert it in string comma-seprated
            for (var index in arrData[i]) {
                row += '"' + arrData[i][index] + '",';
            }

            row.slice(0, row.length - 1);

            //add a line break after each row
            CSV += row + '\r\n';
        }

        if (CSV == '') {
            alert("Invalid data");
            return;
        }

        //Initialize file format you want csv or xls
        var uri = 'data:text/csv;charset=utf-8,' + escape(CSV);

        // Now the little tricky part.
        // you can use either>> window.open(uri);
        // but this will not work in some browsers
        // or you will not get the correct file extension    

        //this trick will generate a temp <a /> tag
        var link = document.createElement("a");
        link.href = uri;

        //set the visibility hidden so it will not effect on your web-layout
        link.style = "visibility:hidden";
        link.download = FileName + ".csv";

        //this part will append the anchor tag and remove it after automatic click
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
    }


    //Functions not stored
    var GetSmallDate = function (jsonDate) {
        var value = new Date(parseInt(jsonDate.substr(6)));
        return value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear()
    }

    var getCommentsBySmartCharId = function (smartCharIdValue, successCallBack, errorCallback) {
        $.ajax({
            type: "GET",
            url: "../Comments/GetCommentsByChart",
            data: {
                smartChartId: smartCharIdValue
            },
            contentType: "application/json; charset=utf-8",
            dataType: "text", // the data type we want back, so text.  The data will come wrapped in xml
            success: function (data) {
                var comments = JSON.parse(data);
                if (comments.Acknowledgment) {
                    successCallBack(comments);
                } else {
                    errorCallback();
                }

            }
        });
    }

    //var GetChartData = function (chartTypeId, smartChartId, chartName, commentCount, successCallback, errorCallBack) {
    //    var spinner = new Spinner(opts).spin(document.getElementById('spinner_' + smartChartId));
    //    $.ajax({
    //        url: "../Data/GetChartDataByChartTypeId?chartTypeId=" + chartTypeId + "&smartChartId=" + smartChartId,
    //        type: "GET",
    //        dataType: "Json",
    //        success: function (data) {
    //            if (data.Acknowledgment) {
    //                successCallback(data, smartChartId, chartName, commentCount);
    //                spinner.stop();
    //                $(window).trigger("resize")
    //            } else {
    //                errorCallBack();
    //                spinner.stop();
    //            }

    //        },
    //        error: function (error) {
    //            errorCallBack();
    //        }
    //    })
    //}

    var GetSharedreport = function (comment, reportId, url) {
        $.ajax({
            url: "../Data/GetSharedreport",
            type: "GET",
            data: {
                comments: comment, smartReportid: reportId, url: url
            },
            dataType: "Json",
            success: function (data) {
                if (data.Acknowledgment) {
                    $scope.$apply(function () {
                        $scope.shareUrl = data.SharedResponse.TinyUrl;
                    })
                    //successCallback(data, smartChartId, chartName);
                    //spinner.stop();
                } else {
                    //errorCallBack();
                }

            },
            error: function (error) {
                //errorCallBack();
            }
        })
    }

    var DrawStackedColumnChart = function (data, smartChartId, chartName, commentsCount) {
        var categories = [];
        var tableBody = "<thead>" +
                    "<tr>" +
                        "<th>Social Media</th>" +
                        "<th>Term</th>" +
                        "<th>Count</th>" +
                    "</tr>" +
                "</thead>" +
                "<tbody>";
        for (var e = 0; e < data.Series.series.length; e++) {
            for (var i = 0; i < data.Series.groupNames.length; i++) {
                tableBody = tableBody + "<tr>" +
        "<td>" + data.Series.groupNames[i] + "</td>" +
        "<td>" + data.Series.series[e].name + "</td>" +
        "<td>" + (data.Series.series[e].data[i] != null ? data.Series.series[e].data[i] : "-") + "</td>" +
    "</tr>";
            }
        }
        tableBody += "</tbody>";
        $("#tableContainer_" + smartChartId).html(tableBody);
        $("#tableContainer_" + smartChartId).parent().slimScroll({
            height: "400px",
            width: "100%"
        });
        var stackedChart = $('#chartContainer_' + smartChartId).highcharts({
            chart: {
                type: 'column'
            },
            exporting: {
                enabled: false
            },
            title: {
                text: ''
            },
            xAxis: {
                categories: data.Series.groupNames
            },
            yAxis: {
                min: 0,
                title: {
                    text: ''
                },
                stackLabels: {
                    enabled: true,
                    style: {
                        fontWeight: 'bold',
                        color: (Highcharts.theme && Highcharts.theme.textColor) || 'gray'
                    }
                }
            },
            legend: {
                align: 'right',
                x: -30,
                verticalAlign: 'top',
                y: 25,
                floating: true,
                backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                borderColor: '#CCC',
                borderWidth: 1,
                shadow: false
            },
            tooltip: {
                formatter: function () {
                    return '<b>' + this.x + '</b><br/>' +
                        this.series.name + ': ' + this.y + '<br/>' +
                        'Total: ' + this.point.stackTotal;
                }
            },
            plotOptions: {
                column: {
                    stacking: 'normal',
                    dataLabels: {
                        enabled: true,
                        color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'white',
                        style: {
                            textShadow: '0 0 3px black'
                        }
                    }
                },
                series: {
                    cursor: 'pointer',
                    point: {
                        events: {
                            click: function () {
                                $("#socialPostWindow").dialog({
                                    open: function () {
                                        $(this).scrollTop(0);
                                    },
                                });
                                $scope.socialPostFilter = smartChartId + "|" + this.series.name + "," + this.category;
                                conversationAjaxCallback();
                            }
                        }
                    }
                }
            },
            series: data.Series.series
        });
        $("#exporterPdf" + smartChartId).on('click', function () {
            //stackedChart.highcharts().exportChart({
            //    type: "application/pdf", filename: chartName + "_" + new Date().getDate()
            //})
        })
        $("#exporterExcel" + smartChartId).on('click', function () {
            JSONToCSVConvertor(data.ChartData, chartName, true, chartName + "_" + new Date().getDate());
        })


    }
    var DrawLinearChart = function (data, smartChartId, chartName, commentsCount) {
        var tableBody = "<thead>" +
            "<tr>" +
            "<th>Date</th>" +
            "<th>Term</th>" +
            "<th>Count</th>" +
        "</tr>" +
    "</thead>" +
    "<tbody>";
        var jsonToCsv = []
        for (var e = 0; e < data.Series.series.length; e++) {
            for (var i = 0; i < data.Series.groupNames.length; i++) {
                tableBody = tableBody + "<tr>" +
        "<td>" + data.Series.groupNames[i] + "</td>" +
        "<td>" + data.Series.series[e].name + "</td>" +
        "<td>" + (data.Series.series[e].data[i] != null ? data.Series.series[e].data[i] : "-") + "</td>" +
    "</tr>";
                var row = { "Date": data.Series.groupNames[i], "Term": data.Series.series[e].name, "Count": (data.Series.series[e].data[i] != null ? data.Series.series[e].data[i] : "-") }
                jsonToCsv.push(row)
            }
        }
        tableBody += "</tbody>";
        $("#tableContainer_" + smartChartId).html(tableBody);
        $("#tableContainer_" + smartChartId).parent().slimScroll({
            height: "400px",
            width: "100%"
        });
        var lineChart = $('#chartContainer_' + smartChartId).highcharts({
            title: {
                text: ''
            },
            chart: {
            },
            exporting: {
                enabled: false
            },
            tooltip: {
                headerFormat: '<b>Date:{point.x}</b><br>',
                pointFormat: 'Count: {point.y}'
            },

            series: data.Series.series,
            xAxis: {
                type: "datetime",
                categories: data.Series.groupNames,
                minPadding: 0.05,
                maxPadding: 0.05,
                tickInterval: 5

            },
            plotOptions: {
                series: {
                    connectNulls: true,
                    cursor: 'pointer',
                    point: {
                        events: {
                            click: function () {
                                $("#socialPostWindow").dialog("open");
                                var date = this.category.split("/");
                                $scope.socialPostFilter = smartChartId + "|" + this.series.name + "," + date[2] + "-" + date[0] + "-" + date[1];
                                conversationAjaxCallback();
                            }
                        }
                    }
                }
            },

        });
        $("#exporterPdf" + smartChartId).on('click', function () {
            //lineChart.highcharts().exportChart({
            //    type: "application/pdf", filename: chartName + "_" + new Date().getDate()
            //})
            $scope.$apply(function () {
                $scope.exportChartName = chartName;
                $scope.currentExportId = smartChartId;
                $scope.currentExportName = chartName;
            })
            $("#exportChartModal").modal("show")
        })
        $("#exporterExcel" + smartChartId).on('click', function () {
            JSONToCSVConvertor(jsonToCsv, chartName, true, chartName + "_" + new Date().getDate());
        })

    }

    var DrawColumnChart = function (data, smartChartId, chartName, commentsCount) {

        var columnSeries = [];
        var tableBody = "<thead>" +
                    "<tr>" +
                        "<th>Term</th>" +
                        "<th>Count</th>" +
                    "</tr>" +
                "</thead>" +
                "<tbody>";

        angular.forEach(data.ChartData, function (chartData) {
            tableBody += "<tr>" +
                "<td>" + chartData.Term + "</td>" +
                "<td>" + chartData.theCount + "</td>" +
            "</tr>";
            var especificData = { name: chartData.Term, data: [parseInt(chartData.theCount)] }
            columnSeries.push(especificData)
        })
        var columnChart = $('#chartContainer_' + smartChartId).highcharts({
            chart: {
                type: 'bar'
            },
            exporting: {
                enabled: false
            },
            plotOptions: {
                series: {
                    cursor: 'pointer',
                    point: {
                        events: {
                            click: function () {
                                $("#socialPostWindow").dialog("open");
                                $scope.socialPostFilter = smartChartId + "|" + this.series.name;
                                conversationAjaxCallback();
                            }
                        }
                    }
                }
            },
            tooltip: {
                formatter: function () {
                    return this.series.name + " " + this.y;
                }
            },
            title: {
                text: ''
            },
            yAxis: {
                title: {
                    text: ''
                },
            },
            xAxis: {
                labels: { enabled: false }
            },
            series: columnSeries
        });
        $("#exporterPdf" + smartChartId).on('click', function () {
            //columnChart.highcharts().exportChart({
            //    type: "application/pdf", filename: chartName + "_" + new Date().getDate()
            //})
            $scope.$apply(function () {
                $scope.exportChartName = chartName;
                $scope.currentExportId = smartChartId;
                $scope.currentExportName = chartName;
            })
            $("#exportChartModal").modal("show")
        })
        tableBody += "</tbody>";
        $("#tableContainer_" + smartChartId).html(tableBody);
        $("#tableContainer_" + smartChartId).parent().slimScroll({
            height: "400px",
            width: "100%"
        });
        $("#exporterExcel" + smartChartId).on('click', function () {
            JSONToCSVConvertor(data.ChartData, chartName, true, chartName + "_" + new Date().getDate());
        })

    }

    var DrawPieChart = function (data, smartChartId, chartName) {
        var pieSeries = [];
        var tableBody = "<thead>" +
                            "<tr>" +
                                "<th>Term</th>" +
                                "<th>Count</th>" +
                            "</tr>" +
                        "</thead>" +
                        "<tbody>";
        angular.forEach(data.ChartData, function (chartData) {
            tableBody += "<tr>" +
                            "<td>" + chartData.Term + "</td>" +
                            "<td>" + chartData.theCount + "</td>" +
                        "</tr>";
            pieSeries.push([chartData.Term, parseInt(chartData.theCount)]);
        })
        var pieChart = $('#chartContainer_' + smartChartId).highcharts({
            chart: {
                plotBackgroundColor: null,
                plotBorderWidth: null,
                plotShadow: false
            },
            exporting: {
                enabled: false
            },
            title: {
                text: ''
            },
            tooltip: {
                pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
            },
            plotOptions: {
                pie: {

                    allowPointSelect: true,
                    cursor: 'pointer',
                    dataLabels: {
                        enabled: true,
                        format: '<b>{point.name}</b>: {point.percentage:.1f} %',
                        style: {
                            color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                        }
                    }
                },
                series: {
                    cursor: 'pointer',
                    point: {
                        events: {
                            click: function () {
                                $("#socialPostWindow").dialog("open");
                                $scope.socialPostFilter = smartChartId + "|" + this.name;
                                conversationAjaxCallback();
                            }
                        }
                    }
                }
            },
            series: [{
                type: 'pie',
                name: 'Count',
                data: pieSeries
            }]
        });
        $("#exporterPdf" + smartChartId).on('click', function () {
            //pieChart.highcharts().exportChart({
            //    type: "application/pdf", filename: chartName + "_" + new Date().getDate()
            //})
            $scope.$apply(function () {
                $scope.exportChartName = chartName;
                $scope.currentExportId = smartChartId;
                $scope.currentExportName = chartName;
            })
            $("#exportChartModal").modal("show")
        })
        tableBody += "</tbody>";
        $("#tableContainer_" + smartChartId).html(tableBody);
        $("#tableContainer_" + smartChartId).parent().slimScroll({
            height: "400px",
            width: "100%"
        });
        $("#exporterExcel" + smartChartId).on('click', function () {
            JSONToCSVConvertor(data.ChartData, chartName, true, chartName + "_" + new Date().getDate());
        })

    }
    var paintSummary = function (smartChartId, cssClasses) {
        var sizeClass = "";
        if (cssClasses == null || cssClasses == "" || cssClasses == "undefined") {
            sizeClass = "col-lg-3 col-md-3 col-sm-6 col-xs-12"
        }
        else {
            sizeClass = cssClasses;
        } var container = "<div class='" + sizeClass + "' id='" + smartChartId + "SummaryContainer' ></div>"
        $("#rowChartContainer").append(container);
    }

    var DrawProlificUser = function (data, smartChartId, chartName, commentsCount) {
        var id = "1997";
        var suave = "enterprise";
        var tableBody = "<thead>" +
                    "<tr>" +
                        "<th>User Name</th>" +
                        "<th>Fullname</th>" +
                        "<th>Bio</th>" +
                        "<th>Followers</th>" +
                        "<th>Following</th>" +
                        "<th>Profile Image Url</th>" +
                        "<th>Profile Url</th>" +
                        "<th>Reach</th>" +
                        "<th>Social Network</th>" +
                        "<th>Statuses</th>" +
                    "</tr>" +
                "</thead>" +
                "<tbody>";
        var costumersContainer = "<ul class='list-group recent-comments'>";
        angular.forEach(data.ChartData, function (chartData) {
            tableBody += "<tr>" +
                            "<td>" + chartData.UserName + "</td>" +
                            "<td>" + chartData.FullName + "</td>" +
                            "<td>" + chartData.Bio + "</td>" +
                            "<td>" + chartData.Followers + "</td>" +
                            "<td>" + chartData.Following + "</td>" +
                            "<td>" + chartData.ProfileImageUrl + "</td>" +
                            "<td>" + chartData.ProfileUrl + "</td>" +
                            "<td>" + chartData.Reach + "</td>" +
                            "<td>" + chartData.SocialNetwork + "</td>" +
                            "<td>" + chartData.Statuses + "</td>" +
                        "</tr>";
            if (chartData.ProfileUrl != "") {
                costumersContainer += "<li class='list-group-item clearfix comment-info'>" +
                                                "<div class='avatar pull-left mr15'>" +
                                                    "<img src='" + ProcessImage(chartData.ProfileImageUrl) + "' alt='avatar' style='width:48px;height:48px'>" +
                                                "</div>" +
                                                "<p class='text-ellipsis'><span class='name strong'>" + ProcessScreenName(chartData.UserName) + ": </span>" + chartData.Bio + " </p>" +
                                                "<span class='date text-muted small pull-left'><img style='width:16px;height:16px' src='" +
                        ProcessSocialNetwork(chartData.SocialNetwork) + "'/> " + chartData.Followers + " Followers | " + chartData.Statuses + " Total Posts</span>" +
                                                "<a href='" + chartData.ProfileUrl + "' class='see-more small pull-right' target='_blanc' >View profile</a>" +
                                            "</li>";
            }
            else {
                costumersContainer += "<li class='list-group-item clearfix comment-info'>" +
                                            "<div class='avatar pull-left mr15'>" +
                                                "<img src='" + ProcessImage(chartData.ProfileImageUrl) + "' alt='avatar' style='width:48px;height:48px'>" +
                                            "</div>" +
                                            "<p class='text-ellipsis'><span class='name strong'>" + ProcessScreenName(chartData.UserName) + ": </span>" + chartData.Bio + " </p>" +
                                            "<span class='date text-muted small pull-left'><img style='width:16px;height:16px' src='" +
                ProcessSocialNetwork(chartData.SocialNetwork) + "'/> " + chartData.Followers + " Followers | " + chartData.Statuses + " Total Posts</span>" +
                                        "</li>";
            }
        })
        costumersContainer += "</ul>";
        tableBody += "</tbody>";

        $("#chartContainer_" + smartChartId).html(costumersContainer);
        $("#chartContainer_" + smartChartId).parent().slimScroll({
            height: "400px",
            width: "100%"
        });
        $("#tableContainer_" + smartChartId).html(tableBody);
        $("#tableContainer_" + smartChartId).parent().slimScroll({
            height: "400px",
            width: "100%"
        });
        $("#exporterPdf" + smartChartId).on('click', function () {

            $scope.$apply(function () {
                $scope.exportChartName = chartName;
                $scope.currentExportId = smartChartId;
                $scope.currentExportName = chartName;
            })
            $("#exportChartModal").modal("show")
        });
        $("#exporterExcel" + smartChartId).on('click', function () {
            JSONToCSVConvertor(data.ChartData, chartName, true, chartName + "_" + new Date().getDate());

        });

    }

    var DrawTopPost = function (data, smartChartId, chartName, commentsCount) {
        var suave = "enterprise";

        var tableBody = "<thead>" +
                    "<tr>" +
                        "<th>Message</th>" +
                        "<th>Number of Post</th>" +
                        "<th>Social Network</th>" +
                        "<th>Product</th>" +
                    "</tr>" +
                "</thead>" +
                "<tbody>";
        var costumersContainer = "<ul id='yourmomma' class='list-group recent-comments'>";
        angular.forEach(data.ChartData, function (chartData) {
            tableBody += "<tr>" +
                            "<td>" + chartData.Message + "</td>" +
                            "<td>" + chartData.dMessage + "</td>" +
                            "<td>" + chartData.SocialNetwork + "</td>" +
                            "<td>" + chartData.Product + "</td>" +
                        "</tr>";

            costumersContainer += "<li class='list-group-item clearfix comment-info'>" +
                                            "<div class='panel-body panelSmart-body'> <div class='socialPostItem'><div class='SocialPostMessage' > <div>" + chartData.Message + "</div>  </div>  </div> </div>" +
                                            "<span class='date text-muted small pull-left'><img style='width:16px;height:16px' src='" +
                    ProcessSocialNetwork(chartData.SocialNetwork) + "'/> " + chartData.dMessage + " Total Posts </span>" +
                   "<a href='javascript:void(0)' class='see-more small pull-right' ng-click=\"conversationStreamWordCloudPerMessage('" + chartData.idSmartReport + "','" + chartData.Message.substring(0, 10) + "')\"> View all posts </a> " +
              "</li>";
        })
        costumersContainer += "</ul>";
        tableBody += "</tbody>";

        $("#chartContainer_" + smartChartId).html(costumersContainer);
        $("#chartContainer_" + smartChartId).parent().slimScroll({
            height: "400px",
            width: "100%"
        });


        $("#tableContainer_" + smartChartId).html(tableBody);
        $("#tableContainer_" + smartChartId).parent().slimScroll({
            height: "400px",
            width: "100%"
        });
        $("#exporterPdf" + smartChartId).on('click', function () {

            $scope.$apply(function () {
                $scope.exportChartName = chartName;
                $scope.currentExportId = smartChartId;
                $scope.currentExportName = chartName;
            })
            $("#exportChartModal").modal("show")
        });
        $("#exporterExcel" + smartChartId).on('click', function () {
            JSONToCSVConvertor(data.ChartData, chartName, true, chartName + "_" + new Date().getDate());
        });
        $compile($('#yourmomma'))($scope);
    }

    var DrawTopPosts = function (data, smartChartId, chartName, commentsCount) {
        var suave = "enterprise";

        var tableBody = "<thead>" +
                    "<tr>" +
                        "<th>Message</th>" +
                        "<th>Number of Post</th>" +
                        "<th>Social Network</th>" +
                        "<th>Product</th>" +
                    "</tr>" +
                "</thead>" +
                "<tbody>";
        var costumersContainer = "<ul id='yourmomma' class='list-group recent-comments'>";
        
        angular.forEach(data.ChartData, function (chartData) {
            
            tableBody += "<tr>" +
                            "<td>" + chartData.Message + "</td>" +
                            "<td>" + chartData.dMessage + "</td>" +
                            "<td>" + chartData.SocialNetwork + "</td>" +
                            "<td>" + chartData.Product + "</td>" +
                        "</tr>";

            costumersContainer += "<div>" + chartData.Product + "</div>";
            costumersContainer += "<li class='list-group-item clearfix comment-info'>" +
                                            "<div class='panel-body panelSmart-body'> <div class='socialPostItem'><div class='SocialPostMessage' > <div>" + chartData.Message + "</div>  </div>  </div> </div>" +
                                            "<span class='date text-muted small pull-left'><img style='width:16px;height:16px' src='" +
                    ProcessSocialNetwork(chartData.SocialNetwork) + "'/> " + chartData.dMessage + " Total Posts </span>" +
                   "<a href='javascript:void(0)' class='see-more small pull-right' ng-click=\"conversationStreamWordCloudPerMessage('" + chartData.idSmartReport + "','" + chartData.Message.substring(0, 10) + "')\"> View all posts </a> " +
              "</li>";
        })
        costumersContainer += "</ul>";
        tableBody += "</tbody>";

        $("#chartContainer_" + smartChartId).html(costumersContainer);
        $("#chartContainer_" + smartChartId).parent().slimScroll({
            height: "400px",
            width: "100%"
        });


        $("#tableContainer_" + smartChartId).html(tableBody);
        $("#tableContainer_" + smartChartId).parent().slimScroll({
            height: "400px",
            width: "100%"
        });
        $("#exporterPdf" + smartChartId).on('click', function () {

            $scope.$apply(function () {
                $scope.exportChartName = chartName;
                $scope.currentExportId = smartChartId;
                $scope.currentExportName = chartName;
            })
            $("#exportChartModal").modal("show")
        });
        $("#exporterExcel" + smartChartId).on('click', function () {
            JSONToCSVConvertor(data.ChartData, chartName, true, chartName + "_" + new Date().getDate());
        });
        $compile($('#yourmomma'))($scope);
    }

    var DrawSummaryReach = function (data, smartChartId, chartName, commentsCount) {
        var comparison = "";
        if (data.PastDelivery == null) {
            comparison = "No previous data"
        }
        else {
            if (parseInt(data.ChartData.theCount) > parseInt(data.PastDelivery.theCount)) {
                comparison = "<span><i class='fa fa-angle-double-up'></i> " + (parseInt(data.ChartData.theCount) - parseInt(data.PastDelivery.theCount)).toString() + " people from last delivery</span>"
            }
            else if (parseInt(data.ChartData.theCount) == parseInt(data.PastDelivery.theCount)) {
                comparison = "<span><i class='fa fa-long-arrow-right'></i> The reach is the same from last delivery</span>"
            }
            else {
                comparison = "<span><i class='fa fa-angle-double-down'></i> " + (parseInt(data.PastDelivery.theCount) - parseInt(data.ChartData.theCount)).toString() + " people from last delivery</span>"
            }
        }
        if ($scope.fromValue != $scope.toValue) {
            comparison = "";
            $("#summaryBody" + smartChartId).height("auto");
        }
        else {
            comparison = "<div class='col-lg-12 col-md-12 col-sm-12 col-xs-12'>" +
            "<div class='comparison'>" +
                "<p class='mb0'>" + comparison + "</p>" +
            "</div>" +
        "</div>";
        }
        var summaryTemplate = "<div class='row progressbar-stats-1'>" +
        "<div class='col-lg-12 col-md-12 col-sm-12 col-xs-12'>" +
            "<div class='row-fluid stats'>" +
                "<div class='col-lg-12 col-md-12 col-sm-12 col-xs-12'>" +
                    "<a href='javascript:void(0)' class='summaryFonts' style='color:white' ng-click=\"conversationStreamWordCloud(" + smartChartId + ",'" + data.ChartData.Term + "')\">" +
                        "<i class=' l-ecommerce-graph3'></i>" +
                        "<div data-from='0' data-to='0'>" +
                            data.ChartData.theCount + " People" +
                        "</div>" +
                    "</a>" +
                "</div>" +
            "</div>" +
        "</div>" +
        "<div class='col-lg-12 col-md-12 col-sm-12 col-xs-12'>" +
            "<div class='progress animated-bar flat transparent progress-bar-xs mb10 mt0'>" +
                "<div class='progress-bar progress-bar-white' role='progressbar' data-transitiongoal='100' aria-valuenow='100' style='width: 100%;'>" +
                "</div>" +
            "</div>" +
        "</div>" +
        comparison +
                                    "</div>";
        $("#summaryBody" + smartChartId).append(summaryTemplate);
        $("#summaryBody" + smartChartId).parent().addClass("panel-success").addClass("panelSmart-success");
        $compile($("#summaryBody" + smartChartId))($scope);
        //$("#rowChartContainer").prepend(summaryTemplate)
    }

    var DrawSummaryMentions = function (data, smartChartId, chartName, commentsCount) {
        var comparison = "";
        if (data.PastDelivery == null) {
            comparison = "No previous data"
        }
        else {
            if (parseInt(data.ChartData.theCount) > parseInt(data.PastDelivery.theCount)) {
                comparison = "<span><i class='fa fa-angle-double-up'></i> " + (parseInt(data.ChartData.theCount) - parseInt(data.PastDelivery.theCount)).toString() + " Posts from last delivery</span>"
            }
            else if (parseInt(data.ChartData.theCount) == parseInt(data.PastDelivery.theCount)) {
                comparison = "<span><i class='fa fa-long-arrow-right'></i> The mentions are the same from last delivery</span>"
            }
            else {
                comparison = "<span><i class='fa fa-angle-double-down'></i> " + (parseInt(data.PastDelivery.theCount) - parseInt(data.ChartData.theCount)).toString() + " Posts from last delivery</span>"
            }
        }
        if ($scope.fromValue != $scope.toValue) {
            comparison = "";
            $("#summaryBody" + smartChartId).height("auto");
        }
        else {
            comparison = "<div class='col-lg-12 col-md-12 col-sm-12 col-xs-12'>" +
            "<div class='comparison'>" +
                "<p class='mb0'>" + comparison + "</p>" +
            "</div>" +
        "</div>";
        }
        var summaryTemplate = "<div class='row progressbar-stats-1'>" +
        "<div class='col-lg-12 col-md-12 col-sm-12 col-xs-12'>" +
            "<div class='row-fluid stats'>" +
                "<div class='col-lg-12 col-md-12 col-sm-12 col-xs-12'>" +
                "<a href='javascript:void(0)' class='summaryFonts'  style='color:white' ng-click=\"conversationStreamWordCloud(" + smartChartId + ",'" + data.ChartData.Term + "')\">" +
                    "<i class=' l-ecommerce-megaphone'></i>" +
                    "<div data-from='0' data-to='0'>" +
                        data.ChartData.theCount + " Posts" +
                    "</div>" +
                "</a>" +
                "</div>" +
            "</div>" +
        "</div>" +
        "<div class='col-lg-12 col-md-12 col-sm-12 col-xs-12'>" +
            "<div class='progress animated-bar flat transparent progress-bar-xs mb10 mt0'>" +
                "<div class='progress-bar progress-bar-white' role='progressbar' data-transitiongoal='100' aria-valuenow='100' style='width: 100%;'>" +
                "</div>" +
            "</div>" +
        "</div>" +
            comparison +
        "</div>" +
    "</div>" +
"</div>";
        $("#summaryBody" + smartChartId).append(summaryTemplate);
        $("#summaryBody" + smartChartId).parent().addClass("panel-info").addClass("panelSmart-info");
        $compile($("#summaryBody" + smartChartId))($scope);
        //$("#rowChartContainer").prepend(summaryTemplate)
    }

    var DrawSummaryDay = function (data, smartChartId, chartName, commentsCount) {
        var comparison = "";
        if (data.PastDelivery == null) {
            comparison = "No previous data"
        }
        else {
            if (parseInt(data.ChartData.theCount) > parseInt(data.PastDelivery.theCount)) {
                comparison = "<span><i class='fa fa-angle-double-up'></i> " + (parseInt(data.ChartData.theCount) - parseInt(data.PastDelivery.theCount)).toString() + " Posts from last delivery</span>"
            }
            else if (parseInt(data.ChartData.theCount) == parseInt(data.PastDelivery.theCount)) {
                comparison = "<span><i class='fa fa-long-arrow-right'></i> same from last delivery</span>"
            }
            else {
                comparison = "<span><i class='fa fa-angle-double-down'></i> " + (parseInt(data.PastDelivery.theCount) - parseInt(data.ChartData.theCount)).toString() + " Posts from last delivery</span>"
            }
        }
        if ($scope.fromValue != $scope.toValue) {
            comparison = "";
            $("#summaryBody" + smartChartId).height("auto");
        }
        else {
            comparison = "<div class='col-lg-12 col-md-12 col-sm-12 col-xs-12'>" +
            "<div class='comparison'>" +
                "<p class='mb0'>" + comparison + "</p>" +
            "</div>" +
        "</div>";
        }
        var dateFromServer = new Date(data.ChartData.Term);

        var summaryTemplate = "<div class='row progressbar-stats-1'>" +
            "<div class='col-lg-12 col-md-12 col-sm-12 col-xs-12'>" +
                "<div class='row-fluid stats'>" +
                    "<div class='col-lg-12 col-md-12 col-sm-12 col-xs-12 summaryFonts'>" +
                        "<i class=' l-basic-calendar'></i>" +
                        "<div data-from='0' data-to='0'>" +
                            dateFromServer.toLocaleString("en-us", { month: "long" }) + " " + dateFromServer.getDate() + " (" + data.ChartData.theCount + " Mentions)" +
                        "</div>" +
                    "</div>" +
                "</div>" +
            "</div>" +
            "<div class='col-lg-12 col-md-12 col-sm-12 col-xs-12'>" +
                "<div class='progress animated-bar flat transparent progress-bar-xs mb10 mt0'>" +
                    "<div class='progress-bar progress-bar-white' role='progressbar' data-transitiongoal='100' aria-valuenow='100' style='width: 100%;'>" +
                    "</div>" +
                "</div>" +
            "</div>" +
            comparison +
        "</div>" +
    "</div>";
        $("#summaryBody" + smartChartId).append(summaryTemplate);
        $("#summaryBody" + smartChartId).parent().addClass("panel-danger").addClass("panelSmart-danger");
        $compile($("#summaryBody" + smartChartId))($scope);
        //$("#rowChartContainer").prepend(summaryTemplate)
    }

    var DrawSummaryUser = function (data, smartChartId, chartName, commentsCount) {
        var comparison = "";
        if (data.PastDelivery == null) {
            comparison = "No previous data"
        }
        else {
            comparison = "<span><i class='fa fa-user'></i> " + data.PastDelivery.Term + ": " + data.PastDelivery.theCount + " was previously best</span>"
        }
        if ($scope.fromValue != $scope.toValue) {
            comparison = "";
            $("#summaryBody" + smartChartId).height("auto");
        }
        else {
            comparison = "<div class='col-lg-12 col-md-12 col-sm-12 col-xs-12'>" +
            "<div class='comparison'>" +
                "<p class='mb0'>" + comparison + "</p>" +
            "</div>" +
        "</div>";
        }
        var summaryTemplate = "<div class='row progressbar-stats-1 dark'>" +
            "<div class='col-lg-12 col-md-12 col-sm-12 col-xs-12 summaryFonts' >" +
                "<div class='row-fluid stats'>" +
                    "<div class='col-lg-9 col-md-8 col-sm-8 col-xs-6'>" +
                        "<div class='row stats'>" +
                            "<i class=' l-weather-star'></i>" +
                                "<div data-from='0' data-to='0'>" +
                                    data.ChartData.Term + ": " + data.ChartData.theCount +
                                "</div>" +
                        "</div>" +
                    "</div>" +
                    //"<div class='col-lg-3 col-md-4 col-sm-4 col-xs-6'>" +
                    //    "<div data-from='0' data-to='0'>" + data.ChartData.theCount + "</div>" +
                    //"</div>" +
                "</div>" +
            "</div>" +
            "<div class='col-lg-12 col-md-12 col-sm-12 col-xs-12'>" +
                "<div class='progress animated-bar flat transparent progress-bar-xs mb10 mt0'>" +
                    "<div class='progress-bar progress-bar-white' role='progressbar' data-transitiongoal='100' aria-valuenow='100' style='width: 100%;'>" +
                    "</div>" +
                "</div>" +
            "</div>" +
             comparison +
        "</div>" +
    "</div>";
        $("#summaryBody" + smartChartId).append(summaryTemplate);
        $("#summaryBody" + smartChartId).parent().addClass("panel-default").addClass("panelSmart-default");
        $compile($("#summaryBody" + smartChartId))($scope);
        //$("#rowChartContainer").prepend(summaryTemplate)
    }

    var DrawWordCloud = function (data, smartChartId, chartName, commentsCount) {
        var words = [];
        var tableBody = "<thead>" +
                            "<tr>" +
                                "<th>Term</th>" +
                                "<th>Count</th>" +
                            "</tr>" +
                        "</thead>" +
                        "<tbody>";
        angular.forEach(data.ChartData, function (chartData) {
            tableBody += "<tr>" +
                                       "<td>" + chartData.Term + "</td>" +
                                       "<td>" + chartData.theCount + "</td>" +
                                   "</tr>";
            var wordToAdd = { text: chartData.Term, weight: chartData.theCount, link: "conversationStreamWordCloud('" + smartChartId + "','" + chartData.Term.replace("'", "") + "')", isAngular: true }
            words.push(wordToAdd);
        })
        $('#chartContainer_' + smartChartId).append("<div id='wordCloudContainer_" + smartChartId + "' style='height:390px;width:99%;margin: 5px;'></div>")
        $('#wordCloudContainer_' + smartChartId).jQCloud(words, {
            autoResize: true,
            fontSize: {
                from: 0.1,
                to: 0.03
            },
            afterCloudRender: function () {
                $compile($('#wordCloudContainer_' + smartChartId))($scope);
            }
        });
        tableBody += "</tbody>";
        $("#tableContainer_" + smartChartId).html(tableBody);
        $("#tableContainer_" + smartChartId).parent().slimScroll({
            height: "400px",
            width: "100%"
        });
        $("#exporterPdf" + smartChartId).on('click', function () {

            $scope.$apply(function () {
                $scope.exportChartName = chartName;
                $scope.currentExportId = smartChartId;
                $scope.currentExportName = chartName;
            })
            $("#exportChartModal").modal("show")
        });
        $("#exporterExcel" + smartChartId).on('click', function () {
            JSONToCSVConvertor(data.ChartData, chartName, true, chartName + "_" + new Date().getDate());

        })


    }

    var DrawLocationAnalysis = function (data, smartChartId, chartName, commentsCount) {
        //var locations = [];
        var tableBody = "<thead>" +
                    "<tr>" +
                        "<th>Country</th>" +
                        "<th>Counter</th>" +
                    "</tr>" +
                "</thead>" +
                "<tbody>";
        var worldData = [];
        angular.forEach(data.ChartData, function (chartData) {
            tableBody += "<tr>" +
                "<td><div class='flag flag-" + AppendFlag(chartData.Term) + "' style='display:inline-block'></div><div style='display:inline-block'>&nbsp;&nbsp;" + chartData.Term + "</div> </td>" +
                "<td>" + chartData.theCount + "</td>" +
            "</tr>";
            var countryData = {
                "hc-key": isoCountries[chartData.Term],
                "value": chartData.theCount
            };
            worldData.push(countryData);
        })
        var map = $("#chartContainer_" + smartChartId).highcharts('Map', {

            title: {
                text: null
            },
            exporting: {
                enabled: false
            },
            mapNavigation: {
                enabled: true
            },
            colorAxis: {
                min: 0,
                labels: {
                    enabled: false,
                },
                //tickPosition:"inside",
                //type: "logarithmic"
                //reversed:true
                //gridLineDashStyle:"LongDash"
                
            },
            series: [{
                data: worldData,
                mapData: Highcharts.maps['custom/world'],
                joinBy: 'hc-key',
                //name: 'Mentions',
                states: {
                    hover: {
                        color: Highcharts.getOptions().colors[2]
                    }
                },
                cursor: 'pointer',
                point: {
                    events: {
                        click: function () {
                            $("#socialPostWindow").dialog("open");
                            $scope.socialPostFilter = smartChartId + "|" + countries[this.properties['hc-key']];
                            conversationAjaxCallback();
                        }
                    }
                }
            }]
        }).height("400px");
        $("#exporterPdf" + smartChartId).on('click', function () {
            //map.highcharts().exportChart({ type: "application/pdf", filename: chartName + "_" + new Date().getDate() })
            $scope.$apply(function () {
                $scope.exportChartName = chartName;
                $scope.currentExportId = smartChartId;
                $scope.currentExportName = chartName;
            })
            $("#exportChartModal").modal("show")
        })
        $('#tableContainer_' + smartChartId).append("<table class='table table-striped' id='locationContainer_" + smartChartId + "'></table>")
        tableBody += "</tbody>"
        $('#tableContainer_' + smartChartId).html(tableBody);
        $('#tableContainer_' + smartChartId).parent().slimScroll({
            height: "400px",
            width: "100%"
        });
        $("#exporterExcel" + smartChartId).on('click', function () {
            JSONToCSVConvertor(data.Series.series, chartName, true, chartName + "_" + new Date().getDate());
        })


    }

    var paintHtml = function (chartName, smartChartId, commentsCount, insights, cssClasses, idChartType) {
        var sizeClass = "";
        if (cssClasses == null || cssClasses == "" || cssClasses == "undefined") {
            sizeClass = "col-lg-6 col-md-6 col-sm-6 col-xs-12"
        }
        else {
            sizeClass = cssClasses;
        }
        var htmlToPaint = "<div class='" + sizeClass + "'><div class='panel panel-default toggle panelRefresh' id='dyn_" + smartChartId + "'>" +
                                    "<div class='panel-heading'>" +
        "<h4 class='panel-title'>" + chartName + "</h4><div class='customSpinner' id='spinner_" + smartChartId + "'></div>" +
                    "<div class='panel-controls panel-controls-right'>" +
                        "<a href='javascript:void()' title='" + insights + "'><i class='fa fa-question'></i></a>" +
                        "<a href='javascript:void(0)'  title='Change View' id='aChartTable'><i onClick='ChangeIconOpenTab(this," + smartChartId + ")' id='iconGraphChart_" + smartChartId + "' class='l-software-layout-8boxes'></i></a>" +
                        "<a href='javascript:void(0)' title='Reload Data' class='panel-refresh' onClick='ReloadChart(" + idChartType + "," + smartChartId + ")'>" +
                            "<i class='fa  fa-refresh'></i>" +
                        "</a>" +
                        "<a href='javascript:void(0)'  title='Comments' type='button' id='" + chartName + 1 + "Menu' onClick='lunchPopOver(this," + smartChartId + ")' aria-expanded='true' >" +
                            "<i class='fa fa-comments-o white counter' aria-hidden='true'></i>  <span class='badge badge-notify' id='" + smartChartId + "_CommentCounter'>" + commentsCount + "</span>" +
                        "</a>" +
                        "<div id='" + smartChartId + "_PopUp'  class='popover-markup'>" +
                            "<div class='head head-popup_" + smartChartId + " hide'>Comments</div>" +
                        "<div class='content content-popup_" + smartChartId + " hide'>" +
                            "<div class='row'>" +
                                "<div class='col-lg-12 commentsField' id='commentsField_" + smartChartId + "'></div>" +
                            "</div>" +
                            "<div class='row'>" +
                                "<div class='col-lg-12'>" +
                                    "<div class='input-group'>" +
                                        "<input type='text' name='" + smartChartId + "_" + smartChartId + "' onKeyDown='if(event.keyCode==13) postComment(" + smartChartId + ");' class='form-control' id='txtComment_" + smartChartId + "'  pattern='[a-zA-Z0-9]+' placeholder='New Comment' />" +
                                        "<span class='input-group-btn'>" +
                                            "<button class='btn btn-default' onClick='postComment(" + smartChartId + ")' type='button'>" +
                                                "<i class='fa fa-chevron-right'></i>" +
                                            "</button>" +
                                        "</span>" +
                                    "</div>" +
                                "</div>" +
                            "</div>" +
                        "</div>" +
                    "</div>" +
                "</div>" +
            "</div>" +
            "<div class='panel-body p0'>" +
            "<a id='achartPill_" + smartChartId + "'  style='visibility: hidden' href='#chartPill_" + smartChartId + "' aria-controls='chartPill_" + smartChartId + "' role='tab' data-toggle='tab' onclick='return false'></a>" +
            "<a id='atablePill_" + smartChartId + "'  style='visibility: hidden' href='#tablePill_" + smartChartId + "' aria-controls='tablePill_" + smartChartId + "' role='tab' data-toggle='tab' onclick='return false'></a>" +
                "<div class='tabs inside-panel tabContainerMargin'>" +
                    "<div class='tab-content'>" +
                        "<div role='tabpanel' class='tab-pane active' id='chartPill_" + smartChartId + "'>" +
                            "<div class='row-fluid'>" +
                                "<div class='canvas-holder' id='chartContainer_" + smartChartId + "'></div>" +
                            "</div>" +
                        "</div>" +
                        "<div role='tabpanel' class='tab-pane container-fluid' id='tablePill_" + smartChartId + "'>" +
                            "<div class='row-fluid '>" +
                                "<table class='table table-striped' id='tableContainer_" + smartChartId + "'>" +

                                "</table>" +
                            "</div>" +
                        "</div>" +
                    "</div>" +
        "</div>" +
        "</div>" +
        "</div>" +
                                            "</div>";
        $("#rowChartContainer").append(htmlToPaint);

    };

    var conversationAjaxCallback = function () {
        jQuery.ajaxSettings.traditional = true;
        $.ajax({
            type: "GET",
            url: "../Data/GetConversationStream",
            data: {
                reportId: $scope.reportsIdInRange, filter: $scope.socialPostFilter, rowsSkipped: $scope.socialPostModel.length
            },
            dataType: "Json",
            success: function (data) {
                if (data.Acknowledgment) {
                    $scope.$apply(function () {
                        angular.forEach(data.conversationStreamObjects, function (socialPost) {
                            $scope.socialPostModel.push(socialPost);
                        });
                    });
                    if ($scope.socialPostModel.length == 0) {
                        $("#noItems").show();
                        $("#loadingImg").hide();
                        $("#socialPostContainer").hide();
                    }
                    else {
                        $("#socialPostContainer").show();
                        $("#loadingImg").hide();
                        $("#noItems").hide();
                    }
                }
                else {

                }
            }
        });
    }

    var conversationAjaxCallbackMessage = function () {
        jQuery.ajaxSettings.traditional = true;
        $.ajax({
            type: "GET",
            url: "../Data/GetConversationStreamMessage",
            data: {
                reportId: $scope.reportsIdInRange, filter: $scope.socialPostFilterMessage, rowsSkipped: $scope.socialPostModel.length
            },
            dataType: "Json",
            success: function (data) {
                if (data.Acknowledgment) {
                    $scope.$apply(function () {
                        angular.forEach(data.conversationStreamObjects, function (socialPost) {
                            $scope.socialPostModel.push(socialPost);
                        });
                    });
                    if ($scope.socialPostModel.length == 0) {
                        $("#noItems").show();
                        $("#loadingImg").hide();
                        $("#socialPostContainer").hide();
                    }
                    else {
                        $("#socialPostContainer").show();
                        $("#loadingImg").hide();
                        $("#noItems").hide();
                    }
                }
                else {

                }
            }
        });
    }

    var ProcessLeftBarMenu = function () {
        setTimeout(function () {
            if (isMenusLoaded) {
                $(".reportsContainer").on('hide.bs.collapse', function () {
                    $("#" + $(this).data("iconid")).removeClass("fa-folder-open").addClass("fa-folder");
                });
                $(".reportsContainer").on('show.bs.collapse', function () {
                    $("#" + $(this).data("iconid")).removeClass("fa-folder").addClass("fa-folder-open");
                });
                $(".activeReport").removeClass("activeReport").addClass("reportDelivered");
                var reportsIds = $routeParams.reportId.split("+");
                var reportBtn = $('#report' + $routeParams.reportId.split("+")[0]);
                var report2Btn = $('#report' + $routeParams.reportId.split("+")[0]);
                if (reportsIds.length > 1) {
                    report2Btn = $('#report' + $routeParams.reportId.split("+")[1]);
                }
                else {
                    $scope.reportsIdInRange.push($routeParams.reportId.split("+")[0]);
                }
                if (reportBtn.hasClass("hidden")) {
                    $scope.$parent.showMoreReports = true;
                    $scope.$apply();
                }
                reportBtn = $('#report' + $routeParams.reportId.split("+")[0]);
                var reportsBtn = reportBtn.parent().find("a");
                var reports = [];
                var isActive = false;
                var from = { date: reportBtn.text() };
                var to = { date: report2Btn.text() };
                for (var i = 0; i < reportsBtn.length; i++) {
                    if ($(reportsBtn[i]).text() != " Show More...") {
                        var thisdateReport = $(reportsBtn[i]).text();
                        var thisIdReport = $(reportsBtn[i]).attr("id").split("report")[$(reportsBtn[i]).attr("id").split("report").length - 1];
                        if (reportsIds.length > 1) {
                            if (isActive) {
                                $(reportsBtn[i]).addClass("activeReport");
                                $scope.reportsIdInRange.push(thisIdReport);
                                if (thisIdReport == $routeParams.reportId.split("+")[1]) {
                                    isActive = false;
                                    to.order = i;
                                }
                            }
                            if (thisIdReport == $routeParams.reportId.split("+")[0]) {
                                $scope.reportsIdInRange.push(thisIdReport);
                                isActive = true;
                                from.order = i;
                            }
                        }
                        else {
                            if (thisIdReport == $routeParams.reportId.split("+")[0]) {
                                from.order = i;
                                to.order = i;
                            }
                        }
                        reports.push({ dateReport: thisdateReport, reportId: thisIdReport, order: i });
                    }
                }
                if ($("#sharedContainer").length > 0) {
                    if ($.contains($("#sharedContainer")[0], $('#report' + $routeParams.reportId.split("+")[0])[0])) {
                        $scope.$apply(function () {
                            reportBtn.addClass("activeReport").parent().collapse("show");
                            $scope.isSharedWithMe = true;
                            $scope.reportsRange = reports;
                            $scope.fromDropdownValue = from;
                            $scope.fromValue = reportBtn.text();
                            $scope.$parent.fromValue = reportBtn.text();
                            $scope.toDropdownValue = to;
                            $scope.toValue = report2Btn.text();
                            $scope.$parent.toValue = report2Btn.text();
                            $scope.isMenuProcess = true;
                        });
                    }
                    else {
                        $scope.$apply(function () {
                            reportBtn.addClass("activeReport").parent().collapse("show");
                            $scope.isSharedWithMe = false;
                            $scope.reportsRange = reports;
                            $scope.fromDropdownValue = from;
                            $scope.fromValue = reportBtn.text();
                            $scope.$parent.fromValue = reportBtn.text();
                            $scope.toDropdownValue = to;
                            $scope.toValue = report2Btn.text();
                            $scope.$parent.toValue = report2Btn.text();
                            $scope.isMenuProcess = true;
                        });
                    }
                }
                else {
                    $scope.$apply(function () {
                        reportBtn.addClass("activeReport").parent().collapse("show");
                        $scope.isSharedWithMe = false;
                        $scope.reportsRange = reports;
                        $scope.fromDropdownValue = from;
                        $scope.fromValue = reportBtn.text();
                        $scope.$parent.fromValue = reportBtn.text();
                        $scope.toDropdownValue = to;
                        $scope.toValue = report2Btn.text();
                        $scope.$parent.toValue = report2Btn.text();
                        $scope.isMenuProcess = true;
                    });
                }
            }
            else {
                ProcessLeftBarMenu();
            }
        }, 500);
    }

    var ProcessMessagePreview = function (message) {
        var messageProcessed = $("<div>" + message + "</div>").text();
        return messageProcessed;
    }

    var ProcessScreenName = function (name) {
        if (name == "") {
            return "User";
        }

        return name;
    }

    var ProcessImage = function (imageSrc) {
        if (imageSrc == "") {
            return "../images/userPlaceHolder.jpg";
        }
        return imageSrc;
    }

    var ProcessSocialNetwork = function (socialNetwork) {
        switch (socialNetwork) {
            case "TWITTER":
                return "../images/SocialNetworkIcons/twitter-icon.png";
            case "WORDPRESS":
                return "../images/SocialNetworkIcons/wordpress-icon.png";
            case "WEB":
                return "../images/SocialNetworkIcons/blog-icon.jpg";
            case "FACEBOOK":
                return "../images/SocialNetworkIcons/facebook-icon.jpg";
            case "WEB":
                return "../images/SocialNetworkIcons/forum-icon.png";
            case "REDDIT":
                return "../images/SocialNetworkIcons/reddit-icon.png";
            case "GOOGLE_PLUS":
                return "../images/SocialNetworkIcons/google-plus-icon.png";
            case "INSTAGRAM":
                return "../images/SocialNetworkIcons/Instagram-icon.png";
            case "YOUTUBE":
                return "../images/SocialNetworkIcons/youtube-icon.png";
            default:
                return "../images/SocialNetworkIcons/blog-icon.jpg";
        }
    }

    var ProcessMessage = function (message) {
        return "<div>" + message + "</div>"
    }

    var countries = {
        'af': 'Afghanistan',
        'ax': 'Aland Islands',
        'al': 'Albania',
        'dz': 'Algeria',
        'as': 'American Samoa',
        'ad': 'Andorra',
        'ao': 'Angola',
        'ai': 'Anguilla',
        'aq': 'Antarctica',
        'ag': 'Antigua And Barbuda',
        'ar': 'Argentina',
        'am': 'Armenia',
        'aw': 'Aruba',
        'au': 'Australia',
        'at': 'Austria',
        'az': 'Azerbaijan',
        'bs': 'Bahamas',
        'bh': 'Bahrain',
        'bd': 'Bangladesh',
        'bb': 'Barbados',
        'by': 'Belarus',
        'be': 'Belgium',
        'bz': 'Belize',
        'bj': 'Benin',
        'bm': 'Bermuda',
        'bt': 'Bhutan',
        'bo': 'Bolivia',
        'ba': 'Bosnia And Herzegovina',
        'bw': 'Botswana',
        'bv': 'Bouvet Island',
        'br': 'Brazil',
        'io': 'British Indian Ocean Territory',
        'bn': 'Brunei Darussalam',
        'bg': 'Bulgaria',
        'bf': 'Burkina Faso',
        'bi': 'Burundi',
        'kh': 'Cambodia',
        'cm': 'Cameroon',
        'ca': 'Canada',
        'cv': 'Cape Verde',
        'ky': 'Cayman Islands',
        'cf': 'Central African Republic',
        'td': 'Chad',
        'cl': 'Chile',
        'cn': 'China',
        'cx': 'Christmas Island',
        'cc': 'Cocos (Keeling) Islands',
        'co': 'Colombia',
        'km': 'Comoros',
        'cg': 'Congo',
        'cd': 'Congo, Democratic Republic',
        'ck': 'Cook Islands',
        'cr': 'Costa Rica',
        'ci': 'Cote D\'Ivoire',
        'hr': 'Croatia',
        'cu': 'Cuba',
        'cy': 'Cyprus',
        'cz': 'Czech Republic',
        'dk': 'Denmark',
        'dj': 'Djibouti',
        'dm': 'Dominica',
        'do': 'Dominican Republic',
        'ec': 'Ecuador',
        'eg': 'Egypt',
        'sv': 'El Salvador',
        'gq': 'Equatorial Guinea',
        'er': 'Eritrea',
        'ee': 'Estonia',
        'et': 'Ethiopia',
        'fk': 'Falkland Islands (Malvinas)',
        'fo': 'Faroe Islands',
        'fj': 'Fiji',
        'fi': 'Finland',
        'fr': 'France',
        'gf': 'French Guiana',
        'pf': 'French Polynesia',
        'tf': 'French Southern Territories',
        'ga': 'Gabon',
        'gm': 'Gambia',
        'ge': 'Georgia',
        'de': 'Germany',
        'gh': 'Ghana',
        'gi': 'Gibraltar',
        'gr': 'Greece',
        'gl': 'Greenland',
        'gd': 'Grenada',
        'gp': 'Guadeloupe',
        'gu': 'Guam',
        'gt': 'Guatemala',
        'gg': 'Guernsey',
        'gn': 'Guinea',
        'gw': 'Guinea-Bissau',
        'gy': 'Guyana',
        'ht': 'Haiti',
        'hm': 'Heard Island & Mcdonald Islands',
        'va': 'Holy See (Vatican City State)',
        'hn': 'Honduras',
        'hk': 'Hong Kong',
        'hu': 'Hungary',
        'is': 'Iceland',
        'in': 'India',
        'id': 'Indonesia',
        'ir': 'Iran, Islamic Republic Of',
        'iq': 'Iraq',
        'ie': 'Ireland',
        'im': 'Isle Of Man',
        'il': 'Israel',
        'it': 'Italy',
        'jm': 'Jamaica',
        'jp': 'Japan',
        'je': 'Jersey',
        'jo': 'Jordan',
        'kz': 'Kazakhstan',
        'ke': 'Kenya',
        'ki': 'Kiribati',
        'kr': 'Korea',
        'kw': 'Kuwait',
        'kg': 'Kyrgyzstan',
        'la': 'Lao People\'s Democratic Republic',
        'lv': 'Latvia',
        'lb': 'Lebanon',
        'ls': 'Lesotho',
        'lr': 'Liberia',
        'ly': 'Libyan Arab Jamahiriya',
        'li': 'Liechtenstein',
        'lt': 'Lithuania',
        'lu': 'Luxembourg',
        'mo': 'Macao',
        'mk': 'Macedonia',
        'mg': 'Madagascar',
        'mw': 'Malawi',
        'my': 'Malaysia',
        'mv': 'Maldives',
        'ml': 'Mali',
        'mt': 'Malta',
        'mh': 'Marshall Islands',
        'mq': 'Martinique',
        'mr': 'Mauritania',
        'mu': 'Mauritius',
        'yt': 'Mayotte',
        'mx': 'Mexico',
        'fm': 'Micronesia, Federated States Of',
        'md': 'Moldova',
        'mc': 'Monaco',
        'mn': 'Mongolia',
        'me': 'Montenegro',
        'ms': 'Montserrat',
        'ma': 'Morocco',
        'mz': 'Mozambique',
        'mm': 'Myanmar',
        'na': 'Namibia',
        'nr': 'Nauru',
        'np': 'Nepal',
        'nl': 'Netherlands',
        'an': 'Netherlands Antilles',
        'nc': 'New Caledonia',
        'nz': 'New Zealand',
        'ni': 'Nicaragua',
        'ne': 'Niger',
        'ng': 'Nigeria',
        'nu': 'Niue',
        'nf': 'Norfolk Island',
        'mp': 'Northern Mariana Islands',
        'no': 'Norway',
        'om': 'Oman',
        'pk': 'Pakistan',
        'pw': 'Palau',
        'ps': 'Palestinian Territory, Occupied',
        'pa': 'Panama',
        'pg': 'Papua New Guinea',
        'py': 'Paraguay',
        'pe': 'Peru',
        'ph': 'Philippines',
        'pn': 'Pitcairn',
        'pl': 'Poland',
        'pt': 'Portugal',
        'pr': 'Puerto Rico',
        'qa': 'Qatar',
        're': 'Reunion',
        'ro': 'Romania',
        'ru': 'Russian Federation',
        'rw': 'Rwanda',
        'bl': 'Saint Barthelemy',
        'sh': 'Saint Helena',
        'kn': 'Saint Kitts And Nevis',
        'lc': 'Saint Lucia',
        'mf': 'Saint Martin',
        'pm': 'Saint Pierre And Miquelon',
        'vc': 'Saint Vincent and the Grenadines',
        'ws': 'Samoa',
        'sm': 'San Marino',
        'st': 'Sao Tome And Principe',
        'sa': 'Saudi Arabia',
        'sn': 'Senegal',
        'rs': 'Serbia',
        'sc': 'Seychelles',
        'sl': 'Sierra Leone',
        'sg': 'Singapore',
        'sk': 'Slovakia',
        'si': 'Slovenia',
        'sb': 'Solomon Islands',
        'so': 'Somalia',
        'za': 'South Africa',
        'gs': 'South Georgia And Sandwich Isl.',
        'es': 'Spain',
        'lk': 'Sri Lanka',
        'sd': 'Sudan',
        'sr': 'Suriname',
        'sj': 'Svalbard And Jan Mayen',
        'sz': 'Swaziland',
        'se': 'Sweden',
        'ch': 'Switzerland',
        'sy': 'Syrian Arab Republic',
        'tw': 'Taiwan',
        'tj': 'Tajikistan',
        'tz': 'Tanzania',
        'th': 'Thailand',
        'tl': 'Timor-Leste',
        'tg': 'Togo',
        'tk': 'Tokelau',
        'to': 'Tonga',
        'tt': 'Trinidad And Tobago',
        'tn': 'Tunisia',
        'tr': 'Turkey',
        'tm': 'Turkmenistan',
        'tc': 'Turks And Caicos Islands',
        'tv': 'Tuvalu',
        'ug': 'Uganda',
        'ua': 'Ukraine',
        'ae': 'United Arab Emirates',
        'gb': 'United Kingdom',
        'us': 'United States',
        'um': 'United States Outlying Islands',
        'uy': 'Uruguay',
        'uz': 'Uzbekistan',
        'vu': 'Vanuatu',
        've': 'Venezuela',
        'vn': 'Viet Nam',
        'vg': 'Virgin Islands, British',
        'vi': 'Virgin Islands, U.S.',
        'wf': 'Wallis And Futuna',
        'eh': 'Western Sahara',
        'ye': 'Yemen',
        'zm': 'Zambia',
        'zw': 'Zimbabwe'
    }

    var isoCountries = {
        'Afghanistan': 'af',
        'Aland Islands': 'ax',
        'Albania': 'al',
        'Algeria': 'dz',
        'American Samoa': 'as',
        'Andorra': 'ad',
        'Angola': 'ao',
        'Anguilla': 'ai',
        'Antarctica': 'aq',
        'Antigua And Barbuda': 'ag',
        'Argentina': 'ar',
        'Armenia': 'am',
        'Aruba': 'aw',
        'Australia': 'au',
        'Austria': 'at',
        'Azerbaijan': 'az',
        'Bahamas': 'bs',
        'Bahrain': 'bh',
        'Bangladesh': 'bd',
        'Barbados': 'bb',
        'Belarus': 'by',
        'Belgium': 'be',
        'Belize': 'bz',
        'Benin': 'bj',
        'Bermuda': 'bm',
        'Bhutan': 'bt',
        'Bolivia': 'bo',
        'Bosnia And Herzegovina': 'ba',
        'Botswana': 'bw',
        'Bouvet Island': 'bv',
        'Brazil': 'br',
        'British Indian Ocean Territory': 'io',
        'Brunei Darussalam': 'bn',
        'Bulgaria': 'bg',
        'Burkina Faso': 'bf',
        'Burundi': 'bi',
        'Cambodia': 'kh',
        'Cameroon': 'cm',
        'Canada': 'ca',
        'Cape Verde': 'cv',
        'Cayman Islands': 'ky',
        'Central African Republic': 'cf',
        'Chad': 'td',
        'Chile': 'cl',
        'China': 'cn',
        'Christmas Island': 'cx',
        'Cocos (Keeling) Islands': 'cc',
        'Colombia': 'co',
        'Comoros': 'km',
        'Congo': 'cg',
        'Congo Democratic Republic': 'cd',
        'Cook Islands': 'ck',
        'Costa Rica': 'cr',
        'Cote D\'Ivoire': 'ci',
        'Croatia': 'hr',
        'Cuba': 'cu',
        'Cyprus': 'cy',
        'Czech Republic': 'cz',
        'Denmark': 'dk',
        'Djibouti': 'dj',
        'Dominica': 'dm',
        'Dominican Republic': 'do',
        'Ecuador': 'ec',
        'Egypt': 'eg',
        'El Salvador': 'sv',
        'Equatorial Guinea': 'gq',
        'Eritrea': 'er',
        'Estonia': 'ee',
        'Ethiopia': 'et',
        'Falkland Islands (Malvinas)': 'fk',
        'Faroe Islands': 'fo',
        'Fiji': 'fj',
        'Finland': 'fi',
        'France': 'fr',
        'French Guiana': 'gf',
        'French Polynesia': 'pf',
        'French Southern Territories': 'tf',
        'Gabon': 'ga',
        'Gambia': 'gm',
        'Georgia': 'ge',
        'Germany': 'de',
        'Ghana': 'gh',
        'Gibraltar': 'gi',
        'Greece': 'gr',
        'Greenland': 'gl',
        'Grenada': 'gd',
        'Guadeloupe': 'gp',
        'Guam': 'gu',
        'Guatemala': 'gt',
        'Guernsey': 'gg',
        'Guinea': 'gn',
        'Guinea-Bissau': 'gw',
        'Guyana': 'gy',
        'Haiti': 'ht',
        'Heard Island & Mcdonald Islands': 'hm',
        'Holy See (Vatican City State)': 'va',
        'Honduras': 'hn',
        'Hong Kong': 'hk',
        'Hungary': 'hu',
        'Iceland': 'is',
        'India': 'in',
        'Indonesia': 'id',
        'Iran Islamic Republic Of': 'ir',
        'Iraq': 'iq',
        'Ireland': 'ie',
        'Isle Of Man': 'im',
        'Israel': 'il',
        'Italy': 'it',
        'Jamaica': 'jm',
        'Japan': 'jp',
        'Jersey': 'je',
        'Jordan': 'jo',
        'Kazakhstan': 'kz',
        'Kenya': 'ke',
        'Kiribati': 'ki',
        'Korea': 'kr',
        'Kuwait': 'kw',
        'Kyrgyzstan': 'kg',
        'Lao People\'s Democratic Republic': 'la',
        'Latvia': 'lv',
        'Lebanon': 'lb',
        'Lesotho': 'ls',
        'Liberia': 'lr',
        'Libyan Arab Jamahiriya': 'ly',
        'Liechtenstein': 'li',
        'Lithuania': 'lt',
        'Luxembourg': 'lu',
        'Macao': 'mo',
        'Macedonia': 'mk',
        'Madagascar': 'mg',
        'Malawi': 'mw',
        'Malaysia': 'my',
        'Maldives': 'mv',
        'Mali': 'ml',
        'Malta': 'mt',
        'Marshall Islands': 'mh',
        'Martinique': 'mq',
        'Mauritania': 'mr',
        'Mauritius': 'mu',
        'Mayotte': 'yt',
        'Mexico': 'mx',
        'Micronesia Federated States Of': 'fm',
        'Moldova': 'md',
        'Monaco': 'mc',
        'Mongolia': 'mn',
        'Montenegro': 'me',
        'Montserrat': 'ms',
        'Morocco': 'ma',
        'Mozambique': 'mz',
        'Myanmar': 'mm',
        'Namibia': 'na',
        'Nauru': 'nr',
        'Nepal': 'np',
        'Netherlands': 'nl',
        'Netherlands Antilles': 'an',
        'New Caledonia': 'nc',
        'New Zealand': 'nz',
        'Nicaragua': 'ni',
        'Niger': 'ne',
        'Nigeria': 'ng',
        'Niue': 'nu',
        'Norfolk Island': 'nf',
        'Northern Mariana Islands': 'mp',
        'Norway': 'no',
        'Oman': 'om',
        'Pakistan': 'pk',
        'Palau': 'pw',
        'Palestinian Territory Occupied': 'ps',
        'Panama': 'pa',
        'Papua New Guinea': 'pg',
        'Paraguay': 'py',
        'Peru': 'pe',
        'Philippines': 'ph',
        'Pitcairn': 'pn',
        'Poland': 'pl',
        'Portugal': 'pt',
        'Puerto Rico': 'pr',
        'Qatar': 'qa',
        'Reunion': 're',
        'Romania': 'ro',
        'Russia': 'ru',
        'Rwanda': 'rw',
        'Saint Barthelemy': 'bl',
        'Saint Helena': 'sh',
        'Saint Kitts And Nevis': 'kn',
        'Saint Lucia': 'lc',
        'Saint Martin': 'mf',
        'Saint Pierre And Miquelon': 'pm',
        'Saint Vincent and the Grenadines': 'vc',
        'Samoa': 'ws',
        'San Marino': 'sm',
        'Sao Tome And Principe': 'st',
        'Saudi Arabia': 'sa',
        'Senegal': 'sn',
        'Serbia': 'rs',
        'Seychelles': 'sc',
        'Sierra Leone': 'sl',
        'Singapore': 'sg',
        'Slovakia': 'sk',
        'Slovenia': 'si',
        'Solomon Islands': 'sb',
        'Somalia': 'so',
        'South Africa': 'za',
        'South Georgia And Sandwich Isl.': 'gs',
        'Spain': 'es',
        'Sri Lanka': 'lk',
        'Sudan': 'sd',
        'Suriname': 'sr',
        'Svalbard And Jan Mayen': 'sj',
        'Swaziland': 'sz',
        'Sweden': 'se',
        'Switzerland': 'ch',
        'Syrian Arab Republic': 'sy',
        'Taiwan': 'tw',
        'Tajikistan': 'tj',
        'Tanzania': 'tz',
        'Thailand': 'th',
        'Timor-Leste': 'tl',
        'Togo': 'tg',
        'Tokelau': 'tk',
        'Tonga': 'to',
        'Trinidad And Tobago': 'tt',
        'Tunisia': 'tn',
        'Turkey': 'tr',
        'Turkmenistan': 'tm',
        'Turks And Caicos Islands': 'tc',
        'Tuvalu': 'tv',
        'Uganda': 'ug',
        'Ukraine': 'ua',
        'United Arab Emirates': 'ae',
        'United Kingdom': 'gb',
        'United States': 'us',
        'United States Outlying Islands': 'um',
        'Uruguay': 'uy',
        'Uzbekistan': 'uz',
        'Vanuatu': 'vu',
        'Venezuela': 've',
        'Viet Nam': 'vn',
        'Virgin Islands British': 'vg',
        'Virgin Islands U.S.': 'vi',
        'Wallis And Futuna': 'wf',
        'Western Sahara': 'eh',
        'Yemen': 'ye',
        'Zambia': 'zm',
        'Zimbabwe': 'zw'
    };

};
$(function () {
    $(document).tooltip();
});


function ChangeText(element) {
    if ($(element).text() == "Show More") {
        $(element).text("Show Less");
    } else {
        $(element).text("Show More");
    }
    return false;
}

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


function changeTab(value) {
    if (value === 1) {
        $("#externalDiv").removeClass("active").removeClass("in");
        $("#internalDiv").addClass("active").addClass("in")
    } else {
        $("#internalDiv").removeClass("active").removeClass("in");
        $("#externalDiv").addClass("active").addClass("in")
    }
}

function SearchUserByEmail(e) {
    if (e.keyCode != 13) {
        if ($("#txtSearchEmail").val().length > 2) {
            $.ajax({
                url: "../Share/User?email=" + $("#txtSearchEmail").val(),
                type: "GET",
                dataType: "Json",
                success: function (data) {
                    if (data.Acknowledgment) {
                        var dataNames = new Array();
                        for (var i = 0; i < data.Users.length; i++) {
                            dataNames[i] = data.Users[i].UserName;
                        }
                        $("#txtSearchEmail").autocomplete({
                            source: dataNames
                        });
                    } else {

                    }

                },
                error: function (error) {
                }
            })
        }
    }
    else {
        return false;
    }

}

function postComment(thisElement) {
    var idSmartChart = $(thisElement).data("idsmartchart");
    var commentSpinOpts = {
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
, position: 'relative' // Element positioning
    }
    var spinner = new Spinner(commentSpinOpts).spin($("#commentSpinner_" + idSmartChart)[0]);
    var currentDate = new Date();
    var day = currentDate.getDate();
    var month = currentDate.getMonth() + 1;
    var year = currentDate.getFullYear();
    var message = $('.popover #txtComment_' + idSmartChart).val().replace(notHtmlRegex, "");
    if (message != "") {
        $.ajax({
            type: "POST",
            url: "../Comments/AddChartComment",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify({ "IdSmartChart": idSmartChart, "Message": message }),
            success: function (data) {
                if (data.Acknowledgment) {
                    $('.popover #commentsField_' + idSmartChart).append("<div id=\"comment_" + data.Comments[0].IdComment + "\" class=\"bg-info commentPopup\"><button data-toggle=\"modal\" data-target=\"#deleteComment\" onclick=\"deleteCommentPopUp(" + data.Comments[0].IdComment + ", " + idSmartChart + ")\" type=\" button\" class=\"close\" aria-hidden=\"true\">×</button>" + message + "</div><span id=\"commentDate_" + data.Comments[0].IdComment + "\" class=\"help-block text-right\">" + month + "/" + day + "/" + year + " by You</span>");
                    $('.popover #txtComment_' + idSmartChart).val("");
                } else {
                    errorCallback();
                }
                spinner.stop();
            }
        });
        var commentCount = $('#' + idSmartChart + '_CommentCounter').text();
        $('#' + idSmartChart + '_CommentCounter').text(parseInt(commentCount) + 1);
        $('#' + idSmartChart + '_CommentCounter').css("visibility", 'visible');
    }
}

function deleteCommentPopUp(commentId, chartId) {
    $("#commentToDelete").val(commentId);
    $("#commentChartIdToDelete").val(chartId);
}

function closePopOver(thisElement, smartCharId) {
    $(thisElement).closest('div.popover').popover('hide');
    $('#commentsField_' + smartCharId).html('');
}

var notHtmlRegex = /(<([^>]+)>)/ig;

