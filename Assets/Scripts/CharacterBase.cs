using System;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    [SerializeField] private float _lifeMax;
    [SerializeField] protected GameObject _projetilPrefab;
    [SerializeField] protected GameObject _projetilPos;

    private float _life;

    private void Start()
    {
        _life = _lifeMax;
    }

    public void TakeDamage(float damage)
    {
        _life -= damage;
        
        Debug.Log($"Life {gameObject.name} = {_life}");
    }
}