using UnityEngine;
public class UnityChanContorller : MonoBehaviour
{
    Animator animator;
    Vector3 lookDirection;
    public float speed = 1.0f;
    public Manager manager;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float rot = Input.GetAxis("Horizontal");//回転
        float vertical = Input.GetAxis("Vertical");//進行方向
        
        animator.SetFloat("Speed", Mathf.Max(vertical,Mathf.Abs(rot)));
        transform.Rotate(0, rot * 150.0f * Time.deltaTime,0);
        transform.position += transform.forward*vertical*speed*Time.deltaTime;

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
                BoxOpen box = GetComponent<BoxOpen>();
                if (!box.IsOpen())
                {
                    box.Open();
                    if (hit.collider.name == "hit") manager.testOk =true;
                    else manager.testNg = true;
                }
            }
            Debug.DrawRay(ray.origin, ray.direction * 2.0f, Color.red, 1f);
        }
    }
}
