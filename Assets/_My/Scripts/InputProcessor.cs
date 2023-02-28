using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputProcessor : MonoBehaviour
{
    private SwitchWorlds switchWorlds;
    private ShowHideWorld showHideWorld;
    private bool visible;
    // Start is called before the first frame update
    void Start()
    {
        visible = true;
        switchWorlds = gameObject.GetComponent<SwitchWorlds>();
        showHideWorld = gameObject.GetComponent<ShowHideWorld>();
    }

    // Update is called once per frame
    void Update()
    {
        bool switchNow = false;// OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.LTouch);
        if (switchNow)
            switchWorlds.ActivateNext();
        bool showHide = false;// OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch);
        if (showHide)
        {
            visible = !visible;
            showHideWorld.ShowWorld(visible);
        }
    }
}
