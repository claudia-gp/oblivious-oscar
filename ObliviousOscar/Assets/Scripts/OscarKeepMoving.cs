using UnityEngine;
using System.Collections;

public class OscarKeepMoving : OscarEnterDetecter
{
    protected override void OnOscarEnter()
    {
        StartCoroutine(KeepMoving());
    }

    IEnumerator KeepMoving()
    {
        yield return new WaitForSeconds(1);
        OscarController.Instance.ReverseDirection();
    }
}
