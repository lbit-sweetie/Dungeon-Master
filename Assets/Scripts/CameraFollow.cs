using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTr;
    public BoxCollider2D mapBounds;
    public float smoothSpeed = 0.5f;

    private float xMin, xMax, yMin, yMax;
    private float camX, camY;
    private float camOrthsize;
    private float cameraRatio;
    private Camera mainCam;
    private Vector3 smoothPos;

    private void Start()
    {
        xMin = mapBounds.bounds.min.x;
        xMax = mapBounds.bounds.max.x;
        yMin = mapBounds.bounds.min.y;
        yMax = mapBounds.bounds.max.y;

        mainCam = GetComponent<Camera>();
        camOrthsize = mainCam.orthographicSize;
        cameraRatio = (xMax + camOrthsize) / 2f;
    }

    private void FixedUpdate()
    {
        camY = Mathf.Clamp(followTr.position.y, yMin + camOrthsize, yMax - camOrthsize);
        camX = Mathf.Clamp(followTr.position.x, xMin + cameraRatio, xMax - cameraRatio);
        smoothPos = Vector3.Lerp(transform.position, new Vector3(camX, camY, transform.position.z), smoothSpeed);
        transform.position = smoothPos;
    }
}