namespace Jubanlabs.JubanShared.UnitTest
{
    using Jubanlabs.JubanShared.Common;
    using NLog;
    using NLog.Targets;
    using Xunit.Abstractions;

    [Target("XUnit")]
    public sealed class XUnitTarget : TargetWithLayout
    {
        private readonly ITestOutputHelper output;

        public XUnitTarget(ITestOutputHelper testOutputHelper)
        {
            this.output = testOutputHelper;
        }

        protected override void Write(LogEventInfo logEvent)
        {
            string logMessage = this.Layout.Render(logEvent);

            this.output.WriteLine(AppSession.Instance.ProcessInfo + " - " + logMessage);
        }
    }
}