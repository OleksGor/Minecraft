using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class genWorld : MonoBehaviour
{
    public GameObject grass;
    public GameObject dirt;
    public GameObject rock;
    public GameObject water;
    public GameObject tree;
    public GameObject grass_tile;
    public GameObject flower;
    public GameObject sand;
    public GameObject cactus;
    public GameObject player;
    public float seed;
    public float cy;
    public int waterLevel;
    public float positionz;
    public float positionx;
    public int mapsize;
    public float smoothness;
    public int biomeSize;

    private void genMap(float i, float j)
    {
        if (Mathf.PerlinNoise((player.transform.position.x/200) + seed, (player.transform.position.z/200) + seed)<0.3f)
        {
            //desert
            for (int y = 0; y < 20; y++)
            {
                cy = Mathf.Round(Mathf.PerlinNoise(i / smoothness + seed, j / smoothness + seed) * 10) - y;
                if (y == 0)
                {

                    if (cy <= waterLevel + 1)
                    {
                        
                        for (int w = 0; w < waterLevel + 1 - cy; w++)
                        {
                            GameObject block2 = Instantiate(water);
                            block2.transform.position = new Vector3(i, cy + w + 1, j);
                        }

                        GameObject block = Instantiate(sand);
                        block.transform.position = new Vector3(i, cy, j);
                    }
                    else
                    {
                        if (Mathf.PerlinNoise(i / 2 + seed, j / 2 + seed) <= 0.1)
                        {
                            GameObject block4 = Instantiate(cactus);
                            block4.transform.position = new Vector3(i, cy + 1, j);
                        }
                        GameObject block = Instantiate(sand);
                        block.transform.position = new Vector3(i, cy, j);
                    }

                }
                else if (y < 5)
                {
                    GameObject block = Instantiate(sand);
                    block.transform.position = new Vector3(i, cy, j);
                }
                else
                {
                    if (cy > -6)
                    {
                        GameObject block3 = Instantiate(rock);
                        block3.transform.position = new Vector3(i, cy, j);
                    }
                }
            }
        }
        else  if(Mathf.PerlinNoise((player.transform.position.x / 200) + seed, (player.transform.position.z / 200) + seed) > 0.6f)
        {
            //plains forest
            for (int y = 0; y < 20; y++)
            {
                cy = Mathf.Round(Mathf.PerlinNoise(i / smoothness + seed, j / smoothness + seed) * 10) - y;
                if (y == 0)
                {
                    if (cy <= waterLevel + 1)
                    {

                        for (int w = 0; w < waterLevel + 1 - cy; w++)
                        {
                            GameObject block2 = Instantiate(water);
                            block2.transform.position = new Vector3(i, cy + w + 1, j);
                        }

                        GameObject block = Instantiate(sand);
                        block.transform.position = new Vector3(i, cy, j);
                    }
                    else
                    {
                        if (Mathf.PerlinNoise(i/2 + seed, j/2 + seed) <= 0.1)
                        {
                            GameObject block4 = Instantiate(tree);
                            block4.transform.position = new Vector3(i, cy + 2, j);
                        }
                        else if (Mathf.PerlinNoise(i/2 + seed+1, j/2  + seed+1) <= 0.2)
                        {
                            GameObject block5 = Instantiate(grass_tile);
                            block5.transform.position = new Vector3(i, cy + 1, j);
                        }
                        else if (Mathf.PerlinNoise(i/2 + seed+2, j/2 + seed+2) <= 0.2)
                        {
                            GameObject block5 = Instantiate(flower);
                            block5.transform.position = new Vector3(i, cy + 0.7f, j);
                        }
                        GameObject block = Instantiate(grass);
                        block.transform.position = new Vector3(i, cy, j);
                    }

                }
                else if (y < 5)
                {
                    if (cy + y <= waterLevel + 1)
                    {
                        GameObject block = Instantiate(sand);
                        block.transform.position = new Vector3(i, cy, j);
                    }
                    else
                    {

                        GameObject block2 = Instantiate(dirt);
                        block2.transform.position = new Vector3(i, cy, j);
                    }


                }
                else
                {
                    if (cy > -6)
                    {
                        GameObject block3 = Instantiate(rock);
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
                cy = Mathf.Round(Mathf.PerlinNoise(i / (smoothness/1.5f) + seed, j / (smoothness/1.5f) + seed) * 40) - y;
                if (y == 0)
                {
                    if (cy <= waterLevel + 1)
                    {

                        for (int w = 0; w < waterLevel + 1 - cy; w++)
                        {
                            GameObject block2 = Instantiate(water);
                            block2.transform.position = new Vector3(i, cy + w + 1, j);
                        }

                        GameObject block = Instantiate(sand);
                        block.transform.position = new Vector3(i, cy, j);
                    }
                    else
                    {
                        GameObject block = Instantiate(rock);
                        block.transform.position = new Vector3(i, cy, j);
                    }

                }
                else if (y < 5)
                {
                    if (cy + y <= waterLevel + 1)
                    {
                        GameObject block = Instantiate(sand);
                        block.transform.position = new Vector3(i, cy, j);
                    }
                    else
                    {

                        GameObject block2 = Instantiate(rock);
                        block2.transform.position = new Vector3(i, cy, j);
                    }


                }
                else
                {
                    if (cy > -6)
                    {
                        GameObject block3 = Instantiate(rock);
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
