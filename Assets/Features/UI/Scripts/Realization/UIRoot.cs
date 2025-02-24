using Features.UI.Scripts.Interfaces;
using UnityEngine;

namespace Features.UI.Scripts.Realization
{
    public class UIRoot : MonoBehaviour, IUIRoot
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private Camera camera;
        [SerializeField] private Transform container;
        [SerializeField] private Transform poolContainer;

        public Canvas Canvas
        {
            get => canvas;
            set => canvas = value;
        }

        public Camera Camera => camera;

        public Transform Container => container;

        public Transform PoolContainer => poolContainer;
    }
}