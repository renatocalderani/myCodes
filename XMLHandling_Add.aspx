public void AddKiosk_XmlConfig(string _configFile, KioskDTO kiosk)
{
    XDocument xmlFile = XDocument.Load(_configFile);

    var newElement = new XElement("kiosk",
                            new XAttribute("name", kiosk.KioskName),
                            new XAttribute("ip", kiosk.KioskIP),
                            new XAttribute("groupname", kiosk.KioskGroupName),
                            new XAttribute("username", kiosk.KioskUserName),
                            new XAttribute("password", kiosk.KioskPassword));

    xmlFile.Element("UsageReportXML").Element("kiosks").Add(new XElement(newElement));
    xmlFile.Save(_configFile);
}