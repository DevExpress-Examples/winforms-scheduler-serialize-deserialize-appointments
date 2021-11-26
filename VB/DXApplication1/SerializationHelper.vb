Imports DevExpress.XtraScheduler
Imports DevExpress.XtraScheduler.Xml
Imports System.Collections.Generic

Namespace DXApplication1

    Friend Class SerializationHelper

        Private Shared serializedAppointments As List(Of String) = New List(Of String)()

        Public Shared Sub AppointmentSerialization(ByVal scheduler As SchedulerControl)
'#Region "#AppointmentSerialization"
            SchedulerCompatibility.Base64XmlObjectSerialization = True
            For Each apt As Appointment In scheduler.ActiveView.GetAppointments()
                Dim helper As AppointmentXmlPersistenceHelper = New AppointmentXmlPersistenceHelper(apt, Nothing)
                Call serializedAppointments.Add(helper.ToXml())
            Next

            scheduler.DataStorage.Appointments.Clear()
'#End Region  ' #AppointmentSerialization
        End Sub

        Public Shared Sub AppointmentDeserialization(ByVal scheduler As SchedulerControl)
'#Region "#AppointmentDeserialization"
            If serializedAppointments.Count > 0 Then
                For Each xmlAppointment As String In serializedAppointments
                    Dim objAppointment As Appointment = AppointmentXmlPersistenceHelper.ObjectFromXml(scheduler.DataStorage.Appointments, xmlAppointment)
                    scheduler.DataStorage.Appointments.Add(objAppointment)
                    scheduler.Start = Date.Today
                Next
            End If

            Call serializedAppointments.Clear()
'#End Region  ' #AppointmentDeserialization
        End Sub
    End Class
End Namespace
