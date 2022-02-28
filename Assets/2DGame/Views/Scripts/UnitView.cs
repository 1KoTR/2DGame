using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class UnitView : View
{
    public GameObject body;
    
    public SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = body.GetComponent<SpriteRenderer>();
    }
}
