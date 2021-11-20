using UnityEngine;
using System;

//If we try to uncomment [Flags] attribute, TerrainEnumeratorTest will have an unexpected behaviour inside the inspector
//  Try to set it to Desert: it will switch on Grass, Hill and Desert!//[Flags]
// public enum TerrainEnum
// {
//     // Decimal      // Binary
//     None    = 0,    // 000000
//     Grass   = 1,    // 000001
//     Hill    = 2,    // 000010
//     Desert  = 3,    // 000011
//     Forest  = 4     // 000100
// }

[Flags]
public enum TerrainEnum
{
    // Decimal      // Binary
    None,
    Grass,
    Hill,
    Desert,
    Forest,
}

[Flags]
public enum TerrainType
{
    // Decimal      // Binary
    None    = 0,    // 000000
    Grass   = 1,    // 000001
    Hill    = 2,    // 000010
    Desert  = 4,    // 000100
    Forest  = 8     // 001000
}

public class testEnums : MonoBehaviour
{
    public TerrainEnum TerrainEnumeratorTest;
    public TerrainType Terrain;
    public TerrainType TerrainA;
    public TerrainType TerrainB;
    public LayerMask Layers;
    public bool TestTerrainAND, TestTerrainOR;
    public TerrainType TerrainC;

    private void Start()
    {
        //TerrainC = TerrainType.Desert;
        //OR - Add also Hill to TerrainC
        //TerrainC |= TerrainType.Hill;

        //Now TerrainC is Desert + Hill

        //AND - Check TerrainC against Hill
        bool isHill = (TerrainC & TerrainType.Hill) != 0;
        //This is the correct way to check against None value
        bool isNone = TerrainC == TerrainType.None;
        if(isNone)
            Debug.Log("isNone!");
        //This is the wrong way: it will ALWAYS be 0!
        //bool isNone = (TerrainC & TerrainType.None) != 0;

        //NOT - Remove Hill from TerrainC
        TerrainC &= ~TerrainType.Hill;

        //XOR - Toggle Hill (if TerrainC contains Hill turn it to 0, otherwise turn it to 1)
        TerrainC ^= TerrainType.Hill;
    }

    private void Update()
    {
        if (TestTerrainAND)
        {
            //NB: This is a BITWISE AND!
            //This will be TRUE only if TerrainA and TerrainB have the same values of Terrain!
            TestTerrainAND = false;
            Debug.Log("Terrain AND Result: " + (Terrain == (TerrainA & TerrainB)));
        }
        if (TestTerrainOR)
        {
            //NB: This is a BITWISE OR!
            //This will be TRUE only if Terrain has BOTH TerrainA and TerrainB turned ON!
            TestTerrainOR = false;
            Debug.Log("Terrain OR Result: " + (Terrain == (TerrainA | TerrainB)));
        }
    }
}
