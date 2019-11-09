using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode]
public class SaveAssetWithNameAfterTimeHasPassed : Singleton<SaveAssetWithNameAfterTimeHasPassed>
{
#if UNITY_EDITOR
    public UnityEngine.Object assetToSave;
    public string nameToRenameTo;
    public float timeSinceLastRename = 0f;

    public float renameAfterSecondsPassed = 1f;
    public Coroutine coroutineId = null;

    protected virtual void OnEnable()
    {
#if UNITY_EDITOR
        EditorApplication.update += OnEditorUpdate;
#endif
    }

    protected virtual void OnDisable()
    {
#if UNITY_EDITOR
        EditorApplication.update -= OnEditorUpdate;
#endif
    }

    protected virtual void OnEditorUpdate()
    {
        if (Time.realtimeSinceStartup >= timeSinceLastRename + renameAfterSecondsPassed && assetToSave != null)
        {
            RenameAsset();
        }
    }

    public void ScheduleAssetRename(UnityEngine.Object asset, string newName)
    {
        if (coroutineId != null) { StopCoroutine(coroutineId); }

        if (assetToSave != null && assetToSave != asset)
        {
            RenameAsset();
        }

        assetToSave = asset;
        nameToRenameTo = newName;
        timeSinceLastRename = Time.realtimeSinceStartup;
    }

    private void RenameAsset()
    {
        AssetDatabase.RenameAsset(AssetDatabase.GetAssetPath(assetToSave), nameToRenameTo);
        assetToSave = null;
    }
#endif
}