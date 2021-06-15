using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class TailMovement : MonoBehaviour
{
    public float speed = 10;
    public float OnApple = 0.9f;
                       
    public Vector3 tailtarget;
   
    public Transform Target;

    public GameObject tailTargetObj;
    public Snake mainSnake;
    public float RelaxDistance=1.4f;
    void Start ()
    {
        mainSnake = GameObject.FindGameObjectWithTag("SnakeHead").GetComponent<Snake>();
        tailTargetObj = mainSnake.tailObjects[(mainSnake.tailObjects.Count) - 1];
    }
                                            

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnakeHead"))
        {   
            SceneManager.LoadScene("MainMenu");
        }
        if (other.CompareTag("Apple"))
        {
            transform.position  = new Vector3(transform.position.x, OnApple, transform.position.z);
        }
    }

    void Update()
    {
        int i = mainSnake.tailObjects.IndexOf(gameObject);
        tailTargetObj = mainSnake.tailObjects[i-1];                                                    
        Target = tailTargetObj.transform;
        var dir = Target.position - transform.position;
                   
        if (dir.sqrMagnitude > RelaxDistance * RelaxDistance)
        {   
            transform.LookAt(Target);
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, Target.position, step);
        }
    }
}
