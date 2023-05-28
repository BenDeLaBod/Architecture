using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HatScript : MonoBehaviour
{
    public GameObject menu;

    public GameObject[] hats;

    public Vector2 moveInput;

    public TextMeshProUGUI[] options;

    public Color defaultColour, highlightedColour;

    int selectedOption;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            menu.SetActive(!menu.activeInHierarchy);
        }

        if(menu.activeInHierarchy)
        {
            moveInput.x = Input.mousePosition.x - (Screen.width/2);
            moveInput.y = Input.mousePosition.y - (Screen.height/2);
            moveInput.Normalize();

            if (moveInput != Vector2.zero)
            {
                float angle = Mathf.Atan2(moveInput.y, -moveInput.x) / Mathf.PI;
                angle *= 180;
                angle -= 90.0f;
                if (angle < 0)
                {
                    angle += 360.0f;
                }

                for (int i = 0; i < options.Length; i++)
                {
                    if(angle > i * 60 && angle < (i + 1) * 60)
                    {
                        options[i].color = highlightedColour;
                        selectedOption = i;
                    }
                    else
                    {
                        options[i].color = defaultColour;
                    }
                }
            }

            if(Input.GetMouseButtonDown(0))
            {
                SwitchHat(selectedOption);
                menu.SetActive(false);
            }
        }
    }

    void SwitchHat(int index)
    {
        foreach (GameObject hat in hats)
        {
            hat.SetActive(false);
        }

        if (index != 5)
        {
            hats[index].SetActive(true);
        }
    }
}
