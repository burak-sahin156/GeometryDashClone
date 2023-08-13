using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static volatile T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType(typeof(T)) as T;

            return _instance;
        }
    }
}

public abstract class MonoBehaviourSingletonPersistent<T> : MonoBehaviour where T : Component
{
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = this as T;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
