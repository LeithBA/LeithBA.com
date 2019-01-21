using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalCamerasController : MonoBehaviour {

	public Transform cameraMain, worldMain, worldLocal;
	void Update () 
	{
		Vector3 cameraMainOffset = cameraMain.position - worldMain.position;
		transform.position = worldLocal.position + cameraMainOffset;

		float portalAngularDifference = Quaternion.Angle(worldLocal.rotation, worldMain.rotation);
		Quaternion portalRotationalDifference = Quaternion.AngleAxis(portalAngularDifference, Vector3.up);
		Vector3 newCameraDirection = portalRotationalDifference * cameraMain.forward;
		transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);

		
	}
}
