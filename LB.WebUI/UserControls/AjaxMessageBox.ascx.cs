using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AjaxControl_AjaxMessageBox : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region 属性
    /// <summary>
    /// 对话框的宽度
    /// </summary>
    public Unit Width
    {
        get { return pnlMessage.Width; }
        set { pnlMessage.Width = value; }
    }

    /// <summary>
    /// 对话框的高度
    /// </summary>
    public Unit Height
    {
        get { return pnlMessage.Width; }
        set { pnlMessage.Height = value; }
    }

    public string MessageText
    {
        get { return lbMessage.Text; }
        set { lbMessage.Text = value; }
    }

    public string TargetControlID
    {
        get { return ModalPopupExtender1.TargetControlID; }
        set { ModalPopupExtender1.TargetControlID = value; }
    }
    #endregion

    public void Show()
    {
        ModalPopupExtender1.Show();
    }

    public void Show(string messageText)
    {
        lbMessage.Text = messageText;
        ModalPopupExtender1.Show();
    }

    public void Hide()
    {
        ModalPopupExtender1.Hide();
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        ModalPopupExtender1.Hide();
    }

    protected void UpdatePanel1_Load(object sender, EventArgs e)
    {
        UpdatePanel1.Update();
    }
}