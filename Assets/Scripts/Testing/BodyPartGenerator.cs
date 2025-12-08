// using UnityEngine;
// using UnityEditor;
// using Classes.Bodyparts;
// using System;
// using System.Linq;
// using System.Reflection;

// public class BodyPartItemGenerator
// {
//     [MenuItem("Tools/Generate BodyPart Items")]
//     public static void Generate()
//     {
//         var bodyPartTypes = Assembly.GetAssembly(typeof(BodyPart))
//             .GetTypes()
//             .Where(t => t.IsSubclassOf(typeof(BodyPart)) && !t.IsAbstract);

//         foreach (var type in bodyPartTypes)
//         {
//             BodyPartItem item = ScriptableObject.CreateInstance<BodyPartItem>();
//             item.bodyPartType = type;
//             item.itemName = type.Name;
//             // Optionally: assign icon via Resources.Load<Sprite>($"Sprites/{type.Name}");

//             AssetDatabase.CreateAsset(item, $"Assets/Inventory/BodyPartItems/{type.Name}Item.asset");
//         }

//         AssetDatabase.SaveAssets();
//         Debug.Log("Generated BodyPartItems for all BodyPart classes!");
//     }
// }