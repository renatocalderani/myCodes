<asp:GridView ID="grdExistingKiosks" runat="server" Font-Name="Verdana" Font-Size="10pt" CellPadding="4" HeaderStyle-BackColor="#444444" HeaderStyle-ForeColor="White"
    AlternatingRowStyle-BackColor="#dddddd" HorizontalAlign="Center" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="grdExistingKiosks_PageIndexChanging">
    <Columns>
        <asp:BoundField DataField="KioskName" HeaderText="Kiosk Name" />
        <asp:BoundField DataField="KioskIP" HeaderText="Kiosk IP" />
        <asp:BoundField DataField="KioskUserName" HeaderText="Network Username" />
        <asp:BoundField DataField="KioskPassword" HeaderText="Network Password" />
        <asp:BoundField DataField="KioskGroupName" HeaderText="Belongs to Group" />
    </Columns>
</asp:GridView>