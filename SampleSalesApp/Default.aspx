<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SampleSalesApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-4">
             <table class="style1">
            <tr>
                <td class="style3">
                     Name</td>
                <td class="style4">
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name cannot be blank" ControlToValidate="txtName" ForeColor="Red"></asp:RequiredFieldValidator> 
                </td>
      
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    Qty</td>
                <td class="style4">
                    <asp:TextBox ID="txtQty" runat="server" AutoPostBack="True" 
                        ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Qty cannot be blank" ControlToValidate="txtQty" ForeColor="Red"></asp:RequiredFieldValidator> 
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                     Rate</td>
                <td class="style4">
                    <asp:TextBox ID="txtRate" runat="server"  AutoPostBack="True">
                       </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Rate cannot be blank" ControlToValidate="txtRate" ForeColor="Red"></asp:RequiredFieldValidator> 
                </td>
                <td class="style6">
                <td>
                    &nbsp;</td>
            </tr>
            <tr>                          
                <td class="style9">
                   <asp:Button ID="btnAdd" runat="server" CausesValidation="true" 
                        Text="Add" onclick="btnAdd_Click"/>
                </td>
            </tr>
        </table>
        </div>
        <%--<div class="col-md-10">--%>
            <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
        EmptyDataText="No records has been added." DataKeyNames="Name" 
             OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating" >
         <Columns> 
         <asp:BoundField DataField="Id" HeaderText="Id" ItemStyle-Width="0" Visible ="false"/>
        <asp:BoundField DataField="Slno" HeaderText="Slno" ItemStyle-Width="100" />    
        <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-Width="120" />
        <asp:BoundField DataField="Qty" HeaderText="Qty" ItemStyle-Width="80" />
        <asp:BoundField DataField="Rate" HeaderText="Rate" ItemStyle-Width="100" />
        <asp:BoundField DataField="Total" HeaderText="Total" ItemStyle-Width="120" />
             <asp:TemplateField HeaderText="Edit">
            <ItemStyle Width="5%" />
            <ItemTemplate >
                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName="update">Edit</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
             <asp:TemplateField HeaderText="Delete">
            <ItemStyle Width="5%" />
            <ItemTemplate >
                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="false" CommandName="delete">Delete</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
        </asp:GridView>
        <div style="float:left; width: 450px;">
             <asp:Button ID="Button2" runat="server" CausesValidation="true" 
                        Text="Print" onclick="btnPrint_Click"/>
            </div>
      <%--  </div>--%>
    </div>
</asp:Content>
