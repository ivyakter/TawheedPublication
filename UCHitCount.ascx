<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UCHitCount.ascx.cs" Inherits="UCHitCount" %>


<table class="table">
    <tbody>
        <tr>
            <th scope="row"><i class="fa fa-group"></i>&nbsp;Visitor Online</th>
            <td>
                <asp:Label runat="server" ID="lblVisitorOnline"></asp:Label></td>
        </tr>
        <tr>
            <th scope="row"><i class="fa fa-group"></i>&nbsp;Today Visitor</th>
            <td>
                <asp:Label runat="server" ID="lblTodayVisitor"></asp:Label></td>
        </tr>
        <tr>
            <th scope="row"><i class="fa fa-group"></i>&nbsp;Total Visitor</th>
            <td>
                <asp:Label runat="server" ID="lblTotalVisitor"></asp:Label></td>
        </tr>
        <tr>
            <th scope="row"><i class="fa fa-globe"></i>&nbsp;Today Page Hit</th>
            <td>
                <asp:Label runat="server" ID="lblTotalPageHit"></asp:Label></td>
        </tr>
    </tbody>
</table>