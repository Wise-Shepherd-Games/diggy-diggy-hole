using UnityEngine;

public class BarrelTrap : Trap
{
    [Range(0, 100)]
    public float barrelVelocity;
    GameObject barrel;

    public override TrapType type => TrapType.Barrel;

    void Awake()
    {
        barrel = this.transform.GetChild(0).gameObject;
    }

    public override void TriggerTrap() => Invoke("ThrowBarrel", this.triggerDelay);

    private void ThrowBarrel()
    {
        if (barrel.tag != "Interactable")
        {
            barrel.tag = "Trap";
            var rbSpike = barrel.gameObject.GetComponent<Rigidbody>();
            rbSpike.AddForce(-this.transform.forward * barrelVelocity, ForceMode.Impulse);
            rbSpike.constraints = RigidbodyConstraints.None;
            DestroyChildren();
        }
    }
}
