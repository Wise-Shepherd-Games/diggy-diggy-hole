using UnityEngine;

public class ImpaleTrap : Trap
{
    public bool isHidden;
    GameObject spike;

    public override TrapType type => TrapType.Impale;

    void Awake()
    {
        spike = this.transform.GetChild(0).gameObject;
        spike.SetActive(!isHidden);
    }

    public override void TriggerTrap()
    {
        if (isHidden)
            Invoke("Spiked", this.triggerDelay);
    }

    private void Spiked()
    {
        spike.SetActive(true);
    }
}
