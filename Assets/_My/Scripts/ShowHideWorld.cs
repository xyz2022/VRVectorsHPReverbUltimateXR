using System.Collections;
using System.Collections.Generic;
using UltimateXR.Avatar;
using UltimateXR.Core;
using UltimateXR.Devices;
using UnityEngine;

public class ShowHideWorld : MonoBehaviour
{
    public List<GameObject> gameObjects;
    public Material blackSkybox;
    public GameObject invisiblePlane;
    public GameObject terrain;

    private Material previousSkybox;
    private bool showNow;

    private void Start()
    {
        previousSkybox = RenderSettings.skybox;
        showNow = true;
        ShowWorld(showNow);
    }
    private void Update()
    {
        bool thumb = UxrAvatar.LocalAvatarInput.GetButtonsPressDown(UxrHandSide.Left, UxrInputButtons.Button2);
        if (thumb)
        {
            showNow = !showNow;
            ShowWorld(showNow);
        }
    }
    public void ShowWorld(bool show)
    {
        if (!show)
        {
            previousSkybox = RenderSettings.skybox;
            RenderSettings.skybox = blackSkybox;
            
            invisiblePlane.SetActive(true);
            terrain.SetActive(false);
            MeshRenderer mr = invisiblePlane.GetComponent<MeshRenderer>();
            mr.enabled = show;
            //throwableObject.GetComponent<Rigidbody>().isKinematic = true;
        }
        else
        {
            RenderSettings.skybox = previousSkybox;
            terrain.SetActive(true);
            invisiblePlane.SetActive(false);
            MeshRenderer mr = invisiblePlane.GetComponent<MeshRenderer>();
            mr.enabled = show;
            //throwableObject.GetComponent<Rigidbody>().isKinematic = false;
        }

        //for (int i = 0; i < gameObjects.Count; i++)
        //    gameObjects[i].SetActive(show);
        //RenderSettings.skybox = Color.black;

    }
}
