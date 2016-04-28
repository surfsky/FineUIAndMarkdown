using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;

namespace TestFineUI.Plugins.MdEditor
{
    public partial class TestMd3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 编辑器初始值可如下设置
                edtArea.InnerText = "###hello world!";
            }
        }

        protected void btnSet_Click(object sender, EventArgs e)
        {
            // 直接操作 textarea 失败
            //edtArea.InnerText = "## This is title"; 

            // 注册脚本到客户端成功
            string content = "## This is title";
            PageContext.RegisterStartupScript(String.Format("updateEditor({0});", JsHelper.Enquote(content)));
        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            // string id = string.Format("{0}-markdown-doc", this.edt.ClientID);
            string id = edtArea.ClientID.Replace('_', '$');  // 表单提交过来就是这个名称，不是用ClientID
            string txt = Request.Form[id];
            if (String.IsNullOrEmpty(txt))
                Alert.ShowInTop("编辑器内容为空！");
            else
                Alert.ShowInTop(HttpUtility.HtmlEncode(txt));
        }
    }
}