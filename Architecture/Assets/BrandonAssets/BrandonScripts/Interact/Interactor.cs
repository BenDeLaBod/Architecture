using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interctionPoint;
    [SerializeField] private float _interractionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numColliderFound;
    Collider[] _hoverArray = new Collider[0];

    private void HoverHighlightOff()
    {
        foreach (var hover in _hoverArray)
        {
            hover.GetComponent<HighlightInteract>().ToggleHighlight(false);
        }
    }
    private void HoverHighlightOn()
    {
        foreach (var hover in _hoverArray)
        {
            hover.GetComponent<HighlightInteract>().ToggleHighlight(true);
        }
    }
    private void InteractWithObject()
    {
        if (_numColliderFound > 0)
        {
            var interactable = _colliders[0].GetComponent<Interactable>();
            //If interactable object is found press L to interact
            if (interactable != null && Input.GetKeyDown(KeyCode.L))
            {
                interactable.Interact(this);
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
