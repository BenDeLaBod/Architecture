using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightSensor : MonoBehaviour
{
    public Transform Player { get; private set; }

    [SerializeField] private LayerMask _ignoreMask;

    private Ray _ray, Aray;

    private void Awake()
    {
        //Player = GameObject.Find("Player1").transform;
        Player = GameObject.FindWithTag("Player").transform;
    }

    public bool Ping()
    {
        if (Player == null)
            return false;

        _ray = new Ray(this.transform.position, Player.position - this.transform.position);

        var dir = new Vector3(_ray.direction.x, 0, _ray.direction.z);

        var angle = Vector3.Angle(dir, this.transform.forward);

        if (angle > 60)
            return false;

        if (!Physics.Raycast(_ray, out var hit, 100, ~_ignoreMask))
        {
            return false;
        }

        if (hit.collider.tag == "Player")
        {
            return true;
        }

        return false;
    }

    public bool DistanceCheck()
    {
        if (Player == null)
            return false;

        Aray = new Ray(this.transform.position, Player.position - this.transform.position);

        var dir = new Vector3(Aray.direction.x, 0, Aray.direction.z);

        var angle = Vector3.Angle(dir, this.transform.forward);
        if (angle > 60)
            return false;

        if (!Physics.Raycast(Aray, out var hit, 100, ~_ignoreMask))
        {
            return false;
        }
        if (Vector3.Distance(this.transform.position, Player.position) < 10 && hit.collider.tag == "Player")
        {
            Debug.Log("In Range");
            return true;
           
        }
        else
            return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_ray.origin, _ray.origin + _ray.direction * 100);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(this.transform.position, this.transform.position + this.transform.forward * 100);
    }
}
