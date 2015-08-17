<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Info._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Телефонный справочник ОАО КБ “Жилстройбанк”</title>
</head>
<body style ="background-color:#DEDDFF">
    <iframe src="Head.htm" width=100%  height = 50  scrolling=no></iframe>
   
   
    <form id="PhoneTable" runat="server" height = 100% style ="background-color:#DfDfFF">
        <div >
            <table width="100%"  border="1" cellspacing="0" cellpadding="0">
            <tbody><tr>
            <td align="left">
                    <asp:Button ID="Button1" runat="server" Text="Головной офис" Width="150px" />
            <td>
                    <asp:Button ID="Button2" runat="server" Text="ДО Хорошевский" Width="150px" />
            <td align="left">
            
                    <asp:Label ID="Label1"  runat="server" Text="Поиск"></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server" Width=100%></asp:TextBox>
                    <asp:Button ID="Button3" Text="Искать" runat="server" Text="Button" />

            </td>
            </tr>
            </tbody>
            </table>
        </div>
        <div >
 
            
 
        </div>
    </form>
   
         

</body>
</html>
