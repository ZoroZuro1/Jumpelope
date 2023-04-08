using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float jumpPower;
    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriteRenderer;
    public AudioSource jumpEffectAudio;
    bool jump = false;
    public heartM HM;
    public AudioSource aya;


    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
     
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        jump = true;
    }


    void FixedUpdate()
    {
        //Landing Platform
        if (rigid.velocity.y < 0)
        {
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1);
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 0.5f)
                {
                    anim.SetBool("isJumping", false);
                }
            }
        }

    }

    // ���콺�� ������ ���� ����
    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            if (jump && !anim.GetBool("isJumping"))
            {
                jumpEffectAudio.Play();
                rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                anim.SetBool("isJumping", true);
            }
        }
    }


    // rope Ʈ���� �浹
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 9)
        {
            Debug.Log("�� �ɸ�");
          
            OnDamaged();
        }
    }

    // �浹 �ִϸ��̼�
    // ���� -1
    void OnDamaged()
    {
       
        gameObject.layer = 8; // PlayerDamaged
        anim.SetBool("isDamaged", true);
        Life.cnt--;
        aya.Play();
        Invoke("OffDamagedAnim", 0.5f);
        Invoke("OffDamaged", 0.8f);
    }
    
    // �ٽ� Idel �ִϸ��̼����� ���ư�. ��� ��������
    void OffDamagedAnim()
    {
        anim.SetBool("isDamaged", false);
        spriteRenderer.color = new Color(1, 1, 1, 0.5f);

    }

    void OffDamaged()
    {
        gameObject.layer = 7; // Player
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

}
