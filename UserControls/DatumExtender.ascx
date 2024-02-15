<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DatumExtender.ascx.cs" Inherits="ImagesUpload.UserControls.DatumExtender" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
                <asp:TextBox ID="txtDatum" runat="server" Style="width: 150px; height: 40px; font-size: 18px; border: 2px solid #ededed; border-radius: 10px; padding: 5px;" placeholder="Datum..."></asp:TextBox><cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="MaskedEditExtender1"
                    ControlToValidate="txtDatum" Display="Dynamic" EmptyValueBlurredText="Date must be entered!"
                    EmptyValueMessage="Date must be entered!" ErrorMessage="MaskedEditValidator1" IsValidEmpty="False" ToolTip="Enter the date" MaximumValueBlurredMessage="The date is outside the expected limits!" MinimumValueBlurredText="The date is outside the expected limits!" MaximumValueMessage="The date is outside the expected limits!" MinimumValueMessage="The date is outside the expected limits!" ForeColor="Red"></cc1:MaskedEditValidator>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" PopupPosition ="BottomRight" TargetControlID="txtDatum">
                </cc1:CalendarExtender>
                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server"
                    CultureName="fr-FR" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date"
                    TargetControlID="txtDatum" Century="2000">
                </cc1:MaskedEditExtender>