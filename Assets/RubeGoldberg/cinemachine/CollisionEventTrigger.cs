using UnityEngine;
using UnityEngine.Events;

public class CollisionEventTrigger : MonoBehaviour
{
    public bool isOneShot = false;
    private bool _isTriggered = false;
    // UnityEvent allows you to set up any function to be triggered in the Unity Editor
    public UnityEvent onCollisionEvent;

    // This function is automatically called by Unity when the GameObject collides with something
    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleCollision();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HandleCollision();
    }

    void HandleCollision()
    {
        Debug.Log("Trigger activated");
        if((isOneShot && !_isTriggered) || !isOneShot)
        {
            // Trigger the event
            onCollisionEvent.Invoke();
        }

        _isTriggered = true;
    }
}
