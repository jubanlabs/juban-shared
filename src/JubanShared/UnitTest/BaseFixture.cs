namespace Jubanlabs.JubanShared.UnitTest
{
    using System;
    using Jubanlabs.JubanShared.Common;

    public class BaseFixture : IDisposable
    {
        public BaseFixture()
        {
            AppSession.Instance.SetEnvironmentName( "testing");
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