using UnityEngine;

public class TriggerFakeMagnetClass : MonoBehaviour
{

    public GameObject magnet;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Oscar.Tag))
        {
            Destroy(magnet.GetComponent<TappableMagnet>());
        }

    }
}
