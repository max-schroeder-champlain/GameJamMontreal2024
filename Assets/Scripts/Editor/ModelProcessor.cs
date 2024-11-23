using UnityEditor;
using UnityEngine;

public class ModelProcessor : AssetPostprocessor
{
    void OnPreprocessModel()
    {

        ModelImporter modelImporter = assetImporter as ModelImporter;
        modelImporter.materialImportMode = ModelImporterMaterialImportMode.None;

    }
}
