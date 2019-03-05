using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class genWorld : MonoBehaviour
{
    public GameObject player;
    public float seed;
    public float cy;
    public int waterLevel;
    public float positionz;
    public float positionx;
    public int mapsize;
    public int biomeSize;

    private void genMap(float i, float j)
    {
        if (Mathf.PerlinNoise((player.transform.position.x/200) + seed, (player.transform.position.z/200) + seed)<=0.2f)
        {
            //desert
            for (int y = 0; y < 20; y++)
            {
                cy = Mathf.Round(Mathf.PerlinNoise(i / 20 + seed, j / 20 + seed) * 10) - y;
                if (y == 0)
                {

                    if (cy <= waterLevel + 1)
                    {
                        
                        for (int w = 0; w < waterLevel + 1 - cy; w++)
                        {
                            GameObject block2 = Instantiate(blocks.block["Water"]);
                            block2.transform.position = new Vector3(i, cy + w + 1, j);
                        }

                        GameObject block = Instantiate(blocks.block["Sand"]);
                        block.transform.position = new Vector3(i, cy, j);
                    }
                    else
                    {
                        if (Mathf.PerlinNoise(i / 2 + seed, j / 2 + seed) <= 0.1)
                        {
                            GameObject block4 = Instantiate(blocks.block["Cactus"]);
                            block4.transform.position = new Vector3(i, cy + 1, j);
                        }
                        GameObject block = Instantiate(blocks.block["Sand"]);
                        block.transform.position = new Vector3(i, cy, j);
                    }

                }
                else if (y < 5)
                {
                    GameObject block = Instantiate(blocks.block["Sand"]);
                    block.transform.position = new Vector3(i, cy, j);
                }
                else
                {
                    if (cy > -6)
                    {
                        GameObject block3 = Instantiate(blocks.block["Stone"]);
                        block3.transform.position = new Vector3(i, cy, j);
                    }
                }
            }
        }
        else  if(Mathf.PerlinNoise((player.transform.position.x / 200) + seed, (player.transform.position.z / 200) + seed) > 0.2f)
        {
            //plains forest
            for (int y = 0; y < 20; y++)
            {
                cy = Mathf.Round(Mathf.PerlinNoise(i / 20 + seed, j / 20 + seed) * 10) - y;
                if (y == 0)
                {
                    if (cy <= waterLevel + 1)
                    {

                        for (int w = 0; w < waterLevel + 1 - cy; w++)
                        {
                            GameObject block2 = Instantiate(blocks.block["Water"]);
                            block2.transform.position = new Vector3(i, cy + w + 1, j);
                        }

                        GameObject block = Instantiate(blocks.block["Sand"]);
                        block.transform.position = new Vector3(i, cy, j);
                    }
                    else
                    {
                        if (Mathf.PerlinNoise(i/2 + seed, j/2 + seed) <= 0.1)
                        {
                            GameObject block4 = Instantiate(blocks.block["Tree"]);
                            block4.transform.position = new Vector3(i, cy + 2, j);
                        }
                        else if (Mathf.PerlinNoise(i/2 + seed+1, j/2  + seed+1) <= 0.2)
                        {
                            GameObject block5 = Instantiate(blocks.block["Grass_Tile"]);
                            block5.transform.position = new Vector3(i, cy + 1, j);
                        }
                        else if (Mathf.PerlinNoise(i/2 + seed+2, j/2 + seed+2) <= 0.2)
                        {
                            GameObject block5 = Instantiate(blocks.block["Flower"]);
                            block5.transform.position = new Vector3(i, cy + 0.7f, j);
                        }
                        GameObject block = Instantiate(blocks.block["Grass"]);
                        block.transform.position = new Vector3(i, cy, j);
                    }

                }
                else if (y < 5)
                {
                    if (cy + y <= waterLevel + 1)
                    {
                        GameObject block = Instantiate(blocks.block["Sand"]);
                        block.transform.position = new Vector3(i, cy, j);
                    }
                    else
                    {

                        GameObject block2 = Instantiate(blocks.block["Dirt"]);
                        block2.transform.position = new Vector3(i, cy, j);
                    }


                }
                else
                {
                    if (cy > -6)
                    {
                        GameObject block3 = Instantiate(blocks.block["Stone"]);
                        block3.transform.position = new Vector3(i, cy, j);
                    }
                }
            }
        }
        else
        {
            //mountains
            for (int y = 0; y < 20; y++)
            {
                cy = Mathf.Round(Mathf.PerlinNoise(i / 20 + seed, j / 20 + seed) * 40) - y;
                if (y == 0)
                {
                    if (cy <= waterLevel + 1)
                    {

                        for (int w = 0; w < waterLevel + 1 - cy; w++)
                        {
                            GameObject block2 = Instantiate(blocks.block["Water"]);
                            block2.transform.position = new Vector3(i, cy + w + 1, j);
                        }

                        GameObject block = Instantiate(blocks.block["Sand"]);
                        block.transform.position = new Vector3(i, cy, j);
                    }
                    else
                    {
                        GameObject block = Instantiate(blocks.block["Stone"]);
                        block.transform.position = new Vector3(i, cy, j);
                    }

                }
                else if (y < 5)
                {
                    if (cy + y <= waterLevel + 1)
                    {
                        GameObject block = Instantiate(blocks.block["Sand"]);
                        block.transform.position = new Vector3(i, cy, j);
                    }
                    else
                    {

                        GameObject block2 = Instantiate(blocks.block["Stone"]);
                        block2.transform.position = new Vector3(i, cy, j);
                    }


                }
                else
                {
                    if (cy > -6)
                    {
                        GameObject block3 = Instantiate(blocks.block["Stone"]);
                        block3.transform.position = new Vector3(i, cy, j);
                    }
                }
            }
        }
        
    }
    void Start()
    {
        positionz = Mathf.Round(player.transform.position.z);
        positionx = Mathf.Round(player.transform.position.x);
        seed = Random.Range(0.0f, 10000.0f);
        for (int i = 0; i < mapsize; i++)
        {
            for (int j = 0; j < mapsize; j++)
            {
                genMap(i, j);
            }
        }
    }
    private void Update()
    {
        if ((player.transform.position.x  - positionx) >= 1)
        {
            positionx = Mathf.Round(player.transform.position.x);
            for (float i = Mathf.Round(player.transform.position.x) + Mathf.Round(mapsize/2) - 1; i < Mathf.Round(player.transform.position.x) + Mathf.Round(mapsize / 2); i++)
            {
                for (float j = Mathf.Round(player.transform.position.z) - Mathf.Round(mapsize / 2) - 1; j < Mathf.Round(player.transform.position.z) + Mathf.Round(mapsize / 2) + 1; j++)
                {
                    genMap(i, j);
                }
            }
        }
        if ((player.transform.position.x - positionx) <= -1)
        {
            positionx = Mathf.Round(player.transform.position.x);
            for (float i = Mathf.Round(player.transform.position.x)- Mathf.Round(mapsize / 2); i > Mathf.Round(player.transform.position.x) - Mathf.Round(mapsize / 2)- 1; i--)
            {
                for (float j = Mathf.Round(player.transform.position.z) - Mathf.Round(mapsize / 2) - 1; j < Mathf.Round(player.transform.position.z)  + Mathf.Round(mapsize / 2) + 1; j++)
                {
                    genMap(i, j);
                }
            }
        }
        if ((player.transform.position.z - positionz) >= 1)
        {
            positionz = Mathf.Round(player.transform.position.z);
            for (float i = Mathf.Round(player.transform.position.x)- Mathf.Round(mapsize / 2) - 1; i < Mathf.Round(player.transform.position.x) + Mathf.Round(mapsize / 2) + 1; i++)
            {
                for (float j = Mathf.Round(player.transform.position.z) + Mathf.Round(mapsize / 2) - 1; j < Mathf.Round(player.transform.position.z) + Mathf.Round(mapsize / 2); j++)
                {
                    genMap(i, j);
                }
            }
        }
        if ((player.transform.position.z - positionz) <= - 1)
        {
            positionz = Mathf.Round(player.transform.position.z);
            for (float i = Mathf.Round(player.transform.position.x) - Mathf.Round(mapsize / 2) - 1; i < Mathf.Round(player.transform.position.x) + Mathf.Round(mapsize / 2) + 1; i++)
            {
                for (float j = Mathf.Round(player.transform.position.z)  - Mathf.Round(mapsize / 2); j > Mathf.Round(player.transform.position.z) - Mathf.Round(mapsize / 2) - 1; j--)
                {
                    genMap(i, j);
                }
            }
        }
    }
}
