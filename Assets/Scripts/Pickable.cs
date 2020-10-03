using UnityEngine;

public class Pickable : Interactable
{
    // VARIABLES
    [SerializeField] private ItemSO myItem = null;

    [SerializeField] private ItemSO[] requiredItemsToPickup = null;

    private bool CanBePicked {
        get {
            foreach (var item in requiredItemsToPickup) {
                if (!PlayerInventory.instance.Contains(item))
                    return false;
            }
            return true;
        }
    }

    protected override bool ShouldBeTriggered {
        get {
            return ShouldBeActive && CanBePicked;
        }
    }

    // METHODS
    public void Pickup() {
        if (!CanBePicked) return;

        if (requiredItemsToPickup.Length > 0) {
            foreach (var item in requiredItemsToPickup) {
                PlayerInventory.instance.Remove(item);
            }
        }

        if (myItem != null) {
            PlayerInventory.instance.Add(myItem);
            RoomManager.instance.CurrentRoom.TriggerItemText("Picked up " + myItem.itemName);
        }
        
        PlayerManager.instance.OnObjectChange(false);
        Destroy(gameObject);
    }
}
