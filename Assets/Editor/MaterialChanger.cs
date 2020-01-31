using UnityEngine;
using UnityEditor;
using System.Collections;

class MyWindow : EditorWindow
{
    Material material;

    [MenuItem("Window/My Window")]
    public static void  ShowWindow () {
        EditorWindow.GetWindow(typeof(MyWindow));
    }
    
    void OnGUI ()
    {
        material = EditorGUILayout.ObjectField("Material", material, typeof(Material)) as Material;

        if (GUILayout.Button("Replace"))
        {
            ReplaceMaterials();
        }
    }

    void ReplaceMaterials()
    {
        if (material == null)
        {
            Debug.Log("Material is not assigned");
            return;
        }

        var all = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        Debug.Log(all.Length);

        for (int i = 0; i < all.Length; i++)
        {
            var current = all[i];
            var meshRenderer = current.GetComponent<MeshRenderer>();

            if (meshRenderer == null)
            {
                continue;
            }

            var materials = meshRenderer.materials;

            for (int j = 0; j < materials.Length; j++)
            {
                materials[j] = material;
            }

            meshRenderer.materials = materials;
        }
    }
}