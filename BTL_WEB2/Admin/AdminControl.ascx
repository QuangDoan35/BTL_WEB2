<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminControl.ascx.cs" Inherits="BTL_WEB2.Admin.AdminControl" %>
<%@ Register Src="~/Admin/Menu.ascx" TagPrefix="uc1" TagName="Menu" %>

<div style="">
    <div class="menu">
        <uc1:Menu runat="server" id="Menu" />
    </div>
    <div>
        <asp:PlaceHolder ID="plLoad" runat="server"></asp:PlaceHolder>
    </div>
</div>
