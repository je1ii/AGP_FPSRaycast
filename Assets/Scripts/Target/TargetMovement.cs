using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float leftMax = -4f;
    [SerializeField] private float rightMax = 4f;

    [SerializeField] private bool rightFirst = true;

    private Vector3 direction;

    private void Start()
    {
        if (rightFirst) direction = Vector3.right;
        else direction = Vector3.left;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if(transform.position.x <= leftMax)
        {
            direction = Vector3.right;
        }
        else if (transform.position.x >= rightMax)
        {
            direction = Vector3.left; 
        }
    }
}
