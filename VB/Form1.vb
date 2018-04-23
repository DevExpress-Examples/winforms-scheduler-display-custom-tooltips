Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.Utils
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraScheduler.Drawing

Namespace SchedulerCustomTooltip
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()

			SetupCustomField()
			SetupSampleResource()
			SetupSampleAppointment()

			schedulerControl1.OptionsView.ToolTipVisibility = ToolTipVisibility.Always
		End Sub

		Private Sub toolTipController1_BeforeShow(ByVal sender As Object, ByVal e As DevExpress.Utils.ToolTipControllerShowEventArgs) Handles toolTipController1.BeforeShow
			If TypeOf toolTipController1.ActiveObject Is AppointmentViewInfo Then
				Dim apt As Appointment = (CType(toolTipController1.ActiveObject, AppointmentViewInfo)).Appointment

				e.ToolTipType = ToolTipType.SuperTip

				Dim stt As New SuperToolTip()
				Dim ttiTitle As New ToolTipTitleItem()
				Dim ttiBody As New ToolTipItem()
				Dim ttiFooter As New ToolTipItem()

				ttiTitle.Text = "Appointment"

				ttiBody.Text = String.Format("Subject: {0} " & Constants.vbLf & "Description: {1}" & Constants.vbLf & "Price: {2}", apt.Subject, apt.Description, apt.CustomFields("cfPrice"))

				ttiBody.Image = SystemIcons.Information.ToBitmap()

				ttiFooter.AllowHtmlText = DefaultBoolean.True
				ttiFooter.Text = "<b>www.devexpress.com</b>"
				ttiFooter.Appearance.BackColor = Color.Red
				ttiFooter.Appearance.ForeColor = Color.Blue
				ttiFooter.LeftIndent = 30

				stt.Items.Add(ttiTitle)
				stt.Items.AddSeparator()
				stt.Items.Add(ttiBody)
				stt.Items.AddSeparator()
				stt.Items.Add(ttiFooter)

				e.SuperTip = stt
			End If

			If TypeOf toolTipController1.ActiveObject Is ResourceHeader Then
				Dim res As Resource = (CType(toolTipController1.ActiveObject, ResourceHeader)).Resource

				e.ToolTipType = ToolTipType.Standard
				e.Rounded = True

				e.Title = "Resource"
				e.ToolTip = res.Caption
			End If

			If TypeOf toolTipController1.ActiveObject Is DayHeader OrElse TypeOf toolTipController1.ActiveObject Is TimeScaleHeader Then
				Dim interval As TimeInterval = (CType(toolTipController1.ActiveObject, SchedulerHeader)).Interval

				e.ToolTipType = ToolTipType.Standard
				e.IconType = ToolTipIconType.Exclamation
				e.ShowBeak = True
				e.Title = "TimeInterval"
				e.ToolTip = interval.ToString()
			End If
		End Sub

		Private Sub SetupCustomField()
			schedulerControl1.Storage.Appointments.CustomFieldMappings.Add(New AppointmentCustomFieldMapping("cfPrice", "Price"))
		End Sub

		Private Sub SetupSampleResource()
			Dim schedulerStorage As SchedulerStorage = schedulerControl1.Storage
			Dim res As Resource = schedulerStorage.CreateResource(0)

			res.Caption = "Resource1"

			schedulerStorage.Resources.Add(res)

			schedulerControl1.GroupType = SchedulerGroupType.Resource
		End Sub

		Private Sub SetupSampleAppointment()
			Dim schedulerStorage As SchedulerStorage = schedulerControl1.Storage
			Dim apt As Appointment = schedulerStorage.CreateAppointment(AppointmentType.Normal)
			Dim baseTime As DateTime = DateTime.Today

			apt.Start = baseTime.AddHours(1)
			apt.End = baseTime.AddHours(2)
			apt.Subject = "Test"
			apt.Location = "Office"
			apt.Description = "Test procedure"
			apt.CustomFields("cfPrice") = 10

			schedulerStorage.Appointments.Add(apt)

			schedulerControl1.Start = baseTime
		End Sub
	End Class
End Namespace