 private void LoadReport_TT(List<KioskDTO> lstKiosk)
{
    reportViewer.ProcessingMode = ProcessingMode.Local;
    reportViewer.LocalReport.EnableExternalImages = true;

    string exeFolder = Path.GetDirectoryName(Application.ExecutablePath);
    string reportPath = Path.Combine(exeFolder, @"Reports/rptKioskUsage.rdlc");
    reportViewer.LocalReport.ReportPath = reportPath;

    lstKiosk = (from items in lstKiosk
                where items.KioskGroupName.Contains("TT")
                select items).ToList<KioskDTO>();

    ReportDataSource rptDataSource = new ReportDataSource("dsKioskUsage", lstKiosk);
    ReportParameter pDateFrom = new ReportParameter("pDateFrom", this.DateFROM.ToString("dd/MM/yyyy"));
    ReportParameter pDateTo = new ReportParameter("pDateTo", this.DateTO.ToString("dd/MM/yyyy"));
    ReportParameter pAirline = new ReportParameter("pAirline", "Tiger Air");
    ReportParameter pAirlineLogo = new ReportParameter("pAirlineLogo", Path.Combine(exeFolder, @"Images\TTlogo_rpt.jpg"));
    reportViewer.LocalReport.SetParameters(new ReportParameter[] { pDateFrom, pDateTo, pAirline, pAirlineLogo });
    reportViewer.LocalReport.DataSources.Clear();
    reportViewer.LocalReport.DataSources.Add(rptDataSource);
    reportViewer.RefreshReport();
}