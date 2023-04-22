using System.Management;

namespace Salhani.HardwareInfo
{
    public class GetInfo
    {
        public string GetCpuSerial()
        {
            string Variable = null;
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                Variable = mo.Properties["processorID"].Value.ToString();
                
                break;
            }
            return Variable;
        }
        public string GetHardDriveSerial()
        {
            string Variable = null;
            ManagementObjectSearcher searcher = new
            ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

            foreach (ManagementObject wmi_HD in searcher.Get())
            {
                if(wmi_HD.Properties.Count>1)
                Variable = wmi_HD["SerialNumber"].ToString();
                break;
            }
            return Variable;
        }
    }
}
