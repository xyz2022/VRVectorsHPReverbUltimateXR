using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UltimateXR.Avatar;
using UltimateXR.Core;
using UltimateXR.Devices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchWorlds : MonoBehaviour
{
    [System.Serializable]
    public class WorldSetting
    {
        public Material skyboxMat;
        public float gravity;
        public GameObject terrain;
    }

    public List<WorldSetting> worldSetting;
    private int worldIndex;
    private int worldCount;
    //public List
    // Start is called before the first frame update
    void Start()
    {
        worldIndex = 0;
        worldCount = worldSetting.Count;
        if(worldCount > 0)
        {
            RenderSettings.skybox = worldSetting[worldIndex].skyboxMat;
            Physics.gravity = new Vector3(0, worldSetting[worldIndex].gravity, 0);
            Debug.Log(worldSetting[worldIndex].gravity);
            Debug.Log(Physics.gravity);


        }
    }

    // Update is called once per frame
    void Update()
    {
        bool thumb = UxrAvatar.LocalAvatarInput.GetButtonsPressDown(UxrHandSide.Left, UxrInputButtons.Button1);
        if (thumb)
            ActivateNext();
    }

    public void ActivateNext()
    {
        if (worldCount >= 2)//only switch if there are at least 2 worlds
        {
            //disable previous terrain
            worldSetting[worldIndex].terrain.SetActive(false);

            worldIndex++;
            if (worldIndex >= worldCount)
                worldIndex = 0;

            //enable current terrain
            worldSetting[worldIndex].terrain.SetActive(true);

            RenderSettings.skybox = worldSetting[worldIndex].skyboxMat;
            Physics.gravity = new Vector3(0, worldSetting[worldIndex].gravity, 0);
            Debug.Log(worldSetting[worldIndex].gravity);
            Debug.Log(Physics.gravity);
        }
    }
}
