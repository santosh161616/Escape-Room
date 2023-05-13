using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Theif : MonoBehaviour
{
    private float moveSpeed = 10f;
    LineRenderer line;

    PoliceSpawner police;
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
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.position += new Vector3(horizontalInput, verticalInput) * moveSpeed * Time.deltaTime;

        DrawLine();
    }

    public void DrawLine()
    {
        line.SetPosition(0, transform.position);
        line.SetPosition(1, police.BestPath());
    }
}