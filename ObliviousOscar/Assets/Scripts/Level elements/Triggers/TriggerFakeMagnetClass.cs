using UnityEngine;

public class TriggerFakeMagnetClass : OscarEnterDetecter
{
    public GameObject magnet;

    protected override void OnOscarEnter()
    {
		magnet.GetComponent<BoxCollider2D> ().enabled = false;
    }
}
