using System.Collections;
using UnityEngine;

public class PausableRigidbody2D : MonoBehaviour
{
    private Vector3 _pausedVelocity;
    private float _pausedAngularVelocity;
    private Rigidbody2D _rigidBody2D;

    void Awake()
    {
        _rigidBody2D = this.GetComponent<Rigidbody2D>();
    }

    public void Pause()
    {
        Debug.Log("Pause with velocity=" + _rigidBody2D.velocity + " & angularVelocity=" + _rigidBody2D.angularVelocity);
        _pausedVelocity = _rigidBody2D.velocity;
        _pausedAngularVelocity = _rigidBody2D.angularVelocity;
        _rigidBody2D.bodyType = RigidbodyType2D.Static;
    }

    public void Resume()
    {
        _rigidBody2D.bodyType = RigidbodyType2D.Dynamic;
        _rigidBody2D.velocity = _pausedVelocity;
        _rigidBody2D.angularVelocity = _pausedAngularVelocity;
        Debug.Log("Resume with velocity=" + _rigidBody2D.velocity + " &    angularVelocity=" + _rigidBody2D.angularVelocity);
    }
}