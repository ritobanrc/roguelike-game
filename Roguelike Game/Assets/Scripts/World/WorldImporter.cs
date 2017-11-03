﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Responsible for importing worlds. Now, that only means generating the world from a pre-defined level image. 
/// </summary>
public class WorldImporter : MonoBehaviour
{
    public static World ImportWorldFromLevelImage(Texture2D texture)
    {
        int width = texture.width;
        int height = texture.height;
        // Get the pixels. To avoid floating point drift, we get the colors as 32 bit integers instead of floats
        Color32[] pixels = texture.GetPixels32();



        World world = new World(width, height);
        return world;
    }
}
