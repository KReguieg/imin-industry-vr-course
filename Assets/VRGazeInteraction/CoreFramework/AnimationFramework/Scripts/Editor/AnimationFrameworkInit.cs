using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;


public class AnimationFrameworkInit : EditorWindow
{
    [MenuItem("VRGazeInteraction/Generate Profiles")]
    public static void Initialize()
    {

        //TODO: Change the creation of profiles to GetEnumerableOfType instead of hard coding
        ScaleProfile scaleProfile = ScriptableObject.CreateInstance<ScaleProfile>();
        AssetDatabase.CreateAsset(scaleProfile, "Assets/VRGazeInteraction/CoreFramework/AnimationFramework/Profiles/ScaleProfile.asset");

        MoveProfile moveProfile = ScriptableObject.CreateInstance<MoveProfile>();
        AssetDatabase.CreateAsset(moveProfile, "Assets/VRGazeInteraction/CoreFramework/AnimationFramework/Profiles/MoveProfile.asset");

        LightProfile lightProfile = ScriptableObject.CreateInstance<LightProfile>();
        AssetDatabase.CreateAsset(lightProfile, "Assets/VRGazeInteraction/CoreFramework/AnimationFramework/Profiles/LightProfile.asset");


        AssetDatabase.SaveAssets();
        Debug.Log("AnimationFramework initialized");

    }

}

//public static class ReflectiveEnumerator
//{
//    static ReflectiveEnumerator() { }

//    public static IEnumerable<T> GetEnumerableOfType<T>(params object[] constructorArgs) where T : class, IComparable<T>
//    {
//        List<T> objects = new List<T>();
//        foreach (Type type in
//            Assembly.GetAssembly(typeof(T)).GetTypes()
//            .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T))))
//        {
//            objects.Add((T)Activator.CreateInstance(type, constructorArgs));
//        }
//        objects.Sort();
//        return objects;
//    }
//}