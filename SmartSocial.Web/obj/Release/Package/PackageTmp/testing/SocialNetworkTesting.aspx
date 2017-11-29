<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SocialNetworkTesting.aspx.cs" Inherits="SmartSocial.Web.testing.SocialNetworkTesting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
      window.fbAsyncInit = function() {
        FB.init({
          appId      : '808310982550906',
          xfbml      : true,
          version    : 'v2.2'
        });
      };

      (function(d, s, id){
         var js, fjs = d.getElementsByTagName(s)[0];
         if (d.getElementById(id)) {return;}
         js = d.createElement(s); js.id = id;
         js.src = "//connect.facebook.net/en_US/sdk.js";
         fjs.parentNode.insertBefore(js, fjs);
       }(document, 'script', 'facebook-jssdk'));
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div
      class="fb-like"
      data-share="true"
      data-width="450"
      data-show-faces="true">
    </div>
    </div>
    </form>
</body>
</html>
