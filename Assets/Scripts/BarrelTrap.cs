using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelTrap : Trap
{
    [Range(0, 100)]
    public float barrelVelocity;
    GameObject barrel;

    void Awake()
    {
        barrel = this.transform.GetChild(0).gameObject;
    }

    public override void TriggerTrap() => Invoke("ThrowBarrel", this.triggerDelay);

    private void ThrowBarrel()
    {
        var rbSpike = barrel.gameObject.GetComponent<Rigidbody>();
        rbSpike.AddForce(-this.transform.forward * barrelVelocity, ForceMode.Impulse);
        rbSpike.constraints = RigidbodyConstraints.None;
    }
}
