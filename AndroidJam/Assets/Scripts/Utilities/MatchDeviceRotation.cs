using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{

    public class MatchDeviceRotation : MonoBehaviour
    {
        public float softRotationSpeed = 20f;
        public float hardRotationSpeed = 80f;
        public float angleSoftTreshold = 2f;
        public float angleHardTreshold = 10f;

        void Update()
        {
            Quaternion oldRot = transform.rotation;
            Vector3 inputProjection = Vector3.ProjectOnPlane(-Input.acceleration, Vector3.forward).normalized;
            float angle = Mathf.Rad2Deg * Mathf.Atan(inputProjection.y / inputProjection.x);
            angle = Mathf.Sign(angle) * Mathematiques.Map(Mathf.Abs(angle), 90, 0, 0, 90);
            Quaternion newRot = Quaternion.Euler(0, 0, angle);
            if (Quaternion.Angle(oldRot, newRot) > angleHardTreshold)
                transform.rotation = Quaternion.RotateTowards(oldRot, newRot, hardRotationSpeed * Time.deltaTime);
            else if (Quaternion.Angle(oldRot, newRot) > angleSoftTreshold)
                transform.rotation = Quaternion.RotateTowards(oldRot, newRot, softRotationSpeed * Time.deltaTime);
        }
    }
}
