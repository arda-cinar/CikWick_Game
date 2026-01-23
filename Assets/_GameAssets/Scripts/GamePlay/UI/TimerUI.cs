using DG.Tweening;
using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private RectTransform _timerRotatableTransform;
    [SerializeField] private TMP_Text _timerText;

    [Header("References")]
    [SerializeField] private float _rotationDuration;
    [SerializeField] private Ease _rotationEase;

    private float _elpasedTime;

    private void Start()
    {
        PlayerRotationAnimation();
        StartTimer();
    }

    private void PlayerRotationAnimation()
    {
        _timerRotatableTransform.DORotate(new Vector3(0f, 0f, -360f), _rotationDuration, RotateMode.FastBeyond360)
            .SetLoops(-1, LoopType.Restart)
            .SetEase(_rotationEase);
    }

    private void StartTimer()
    {
        _elpasedTime = 0f;
        InvokeRepeating(nameof(UpdateTimerUI), 0f, 1f);
    }

    private void UpdateTimerUI()
    {
        _elpasedTime += 1f;

        int minutes = Mathf.FloorToInt(_elpasedTime / 60f);
        int seconds = Mathf.FloorToInt(_elpasedTime % 60f);
        _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
