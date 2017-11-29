$(document).ready(function () {

    LoadLead();

    $('#wizard').bootstrapWizard({
        'tabClass': 'nav nav-pills',
        'nextSelector': '.btn-next',
        'previousSelector': '.btn-previous',
        onInit: function (tab, navigation, index) {

            //check number of tabs and fill the entire row
            var $total = navigation.find('li').length;
            $width = 100 / $total;

            $display_width = $(document).width();

            if ($display_width < 400 && $total > 3) {
                $width = 50;
            }
            navigation.find('li').css('width', $width + '%');
        },
        onTabClick: function (tab, navigation, index) {
            // Disable the posibility to click on tabs
            return false;
        },
        'onNext': function(tab, navigation, index) {
            var $valid = $("#idWizardFormMore").valid();
            if(!$valid) {
                $("#idWizardFormMore").validate().focusInvalid();
                return false;
            }
        },
        onTabShow: function (tab, navigation, index) {
            var $total = navigation.find('li').length;
            var $current = index + 1;

            var wizard = navigation.closest('.wizard-card');

            // If it's the last tab then hide the last button and show the finish instead
            if ($current >= $total) {
                $(wizard).find('.btn-next').hide();
                $(wizard).find('.btn-finish').show();
            } else {
                $(wizard).find('.btn-next').show();
                $(wizard).find('.btn-finish').hide();
            }
        }
    });

    // Prepare the preview for profile picture
    $("#wizard-picture").change(function () {
        readURL(this);
    });

    $("#myModal").modal('show');

    $.ajax({
        url: 'https://api.myjson.com/bins/3r70w', //https://dl.dropboxusercontent.com/u/660462/softwareCategories.json
        success: function (data) {
            $("#SoftwareTreeview").kendoTreeView({
                checkboxes: {
                    checkChildren: false
                },
                check: onCheck,
                dataSource: data
            });

            var tv = $('#SoftwareTreeview').data('kendoTreeView');

            $('#search-term').on('keyup', function () {

                $('span.k-in > span.highlight').each(function () {
                    $(this).parent().text($(this).parent().text());
                });

                // show all collapsed if no search term
                if ($.trim($(this).val()) == '') {

                    $('#SoftwareTreeview .k-item').each(function () {

                        $(this).show();

                    });
                    tv.collapse(".k-item");
                    return;
                }

                var term = this.value.toUpperCase();
                var tlen = term.length;

                $('#SoftwareTreeview span.k-in').each(function (index) {
                    var text = $(this).text();
                    var html = '';
                    var q = 0;
                    while ((p = text.toUpperCase().indexOf(term, q)) >= 0) {
                        html += text.substring(q, p) + '<span class="highlight">' + text.substr(p, tlen) + '</span>';
                        q = p + tlen;
                    }

                    if (q > 0) {
                        html += text.substring(q);
                        $(this).html(html);

                        $(this).parentsUntil('.k-treeview').filter('.k-item').each(
                            function (index, element) {
                                tv.expand($(this));
                                $(this).data('search-term', term);
                            }
                        );
                    }
                });

                $('#SoftwareTreeview .k-item').each(function () {
                    if ($(this).data('search-term') != term)
                    { $(this).hide(); }
                    else
                    { $(this).show(); }
                });
            });
        }
    });

    function LoadLead()
    {
        //Load the first group of fields already filled out into the Intake Wizard
        var myToken = getUrlParameter("token");
        var subscription_id = getUrlParameter("subscription_id");
        var customer_id = getUrlParameter("customer_id");

        if (typeof myToken === "undefined")
        {
            $.ajax({
                url: "../Intake/Load1stLeadPartChargify?subscription_id=" + subscription_id + "&customer_id=" + customer_id,
                type: "GET",
                dataType: "Json",
                success: function (data) {
                    if (data.Acknowledgment) {
                        $("#txtFirstName").val(data.Lead.FirstName);
                        $("#txtLastName").val(data.Lead.LastName);
                        $("#txtWorkEmail").val(data.Lead.Email);
                        $("#txtPhoneNumber").val(data.Lead.PhoneNumber);
                        $("#ddlCountryCode").val(data.Lead.CountryCode);
                        $("#idLead").val(data.Lead.idLead);
                        
                    } else {

                    }

                },
                error: function (error) {
                }
            })
        } else
        {
            $.ajax({
                url: "../Intake/Load1stLeadPart?strToken=" + myToken,
                type: "GET",
                dataType: "Json",
                success: function (data) {
                    if (data.Acknowledgment) {
                        $("#txtFirstName").val(data.Lead.FirstName);
                        $("#txtLastName").val(data.Lead.LastName);
                        $("#txtWorkEmail").val(data.Lead.Email);
                        $("#txtPhoneNumber").val(data.Lead.PhoneNumber);
                        $("#ddlCountryCode").val(data.Lead.CountryCode);
                        $("#idLead").val(data.Lead.idLead);
                    } else {

                    }

                },
                error: function (error) {
                }
            })
         
        }
          
    }

    // function that gathers IDs of checked nodes
    function checkedNodeIds(nodes, checkedNodes) {
        for (var i = 0; i < nodes.length; i++) {
            if (nodes[i].checked) {
                checkedNodes.push(nodes[i]);
            }

            if (nodes[i].hasChildren) {
                checkedNodeIds(nodes[i].children.view(), checkedNodes);
            }
        }
    }

    // show checked node IDs on datasource change
    function onCheck() {
        var checkedNodes = [],
            treeView = $("#SoftwareTreeview").data("kendoTreeView"),
            message="",
            messageForDB="";

        checkedNodeIds(treeView.dataSource.view(), checkedNodes);
        var nCheckedNodesLen = checkedNodes.length;
        if (nCheckedNodesLen > 0) {
            var i;
            for (i = 0; i < nCheckedNodesLen; ++i) {
                
                message += checkedNodes[i].text;
                messageForDB += checkedNodes[i].id + ":" + checkedNodes[i].text;

                //If it's the last node
                if (i != (nCheckedNodesLen-1)) {
                    message += ", ";
                    messageForDB += ", ";
                }
            }
            //message = checkedNodes.join(", ");
        } else {
            message = "No market segments selected.";
        }
        $("#result").html(message);
        $("#hiddenMarketSegments").html(messageForDB);
    }

});


//Function to show image before upload

function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#wizardPicturePreview').attr('src', e.target.result).fadeIn('slow');
        }
        reader.readAsDataURL(input.files[0]);
    }
}

var getUrlParameter = function getUrlParameter(sParam) {
    var sPageURL = decodeURIComponent(window.location.search.substring(1)),
        sURLVariables = sPageURL.split('&'),
        sParameterName,
        i;

    for (i = 0; i < sURLVariables.length; i++) {
        sParameterName = sURLVariables[i].split('=');

        if (sParameterName[0] === sParam) {
            return sParameterName[1] === undefined ? true : sParameterName[1];
        }
    }
};