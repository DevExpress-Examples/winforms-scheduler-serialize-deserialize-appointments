using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DXApplication1
{
    public partial class Form1 : DevExpress.XtraBars.ToolbarForm.ToolbarForm
    {

        BindingList<CustomResource> CustomResourceCollection = new BindingList<CustomResource>();
        BindingList<CustomAppointment> CustomEventList = new BindingList<CustomAppointment>();
        public Form1()
        {
            InitializeComponent();

            InitHelper.InitResources(CustomResourceCollection);
            InitHelper.InitAppointments(CustomEventList, CustomResourceCollection);

            ResourceMappingInfo mappingsResource = this.schedulerDataStorage1.Resources.Mappings;
            mappingsResource.Id = "ResID";
            mappingsResource.Caption = "Name";

            AppointmentMappingInfo mappingsAppointment = this.schedulerDataStorage1.Appointments.Mappings;
            mappingsAppointment.Start = "StartTime";
            mappingsAppointment.End = "EndTime";
            mappingsAppointment.Subject = "Subject";
            mappingsAppointment.AllDay = "AllDay";
            mappingsAppointment.Description = "Description";
            mappingsAppointment.Label = "Label";
            mappingsAppointment.Location = "Location";
            mappingsAppointment.RecurrenceInfo = "RecurrenceInfo";
            mappingsAppointment.ReminderInfo = "ReminderInfo";
            mappingsAppointment.ResourceId = "OwnerId";
            mappingsAppointment.Status = "Status";
            mappingsAppointment.Type = "EventType";

            schedulerDataStorage1.Resources.DataSource = CustomResourceCollection;
            schedulerDataStorage1.Appointments.DataSource = CustomEventList;
            schedulerControl1.Start = DateTime.Today;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SerializationHelper.AppointmentSerialization(schedulerControl1);
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SerializationHelper.AppointmentDeserialization(schedulerControl1);
        }
    }
}
