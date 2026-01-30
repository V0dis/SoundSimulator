using UnityEngine;

namespace House
{
    public class House : MonoBehaviour
    {
        [SerializeField] private CollisionDetector _collisionDetector;
        [SerializeField] private AlarmSound _alarmSound;

        private void OnEnable()
        {
            _collisionDetector.IntruderEntered += IntruderStatusChanged;
        }

        private void OnDisable()
        {
            _collisionDetector.IntruderEntered -= IntruderStatusChanged;
        }

        private void IntruderStatusChanged(bool isEntered)
        {
            _alarmSound.SetAlarm(isEntered);
        }
    }
}