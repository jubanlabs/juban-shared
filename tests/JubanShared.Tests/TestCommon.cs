using Jubanlabs.JubanShared.Logging;
using JubanShared;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jubanlabs.JubanShared.Common.Test
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Jubanlabs.JubanShared.Common.Config;


    [TestClass]
    public class TestCommon :JubanTestBase
    {
        private static readonly ILogger<TestCommon> Logger =  JubanLogger.GetLogger<TestCommon>();

        [TestMethod]
        public void TestAppConfig()
        {
            Assert.AreEqual("world", AppSettings.Instance.GetValue("hello"));
            Assert.IsNull(AppSettings.Instance.GetValue("invalidkey"));
            Assert.AreEqual("overrided", AppSettings.Instance.GetValue("hello-to-be-override"));
            Assert.AreEqual("word-testing", AppSettings.Instance.GetValue("hello-testing"));
            
            Logger.LogTrace("test logger");
        }
        
        [TestMethod]
        public void TestAppConfigEnvVarOverride()
        {
            
            Environment.SetEnvironmentVariable("key-to-be-override-env", "overrided-env");
            //recreate the host to validate if the config get override by env. var.
            Host.CreateDefaultBuilder()
                .ConfigureLogging((hostContext, loggingBuilder) => { loggingBuilder.AddConsole().AddDebug().SetMinimumLevel(LogLevel.Trace); })
                .Build().JubanWireUp();
            Assert.AreEqual("overrided-env", AppSettings.Instance.GetValue("key-to-be-override-env"));
            
        }

        // [TestMethod]
        // public void TestTransformEnvironmentVariables()
        // {
        //     Dictionary<string, string> dict = new Dictionary<string, string>();
        //     var newDict = TransformEnvironmentVariables.Load(dict);
        //     Assert.AreEqual("testing", newDict["JUBAN_ENVIRONMENT_NAME"]);

        //     dict["JUBAN_ENVIRONMENT_NAME"] = "staging";
        //     newDict = TransformEnvironmentVariables.Load(dict);
        //     Assert.NotEqual("testing", newDict["JUBAN_ENVIRONMENT_NAME"]);
        // }

        [TestMethod]
        public void TestConditionalStopwatch()
        {
            ConditionalStopwatch.PunchIn("t1", "message");
            ConditionalStopwatch.PunchOutAndIn("t1");
            ConditionalStopwatch.PunchOut("t1");
            ConditionalStopwatch.PunchOut("t1");
        }

        [TestMethod]
        public void TestCommonHelper()
        {
            var commonHelper = new CommonHelper();
            Assert.IsTrue(commonHelper.GetHash("abc") > 0);

            Assert.AreEqual("abc", CommonHelper.UncompressSmallString(CommonHelper.CompressSmallString("abc")));
        }

        [TestMethod]
        public void TestStripeHostname()
        {
            Assert.AreEqual("ab", AppSession.StripHostName("ab.cd.ef"));
            Assert.AreEqual("ab", AppSession.StripHostName("ab.cd"));
            Assert.AreEqual("ab", AppSession.StripHostName("ab"));
        }

        [TestMethod]
        public void TestLog()
        {
            //ILoggerFactory loggerFactory =
             //   LoggerFactory.Create(builder => builder.AddConsole().AddDebug().SetMinimumLevel(LogLevel.Trace));
            //JubanLogger.SetLoggerFactory(loggerFactory);
           
            Logger.LogInformation("log info");
        }
    }
}