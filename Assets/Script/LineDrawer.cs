using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    [SerializeField] private GameObject linePrefab;
    [SerializeField, Range(1f, 5f)] private float threshold;
    [SerializeField] private Color color;
    private Vector3 lastPos;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // the starting point
            lastPos = WorldPosition(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            // next point
            Vector3 currentPos = WorldPosition(Input.mousePosition);
            if ((currentPos - lastPos).magnitude >= threshold)
            {
                Draw(lastPos, currentPos);
                lastPos = currentPos;
            }
        }
    }

    // draws a line between two points
    private void Draw(Vector3 startPos, Vector3 endPos)
    {
        // spawns a square
        GameObject line = Instantiate(linePrefab, (endPos + startPos) * 0.5f, Quaternion.identity, transform);

        // calculates and sets the rotation
        float rotation = Mathf.Atan2(endPos.y - startPos.y, endPos.x - startPos.x) * Mathf.Rad2Deg;
        line.transform.Rotate(Vector3.forward * rotation);

        // calculates and sets the line lenght
        float lenght = (endPos - startPos).magnitude;
        line.transform.localScale = new Vector3(lenght, line.transform.localScale.y, 1f);

        // sets the line color
        line.GetComponent<SpriteRenderer>().color = color;
    }

    private Vector3 WorldPosition(Vector3 screenPosition)
    {
        Vector3 temp = Camera.main.ScreenToWorldPoint(screenPosition);
        return new Vector3(temp.x, temp.y, 0f);
    }
}
