using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour
{
    // VARIABLES
    private RoomSwitchTrigger[] myTriggers;
    [SerializeField] private SceneText myItemText = null;

    // EXECUTION FUNCTIONS
    private void Awake() {
        myTriggers = GetComponentsInChildren<RoomSwitchTrigger>();
    }

    // METHODS
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

    public void TriggerItemText(string text) {
        StartCoroutine(ItemTextCoroutine(text));
    }

    private IEnumerator ItemTextCoroutine(string text) {
        myItemText.ActivateTextSimple(text);

        yield return new WaitForSeconds(2f);

        myItemText.GetComponent<Animator>().Play("OnDisable");
    }
}
