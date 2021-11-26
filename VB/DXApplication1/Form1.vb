Imports DevExpress.XtraScheduler
Imports System.ComponentModel

Namespace DXApplication1

    Public Partial Class Form1
        Inherits DevExpress.XtraBars.ToolbarForm.ToolbarForm

        Private CustomResourceCollection As BindingList(Of CustomResource) = New BindingList(Of CustomResource)()

        Private CustomEventList As BindingList(Of CustomAppointment) = New BindingList(Of CustomAppointment)()

        Public Sub New()
            InitializeComponent()
            InitHelper.InitResources(CustomResourceCollection)
            InitHelper.InitAppointments(CustomEventList, CustomResourceCollection)
            Dim mappingsResource As ResourceMappingInfo = schedulerDataStorage1.Resources.Mappings
            mappingsResource.Id = "ResID"
            mappingsResource.Caption = "Name"
            Dim mappingsAppointment As AppointmentMappingInfo = schedulerDataStorage1.Appointments.Mappings
            mappingsAppointment.Start = "StartTime"
            mappingsAppointment.End = "EndTime"
            mappingsAppointment.Subject = "Subject"
            mappingsAppointment.AllDay = "AllDay"
            mappingsAppointment.Description = "Description"
            mappingsAppointment.Label = "Label"
            mappingsAppointment.Location = "Location"
            mappingsAppointment.RecurrenceInfo = "RecurrenceInfo"
            mappingsAppointment.ReminderInfo = "ReminderInfo"
            mappingsAppointment.ResourceId = "OwnerId"
            mappingsAppointment.Status = "Status"
            mappingsAppointment.Type = "EventType"
            schedulerDataStorage1.Resources.DataSource = CustomResourceCollection
            schedulerDataStorage1.Appointments.DataSource = CustomEventList
            schedulerControl1.Start = Date.Today
        End Sub

        Private Sub barButtonItem1_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
            SerializationHelper.AppointmentSerialization(schedulerControl1)
        End Sub

        Private Sub barButtonItem2_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
            SerializationHelper.AppointmentDeserialization(schedulerControl1)
        End Sub
    End Class
End Namespace
