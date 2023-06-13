using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RedCubeScript : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            float norm = Vector3.Dot(collision.contacts[0].normal, Vector3.back);
            if (norm < -0.5f)
            {
                FindObjectOfType<CubeScript>().IsMove = false;
                Debug.Log("loooooooooooooooooooool");
            }
        }
        if (collision.transform.tag == "PlayerCube")
        {
            if (Vector3.Dot(collision.contacts[0].normal, Vector3.back) < -0.5f)
            {
                collision.transform.tag = "DetachedCube";
                collision.transform.SetParent(null);
            }
            FindObjectOfType<YellowCubeScript>().GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.None;
        }
    }
}
