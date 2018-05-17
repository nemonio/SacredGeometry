using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Generator : MonoBehaviour {

    public GameObject atomPrefab;

    public List<GameObject> atomList;

    public int numberOfAtoms = 100;

    public float scaleFactor = 100;

    public float speed=120; 


    public float angle_incr;

    public float ratio;

    // Use this for initialization
    void Start () {

        angle_incr = 2 * Mathf.PI / numberOfAtoms;

        for (int i = 1; i <= numberOfAtoms; ++i)
        {
            GameObject myAtom = Instantiate(atomPrefab);
            atomList.Add(myAtom);

            ratio = i / (float)numberOfAtoms;
            float spiral_rad = ratio * scaleFactor;
            float angle = i * angle_incr;
            float x = transform.position.x + Mathf.Cos(angle) * spiral_rad;
            float y = transform.position.y + Mathf.Sin(angle) * spiral_rad;

            myAtom.transform.position = new Vector3(x, y, transform.position.z);
            myAtom.transform.SetParent(transform);
            // draw tiny circle at x,y
            //ellipse(x, y, sm_diameter, sm_diameter);
        }

    }
	
	// Update is called once per frame
	void Update () {

        //float elapsedSeconds = millis() * .001;
        angle_incr = Mathf.Deg2Rad * (2f + Time.frameCount / speed);

        //float cx = 100 / 2;
        //float cy = 100 / 2;

        //float sm_diameter = 4;

        for (int i = 1; i <= atomList.Count; ++i)
        {
            

            float ratio = i / (float)numberOfAtoms;
            float spiral_rad = ratio * scaleFactor;
            float angle = i * angle_incr;
            float x = transform.position.x + Mathf.Cos(angle) * spiral_rad;
            float y = transform.position.y + Mathf.Sin(angle) * spiral_rad;

            atomList[i-1].transform.position = new Vector3(x, y, transform.position.z);

            // draw tiny circle at x,y
            //ellipse(x, y, sm_diameter, sm_diameter);
        }

    }

    


}
