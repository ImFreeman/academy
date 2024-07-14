using System.Collections.Generic;
using Features.Core.Actor.Scripts.Interfaces;

namespace Features.Enemy.Scripts.Realization
{
    public class ActorStorage : IActorStorage
    {
        private readonly Dictionary<int, IActor> _dictionary = new Dictionary<int, IActor>();

        public IReadOnlyDictionary<int, IActor> Actors => _dictionary;

        public void Add(IActor actor)
        {
            _dictionary.TryAdd(actor.GetID(), actor);
        }

        public void Remove(int id)
        {
            if (_dictionary.TryGetValue(id, out var enemy))
            {
                enemy.Dispose();
                _dictionary.Remove(id);
            }
        }

        public void Clear()
        {
            foreach (var value in _dictionary.Values)
            {
                value.Dispose();
            }
            _dictionary.Clear();
        }
    }
}