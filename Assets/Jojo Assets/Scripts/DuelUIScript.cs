using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class DuelUIScript : MonoBehaviour
{
    public static DuelUIScript instance;

    [SerializeField] Image pin, bar;
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
        centreVal = (int)pin.transform.position.x;
        maxVal = centreVal + (int)bar.sprite.rect.xMax / 2;
        minVal = centreVal - (int)bar.sprite.rect.xMax / 2;
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

        Debug.Log(minVal + ", " + maxVal + ", " + pin.transform.position.x);
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
