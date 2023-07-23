using UnityEngine;

public abstract class Trap : MonoBehaviour
{
    public abstract TrapType type { get; }
    public int triggerDelay;
    public abstract void TriggerTrap();
}
