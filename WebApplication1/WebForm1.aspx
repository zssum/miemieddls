<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:GridView ID="GridView1" runat="server" OnRowCreated="GridView1_RowCreated" OnRowDataBound="GridView1_RowDataBound" ViewStateMode="Enabled">
        </asp:GridView>
    </form>
</body>
</html>
