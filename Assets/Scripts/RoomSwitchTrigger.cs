using UnityEngine;
using UnityEngine.Events;

public class RoomSwitchTrigger : MonoBehaviour
{
    // VARIABLES
    private Room myRoom;
    [SerializeField] private UnityEvent OnTrigger = null;

    // EXECUTION FUNCTIONS
    private void Start() {
        myRoom = GetComponentInParent<Room>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<PlayerMovement>() == null) return;
        OnTrigger?.Invoke();
    }
}
