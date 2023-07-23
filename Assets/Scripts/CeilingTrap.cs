using UnityEngine;

public class CeilingTrap : Trap
{

    [Range(0, 100)]
    public float fallForce;
    GameObject ceiling;

    public override TrapType type => TrapType.Ceiling;

    void Awake()
    {
        ceiling = this.transform.GetChild(0).gameObject;
    }

    public override void TriggerTrap() => Invoke("Fall", this.triggerDelay);

    private void Fall()
    {
        ceiling.SetActive(true);
        ceiling.GetComponent<Rigidbody>().AddForce(Vector3.down * fallForce, ForceMode.Impulse);
        DestroyChildren();
    }
}
