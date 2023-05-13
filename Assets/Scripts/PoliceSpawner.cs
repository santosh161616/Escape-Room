using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceSpawner : MonoBehaviour
{   
    [SerializeField] int numberOfPolice = 10;
    [SerializeField] float minDistance = 3f;

    public float radius = 2f;    
    public GameObject prefab;
    public Vector2 center;
    Vector2[] totalPositions;

    float maxDistance = 0f;
    Vector2 midPoint;
    // Start is called before the first frame update
    void Start()
    {
        totalPositions = new Vector2[numberOfPolice];                                    
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            TotoalNumberPositions();
        }
    }

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

