using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kudan.AR;
using System.Data;
using UnityEngine.UI;

public class Kudan_Main : MonoBehaviour{

    public GameObject target;
    public GameObject ALU;
    public GameObject IAND;
    public GameObject R2D2;
    public GameObject SpiderTak;

    public KudanTracker kudan_tracker_;
    public TrackingMethodMarker _markerTracking;    // The reference to the marker tracking method that lets the tracker know which method it is using
    public TrackingMethodMarkerless _markerlessTracking;    // The reference to the markerless tracking method that lets the tracker know which method it is using


    public void MarkerClicked()
    {
        kudan_tracker_.ChangeTrackingMethod(_markerTracking);    // Change the current tracking method to marker tracking
    }

    public void MarkerlessClicked()
    {
        kudan_tracker_.ChangeTrackingMethod(_markerlessTracking);    // Change the current tracking method to markerless tracking
    }

    public void Markerless_Start()
    {
        Vector3 floor_position;
        Quaternion floor_orientation;

        kudan_tracker_.FloorPlaceGetPose(out floor_position, out floor_orientation);
        kudan_tracker_.ArbiTrackStart(floor_position, floor_orientation);
    }

    public void Target_Node()
    {
        Vector3 pos;
        Quaternion rot;

        target.gameObject.SetActive(false);

        if (kudan_tracker_.CurrentTrackingMethod == _markerlessTracking && (!ALU.activeInHierarchy
            || !IAND.activeInHierarchy || !R2D2.activeInHierarchy || !SpiderTak.activeInHierarchy))
        {
            target.gameObject.SetActive(true);
        }

        if (target.gameObject.activeSelf)
        {
            kudan_tracker_.FloorPlaceGetPose(out pos, out rot);
            target.transform.position = pos;
            target.transform.Translate(0, -25, 0);
            target.transform.rotation = rot;
        }
    }

}
