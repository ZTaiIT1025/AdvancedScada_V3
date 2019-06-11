using System;
using System.Collections.Generic;
using System.ServiceModel;
using AdvancedScada.DriverBase.Client;
using AdvancedScada.DriverBase.Devices;
using AdvancedScada.IBaseService;
using AdvancedScada.Management.BLManager;
using static AdvancedScada.IBaseService.Common.XCollection;

namespace AdvancedScada.BaseService
{
    [CallbackBehavior(UseSynchronizationContext = true)]
    public class ReadServiceCallbackClient : IServiceCallback
    {
        public static bool LoadTagCollection()
        {
            
           var  objChannelManager = ChannelService.GetChannelManager();

                try
                {

                    var xmlFile = objChannelManager.ReadKey(objChannelManager.XML_NAME_DEFAULT);
                    if (string.IsNullOrEmpty(xmlFile) || string.IsNullOrWhiteSpace(xmlFile))
                    {
                        return false;
                    }

                    objChannelManager.Channels.Clear();
                    TagCollectionClient.Tags.Clear();
                    var channels = objChannelManager.GetChannels(xmlFile);

                    foreach (var ch in channels)
                        foreach (var dv in ch.Devices)
                            foreach (var db in dv.DataBlocks)
                                foreach (var tg in db.Tags)
                                    TagCollectionClient.Tags.Add(
                                        $"{ch.ChannelName}.{dv.DeviceName}.{db.DataBlockName}.{tg.TagName}", tg);
                }
                catch (Exception ex)
                {
               EventscadaException?.Invoke("ReadServiceCallbackClient", ex.Message);
                }
           

            return true;
        }

        public void DataTags(Dictionary<string, Tag> Tags)
        {
            var tagsClient = TagCollectionClient.Tags;
            if (tagsClient == null) throw new ArgumentNullException(nameof(tagsClient));
            foreach (var author in Tags)
                if (tagsClient.ContainsKey(author.Key))
                {
                    tagsClient[author.Key].Value = author.Value.Value;
                    tagsClient[author.Key].Checked = author.Value.Checked;
                    tagsClient[author.Key].Enabled = author.Value.Enabled;
                    tagsClient[author.Key].ValueSelect1 = author.Value.ValueSelect1;
                    tagsClient[author.Key].ValueSelect2 = author.Value.ValueSelect2;
                    tagsClient[author.Key].Visible = author.Value.Visible;
                    tagsClient[author.Key].Timestamp = author.Value.Timestamp;
                }
        }
    }
}