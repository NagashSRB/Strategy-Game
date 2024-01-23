using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float panSpeed = 20f;
    [SerializeField] private float panBorderThickness = 10f;
    [SerializeField] private Vector2 panLimit;

    [SerializeField] private float scrollSpeed = 20f;
    [SerializeField] private float minZ = -10f;
    [SerializeField] private float maxZ = 20f;
    
    
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (/*Input.GetKey("w") ||*/ Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.y += panSpeed * Time.deltaTime;
        }
        if (/*Input.GetKey("s") ||*/ Input.mousePosition.y <= panBorderThickness)
        {
            pos.y -= panSpeed * Time.deltaTime;
        }
        if (/*Input.GetKey("a") ||*/ Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }
        if (/*Input.GetKey("d") ||*/ Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.z -= scroll * scrollSpeed * 100f * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, -panLimit.y, panLimit.y);
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);
        

        transform.position = pos;
    }
}