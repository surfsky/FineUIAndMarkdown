<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ckeditor.aspx.cs" ValidateRequest="false" Inherits="TestFineUI.Plugins.ckeditor" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../../res/css/common.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />

        <f:SimpleForm ID="SimpleForm1" runat="server" ShowBorder="false" BodyPadding="10px" LabelWidth="60px" ShowHeader="false">
            <Toolbars>
                <f:Toolbar runat="server">
                    <Items>
                        <f:Button ID="Button1" runat="server" Text="获取编辑器的值" OnClick="btnGet_Click" />
                        <f:Button ID="Button2" runat="server" CssClass="marginr" Text="设置编辑器的值" OnClick="btnSet_Click" />
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:TextBox ID="tbTitle" Label="标题"  runat="server" />
                <f:DatePicker runat="server" Label="开始日期" DateFormatString="yyyy-MM-dd" EmptyText="请选择日期" ID="DatePicker1" ShowRedStar="True" />
                <f:ContentPanel ID="ContentPanel1" runat="server" CssStyle="padding-left:65px;"  BodyPadding="0px" Width="800px" EnableCollapse="true"
                    ShowBorder="false" ShowHeader="false" Title="内容面板">
                    <textarea id="Editor1" name="Editor1" style="width: 100%;">
                        &lt;p&gt;
                        FineUI（开源版）&lt;br&gt;
                        基于 ExtJS 的开源 ASP.NET 控件库。&lt;br&gt;
                        &lt;br&gt;
                        FineUI的使命&lt;br&gt;
                        创建 No JavaScript，No CSS，No UpdatePanel，No ViewState，No WebServices 的网站应用程序。&lt;br&gt;
                        &lt;br&gt;
                    </textarea>
                </f:ContentPanel>
            </Items>
        </f:SimpleForm>
    </form>

    <!-- CKEditor -->
    <script type="text/javascript" src="../../res/js/jquery.min.js"></script>
    <script type="text/javascript" src="./ckeditor/ckeditor.js"></script>
    <script type="text/javascript">
        var containerClientID = '<%= ContentPanel1.ClientID %>';
        F.ready(function () {
            CKEDITOR.replace('Editor1', {
                resize_enabled: true,
                height: 200,
                on: {
                    instanceReady: function () {
                        F(containerClientID).updateLayout();
                    }
                }
            });
        });

        // FineUI Ajax提交之前，将编辑器的值同步到表单字段中(textarea)
        F.beforeAjax(function () {
            $('#Editor1').val(CKEDITOR.instances['Editor1'].getData());
        });

        // 更新编辑器内容
        function updateEditor(content) {
            var editor = CKEDITOR.instances['Editor1'];
            editor.setData(content);
        }
    </script>
</body>
</html>
