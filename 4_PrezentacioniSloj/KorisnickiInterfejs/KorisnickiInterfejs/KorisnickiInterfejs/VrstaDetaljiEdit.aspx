<%@ Page Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="VrstaDetaljiEdit.aspx.cs" Inherits="KorisnickiInterfejs.VrstaDetaljiEdit" %>

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
            height: 21px;
        }
        .auto-style6 {
            width: 300px;
            height: 21px;
        }
        .auto-style7 {
            width: 177px;
            height: 21px;
        }
        .auto-style8 {
            height: 21px;
        }
        .auto-style9 {
            width: 150px;
            text-align: right;
            height: 26px;
        }
        .auto-style10 {
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
                <b>AZURIRANJE VRSTE TRENINGA</b></td>
            <td class="auto-style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                Naziv treninga&nbsp; </td>
            <td class="auto-style1">
                <asp:TextBox ID="NazivTreningatxb" runat="server" Width="285px"></asp:TextBox>
            </td>
            <td class="auto-style4" rowspan="5">
                &nbsp;</td>
            <td rowspan="5">
                &nbsp;</td>
            <td rowspan="5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">
                </td>
            <td class="auto-style6">
            </td>
        </tr>
        <tr>
            <td class="auto-style9">
                </td>
            <td class="auto-style10">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">
                </td>
            <td class="auto-style6">
            </td>
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
            <td class="auto-style5">
                </td>
            <td class="auto-style6">
                <asp:Label ID="lblStatus" runat="server" Text="status"></asp:Label>
            </td>
            <td class="auto-style7">
                </td>
            <td class="auto-style8">
                </td>
            <td class="auto-style8">
                </td>
        </tr>
        <tr>
            <td class="auto-style4">
                &nbsp;</td>
            <td class="auto-style1">
                <asp:Button ID="btnIzmeni" runat="server" Text="IZMENI" 
                    Width="90px" OnClick="btnIzmeni_Click" />
                <asp:Button ID="btnOdustani" runat="server" 
                    Text="OBRISI" OnClick="btnOdustani_Click" />
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
