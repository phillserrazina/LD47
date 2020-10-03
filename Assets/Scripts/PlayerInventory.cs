using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance { get; private set; }
    private List<ItemSO> items = new List<ItemSO>();

    private void Awake() => instance = this;

    public void Add(ItemSO item) => items.Add(item);
    public void Remove(ItemSO item) => items.Remove(item);
    public bool Contains(ItemSO item) { return items.Contains(item); } 
}
