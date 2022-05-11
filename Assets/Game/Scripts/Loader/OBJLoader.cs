using Dummiesman;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KYapp.Loader
{
    public static class OBJLoader
    {
        public static GameObject LoadGameObject(string Path, string mtlPath)
        {
            GameObject loadedObj = new Dummiesman.OBJLoader().Load(Path, mtlPath);
            loadedObj.SetActive(false);

            return loadedObj;
        }
        public static (Mesh,Material[])[] Load_MeshMaterial(string Path,string mtlPath)
        {
            GameObject loadedObj = LoadGameObject(Path, mtlPath);

            List<Mesh> meshes = new List<Mesh>();
            List<Material[]> materials = new List<Material[]>();

            foreach (Transform item in loadedObj.transform)
            {
                meshes.Add(item.gameObject.GetComponent<MeshFilter>().mesh);
                materials.Add(item.gameObject.GetComponent<MeshRenderer>().materials);
            }

            List<(Mesh, Material[])> returnT = new List<(Mesh, Material[])>();

            for (int i = 0; i < meshes.Count; i++)
            {
                returnT.Add((meshes[i], materials[i]));
            }

            return returnT.ToArray();
        }
    }
}
