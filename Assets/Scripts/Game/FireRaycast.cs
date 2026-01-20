using Unity.Mathematics.Geometry;
using UnityEngine;

public class FireRaycast : MonoBehaviour
{
    [SerializeField] private Camera gameCamera;
    [SerializeField] private ScoreText scoreText;
    [SerializeField] private LayerMask layer;

    private float basePoints = 5f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layer, QueryTriggerInteraction.Ignore))
            {
                if(hit.transform.gameObject.CompareTag("Target"))
                {
                    float score = hit.distance * basePoints;
                    Debug.Log($"Score: {score}");
                    
                    scoreText.AddScore(score);
                    hit.transform.gameObject.SetActive(false);
                }
            }
        }
        
        Debug.DrawRay(gameCamera.transform.position, gameCamera.transform.forward * 100, Color.white);
    }
}
