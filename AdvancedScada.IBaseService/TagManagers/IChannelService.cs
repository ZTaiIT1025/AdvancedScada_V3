using AdvancedScada.DriverBase.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Xml;

namespace AdvancedScada.IBaseService.TagManagers
{
    
    [ServiceContract]
    public interface IChannelService
    {
        [OperationContract]
         void Add(Channel ch);

        [OperationContract]
         void CreatFile(string pathXml);

        [OperationContract]
         void DeleteByChannel(Channel ch);

        [OperationContract]
         void DeleteByID(int chId);

        [OperationContract]
         void DeleteByName(string chName);

        [OperationContract]
         Channel GetByChannelId(int chId);

        [OperationContract]
         Channel GetByChannelName(string chName);

        [OperationContract]
        List<Channel> GetChannels();
        [OperationContract]
         Channel IsExisted(Channel ch);

        [OperationContract]
         string ReadKey(string keyName);
        [OperationContract]
         void Save(string pathXml);
        [OperationContract]
         void Update(Channel ch);

        [OperationContract]
         void WriteKey(string keyName, string keyValue);

         List<Channel> Channels { get ; set; }

    }
}
