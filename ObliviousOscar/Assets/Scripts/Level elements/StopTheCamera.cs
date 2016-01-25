using UnityEngine;

public class StopTheCamera : OscarEnterDetecter
{
    protected override void OnOscarEnter()
    {
        Camera.main.transform.parent = null;
    }
}
