using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestoyScript : MonoBehaviour
{
    [SerializeField] private float _detroyDelay;
    void Start() {
        Destroy(gameObject , _detroyDelay);
    }

    
}
