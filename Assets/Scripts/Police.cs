using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police : MonoBehaviour
{
    LineRenderer linePolice;

    private void Start()
    {
        linePolice = GetComponent<LineRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        DrawPoliceLine();   
    }
    
    public void DrawPoliceLine()
    {
        linePolice.SetPosition(0, transform.position);
        linePolice.SetPosition(1, FindObjectOfType<Theif>().transform.position);            
    }
}
