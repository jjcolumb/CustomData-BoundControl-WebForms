<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DepartmentViewControl.ascx.cs" Inherits="CustomData_BoundControl_WebForms.Web.DepartmentViewControl" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v22.2, Version=22.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>

<dx:ASPxTextBox ID="TitleControl" runat="server" Caption="Title" Width="100%"></dx:ASPxTextBox>
<div style="height:5px"></div>
<dx:ASPxCardView ID="ContactsControl" runat="server" AutoGenerateColumns="false">
    <Columns>
        <dx:CardViewTextColumn Name="FullName" FieldName="FullName" Caption="Full Name" VisibleIndex="0"></dx:CardViewTextColumn>
        <dx:CardViewTextColumn Name="Email" FieldName="Email" Caption="Email" VisibleIndex="1"></dx:CardViewTextColumn>
    </Columns>
    <SettingsPager>
        <SettingsTableLayout ColumnCount="2" />
    </SettingsPager>
</dx:ASPxCardView>
