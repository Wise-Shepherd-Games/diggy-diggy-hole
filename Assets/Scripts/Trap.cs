using UnityEngine;

public abstract class Trap : MonoBehaviour
{
    public abstract TrapType type { get; }
    public int triggerDelay;
    public abstract void TriggerTrap();

    public void DestroyChildren()
    {
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            var child = this.gameObject.transform.GetChild(i);
            if (child.tag == "Trap")
            {
                Object.Destroy(child.gameObject, 5);
            }
        }
    }
}
