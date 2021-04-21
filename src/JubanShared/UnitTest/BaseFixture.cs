namespace Jubanlabs.JubanShared.UnitTest
{
    using System;
    using Jubanlabs.JubanShared.Common;

    public class BaseFixture : IDisposable
    {
        public BaseFixture()
        {
            Environment.SetEnvironmentVariable("JUBAN_ENVIRONMENT_NAME", "testing");
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
        }
    }
}