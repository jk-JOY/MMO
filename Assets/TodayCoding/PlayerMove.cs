using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rigidbody;
    [SerializeField]
    private float speed = 10;
    private float rotSpeed = 5;

    [SerializeField]
    private float jumpHeight = 3f;
    [SerializeField]
    private float dash = 5f;
    private bool isGround = false;
    public LayerMask layer;

    private Vector3 dir = Vector3.zero;

    private void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");
        dir.Normalize(); // 값은 동일하게 만들어주는 벡터의 정규화
        CheckGround();

        if(Input.GetButtonDown("Jump") && isGround)
        {
            Vector3 jumpPower = Vector3.up * jumpHeight;
            rigidbody.AddForce(jumpPower, ForceMode.VelocityChange);
           // jumpPower = Mathf.Log(rigidbody.drag)
        }

        if(Input.GetButtonDown("Dash") )
        {
            Vector3 dashPower = transform.forward * -Mathf.Log(1 / rigidbody.drag) * dash;
            rigidbody.AddForce(dashPower, ForceMode.VelocityChange);

            //Vector3 dashPower = this.transform.forward * dash;
            //rigidbody.AddForce(dashPower, ForceMode.VelocityChange);
        }
    }

    private void FixedUpdate()
    {
        if (dir != Vector3.zero)
        { 
            //지금 바라보는 방향의 부호 != 나아갈 방향의 부호
            if(Mathf.Sign(transform.forward.x) != Mathf.Sign(dir.x) || Mathf.Sign(transform.forward.z) != Mathf.Sign(dir.z))
            {
                transform.Rotate(0,1,0);
            }
                transform.forward = Vector3.Lerp(transform.forward, dir, rotSpeed * Time.deltaTime) ; // 키보드를 누른 방향으로 
        }
        rigidbody.MovePosition(this.gameObject.transform.position + dir * speed * Time.deltaTime);
    }


    void CheckGround()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position +( Vector3.up * 0.2f) , Vector3.down, out hit, 0.4f , layer))
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
    }
}


