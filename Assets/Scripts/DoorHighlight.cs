using UnityEngine;

public class DoorHighlight : MonoBehaviour
{
    // VARIABLES
    private int loop = 0;
    public void SetLoop(int l) => loop = l;

    [SerializeField] private GameObject lightObject = null;

    public static DoorHighlight instance { get; private set;}

    // EXECUTION FUNCTIONS
    private void Awake() => instance = this;

    private void Update() {
        lightObject.SetActive(RoomManager.instance.CurrentLoop == loop);
    }
}
