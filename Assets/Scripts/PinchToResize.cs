using UnityEngine;

public class PinchToResize : MonoBehaviour
{
    [SerializeField] private TouchInput touchInput = null;

    private float scale = 10f;

    private const float MIN_SCALE = 2f;
    private const float MAX_SCALE = 14f;

    private void OnEnable()
    {
        touchInput.pinchAction += OnPinch;
    }

    private void OnDisable()
    {
        touchInput.pinchAction -= OnPinch;
    }

    private void OnPinch(float delta)
    {
        scale -= delta;
        this.transform.localScale = Mathf.Clamp(scale, MIN_SCALE, MAX_SCALE)
                                     * Vector3.one;
    }
}
