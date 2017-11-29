<%@ Page Title="Main Page" Language="C#" MasterPageFile="~/Site.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="SmartSocial.Web.pages.main" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContentPlaceholder" runat="server">

    <%--<asp:Button ID="CleanExcelGridAjaxManager" runat="server" Text="Excel" CssClass="hidden" OnClick="CleanExcelGrid" />--%>
    <%--<asp:Button ID="ExcelAjaxManager" runat="server" Text="Excel" CssClass="hidden" OnClick="DatasourceExcel" />--%>
    <%--<asp:Button ID="WordCloudAjaxManager" runat="server" Text="WordCloud" OnClick="WordCloudContexDeleter" CssClass="hidden" />--%>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ExcelGrid" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="LoadingImageExcel" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="ExcelGrid" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="LoadingImageExcel" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="WordCloudContextMenu" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>

    <telerik:RadClientExportManager ID="RadClientExportManager1" runat="server" RenderMode="Classic">
        <PdfSettings Title="Chart" FileName="Exported Chart" Creator="Smart Social Reporting" />
    </telerik:RadClientExportManager>
    <div style="height: 100px; background-color: #fcfcfc; margin-top: 1px; padding: 0 20px; margin-right: -20px; margin-left: -20px; margin-bottom: 5px; box-shadow: 0px 1px 0px 0px rgba(0, 0, 0, 0.1);">
        <div style="margin-top: 0px; margin-bottom: 15px; border-bottom: none; float: left; margin-right: 20px; margin-left: 15px;">
            <h2>
                <asp:Label ID="ReportName" runat="server" Text=""></asp:Label>
                <button id="windowButton" class="btn btn-lg" onclick="OpenInsights(); return false;" style="margin-top: -5px; background-color: transparent"><i class="fa fa-eye"></i></button>
            </h2>
        </div>
        <div style="margin-top: 0px; margin-bottom: 15px; border-bottom: none; float: right; margin-right: 20px;">
            <h2>
                <asp:Label ID="AnalysisPeriod" runat="server" Text=""></asp:Label>
            </h2>
        </div>
    </div>

    <div id="MainContainer" runat="server" style="margin-top:30px">
        
        <div id="ChartsContainer" class="row-fluid" runat="server">
        </div>
        <br />
        <div class="row">
            <div class="col-lg-12 col-sm-12 col-md-12 col-xs-12">
                <p class="text-center">&#169; Created by Smart Social</p>
            </div>
        </div>
        <telerik:RadContextMenu ID="WordCloudContextMenu" runat="server" OnItemClick="DeleteWord" EnableAjaxSkinRendering="true" OnClientShown="WordCloudMenuOpen">
            <Items>
                <telerik:RadMenuItem Text="Delete">
                </telerik:RadMenuItem>
            </Items>
        </telerik:RadContextMenu>
    </div>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true"
        ShowContentDuringLoad="false" Behaviors="Close,Move,Resize" InitialBehaviors="Close" Skin="Bootstrap" Style="z-index: 8001">
        <Windows>
            <telerik:RadWindow ID="KPIinsights" runat="server" Title="Insights"
                VisibleOnPageLoad="false" OnClientCommand="CenterWindow" Width="800px" Height="600px">
                <ContentTemplate>
                    <div style="text-align: center;" id="KPIInsigthsTxt" runat="server">
                    </div>
                </ContentTemplate>
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <telerik:RadWindowManager ID="RadWindowManager3" runat="server" EnableShadow="true"
        ShowContentDuringLoad="false" Behaviors="Move,Resize,Close" Skin="Bootstrap" Style="z-index: 9001">
        <Windows>
            <telerik:RadWindow ID="ExcelViewer" runat="server" Title="Table View"
                VisibleOnPageLoad="false" Height="550" Width="650" OnClientClose="CleanExcelGrid">
                <ContentTemplate>
                    <%--<asp:ImageButton ID="ExportExcel" runat="server" ImageUrl="../images/excelIcon.png"
                        OnClick="ExportExcel_Click" AlternateText="Export to Excel" Width="16px" Height="16px" />--%>
                    <%--<asp:Button ID="ExportExcelBut" runat="server" ImageUrl="../images/excelIcon.png"
                        OnClick="ExportExcel_Click" Text="Export to Excel" Width="120px" Height="30px"  />--%>
                    <asp:LinkButton ID="SubmitBtn" runat="server" OnClick="ExportExcel_Click" CssClass="btn btn-xs btn-default margin5"><i class="fa fa-file-excel-o"></i>&nbsp;Export to Excel</asp:LinkButton>
                    <br />
                    <telerik:RadGrid ID="ExcelGrid" runat="server" Visible="false">
                        <MasterTableView CommandItemDisplay="None" UseAllDataFields="True">
                        </MasterTableView>
                    </telerik:RadGrid>
                    <img src="../images/loading-x.gif" style="margin-top: 15%; margin-left: 10%" id="LoadingImageExcel" runat="server" />
                </ContentTemplate>
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <telerik:RadWindowManager ID="RadWindowManager2" runat="server" EnableShadow="true"
        ShowContentDuringLoad="false" Behaviors="Resize,Move,Close" Skin="Bootstrap" Height="550" Width="650" Style="z-index: 8001" OnClientShow="AddSocialPostEvents" OnClientClose="CloseSocialPost">
        <Windows>
            <telerik:RadWindow ID="RadWindow1" runat="server" Title="Conversation Stream">
                <ContentTemplate>
                    <div id="socialContainer">
                        <ul class='list-group recent-comments'style="width:100%;display:none" id="socialPostContainer">

                        </ul>
                    </div>
                    <img src="../images/loading-x.gif" style="position: absolute;top: 80px; margin-left: 10%" id="loadingImg"/>
                    <div id="noItems" style="display:none;position: absolute;top: 40px;" >There are no items to Display</div>
                </ContentTemplate>
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
<%--    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" CssClass="overflowed">
    </telerik:RadAjaxLoadingPanel>--%>
    <input id="WordToDelete" class="wordToDelete" runat="server" type="hidden" value="" />
    <input id="IsAdmin" runat="server" type="hidden" value="false" />
    <input id="TreeViewWordString" runat="server" type="hidden" />
    <input id="WordClouds" runat="server" type="hidden" />
    <input id="HtmlString" type="hidden" runat="server" />
    <input id="ExcelType" type="hidden" runat="server" class="excelType" />
    <input id="ExcelId" type="hidden" runat="server" class="excelId" />
    <input type="hidden" runat="server" id="SmartReportID" class="smartReportID" value="0" />
    <input type="hidden" runat="server" id="SqlFilter" class="sqlFilter" value="[Message] LIKE '%%'" />
    <script type="text/javascript">
        var isInParent = false;
        $(function () {
            if ($(".smartReportID").val() > 0) {
                var wordClouds = $("#<%= WordClouds.ClientID%>").val().split(",");
                for (var j = 0; j < wordClouds.length - 1; j++) {
                    var cloudIds = wordClouds[j].split("|");
                    var words = [];
                    var wordCloudData = $("#" + cloudIds[1]).val().split("|");
                    var chartId = $('#' + cloudIds[0]).parents(".panel").find('.panel-title').find('input').val()
                    for (var i = 0; i < wordCloudData.length; i++) {
                        var wordCloudDataItem = wordCloudData[i].split(",");
                        var wordToAdd = { text: wordCloudDataItem[0], weight: parseInt(wordCloudDataItem[1]), link: "javascript:ConversationStreamWordCloud('" + chartId + "," + wordCloudDataItem[0] + "')" }
                        words.push(wordToAdd);
                    }
                    $('#' + cloudIds[0]).jQCloud(words, {
                        autoResize: true,
                        fontSize: {
                            from: 0.1,
                            to: 0.03
                        }
                    });
                    $("#exportReportBut").css("display", "block");
                }
                if ($("#<%= KPIInsigthsTxt.ClientID%>").text().trim() == "") {
                    $("#windowButton").hide();
                }
                $("#socialContainer").slimScroll({
                    height:"100%"
                });
                $(".costumersContainer").slimScroll({
                    height: "427px"
                });
                $(window).on("resize", function () {
                    var charts = "<%=Charts%>";
                    var chartsArray = charts.split("|");
                    for (var c = 0; c < chartsArray.length; c++) {
                        $find(chartsArray[c])._chartObject.resize()
                    }
                })
                //$telerik.$(window).on("resize", function () { $find("#VolumeTrendContainer")._chartObject.resize() });
            }
        });
        window.onload = function () {
            if ($("#<%= IsAdmin.ClientID%>").val()) {
                var ajaxManager = $find("<%= RadAjaxManager1.ClientID %>");
                ajaxManager.ajaxRequest('WordCloudsDeleter');
            }
        }

        function OpenInsights() {
            var wnd = $find("<%=KPIinsights.ClientID%>");
            wnd.show();
        }

        function CenterWindow(sender, args) {
            if (args._commandName == "Restore") {
                var wnd = $find("<%=KPIinsights.ClientID%>");
            wnd.moveTo(500, 50);
        }
    }

    var isCloudCreated = false;
    function TreeViewWordCloud(sender, args) {
        var treeViewCloudData = $("#<%= TreeViewWordString.ClientID%>").val().split("|");
            var treeViewWords = [];
            var counter = 0;
            for (var i = 0; i < treeViewCloudData.length; i++) {
                var wordCloudDataItem = treeViewCloudData[i].split(",,");
                if (wordCloudDataItem[1] == args._node._text) {
                    var wordToAdd = { text: wordCloudDataItem[0], weight: parseInt(wordCloudDataItem[2]), link: "javascript:ConversationStreamWordCloud('" + wordCloudDataItem[0] + "')" }
                    counter++
                    treeViewWords.push(wordToAdd);
                    if (counter > 11) {
                        i == treeViewCloudData.length;
                    }
                }
            }
            if (isCloudCreated) {
                $("#wordCloudTree").jQCloud('update', treeViewWords);
            }
            else {
                $("#wordCloudTree").jQCloud(treeViewWords, {
                    autoResize: true,
                });
                isCloudCreated = true;
            }

        }

        function WordCloudMenuOpen(sender, args) {
            var wordToDelete = args._targetElement.innerText;
            var chartId = $(args._targetElement).parents(".panel").find('.panel-title').find('input').val();
            $(".wordToDelete").val(chartId + "|" + wordToDelete);
        }

        function CloseSocialPost(sender, args) {
            $(".sqlFilter").val(" [idSocialPost] < 1");
            rowsSkippedAlready = 0;
            $("#socialPostContainer").html(""); // Delete panels
            $("#socialPostContainer").hide();
            $("#loadingImg").show();
            $("#noItems").hide();

        }

        function ConversationStream() {
            var wnd = $find("<%=RadWindow1.ClientID%>");
            wnd.show();
        }

        function ConversationStreamTopicAnalysisOpen(sender, args) {
            $("#LoadingImg").show();
            $("#LoadingFinish").hide();
            var wnd = $find("<%=RadWindow1.ClientID%>");
            messageValue = dataArray[tree.getSelection()[0].row][0].ef;
            isParent = false;
            for (var i = 0; i < parentDataArray.length; i++) {
                if (parentDataArray[i] == messageValue) {
                    isParent = true;
                    i == parentDataArray.length;
                }
            }
            if (isInParent || !isParent) {
                $(".sqlFilter").val(" [Message] LIKE '%" + messageValue + "%'");
                SocialAjax();
                wnd.show();
            }
            else if (isParent) {
                isInParent = true;
            }
        }

        function ConversationStreamTrendlineOpen(sender, args) {
            $("#loadingImg").show();
            $("#loadingFinish").hide();
            var wnd = $find("<%=RadWindow1.ClientID%>");
            var chartId = $(sender._element).parents(".panel").find('.panel-title').find('input').val();
            var dateFilter1 = kendo.format("{0:yyyy-MM-dd}", new Date(args._dataItem.x))
            var messageValue = args._seriesName;
            //messageValue = messageValue[messageValue.length - 1];
            $(".sqlFilter").val(chartId + "|" + messageValue + "," + dateFilter1);
            SocialAjax();
            wnd.show();
        }

        function ConversationColumPie(sender, args) {
            $("#loadingImg").show();
            $("#loadingFinish").hide();
            var chartId = $(sender._element).parents(".panel").find('.panel-title').find('input').val();
            var wnd = $find("<%=RadWindow1.ClientID%>");
            var messageValue = args._category;
            //messageValue = messageValue[messageValue.length - 1];
            $(".sqlFilter").val(chartId + "|" + messageValue);
            SocialAjax();
            wnd.show();
        }

        function ConversationStreamTopicSourceOpen(sender, args) {
            $("#loadingImg").show();
            $("#loadingFinish").hide();
            var wnd = $find("<%=RadWindow1.ClientID%>");
            var chartId = $(sender._element).parents(".panel").find('.panel-title').find('input').val();
            var messageValue = args._category;
            var network = args._seriesName;
            //messageValue = messageValue[messageValue.length - 1];
            $(".sqlFilter").val(chartId + "|" + messageValue + "," + network);
            SocialAjax();
            wnd.show();
        }

        function ConversationStreamWordCloud(sender) {
            $("#loadingImg").show();
            $("#loadingFinish").hide();
            var wnd = $find("<%=RadWindow1.ClientID%>");
            if (wnd != null) {
                $(".sqlFilter").val(sender.split(",")[0] + "|" + sender.split(",")[1]);
                SocialAjax();
                wnd.show()
            }
        }
        var isUpdated = false;
        function AddSocialPostEvents(sender, args) {
            var wnd = $find("<%=RadWindow1.ClientID%>");
            var wndContent = $("#socialContainer");
            if (!isUpdated) {
                wndContent.on("scroll", function (e) {
                    if (wndContent.scrollTop() == (wndContent.prop('scrollHeight') - wndContent.height())) {
                        SocialAjax();
                    }
                });
                isUpdated = true;
            }
            //var top = $(window).scrollTop() + (($(window).height()/2)-);
            //var left = $(window).scrollLeft()
            //wnd.moveTo(top, 50);
            wnd.Center();
        }
        var rowsSkippedAlready = 0;

        function SocialAjax() {
            $.ajax({
                type: "POST",
                url: $(location).attr('origin')+"/SocialPostService.asmx/SocialPostDatasource",
                data: { reportId: $(".smartReportID").val(), topN: 15, filter: $(".sqlFilter").val(), rowsSkipped: rowsSkippedAlready }, // the data in JSON format.  Note it is *not* a JSON object, is is a literal string in JSON format
                dataType: "html",
                success: function (data) {
                    var stringOfPanels = $(data).text().trim();
                    if (stringOfPanels.length == 0 && rowsSkippedAlready==0) {
                        $("#noItems").show();
                        $("#loadingImg").hide();
                        $("#socialPostContainer").hide();
                    }
                    else {
                        $("#socialPostContainer").append($(data).text()); // append Accordions into window
                        $("#socialPostContainer").show();
                        $("#loadingImg").hide();
                        $("#noItems").hide();
                        rowsSkippedAlready = rowsSkippedAlready + 15
                    }
                }
            });
        }

        function CleanExcelGrid() {
            var ajaxManager = $find("<%= RadAjaxManager1.ClientID %>");
            ajaxManager.ajaxRequest('CleanExcelGrid');
        }

        function ExportIndividualPDF(sender) {
            $find('<%=RadClientExportManager1.ClientID%>').exportPDF($telerik.$('#' + sender));
        }

        function ViewAsExcel(sender, type) {
            $(".excelId").val(sender);
            $(".excelType").val(type);
            var ajaxManager = $find("<%= RadAjaxManager1.ClientID %>");
            ajaxManager.ajaxRequest('DatasourceExcel');
            var wnd = $find("<%=ExcelViewer.ClientID%>");
            wnd.show();
            wnd.Center();
        }

        function ExportTotalPDF() {
            $find('<%=RadClientExportManager1.ClientID%>').exportPDF($telerik.$('#<%= ChartsContainer.ClientID %>'));
            }

        var currentUserId = '<%= UserId %>';
    </script>
    
     <script src="../Scripts/pages/comments.js"></script>
 
</asp:Content>
