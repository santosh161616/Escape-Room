using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Theif : MonoBehaviour
{
    Rigidbody2D rb;
    private float moveSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.position += new Vector3(horizontalInput, verticalInput) * moveSpeed * Time.deltaTime;
    }
}
