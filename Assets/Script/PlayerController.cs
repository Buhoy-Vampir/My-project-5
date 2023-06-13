using UnityEngine;

public class PlayerController : MonoBehaviour
{

    /*public bool IsMove = true;
    public float Speed;
    public float X_Speed;
    private Vector3 _normal;
    private Vector3 _directionAlongSurface;


    private void FixedUpdate()
    {
        if (IsMove)
        {
            float _x = 0;
            if (Input.GetMouseButton(0))
            {
                _x = Input.GetAxis("Mouse X") * X_Speed;
            }
            Move(new Vector3(_x, 0, Speed));
        }
    }

    public void Move(Vector3 direction)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        _directionAlongSurface = direction - Vector3.Dot(direction, _normal) * _normal;
        Vector3 offset = _directionAlongSurface * (Speed * Time.deltaTime);
        rb.MovePosition(rb.position + offset);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, transform.position + _normal * 3);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + _directionAlongSurface);

    }*/

}
