using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceSpawner : MonoBehaviour
{   
    [SerializeField] int numberOfPolice = 10;       //Number of police on the scene.
    [SerializeField] float minDistance = 3f;        //Min distance to keep netween each police.

    public float radius = 2f;                       // All police should be spawned from a radius to theif
    public GameObject prefab;                       // holding police prefab.
    public Vector2 center;                          // theif position(center scene)
    Vector2[] totalPositions;                       // Total number of police position.

    float maxDistance = 0f;                         // to hold the maximum distance between police (to find best run route)
    Vector2 midPoint;                               // middle vector position (best run route)
    // Start is called before the first frame update
    void Start()
    {
        totalPositions = new Vector2[numberOfPolice];                                    
    }

    private void Update()
    {

        // Press space to generate random police.
        if (Input.GetKeyDown("space"))
        {
            TotoalNumberPositions();
        }
    }

      
    // Creating total possible random positions.
    public void TotoalNumberPositions()
    {
        Vector2[]  temp = new Vector2[numberOfPolice];
        float distanceVector;        
        float midPointX;
        float midPointY;

        for (int i = 0; i < numberOfPolice; i++)
        {            
            totalPositions[i] = GetRandomPositionOutsideCircle();            
            /*while (Vector2.Distance(temp, totalPositions[i]) <= minDistance)
            {
                totalPositions[i] = GetRandomPositionOutsideCircle();
            }
            temp[i] = totalPositions[i];*/
            for (int j = 0; j < i; j++)
            {
                while(Vector2.Distance(temp[j], totalPositions[i]) <= minDistance)
                {
                    totalPositions[i] = GetRandomPositionOutsideCircle();
                }
                distanceVector = Vector2.Distance(temp[j], totalPositions[i]);

                if(distanceVector > maxDistance)
                {
                    maxDistance = distanceVector;
                    midPointX = (temp[j].x + totalPositions[i].x) / 2;
                    midPointY = (temp[j].y + totalPositions[i].y) / 2;
                     
                    midPoint = new Vector2(midPointX, midPointY);

                    Debug.Log("MidPoint "+ midPoint+ "Distance between j " + temp[j] + "and i" + totalPositions[i] + " " + maxDistance);
                }
                
                temp[j] = totalPositions[i];
            }
            Instantiate(prefab, totalPositions[i], Quaternion.identity);            
        }        
    }


    // Generating a random positions from a radius to the theif.
    Vector2 GetRandomPositionOutsideCircle() {
        Vector2 position = new Vector2(Random.Range(center.x - radius - 1f, center.x + radius + 1f),
                                   Random.Range(center.y - radius - 1f, center.y + radius + 1f));
        while (Vector2.Distance(position, center) <= radius)
        {
            position = new Vector2(Random.Range(center.x - radius - 1f, center.x + radius + 1f),
                                   Random.Range(center.y - radius - 1f, center.y + radius + 1f));
        }
        return position;
    
    }

    public Vector2 BestPath()
    {
        return midPoint;
    }


}

