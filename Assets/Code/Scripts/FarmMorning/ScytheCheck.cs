using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CheckCo());
    }

    private IEnumerator CheckCo()
    {
        yield return new WaitForSeconds(0.5f);

        Interaction interaction = GetComponent<Interaction>();
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        if ((int)GameManager.Instance.inkStory.variablesState["has_scythe"] == 0)
        {
            interaction.enabled = true;
            sprite.enabled = true;
        }
        else
        {
            interaction.enabled = false;
            sprite.enabled = false;
        }

        yield return null;
    }
}
