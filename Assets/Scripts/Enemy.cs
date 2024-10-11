using System;
using System.Collections;
using UnityEngine;

public class Enemy : CharacterBase
{
    [SerializeField] private GameObject _playerObj;
    [SerializeField] private float _fireRate;

    void Start()
    {
        StartCoroutine(WaitFire());
    }
    
    private void Update()
    {
        transform.LookAt(_playerObj.transform);
    }

    private IEnumerator WaitFire()
    {
        while (true)
        {
            yield return new WaitForSeconds(_fireRate);
            Instantiate(_projetilPrefab,
                _projetilPos.transform.position,
                _projetilPos.transform.rotation);
        }
    }
}