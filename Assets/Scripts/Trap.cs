using UnityEngine;

public abstract class Trap : MonoBehaviour
{
    public int triggerDelay;
    public abstract void TriggerTrap();
}
