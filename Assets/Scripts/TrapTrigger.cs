using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    private Trap trap = null;

    void Awake()
    {
        trap = this.transform.gameObject.GetComponentInParent<Trap>();
    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "Player")
        {
            Debug.Log("Trigger!");
            trap.TriggerTrap();
        }
    }
}
