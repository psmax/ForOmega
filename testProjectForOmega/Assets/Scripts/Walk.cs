using UnityEngine;
using System.Collections;

public class Walk : MonoBehaviour
{

    public GameObject player;
    public float move_speed;
    public float maxDist;
    public Transform coin;

 //   private Vector3 look_dir;


    void Start()
    {

    }

    void Update()
    {
        transform.LookAt(coin);
        if(Vector3.Distance(transform.position, coin.position) <= maxDist)
        {
            transform.position += transform.forward * move_speed * Time.deltaTime;
        }
    }

 

}