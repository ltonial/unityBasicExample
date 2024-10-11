using UnityEngine;

public class Player : CharacterBase
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _sensitivity = 100f;
    
    private float _xRotation;
    

    void Update()
    {
        //BasicMovement();
        MovementWithKeyboardRotation();

        //MovementWithMouseRotation();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
        
    }

    private void Fire()
    {
        Instantiate(_projetilPrefab, 
                    _projetilPos.transform.position, 
                    _projetilPos.transform.rotation);
    }

    private void BasicMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * _speed * Time.deltaTime);
    }

    private void MovementWithKeyboardRotation()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(0.0f, 0.0f, moveVertical);
        transform.Translate(movement * _speed * Time.deltaTime);
        
        _xRotation -= moveHorizontal;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(0f, -_xRotation, 0f);
    }

    private void MovementWithMouseRotation()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * _speed * Time.deltaTime);
        
        float mouseY = Input.GetAxis("Mouse X") * _sensitivity * Time.deltaTime;
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(0f, -_xRotation, 0f);
    }
}