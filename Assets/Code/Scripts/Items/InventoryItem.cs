using System;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class InventoryItem : IEquatable<InventoryItem>
{
    public string itemName;
    public string description;
    public string icon;
    public int weight;
    public int value;
    public int count;
	public bool unique;
    public string clickAction;

    public bool Equals(InventoryItem other)
    {
        if (other == null) return false;
        return this.itemName.Equals(other.itemName);
    }

}
