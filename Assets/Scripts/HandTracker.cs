using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using OculusSampleFramework;

public class HandTracker : MonoBehaviour
{
    public static event Action<bool> OnHandVisible = (isVisible) => { };
    public static event Action<HandTracker> OnInitialized = (h) => { };
    
    new Transform transform;

    List<Hand> hands = new List<Hand>(2);
    bool anyHandVisible;

    public bool AnyHandVisible => anyHandVisible;

    void Awake()
    {
        Hand.OnHandInitialized += StartTrackingHand;
    }

    void OnDestroy()
    {
        Hand.OnHandInitialized -= StartTrackingHand;
    }

    void StartTrackingHand(Hand hand)
    {
        hands.Add(hand);
        
        OnInitialized.Invoke(this);
    }

    void Update()
    {
        for (int i = 0; i < hands.Count; i++)
        {
            var h = hands[i];
            
            if (h.IsTracked && h.Pointer.PointerPosition.y >= 1f)
            {
                if (!anyHandVisible)
                {
                    OnHandVisible.Invoke(true);
                }
                
                anyHandVisible = true;
                return;
            }
        }

        if (anyHandVisible)
        {
            OnHandVisible.Invoke(false);
        }
        
        anyHandVisible = false;
    }
}
