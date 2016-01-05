using UnityEngine;
using System.Collections;

public class TriggerBombsAppearing : OscarEnterDetecter
{
    public GameObject bomb;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = bomb.GetComponent<SpriteRenderer>();
    }

    protected override void OnOscarEnter()
    {
        StartCoroutine(BombsAppear());
    }

    IEnumerator BombsAppear()
    {
        yield return new WaitForSeconds(0.8f);
        spriteRenderer.enabled = true;
    }
}
