using UnityEngine;
using System.Collections;

public class Triggerboxesfalling : MonoBehaviour
{

    const float GravityScale = 0.3f;

    public GameObject box1, box2, box3;
  
    public float gravityIndex;

    Rigidbody2D rb1, rb2, rb3;

    void Start()
    {
        rb1 = box1.GetComponent<Rigidbody2D>();
        rb2 = box2.GetComponent<Rigidbody2D>();
        rb3 = box3.GetComponent<Rigidbody2D>();
    }

 
    IEnumerator revertGravity()
    {
        yield return new WaitForSeconds(0.5f);
        rb1.gravityScale = rb2.gravityScale = rb3.gravityScale = GravityScale;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Oscar.Tag))
        {
            rb1.isKinematic = rb2.isKinematic = rb3.isKinematic = false;

            rb1.gravityScale = rb2.gravityScale = rb3.gravityScale = gravityIndex;

            StartCoroutine(revertGravity());
        }

    }
}
