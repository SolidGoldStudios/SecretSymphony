using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentPiano : Quest
{
    public override void Setup()
    {
        questName = "Chop Up Firewood";
        description = "A strange lump of firewood showed up in the living room. I should get my scythe from the barn outside and chop it up for kindling.";
        requirements = "Get the scythe, and use it on the big wood thing in the living room.";

        GameManager.Instance.itemAddDelegate += ItemAdded;
        GameManager.Instance.itemRemoveDelegate += ItemRemoved;

        GameManager.Instance.inkStory.ObserveVariable("has_hit_piano", (string varName, object newValue) => {
            if (newValue.ToString().Equals("true"))
            {
                Complete();
            }
        });
    }

    public override bool IsReadyToComplete()
    {
        return
            GameManager.Instance.GetInventoryCount("Scythe") >= 1;
    }

    public override void Complete()
    {
        if (!IsReadyToComplete() || isComplete) return;

        GameManager.Instance.inkStory.RemoveVariableObserver(null, "has_hit_piano");

        GameManager.Instance.itemAddDelegate -= ItemAdded;
        GameManager.Instance.itemRemoveDelegate -= ItemRemoved;

        isComplete = true;
    }

    void ItemAdded(string name)
    {
        Debug.Log("InstrumentPiano quest saw item added: " + name);

        if (name == "Piano Key")
        {
            GameManager.Instance.inkStory.variablesState["has_piano_key"] = true;
        }
    }

    void ItemRemoved(string name)
    {
        Debug.Log("InstrumentPiano saw item removed: " + name);
    }
}
