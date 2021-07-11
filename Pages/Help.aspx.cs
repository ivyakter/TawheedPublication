using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Help : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ddlaction_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlaction.SelectedIndex ==1)
        {
            pnlperformance.Visible = false;
            pnlIEcacheclear.Visible = false;
            pnlfirefoxcacheclear.Visible = false;
            pnlchromecacheclearing.Visible = false;
            pnlbrowsermobile.Visible = false;
            pnlbrowserdesktop.Visible = false;
            pnloperatingsystem.Visible = false;
            pnldevices.Visible = false;
            pnlbrowser.Visible = false;
            pnlshopingbasket.Visible = false;
            pnlsearch.Visible = false;
            pnlreports.Visible = false;
            pnlregister.Visible = false;
            pnlinvoicesurveys.Visible = false;
            pnlpayment.Visible = false;
            pnlpasswordreset.Visible = false;
            pnlnavigation.Visible = false;
            pnlOrderstatus.Visible = true;
            pnllogin.Visible = false;
        }
        if (ddlaction.SelectedIndex == 2)
        {
            pnlperformance.Visible = false;
            pnlIEcacheclear.Visible = false;
            pnlfirefoxcacheclear.Visible = false;
            pnlchromecacheclearing.Visible = false;
            pnlbrowsermobile.Visible = false;
            pnlbrowserdesktop.Visible = false;
            pnloperatingsystem.Visible = false;
            pnldevices.Visible = false;
            pnlbrowser.Visible = false;
            pnlshopingbasket.Visible = false;
            pnlsearch.Visible = false;
            pnlreports.Visible = false;
            pnlregister.Visible = false;
            pnlinvoicesurveys.Visible = false;
            pnlpayment.Visible = false;
            pnlpasswordreset.Visible = false;
            pnlnavigation.Visible = false;
            pnlOrderstatus.Visible = false;
            pnllogin.Visible = true;
        }
        if (ddlaction.SelectedIndex == 3)
        {
            pnlperformance.Visible = false;
            pnlIEcacheclear.Visible = false;
            pnlfirefoxcacheclear.Visible = false;
            pnlchromecacheclearing.Visible = false;
            pnlbrowsermobile.Visible = false;
            pnlbrowserdesktop.Visible = false;
            pnloperatingsystem.Visible = false;
            pnldevices.Visible = false;
            pnlbrowser.Visible = false;
            pnlshopingbasket.Visible = false;
            pnlsearch.Visible = false;
            pnlreports.Visible = false;
            pnlregister.Visible = false;
            pnlinvoicesurveys.Visible = false;
            pnlpayment.Visible = false;
            pnlpasswordreset.Visible = false;
            pnlnavigation.Visible = true;
            pnlOrderstatus.Visible = false;
            pnllogin.Visible = false;
        }

        if (ddlaction.SelectedIndex == 4)
        {
            pnlperformance.Visible = false;
            pnlIEcacheclear.Visible = false;
            pnlfirefoxcacheclear.Visible = false;
            pnlchromecacheclearing.Visible = false;
            pnlbrowsermobile.Visible = false;
            pnlbrowserdesktop.Visible = false;
            pnloperatingsystem.Visible = false;
            pnldevices.Visible = false;
            pnlbrowser.Visible = false;
            pnlshopingbasket.Visible = false;
            pnlsearch.Visible = false;
            pnlreports.Visible = false;
            pnlregister.Visible = false;
            pnlinvoicesurveys.Visible = false;
            pnlpayment.Visible = false;
            pnlpasswordreset.Visible = true;
            pnlnavigation.Visible = false;
            pnlOrderstatus.Visible = false;
            pnllogin.Visible = false;
        }

        if (ddlaction.SelectedIndex == 5)
        {
            pnlperformance.Visible = false;
            pnlIEcacheclear.Visible = false;
            pnlfirefoxcacheclear.Visible = false;
            pnlchromecacheclearing.Visible = false;
            pnlbrowsermobile.Visible = false;
            pnlbrowserdesktop.Visible = false;
            pnloperatingsystem.Visible = false;
            pnldevices.Visible = false;
            pnlbrowser.Visible = false;
            pnlshopingbasket.Visible = false;
            pnlsearch.Visible = false;
            pnlreports.Visible = false;
            pnlregister.Visible = false;
            pnlinvoicesurveys.Visible = false;
            pnlpayment.Visible = true;
            pnlpasswordreset.Visible = false;
            pnlnavigation.Visible = false;
            pnlOrderstatus.Visible = false;
            pnllogin.Visible = false;
        }
        if (ddlaction.SelectedIndex == 6)
        {
            pnlperformance.Visible = false;
            pnlIEcacheclear.Visible = false;
            pnlfirefoxcacheclear.Visible = false;
            pnlchromecacheclearing.Visible = false;
            pnlbrowsermobile.Visible = false;
            pnlbrowserdesktop.Visible = false;
            pnloperatingsystem.Visible = false;
            pnldevices.Visible = false;
            pnlbrowser.Visible = false;
            pnlshopingbasket.Visible = false;
            pnlsearch.Visible = false;
            pnlreports.Visible = false;
            pnlregister.Visible = false;
            pnlinvoicesurveys.Visible = true;
            pnlpayment.Visible = false;
            pnlpasswordreset.Visible = false;
            pnlnavigation.Visible = false;
            pnlOrderstatus.Visible = false;
            pnllogin.Visible = false;
        }
        if (ddlaction.SelectedIndex == 7)
        {
            pnlperformance.Visible = false;
            pnlIEcacheclear.Visible = false;
            pnlfirefoxcacheclear.Visible = false;
            pnlchromecacheclearing.Visible = false;
            pnlbrowsermobile.Visible = false;
            pnlbrowserdesktop.Visible = false;
            pnloperatingsystem.Visible = false;
            pnldevices.Visible = false;
            pnlbrowser.Visible = false;
            pnlshopingbasket.Visible = false;
            pnlsearch.Visible = false;
            pnlreports.Visible = false;
            pnlregister.Visible = true;
            pnlinvoicesurveys.Visible = false;
            pnlpayment.Visible = false;
            pnlpasswordreset.Visible = false;
            pnlnavigation.Visible = false;
            pnlOrderstatus.Visible = false;
            pnllogin.Visible = false;
        }
        if (ddlaction.SelectedIndex == 8)
        {
            pnlperformance.Visible = false;
            pnlIEcacheclear.Visible = false;
            pnlfirefoxcacheclear.Visible = false;
            pnlchromecacheclearing.Visible = false;
            pnlbrowsermobile.Visible = false;
            pnlbrowserdesktop.Visible = false;
            pnloperatingsystem.Visible = false;
            pnldevices.Visible = false;
            pnlbrowser.Visible = false;
            pnlshopingbasket.Visible = false;
            pnlsearch.Visible = false;
            pnlreports.Visible = true;
            pnlregister.Visible = false;
            pnlinvoicesurveys.Visible = false;
            pnlpayment.Visible = false;
            pnlpasswordreset.Visible = false;
            pnlnavigation.Visible = false;
            pnlOrderstatus.Visible = false;
            pnllogin.Visible = false;
        }

        if (ddlaction.SelectedIndex == 9)
        {
            pnlperformance.Visible = false;
            pnlIEcacheclear.Visible = false;
            pnlfirefoxcacheclear.Visible = false;
            pnlchromecacheclearing.Visible = false;
            pnlbrowsermobile.Visible = false;
            pnlbrowserdesktop.Visible = false;
            pnloperatingsystem.Visible = false;
            pnldevices.Visible = false;
            pnlbrowser.Visible = false;
            pnlshopingbasket.Visible = false;
            pnlsearch.Visible = true;
            pnlreports.Visible = false;
            pnlregister.Visible = false;
            pnlinvoicesurveys.Visible = false;
            pnlpayment.Visible = false;
            pnlpasswordreset.Visible = false;
            pnlnavigation.Visible = false;
            pnlOrderstatus.Visible = false;
            pnllogin.Visible = false;
        }

        if (ddlaction.SelectedIndex == 10)
        {
            pnlperformance.Visible = false;
            pnlIEcacheclear.Visible = false;
            pnlfirefoxcacheclear.Visible = false;
            pnlchromecacheclearing.Visible = false;
            pnlbrowsermobile.Visible = false;
            pnlbrowserdesktop.Visible = false;
            pnloperatingsystem.Visible = false;
            pnldevices.Visible = false;
            pnlbrowser.Visible = false;
            pnlshopingbasket.Visible = true;
            pnlsearch.Visible = false;
            pnlreports.Visible = false;
            pnlregister.Visible = false;
            pnlinvoicesurveys.Visible = false;
            pnlpayment.Visible = false;
            pnlpasswordreset.Visible = false;
            pnlnavigation.Visible = false;
            pnlOrderstatus.Visible = false;
            pnllogin.Visible = false;
        }

        if (ddlaction.SelectedIndex == 11)
        {
            pnlperformance.Visible = false;
            pnlIEcacheclear.Visible = false;
            pnlfirefoxcacheclear.Visible = false;
            pnlchromecacheclearing.Visible = false;
            pnlbrowsermobile.Visible = false;
            pnlbrowserdesktop.Visible = false;
            pnloperatingsystem.Visible = false;
            pnldevices.Visible = false;
            pnlbrowser.Visible = true;
            pnlshopingbasket.Visible = false;
            pnlsearch.Visible = false;
            pnlreports.Visible = false;
            pnlregister.Visible = false;
            pnlinvoicesurveys.Visible = false;
            pnlpayment.Visible = false;
            pnlpasswordreset.Visible = false;
            pnlnavigation.Visible = false;
            pnlOrderstatus.Visible = false;
            pnllogin.Visible = false;
        }

        if (ddlaction.SelectedIndex == 12)
        {
            pnlperformance.Visible = false;
            pnlIEcacheclear.Visible = false;
            pnlfirefoxcacheclear.Visible = false;
            pnlchromecacheclearing.Visible = false;
            pnlbrowsermobile.Visible = false;
            pnlbrowserdesktop.Visible = false;
            pnloperatingsystem.Visible = false;
            pnldevices.Visible = true;
            pnlbrowser.Visible = false;
            pnlshopingbasket.Visible = false;
            pnlsearch.Visible = false;
            pnlreports.Visible = false;
            pnlregister.Visible = false;
            pnlinvoicesurveys.Visible = false;
            pnlpayment.Visible = false;
            pnlpasswordreset.Visible = false;
            pnlnavigation.Visible = false;
            pnlOrderstatus.Visible = false;
            pnllogin.Visible = false;
        }

        if (ddlaction.SelectedIndex == 13)
        {
            pnlperformance.Visible = false;
            pnlIEcacheclear.Visible = false;
            pnlfirefoxcacheclear.Visible = false;
            pnlchromecacheclearing.Visible = false;
            pnlbrowsermobile.Visible = false;
            pnlbrowserdesktop.Visible = false;
            pnloperatingsystem.Visible = true;
            pnldevices.Visible = false;
            pnlbrowser.Visible = false;
            pnlshopingbasket.Visible = false;
            pnlsearch.Visible = false;
            pnlreports.Visible = false;
            pnlregister.Visible = false;
            pnlinvoicesurveys.Visible = false;
            pnlpayment.Visible = false;
            pnlpasswordreset.Visible = false;
            pnlnavigation.Visible = false;
            pnlOrderstatus.Visible = false;
            pnllogin.Visible = false;
        }

        if (ddlaction.SelectedIndex == 14)
        {
            pnlperformance.Visible = false;
            pnlIEcacheclear.Visible = false;
            pnlfirefoxcacheclear.Visible = false;
            pnlchromecacheclearing.Visible = false;
            pnlbrowsermobile.Visible = false;
            pnlbrowserdesktop.Visible = true;
            pnloperatingsystem.Visible = false;
            pnldevices.Visible = false;
            pnlbrowser.Visible = false;
            pnlshopingbasket.Visible = false;
            pnlsearch.Visible = false;
            pnlreports.Visible = false;
            pnlregister.Visible = false;
            pnlinvoicesurveys.Visible = false;
            pnlpayment.Visible = false;
            pnlpasswordreset.Visible = false;
            pnlnavigation.Visible = false;
            pnlOrderstatus.Visible = false;
            pnllogin.Visible = false;
        }

        if (ddlaction.SelectedIndex == 15)
        {
            pnlperformance.Visible = false;
            pnlIEcacheclear.Visible = false;
            pnlfirefoxcacheclear.Visible = false;
            pnlchromecacheclearing.Visible = false;
            pnlbrowsermobile.Visible = true;
            pnlbrowserdesktop.Visible = false;
            pnloperatingsystem.Visible = false;
            pnldevices.Visible = false;
            pnlbrowser.Visible = false;
            pnlshopingbasket.Visible = false;
            pnlsearch.Visible = false;
            pnlreports.Visible = false;
            pnlregister.Visible = false;
            pnlinvoicesurveys.Visible = false;
            pnlpayment.Visible = false;
            pnlpasswordreset.Visible = false;
            pnlnavigation.Visible = false;
            pnlOrderstatus.Visible = false;
            pnllogin.Visible = false;
        }

        if (ddlaction.SelectedIndex == 16)
        {
            pnlperformance.Visible = false;
            pnlIEcacheclear.Visible = false;
            pnlfirefoxcacheclear.Visible = false;
            pnlchromecacheclearing.Visible = true;
            pnlbrowsermobile.Visible = false;
            pnlbrowserdesktop.Visible = false;
            pnloperatingsystem.Visible = false;
            pnldevices.Visible = false;
            pnlbrowser.Visible = false;
            pnlshopingbasket.Visible = false;
            pnlsearch.Visible = false;
            pnlreports.Visible = false;
            pnlregister.Visible = false;
            pnlinvoicesurveys.Visible = false;
            pnlpayment.Visible = false;
            pnlpasswordreset.Visible = false;
            pnlnavigation.Visible = false;
            pnlOrderstatus.Visible = false;
            pnllogin.Visible = false;
        }

        if (ddlaction.SelectedIndex == 17)
        {
            pnlperformance.Visible = false;
            pnlIEcacheclear.Visible = false;
            pnlfirefoxcacheclear.Visible = true;
            pnlchromecacheclearing.Visible = false;
            pnlbrowsermobile.Visible = false;
            pnlbrowserdesktop.Visible = false;
            pnloperatingsystem.Visible = false;
            pnldevices.Visible = false;
            pnlbrowser.Visible = false;
            pnlshopingbasket.Visible = false;
            pnlsearch.Visible = false;
            pnlreports.Visible = false;
            pnlregister.Visible = false;
            pnlinvoicesurveys.Visible = false;
            pnlpayment.Visible = false;
            pnlpasswordreset.Visible = false;
            pnlnavigation.Visible = false;
            pnlOrderstatus.Visible = false;
            pnllogin.Visible = false;
        }

        if (ddlaction.SelectedIndex == 18)
        {
            pnlperformance.Visible = false;
            pnlIEcacheclear.Visible = true;
            pnlfirefoxcacheclear.Visible = false;
            pnlchromecacheclearing.Visible = false;
            pnlbrowsermobile.Visible = false;
            pnlbrowserdesktop.Visible = false;
            pnloperatingsystem.Visible = false;
            pnldevices.Visible = false;
            pnlbrowser.Visible = false;
            pnlshopingbasket.Visible = false;
            pnlsearch.Visible = false;
            pnlreports.Visible = false;
            pnlregister.Visible = false;
            pnlinvoicesurveys.Visible = false;
            pnlpayment.Visible = false;
            pnlpasswordreset.Visible = false;
            pnlnavigation.Visible = false;
            pnlOrderstatus.Visible = false;
            pnllogin.Visible = false;
        }

        if (ddlaction.SelectedIndex == 20)
        {
            pnlperformance.Visible = true;
            pnlIEcacheclear.Visible = false;
            pnlfirefoxcacheclear.Visible = false;
            pnlchromecacheclearing.Visible = false;
            pnlbrowsermobile.Visible = false;
            pnlbrowserdesktop.Visible = false;
            pnloperatingsystem.Visible = false;
            pnldevices.Visible = false;
            pnlbrowser.Visible = false;
            pnlshopingbasket.Visible = false;
            pnlsearch.Visible = false;
            pnlreports.Visible = false;
            pnlregister.Visible = false;
            pnlinvoicesurveys.Visible = false;
            pnlpayment.Visible = false;
            pnlpasswordreset.Visible = false;
            pnlnavigation.Visible = false;
            pnlOrderstatus.Visible = false;
            pnllogin.Visible = false;
        }

    }
}