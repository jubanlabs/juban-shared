using Jubanlabs.JubanShared.Logging;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jubanlabs.JubanShared.Common.Test
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Jubanlabs.JubanShared.Common.Config;


    [TestClass]
    public class TestCommon 
    {
        private static readonly ILogger<TestCommon> Logger =  JubanLogger.GetLogger<TestCommon>();

        public TestCommon()
        {
           
            Environment.SetEnvironmentVariable("JUBAN_CONFIG", @"{
                    'key-to-be-override-env':'overrided-env',
                    'hello-testing':'word-testing'
                }".Replace("'", "\"", StringComparison.Ordinal));
            var path = Path.GetFullPath(Path.Combine(System.AppContext.BaseDirectory, "../../../extra_config_test"));

            Environment.SetEnvironmentVariable("JUBAN_EXTRA_CONFIG_FOLDER", path);
            
        }

        [TestMethod]
        public void TestAppConfig()
        {
            Assert.AreEqual("world", AppSettings.Instance.GetValue("hello"));
            Assert.IsNull(AppSettings.Instance.GetValue("invalidkey"));
            Assert.AreEqual("overrided", AppSettings.Instance.GetValue("hello-to-be-override"));
            Assert.AreEqual("word-testing", AppSettings.Instance.GetValue("hello-testing"));
            Assert.AreEqual("overrided-env", AppSettings.Instance.GetValue("key-to-be-override-env"));
            Assert.AreEqual("overrided-extra-folder", AppSettings.Instance.GetValue("key-to-be-override-extra-folder"));
            Logger.LogTrace("test logger");
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
    }
}