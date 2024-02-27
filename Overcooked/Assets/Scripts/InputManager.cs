using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour//Controls.IPlayerActions
{
    public Vector2 moveInput;
    public bool interactPress = false;
    public bool boostPress = false;

    public float verticalInput;

    public float horizontalInput;
    /*CharacterController controller;
    public float playerSpeed = 1.0f;
    private Vector3 playerVelocity;

    public Action OnInteractPerformed;*/

    private Controls controls;//Referencing the autogenerated script from input Actions

    private void OnEnable()//called when the player is enabled and called once after Awake (When the game starts)
    {
        if (controls == null)//If controls is not enabled
        {
            controls = new Controls();
            controls.Player.Move.performed += i => moveInput = i.ReadValue<Vector2>();
            if (interactPress == false)
            {
                controls.Player.Interact.performed += i => interactPress = true;
            }
            if (boostPress == false)
            {
                controls.Player.Boost.performed += i => boostPress = true;
            }

            //^^Whenever an input is performed it is recorded into the Vector2
        }

        controls.Enable();
    }

    public void OnDisable()//called when player is disabled
    {
        controls.Player.Disable();
    }

    public void AllMovement()
    {
        MovementInput();
        //Add boost eventually
    }
    
    private void MovementInput()
    {
        verticalInput = moveInput.y;//breaks down the vector 2 from inputs and assigns to vars
        horizontalInput = moveInput.x;
        
    }
    /*//Input system is event based
    //Functions are automatically generated from inputActions created in Unity
    //The context parameter contains the actual input value
    public void OnMove(InputAction.CallbackContext context)
    {
        MoveComposite = context.ReadValue<Vector2>();
        Vector3 move = new Vector3(MoveComposite.x, 0, MoveComposite.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (!context.performed)
        {
            return; //Returns early so it is not called again on spacebar release
        }

        OnInteractPerformed?.Invoke();
    }*/
    
}
