using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    public GameObject TileGround;
    public GameObject TileGroundTop;
    public GameObject TileFloatingMiddle;
    public GameObject TileFloatingLeftEdge;
    public GameObject TileFloatingRightEdge;
    public GameObject ElevatorUp;
    public GameObject ElevatorDown;
    private float tileScale = 0.25f;
    private float floorHeight = 1.0f;

    Queue<GameObject> tiles = new Queue<GameObject>();
    void Start()
    {
        for(int i = -20; i < 20; i++)
        {
            Instantiate(TileGround, new Vector3(i, -0.6f, 0), Quaternion.identity);
        }
        for(int i = -80; i < 80; i++)
        {
            Instantiate(TileGroundTop, new Vector3(i*tileScale, 0, 0), Quaternion.identity);
        }
        for(int j = 1; j < 8; j++)
        {
            for(int i = -20; i < -14; i++)
            {
                Instantiate((i==-20) ? TileFloatingLeftEdge: TileFloatingMiddle, new Vector3(i * tileScale, floorHeight * j, 0), Quaternion.identity);
            }
            Instantiate(ElevatorUp, new Vector3(-13 * tileScale, floorHeight * j, 0), Quaternion.identity);
            for(int i = -7; i < 7; i++)
            {
                Instantiate(TileFloatingMiddle, new Vector3(i * tileScale, floorHeight * j, 0), Quaternion.identity);
            }
            Instantiate(ElevatorDown, new Vector3(8 * tileScale, floorHeight * j, 0), Quaternion.identity);
            for(int i = 14; i < 20; i++)
            {
                Instantiate((i==19) ? TileFloatingRightEdge : TileFloatingMiddle, new Vector3(i * tileScale, floorHeight * j, 0), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
