using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFollowCam : MonoBehaviour
{
    public GameObject _FollowObject;

    public Vector3 _Offset = new Vector3(0.0f,10.0f,-5.0f);

    public float Stiffness = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 RelativePosition = _FollowObject.transform.position- transform.position;

        RelativePosition.Normalize();
        Quaternion qua = Quaternion.LookRotation(RelativePosition, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, qua, Time.deltaTime*Stiffness);

        Vector3 TargetLocation = _FollowObject.transform.position + _Offset;

        transform.position = Vector3.Lerp(transform.position, TargetLocation, Stiffness *Time.deltaTime);
    }
}
