using UnityEngine;

public class DoorHighlight : MonoBehaviour
{
    // VARIABLES
    [SerializeField] private Sprite originalSprite = null;
    [SerializeField] private Sprite activeSprite = null;

    [SerializeField] private SpriteRenderer spriteRenderer = null;

    private int loop = 1000;
    public void SetLoop(int l) {
        loop = l;
        AudioManager.instance.Play("DoorOn");
    }

    [SerializeField] private GameObject lightObject = null;

    public static DoorHighlight instance { get; private set;}

    // EXECUTION FUNCTIONS
    private void Awake() => instance = this;

    private void Update() {
        lightObject.SetActive(RoomManager.instance.CurrentLoop == loop);
        spriteRenderer.sprite = RoomManager.instance.CurrentLoop == loop ? activeSprite : originalSprite;
    }
}
