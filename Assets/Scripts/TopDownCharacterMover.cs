using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownCharacterMover : MonoBehaviour
{
    private InputHandler _input;

    [Space][SerializeField]
    private InputActionAsset PlayerActions;
    [SerializeField]
    private InputAction movement;
    [SerializeField]
    private bool RotateTowardMouse;

    [SerializeField]
    private Transform MousePositon;
    [SerializeField]
    private float SprintModifier;
    [SerializeField]
    private float MovementSpeed;
    [SerializeField]
    private float RotationSpeed;
    Animator animator;
    [SerializeField]
    private Camera Camera;
    private void Start()
    {
       
        animator = GetComponent<Animator>();
    }
    private void Awake()
    {
        _input = GetComponent<InputHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
        var targetVector = new Vector3(_input.InputVector.x, 0, _input.InputVector.y);
        var movementVector = MoveTowardTarget(targetVector);

        if (!RotateTowardMouse)
        {
            RotateTowardMovementVector(movementVector);
        }
        if (RotateTowardMouse)
        {
            RotateFromMouseVector();
        }

    }

   
    private void RotateFromMouseVector()
    {
        var target = MousePositon.position;
        target.y = transform.GetChild(2).transform.position.y;
        
        transform.GetChild(2).transform.LookAt(target);
        
    }
    [ExecuteInEditMode]
    void OnAnimatorMove()
    {
        
        if (animator)
        {

            animator.ApplyBuiltinRootMotion();
            
            var target = MousePositon.position;
            target.y = 1000;
            transform.GetChild(2).LookAt(target);
            Debug.Log("works");
        }
    }
    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
        var speed = MovementSpeed * Time.deltaTime;
        Debug.Log(_input.sprint);
        if (_input.sprint)
        {
            speed = MovementSpeed * SprintModifier * Time.deltaTime;
            if (_input.InputVector.x != 0 || _input.InputVector.y != 0) {
                animator.SetBool("IsRunning", true);
                animator.SetBool("IsMoving", true);
            }
              
        }
        else
        {
            if (_input.InputVector.x != 0 || _input.InputVector.y != 0)
            {
                animator.SetBool("IsMoving", true);
                animator.SetBool("IsRunning", false);
            }
            else 
            if (_input.InputVector.x == 0 &&_input.InputVector.y==0)
            {
                animator.SetBool("IsMoving", false);
                animator.SetBool("IsRunning", false);
            }
            
           
            speed = MovementSpeed* Time.deltaTime;
        }
        
        // transform.Translate(targetVector * (MovementSpeed * Time.deltaTime)); Demonstrate why this doesn't work
        //transform.Translate(targetVector * (MovementSpeed * Time.deltaTime), Camera.gameObject.transform);

        targetVector = Quaternion.Euler(0, Camera.gameObject.transform.rotation.eulerAngles.y, 0) * targetVector;
        var targetPosition = transform.position + targetVector * speed;
        transform.position = targetPosition;
        return targetVector;
    }

    private void RotateTowardMovementVector(Vector3 movementDirection)
    {
        if(movementDirection.magnitude == 0) { return; }
        var rotation = Quaternion.LookRotation(movementDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, RotationSpeed);
    }
}
