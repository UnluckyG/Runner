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
    [SerializeField] private Transform StartContoler;

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


    [SerializeField] private const float SPAWN_DISTANCE = 150f;



    private void Awake()
    {
        FloorTabSize = FloorsTab.Count;
        ObstaclekTabSize = ObstaclesTab.Count;
        LeftSideObstaclekTabSize = LS_ObstaclesTab.Count;
        RightSideObstaclekTabSize = RS_ObstaclesTab.Count;


        lastFloorPosition = StartContoler.Find("Start_Base_Road").Find("koniecDrogi").position;
        lastObstaclePosition = StartContoler.Find("Obstance_START").position;
        lastLeftSideObstaclePosition = StartContoler.Find("L_START").position;
        lastRightSideObstaclePosition = StartContoler.Find("R_START").position;



        for (int i=0; i < 10; i++)
        {
            spanwFloor();
            spawnLeft();
            spawnRight();
            spawnObstance();
        }

    }

    private void Update() {

        if (Vector3.Distance(player.transform.position , lastFloorPosition) < SPAWN_DISTANCE)
            spanwFloor();
        if (Vector3.Distance(player.transform.position , lastLeftSideObstaclePosition) < SPAWN_DISTANCE)
            spawnLeft();
        if (Vector3.Distance(player.transform.position , lastRightSideObstaclePosition) < SPAWN_DISTANCE)
            spawnRight();
        if (Vector3.Distance(player.transform.position , lastObstaclePosition) < SPAWN_DISTANCE)
            spawnObstance();
        

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
        lastLeftSideObstaclePosition += new Vector3(0f,0f,0f+ Random.Range(40, 150)); 
    }

    private Transform spawnLeft(Vector3 vector)
    {
        int i =  Random.Range(0, LeftSideObstaclekTabSize);
        Transform myPosition =  Instantiate(LS_ObstaclesTab[i], vector, Quaternion.identity);
        return myPosition;
    }

    


    //        <<---->>  RIGHT SIDE   <<---->>
    private void spawnRight()
    {
        Transform lastRightPositionTransform = spawnLeft(lastRightSideObstaclePosition);
        lastRightSideObstaclePosition = lastRightPositionTransform.position;
        lastRightSideObstaclePosition += new Vector3(0f,0f,0f+ Random.Range(40, 150)); 
    }

    private Transform spawnRight(Vector3 vector)
    {
        int i =  Random.Range(0, RightSideObstaclekTabSize);
        Transform myPosition =  Instantiate(RS_ObstaclesTab[i], vector, Quaternion.identity);
        return myPosition;
    }

    

    //        <<---->>  MID  <<---->>
    private void spawnObstance()
    {
        Transform obstancePositionTransform = spawnObstance(lastObstaclePosition);
        lastObstaclePosition = obstancePositionTransform.position;
        lastObstaclePosition += new Vector3(0f,0f,0f+ Random.Range(10, 15)); 
    }

    private Transform spawnObstance(Vector3 vector)
    {
        int i =  Random.Range(0, ObstaclekTabSize);
        Transform myPosition =  Instantiate(ObstaclesTab[i], vector, Quaternion.identity);
        return myPosition;
    }




}