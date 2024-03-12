using UnityEngine;

public class ThirdPersonControllerDisplay2 : ThirdPersonControllerBase
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _heightCheck;
    [Range(0,2)][SerializeField] private float _heightCheckDistance = 0.5f;
    
    // Est vrai si le player touche le sol
    //protected bool _isGRounded;
    
    // La vitesse vertical du joueur
    //protected Vector3 _velocity;
    
    // La direction de movement du joueur
    //protected Vector3 _moveVector;
    protected void Update() {
        ManageMovement();
        ManageHeight();
    }

    private void ManageHeight()
    {
        Ray ray = new Ray(_heightCheck.position, Vector3.up);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, _heightCheckDistance, GroundMask)) {
            Debug.DrawLine(_heightCheck.position, hit.point, Color.red);
            _animator.SetFloat("Height", Vector3.Distance(_heightCheck.position, hit.point)/_heightCheckDistance);
        }
        else
        {
            Debug.DrawLine(_heightCheck.position, _heightCheck.position+Vector3.up*_heightCheckDistance, Color.green);
            _animator.SetFloat("Height", 1);
        }
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