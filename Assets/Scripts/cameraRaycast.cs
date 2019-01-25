using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRaycast : MonoBehaviour
{

    public Camera[] portalCameras;
    public GameObject[] portals;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // do we hit our portal plane?
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "mainRenderPlane");
            {
                // casts a new ray from the corresponding portalCamera in the same direction
                Ray portalRay = new Ray(portalCameras[GetIndex(hit.collider.gameObject)].transform.position, ray.direction);

                Debug.DrawRay(portalCameras[GetIndex(hit.collider.gameObject)].transform.position, ray.direction);


                RaycastHit portalHit;
                // test these camera coordinates in another raycast test
                if (Physics.Raycast(portalRay, out portalHit))
                {
                    GameObject target = portalHit.collider.gameObject;

                    
                    if(target.GetComponent<customButton>() != null)
                        target.GetComponent<customButton>().OnClick();
                    
                    if(target.GetComponent<cubeLevitation>() != null)
                        target.GetComponent<cubeLevitation>().multiplier += 25;

                }
            }
        }
    }

    int GetIndex(GameObject obj)
    {
        for (int i = 0; i < portals.Length; i++)
        {
            if (portals[i] == obj)
            {
                return i;
            }
        }
        return -1;
    }
}