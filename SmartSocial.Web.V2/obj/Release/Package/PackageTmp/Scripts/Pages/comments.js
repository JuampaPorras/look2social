/*
Created by Hugo Vindas.
*/
//var notHtmlRegex = /(<([^>]+)>)/ig;


//$(document).ready(function () {
//});

//function closePopOver(thisElement,smartCharId) {
//    $(thisElement).closest('div.popover').popover('hide');
//    $('#commentsField_'+ smartCharId).html('');
//}

//function lunchPopOver(thisElement, smartCharId) {
//    var genericCloseBtnHtml = '<button onclick="closePopOver(this,' + smartCharId + ');" type="button" class="close" aria-hidden="true">&times;</button>';
//    $(thisElement).popover({
//        html: true,
//        title: 'Comments ' + genericCloseBtnHtml,
//        content: function () {
//            return $('.content-popup_' + smartCharId).html();
//        },
//        container: 'body',
//        placement: 'auto right'
//    });
//    var popoverId = $(thisElement).attr("aria-describedby");
//    if (!$("#" + popoverId).hasClass("in")) {
//        getCommentsBySmartCharId(smartCharId, function (data) {
//            $('#commentsField_' + smartCharId).html('');
//            var commentsFromServer = "";
//            for (var i = 0; i < data.Comments.length; i++) {
//                $('#commentsField_' + smartCharId).append("<p class=\"bg-info commentPopup\" class=\"commentPopup\">" + data.Comments[i].Message + "</p><span class=\"help-block text-right\">" + GetSmallDate(data.Comments[i].DatePosted) + " by " + data.Comments[i].UserName + "</span>");
               
//            }
//            $(thisElement).popover('show');
//            $('.popover #commentsField_' + smartCharId).scrollTop($('.popover #commentsField_' + smartCharId).prop('scrollHeight'));
//        }, function () {
//            alert("unable to load Comments for Chart Id: " + smartCharId);
//        });
        
//    } else {
//        $('#commentsField_' + smartCharId).empty();
//    }


//}

//function getCommentsBySmartCharId(smartCharIdValue, successCallBack, errorCallback) {
//    $.ajax({
//        type: "GET",
//        url: "../Comments/GetCommentsByChart",
//        data: { smartChartId: smartCharIdValue },
//        contentType: "application/json; charset=utf-8",
//        dataType: "text", // the data type we want back, so text.  The data will come wrapped in xml
//        success: function (data) {
//            var comments = JSON.parse(data);
//            if (comments.Acknowledgment) {
//                successCallBack(comments);
//            } else {
//                errorCallback();
//            }

//        }
//    });
//}

//function postComment(idSmartChart) {
//    var currentDate = new Date(); 
//    var day = currentDate.getDate();
//    var month = currentDate.getMonth() + 1;
//    var year = currentDate.getFullYear();
//    var message = $('.popover #txtComment_' + idSmartChart).val().replace(notHtmlRegex, "");
//    if (message != "") {
//        $.ajax({
//            type: "POST",
//            url: "../Comments/AddChartComment",
//            contentType: "application/json; charset=utf-8",
//            dataType: "json",
//            data: JSON.stringify({ "IdUser": currentUserId, "IdSmartChart": idSmartChart, "Message": message }),
//            success: function(data) {
//                if (data.Acknowledgment) {
//                    $('.popover #commentsField_' + idSmartChart).append("<p class=\"bg-info commentPopup\">" + message + "</p><span class=\"help-block text-right\">" + month + "/" + day + "/" + year + " by You</span>");
//                    $('.popover #txtComment_' + idSmartChart).val("");                   
//                } else {
//                    errorCallback();
//                }

//            }
//        });
//        var commentCount = $('#' + idSmartChart + '_CommentCounter').text();
//        $('#' + idSmartChart + '_CommentCounter').text(parseInt(commentCount) + 1);
//    }
//}

//function GetSmallDate(jsonDate) {
//    var value = new Date(parseInt(jsonDate.substr(6)));
//    return value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear()
//}
