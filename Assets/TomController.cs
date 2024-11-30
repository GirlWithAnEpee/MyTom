using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomController : MonoBehaviour
{
    int BananaAmount = 3;
    int BananasAvailable = 3;
    private Animator animator;
    private Rigidbody rb;
    public Transform SpawnPosition; // ���������� ��� ������� ������
    public GameObject Banana;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        SpawnPosition = GameObject.Find("BananaSpawn").transform;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("AnimNum", 0);

        // ���� "� ������" ���� ������, ��� ������� �� ������ 1 ����� ����������� �� ������
        // ���� ��� - �������� ������

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (BananaAmount == 0)
            {
                animator.SetInteger("AnimNum", 4);
            } else
            {
                animator.SetInteger("AnimNum", 3);
                BananaAmount--;
                rb.AddForce(new Vector3(0, 4, 0), ForceMode.Impulse);
            }
        } 
         // ���� ���� ������, ������ ����, ����� �� ���������� �������� 

        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (BananasAvailable == 0)
            {
                animator.SetInteger("AnimNum", 1);
            } else
            {
                animator.SetInteger("AnimNum", 2);
                BananasAvailable--;
                BananaAmount++;

                var b = Instantiate(Banana, SpawnPosition.position, Banana.transform.rotation);
                Destroy(b, (float)0.35);
            }
        }
    }
}
