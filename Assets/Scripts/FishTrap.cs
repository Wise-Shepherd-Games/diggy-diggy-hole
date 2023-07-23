using System.Collections.Generic;
using UnityEngine;

public class FishTrap : Trap
{
    [Range(0, 100)]
    public float fishVelocity;
    [Range(0, 100)]
    public float fishRotate;
    List<Fish> fishes = new List<Fish>();

    public override TrapType type => TrapType.Fish;

    void Awake()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            var child = (this.transform.GetChild(i));
            if (child.tag == "Trap") fishes.Add(child.GetComponent<Fish>());
        }
    }

    public override void TriggerTrap() => Invoke("ThrowFish", this.triggerDelay);

    private void ThrowFish() =>
        fishes.ForEach((obj) =>
        {
            obj.transform.gameObject.SetActive(true);
            obj.FlyAway(fishVelocity, fishRotate);
        });

}
