using UnityEditor;
using System.Collections;

public class BundleCreate
{

    [MenuItem("Simple Bundles/BuildBut")]
    static void BuildBundles()
    {
        string path = EditorUtility.SaveFolderPanel("Save Bundle", "", "");  //Отображает диалоговое окно "Сохранить Папку" и возвращается
        if (path.Length != 0)
        {
            BuildPipeline.BuildAssetBundles(path, BuildAssetBundleOptions.None, BuildTarget.Android);
        }
    }
}