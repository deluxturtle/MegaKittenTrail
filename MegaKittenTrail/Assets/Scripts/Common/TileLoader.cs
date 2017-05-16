﻿using System.Collections;
using System.Xml;
using UnityEngine;

/// <summary>
/// Author: Andrew Seba
/// Description: Loads the background tiles from the XML
/// </summary>
public class TileLoader : MonoBehaviour
{
    //Holds the .xml
    private TextAsset mapInformation;
    [HideInInspector]
    public int layerWidth;
    [HideInInspector]
    public int layerHeight;
    private Sprite[] sprites;
    

    public void StartLoad()
    {
        //StartCoroutine(LoadMap());
        LoadMap();
    }

    /// <summary>
    /// Sets the textasset xml sheet to the provided sheet.
    /// (Changes the xml sheet to load)
    /// </summary>
    /// <param name="mapInfo"></param>
    public void SetLevel(TextAsset mapInfo)
    {
        mapInformation = mapInfo;
    }

    /// <summary>
    /// Loads the maps in the resources files.
    /// </summary>
    /// <returns></returns>
    void LoadMap()
    {
        //yield return new WaitForEndOfFrame();
        sprites = Resources.LoadAll<Sprite>("MegaKittenTrailSpriteSheet");
        XmlDocument xmlDoc = new XmlDocument();

        xmlDoc.LoadXml(mapInformation.text);
        GameObject block1 = new GameObject("Block1");

        XmlNodeList layerNames = xmlDoc.GetElementsByTagName("layer");

        XmlNode tilesetInfo = xmlDoc.SelectSingleNode("map").SelectSingleNode("tileset");
        float tilewidth = float.Parse(tilesetInfo.Attributes["tilewidth"].Value) / 16f;
        float tileHeight = float.Parse(tilesetInfo.Attributes["tileheight"].Value) / 16f;

        foreach (XmlNode layerInfo in layerNames)
        {
            layerWidth = int.Parse(layerInfo.Attributes["width"].Value);
            layerHeight = int.Parse(layerInfo.Attributes["height"].Value);

            XmlNode tempNode = layerInfo.SelectSingleNode("data");

            int verticalIndex = layerHeight - 1;
            int horizontalIndex = 0;

            foreach (XmlNode tile in tempNode.SelectNodes("tile"))
            {
                int spriteValue = int.Parse(tile.Attributes["gid"].Value);

                //if sprite is not empty
                if (spriteValue > 0)
                {
                    Sprite[] currentSpriteSheet = sprites;

                    GameObject tempSprite = new GameObject(layerInfo.Attributes["name"].Value + " <" + horizontalIndex + ", " + verticalIndex + ">");

                    //Add the tile script here if needed

                    //SpriteRenderer spriteRen = tempSprite.AddComponent<SpriteRenderer>();
                    tempSprite.AddComponent<SpriteRenderer>();
                    //get sprite from sheet
                    //spriteRen.sprite = currentSpriteSheet[spriteValue - 1];
                    tempSprite.GetComponent<SpriteRenderer>().sprite = currentSpriteSheet[spriteValue - 1];

                    //set position
                    tempSprite.transform.position = new Vector3((tilewidth * horizontalIndex), (tileHeight * verticalIndex));
                    //set the sorting layer
                    //spriteRen.sortingLayerName = layerInfo.Attributes["name"].Value;
                    tempSprite.GetComponent<SpriteRenderer>().sortingLayerName = layerInfo.Attributes["name"].Value;

                    //set parent

                    tempSprite.transform.parent = block1.transform;
                    //tempSprite.tag = "Tile";


                }
                horizontalIndex++;
                if(horizontalIndex % layerWidth == 0)
                {
                    verticalIndex--;
                    horizontalIndex = 0;
                }
            }
        }

        GetComponent<GameController>().levelBlocks.Add(block1);
    }
}
