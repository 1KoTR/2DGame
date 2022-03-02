using UnityEngine;

public sealed class GameController : MonoBehaviour
{
    private static GameController _instance;
    public static GameController instance
    {
        get
        {
            if (_instance == null)
            {
                var go = new GameObject($"[{nameof(GameController)}]", typeof(GameController));
                _instance = go.GetComponent<GameController>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }

    public event OnUpdate onUpdate;
    public delegate void OnUpdate();

    private void Update()
    {
        onUpdate?.Invoke();
    }
}
