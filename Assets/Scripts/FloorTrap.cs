using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTrap : Trap
{

    public override void TriggerTrap() => Invoke("Fall", this.triggerDelay);

    private void Fall()
    {
        var rb = this.transform.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddForce(Vector3.down * 10, ForceMode.Impulse);
        rb.constraints = RigidbodyConstraints.None;
    }
}
