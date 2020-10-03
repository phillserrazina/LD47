using UnityEngine;

public class RoomManager : MonoBehaviour
{
    // VARIABLES
    private Room[] allRooms;
    private Room currentRoom { get { return allRooms[currentRoomIndex]; } }
    private int currentRoomIndex = 1;

    public static RoomManager instance { get; private set; }

    // EXECUTION FUNCTIONS
    private void Awake() => instance = this;

    private void Start() {
        allRooms = GetComponentsInChildren<Room>();
        currentRoom.DisableTriggers();
    }

    public void OnRoomChange(int index) {
        currentRoom.ReenableTriggers();

        currentRoomIndex += index;
        if (currentRoomIndex < 0) currentRoomIndex = allRooms.Length-1;
        else if (currentRoomIndex >= allRooms.Length) currentRoomIndex = 0;

        var children = GetComponentsInChildren<Transform>();
        var firstChild = children[1].gameObject;
        var lastChild = children[children.Length-1].gameObject;
        lastChild = lastChild.GetComponentInParent<Room>().gameObject;

        var offset = Vector3.zero;
        offset.x = 22.5f;

        if (index > 0) {
            firstChild.transform.SetAsLastSibling();
            firstChild.transform.position = lastChild.transform.position + offset;
        }
        else {
            lastChild.transform.SetAsFirstSibling();
            lastChild.transform.position = firstChild.transform.position - offset;
        }
    }
}
