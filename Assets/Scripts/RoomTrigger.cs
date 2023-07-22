using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    [SerializeField] private Vector2 camMinChange;
    [SerializeField] private Vector2 camMaxChange;

    [SerializeField] private Vector3 playerChange;

    [SerializeField] CameraFollow camFollow;

    private void Start()
    {
        camFollow = Camera.main.GetComponent<CameraFollow>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            TransitionRoom(collision);
        }

    }

    private void TransitionRoom(Collider2D collision)
    {
        camFollow.minPos += camMinChange;
        camFollow.maxPos += camMaxChange;

        collision.transform.position += playerChange;
    }
} 
