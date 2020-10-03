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

    // METHODS
    public void Pickup() {
        if (!CanBePicked) return;

        if (requiredItemsToPickup.Length > 0) {
            foreach (var item in requiredItemsToPickup) {
                PlayerInventory.instance.Remove(item);
            }
        }

        PlayerInventory.instance.Add(myItem);
        Destroy(gameObject);
    }
}
