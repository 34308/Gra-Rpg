using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class TopDownCharacterMover : MonoBehaviour
{
    private InputHandler _input;
    public int dodgeRadius=7;
    private ParticleSystem _particleSystem;
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

    private bool alive=true;
    private PointerHandler _pointerHandler;
    private void Start()
    {
        _particleSystem = GetComponentInChildren<ParticleSystem>();
        _pointerHandler = MousePositon.GetComponent<PointerHandler>();
         animator = GetComponent<Animator>();
    }
    private void Awake()
    {
        _input = GetComponent<InputHandler>();
    }

    public void Dead()
    {
        alive = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (!alive)
        {
            return;
        }
        else
        {
            if (_input.magicAttack || _input.dogde)
            {
           
                if (Vector3.Distance(transform.position, MousePositon.position) < dodgeRadius && _input.dogde)
                {
                    if (!_pointerHandler.IsGreen())
                    {
                        _pointerHandler.TurnGreen();
                    }
                    _particleSystem.Play ();
                    ParticleSystem.EmissionModule em = _particleSystem.emission;
                    em.enabled = true;

                }
                else
                {
                    if (!_pointerHandler.IsRed())
                    {
                        _pointerHandler.TurnRed();
                    }
                }
                GameObject.FindGameObjectWithTag("Pointer").GetComponent<MeshRenderer>().enabled = true;
            }
            else if(!_input.magicAttack || !_input.dogde)
            {
                if (!_pointerHandler.IsRed())
                {
                    _pointerHandler.TurnRed();
                }
                GameObject.FindGameObjectWithTag("Pointer").GetComponent<MeshRenderer>().enabled =false;
            }
            var targetVector = new Vector3(_input.InputVector.x, 0, _input.InputVector.y);
            var movementVector = MoveTowardTarget(targetVector);
            if (_input.physicalAttack)
            {
                animator.SetBool("IsAttacking1", true);
           
            }
            if (!RotateTowardMouse)
            {
                RotateTowardMovementVector(movementVector);
            }
            if (RotateTowardMouse)
            {
                RotateFromMouseVector();
            }
        }
       

    }

    public void Dodge()
    {
        LifeAndManaSystem lifeAndManaSystem = GetComponent<LifeAndManaSystem>();
        if (lifeAndManaSystem.mp <= 2) return;
        if (Vector3.Distance(transform.position, MousePositon.position) < dodgeRadius)
        {
            lifeAndManaSystem.takeMana(2);
            transform.position = MousePositon.position;
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
        if (!alive)
        {
            return;
        }
        if (animator)
        {

            animator.ApplyBuiltinRootMotion();
            
            var target = MousePositon.position;
            target.y = 1000;
            transform.GetChild(2).LookAt(target);

            var targetVector = new Vector3(_input.InputVector.x, 0, _input.InputVector.y);
            targetVector = Quaternion.Euler(0, Camera.gameObject.transform.rotation.eulerAngles.y, 0) * targetVector;
            var rotation = transform.GetChild(2).rotation.eulerAngles;
            
            if ((targetVector.x >= -1.0f && targetVector.x <= 1.0f) && targetVector.z == 1.0f) {
                //N
                
                if(!(rotation.y>275 && rotation.y<360) && !(rotation.y > 0 && rotation.y <= 88))
                {
                    var Y=Math.Sqrt(Math.Pow(rotation.y - 275, 2)); 
                    var Y2= Math.Sqrt(Math.Pow(rotation.y - 360, 2)); 
                    var Y3 = Math.Sqrt(Math.Pow(rotation.y - 0, 2)); 
                    var Y4 = Math.Sqrt(Math.Pow(rotation.y - 88,2));
                    var min= Math.Min(Y, Math.Min(Y2, Math.Min(Y3,Y4)));
                    if (Y == min)
                    {
                        rotation.y = 275;
                    }else if (Y2 == min)
                    {
                        rotation.y = 360;
                    }
                    else if(Y3==min){
                        rotation.y = 0;
                    }
                    else if(Y4==min)
                    {
                        rotation.y = 88;
                    }
                }
                
            }
            else if (targetVector.x == 1.0f && (targetVector.z >= -1.0f && targetVector.z <= 1.0f)) {
                //E
                
                rotation.y = Mathf.Clamp(rotation.y, 0, 170);
             
            }
        
          
            else if (targetVector.x == -1.0f &&  (targetVector.z <= 1.0f && targetVector.z >= -1.0f)) {
                //w

                rotation.y = Mathf.Clamp(rotation.y, 194, 350);
            }
            else if ((targetVector.x >= -1.0f && targetVector.x <= 1.0f) && targetVector.z == -1.0f) {
                //s
                rotation.y = Mathf.Clamp(rotation.y, 90, 270);
            }
            transform.GetChild(2).rotation=Quaternion.Euler(rotation);
         

        }
    }
    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
        var speed = MovementSpeed * Time.deltaTime;
       
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
