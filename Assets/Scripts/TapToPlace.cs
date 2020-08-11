using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TapToPlace : MonoBehaviour
{
    [HideInInspector] public bool placed = false;

    [SerializeField] private GameObject pedestalPrefab = null;

    private ARRaycastManager manager;
    private List<ARRaycastHit> hits;
    private SetPedestalAndModel latestPedestal;

    private readonly Vector2 centreOfScreen = 0.5f * new Vector2(Screen.width, Screen.height);

    private void Awake()
    {
        manager = FindObjectOfType<ARRaycastManager>();
        hits = new List<ARRaycastHit>();
    }

    private void Update()
    {
        if (placed) return;

        if (!manager.Raycast(centreOfScreen, hits, TrackableType.Planes))
        {
            this.transform.position = 100f * Vector3.back;
            return;
        }

        this.transform.SetPositionAndRotation(
            Vector3.Lerp(this.transform.position, hits[0].pose.position, 0.8f),
            //hits[0].pose.position,
            hits[0].pose.rotation);

        if (Input.touches.Length <= 0) return;
        Touch touch = Input.GetTouch(0);
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(touch.fingerId))
        {
            return;
        }
        if (touch.phase == TouchPhase.Began)
        {
            PlaceObject();
        }

    }

    public void RecalculatePlacement()
    {
        placed = false;
        this.GetComponent<Renderer>().enabled = true;

    }

    public SetPedestalAndModel GetLatestPedestal()
    {
        return latestPedestal;
    }

    private void PlaceObject()
    {
        latestPedestal = Instantiate(pedestalPrefab, this.transform.position, this.transform.rotation).GetComponent<SetPedestalAndModel>();
        placed = true;
        this.GetComponent<Renderer>().enabled = false;
    }
}