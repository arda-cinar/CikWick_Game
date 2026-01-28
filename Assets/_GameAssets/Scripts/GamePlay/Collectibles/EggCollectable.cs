using UnityEngine;

public class EggCollectable : MonoBehaviour, ICollectible
{
    public void Collect()
    {
        GameManager.Instance.OnEggCollected();
        CameraShake.Instance.ShakeCamera(0.5f, 0.5f);
        AudioManager.Instance.Play(SoundType.PickupGoodSound);
        Destroy(gameObject);
    }
}
