using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    // VARIABLES
    [SerializeField] private bool showInSpecificLoop = false;
    [SerializeField] private int loopToShowIn = 0;
    [SerializeField] private ItemSO[] requiredItems = null;
    [SerializeField] private UnityEvent OnInteract = null;
    private bool playerInRange = false;

    protected bool ShouldBeActive {
        get {
            if ((showInSpecificLoop && RoomManager.instance.CurrentLoop != loopToShowIn)) return false;
            foreach (var item in requiredItems) {
                if (!PlayerInventory.instance.Contains(item))
                    return false;
            }
            return true;
        }
    }

    protected virtual bool ShouldBeTriggered {
        get {
            return ShouldBeActive;
        }
    }

    private SpriteRenderer spriteRenderer;

    // EXECUTION FUNCTIONS
    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        spriteRenderer.enabled = ShouldBeActive;

        if (!playerInRange) return;
    	
        if (Input.GetKeyDown(KeyCode.E)) {
            OnInteract?.Invoke();
            PlayerManager.instance.BeginCooldown();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (!ShouldBeTriggered) return;

        playerInRange = true;
        PlayerManager.instance.OnObjectChange(true);
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (!ShouldBeTriggered) return;

        playerInRange = false;
        PlayerManager.instance.OnObjectChange(false);
    }
}
