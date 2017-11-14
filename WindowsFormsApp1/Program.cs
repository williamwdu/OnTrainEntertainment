using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using System.Management;
using System.IO;
using System.IO.Ports;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    public class Station
    {
        public Waypoint middle { get; set; }
        public Waypoint left { get; set; }
        public Waypoint right { get; set; }
        public String order1 { get; set; }
        public String order2 { get; set; }

    }
    public class Waypoint
    {
        public String name { get; set; }
        public String lat { get; set; }
        public String lng { get; set; }
    }

    public class PowerHelper
    {
        public static void ForceSystemAwake()
        {
            NativeMethods.SetThreadExecutionState(NativeMethods.EXECUTION_STATE.ES_CONTINUOUS |
                                                  NativeMethods.EXECUTION_STATE.ES_DISPLAY_REQUIRED |
                                                  NativeMethods.EXECUTION_STATE.ES_SYSTEM_REQUIRED |
                                                  NativeMethods.EXECUTION_STATE.ES_AWAYMODE_REQUIRED);
        }

        public static void ResetSystemDefault()
        {
            NativeMethods.SetThreadExecutionState(NativeMethods.EXECUTION_STATE.ES_CONTINUOUS);
        }
    }

    internal static partial class NativeMethods
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

        [FlagsAttribute]
        public enum EXECUTION_STATE : uint
        {
            ES_AWAYMODE_REQUIRED = 0x00000040,
            ES_CONTINUOUS = 0x80000000,
            ES_DISPLAY_REQUIRED = 0x00000002,
            ES_SYSTEM_REQUIRED = 0x00000001

            // Legacy flag, should not be used.
            // ES_USER_PRESENT = 0x00000004
        }
    }
    class USBDeviceInfo
    {
        public USBDeviceInfo(string deviceID, string pnpDeviceID, string description)
        {
            this.DeviceID = deviceID;
            this.PnpDeviceID = pnpDeviceID;
            this.Description = description;
        }
        public string DeviceID { get; private set; }
        public string PnpDeviceID { get; private set; }
        public string Description { get; private set; }
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        //global variable
        static SerialPort mySerialPort;
        public static int blink = 0;
        public static int counter = 0;
        public static List<Station> stationlist = new List<Station>();
        public static string Latitude, Altitude, Longitude, RealTime, link,lastCity,NerCity, nextstation, direction, status, locatime,Speed,debug;
        public static int timestamp;
        public static Boolean stop;
        //end of global variable 
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetSystemTime(ref SYSTEMTIME st);
        public struct SYSTEMTIME
        {
            public short wYear;
            public short wMonth;
            public short wDayOfWeek;
            public short wDay;
            public short wHour;
            public short wMinute;
            public short wSecond;
            public short wMilliseconds;
        }
        [STAThread]
        static void Main()
        {
            PowerHelper.ForceSystemAwake();
            //Preparing GPS Device
            //var usbDevices = GetUSBDevices();
            string str = "";
            try
            {
                List<USBDeviceInfo> devices = new List<USBDeviceInfo>();
                ManagementObjectSearcher searcher =
                        new ManagementObjectSearcher("root\\CIMV2",
                        "SELECT * FROM Win32_PnPEntity");
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    devices.Add(new USBDeviceInfo(
                    (string)queryObj["DeviceID"],
                    (string)queryObj["PNPDeviceID"],
                    (string)queryObj["Name"]
                    ));
                }
                    foreach (USBDeviceInfo usbDevice in devices)
                {
                    if (usbDevice.Description != null)
                    {
                        if (usbDevice.Description.Contains("Prolific"))
                        {
                            int i = usbDevice.Description.IndexOf("COM");
                            char[] arr = usbDevice.Description.ToCharArray();
                            str = "COM" + arr[i + 3];
                            if (arr[i + 4] != ')')
                            {
                                str += arr[i + 4];
                            }
                            break;
                        }
                    }

                }

                mySerialPort = new SerialPort(str);
                mySerialPort.BaudRate = 4800;
                mySerialPort.Parity = Parity.None;
                mySerialPort.StopBits = StopBits.One;
                mySerialPort.DataBits = 8;
                mySerialPort.Close();
                mySerialPort.Open();
            }
            catch(Exception e)
            {
                int line = (new StackTrace(e, true)).GetFrame(0).GetFileLineNumber();
                MessageBox.Show(e.Message + "line:" + line);
            }

            string[] csvText = Properties.Resources.TheOcean.Split('\n');
                int ounter1 = 0;
                Waypoint middle = new Waypoint();
                Waypoint left = new Waypoint();
                Waypoint right = new Waypoint();
                string order1 = "";
                string order2 = "";

            foreach (string line in csvText)
            {
                if (ounter1 == 0)
                {
                    string[] values = line.Split(',');
                    left = new Waypoint() { name = values[0], lat = values[1], lng = values[2] };
                    ounter1++;
                }
                else if (ounter1 == 1)
                {
                    string[] values = line.Split(',');
                    middle = new Waypoint() { name = values[0], lat = values[1], lng = values[2] };
                    order1 = values[3];
                    order2 = values[4];
                    ounter1++;
                }
                else if (ounter1 == 2)
                {
                    string[] values = line.Split(',');
                    right = new Waypoint() { name = values[0], lat = values[1], lng = values[2] };
                    stationlist.Add(new Station() { middle = middle, left = left, right = right, order1 = order1, order2 = order2 });
                    ounter1 = 0;
                }
            }
                //end of preparing GPS Device
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());



        }
        public static void Convertion()
        {

                if (!Latitude.Equals(""))
                {
                    if (Latitude[0] == 'S')
                    {
                        Latitude = "-" + Latitude.Remove(0, 1);
                    }
                    else if (Latitude[0] == 'N')
                    {
                        Latitude = "+" + Latitude.Remove(0, 1);
                    }
                }
                if (!Longitude.Equals(""))
                {
                    if (Longitude[0] == 'W')
                    {
                        Longitude = "-" + Longitude.Remove(0, 1);
                    }
                    else if (Longitude[0] == 'E')
                    {
                        Longitude = "+" + Longitude.Remove(0, 1);
                    }
                }
        }
        public static void GPSTrack()
         {
            if (!mySerialPort.IsOpen)
            {
                while (!mySerialPort.IsOpen)
                {
                    try
                    {
                        mySerialPort.Close();
                        mySerialPort.Open();
                    }
                    catch (Exception er)
                    {
                    }
                }
            }
            int i = 0;
            while (i < 5)
            {
                i++;
                System.Threading.Thread.Sleep(200);
                if (mySerialPort.IsOpen)
                {
                    string data = mySerialPort.ReadExisting();
                    string[] strArr = data.Split('$');
                    for (int j = 0; j < strArr.Length; j++)
                    {
                        string strTemp = strArr[j];
                        debug = strTemp;
                        string[] lineArr = strTemp.Split(',');
                        if (lineArr[0] == "GPGGA")
                        {
                            try
                            {
                                //Latitude
                                if (lineArr.Length >= 6 && lineArr[2] != "")
                                {
                                    Double dLat = Convert.ToDouble(lineArr[2]);
                                    dLat = dLat / 100;
                                    string[] lat = dLat.ToString().Split('.');
                                    Latitude = lineArr[3].ToString() + lat[0].ToString() + "." + ((Convert.ToDouble(lat[1]) / 60)).ToString("#####");
                                    //Longitude
                                    Double dLon = Convert.ToDouble(lineArr[4]);
                                    dLon = dLon / 100;
                                    string[] lon = dLon.ToString().Split('.');
                                    Longitude = lineArr[5].ToString() + lon[0].ToString() + "." + ((Convert.ToDouble(lon[1]) / 60)).ToString("#####");
                                    //Time
                                    string timeMinAndSec = lineArr[1][0].ToString() + lineArr[1][1].ToString();
                                    //Altitude
                                    if (lineArr.Length >= 10)
                                    { 
                                        Altitude = lineArr[9].ToString();
                                    }
                                    Convertion();
                                    //debug message
                                    using (TextWriter tw = new StreamWriter(@"C:\Users\VIA RAIL\Desktop\log.txt", true))
                                    {

                                        string line = "localtime:" + locatime + "; time: " + timestamp + "; latitude:" + Latitude + "; Longitude:" + Longitude + "; gps:" + debug;
                                        tw.WriteLine(line);
                                    }
                                    //REMOVE AFTER DEV
                                    /*
                                    double calculus = Convert.ToDouble(timeMinAndSec) - heure;
                                    if (calculus < 0)
                                    {
                                        calculus += 24;
                                    }
                                    int k = timeMinAndSec.IndexOf(".");
                                    */
                                    RealTime = "UTC Time:" + DateTime.UtcNow.ToString("yyyy - MM - dd THH:mm:ss");
                                }
                            }
                            catch (Exception er)
                            {

                            }
                        }
                        else if ((lineArr[0] == "GPRMC"))
                        {
                            //Console.WriteLine(lineArr[9]);
                            //Console.WriteLine(lineArr[1]);
                            if (lineArr.Length >= 10)
                            {
                                if (lineArr[1] != "" && lineArr[9].Length >= 6)
                                {
                                    Console.WriteLine(lineArr[1][0]);
                                    short hour = (Int16)(Convert.ToInt16(lineArr[1][0].ToString()) * 10 + Convert.ToInt16(lineArr[1][1].ToString()));
                                    short minute = (Int16)(Convert.ToInt16(lineArr[1][2].ToString()) * 10 + Convert.ToInt16(lineArr[1][3].ToString()));
                                    short second = (Int16)(Convert.ToInt16(lineArr[1][4].ToString()) * 10 + Convert.ToInt16(lineArr[1][5].ToString()));
                                    short Day = (Int16)(Convert.ToInt16(lineArr[9][0].ToString()) * 10 + Convert.ToInt16(lineArr[9][1].ToString()));
                                    short Month = (Int16)(Convert.ToInt16(lineArr[9][2].ToString()) * 10 + Convert.ToInt16(lineArr[9][3].ToString()));
                                    short Year = (Int16)(2000 + Convert.ToInt16(lineArr[9][4].ToString()) * 10 + Convert.ToInt16(lineArr[9][5].ToString()));
                                    SYSTEMTIME st = new SYSTEMTIME();
                                    st.wYear = Year; // must be short
                                    st.wMonth = Month;
                                    st.wDay = Day;
                                    st.wHour = hour;
                                    st.wMinute = minute;
                                    st.wSecond = second;
                                    SetSystemTime(ref st); // invoke this method.
                                    RealTime = "UTC Time: " + DateTime.UtcNow.ToString("yyyy - MM - dd THH:mm:ss");
                                    //speed in knots
                                    if (lineArr[7] != "")
                                    { 
                                        double knots = Convert.ToDouble(lineArr[7].ToString());
                                        Speed = Convert.ToInt32(knots * 1.852).ToString();
                                    }
                                }
                            }

                        }
                    }
                }
            }
            i = 0;
        }
        static List<USBDeviceInfo> GetUSBDevices()
        {
            List<USBDeviceInfo> devices = new List<USBDeviceInfo>();
            ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_PnPEntity");
            foreach (ManagementObject queryObj in searcher.Get())
            {
                devices.Add(new USBDeviceInfo(
                (string)queryObj["DeviceID"],
                (string)queryObj["PNPDeviceID"],
                (string)queryObj["Name"]
                ));
            }       
            return devices;
        }
        public static double convertRad(double input)
        {
            return (Math.PI * input) / 180;
        }
        public static string GetTime(double lon_a_degre)
        {
            DateTime cstTime = DateTime.UtcNow;
            if (lon_a_degre <= -90 && lon_a_degre >= -110)
            {
                TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
                cstTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
                //UTC-6
            }
            else if (lon_a_degre <= -110)
            {
                TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("Mountain Standard Time");
                cstTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
                //UTC-7
            }
            else if (lon_a_degre >= -90 && lon_a_degre <= -66.9)
            {
                TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                cstTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
                //UTC-5
            }
            else if (lon_a_degre >= -66.9)
            {
                TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("Atlantic Standard Time");
                cstTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
                //UTc-4
            }
            else if (lon_a_degre <= -118.459)
            {
                TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
                cstTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
                //UTc-8
            }
            return cstTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
        public static double Distance(double lat_a_degre, double lon_a_degre, double lat_b_degre, double lon_b_degre)
        {
            int R = 6378000; //Rayon de la terre en mètre
            double lat_a = convertRad(lat_a_degre);
            double lon_a = convertRad(lon_a_degre);
            double lat_b = convertRad(lat_b_degre);
            double lon_b = convertRad(lon_b_degre);
            double d = R * (Math.PI / 2 - Math.Asin(Math.Sin(lat_b) * Math.Sin(lat_a) + Math.Cos(lon_b - lon_a) * Math.Cos(lat_b) * Math.Cos(lat_a)));
            return d;
        }

        public static void NearestCity()
        {
            //dev
            //string[] linesssss = File.ReadAllLines(@"C:\Users\Inno3\Desktop\station.txt");
            //prod
            string[] linesssss = File.ReadAllLines(@"C:\Users\VIA RAIL\Desktop\station.txt");
            if (linesssss.Length<3|| linesssss[0] == "" || linesssss[1] == "" || linesssss[2] == "")
            {
                DialogResult dialogResult = MessageBox.Show("Something wrong with system file, is this train onroute to Halifax?", "ERROR", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //prod
                    using (System.IO.StreamWriter sw = System.IO.File.CreateText(@"C:\Users\VIA RAIL\Desktop\station.txt"))
                    //dev
                    //using (System.IO.StreamWriter sw = System.IO.File.CreateText(@"C:\Users\Inno3\Desktop\station.txt"))
                    {
                        sw.WriteLine("St. LAMBERT");
                        sw.WriteLine(0);
                        sw.WriteLine(0);
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    //prod
                    using (System.IO.StreamWriter sw = System.IO.File.CreateText(@"C:\Users\VIA RAIL\Desktop\station.txt"))
                    //dev
                    //using (System.IO.StreamWriter sw = System.IO.File.CreateText(@"C:\Users\Inno3\Desktop\station.txt"))
                    {
                        sw.WriteLine("TRURO");
                        sw.WriteLine(1);
                        sw.WriteLine(0);
                    }
                }
            }

            if (Convert.ToDouble(Longitude) == 0 || Convert.ToDouble(Latitude) == 0 || Convert.ToDouble(Longitude) >= -61 || Convert.ToDouble(Latitude) <= 42 || Convert.ToDouble(Latitude) >= 60)
            {
                link = "blank";
                NerCity = Form1.rm.GetString("nogps");
            }
            else
            {
                //prod
                linesssss = File.ReadAllLines(@"C:\Users\VIA RAIL\Desktop\station.txt");
                //dev
                //linesssss = File.ReadAllLines(@"C:\Users\Inno3\Desktop\station.txt");
                link = "blank";
                nextstation = linesssss[0];
                direction = linesssss[1];
                timestamp = Convert.ToInt32(linesssss[2]);
                stop = false;

                if (timestamp != 0)
                {
                    timestamp--;
                }
                else
                {
                    if (direction == "1")
                    {
                        foreach (Station stations in Program.stationlist.AsEnumerable().Reverse())
                        {
                            if (stop == true)
                            {
                                if (blink == 1)
                                {
                                    link = "w" + stations.order2;
                                    blink = 0;
                                }
                                else
                                {
                                    link = "w" + stations.order2+"f";
                                    blink++;
                                }
                                NerCity = stations.middle.name;
                                //label1.Invoke(t => t.Text = "Next Station: " + stations.middle.name);
                                nextstation = stations.middle.name;
                                status = "Enroute to";
                                break;
                            }
                            if (nextstation == stations.middle.name)
                            {
                                if (Distance(Convert.ToDouble(stations.right.lat), Convert.ToDouble(stations.right.lng), Convert.ToDouble(Latitude), Convert.ToDouble(Longitude)) < Distance(Convert.ToDouble(stations.left.lat), Convert.ToDouble(stations.left.lng), Convert.ToDouble(Latitude), Convert.ToDouble(Longitude)))
                                {
                                    if (Distance(Convert.ToDouble(stations.right.lat), Convert.ToDouble(stations.right.lng), Convert.ToDouble(Latitude), Convert.ToDouble(Longitude)) < 2000)
                                    {
                                        if (stations.middle.name == "MONTREAL")
                                        {
                                            if (blink == 1)
                                            {
                                                link = "w" + stations.order2;
                                                blink = 0;
                                            }
                                            else
                                            {
                                                link = "w" + stations.order2+"f";
                                                blink++;
                                            }
                                            NerCity = stations.middle.name;
                                            //label1.Invoke(t => t.Text = "Next Station: " + stations.middle.name);
                                            nextstation = stations.middle.name;
                                            status = "Arriving at final stop";
                                            direction = "0";
                                            timestamp = 5000;
                                        }
                                        else
                                        {
                                            if (blink == 1)
                                            {
                                                link = "w" + stations.order2;
                                                blink = 0;
                                            }
                                            else
                                            {
                                                link = "w" + stations.order2 + "f";
                                                blink++;
                                            }
                                            NerCity = stations.middle.name;
                                            //label1.Invoke(t => t.Text = "Next Station: " + stations.middle.name);
                                            nextstation = stations.middle.name;
                                            status = "Arriving at";
                                        }
                                        counter = 0;

                                        break;
                                    }
                                    else
                                    {
                                        if (blink == 1)
                                        {
                                            link = "w" + stations.order2;
                                            blink = 0;
                                        }
                                        else
                                        {
                                            link = "w" + stations.order2 + "f";
                                            blink++;
                                        }
                                        NerCity = stations.middle.name;
                                        //label1.Invoke(t => t.Text = "Next Station: " + stations.middle.name);
                                        nextstation = stations.middle.name;
                                        status = "Enroute to";
                                        counter = 0;

                                        break;
                                    }
                                }
                                else if (Distance(Convert.ToDouble(stations.right.lat), Convert.ToDouble(stations.right.lng), Convert.ToDouble(Latitude), Convert.ToDouble(Longitude)) > Distance(Convert.ToDouble(stations.left.lat), Convert.ToDouble(stations.left.lng), Convert.ToDouble(Latitude), Convert.ToDouble(Longitude)))
                                {
                                    counter++;
                                    if (counter >= 20)
                                    {
                                        stop = true;
                                        counter = 0;
                                    }
                                }
                            }

                        }
                    }
                    else
                    {
                        foreach (Station stations in Program.stationlist)
                        {
                            if (stop == true)
                            {
                                if (blink == 1)
                                {
                                    link = "e" + stations.order1;
                                    blink = 0;
                                }
                                else
                                {
                                    link = "e" + stations.order1 +"f";
                                    blink++;
                                }
                                NerCity = stations.middle.name;
                                //label1.Invoke(t => t.Text = "Next Station: " + stations.middle.name);
                                nextstation = stations.middle.name;
                                status = "Enroute to";
                                counter = 0;
                                break;
                            }
                            if (nextstation == stations.middle.name)
                            {
                                if (Distance(Convert.ToDouble(stations.right.lat), Convert.ToDouble(stations.right.lng), Convert.ToDouble(Latitude), Convert.ToDouble(Longitude)) > Distance(Convert.ToDouble(stations.left.lat), Convert.ToDouble(stations.left.lng), Convert.ToDouble(Latitude), Convert.ToDouble(Longitude)))
                                {
                                    if (Distance(Convert.ToDouble(stations.right.lat), Convert.ToDouble(stations.right.lng), Convert.ToDouble(Latitude), Convert.ToDouble(Longitude)) < 2000)
                                    {
                                        if (stations.middle.name == "HALIFAX")
                                        {
                                            if (blink == 1)
                                            {
                                                link = "e" + stations.order1;
                                                blink = 0;
                                            }
                                            else
                                            {
                                                link = "e" + stations.order1 + "f";
                                                blink++;
                                            }
                                            NerCity = stations.middle.name;
                                            //label1.Invoke(t => t.Text = "Next Station: " + stations.middle.name);
                                            nextstation = stations.middle.name;
                                            status = "Arriving at final stop";
                                            direction = "1";
                                            timestamp = 5000;
                                        }
                                        else
                                        {
                                            if (blink == 1)
                                            {
                                                link = "e" + stations.order1;
                                                blink = 0;
                                            }
                                            else
                                            {
                                                link = "e" + stations.order1 + "f";
                                                blink++;
                                            }
                                            NerCity = stations.middle.name;
                                            //label1.Invoke(t => t.Text = "Next Station: " + stations.middle.name);
                                            nextstation = stations.middle.name;
                                            status = "Arriving at";
                                            counter = 0;

                                            break;
                                        }
                                    }
                                    else
                                    {
                                        if (blink == 1)
                                        {
                                            link = "e" + stations.order1;
                                            blink = 0;
                                        }
                                        else
                                        {
                                            link = "e" + stations.order1 + "f";
                                            blink++;
                                        }
                                        NerCity = stations.middle.name;
                                        //label1.Invoke(t => t.Text = "Next Station: " + stations.middle.name);
                                        nextstation = stations.middle.name;
                                        status = "Enroute to";
                                        counter = 0;
                                        break;
                                    }
                                }
                                else if (Distance(Convert.ToDouble(stations.right.lat), Convert.ToDouble(stations.right.lng), Convert.ToDouble(Latitude), Convert.ToDouble(Longitude)) < Distance(Convert.ToDouble(stations.left.lat), Convert.ToDouble(stations.left.lng), Convert.ToDouble(Latitude), Convert.ToDouble(Longitude)))
                                {
                                    counter++;
                                    if (counter >= 20)
                                    {
                                        stop = true;
                                        counter = 0;
                                    }
                                }
                            }

                        }
                    }
                }
                locatime = GetTime(Convert.ToDouble(Longitude));
                string lines = GetTime(Convert.ToDouble(Longitude));
                //prod
                using (System.IO.StreamWriter sw = System.IO.File.CreateText(@"C:\Users\VIA RAIL\Desktop\test.txt"))
                //dev
                //using (System.IO.StreamWriter sw = System.IO.File.CreateText(@"C:\Users\Inno3\Desktop\test.txt"))
                {
                    sw.WriteLine(lines);
                    sw.WriteLine(NerCity);
                    sw.WriteLine(link);
                    sw.WriteLine(Program.Altitude);
                }



                //prod
                using (System.IO.StreamWriter sw = System.IO.File.CreateText(@"C:\Users\VIA RAIL\Desktop\station.txt"))
                //dev
                //using (System.IO.StreamWriter sw = System.IO.File.CreateText(@"C:\Users\Inno3\Desktop\station.txt"))
                {
                    sw.WriteLine(nextstation);
                    sw.WriteLine(direction);
                    sw.WriteLine(timestamp);
                }
            }


        }
    }
}
