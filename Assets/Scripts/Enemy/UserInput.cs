using UnityEngine;

public class UserInput : MonoBehaviour
{
    private const KeyCode TurnLeftKey = KeyCode.Q;
    private const KeyCode TurnRightKey = KeyCode.E;
    
    public Vector3 GetMoveInput()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        return new Vector3(horizontal, 0, vertical).normalized;
    }
    
    public bool IsPressingKeyLeft => Input.GetKey(TurnLeftKey);
    public bool IsPressingKeyRight => Input.GetKey(TurnRightKey);
}