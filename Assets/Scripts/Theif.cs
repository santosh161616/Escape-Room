using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Theif : MonoBehaviour
{
    private float moveSpeed = 10f;          // Move speed at which theif will run.
    LineRenderer line;                      // Line Rendere reference.
    
    PoliceSpawner police;                   // Police reference to get the call the BestPath() function. 
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 2;
        police = FindAnyObjectByType<PoliceSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        // Using unity's inbuilt move system to move the object in the scene. 
        float horizontalInput = Input.GetAxis("Horizontal"); 
        float verticalInput = Input.GetAxis("Vertical");
        transform.position += new Vector3(horizontalInput, verticalInput) * moveSpeed * Time.deltaTime;

        DrawLine();
    }

    // Drawing a line between the theif position to best run route. 
    public void DrawLine()
    {
        line.SetPosition(0, transform.position);
        line.SetPosition(1, police.BestPath());
    }
}