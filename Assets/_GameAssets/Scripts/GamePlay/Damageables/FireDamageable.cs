using UnityEngine;

public class FireDamageable : MonoBehaviour, IDamageable
{
    [SerializeField] private float _force = 10f;

    public void GiveDamage(Rigidbody rb, Transform playerVisualTransform)
    {
        HealthManager.Instance.Damage(1);
        rb.AddForce(-playerVisualTransform.forward * _force, ForceMode.Impulse);
        Destroy(gameObject);
    }
}
