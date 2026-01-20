using UnityEngine;

public class FireRaycast : MonoBehaviour
{
    [SerializeField] private Camera gameCamera;
    [SerializeField] private Material hitMat;

    private float basePoints = 5f;

    void Update()
    {
        Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.white);
            MeshRenderer mr = hit.transform.GetComponent<MeshRenderer>();

            if (Input.GetMouseButtonDown(0))
            {
                mr.material = hitMat;

                float score = hit.distance * basePoints;
                Debug.Log($"Score: {score}");

                mr.gameObject.SetActive(false);
            }
        }
    }
}
