using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PositionsRecorder : MonoBehaviour {

    public Transform recordedObject;
    public List<Vector3> positions = new List<Vector3>();
    public int maxFrameRecord = 200;

    private void Update()
    {
        positions.Add(recordedObject.position);

        if(positions.Count > maxFrameRecord)
        {
            positions.RemoveAt(0);
            positions.RemoveAt(0);
        }
    }

    public List<Vector3> GetRecordedPosition()
    {
        List<Vector3> returnedList = new List<Vector3>();

        for (int i = 0; i < positions.Count; i++)
        {
            returnedList.Add(positions[i]);
        }

        return returnedList;
    }
}
