using UnityEngine;
using UnityEngine.TextCore.Text;

public class Projetil : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timeToDestroy;
    [SerializeField] private float _damage;

    private void Start()
    {
        Destroy(gameObject, _timeToDestroy);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Component character;
        if (other.TryGetComponent(typeof(CharacterBase), out character))
        {
            ((CharacterBase)character).TakeDamage(_damage);
        }
    }
}
