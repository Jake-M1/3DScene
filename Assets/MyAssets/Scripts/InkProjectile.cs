using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkProjectile : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody rb;
    public GameObject inkGround;
    public float groundHeight = 0.2501f;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Terrain"))
        {
            Instantiate(inkGround, new Vector3(gameObject.transform.position.x, groundHeight, gameObject.transform.position.z), Quaternion.Euler(new Vector3(-90f, 0f, 0f)));
            Destroy(gameObject);
        }
        else if (other.CompareTag("Crate"))
        {
            other.GetComponent<Crate>().TakeDamage();
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ColorChangeGround(Material newMaterial)
    {
        inkGround.GetComponent<MeshRenderer>().material = newMaterial;
    }
}
