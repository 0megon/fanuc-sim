using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Joints
{
    J1 = 0,
    J2,
    J3,
    J4,
    J5,
    J6,
    J7
}

public class CalculateDistance : MonoBehaviour
{
    private const int jointNumber = 7;

    private GameObject[] joints = new GameObject[jointNumber];
    private GameObject blueCube;
    private GameObject manipBase;
    private float[] xDistance = new float[jointNumber];
    private float[] yDistance = new float[jointNumber];
    private float[] zDistance = new float[jointNumber];
    
    

    // Start is called before the first frame update
    void Start()
    {
        joints[(int)Joints.J1]= GameObject.Find("J1");
        joints[(int)Joints.J2]= GameObject.Find("J2");
        joints[(int)Joints.J3]= GameObject.Find("J3");
        joints[(int)Joints.J4]= GameObject.Find("J4");
        joints[(int)Joints.J5]= GameObject.Find("J5");
        joints[(int)Joints.J6]= GameObject.Find("J6");
        joints[(int)Joints.J7]= GameObject.Find("AnimationEE"); //относится к рабочей точке (шару), J7 называется условно 
        blueCube =  GameObject.Find("CubeBlueOrigin");
        manipBase =  GameObject.Find("J1");


        for(int i = 0; i < jointNumber - 1; ++i)
        {
            xDistance[i] = (joints[i + 1].transform.position.x - joints[i].transform.position.x)/100;
            yDistance[i] = (joints[i + 1].transform.position.y - joints[i].transform.position.y)/100;
            zDistance[i] = (joints[i + 1].transform.position.z - joints[i].transform.position.z)/100;
            Debug.Log("Distance between J" + (i+1) + " and J" + (i + 2) + ": x=" + xDistance[i] + ", y=" + yDistance[i]);// + ", z=" + zDistance[i]);
        }
        Debug.Log("Distance between blue cube and manipulator base origin: x=" 
        + (blueCube.transform.position.x - manipBase.transform.position.x)/100
        + ", y=" + (blueCube.transform.position.y - manipBase.transform.position.y)/100
        + ", z=" + (blueCube.transform.position.z - manipBase.transform.position.z)/100);
        
    }

}
