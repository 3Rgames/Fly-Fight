using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBalancer : MonoBehaviour
{
    [SerializeField] private List<Rigidbody> _bodyParts = new List<Rigidbody>();
    [SerializeField] private float _movementYGravityValue = 18f;
    [SerializeField] private float _distanceMultiplayer = 2f;

    public void Balance(Vector3 movementVelocity, Vector3 centerPoint)
    {
        _bodyParts.ForEach(rigidbody =>
        {
            Vector3 velocity = Vector3.Scale(movementVelocity, new Vector3(-1, 0, -1));
            velocity.y = _movementYGravityValue;

            rigidbody.AddForce(velocity * (Vector3.Distance(rigidbody.position, centerPoint) * _distanceMultiplayer),
                ForceMode.Acceleration);
        });
    }
}
