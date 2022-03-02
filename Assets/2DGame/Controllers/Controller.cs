using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    private protected virtual void OnEnable()
    {
        GameController.instance.onUpdate += Execute;
    }
    private protected virtual void OnDisable()
    {
        GameController.instance.onUpdate -= Execute;
    }

    private protected abstract void Execute();
}
