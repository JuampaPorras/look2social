angular
        .module("smartSocialApp")
    .controller("manageCtrl", manageCtrl);

manageCtrl.$inject = ["$scope", "$routeParams", '$compile'];

function manageCtrl($scope, $routeParams, $compile) {
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
        $scope.$apply(function () {
            $scope.$parent.showMoreReports = false;
        });
        var spinnerProfile = new Spinner(manageOpts).spin($("#yourProfileSpinner")[0]);
        $.ajax({
            url: "../Manage/GetUserProfilePage",
            type: "GET",
            dataType: "Json",
            data: {},
            success: function (data) {
                if (data.Acknowledgment) {
                    $scope.userInfo = data.UserProfile;
                    $scope.$apply();
                    spinnerProfile.stop();
                } else {
                }
            }
        });
        $.ajax({
            url: "../Share/GetUserSharedReports",
            type: "GET",
            dataType: "Json",
            data: {},
            success: function (data) {
                if (data.Acknowledgment) {
                    $scope.sharedReportsWithMe = data.SharedWithMeReports;
                    $scope.sharedReportsByMe = data.SharedByMeReports;
                    if (data.SharedByMeReports.length > 7) {
                        $("#reportsIShared").slimScroll({
                            height: "434px",
                            width: "100%"
                        });
                    }
                    if (data.SharedWithMeReports.length > 7) {
                        $("#reportsTheyShared").slimScroll({
                            height: "434px",
                            width: "100%"
                        });
                    }
                    $scope.$apply();
                } else {
                }
            }
        });
        $.ajax({
            url: "../Manage/GetBillingPortal",
            type: "GET",
            dataType: "Json",
            data: {},
            success: function (data) {
                if (data.Acknowledgment) {
                    $scope.billingHref = data.BillingPortalUrl;
                    $scope.$apply();
                } else {
                }
            }
        });
        var subscriptionsDatasource = new kendo.data.DataSource({
            transport: {
                read: {
                    // the remote service url
                    url: "../Manage/GetUserAdminSbscription",

                    // the request type
                    type: "get",

                    // the data type of the returned result
                    dataType: "json",

                }
            },
            serverPaging: false,
            serverSorting: false,
            serverFiltering: false,
            pageSize: 6,
        });
        var element = $("#grid").kendoGrid({
            dataSource: subscriptionsDatasource,
            height: "100%",
            sortable: true,
            pageable: true,
            resizable: true,
            detailInit: detailInit,
            dataBound: function () {
                this.expandRow(this.tbody.find("tr.k-master-row").first());
                gridCompiler
            },
            scrollable: true,
            columns: [
                {
                    field: "SubscriptionName",
                    title: "Subscription",
                    filterable: {
                        cell: {
                            operator: "contains"
                        }
                    }
                },
                {
                    field: "BusinessType",
                    template: "<button class='btn btn-warning'>#: data.BusinessType #</button>",
                    title: "Type"
                },
                {
                    title: "Actions", template: "<div class='dropdown'>" +
      "<button class='btn btn-default dropdown-toggle' type='button'  data-toggle='dropdown' aria-haspopup='true' aria-expanded='true'>" +
       " Actions" +
        "<span class='caret'></span>" +
      "</button>" +
      "<ul class='dropdown-menu' aria-labelledby='dropdownMenu'>" +
        "<li><a ng-click='addUserSubModal(#: data.idServiceSubscription #)'>Add User</a></li>" +
      "</ul>" +
    "</div>"
                }
            ]
        });
    });
    $scope.sharedReportsWithMe = [];
    $scope.sharedReportsByMe = [];
    $scope.shareToDelete = 0;
    $scope.billingHref = "";
    $scope.userInfo = { FirstName: "", LastName: "", Phone: "", UserName: "", CountryCode: "" };
    $scope.changeInfo = function () {
        $.ajax({
            url: "../Manage/UpdateProfileSettings",
            type: "POST",
            dataType: "Json",
            data: { pFirstName: $scope.userInfo.FirstName, pLastName: $scope.userInfo.LastName, pPhone: $scope.userInfo.Phone, pCountryCode: $scope.userInfo.CountryCode },
            success: function (data) {
                if (data.Acknowledgment) {
                    swal("", "Profile Information Changed", "success")
                } else {
                }
            }
        });
    }
    $scope.oldPassword = "";
    $scope.newPassword = "";
    $scope.confirmPassword = "";
    $scope.message = "";
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
                                dataNames[i] = data.Users[i].UserName
                            }
                            $("#txtSearchEmail").autocomplete({
                                source: dataNames,
                                select: function (event, ui) {
                                    $("#chooseBtn").attr("disabled", "disabled");
                                    for (var i = 0; i < data.Users.length; i++) {
                                        if (data.Users[i].UserName == ui.item.label) {
                                            $scope.$apply(function () {
                                                $scope.userFindId = data.Users[i].UserId;
                                                $scope.userFindEmail = ui.item.label;
                                                $("#chooseBtn").removeAttr("disabled");
                                            });
                                        }
                                    }
                                },
                                change: function (event, ui) {
                                    $("#addUserSaveBtn").attr("disabled", "disabled");
                                    var isExistingUser = false;
                                    $("#chooseBtn").attr("disabled", "disabled");
                                    for (var i = 0; i < data.Users.length; i++) {
                                        if (data.Users[i].UserName == $("#txtSearchEmail").val()) {
                                            isExistingUser = true;
                                            $scope.$apply(function () {
                                                $scope.userFindId = data.Users[i].UserId;
                                                $scope.hideFields = true;
                                                $scope.userFindEmail = $("#txtSearchEmail").val();
                                                $("#chooseBtn").removeAttr("disabled");
                                            });
                                        }
                                    }
                                    if (!isExistingUser) {
                                        $scope.$apply(function () {
                                            $scope.userFindId = 0;
                                            $scope.hideFields = true;
                                            $scope.userFindEmail = $("#txtSearchEmail").val();
                                            $("#chooseBtn").removeAttr("disabled");
                                        });
                                    }
                                }
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
    //Manage Users
    $scope.getUserBySearch = function () {
        var regexEmail = /^[-a-z0-9~!$%^&*_=+}{\'?]+(\.[-a-z0-9~!$%^&*_=+}{\'?]+)*@([a-z0-9_][-a-z0-9_]*(\.[-a-z0-9_]+)*\.(aero|arpa|biz|com|coop|edu|gov|info|int|mil|museum|name|net|org|pro|travel|mobi|[a-z][a-z])|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(:[0-9]{1,5})?$/;
        if (regexEmail.test($scope.userFindEmail)) {
            $(".addUserInput").attr("disabled", "disabled");
            if ($scope.userFindId > 0) {
                $.ajax({
                    url: "../Manage/GetUserInfoByIdWithRoles",
                    type: "GET",
                    dataType: "Json",
                    data: { userId: $scope.userFindId, subsId: $scope.currentSubsId },
                    success: function (data) {
                        if (data.Acknowledgment) {
                            $scope.hideFields = false;
                            $scope.addUserModel = data;
                            $("#addUserSaveBtn").removeAttr("disabled")
                        } else {
                            //$scope.message = data.Message
                        }
                        $scope.$apply();
                    }
                });
            }
            else {
                $.ajax({
                    url: "../Manage/GetSubscriptionRoles",
                    type: "GET",
                    dataType: "Json",
                    data: { subsId: $scope.currentSubsId },
                    success: function (data) {
                        if (data.Acknowledgment) {
                            $scope.hideFields = false;
                            $(".addUserInput").removeAttr("disabled");
                            $("#addUserSaveBtn").removeAttr("disabled");
                            $scope.addUserModel.UserProfile.RolesInSubscription = data.RolesInSubscription;
                        } else {
                            //$scope.message = data.Message
                        }
                        $scope.$apply();
                    }
                });
            }
        }
        else {

        }
    }

    //$scope.GetUserInSub = function () {
    //    var regexEmail = /^[-a-z0-9~!$%^&*_=+}{\'?]+(\.[-a-z0-9~!$%^&*_=+}{\'?]+)*@([a-z0-9_][-a-z0-9_]*(\.[-a-z0-9_]+)*\.(aero|arpa|biz|com|coop|edu|gov|info|int|mil|museum|name|net|org|pro|travel|mobi|[a-z][a-z])|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(:[0-9]{1,5})?$/;
    //    if (regexEmail.test($scope.userFindEmail)) {
    //        $(".addUserInput").attr("disabled", "disabled");
    //        if ($scope.userFindId > 0) {
    //            $.ajax({
    //                url: "../Manage/GetUserInfoById",
    //                type: "GET",
    //                dataType: "Json",
    //                data: { userId: $scope.userFindId, subsId: $scope.currentSubsId },
    //                success: function (data) {
    //                    if (data.Acknowledgment) {
    //                        $scope.hideFields = false;
    //                        $scope.addUserModel = data.UserProfile;
    //                        $("#addUserSaveBtn").removeAttr("disabled")
    //                    } else {
    //                        //$scope.message = data.Message
    //                    }
    //                    $scope.$apply();
    //                }
    //            });
    //        }
    //        else {
    //            $scope.hideFields = false;
    //            $(".addUserInput").removeAttr("disabled")
    //        }
    //    }
    //    else {

    //    }
    //}

    $scope.addUserSafe = function () {
        var rolesToAdd = [];
        var rolesString=""
        angular.forEach($scope.addUserModel.UserProfile.RolesInSubscription, function (role) {
            if (role.isActive) {
                rolesToAdd.push(role.RoleId);
                rolesString += role.RoleName + " ";
            }
        });
        var spinnerAddUser = new Spinner(manageOpts).spin($("#addUserSpin")[0]);
        $("#addUserSaveBtn").attr("disabled");
        if ($scope.userFindId > 0) {
            $.ajax({
                url: "../Manage/AddUserXSubscription",
                type: "POST",
                dataType: "json",
                traditional: true,
                data: { userId: $scope.userFindId, subscriptionId: $scope.currentSubsId, roleIds: rolesToAdd },
                success: function (data) {
                    if (data.Acknowledgment) {
                        for (var i = 0; i < gridsDatasoruces.length; i++) {
                            if (gridsDatasoruces[i].subId == $scope.currentSubsId) {
                                var order = gridsDatasoruces[i].data.total();
                                gridsDatasoruces[i].data.insert(order, {
                                    BusinessType:null,
                                    ChargifyCustomerId:null,
                                    Company: null,
                                    CompanyId: null,
                                    CountryCode: $scope.addUserModel.UserProfile.CountryCode,
                                    FirstName: $scope.addUserModel.UserProfile.FirstName,
                                    IsActive: true,
                                    LastName: $scope.addUserModel.UserProfile.LastName,
                                    LastReportId: null,
                                    Phone: $scope.addUserModel.UserProfile.Phone,
                                    SubscriptionRoleName: rolesString,
                                    UserId: $scope.userFindId,
                                    UserName: $scope.userFindEmail,
                                    Order:order
                                });
                            }
                        }
                        $("#txtSearchEmail").val("");
                        $(".addUserInput").attr("disabled", "disabled");
                        $scope.$apply(function () {
                            $scope.userFindId = 0;
                            $scope.hideFields = true;
                            $scope.userFindEmail = "";
                            $scope.currentSubsId = 0;
                            $scope.addUserModel = {
                                UserProfile: {
                                    BusinessType: "",
                                    ChargifyCustomerId: null,
                                    Company: null,
                                    CompanyId: null,
                                    CountryCode: 1,
                                    FirstName: null,
                                    IsActive: null,
                                    LastName: null,
                                    LastReportId: null,
                                    Phone: null,
                                    RolesInSubscription: [
                                        {
                                            RoleActive: {
                                                RoleId: 1,
                                                RoleName: "Admin",
                                                isActive: false
                                            }
                                        },
                                    {
                                        RoleActive: {
                                            RoleId: 2,
                                            RoleName: "User",
                                            isActive: true
                                        }
                                    },
                                        {
                                            RoleActive: {
                                                RoleId: 3,
                                                RoleName: "Guest",
                                                isActive: false,
                                            }
                                        }],
                                    SubscriptionRoleName: "",
                                    UserId: 0,
                                    UserName: ""
                                }
                            };
                        });
                        swal("", "User added to subscription", "success")
                        $("#addUserSaveBtn").removeAttr("disabled");
                        $("#addUser").modal("hide");
                        spinnerAddUser.stop();
                    } else {

                    }
                    $scope.$apply();
                }
            });
        }
        else {
            $.ajax({
                url: "../Manage/AddNewUserXSubscription",
                type: "POST",
                dataType: "json",
                traditional: true,
                data: { email: $scope.userFindEmail, subscriptionId: $scope.currentSubsId, roleIds: rolesToAdd, firstName: $scope.addUserModel.UserProfile.FirstName, lastName: $scope.addUserModel.UserProfile.LastName, phone: $scope.addUserModel.UserProfile.Phone, countryCode: $scope.addUserModel.UserProfile.CountryCode },
                success: function (data) {
                    if (data.Acknowledgment) {
                        for (var i = 0; i < gridsDatasoruces.length; i++) {
                            if (gridsDatasoruces[i].subId == $scope.currentSubsId) {
                                var order = gridsDatasoruces[i].data.total();
                                gridsDatasoruces[i].data.insert(order, {
                                    BusinessType: null,
                                    ChargifyCustomerId: null,
                                    Company: null,
                                    CompanyId: null,
                                    CountryCode: $scope.addUserModel.UserProfile.CountryCode,
                                    FirstName: $scope.addUserModel.UserProfile.FirstName,
                                    IsActive: true,
                                    LastName: $scope.addUserModel.UserProfile.LastName,
                                    LastReportId: null,
                                    Phone: $scope.addUserModel.UserProfile.Phone,
                                    SubscriptionRoleName: rolesString,
                                    UserId: data.User.UserId,
                                    UserName: $scope.userFindEmail,
                                    Order:order
                                });
                            }
                        }
                        $scope.userFindId = 0;
                        $scope.hideFields = true;
                        $scope.userFindEmail = "";
                        $scope.currentSubsId = 0;
                        $scope.$apply(function () {
                            $scope.userFindId = 0;
                            $scope.hideFields = true;
                            $scope.userFindEmail = "";
                            $scope.currentSubsId = 0;
                            $scope.addUserModel = {
                                UserProfile: {
                                    BusinessType: "",
                                    ChargifyCustomerId: null,
                                    Company: null,
                                    CompanyId: null,
                                    CountryCode: 1,
                                    FirstName: null,
                                    IsActive: null,
                                    LastName: null,
                                    LastReportId: null,
                                    Phone: null,
                                    RolesInSubscription: [
                                        {
                                            RoleActive: {
                                                RoleId: 1,
                                                RoleName: "Admin",
                                                isActive: false
                                            }
                                        },
                                    {
                                        RoleActive: {
                                            RoleId: 2,
                                            RoleName: "User",
                                            isActive: true
                                        }
                                    },
                                        {
                                            RoleActive: {
                                                RoleId: 3,
                                                RoleName: "Guest",
                                                isActive: false,
                                            }
                                        }],
                                    SubscriptionRoleName: "",
                                    UserId: 0,
                                    UserName: ""
                                }
                            };
                        });
                        swal("", "User added to subscription", "success")
                        $("#addUserSaveBtn").removeAttr("disabled");
                        $("#addUser").modal("hide");
                        spinnerAddUser.stop();
                    }
                }
            });                        //$scope.message = data.Message
            
        }
    }

    $scope.cleanAddUser = function () {
        $("#txtSearchEmail").val("");
        $(".addUserInput").attr("disabled", "disabled");
        $scope.$apply(function () {
            $scope.userFindId = 0;
            $scope.hideFields = true;
            $scope.userFindEmail = "";
            $scope.currentSubsId = 0;
            $scope.addUserModel = {
                UserProfile: {
                    BusinessType: "",
                    ChargifyCustomerId: null,
                    Company: null,
                    CompanyId: null,
                    CountryCode: 1,
                    FirstName: null,
                    IsActive: null,
                    LastName: null,
                    LastReportId: null,
                    Phone: null,
                    RolesInSubscription: [
                        {
                            RoleActive: {
                                RoleId: 1,
                                RoleName: "Admin",
                                isActive: false
                            }
                        },
                    {
                        RoleActive: {
                            RoleId: 2,
                            RoleName: "User",
                            isActive: true
                        }
                    },
                        {
                            RoleActive: {
                                RoleId: 3,
                                RoleName: "Guest",
                                isActive: false,
                            }
                        }],
                    SubscriptionRoleName: "",
                    UserId: 0,
                    UserName: ""
                }
            };
        });
    }

    $scope.addUserModel = {
        UserProfile: {
            BusinessType: "",
            ChargifyCustomerId: null,
            Company: null,
            CompanyId: null,
            CountryCode: 1,
            FirstName: null,
            IsActive: null,
            LastName: null,
            LastReportId: null,
            Phone: null,
            RolesInSubscription: [
                {
                    RoleActive: {
                        RoleId: 1,
                        RoleName: "Admin",
                        isActive: false
                    }
                },
            {
                RoleActive: {
                    RoleId: 2,
                    RoleName: "User",
                    isActive: true
                }
            },
                {
                    RoleActive: {
                        RoleId: 3,
                        RoleName: "Guest",
                        isActive: false,
                    }
                }],
            SubscriptionRoleName: "",
            UserId: 0,
            UserName: ""
        }
    };
    $scope.userFindId = 0;
    $scope.hideFields = true;
    $scope.userFindEmail = "";
    $scope.currentSubsId = 0;
    $scope.changePassword = function () {
        $("#passChangeBtn").attr("disabled");
        if ($scope.confirmPassword == $scope.newPassword) {
            var spinnerAddUser = new Spinner(manageOpts).spin($("#changePassSpin")[0]);
            $.ajax({
                url: "../Account/ChangePassword",
                type: "POST",
                dataType: "Json",
                data: { oldPassword: $scope.oldPassword, newPassword: $scope.newPassword },
                success: function (data) {
                    if (data.Acknowledgment) {
                        $("#changePasswordUser").modal('hide');
                        $("#passChangeBtn").removeAttr("disabled")
                        swal("", data.Message, "success")
                        $scope.message = "";
                    } else {
                        $scope.message = data.Message
                    }
                    $scope.$apply();
                    spinnerAddUser.stop();
                }
            });
        } else {
            $scope.message = "New password and confirmation don't match ";
            $("#passChangeBtn").removeAttr("disabled")
            $scope.$apply();
        }
    }
    var gridsDatasoruces = [];
    function detailInit(e) {
        var usersDatasource = new kendo.data.DataSource({
            transport: {
                read: {
                    // the remote service url
                    url: "../Manage/GetUserXSubscriptions",

                    // the request type
                    type: "get",

                    // the data type of the returned result
                    dataType: "json",

                    // additional custom parameters sent to the remote service
                    data: {
                        subscriptionId: e.data.idServiceSubscription,
                    }
                }
            },
            batch:true,
            schema: {
                model: {
                    fields: {
                        "BusinessType":{editable: true, nullable: true},
                        "ChargifyCustomerId":{editable: true, nullable: true},
                        "Company":{editable: true, nullable: true},
                        "CompanyId":{editable: true, nullable: true},
                        "CountryCode":{editable: true, nullable: true},
                        "FirstName":{editable: true, nullable: true},
                        "IsActive":{editable: true, nullable: true},
                        "LastName":{editable: true, nullable: true},
                        "LastReportId":{editable: true, nullable: true},
                        "Phone":{editable: true, nullable: true},
                        "SubscriptionRoleName":{editable: true, nullable: true},
                        "UserId":{editable: true, nullable: true},
                        "UserName": { editable: true, nullable: true },
                        "Order": { editable: true, nullable: true },
                    },
                    id: "UserId"
                }
            },
            serverPaging: false,
            serverSorting: false,
            serverFiltering: false,
            pageSize: 5,
        });
        gridsDatasoruces.push({ data: usersDatasource, subId: e.data.idServiceSubscription })
        $("<div/>").appendTo(e.detailCell).kendoGrid({
            dataSource: usersDatasource,
            scrollable: true,
            sortable: true,
            pageable: true,
            //change: gridCompiler,
            dataBound: gridCompiler,
            columns: [
                { field: "UserId", title: "#" },
                {
                    field: "UserName", title: "Email", filterable: {
                        cell: {
                            operator: "contains"
                        }
                    }
                },
                {
                    field: "FirstName", title: "Name", template: "<div>#: (data.FirstName==null)? '':data.FirstName # #: (data.LastName==null)? '':data.LastName  #</div>", filterable: {
                        cell: {
                            operator: "contains"
                        }
                    }
                },
                 {
                     field: "SubscriptionRoleName", title: "Role", template: function (dataItem) {
                         rolesArray = dataItem.SubscriptionRoleName.trim().split(" ");
                             var roleButtons = "<div class='btn-group btn-group-sm' role='group' aria-label='...'>";
                             for (var i = 0; i < rolesArray.length; i++) {
                                 roleButtons += "<button type='button' class='btn btn-primary'>" + rolesArray[i] + "</button>"
                             }
                             roleButtons+="</div>"
                             return roleButtons;
                     }, filterable: {
                         cell: {
                             operator: "contains"
                         }
                     }
                 },
                {
                    title: "Actions", template: "<div class='dropdown'>" +
                      "<button class='btn btn-default dropdown-toggle' type='button'  data-toggle='dropdown' aria-haspopup='true' aria-expanded='true'>" +
                       " Actions" +
                        "<span class='caret'></span>" +
                      "</button>" +
                      "<ul class='dropdown-menu' aria-labelledby='dropdownMenu'>" +
                        "<li><a ng-click='openDeleteModal(#: data.UserId #," + e.data.idServiceSubscription + ",#: data.Order #)'>Delete User</a></li>" +
                        "<li><a ng-click='openEditUserModal(#: data.UserId #," + e.data.idServiceSubscription + ",#: data.Order #)'>Edit User</a></li>" +
                      "</ul>" +
                    "</div>"
                }
            ]
        });
    }

    function gridCompiler() {
        $compile($("#grid"))($scope);
    }

    $scope.addUserSubModal = function (subId) {
        //$scope.$apply(function () {
        $scope.currentSubsId = subId;
        //});
        $("#addUser").modal("show");
    }

    $scope.deleteReportModal = function (shareId, index, sharedByMe) {
        //$scope.$apply(function () {
        $scope.shareToDelete = shareId;
        $scope.shareToDeleteIndex = index;
        $scope.sharedByMe = sharedByMe;
        //});
        $("#deleteShare").modal("show");
    }
    $scope.deleteReport = function () {
        var spinnerAddUser = new Spinner(manageOpts).spin($("#deleteShareSpin")[0]);
        $("#deleteShareReportBtn").attr("disabled");
        //$scope.$apply(function () {
        $.ajax({
            url: "../Manage/DeactivateSharedReport",
            type: "GET",
            dataType: "Json",
            data: { shareId: $scope.shareToDelete },
            success: function (data) {
                if (data.Acknowledgment) {
                    if ($scope.sharedByMe) {
                        $scope.sharedReportsByMe.splice($scope.shareToDeleteIndex, 1);
                    }
                    else {
                        $scope.sharedReportsWithMe.splice($scope.shareToDeleteIndex, 1);
                    }
                    $("#deleteShare").modal("hide");
                    swal("", "Shared report deleted", "success");
                    $scope.shareToDelete = 0;
                    $scope.index = 0;
                    $scope.$apply();
                    $("#deleteShareReportBtn").removeAttr("disabled");
                    spinnerAddUser.stop();
                } else {

                }
            }
        });
    }
    $scope.openDeleteModal = function (userId,subId, order) {
        $("#deleteUser").modal('show');
        $scope.userToDelete = userId;
        $scope.currentSubsId = subId;
        $scope.deleteUserOrder = order;
    }
    $scope.deleteUserOrder = 0;
    $scope.deleteUser = function () {
        var spinnerAddUser = new Spinner(manageOpts).spin($("#deleteUserSpin")[0]);
        $("#deleteShareReportBtn").attr("disabled");
        $.ajax({
            url: "../Manage/DeactivateUser",
            type: "GET",
            dataType: "Json",
            data: { userId: $scope.userToDelete, subId: $scope.currentSubsId },
            success: function (data) {
                if (data.Acknowledgment) {
                    for (var i = 0; i < gridsDatasoruces.length; i++) {
                        if (gridsDatasoruces[i].subId == $scope.currentSubsId) {
                            var dataItem = gridsDatasoruces[i].data.at($scope.deleteUserOrder);
                            gridsDatasoruces[i].data.remove(dataItem);
                            for (var e = 0; e < gridsDatasoruces[i].data.total(); e++) {
                                var rowToUpdate = gridsDatasoruces[i].data.at(e);
                                rowToUpdate.set("Order", e);
                                //gridsDatasoruces[i].data.set(rowToUpdate);
                            }
                        }
                    }
                    spinnerAddUser.stop();
                    $("#deleteUser").modal('hide');
                    swal("","User deleted from subscription","success")
                } else {

                }
                $("#deleteShareReportBtn").removeAttr("disabled");
            }
        })
    }
    $scope.userToDelete = 0;
    $scope.userToEdit = {
        UserProfile: {
            BusinessType: "",
            ChargifyCustomerId: null,
            Company: null,
            CompanyId: null,
            CountryCode: 1,
            FirstName: null,
            IsActive: null,
            LastName: null,
            LastReportId: null,
            Phone: null,
            RolesInSubscription: [
                {
                    RoleActive: {
                        RoleId: 1,
                        RoleName: "Admin",
                        isActive: false
                    }
                },
            {
                RoleActive: {
                    RoleId: 2,
                    RoleName: "User",
                    isActive: false
                }
            },
                {
                    RoleActive: {
                        RoleId: 3,
                        RoleName: "Guest",
                        isActive: false,
                    }
                }],
            SubscriptionRoleName: "",
            UserId: 0,
            UserName: ""
        }
    };
    $scope.openEditUserModal = function (userId, subId,order) {
        $scope.currentSubsId = subId;
        $scope.editUserOrder=order
        $.ajax({
            url: "../Manage/GetUserInfoById",
            type: "GET",
            dataType: "Json",
            data: { userId: userId, subsId: subId },
            success: function (data) {
                if (data.Acknowledgment) {
                    $scope.hideFields = false;
                    $scope.userToEdit = data.UserProfile;
                    $("#addUserSaveBtn").removeAttr("disabled")
                } else {
                    //$scope.message = data.Message
                }
                $scope.$apply();
                $("#editUser").modal('show');
            }
        });
    }

    $scope.editUser = function () {
        var rolesToAdd = [];
        var rolesString = ""
        angular.forEach($scope.userToEdit.RolesInSubscription, function (role) {
            if (role.isActive) {
                rolesToAdd.push(role.RoleId);
                rolesString += role.RoleName + " ";
            }
        });
        var spinnerAddUser = new Spinner(manageOpts).spin($("#editUserSpin")[0]);
        $.ajax({
            url: "../Manage/DeactivateRolesUserSubscription",
            type: "POST",
            dataType: "Json",
            traditional: true,
            data: { userId: $scope.userToEdit.UserId, subscriptionId: $scope.currentSubsId, rolesId: rolesToAdd },
            success: function (data) {
                if (data.Acknowledgment) {
                    for (var i = 0; i < gridsDatasoruces.length; i++) {
                        if (gridsDatasoruces[i].subId == $scope.currentSubsId) {
                            var dataItem = gridsDatasoruces[i].data.at($scope.editUserOrder).set("SubscriptionRoleName", rolesString);
                        }
                    }
                } else {
                    //$scope.message = data.Message
                }
                $scope.$apply();
                spinnerAddUser.stop();
                $("#editUser").modal('hide');
                swal("", "User succesfully edited", "success");
            }
        });
    }

}
var manageOpts = {
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
, top: '100%' // Top position relative to parent
, left: '90%' // Left position relative to parent
, shadow: true // Whether to render a shadow
, hwaccel: false // Whether to use hardware acceleration
, position: 'relative' // Element positioning
}
