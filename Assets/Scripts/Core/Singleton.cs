using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton: MonoBehaviour
{
    public static Singleton Instance
    {
        get
        {
            if (instance == null)
                instance = new Singleton();
            return instance;
        }

        set
        {
            instance = value;
        }
    }

    private static Singleton instance;
}
