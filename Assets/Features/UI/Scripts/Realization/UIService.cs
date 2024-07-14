using System;
using System.Collections.Generic;
using Features.UI.Scripts.Interfaces;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Features.UI.Scripts.Realization
{
    public class UIService : IUIService
    {
        private readonly IUIRoot _uIRoot;
        private Transform _deactivatedContainer;
        private readonly Dictionary<Type, UIWindow> _viewStorage = new Dictionary<Type, UIWindow>();
        private readonly Dictionary<Type, GameObject> _initWindows = new Dictionary<Type, GameObject>();
        private bool _initialized = false;

        public UIService(IUIRoot uIRoot)
        {
            _uIRoot = uIRoot;                        
        }

        private void Init()
        {
            LoadWindows();
            var container = new GameObject("DeactivatedWindows");
            var containerRect = container.AddComponent<RectTransform>();
            containerRect.SetParent(_uIRoot.Container);
            containerRect.localScale = Vector3.one;
            containerRect.anchorMin = Vector2.zero;
            containerRect.anchorMax = Vector2.one;
            containerRect.pivot = new Vector2(0.5f, 0.5f);
            containerRect.offsetMin = Vector2.zero;
            containerRect.offsetMax = Vector2.zero;

            container.gameObject.SetActive(false);

            InitWindows(containerRect);
            _initialized = true;
        }

        public T Show<T>() where T : UIWindow
        {
            if(!_initialized)
            {
                Init();
            }
            var window = Get<T>();
            if (window != null)
            {
                window.transform.SetParent(_uIRoot.Container);
                window.Show();
                return window;
            }
            return null;
        }

        public T Get<T>() where T : UIWindow
        {
            if (!_initialized)
            {
                Init();
            }
            var type = typeof(T);
            if (_initWindows.ContainsKey(type))
            {
                var view = _initWindows[type];
                return view.GetComponent<T>();
            }
            return null;
        }

        public void Hide<T>() where T : UIWindow
        {
            if (!_initialized)
            {
                Init();
            }
            var window = Get<T>();
            if (window != null)
            {
                window.Hide();
            }
        }

        public void InitWindows(Transform poolDeactiveContiner = null)
        {
            _deactivatedContainer = poolDeactiveContiner == null ? _uIRoot.PoolContainer : poolDeactiveContiner;
            foreach (var windowKVP in _viewStorage)
            {
                Init(windowKVP.Key, _deactivatedContainer);
            }
        }

        public void LoadWindows()
        {
            var windows = Resources.LoadAll("", typeof(UIWindow));

            foreach (var window in windows)
            {
                var windowType = window.GetType();
                _viewStorage.Add(windowType, (UIWindow)window);
            }
        }

        private void Init(Type t, Transform parent = null)
        {
            if (_viewStorage.ContainsKey(t))
            {
                UIWindow view = null;
                if (parent != null)
                {
                    view = Object.Instantiate(_viewStorage[t], parent);
                }
                else
                {
                    view = Object.Instantiate(_viewStorage[t]);
                }
                _initWindows.Add(t, view.gameObject);
            }
        }
    }
}