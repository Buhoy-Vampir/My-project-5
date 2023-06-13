using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public GameObject CubePrefab;
    public bool IsMove = true;
    public bool IsCircle = false;
    [SerializeField] private float _speed;
    [SerializeField] private float _x_Speed;
    [SerializeField] private Vector3 _normal;
    [SerializeField] private Vector3 _directionAlongSurface;
    [SerializeField] private float _angularVelocity;
    [SerializeField] private float _normal123;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (transform.childCount > 0)
            {
                /*Transform yellowCube = transform.GetChild(transform.childCount - 1).transform;
                yellowCube.SetParent(null);*/
                FindObjectOfType<YellowCubeScript>().GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.FreezePositionY;
            }
            Debug.Log("Всего желтых кубов: " + transform.childCount);
        }
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if (transform.childCount > 0)
            {
                /*Transform yellowCube = transform.GetChild(transform.childCount - 1).transform;
                yellowCube.SetParent(null);*/
                FindObjectOfType<YellowCubeScript>().GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.None;
            }
            Debug.Log("Всего желтых кубов: " + transform.childCount);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            IsMove = !IsMove;
            Debug.Log("Всего желтых кубов: " + transform.childCount);
        }
        if (IsCircle)
        {
            transform.Rotate(0f, _angularVelocity * Time.deltaTime, 0f);

            if (transform.eulerAngles.y < 270)
            {
                // Куб достиг нужного угла поворота
                transform.rotation = Quaternion.Euler(0f, -90f, 0f);
                IsCircle = false; // Останавливаем движение
            }
        }
    }

    private void FixedUpdate()
    {
        if (IsMove)
        {
            float _x = 0;
            if (Input.GetMouseButton(0))
            {
                _x = Input.GetAxis("Mouse X") * _x_Speed;
            }
            Move(new Vector3(_x, 0, _speed));
        }
    }

    public void Move(Vector3 direction)
    {
        Rigidbody rb = transform.GetComponent<Rigidbody>();
        _directionAlongSurface = direction.normalized - Vector3.Dot(direction.normalized, _normal) * _normal;
        Vector3 offset = transform.TransformVector(direction * (_speed * Time.deltaTime));
        rb.MovePosition(rb.position + offset);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, transform.position + _normal * 3);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + _directionAlongSurface);

    }

    private void OnCollisionEnter(Collision collision)
    {
        _normal = collision.contacts[0].normal;
      
        switch (collision.gameObject.tag)
        {
            case "YellowCube":
            collision.transform.tag = "Player";
            Destroy(collision.gameObject);
            spawnCube();
                break;
            case "Turn":
                IsCircle = true; 
                 break;
            default:
                break;
        }
    }

    public void spawnCube()
    {
        GameObject _newCube = Instantiate(CubePrefab);
        _newCube.transform.tag = "PlayerCube";
        _newCube.transform.name = "Cube" + transform.childCount;
        Transform yellowCube = _newCube.transform;
        yellowCube.SetParent(transform);
        transform.position += Vector3.up;
        for (int i = 0; i < transform.childCount; i++)
        {
            yellowCube.localPosition = Vector3.down * transform.childCount;
        }
    }
}
