using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tracker : MonoBehaviour
{

    // -------------------- VARIABLES -------------------- //
    private static Tracker instance;





    // -------------------- FUNCIONES -------------------- //
    public static Tracker Instance { get { return instance; } }


    void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

}
