using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndClickController : MonoBehaviour
{
    public Camera _GameCamera;
    public MyCharacter _GameCharacter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {

            Ray ray = _GameCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray ,out hit,100,LayerMask.GetMask("Ground")))
            {
                Debug.Log(hit.transform.name);
                _GameCharacter.SetTarget(hit.point);
            }
/*
            Vector3 mousePos = Input.mousePosition;

            Vector3 point = _GameCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, _GameCamera.nearClipPlane));

            Vector3 direction = point - _GameCamera.transform.position;

            direction.Normalize();

            RaycastHit hit;

            if (Physics.Raycast(_GameCamera.transform.position, direction, out hit))
            {
                _GameCharacter.SetTarget (hit.point);
                if (hit.collider.gameObject.GetComponent<ClickToHide>())
                {
                    hit.collider.gameObject.GetComponent<ClickToHide>().DoHide();
                }
            }
*/
        }
    }
}
