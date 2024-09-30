using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Cubes
{
    red = 0,
    green,
    blue
}

public class CubeDistCalc : MonoBehaviour
{
    private const int cubeNumber = 3;

    private GameObject[] cubes = new GameObject[cubeNumber];
    private GameObject[] cubeOrigins = new GameObject[cubeNumber];
    private GameObject manipBase;
    private float[] xDistance = new float[cubeNumber];
    private float[] yDistance = new float[cubeNumber];
    private float[] zDistance = new float[cubeNumber];
    
    private float[] xDistanceOrigins = new float[cubeNumber];
    private float[] yDistanceOrigins = new float[cubeNumber];
    private float[] zDistanceOrigins = new float[cubeNumber];

    private string pickCubeColor(int cubeIndex)
    {
        if(cubeIndex == (int)Cubes.red)
            return "red";
        else if(cubeIndex == (int)Cubes.green)
            return "green";
        else if(cubeIndex == (int)Cubes.blue)
            return "blue";
        else return "not a cube";
    }

    void Start()
    {
        cubes[(int)Cubes.red]= GameObject.Find("CubeRed");
        cubes[(int)Cubes.green]= GameObject.Find("CubeGreen");
        cubes[(int)Cubes.blue]= GameObject.Find("CubeBlue");
        
        cubeOrigins[(int)Cubes.red]= GameObject.Find("r");
        cubeOrigins[(int)Cubes.green]= GameObject.Find("g");
        cubeOrigins[(int)Cubes.blue]= GameObject.Find("b");

        manipBase = GameObject.Find("J1");


        for(int i = 0; i < cubeNumber; ++i)
        {
            xDistance[i] = (manipBase.transform.position.x - cubes[i].transform.position.x)/100;
            yDistance[i] = (manipBase.transform.position.y - cubes[i].transform.position.y)/100;
            zDistance[i] = (manipBase.transform.position.z - cubes[i].transform.position.z)/100;
            
            Debug.Log("Distance between manipulator base and " + pickCubeColor(i) + " cube:" + " x=" + xDistance[i] + ", y=" + yDistance[i] + ", z=" + zDistance[i]);

            xDistanceOrigins[i] = (manipBase.transform.position.x - cubeOrigins[i].transform.position.x)/100;
            yDistanceOrigins[i] = (manipBase.transform.position.y - cubeOrigins[i].transform.position.y)/100;
            zDistanceOrigins[i] = (manipBase.transform.position.z - cubeOrigins[i].transform.position.z)/100;

            Debug.Log("Distance between manipulator base and " + pickCubeColor(i) + " origin:" + " x=" + xDistanceOrigins[i] + ", y=" + yDistanceOrigins[i] + ", z=" + zDistanceOrigins[i]);
        }
        
    }

}
