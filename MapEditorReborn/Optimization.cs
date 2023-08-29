using System;
using System.Collections.Generic;
using Exiled.API.Features;
using UnityEngine;

namespace MapEditorReborn
{
    public static class Optimization
    {
        /// <summary>
        /// Примерное количество объектов
        /// </summary>
        private const int HashSetSize = 1000;

        /// <summary>
        /// Список разрешённых к обновлению позиции объектов
        /// </summary>
        public static readonly HashSet<GameObject> WhiteList = new(HashSetSize);

        /// <summary>
        /// Добавляет объект и все его дочерние объекты в белый список
        /// </summary>
        /// <param name="gameObject">Объект</param>
        public static void AddToWhiteList(GameObject gameObject)
        {
            try
            {
                WhiteList.Add(gameObject);

                foreach (var child in gameObject.GetComponentsInChildren<Component>())
                {
                    if (child is { gameObject: not null })
                    {
                        WhiteList.Add(child.gameObject);
                    }
                }
            }
            catch (Exception error)
            {
                Log.Error(error);
            }
        }
    }
}