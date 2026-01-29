using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _rotateSpeed = 100f;

    private float _rotation;
    private float _targetY;
    
    public void Move(Vector3 direction)
    {
        if (direction.magnitude > 1f)
            direction.Normalize();
        
        transform.position += transform.TransformDirection(direction) * (_moveSpeed * Time.deltaTime);
    }

    public void Rotate(bool isPressingKeyLeft, bool isPressingKeyRight)
    {
        _rotation = 0f;
        
        if (isPressingKeyLeft) 
            _rotation -= _rotateSpeed;
        
        if (isPressingKeyRight)
            _rotation += _rotateSpeed;

        if (_rotation != 0f)
        {
            _targetY = transform.eulerAngles.y + _rotation * Time.deltaTime;
            transform.rotation = Quaternion.Euler(x: 0f, y: _targetY, z: 0f);
        }
    }
}