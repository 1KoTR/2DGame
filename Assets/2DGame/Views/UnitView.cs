using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class UnitView : MonoBehaviour
{
    private const string Body = nameof(Body);
    private const string Weapon = nameof(Weapon);

    public GameObject body;
    public GameObject weapon;
    
    public SpriteRenderer bodySpriteRenderer;
    
    private protected virtual void Awake()
    {
        body = transform.Find(Body).gameObject;
        weapon = transform.Find(Weapon).gameObject;

        bodySpriteRenderer = body.GetComponent<SpriteRenderer>();
    }
}
