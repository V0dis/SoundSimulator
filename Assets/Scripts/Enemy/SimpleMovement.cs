using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class SimpleMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _rotateSpeed = 100f;
    
    private Keyboard _keyboard = Keyboard.current;

    private KeyControl _forwardKey;
    private KeyControl _backwardKey;
    private KeyControl _leftKey;
    private KeyControl _rightKey;
    private KeyControl _leftRotateKey;
    private KeyControl _rightRotateKey;
    
    private Vector3 _direction;
    private Vector3 _rotation;

    private void Awake()
    {
        _forwardKey = _keyboard[Key.W];
        _backwardKey = _keyboard[Key.S];
        _leftKey = _keyboard[Key.A];
        _rightKey = _keyboard[Key.D];
        
        _leftRotateKey = _keyboard[Key.Q];
        _rightRotateKey = _keyboard[Key.E];
    }

    private void Update()
    {
        HundlerInput();
        
        Move();
        Rotate();
    }

    private void HundlerInput()
    {
        if (_forwardKey.isPressed) _direction.z += 1;
        if (_backwardKey.isPressed) _direction.z -= 1;
        if (_leftKey.isPressed) _direction.x -= 1;
        if (_rightKey.isPressed) _direction.x += 1;
        
        if (_rightRotateKey.isPressed) _rotation.y += 1;
        if (_leftRotateKey.isPressed) _rotation.y -= 1;
    }

    private void Move()
    {
        if (_direction.z != 0f || _direction.x != 0f)
            transform.position += transform.TransformDirection(_direction) * (_moveSpeed * Time.deltaTime);
        
        if (_direction.magnitude > 1f)
            _direction.Normalize();
        
        _direction = Vector3.zero;
    }

    private void Rotate()
    {
        if (_rotation.y != 0f) 
            transform.Rotate(0f, _rotation.y * _rotateSpeed * Time.deltaTime, 0f);
        
        _rotation = Vector3.zero;
    }
}