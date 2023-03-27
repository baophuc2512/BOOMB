using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowMultiplePlayer : MonoBehaviour
{
    private List<Transform> targets = new List<Transform>();
    private List<Transform> transformPlayers = new List<Transform>();

    public Vector3 offset;
    public float smoothTime = 5f;

    public float minZoom = 10f;
    public float maxZoom = 40f;
    public float zoomLimiter = 50f;

    private Vector3 velocity;
    private Camera cam;

    void Awake()
    {
        cam = GetComponent<Camera>();
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length != targets.Count)
        {
            transformPlayers = new List<Transform>();
            for (int tmp = 0; tmp < players.Length; tmp++)
            {
                transformPlayers.Add(players[tmp].transform);
            }
            targets = transformPlayers;
        }
    }

    void Update()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length != targets.Count)
        {
            transformPlayers = new List<Transform>();
            for (int tmp = 0; tmp < players.Length; tmp++)
            {
                transformPlayers.Add(players[tmp].transform);
            }
            targets = transformPlayers;
        }
    }

    void LateUpdate()
    {
        if (targets.Count == 0 || (transformPlayers.Count != targets.Count) || targets[0].IsDestroyed() == true)
        {
            return;
        }
        Move();
        Zoom();
    }

    void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }

    void Move()
    {
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            if (targets[i].IsDestroyed() == true) return bounds.size.x;
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.size.x;
    }

    Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            if (targets[i].IsDestroyed() == true) return bounds.center;
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.center;
    }
}

public static class ObjectExtensions {
	public static bool IsDestroyed (this UnityEngine.Object obj) {
		return obj == null && !ReferenceEquals (obj, null);
	}
}