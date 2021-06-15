using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTheApple : MonoBehaviour
{
    public float Xsize = 13.3f;

    public float Zsize = 13.3f;

    public GameObject foodPrefab;

    public Vector3 curPos;

    public GameObject curFood;
    

    void AddNewFood()
    {
        RandomPos();
        curFood = GameObject.Instantiate(foodPrefab, curPos, Quaternion.Euler(0, Random.Range(0,180),0 )) as GameObject;
    }
    void RandomPos()
    {
        curPos = new Vector3(Random.Range(Xsize*-1,Xsize),0.1f, Random.Range(Zsize * -1, Zsize));
    }
    private void Update()
    {
        if (!curFood)
        {
            AddNewFood();
        }
        else { return; }
    }                                                 

}
