using UnityEngine;

public class ThirdPersonControllerDisplay3 : ThirdPersonControllerBase
{
    [SerializeField] private Animator _animator;
    
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
        
        _animator.SetFloat("X", _moveVector.x );
        _animator.SetFloat("Y", _moveVector.z );
    }
}