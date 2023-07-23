using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    public List<AudioClip> triggerSounds = new List<AudioClip>();
    public AudioSource audioSource;

    private Trap trap;
    private BoxCollider bc;


    void Awake()
    {
        trap = GetComponentInParent<Trap>();
        bc = GetComponent<BoxCollider>();
    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "Player" || obj.tag == "Interactable" || obj.tag == "Trap")
        {
            bc.enabled = false;

            if (RunesManager.dict.TryGetValue(trap.type, out var dto) && dto.enabled)
            {
                if (triggerSounds.Count > 0)
                    audioSource.PlayOneShot(triggerSounds[Random.Range(0, triggerSounds.Count)]);
                trap.TriggerTrap();
            }
        }
    }
}
