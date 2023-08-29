namespace MapEditorReborn.Patches.Optimizations
{
    using AdminToys;
    using HarmonyLib;
    using UnityEngine;

    [HarmonyPatch(typeof(AdminToyBase), nameof(AdminToyBase.UpdatePositionServer))]
    internal static class AdminToyBasePatch
    {
        private static bool Prefix(AdminToyBase __instance)
        {
            if (Optimization.WhiteList.Contains(__instance.gameObject))
            {
                var transform = __instance.transform;
                var rootTransform = transform.root;

                __instance.NetworkPosition = transform.position;
                __instance.NetworkRotation = new LowPrecisionQuaternion(transform.rotation);
                __instance.NetworkScale = rootTransform != transform
                    ? Vector3.Scale(transform.localScale, rootTransform.localScale)
                    : transform.localScale;
                return false;
            }

            // Меняем только локальную позицию для объектов
            // var transform = adminToy.transform;
            //
            // adminToy.Position = transform.position;
            // adminToy.Rotation = new LowPrecisionQuaternion(transform.rotation);
            // adminToy.Scale = transform.root != transform
            //     ? Vector3.Scale(transform.localScale, transform.root.localScale)
            //     : transform.localScale;

            return false;
        }
    }
}