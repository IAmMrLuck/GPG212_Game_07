using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    [SerializeField] private Vector2 camMinChange;
    [SerializeField] private Vector2 camMaxChange;

    [SerializeField] private Vector3 playerChange;

    [SerializeField] CameraFollow camFollow;

    [SerializeField] private string methodToCall;

    private void Start()
    {
        camFollow = Camera.main.GetComponent<CameraFollow>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            TransitionRoom(collision);
            AudioManager.instance.PlayOneShot(FMODEvents.instance.useDoorSound, this.transform.position);

            if(!string.IsNullOrEmpty(methodToCall))
            {
                MethodInfo method = GetType().GetMethod(methodToCall, BindingFlags.Instance | BindingFlags.NonPublic);
                if (method != null)
                {
                    method.Invoke(this, null);
                }
                else
                {
                    Debug.LogError("Method not found: " + methodToCall);
                }
            }
        }

    }

    private void NoNarration()
    {
        return;
    }

    private void TransitionRoom(Collider2D collision)
    {        
        camFollow.minPos += camMinChange;
        camFollow.maxPos += camMaxChange;
        collision.transform.position += playerChange;
    }

    private void PlayNarration111()
    {
        NarrationManager.instance.PlayOneShot(FMODEvents.instance.Narration112);

    }

} 
