using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    Animator anim;
    public Canvas MainMenu;
    public Camera MainCamera;
    public Canvas LoadingCanvas;
    public Button PlayButton;
    public Button BackButton;
    public Button SettingsButton;
    //    private const string SEC_SCENE = "Test";
    public string BundleName;
    public string SceneName;

    public string ManifestName;
    AssetBundleManifest manifest;

    // Use this for initialization

    public IEnumerator LoadBund()
    {

        //using (WWW www = new WWW("https://www.dropbox.com/sh/cebpfvejbvxeaqn/AADFevCm8En9Qu8d0_QkfBSxa?dl=0" + ManifestName))
        //{
        //    yield return www;

        //    if (!string.IsNullOrEmpty(www.error))
        //    {
        //        Debug.Log(www.error);
        //        yield break;

        //    }


        //    manifest = (AssetBundleManifest)www.assetBundle.LoadAsset("AssetBundleManifest") ;
        //    yield return null;
        //    www.assetBundle.Unload(false);

        //}

        using (WWW www = WWW.LoadFromCacheOrDownload("https://www.dropbox.com/sh/cebpfvejbvxeaqn/AADFevCm8En9Qu8d0_QkfBSxa?dl=0" + BundleName,0/* manifest.GetAssetBundleHash(BundleName)*/))
        {
            yield return www;

            if (!string.IsNullOrEmpty(www.error))
            {
                Debug.Log(www.error);
                yield break;
            }
            SceneManager.LoadScene(SceneName);
            yield return null;
            www.assetBundle.Unload(false);

            
        }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        MainMenu = MainMenu.GetComponent<Canvas>();
        PlayButton = PlayButton.GetComponent<Button>();
        SettingsButton = SettingsButton.GetComponent<Button>();
        BackButton = BackButton.GetComponent<Button>();
        LoadingCanvas = LoadingCanvas.GetComponent<Canvas>();
        MainCamera = MainCamera.GetComponent<Camera>();
        LoadingCanvas.enabled = false;
        anim.enabled = false;
    }

    public void StartGame()
    {
        anim.SetBool("Play", true);
        LoadingCanvas.enabled = true;
        MainMenu.enabled = false;
        StartCoroutine(LoadBund());

 //       SceneManager.LoadScene(SEC_SCENE);
        
    }

    public void ConfigureSettings()
    {
        BackButton.enabled = true;
        PlayButton.enabled = false;
        SettingsButton.enabled = false;
        anim.SetBool("Run", false);
        anim.enabled = true;
    }

    public void BackToMainMenu()
    {
        BackButton.enabled = false;
        PlayButton.enabled = true;
        SettingsButton.enabled = true;
        anim.SetBool("Run", true);
    }
}
