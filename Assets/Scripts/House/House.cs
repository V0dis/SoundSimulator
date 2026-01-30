using UnityEngine;

namespace House
{
    public class House : MonoBehaviour
    {
        [SerializeField] private CollisionDetector _collisionDetector;
        [SerializeField] private AlarmSound _alarmSound;

        private void OnEnable()
        {
            _collisionDetector.IntruderEntered += OnIntruderStatusChanged;
        }

        private void OnDisable()
        {
            _collisionDetector.IntruderEntered -= OnIntruderStatusChanged;
        }

        private void OnIntruderStatusChanged(bool isEntered)
        {
            _alarmSound.SetAlarm(isEntered);
        }
    }
}