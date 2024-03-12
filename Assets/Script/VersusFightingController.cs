using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VersusFightingController : MonoBehaviour
{

    public event EventHandler<bool> OnKickButton;
    public event EventHandler<bool> OnPunchButton;
    public event EventHandler<bool> OnHeadBumpButton;
    public event EventHandler<bool> OnJumpButton;
    public event EventHandler<float> OnMoveButton; 

    public float Speed = 1;
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerInput _playerInput; 

    private float _movevalue;

    private void Start()
    {
        
    }

    public void OnMove(InputValue value) {
        OnMoveButton?.Invoke(this, value.Get<float>());
        _movevalue = value.Get<float>();
    }

    public void OnKick(InputValue value) {
        OnKickButton?.Invoke(this, value.isPressed);
        if (!value.isPressed) return;
        
        _animator.SetTrigger("Kick");
        }

    public void OnPunsh(InputValue value) {
        
        OnPunchButton?.Invoke(this, value.isPressed);
        if (!value.isPressed) return;
        
        _animator.SetTrigger("Punsh");
    }

    public void OnHeadBump(InputValue value) {
        OnHeadBumpButton?.Invoke(this, value.isPressed);
        if (!value.isPressed) return;
        
        _animator.SetTrigger("HeadBump");
    }

    public void OnHit(InputValue value) {
        
        _animator.SetTrigger("Kick");
    }
    
    
    public void OnJump(InputValue value) {
        OnJumpButton?.Invoke(this, value.isPressed);
        _animator.SetBool("IsJumping" , value.isPressed);
        if (!value.isPressed) return;
        
        
    }
    

    public void Update() {
        transform.Translate(-transform.forward *(_movevalue*Speed*Time.deltaTime));
        _animator.SetBool("GoForward" , _movevalue>0.1f);
        _animator.SetBool("GoBackward" , _movevalue<-0.1f);
    }
}
