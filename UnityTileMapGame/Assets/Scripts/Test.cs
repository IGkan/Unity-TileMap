using UnityEngine;

public class Test : MonoBehaviour
{
    float speed = 0.3f;

    bool canMove = true;

    // 要移动到的指定位置
    public Vector3 mTargetPosition = new Vector3 (12.5f,-4.5f,0);

    float mMoveSpeed = 3f;
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position,mTargetPosition, mMoveSpeed * Time.fixedDeltaTime);
        if (Vector3.Distance(transform.position, mTargetPosition) < 0.001f)
        {
            canMove = true;
        }
        if (!canMove) return;
        if (Input.GetKey(KeyCode.W))
        {
            canMove = false;
            mTargetPosition += Vector3.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            canMove = false;
            mTargetPosition += Vector3.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            canMove = false;
            mTargetPosition += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            canMove = false;
            mTargetPosition += Vector3.right;
        }
    }

    }
}
