using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceSpawner : MonoBehaviour
{   
    [SerializeField] int numberOfPolice = 10;
    [SerializeField] float minDistance = 1f;

    public float radius = 2f;    
    public GameObject prefab;
    public Vector2 center;
    Vector2[] totalPositions; 

    // Start is called before the first frame update
    void Start()
    {
        totalPositions = new Vector2[numberOfPolice];
        TotoalPositions();                             
    }

    public void TotoalPositions()
    {
        for (int i = 0; i < numberOfPolice; i++)
        {                        
            totalPositions[i] = GetRandomPositionOutsideCircle();
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
}

