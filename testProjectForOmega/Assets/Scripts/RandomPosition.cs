using UnityEngine;
using System.Collections;

public class RandomPosition : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(RePositionWithDelay());
    }

    IEnumerator RePositionWithDelay()
    {
        while (true)
        {
            SetRandomPosition();
            yield return new WaitForSeconds(3);
        }
    }

    public void SetRandomPosition()
    {
        float x = Random.Range(-9.0f, 9.0f);
        float z = Random.Range(-9.0f, 9.0f);
        transform.position = new Vector3(x, 0, z);
    }
}
