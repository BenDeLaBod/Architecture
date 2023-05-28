using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using TMPro;

public class DuelUIScript : MonoBehaviour
{
    public static DuelUIScript instance;

    [SerializeField] Image pin, bar;
    float speed;
    Vector2 direction;
    int maxVal, minVal, centreVal, winSize;
    bool isStopped;

    [SerializeField] private GameObject _result;
    [SerializeField] private TextMeshProUGUI _duelResultText;
    [SerializeField] private GameObject _returnButton;
    //private SceneSwitchScript _sceneManager;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        _result.SetActive(false);
        _returnButton.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        centreVal = (int)pin.transform.position.x;
        maxVal = centreVal + (int)bar.sprite.rect.width;
        minVal = centreVal - (int)bar.sprite.rect.width;
        winSize = (int)bar.sprite.rect.width / 6;
        speed = 500.0f;
        direction = new Vector2(1, 0);
       // _sceneManager = GameObject.Find("Scene Manager").GetComponent<SceneSwitchScript>();
        
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

    public void StopPin()
    {
        isStopped = true;
    }

    public bool HitOrMiss()
    {
        StartCoroutine(DelayResultText(3));
        if (-winSize < centreVal - pin.transform.position.x && centreVal - pin.transform.position.x < winSize)
        {
            _duelResultText.text = "Victory";
            SceneSwitchScript.duelWon = true;
            return true;
        }
        else
        {         
            _duelResultText.text = "Lose";
            SceneSwitchScript.duelWon = false;
            return false;
        }


    }

    private IEnumerator DelayResultText(float duration)
    {
        yield return new WaitForSeconds(duration);
        _result.SetActive(true);
        yield return new WaitForSeconds(duration);
        _returnButton.SetActive(true);
    }
}
