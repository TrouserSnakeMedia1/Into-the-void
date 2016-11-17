using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    [SerializeField]
    GameObject target; // what the camera will be following
    [SerializeField]
    Vector3 cameraOffset; //will be able to adjust where the camera sits over the player
	void Update () {
        transform.position = new Vector3(target.transform.position.x + cameraOffset.x , target.transform.position.y + cameraOffset.y, target.transform.position.z +cameraOffset.z); // you are using the targets position plus an offset. the offset will create the distance between the player and the camera
	}
}
