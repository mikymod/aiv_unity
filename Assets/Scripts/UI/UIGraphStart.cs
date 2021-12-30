using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Draws a custom UI Mesh, based on RawValues[]
// [ExecuteInEditMode]
public class UIGraphStart: Graphic
{
    public float[] RawValues;       //Contains values from MinVal to MaxVal
    public Color TopCol, BottomCol;
    public float xStep = 20f;       //Graph x values will start from bottom.left (pivot point), each sample will increase its x by xStep
    public float MinVal = 0;        //min value range of RawValues[]
    public float MaxVal = 100;      //max value range of RawValues[]
    // float t;

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
        var NormValues = new float[RawValues.Length];
        var v = new Vector2[RawValues.Length];

        //RawVal[] Contains values from MinVal to MaxVal
        //Transform RawVal into NormVal [0..1]: 0 will have vRaw.y = 0, 1 will have vRaw.y = GraphPanel.height

        for (int i = 0; i < RawValues.Length; i++)
        {
            var height = transform.parent.GetComponent<RectTransform>().rect.height;
            NormValues[i] = Mathf.InverseLerp(MinVal, MaxVal, RawValues[i]);
            v[i] = new Vector2(xStep * i, NormValues[i] * height);
        }      

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
        for (int i = 1; i < v.Length; i++)
        {
            var bottomLeft = new Vector2(v[i-1].x, 0f);
            var topLeft = new Vector2(v[i-1].x, v[i-1].y);
            var topRight = new Vector2(v[i].x, v[i].y);
            var bottomRight = new Vector2(v[i].x, 0f);

            DrawQuad(vh, bottomLeft, topLeft, topRight, bottomRight);
        }

        for (int i = 1; i < v.Length; i++)
        {

            var bottomLeft = new Vector2(v[i-1].x, v[i-1].y);
            var topLeft = new Vector2(v[i-1].x, v[i-1].y + 10f);
            var topRight = new Vector2(v[i].x, v[i].y + 10f);
            var bottomRight = new Vector2(v[i].x, v[i].y);

            int index = vh.currentVertCount;

            UIVertex vUI0 = UIVertex.simpleVert;
            vUI0.position = bottomLeft;
            vUI0.color = Color.red;
            vh.AddVert(vUI0);

            UIVertex vUI1 = UIVertex.simpleVert;
            vUI1.position = topLeft;
            vUI1.color = Color.red;
            vh.AddVert(vUI1);

            UIVertex vUI2 = UIVertex.simpleVert;
            vUI2.position = topRight;
            vUI2.color = Color.red;
            vh.AddVert(vUI2);

            UIVertex vUI3 = UIVertex.simpleVert;
            vUI3.position = bottomRight;
            vUI3.color = Color.red;
            vh.AddVert(vUI3);

            vh.AddTriangle(index + 0, index + 1, index + 2);
            vh.AddTriangle(index + 2, index + 3, index + 0);
        }
    }

    private void DrawQuad(VertexHelper vh, Vector2 bottomLeft, Vector2 topLeft, Vector2 topRight, Vector2 bottomRight)
    {
        int index = vh.currentVertCount;

        UIVertex vUI0 = UIVertex.simpleVert;
        vUI0.position = bottomLeft;
        vUI0.color = BottomCol;
        vh.AddVert(vUI0);

        UIVertex vUI1 = UIVertex.simpleVert;
        vUI1.position = topLeft;
        vUI1.color = TopCol;
        vh.AddVert(vUI1);

        UIVertex vUI2 = UIVertex.simpleVert;
        vUI2.position = topRight;
        vUI2.color = TopCol;
        vh.AddVert(vUI2);

        UIVertex vUI3 = UIVertex.simpleVert;
        vUI3.position = bottomRight;
        vUI3.color = BottomCol;
        vh.AddVert(vUI3);

        vh.AddTriangle(index + 0, index + 1, index + 2);
        vh.AddTriangle(index + 2, index + 3, index + 0);
    }
}
