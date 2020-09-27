using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets
{
    public static class GlobalDictionaries
    {
        private static  Dictionary<string, Enemy> _enemyCatalog = new Dictionary<string, Enemy>();
        private static Dictionary<string, Player> _playerCatalog = new Dictionary<string, Player>();
        private static object _playerCatalogLock = new object();
        private static object _enemyCatalogLock =new object();

        #region Player Dictionary Methods
        public static Player GetPlayer(string name)
        {
            if (_playerCatalog.TryGetValue(name, out Player result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public static void AddPlayer(string name, Player player)
        {
            lock (_playerCatalogLock)
            {
                if (_playerCatalog.ContainsKey(name))
                {
                    var possibleDuplicate = GetPlayer(name);
                    if (player.Equals(possibleDuplicate))
                    {
                        Debug.LogWarning($"{name} object already added. It's a duplicate");
                        return;
                    }
                    else
                    {
                        int count = _playerCatalog.Count;
                        name = $"{name}_{count}";
                        Debug.Log($"Key changed to  because of duplicate naming");
                        _playerCatalog.Add(name, player);
                        return;
                    }
                }
                _playerCatalog.Add(name, player);
            }
        }

        public static void RemovePlayer(string name)
        {
            lock (_playerCatalogLock)
            {
                if (_playerCatalog.ContainsKey(name))
                {
                    _playerCatalog.Remove(name);
                }
            }
        }

        public static string[] GetPlayerKeys()
        {
            lock (_playerCatalogLock)
            {
                string[] results = new string[_playerCatalog.Count];
                _playerCatalog.Keys.CopyTo(results, 0);
                return results;
            }
        }

        private static void ClearPlayerCatalog()
        {
            lock (_playerCatalogLock)
            {
                _playerCatalog.Clear();
            }
        }

        #endregion

        #region Enemy Catalog Methods
        public static Enemy GetEnemy(string name)
        {
            if (_enemyCatalog.TryGetValue(name, out Enemy result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public static void AddEnemy(string name, Enemy enemy)
        {
            lock (_enemyCatalogLock)
            {
                if (_enemyCatalog.ContainsKey(name))
                {
                    var possibleDuplicate = GetEnemy(name);
                    if (enemy.Equals(possibleDuplicate))
                    {
                        Debug.LogWarning($"{name} object already added. It's a duplicate");
                        return;
                    }
                    else
                    {
                        int count = _enemyCatalog.Count;
                        name = $"{name}_{count}";
                        Debug.Log($"Key changed to  because of duplicate naming");
                        _enemyCatalog.Add(name, enemy);
                        return;
                    }
                }
                _enemyCatalog.Add(name, enemy);
            }
        }
        public static void RemoveEnemy(string name)
        {
            lock (_enemyCatalogLock)
            {
                if (_enemyCatalog.ContainsKey(name))
                {
                    _enemyCatalog.Remove(name);
                }
            }
        }

        public static string[] GetEnemyKeys()
        {
            lock (_enemyCatalogLock)
            {
                string[] results = new string[_enemyCatalog.Count];
                _enemyCatalog.Keys.CopyTo(results, 0);
                return results;
            }
        }

        private static void ClearEnemyCatalog()
        {
            lock (_enemyCatalog)
            {
                _enemyCatalog.Clear();
            }
        }

        #endregion

        public static void ClearAllDictionaries()
        {
            ClearPlayerCatalog();
            ClearEnemyCatalog();
        }

    }
}