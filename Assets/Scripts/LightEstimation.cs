using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class LightEstimation : MonoBehaviour
{
    [SerializeField] private ARCameraManager camManager = null;

    private Light currentLight = null;

    private void Awake()
    {
        currentLight = this.GetComponent<Light>();
    }

    private void OnEnable()
    {
        camManager.frameReceived += FrameUpdated;
    }

    private void OnDisable()
    {
        camManager.frameReceived -= FrameUpdated;
    }

    private void FrameUpdated(ARCameraFrameEventArgs args)
    {
        if(args.lightEstimation.averageBrightness.HasValue)
        {
            currentLight.intensity = args.lightEstimation.averageBrightness.Value;
        }

        if(args.lightEstimation.averageColorTemperature.HasValue)
        {
            currentLight.colorTemperature = args.lightEstimation.averageColorTemperature.Value;
        }

        if(args.lightEstimation.colorCorrection.HasValue)
        {
            currentLight.color = args.lightEstimation.colorCorrection.Value;
        }
    }
}