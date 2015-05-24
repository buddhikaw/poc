<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" Debug="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href ="Styles/CSS/ehr.css" /> 
    <script type="text/javascript" src="Scripts/jquery-2.1.4.js"></script>
    <script type="text/javascript" src="Scripts/Js/ehr.js"></script>
</head>
<body>
    <form id="form1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
    POC for office work - Auto Generated Grid View with Selected Column Sorting change 
    </div>
        <div>

        </div>
        <div class="dvGridPanel">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="gvTravelCity" runat="server" AutoGenerateColumns="true" AllowPaging="true" PageSize="10" AllowSorting="true" Width="700px" onsorting="grdCause_Sorting" OnRowCreated="grdTravel_RowCreated">

                    </asp:GridView>
                    <asp:Label ID="lblMsg" runat="server" Text="Label"></asp:Label>
                    <asp:Button ID="btn2" runat="server" Text="jsAlert" />
                    <asp:Button ID="btn1" runat="server" Text="gridRefresh" OnClick="btn1_Click"/>                    
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
