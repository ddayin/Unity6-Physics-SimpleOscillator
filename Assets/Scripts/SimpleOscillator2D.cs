using UnityEngine;

// references : https://bloodstrawberry.tistory.com/1150

namespace Oscillator
{
    public class SimpleOscillator2D : MonoBehaviour
    {
        public Transform pivot;

        /// <summary>
        /// speed of the harmonic oscillator in degrees per second.
        /// </summary>
        public float speed = 2.0f;

        /// <summary>
        /// Represents the angle in degrees.
        /// </summary>
        /// <remarks>The angle is stored as a floating-point value and can represent any valid degree
        /// measurement.</remarks>
        public float angle = 30.0f;

        /// <summary>
        /// Represents the length of a line in units.
        /// </summary>
        public float lineLength = 5.0f;

        Quaternion startQt, endQt;

        public GameObject lineRenderer;
        LineRenderer[] lrs;

        float startRot = 0.0f;

        void Start()
        {
            SetInitialPosition();

            angle = Vector2.Angle(this.transform.position - pivot.position, Vector2.down);
            float dir = (pivot.position.z < this.transform.position.z) ? 1.0f : -1.0f;

            startQt = getRotateQuaternion(0);
            endQt = getRotateQuaternion(2 * angle * dir);

            lrs = lineRenderer.GetComponentsInChildren<LineRenderer>();
            setLineRenderer(lrs[0], Color.blue);
            lrs[0].SetPosition(0, pivot.position);
        }

        void Update()
        {
            lrs[0].SetPosition(1, this.transform.position);
        }

        void FixedUpdate()
        {
            startRot += (Time.fixedDeltaTime * speed);
            pivot.rotation
                = Quaternion.Lerp(startQt, endQt, (Mathf.Sin(startRot - Mathf.PI / 2) + 1.0f) / 2.0f);

            Debug.Log("pivot.rotation: " + pivot.rotation.eulerAngles);
        }

        void SetInitialPosition()
        {
            pivot.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            Vector3 pos = pivot.position + pivot.rotation * new Vector3(0f, -lineLength, 0f);
            this.transform.position = pos;
        }

        void setLineRenderer(LineRenderer lr, Color color)
        {
            lr.startWidth = lr.endWidth = .1f;
            lr.material.color = color;

            lr.positionCount = 2;
        }

        Quaternion getRotateQuaternion(float angle)
        {
            Quaternion current = Quaternion.Euler(new Vector3(0, 0, 0));
            Quaternion quaternion = Quaternion.Euler(new Vector3(0, 0, angle));

            return current * quaternion;
        }
    }
}