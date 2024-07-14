using System;

namespace Features.Core.UpdateManager
{
    public interface IUpdatable : IDisposable
    {
        public event EventHandler<IUpdatable> Destroyed;

        public void Update();
    }
}