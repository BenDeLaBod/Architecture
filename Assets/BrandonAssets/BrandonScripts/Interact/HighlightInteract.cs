using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightInteract : MonoBehaviour
{

    [SerializeField] private List<Renderer> _renderers;
    [SerializeField] private Color _color = Color.red;

    private List<Material> _materials;



    private void Awake()
    {
        _materials = new List<Material>();
        foreach (var renderer in _renderers)
        {
            _materials.AddRange(new List<Material>(renderer.materials));
        }
    }

   
        
    public void ToggleHighlight(bool val)
    {
        if (val)
        {
            foreach (var material in _materials)
            {
                material.EnableKeyword("_EMISSION");
                material.SetColor("_EmissionColor", _color);
            }
        }
        else
        {
            foreach (var material in _materials)
            {
                material.DisableKeyword("_EMISSION");
            }
        }
    }
}
