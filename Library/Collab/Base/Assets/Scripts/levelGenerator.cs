using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelGenerator : MonoBehaviour
{

    // Tablice
    [SerializeField] private GameObject player;
    [SerializeField] private List <Transform> FloorsTab;
    [SerializeField] private List <Transform> ObstaclesTab;
    [SerializeField] private List <Transform> LS_ObstaclesTab;
    [SerializeField] private List <Transform> RS_ObstaclesTab;

    // Start pozycje
    [SerializeField] private Transform Start_FloorPosition;
    [SerializeField] private Transform Start_ObstaclePosition;
    [SerializeField] private Transform Start_LS_ObstaclePosition;
    [SerializeField] private Transform Start_RightSideObstaclePosition;

    // Last pozycje
    private Vector3 lastFloorPosition;
    private Vector3 lastObstaclePosition;
    private Vector3 lastLeftSideObstaclePosition;
    private Vector3 lastRightSideObstaclePosition;

    // Tab size
    private int FloorTabSize;
    private int ObstaclekTabSize;
    private int LeftSideObstaclekTabSize;
    private int RightSideObstaclekTabSize;


    private const float SPAWN_DISTANCE = 50f;



    private void Awake()
    {
        FloorTabSize = FloorsTab.Count;
        ObstaclekTabSize = ObstaclesTab.Count;
        LeftSideObstaclekTabSize = LS_ObstaclesTab.Count;
        RightSideObstaclekTabSize = RS_ObstaclesTab.Count;

        lastFloorPosition = Start_FloorPosition.Find("koniecDrogi").position;
        lastLeftSideObstaclePosition = Start_LS_ObstaclePosition.position;


        for (int i=0; i < 5; i++)
        {
            spanwFloor();
            spawnLeft();
        }

    }

    private void Update() {

        if (Vector3.Distance(player.transform.position , lastFloorPosition) < SPAWN_DISTANCE)
            spanwFloor();
        if (Vector3.Distance(player.transform.position , lastLeftSideObstaclePosition) < SPAWN_DISTANCE)
            spawnLeft();
        

    }





    //        <<---->>  FLOOR  <<---->>
    private void spanwFloor()
    {
        Transform lastFloorPositionTransform = spanwFloor(lastFloorPosition);
        lastFloorPosition = lastFloorPositionTransform.Find("koniecDrogi").position;
    }
    private Transform spanwFloor(Vector3 vector)
    {
        int i =  Random.Range(0, FloorTabSize);
        Transform myPosition =  Instantiate(FloorsTab[i], vector, Quaternion.identity);
        return myPosition;
    }




    //        <<---->>  LEFT SIDE   <<---->>
    private void spawnLeft()
    {
        Transform lastLeftPositionTransform = spawnLeft(lastLeftSideObstaclePosition);
        lastLeftSideObstaclePosition = lastLeftPositionTransform.position;
        float z = Random.Range(0, 14);
        lastLeftSideObstaclePosition += new Vector3(0f,0f,0f+ Random.Range(40, 150)); 
    }

    private Transform spawnLeft(Vector3 vector)
    {
        int i =  Random.Range(0, LeftSideObstaclekTabSize);
        Transform myPosition =  Instantiate(LS_ObstaclesTab[i], vector, Quaternion.identity);
        return myPosition;
    }




}