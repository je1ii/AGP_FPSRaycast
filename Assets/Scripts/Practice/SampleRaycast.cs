using UnityEngine;

public class SampleRaycast : MonoBehaviour
{
    [SerializeField] private float dis = 100;
    [SerializeField] private LayerMask layer;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, dis, layer, QueryTriggerInteraction.Ignore))
        {
            MeshRenderer mesh = hit.transform.GetComponent<MeshRenderer>();
            mesh.material.color = Color.red;
            Debug.DrawLine(ray.origin, hit.point, Color.red);
        }
    }
}
