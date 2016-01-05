using UnityEngine;

public class StopOscarOnTutorial : Tappable
{

    public override void OnClick()
    {
        Oscar oscar = Oscar.Instance;
        oscar.IsAnimationEnabled = true;
        oscar.IsRunning = true;
        oscar.Sprite = oscar.InitialSprite;
        Camera.main.transform.parent = oscar.transform;
    }

    public void OnDrag()
    {
        OnClick();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (OscarEnterDetecter.IsOscar(other.gameObject))
        {
            OscarController.Instance.StopOscarAndSayHi();
        }
    }
	
}
