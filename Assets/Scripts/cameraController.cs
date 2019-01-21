using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public float rotateMultiplier, scrollMultiplier, zoomMultiplier, panMultiplier,
                 zoomMinDistance, zoomMaxDistance;
    private float mousePosX, mousePosY;
    private Vector3 currentAngle;

    void Update()
    {
        cameraRotate();
        cameraZoom();
        cameraPan();
    }

    void cameraRotate()
    {
        //MOVES CAMERA RIGHT AND LEFT
        //using keyboard D and A (or arrow keys)
        if (Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.LeftArrow))
            transform.RotateAround(Vector3.zero, Vector3.up,
                                   rotateMultiplier * Time.deltaTime);
        else if (Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.RightArrow))
            transform.RotateAround(Vector3.zero, Vector3.down,
                                   rotateMultiplier * Time.deltaTime);

        else if (Input.GetKey(KeyCode.Mouse0))
            transform.RotateAround(Vector3.zero, Vector3.up,
                                   2 * rotateMultiplier * Input.GetAxis("Mouse X") * Time.deltaTime);




    }

    void cameraZoom()
    {
        float zoomDistance = Vector3.Distance(Vector3.zero, transform.position);
        //MOVES THE CAMERA FORWARD AND BACKWARD
        //using keyboard W and S (or arrow keys)
        if (Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.UpArrow) && zoomDistance >= zoomMinDistance)
            transform.position = Vector3.MoveTowards(transform.position,
                                                     Vector3.zero,
                                                     zoomMultiplier * Time.deltaTime);
        else if (Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.DownArrow) && zoomDistance <= zoomMaxDistance)
            transform.position = Vector3.MoveTowards(transform.position,
                                                     Vector3.zero,
                                                     -zoomMultiplier * Time.deltaTime);
        //using scroll wheel
        else if (Input.GetKey(KeyCode.W) == false && Input.GetKey(KeyCode.S) == false)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0 && zoomDistance >= zoomMinDistance)
                transform.position = Vector3.MoveTowards(transform.position,
                                                         Vector3.zero,
                                                         zoomMultiplier * scrollMultiplier * Time.deltaTime);
            else if (Input.GetAxis("Mouse ScrollWheel") < 0 && zoomDistance <= zoomMaxDistance)
                transform.position = Vector3.MoveTowards(transform.position,
                                                         Vector3.zero,
                                                         -zoomMultiplier * scrollMultiplier * Time.deltaTime);
        }
    }

    void cameraPan()
    {
        
    }
}
