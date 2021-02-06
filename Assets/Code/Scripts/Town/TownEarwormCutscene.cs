using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownEarwormCutscene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EnvironmentManager.Instance.cloudy = true;
        EnvironmentManager.Instance.rainStorm = true;
    }
}
