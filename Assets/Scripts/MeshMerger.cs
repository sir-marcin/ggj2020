using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MeshMerger : MonoBehaviour
{
    [SerializeField] GameObject root;

    List<Mesh> meshes = new List<Mesh>();

    void Start()
    {
        var meshFilters = root.GetComponentsInChildren<MeshFilter>().ToList();

        foreach (var mr in meshFilters)
        {
            meshes.Add(mr.mesh);
        }
        
        var mesh = CombineMeshes(meshes);
        GetComponent<MeshFilter>().mesh = mesh;
        root.SetActive(false);
    }

    Mesh CombineMeshes(List<Mesh> meshes)
    {
        var combine = new CombineInstance[meshes.Count];
        for (int i = 0; i < meshes.Count; i++)
        {
            combine[i].mesh = meshes[i];
            combine[i].transform = transform.localToWorldMatrix;
        }

        var mesh = new Mesh();
        mesh.CombineMeshes(combine);
        return mesh;
    }
}