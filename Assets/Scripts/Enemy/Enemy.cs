using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private UserInput _userInput;

    private void Update()
    {
        _mover.Move(_userInput.GetMoveInput());
        _mover.Rotate(_userInput.IsPressingKeyLeft, _userInput.IsPressingKeyRight);
    }
}