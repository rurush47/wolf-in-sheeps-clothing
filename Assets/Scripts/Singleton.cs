using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                CreateInstance();
                if (_instance == null)
                {
                    GameObject obj = new GameObject {name = typeof(T).Name};
                    _instance = obj.AddComponent<T>();
                }
            }
            return _instance;
        }
    }

    private static void CreateInstance()
    {
        _instance = FindObjectOfType<T>();
    }

    public virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}