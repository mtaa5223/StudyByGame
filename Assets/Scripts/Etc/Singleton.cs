using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    private static object _lock = new object();

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    _instance = FindObjectOfType<T>();

                    if (_instance == null)
                    {
                        GameObject singletonObj = new GameObject(typeof(T).Name);
                        _instance = singletonObj.AddComponent<T>();
                        DontDestroyOnLoad(singletonObj);
                    }
                }
            }
            return _instance;
        }
    }
}
