using Liquid.Messaging.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liquid.Debug.Domain.Entities
{
    [SettingsName("test")]
    [Serializable]
    public class SampleMessage
    {
        public int Id { get; set; }
        public string MyProperty { get; set; }
    }
}
