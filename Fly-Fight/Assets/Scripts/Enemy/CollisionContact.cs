using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionContact : MonoBehaviour
{
    [SerializeField] private ParticleSystem _colissionParticle;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == Tags.SWORD)
        {
            Instantiate(_colissionParticle, collision.contacts[0].point, Quaternion.identity).Play();
        }
    }
}
