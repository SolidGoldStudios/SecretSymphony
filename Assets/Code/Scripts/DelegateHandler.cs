using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateHandler : MonoBehaviour
{
    // Delegate
    public delegate void OnDisable();


    //event  
    public static event OnDisable Disabled;


    //On Button Click the event named Click can be called
    public void OnOnDisable()
    {
        //call the event
        Disabled();
    }
}
