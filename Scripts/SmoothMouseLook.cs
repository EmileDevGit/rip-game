using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[AddComponentMenu("Camera-Control/Smooth Mouse Look")]
public class SmoothMouseLook : MonoBehaviour
{
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;

    public float sensitivityX = 4F;
    public float sensitivityY = 4F;

    public float minimumX = -360F;
    public float maximumX = 360F;
    public float minimumY = -60F;
    public float maximumY = 60F;

    public float smoothTime = 5f;

    private float rotationX = 0F;
    private float rotationY = 0F;

    private float currentX = 0F;
    private float currentY = 0F;

    private Quaternion originalRotation;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
            rb.freezeRotation = true;

        originalRotation = transform.localRotation;
    }

    void Update()
    {
        if (axes == RotationAxes.MouseXAndY)
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivityX;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivityY;

            rotationX += mouseX;
            rotationY += mouseY;

            rotationX = ClampAngle(rotationX, minimumX, maximumX);
            rotationY = ClampAngle(rotationY, minimumY, maximumY);

            currentX = Mathf.Lerp(currentX, rotationX, Time.deltaTime * smoothTime);
            currentY = Mathf.Lerp(currentY, rotationY, Time.deltaTime * smoothTime);

            Quaternion xQuaternion = Quaternion.AngleAxis(currentX, Vector3.up);
            Quaternion yQuaternion = Quaternion.AngleAxis(currentY, Vector3.left);

            transform.localRotation = originalRotation * xQuaternion * yQuaternion;
        }
        else if (axes == RotationAxes.MouseX)
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivityX;
            rotationX += mouseX;
            rotationX = ClampAngle(rotationX, minimumX, maximumX);
            currentX = Mathf.Lerp(currentX, rotationX, Time.deltaTime * smoothTime);

            Quaternion xQuaternion = Quaternion.AngleAxis(currentX, Vector3.up);
            transform.localRotation = originalRotation * xQuaternion;
        }
        else // MouseY only
        {
            float mouseY = Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY -= mouseY;
            rotationY = ClampAngle(rotationY, minimumY, maximumY);
            currentY = Mathf.Lerp(currentY, rotationY, Time.deltaTime * smoothTime);

            Quaternion yQuaternion = Quaternion.AngleAxis(-currentY, Vector3.left);
            transform.localRotation = originalRotation * yQuaternion;
        }
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        angle %= 360;
        return Mathf.Clamp(angle, min, max);
    }
}