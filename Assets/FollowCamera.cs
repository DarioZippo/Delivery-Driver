using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject thingToFollow;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPosition = new Vector3(thingToFollow.transform.position.x, thingToFollow.transform.position.y, this.transform.position.z);
        transform.position = newPosition; // + new Vector3 (0,0,-10);
    }
}
