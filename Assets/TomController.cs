using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomController : MonoBehaviour
{
    int BananaAmount = 3;
    int BananasAvailable = 3;
    private Animator animator;
    private Rigidbody rb;
    public Transform SpawnPosition; // переменная для позиции спавна
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

        // если "в животе" есть бананы, при нажатии на пробел 1 банан расходуется на прыжок
        // если нет - анимация отказа

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
         // если есть бананы, кормим кота, иначе он показывает анимацию 

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
