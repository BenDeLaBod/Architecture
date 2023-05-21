using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class DuelUIScript : MonoBehaviour
{
    public static DuelUIScript instance;

    [SerializeField] Image pin;
    float speed;
    Vector2 direction;
    int maxVal, minVal, centreVal;
    bool isStopped;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        maxVal = (int)pin.transform.position.x + 340;
        minVal = (int)pin.transform.position.x;
        centreVal = (int)pin.transform.position.x + 170;
        speed = 500.0f;
        direction = new Vector2(1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStopped && (((pin.transform.position.x > maxVal) && direction.x > 0) || ((pin.transform.position.x < minVal) && direction.x < 0)))
        {
            direction.x *= -1;
        }
    }

    private void FixedUpdate()
    {
        if (!isStopped)
        {
            pin.transform.Translate(direction * speed * Time.fixedDeltaTime);
        }
    }

    public void StoppPin()
    {
        isStopped = true;
    }

    public bool HitOrMiss()
    {

        if (-25 < centreVal - pin.transform.position.x && centreVal - pin.transform.position.x < 25)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
