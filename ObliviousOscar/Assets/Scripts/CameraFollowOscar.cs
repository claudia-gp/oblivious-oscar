using UnityEngine;

public class CameraFollowOscar : OscarEnterDetecter
{
    public GameObject button;

    protected override void OnOscarEnter()
    {
        Camera.main.transform.SetParent(Oscar.Instance.transform); 
        OscarController.Instance.StopOscarAndSayHi();
        button.GetComponent<BoxCollider2D>().enabled = true;
    }
}
