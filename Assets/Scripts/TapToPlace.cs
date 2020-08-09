using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TapToPlace : MonoBehaviour
{
    private ARRaycastManager manager;
    private List<ARRaycastHit> hits;
    private bool placed = false;

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
            return;
        }

        this.transform.SetPositionAndRotation(
            Vector3.Lerp(this.transform.position, hits[0].pose.position, 0.8f),
            //hits[0].pose.position,
            hits[0].pose.rotation);

        if (Input.touches.Length <= 0) return;
        Touch touch = Input.GetTouch(0);
        if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
        {
            return;
        }
        if (touch.phase == TouchPhase.Began)
        {
            PlaceObject();
        }

    }

    public void UI_RecalculatePlacement()
    {
        placed = false;
    }

    private void PlaceObject()
    {
        placed = true;
    }
}