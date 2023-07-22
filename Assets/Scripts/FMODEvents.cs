using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{

    [field: Header("Narration")]

    [field: SerializeField] public EventReference Narration00 { get; private set; }


    [field: Header("Door SFX")]

    [field: SerializeField] public EventReference useDoorSound { get; private set; }

    public static FMODEvents instance { get; private set; }



    // ensures there is only one of these in scene
    private void Awake()
    {

        if(instance != null)
        {
            Debug.Log("Too many FMOD Events in here"); 
        }

        instance = this;
    }

}
