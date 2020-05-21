using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    //private float interpolationModifier;
    private float interpolationMaxVal;
    private float interpolationProgress;

    [SerializeField]//Make private value visible to the editor
    private float maxYPos = 2f;
    [SerializeField]//Make private value visible to the editor
    private float minYPos = -2f;

    private float setYPos;

    private bool travelling = false; public bool isTravelling() { return travelling; }

    private Vector3 startPoint, endPoint;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        interpolationProgress += Time.deltaTime;
        gameObject.transform.position = new Vector3(startPoint.x + ((endPoint.x - startPoint.x) * (interpolationProgress / interpolationMaxVal)), setYPos, 0f);
        if (interpolationProgress > interpolationMaxVal)
            deactivateObstacle();
    }

    public void setStartEndPoints(Vector3 start, Vector3 end, float interpolationMaxVal)
    {
        startPoint = start;
        endPoint = end;
        this.interpolationMaxVal = interpolationMaxVal;
        gameObject.transform.position = endPoint;
        interpolationProgress = interpolationMaxVal;
    }

    public void activateObstacle(float heightDif)
    {
        travelling = true;
        gameObject.transform.localPosition = startPoint;
        //!!!! Not quite working
        setYPos = startPoint.y + minYPos + ((maxYPos - minYPos) * heightDif);//Set radnom height which should mirror its counterpart and remain within its position Y bounds
        interpolationProgress = 0f;
    }

    public void deactivateObstacle()
    {
        travelling = false;
        gameObject.transform.localPosition = endPoint;
    }
}
