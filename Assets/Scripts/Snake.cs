using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class Snake : MonoBehaviour
{
    public float speed = 10;
    

    public List<GameObject> tailObjects = new List<GameObject>();


    public float z_offset = 0.8f;

    public GameObject TailPreFab;

    [SerializeField] KeyCode keyOne;
    [SerializeField] KeyCode keyTwo;
    [SerializeField] KeyCode keyTree;
    [SerializeField] KeyCode keyFour;

    

    public GameObject HeadSnake;
    int key = 1, InpTime=0;

     void Start ()
     {
        AddTail();
        AddTail();
    }
 
    private void FixedUpdate ()
    {
        
        if (Input.GetKey(keyOne) && (key != 2)&&InpTime==0)
        {
            key = 1;
            InpTime = 10;
        }
        if (Input.GetKey(keyTwo) && (key != 1) && InpTime == 0)
        {
            key = 2;
            InpTime = 10;
        }
        if (Input.GetKey(keyTree) && (key != 4) && InpTime == 0)
        {
            key = 3;
            InpTime = 10;
        }
        if (Input.GetKey(keyFour) && (key != 3) && InpTime == 0)
        {
            key = 4;
            InpTime = 10;
        }
        transform.Translate(new Vector3(0.02f*speed,0,0));
        switch (key)
        {
            case 1:
                transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
                break;
            case 2:
                transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                break;

            case 3:
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                break;
            case 4:
                transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
                break;
        }
        if (InpTime > 0) { InpTime--; }
    }
    public void AddTail()
    {

        Vector3 newTailPos = tailObjects[tailObjects.Count-1].transform.position;
        newTailPos.z -= z_offset;
        
        GameObject clone = GameObject.Instantiate(TailPreFab, newTailPos, Quaternion.identity) as GameObject;
        clone.GetComponent<BoxCollider>().enabled = true;
        TailMovement addComp = clone.AddComponent < TailMovement > ();

        tailObjects.Add(clone);

    }
}