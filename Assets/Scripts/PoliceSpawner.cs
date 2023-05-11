using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceSpawner : MonoBehaviour
{
    [SerializeField] GameObject police;
    [SerializeField] Transform playerPos;
    [SerializeField] int numberOfPolice = 10;
    [SerializeField] float minDistance = 1f;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GenerateRandomPosition();           
        }
    }

    public void GenerateRandomPosition()
    {
        Vector2[] randomPositions = new Vector2[numberOfPolice];
        for (int i = 0; i < numberOfPolice; i++)
        {
            bool validPosition = false;
            Vector2 newPosition = Vector2.zero;

            while (!validPosition)
            {
                newPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

                // Check if the new position is at least minDistance from all previous positions
                bool distanceValid = true;
                for (int j = 0; j < i; j++)
                {
                    if (Vector2.Distance(newPosition, randomPositions[j]) < minDistance)
                    {
                        distanceValid = false;
                        break;
                    }
                }

                // Check if the new position is different from the predefined position
                bool skipValid = true;
                if (playerPos != null)
                {
                    if (Vector2.Distance(newPosition, playerPos.position) < minDistance)
                    {
                        skipValid = false;
                    }
                }

                validPosition = distanceValid && skipValid;
            }

            randomPositions[i] = newPosition;
            Instantiate(police, randomPositions[i], transform.rotation);
            Debug.DrawLine(playerPos.position, randomPositions[i], Color.green, 10f);
            Debug.Log(randomPositions[i]);
        }                

    }
}
