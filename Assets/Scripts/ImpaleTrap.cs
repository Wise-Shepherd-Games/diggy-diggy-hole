using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpaleTrap : Trap
{
    public bool isHidden;
    GameObject spike;

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
