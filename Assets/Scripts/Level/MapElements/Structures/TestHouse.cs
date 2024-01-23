using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHouse : Structure
{
    //TODO: onvalidate u base u structure ako treba za pribavljanje svojih komponenti
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("Collider clicked");
    }
}
