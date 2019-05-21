using System;
using System.Collections.Generic;
using AdvancedScada.DriverBase.Client;
using AdvancedScada.DriverBase.Devices;
using AdvancedScada.IBaseService;

namespace AdvancedScada.BaseService
{
    public class ReadServiceCallbackClient : IServiceCallback
    {
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