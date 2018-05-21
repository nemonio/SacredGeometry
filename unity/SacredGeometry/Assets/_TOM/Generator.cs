using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Generator : MonoBehaviour {

    public float angle_incr;

    public float scaleFactor;


    public GameObject atomPrefab;

    public List<GameObject> atomList;

    public int numberOfAtoms = 100;



    public float initialScale = 1.6f;
    public float scaleInterval = 1f;  // Amount to move left and right from the start point
    public float scaleSpeed = 2.0f;


    public float initialAngleIncr = 1.6f;
    public float oscilationInterval = 1f;  // Amount to move left and right from the start point
    public float oscilationSpeed = 2.0f;

    // Use this for initialization
    void Start () {

        for (int i = 1; i <= numberOfAtoms; ++i)
        {
            GameObject myAtom = Instantiate(atomPrefab);
            atomList.Add(myAtom);
            myAtom.transform.SetParent(transform);

        }

    }



    // Update is called once per frame
    void Update () {



   
        angle_incr = initialAngleIncr;
        angle_incr += oscilationInterval * Mathf.Sin(Time.time * oscilationSpeed);

        scaleFactor = initialScale;
        scaleFactor += scaleInterval * Mathf.Sin(Time.time * scaleSpeed);



        for (int i = 1; i <= atomList.Count; ++i)
        {
            

            float ratio = i / (float)numberOfAtoms;
            float spiral_rad = ratio * scaleFactor;
            float angle = i * angle_incr;
            float x =  + Mathf.Cos(angle) * spiral_rad;
            float y =  + Mathf.Sin(angle) * spiral_rad;

            float z =  + Mathf.Atan(angle) * spiral_rad;


            atomList[i-1].transform.localPosition = new Vector3(x, y, z);


        }

    }

    


}
