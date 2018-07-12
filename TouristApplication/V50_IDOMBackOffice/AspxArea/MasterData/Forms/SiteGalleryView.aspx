<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="SiteGalleryView.aspx.cs" Inherits="V50_IDOMBackOffice.AspxArea.MasterData.Forms.SiteGalleryView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<dx:ASPxFileManager ID="SiteFileManager" runat="server" ClientInstanceName="FileManager" Height="367px" OnFileUploading="SiteFileManager_FileUploading" OnLoad="SiteFileManager_Load" ProviderType="Physical" Width="520px">
                            <Settings EnableMultiSelect="True" RootFolder="~/" ThumbnailFolder="~/Thumb/" />
                            <SettingsFileList>
                                <ThumbnailsViewSettings ThumbnailHeight="220px" ThumbnailWidth="220px">
                                </ThumbnailsViewSettings>
                            </SettingsFileList>
                            <SettingsEditing AllowDelete="True" AllowDownload="True" />
                            <SettingsFolders Visible="False" />
                            <SettingsToolbar ShowFilterBox="False" ShowPath="False">
                                <Items>
                                    <dx:FileManagerToolbarCustomButton CommandName="CropLogo" Text="Logo Image">
                                    </dx:FileManagerToolbarCustomButton>
                                    <dx:FileManagerToolbarCustomButton CommandName="CropTitel" Text="Titel Image">
                                    </dx:FileManagerToolbarCustomButton>
                                    <dx:FileManagerToolbarDownloadButton ToolTip="Download">
                                    </dx:FileManagerToolbarDownloadButton>
                                    <dx:FileManagerToolbarDeleteButton ToolTip="Delete (Del)">
                                    </dx:FileManagerToolbarDeleteButton>
                                    <dx:FileManagerToolbarRefreshButton ToolTip="Refresh">
                                    </dx:FileManagerToolbarRefreshButton>
                                </Items>
                            </SettingsToolbar>
                            <SettingsUpload>
                                <AdvancedModeSettings EnableMultiSelect="True">
                                </AdvancedModeSettings>
                            </SettingsUpload>
                            <SettingsAzure AccountName="adriabookblob" ContainerName="dataimage" />
                        </dx:ASPxFileManager>
</asp:Content>
