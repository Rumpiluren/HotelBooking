using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.HotelBooking.UI.Event
{
    public class AfterSavedEvent : PubSubEvent<InfoAboutChangedEntityArgs>
    {
    }

    public class InfoAboutChangedEntityArgs
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
