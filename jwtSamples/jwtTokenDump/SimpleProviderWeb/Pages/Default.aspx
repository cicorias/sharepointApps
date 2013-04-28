<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SimpleProviderWeb.Pages.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>Raw token</div>
            <asp:TextBox runat="server" ID="txtToken" Width="600px" Height="323px" Wrap="true" TextMode="MultiLine" />
            <div>Decoded</div>
            <asp:TextBox runat="server" ID="txtJwt" Width="600px" Height="323px" Wrap="true" TextMode="MultiLine" />
        </div>
        <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px">
        </asp:DetailsView>
    </form>
</body>
</html>
