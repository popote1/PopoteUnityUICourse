using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(CharacterController))]
public class Exercise2Ennemi : MonoBehaviour
{
    [SerializeField] private float _detectionDistance = 5;
    [SerializeField] private float _attackDistance = 1;
    [SerializeField] private float _attaqueTime = 2;
    [SerializeField] private float _moveSpeed = 2;
    [SerializeField] private int _hp = 3;
    [SerializeField] private float _deathlifeTime = 5;

    [SerializeField] protected Animator _animator;

    private CharacterController _characterController;
    private Exercice2Controller _target;
    private float _attackTimer;

    private enum Stat
    {
        Idle,
        Chasse,
        Attack,
        die
    }

    private Stat _stat = Stat.Idle;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        _target = Exercice2Controller.Player;
    }

    private void Update()
    {
        switch (_stat)
        {
            case Stat.Idle:
                ManageIdle();
                break;
            case Stat.Chasse:
                ManageChasse();
                break;
            case Stat.Attack:
                ManageAttack();
                break;
            case Stat.die:
                ManageDie();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void ManageIdle()
    {
        if (Vector3.Distance(transform.position, _target.transform.position) < _detectionDistance)
        {
            _stat = Stat.Chasse;
            if (_animator) _animator.SetBool("IsWalking", false);
            else Debug.LogWarning("Il n'y pas d'animator referencé sur l'ennemi", this);
        }
    }

    private void ManageChasse()
    {
        if (Vector3.Distance(transform.position, _target.transform.position) > _detectionDistance)
        {
            _stat = Stat.Idle;
            return;
        }

        if (Vector3.Distance(transform.position, _target.transform.position) < _attackDistance)
        {
            _stat = Stat.Attack;
            _target.TakeDamage();
            return;
        }

        if (_animator) _animator.SetBool("IsWalking", true);
        else Debug.LogWarning("Il n'y pas d'animator referencé sur l'ennemi", this);
        transform.forward = _target.transform.position - transform.position;
        _characterController.Move(((_target.transform.position - transform.position).normalized) * Time.deltaTime *
                                  _moveSpeed);
    }

    private void ManageAttack()
    {
        _attackTimer += Time.deltaTime;
        if (_animator) _animator.SetBool("Attack", true);
        if (_attackTimer >= _attaqueTime)
        {
            _attackTimer = 0;
            _stat = Stat.Idle;
            if (_animator) _animator.SetBool("Attack", false);
            else Debug.LogWarning("Il n'y pas d'animator referencé sur l'ennemi", this);

        }
    }

    private void ManageDie()
    {
        _deathlifeTime -= Time.deltaTime;
        _characterController.enabled = false;
        if (_animator) _animator.SetBool("Die", true);
        else Debug.LogWarning("Il n'y pas d'animator referencé sur l'ennemi", this);
        if (_deathlifeTime < 0)
        {
            Destroy(gameObject);
        }
    }

    public virtual void TakeDamage()
    {
        _hp--;
        if (_hp <= 0)
        {
            _stat = Stat.die;
        }
    }
}