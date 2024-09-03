using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    private PlayerInput playerInput;

    public InputAction MouseLeftClick { get; private set; }
    public InputAction MouseRightClick { get; private set; }
    public InputAction Move { get; private set; }

    private void Awake()
    {
        playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        MouseLeftClick = playerInput.PlayerActions.Select;
        MouseRightClick = playerInput.PlayerActions.Cancel;
        Move = playerInput.PlayerActions.Move;

        MouseLeftClick.Enable();
        MouseRightClick.Enable();
        Move.Enable();
    }

    private void OnDisable()
    {
        MouseLeftClick.Disable();
        MouseRightClick.Disable();
        Move.Disable();
    }
}
