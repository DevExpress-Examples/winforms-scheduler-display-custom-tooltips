using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Drawing;

namespace SchedulerCustomTooltip {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            SetupCustomField();
            SetupSampleResource();
            SetupSampleAppointment();

            schedulerControl1.OptionsView.ToolTipVisibility = ToolTipVisibility.Always;
        }

        private void toolTipController1_BeforeShow(object sender, DevExpress.Utils.ToolTipControllerShowEventArgs e) {
            if (toolTipController1.ActiveObject is AppointmentViewInfo) {
                Appointment apt = ((AppointmentViewInfo)toolTipController1.ActiveObject).Appointment;

                e.ToolTipType = ToolTipType.SuperTip;

                SuperToolTip stt = new SuperToolTip();
                ToolTipTitleItem ttiTitle = new ToolTipTitleItem();
                ToolTipItem ttiBody = new ToolTipItem();
                ToolTipItem ttiFooter = new ToolTipItem();

                ttiTitle.Text = "Appointment";

                ttiBody.Text = string.Format("Subject: {0} \nDescription: {1}\nPrice: {2}",
                    apt.Subject, apt.Description, apt.CustomFields["cfPrice"]);

                ttiBody.Image = SystemIcons.Information.ToBitmap();

                ttiFooter.AllowHtmlText = DefaultBoolean.True;
                ttiFooter.Text = "<b>www.devexpress.com</b>";
                ttiFooter.Appearance.BackColor = Color.Red;
                ttiFooter.Appearance.ForeColor = Color.Blue;
                ttiFooter.LeftIndent = 30;

                stt.Items.Add(ttiTitle);
                stt.Items.AddSeparator();
                stt.Items.Add(ttiBody);
                stt.Items.AddSeparator();
                stt.Items.Add(ttiFooter);

                e.SuperTip = stt;
            }

            if (toolTipController1.ActiveObject is ResourceHeader) {
                Resource res = ((ResourceHeader)toolTipController1.ActiveObject).Resource;

                e.ToolTipType = ToolTipType.Standard;
                e.Rounded = true;

                e.Title = "Resource";
                e.ToolTip = res.Caption;
            }

            if (toolTipController1.ActiveObject is DayHeader || toolTipController1.ActiveObject is TimeScaleHeader) {
                TimeInterval interval = ((SchedulerHeader)toolTipController1.ActiveObject).Interval;

                e.ToolTipType = ToolTipType.Standard;
                e.IconType = ToolTipIconType.Exclamation;
                e.ShowBeak = true;
                e.Title = "TimeInterval";
                e.ToolTip = interval.ToString();
            }
        }

        private void SetupCustomField() {
            schedulerControl1.Storage.Appointments.CustomFieldMappings.Add(new AppointmentCustomFieldMapping("cfPrice", "Price"));
        }

        private void SetupSampleResource() {
            SchedulerStorage schedulerStorage = schedulerControl1.Storage;
            Resource res = schedulerStorage.CreateResource(0);

            res.Caption = "Resource1";

            schedulerStorage.Resources.Add(res);

            schedulerControl1.GroupType = SchedulerGroupType.Resource;
        }

        private void SetupSampleAppointment() {
            SchedulerStorage schedulerStorage = schedulerControl1.Storage;
            Appointment apt = schedulerStorage.CreateAppointment(AppointmentType.Normal);
            DateTime baseTime = DateTime.Today;

            apt.Start = baseTime.AddHours(1);
            apt.End = baseTime.AddHours(2);
            apt.Subject = "Test";
            apt.Location = "Office";
            apt.Description = "Test procedure";
            apt.CustomFields["cfPrice"] = 10;

            schedulerStorage.Appointments.Add(apt);

            schedulerControl1.Start = baseTime;
        }
    }
}