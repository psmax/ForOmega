using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public GameObject player;
    public float offsetX = 2;
    public float offsetZ = -12;
    public float maxDistance = 2;
    public float playerVelocity = 10;
    public float positionX = 0;
    public float positionY = 20;
    public float positionZ = 0;
    private float movementX;
    private float movementZ;



    // Use this for initialization
    void Start () {
	
	}
    
	// Update is called once per frame
	void Update () {
        movementX = (player.transform.position.x + offsetX - this.transform.position.x) / maxDistance;
        movementZ = (player.transform.position.z + offsetZ - this.transform.position.z) / maxDistance;
        this.transform.position += new Vector3((movementX * playerVelocity * Time.deltaTime), 0,
            (movementZ * playerVelocity * Time.deltaTime)); 


    }
}
