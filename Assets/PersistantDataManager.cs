using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistantDataManager : MonoBehaviour
{
    public static PersistantDataManager Instance;

    public string PlayerName;
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
