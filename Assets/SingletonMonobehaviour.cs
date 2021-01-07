using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SingletonMonobehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if(_instance==null)
            {
                Type t = typeof(T);

                _instance = (T)FindObjectOfType(t);
            }
            return _instance;
        }
}
    public static bool HasInstance { get { return Instance != null; } }

    virtual protected void Awake()
    {
        if(this != Instance)
        {
            Destroy(this);
            return;
        }
    }

    protected virtual void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }

}
