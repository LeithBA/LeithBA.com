using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeLevitation : MonoBehaviour
{
    public float  amplitude, frequency;
    public Vector3 degreesPerSecond;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();
    public float multiplier = 1;
    float lerpValue;


    void Start()
    {
        posOffset = transform.position;
		amplitude *= Random.Range(.5f, 1.5f);
        degreesPerSecond = new Vector3(degreesPerSecond.x * Random.Range(-1.5f, 1.5f), 
                                       degreesPerSecond.y * Random.Range(-1.5f, 1.5f),
                                       degreesPerSecond.z * Random.Range(-1.5f, 1.5f));
    }

    void Update()
    {
        multiplier = Mathf.Lerp(multiplier, 1, Mathf.Pow(multiplier, 2)/100000);
        transform.Rotate(new Vector3(Time.deltaTime * multiplier * degreesPerSecond.x,
                                     Time.deltaTime * multiplier * degreesPerSecond.y,
                                     Time.deltaTime * multiplier * degreesPerSecond.z),
                                     Space.World);

        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }
}
