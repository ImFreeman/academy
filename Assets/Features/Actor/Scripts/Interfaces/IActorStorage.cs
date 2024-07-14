using System.Collections.Generic;

namespace Features.Core.Actor.Scripts.Interfaces
{
    public interface IActorStorage
    {
        public IReadOnlyDictionary<int, IActor> Actors { get; }
        public void Add(IActor actor);
        public void Remove(int id);
        public void Clear();
    }
}