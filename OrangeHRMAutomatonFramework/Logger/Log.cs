using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace OrangeHRMAutomatonFramework.Logger
{
    public class Log
    {
        public static ExtentReports extent;
        public static string reportsDirectory = ConfigurationManager.AppSettings["ReportsDirectory"] + DateTime.Now.ToString("_MMddyyyyhhmmtt") + @"\";
        private static ExtentTest currentTest;
        public static void Initialize()
        {
            extent = new ExtentReports();
            var htmlreporter = new ExtentHtmlReporter(reportsDirectory);
            extent.AttachReporter(htmlreporter);
        }

        public static void Flush()
        {
            extent.Flush();
        }

        public static void CreateTest(string testNumber, string testDescription)
        {
            currentTest = extent.CreateTest(testNumber, testDescription);
        }

        public static MediaEntityModelProvider ScreenShotFromPath(string path)
        {
            return MediaEntityBuilder.CreateScreenCaptureFromPath(path).Build();
        }

        public static void Info(string message)
        {
            currentTest.Info(message);
        }

        public static void Info(string message, string path)
        {
            currentTest.Info(message, ScreenShotFromPath(path));
        }

        public static void Warn(string message)
        {
            currentTest.Warning(message);
        }
        public static void Warn(string message, string path)
        {
            currentTest.Warning(message, ScreenShotFromPath(path));
        }

        public static void Error(string message)
        {
            currentTest.Error(message);
        }

        public static void Error(string message, string path)
        {
            currentTest.Error(message, ScreenShotFromPath(path));
        }

        public static void Pass(string message)
        {
            currentTest.Pass(message);
        }

        public static void Pass(string message, string path)
        {
            currentTest.Pass(message, ScreenShotFromPath(path));
        }

        public static void Fail(string message)
        {
            currentTest.Fail(message);
        }

        public static void Fail(string message, string path)
        {
            currentTest.Fail(message, ScreenShotFromPath(path));
        }

        public static void Fail(Exception e)
        {
            currentTest.Fail(e);
        }

        public static void Fail(Exception e, string path)
        {
            currentTest.Fail(e, ScreenShotFromPath(path));
        }

        public static void AddScreenCaptureFromPath(string path)
        {
            currentTest.AddScreenCaptureFromPath(path);
        }

        public static void AddScreenCaptureFromBase64String(string base64String)
        {
            currentTest.AddScreenCaptureFromBase64String(base64String);
        }
    }
}
