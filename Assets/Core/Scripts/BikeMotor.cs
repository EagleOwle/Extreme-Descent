using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeMotor : MonoBehaviour
{
    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private PausableRigidbody2D pausableRigidbody;
    [SerializeField] private float speedDirection = 100;
    [SerializeField] private float speedRotation = 100;

    [Header("Debug")]
    [SerializeField] private Transform ring;
    [SerializeField] private bool enableCentrOfMass;

    private void FixedUpdate()
    {
        rigidbody.AddForce(Vector2.right * InputHandler.Instance.MoveDirection * speedDirection * Time.fixedDeltaTime);
        rigidbody.AddTorque(InputHandler.Instance.UpDirection * speedRotation * Time.fixedDeltaTime);

        if (enableCentrOfMass)
        {
            Vector2 centr = (Vector2)transform.position + rigidbody.centerOfMass;
            ring.position = centr + Vector2.left * InputHandler.Instance.UpDirection;
        }
    }

    public void Sleep()
    {
        pausableRigidbody.Pause();
        enabled = false;
    }

    public void WakeUp()
    {
        pausableRigidbody.Resume();
        enabled = true;
    }
}
