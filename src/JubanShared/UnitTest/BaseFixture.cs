namespace Jubanlabs.JubanShared.UnitTest
{
    using System;

    public class BaseFixture : IDisposable
    {
        public BaseFixture()
        {
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