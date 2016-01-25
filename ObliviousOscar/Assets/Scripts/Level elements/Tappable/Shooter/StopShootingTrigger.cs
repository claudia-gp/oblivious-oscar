using UnityEngine;

public class StopShootingTrigger : OscarEnterDetecter
{
    public GameObject shooter;

    protected override void OnOscarEnter()
    {
        shooter.GetComponent<ShootAPlayerInRange>().isShooting = false;
    }
}
