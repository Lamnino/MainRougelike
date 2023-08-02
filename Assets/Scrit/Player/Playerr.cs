using System.Collections;
using UnityEngine;

public class Playerr : MonoBehaviour
{
    public static Playerr instance;
    private Rigidbody2D rb;

    [SerializeField] private float timeJump;
    [SerializeField] private float falltime;
    [SerializeField] private float jumptime;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private int IsWall = 0;
    [SerializeField] public int curdir = 1;
    [SerializeField] private int dir = 1;

    [SerializeField] private bool allowRorateR = true;
    [SerializeField] private bool allowRorateL = true;
    [SerializeField] private bool isGround = true;
    [SerializeField] private bool allowspace = true;
    [SerializeField] private bool allowDash = false;
    [SerializeField] private bool isDash = false;
    [SerializeField] public bool allowAttack = true;
    [SerializeField] public  bool isAttack = false;
    [SerializeField] public bool Attacking = false;

    [SerializeField] public Animator animator;
    [SerializeField] private Transform cam;


    void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            if (allowDash && curdir != IsWall && !isDash)
            {
                inputdash();
            }
        }
        else allowDash = true;
        if (isDash)
        {
            Move();
        }
        else
        {
            inputmove();
            inputjump();
            inputattack();
        }
        SetAnimator();
    }
    private void SetAnimator()
    {
        animator.SetBool("IsJump", isGround);
        animator.SetFloat("yvelocity", rb.velocity.y);
        animator.SetBool("IsDash", isDash);
        animator.SetBool("IsAttack", isAttack);
    }
    private void inputdash()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(curdir * 0.4f, -0.3f, 0), new Vector2(curdir, 0), 3f);
        //RaycastHit2D hitt = Physics2D.Raycast(transform.position + new Vector3(1 * 0.4f, 0.3f, 0), new Vector2(1, 0), 3f);
        float distance = 4f;
        if (hit.collider != null)
        {
            distance = hit.distance;
        }
        StartCoroutine(dash(distance));
        allowDash = false;
    }
    private void inputmove()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && IsWall != -1 )
        {
            allowRorateR = true;
            if (allowRorateL)
            {
                if (!Attacking)
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    allowRorateL = false;
                    dir = 1;
                }
                else
                {
                    if (curdir == 1)
                    dir = -1;
                }
            }
            Move();
            animator.SetTrigger("WalkRight");
            curdir = -1;
        }
        else
            if (Input.GetKey(KeyCode.RightArrow) && IsWall != 1 )
            {
            allowRorateL = true;
            if (allowRorateR)
            {
                if (!Attacking)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    allowRorateR = false;
                    dir = 1;
                }
                else
                {
                    if (curdir == -1)
                        dir = -1;
                }
            }
            Move();
            animator.SetTrigger("WalkRight");
            curdir = 1;
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetTrigger("Idle");
            allowRorateL = true;
            allowRorateR = true;
        }
    }
    private void inputjump()
    {
        if (isGround)
        {
            allowspace = true;
            jumptime = 0;
            falltime = 0;
        }
        if (jumptime < timeJump)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                rb.velocity = new(rb.velocity.x, jumpForce);
                jumptime += Time.deltaTime;
            }
            else
            {
                jumptime = 3;
                falltime += Time.deltaTime;
                float v = 1.5f + 15 * falltime;
                rb.velocity = new(rb.velocity.x,- v);
            }
        }
    }  
        
        
    private void inputattack()
    {
        if (Input.GetKey(KeyCode.X) && !isAttack)
        {
            if (allowAttack)
            {
                isAttack = true;
                allowAttack = false;
            }
        }
        else
        {
            allowAttack = true;
        }
    } 
    private void Move()
    {
            //transform.Translate(new Vector2(dir, 0) * speed * Time.deltaTime);
        rb.velocity = new Vector2(curdir * speed, rb.velocity.y);
    }
    private void FixedUpdate()
    {
        cam.position = Vector3.Lerp(cam.position, transform.position + new Vector3(0,0, -10), 7f * Time.deltaTime);
        checkWallisGround();
    }
    private void checkWallisGround()
    {
        RaycastHit2D hitR = Physics2D.Raycast(transform.position + new Vector3(0.42f, -0.3f, 0), new Vector2(1, 0), 0.1f);
        RaycastHit2D hitRR = Physics2D.Raycast(transform.position + new Vector3(0.42f, 0.35f, 0), new Vector2(1, 0), 0.1f);
        RaycastHit2D hitLL = Physics2D.Raycast(transform.position + new Vector3(-0.42f, 0.3f, 0), new Vector2(-1, 0), 0.1f);
        RaycastHit2D hitL = Physics2D.Raycast(transform.position + new Vector3(-0.42f, -0.3f, 0), new Vector2(-1, 0), 0.1f);
        if (hitR.collider != null || hitRR.collider != null) IsWall = 1;
        else
        if (hitL.collider != null || hitLL.collider != null) IsWall = -1; else IsWall = 0;
        RaycastHit2D hit1 = Physics2D.Raycast(transform.position + new Vector3(0.3f, -0.47f, 0), new Vector3(0, -1), 0.1f);
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position + new Vector3(-0.3f, -0.47f, 0), new Vector3(0, -1), 0.1f);
        if (hit1.collider != null || hit2.collider != null) isGround = true;
        else isGround = false;
    }
    IEnumerator dash(float distance)
    {
        float moveDistance = 0;
        speed = 15f;
        isDash = true;
        while (moveDistance < distance)
        {
            moveDistance += speed * Time.deltaTime;
            if (moveDistance < distance)
                yield return null;
        }
        speed = 5f;
        isDash = false;
    }
}

