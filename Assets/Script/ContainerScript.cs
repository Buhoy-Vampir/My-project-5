using System;
using UnityEngine;

public class ContainerScript : MonoBehaviour
{
    public GameObject CubePrefab;
    public bool IsCircle = false;
    public bool IsMove = false;
    [SerializeField] private float _speed;
    [SerializeField] private float _x_Speed;
    [SerializeField] private float _angularVelocity;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            IsMove = !IsMove;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            IsCircle = !IsCircle;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spawnCube();
        }
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if (transform.childCount > 0)
            {
                Transform child = transform.GetChild(transform.childCount - 1);
                child.SetParent(null);
                Debug.Log("Всего желтых кубов: " + transform.childCount);
            }
        }
    }

    private void FixedUpdate()
    {
        if (FindObjectOfType<ScriptScene>().IsPlay)
        {
            float x = 0;
            if (Input.GetMouseButton(0))
            {
                IsMove = true;

                x = Input.GetAxis("Mouse X") * _x_Speed;
            }
            if (IsMove)
            {
                Vector3 VectorRelativeToPlayer = transform.TransformVector(new Vector3(x, 0, _speed) * Time.deltaTime);
                transform.Translate(VectorRelativeToPlayer, Space.World);
            }
        }
        if (IsCircle)
        {
            transform.Rotate(0f, _angularVelocity * Time.deltaTime, 0f);

            if (transform.localRotation.eulerAngles.y < 270f)
            {
                transform.rotation = Quaternion.Euler(0f, 270f, 0f);
                IsCircle = false;
            }
        }
    }

    public void spawnCube()
    {
        GameObject _newCube = Instantiate(CubePrefab);
        _newCube.transform.name = Convert.ToString(transform.childCount);
        Transform yellowCube = _newCube.transform;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).localPosition = new Vector3(0f, transform.GetChild(i).localPosition.y, 0f);
            transform.GetChild(i).localPosition += Vector3.up;
        }
        Vector3 vector = transform.GetChild(transform.childCount - 1).position;
        yellowCube.position = new Vector3(vector.x, vector.y - 1, vector.z);
        yellowCube.SetParent(transform);
    }
}
