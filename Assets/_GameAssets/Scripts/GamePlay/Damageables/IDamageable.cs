using UnityEngine;

public interface IDamageable
{
    void GiveDamage(Rigidbody rb, Transform playerVisualTransform);
}
