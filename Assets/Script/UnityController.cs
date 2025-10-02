using UnityEngine;

public class UnityController : MonoBehaviour
{
    Animator animator;
    Vector3 lookDirection;
    public float speed = 1.0f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");//横方向
        float vertical = Input.GetAxis("Vertical");//縦方向
        Vector3 position = transform.position;
        position.x = position.x+speed- horizontal * Time.deltaTime;
        position.z = position.z+speed- vertical * Time.deltaTime;
        transform.position = position;
        animator.SetFloat("Speed", Mathf.Max(position.x,position.z));

        lookDirection = transform.forward;
        if (Input.GetKeyDown(KeyCode.X))
        {
            Ray ray = new Ray(
                transform.position+Vector3.up*0.2f,
                lookDirection
            );
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 2f))
            {
                Debug.Log("当たった相手：" + hit.collider.name);
            }
            Debug.DrawRay(ray.origin, ray.direction * 2.0f, Color.red, 1f);
        }
    }
}
