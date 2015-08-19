<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Info._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Телефонный справочник ОАО КБ “Жилстройбанк”</title>
    <link href="StroyStyle.css" rel="stylesheet" type="text/css" />
</head>
<body style ="background-color:#DEDDFF">
    <iframe src="Head.htm" width=100%  height = 70  scrolling=no></iframe>
   
    
    <form id="PhoneTable" runat="server" height = 100% style ="background-color:#DfDfFF">
        <div >
            <table width="100%"  border="0" cellspacing="0" cellpadding="0">
                <tbody>
                       <tr   >
                         <td align="left">
                             <asp:ImageButton ID="ImageButton1" runat="server" BorderStyle="None" 
                                 ImageAlign="Bottom" ImageUrl="~/img/GO.png" onclick="ImageButton1_Click" />
                             <asp:ImageButton ID="ImageButton2" runat="server" ImageAlign="Bottom" 
                                 ImageUrl="~/img/DO1.png" onclick="ImageButton2_Click" />
                             <asp:ImageButton ID="ImageButton3" runat="server" ImageAlign="Bottom" 
                                 ImageUrl="~/img/ALL.png" onclick="ImageButton3_Click" />
                         </td>
                         <td align= "right">
                            <asp:Label ID="Label1"  runat="server" Text="Поиск"></asp:Label>
                            <asp:TextBox ID="TextBox1" runat="server" Width=50%></asp:TextBox>
                            <asp:Button ID="Button3" runat="server" Text="Искать" onclick="Button3_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div >
            <asp:Panel ID="Panel1" BackColor=White runat="server" Height="100%" Width="100%">
                <div id="tableContent" runat="server"></div>
            </asp:Panel>
        </div>
    </form>
   
         

</body>
</html>
