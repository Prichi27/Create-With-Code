using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject muzzle;

    private bool _isShooting;

    private void Update()
    {
        if (_isShooting)
        {
            Instantiate(bullet, muzzle.transform.position, muzzle.transform.rotation);
            _isShooting = false;
        }    
    }

    private void ShotsFired()
    {

    }

    public void TriggerShoot()
    {
        _isShooting = true;
    }
}
