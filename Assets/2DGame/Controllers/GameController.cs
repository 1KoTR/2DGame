using UnityEngine;

public sealed class GameController : MonoBehaviour
{
    public static GameController instance;

    public event OnUpdate onUpdate;
    public delegate void OnUpdate();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance == this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        onUpdate?.Invoke();
    }
}
