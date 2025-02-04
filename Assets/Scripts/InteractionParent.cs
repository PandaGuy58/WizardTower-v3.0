using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractionParent : MonoBehaviour
{
    // the parent of the interaction classes

    public string defaultMessage = "E - Interact";
    public string firstMessage = "E - Interact";
    public string alternateMessage = "Hello!";

    public AudioClip defaultClip;
    [HideInInspector]
    public AudioSource source;

    public bool canActivate = true;

    void Start()
    {
        defaultMessage = firstMessage;
        source = gameObject.GetComponent<AudioSource>();
    }

    public virtual string Communicate()
    {
        return defaultMessage;
    }

    public virtual List<int> Activate(List<int> playerItems)
    {
        if(canActivate)
        {
            canActivate = false;
            if(!source.isPlaying)
            {
                source.PlayOneShot(defaultClip);
            }
            defaultMessage = alternateMessage;
        }
        return playerItems;
    }


    public virtual void ResetState()
    {
        canActivate = true;
        defaultMessage = firstMessage;
    }

}
