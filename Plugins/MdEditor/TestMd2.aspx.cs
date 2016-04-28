using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestFineUI.Plugins.MdEditor
{
    public partial class TestMd2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 初始化失败，估计是位置不对，但不知道怎么将脚本注册到html最后
                string script = "editor.setMarkdown('## helloworld');";
                ScriptManager.RegisterStartupScript(this, typeof(string), "script", script, true);
                //ScriptManager.RegisterClientScriptBlock(this, typeof(string), "script", script, true);
            }
        }

        protected void btnSet_Click(object sender, EventArgs e)
        {
            // 设置失败，估计是位置不对，但不知道怎么将脚本注册到html最后
            string script = "editor.setMarkdown('## helloworld');";
            //ScriptManager.RegisterClientScriptBlock(this, typeof(string), "script", script, true);
            ScriptManager.RegisterStartupScript(this, typeof(string), "script", script, true);
        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            // 获取成功，但成功后编辑器内容又清空了
            string txt = Request["edt-markdown-doc"].ToString();
            Kingsoc.Web.ScriptHelper.Alert(txt);
        }
    }
}