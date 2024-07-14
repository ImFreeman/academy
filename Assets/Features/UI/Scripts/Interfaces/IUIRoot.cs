using UnityEngine;

namespace Features.UI.Scripts.Interfaces
{
    public interface IUIRoot
    {
        Canvas Canvas { get; set; }
        Camera Camera { get; }
        Transform Container { get; }
        Transform PoolContainer { get; }
    }
}