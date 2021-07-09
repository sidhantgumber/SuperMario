using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

  //  public float offsetX;
    private void FixedUpdate()
    {
        float playerXPos = target.position.x;
        float cameraXPos = Mathf.Clamp(playerXPos, 5.23f, 100f);
        transform.position = new Vector3(cameraXPos, 3.06f, -10f);
    }
}
