using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    private Trap trap = null;

    void Awake()
    {
        var parent = this.transform.parent?.gameObject;
        trap = parent?.GetComponent<Trap>();
    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "Player" || obj.tag == "Interactable" || obj.tag == "Trap")
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            trap?.TriggerTrap();
        }
    }
}
