using UnityEngine;

public class TriggerFakeMagnetClass : OscarEnterDetecter
{
    public GameObject magnet;

    protected override void OnOscarEnter()
    {
        Destroy(magnet.GetComponent<TappableMagnet>());
    }
}
