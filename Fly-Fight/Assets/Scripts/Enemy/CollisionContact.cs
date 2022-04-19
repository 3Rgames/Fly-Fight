using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionContact : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == Tags.SWORD)
        {
            ObjectPooler.Instance.SpawnFromPool(ObjectPooler.Instance.AllTags[0], collision.contacts[0].point, Quaternion.identity).GetComponent<ParticleSystem>().Play();
        }
        if(collision.collider.tag == Tags.HIT)
        {
            ObjectPooler.Instance.SpawnFromPool(ObjectPooler.Instance.AllTags[1], collision.contacts[0].point, Quaternion.identity).GetComponent<ParticleSystem>().Play();
        }
    }
}
