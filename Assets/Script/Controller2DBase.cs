using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller2DBase : MonoBehaviour
{
    public event EventHandler<bool> OnNorthButton;
    public event EventHandler<bool> OnWestButton;
    public event EventHandler<bool> OnEastButton;
    public event EventHandler<Vector2> OnMoveButton;


    public CharacterController Controller;
    public float MoveSpeed;

    public float Gravity = -9.81f;
    public Transform GroundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask GroundMask;

    public float JumpHeight = 1f;
    [SerializeField] private Animator _animator;


    // Est vrai si le player touche le sol
    protected bool _isGRounded;

    // La vitesse vertical du joueur
    protected Vector3 _velocity;

    // La direction de movement du joueur
    protected Vector3 _moveVector;

    protected virtual void Update()
    {
        ManageMovement();
    }

    protected virtual void DoJump(bool isPress)
    {
       
    }

    protected virtual void DoActionOnNorth(bool isPress)
    {

    }

    protected virtual void DoActionOnWest(bool isPress)
    {
    }

    protected virtual void ManageMovement()
    {
        //_isGRounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);
//
        //if (_isGRounded && _velocity.y < 0)
        //{
        //    _velocity.y = -2f;
        //}
//
        //_velocity.y += Gravity * Time.deltaTime;
//
        //Controller.Move(MoveSpeed * Time.deltaTime * _moveVector);
        //Controller.Move(_velocity * Time.deltaTime);
         _animator.SetFloat("X", _moveVector.x);
    }




    // Ici sont ressu les informations des Input , comme les manettes ou clavier
    public void OnMove(InputValue value)
    {
        Vector2 vector2 = value.Get<Vector2>();
        _moveVector = new Vector3(vector2.x, 0, vector2.y);
        OnMoveButton?.Invoke(this, vector2);
    }

    public void OnNorth(InputValue value)
    {
        DoActionOnNorth(value.isPressed);
        OnNorthButton?.Invoke(this, value.isPressed);
    }

    public void OnWest(InputValue value)
    {
        DoActionOnWest(value.isPressed);
        OnWestButton?.Invoke(this, value.isPressed);
    }

    public void OnEast(InputValue value)
    {
        DoJump(value.isPressed);
        OnEastButton?.Invoke(this, value.isPressed);
    }
}