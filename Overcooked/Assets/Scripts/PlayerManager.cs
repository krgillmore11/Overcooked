using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private InputManager inputManager;
    private PlayerMovement playerMovement;
    private Vector3 spawn;
    

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerMovement = GetComponent<PlayerMovement>();
        spawn = gameObject.transform.position;
    }

    private void Update()//called every frame
    {
        inputManager.AllMovement();
    }

    private void FixedUpdate()//rbs work better under fixed update
    {
        playerMovement.AllMovement();
    }

    public void Respawn()
    {
        Debug.Log("hit respawn move code");
        transform.position = spawn;
    }
    
}
