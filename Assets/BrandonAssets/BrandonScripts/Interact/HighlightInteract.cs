using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightInteract : MonoBehaviour
{

    [SerializeField] private List<Renderer> _renderers;
    [SerializeField] private Color _highlightColor;
    [SerializeField] private Color _wantedColor;

    private List<Material> _materials;



    private void Awake()
    {
        _materials = new List<Material>();
        foreach (var renderer in _renderers)
        {
            _materials.AddRange(new List<Material>(renderer.materials));
        }
    }

    public void ToggleWanted(bool wanted)
    {
        if (wanted)
        {
            foreach (var material in _materials)
            {
                material.EnableKeyword("_EMISSION");
                material.SetColor("_EmissionColor", _wantedColor);
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
   
        
    public void ToggleHighlight(bool val)
    {
        if (val)
        {
            foreach (var material in _materials)
            {
                material.EnableKeyword("_EMISSION");
                material.SetColor("_EmissionColor", _highlightColor);
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

    internal void GetRenderer(List<Renderer> renderers)
    {
        _renderers = renderers;
    }
}
