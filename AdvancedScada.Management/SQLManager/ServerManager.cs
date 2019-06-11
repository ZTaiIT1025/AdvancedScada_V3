using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Win32;
using static AdvancedScada.IBaseService.Common.XCollection;

namespace AdvancedScada.Management.SQLManager
{
    public class ServerManager
    {

        public const string ROOT = "Root";
        public const string Server = "Server";
        public const string Server_ID = "ServerId";
        public const string Server_NAME = "ServerName";
        public const string User_Name = "UserName";
        public const string Passwerd = "Passwerd";
        public const string DESCRIPTION = "Description";
        public const string XML_NAME_DEFAULT = "SQLCollection";
        private static readonly object mutex = new object();
        private static ServerManager _instance;

        public string XmlPath { set; get; }
        public List<Server> SQLServers { get; set; } = new List<Server>();

        public static ServerManager GetServerManager()
        {
            lock (mutex)
            {
                if (_instance == null) _instance = new ServerManager();
            }

            return _instance;
        }


        public void Add(Server SQ)
        {
            try
            {
                if (SQ == null) throw new NullReferenceException("The SQLServer is null reference exception");
                var fCh = IsExisted(SQ);
                if (fCh != null) throw new Exception($"SQLServer name: '{SQ.ServerName}' is existed");
                SQLServers.Add(SQ);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Server IsExisted(Server ch)
        {
            Server result = null;
            try
            {
                foreach (var item in SQLServers)
                    if (item.ServerId != ch.ServerId && item.ServerName.Equals(ch.ServerName))
                    {
                        result = item;
                        break;
                    }
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }

            return result;
        }

        public void Update(Server ch)
        {
            try
            {
                if (ch == null) throw new NullReferenceException("The SQLServer is null reference exception");
                var fCh = IsExisted(ch);
                if (fCh != null) throw new Exception($"SQLServer name: '{ch.ServerName}' is existed");
                foreach (var item in SQLServers)
                    if (item.ServerId == ch.ServerId)
                    {
                        item.ServerName = ch.ServerName;
                        item.Description = ch.Description;
                        item.Passwerd = ch.Passwerd;
                        item.UserName = ch.UserName;
                        item.ServerId = ch.ServerId;

                    }
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }
        public void Delete(int chId)
        {
            try
            {
                var result = GetBySQLServerId(chId);
                if (result == null) throw new KeyNotFoundException("SQLServer Id is not found exception");
                SQLServers.Remove(result);
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        /// <summary>
        ///     Xóa kênh.
        /// </summary>
        /// <param name="chName">Tên kênh</param>
        public void Delete(string chName)
        {
            try
            {
                var result = GetBySQLServerName(chName);
                if (result == null) throw new KeyNotFoundException("SQLServer name is not found exception");
                SQLServers.Remove(result);
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        /// <summary>
        ///     Xóa kênh.
        /// </summary>
        /// <param name="ch">Kênh</param>
        public void Delete(Server ch)
        {
            try
            {
                if (ch == null) throw new NullReferenceException("The SQLServer is null reference exception");
                foreach (var item in SQLServers)
                    if (item.ServerId == ch.ServerId)
                    {
                        SQLServers.Remove(item);
                        break;
                    }
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }
        public Server GetBySQLServerId(int chId)
        {
            Server result = null;
            try
            {
                foreach (var item in SQLServers)
                    if (item.ServerId == chId)
                    {
                        result = item;
                        break;
                    }
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
            return result;
        }

        /// <summary>
        ///     Tìm kiếm kênh theo tên kênh.
        /// </summary>
        /// <param name="chName">Tên kênh</param>
        /// <returns>Kênh</returns>
        public Server GetBySQLServerName(string chName)
        {
            Server result = null;
            try
            {
                foreach (var item in SQLServers)
                    if (item.ServerName.Equals(chName))
                    {
                        result = item;
                        break;
                    }
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }

            return result;
        }
        public List<Server> GetServers(string XmlPath)
        {
            try
            {
                var xmlDoc = new XmlDocument();
                if (string.IsNullOrEmpty(XmlPath) || string.IsNullOrWhiteSpace(XmlPath))
                    XmlPath = ReadKey(XML_NAME_DEFAULT);
                xmlDoc.Load(XmlPath);
                var nodes = xmlDoc.SelectNodes(ROOT);
                foreach (XmlNode rootNode in nodes)
                {
                    var channelNodeList = rootNode.SelectNodes(Server);
                    foreach (XmlNode chNode in channelNodeList)
                    {
                        var newServer = new Server();


                        if (newServer != null)
                        {
                            newServer.ServerId = int.Parse(chNode.Attributes[Server_ID].Value);
                            newServer.ServerName = chNode.Attributes[Server_NAME].Value;
                            newServer.UserName = chNode.Attributes[User_Name].Value;
                            newServer.Passwerd = int.Parse(chNode.Attributes[Passwerd].Value);
                            newServer.Description = chNode.Attributes[DESCRIPTION].Value;
                            newServer.DataBase = DataBaseManager.GetDevices(chNode);
                            SQLServers.Add(newServer);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }

            return SQLServers;
        }
        public void CreatFile(string pathXml)
        {
            try
            {
                if (File.Exists(pathXml)) File.Delete(pathXml);
                var element = new XElement(ROOT);
                var doc = new XDocument(element);
                doc.Save(pathXml);
                XmlPath = pathXml;
                WriteKey(XML_NAME_DEFAULT, pathXml);
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        /// <summary>
        ///     Phương thức đọc key.
        /// </summary>
        /// <param name="keyName">Tên key</param>
        /// <returns>Giá trị của key</returns>
        public string ReadKey(string keyName)
        {
            var result = string.Empty;
            try
            {
                RegistryKey regKey;
                regKey = Registry.CurrentUser.OpenSubKey(@"Software\IndustrialHMI"); //HKEY_CURRENR_USER\Software\VSSCD
                if (regKey != null) result = (string)regKey.GetValue(keyName);
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }

            return result;
        }

        /// <summary>
        ///     Phương thức ghi tên và giá trị của key
        /// </summary>
        /// <param name="keyName">Tên key</param>
        /// <param name="keyValue">Giá trị của key</param>
        public void WriteKey(string keyName, string keyValue)
        {
            try
            {
                RegistryKey regKey;
                regKey = Registry.CurrentUser.CreateSubKey(@"Software\IndustrialHMI");
                regKey.SetValue(keyName, keyValue);
                regKey.Close();
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }
        public void Save(string pathXml)
        {
            try
            {
                WriteKey(XML_NAME_DEFAULT, pathXml);
                CreatFile(pathXml);
                XmlPath = pathXml;
                var xmlDoc = new XmlDocument();
                xmlDoc.Load(pathXml);
                var root = xmlDoc.SelectSingleNode(ROOT);

                // List SQLServers.
                foreach (var ch in SQLServers)
                {
                    var chElement = xmlDoc.CreateElement(Server);
                    chElement.SetAttribute(Server_ID, $"{ch.ServerId}");
                    chElement.SetAttribute(Server_NAME, ch.ServerName);
                    chElement.SetAttribute(User_Name, ch.UserName);
                    chElement.SetAttribute(Passwerd, $"{ch.Passwerd}");
                    chElement.SetAttribute(DESCRIPTION, ch.Description);
                    root.AppendChild(chElement);
                    if (ch.DataBase.Count == 0) continue;

                    // List DataBase.
                    foreach (var dv in ch.DataBase)
                    {
                        var dvElement = xmlDoc.CreateElement(DataBaseManager.DataBase);
                        dvElement.SetAttribute(DataBaseManager.DataBase_ID, $"{dv.DataBaseId}");
                        dvElement.SetAttribute(DataBaseManager.DataBase_NAME, dv.DataBaseName);
                        dvElement.SetAttribute(DESCRIPTION, dv.Description);
                        chElement.AppendChild(dvElement);
                        if (dv.Tables.Count == 0) continue;
                        // List Tables.
                        foreach (var db in dv.Tables)
                        {
                            var dbElement = xmlDoc.CreateElement(TableManager.Tabled);
                            dbElement.SetAttribute(TableManager.Table_ID, $"{db.TableId}");
                            dbElement.SetAttribute(TableManager.Table_NAME, db.TableName);
                            dbElement.SetAttribute(DESCRIPTION, db.Description);
                            dvElement.AppendChild(dbElement);

                            // List Columns.
                            foreach (var tg in db.Columns)
                            {
                                var tgElement = xmlDoc.CreateElement(ColumnManager.Column);
                                tgElement.SetAttribute(ColumnManager.Column_ID, $"{tg.ColumnId}");
                                tgElement.SetAttribute(ColumnManager.TAG_NAME, tg.TagName);
                                tgElement.SetAttribute(ColumnManager.Column_NAME, $"{tg.ColumnName}");
                                tgElement.SetAttribute(ColumnManager.Channel, $"{tg.Channel}");
                                tgElement.SetAttribute(ColumnManager.Device, $"{tg.Device}");
                                tgElement.SetAttribute(ColumnManager.DataBlock, $"{tg.DataBlock}");
                                tgElement.SetAttribute(ColumnManager.Mode, $"{tg.Mode}");
                                tgElement.SetAttribute(ColumnManager.TriggerType, $"{tg.TriggerType}");
                                tgElement.SetAttribute(DESCRIPTION, tg.Description);
                                dbElement.AppendChild(tgElement);
                            }
                        }
                    }
                }

                xmlDoc.Save(pathXml);
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }
    }

}