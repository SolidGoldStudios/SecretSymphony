using System;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;

public abstract class Quest : IEquatable<Quest>
{
    public string questName;
    public string description;
    public string requirements;
    public bool isComplete = false;

    public abstract void Setup();
    public abstract bool IsReadyToComplete();
    public abstract void Complete();

    public bool Equals(Quest other)
    {
        if (other == null) return false;
        return this.questName.Equals(other.questName);
    }
}
