using Features.UI.Scripts;
using UnityEngine;

public interface IUIService
{
    
    T Show<T>() where T : UIWindow;

    
    void Hide<T>() where T : UIWindow;
    
    T Get<T>() where T : UIWindow;

    void InitWindows(Transform poolDeactiveContiner = null);
    void LoadWindows();
}