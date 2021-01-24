using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLogItemButtonHandler : MonoBehaviour
{
    public void UpdateQuestIndex()
    {
        GameManager.Instance.UpdateQuestLog();
    }
}
