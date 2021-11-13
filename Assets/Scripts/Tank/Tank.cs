using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tank : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _delayBetweenShots;
    [SerializeField] private float _recoilDistance;

    private float _timeAfterShots;

    private void Update()
    {
        _timeAfterShots += Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            if(_timeAfterShots > _delayBetweenShots)
            {
                Shoot();
                transform.DOMoveZ(transform.position.z - _recoilDistance, _delayBetweenShots / 2).SetLoops(2, LoopType.Yoyo);
                _timeAfterShots = 0f;
            }
        }
    }

    private void Shoot()
    {
        Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
    }
}
