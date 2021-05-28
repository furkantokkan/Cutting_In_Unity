using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    private bool cutted = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!cutted)
        {
            Cutter.Cut(collision.transform, transform);
            cutted = true;
        }
    }
}
