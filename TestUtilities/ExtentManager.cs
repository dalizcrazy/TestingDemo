using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;
using System.Threading;

namespace TestUtilities
{
    public static class ExtentManager
    {
        private static readonly Lazy<AventStack.ExtentReports.ExtentReports> _lazyReporter = new Lazy<AventStack.ExtentReports.ExtentReports>(CreateReporter);
        private static readonly ThreadLocal<ExtentTest> _currentTest = new ThreadLocal<ExtentTest>();

        public static AventStack.ExtentReports.ExtentReports Instance => _lazyReporter.Value;

        private static AventStack.ExtentReports.ExtentReports CreateReporter()
        {
            string baseDir = AppContext.BaseDirectory;
            var solutionRoot = Directory.GetParent(baseDir).Parent.Parent.Parent.FullName;
            string reportsDir = Path.Combine(solutionRoot, "Reports");
            if (!Directory.Exists(reportsDir))
                Directory.CreateDirectory(reportsDir);

            string htmlPath = Path.Combine(reportsDir, "CombinedReport.html");

            var htmlReporter = new ExtentHtmlReporter(htmlPath);
            htmlReporter.Config.DocumentTitle = "Combined Test Report";
            htmlReporter.Config.ReportName = "UI + API Combined Tests";
            var extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("OS", Environment.OSVersion.ToString());
            extent.AddSystemInfo("Machine", Environment.MachineName);
            extent.AddSystemInfo("Environment", "QA-Demo");

            return extent;
        }

        public static ExtentTest CreateTest(string testName, string description = "")
        {
            var test = Instance.CreateTest(testName, description);
            _currentTest.Value = test;
            return test;
        }

        public static ExtentTest GetTest() => _currentTest.Value;

        public static void Flush()
        {
            try { Instance.Flush(); } catch (Exception) { }
        }
    }
}