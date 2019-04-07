using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GoogleARCore;

#if UNITY_EDITOR
using input = GoogleARCore.InstantPreviewInput;
#endif

public class ARController : MonoBehaviour
{
    private List<DetectedPlane> newTrackedPlanes = new List<DetectedPlane>();

    public GameObject gridPrefab;
    public GameObject portal;
    public GameObject arCamera;
	// Use this for initialization
	void Start ()
    {
        QuitOnConnectionErrors();
    }

    // Update is called once per frame
    void Update ()
    {
        // The session status must be Tracking in order to access the Frame.
        if (Session.Status != SessionStatus.Tracking)
        {
            int lostTrackingSleepTimeout = 15;
            Screen.sleepTimeout = lostTrackingSleepTimeout;
            return;
        }

        //fills in the plane list from arcore
        Session.GetTrackables<DetectedPlane>(newTrackedPlanes, TrackableQueryFilter.New);

        for(int i = 0; i < newTrackedPlanes.Count; ++i)
        {
            GameObject grid = Instantiate(gridPrefab, Vector3.zero, Quaternion.identity, transform);

            grid.GetComponent<GridVisualizer>().Initialize(newTrackedPlanes[i]);
        }

        //check fro user input
        Touch touch;
        if(Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }
        // check if user touched plnes
        TrackableHit hit;
        if(Frame.Raycast(touch.position.x, touch.position.y, TrackableHitFlags.PlaneWithinPolygon, out hit))
        {
            // place portal
            portal.SetActive(true);
            Anchor anchor = hit.Trackable.CreateAnchor(hit.Pose);
            portal.transform.position = hit.Pose.position;
            portal.transform.rotation = hit.Pose.rotation;

            // face portal
            Vector3 cameraPos = arCamera.transform.position;

            cameraPos.y = hit.Pose.position.y;
            portal.transform.LookAt(cameraPos, portal.transform.up);
            portal.transform.parent = anchor.transform;
        }

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
    void QuitOnConnectionErrors()
    {
        if (Session.Status == SessionStatus.ErrorPermissionNotGranted)
        {
            StartCoroutine(CodelabUtils.ToastAndExit(
                "Camera permission is needed to run this application.", 5));
        }
        else if (Session.Status.IsError())
        {
            // This covers a variety of errors.  See reference for details
            // https://developers.google.com/ar/reference/unity/namespace/GoogleARCore
            StartCoroutine(CodelabUtils.ToastAndExit(
                "ARCore encountered a problem connecting. Please restart the app.", 5));
        }
    }
}
