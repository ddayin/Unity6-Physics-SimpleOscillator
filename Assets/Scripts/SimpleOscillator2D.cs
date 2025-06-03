using UnityEngine;

namespace Oscillator
{
    public class SimpleOscillator2D : MonoBehaviour
    {
        public Transform pivot;
        private float speed = 2.0f;
        private float angle = 30.0f;
        private float lineLength = 5.0f;
        private Quaternion startQt, endQt;
        public GameObject lineRenderer;
        private LineRenderer[] lrs;
        private float startRot = 0.0f;

        void Start()
        {
            SetInitialPosition();

            float direction = (pivot.position.z < this.transform.position.z) ? 1.0f : -1.0f;

            startQt = getRotateQuaternion(angle * -direction);
            endQt = getRotateQuaternion(angle * direction);

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

            //Debug.Log("pivot.rotation: " + pivot.rotation.eulerAngles);
        }

        public void Set(float angle, float lineLength)
        {
            this.angle = angle;
            this.lineLength = lineLength;
        }

        void SetInitialPosition()
        {
            pivot.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            Vector3 pos = pivot.position + pivot.rotation * new Vector3(0f, -lineLength, 0f);
            this.transform.position = pos;
        }

        void setLineRenderer(LineRenderer lr, Color color)
        {
            lr.startWidth = lr.endWidth = 0.1f;
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