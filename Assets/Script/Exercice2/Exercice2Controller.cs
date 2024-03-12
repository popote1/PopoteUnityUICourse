
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(CharacterController))]
public class Exercice2Controller : MonoBehaviour
{

    public static Exercice2Controller Player;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private LayerMask _mouseLayerMask;
    [Space(5)]
    [SerializeField] private GameObject _psGound;
    [SerializeField] private GameObject _psBlood;
    [SerializeField] private Transform _firePoint;
    [SerializeField] protected Animator _animator;
    
    private CharacterController _characterController;
    private Camera _camera;
    
    private Vector3 _moveVector;

    private void Awake() {
        _characterController = GetComponent<CharacterController>();
        _camera = Camera.main;
        Player = this;
    }

    void Start() {
        
    }

    // Update is called once per frame
    protected virtual void Update() {
        ManageMovement();
        ManagerOriantation();
    }

    public void ManageMovement() {
        _characterController.Move(_moveVector *( _moveSpeed * Time.deltaTime));

        if (_animator != null) {
            float angle = Vector3.SignedAngle(transform.forward, Vector3.forward, Vector3.up);

            Vector3 displayVec = RotateXZ(_moveVector.normalized, -angle);
            _animator.SetFloat("X", displayVec.x);
            _animator.SetFloat("Y", displayVec.z);
        }
        else {
            Debug.LogWarning("Il n'y pas d'animator referencé sur le Player", this);
        }
    }

    private void ManagerOriantation() {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
        if (Physics.Raycast(ray, out hit , Mathf.Infinity, _mouseLayerMask))
        {
            Vector3 lookAtVac = hit.point - transform.position;
            lookAtVac.y = 0;
            transform.forward =lookAtVac ;
        }
    }

    protected virtual void ManagerFire() {
        RaycastHit hit;
        if (Physics.Raycast(new Ray(_firePoint.position, _firePoint.forward), out hit, 50)) {
            if (hit.collider.CompareTag("Ennemi")) {
                Exercise2Ennemi ennemi = hit.collider.GetComponent<Exercise2Ennemi>();
                ennemi.TakeDamage();
                GameObject go = Instantiate(_psBlood, hit.point, Quaternion.identity);
                go.transform.forward = transform.position - hit.point;
                return;
            }

            if (hit.collider.CompareTag("Ground"))
            {
                GameObject go = Instantiate(_psGound, hit.point, Quaternion.identity);
                go.transform.forward =hit.normal; 
            }
        }
    }

    public virtual void TakeDamage() {
        
    }
    
    public void OnMove(InputValue value) {
        Vector2 vector2 = value.Get<Vector2>();
        _moveVector = new Vector3(vector2.x, 0, vector2.y);
    }

    public void OnNorth(InputValue value) {
       
    }

    public void OnWest(InputValue value) {
        
    }

    public void OnEast(InputValue value) {
        
    }

    public void OnFire(InputValue value) {
        if( value.isPressed)ManagerFire();
        
    }
    
    public Vector3 RotateXZ(Vector3 originVec, float angle) {
        angle = angle * Mathf.Deg2Rad;
        float x = (originVec.x*Mathf.Cos(angle) - originVec.z*Mathf.Sin(angle));
        float z = (originVec.x*Mathf.Sin(angle) + originVec.z*Mathf.Cos(angle));
        return new Vector3(x, 0, z);
    }
    
}