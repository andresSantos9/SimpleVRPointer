using UnityEngine;

public class PhysicsPointer : MonoBehaviour
{
    public float defaultLenght = 300.0f;

    public LineRenderer lineRenderer = null;

    private void awake()
    {
        //lineRenderer = GetComponent<LineRenderer>();
    }
    private void Update()
    {
        UpdateLenght();
    }

    private void UpdateLenght()
    {
        lineRenderer.SetPosition(0, this.transform.position);
        lineRenderer.SetPosition(1, CalculateEnd());
    }

    private Vector3 CalculateEnd()
    {
        RaycastHit hit = CreateForwardRayCast();
        Vector3 endPosition = DefaultEnd(defaultLenght); 

        if (hit.collider)
        {
            endPosition = hit.point;
        }

        return endPosition;

    }

    private RaycastHit CreateForwardRayCast()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);

        Physics.Raycast(ray, out hit, defaultLenght);

        return hit;

    }

    private Vector3 DefaultEnd(float length)
    {
        return transform.position + (transform.forward*length);
    }



}
