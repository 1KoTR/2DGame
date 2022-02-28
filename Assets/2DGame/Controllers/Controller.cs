using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    [SerializeField] private protected GameController _gameController = GameController.instance;

    private protected virtual void OnEnable() => _gameController.onUpdate += Execute;
    private protected virtual void OnDisable() => _gameController.onUpdate -= Execute;

    private protected abstract void Execute();
}
