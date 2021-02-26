using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySingleton : MonoBehaviour
{
    private static DifficultySingleton _instance;

    public static DifficultySingleton Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<DifficultySingleton>();
            }

            return _instance;
        }
    }

    private bool isHard = false;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        isHard = false;
    }

    public bool CheckIsHard()
    {
        return isHard;
    }

    public void SetIsHard()
    {
        
        isHard = !isHard;
        Debug.Log(isHard);

    }


}
