using System;
using Features.Core.UpdateManager;
using UnityEngine;

public class InputHandler : IUpdatable
{
    public event EventHandler<Vector2> KeyboardInputEvent;  
    public event EventHandler<Vector2> MouseInputEvent;  
    public event EventHandler<IUpdatable> Destroyed;
    public void Update()
    {
        KeyboardInputEvent?.Invoke(this, new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) );
        MouseInputEvent?.Invoke(this, new Vector2(Input.GetAxis ("Mouse X"), Input.GetAxis ("Mouse Y")));
    }
        
    public void Dispose()
    {
        Destroyed?.Invoke(this, this);
    }
}