using System.Collections;
using System.Xml;
using UnityEngine;

/// <summary>
/// Author: Andrew Seba
/// Description: Loads the background tiles from the XML
/// </summary>
public class TileLoader : MonoBehaviour
{
    //Holds the .xml
    public TextAsset mapInformation;
    //Temp tile obj.
    public GameObject tempCube;
    private Sprite[] sprites;

    // Use this for initialization
    void Start()
    {
        sprites = Resources.LoadAll<Sprite>("MegaKittenTrailSpriteSheet copy");
        XmlDocument xmlDoc = new XmlDocument();
    }
}
