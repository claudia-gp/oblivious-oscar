using UnityEngine;

public class CameraFollowOscar : OscarEnterDetecter
{
    public GameObject button;

    protected override void OnOscarEnter()
    {
        Camera.main.transform.SetParent(Oscar.Instance.transform); 
		Oscar.Instance.SetIdle (true);
        button.GetComponent<BoxCollider2D>().enabled = true;
    }
}
