using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using FineUI;

namespace TestFineUI.Plugins
{
    /// <summary>
    /// 测试集成 CKEditor
    /// ? 如何解决“检测到危险的form值....”
    /// </summary>
    public partial class ckeditor : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            string editorContent = Request.Form["Editor1"].ToString();
            if (String.IsNullOrEmpty(editorContent))
            {
                Alert.ShowInTop("编辑器内容为空！");
            }
            else
            {
                Alert.ShowInTop(HttpUtility.HtmlEncode(editorContent));
            }
        }

        protected void btnSet_Click(object sender, EventArgs e)
        {
            string content = "基于 ExtJS 的开源 ASP.NET 控件库。";
            PageContext.RegisterStartupScript(String.Format("updateEditor({0});", JsHelper.Enquote(content)));
        }





    }
}
