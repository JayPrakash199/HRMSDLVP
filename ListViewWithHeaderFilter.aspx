<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListViewWithHeaderFilter.aspx.cs" Inherits="HRMS.ListViewWithHeaderFilter" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ListView Header Filter Example</title>
    <style>
        table {
            width: 100%;
            border-collapse: collapse;
        }
        th, td {
            border: 1px solid #ddd;
            padding: 8px;
        }
        th {
            background-color: #f2f2f2;
            text-align: left;
        }
        .filter-dropdown {
            position: absolute;
            background: #fff;
            border: 1px solid #ddd;
            padding: 10px;
            z-index: 1000;
        }
    </style>
    <link href="assets/vendor/css/font-awesome.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ListView ID="lvData" runat="server">
                <LayoutTemplate>
                    <table>
                        <thead>
                            <tr>
                                <th>
                                    Company Name
                                    <a href="#" onclick="toggleFilter('companyFilter')"> <i class="fa fa-filter" aria-hidden="true"></i> </a>
                                    <div id="companyFilter" class="filter-dropdown" style="display:none;">
                                        <asp:TextBox ID="txtCompanyFilter" runat="server" onkeyup="filterCheckboxList('lvData_chkCompanyFilter', 'lvData_txtCompanyFilter')" placeholder="Enter text to filter"></asp:TextBox>
                                        <asp:CheckBoxList ID="chkCompanyFilter" runat="server"></asp:CheckBoxList>
                                        <asp:Button ID="btnApplyCompanyFilter" runat="server" Text="OK" OnClick="btnApplyCompanyFilter_Click" />
                                    </div>
                                </th>
                                <th>
                                    Country
                                    <a href="#" onclick="toggleFilter('countryFilter')"> &#x25BC; </a>
                                    <div id="countryFilter" class="filter-dropdown" style="display:none;">
                                        <asp:CheckBoxList ID="chkCountryFilter" runat="server"></asp:CheckBoxList>
                                        <asp:Button ID="btnApplyCountryFilter" runat="server" Text="OK" OnClick="btnApplyCountryFilter_Click" />
                                    </div>
                                </th>
                                <th>City</th>
                                <th>Unit Price</th>
                                <th>Quantity</th>
                                <th>Discount</th>
                                <th>Total</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("CompanyName") %></td>
                        <td><%# Eval("Country") %></td>
                        <td><%# Eval("City") %></td>
                        <td><%# Eval("UnitPrice") %></td>
                        <td><%# Eval("Quantity") %></td>
                        <td><%# Eval("Discount") %></td>
                        <td><%# Eval("Total") %></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </form>
    <script type="text/javascript">
        function toggleFilter(filterId) {
            var filterDiv = document.getElementById(filterId);
            if (filterDiv.style.display === "none") {
                filterDiv.style.display = "block";
            } else {
                filterDiv.style.display = "none";
            }
        }
     

        function filterCheckboxList(filterId, textboxId) {
            var filterText = document.getElementById(textboxId).value.toLowerCase();
            var checkBoxList = document.getElementById(filterId).getElementsByTagName('input');
            for (var i = 0; i < checkBoxList.length; i++) {
                var listItem = checkBoxList[i].parentNode;
                var text = listItem.innerText.toLowerCase();
                listItem.style.display = text.includes(filterText) ? '' : 'none';
            }
        }
    </script>
</body>
</html>
