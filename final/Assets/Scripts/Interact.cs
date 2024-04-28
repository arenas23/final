using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    InteractEvent interact = new();
    Player player;

    public InteractEvent GetInteractEvent
    { 
        get
        { 
            interact ??= new InteractEvent();
            return interact;
        } 
    }

    public Player GetPlayer
    {
        get
        {
            return player;
        }
    }

    public void CallInteract(Player interactedPlayer){
        player = interactedPlayer;
        interact.CallInteractEvet();
    }

}

public class InteractEvent
{
    public delegate void InteractHandler();
    public event InteractHandler HasInteracted;

    public void CallInteractEvet() => HasInteracted?.Invoke();
}