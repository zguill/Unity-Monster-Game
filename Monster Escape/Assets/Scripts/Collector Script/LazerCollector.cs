using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerCollector : MonoBehaviour {

    private GameObject[] lazerHolders;
    private float distance = 3.5f;
    private float lastLazerX;
    private float lazerMin = -1.5f;
    private float lazerMax = 1.7f;

    void Awake()
    {
        lazerHolders = GameObject.FindGameObjectsWithTag("LazerHolder");

        for (int i = 0; i < lazerHolders.Length; i++)
        {

            Vector3 temp = lazerHolders[i].transform.position;
            temp.y = Random.Range(lazerMin, lazerMax);
            lazerHolders[i].transform.position = temp;
        }
        lastLazerX =lazerHolders[0].transform.position.x;

        for (int i = 1; i < lazerHolders.Length; i++)
        {
            if (lastLazerX < lazerHolders[i].transform.position.x)
            {
                lastLazerX = lazerHolders[i].transform.position.x;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "LazerHolder")
        {
            Vector3 temp = target.transform.position;

            temp.x = lastLazerX + distance;
            temp.y = Random.Range(lazerMin, lazerMax);

            target.transform.position = temp;

            lastLazerX = temp.x;
        }
    }


}
