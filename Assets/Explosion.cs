using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private SphereCollider coll;

    public float explosionForce = 250f;

    void Start()
    {
        coll = GetComponent<SphereCollider>();

        StartCoroutine(Delete());
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rbody = other.GetComponent<Rigidbody>();
        if (rbody != null)
        {
            rbody.AddExplosionForce(
                explosionForce, gameObject.transform.position,
                coll.radius, 0.3f, ForceMode.Impulse);
        }
    }

    private IEnumerator Delete()
    {
        yield return new WaitForFixedUpdate();
        Destroy(gameObject);
    }
}
