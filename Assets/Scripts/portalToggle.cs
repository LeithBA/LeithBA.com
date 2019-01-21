using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalToggle : MonoBehaviour
{
    void Update()
    {
		Vector3 localForward = Vector3.zero - transform.position;
        float vectorDot = Vector3.Dot((Camera.main.transform.position - this.transform.position).normalized, localForward);

        if (vectorDot > 0)
        {
            this.GetComponent<BoxCollider>().enabled = true;
        }
        else if (vectorDot < 0)
        {
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
