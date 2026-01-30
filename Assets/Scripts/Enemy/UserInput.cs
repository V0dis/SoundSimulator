using UnityEngine;

public class UserInput : MonoBehaviour
{
    private const KeyCode TurnLeftKey = KeyCode.Q;
    private const KeyCode TurnRightKey = KeyCode.E;
    private const string AxisHorizontal = "Horizontal";
    private const string AxisVertical = "Vertical";
    
    public Vector3 GetMoveInput()
    {
        float horizontal = Input.GetAxisRaw(AxisHorizontal);
        float vertical = Input.GetAxisRaw(AxisVertical);
        
        return new Vector3(horizontal, 0, vertical).normalized;
    }
    
    public bool IsPressingKeyLeft => Input.GetKey(TurnLeftKey);
    public bool IsPressingKeyRight => Input.GetKey(TurnRightKey);
}