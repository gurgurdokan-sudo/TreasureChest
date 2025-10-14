using System.Collections;
using DG.Tweening;
using UnityEngine;
public class UnityChanController : MonoBehaviour
{
    Animator animator;
    Vector3 lookDirection;
    public float speed = 1.0f;
    public Manager manager;
    public bool isMove = false;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isMove) return;
        float rot = Input.GetAxis("Horizontal");//回転
        float vertical = Input.GetAxis("Vertical");//進行方向

        animator.SetFloat("Speed", Mathf.Max(vertical, Mathf.Abs(rot)));
        transform.Rotate(0, rot * 150.0f * Time.deltaTime, 0);
        transform.position += transform.forward * vertical * speed * Time.deltaTime;

        lookDirection = transform.forward;
        if (Input.GetKeyDown(KeyCode.X))
        {
            Ray ray = new Ray(
                transform.position + Vector3.up * 0.2f,
                lookDirection
            );
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 2f))
            {
                Debug.Log("当たった相手：" + hit.collider.name);
                BoxOpen box = hit.collider.GetComponent<BoxOpen>();
                if (box != null)
                {
                    if (hit.collider.tag == "hit")
                    {
                        manager.currentPlayer = Manager.player.correct;
                    }
                    else
                    {
                        box.Open(true);
                        StartCoroutine(FalseWait());
                        Sequence seq = DOTween.Sequence();
                        seq.AppendInterval(1.0f);
                        seq.Append(transform.DOLocalJump(Vector3.back * 2.5f, 1.0f, 2, 1.0f)
                        .SetRelative());
                        seq.AppendInterval(1.0f);
                        seq.OnComplete(() => manager.currentPlayer = Manager.player.incorrect);
                        seq.Play();
                    }
                }
            }
            Debug.DrawRay(ray.origin, ray.direction * 2.0f, Color.red, 1f);
        }
    }
    IEnumerator FalseWait()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("DownBool", true);
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("DownBool", false);
    }
}
