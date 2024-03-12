using Unity.IO.LowLevel.Unsafe;using UnityEngine;

public class ThirdPersonControllerDisplay4 : ThirdPersonControllerBase
{
    [SerializeField] private Animator _animator;
    
    protected void Update() {
        ManageMovement();
       
    }
    

    protected override void DoJump(bool isPress) {
        Debug.Log("DoJump");
        if ( _isGRounded) _velocity.y = Mathf.Sqrt(JumpHeight * -2f * Gravity);
    }

   // public override void DoActionOnNorth(bool isPress) {
   //     Debug.Log("Do North");
   //     _animator.SetBool("Attack", isPress);
   // }
   protected override void DoActionOnNorth(bool isPress)
   {
       _animator.SetBool("Attack", isPress);
   }

   protected override void DoActionOnWest(bool isPress) {
        _animator.SetBool("Def", isPress);
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