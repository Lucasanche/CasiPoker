using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ChangeLight : MonoBehaviour
{
    [SerializeField] Light2D Light;
    [SerializeField] LamparitaStates LamparitaState;
    bool doorOpen = false;
    // Update is called once per frame
    void Update()
    {
        if (!doorOpen)
        {
            switch (LamparitaState.mood)
            {
                case "angry":
                    Light.intensity = 2;
                    break;
                case "light":
                    Light.intensity = 1;
                    doorOpen = true;
                    break;
                default:
                    Light.intensity = 0.2f;
                    break;
            }
        }
    }
}
