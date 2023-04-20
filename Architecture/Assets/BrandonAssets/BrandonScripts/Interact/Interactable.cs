using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Interactable 
{
   public string InteractionPromt { get; }

    public bool Hover(Interactor interactor);
    public bool Interact(Interactor interactor);
  
    
}
