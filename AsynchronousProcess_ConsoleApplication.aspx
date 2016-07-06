/// <summary>
/// Main method where robot process logs
/// </summary>
private void RobotProcess()
{
    try
    {
        Console.WriteLine("Start process " + DateTime.Now.ToString() + Environment.NewLine);

        _dao = new FileControl();
        List<KioskDTO> listKiosk = _dao.ReturnListOfKiosks(_configFile);

        Parallel.ForEach<KioskDTO>(listKiosk, new ParallelOptions { MaxDegreeOfParallelism = 3 }, kiosk => ProcessKiosk_Assynchronous(kiosk));

        Console.WriteLine(Environment.NewLine + "All process finished " + DateTime.Now.ToString());
    }
    catch (Exception exc)
    {
        CreateLogError("Error!! Method: " + exc.TargetSite.Name + ". Details: " + exc.Message);
    }
}

private void ProcessKiosk_Assynchronous(KioskDTO kiosk)
{
    try
    {
        //Start process
        Console.WriteLine("Starting process for Kiosk " + kiosk.KioskName + "... " + DateTime.Now);

        //Get necessary information to process kiosk
        LogInfoDTO logInfo = _dao.ReturnLogInformation("PCPNET", _configFile);

        //Get date to check the logs
        //0 = same day that is running
        //1 = get logs from "yesterday"
        int _whentocheck = int.Parse(RetrieveConfigKey("LogsFrom_todayORyesterday"));

        string finalCounting_Path = RetrieveConfigKey("FinalCounting_Path") + @"\" + DateTime.Now.AddDays(-_whentocheck).ToString(@"yyyy/MM").Replace("/", @"\");
        finalCounting_Path = finalCounting_Path + @"\" + DateTime.Now.AddDays(-_whentocheck).ToString("dd.MM.yyyy");

        string logPath_network = kiosk.KioskIP + @"\" + logInfo.Address;

        //Execute NET USE command
        _dao.ExecuteCommand(@"net use \\" + kiosk.KioskIP + @"\c$ " + kiosk.KioskPassword + " /user:" + kiosk.KioskUserName, 5000);

        //Get logs only pre-defined date and only ATB logs (it looks for the modified date)
        string[] todayLogs = Directory.GetFiles(@"\\" + logPath_network)
                          .Where(x => (
                                            new FileInfo(x).LastWriteTime.Date == DateTime.Now.Date
                                        ||
                                            new FileInfo(x).LastWriteTime.Date == DateTime.Now.AddDays(-_whentocheck).Date
                                      )
                                    &&
                              new FileInfo(x).Name.Contains("ATB")
                        ).ToArray();

        //Get quantity of passengers for the Kiosk and create final report text file
        _dao.GetPassengersProcessed(kiosk, todayLogs, finalCounting_Path, logInfo, _whentocheck);

        //Finish process
        Console.WriteLine(Fineshed process at " + DateTime.Now + Environment.NewLine);
    }
    catch (Exception exc)
    {
        //Exception handling
    }
}