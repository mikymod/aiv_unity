using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Draws a custom UI Mesh, based on RawValues[]
[ExecuteInEditMode]
public class UIGraphStart: Graphic
{
    public float[] RawValues;       //Contains values from MinVal to MaxVal
    public Color TopCol, BottomCol;
    float[] NormValues;             //Normalized values [0,1] from RawValues[], based on [MinVal, MaxVal]
    Vector2[] v;                    //UIcoordinates from NormValues[], based on UI RectTransform Width/Height
    float xStep;                    //Graph x values will start from bottom.left (pivot point), each sample will increase its x by xStep
    float xCurrVal;
    float MinVal = 0, MaxVal = 100;    //min/max value range of RawValues[]
    float t;

    //Only for debug
    public Vector2 DebugTLv, DebugTRv, DebugBLv, DebugBRv;

    //Call this method to update the graph
    public void UpdateGraphValues(float[] _RawValues)
    {
        RawValues = _RawValues;
        UpdateGraph();
    }

    public void UpdateGraph()
    {
        SetAllDirty();
    }

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        //RawVal[] Contains values from MinVal to MaxVal
        //Transform RawVal into NormVal [0..1]: 0 will have vRaw.y = 0, 1 will have vRaw.y = GraphPanel.height

        /* Split the graph in adjacent Quads. Every quad has 2 triangles. First quad is:
         * 1_____2
         * |    /|
         * |   / |
         * |  /  |
         * | /   |
         * |/    |
         * 0_____3
         * 
         * Based on: https://docs.unity3d.com/2019.1/Documentation/ScriptReference/UI.Graphic.html
         * Quad Triangles are: 0,1,2; 2,3,0
         */
        vh.Clear();
        UIVertex vUI0 = UIVertex.simpleVert;
        vUI0.position = DebugBLv;
        vUI0.color = Random.ColorHSV();
        UIVertex vUI1 = UIVertex.simpleVert;
        vUI1.position = DebugTLv;
        vUI1.color = Random.ColorHSV();
        UIVertex vUI2 = UIVertex.simpleVert;
        vUI2.position = DebugTRv;
        vUI2.color = Random.ColorHSV();
        UIVertex vUI3 = UIVertex.simpleVert;
        vUI3.position = DebugBRv;
        vUI3.color = Random.ColorHSV();

        //Add 4 vertices to UIMesh
        vh.AddVert(vUI0);
        vh.AddVert(vUI1);
        vh.AddVert(vUI2);
        vh.AddVert(vUI3);

        //Add 2 triangles to UIMesh
        vh.AddTriangle(0, 1, 2);
        vh.AddTriangle(2, 3, 0);
    }
}
