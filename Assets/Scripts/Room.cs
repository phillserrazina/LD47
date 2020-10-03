using UnityEngine;

public class Room : MonoBehaviour
{
    private RoomSwitchTrigger[] myTriggers;

    private void Awake() {
        myTriggers = GetComponentsInChildren<RoomSwitchTrigger>();
    }

    public void ChangeRooms(int index) {
        RoomManager.instance.OnRoomChange(index);
        DisableTriggers();
    }

    public void ReenableTriggers() {
        foreach (var t in myTriggers) t.gameObject.SetActive(true);
    }

    public void DisableTriggers () {
        foreach (var t in myTriggers) t.gameObject.SetActive(false);
    }
}
