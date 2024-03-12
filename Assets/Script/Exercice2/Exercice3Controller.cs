using System;
using Cinemachine;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Exercice3Controller : Exercice2Controller
{

    [SerializeField] private CinemachineImpulseSource _impulseSource;
    [SerializeField] private float _flashTime = 0.2f;
    [SerializeField] private Light _pointLight;

    private float flashTimer;
    public override void TakeDamage() {
        if (_animator!=null)_animator.SetTrigger("TakeDamage");
        base.TakeDamage();
    }

    protected override void ManagerFire() {
        _impulseSource.GenerateImpulse();
        _pointLight.enabled = true;
        flashTimer = _flashTime;
        base.ManagerFire();
    }

    protected override void Update()
    {
        ManageFlashTime();
        base.Update();
    }

    private void ManageFlashTime()
    {
        if (flashTimer != 0) {
            flashTimer -= Time.deltaTime;
            if (flashTimer <= 0) {
                flashTimer = 0;
                _pointLight.enabled = false;
            }
        }
    }
    
    
}