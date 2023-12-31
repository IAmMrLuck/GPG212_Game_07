using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform targetPlayer;
    [SerializeField] private float smoothing;

    public Vector2 minPos;
    public Vector2 maxPos;


    private void FixedUpdate()
    {
        if (transform.position != targetPlayer.position)
        {
            Vector3 targetPos = new Vector3(targetPlayer.position.x, targetPlayer.position.y, transform.position.z);

            targetPos.x = Mathf.Clamp(targetPos.x, minPos.x, maxPos.x);
            targetPos.y = Mathf.Clamp(targetPos.y, minPos.y, maxPos.y);

            transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
        }
    }
}
