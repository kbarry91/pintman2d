using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DestroyObject is used to destroy an object that is unused after a specified amount of time.
public class DestroyObject : MonoBehaviour
{

    public float timeSpan;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeSpan -= Time.deltaTime;

        // Destroy unused object.
        if (timeSpan < 0)
        {
            Destroy(gameObject);
        }
    }
}
