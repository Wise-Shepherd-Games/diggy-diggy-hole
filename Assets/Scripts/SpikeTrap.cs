using UnityEngine;

public class SpikeTrap : Trap
{
    [Range(0, 100)]
    public float spikeVelocity;
    GameObject spike;

    public override TrapType type => TrapType.Spike;

    void Awake()
    {
        spike = this.transform.GetChild(0).gameObject;
    }

    public override void TriggerTrap() => Invoke("ThrowSpike", this.triggerDelay);

    private void ThrowSpike()
    {
        spike.SetActive(true);
        var rbSpike = spike.gameObject.GetComponent<Rigidbody>();
        rbSpike.AddForce(this.transform.forward * spikeVelocity, ForceMode.Impulse);
        rbSpike.constraints = RigidbodyConstraints.None;
    }

}
