using System;
using UnityEngine;

namespace Features.UI.Scripts
{
    public class UIWindow : MonoBehaviour
    {
        [SerializeField] private RectTransform rectTransform;
        public event EventHandler ShowEvent;
        public event EventHandler HideEvent;

        public virtual void Show()
        {        
            gameObject.SetActive(true);
            ShowEvent?.Invoke(this, EventArgs.Empty);
        }

        public virtual void Hide()
        {
            HideEvent?.Invoke(this, EventArgs.Empty);
            gameObject.SetActive(false);
        }        

        public void SetNewParent(RectTransform parent)
        {
            rectTransform.parent = parent;
            rectTransform.position = parent.position;
            rectTransform.localScale = new Vector3(1, 1, 1);
            rectTransform.offsetMin = new Vector2(0, 0);
            rectTransform.offsetMax = new Vector2(0, 0);
            rectTransform.rotation = new Quaternion(0, 0, 0, 0);
        }    
    }
}