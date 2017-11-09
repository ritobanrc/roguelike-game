﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Will generate GameObjects given a World. 
/// </summary>
public class WorldGameObjectCreator : MonoBehaviour
{
    public GameObject EmptyTilePrefab;
    public Sprite _TEMP_EmptyTileSprite;
    public GameObject EmptyFurniturePrefab;

    public BidirectionalDictionary<GameObject, Tile> TileGameObjectMap = new BidirectionalDictionary<GameObject, Tile>();

    /// <summary>
    /// Given a world, this function with instantiate all the objects for the first time.
    /// </summary>
    /// <param name="world"></param>
    public void CreateWorldGameObjects(World world)
    {
        for (int i = 0; i < world.Width; i++)
        {
            for (int j = 0; j < world.Height; j++)
            {
                Tile t = world.GetTileAt(i, j);
                // Separate Graphics? #5
                // Keeping this here because
                GameObject obj = Instantiate(EmptyTilePrefab, new Vector3(i, j), Quaternion.identity, this.transform);
                obj.name = "Tile (" + i + "," + j + ")";
                TileGameObjectMap.Add(obj, t);
                SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
                sr.sprite = _TEMP_EmptyTileSprite; // Get more tiletypes
                // TODO: I don't like how this is setup. What if we decide to add more stuff to our tile?
                // Shouldn't this be in the Furniture controller?
                if(t.Furniture != null)
                {
                    Sprite s = Resources.Load<Sprite>(t.Furniture.Prototype.ImagePath);
                    Debug.Log(t.Furniture.Prototype.ImagePath);
                    GameObject furnObj = Instantiate(EmptyFurniturePrefab, obj.transform, false);
                    furnObj.GetComponent<SpriteRenderer>().sprite = s;
                    
                }
            }
        }
    }

}
