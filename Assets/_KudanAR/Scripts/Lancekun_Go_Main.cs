using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kudan.AR;
using System.Data;
public class Lancekun_Go_Main : MonoBehaviour{

    public KudanTracker kudan_tracker_;
    public void Test()
    {
        Vector3 floor_position;
        Quaternion floor_orientation;

        kudan_tracker_.FloorPlaceGetPose(out floor_position, out floor_orientation);
        kudan_tracker_.ArbiTrackStart(floor_position, floor_orientation);
    }
}
