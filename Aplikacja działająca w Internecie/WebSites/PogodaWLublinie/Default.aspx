<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 149%;
            height: 159px;
        }
        .style2
        {
            width: 174px;
        }
        .style3
        {
            width: 240px;
        }
        .style4
        {
            width: 133px;
        }
        .style5
        {
            width: 131px;
        }
        .style6
        {
            width: 115%;
        }
        .style8
        {
            width: 132px;
        }
        .style9
        {
            width: 319px;
        }
        .style10
        {
            width: 241px;
        }
        .style11
        {
            text-align: center;
            font-weight: bold;
        }
        .style13
        {
            text-align: left;
            font-weight: normal;
            font-style: italic;
        }
        .style14
        {
            width: 174px;
            height: 26px;
        }
        .style15
        {
            width: 240px;
            height: 26px;
        }
        .style16
        {
            width: 133px;
            height: 26px;
        }
        .style17
        {
            width: 131px;
            height: 26px;
        }
        .style18
        {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="style11">
        <h1>
            Prognozowanie pogody w Lublinie</h1>
        <p class="style13">
            Aplikacja jest integralną częścią pracy magisterskiej &quot;Prognozowanie pogody przy 
            użyciu sieci neuronowej&quot; napisanej przez Jakuba Żeżułę - studenta II roku 
            dziennych studiów uzupełniających informatyki na Uniwersytecie Marii Curie 
            Skłodowskiej w Lublinie pod kierunkiem Pana Doktora Tomasza Żurka. Aplikacja 
            służy do testowania sieci neuronowej, prognozującej pogodę w Lublinie.</p>
        <p class="style13">
            &nbsp;Prognozowanie pogody realizowane jest na 1 dzień naprzód.</p>
        <p class="style13">
            Dane uzupełniamy dla 4 dni 
            z Lublina. Zaczynamy od dnia najwcześniejszego. Formularz można uzupełnić 
            ręcznie, całkowicie losowo, wygenerować losowo pewien scenariusz, który 
            wprowadzi w miarę sensowne dane dla jakiejś sytuacji pogodowej lub użyć 
            prawdziwych danych w 1985 roku i porównać otrzymane wyniki z prawidłowymi. Wyniki pojawią się na formularzu znajdującym się pod 
            formularzem do wprowadzania danycyh.</p>
        <p class="style13">
            Możemy podawać wartości w 2 systemach:</p>
        <p class="style13">
            - metryczny - temperatura: stopnie C; wiatr: m/s; ciśnienie: hPA<br />
            - angielski - temperatura: stopnie F; wiatr: knoty; ciśnienie: hPA</p>
    </div>
    <div>
    
        <asp:Button ID="buLosowo" runat="server" onclick="Button1_Click" 
            Text="Uzupełnij formlularz wejścia losowo" />
        &nbsp;&nbsp;<asp:Button ID="buPodajPrognoze" runat="server" onclick="buLicz_Click" 
            Text="Podaj prognozę" Height="26px" />
        
        <br />
        <br />
    
        System jednostek:
        <asp:DropDownList ID="cbSystem" runat="server">
            <asp:ListItem Selected="True">Metryczny</asp:ListItem>
            <asp:ListItem>Angielski</asp:ListItem>
        </asp:DropDownList>
&nbsp;Pora roku:
                &nbsp;<asp:DropDownList ID="cbPoraRokuGłówna" runat="server">
            <asp:ListItem Selected="True">Zima</asp:ListItem>
            <asp:ListItem>Przedwiośnie</asp:ListItem>
            <asp:ListItem>Wiosna</asp:ListItem>
            <asp:ListItem>Przedlecie</asp:ListItem>
            <asp:ListItem>Lato</asp:ListItem>
            <asp:ListItem>Polecie</asp:ListItem>
            <asp:ListItem>Jesień</asp:ListItem>
            <asp:ListItem>Przedzimie</asp:ListItem>
        </asp:DropDownList>
&nbsp;Data testowa:
        <asp:DropDownList ID="cbData" runat="server">
        </asp:DropDownList>
        <asp:Button ID="buWynikiTestu" runat="server" Text="Wpisz dane testowe" 
            onclick="buWynikiTestu_Click" />
        <asp:Button ID="buWynikiWszystkie" runat="server" 
            onclick="buWynikiWszystkie_Click" Text="Wszystkie wyniki" 
            Visible="False" />
        <br />
        <br />
        Scenariusz: 
        <asp:DropDownList ID="cbPoraRoku" runat="server">
            <asp:ListItem Selected="True">Zima</asp:ListItem>
            <asp:ListItem>Przedwiośnie</asp:ListItem>
            <asp:ListItem>Wiosna</asp:ListItem>
            <asp:ListItem>Przedlecie</asp:ListItem>
            <asp:ListItem>Lato</asp:ListItem>
            <asp:ListItem>Polecie</asp:ListItem>
            <asp:ListItem>Jesień</asp:ListItem>
            <asp:ListItem>Przedzimie</asp:ListItem>
        </asp:DropDownList>
&nbsp;<asp:DropDownList ID="cbCzyCiepło" runat="server">
            <asp:ListItem Selected="True">Zimno</asp:ListItem>
            <asp:ListItem>Normalnie</asp:ListItem>
            <asp:ListItem>Ciepło</asp:ListItem>
        </asp:DropDownList>
&nbsp;<asp:DropDownList ID="cbCzyStabilnie" runat="server">
            <asp:ListItem Selected="True">Ochłodzenie</asp:ListItem>
            <asp:ListItem>Stabilnie</asp:ListItem>
            <asp:ListItem>Ocieplenie</asp:ListItem>
        </asp:DropDownList>
&nbsp;<asp:Button ID="buGenerujScenariusz" runat="server" 
            onclick="buGenerujScenariusz_Click" 
            Text="Generuj scenariusz" Width="250px" />
            <br />
    
    </div>
    <table class="style1">
        <tr>
            <td class="style2">
        <asp:DropDownList ID="cbMiasto0" runat="server"  
                    style="margin-bottom: 0px" Enabled="False">
            <asp:ListItem Selected="True">Lublin</asp:ListItem>
            <asp:ListItem>Legnica</asp:ListItem>
            <asp:ListItem>Miskolc</asp:ListItem>
            <asp:ListItem>Mogilev</asp:ListItem>
            <asp:ListItem>Suwałki</asp:ListItem>
        </asp:DropDownList>
    
            </td>
            <td class="style3">
                <asp:DropDownList ID="cbDzień0" runat="server" Height="21px" 
                    onselectedindexchanged="cbMiasto_SelectedIndexChanged" Width="64px" 
                    Enabled="False">
                    <asp:ListItem Selected="True">1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                Temperatura MAX:</td>
            <td class="style3">
                <asp:TextBox ID="tbTempMax0" runat="server" 
                    ontextchanged="tbTempMaxW_TextChanged"></asp:TextBox>
            </td>
            <td class="style4">
                Prędkość wiatru:</td>
            <td class="style5">
                <asp:TextBox ID="tbWiatrPr0" runat="server" 
                    ontextchanged="tbTempMaxW_TextChanged"></asp:TextBox>
            </td>
            <td>
                <asp:CheckBox ID="cbDeszcz0" runat="server" Text="Deszcz" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                Temperatura MIN:</td>
            <td class="style3">
                <asp:TextBox ID="tbTempMin0" runat="server" 
                    ontextchanged="tbTempMaxW_TextChanged"></asp:TextBox>
            </td>
            <td class="style4">
                Zonal indeks:</td>
            <td class="style5">
                <asp:TextBox ID="tbZonalIndeks0" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:CheckBox ID="cbŚnieg0" runat="server" Text="Śnieg" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                Temperatura punktu rosy:</td>
            <td class="style3">
                <asp:TextBox ID="tbTempPR0" runat="server" 
                    ontextchanged="tbTempMaxW_TextChanged"></asp:TextBox>
            </td>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                Ciśnienie:</td>
            <td class="style3">
                <asp:TextBox ID="tbCiśnienie0" runat="server" 
                    ontextchanged="tbTempMaxW_TextChanged"></asp:TextBox>
            </td>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <table class="style1">
        <tr>
            <td class="style2">
        <asp:DropDownList ID="cbMiasto1" runat="server" 
                    onselectedindexchanged="cbMiasto_SelectedIndexChanged" 
                    style="margin-bottom: 0px" Enabled="False">
            <asp:ListItem Selected="True">Lublin</asp:ListItem>
            <asp:ListItem>Legnica</asp:ListItem>
            <asp:ListItem>Miskolc</asp:ListItem>
            <asp:ListItem>Mogilev</asp:ListItem>
            <asp:ListItem>Suwałki</asp:ListItem>
        </asp:DropDownList>
    
            </td>
            <td class="style3">
                <asp:DropDownList ID="cbDzień1" runat="server" Height="21px" 
                    onselectedindexchanged="cbMiasto_SelectedIndexChanged" Width="64px" 
                    Enabled="False">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem Selected="True">2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                Temperatura MAX:</td>
            <td class="style3">
                <asp:TextBox ID="tbTempMax1" runat="server" 
                    ontextchanged="tbTempMaxW_TextChanged"></asp:TextBox>
            </td>
            <td class="style4">
                Prędkość wiatru:</td>
            <td class="style5">
                <asp:TextBox ID="tbWiatrPr1" runat="server" 
                    ontextchanged="tbTempMaxW_TextChanged"></asp:TextBox>
            </td>
            <td>
                <asp:CheckBox ID="cbDeszcz1" runat="server" Text="Deszcz" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                Temperatura MIN:</td>
            <td class="style3">
                <asp:TextBox ID="tbTempMin1" runat="server" 
                    ontextchanged="tbTempMaxW_TextChanged"></asp:TextBox>
            </td>
            <td class="style4">
                Zonal indeks:</td>
            <td class="style5">
                <asp:TextBox ID="tbZonalIndeks1" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:CheckBox ID="cbŚnieg1" runat="server" Text="Śnieg" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                Temperatura punktu rosy:</td>
            <td class="style3">
                <asp:TextBox ID="tbTempPR1" runat="server" 
                    ontextchanged="tbTempMaxW_TextChanged"></asp:TextBox>
            </td>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                Ciśnienie:</td>
            <td class="style3">
                <asp:TextBox ID="tbCiśnienie1" runat="server" 
                    ontextchanged="tbTempMaxW_TextChanged"></asp:TextBox>
            </td>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <table class="style1">
        <tr>
            <td class="style2">
        <asp:DropDownList ID="cbMiasto2" runat="server" 
                    onselectedindexchanged="cbMiasto_SelectedIndexChanged" 
                    style="margin-bottom: 0px" Enabled="False">
            <asp:ListItem Selected="True">Lublin</asp:ListItem>
            <asp:ListItem>Legnica</asp:ListItem>
            <asp:ListItem>Miskolc</asp:ListItem>
            <asp:ListItem>Mogilev</asp:ListItem>
            <asp:ListItem>Suwałki</asp:ListItem>
        </asp:DropDownList>
    
            </td>
            <td class="style3">
                <asp:DropDownList ID="cbDzień2" runat="server" Height="21px" 
                    onselectedindexchanged="cbMiasto_SelectedIndexChanged" Width="64px" 
                    Enabled="False">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem Selected="True">3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                Temperatura MAX:</td>
            <td class="style3">
                <asp:TextBox ID="tbTempMax2" runat="server" 
                    ontextchanged="tbTempMaxW_TextChanged"></asp:TextBox>
            </td>
            <td class="style4">
                Prędkość wiatru:</td>
            <td class="style5">
                <asp:TextBox ID="tbWiatrPr2" runat="server" 
                    ontextchanged="tbTempMaxW_TextChanged"></asp:TextBox>
            </td>
            <td>
                <asp:CheckBox ID="cbDeszcz2" runat="server" Text="Deszcz" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                Temperatura MIN:</td>
            <td class="style3">
                <asp:TextBox ID="tbTempMin2" runat="server" 
                    ontextchanged="tbTempMaxW_TextChanged"></asp:TextBox>
            </td>
            <td class="style4">
                Zonal indeks:</td>
            <td class="style5">
                <asp:TextBox ID="tbZonalIndeks2" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:CheckBox ID="cbŚnieg2" runat="server" Text="Śnieg" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                Temperatura punktu rosy:</td>
            <td class="style3">
                <asp:TextBox ID="tbTempPR2" runat="server" 
                    ontextchanged="tbTempMaxW_TextChanged"></asp:TextBox>
            </td>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                Ciśnienie:</td>
            <td class="style3">
                <asp:TextBox ID="tbCiśnienie2" runat="server" 
                    ontextchanged="tbTempMaxW_TextChanged"></asp:TextBox>
            </td>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <table class="style1">
        <tr>
            <td class="style14">
        <asp:DropDownList ID="cbMiasto3" runat="server" 
                    onselectedindexchanged="cbMiasto_SelectedIndexChanged" 
                    style="margin-bottom: 0px" Enabled="False">
            <asp:ListItem Selected="True">Lublin</asp:ListItem>
            <asp:ListItem>Legnica</asp:ListItem>
            <asp:ListItem>Miskolc</asp:ListItem>
            <asp:ListItem>Mogilev</asp:ListItem>
            <asp:ListItem>Suwałki</asp:ListItem>
        </asp:DropDownList>
    
            </td>
            <td class="style15">
                <asp:DropDownList ID="cbDzień3" runat="server" Height="21px" 
                    onselectedindexchanged="cbMiasto_SelectedIndexChanged" Width="64px" 
                    Enabled="False">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem Selected="True">4</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style16">
                </td>
            <td class="style17">
                </td>
            <td class="style18">
                </td>
        </tr>
        <tr>
            <td class="style2">
                Temperatura MAX:</td>
            <td class="style3">
                <asp:TextBox ID="tbTempMax3" runat="server" 
                    ontextchanged="tbTempMaxW_TextChanged"></asp:TextBox>
            </td>
            <td class="style4">
                Prędkość wiatru:</td>
            <td class="style5">
                <asp:TextBox ID="tbWiatrPr3" runat="server" 
                    ontextchanged="tbTempMaxW_TextChanged"></asp:TextBox>
            </td>
            <td>
                <asp:CheckBox ID="cbDeszcz3" runat="server" Text="Deszcz" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                Temperatura MIN:</td>
            <td class="style3">
                <asp:TextBox ID="tbTempMin3" runat="server" 
                    ontextchanged="tbTempMaxW_TextChanged"></asp:TextBox>
            </td>
            <td class="style4">
                Zonal indeks:</td>
            <td class="style5">
                <asp:TextBox ID="tbZonalIndeks3" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:CheckBox ID="cbŚnieg3" runat="server" Text="Śnieg" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                Temperatura punktu rosy:</td>
            <td class="style3">
                <asp:TextBox ID="tbTempPR3" runat="server" 
                    ontextchanged="tbTempMaxW_TextChanged"></asp:TextBox>
            </td>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                Ciśnienie:</td>
            <td class="style3">
                <asp:TextBox ID="tbCiśnienie3" runat="server" 
                    ontextchanged="tbTempMaxW_TextChanged"></asp:TextBox>
            </td>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <br />
    <asp:Button ID="buLicz" runat="server" Text="Podaj prognozę" onclick="buLicz_Click" 
         />
    <p>
        Wyniki:</p>
    <table class="style6">
        <tr>
            <td class="style10">
                Temperatura MAX:</td>
            <td class="style8">
                <asp:TextBox ID="tbTempMaxW" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td class="style9">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style10">
                Temperatura MIN:</td>
            <td class="style8">
                <asp:TextBox ID="tbTempMinW" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td class="style9">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style10">
                Ciśnienie:</td>
            <td class="style8">
                <asp:TextBox ID="tbCiśnienieW" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td class="style9">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style10">
                &nbsp;</td>
            <td class="style8">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style10">
                &nbsp;</td>
            <td class="style8">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <p>
        Poprawny wynik (tylko dla realnych danych):</p>
    <table class="style6">
        <tr>
            <td class="style10">
                Temperatura MAX:</td>
            <td class="style8">
                <asp:TextBox ID="tbTempMaxW0" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td class="style9">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style10">
                Temperatura MIN:</td>
            <td class="style8">
                <asp:TextBox ID="tbTempMinW0" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td class="style9">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style10">
                Ciśnienie:</td>
            <td class="style8">
                <asp:TextBox ID="tbCiśnienieW0" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td class="style9">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style10">
                &nbsp;</td>
            <td class="style8">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style10">
                &nbsp;</td>
            <td class="style8">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </form>
</body>
</html>
