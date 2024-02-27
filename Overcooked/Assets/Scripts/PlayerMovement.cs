using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 moveDirection;
    private Transform cameraObject;
    private Rigidbody playerRB;
    private bool allowBoost = true;
    
    [SerializeField] float speed = 1.0f;
    [SerializeField] float rotateSpeed = 1.0f;

    private InputManager inputManager;

    private void Awake()//called before start
    {
        inputManager = GetComponent<InputManager>();//gets from player input manager
        playerRB = GetComponent <Rigidbody>();
        cameraObject = Camera.main.transform;//gets main Camera (default camera)
    }
    
    public void AllMovement()
    {
        Movement();
        Rotation();
    }
    
    private void Movement()
    {
        
        if (inputManager.boostPress == true && allowBoost)
        {
            inputManager.boostPress = false;
            allowBoost = false;
            StartCoroutine(setBoost());
        }

        moveDirection = cameraObject.forward * inputManager.verticalInput;//Move in the direction camera is facing
        moveDirection = moveDirection + cameraObject.right * inputManager.horizontalInput;//^^
        moveDirection.Normalize();//Takes a vector and kepps the direction the same but changes the length to 1 for concistency
        moveDirection.y = 0;  //Keeps the player grounded
        moveDirection = moveDirection * speed;//allows changes to speed from unity

        Vector3 movementVelocity = moveDirection;
        playerRB.velocity = movementVelocity;//moves the playerRB based on the inputs calcs
        

        
    }

  IEnumerator setBoost()
    {
        speed *= 3;
        yield return new WaitForSeconds(0.2f);
        speed /= 3;
        yield return new WaitForSeconds(0.8f);
        allowBoost = true;

    }

    private void Rotation()
    {
        //{Same as Movement() but applies to the players rotation
        Vector3 targetDirection = Vector3.zero;//Takes initial direction of player
        
        
        targetDirection = cameraObject.forward * inputManager.verticalInput;
        targetDirection = targetDirection + cameraObject.right * inputManager.horizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0;//}

        if (targetDirection == Vector3.zero)
        {
            targetDirection = transform.forward;//keeps rotation from when the player stopped
        }
        //Qauternions are to calculate rotations
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);//Player looks toward target direction
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        //.Slerp is a roation between two points
        //Time.deltaTime gurantees a constant speed even with changing framerates

        transform.rotation = playerRotation;
    }
}
