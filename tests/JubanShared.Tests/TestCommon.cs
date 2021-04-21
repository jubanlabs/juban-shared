namespace Jubanlabs.JubanShared.Common.Test
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Jubanlabs.JubanShared.Common.Config;
    using Jubanlabs.JubanShared.UnitTest;
    using Xunit;
    using Xunit.Abstractions;

    public class TestCommon : IClassFixture<BaseFixture>
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public TestCommon(ITestOutputHelper outputHelper)
        {
            LoggingHelper.BindNLog(outputHelper);
            Environment.SetEnvironmentVariable("JUBAN_CONFIG", @"{
                    'key-to-be-override-env':'overrided-env',
                    'hello-testing':'word-testing'
                }".Replace("'", "\"", StringComparison.Ordinal));
            var path = Path.GetFullPath(Path.Combine(System.AppContext.BaseDirectory, "../../../extra_config_test"));

            Environment.SetEnvironmentVariable("JUBAN_EXTRA_CONFIG_FOLDER", path);
            
        }

        [Fact]
        public void TestAppConfig()
        {
            Assert.Equal("world", AppSettings.Instance.GetValue("hello"));
            Assert.Null(AppSettings.Instance.GetValue("invalidkey"));
            Assert.Equal("overrided", AppSettings.Instance.GetValue("hello-to-be-override"));
            Assert.Equal("word-testing", AppSettings.Instance.GetValue("hello-testing"));
            Assert.Equal("overrided-env", AppSettings.Instance.GetValue("key-to-be-override-env"));
            Assert.Equal("overrided-extra-folder", AppSettings.Instance.GetValue("key-to-be-override-extra-folder"));
            Logger.ConditionalTrace("test logger");
        }

        // [Fact]
        // public void TestTransformEnvironmentVariables()
        // {
        //     Dictionary<string, string> dict = new Dictionary<string, string>();
        //     var newDict = TransformEnvironmentVariables.Load(dict);
        //     Assert.Equal("testing", newDict["JUBAN_ENVIRONMENT_NAME"]);

        //     dict["JUBAN_ENVIRONMENT_NAME"] = "staging";
        //     newDict = TransformEnvironmentVariables.Load(dict);
        //     Assert.NotEqual("testing", newDict["JUBAN_ENVIRONMENT_NAME"]);
        // }

        [Fact]
        public void TestConditionalStopwatch()
        {
            ConditionalStopwatch.PunchIn("t1", "message");
            ConditionalStopwatch.PunchOutAndIn("t1");
            ConditionalStopwatch.PunchOut("t1");
            ConditionalStopwatch.PunchOut("t1");
        }

        [Fact]
        public void TestCommonHelper()
        {
            var commonHelper = new CommonHelper();
            Assert.True(commonHelper.GetHash("abc") > 0);

            Assert.Equal("abc", CommonHelper.UncompressSmallString(CommonHelper.CompressSmallString("abc")));
        }

        [Fact]
        public void TestStripeHostname()
        {
            Assert.Equal("ab", AppSession.StripHostName("ab.cd.ef"));
            Assert.Equal("ab", AppSession.StripHostName("ab.cd"));
            Assert.Equal("ab", AppSession.StripHostName("ab"));
        }
    }
}