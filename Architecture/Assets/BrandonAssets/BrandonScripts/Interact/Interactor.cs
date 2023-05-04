using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interctionPoint;
    [SerializeField] private float _interractionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;
    [SerializeField] private InteractionPromptUI _interactionPromptUI;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numColliderFound;
    Collider[] _hoverArray = new Collider[0];

    private Interactable _interactable;

    /// <summary>
    /// Toggle all highlights off
    /// </summary>
    private void HoverHighlightOff()
    {
        foreach (var hover in _hoverArray)
        {
            if (hover != null)
            {
                hover.GetComponent<HighlightInteract>().ToggleHighlight(false);
            }
        }
    }
    /// <summary>
    /// Toggle all highlights on
    /// </summary>
    private void HoverHighlightOn()
    {
        foreach (var hover in _hoverArray)
        {
            hover.GetComponent<HighlightInteract>().ToggleHighlight(true);
        }
    }

    /// <summary>
    /// If there are any colliders within the Shere area and interact promt is 
    /// not displayed display interaction promt, Press L to interact with object.
    /// 
    /// If no collider is found make interactable null and turn off display
    /// </summary>
    private void InteractWithObject()
    {
        if (_numColliderFound > 0)
        {
            _interactable = _colliders[0].GetComponent<Interactable>();
            //If interactable object is found press L to interact
            if (_interactable != null /*&& Input.GetKeyDown(KeyCode.L)*/)
            {
                if (!_interactionPromptUI.isDisplayed)
                {
                    _interactionPromptUI.SetUp(_interactable.InteractionPromt);
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    _interactable.Interact(this);
                    
                }
            }
        }
        else
        {
            if(_interactable != null)
            {
                _interactable = null;
            }
            if (_interactionPromptUI.isDisplayed)
            {
                _interactionPromptUI.ClosePanel();
            }
        }
    }
    private void Update()
    {
        //Start point, area, check colliders, mask
        _numColliderFound = Physics.OverlapSphereNonAlloc(_interctionPoint.position, 
                            _interractionPointRadius, _colliders, _interactableMask);

        HoverHighlightOff();
        _hoverArray = Physics.OverlapSphere(_interctionPoint.position, _interractionPointRadius,_interactableMask);
        HoverHighlightOn();
        InteractWithObject();
       
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interctionPoint.position, _interractionPointRadius);
    }

    
}
