using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawFloorGrid : MonoBehaviour
{
    public GameObject lineX;
    private List<GameObject> lineXarray;

    // Start is called before the first frame update
    void Start()
    {
        //lineX = GetComponent<LineRenderer>();   
        lineXarray = new List<GameObject>();
        
        for (int i = 0; i < 50; i++)
        {
            GameObject tmpGameObject;
            tmpGameObject = Instantiate(lineX);
            LineRenderer lr = tmpGameObject.GetComponent<LineRenderer>();
            lr.SetPosition(0, new Vector3(lr.GetPosition(0).x, 0, i + 1));
            lr.SetPosition(1, new Vector3(lr.GetPosition(1).x, 0, i + 1));
            tmpGameObject.SetActive(true);
            lineXarray.Add(tmpGameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
