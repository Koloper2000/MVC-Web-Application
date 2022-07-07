<%@ Page Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="PlanUnos.aspx.cs" Inherits="KorisnickiInterfejs.PlanUnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 214px;
            text-align: right;
        }
        .style2
        {
            width: 214px;
            text-align: right;
            font-weight: bold;
        }
        .auto-style1 {
        width: 548px;
    }
        .auto-style3 {
            width: 290px;
            text-align: right;
            font-weight: bold;
        }
        .auto-style4 {
        width: 290px;
        text-align: right;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style3">
                &nbsp;</td>
            <td class="auto-style1">
                <b>UNOS PLANOVA

                </b></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                Naziv Treninga</td>
            <td class="auto-style1">
                <asp:DropDownList ID="VrstaDDL" runat="server" Width="250px">
                </asp:DropDownList>
            </td>
            <td rowspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                Opis</td>
            <td class="auto-style1">
                <asp:TextBox ID="OpisTxb" runat="server" Height="95px" Width="240px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">
                Datum</td>
            <td class="auto-style1">
                <asp:ScriptManager ID="ScriptManager1" 
                               runat="server" />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Calendar ID="Calendar1" runat="server" OnDayRender="Calendar1_DayRender"></asp:Calendar>
                </ContentTemplate>
            </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">
                Vreme</td>
            <td class="auto-style1">
                <asp:DropDownList ID="VremeDDL" runat="server" Width="250px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">
                &nbsp;</td>
            <td class="auto-style1">
                <asp:Label ID="lblStatus" runat="server" Text="status"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                &nbsp;</td>
            <td class="auto-style1">
                
                <asp:Button ID="btnSnimi" runat="server" onclick="btnSnimi_Click" Text="SNIMI" 
                    Width="90px" />
                 
                <asp:Button ID="btnOdustani" runat="server" onclick="btnOdustani_Click" 
                    Text="ODUSTANI" />

            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                &nbsp;</td>
            <td class="auto-style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
