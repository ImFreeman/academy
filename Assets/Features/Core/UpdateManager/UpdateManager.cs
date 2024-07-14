using System.Collections.Generic;
using UnityEngine;

namespace Features.Core.UpdateManager
{
    public class UpdateManager : MonoBehaviour, IUpdateManager
    {
        private IList<IUpdatable> _list;

        private void Awake()
        {
            _list = new List<IUpdatable>();
        }

        public void Add(IUpdatable updatable)
        {
            _list.Add(updatable);
            updatable.Destroyed += OnDestroyed;
        }

        public void Remove(IUpdatable updatable)
        {
            updatable.Destroyed -= OnDestroyed;
            _list.Remove(updatable);
        }

        private void Update()
        {
            foreach (IUpdatable updatable in _list)
            {
                updatable.Update();
            }
        }

        private void OnDestroyed(object sender, IUpdatable e)
        {
            Remove(e);
        }

        private void OnDestroy()
        {
            foreach (IUpdatable updatable in _list)
            {
                updatable.Destroyed -= OnDestroyed;
            }
            _list.Clear();
        }
    }
}