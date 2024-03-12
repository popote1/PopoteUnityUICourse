using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonControllerDisplay : ThirdPersonControllerBase
{

    [SerializeField] private Animator _animator;
    
    // Est vrai si le player touche le sol
    //protected bool _isGRounded;
    
    // La vitesse vertical du joueur
    //protected Vector3 _velocity;
    
    // La direction de movement du joueur
    //protected Vector3 _moveVector;
    protected void Update() {
        ManageMovement();
    }
    
    protected override void DoJump(bool isPress) {
        if ( _isGRounded) _velocity.y = Mathf.Sqrt(JumpHeight * -2f * Gravity);
    }

    protected override void DoActionOnNorth(bool isPress) {
    }

    protected override void DoActionOnWest(bool isPress) {
    }
    
    protected  override void ManageMovement() {
        _isGRounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        if (_isGRounded && _velocity.y < 0) {
            _velocity.y = -2f;
        }
        _velocity.y += Gravity * Time.deltaTime;
        
        Controller.Move(MoveSpeed*Time.deltaTime*_moveVector);
        Controller.Move(_velocity*Time.deltaTime);
    }
}