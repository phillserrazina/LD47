using UnityEngine;

public class RoomSwitchTrigger : MonoBehaviour
{
    private Room myRoom;
    [SerializeField] private int switchIndex;

    private void Start() {
        myRoom = GetComponentInParent<Room>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<PlayerMovement>() == null) return;

        myRoom.ChangeRooms(switchIndex);
    }
}
