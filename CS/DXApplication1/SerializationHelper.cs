using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication1
{
    class SerializationHelper
    {
        static List<string> serializedAppointments = new List<string>();
        public static void AppointmentSerialization(SchedulerControl scheduler)
        {
            #region #AppointmentSerialization
            SchedulerCompatibility.Base64XmlObjectSerialization = true;
            foreach (Appointment apt in scheduler.ActiveView.GetAppointments())
            {
                AppointmentXmlPersistenceHelper helper =
                    new AppointmentXmlPersistenceHelper(apt, null);
                serializedAppointments.Add(helper.ToXml());
            }
            scheduler.DataStorage.Appointments.Clear();
            #endregion #AppointmentSerialization
        }

        public static void AppointmentDeserialization(SchedulerControl scheduler)
        {
            #region #AppointmentDeserialization
            if (serializedAppointments.Count > 0)
            {
                foreach (string xmlAppointment in serializedAppointments)
                {
                    Appointment objAppointment = AppointmentXmlPersistenceHelper.ObjectFromXml(scheduler.DataStorage.Appointments, xmlAppointment);
                    scheduler.DataStorage.Appointments.Add(objAppointment);
                    scheduler.Start = DateTime.Today;
                }
            }
            serializedAppointments.Clear();
            #endregion #AppointmentDeserialization
        }
    }
}
