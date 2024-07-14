using System;
using Features.UI.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Features.UI.UIMainMenu.Scripts
{
    public class UIMainWindow : UIWindow
    {
        [SerializeField] private Button _playButton;

        public event EventHandler PlayButtonPressed;

        public override void Show()
        {
            base.Show();
            
            _playButton.onClick.AddListener(OnPlayButtonPressed);
        }

        private void OnPlayButtonPressed()
        {
            PlayButtonPressed?.Invoke(this, EventArgs.Empty);
        }

        public override void Hide()
        {
            base.Hide();
            _playButton.onClick.RemoveListener(OnPlayButtonPressed);
        }
    }
}