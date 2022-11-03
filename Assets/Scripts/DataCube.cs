using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataCube : MonoBehaviour
{
    private int index = 0;

    private void Awake()
    {
        index = (int)Time.time;
    }

    private void OnBecameVisible()
    {
        
    }
    private void OnBecameInvisible()
    {
        
    }
}
