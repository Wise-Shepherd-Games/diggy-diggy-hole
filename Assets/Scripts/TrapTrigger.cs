using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
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
                trap.TriggerTrap();
        }
    }
}
