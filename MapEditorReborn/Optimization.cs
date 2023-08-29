using System.Collections.Generic;
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
            WhiteList.Add(gameObject);

            foreach (var child in gameObject.GetComponentsInChildren<Component>())
            {
                WhiteList.Add(child.gameObject);
            }
        }
    }
}