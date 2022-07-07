<%@ Page Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="PlanDetaljiEdit.aspx.cs" Inherits="KorisnickiInterfejs.PlanDetaljiEdit" %>


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
            height: 21px;
        }
        .auto-style4 {
        width: 290px;
        text-align: right;
    }
        .auto-style5 {
            width: 548px;
            height: 21px;
        }
        .auto-style6 {
            height: 21px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style3">
                </td>
            <td class="auto-style5">
                <b>IZMENA PLANA</b></td>
            <td class="auto-style6">
                </td>
        </tr>
        <tr>
            <td class="auto-style4">
                Naziv treninga</td>
            <td class="auto-style1">
                <asp:DropDownList ID="VrstaDDL" runat="server" Width="250px">
                </asp:DropDownList>
                <asp:Label ID="VrstaPrethodnaVrednostLabel" runat="server" Text="Label"></asp:Label>
            </td>
            <td rowspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                Opis treninga</td>
            <td class="auto-style1">
                <asp:TextBox ID="OpisTxb" runat="server" Height="138px" Width="245px"></asp:TextBox>
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
                    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
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
                <asp:Label ID="VremePrethodnaVrednostLabel" runat="server" Text="Label"></asp:Label>
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
                
                <asp:Button ID="btnIzmeni" runat="server"  Text="IZMENI" 
                    Width="90px" OnClick="btnIzmeni_Click" />
                 
                <asp:Button ID="btnObrisi" runat="server"  
                    Text="OBRISI" OnClick="btnObrisi_Click" />

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
