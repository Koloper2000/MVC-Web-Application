<%@ Page Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="VrstaUnos.aspx.cs" Inherits="KorisnickiInterfejs.VrstaUnos" %>
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
            width: 300px;
        }
        .auto-style2 {
            width: 177px;
        }
        .auto-style3 {
            width: 150px;
            text-align: right;
            font-weight: bold;
        }
        .auto-style4 {
            width: 150px;
            text-align: right;
        }
        .auto-style5 {
            width: 150px;
            text-align: right;
            height: 26px;
        }
        .auto-style6 {
            width: 300px;
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style3">
                &nbsp;</td>
            <td class="auto-style1">
                <b>UNOS </b><strong>VRSTE TRENINGA</strong></td>
            <td class="auto-style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">
                Naziv vrste treninga</td>
            <td class="auto-style6">
                <asp:TextBox ID="NazivTreningatxb" runat="server" Width="250px"></asp:TextBox>
            </td>
            <td class="auto-style4" rowspan="5">
                &nbsp;</td>
            <td rowspan="5">
                &nbsp;</td>
            <td rowspan="5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                &nbsp;</td>
            <td class="auto-style1">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                &nbsp;</td>
            <td class="auto-style1">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                &nbsp;</td>
            <td class="auto-style1">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                &nbsp;</td>
            <td class="auto-style1">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                &nbsp;</td>
            <td class="auto-style1">
                &nbsp;</td>
            <td class="auto-style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                &nbsp;</td>
            <td class="auto-style1">
                <asp:Label ID="lblStatus" runat="server" Text="status"></asp:Label>
            </td>
            <td class="auto-style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
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
            <td class="auto-style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                &nbsp;</td>
            <td class="auto-style1">
                &nbsp;</td>
            <td class="auto-style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
