using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using System.Reflection;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    private EventInstance musicEventInstance;


    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("there is more than one Audio Manager");

        }
        instance = this;
    }

    private void Start()
    {
        InitialiseMusic(FMODEvents.instance.BackGroundMusic);
        PlayOneShot(FMODEvents.instance.Intro, this.transform.position);
    }

    private void InitialiseMusic(EventReference musicEventReference)
    {
        musicEventInstance = CreateEventInstance(musicEventReference);
        musicEventInstance.start();
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    { 
        RuntimeManager.PlayOneShot(sound, worldPos);
    }


    public EventInstance CreateEventInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        return eventInstance;
    }
}
