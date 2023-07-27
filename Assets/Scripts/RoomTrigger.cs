using UnityEngine;
using FMOD.Studio;
using FMODUnity;
using Unity.VisualScripting.Antlr3.Runtime;

public class RoomTrigger : MonoBehaviour
{
    [SerializeField] private Vector2 camMinChange;
    [SerializeField] private Vector2 camMaxChange;
    [SerializeField] private Vector3 playerChange;
    [SerializeField] private CameraFollow camFollow;
    [SerializeField] private string fmodEventName;

    private bool hasSoundPlayed = false;

    // Keep track of the active sound event instance for this trigger
    private static EventInstance activeSoundEvent;

    private void Start()
    {
        camFollow = Camera.main.GetComponent<CameraFollow>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.useDoorSound, this.transform.position);
            TransitionRoom(collision);
            PlayNarration();
            hasSoundPlayed = true;
        }
    }

    private void PlayNarration()
    {
        if (hasSoundPlayed == false)
        {
            if (activeSoundEvent.isValid())
            {
                activeSoundEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            }

            activeSoundEvent = RuntimeManager.CreateInstance(fmodEventName);

            if (!string.IsNullOrEmpty(fmodEventName))
            {
                activeSoundEvent.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));
                activeSoundEvent.start();
                activeSoundEvent.release();
            }
        }
    }

    private void TransitionRoom(Collider2D collision)
    {
        camFollow.minPos += camMinChange;
        camFollow.maxPos += camMaxChange;
        collision.transform.position += playerChange;
    }

}
