using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetResolution : MonoBehaviour
{
    [SerializeField] private int _screenSize=800;

    void Awake()
    {
        Screen.SetResolution(_screenSize, _screenSize, false);
    }

   
}
