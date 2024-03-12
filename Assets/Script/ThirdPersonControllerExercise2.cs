using UnityEngine;

public class ThirdPersonControllerExercise2 : ThirdPersonControllerBase
{

    [SerializeField] private Animator _animator;
    
    // Est vrai si le player touche le sol
    //protected bool _isGRounded;
    
    // La vitesse vertical du joueur
    //protected Vector3 _velocity;
    
    // La direction de movement du joueur
    //protected Vector3 _moveVector;
    // Le _moveVéctor et composer de la manière suivent en X se trouve l'axes X et
    // en Z se trouve l'axe Y de l'input alors que le Y est toujours zéro .
    protected override void Update() {
        ManageMovement();
        _animator.SetFloat("MoveSpeed", _moveVector.z);
    }
    
    protected override void DoJump(bool isPress) {
        if ( _isGRounded) _velocity.y = Mathf.Sqrt(JumpHeight * -2f * Gravity);
    }

    protected override void DoActionOnNorth(bool isPress) {
        _animator.SetBool("Salut", isPress);
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